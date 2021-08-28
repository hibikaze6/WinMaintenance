using System.Management;

namespace WinMaintenance
{
    /// <summary>
    /// Wmiの操作関連のメソッド群を記述してある。
    /// </summary>
    /// <see cref="System.Management"/>
    class WmiOperation
    {
        /// <summary>
        /// AutoProps.csにあるGetter、Setter(managementClass、classProperty)にセットされている
        /// プロパティ(値)を利用し、wmiInfoから情報をとってくる
        /// </summary>
        /// <see cref="System.Management"/>
        /// <returns>wmiInfoメソッドから取得したWmiの情報をstring型でreturnしている</returns>
        public static string getWmiInfo()
        {
            return wmiInfo(AutoProps.managementClass, AutoProps.classProperty);
        }

        /// <summary>
        /// AutoProps.csのmanagementClass、classPropertyGetter、Setterのプロパティを利用して、取得した
        /// Wmiの情報を返すメソッド
        /// </summary>
        /// <param name="managementClass">AutoProps.csのmanagementClassGetter、Setterのプロパティの値を参照している</param>
        /// <param name="classProperty">AutoProps.csのclassPropertyGetter、Setterのプロパティの値を参照している</param>
        /// <returns>上記のプロパティを利用してWmi情報を取得した値を"string"型で返している</returns>
        private static string wmiInfo(string managementClass, string classProperty)
        {
            var result = string.Empty;

            // ここでWmiの(managementClassに代入(指定)されいる)クラス全体の情報を格納している
            ManagementClass mc = new ManagementClass(managementClass);
            ManagementObjectCollection moc = mc.GetInstances();

            // ここでclassPropertyに代入(指定)されている値で返したい値を"foreach"で出している
            foreach (ManagementObject mo in moc)
            {
                result = mo[classProperty].ToString();
            }
            return result;
        }
    }
}
