using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustBlanketHeaderTblDB
    {
        public XcustBlanketHeaderTbl xCBlKH;
        ConnectDB conn;
        private InitC initC;

        public XcustBlanketHeaderTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }

        private void initConfig()
        {
            xCBlKH = new XcustBlanketHeaderTbl();

            xCBlKH.POCUMENT_BU = "POCUMENT_BU";
            xCBlKH.AGREEMENT_NUMBER = "AGREEMENT_NUMBER";
            xCBlKH.STATUS = "STATUS";
            xCBlKH.BUYER = "BUYER";
            xCBlKH.SUPPLIER = "SUPPLIER";
            xCBlKH.SUPPLIER_SITE = "SUPPLIER_SITE";
            xCBlKH.SUPPLIER_CODE = "SUPPLIER_CODE";
            xCBlKH.COMUNICATION_METHOD = "COMUNICATION_METHOD";
            xCBlKH.E_MAIL = "E_MAIL";
            xCBlKH.START_DATE = "START_DATE";
            xCBlKH.END_DATE = "END_DATE";
            xCBlKH.AGREEMENT_AMT = "AGREEMENT_AMT";
            xCBlKH.MIN_RELEASE_AMT = "MIN_RELEASE_AMT";
            xCBlKH.RELEASE_AMT = "RELEASE_AMT";
            xCBlKH.DESCRIPTION = "DESCRIPTION";
            xCBlKH.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCBlKH.CREATION_DATE = "CREATION_DATE";
            xCBlKH.PO_HEADER_ID = "PO_HEADER_ID";

            xCBlKH.table = "XCUST_BLANKET_AGREEMENT_HEADER_TBL";
        }

        public Boolean selectDupPk(String POCUMENT_BU, String AGREEMENT_NUMBER, String PO_HEADER_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCBlKH.table + " Where " + xCBlKH.POCUMENT_BU + "='" + POCUMENT_BU + "' and " + 
                xCBlKH.AGREEMENT_NUMBER + "='" + AGREEMENT_NUMBER + "' and " + xCBlKH.PO_HEADER_ID + "='" + PO_HEADER_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCBlKH(String POCUMENT_BU, String AGREEMENT_NUMBER, String PO_HEADER_ID)
        {
            String sql = "Delete From " + xCBlKH.table + " Where " + xCBlKH.POCUMENT_BU + "='" + POCUMENT_BU + "' and " + 
                xCBlKH.AGREEMENT_NUMBER + "='" + AGREEMENT_NUMBER +"' and " + xCBlKH.PO_HEADER_ID + "='" + PO_HEADER_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCBlKH(XcustBlanketHeaderTbl b)
        {
            String sql = "", chk = "";
            if (selectDupPk(b.POCUMENT_BU.Replace("|", ","), b.AGREEMENT_NUMBER, b.PO_HEADER_ID))
            {
                deletexCBlKH(b.POCUMENT_BU.Replace("|", ","), b.AGREEMENT_NUMBER, b.PO_HEADER_ID);
            }
            chk = insert(b);
            return chk;
        }

        public String insert(XcustBlanketHeaderTbl b)
        {
            String sql = "", chk = "";
            try
            {
                
                String last_update_by = "0", creation_by = "0";
                //p.TAX_AMOUNT = p.TAX_AMOUNT.Equals("") ? "0" : p.TAX_AMOUNT;

                sql = "Insert Into " + xCBlKH.table + "(" + 
                    xCBlKH.POCUMENT_BU + "," + 
                    xCBlKH.AGREEMENT_NUMBER + "," + 
                    xCBlKH.STATUS + "," +
                    xCBlKH.BUYER + "," + 
                    xCBlKH.SUPPLIER + "," + 
                    xCBlKH.SUPPLIER_SITE + "," +
                    xCBlKH.SUPPLIER_CODE + "," + 
                    xCBlKH.COMUNICATION_METHOD + "," + 
                    xCBlKH.E_MAIL + "," +
                    xCBlKH.START_DATE + "," + 
                    xCBlKH.END_DATE + "," + 
                    xCBlKH.AGREEMENT_AMT + "," +
                    xCBlKH.MIN_RELEASE_AMT + "," + 
                    xCBlKH.RELEASE_AMT + "," + 
                    xCBlKH.DESCRIPTION + "," +
                    xCBlKH.LAST_UPDATE_DATE + "," + 
                    xCBlKH.CREATION_DATE + "," + 
                    xCBlKH.PO_HEADER_ID + " " +

                    ") " +
                    "Values('" + b.POCUMENT_BU.Replace("|", ",") + "','" + 
                    b.AGREEMENT_NUMBER + "','" + 
                    b.STATUS + "','" +
                    b.BUYER.Replace("|", ",") + "','" + 
                    b.SUPPLIER.Replace("|", ",") + "','" + 
                    b.SUPPLIER_SITE + "','" +
                    b.SUPPLIER_CODE + "','" + 
                    b.COMUNICATION_METHOD.Replace("|", ",") + "','" + 
                    b.E_MAIL.Replace("|", ",") + "','" +
                    b.START_DATE + "','" + 
                    b.END_DATE + "'," + 
                    b.AGREEMENT_AMT + "," +
                    b.MIN_RELEASE_AMT + "," + 
                    b.RELEASE_AMT + ",'" + 
                    b.DESCRIPTION.Replace("|", ",") + "','" +
                    b.LAST_UPDATE_DATE + "','" + 
                    b.CREATION_DATE + "'," + 
                    b.PO_HEADER_ID + "" +
                    ") ";
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
