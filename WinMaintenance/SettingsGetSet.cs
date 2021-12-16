using System.Windows.Forms;
using System.Collections.Generic;

namespace WinMaintenance
{
    partial class Main : Form
    {
        RegSet RegSet = new RegSet();

        /// <summary>
        /// PCの非表示の"ThisPCPolicy"までのPathが格納されている
        /// [0]Picture, [1]Video [2]Downloads [3]Music [4]Docments [5]Desktop 
        /// </summary>
        private List<string> regKeyList = new List<string>();

        /// <summary>
        /// 現在のPCのレジストリの設定を取得し、画面の方へ反映する ※レジストリ弄るから慎重に！
        /// </summary>
        private void regSetteingGet()
        {
            //レジストリのPathのライブラリ的な
            //[0] Picture "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{0ddd015d-b06c-45d5-8c4c-f59713854639}\PropertyBag\");

            //[1] Video "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{35286a68-3c57-41a1-bbb1-0eae73d76c95}\PropertyBag");

            //[2] Download "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{7d83ee9b-2244-4e70-b1f5-5393042af1e4}\PropertyBag\");

            //[3] Music "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{a0c69a99-21c8-4671-8703-7934162fcf1d}\PropertyBag\");

            //[4] Documents "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{f42ee2d3-909f-4907-8871-4c22fc0bf756}\PropertyBag\");

            //[5] Desktop "ThisPCPolicy" Path
            regKeyList.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\" +
                @"{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}\PropertyBag\");




            //ここからLocalMachineを使用 PCのフォルダ非表示関係 "ThisPCPolicy" 関連の設定群
            AutoProps.regSubKeyName = "ThisPCPolicy";

            //PCの"ピクチャ"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[0];
            //"ピクチャ"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide")) 
                {
                    pcHidePictureCheckbox.Checked = true;
                }
                else
                {
                    pcHidePictureCheckbox.Checked = false;
                }
            }
            else
            {
                pcHidePictureCheckbox.Enabled = false;
            }

            //PCの"ビデオ"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[1];
            //"ビデオ"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    pcHideVideoCheckbox.Checked = true;
                }
                else
                {
                    pcHideVideoCheckbox.Checked = false;
                }
            }
            else
            {
                pcHideVideoCheckbox.Enabled = false;
            }

            //PCの"ダウンロード"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[2];
            //"ダウンロード"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    pcHideDownloadCheckbox.Checked = true;
                }
                else
                {
                    pcHideDownloadCheckbox.Checked = false;
                }
            }
            else
            {
                pcHideDownloadCheckbox.Enabled = false;
            }

            //PCの"ミュージック"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[3];
            //"ミュージック"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    pcHideMusicCheckbox.Checked = true;
                }
                else
                {
                    pcHideMusicCheckbox.Checked = false;
                }
            }
            else
            {
                pcHideMusicCheckbox.Enabled = false;
            }

            //PCの"ドキュメント"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[4];
            //"ドキュメント"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    pcHideDocumentCheckbox.Checked = true;
                }
                else
                {
                    pcHideDocumentCheckbox.Checked = false;
                }
            }
            else
            {
                pcHideDocumentCheckbox.Enabled = false;
            }

            //PCの"デスクトップ"フォルダが非表示設定か確認するブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[5];
            //"デスクトップ"フォルダが 表示 or 非表示 かチェック
            if (!RegSet.regLocaValueReturn().Contains("Path is None"))
            {
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    pcHideDesktopCheckbox.Checked = true;
                }
                else
                {
                    pcHideDesktopCheckbox.Checked = false;
                }
            }
            else
            {
                pcHideDesktopCheckbox.Enabled = false;
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

            //PCの"ピクチャ"フォルダを表示、非表示にできるか、また行うブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[0];
            //"ピクチャ"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHidePictureCheckbox.Checked)
            {
                //かつ"ピクチャ"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"ピクチャ"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //PCの"ビデオ"フォルダを表示、非表示にできるか、また行うブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[1];
            //"ビデオ"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHideVideoCheckbox.Checked)
            {
                //かつ"ビデオ"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"ビデオ"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //PCの"ダウンロード"フォルダを表示、非表示にできるか、また行うブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[2];
            //"ダウンロード"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHideDownloadCheckbox.Checked)
            {
                //かつ"ダウンロード"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"ダウンロード"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //PCの"ミュージック"フォルダを表示、非表示にできるか、また行うブロック
            AutoProps.regKeyPass = regKeyList[3];
            //"ミュージック"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHideMusicCheckbox.Checked)
            {
                //かつ"ミュージック"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"ミュージック"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //PCの"ドキュメント"フォルダを表示、非表示にできるか、また行うブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[4];
            //"ドキュメント"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHideDocumentCheckbox.Checked)
            {
                //かつ"ドキュメント"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"ミュージック"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }

            //PCの"デスクトップ"フォルダを表示、非表示にできるか、また行うブロック
            //格納されているPathを選択
            AutoProps.regKeyPass = regKeyList[5];
            //"デスクトップ"フォルダを非表示にする"項目にチェックがあるかないか
            if (!pcHideDesktopCheckbox.Checked)
            {
                //かつ"デスクトップ"フォルダーが表示設定の時に、非表示にする
                if (RegSet.regLocaValueReturn().Contains("Hide"))
                {
                    AutoProps.regValue = "Show";
                    AutoProps.inputType = "String";
                    RegSet.lmRegWrite();
                }
            }
            //"デスクトップ"フォルダーを非表示にする"項目にチェックがあるのであれば問答無用で"Hide"設定を書き込む
            //そもそも"ThisPCPolicy"サブキーがないものも存在するため"Contains"で弾いてると設定追加できなくなる
            else
            {
                AutoProps.regValue = "Hide";
                AutoProps.inputType = "String";
                RegSet.lmRegWrite();
            }
        }
    }
}
