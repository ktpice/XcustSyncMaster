using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustCurrencyMstTblDB
    {
        public XcustCurrencyMstTbl xCCur;
        ConnectDB conn;
        private InitC initC;

        public XcustCurrencyMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCCur = new XcustCurrencyMstTbl();

            xCCur.CURRENCY_CODE = "CURRENCY_CODE";
            xCCur.CURRENCY_NAME = "CURRENCY_NAME";
            xCCur.DESCRIPTION = "DESCRIPTION";
            xCCur.ENABLE = "ENABLE";
            xCCur.START_DATE = "START_DATE";
            xCCur.END_DATE = "END_DATE";
            xCCur.CREATION_DATE = "CREATION_DATE";
            xCCur.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";

            xCCur.table = "xcust_currency_mst_tbl";
        }
        public Boolean selectDupPk(String cur_code)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCCur.table + " Where " + xCCur.CURRENCY_CODE + "='" + cur_code  + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String cur_code)
        {
            String sql = "Delete From " + xCCur.table + " Where " + xCCur.CURRENCY_CODE + "='" + cur_code + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCCurMst(XcustCurrencyMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.CURRENCY_CODE))
            {
                deletexCItem(p.CURRENCY_CODE);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustCurrencyMstTbl p)
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
                sql = "Insert Into " + xCCur.table + "(" +  xCCur.CURRENCY_CODE +
                                                        "," + xCCur.CURRENCY_NAME +
                                                        "," + xCCur.DESCRIPTION + 
                                                        "," + xCCur.ENABLE + 
                                                        "," + xCCur.START_DATE + 
                                                        "," + xCCur.END_DATE + 
                                                        "," + xCCur.CREATION_DATE + 
                                                        "," + xCCur.LAST_UPDATE_DATE + 
                    ") " +
                    "Values('"  + p.CURRENCY_CODE +
                             "','" + p.CURRENCY_NAME + 
                             "','" + p.DESCRIPTION + 
                             "','" + p.ENABLE + 
                             "','" + p.START_DATE + 
                             "','" + p.END_DATE + 
                             "','" +p.CREATION_DATE + 
                             "','" + p.LAST_UPDATE_DATE +  
                             "'" +
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
