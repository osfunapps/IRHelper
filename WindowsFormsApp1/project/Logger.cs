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
            return "Version 2.0:" +
                   "\n- now remotes which already finished can be migrated to the same directory as the finished ones" +
                   "\n- power off and power on switched" +
                   "\n- disconnected usb will inform with the problem. Restart the program" +
                   "\n- if run over is open, the session will run on all of the remotes in the directory" +
                   "\n\nNOTICE: change EventGhost.exe to 8bit (256 color) and 'vista mode' for max performance!" +
                   "\n\nVersion 1.6:" +
                   "\n- degree above window fixed" +
                   "\nVersion 1.5:" +
                   "\n- fixed paused and next buttons" +
                   "\n- fixed commands listin duration" +
                   "\n- user settings will now be saved" +
                   "\n- fixed short cooldown on program init" +
                   "\n- added text to speech + enable button" +
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
