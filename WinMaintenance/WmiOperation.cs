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
        /// Wmiクラスから参照し取得したWmiプロパティの値を返す
        /// </summary>
        /// <returns>指定されたクラスのプロパティの値を"文字列"で返す</returns>
        public string GetWmiInfo()
        {
                return WmiInfo();
        }

        /// <summary>
        /// Wmiクラスの中の"全プロパティ"を返す
        /// </summary>
        /// <returns>指定されたクラスの"全プロパティ"が入った"コレクション(ManagementObjectCollection)"を返す</returns>
        public ManagementObjectCollection GetWmiAll()
        {
                return WmiAll();
        }

        //Wmi関係の変数を定義
        private ManagementClass mc;
        private ManagementObjectCollection moc;

        /// <summary>
        /// Wmiクラスから参照し取得したWmiプロパティの値を返す
        /// </summary>
        /// <returns>指定されたクラスのプロパティの値を"文字列"で返す</returns>
        private string WmiInfo()
        {
            // 結果格納するの変数を初期化
            var result = string.Empty;
            do
            {
                // Wmiクラスの全プロパティを格納
                mc = new ManagementClass(AutoProps.managementClass);
                moc = mc.GetInstances();

                // nullチェックをし、NullException回避をしている
            } while (mc == null || moc == null);

                // mocに格納された中から指定されたプロパティの値を"result"へ格納する
                foreach (ManagementObject mo in moc)
                {
                    result = mo[AutoProps.classProperty].ToString();
                    mo.Dispose();
                }

                moc.Dispose();
                mc.Dispose();
                // 結果を返す
                return result;
        }

        /// <summary>
        /// Wmiクラスの中の"全プロパティ"を返す
        /// </summary>
        /// <returns指定されたクラスの"全プロパティ"が入った"コレクション(ManagementObjectCollection)"を返す></returns>
        private ManagementObjectCollection WmiAll()
        {
            do
            {
                // Wmiクラスの全プロパティを格納
                mc = new ManagementClass(AutoProps.managementClass);
                moc = mc.GetInstances();
                //nullチェックをし、NullException回避をしている
            } while (mc == null || moc == null);

            mc.Dispose();
            // 結果を返す
            return moc;
        }
    }
}
