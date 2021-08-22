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
        delegate void delInt(int value);
        delegate void delStr(string value);

        bool formEnd_Flg = false;

        /*
         * なんか処理を別にしないとフォーム固まる(Task.Runの中でできない件)
         * ここにはInvoke処理でFormの値が変更される処理を書くところ
         */
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
        /*
         * ここにはInvoke処理でFormの値が変更される処理を書くところ ～End～
         */

        public Main()
        {
            InitializeComponent();
        }
        private int cpuUsePercentChange()
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "LoadPercentage";
            Thread.Sleep(500);
            Invoke(new delInt(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
            return 1;
        }
        private int memoryUsePercentChange()
        {
            AutoProps.managementClass = "Win32_OperatingSystem";
            AutoProps.classProperty = "TotalVisibleMemorySize";

            //メモリ最大を○○.○GB表記にするためにdoubleParceしてる
            var maxMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) / 10);

            AutoProps.classProperty = "FreePhysicalMemory";

            //空きメモリ要領を 〃
            var freeMemory = (Math.Floor(double.Parse(WmiOperation.getWmiInfo()) / 1024.0 / 1024.0 * 10) /10);

            /* 値の確認テスト用
            MessageBox.Show(maxMemory.ToString());
            MessageBox.Show(freeMemory.ToString());
            */

            Invoke(new delInt(setMaxMemoryProgressValue), Convert.ToInt32(maxMemory * 10));
            Invoke(new delInt(setMemoryProgressValue), (memoryProgress.Maximum - Convert.ToInt32(freeMemory * 10)));
            Invoke(new delStr(setMemoryAvailableLabelText), ("UseMem" + maxMemory + " / " + (maxMemory - freeMemory).ToString()));

            return 1;
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();

            while (!formEnd_Flg)
            {
                //メモリ使用率を別スレッドで変異させるTask.Run
                Task<int> task1 = Task.Run(() => memoryUsePercentChange());
                //Task1を待機
                await Task.WhenAll(task1);
                //CPU使用率を別スレッドで変異させるTask.Run
                Task<int> task2 = Task.Run(() => cpuUsePercentChange());
                //Task2を待機
                await Task.WhenAll(task2);
            }
        }
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEnd_Flg = true;
            await Task.WhenAll();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}