using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

/// <summary>
/// ・WinMaintenance(Ver0.01) C#7.3
/// ・Formのフロントエンドの動作全般を記述している
/// </summary>
/// <see cref="System"/>
/// <see cref="System.Threading.Tasks"/>
/// <see cref="System.Windows.Forms"/>
/// <see cref="System.Threading"/>

namespace WinMaintenance
{
    public partial class Main : Form
    {
        /// <summary>
        /// intを引数とするDelegate型 delInt
        /// </summary>
        /// <param name="value">intの引数を受け取る</param>
        delegate void delInt(int value);

        /// <summary>
        /// stringを引数とするDelegate型 delStr
        /// </summary>
        /// <param name="value">stringの引数を受け取る</param>
        delegate void delStr(string value);

        /// <summary>
        /// trueになるとCPUとメモリ使用容量を無限ループで取得するループを抜けるようにする(予定) ※なぜか動かん
        /// </summary>
        /// <param name="formEnd_Flg">trueでループEnd</param>
        bool formEnd_Flg = false;

        /// <summary>
        /// なんか処理を別にしないとフォーム固まる(Task.Runの中でできない件)
        /// ここにはInvoke処理でFormの値が変更される処理を書くところ
        /// </summary>
        private void setCpuProgressValue(int cpuUsePer)
        {
            cpuProgress.Value = cpuUsePer;
            cpuUsePerLabel.Text = cpuUsePer.ToString() + "％ Use";
        }
        private void setMemoryProgressValue(int memoryUseCapa)
        {
            memoryProgress.Value = memoryUseCapa;

            memUsePerLabel.Text = Convert.ToString((Math.Floor((double)memoryUseCapa / memoryProgress.Maximum * 100.00))) + "％ Use";
        }
        private void setMaxMemoryProgressValue(int memoryMaxValue) 
        {
            memoryProgress.Maximum = memoryMaxValue;
        }
        private void setMemoryAvailableLabelText(string memoryAvailableLabelText)
        {
            memoryAvailableLabel.Text = memoryAvailableLabelText;
        }
        /// <summary>
        /// ここにはInvoke処理でFormの値が変更される処理を書くところ ～End～
        /// </summary>
        

        public Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// AutoPropsへWmiの引き出したい情報を代入して、InvokeでDelegateのメソッドへ代入してFormの値を変更させるメソッド(下記二つのメソッド)
        /// </summary>
        /// <returns>正常終了した際にint型の0を返す</returns>
        private int cpuUsePercentChange()
        {
            // プロパティを設定してWmiから情報を抜き出す
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "LoadPercentage";
            Thread.Sleep(500);

            // Formに取得した値をFormに代入する
            Invoke(new delInt(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
            return 0;
        }
        private int memoryUsePercentChange()
        {
            // プロパティを設定してWmiから情報を抜き出す
            AutoProps.managementClass = "Win32_OperatingSystem";
            AutoProps.classProperty = "TotalVisibleMemorySize";

            // メモリ最大を○○.○GB表記にするために計算結果をdoubleParceしてから変数に代入している
            var maxMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10);

            AutoProps.classProperty = "FreePhysicalMemory";

            // 空きメモリ容量を 〃
            var freeMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) /10);

            /* 値の確認テスト用
            MessageBox.Show(maxMemory.ToString());
            MessageBox.Show(freeMemory.ToString());
            */

            // Formに取得した値をFormに代入する
            Invoke(new delInt(setMaxMemoryProgressValue), Convert.ToInt32(maxMemory * 10));
            Invoke(new delInt(setMemoryProgressValue), (memoryProgress.Maximum - Convert.ToInt32(freeMemory * 10)));
            Invoke(new delStr(setMemoryAvailableLabelText), ("UseMem" + maxMemory + " / " + (maxMemory - freeMemory).ToString()));

            return 0;
        }

        /// <summary>
        /// メインフォームがロードされる時にに動作するメソッド
        /// ・CPU名を出す
        /// ・memUsePerTaskを生成し、別スレッドにてメモリの使用量をFormで出す(ProgressBar、Label)
        /// ・cpuUsePerTaskを生成し、〃
        /// ・"Task.WhenAll"は処理終わるまで待ってる(理由はAutoProps.managementClassとAutoProps.classPropertyのプロパティーの変更が
        /// Taskを二つ同時に動かすと変更が混ざってエラー起こすので一つずつ処理している
        /// </summary>
        /// <param name="sender">自動生成されたイベントハンドラ</param>
        /// <param name="e">自動生成されたイベントハンドラ</param>
        private async void Main_Load(object sender, EventArgs e)
        {
            // CPUの名前を習得し、"cpuNameLabel"Formに反映する
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();

            // Formを閉じた際に"fromEnd_Flg"がtrueになるのでループから抜け出す(予定) ※なぜか動かん...
            while (!formEnd_Flg)
            {
                // メモリ使用率を別スレッドで変異させるTask.Run
                Task<int> memUsePerTask = Task.Run(() => memoryUsePercentChange());
                // memUsePerTaskを待機
                await Task.WhenAll(memUsePerTask);
                // CPU使用率を別スレッドで変異させるTask.Run
                Task<int> cpuUsePerTask = Task.Run(() => cpuUsePercentChange());
                // cpuUsePerTaskを待機
                await Task.WhenAll(cpuUsePerTask);
            }
        }
        /// <summary>
        /// Formを閉じる際に"formEnd_Flg"をtrueにして"memUsePerTask"と"cpuUsePerTask"の無限ループタスクを終わらせる(予定) 
        /// "await Task.WhenAll()"でも上記のタスクを終了待ちして～を実現したいけども...(やっぱブレークモードは行ったりエラー起こす...)
        /// ※うまく動かない...
        /// </summary>
        /// <param name="sender">自動生成されたイベントハンドラ</param>
        /// <param name="e">自動生成されたイベントハンドラ</param>
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEnd_Flg = true;
            await Task.WhenAll();
        }

        /// <summary>
        /// Applyボタン押したら"Settingsタブ"の設定状況を反映する。（予定）
        /// </summary>
        /// <param name="sender">自動生成されたイベントハンドラ</param>
        /// <param name="e">自動生成されたイベントハンドラ</param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}