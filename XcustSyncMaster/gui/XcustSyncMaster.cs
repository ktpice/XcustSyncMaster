using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    class XcustSyncMaster : Form
    {
        int gapLine = 5;
        int grd0 = 0, grd1 = 100, grd2 = 240, grd3 = 320, grd4 = 570, grd5 = 700, grd51 = 700, grd6 = 820, grd7 = 900, grd8 = 1070, grd9 = 1200;
        int line1 = 35, line2 = 27, line3 = 85, line4 = 105, line41 = 120, line42 = 111, line5 = 270, ControlHeight = 21, lineGap = 5;

        int formwidth = 860, formheight = 740;

        MaterialLabel lb1, lb2;
        MaterialSingleLineTextField txtFileName;
        MaterialFlatButton btnRead, btnPrepare, btnWebService, btnFTP, btnEmail;
        MaterialListView lv1;
        MaterialProgressBar pB1;

        Color cTxtL, cTxtE, cForm;

        ControlMain Cm;
        ControlAPInvoiceWebService cApInvWS;
        ControlApSourceWebService cApWS;
        ControlBlanketHeader cBlKH;
        ControlBlanketLine cBlKL;
        ControlBuMstWebService cIBuWS;
        ControlCatMappingMstWebService cICatmWS;
        ControlCSTPeriodMstWebService cICSTPeriodWS;
        ControlCurrencyMstWebService cICurWS;
        ControlGlCodeCombinationWebService cGlCWS;
        ControlGlEntityWebService cGlWS;
        ControlGlLedger cGLG;
        ControlGlPeriodWebService cGlPWS;
        ControlLocatorMstWebService cLCT;
        ControlItemMstWebService cItemWS;
        ControlLocationsWebService cLcWS;
        ControlPoRWebService cPoRWS;
        ControlSubInvMstWebService cISubWS;
        ControlSupplierSiteWebService cSupSWS;
        ControlSupplierWebService cSupWS;
        ControlTaxCodeWebService cTxCWS;
        ControlUomConvertMstWebService cIUomConvWS;
        ControlUomMstWebService cIUomWS;
        ControlValueSet cVS;



        private ListViewColumnSorter lvwColumnSorter;

        public XcustSyncMaster(ControlMain cm)
        {
            this.Size = new Size(formwidth, formheight);
            this.StartPosition = FormStartPosition.CenterScreen;
            Cm = cm;
            initConfig();
            cTxtL = txtFileName.BackColor;
            cTxtE = Color.Yellow;
            this.Text = "Last Update 2018-01-05 ";
        }
        private void initConfig()
        {
            cApInvWS = new ControlAPInvoiceWebService(Cm);
            cApWS = new ControlApSourceWebService(Cm);
            cBlKH = new ControlBlanketHeader(Cm);
            cBlKL = new ControlBlanketLine(Cm);
            cIBuWS = new ControlBuMstWebService(Cm);
            cICatmWS = new ControlCatMappingMstWebService(Cm);
            cICSTPeriodWS = new ControlCSTPeriodMstWebService(Cm);
            cICurWS = new ControlCurrencyMstWebService(Cm);
            cGlCWS = new ControlGlCodeCombinationWebService(Cm);
            cGlWS = new ControlGlEntityWebService(Cm);
            cGLG = new ControlGlLedger(Cm);
            cGlPWS = new ControlGlPeriodWebService(Cm);
            cLCT = new ControlLocatorMstWebService(Cm);
            cItemWS = new ControlItemMstWebService(Cm);
            cLcWS = new ControlLocationsWebService(Cm);
            cPoRWS = new ControlPoRWebService(Cm);
            cISubWS = new ControlSubInvMstWebService(Cm);
            cSupSWS = new ControlSupplierSiteWebService(Cm);
            cSupWS = new ControlSupplierWebService(Cm);
            cTxCWS = new ControlTaxCodeWebService(Cm);
            cIUomConvWS = new ControlUomConvertMstWebService(Cm);
            cIUomWS = new ControlUomMstWebService(Cm);
            cVS = new ControlValueSet(Cm);

            initCompoment();
            pB1.Visible = false;
            lvwColumnSorter = new ListViewColumnSorter();
            lvwColumnSorter.Order = SortOrder.Descending;
            lvwColumnSorter.SortColumn = 0;
            lv1.Sort();
            txtFileName.Text = Cm.initC.AutoApSource;

            lv1.Columns.Add("NO", 50);
            lv1.Columns.Add("List File", formwidth - 50 - 40 - 100, HorizontalAlignment.Left);
            lv1.Columns.Add("   process   ", 100, HorizontalAlignment.Center);
            lv1.ListViewItemSorter = lvwColumnSorter;

        }
        private void disableBtn()
        {
            btnRead.Enabled = false;
            btnPrepare.Enabled = false;
            btnFTP.Enabled = false;
            btnWebService.Enabled = false;
            btnEmail.Enabled = false;
        }
        private void initCompoment()
        {
            line1 = 35 + gapLine;
            line2 = 57 + gapLine;
            line3 = 75 + gapLine;
            line4 = 125 + gapLine;
            line41 = 120 + gapLine;
            line42 = 140 + gapLine;
            line5 = 270 + gapLine;

            lb1 = new MaterialLabel();
            lb1.Font = cApWS.fV1;
            lb1.Text = "Text File";
            lb1.AutoSize = true;
            Controls.Add(lb1);
            lb1.Location = new System.Drawing.Point(cApWS.formFirstLineX, cApWS.formFirstLineY + gapLine);

            lb2 = new MaterialLabel();
            lb2.Font = cApWS.fV1;
            lb2.Text = "Program Name Xcust Sync Master";
            lb2.AutoSize = true;
            Controls.Add(lb2);
            lb2.Location = new System.Drawing.Point(grd3, cApWS.formFirstLineY + gapLine);

            txtFileName = new MaterialSingleLineTextField();
            txtFileName.Font = cApWS.fV1;
            txtFileName.Text = "";
            txtFileName.Size = new System.Drawing.Size(300 - grd1 - 20 - 30, ControlHeight);
            Controls.Add(txtFileName);
            txtFileName.Location = new System.Drawing.Point(grd1, cApWS.formFirstLineY + gapLine);
            txtFileName.Hint = lb1.Text;
            txtFileName.Enter += txtFileName_Enter;
            txtFileName.Leave += txtFileName_Leave;


            btnRead = new MaterialFlatButton();
            btnRead.Font = cApWS.fV1;
            btnRead.Text = "Web Service";
            btnRead.Size = new System.Drawing.Size(30, ControlHeight);
            Controls.Add(btnRead);
            btnRead.Location = new System.Drawing.Point(grd1, line1);
            btnRead.Click += btnRead_Click;



            pB1 = new MaterialProgressBar();
            Controls.Add(pB1);
            pB1.Size = new System.Drawing.Size(formwidth - 40, pB1.Height);
            pB1.Location = new System.Drawing.Point(cApWS.formFirstLineX + 5, line41);

            lv1 = new MaterialListView();
            lv1.Font = cApWS.fV1;
            lv1.FullRowSelect = true;
            lv1.Size = new System.Drawing.Size(formwidth - 40, formheight - line3 - 100);
            lv1.Location = new System.Drawing.Point(cApWS.formFirstLineX + 5, line42);
            lv1.FullRowSelect = true;
            lv1.View = View.Details;
            //lv1.Dock = System.Windows.Forms.DockStyle.Fill;
            lv1.BorderStyle = System.Windows.Forms.BorderStyle.None;

            Controls.Add(lv1);
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            
            if (Cm.initC.Mastername == "XCustAPInvoiceWebService")
            {
                cApInvWS.setXcustAPTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustApSourceWebService")
            {
                cApWS.setXcustApTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustBlanketHeader")
            {
                cBlKH.setXcustBlkHTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustBlanketLine")
            {
                cBlKL.setXcustBlkLTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustBuMstWebService")
            {
                cIBuWS.setXcustBUTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustCatMappingMstWebService")
            {
                cICatmWS.setXcustCatMappingTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustCSTPeriodMstWebService")
            {
                cICSTPeriodWS.setXcustCSTPeriodTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustCurrencyMstWebService")
            {
                cICurWS.setXcustCURTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustGlCodeCombinationWebService")
            {
                cGlCWS.setXcustGlCTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustGlEntityWebService")
            {
                cGlWS.setXcustGlTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustGlLedger")
            {
                cGLG.setXcustGlLedgerTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustGlPeriodWebService")
            {
                cGlPWS.setXcustGlPTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XcustItemLocator")
            {
                cLCT.setXcustLocatorTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustItemMstWebService")
            {
                cItemWS.setXcustITEMTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustLocationsWebService")
            {
                cLcWS.setXcustGlCTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustPoRWebService")
            {
                cPoRWS.setXcustPRTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustSubInvMstWebService")
            {
                cISubWS.setXcustSUBTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustSupplierSiteWebService")
            {
                cSupSWS.setXcustSupTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustSupplierWebService")
            {
                cSupWS.setXcustSupTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustTaxCodeWebService")
            {
                cTxCWS.setXcustTxCTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustUomConvertMstWebService")
            {
                cIUomConvWS.setXcustUOMConvertTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XCustUomMstWebService")
            {
                cIUomWS.setXcustUOMTbl(lv1, this, pB1);
            }
            else if (Cm.initC.Mastername == "XcustValueSet")
            {
                cVS.setXcustValueTbl(lv1, this, pB1);
            }
            else
            {
                cApInvWS.setXcustAPTbl(lv1, this, pB1);
                cApWS.setXcustApTbl(lv1, this, pB1);
                cBlKH.setXcustBlkHTbl(lv1, this, pB1);
                cBlKL.setXcustBlkLTbl(lv1, this, pB1);
                cIBuWS.setXcustBUTbl(lv1, this, pB1);
                cICatmWS.setXcustCatMappingTbl(lv1, this, pB1);
                cICSTPeriodWS.setXcustCSTPeriodTbl(lv1, this, pB1);
                cICurWS.setXcustCURTbl(lv1, this, pB1);
                cGlCWS.setXcustGlCTbl(lv1, this, pB1);
                cGlWS.setXcustGlTbl(lv1, this, pB1);
                cGLG.setXcustGlLedgerTbl(lv1, this, pB1);
                cGlPWS.setXcustGlPTbl(lv1, this, pB1);
                cLCT.setXcustLocatorTbl(lv1, this, pB1);
                cItemWS.setXcustITEMTbl(lv1, this, pB1);
                cLcWS.setXcustGlCTbl(lv1, this, pB1);
                cPoRWS.setXcustPRTbl(lv1, this, pB1);
                cISubWS.setXcustSUBTbl(lv1, this, pB1);
                cSupSWS.setXcustSupTbl(lv1, this, pB1);
                cSupWS.setXcustSupTbl(lv1, this, pB1);
                cTxCWS.setXcustTxCTbl(lv1, this, pB1);
                cIUomConvWS.setXcustUOMConvertTbl(lv1, this, pB1);
                cIUomWS.setXcustUOMTbl(lv1, this, pB1);
                cVS.setXcustValueTbl(lv1, this, pB1);
            }
        }

        private void txtFileName_Leave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtFileName.BackColor = cTxtL;
        }

        private void txtFileName_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtFileName.BackColor = cTxtE;
        }
        private ListViewItem AddToList(int col1, string col2, string col3)
        {
            string[] array = new string[3];
            array[0] = col1.ToString();
            array[1] = col2;
            array[2] = col3;

            return (new ListViewItem(array));
        }
    }
}
