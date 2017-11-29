using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustApSourceMstTblDB
    {
        public XcustApSourceMstTbl xCAP;
        ConnectDB conn;
        private InitC initC;

        public XcustApSourceMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCAP = new XcustApSourceMstTbl();

            xCAP.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCAP.CREATION_DATE = "CREATION_DATE";

            xCAP.LOOKUP_TYPE = "LOOKUP_TYPE";
            xCAP.LOOKUP_CODE = "LOOKUP_CODE";
            xCAP.MEANING = "MEANING";
            xCAP.ENABLED_FLAG = "ENABLED_FLAG";

        xCAP.table = "XCUST_AP_INVOICE_SOURCE_MST_TBL";
        }
        public Boolean selectDupPk(String lookupType, String lookupCode)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCAP.table + " Where " + xCAP.LOOKUP_TYPE + "='" + lookupType + "' and " + xCAP.LOOKUP_CODE + "='" + lookupCode + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCAP(String lookupType, String lookupCode)
        {
            String sql = "Delete From " + xCAP.table + " Where " + xCAP.LOOKUP_TYPE + "='" + lookupType + "' and " + xCAP.LOOKUP_CODE + "='" + lookupCode + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCAP(XcustApSourceMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.LOOKUP_TYPE, p.LOOKUP_CODE))
            {
                deletexCAP(p.LOOKUP_TYPE, p.LOOKUP_CODE);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustApSourceMstTbl p)
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

                //MessageBox.Show(xCAP.LOOKUP_TYPE + " = " + p.LOOKUP_TYPE);
                //MessageBox.Show(xCAP.LOOKUP_CODE + " = " + p.LOOKUP_CODE);
                //MessageBox.Show(xCAP.MEANING + " = " + p.MEANING);
                //MessageBox.Show(xCAP.ENABLED_FLAG + " = " + p.ENABLED_FLAG);

                sql = "Insert Into " + xCAP.table + "(" + xCAP.LOOKUP_TYPE + "," + xCAP.LOOKUP_CODE + "," + xCAP.MEANING + "," +
                    xCAP.ENABLED_FLAG + " " +
                    ") " +

                    "Values( '" + p.LOOKUP_TYPE + "','" +
                    p.LOOKUP_CODE + "','" + p.MEANING + "','" +
                    p.ENABLED_FLAG + "'" +
                    ") ";

                //MessageBox.Show(sql);

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
