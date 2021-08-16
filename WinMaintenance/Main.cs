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
        private void setCpuProgressValue(int CpuUsePer)
        {
            cpuProgress.Value = CpuUsePer;
        }
        private void setMemoryProgressValue(int MemoryUsePer)
        {
            memoryProgress.Value = MemoryUsePer;
        }
        public Main()
        {
            InitializeComponent();
        }

        private int test1()
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "LoadPercentage";
            while (!formEnd_Flg)
            {
                Thread.Sleep(500);
                Invoke(new del(setCpuProgressValue), int.Parse(WmiOperation.getWmiInfo()));
            }
            return 1;
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            AutoProps.managementClass = "Win32_Processor";
            AutoProps.classProperty = "Name";
            cpuNameLabel.Text = WmiOperation.getWmiInfo();


            //CPU使用率を別スレッドで変異させるTask.Run
            Task<int> task1 = Task.Run(() => test1());

            await Task.WhenAll(task1);
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