using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.project.newnewnew
{
    class JavaKiller
    {

        public void KillAllJavaProcessess()
        {
            Process[] procs = Process.GetProcessesByName("javaw");
            foreach (Process p in procs) { p.Kill(); }

            Process[] procs2 = Process.GetProcessesByName("java");
            foreach (Process p in procs2) { p.Kill(); }



        }
    }
}
