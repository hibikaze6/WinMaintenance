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
        /// Main それ以上でも以下でもない
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Taskでの操作のWMI関係のデッドロック防止の"testLock"
        /// </summary>
        public readonly object taskLock = new object();

        /// <summary>
        /// WmiOperationClassのインスタンス化
        /// </summary>
        WmiOperation WmiOperation = new WmiOperation();

        //ここにはInvoke処理でFormの値が変更される処理を書くところ ～ここから～

        private void setCpuProgressValue(int cpuUsePer)
        {
            cpuProgress.Value = cpuUsePer;
            cpuUsePerLabel.Text = cpuUsePer.ToString() + "％ Use";
        }
        /// <summary>
        /// 受け取った現在のメモリ使用率をFormへ反映
        /// </summary>
        /// <param name="memoryUseCapa">memoryUsePercentChange()から計算され、受け取った</param>
        private void setMemoryProgressValue(int memoryUseCapa)
        {
            memoryProgress.Value = memoryUseCapa;

            memUsePerLabel.Text = Convert.ToString((Math.Floor((double)memoryUseCapa / memoryProgress.Maximum * 100.00))) + "％ Use";
        }
        private void setMaxMemoryProgressValue(int memoryMaxValue) 
        {
            memoryProgress.Maximum = memoryMaxValue;
        }
        /// <summary>
        /// 受け取った現在のメモリ空きパーセントをFormへ反映する。
        /// </summary>
        /// <param name="memoryAvailableLabelText">memoryUsePercentChange()から渡された値</param>
        private void setMemoryAvailableLabelText(string memoryAvailableLabelText)
        {
            memoryAvailableLabel.Text = memoryAvailableLabelText + "GB";
        }

        /// <summary>
        /// 受け取った値で、ディスクの最大容量とディスクの空き容量を再計算し、GBで出して、Formに反映している。
        /// </summary>
        /// <param name="maxDiskSizeGB">setDiskStatusChange()から受け取った、ディスクの最大容量をGBで、"浮動小数点"で出している</param>
        /// <param name="freeDiskDizeGB">setDiskStatusChange()から受け取った、ディスクの空き容量を 〃 </param>
        private void setDiskStatusText(double maxDiskSizeGB, double freeDiskDizeGB)
        {
            diskProgress.Maximum = Convert.ToInt32(maxDiskSizeGB);
            diskProgress.Value = Convert.ToInt32(freeDiskDizeGB);

            diskUsePerLabel.Text = Math.Round(Math.Floor(Convert.ToDouble(freeDiskDizeGB)) / (Convert.ToDouble(maxDiskSizeGB)) * 100.0).ToString() + "% Free";
            diskAvailableLabel.Text = maxDiskSizeGB.ToString() + "GB/" + freeDiskDizeGB.ToString() + "GB Free";
        }

        /// <summary>
        /// 受け取った現在時刻をnowTimeLabelへ反映する。
        /// </summary>
        /// <param name="nowTimeLabelText">nowTimeLabelChange()から受け取った現在時刻の"文字列"</param>
        private void setNowTimeLabelText(string nowTimeLabelText)
        {
            nowTimeLabel.Text = nowTimeLabelText;
        }

        /// <summary>
        /// moの中に複数入っている"Win32_LogicalDisk"の"ドライブの情報"(例えば"C:"、"D:")から、diskListCbに選択されている、
        /// ドライブ文字の情報を出せるように、Containsで現在"mo"の中に入ってる"ドライブ文字"の"Caption"プロパティと選択されている文字を比較し、
        /// どちらも同じドライブ文字になった時にtrueを返している
        /// </summary>
        /// <param name="mo">ここではWin32_LogicalDiskの情報を格納している</param>
        /// <returns></returns>
        private bool getDiskListCbText(ManagementObject mo)
        {
            return diskListCb.Text.Contains(mo["Caption"].ToString());
        }

        // ここにはInvoke処理でFormの値が変更される処理を書くところ ～End～

        /// <summary>
        /// CPUの使用率を取得し、Formへ反映する
        /// </summary>
        /// <returns>よくわからないけど返さないとTask関係がエラーなるから"数値型"を返している</returns>
        private int cpuUsePercentChange()
        {
            lock (taskLock)
            {
                // プロパティを設定してWmiから情報を抜き出す
                AutoProps.managementClass = "Win32_Processor";
                AutoProps.classProperty = "LoadPercentage";
                Thread.Sleep(500);

                // Formに取得した値をFormに代入する
                Invoke(new delInt(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
            }
                return 0;
        }

        /// <summary>
        /// メモリの最大容量と空き容量を計算し、Formへ反映する
        /// </summary>
        /// <returns>よくわからないけど返さないとTask関係がエラーなるから"数値型"を返している</returns>
        private int memoryUsePercentChange()
        {
            //スコープの関係上ここで宣言、初期化
            var maxMemory = 0.0;
            var freeMemory = 0.0;

            lock (taskLock)
            {
                // Wmiクラスを指定
                AutoProps.managementClass = "Win32_OperatingSystem";

                // メモリ最大値を計算
                AutoProps.classProperty = "TotalVisibleMemorySize";
                // メモリ最大を○○.○GB表記にするために計算結果をdoubleParceしてから変数に代入している
                maxMemory = Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10;

                //空きメモリ容量を計算
                AutoProps.classProperty = "FreePhysicalMemory";
                // 空きメモリ容量を 〃
                freeMemory = Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10;
            }

                // Formに取得した値をInvokeで代入する
                Invoke(new delInt(setMaxMemoryProgressValue), Convert.ToInt32(maxMemory * 10));
                Invoke(new delInt(setMemoryProgressValue), (memoryProgress.Maximum - Convert.ToInt32(freeMemory * 10)));
                Invoke(new delStr(setMemoryAvailableLabelText), ("UseMem" + maxMemory + "GB" + " / " + (maxMemory - freeMemory).ToString()));

            return 0;
        }

        /// <summary>
        /// DiskListCbで選択されているドライブの情報を計算し、Formへ反映する
        /// </summary>
        private void setDiskStatusChange()
        {
            lock (taskLock)
            {
                //diskListCbへ先に"Win32_DiskDrive"の"Caption"を入れて、それから最初に取得できたディスクの空き容量を出す
                AutoProps.managementClass = "Win32_LogicalDisk";
                foreach (ManagementObject mo in WmiOperation.getWmiAll())
                {
                    // "Form_Load" の時点で容量が出せるものだけで絞られておりnull処理が要らない。
                    // getDiskListCbText()で"DiskListCb"で選択されているものだけ選ばれるようにしてある
                    bool b = (bool)Invoke(new delMo(getDiskListCbText), mo);
                    if (b is true)
                    {
                        //計算部分
                        //あえて分かりやすく1024で3回割ってGBにして数値を出している(元の数値はバイトで出ているため)
                        double maxDiskSizeGB = Math.Round(double.Parse(mo["Size"].ToString()) / 1024 / 1024 / 1024, 1);
                        double freeDiskDizeGB = Math.Round(double.Parse(mo["FreeSpace"].ToString()) / 1024 / 1024 / 1024, 1);

                        Invoke(new delDouble2(setDiskStatusText), maxDiskSizeGB, freeDiskDizeGB);
                    }
                }
            }
        }

        /// <summary>
        /// なんとなく追加した右上の時計を、Formへ反映する
        /// </summary>
        /// <returns>よくわからないけど返さないとTask関係がエラーなるから"数値型"を返している</returns>
        private int nowTimeLabelChange()
        {
            Thread.Sleep(500);
            //時計を表示、更新する
            Invoke(new delStr(setNowTimeLabelText), DateTime.Now.ToString("yyyy MM-dd HH:mm"));
            return 0;
        }

        /// <summary>
        /// ドライブ文字が格納されている"diskListCb_SelectedIndex"のドライブ文字を変更した際に空き容量を計算し出す
        /// </summary>
        private async void diskListCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //サブスレッドで動作させないとメインスレッドだとLockした際にデッドロックが起こりプログラムがフリーズしてしまう
            await Task.Run(() => setDiskStatusChange());
        }

        /// <summary>
        /// メインフォームがロードされる時にに動作するメソッド
        /// ・CPU名、それに対応した画像を出す
        /// ・GPU名、〃
        /// ・メモリタイプ、速度を出す。
        /// ・memUsePerTask(現在は _)を生成し、別スレッドにてメモリの使用量を計算、Formへ反映(memoryProgress、memUsePerLabel、memoryTypeLabel)
        /// ・cpuUsePerTask(現在は _ )を生成し、CPU名、(cpuProgress、cpuUsePerLabel、cpuNameLabel)
        /// ・nowTimeTask(現在は _ )を生成し、DateTimNowで現在時間を出しnowTimeLabelへ反映
        /// ・メモリのタイプ、速度を出している。
        /// ・GPU、CPUの種類の画像をWMIから情報を取得し、表示している。
        /// ・ディスクの情報を全て出し、空き容量を％と数値で表示する。
        /// </summary>
        private async void Main_Load(object sender, EventArgs e)
        {
            //CPU情報関連の処理
            // CPUの名前を取得し、"cpuNameLabel"Formに反映する
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();
            //搭載Cpuによって"gpuPictureBox"の画像を変える
            try
            {
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
            }
            catch (System.IO.FileNotFoundException)
            {
                gpuPictureBox.Image = null;
            }

            //GPU情報関連の処理
            // GPUの名前を取得し、"gpuNameLabel"Formに反映する
            AutoProps.managementClass = "Win32_VideoController";
            AutoProps.classProperty = "Name";
            gpuNameLabel.Text = WmiOperation.getWmiInfo();
            //搭載Gpuによって"gpuPictureBox"の画像を変える
            try
            {
                if (gpuNameLabel.Text.Contains("Intel"))
                {
                    gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\INTELHD_BADGE.png");
                }
                else if (gpuNameLabel.Text.Contains("Radeon"))
                {
                    gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\RADEON_FAMILY_BADGE.png");
                }
                else if (gpuNameLabel.Text.Contains("NVIDIA"))
                {
                    gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\NVIDIA_BADGE.png");
                }
                else
                {
                    gpuPictureBox.Image = System.Drawing.Image.FromFile(@".\WMResource\Image\GpuLogo\OTHERGPU_BADGE.png");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                gpuPictureBox.Image = null;
            }

            //Memory関連の処理
            //Memoryのタイプを取得し、"memoryTypeLabel"Formに反映する
            AutoProps.managementClass = "Win32_PhysicalMemory";
            AutoProps.classProperty = "SMBIOSMemoryType";
            //SMBIOSMemoryType is 20 = DDR, 21 = DDR2, 22 = DDR2 FB-DIMM, 24 = DDR3, 26 = DDR4. DDR5 is Unknown
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
            AutoProps.classProperty = "ConfiguredClockSpeed";
            memoryTypeLabel.Text = memoryTypeLabel.Text + WmiOperation.getWmiInfo();

            //ディスク関連の処理
            //diskListCbへ先に"Win32_DiskDrive"の"Caption"を入れて、それから最初に取得できたディスクの空き容量を出す
            AutoProps.managementClass = "Win32_LogicalDisk";
            foreach (ManagementObject mo in WmiOperation.getWmiAll())
            {
                if (mo["Size"] != null)
                {
                    diskListCb.Items.Add(mo["Caption"] + " Drive");
                }
            }
            //先にプルダウンの初期選択を配列1番目に設定しておき、Disk情報群を選択せずとも、表示させるようにする
            diskListCb.SelectedIndex = 0;
            //この先↑の選択動作により、"diskListCb_SelectedIndexChanged"イベントで表示してくれるため書く必要はない

            //ここでSettingForm関連の処理
            //レジストリ関連の設定を読み込み、Formへ反映
            regSetteingGet();

            //常時更新したい値のTask群
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
        /// trueになるとCPUとメモリ使用容量を無限ループで取得するループを抜けるようにする(予定) ※なぜか動かん
        /// </summary>
        bool formEnd_Flg = false;

        /// <summary>
        /// Formを閉じる際に"formEnd_Flg"をtrueにして"memUsePerTask"と"cpuUsePerTask"の無限ループタスクを終わらせる(予定) 
        /// "await Task.WhenAll()"でも上記のタスクを終了待ちして～を実現したいけども...(やっぱブレークモードはいったりエラー起こす...)
        /// ※うまく動かない...
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEnd_Flg = true;
            BeginInvoke((MethodInvoker)delegate { this.Close(); });
        }

        /// <summary>
        /// Applyボタン押したら"Settingsタブ"の設定状況を反映する。（予定）
        /// </summary>
        private void applyButton_Click(object sender, EventArgs e)
        {
            regSettingWrite();

            MessageBox.Show("OK");
        }
    }
}