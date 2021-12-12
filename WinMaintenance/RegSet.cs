using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMaintenance
{
    class RegSet
    {/// <summary>
    /// ドキュメンテーション作成途中
    /// </summary>
    /// <param name="regKeyPass"></param>
    /// <param name="regName"></param>
    /// <returns></returns>


        // 値を読み取る"String"で返す
        private string regValueReturn(string regKeyPass, string regName) 
        {
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPass, false);

            if (regkey == null) return "none";

            //文字列を読み込む
            //指定した名前の値が存在しないときは null が返される
            return (regkey.GetValue(regName, "none").ToString());
        }
        
        // cu = CurrentUserの値を変更する
        private void cuRegSZ(string regKeyPass, string regName, string regValueString)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPass);
            //文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue(regName, regValueString);
            //閉じる
            regkey.Close();
        }
        private void cuRegDword(string regKeyPass, string regName, int regValueInt)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPass);
            //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
            regkey.SetValue(regName, regValueInt);
            //閉じる
            regkey.Close();
        }

        // lm = LocalMachineの値を変更する
        private void lmRegSZ(string regKeyPass, string regName, string regValueString)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPass);
            //文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue(regName, regValueString);
            //閉じる
            regkey.Close();
        }
        private void lmRegDword(string regKeyPass, string regName, int regValueInt)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPass);
            //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
            regkey.SetValue(regName, regValueInt);
            //閉じる
            regkey.Close();
        }
    }
}
