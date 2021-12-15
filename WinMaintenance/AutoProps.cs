namespace WinMaintenance
{
    /// <summary>
    /// ここはGetter、Setterを設置するクラス
    /// </summary>
    class AutoProps
    {
        /// <summary>
        /// Wmiのクラス名の"文字列"
        /// </summary>
        /// <example> AutoProps.managementClass = "Win32_PhysicalMemory";</example>
        public static string managementClass { get; set; }

        /// <summary>
        /// Wmiクラスのプロパティー名の"文字列"
        /// </summary>
        /// <example> AutoProps.classProperty = "SMBIOSMemoryType";</example>
        public static string classProperty { get; set; }

        /// <summary>
        /// レジストリキーへの絶対パスの"文字列"
        /// </summary>
        /// <example> AutoProps.regKeyPass = @"\HKEY_LOCAL_MACHINE\SOFTWARE\..." </example>
        public static string regKeyPass { get; set; }

        /// <summary>
        /// レジストリキーの中のサブキーの名前の"文字列"
        /// </summary>
        /// <example> AutoProps.regKeyPass = "Example"; </example>
        public static string regSubKeyName { get; set; }

        /// <summary>
        /// サブキーへ格納する"文字列"
        /// </summary>
        /// <example> AutoProps.regSubKeyName = "Example"; </example>
        public static string regValue { get; set; }

        /// <summary>
        /// レジストリサブキーへ入力するデータタイプを選択する文字列(現在は"String"か"Int"のみ)
        /// </summary>
        public static string inputType { get; set; }
    }
}
