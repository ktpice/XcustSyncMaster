using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace XcustSyncMaster
{


    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);

            MaterialListView lv1;
            MaterialProgressBar pB1;
            Form from1;

            string[] args = Environment.GetCommandLineArgs();

            ControlMain Cm = new ControlMain();
            lv1 = new MaterialListView();
            pB1 = new MaterialProgressBar();
            from1 = new Form();


            Cm.args = args;
            Cm.setAgrument();

            /* ControlApSourceWebService cApWS = new ControlApSourceWebService(Cm);
             ControlBlanketHeader cBlKH = new ControlBlanketHeader(Cm);
             ControlBlanketLine cBlKL = new ControlBlanketLine(Cm);
             ControlBuMstWebService cIBuWS = new ControlBuMstWebService(Cm);
             ControlCatMappingMstWebService cICatmWS = new ControlCatMappingMstWebService(Cm);
             ControlCSTPeriodMstWebService cICSTPeriodWS = new ControlCSTPeriodMstWebService(Cm);
             ControlCurrencyMstWebService cICurWS = new ControlCurrencyMstWebService(Cm);
             ControlGlCodeCombinationWebService cGlCWS = new ControlGlCodeCombinationWebService(Cm);
             ControlGlEntityWebService cGlWS = new ControlGlEntityWebService(Cm);
             ControlGlLedger cGLG = new ControlGlLedger(Cm);
             ControlGlPeriodWebService cGlPWS = new ControlGlPeriodWebService(Cm);
             ControlLocatorMstWebService cLCT = new ControlLocatorMstWebService(Cm);
             ControlItemMstWebService cItemWS = new ControlItemMstWebService(Cm);
             ControlLocationsWebService cLcWS = new ControlLocationsWebService(Cm);
             ControlPoRWebService cPoRWS = new ControlPoRWebService(Cm);
             ControlSubInvMstWebService cISubWS = new ControlSubInvMstWebService(Cm);
             ControlSupplierSiteWebService cSupSWS = new ControlSupplierSiteWebService(Cm);
             ControlSupplierWebService cSupWS = new ControlSupplierWebService(Cm);
             ControlTaxCodeWebService cTxCWS = new ControlTaxCodeWebService(Cm);
             ControlUomConvertMstWebService cIUomConvWS = new ControlUomConvertMstWebService(Cm);
             ControlUomMstWebService cIUomWS = new ControlUomMstWebService(Cm);
             ControlValueSet cVS = new ControlValueSet(Cm);




             if (Cm.initC.Mastername == "XCustApSourceWebService")
             {
                 cApWS.setXcustApTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustBlanketHeader")
             {
                 cBlKH.setXcustBlkHTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustBlanketLine")
             {
                 cBlKL.setXcustBlkLTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustBuMstWebService")
             {
                 cIBuWS.setXcustBUTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustCatMappingMstWebService")
             {
                 cICatmWS.setXcustCatMappingTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustCSTPeriodMstWebService")
             {
                 cICSTPeriodWS.setXcustCSTPeriodTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustCurrencyMstWebService")
             {
                 cICurWS.setXcustCURTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustGlCodeCombinationWebService")
             {
                 cGlCWS.setXcustGlCTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustGlEntityWebService")
             {
                 cGlWS.setXcustGlTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustGlLedger")
             {
                 cGLG.setXcustGlLedgerTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustGlPeriodWebService")
             {
                 cGlPWS.setXcustGlPTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XcustItemLocator")
             {
                 cLCT.setXcustLocatorTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustItemMstWebService")
             {
                 cItemWS.setXcustITEMTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustLocationsWebService")
             {
                 cLcWS.setXcustGlCTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustPoRWebService")
             {
                 cPoRWS.setXcustPRTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustSubInvMstWebService")
             {
                 cISubWS.setXcustSUBTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustSupplierSiteWebService")
             {
                 cSupSWS.setXcustSupTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustSupplierWebService")
             {
                 cSupWS.setXcustSupTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustTaxCodeWebService")
             {
                 cTxCWS.setXcustTxCTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustUomConvertMstWebService")
             {
                 cIUomConvWS.setXcustUOMConvertTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XCustUomMstWebService")
             {
                 cIUomWS.setXcustUOMTbl(lv1, from1, pB1);
             }
             else if (Cm.initC.Mastername == "XcustValueSet")
             {
                 cVS.setXcustValueTbl(lv1, from1, pB1);
             }
             else
             {
                 cApWS.setXcustApTbl(lv1, from1, pB1);
                 cBlKH.setXcustBlkHTbl(lv1, from1, pB1);
                 cBlKL.setXcustBlkLTbl(lv1, from1, pB1);
                 cIBuWS.setXcustBUTbl(lv1, from1, pB1);
                 cICatmWS.setXcustCatMappingTbl(lv1, from1, pB1);
                 cICSTPeriodWS.setXcustCSTPeriodTbl(lv1, from1, pB1);
                 cICurWS.setXcustCURTbl(lv1, from1, pB1);
                 cGlCWS.setXcustGlCTbl(lv1, from1, pB1);
                 cGlWS.setXcustGlTbl(lv1, from1, pB1);
                 cGLG.setXcustGlLedgerTbl(lv1, from1, pB1);
                 cGlPWS.setXcustGlPTbl(lv1, from1, pB1);
                 cLCT.setXcustLocatorTbl(lv1, from1, pB1);
                 cItemWS.setXcustITEMTbl(lv1, from1, pB1);
                 cLcWS.setXcustGlCTbl(lv1, from1, pB1);
                 cPoRWS.setXcustPRTbl(lv1, from1, pB1);
                 cISubWS.setXcustSUBTbl(lv1, from1, pB1);
                 cSupSWS.setXcustSupTbl(lv1, from1, pB1);
                 cSupWS.setXcustSupTbl(lv1, from1, pB1);
                 cTxCWS.setXcustTxCTbl(lv1, from1, pB1);
                 cIUomConvWS.setXcustUOMConvertTbl(lv1, from1, pB1);
                 cIUomWS.setXcustUOMTbl(lv1, from1, pB1);
                 cVS.setXcustValueTbl(lv1, from1, pB1);
             }
             */


            //MessageBox.Show("args "+ args.Length, "");

            /*if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("xcustvalueset"))
            {
                Application.Run(new XcustValueSet(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("xcustvalueset"))
            {
                Application.Run(new XcustValueSet(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustItemMstWebService"))
            {
                Application.Run(new XCustItemMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustSubInvMstWebService"))
            {
                Application.Run(new XCustSubInvMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustUomMstWebService"))
            {
                Application.Run(new XCustUomMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustCurrencyMstWebService"))
            {
                Application.Run(new XCustCurrencyMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustBuMstWebService"))
            {
                Application.Run(new XCustBuMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustUomConvertMstWebService"))
            {
                Application.Run(new XCustUomConvertMstWebService(Cm));
            }
            else
            {
                //Application.Run(new XCustPoRWebService(Cm));
                //Application.Run(new XCustGlPeriodWebService(Cm));
                //Application.Run(new XCustApSourceWebService(Cm));
                //Application.Run(new XCustGlEntityWebService(Cm));
                //Application.Run(new XCustTaxCodeWebService(Cm));
                //Application.Run(new XCustSupplierSiteWebService(Cm));
                //Application.Run(new XCustSupplierWebService(Cm));
                //Application.Run(new XCustGlEntityWebService(Cm)); 

                //Application.Run(new XCustUomMstWebService(Cm));  //kts****
                //Application.Run(new XCustBuMstWebService(Cm));  //kts
                //Application.Run(new XCustCurrencyMstWebService(Cm));  //kts
                //Application.Run(new XCustSubInvMstWebService(Cm));  //kts **
                Application.Run(new XcustValueSet(Cm));  //kts
                //Application.Run(new XcustItemLocator(Cm));  //kts
                //Application.Run(new XCustItemMstWebService(Cm));  //kts
                //Application.Run(new XCustUomConvertMstWebService(Cm));  //kts
                //Application.Run(new XCustCSTPeriodMstWebService(Cm));  //kts
                //Application.Run(new XCustCatMappingMstWebService(Cm));  //kts

                //Application.Run(new XCustSubInvMstWebService(Cm));  //kts


                //Application.Run(new XcustBlanketHeader(Cm));

                //Application.Run(new XCustBlanketLine(Cm));
                //Application.Run(new XCustGlLedger(Cm));

                //Application.Run(new XCustUomMstWebService(Cm));  //kts
                //Application.Run(new XCustGlCodeCombinationWebService(Cm));
                //Application.Run(new XCustLocationsWebService(Cm));
            }
            */

            Application.Run(new XcustSyncMaster(Cm));

        }
    }
}
