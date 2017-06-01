using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTM_Proj
{
    public static class Helper
    {
        public static void log(string info)
        {
            string currentTime = DateTime.Now.ToString("h:mm:ss tt");
            Console.WriteLine(currentTime + ": " + info);
        }
    }
}
