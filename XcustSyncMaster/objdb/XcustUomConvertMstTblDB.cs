using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustUomConvertMstTblDB
    {
        public XcustUomConvertMstTbl xCUOMCv;
        ConnectDB conn;
        private InitC initC;

        public XcustUomConvertMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCUOMCv = new XcustUomConvertMstTbl();

            xCUOMCv.CONVERSION_RATE = "CONVERSION_RATE";
            xCUOMCv.CONVERSION_ID = "CONVERSION_ID";
            xCUOMCv.UOM_CODE = "UOM_CODE";
            xCUOMCv.INVENTORY_ITEM_ID = "INVENTORY_ITEM_ID";
            xCUOMCv.DISABLE_DATE = "DISABLE_DATE";
            xCUOMCv.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCUOMCv.CREATION_DATE = "CREATION_DATE";

            xCUOMCv.table = "XCUST_UOM_CONVERSION_MST_TBL";
        }
        public Boolean selectDupPk(String CONVERSION_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCUOMCv.table + " Where " + xCUOMCv.CONVERSION_ID + "='" + CONVERSION_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCItem(String CONVERSION_ID)
        {
            String sql = "Delete From " + xCUOMCv.table + " Where " + xCUOMCv.CONVERSION_ID + "='" + CONVERSION_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCUomConvertMst(XcustUomConvertMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.CONVERSION_ID))
            {
                deletexCItem(p.CONVERSION_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustUomConvertMstTbl p)
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
                sql = "Insert Into " + xCUOMCv.table + "(" + xCUOMCv.CONVERSION_RATE + 
                                                        "," + xCUOMCv.CONVERSION_ID + 
                                                        "," + xCUOMCv.UOM_CODE + 
                                                        "," + xCUOMCv.INVENTORY_ITEM_ID + 
                                                        "," + xCUOMCv.DISABLE_DATE + 
                                                        "," + xCUOMCv.LAST_UPDATE_DATE + 
                                                        "," + xCUOMCv.CREATION_DATE + 
                    ") " +
                    "Values('"  + p.CONVERSION_RATE +
                             "','" + p.CONVERSION_ID + 
                             "','" + p.UOM_CODE + 
                             "','" + p.INVENTORY_ITEM_ID + 
                             "','" + p.DISABLE_DATE + 
                             "','" + p.LAST_UPDATE_DATE + 
                             "','" +p.CREATION_DATE +    "'" +
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
