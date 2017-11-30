using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustTaxCodeMstTblDB
    {
        public XcustTaxCodeMstTbl xCTxC;
        ConnectDB conn;
        private InitC initC;

        public XcustTaxCodeMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCTxC = new XcustTaxCodeMstTbl();

            xCTxC.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCTxC.CREATION_DATE = "CREATION_DATE";

            xCTxC.TAX_RATE_ID = "TAX_RATE_ID";
            xCTxC.TAX_RATE_CODE = "TAX_RATE_CODE";
            xCTxC.PERCENTAGE_RATE = "PERCENTAGE_RATE";
            xCTxC.TAX_REGIME_CODE = "TAX_REGIME_CODE";
            xCTxC.REGIME_TYPE_FLAG = "REGIME_TYPE_FLAG";

            xCTxC.table = "XCUST_TAX_CODE_MST_TBL";
        }
        public Boolean selectDupPk(String TaxRateId, String TaxRateCode)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCTxC.table + " Where " + xCTxC.TAX_RATE_ID + "='" + TaxRateId + "' and " + xCTxC.TAX_RATE_CODE + "='" + TaxRateCode + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCTxC(String TaxRateId, String TaxRateCode)
        {
            String sql = "Delete From " + xCTxC.table + " Where " + xCTxC.TAX_RATE_ID + "='" + TaxRateId + "' and " + xCTxC.TAX_RATE_CODE + "='" + TaxRateCode + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCTxC(XcustTaxCodeMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.TAX_RATE_ID, p.TAX_RATE_CODE))
            {
                deletexCTxC(p.TAX_RATE_ID, p.TAX_RATE_CODE);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustTaxCodeMstTbl p)
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
                sql = "Insert Into " + xCTxC.table + "(" + 
                                       xCTxC.TAX_RATE_ID + "," + 
                                       xCTxC.TAX_RATE_CODE + "," + 
                                       xCTxC.PERCENTAGE_RATE + "," +
                                       xCTxC.TAX_REGIME_CODE + "," + 
                                       xCTxC.REGIME_TYPE_FLAG + 
                    ") " +

                    "Values( " + p.TAX_RATE_ID + ",'" +
                                 p.TAX_RATE_CODE + "'," + 
                                 p.PERCENTAGE_RATE + ",'" + 
                                 p.TAX_REGIME_CODE + "','" +
                                 p.REGIME_TYPE_FLAG + "'" + 
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
