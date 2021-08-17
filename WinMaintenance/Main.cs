using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WinMaintenance.Properties;

namespace WinMaintenance
{
    public partial class Main : Form
    {
        delegate void del(int value);
        bool formEnd_Flg = false;

        /*
         * なんか処理を別にしないとフォーム固まる(Task.Runの中でできない件)
         * ここにはInvoke処理で値が変更される処理を書くところ
         */
        private void setCpuProgressValue(int cpuUsePer)
        {
            cpuProgress.Value = cpuUsePer;
        }
        private void setMemoryProgressValue(int memoryUsePer)
        {
            memoryProgress.Value = memoryUsePer;
        }
        private void setMaxMemoryProgressValue(int memoryMaxValue) 
        {
            memoryProgress.Maximum = memoryMaxValue;
        }
        public Main()
        {
            InitializeComponent();
        }

        //使えることがわかったらメソッド名ちゃんとかえる
        private int cpuUsePercentChange()
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "LoadPercentage";
            Thread.Sleep(500);
            Invoke(new del(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
            return 1;
        }
        private int memoryUsePercentChange()
        {
            AutoProps.managementClass = "Win32_OperatingSystem";
            AutoProps.classProperty = "TotalVisibleMemorySize";

            var maxMemory = Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10;

            AutoProps.classProperty = "FreePhysicalMemory";

            var freeMemory = Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10;


            MessageBox.Show(maxMemory.ToString());
            MessageBox.Show(freeMemory.ToString());

            Invoke(new del(setMaxMemoryProgressValue), maxMemory);
            Invoke(new del(setMemoryProgressValue), freeMemory);
            return 1;
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();

            AutoProps.managementClass = "Win32_OperatingSystem";
            AutoProps.classProperty = "TotalVisibleMemorySize";

            memoryAvailableLabel.Text = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10).ToString();

            while (!formEnd_Flg)
            {
                //CPU使用率を別スレッドで変異させるTask.Run
                Task<int> task1 = Task.Run(() => cpuUsePercentChange());
                //Task1を待機
                await Task.WhenAll(task1);
                //メモリ使用率を別スレッドで変異させるTask.Run
                Task<int> task2 = Task.Run(() => memoryUsePercentChange());
                //Task2を待機
                await Task.WhenAll(task2);
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEnd_Flg = true;
            Thread.Sleep(1000);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}