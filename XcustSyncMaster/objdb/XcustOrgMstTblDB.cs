using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    class XcustOrgMstTblDB
    {
        public XcustOrgMstTbl xCOrg;
        ConnectDB conn;
        private InitC initC;

        public XcustOrgMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }

        private void initConfig()
        {
            xCOrg = new XcustOrgMstTbl();

            xCOrg.ORGANIZATION_ID = "ORGANIZATION_ID";
            xCOrg.ORGANIZATION_NAME = "ORGANIZATION_NAME";
            xCOrg.BUSINESS_GROUP_ID = "BUSINESS_GROUP_ID";
            xCOrg.SET_OF_BOOKS_ID = "SET_OF_BOOKS_ID";
            xCOrg.CHART_OF_ACCOUNTS_ID = "CHART_OF_ACCOUNTS_ID";
            xCOrg.INVENTORY_FLAG = "INVENTORY_FLAG";
            xCOrg.ORGANIZATION_CODE = "ORGANIZATION_CODE";
            xCOrg.CREATION_DATE = "CREATION_DATE";
            xCOrg.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCOrg.MATERIAL_ACCOUNT_CCID = "MATERIAL_ACCOUNT_CCID";

            xCOrg.table = "XCUST_ORGANIZATION_MST_TBL";
        }

        public Boolean selectDupPk(String ORGANIZATION_ID)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCOrg.table + " Where " + xCOrg.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCOrgMst(String ORGANIZATION_ID)
        {
            String sql = "Delete From " + xCOrg.table + " Where " + xCOrg.ORGANIZATION_ID + "='" + ORGANIZATION_ID + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }

        public String insertxCOrgMst(XcustOrgMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.ORGANIZATION_ID))
            {
                deletexCOrgMst(p.ORGANIZATION_ID);
            }
            chk = insert(p);
            return chk;
        }

        public String insert(XcustOrgMstTbl p)
        {
            String sql = "", chk = "";
            try
            {

                sql = "Insert Into " + xCOrg.table + "(" + xCOrg.ORGANIZATION_ID +
                                                        "," + xCOrg.ORGANIZATION_NAME +
                                                        "," + xCOrg.BUSINESS_GROUP_ID +
                                                        "," + xCOrg.SET_OF_BOOKS_ID +
                                                        "," + xCOrg.CHART_OF_ACCOUNTS_ID +
                                                        "," + xCOrg.INVENTORY_FLAG +
                                                        "," + xCOrg.ORGANIZATION_CODE +
                                                        "," + xCOrg.CREATION_DATE +
                                                        "," + xCOrg.LAST_UPDATE_DATE +
                                                        "," + xCOrg.MATERIAL_ACCOUNT_CCID +
                    ") " +
                    "Values('" + decimal.Parse(p.ORGANIZATION_ID) +
                             "','" + p.ORGANIZATION_NAME.Replace("|", ",") +
                             "','" + p.BUSINESS_GROUP_ID +
                             "','" + p.SET_OF_BOOKS_ID +
                             "','" + p.CHART_OF_ACCOUNTS_ID +
                             "','" + p.INVENTORY_FLAG +
                             "','" + p.ORGANIZATION_CODE +
                             "','" + p.CREATION_DATE +
                             "','" + p.LAST_UPDATE_DATE +
                             "','" + p.MATERIAL_ACCOUNT_CCID + "'" +
                             ") ";

                chk = conn.ExecuteNonQuery(sql, "kfc_po");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Doctor");
            }

            return chk;
        }
    }
}
