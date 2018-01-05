using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustBUMstTblDB
    {
        public XcustBUMstTbl xCBU;
        ConnectDB conn;
        private InitC initC;

        public XcustBUMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCBU = new XcustBUMstTbl();

            xCBU.BU_ID = "BU_ID";
            xCBU.BU_NAME = "BU_NAME";
            xCBU.DATE_FROM = "DATE_FROM";
            xCBU.LEGAL_ENTITY_ID = "LEGAL_ENTITY_ID";
            xCBU.PRIMARY_LEDGER_ID = "PRIMARY_LEDGER_ID";
            xCBU.SHORT_CODE = "SHORT_CODE";
            xCBU.STATUS = "STATUS";
            xCBU.CREATION_DATE = "CREATION_DATE";
            xCBU.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";

            xCBU.table = "XCUST_BU_MST_TBL";
        }
        public Boolean selectDupPk(String BU_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCBU.table + " Where " + xCBU.BU_ID + "='" + BU_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCBU(String BU_ID)
        {
            String sql = "Delete From " + xCBU.table + " Where " + xCBU.BU_ID + "='" + BU_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCBuMst(XcustBUMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.BU_ID))
            {
                deletexCBU(p.BU_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustBUMstTbl p)
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
                //MessageBox.Show("222" + xCBU.BU_NAME);
                sql = "Insert Into " + xCBU.table + "(" + xCBU.BU_ID + 
                                                        "," + xCBU.BU_NAME + 
                                                        "," + xCBU.DATE_FROM + 
                                                        "," + xCBU.LEGAL_ENTITY_ID + 
                                                        "," + xCBU.PRIMARY_LEDGER_ID + 
                                                        "," + xCBU.SHORT_CODE + 
                                                        "," + xCBU.STATUS +
                                                        "," + xCBU.CREATION_DATE +
                                                        "," + xCBU.LAST_UPDATE_DATE + 
                    ") " +
                    "Values('"  + decimal.Parse(p.BU_ID) +
                             "','" + p.BU_NAME.Replace("|",",") +
                             "','" + p.DATE_FROM + 
                             "','" + p.LEGAL_ENTITY_ID + 
                             "','" + p.PRIMARY_LEDGER_ID + 
                             "','" + p.SHORT_CODE.Replace("|", ",") +
                             "','" +p.STATUS +
                             "','" + p.CREATION_DATE +
                             "','" + p.LAST_UPDATE_DATE +   "'" +
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
