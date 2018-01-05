using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustCatMappingMstTblDB
    {
        public XcustCatMappingMstTbl xCCatm;
        ConnectDB conn;
        private InitC initC;

        public XcustCatMappingMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCCatm = new XcustCatMappingMstTbl();

            xCCatm.ORGANIZATION_ID = "ORGANIZATION_ID";
            xCCatm.ORGANIZATION_CODE = "ORGANIZATION_CODE";
            xCCatm.INVENTORY_ITEM_ID = "INVENTORY_ITEM_ID";
            xCCatm.CATEGORY_SET_ID = "CATEGORY_SET_ID";
            xCCatm.CATEGORY_ID = "CATEGORY_ID";
            xCCatm.ENABLED_FLAG = "ENABLED_FLAG";
            xCCatm.CATEGORY_CODE = "CATEGORY_CODE";
            xCCatm.CATALOG_CODE_C = "CATALOG_CODE_C";
            xCCatm.MAPPING_SET_CODE = "MAPPING_SET_CODE";
            xCCatm.VALUE_CODE_COMBINATION_ID = "VALUE_CODE_COMBINATION_ID";
            xCCatm.SEGMENT1 = "SEGMENT1";
            xCCatm.SEGMENT2 = "SEGMENT2";
            xCCatm.SEGMENT3 = "SEGMENT3";
            xCCatm.SEGMENT4 = "SEGMENT4";
            xCCatm.SEGMENT5 = "SEGMENT5";
            xCCatm.SEGMENT6 = "SEGMENT6";
            xCCatm.CONCATESEGMENT = "CONCATESEGMENT";
            xCCatm.CREATION_DATE = "CREATION_DATE";
            xCCatm.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";

            xCCatm.table = "XCUST_CATEGORY_MAPPING_MST_TBL";
        }
        public Boolean selectDupPk(String ORGANIZATION_ID,String INVENTORY_ITEM_ID,String CATEGORY_SET_ID,String CATEGORY_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCCatm.table + " Where " + xCCatm.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "'" +
                                                       " and " + xCCatm.INVENTORY_ITEM_ID + "='" + INVENTORY_ITEM_ID + "'" +
                                                       " and " + xCCatm.CATEGORY_SET_ID + "='" + CATEGORY_SET_ID + "'" +
                                                       " and " + xCCatm.CATEGORY_ID + "='" + CATEGORY_ID +
                                                       "'";

            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCCat(String ORGANIZATION_ID, String INVENTORY_ITEM_ID, String CATEGORY_SET_ID, String CATEGORY_ID)
        {
            String sql = "Delete From " + xCCatm.table + " Where " + xCCatm.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "'" +
                                                       " and " + xCCatm.INVENTORY_ITEM_ID + "='" + INVENTORY_ITEM_ID + "'" +
                                                       " and " + xCCatm.CATEGORY_SET_ID + "='" + CATEGORY_SET_ID + "'" +
                                                       " and " + xCCatm.CATEGORY_ID + "='" + CATEGORY_ID +
                                                       "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCCatMappingMst(XcustCatMappingMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.ORGANIZATION_ID, p.INVENTORY_ITEM_ID, p.CATEGORY_SET_ID, p.CATEGORY_ID))
            {
                deletexCCat(p.ORGANIZATION_ID, p.INVENTORY_ITEM_ID, p.CATEGORY_SET_ID, p.CATEGORY_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustCatMappingMstTbl p)
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
                sql = "Insert Into " + xCCatm.table + "(" + xCCatm.ORGANIZATION_ID + 
                                                        "," + xCCatm.ORGANIZATION_CODE + 
                                                        "," + xCCatm.INVENTORY_ITEM_ID + 
                                                        "," + xCCatm.CATEGORY_SET_ID + 
                                                        "," + xCCatm.CATEGORY_ID + 
                                                        "," + xCCatm.ENABLED_FLAG + 
                                                        "," + xCCatm.CATEGORY_CODE +
                                                        "," + xCCatm.CATALOG_CODE_C +
                                                        "," + xCCatm.MAPPING_SET_CODE +
                                                        "," + xCCatm.VALUE_CODE_COMBINATION_ID +
                                                        "," + xCCatm.SEGMENT1 +
                                                        "," + xCCatm.SEGMENT2 +
                                                        "," + xCCatm.SEGMENT3 +
                                                        "," + xCCatm.SEGMENT4 +
                                                        "," + xCCatm.SEGMENT5 +
                                                        "," + xCCatm.SEGMENT6 +
                                                        "," + xCCatm.CONCATESEGMENT +
                                                        "," + xCCatm.CREATION_DATE +
                                                        "," + xCCatm.LAST_UPDATE_DATE + 
                    ") " +
                    "Values('"  + decimal.Parse(p.ORGANIZATION_ID) +
                             "','" + p.ORGANIZATION_CODE.Replace("|",",") +
                             "','" + p.INVENTORY_ITEM_ID + 
                             "','" + p.CATEGORY_SET_ID + 
                             "','" + p.CATEGORY_ID + 
                             "','" + p.ENABLED_FLAG.Replace("|", ",") +
                             "','" +p.CATEGORY_CODE +
                             "','" + p.CATALOG_CODE_C +
                             "','" + p.MAPPING_SET_CODE +
                             "','" + p.VALUE_CODE_COMBINATION_ID +
                             "','" + p.SEGMENT1 +
                             "','" + p.SEGMENT2 +
                             "','" + p.SEGMENT3 +
                             "','" + p.SEGMENT4 +
                             "','" + p.SEGMENT5 +
                             "','" + p.SEGMENT6 +
                             "','" + p.CONCATESEGMENT +
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
