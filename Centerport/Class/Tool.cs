using System;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Centerport
{
    public static class Tool
    {

        private static bool bl;
        public static string Papin;
        public static string Action_PatientInfo;
        public static string version = " 5.0";

        public static string ReplaceString(string str)
        {
            return str.Replace("'", "`").Replace(@"\", "\\");
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }



        public static DataTable GetDataSourceFromFile(string fileName)
        {
            DataTable dt = new DataTable();
            string[] columns = null;

            var lines = File.ReadAllLines(fileName);

            // assuming the first row contains the columns information
            if (lines.Count() > 0)
            {
                columns = lines[0].Split(new char[] { '\t' });

                foreach (var column in columns)
                {
                    dt.Columns.Add(column);
                }

            }


            // // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                DataRow dr = dt.NewRow();
                string[] values = lines[i].Split(new char[] { '\t' });

                for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    dr[j] = values[j];

                dt.Rows.Add(dr);
            }




            return dt;
        }

        public static DataTable GetDataSource_Repeat(string fileName)
        {
            DataTable dt = new DataTable();
            string[] columns = null;

            var lines = File.ReadAllLines(fileName);

            // assuming the first row contains the columns information
            //if (lines.Count() > 0)
            //{
            //   columns = lines[0].Split(new char[] { '\t' });
            //    //columns = new string[] { "Column1", "Column2", "Column3" };
            //    foreach (var column in columns)
            //    {
            //        dt.Columns.Add(column);
            //    }


            //}


            // // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                DataRow dr = dt.NewRow();
                string[] values = lines[i].Split(new char[] { '\t' });

                for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    dr[j] = values[j];

                dt.Rows.Add(dr);
            }




            return dt;
        }

        public static string CurrentVersion
        {
            get
            {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string PrinterPath()
        {

            PrinterSettings settings = new PrinterSettings();
            string Name = settings.PrinterName;
            return Name;
        }


        public static long GetInt(string str)
        {
            var phone = str;
            String ans = string.Join("", phone.ToCharArray().Where(Char.IsDigit));
            long a = Convert.ToInt64(ans);
            a += 1;
            return a;
        }

        public static void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
        public static void SetCursor(Control control)
        {

            foreach (Control c in control.Controls)

                if (c is RadioButton)
                {
                    (c as RadioButton).Cursor = Cursors.Hand;

                }

        }

        public static void ClearForm(Form frm)
        {
            foreach (Control c in frm.Controls)

                if (c is TextBox)
                {
                    (c as TextBox).Clear();

                }


        }


        public static void ClearFields(Control control)
        {

            foreach (Control c in control.Controls)

                if (c is TextBox)
                {
                    (c as TextBox).Clear();

                }

            foreach (Control c in control.Controls)

                if (c is ComboBox)
                {
                    (c as ComboBox).Text = "";

                }

            foreach (Control c in control.Controls)

                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Text = "00000000";

                }
            foreach (Control c in control.Controls)

                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;

                }
            foreach (Control c in control.Controls)
                if (c is CheckBox)
                {
                    (c as CheckBox).Checked = false;
                }

            foreach (Control c in control.Controls)
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Format = DateTimePickerFormat.Custom; (c as DateTimePicker).CustomFormat = "MM/dd/yyyy";
                }

            foreach (Control c in control.Controls)
            {
                if (c is RichTextBox)
                {
                    (c as RichTextBox).Clear();
                }
            }


        }

        public static void setformat(Control control)
        {

            foreach (Control c in control.Controls)
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Format = DateTimePickerFormat.Custom; (c as DateTimePicker).CustomFormat = "MM/dd/yyyy";
                }
        }

        public static bool SetColor(Control cotrol)
        {

            foreach (Control c in cotrol.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")
                    {
                        c.BackColor = System.Drawing.Color.Red;
                        bl = false;
                    }
                    else
                    {
                        //c.BackColor = System.Drawing.Color.White;
                        bl = true;
                    }
                }
            }


            foreach (Control c in cotrol.Controls)
            {
                if (c is DateTimePicker)
                {
                    if (c.Text == "00/00/0000")
                    {
                        c.ForeColor = System.Drawing.Color.Red;

                        bl = false;
                    }
                    else
                    {
                        //c.ForeColor = System.Drawing.Color.White;
                        bl = true;
                    }
                }
            }
            foreach (Control c in cotrol.Controls)
            {
                if (c is ComboBox)
                {
                    if (c.Text == "")
                    {
                        c.BackColor = System.Drawing.Color.Red;
                        bl = false;
                    }
                    else
                    {
                        //c.BackColor = System.Drawing.Color.White;
                        bl = true;
                    }
                }
            }
            foreach (Control c in cotrol.Controls)
            {
                if (c is RichTextBox)
                {
                    if (c.Text == "")
                    {
                        c.BackColor = System.Drawing.Color.Red;
                        bl = false;
                    }
                    else
                    {
                        //c.BackColor = System.Drawing.Color.White;
                        bl = true;
                    }
                }
            }



            return bl;
        }

        public static void SetEnable(Control control, bool bl)
        {

            foreach (Control c in control.Controls)

                if (c is TextBox)
                {
                    (c as TextBox).Enabled = bl;

                }

            foreach (Control c in control.Controls)

                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = bl;

                }

            foreach (Control c in control.Controls)

                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Enabled = bl;

                }
            foreach (Control c in control.Controls)

                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = bl;

                }
            foreach (Control c in control.Controls)

                if (c is DataGridView)
                {
                    (c as DataGridView).Enabled = bl;

                }
            foreach (Control c in control.Controls)

                if (c is CheckBox)
                {
                    (c as CheckBox).Enabled = bl;

                }

            foreach (Control c in control.Controls)

                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = bl;

                }
            foreach (Control c in control.Controls)

                if (c is RichTextBox)
                {
                    (c as RichTextBox).Enabled = bl;

                }


        }

        public static Image bytetoimage(byte[] bytearray)
        {

            Image img = null;


            try
            {

                using (MemoryStream ms = new MemoryStream(bytearray))
                {

                    img = Image.FromStream(ms, true);

                }
            }
            catch (Exception)
            {
                img = Properties.Resources.AnonymousPic;
                // throw;
            }



            return img;
        }

        public static byte[] ImageToByte(Image img)
        {
            using (Bitmap bmp = new Bitmap(img))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }




        public static void MessageBoxSave()
        {
            MessageBox.Show("New record successfully saved", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void MessageBoxUpdate()
        {
            MessageBox.Show("Record successfully updated", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void MessageBoxDelete()
        {
            MessageBox.Show("Record has been deleted", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void MessageBoxDeniede()
        {
            MessageBox.Show("Action Denied! Please fill required information", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;

        }



    }
}
