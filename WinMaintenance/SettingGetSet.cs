using System.Windows.Forms;
using System.Collections.Generic;

namespace WinMaintenance
{
    partial class Main : Form
    {
        RegSet RegSet = new RegSet();

        /// <summary>
        /// PCの非表示の"ThisPCPolicy"までのPathが格納されている
        /// [0]Picture, [1]Video [2]Downloads
        /// </summary>
        private List<string> regKeyList = new List<string>();

        /// <summary>
        /// 現在のPCのレジストリの設定を取得し、画面の方へ反映する ※レジストリ弄るから慎重に！
        /// </summary>
        private void regSetteingGet()
        {
            //[0] Picture "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" + 
                @"{0ddd015d-b06c-45d5-8c4c-f59713854639}\PropertyBag\");

            //[1] Video "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{35286a68-3c57-41a1-bbb1-0eae73d76c95}\PropertyBag\");

            //[2] Download "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{7d83ee9b-2244-4e70-b1f5-5393042af1e4}\PropertyBag\");

            AutoProps.regSubKeyName = "ThisPCPolicy";

            //PCのPictureフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = regKeyList[0];
            //Picture Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
                pcHidePictureCheckbox.Checked = true;

            //PCのVideoフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = AutoProps.regKeyPass = regKeyList[1];
            //Video Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
                pcHideVideoCheckbox.Checked = true;

            //PCのDownloadフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = AutoProps.regKeyPass = AutoProps.regKeyPass = regKeyList[2];
            //Download Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
                pcHideDownloadCheckbox.Checked = true;


        }

        /// <summary>
        /// 設定タブの状況に応じてレジストリを書き換える所 ※レジストリ弄るから慎重に！
        /// </summary>
        private void regSettingSet()
        {
            //LocalMachineを使用 PCのフォルダ非表示関係 "ThisPCPolicy" 関連の設定群
            AutoProps.regSubKeyName = "ThisPCPolicy";
            //Picture Show Hide Check
            if (pcHidePictureCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regKeyPass = regKeyList[0];
            }
            else if (pcHideVideoCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regKeyPass = @"SOFTWARE\Microsoft\Windows\CurrentVersion\" +
                    @"Explorer\FolderDescriptions\{35286a68-3c57-41a1-bbb1-0eae73d76c95}\PropertyBag\";
            }
        }
    }
}
