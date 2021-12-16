using System.Diagnostics;

namespace WinMaintenance
{
    class PSCommands
    {

        const string ps_command = @"Get-Process | Get-Process | Sort-Object PM -Descending | Out-File -FilePath ";
        //PowerShellの実行メソッド（引数:PowerShellコマンド)
        private void RegSettingsBackUp()
        {
            // パワーシェルのGet-Processをダンプしたかったのでここで出力ファイル定義(可変)を実行させる。
            string option = ps_command + @"C:\temp\dump.txt";
            OpenWithArguments(option);  // メソッド呼び出し
        }
        static void OpenWithArguments(string options)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "PowerShell.exe";
            //PowerShellのWindowを立ち上げずに実行したい場合は" cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; "
            // 引数optionsをShellのコマンドとして渡す。
            cmd.StartInfo.Arguments = options;
            cmd.Start();
        }
    }
}
