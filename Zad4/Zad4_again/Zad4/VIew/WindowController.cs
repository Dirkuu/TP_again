using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4.VIew
{
    public class WindowController
    {
        public static void ShowWindow()
        {
            var secondWindow = new EditClient();
            secondWindow.Show();
        }
    }
}
