using System.Diagnostics;

namespace WinMaintenance
{
    class PSCommands
    {
        //PowerShellの実行メソッド（引数:PowerShellコマンド)
        public void WaitCmdRun(string executeCommand)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + executeCommand);

            process = Process.Start(processStartInfo);
            process.WaitForExit();
        }

        public void NoWaitCmdRun(string executeCommand)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + executeCommand);

            process = Process.Start(processStartInfo);

            process.CloseMainWindow();
        }


        public void ExeRun(string executeCommand)
        {
            Process.Start(executeCommand);
        }
    }
}
