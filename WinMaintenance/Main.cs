using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Management;

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
        /// Taskでの操作のWMI関係のデッドロック防止の"testLock"
        /// </summary>
        /// 
        private readonly object testLock = new object();

        WmiOperation WmiOperation = new WmiOperation();

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
            memoryAvailableLabel.Text = memoryAvailableLabelText + "GB";
        }
        private void setNowTimeLabelChange(string nowTimeLabelText)
        {
            nowTimeLabel.Text = nowTimeLabelText;
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
            lock (testLock) 
            {
                // プロパティを設定してWmiから情報を抜き出す
                AutoProps.managementClass = "Win32_Processor";
                AutoProps.classProperty = "LoadPercentage";
                Thread.Sleep(500);

                // Formに取得した値をFormに代入する
                Invoke(new delInt(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
                return 0;
            }
        }
        private int memoryUsePercentChange()
        {
            lock (testLock)
            {
                // プロパティを設定してWmiから情報を抜き出す
                AutoProps.managementClass = "Win32_OperatingSystem";
                AutoProps.classProperty = "TotalVisibleMemorySize";

                // メモリ最大を○○.○GB表記にするために計算結果をdoubleParceしてから変数に代入している
                var maxMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10);

                AutoProps.classProperty = "FreePhysicalMemory";

                // 空きメモリ容量を 〃
                var freeMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10);


                /* 値の確認テスト用
                MessageBox.Show(maxMemory.ToString());
                MessageBox.Show(freeMemory.ToString());
                */

                // Formに取得した値をFormに代入する
                Invoke(new delInt(setMaxMemoryProgressValue), Convert.ToInt32(maxMemory * 10));
                Invoke(new delInt(setMemoryProgressValue), (memoryProgress.Maximum - Convert.ToInt32(freeMemory * 10)));
                Invoke(new delStr(setMemoryAvailableLabelText), ("UseMem" + maxMemory + "GB" + " / " + (maxMemory - freeMemory).ToString()));
            }

            return 0;
        }
        private int nowTimeLabelChange()
        {
            Thread.Sleep(500);
            Invoke(new delStr(setNowTimeLabelChange), DateTime.Now.ToString("yyyy MM-dd HH:mm"));
            return 0;
        }

        /// <summary>
        /// メインフォームがロードされる時にに動作するメソッド
        /// ・CPU名を出す
        /// ・memUsePerTaskを生成し、別スレッドにてメモリの使用量をFormで出す(ProgressBar、Label)
        /// ・cpuUsePerTaskを生成し、〃
        /// ・"Task.WhenAll"は処理終わるまで待ってる(理由はAutoProps.managementClassとAutoProps.classPropertyのプロパティーの変更が
        /// Taskを二つ同時に動かすと変更が混ざってエラー起こすので一つずつ処理している
        /// ・メモリのタイプ、速度を出している。
        /// ・GPU、CPUの種類の画像をWMIから情報を取得し、表示している。
        /// ・ディスクの情報を全て出し、
        /// </summary>
        /// <param name="sender">自動生成されたイベントハンドラ</param>
        /// <param name="e">自動生成されたイベントハンドラ</param>
        private async void Main_Load(object sender, EventArgs e)
        {
            // CPUの名前を取得し、"cpuNameLabel"Formに反映する
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();

            // GPUの名前を取得し、"gpuNameLabel"Formに反映する
            AutoProps.managementClass = "Win32_VideoController";
            AutoProps.classProperty = "Name";
            gpuNameLabel.Text = WmiOperation.getWmiInfo();

            //Memoryのタイプを取得し、"memoryTypeLabel"Formに反映する
            AutoProps.managementClass = "Win32_PhysicalMemory";
            AutoProps.classProperty = "SMBIOSMemoryType";
            //SMBIOSMemoryType is 20 = DDR, 21 is DDR2, 22 is DDR2 FB-DIMM
            //24 is DDR3, 26 is DDR4. DDR5 is Unknown
            if (WmiOperation.getWmiInfo().Equals("20"))
            {
                memoryTypeLabel.Text = "DDR-";
            }
            else if (WmiOperation.getWmiInfo().Equals("21") || WmiOperation.getWmiInfo().Equals("22"))
            {
                memoryTypeLabel.Text = "DDR2-";
            }
            else if (WmiOperation.getWmiInfo().Equals("24"))
            {
                memoryTypeLabel.Text = "DDR3-";
            }
            else if(WmiOperation.getWmiInfo().Equals("26"))
            {
                memoryTypeLabel.Text = "DDR4-";
            }
            else
            {
                memoryTypeLabel.Text = "DDR5-";
            }

            // Memoryの周波数を取得し、"memoryTypeLabel"Formに反映する
            AutoProps.managementClass = "Win32_PhysicalMemory";
            AutoProps.classProperty = "ConfiguredClockSpeed";
            memoryTypeLabel.Text = memoryTypeLabel.Text + WmiOperation.getWmiInfo();

            //搭載Gpuによって"gpuPictureBox"の画像を変える
            if (gpuNameLabel.Text.Contains("Intel"))
            {
                gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\INTELHD_BADGE.png");
            }
            else if (gpuNameLabel.Text.Contains("Radeon"))
            {
                gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\RADEON_FAMILY_BADGE.png");
            }
            else if(gpuNameLabel.Text.Contains("NVIDIA"))
            {
                gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\NVIDIA_BADGE.png");
            }
            else
            {
                gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\OTHERGPU_BADGE.png");
            }

            //搭載Cpuによって"gpuPictureBox"の画像を変える
            if (cpuNameLabel.Text.Contains("Intel"))
            {
                cpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\CpuLogo\INTELCPU_BADGE.png");
            }
            else if (cpuNameLabel.Text.Contains("AMD"))
            {
                cpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\CpuLogo\AMDCPU_BADGE.png");
            }
            else
            {
                cpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\CpuLogo\OTHERCPU_BADGE.png");
            }


            //ディスク全ての情報を出す(予定)
            AutoProps.managementClass = "Win32_DiskDrive";
            foreach (ManagementObject mo in WmiOperation.getWmiAll())
            {
                if (mo["Caption"] != null)
                {
                    diskListCb.Items.Add(mo["Caption"]);
                    MessageBox.Show(mo["Caption"].ToString());
                }
            }
            diskListCb.SelectedIndex = 0;

            // Formを閉じた際に"fromEnd_Flg"がtrueになるのでループから抜け出す(予定) ※なぜか動かん...
            while (!formEnd_Flg)
            {
                // メモリ使用率を別スレッドで変異させるTask.Run
                _ = await Task.Run(() => { return memoryUsePercentChange(); });
                // CPU使用率を別スレッドで変異させるTask.Run
                _ =  await Task.Run(() => { return cpuUsePercentChange(); });
                //MainFormの右上の時間を更新するTask.Run
                _ = await Task.Run(() => { return nowTimeLabelChange(); });

            }
        }
        /// <summary>
        /// Formを閉じる際に"formEnd_Flg"をtrueにして"memUsePerTask"と"cpuUsePerTask"の無限ループタスクを終わらせる(予定) 
        /// "await Task.WhenAll()"でも上記のタスクを終了待ちして～を実現したいけども...(やっぱブレークモードは行ったりエラー起こす...)
        /// ※うまく動かない...
        /// </summary>
        /// <param name="sender">自動生成されたイベントハンドラ</param>
        /// <param name="e">自動生成されたイベントハンドラ</param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEnd_Flg = true;
            BeginInvoke((MethodInvoker)delegate { this.Close(); });
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