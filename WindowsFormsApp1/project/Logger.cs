using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.project
{
    internal class Logger
    {
        internal static string TITLE = "Log";

        internal static string GetTxt()
        {
            return "NOTICE: change EventGhost.exe to 8bit (256 color) and 'vista mode' for max performance!" +
                   "\n\nVersion 1.5:" +
                   "\n- fixed short cooldown on program init" +
                   "\n- added text to speech" +
                   "\n\nVersion 1.4" +
                   "\n- fixed an error regarding the ESC button functionality" +
                   "\n- now the computer user account will be identified automatically on startup. Place ghostKill.bat in the desktop for the program to run" +
                   "\n- fixed an error regarding event killer startup in vista comptability mode, where the loading bar is stuck on screen for a while" +
                   "\n" + 
                   "\nVersion 1.3" +
                   "\n- text scaled, changed color and relocated above mouse" +
                   "\n" +
                   "\nVersion 1.2" +
                   "\n- added a button for skipping a missing values" +
                   "\n- added an actions pop up window" +
                   "\n- fixed a few strings" +
                   "\n- added windows titles" +
                   "\n- pause and esc buttons changed to onRelease from onClick" +
                   "\n" +
                   "\nVersion 1.1:" +
                   "\n- added drag option to both fields" +
                   "\n- auto control realesed on exit";
        }
    }
}
