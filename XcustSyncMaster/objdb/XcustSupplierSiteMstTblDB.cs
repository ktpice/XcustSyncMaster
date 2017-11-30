using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustSupplierSiteMstTblDB
    {
        public XcustSupplierSiteMstTbl xCSup;
        ConnectDB conn;
        private InitC initC;

        public XcustSupplierSiteMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCSup = new XcustSupplierSiteMstTbl();

            xCSup.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCSup.CREATION_DATE = "CREATION_DATE";

            xCSup.VENDOR_SITE_SPK_ID = "VENDOR_SITE_SPK_ID";
            xCSup.VENDOR_SITE_ID = "VENDOR_SITE_ID";
            xCSup.VENDOR_ID = "VENDOR_ID";
            xCSup.LOCATION_ID = "LOCATION_ID";
            xCSup.VENDOR_SITE_CODE = "VENDOR_SITE_CODE";
            xCSup.PURCHASING_SITE_FLAG = "PURCHASING_SITE_FLAG";
            xCSup.RFQ_ONLY_SITE_FLAG = "RFQ_ONLY_SITE_FLAG";
            xCSup.PAY_SITE_FLAG = "PAY_SITE_FLAG";
            xCSup.MATCH_OPTION = "MATCH_OPTION";
            xCSup.SUPPLIER_NOTIF_METHOD = "SUPPLIER_NOTIF_METHOD";
            xCSup.EMAIL_ADDRESS = "EMAIL_ADDRESS";
            xCSup.ATTRIBUTE1 = "ATTRIBUTE1";
            xCSup.ATTRIBUTE2 = "ATTRIBUTE2";
            xCSup.ATTRIBUTE3 = "ATTRIBUTE3";
            xCSup.ATTRIBUTE4 = "ATTRIBUTE4";
            xCSup.ATTRIBUTE5 = "ATTRIBUTE5";
            xCSup.ATTRIBUTE6 = "ATTRIBUTE6";
            xCSup.ATTRIBUTE7 = "ATTRIBUTE7";
            xCSup.ATTRIBUTE8 = "ATTRIBUTE8";
            xCSup.ATTRIBUTE9 = "ATTRIBUTE9";
            xCSup.ATTRIBUTE10 = "ATTRIBUTE10";
            xCSup.ATTRIBUTE11 = "ATTRIBUTE11";
            xCSup.ATTRIBUTE12 = "ATTRIBUTE12";
            xCSup.ATTRIBUTE13 = "ATTRIBUTE13";
            xCSup.ATTRIBUTE14 = "ATTRIBUTE14";
            xCSup.ATTRIBUTE15 = "ATTRIBUTE15";

            xCSup.table = "XCUST_SUPPLIER_SITE_MST_TBL";
        }
        public Boolean selectDupPk(String SupSiteSpkId, String VendorSiteId)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCSup.table + " Where " + xCSup.VENDOR_SITE_SPK_ID + "='" + SupSiteSpkId + "' and " + xCSup.VENDOR_SITE_ID + "= '" + VendorSiteId + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCSup(String SupSiteSpkId, String VendorSiteId)
        {
            String sql = "Delete From " + xCSup.table + " Where " + xCSup.VENDOR_SITE_SPK_ID + "='" + SupSiteSpkId + "' and " + xCSup.VENDOR_SITE_ID + "='" + VendorSiteId + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCSup(XcustSupplierSiteMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.VENDOR_SITE_SPK_ID, p.VENDOR_SITE_ID))
            {
                deletexCSup(p.VENDOR_SITE_SPK_ID, p.VENDOR_SITE_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustSupplierSiteMstTbl p)
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
                                       xCSup.VENDOR_SITE_SPK_ID + "," +
                                       xCSup.VENDOR_SITE_ID + "," +
                                       xCSup.VENDOR_ID + "," +
                                       xCSup.LOCATION_ID + "," +
                                       xCSup.VENDOR_SITE_CODE + "," +
                                       xCSup.PURCHASING_SITE_FLAG + "," +
                                       xCSup.RFQ_ONLY_SITE_FLAG + "," +
                                       xCSup.PAY_SITE_FLAG + "," +
                                       xCSup.MATCH_OPTION + "," +
                                       xCSup.SUPPLIER_NOTIF_METHOD + "," +
                                       xCSup.EMAIL_ADDRESS + "," +
                                       xCSup.ATTRIBUTE1 + "," +
                                       xCSup.ATTRIBUTE2 + "," +
                                       xCSup.ATTRIBUTE3 + "," +
                                       xCSup.ATTRIBUTE4 + "," +
                                       xCSup.ATTRIBUTE5 + "," +
                                       xCSup.ATTRIBUTE6 + "," +
                                       xCSup.ATTRIBUTE7 + "," +
                                       xCSup.ATTRIBUTE8 + "," +
                                       xCSup.ATTRIBUTE9 + "," +
                                       xCSup.ATTRIBUTE10 + "," +
                                       xCSup.ATTRIBUTE11 + "," +
                                       xCSup.ATTRIBUTE12 + "," +
                                       xCSup.ATTRIBUTE13 + "," +
                                       xCSup.ATTRIBUTE14 + "," +
                                       xCSup.ATTRIBUTE15 + "," +
                                       xCSup.LAST_UPDATE_DATE + "," +
                                       xCSup.CREATION_DATE +
                    ") " +
                                       
                    "Values( " + p.VENDOR_SITE_SPK_ID + "," +
                                p.VENDOR_SITE_ID + "," +
                                p.VENDOR_ID + "," +
                                p.LOCATION_ID + ",'" +
                                p.VENDOR_SITE_CODE + "','" + 
                                p.PURCHASING_SITE_FLAG + "','" +
                                p.RFQ_ONLY_SITE_FLAG + "','" +
                                p.PAY_SITE_FLAG + "','" +
                                p.MATCH_OPTION + "','" +
                                p.SUPPLIER_NOTIF_METHOD + "','" +
                                p.EMAIL_ADDRESS + "','" +
                                p.ATTRIBUTE1 + "','" +
                                p.ATTRIBUTE2 + "','" +
                                p.ATTRIBUTE3 + "','" +
                                p.ATTRIBUTE4 + "','" +
                                p.ATTRIBUTE5 + "','" +
                                p.ATTRIBUTE6 + "','" +
                                p.ATTRIBUTE7 + "','" +
                                p.ATTRIBUTE8 + "','" +
                                p.ATTRIBUTE9 + "','" +
                                p.ATTRIBUTE10 + "','" +
                                p.ATTRIBUTE11 + "','" +
                                p.ATTRIBUTE12 + "','" +
                                p.ATTRIBUTE13 + "','" +
                                p.ATTRIBUTE14 + "','" +
                                p.ATTRIBUTE15 + "','" +
                                p.LAST_UPDATE_DATE + "','" +
                                p.CREATION_DATE + "'" +
            ") ";

               // MessageBox.Show(sql);

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
