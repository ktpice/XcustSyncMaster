using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcustSyncMaster
{
    class XcustGlLedgerTbl : Persistent
    {
        public String LEDGER_ID = "";
        public String OBJECT_VERSION_NUMBER = "";
        public String NAME = "";
        public String SHORT_NAME = "";
        public String DESCRIPTION = "";
        public String LEDGER_CATEGORY_CODE = "";
        public String ALC_LEDGER_TYPE_CODE = "";
        public String OBJECT_TYPE_CODE = "";
        public String LE_LEDGER_TYPE_CODE = "";
        public String COMPLETION_STATUS_CODE = "";
        public String CHART_OF_ACCOUNTS_ID = "";
        public String PERIOD_SET_NAME = "";
        public String CURRENCY_CODE = "";
        public String ENABLE_BUDGETARY_CONTROL_FLAG = "";
        public String ACCESS_SET_ID = "";
    }
}
