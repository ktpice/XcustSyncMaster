using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustCSTPeriodMstTblDB
    {
        public XcustCSTPeriodMstTbl xCCSTCv;
        ConnectDB conn;
        private InitC initC;

        public XcustCSTPeriodMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCCSTCv = new XcustCSTPeriodMstTbl();

            xCCSTCv.LEDGER_ID = "LEDGER_ID";
            xCCSTCv.COST_ORG_ID = "COST_ORG_ID";
            xCCSTCv.COST_BOOK_ID = "COST_BOOK_ID";
            xCCSTCv.STATUS_CODE = "STATUS_CODE";
            xCCSTCv.PERIOD_NAME = "PERIOD_NAME";
            xCCSTCv.PERIOD_SET_NAME = "PERIOD_SET_NAME";
            xCCSTCv.PERIOD_NUM = "PERIOD_NUM";
            xCCSTCv.PERIOD_YEAR = "PERIOD_YEAR";
            xCCSTCv.START_DATE = "START_DATE";
            xCCSTCv.END_DATE = "END_DATE";
            xCCSTCv.CREATION_DATE = "CREATION_DATE";
            xCCSTCv.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";

            xCCSTCv.table = "XCUST_CST_PERIOD_STATUSES_MST_TBL";
        }
        public Boolean selectDupPk(String LEDGER_ID,String COST_ORG_ID,String COST_BOOK_ID,String PERIOD_NUM,String PERIOD_YEAR)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCCSTCv.table + " Where " + xCCSTCv.LEDGER_ID + "='" + LEDGER_ID + "'" +
                                                                   " and " + xCCSTCv.COST_ORG_ID + "='" + COST_ORG_ID + "'" +
                                                                   " and " + xCCSTCv.COST_BOOK_ID + "='" + COST_BOOK_ID + "'" +
                                                                   " and " + xCCSTCv.PERIOD_NUM + "='" + PERIOD_NUM + "'" +
                                                                   " and " + xCCSTCv.PERIOD_YEAR + "='" + PERIOD_YEAR +
                                                                   "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String LEDGER_ID, String COST_ORG_ID, String COST_BOOK_ID, String PERIOD_NUM, String PERIOD_YEAR)
        {
            String sql = "Delete From " + xCCSTCv.table + " Where " + xCCSTCv.LEDGER_ID + "='" + LEDGER_ID + "'" +
                                                          " and " + xCCSTCv.COST_ORG_ID + "='" + COST_ORG_ID + "'" +
                                                          " and " + xCCSTCv.COST_BOOK_ID + "='" + COST_BOOK_ID + "'" +
                                                          " and " + xCCSTCv.PERIOD_NUM + "='" + PERIOD_NUM + "'" +
                                                          " and " + xCCSTCv.PERIOD_YEAR + "='" + PERIOD_YEAR +
                                                          "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertCSTPeriodMst(XcustCSTPeriodMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.LEDGER_ID,p.COST_ORG_ID,p.COST_BOOK_ID,p.PERIOD_NUM,p.PERIOD_YEAR))
            {
                deletexCItem(p.LEDGER_ID, p.COST_ORG_ID, p.COST_BOOK_ID,p.PERIOD_NUM,p.PERIOD_YEAR);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustCSTPeriodMstTbl p)
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
                //MessageBox.Show("ORGANIZATION_ID" + p.ORGANIZATION_ID);
                //MessageBox.Show("222" + p.CREATION_DATE);
                sql = "Insert Into " + xCCSTCv.table + "(" + xCCSTCv.LEDGER_ID + 
                                                        "," + xCCSTCv.COST_ORG_ID + 
                                                        "," + xCCSTCv.COST_BOOK_ID + 
                                                        "," + xCCSTCv.STATUS_CODE + 
                                                        "," + xCCSTCv.PERIOD_NAME + 
                                                        "," + xCCSTCv.PERIOD_SET_NAME +
                                                        "," + xCCSTCv.PERIOD_NUM +
                                                        "," + xCCSTCv.PERIOD_YEAR +
                                                        "," + xCCSTCv.START_DATE +
                                                        "," + xCCSTCv.END_DATE +
                                                        "," + xCCSTCv.CREATION_DATE +
                                                        "," + xCCSTCv.LAST_UPDATE_DATE + 
                    ") " +
                    "Values('"  + p.LEDGER_ID +
                             "','" + p.COST_ORG_ID + 
                             "','" + p.COST_BOOK_ID + 
                             "','" + p.STATUS_CODE + 
                             "','" + p.PERIOD_NAME + 
                             "','" + p.PERIOD_SET_NAME +
                             "','" + p.PERIOD_NUM +
                             "','" + p.PERIOD_YEAR +
                             "','" + p.START_DATE +
                             "','" + p.END_DATE +
                             "','" + p.CREATION_DATE +
                             "','" +p.LAST_UPDATE_DATE +    "'" +
                             ") ";
                //MessageBox.Show(sql);
                chk = conn.ExecuteNonQuery(sql, "kfc_po");
                //chk = p.RowNumber;
                //chk = p.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Doctor");
            }

            return chk;
        }
    }
}
