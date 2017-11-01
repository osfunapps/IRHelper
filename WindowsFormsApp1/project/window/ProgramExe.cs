using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.project.ghost
{
    public class ProgramExe
    {

        //instances
        private IProgramExeCallback programExeCallback;

        //params
        private static string TITLE_WINDOW_EVENT_GOHST = "EventGhost";

        public void RunGohstExe(IProgramExeCallback programExeCallback)
        {
            this.programExeCallback = programExeCallback;

            System.Diagnostics.Process.Start(AppForm.GetEventGohstPath());
            Thread.Sleep(1500);
            bool gohstWindowClosed = true;
            while (gohstWindowClosed)
            {
                Thread.Sleep(250);
                Console.WriteLine("trying again to look for the window!");
                if (!IsGhostWindowClosed())  gohstWindowClosed = false;
                
            }

            Thread.Sleep(800);
            programExeCallback.OnGhostWindowOpenAndFocused();

            //System.Diagnostics.Process.Start(PathsClass.getGhostPath());
        }

        private Boolean IsGhostWindowClosed()
        {
            return ExeWindowTitleReader.GetActiveWindowTitle().Contains(TITLE_WINDOW_EVENT_GOHST);
        }


        public interface IProgramExeCallback
        {
            void OnGhostWindowOpenAndFocused();
        }

        internal void RunGohstExeNoCallback()
        {
            System.Diagnostics.Process.Start(AppForm.GetEventGohstPath());
        }
    }
}
