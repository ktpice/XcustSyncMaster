using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustSubInvMstTblDB
    {
        public XcustSubInvMstTbl xCSUVINV;
        ConnectDB conn;
        private InitC initC;

        public XcustSubInvMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCSUVINV = new XcustSubInvMstTbl();

            xCSUVINV.ORGANIZATION_ID = "ORGANIZATION_ID";
            xCSUVINV.SUBINVENTORY_ID = "SUBINVENTORY_ID";
            xCSUVINV.SECONDARY_INVENTORY_NAME = "SECONDARY_INVENTORY_NAME";
            xCSUVINV.DESCRIPTION = "DESCRIPTION";
            xCSUVINV.LOCATOR_TYPE = "LOCATOR_TYPE";
            xCSUVINV.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCSUVINV.CREATION_DATE = "CREATION_DATE";
            xCSUVINV.attribute1 = "attribute1";
            xCSUVINV.attribute2 = "attribute2";
            xCSUVINV.attribute3 = "attribute3";
            xCSUVINV.CODE_COMBINATION_ID = "CODE_COMBINATION_ID";

            xCSUVINV.table = "XCUST_SUBINVENTORY_MST_TBL";
        }
        public Boolean selectDupPk(String Org_id, String sub_id)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCSUVINV.table + " Where " + xCSUVINV.ORGANIZATION_ID + "='" + Org_id + "' and " + xCSUVINV.SUBINVENTORY_ID + "='" + sub_id + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String Org_id, String sub_id)
        {
            String sql = "Delete From " + xCSUVINV.table + " Where " + xCSUVINV.ORGANIZATION_ID + "='" + Org_id + "' and " + xCSUVINV.SUBINVENTORY_ID + "='" + sub_id + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCSubInvMst(XcustSubInvMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.ORGANIZATION_ID, p.SUBINVENTORY_ID))
            {
                deletexCItem(p.ORGANIZATION_ID, p.SUBINVENTORY_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustSubInvMstTbl p)
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
                sql = "Insert Into " + xCSUVINV.table + "(" + xCSUVINV.ORGANIZATION_ID + 
                                                        "," + xCSUVINV.SUBINVENTORY_ID + 
                                                        "," + xCSUVINV.SECONDARY_INVENTORY_NAME + 
                                                        "," + xCSUVINV.DESCRIPTION + 
                                                        "," + xCSUVINV.LOCATOR_TYPE + 
                                                        "," + xCSUVINV.LAST_UPDATE_DATE + 
                                                        "," + xCSUVINV.CREATION_DATE + 
                                                        "," + xCSUVINV.attribute1 + 
                                                        "," + xCSUVINV.attribute2 + 
                                                        "," + xCSUVINV.attribute3 +
                                                        //"," + xCSUVINV.CODE_COMBINATION_ID +
                    ") " +
                    "Values('"  + p.ORGANIZATION_ID +
                             "','" + p.SUBINVENTORY_ID + 
                             "','" + p.SECONDARY_INVENTORY_NAME + 
                             "','" + p.DESCRIPTION + 
                             "','" + p.LOCATOR_TYPE + 
                             "','" + p.LAST_UPDATE_DATE + 
                             "','" +p.CREATION_DATE + 
                             "','" + p.attribute1 + 
                             "','" + p.attribute2 + 
                             "','" +p.attribute3 +
                             //"','" + p.CODE_COMBINATION_ID + 
                             "'" +
                             ") ";
                //MessageBox.Show(sql);
                chk = conn.ExecuteNonQuery(sql, "kfc_po");
                //chk = p.RowNumber;
                //chk = p.Code;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("exception"+sql);
                MessageBox.Show("Error " + ex.ToString(), "insert Doctor");
            }

            return chk;
        }
    }
}
