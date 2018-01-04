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
    class ControlBlanketLine
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

        public XcustBlanketLineTblDB xCBlkLDB;

        public ControlBlanketLine(ControlMain cm)
        {
            Cm = cm;
            initConfig();
        }

        private void initConfig()
        {
            conn = new ConnectDB("kfc_po", Cm.initC);        //standard
            //vPrPo = new ValidatePrPo();

            xCBlkLDB = new XcustBlanketLineTblDB(conn, Cm.initC);

            fontSize9 = 9.75f;        //standard
            fontSize8 = 8.25f;        //standard
            fV1B = new Font(fontName, fontSize9, FontStyle.Bold);        //standard
            fV1 = new Font(fontName, fontSize8, FontStyle.Regular);        //standard
        }

        public void setXcustBlkLTbl(MaterialListView lv1, Form form1, MaterialProgressBar pB1)
        {
            String uri = "", dump = "";
            //HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            const Int32 BufferSize = 128;
            String[] filePO;
            addListView("setXcustBlkLTbl ", "Web Service", lv1, form1);
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
                                "<v2:attributeTemplate>XCUST_BLANKET_AGREEMENT_LINE_REP</v2:attributeTemplate> " +
                                "<v2:reportAbsolutePath>/Custom/XCUST_CUSTOM/XCUST_BLANKET_AGREEMENT_LINE_REP.xdo</v2:reportAbsolutePath> " +
                                "<pub:parameterNameValues> " +
                                "<pub:item> " +
                                    "<pub:multiValuesAllowed>False</pub:multiValuesAllowed> " +
                                    "<pub:name>p_cre_date_frm</pub:name> " +   //PARAMETER : p_cre_date_frm
                                    "<pub:values> " +
                                        "<pub:item></pub:item> " +
                                    "</pub:values>" +
                                "</pub:item>" +
                                "<pub:item>" +
                                    "<pub:multiValuesAllowed>False</pub:multiValuesAllowed>" +
                                    "<pub:name>p_cre_date_to</pub:name>" +   //PARAMETER : p_cre_date_to
                                    "<pub:values>" +
                                        "<pub:item></pub:item>" +
                                    "</pub:values>" +
                                "</pub:item> " +
                                "<pub:item>" +
                                    "<pub:multiValuesAllowed>False</pub:multiValuesAllowed> " +
                                    "<pub:name>p_update_date_frm</pub:name> " +   //PARAMETER : p_update_date_frm
                                    "<pub:values> " +
                                        "<pub:item></pub:item> " +
                                    "</pub:values> " +
                                "</pub:item> " +
                                "<pub:item> " +
                                    "<pub:multiValuesAllowed>False</pub:multiValuesAllowed> " +
                                    "<pub:name>p_update_date_to</pub:name> " +  //PARAMETER : p_update_date_to
                                        "<pub:values> " +
                                    "<pub:item></pub:item> " +
                                    "</pub:values> " +
                                "</pub:item> " +
                                "</pub:parameterNameValues>  " +
                                "</v2:reportRequest> " +
                                "<v2:userID>icetech@iceconsulting.co.th</v2:userID> " +  //username
                                "<v2:password>icetech@2017</v2:password> " +   //password
                                "</v2:runReport> " +
                                "</soapenv:Body> " +
                                "</soapenv:Envelope> ";

            //byte[] byteArray = Encoding.UTF8.GetBytes(envelope);
            byte[] byteArray = Encoding.UTF8.GetBytes(uri);
            addListView("setXcustBlkLTbl Start", "Web Service", lv1, form1);
            // Construct the base 64 encoded string used as credentials for the service call
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes("icetech@iceconsulting.co.th" + ":" + "icetech@2017");
            string credentials = System.Convert.ToBase64String(toEncodeAsBytes);

            // Create HttpWebRequest connection to the service
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://eglj-test.fa.us2.oraclecloud.com/xmlpserver/services/PublicReportService");

            // Configure the request content type to be xml, HTTP method to be POST, and set the content length
            request1.Method = "POST";
            request1.ContentType = "text/xml;charset=UTF-8";
            request1.ContentLength = byteArray.Length;

            // Configure the request to use basic authentication, with base64 encoded user name and password, to invoke the service.
            request1.Headers.Add("Authorization", "Basic " + credentials);

            // Set the SOAP action to be invoked; while the call works without this, the value is expected to be set based as per standards
            request1.Headers.Add("SOAPAction", "https://eglj-test.fa.us2.oraclecloud.com/xmlpserver/services/PublicReportService");

            // Write the xml payload to the request
            Stream dataStream = request1.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            addListView("setXcustBlKLTbl Request", "Web Service", lv1, form1);
            // Get the response and process it; In this example, we simply print out the response XDocument doc;
            string actNumber = "";
            XDocument doc;
            using (WebResponse response = request1.GetResponse())
            {
                addListView("setXcustBlKLTbl Response", "Web Service", lv1, form1);
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
            addListView("setXcustBlKLTbl Extract html", "Web Service", lv1, form1);
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
                XcustBlanketLineTbl item = new XcustBlanketLineTbl();

                item.LINE_NUMBER = data2[0].Trim().Replace("\"", "");
                item.ITEM_ID = data2[1].Trim().Replace("\"", "");
                item.ITEM_CODE = data2[2].Trim().Replace("\"", "");
                item.DESCRIPTION = data2[3].Trim().Replace("\"", "");
                item.UOM = data2[4].Trim().Trim().Replace("\"", "");
                item.PRICE = data2[5].Trim().Trim().Equals("") ? "0" : data2[5].Trim();
                item.RELEASE_AMT = data2[6].Trim().Equals("") ? "0" : data2[6].Trim();
                item.EXPIRATION_DATE = data2[7].Trim().Replace("\"", "");
                item.LINE_STATUS = data2[8].Trim().Trim().Replace("\"", "");
                item.LINE_AGREEMENT_QTY = data2[9].Trim().Equals("") ? "0" : data2[9].Trim();  //QUANTITY_COMMITTED
                item.LINE_AGREEMENT_AMT = data2[10].Trim().Equals("") ? "0" : data2[10].Trim();  //COMMITTED_AMOUNT
                item.ALLOW_PRICE_OVERIDE = data2[11].Trim().Equals("") ? "0" : data2[11].Trim();  //ALLOW_PRICE_OVERRIDE_FLAG
                //item.COMUNICATION_METHOD = data2[12].Trim().Trim().Replace("\"", "");  //NOT_TO_EXCEED_PRICE
                //item.DESCRIPTION = data2[13].Trim().Trim().Replace("\"", "");  //REVISION_NUM
                item.CURRENCY_CODE = data2[14].Trim().Replace("\"", "");  //CURRENCY_CODE
                item.CREATION_DATE = data2[15].Trim().Replace("\"", "");  //CREATION_DATE
                item.LAST_UPDATE_DATE = data2[16].Trim().Replace("\"", "");  //LAST_UPDATE_DATE
                //item.RELEASE_AMT = data2[17].Trim().Equals("") ? "0" : data2[17].Trim(); ;  //COMPONENT_AMOUNT_RELEASED
                item.PO_HEADER_ID = data2[18].Trim().Replace("\"", "");  //PO_HEADER_ID
                item.PO_LINE_ID = data2[19].Trim().Replace("\"", "");//PO_LINE_ID
                item.min_release_amt = data2[20].Trim().Equals("") ? "0" : data2[20].Trim();  //MIN_RELEASE_AMT
                item.ATTRIBUTE1 = data2[21].Trim().Replace("\"", "");//ATTRIBUTE1
                item.ATTRIBUTE2 = data2[22].Trim().Replace("\"", "");//ATTRIBUTE2
                item.ATTRIBUTE3 = data2[23].Trim().Replace("\"", "");//ATTRIBUTE3
                item.ATTRIBUTE4 = data2[24].Trim().Replace("\"", "");//ATTRIBUTE4
                item.ATTRIBUTE5 = data2[25].Trim().Replace("\"", "");//ATTRIBUTE5
                item.ATTRIBUTE6 = data2[26].Trim().Replace("\"", "");//ATTRIBUTE6
                item.ATTRIBUTE7 = data2[27].Trim().Replace("\"", "");//ATTRIBUTE7
                item.ATTRIBUTE8 = data2[28].Trim().Replace("\"", "");//ATTRIBUTE8
                item.ATTRIBUTE9 = data2[29].Trim().Replace("\"", "");//ATTRIBUTE9
                item.ATTRIBUTE10 = data2[30].Trim().Replace("\"", "");//ATTRIBUTE10

                item.LINE_RELEASE_AMT = "0";
                item.LINE_RELEASE_QTY = "0";
                item.LINE_REVISION = "0";
                item.PRICE_LIMIT = "0";


                //item.LAST_UPDATE_DATE = xCBlkHDB.xCBlKH.dateTimeYearToDB1(data2[0].Trim());
                //item.CREATION_DATE = xCBlkHDB.xCBlKH.dateTimeYearToDB1(data2[1].Trim());


                xCBlkLDB.insertxCBlKL(item);

                //addListView("insert XCUST_BLANKET_AGREEMENT_LINES_TBL", "Web Service", lv1, form1);
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
