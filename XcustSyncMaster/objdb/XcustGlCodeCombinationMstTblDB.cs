using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustGlCodeCombinationMstTblDB
    {
        public XcustGlCodeCombinationMstTbl xCGlC;
        ConnectDB conn;
        private InitC initC;

        public XcustGlCodeCombinationMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCGlC = new XcustGlCodeCombinationMstTbl();

            xCGlC.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCGlC.CREATION_DATE = "CREATION_DATE";

            xCGlC.CODE_COMBINATION_ID = "CODE_COMBINATION_ID";
            xCGlC.CHART_OF_ACCOUNTS_ID = "CHART_OF_ACCOUNTS_ID";
            xCGlC.DETAIL_POSTING_ALLOWED_FLAG = "DETAIL_POSTING_ALLOWED_FLAG";
            xCGlC.DETAIL_BUDGETING_ALLOWED_FLAG = "DETAIL_BUDGETING_ALLOWED_FLAG";
            xCGlC.ACCOUNT_TYPE = "ACCOUNT_TYPE";
            xCGlC.ENABLED_FLAG = "ENABLED_FLAG";
            xCGlC.SUMMARY_FLAG = "SUMMARY_FLAG";
            xCGlC.SEGMENT1 = "SEGMENT1";
            xCGlC.SEGMENT2 = "SEGMENT2";
            xCGlC.SEGMENT3 = "SEGMENT3";
            xCGlC.SEGMENT4 = "SEGMENT4";
            xCGlC.SEGMENT5 = "SEGMENT5";
            xCGlC.SEGMENT6 = "SEGMENT6";

            xCGlC.table = "XCUST_GL_CODE_COMBINATIONS_TBL";
        }
        public Boolean selectDupPk(String CodeCombinationId)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCGlC.table + " Where " + xCGlC.CODE_COMBINATION_ID + " = " + CodeCombinationId;
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCGlC(String CodeCombinationId)
        {
            String sql = "Delete From " + xCGlC.table + " Where " + xCGlC.CODE_COMBINATION_ID + " = " + CodeCombinationId ;
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCGlC(XcustGlCodeCombinationMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.CODE_COMBINATION_ID))
            {
                deletexCGlC(p.CODE_COMBINATION_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustGlCodeCombinationMstTbl p)
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
                sql = "Insert Into " + xCGlC.table + "(" +
                                       xCGlC.CODE_COMBINATION_ID + "," +
                                       xCGlC.CHART_OF_ACCOUNTS_ID + "," +
                                       xCGlC.DETAIL_POSTING_ALLOWED_FLAG + "," +
                                       xCGlC.DETAIL_BUDGETING_ALLOWED_FLAG + "," +
                                       xCGlC.ACCOUNT_TYPE + "," +
                                       xCGlC.ENABLED_FLAG + "," +
                                       xCGlC.SUMMARY_FLAG + "," +
                                       xCGlC.SEGMENT1 + "," +
                                       xCGlC.SEGMENT2 + "," +
                                       xCGlC.SEGMENT3 + "," +
                                       xCGlC.SEGMENT4 + "," +
                                       xCGlC.SEGMENT5 + "," +
                                       xCGlC.SEGMENT6 + "," +
                                       xCGlC.CREATION_DATE + "," +
                                       xCGlC.LAST_UPDATE_DATE + " " +

                ") " +

                    "Values( " + p.CODE_COMBINATION_ID + "," +
                                 p.CHART_OF_ACCOUNTS_ID + ",'" + 
                                 p.DETAIL_POSTING_ALLOWED_FLAG + "','" +
                                 p.DETAIL_BUDGETING_ALLOWED_FLAG + "','" + 
                                 p.ACCOUNT_TYPE + "','" + 
                                 p.ENABLED_FLAG + "','" +
                                 p.SUMMARY_FLAG + "','" +
                                 p.SEGMENT1 + "','" +
                                 p.SEGMENT2 + "','" +
                                 p.SEGMENT3 + "','" +
                                 p.SEGMENT4 + "','" +
                                 p.SEGMENT5 + "','" +
                                 p.SEGMENT6 + "','" +
                                 p.CREATION_DATE + "','" +
                                 p.LAST_UPDATE_DATE + "'" +
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
