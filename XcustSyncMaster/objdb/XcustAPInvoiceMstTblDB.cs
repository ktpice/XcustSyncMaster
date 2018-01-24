using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustAPInvoiceMstTblDB
    {
        public XcustAPInvoiceMstTbl xCAP;
        ConnectDB conn;
        private InitC initC;

        public XcustAPInvoiceMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCAP = new XcustAPInvoiceMstTbl();

            xCAP.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCAP.CREATION_DATE = "CREATION_DATE";

            xCAP.INVOICE_ID = "INVOICE_ID";
            xCAP.INVOICE_NUM = "INVOICE_NUM";
            xCAP.VENDOR_ID = "VENDOR_ID";
            xCAP.ORG_ID = "ORG_ID";

            xCAP.table = "XCUST_AP_INVOICES_TBL";
        }
        public Boolean selectDupPk(String InvoiceId)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCAP.table + " Where " + xCAP.INVOICE_ID + "=" + InvoiceId;
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deleteAPI(String InvoiceId)
        {
            String sql = "Delete From " + xCAP.table + " Where " + xCAP.INVOICE_ID + "=" + InvoiceId;
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCAP(XcustAPInvoiceMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.INVOICE_ID))
            {
                deleteAPI(p.INVOICE_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustAPInvoiceMstTbl p)
        {
            String sql = "", chk = "";
            try
            {
                //if (p.OrpChtNum.Equals(""))
                //{
                //    return "";
                //}
                //p.RowNumber = selectMaxRowNumber(p.YearId);
                //p.Active = "1";
                String last_update_by = "0", creation_by = "0";
                sql = "Insert Into " + xCAP.table + "(" +
                                       xCAP.INVOICE_ID + "," +
                                       xCAP.INVOICE_NUM + "," +
                                       xCAP.VENDOR_ID + "," +
                                       xCAP.ORG_ID + "," +
                                       xCAP.LAST_UPDATE_DATE + "," +
                                       xCAP.CREATION_DATE +
                    ") " +

                    "Values( " + p.INVOICE_ID + ",'" +
                                 p.INVOICE_NUM + "'," + 
                                 p.VENDOR_ID + "," +
                                 p.ORG_ID + ",'" +
                                 p.LAST_UPDATE_DATE + "','" + 
                                 p.CREATION_DATE + "'" +
                    ") ";

                chk = conn.ExecuteNonQuery(sql, "kfc_po");
                //chk = p.RowNumber;
                //chk = p.Code;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error " + ex.ToString(), "insert Doctor");
            }

            return chk;
        }
    }
}
