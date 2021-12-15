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
                @"{35286a68-3c57-41a1-bbb1-0eae73d76c95}\PropertyBag");

            //[2] Download "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{7d83ee9b-2244-4e70-b1f5-5393042af1e4}\PropertyBag\");

            AutoProps.regSubKeyName = "ThisPCPolicy";

            //PCのPictureフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = regKeyList[0];
            //Picture Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                pcHidePictureCheckbox.Checked = true;
            }
            else if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Show"))
            {
                pcHidePictureCheckbox.Checked = false;
            }
            else
            {
                pcHidePictureCheckbox.Enabled = false;
            }

            //PCのVideoフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = regKeyList[1];
            //Video Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                pcHideVideoCheckbox.Checked = true;
            }
            else if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Show"))
            {
                pcHideVideoCheckbox.Checked = false;
            }
            else
            {
                pcHideVideoCheckbox.Enabled = false;
            }

            //PCのDownloadフォルダが非表示設定か確認するブロック
            AutoProps.regKeyPass = regKeyList[2];
            //Download Show Hide Setting Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                pcHideDownloadCheckbox.Checked = true;
            }
            else if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Show"))
            {
                pcHideDownloadCheckbox.Checked = false;
            }
            else
            {
                pcHideVideoCheckbox.Enabled = false;
            }
        }

        /// <summary>
        /// regSettingSet()のカプセル化みたいなやつ(意味あるのかなこれ...)
        /// </summary>
        public void regSettingWrite() 
        {
            regSettingSet();
        }
        /// <summary>
        /// 設定タブの状況に応じてレジストリを書き換える所 ※レジストリ弄るから慎重に！
        /// </summary>
        private void regSettingSet()
        {
            //ここからLocalMachineを使用 PCのフォルダ非表示関係 "ThisPCPolicy" 関連の設定群
            AutoProps.regSubKeyName = "ThisPCPolicy";

            //Picture Show Hide Check
            //"ピクチャを非表示にする"項目にチェックがあり、かつピクチャが表示設定の時に、非表示にする
            AutoProps.regKeyPass = regKeyList[0];
            if (pcHidePictureCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }
            //"ピクチャを非表示にする"項目にチェックがなく、かつピクチャが表示設定の時に、表示にする
            else if (!pcHidePictureCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                AutoProps.regValue = "Show";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //Video Show Hide Check
            //"ビデオを非表示にする"項目にチェックがあり、かつビデオが表示設定の時に、非表示にする
            AutoProps.regKeyPass = regKeyList[1];
            if (pcHideVideoCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }
            //"ビデオを非表示にする"項目にチェックがなく、かつビデオが表示設定の時に、表示にする
            else if (!pcHideVideoCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                AutoProps.regValue = "Show";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //Download Show Hide Check
            //"ビデオを非表示にする"項目にチェックがあり、かつビデオが表示設定の時に、非表示にする
            AutoProps.regKeyPass = regKeyList[2];
            if (pcHideDownloadCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }
            //"ビデオを非表示にする"項目にチェックがなく、かつビデオが表示設定の時に、表示にする
            else if (!pcHideDownloadCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                AutoProps.regValue = "Show";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }
        }
    }
}
