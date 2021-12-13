namespace WinMaintenance
{
    /// <summary>
    /// ここはGetter、Setterを設置するクラス
    /// </summary>
    class AutoProps
    {
        /// <summary>
        /// WmiOperation.csにある、wmiInfoメソッドの取り出したい"ManagermentClass"名を格納するプロパティ
        /// </summary>
        /// <example> AutoProps.managementClass = "Win32_PhysicalMemory";</example>
        public static string managementClass { get; set; }

        /// <summary>
        /// WmiOperation.csにある、wmiInfoメソッドの取り出したい"ClassProperty"名を格納するプロパティ
        /// </summary>
        /// <example> AutoProps.classProperty = "SMBIOSMemoryType";</example>
        public static string classProperty { get; set; }

        /// <summary>
        /// RegSet.csにある、レジストリキーのある所への絶対パスを格納するプロパティ
        /// </summary>
        /// <example> AutoProps.regKeyPass = @"\HKEY_LOCAL_MACHINE\SOFTWARE\..." </example>
        public static string regKeyPass { get; set; }

        /// <summary>
        /// RegSet.cs にある、レジストリキーの中のサブキーの名前を格納するプロパティ
        /// </summary>
        /// <example> AutoProps.regKeyPass = "Example";
        public static string regSubKeyName { get; set; }

        /// <summary>
        /// Reg.csにある、サブキーへ"String型"を格納する"値"を格納するプロパティ
        /// </summary>
        public static string regValue { get; set; }

        /// <summary>
        /// Reg.csにある、レジストリサブキーへ入力するデータタイプを選択する変数のプロパティ
        /// </summary>
        public static string inputType { get; set; }
    }
}
