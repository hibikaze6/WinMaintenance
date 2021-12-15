namespace WinMaintenance
{
    class RegSet
    {
        /// <summary>
        /// regCurrentValueGetのカプセルかみたいなやつ(意味あるのかなこれ...)
        /// </summary>
        /// <returns>サブキーに設定されている値を返す</returns>
        public string regCurrentValueReturn()
        {
            return regCurrentValueGet();
        }

        /// <summary>
        /// regLocalMachineGetのカプセルかみたいなやつ(意味あるのかなこれ...)
        /// </summary>
        /// <returns>サブキーに設定されている値を返す</returns>
        public string regLocaValueReturn()
        {
            return regLocalValueGet();
        }

        /// <summary>
        /// CurrentUserの値を読み取る"文字列"で返す
        /// </summary>
        /// <returns>サブキーに設定されている値を返す</returns>
        private string regCurrentValueGet()
        {
            //レジストリキーを開き、指定したパスが存在しないときは "none" が返される
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AutoProps.regKeyPass, true);
            if (regkey == null) return "none";

            //サブキーの文字列、数値を読み込む
            //指定した名前の値が存在しないときは "none" が返される
            return (regkey.GetValue(AutoProps.regSubKeyName, "none").ToString());

        }

        /// <summary>
        /// LocalMachineの値を読み取る"String"で返す
        /// </summary>
        /// <returns>サブキーに設定されている値を返す</returns>
        private string regLocalValueGet()
        {
            //レジストリキーを開き、指定したパスが存在しないときは"独自Exception"が返される
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(AutoProps.regKeyPass, true);
            if (regkey == null) /*ここに独自Exceptionを返す記述*/ return "none"; //これは一時的な記述...だと思う

                //サブキーの文字列、数値を読み込む
                //指定した名前の値が存在しないときは "none" が返される
                return (regkey.GetValue(AutoProps.regSubKeyName, "none").ToString());
        }

        //製作途中
        public void cuRegWrite()
        {
            //cuRegSet(AutoProps.regKeyPass,)
        }

        /// <summary>
        /// CurrentUserの指定されたサブキーの値を変更する
        /// </summary>
        private void cuRegSet()
        {
            //レジストリキーを開き、指定したパスが存在しないときは"独自Exception"が返される
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AutoProps.regKeyPass);
            if (regkey == null) //ここに独自Exceptionを返す記述

            //inputTypeを参照し、"String"か"int"かを判断する 関係ないタイプであれば"独自Exception"を返す
            if (AutoProps.inputType.Contains("String"))
            {
                //文字列を書き込む（REG_SZで書き込まれる）
                regkey.SetValue(AutoProps.regSubKeyName, AutoProps.regValue);
            }
            else if (AutoProps.inputType.Contains("Int"))
            {
                //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
                regkey.SetValue(AutoProps.regSubKeyName, System.Convert.ToInt32(AutoProps.regValue));
            }
            //閉じる
            regkey.Close();
        }


        /// <summary>
        /// LocalMachineの指定されたサブキーの値を変更する
        /// </summary>
        private void lmRegSet()
        {
            //レジストリキーを開き、指定したパスが存在しないときは"独自Exception"が返される
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(AutoProps.regKeyPass);
            if (regkey == null) //ここに独自Exceptionを返す記述

                //inputTypeを参照し、"String"か"int"かを判断する 関係ないタイプであれば"独自Exception"を返す
                if (AutoProps.inputType.Contains("String"))
                {
                    //文字列を書き込む（REG_SZで書き込まれる）
                    regkey.SetValue(AutoProps.regSubKeyName, AutoProps.regValue);
                }
                else if (AutoProps.inputType.Contains("Int"))
                {
                    //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
                    regkey.SetValue(AutoProps.regSubKeyName, System.Convert.ToInt32(AutoProps.regValue));
                }
            //閉じる
            regkey.Close();
        }
    }
}
