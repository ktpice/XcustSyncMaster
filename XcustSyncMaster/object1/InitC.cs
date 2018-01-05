using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    public class InitC
    {
        public String usercloud = "";
        public String passcloud = "";

        public String AutoValueSet = "";
        public String AutoItemMaster = "";  //kts
        public String AutoSubInvMaster = "";  //kts
        public String AutoUomMaster = "";  //kts
        public String AutoUomConvertMaster = "";  //kts
        public String AutoCurMaster = "";  //kts
        public String AutoBuMaster = "";  //kts
        public String AutoItemLocator = "";  //kts
        public String AutoCSTPeriodMaster = "";  //kts
        public String AutoCatMappingMaster = "";  //kts

        public String AutoGlPeriod = ""; //kwl 20171129
        public String AutoApSource = ""; //kwl 20171129   
        public String AutoGlEntity = ""; //kwl 20171129  
        public String AutoTaxCode = ""; //kwl 20171130
        public String AutoSupplier = ""; //kwl 20171130
        public String AutoSupplierSite = ""; //kwl 20171130

        public String EmailPort = "3306";
        public String EmailCharset = "hisorc_ma";        //orc master
        public String EmailUsername = "172.25.1.153";
        public String EmailPassword = "root";
        public String EmailSMTPSecure = "Ekartc2c5";
        public String EmailHost = "hisorc_ba";        // orc backoffice
        public String EmailSender = "172.25.1.153";


        public String databaseDBKFCPO = "bithis";        // orc BIT
        public String hostDBKFCPO = "172.25.1.153";
        public String userDBKFCPO = "root";
        public String passDBKFCPO = "Ekartc2c5";
        public String portDBKFCPO = "3306";

       


    }
}
