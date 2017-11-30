using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustSupplierMstTblDB
    {
        public XcustSupplierMstTbl xCSup;
        ConnectDB conn;
        private InitC initC;

        public XcustSupplierMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCSup = new XcustSupplierMstTbl();

            xCSup.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCSup.CREATION_DATE = "CREATION_DATE";

            xCSup.SUPPLIER_REG_ID = "SUPPLIER_REG_ID";
            xCSup.VENDOR_ID = "VENDOR_ID";
            xCSup.SUPPLIER_NUMBER = "SUPPLIER_NUMBER";
            xCSup.SUPPLIER_NAME = "SUPPLIER_NAME";
            xCSup.ATTRIBUTE1 = "ATTRIBUTE1";
            xCSup.ATTRIBUTE2 = "ATTRIBUTE2";
            xCSup.ATTRIBUTE3 = "ATTRIBUTE3";
            xCSup.ATTRIBUTE4 = "ATTRIBUTE4";
            xCSup.ATTRIBUTE5 = "ATTRIBUTE5";


        xCSup.table = "XCUST_SUPPLIER_MST_TBL";
        }
        public Boolean selectDupPk(String SupRegId, String VendorId)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCSup.table + " Where " + xCSup.SUPPLIER_REG_ID + "='" + SupRegId + "' and " + xCSup.VENDOR_ID + "='" + VendorId + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCSup(String SupRegId, String VendorId)
        {
            String sql = "Delete From " + xCSup.table + " Where " + xCSup.SUPPLIER_REG_ID + "='" + SupRegId + "' and " + xCSup.VENDOR_ID + "='" + VendorId + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCSup(XcustSupplierMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.SUPPLIER_REG_ID, p.VENDOR_ID))
            {
                deletexCSup(p.SUPPLIER_REG_ID, p.VENDOR_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustSupplierMstTbl p)
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
                sql = "Insert Into " + xCSup.table + "(" +
                                       xCSup.SUPPLIER_REG_ID + "," +
                                       xCSup.VENDOR_ID + "," +
                                       xCSup.SUPPLIER_NUMBER + "," +
                                       xCSup.SUPPLIER_NAME + "," +
                                       xCSup.ATTRIBUTE1 + "," +
                                       xCSup.ATTRIBUTE2 + "," +
                                       xCSup.ATTRIBUTE3 + "," +
                                       xCSup.ATTRIBUTE4 + "," +
                                       xCSup.ATTRIBUTE5 + "," +
                                       xCSup.LAST_UPDATE_DATE + "," +
                                       xCSup.CREATION_DATE +
                    ") " +

                "Values( " + p.SUPPLIER_REG_ID + "," +
                                 p.VENDOR_ID + ",'" + 
                                 p.SUPPLIER_NUMBER + "','" + 
                                 p.SUPPLIER_NAME + "','" +
                                 p.ATTRIBUTE1 + "','" +
                                 p.ATTRIBUTE2 + "','" +
                                 p.ATTRIBUTE3 + "','" +
                                 p.ATTRIBUTE4 + "','" +
                                 p.ATTRIBUTE5 + "','" +
                                 p.LAST_UPDATE_DATE + "','" +
                                 p.CREATION_DATE + "'" +
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
