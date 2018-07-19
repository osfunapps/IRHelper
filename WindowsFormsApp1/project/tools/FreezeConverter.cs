using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.project.tools
{
    class FreezeConverter
    {

        public static int GetFreezeTime()
        {
            return Convert.ToInt32(AppForm.freezeTime * 1000);
        }


    }
}
