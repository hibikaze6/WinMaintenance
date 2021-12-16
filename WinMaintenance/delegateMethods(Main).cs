using System.Management;

namespace WinMaintenance
{
    partial class Main
    {
        /// <summary>
        /// なにも受け取らない、引き渡さないDelegate型 delVoid
        /// </summary>
        delegate void DelVoid();

        /// <summary>
        /// ManagementObjectを引数とするDelegate型 delMo
        /// </summary>
        /// <param name="mo">ManagementObjectの引数を引き渡す</param>
        delegate bool DelMo(ManagementObject mo);

        /// <summary>
        /// intを引数とするDelegate型 delInt
        /// </summary>
        /// <param name="value">intの引数を引き渡す</param>
        delegate void DelInt(int value);

        /// <summary>
        /// double型2つを引数とするDelegate型 delDouble
        /// </summary>
        /// <param name="value">1つ目のdoubleの引数を引き渡す</param>
        ///  <param name="value2">2つ目のdoubleの引数を引き渡す</param>
        delegate void DelDouble2(double value, double value2);

        /// <summary>
        /// stringを引数とするDelegate型 delStr
        /// </summary>
        /// <param name="value">stringの引数を引き渡す</param>
        delegate void DelStr(string value);
    }
}
