using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustGlPeriodMstTblDB
    {
        public XcustGlPeriodMstTbl xCGlP;
        ConnectDB conn;
        private InitC initC;

        public XcustGlPeriodMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCGlP = new XcustGlPeriodMstTbl();

            xCGlP.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCGlP.CREATION_DATE = "CREATION_DATE";

            xCGlP.LEDGER_ID = "LEDGER_ID";
            xCGlP.PERIOD_NAME = "PERIOD_NAME";
            xCGlP.START_DATE = "START_DATE";
            xCGlP.END_DATE = "END_DATE";
            xCGlP.PERIOD_YEAR = "PERIOD_YEAR";
            xCGlP.EFFECTIVE_PERIOD_NUM = "EFFECTIVE_PERIOD_NUM";
            xCGlP.PERIOD_NUM = "PERIOD_NUM";

            xCGlP.table = "XCUST_GL_PERIOD_MST_TBL";
        }
        public Boolean selectDupPk(String ledgerId, String periodName)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCGlP.table + " Where " + xCGlP.LEDGER_ID + "='" + ledgerId + "' and " + xCGlP.PERIOD_NAME + "='" + periodName + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCGlP(String ledgerId, String periodName)
        {
            String sql = "Delete From " + xCGlP.table + " Where " + xCGlP.LEDGER_ID + "='" + ledgerId + "' and " + xCGlP.PERIOD_NAME + "='" + periodName + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCGlP(XcustGlPeriodMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.LEDGER_ID, p.PERIOD_NAME))
            {
                deletexCGlP(p.LEDGER_ID, p.PERIOD_NAME);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustGlPeriodMstTbl p)
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
                sql = "Insert Into " + xCGlP.table + "(" + xCGlP.LEDGER_ID + "," + xCGlP.PERIOD_NAME + "," + xCGlP.START_DATE + "," +
                    xCGlP.END_DATE + "," + xCGlP.PERIOD_YEAR + "," + xCGlP.EFFECTIVE_PERIOD_NUM + "," +
                    xCGlP.PERIOD_NUM + " " +
                    ") " +

                    "Values( " + p.LEDGER_ID + ",'" +
                    p.PERIOD_NAME + "','" + p.START_DATE + "','" + p.END_DATE + "'," +
                    p.PERIOD_YEAR + "," + p.EFFECTIVE_PERIOD_NUM + "," + 
                    p.PERIOD_NUM +
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
