using System;
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
        /// <returns>
        /// wmiInfoメソッドから取得したWmiの情報をstring型でreturnしている
        /// </returns>
        public string getWmiInfo()
        {
                return wmiInfo(AutoProps.managementClass, AutoProps.classProperty);
        }

        public ManagementObjectCollection getWmiAll()
        {
                return wmiAll(AutoProps.managementClass);
        }

        /// <summary>
        /// AutoProps.csのmanagementClass、classPropertyGetter、Setterのプロパティを利用して、取得した
        /// Wmiの情報を返すメソッド
        /// </summary>
        /// <param name="managementClass">AutoProps.csのmanagementClassGetter、Setterのプロパティの値を参照している</param>
        /// <param name="classProperty">AutoProps.csのclassPropertyGetter、Setterのプロパティの値を参照している</param>
        /// <returns>上記のプロパティを利用してWmi情報を取得した値を"string"型で返している</returns>
        private ManagementClass mc;
        private ManagementObjectCollection moc;
        private string wmiInfo(string managementClass, string classProperty)
        {
                var result = string.Empty;
            do
            {
                // ここでWmiの(managementClassに代入(指定)されいる)クラス全体の情報を格納している
                mc = new ManagementClass(managementClass);
                moc = mc.GetInstances();

                //nullチェックをし、Null系のException回避をしている
            } while (mc == null || moc == null);

                // ここでclassPropertyに代入(指定)されている値で返したい値を"foreach"で出している
                foreach (ManagementObject mo in moc)
                {
                    result = mo[classProperty].ToString();
                    mo.Dispose();
                }

                moc.Dispose();
                mc.Dispose();

                return result;
        }

        /// <summary>
        /// AutoProps.csのmanagementClass、Getter、Setterのプロパティを利用して、取得した
        /// Wmiの情報"全て"を返すメソッド
        /// </summary>
        /// <param name="managementClass">AutoProps.csのmanagementClassGetter、Setterのプロパティの値を参照している</param>
        /// <returns>上記のプロパティを利用してWmi情報"全て"を取得した値を"ManagementObjectCollection"型で返している</returns>
        private ManagementObjectCollection wmiAll(string managementClass)
        {
            do
            {
                // ここでWmiの(managementClassに代入(指定)されいる)クラス全体の情報を格納している
                mc = new ManagementClass(managementClass);
                moc = mc.GetInstances();
                //nullチェックをし、Null系のException回避をしている
            } while (mc == null || moc == null);

            mc.Dispose();

            return moc;
        }
    }
}
