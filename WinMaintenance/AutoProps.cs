namespace WinMaintenance
{
    /// <summary>
    /// ここはGetter、Setterを設置するクラス
    /// </summary>
    class AutoProps
    {
        /// <summary>
        /// WmiOperation.csにある、wmiInfoメソッドをカプセル化するためのGetter、Setter群
        /// </summary>
        /// <example> AutoProps.managementClass = "Win32_PhysicalMemory";</example>
        public static string managementClass { get; set; }

        /// <summary>
        /// 同上
        /// </summary>
        /// <example> AutoProps.classProperty = "SMBIOSMemoryType";</example>
        public static string classProperty { get; set; }

        /// <summary>
        /// RegSet.csにある、レジストリキーのある所への絶対パスを格納するGetter、Setter群
        /// </summary>
        /// <example> AutoProps.regKeyPass = @"\HKEY_LOCAL_MACHINE\SOFTWARE\..." </example>
        public static string regKeyPass { get; set; }

        /// <summary>
        /// RegSet.cs にある、レジストリキーの中のサブキーの名前を格納するGetter、Setter群
        /// </summary>
        /// <example> AutoProps.regKeyPass = "Example";
        public static string regName { get; set; }

        /// <summary>
        /// 力尽きたから続きはここからで
        /// </summary>
        public static string regValueString { get; set; }

        public static int regValueInt { get; set; }
        /// ～群ここまで～
    }
}
