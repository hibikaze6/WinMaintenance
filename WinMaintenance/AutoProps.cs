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
        /// ～群ここまで～
    }
}
