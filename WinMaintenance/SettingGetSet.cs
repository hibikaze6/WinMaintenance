using System.Windows.Forms;

namespace WinMaintenance
{
    partial class Main : Form
    {
        RegSet RegSet = new RegSet();
        private void regSetteingGet() 
        {
            AutoProps.regKeyPass = @"SOFTWARE\Microsoft\Windows\CurrentVersion\" +
               @"Explorer\FolderDescriptions\{0ddd015d-b06c-45d5-8c4c-f59713854639}\PropertyBag\";

            AutoProps.regSubKeyName = "ThisPCPolicy";


            //Picture Show Hide Check
            if (!RegSet.regLocaValueReturn().Contains("none") && RegSet.regLocaValueReturn().Contains("Hide"))
            {
                pcHidePictureCheckbox.Checked = true;
            }
        }

        private void regSettingSet()
        {
            //Picture Show Hide Check
            if (pcHidePictureCheckbox.Checked && RegSet.regLocaValueReturn().Contains("Show"))
            {
                AutoProps.regKeyPass = @"SOFTWARE\Microsoft\Windows\CurrentVersion\" +
                    @"Explorer\FolderDescriptions\{0ddd015d-b06c-45d5-8c4c-f59713854639}\PropertyBag\";

                AutoProps.regSubKeyName = "ThisPCPolicy";

                
            }
        }
    }
}
