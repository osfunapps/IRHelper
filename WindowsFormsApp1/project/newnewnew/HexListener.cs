using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.project.tools;

namespace WindowsFormsApp1.project.newnewnew
{
    class HexListener
    {

        private Process p;
        private IHexListenerCallback callback;


        public HexListener(IHexListenerCallback callback)
        {
            this.callback = callback;
        }

        public void ListenToHex()
        {
            string hexOutput = p.StandardOutput.ReadLine();
            callback.OnHexReturned(hexOutput);
        }

        public void OpenHexListener()
        {

            string executingAppPath = Process.GetCurrentProcess().MainModule.FileName;
            string parentDir = Directory
                .GetParent(Directory.GetParent(Directory.GetParent(executingAppPath).ToString()).ToString()).ToString();
            string jarFilePath = @parentDir + "\\hex_listener\\hex_listener.jar";
            jarFilePath = AddQuotesIfRequired(jarFilePath);
            var freezeTime = FreezeConverter.GetFreezeTime();
            string path = "-jar " + jarFilePath +" "+ freezeTime;
            p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    FileName = "java.exe",
                    Arguments = path
                }
            };
            p.Start();
        }

        private string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrEmpty(path) ?
                path.Contains(" ") ? "\"" + path + "\"" : path
                : string.Empty;
        }

        public void KillListener()
        {
            if (p != null)
            {
                p.Kill();
                p.Close();
            }
        }
    }

    public interface IHexListenerCallback
    {
        void OnHexReturned(string hex);
    }


}