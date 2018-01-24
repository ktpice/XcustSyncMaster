using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustGlEntityMstTblDB
    {
        public XcustGlEntityMstTbl xCGl;
        ConnectDB conn;
        private InitC initC;

        public XcustGlEntityMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCGl = new XcustGlEntityMstTbl();

            xCGl.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCGl.CREATION_DATE = "CREATION_DATE";

            xCGl.REGISTRATION_ID = "REGISTRATION_ID";
            xCGl.BRANCH_NUMBER = "BRANCH_NUMBER";
            xCGl.REGISTERED_NAME = "REGISTERED_NAME";
            xCGl.REGISTRATION_NUMBER = "REGISTRATION_NUMBER";
            xCGl.ADDRESS_LINE_1 = "ADDRESS_LINE_1";
            xCGl.ADDRESS_LINE_2 = "ADDRESS_LINE_2";
            xCGl.ADDRESS_LINE_3 = "ADDRESS_LINE_3";
            xCGl.TOWN_OR_CITY = "TOWN_OR_CITY";
            xCGl.REGION_2 = "REGION_2";
            xCGl.POSTAL_CODE = "POSTAL_CODE";
            xCGl.COUNTRY = "COUNTRY";

            xCGl.table = "XCUST_LEGAL_ENTITY_MST_TBL";
        }
        public Boolean selectDupPk(String RegistrationId, String BranchNumber)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCGl.table + " Where " + xCGl.REGISTRATION_ID + "=" + RegistrationId + " AND " + xCGl.BRANCH_NUMBER + " = '" + BranchNumber + "'";
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCGl(String RegistrationId, String BranchNumber)
        {
            String sql = "Delete From " + xCGl.table + " Where " + xCGl.REGISTRATION_ID + "=" + RegistrationId + " AND " + xCGl.BRANCH_NUMBER + " = '" + BranchNumber + "'";
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCGl(XcustGlEntityMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.REGISTRATION_ID, p.BRANCH_NUMBER))
            {
                deletexCGl(p.REGISTRATION_ID, p.BRANCH_NUMBER);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustGlEntityMstTbl p)
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
                sql = "Insert Into " + xCGl.table + "(" +
                                       xCGl.REGISTRATION_ID + "," +
                                       xCGl.BRANCH_NUMBER + "," +
                                       xCGl.REGISTERED_NAME + "," +
                                       xCGl.REGISTRATION_NUMBER + "," +
                                       xCGl.ADDRESS_LINE_1 + "," +
                                       xCGl.ADDRESS_LINE_2 + "," +
                                       xCGl.ADDRESS_LINE_3 + "," +
                                       xCGl.TOWN_OR_CITY + "," +
                                       xCGl.REGION_2 + "," +
                                       xCGl.POSTAL_CODE + "," +
                                       xCGl.COUNTRY +
                    ") " +

                "Values( " + p.REGISTRATION_ID + ",'" +
                    p.BRANCH_NUMBER + "','" + p.REGISTERED_NAME.Replace("|",",") + "','" +
                    p.REGISTRATION_NUMBER + "','" + p.ADDRESS_LINE_1 + "','" +
                    p.ADDRESS_LINE_2 + "','" + p.ADDRESS_LINE_3 + "','" +
                    p.TOWN_OR_CITY + "','" + p.REGION_2 + "','" +
                    p.POSTAL_CODE + "','" + p.COUNTRY + "'" +
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