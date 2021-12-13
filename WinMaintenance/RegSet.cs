namespace WinMaintenance
{
    class RegSet
    {/// <summary>
     /// ドキュメンテーション作成途中
     /// </summary>
     /// <param name="regKeyPass"></param>
     /// <param name="regSubkeyName"></param>
     /// <returns></returns>

        public string regCurrentValueReturn()
        {
            return regCurrentValueGet(AutoProps.regKeyPass, AutoProps.regSubKeyName);
        }
        public string regLocaValueReturn()
        {
            return regLocalValueGet(AutoProps.regKeyPass, AutoProps.regSubKeyName);
        }
        // CurrentUserの値を読み取る"String"で返す
        private string regCurrentValueGet(string regKeyPass, string regName)
        {
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPass, true);

            if (regkey == null) return "none";

            //文字列を読み込む
            //指定した名前の値が存在しないときは null が返される
            return (regkey.GetValue(regName, "none").ToString());

        }
        // LocalMachineの値を読み取る"String"で返す
        private string regLocalValueGet(string regKeyPass, string regName)
        {
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPass, true);

            if (regkey == null) return "none";

            //文字列を読み込む
            //指定した名前の値が存在しないときは null が返される
            return (regkey.GetValue(regName, "none").ToString());

        }


        // cu = CurrentUserの値を変更する
        private void cuRegWrite(string regKeyPass, string regSubKeyName, string regValue, string inputType)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPass);

            //文字列を書き込む（REG_SZで書き込まれる）
            if (inputType.Contains("String"))
            {
                regkey.SetValue(regSubKeyName, regValue);
            }
            //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
            else if (inputType.Contains("Int"))
            {
                regkey.SetValue(regSubKeyName, System.Convert.ToInt32(regValue));
            }
            //閉じる
            regkey.Close();
        }


        // lm = LocalMachineの値を変更する
        private void lmRegWrite(string regKeyPass, string regSubKeyName, string regValue, string inputType)
        {
            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPass);

            //文字列を書き込む（REG_SZで書き込まれる）
            if (inputType.Contains("String"))
            {
                regkey.SetValue(regSubKeyName, regValue);
            }
            //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
            else if (inputType.Contains("Int"))
            {
                regkey.SetValue(regSubKeyName, System.Convert.ToInt32(regValue));
            }
        }
    }
}
