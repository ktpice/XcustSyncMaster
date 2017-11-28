using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class XcustBlanketHeaderTblDB
    {
        public XcustBlanketHeaderTbl xCBHT;
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
            xCBHT = new XcustBlanketHeaderTbl();

            xCBHT.LAST_UPDATE_DATE = "LAST_UPDATE_DATE";
            xCBHT.POCUMENT_BU = "";
            xCBHT.AGREEMENT_NUMBER = "";
            xCBHT.STATUS = "";
            xCBHT.BUYER = "";
            xCBHT.SUPPLIER = "";
            xCBHT.SUPPLIER_SITE = "";
            xCBHT.SUPPLIER_CODE = "";
            xCBHT.COMUNICATION_METHOD = "";
            xCBHT.E_MAIL = "";
            xCBHT.START_DATE = "";
            xCBHT.END_DATE = "";
            xCBHT.AGREEMENT_AMT = "";
            xCBHT.MIN_RELEASE_AMT = "";
            xCBHT.RELEASE_AMT = "";
            xCBHT.DESCRIPTION = "";
            xCBHT.LAST_UPDATE_DATE = "";
            xCBHT.CREATION_DATE = "";
            xCBHT.PO_HEADER_ID = "";
    }

    }
}
