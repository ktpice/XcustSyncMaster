using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustItemMstTblDB
    {
        public XcustItemMstTbl xCITEM;
        ConnectDB conn;
        private InitC initC;

        public XcustItemMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCITEM = new XcustItemMstTbl();

            xCITEM.ORGANIZATION_ID = "ORGANIZATION_ID";
            xCITEM.INVENTORY_ITEM_ID = "INVENTORY_ITEM_ID";
            xCITEM.ITEM_CODE = "ITEM_CODE";
            xCITEM.ITEM_NAME = "ITEM_NAME";
            xCITEM.DESCRIPTION = "DESCRIPTION";
            xCITEM.ATTRIBUTE1 = "ATTRIBUTE1";
            xCITEM.ATTRIBUTE2 = "ATTRIBUTE2";
            xCITEM.ATTRIBUTE3 = "ATTRIBUTE3";
            xCITEM.ATTRIBUTE4 = "ATTRIBUTE4";
            xCITEM.ATTRIBUTE5 = "ATTRIBUTE5";
            xCITEM.ATTRIBUTE6 = "ATTRIBUTE6";
            xCITEM.ATTRIBUTE7 = "ATTRIBUTE7";
            xCITEM.ATTRIBUTE8 = "ATTRIBUTE8";
            xCITEM.ATTRIBUTE9 = "ATTRIBUTE9";
            xCITEM.ATTRIBUTE10 = "ATTRIBUTE10";
            xCITEM.ATTRIBUTE11 = "ATTRIBUTE11";
            xCITEM.ATTRIBUTE12 = "ATTRIBUTE12";
            xCITEM.ATTRIBUTE13 = "ATTRIBUTE13";
            xCITEM.ATTRIBUTE14 = "ATTRIBUTE14";
            xCITEM.ATTRIBUTE15 = "ATTRIBUTE15";
            xCITEM.ITEM_STATUS = "ITEM_STATUS";
            xCITEM.ITEM_CLASS_NAME = "ITEM_CLASS_NAME";
            xCITEM.ITEM_CLASS_CODE = "ITEM_CLASS_CODE";
            xCITEM.ITEM_TYPE = "ITEM_TYPE";
            xCITEM.PRIMARY_UOM = "PRIMARY_UOM";
            xCITEM.ITEM_CATEGORY_CODE = "ITEM_CATEGORY_CODE";
            xCITEM.ITEM_CATEGORY_NAME = "ITEM_CATEGORY_NAME";
            xCITEM.ITEM_REFERENCE1 = "ITEM_REFERENCE1";
            xCITEM.LOT_CONTROL_CODE = "LOT_CONTROL_CODE";
            xCITEM.SERIAL_NUMBER_CONTROL_CODE = "SERIAL_NUMBER_CONTROL_CODE";
            xCITEM.CREATION_DATE = "CREATION_DATE";
            xCITEM.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCITEM.TAX_RATE = "TAX_RATE";
            xCITEM.ASSET_CATEGORY_CODE = "ASSET_CATEGORY_CODE";
            xCITEM.ACCOUNT_CODE_COMBINATION_ID = "ACCOUNT_CODE_COMBINATION_ID";
            xCITEM.TAX_CODE = "TAX_CODE";

            xCITEM.table = "xcust_item_mst_tbl";
        }
        public Boolean selectDupPk(String Org_id, String item_id)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            //DateTime dat = Convert.ToDateTime(last_upd);
            sql = "Select count(1) as cnt From " + xCITEM.table + " Where " + xCITEM.ORGANIZATION_ID + "='" + Org_id + "' and " + 
                                                                            xCITEM.INVENTORY_ITEM_ID + "='" + item_id + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String Org_id, String item_id)
        {
            //DateTime dat = Convert.ToDateTime(last_upd);
            String sql = "Delete From " + xCITEM.table + " Where " + xCITEM.ORGANIZATION_ID + "='" + Org_id + "' and " + 
                                                                     xCITEM.INVENTORY_ITEM_ID + "='" + item_id + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCItemMst(XcustItemMstTbl p)
        {
            String sql = "", chk = "";
            
            if (selectDupPk(p.ORGANIZATION_ID, p.INVENTORY_ITEM_ID))
            {
                deletexCItem(p.ORGANIZATION_ID, p.INVENTORY_ITEM_ID);
            }
            
            chk = insert(p);
            return chk;
        }
        public String insert(XcustItemMstTbl p)
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
                sql = "Insert Into " + xCITEM.table + "(" + xCITEM.ORGANIZATION_ID + 
                                                        "," + xCITEM.INVENTORY_ITEM_ID + 
                                                        "," + xCITEM.ITEM_CODE + 
                                                        "," + xCITEM.ITEM_NAME + 
                                                        "," + xCITEM.DESCRIPTION + 
                                                        "," + xCITEM.ATTRIBUTE1 + 
                                                        "," + xCITEM.ATTRIBUTE2 + 
                                                        "," + xCITEM.ATTRIBUTE3 + 
                                                        "," + xCITEM.ATTRIBUTE4 + 
                                                        "," + xCITEM.ATTRIBUTE5 + 
                                                        "," + xCITEM.ATTRIBUTE6 + 
                                                        "," + xCITEM.ATTRIBUTE7 + 
                                                        "," + xCITEM.ATTRIBUTE8 + 
                                                        "," + xCITEM.ATTRIBUTE9 + 
                                                        "," + xCITEM.ATTRIBUTE10 + 
                                                        "," + xCITEM.ATTRIBUTE11 + 
                                                        "," + xCITEM.ATTRIBUTE12 + 
                                                        "," + xCITEM.ATTRIBUTE13 + 
                                                        "," + xCITEM.ATTRIBUTE14 + 
                                                        "," + xCITEM.ATTRIBUTE15 + 
                                                        "," + xCITEM.ITEM_STATUS + 
                                                        "," + xCITEM.ITEM_CLASS_NAME + 
                                                        "," + xCITEM.ITEM_CLASS_CODE + 
                                                        "," + xCITEM.ITEM_TYPE + 
                                                        "," + xCITEM.PRIMARY_UOM + 
                                                        "," + xCITEM.ITEM_CATEGORY_NAME + 
                                                        "," + xCITEM.ITEM_CATEGORY_CODE + 
                                                        "," + xCITEM.ITEM_REFERENCE1 + 
                                                        "," + xCITEM.LOT_CONTROL_CODE + 
                                                        "," + xCITEM.SERIAL_NUMBER_CONTROL_CODE + 
                                                        "," + xCITEM.CREATION_DATE + 
                                                        "," + xCITEM.LAST_UPDATE_DATE +
                                                        "," + xCITEM.TAX_RATE +
                                                        "," + xCITEM.ASSET_CATEGORY_CODE +
                                                        "," + xCITEM.ACCOUNT_CODE_COMBINATION_ID +
                                                        "," + xCITEM.TAX_CODE +
                    ") " +
                    "Values('"  + decimal.Parse(p.ORGANIZATION_ID) +
                             "','" + decimal.Parse(p.INVENTORY_ITEM_ID) + 
                             "','" + p.ITEM_CODE + 
                             "','" + p.ITEM_NAME + 
                             "','" + p.DESCRIPTION + 
                             "','" + p.ATTRIBUTE1 + 
                             "','" +p.ATTRIBUTE2 + 
                             "','" + p.ATTRIBUTE3 + 
                             "','" + p.ATTRIBUTE4 + 
                             "','" +p.ATTRIBUTE5 + 
                             "','" + p.ATTRIBUTE6 + 
                             "','" + p.ATTRIBUTE7 + 
                             "','" +p.ATTRIBUTE8 + 
                             "','" + p.ATTRIBUTE9 + 
                             "','" + p.ATTRIBUTE10 + 
                             "','" +p.ATTRIBUTE11 + 
                             "','" + p.ATTRIBUTE12 + 
                             "','" + p.ATTRIBUTE13 + 
                             "','" +p.ATTRIBUTE14 + 
                             "','" + p.ATTRIBUTE15 + 
                             "','" + p.ITEM_STATUS + 
                             "','" +p.ITEM_CLASS_NAME + 
                             "','" + p.ITEM_CLASS_CODE + 
                             "','" + p.ITEM_TYPE + 
                             "','" +p.PRIMARY_UOM + 
                             "','" + p.ITEM_CATEGORY_NAME + 
                             "','" + p.ITEM_CATEGORY_CODE + 
                             "','" +p.ITEM_REFERENCE1 + 
                             "','" + p.LOT_CONTROL_CODE + 
                             "','" + p.SERIAL_NUMBER_CONTROL_CODE + 
                             "','" + p.CREATION_DATE + 
                             "','" + p.LAST_UPDATE_DATE +
                             "','" + p.TAX_RATE +
                             "','" + p.ASSET_CATEGORY_CODE +
                             "','" + p.ACCOUNT_CODE_COMBINATION_ID +
                             "','" + p.TAX_CODE +
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
