using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustBlanketLineTblDB
    {
        public XcustBlanketLineTbl xCBlKL;
        ConnectDB conn;
        private InitC initC;

        public XcustBlanketLineTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }

        private void initConfig()
        {
            xCBlKL = new XcustBlanketLineTbl();

            xCBlKL.LINE_NUMBER = "LINE_NUMBER";
            xCBlKL.ITEM_ID = "ITEM_ID";
            xCBlKL.ITEM_CODE = "ITEM_CODE";
            xCBlKL.DESCRIPTION = "DESCRIPTION";
            xCBlKL.UOM = "UOM";
            xCBlKL.PRICE = "PRICE";
            xCBlKL.RELEASE_AMT = "RELEASE_AMT";
            xCBlKL.EXPIRATION_DATE = "EXPIRATION_DATE";
            xCBlKL.LINE_STATUS = "LINE_STATUS";
            xCBlKL.LINE_AGREEMENT_AMT = "LINE_AGREEMENT_AMT";
            xCBlKL.LINE_AGREEMENT_QTY = "LINE_AGREEMENT_QTY";
            xCBlKL.LINE_RELEASE_AMT = "LINE_RELEASE_AMT";
            xCBlKL.LINE_RELEASE_QTY = "LINE_RELEASE_QTY";
            xCBlKL.ALLOW_PRICE_OVERIDE = "ALLOW_PRICE_OVERIDE";
            xCBlKL.PRICE_LIMIT = "PRICE_LIMIT";
            xCBlKL.CURRENCY_CODE = "CURRENCY_CODE";
            xCBlKL.LINE_REVISION = "LINE_REVISION";
            xCBlKL.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCBlKL.CREATION_DATE = "CREATION_DATE";
            xCBlKL.PO_HEADER_ID = "PO_HEADER_ID";
            xCBlKL.PO_LINE_ID = "PO_LINE_ID";
            xCBlKL.min_release_amt = "min_release_amt";
            xCBlKL.ATTRIBUTE1 = "ATTRIBUTE1";
            xCBlKL.ATTRIBUTE2 = "ATTRIBUTE2";
            xCBlKL.ATTRIBUTE3 = "ATTRIBUTE3";
            xCBlKL.ATTRIBUTE4 = "ATTRIBUTE4";
            xCBlKL.ATTRIBUTE5 = "ATTRIBUTE5";
            xCBlKL.ATTRIBUTE6 = "ATTRIBUTE6";
            xCBlKL.ATTRIBUTE7 = "ATTRIBUTE7";
            xCBlKL.ATTRIBUTE8 = "ATTRIBUTE8";
            xCBlKL.ATTRIBUTE9 = "ATTRIBUTE9";
            xCBlKL.ATTRIBUTE10 = "ATTRIBUTE10";


            xCBlKL.table = "XCUST_BLANKET_AGREEMENT_LINES_TBL";
        }

        public Boolean selectDupPk(String PO_HEADER_ID, String PO_Line_ID, String ITEM_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCBlKL.table + " Where " + xCBlKL.PO_HEADER_ID + "='" + PO_HEADER_ID + "' and " +
                xCBlKL.PO_LINE_ID + "='" + PO_Line_ID + "' and " + xCBlKL.ITEM_ID + "='" + ITEM_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCBlKL(String PO_HEADER_ID, String PO_Line_ID, String ITEM_ID)
        {
            String sql = "Delete From " + xCBlKL.table + " Where " + xCBlKL.PO_HEADER_ID + "='" + PO_HEADER_ID + "' and " +
                xCBlKL.PO_LINE_ID + "='" + PO_Line_ID + "' and " + xCBlKL.ITEM_ID + "='" + ITEM_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCBlKL(XcustBlanketLineTbl b)
        {
            String sql = "", chk = "";
            if (selectDupPk(b.PO_HEADER_ID, b.PO_LINE_ID, b.ITEM_ID))
            {
                deletexCBlKL(b.PO_HEADER_ID, b.PO_LINE_ID, b.ITEM_ID);
            }
            chk = insert(b);
            return chk;
        }

        public String insert(XcustBlanketLineTbl b)
        {
            String sql = "", chk = "";
            try
            {

                String last_update_by = "0", creation_by = "0";
                //p.TAX_AMOUNT = p.TAX_AMOUNT.Equals("") ? "0" : p.TAX_AMOUNT;

                sql = "Insert Into " + xCBlKL.table + "(" +
                    xCBlKL.LINE_NUMBER + "," +
                    xCBlKL.ITEM_ID + "," +
                    xCBlKL.ITEM_CODE + "," +
                    xCBlKL.DESCRIPTION + "," +
                    xCBlKL.UOM + "," +
                    xCBlKL.PRICE + "," +
                    xCBlKL.RELEASE_AMT + "," +
                    xCBlKL.EXPIRATION_DATE + "," +
                    xCBlKL.LINE_STATUS + "," +
                    xCBlKL.LINE_AGREEMENT_AMT + "," +
                    xCBlKL.LINE_AGREEMENT_QTY + "," +
                    xCBlKL.LINE_RELEASE_AMT + "," +
                    xCBlKL.LINE_RELEASE_QTY + "," +
                    xCBlKL.ALLOW_PRICE_OVERIDE + "," +
                    xCBlKL.PRICE_LIMIT + "," +
                    xCBlKL.CURRENCY_CODE + "," +
                    xCBlKL.LINE_REVISION + "," +
                    xCBlKL.LAST_UPDATE_DATE + "," +
                    xCBlKL.CREATION_DATE + "," +
                    xCBlKL.PO_HEADER_ID + "," +
                    xCBlKL.PO_LINE_ID + "," +
                    xCBlKL.min_release_amt + "," +
                    xCBlKL.ATTRIBUTE1 + "," +
                    xCBlKL.ATTRIBUTE2 + "," +
                    xCBlKL.ATTRIBUTE3 + "," +
                    xCBlKL.ATTRIBUTE4 + "," +
                    xCBlKL.ATTRIBUTE5 + "," +
                    xCBlKL.ATTRIBUTE6 + "," +
                    xCBlKL.ATTRIBUTE7 + "," +
                    xCBlKL.ATTRIBUTE8 + "," +
                    xCBlKL.ATTRIBUTE9 + "," +
                    xCBlKL.ATTRIBUTE10 +

                    ") " +
                    "Values(" + b.LINE_NUMBER + "," +
                    b.ITEM_ID + ",'" +
                    b.ITEM_CODE + "','" +
                    b.DESCRIPTION + "','" +
                    b.UOM + "'," +
                    b.PRICE + "," +
                    b.RELEASE_AMT + ",'" +
                    b.EXPIRATION_DATE + "','" +
                    b.LINE_STATUS + "'," +
                    b.LINE_AGREEMENT_AMT + "," +
                    b.LINE_AGREEMENT_QTY + "," +
                    b.LINE_RELEASE_AMT + "," +
                    b.LINE_RELEASE_QTY + ",'" +
                    b.ALLOW_PRICE_OVERIDE + "'," +
                    b.PRICE_LIMIT + ",'" +
                    b.CURRENCY_CODE + "'," +
                    b.LINE_REVISION + ",'" +
                    b.LAST_UPDATE_DATE + "','" +
                    b.CREATION_DATE + "'," +
                    b.PO_HEADER_ID + "," +
                    b.PO_LINE_ID + "," +
                    b.min_release_amt + ",'" +
                    b.ATTRIBUTE1 + "','" +
                    b.ATTRIBUTE2 + "','" +
                    b.ATTRIBUTE3 + "','" +
                    b.ATTRIBUTE4 + "','" +
                    b.ATTRIBUTE5 + "','" +
                    b.ATTRIBUTE6 + "','" +
                    b.ATTRIBUTE7 + "','" +
                    b.ATTRIBUTE8 + "','" +
                    b.ATTRIBUTE9 + "','" +
                    b.ATTRIBUTE10 + "'" +
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
