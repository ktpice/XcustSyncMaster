using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XcustSyncMaster
{
    public class ControlSupplierSiteWebService
    {
        static String fontName = "Microsoft Sans Serif";        //standard
        public String backColor1 = "#1E1E1E";        //standard
        public String backColor2 = "#2D2D30";        //standard
        public String foreColor1 = "#fff";        //standard
        static float fontSize9 = 9.75f;        //standard
        static float fontSize8 = 8.25f;        //standard
        public Font fV1B, fV1;        //standard
        public int tcW = 0, tcH = 0, tcWMinus = 25, tcHMinus = 70, formFirstLineX = 5, formFirstLineY = 5;        //standard

        public ControlMain Cm;
        public ConnectDB conn;        //standard

        //public ValidatePrPo vPrPo;

        private String dateStart = "";      //gen log

        public XcustSupplierSiteMstTblDB xCSupDB;

        public ControlSupplierSiteWebService(ControlMain cm)
        {
            Cm = cm;
            initConfig();
        }
        private void initConfig()
        {
            conn = new ConnectDB("kfc_po", Cm.initC);        //standard
            //vPrPo = new ValidatePrPo();

            xCSupDB = new XcustSupplierSiteMstTblDB(conn, Cm.initC);

            fontSize9 = 9.75f;        //standard
            fontSize8 = 8.25f;        //standard
            fV1B = new Font(fontName, fontSize9, FontStyle.Bold);        //standard
            fV1 = new Font(fontName, fontSize8, FontStyle.Regular);        //standard
        }
        public void setXcustSupTbl(MaterialListView lv1, Form form1, MaterialProgressBar pB1)
        {
            String uri = "", dump = "";
            //HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            const Int32 BufferSize = 128;
            String[] filePO;
            addListView("setXcustSupplierSiteMstTbl ", "Web Service", lv1, form1);
            //filePO = Cm.getFileinFolder(Cm.initC.PathZip);
            //String text = System.IO.File.ReadAllText(filePO[0]);
            //byte[] byteArraytext = Encoding.UTF8.GetBytes(text);
            //byte[] toEncodeAsBytestext = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            //String Arraytext = System.Convert.ToBase64String(toEncodeAsBytestext);
            //< soapenv:Envelope xmlns:soapenv = "http://schemas	xmlsoap	org/soap/envelope/" xmlns: v2 = "http://xmlns	oracle	com/oxp/service/v2" >
            uri = @" <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:pub='http://xmlns.oracle.com/oxp/service/PublicReportService'>  " +
            "<soapenv:Header/> " +
                    "<soapenv:Body> " +
                        "<v2:runReport> " +
                            "<v2:reportRequest> " +
                                "<v2:attributeLocale>en-US</v2:attributeLocale> " +
                                "<v2:attributeTemplate>XCUST_SUPPLIER_SITE_MST_REP</v2:attributeTemplate> " +
                                "<v2:reportAbsolutePath>/Custom/XCUST_CUSTOM/XCUST_SUPPLIER_SITE_MST_REP.xdo</v2:reportAbsolutePath> " +
                                "<pub:parameterNameValues> " +
                                "<pub:item>" +
                                "<pub:multiValuesAllowed>False</pub:multiValuesAllowed> " +
                                "<pub:name>p_update_from</pub:name> " +
                                "<pub:values> " +
                                "<pub:item>" + Cm.initC.p_update_from + "</pub:item> " +
                                "</pub:values> " +
                                "</pub:item> " +
                                "<pub:item> " +
                                "<pub:multiValuesAllowed>False</pub:multiValuesAllowed> " +
                                "<pub:name>p_update_to</pub:name> " +
                                "<pub:values> " +
                                "<pub:item>" + Cm.initC.p_update_to + "</pub:item> " +
                                "</pub:values> " +
                                "</pub:item> " +
                                "</pub:parameterNameValues>  " +
                                "</v2:reportRequest> " +
                                "<v2:userID>"+ Cm.initC.usercloud +"</v2:userID> " +
                                "<v2:password>"+ Cm.initC.passcloud +"</v2:password> " +
                                "</v2:runReport> " +
                                "</soapenv:Body> " +
                                "</soapenv:Envelope> ";

            //byte[] byteArray = Encoding.UTF8.GetBytes(envelope);
            byte[] byteArray = Encoding.UTF8.GetBytes(uri);
            addListView("setXcustSupplierSiteMstTbl Start", "Web Service", lv1, form1);
            // Construct the base 64 encoded string used as credentials for the service call
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(Cm.initC.usercloud + ":" + Cm.initC.passcloud);
            string credentials = System.Convert.ToBase64String(toEncodeAsBytes);

            // Create HttpWebRequest connection to the service
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://eglj.fa.us2.oraclecloud.com/xmlpserver/services/PublicReportService");

            // Configure the request content type to be xml, HTTP method to be POST, and set the content length
            request1.Method = "POST";
            request1.ContentType = "text/xml;charset=UTF-8";
            request1.ContentLength = byteArray.Length;

            // Configure the request to use basic authentication, with base64 encoded user name and password, to invoke the service.
            request1.Headers.Add("Authorization", "Basic " + credentials);

            // Set the SOAP action to be invoked; while the call works without this, the value is expected to be set based as per standards
            request1.Headers.Add("SOAPAction", "https://eglj.fa.us2.oraclecloud.com/xmlpserver/services/PublicReportService");

            // Write the xml payload to the request
            Stream dataStream = request1.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            addListView("setXcustSupplierSiteMstTbl Request", "Web Service", lv1, form1);
            // Get the response and process it; In this example, we simply print out the response XDocument doc;
            string actNumber = "";
            XDocument doc;
            using (WebResponse response = request1.GetResponse())
            {
                addListView("setXcustSupplierSiteMstTbl Response", "Web Service", lv1, form1);
                using (Stream stream = response.GetResponseStream())
                {

                    doc = XDocument.Load(stream);
                    foreach (XNode node in doc.DescendantNodes())
                    {
                        if (node is XElement)
                        {
                            XElement element = (XElement)node;
                            if (element.Name.LocalName.Equals("reportBytes"))
                            {
                                actNumber = element.ToString().Replace(@"<ns1:reportBytes xmlns:ns1=""http://xmlns.oracle.com/oxp/service/PublicReportService"">", "");
                                actNumber = actNumber.Replace("</reportBytes>", "").Replace("</result>", "").Replace(@"""", "").Replace("<>", "");
                                actNumber = actNumber.Replace("<reportBytes>", "").Replace("</ns1:reportBytes>", "");
                            }
                        }
                    }
                }
            }
            actNumber = actNumber.Trim();
            actNumber = actNumber.IndexOf("<reportContentType>") >= 0 ? actNumber.Substring(0, actNumber.IndexOf("<reportContentType>")) : actNumber;
            addListView("setXcustSupplierSiteMstTbl Extract html", "Web Service", lv1, form1);
            byte[] data = Convert.FromBase64String(actNumber);
            string decodedString = Encoding.UTF8.GetString(data);
            //XElement html = XElement.Parse(decodedString);
            //string[] values = html.Descendants("table").Select(td => td.Value).ToArray();

            //int row = -1;
            //var doc1 = new HtmlAgilityPack.HtmlDocument();
            //doc1.LoadHtml(html.ToString());
            //var nodesTable = doc1.DocumentNode.Descendants("tr");
            String[] data1 = decodedString.Split('\n');
            //foreach (var nodeTr in nodesTable)
            for (int row = 0; row < data1.Length; row++)
            {
                if (row == 0) continue;
                if (data1[row].Length <= 0) continue;

                String[] data2 = data1[row].Split(',');
                XcustSupplierSiteMstTbl item = new XcustSupplierSiteMstTbl();
                item.LAST_UPDATE_DATE = xCSupDB.xCSup.dateTimeYearToDB1(data2[13].Trim());
                item.CREATION_DATE = xCSupDB.xCSup.dateTimeYearToDB1(data2[14].Trim());
                item.VENDOR_SITE_SPK_ID = data2[2].Trim();
                item.VENDOR_SITE_ID = data2[3].Trim();
                item.VENDOR_ID = data2[4].Trim();
                item.LOCATION_ID = data2[5].Trim();
                item.VENDOR_SITE_CODE = data2[6].Trim().Replace("\"", "");
                item.PURCHASING_SITE_FLAG = data2[7].Trim();
                item.RFQ_ONLY_SITE_FLAG = data2[8].Trim();
                item.PAY_SITE_FLAG = data2[9].Trim();
                item.MATCH_OPTION = data2[10].Trim().Replace("\"", "");
                item.SUPPLIER_NOTIF_METHOD = data2[11].Trim().Replace("\"", "");
                item.EMAIL_ADDRESS = data2[12].Trim().Replace("\"", "");

                item.ATTRIBUTE1 = data2[15].Trim().Replace("\"", "");
                item.ATTRIBUTE2 = data2[16].Trim().Replace("\"", "");
                item.ATTRIBUTE3 = data2[17].Trim().Replace("\"", "");
                item.ATTRIBUTE4 = data2[18].Trim().Replace("\"", "");
                item.ATTRIBUTE5 = data2[19].Trim().Replace("\"", "");
                item.ATTRIBUTE6 = data2[20].Trim().Replace("\"", "");
                item.ATTRIBUTE7 = data2[21].Trim().Replace("\"", "");
                item.ATTRIBUTE8 = data2[22].Trim().Replace("\"", "");
                item.ATTRIBUTE9 = data2[23].Trim().Replace("\"", "");
                item.ATTRIBUTE10 = data2[24].Trim().Replace("\"", "");
                item.ATTRIBUTE11 = data2[25].Trim().Replace("\"", "");
                item.ATTRIBUTE12 = data2[26].Trim().Replace("\"", "");
                item.ATTRIBUTE13 = data2[27].Trim().Replace("\"", "");
                item.ATTRIBUTE14 = data2[28].Trim().Replace("\"", "");
                item.ATTRIBUTE15 = data2[29].Trim().Replace("\"", "");
                item.PAY_GROUP_LOOKUP_CODE = data2[31].Trim().Replace("\"", "");
                item.TERMS_ID = data2[32].Trim().Equals("") ? "0" : data2[32].Trim();
                item.DEFAULT_PAYMENT_METHOD = data2[33].Trim().Replace("\"", "");
                item.LIABILITY_ACCOUNT_CCID = data2[34].Trim().Equals("") ? "0" : data2[34].Trim();
                item.DEFAULT_WHT_CODE = data2[35].Trim().Replace("\"", "");
                item.TERM_NAME = data2[36].Trim().Replace("\"", "");
                item.TAX_CLASSIFICATION_CODE = data2[37].Trim().Replace("\"", "");

                //int VALUE_SET_ID = 0, VALUE_SET_CODE = 1, VALUE_ID = 2, VALUE = 3, DESCRIPTION = 4, ENABLED_FLAG = 5, LAST_UPDATE_DATE = 6, CREATION_DATE = 7;

                xCSupDB.insertxCSup(item);
            }

            Console.WriteLine(decodedString);
        }

        private void addListView(String col1, String col2, MaterialListView lv1, Form form1)
        {
            lv1.Items.Add(AddToList((lv1.Items.Count + 1), col1, col2));
            form1.Refresh();
        }
        private ListViewItem AddToList(int col1, string col2, string col3)
        {
            //int i = 0;
            string[] array = new string[3];
            array[0] = col1.ToString();
            //i = lv.Items.Count();
            //array[0] = lv.Items.Count();
            array[1] = col2;
            array[2] = col3;

            return (new ListViewItem(array));
        }
    }
}
