using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

namespace Centerport
{
    public partial class frm_printers : Form
    {
        public frm_printers()
        {
            InitializeComponent();
            lbldefault.Text = "Default printer: " + Tool.PrinterPath();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_printers_Load(object sender, EventArgs e)
        {
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                //listBox1.Items.Add(printname);

                listBox1.Items.Add(printname.ToString());
            }
                     
        }
        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count >= 1)
            {
                string pname = this.listBox1.SelectedItem.ToString();
                myPrinters.SetDefaultPrinter(pname);
                lbldefault.Text = pname;
            }
            else
            {
                MessageBox.Show("Please Select Printer","Select Printer",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            
            }

           
        }
    
     
    }
}
