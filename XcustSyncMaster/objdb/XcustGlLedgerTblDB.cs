using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    class XcustGlLedgerTblDB
    {
        public XcustGlLedgerTbl xCGLG;
        ConnectDB conn;
        private InitC initC;

        public XcustGlLedgerTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }

        private void initConfig()
        {
            xCGLG = new XcustGlLedgerTbl();

            xCGLG.LEDGER_ID = "LEDGER_ID";
            xCGLG.OBJECT_VERSION_NUMBER = "OBJECT_VERSION_NUMBER";
            xCGLG.NAME = "NAME";
            xCGLG.SHORT_NAME = "SHORT_NAME";
            xCGLG.DESCRIPTION = "DESCRIPTION";
            xCGLG.LEDGER_CATEGORY_CODE = "LEDGER_CATEGORY_CODE";
            xCGLG.ALC_LEDGER_TYPE_CODE = "ALC_LEDGER_TYPE_CODE";
            xCGLG.OBJECT_TYPE_CODE = "OBJECT_TYPE_CODE";
            xCGLG.LE_LEDGER_TYPE_CODE = "LE_LEDGER_TYPE_CODE";
            xCGLG.COMPLETION_STATUS_CODE = "COMPLETION_STATUS_CODE";
            xCGLG.CHART_OF_ACCOUNTS_ID = "CHART_OF_ACCOUNTS_ID";
            xCGLG.PERIOD_SET_NAME = "PERIOD_SET_NAME";
            xCGLG.CURRENCY_CODE = "CURRENCY_CODE";
            xCGLG.ENABLE_BUDGETARY_CONTROL_FLAG = "ENABLE_BUDGETARY_CONTROL_FLAG";
            xCGLG.ACCESS_SET_ID = "ACCESS_SET_ID";
            

            xCGLG.table = "XCUST_GL_LEDGER_MST_TBL";

        }

        public Boolean selectDupPk(String LEDGER_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCGLG.table + " Where " + xCGLG.LEDGER_ID + "=" + LEDGER_ID;
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }

        public void deletexCGLG(String LEDGER_ID)
        {
            String sql = "Delete From " + xCGLG.table + " Where " + xCGLG.LEDGER_ID + "=" + LEDGER_ID;
            conn.ExecuteNonQuery(sql, "kfc_po");
        }

        public String insertxCGLG(XcustGlLedgerTbl b)
        {
            String sql = "", chk = "";
            if (selectDupPk(b.LEDGER_ID))
            {
                deletexCGLG(b.LEDGER_ID);
            }
            chk = insert(b);
            return chk;
        }


        public String insert(XcustGlLedgerTbl b)
        {
            String sql = "", chk = "";
            try
            {

                String last_update_by = "0", creation_by = "0";
                //p.TAX_AMOUNT = p.TAX_AMOUNT.Equals("") ? "0" : p.TAX_AMOUNT;

                sql = "Insert Into " + xCGLG.table + "(" +
                    xCGLG.LEDGER_ID + "," +
                    xCGLG.OBJECT_VERSION_NUMBER + "," +
                    xCGLG.NAME + "," +
                    xCGLG.SHORT_NAME + "," +
                    xCGLG.DESCRIPTION + "," +
                    xCGLG.LEDGER_CATEGORY_CODE + "," +
                    xCGLG.ALC_LEDGER_TYPE_CODE + "," +
                    xCGLG.OBJECT_TYPE_CODE + "," +
                    xCGLG.LE_LEDGER_TYPE_CODE + "," +
                    xCGLG.COMPLETION_STATUS_CODE + "," +
                    xCGLG.CHART_OF_ACCOUNTS_ID + "," +
                    xCGLG.PERIOD_SET_NAME + "," +
                    xCGLG.CURRENCY_CODE + "," +
                    xCGLG.ENABLE_BUDGETARY_CONTROL_FLAG + "," +
                    xCGLG.ACCESS_SET_ID +

                    ") " +
                    "Values(" + b.LEDGER_ID + "," +
                    b.OBJECT_VERSION_NUMBER + ",'" +
                    b.NAME + "','" +
                    b.SHORT_NAME + "','" +
                    b.DESCRIPTION + "','" +
                    b.LEDGER_CATEGORY_CODE + "','" +
                    b.ALC_LEDGER_TYPE_CODE + "','" +
                    b.OBJECT_TYPE_CODE + "','" +
                    b.LE_LEDGER_TYPE_CODE + "','" +
                    b.COMPLETION_STATUS_CODE + "'," +
                    b.CHART_OF_ACCOUNTS_ID + ",'" +
                    b.PERIOD_SET_NAME + "','" +
                    b.CURRENCY_CODE + "','" +
                    b.ENABLE_BUDGETARY_CONTROL_FLAG + "'," +
                    b.ACCESS_SET_ID +   
                    ") ";
                chk = conn.ExecuteNonQuery(sql, "kfc_po");

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error " + ex.ToString(), "insert Doctor");
            }

            return chk;
        }

    }
}
