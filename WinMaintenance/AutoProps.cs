using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string managementClass { get; set; }
        public static string classProperty { get; set; }
        /// ～群ここまで～
    }
}
