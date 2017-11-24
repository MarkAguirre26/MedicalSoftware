using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Centerport
{
  public static  class Color
    {

      public static void ChangeBackColor(Control ctrl,System.Drawing.Color clr)
      {
         
              ctrl.BackColor = clr;
             
      }

    }
}
