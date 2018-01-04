using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    public class XcustLocationsMstTblDB
    {
        public XcustLocationsMstTbl xCGlC;
        ConnectDB conn;
        private InitC initC;

        public XcustLocationsMstTblDB(ConnectDB c, InitC initc)
        {
            conn = c;
            initC = initc;
            initConfig();
        }
        private void initConfig()
        {
            xCGlC = new XcustLocationsMstTbl();

            xCGlC.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCGlC.CREATION_DATE = "CREATION_DATE";

            xCGlC.LOCATION_ID = "LOCATION_ID";
            xCGlC.LOCATION_DETAILS_ID = "LOCATION_DETAILS_ID";
            xCGlC.EFFECTIVE_START_DATE = "EFFECTIVE_START_DATE";
            xCGlC.EFFECTIVE_END_DATE = "EFFECTIVE_END_DATE";
            xCGlC.LOCATION_CODE = "LOCATION_CODE";
            xCGlC.LOCATION_NAME = "LOCATION_NAME";
            xCGlC.DESCRIPTION = "DESCRIPTION";
            xCGlC.STYLE = "STYLE";
            xCGlC.ADDRESS_LINE_1 = "ADDRESS_LINE_1";
            xCGlC.ADDRESS_LINE_2 = "ADDRESS_LINE_2";
            xCGlC.ADDRESS_LINE_3 = "ADDRESS_LINE_3";
            xCGlC.ADDRESS_LINE_4 = "ADDRESS_LINE_4";
            xCGlC.BUILDING = "BUILDING";
            xCGlC.FLOOR_NUMBER = "FLOOR_NUMBER";
            xCGlC.COUNTRY = "COUNTRY";
            xCGlC.POSTAL_CODE = "POSTAL_CODE";
            xCGlC.TIMEZONE_CODE = "TIMEZONE_CODE";

            xCGlC.table = "XCUST_LOCATIONS_MST_TBL";
        }
        public Boolean selectDupPk(String LocId, String LocDetailsId)
        {
            String sql = "";
            Boolean chk = false;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + xCGlC.table + " Where " + xCGlC.LOCATION_ID + " = " + LocId + " and " + xCGlC.LOCATION_DETAILS_ID + " = " + LocDetailsId;
            dt = conn.selectData(sql, "kfc_po");
            if (dt.Rows.Count >= 1)
            {
                chk = true;
            }
            return chk;
        }
        public void deletexCGlC(String LocId, String LocDetailsId)
        {
            String sql = "Delete From " + xCGlC.table + " Where " + xCGlC.LOCATION_ID + " = " + LocId + " and " + xCGlC.LOCATION_DETAILS_ID + " = " + LocDetailsId;
            conn.ExecuteNonQuery(sql, "kfc_po");
        }
        public String insertxCGlC(XcustLocationsMstTbl p)
        {
            String sql = "", chk = "";
            if (selectDupPk(p.LOCATION_ID,p.LOCATION_DETAILS_ID))
            {
                deletexCGlC(p.LOCATION_ID, p.LOCATION_DETAILS_ID);
            }
            chk = insert(p);
            return chk;
        }
        public String insert(XcustLocationsMstTbl p)
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
                sql = "Insert Into " + xCGlC.table + "(" +
                                       xCGlC.LOCATION_ID + "," +
                                       xCGlC.LOCATION_DETAILS_ID + "," +
                                       xCGlC.EFFECTIVE_START_DATE + "," +
                                       xCGlC.EFFECTIVE_END_DATE + "," +
                                       xCGlC.LOCATION_CODE + "," +
                                       xCGlC.LOCATION_NAME + "," +
                                       xCGlC.DESCRIPTION + "," +
                                       xCGlC.STYLE + "," +
                                       xCGlC.ADDRESS_LINE_1 + "," +
                                       xCGlC.ADDRESS_LINE_2 + "," +
                                       xCGlC.ADDRESS_LINE_3 + "," +
                                       xCGlC.ADDRESS_LINE_4 + "," +
                                       xCGlC.BUILDING + "," +
                                       xCGlC.FLOOR_NUMBER + "," +
                                       xCGlC.COUNTRY + "," +
                                       xCGlC.POSTAL_CODE + "," +
                                       xCGlC.TIMEZONE_CODE + "," +
                                       xCGlC.CREATION_DATE + "," +
                                       xCGlC.LAST_UPDATE_DATE + " " +
                ") " +

                    "Values( " + p.LOCATION_ID + "," +
                                 p.LOCATION_DETAILS_ID + ",'" + 
                                 p.EFFECTIVE_START_DATE + "','" +
                                 p.EFFECTIVE_END_DATE + "','" + 
                                 p.LOCATION_CODE + "','" + 
                                 p.LOCATION_NAME + "','" +
                                 p.DESCRIPTION + "','" +
                                 p.STYLE + "','" +
                                 p.ADDRESS_LINE_1 + "','" +
                                 p.ADDRESS_LINE_2 + "','" +
                                 p.ADDRESS_LINE_3 + "','" +
                                 p.ADDRESS_LINE_4 + "','" +
                                 p.BUILDING + "','" +
                                 p.FLOOR_NUMBER + "','" +
                                 p.COUNTRY + "','" +
                                 p.POSTAL_CODE + "','" +
                                 p.TIMEZONE_CODE + "','" +
                                 p.CREATION_DATE + "','" +
                                 p.LAST_UPDATE_DATE + "'" +
      

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
