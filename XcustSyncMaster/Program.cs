using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XcustSyncMaster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();

            ControlMain Cm = new ControlMain();



            Cm.args = args;
            Cm.setAgrument();
            //MessageBox.Show("args "+ args.Length, "");

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("xcustvalueset"))
            {
                Application.Run(new XcustValueSet(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("xcustvalueset"))
            {
                Application.Run(new XcustValueSet(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustItemMstWebService"))
            {
                Application.Run(new XCustItemMstWebService(Cm));
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Equals("XCustSubInvMstWebService"))
            {
                Application.Run(new XCustSubInvMstWebService(Cm));
            }
            else
            {
                //Application.Run(new XCustPoRWebService(Cm));
                //Application.Run(new XCustGlPeriodWebService(Cm));
                //Application.Run(new XCustApSourceWebService(Cm));
                //Application.Run(new XCustGlEntityWebService(Cm)); 
                Application.Run(new XCustSubInvMstWebService(Cm));  //kts
            }


        }
    }
}
