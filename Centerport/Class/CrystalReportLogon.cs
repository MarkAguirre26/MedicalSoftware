using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerport.Class
{
  public static class CrystalReportLogon
    {

      public static void Connect(ReportDocument cryRpt,string Server, string database,string uid,string pwd )
      {

           cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables ;

         //   cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt");
          //  Visit_Report1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            crConnectionInfo.ServerName = Server;
            crConnectionInfo.DatabaseName = database;
            crConnectionInfo.UserID = uid;
            crConnectionInfo.Password = pwd;

            CrTables = cryRpt.Database.Tables ;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
                     
      
      }

    }
}
