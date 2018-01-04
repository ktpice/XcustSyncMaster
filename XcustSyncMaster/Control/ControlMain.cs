using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XcustSyncMaster
{
    public class ControlMain
    {
        public InitC initC;        //standard
        private IniFile iniFile;        //standard
        private StringBuilder sYear = new StringBuilder();
        private StringBuilder sMonth = new StringBuilder();
        private StringBuilder sDay = new StringBuilder();
        public string[] args;
        public String xcustpowebservice_run="", xcustprwebservice_run = "";
        public String xcustGlPwebservice_run = "", xcustAPSourcewebservice_run = "", xcustGLEntitywebservice_run = ""; //kwl 20171129
        public String xcustTaxCodewebservice_run = "", xcustSupplierwebservice_run = "", xcustSupplierSitewebservice_run = ""; //kwl 20171130
        public String xcustGlCodeCombinationwebservice_run = "", xcustLocationwebservice_run = ""; //kwl 20171206
        public String xcustblanketheader_run = ""; //ktp 20171130
        public String xcustitemmstwebservice_run = ""; //kts
        public String xcustsubinvmstwebservice_run = "";  //kts

        public String xcustblanketline_run = ""; //ktp 20171130
        public String xcustGlLedger_run = ""; //ktp 20180104

        public String xcustuommstwebservice_run = "";  //kts


        public ControlMain()
        {
            initConfig();            
        }
        private void initConfig()
        {
            iniFile = new IniFile(Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini");        //standard
            initC = new InitC();        //standard

            GetConfig();
        }
        public void setAgrument()
        {
            if (args == null) return;
            foreach (String arg in args)
            {
                String[] aaa = arg.Split('=');
                if (aaa.Length > 1)
                {
                    //MessageBox.Show("arg[0] " + aaa[0]+"    arg[1] " + aaa[1], "arg[1] "+ aaa[1]);
                    xcustpowebservice_run = aaa[0].Equals("xcustpowebservice_run") ? aaa[1] : "";   //xcustpowebservice_run
                    xcustprwebservice_run = aaa[0].Equals("xcustprwebservice_run") ? aaa[1] : "";
                    xcustGlPwebservice_run = aaa[0].Equals("xcustGlPwebservice_run") ? aaa[1] : ""; //kwl 20171129
                    xcustAPSourcewebservice_run = aaa[0].Equals("xcustAPSourcewebservice_run") ? aaa[1] : ""; //kwl 20171129
                    xcustGLEntitywebservice_run = aaa[0].Equals("xcustGLEntitywebservice_run") ? aaa[1] : ""; //kwl 20171129
                    xcustTaxCodewebservice_run = aaa[0].Equals("xcustTaxCodewebservice_run") ? aaa[1] : ""; //kwl 20171130
                    xcustTaxCodewebservice_run = aaa[0].Equals("xcustSupplierwebservice_run") ? aaa[1] : ""; //kwl 20171130
                    xcustTaxCodewebservice_run = aaa[0].Equals("xcustSupplierSitewebservice_run") ? aaa[1] : ""; //kwl 20171130
                    xcustitemmstwebservice_run = aaa[0].Equals("xcustitemmstwebservice_run") ? aaa[1] : ""; //kts
                    xcustitemmstwebservice_run = aaa[0].Equals("xcustsubinvmstwebservice_run") ? aaa[1] : ""; //kts
                    xcustuommstwebservice_run = aaa[0].Equals("xcustuommstwebservice_run") ? aaa[1] : ""; //kts

                }
            }
        }
        public void createFolder(String path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        
        public String[] getFileinFolder(String path)
        {
            string[] filePaths = null;
            if (Directory.Exists(path))
            {
                filePaths = Directory.GetFiles(@path);
            }
             
            return filePaths;
        }
        public String[] getFileinFolder(String path, String app)
        {
            string[] filePaths = null;
            String filename = "";
            if (Directory.Exists(path))
            {
                filePaths = Directory.GetFiles(@path, "*"+app+"*");
            }

            return filePaths;
        }
        public void moveFile(String sourceFile, String destinationFile)
        {
            System.IO.File.Move(@sourceFile, @destinationFile);
        }
        public void deleteFile(String sourceFile)
        {
            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Delete(@sourceFile);
            }
        }
        public void setConfig(String key, String value)
        {
            iniFile.Write(key, value);
        }
        public void GetConfig()
        {

            initC.usercloud = iniFile.Read("usercloud"); 
            initC.passcloud = iniFile.Read("passcloud"); 


            initC.EmailPort = iniFile.Read("EmailPort");

            initC.EmailCharset = iniFile.Read("EmailCharset");      //orc master
            initC.EmailUsername = iniFile.Read("EmailUsername");
            initC.EmailPassword = iniFile.Read("EmailPassword");
            initC.EmailSMTPSecure = iniFile.Read("EmailSMTPSecure");
            

            initC.EmailHost = iniFile.Read("EmailHost");        // orc backoffice
            initC.EmailSender = iniFile.Read("EmailSender");
           

            initC.databaseDBKFCPO = iniFile.Read("databaseDBKFCPO");        // orc BIT
            initC.hostDBKFCPO = iniFile.Read("hostDBKFCPO");
            initC.userDBKFCPO = iniFile.Read("userDBKFCPO");
            initC.passDBKFCPO = iniFile.Read("passDBKFCPO");
            initC.portDBKFCPO = iniFile.Read("portDBKFCPO");


            initC.AutoItemMaster = iniFile.Read("AutoItemMaster"); //kts
            initC.AutoSubInvMaster = iniFile.Read("AutoSubInvMaster"); //kts
            initC.AutoUomMaster = iniFile.Read("AutoUomMaster"); //kts

            initC.AutoGlPeriod = iniFile.Read("AutoGlPeriod");  //kwl 20171129
            initC.AutoApSource = iniFile.Read("AutoApSource");  //kwl 20171129
            initC.AutoGlEntity = iniFile.Read("AutoGlEntity");  //kwl 20171129
            initC.AutoGlEntity = iniFile.Read("AutoTaxCode");  //kwl 20171130
            initC.AutoGlEntity = iniFile.Read("AutoSupplier");  //kwl 20171130
            initC.AutoGlEntity = iniFile.Read("AutoSupplierSite");  //kwl 20171130

            

            //initC.grdQuoColor = iniFile.Read("gridquotationcolor");

            //initC.HideCostQuotation = iniFile.Read("hidecostquotation");
            //if (initC.grdQuoColor.Equals(""))
            //{
            //    initC.grdQuoColor = "#b7e1cd";
            //}
            //initC.Password = regE.getPassword();
        }
        /*
         * check qty ว่า data type ถูกต้องไหม
         * ที่ใช้ int.tryparse เพราะ ใน database เป็น decimal(18,0)
         * Error PO001-006 : Invalid data type
         */
        public Boolean validateQTY(String qty)
        {
            Boolean chk = false;
            int i = 0;
            chk = int.TryParse(qty, out i);
            return chk;
        }
        public String dateYearShortToDB(String date)
        {
            String chk = "", year = "", month="", day="";

            year = date.Substring(date.Length - 2);
            day = date.Substring(4, 2);
            month = date.Substring(0, 2);

            chk = "20" + year + "-" + month + "-" + day;

            return chk;
        }
        public Boolean validateDate(String date)
        {
            Boolean chk = false;
            if (date.Length == 8)
            {
                sYear.Clear();
                sMonth.Clear();
                sDay.Clear();
                try
                {
                    sYear.Append(date.Substring(0, 4));
                    sMonth.Append(date.Substring(4, 2));
                    sDay.Append(date.Substring(6, 2));
                    if ((int.Parse(sYear.ToString()) > 2000) && (int.Parse(sYear.ToString()) < 2100))
                    {
                        if ((int.Parse(sMonth.ToString()) >= 1) && (int.Parse(sMonth.ToString()) <= 12))
                        {
                            if ((int.Parse(sDay.ToString()) >= 1) && (int.Parse(sDay.ToString()) <= 31))
                            {
                                chk = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    chk = false;
                }
                finally
                {

                }

            }
            else
            {
                chk = false;
            }
            return chk;
        }
        public Boolean validateDate1(DateTime date)
        {
            Boolean chk = false;
            //if (date.Length == 8)
            //{
            //    sYear.Clear();
            //    sMonth.Clear();
            //    sDay.Clear();
            //    try
            //    {
            //        sYear.Append(date.Substring(0, 4));
            //        sMonth.Append(date.Substring(4, 2));
            //        sDay.Append(date.Substring(6, 2));
            //        if ((int.Parse(sYear.ToString()) > 2000) && (int.Parse(sYear.ToString()) < 2100))
            //        {
            //            if ((int.Parse(sMonth.ToString()) >= 1) && (int.Parse(sMonth.ToString()) <= 12))
            //            {
            //                if ((int.Parse(sDay.ToString()) >= 1) && (int.Parse(sDay.ToString()) <= 31))
            //                {
            //                    chk = true;
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        chk = false;
            //    }
            //    finally
            //    {

            //    }

            //}
            //else
            //{
            //    chk = false;
            //}
            return chk;
        }
        //ktp
       /* public String validateSubInventoryCode(String ordId, String StoreCode, List<XcustSubInventoryMstTbl> listXcSIMT)
        {
            String chk = "";
            foreach (XcustSubInventoryMstTbl item in listXcSIMT)
            {
                if (item.ORGAINZATION_ID.Equals(ordId.Trim()))
                {
                    if (item.attribute1.Equals(StoreCode.Trim()))
                    {
                        chk = item.SECONDARY_INVENTORY_NAME;
                        break;
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateItemCodeByOrgRef(String ordId, String item_code, List<XcustItemMstTbl> listXcIMT)
        {
            Boolean chk = false;
            foreach (XcustItemMstTbl item in listXcIMT)
            {
                if (item.ORGAINZATION_ID.Equals(ordId.Trim()))
                {
                    if (item.ITEM_REFERENCE1.Equals(item_code.Trim()))
                    {
                        chk = true;
                        break;
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateSupplierBySupplierCode(String supplier_code, List<XcustSupplierMstTbl> listXcSMT)
        {
            Boolean chk = false;
            foreach (XcustSupplierMstTbl item in listXcSMT)
            {
                if (item.SUPPLIER_NUMBER.Equals(supplier_code.Trim()))
                {
                    chk = true;
                    break;
                }
            }
            return chk;
        }*/
        /*public Boolean validateUOMCodeByUOMCode(String uomCode, List<XcustUomMstTbl> listXcUMT)
        {
            Boolean chk = false;
            foreach (XcustUomMstTbl item in listXcUMT)
            {
                if (item.UOM_CODE.Equals(uomCode.Trim()))
                {
                    chk = true;
                    break;
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment1(String valuesetcode, String enableflag, String value,List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment2(String valuesetcode, String enableflag, String value, List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment3(String valuesetcode, String enableflag, String value, List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment4(String valuesetcode, String enableflag, String value, List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment5(String valuesetcode, String enableflag, String value, List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public Boolean validateValueBySegment6(String valuesetcode, String enableflag, String value, List<XcustValueSetMstTbl> listXcVSMT)
        {
            Boolean chk = false;
            foreach (XcustValueSetMstTbl item in listXcVSMT)
            {
                if (item.VALUE_SET_CODE.Equals(valuesetcode.Trim()))
                {
                    if (item.ENABLED_FLAG.Equals(enableflag.Trim()))
                    {
                        if (item.VALUE.Equals(value.Trim()))
                        {
                            chk = true;
                            break;
                        }
                    }
                }
            }
            return chk;
        }*/
        /*public void logProcess(String programname, List<ValidatePrPo> lVPr, String startdatetime, List<ValidateFileName> listfile)
        {
            String line1 = "", parameter="", programstart="", filename="", recordError="", txt="";
            int cntErr = 0, err=0;
            if (programname.ToLower().Equals("xcustpo001"))
            {
                line1 = "Program : XCUST Interface PR<Linfox>To PO(ERP)" + Environment.NewLine;
            }
            parameter = "Parameter : "+Environment.NewLine;
            parameter += "           Path Initial :" + initC.PathInitial + Environment.NewLine;
            parameter += "           Path Process :" + initC.PathProcess + Environment.NewLine;
            parameter += "           Path Error :" + initC.PathError + Environment.NewLine;
            parameter += "           Import Source :" + initC.ImportSource + Environment.NewLine;
            programstart = "Program Start : " + startdatetime + Environment.NewLine;
            if (listfile.Count > 0)
            {
                foreach (ValidateFileName vF in listfile)
                {
                    filename += "Filename " + vF.fileName + ", Total = " + vF.recordTotal + ", Validate pass = " + vF.validatePass + ", Record Error = " + vF.recordError+", Total Error = "+vF.totalError + Environment.NewLine;
                    if (int.TryParse(vF.recordError, out err))
                    {
                        if (int.Parse(vF.recordError) > 0)
                        {
                            cntErr++;
                        }
                    }
                }
            }
            if (lVPr.Count > 0)
            {
                foreach(ValidatePrPo vPr in lVPr)
                {
                    recordError += "FileName " + vPr.Filename + Environment.NewLine;
                    recordError += "==>" + vPr.Validate + Environment.NewLine;
                    recordError += "     ====>Error"+vPr.Message + Environment.NewLine;
                }
            }
            using (var stream = File.CreateText(Environment.CurrentDirectory + "\\" + programname+"_"+ startdatetime.Replace("-","_").Replace(":","_") + ".log"))
            {
                txt = line1;
                txt += parameter;
                txt += programstart + Environment.NewLine;
                txt += "File " + Environment.NewLine;
                txt += "--------------------------------------------------------------------------" + Environment.NewLine;
                txt += filename + Environment.NewLine;
                txt += "File Error " + Environment.NewLine;
                txt += "--------------------------------------------------------------------------" + Environment.NewLine;
                txt += recordError + Environment.NewLine;
                txt += "Total "+ listfile.Count + Environment.NewLine;
                txt += "Complete " + (listfile.Count-cntErr) + Environment.NewLine;
                txt += "Error " + cntErr + Environment.NewLine;
                stream.WriteLine(txt);
            }
        }*/
        public void callWebService(String flag)
        {

        }
        public void runCommand(String filename, String argument)
        {
            Process process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = argument; 
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            //* Read the output (or the error)
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            string err = process.StandardError.ReadToEnd();
            Console.WriteLine(err);
            process.WaitForExit();
        }
        public String dateDBtoShow(String date)
        {
            String chk = "", year = "", month = "", day = "";
            if (date.Length >= 10)
            {
                day = date.Substring(8, 2);
                month = date.Substring(5, 2);
                year = date.Substring(0, 4);

                chk = day + "/" + month + "/" + year;
            }
            else
            {
                chk = date;
            }
            return chk;
        }
        public String FixLen(String str, String len, String chrFix)
        {
            String chk = "", aaa = "";
            int len1 = 0;
            if (int.TryParse(len, out len1))
            {
                if (len1 > str.Length)
                {
                    for (int i = 0; i < len1; i++)
                    {
                        aaa += chrFix;
                    }
                    chk = aaa + str;
                    chk = chk.Substring(str.Length);
                }
                else
                {
                    chk = str.Substring(0, len1);
                }
            }
            return chk;
        }
        
        private AlternateView getEmbeddedImage(String filePath, String cid)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = cid;
            string htmlBody = "<img src=cid:" + res.ContentId + ">";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
