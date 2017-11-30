using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustUomMstTblDB
    {
        public XcustUomMstTbl xCUOM;
        ConnectDB conn;
        private InitC initC;

        public XcustUomMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCUOM = new XcustUomMstTbl();

            xCUOM.UNIT_OF_MEASURE_ID = "UNIT_OF_MEASURE_ID";
            xCUOM.UOM_CODE = "UOM_CODE";
            xCUOM.DISABLE_DATE = "DISABLE_DATE";
            xCUOM.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCUOM.CREATION_DATE = "CREATION_DATE";
            xCUOM.attribute1 = "attribute1";
            xCUOM.uom_name = "uom_name";
            xCUOM.uom_description = "uom_description";

            xCUOM.table = "XCUST_UOM_MST_TBL";
        }
        public Boolean selectDupPk(String UOM_CODE)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCUOM.table + " Where " + xCUOM.UOM_CODE + "='" + UOM_CODE  + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String UOM_CODE)
        {
            String sql = "Delete From " + xCUOM.table + " Where " + xCUOM.UOM_CODE + "='" + xCUOM + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCUomMst(XcustUomMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.UOM_CODE))
            {
                deletexCItem(p.UOM_CODE);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustUomMstTbl p)
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
                sql = "Insert Into " + xCUOM.table + "(" + xCUOM.UNIT_OF_MEASURE_ID + 
                                                        "," + xCUOM.UOM_CODE + 
                                                        "," + xCUOM.DISABLE_DATE + 
                                                        "," + xCUOM.LAST_UPDATE_DATE + 
                                                        "," + xCUOM.CREATION_DATE + 
                                                        "," + xCUOM.attribute1 + 
                                                        "," + xCUOM.uom_name + 
                                                        "," + xCUOM.uom_description + 
                    ") " +
                    "Values('"  + decimal.Parse(p.UNIT_OF_MEASURE_ID) +
                             "','" + decimal.Parse(p.UOM_CODE) + 
                             "','" + p.DISABLE_DATE + 
                             "','" + p.LAST_UPDATE_DATE + 
                             "','" + p.CREATION_DATE + 
                             "','" + p.attribute1 + 
                             "','" +p.uom_name + 
                             "','" + p.uom_description +   "'" +
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
