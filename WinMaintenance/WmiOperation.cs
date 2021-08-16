using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WinMaintenance
{
    class WmiOperation
    {
        public static string getWmiInfo()
        {
            return wmiInfo(AutoProps.managementClass, AutoProps.classProperty);
        }
        private static string wmiInfo(string managementClass, string classProperty)
        {
            var result = string.Empty;
            ManagementClass mc = new ManagementClass(managementClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                result = mo[classProperty].ToString();
            }
            return result;
        }
    }
}
