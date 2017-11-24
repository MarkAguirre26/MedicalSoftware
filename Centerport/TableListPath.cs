using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerport
{
 public   class TableListPath
    {

     public static string Psycho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Psycho.txt");
     public static string Patient_Profile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Patient_Profile.txt");

     public static string Lab = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LabSearch.txt");
     public static string HIVSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HIVSearch.txt");
     public static string XRAYSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "XRAYSearch.txt");
     public static string UTZSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UTZSearch.txt");
     public static string SEAMLCSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SEAMLCSearch.txt");
     public static string SEASECCSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SEASECSearch.txt");
     public static string LandBaseSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LandBaseCSearch.txt");
     public static string QueueSearchList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QueueSearch.txt");
     public static string MLC_PatientList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MLC_PatientList.txt");

     public static string Repeat_Hema_List = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Repeat_Hema_.txt");
     public static string Repeat_Chem_List = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Repeat_Chem_.txt");
     public static string Repeat_Fecal_List = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Repeat_Fecal_.txt");
     public static string Repeat_Urine_List = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Repeat_Urine_.txt");
 

 }
}
