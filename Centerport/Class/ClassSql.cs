using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.ServiceProcess;


namespace Centerport
{
    public class ClassSql
    {
        public static bool ConnState = true;
        private static MySqlCommand cmd;
        public static MySqlConnection cnn;
        public static MySqlDataReader dr;
        public static DataTable dt;
        private static long Papin; private static long TrackId;
        public static DataTable dt_patient;
        public static string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConnectionString.txt");
        public static string Update = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Update.txt");
        public static string EmployerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Employer.txt");
        //public static string HemaPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Hema.txt");
        //public static string ChemistryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Chemistry.txt");
        //public static string HivPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HIV.txt");
        public static string MMS_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedicalManagementSoftware.ini");
        public static string tmp_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "temp.txt");
        public static string HIV_TempImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HIV_Image");
        //public static string SeabaseImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SeabaseImage");
        //public static string LandbaseImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LandbaseImage");
        public static string ConnString;// = File.ReadAllText(AppData);
        public static DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);

        public static string MyConString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyConString.ini");
        public static void ConnectSqlInstance(string InstanceName)
        {
            string myServiceName = "MSSQL$" + InstanceName;
            string status;
            ServiceController mySC = new ServiceController(myServiceName);

            try
            {
                status = mySC.Status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new frm_Instance().ShowDialog();
                return;

            }


            if (mySC.Status.Equals(ServiceControllerStatus.Stopped) | mySC.Status.Equals(ServiceControllerStatus.StopPending))
            {
                try
                {

                    mySC.Start();
                    mySC.WaitForStatus(ServiceControllerStatus.Running);


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error in starting the service: " + ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }



        }

        public static void DbConnect()
        {

            try
            {

                cnn = new MySqlConnection(ConnString);
                cnn.Open();
                ConnState = true;
                // MessageBox.Show("Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                ConnState = false;


                //Application.OpenForms["Main"].Close();
                MessageBox.Show(String.Format("an error accured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                new frm_server().ShowDialog();
                if (cnn.State == ConnectionState.Open) { cnn.Close(); cnn.Dispose(); }
                //Application.Exit();

            }



        }


        public static void TempConnect()
        {

            try
            {

                cnn = new MySqlConnection(ConnString);
                cnn.Open();
                MessageBox.Show("Successfully Connected", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConnState = true;
                Application.OpenForms["frm_server"].Close();

            }
            catch (Exception ex)
            {
                ConnState = false;
                File.Delete(AppData);
                MessageBox.Show(String.Format("an error accured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cnn.State == ConnectionState.Open) { cnn.Close(); cnn.Dispose(); }


            }
            //finally
            //{
            //    if (cnn.State == ConnectionState.Open) { cnn.Close(); }
            //}


        }


        public void MySqlBackup(string ConnectionString)
        {


            SaveFileDialog Save = new SaveFileDialog();
            Save.DefaultExt = "sql";
            Save.Filter = "SQl file (*.sql)|*.sql";
            Save.FileName = "cmsi-" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "") + ".sql";
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(Save.FileName);

                            conn.Close();
                            MessageBox.Show("Database Successfully Backup ", "Backed up Database", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }


        }

        public void MysqlRestore(string ConnectionString)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = "sql";
            open.Filter = "SQl file (*.sql)|*.sql";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(open.FileName);
                            conn.Close();
                            MessageBox.Show("Database Successfully Restored", "Restored Database", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Cursor.Current = Cursors.Default;
                        }
                    }
                }


            }




        }




        public static string CreateID()
        {
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            string str;
            var list = db.Create_Patient_ID();
            foreach (var i in list)
            {
                string LastPapin = i.papin.ToString();
                Papin = Tool.GetInt(LastPapin);
            }

            return str = Papin.ToString("CMSI00000000");


        }

        public static string Generate_ResultID(string qry, string field, string Format)
        {


            string str;
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String LastPapin = dr[field].ToString();
                    Papin = Tool.GetInt(LastPapin);
                }
                conn.Close();
                return str = Format + Papin.ToString();

            }




        }



        public static string CreateTrackingId()
        {


            string str;
            //ClassSql a = new ClassSql(); 
            MySqlDataReader dr;
            //dr = a.Mytable("SELECT t_registration.trkid FROM t_registration ORDER BY t_registration.trkid DESC limit 1");
            //cmd = new MySqlCommand(qry, conn);
            //dr = cmd.ExecuteReader();            



            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                cmd = new MySqlCommand("SELECT t_registration.trkid FROM t_registration ORDER BY t_registration.trkid DESC limit 1", conn);
                dr = cmd.ExecuteReader();
                //dr.Close();

                while (dr.Read())
                {
                    String TrackingId = dr["trkid"].ToString();
                    TrackId = Tool.GetInt(TrackingId);
                }

                conn.Close();


            }


            return str = TrackId.ToString("00000000");


        }


        public void executequeryStoreproc(string query, string Parameter, object[] Paramvalue, CommandType cmdtype = CommandType.StoredProcedure)
        {

            if (Parameter.Contains(','))
            {

                string[] parameters = Parameter.Split(',');
                if (parameters.Length - 1 != Paramvalue.Length - 1)
                {
                    MessageBox.Show("Parameter count is invalid", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (MySqlConnection con = new MySqlConnection(ClassSql.ConnString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            for (int i = 0; i <= parameters.Length - 1; i++)
                            {
                                cmd.Parameters.AddWithValue("@" + parameters[i].Trim(), Paramvalue[i].ToString().Trim());
                            }
                            con.Open();
                            cmd.CommandType = cmdtype;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                using (MySqlConnection con = new MySqlConnection(ClassSql.ConnString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@" + Parameter, Paramvalue[Paramvalue.Length - 1]);
                        con.Open();
                        cmd.CommandType = cmdtype;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        //Close connection
        public static void DbClose()
        {

            try
            {
                cnn = new MySqlConnection();
                cnn.ConnectionString = ConnString;
                cnn.Close();
                cnn.Dispose();

            }
            catch //(Exception ex)
            {
                Application.Restart();
                //  MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Close database connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
        //Execute record
        public void ExecuteQuery(string query)
        {



            try
            {
                DbConnect();
                cmd = new MySqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                //DbClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            finally
            {
                if (cnn != null)
                {
                    DbClose();

                }
            }
        }
        //Load Record
        public MySqlDataReader Mytable(string qry)
        {
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                dr = cmd.ExecuteReader();
                //dr.Close();
                conn.Close();
                return dr;

            }
            //MySqlDataReader dr;

        }
        public static DataTable GetData_Data(string qry)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }

        public static DataTable GetData_Data_proc(string ProcName, string SearchID)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                MySqlCommand cmd = new MySqlCommand(ProcName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SearchID);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }


        public DataTable Mytable_Proc(string Proc_Name, string Indentifier, string SearchId)
        {
            // DbClose();
            // DbConnect();

            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {

                conn.Open();
                MySqlDataAdapter da; DataTable dt;
                cmd = new MySqlCommand(Proc_Name, conn);
                da = new MySqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Indentifier, SearchId);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;


            }



        }

        public DataSet Mytable_Report(string Proc_Name, string Indentifier, string SearchId)
        {

            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();

                MySqlDataAdapter da; DataSet ds;
                cmd = new MySqlCommand(Proc_Name, conn);
                da = new MySqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@" + Indentifier, SearchId);
                ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;


            }

        }
        public DataTable Table(string qry)
        {

            //   DbConnect();
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;


            }



        }



        //Populate ComboBox
        //public void PutDataTOComboBox(string qry, ComboBox cbo, string FieldName, string cn)
        //{


        //    try
        //    {
        //        // DbConnect();

        //        using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
        //        {
        //            conn.Open();
        //            cmd = new MySqlCommand(qry, conn);
        //            dr = cmd.ExecuteReader();
        //            cbo.Items.Clear();
        //            while (dr.Read())
        //            {

        //                cbo.Items.Add(new ComboBoxItem(dr[FieldName].ToString(), dr[cn].ToString()));

        //            }
        //            conn.Close();
        //        }

        //        // DbClose();



        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    { dr.Close(); }




        //}
        public void PutDataTOComboBox_ByID(string qry, ComboBox cbo, string FieldName)
        {


            try
            {
                using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                    //cbo.Items.Clear();
                    while (dr.Read())
                    {

                        //  cbo.Items.Add(new ComboBoxItem(dr[FieldName].ToString(), dr[cn].ToString()));
                        cbo.Text = dr[FieldName].ToString();

                    }
                    conn.Close();
                }


                //  DbClose();
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            { if (cnn != null) { DbClose(); dr.Close(); } }




        }



        //public  void CheckUpdate(string NewPath, string OldPath)
        //{




        //}



        public void PutDataTOTextBox(string qry, TextBox text, string FieldName)
        {


            try
            {

                using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                    //cbo.Items.Clear();
                    while (dr.Read())
                    {


                        text.Text = dr[FieldName].ToString();

                    }

                    conn.Close();
                }


            }
            catch //(Exception ex)
            {
                //  MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 

            }
            finally
            { dr.Close(); }

        }



        //Populate ListBox
        public void PutDataTOListBox(string qry, ListBox Listbox, string FieldName, string cn)
        {

            try
            {

                // DbConnect();
                using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                    Listbox.Items.Clear();
                    while (dr.Read())
                    {


                        foreach (string s in Regex.Split(dr[FieldName].ToString(), "\n"))
                            Listbox.Items.Add(new ListboxItem(s, dr[cn].ToString()));

                    }
                    conn.Close();
                }





                //DbClose();
            }
            catch
            {


            }
            finally
            { dr.Close(); }


        }

        //Buckup and Restore Database
        //Note: MysqlBuckUp.net used in this process
        //public void MySqlBackup(string ConnectionString)
        // {

        //     SaveFileDialog Save = new SaveFileDialog();

        //     Save.DefaultExt = "sql";
        //     Save.Filter = "SQl file (*.sql)|*.sql";
        //     if (Save.ShowDialog() == DialogResult.OK)
        //     {

        //         using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //         {
        //             using (MySqlCommand cmd = new MySqlCommand())
        //             {
        //                 using (MySqlBackup mb = new MySqlBackup(cmd))
        //                 {
        //                     cmd.Connection = conn;
        //                     conn.Open();
        //                     mb.ExportToFile(Save.FileName);
        //                     conn.Close();
        //                     MessageBox.Show("Database Successfully Backup to " + Save.FileName, "Buck Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                 }
        //             }
        //         }
        //     }





        // }
        //public void MysqlRestore(string ConnectionString)
        //{
        //    OpenFileDialog open = new OpenFileDialog();
        //    open.DefaultExt = "sql";
        //    open.Filter = "SQl file (*.sql)|*.sql";
        //    if (open.ShowDialog() == DialogResult.OK)
        //    {

        //        using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //        {
        //            using (MySqlCommand cmd = new MySqlCommand())
        //            {
        //                using (MySqlBackup mb = new MySqlBackup(cmd))
        //                {
        //                    cmd.Connection = conn;
        //                    conn.Open();
        //                    mb.ImportFromFile(open.FileName);
        //                    MessageBox.Show("Database Successfully Restored ", "Buck Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    conn.Close();

        //                }
        //            }
        //        }


        //    }




        //}

        public int CountColumn(string qry)
        {


            //  DbConnect();
            int count;
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                //cnt = b.CountColumn("SELECT Count(m_patient.cn) AS count FROM m_patient WHERE m_patient.lastname = '" + Tool.ReplaceString(txt_lname.Text) + "' AND m_patient.firstname = '" + Tool.ReplaceString(txt_fname.Text) + "' AND m_patient.middlename = '" + Tool.ReplaceString(txt_Mname.Text) + "'");
                cmd = new MySqlCommand(qry, conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }


            return count;

        }


        public void GetCount(string qry, TextBox txt, string FieldName)
        {


            try
            {

                //  DbConnect();

                using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                    //cbo.Items.Clear();
                    while (dr.Read())
                    {


                        txt.Text = dr[FieldName].ToString();

                    }
                    conn.Close();
                }





                // DbClose();
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            { dr.Close(); }


        }



        public void GEtTotalCount(string qry, Label label, string FieldName)
        {


            try
            {

                // DbConnect();
                cmd = new MySqlCommand(qry, cnn);
                dr = cmd.ExecuteReader();
                //cbo.Items.Clear();
                while (dr.Read())
                {

                    //  cbo.Items.Add(new ComboBoxItem(dr[FieldName].ToString(), dr[cn].ToString()));
                    label.Text = "Items: " + dr[FieldName].ToString();

                }
                //  DbClose();
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            { dr.Close(); }




        }

        public void GEtTotalNew(string qry, Label label, string FieldName)
        {


            try
            {

                //DbConnect();
                cmd = new MySqlCommand(qry, cnn);
                dr = cmd.ExecuteReader();
                //cbo.Items.Clear();
                while (dr.Read())
                {

                    //  cbo.Items.Add(new ComboBoxItem(dr[FieldName].ToString(), dr[cn].ToString()));
                    label.Text = "New: " + dr[FieldName].ToString();

                }
                // DbClose();
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Connect database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            { dr.Close(); }




        }



        public string ReplaceString(string str)
        { return str.Replace("'", "").Replace(@"\", ""); }









    }
}
