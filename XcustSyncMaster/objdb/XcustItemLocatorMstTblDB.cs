using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustItemLocatorMstTblDB
    {
        public XcustItemLocatorMstTbl xCLoca;
        ConnectDB conn;
        private InitC initC;

        public XcustItemLocatorMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCLoca = new XcustItemLocatorMstTbl();

            xCLoca.ORGANIZATION_ID = "ORGANIZATION_ID";
            xCLoca.INVENTORY_LOCATION_ID = "INVENTORY_LOCATION_ID";
            xCLoca.SUBINVENTORY_ID = "SUBINVENTORY_ID";
            xCLoca.DESCRIPTION = "DESCRIPTION";
            xCLoca.DISABLE_DATE = "DISABLE_DATE";
            xCLoca.INVENTORY_LOCATION_TYPE = "INVENTORY_LOCATION_TYPE";
            xCLoca.SUBINVENTORY_CODE = "SUBINVENTORY_CODE";
            xCLoca.START_DATE_ACTIVE = "START_DATE_ACTIVE";
            xCLoca.END_DATE_ACTIVE = "END_DATE_ACTIVE";
            xCLoca.SEGMENT1 = "SEGMENT1";
            xCLoca.SEGMENT2 = "SEGMENT2";
            xCLoca.ATTRIBUTE1 = "ATTRIBUTE1";
            xCLoca.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCLoca.CREATION_DATE = "CREATION_DATE";

            xCLoca.table = "XCUST_LOCATOR_MST_TBL";
        }
        public Boolean selectDupPk(String ORGANIZATION_ID,String SUBINVENTORY_ID,String INVENTORY_LOCATION_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCLoca.table + " Where " + xCLoca.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "' and " + xCLoca.SUBINVENTORY_ID + "='" + SUBINVENTORY_ID + "' and " + xCLoca.INVENTORY_LOCATION_ID + "='" + INVENTORY_LOCATION_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCLocator(String ORGANIZATION_ID, String SUBINVENTORY_ID, String INVENTORY_LOCATION_ID)
        {
            String sql = "Delete From " + xCLoca.table + " Where " + xCLoca.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "' and " + xCLoca.SUBINVENTORY_ID + "='" + SUBINVENTORY_ID + "' and " + xCLoca.INVENTORY_LOCATION_ID + "='" + INVENTORY_LOCATION_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCLocatorMst(XcustItemLocatorMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.ORGANIZATION_ID, p.SUBINVENTORY_ID, p.INVENTORY_LOCATION_ID))
            {
                deletexCLocator(p.ORGANIZATION_ID, p.SUBINVENTORY_ID, p.INVENTORY_LOCATION_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustItemLocatorMstTbl p)
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
                sql = "Insert Into " + xCLoca.table + "(" + xCLoca.ORGANIZATION_ID + 
                                                        "," + xCLoca.INVENTORY_LOCATION_ID + 
                                                        "," + xCLoca.SUBINVENTORY_ID + 
                                                        "," + xCLoca.DESCRIPTION + 
                                                        "," + xCLoca.DISABLE_DATE + 
                                                        "," + xCLoca.INVENTORY_LOCATION_TYPE + 
                                                        "," + xCLoca.SUBINVENTORY_CODE +
                                                        "," + xCLoca.START_DATE_ACTIVE +
                                                        "," + xCLoca.END_DATE_ACTIVE +
                                                        "," + xCLoca.SEGMENT1 +
                                                        "," + xCLoca.SEGMENT2 +
                                                        "," + xCLoca.ATTRIBUTE1 +
                                                        "," + xCLoca.LAST_UPDATE_DATE +
                                                        "," + xCLoca.CREATION_DATE +
                    ") " +
                    "Values('"  + decimal.Parse(p.ORGANIZATION_ID) +
                             "','" + decimal.Parse(p.INVENTORY_LOCATION_ID) +
                             "','" + decimal.Parse(p.SUBINVENTORY_ID) +
                             "','" + p.DESCRIPTION +
                             "','" + p.DISABLE_DATE + 
                             "','" + p.INVENTORY_LOCATION_TYPE + 
                             "','" + p.SUBINVENTORY_CODE + 
                             "','" + p.START_DATE_ACTIVE +
                             "','" + p.END_DATE_ACTIVE +
                             "','" + p.SEGMENT1 +
                             "','" + p.SEGMENT2 +
                             "','" + p.ATTRIBUTE1 +
                             "','" + p.LAST_UPDATE_DATE + //Convert.ToDateTime(p.LAST_UPDATE_DATE) +
                             "','" + p.CREATION_DATE + //Convert.ToDateTime(p.CREATION_DATE) +
                             "'" +
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
