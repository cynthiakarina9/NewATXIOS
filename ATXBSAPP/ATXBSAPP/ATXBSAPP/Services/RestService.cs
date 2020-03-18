
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;

namespace ATXBSAPP.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }
        static string serviceUri = "https://atx.crm.dynamics.com/";
        static string redirectUrl = "https://atx.api.crm.dynamics.com/api/data/v9.1/";
        /*public async Task<NewsViewModel> GetNewsViewModel(string uri)
        {
            NewsViewModel weatherData = null;
            try
            {
                string authToken = InvokeService();

                HttpClient httpClient = null;
                httpClient = new HttpClient();
                //Default Request Headers needed to be added in the HttpClient Object
                httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Set the Authorization header with the Access Token received specifying the Credentials
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                httpClient.BaseAddress = new Uri(redirectUrl);
                var responses = httpClient.GetAsync("adx_ads?$select=adx_name,createdon").Result;
                var accounts = "";
                dynamic json = "";
                if (responses.IsSuccessStatusCode)
                {
                    accounts = responses.Content.ReadAsStringAsync().Result;
                    json = JsonConvert.DeserializeObject(accounts);

                    Console.WriteLine("OK");
                }


                weatherData = JsonConvert.DeserializeObject<NewsViewModel>(json);
                //weatherData = weatherData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return weatherData;
        }*/

        public string InvokeService()
        {
            //Calling CreateSOAPWebRequest method  
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request  
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
              <soap12:Body>
                <tokenResponse xmlns=""http://tempuri.org/"">
                  <tokenResult>string</tokenResult>
                </tokenResponse>
              </soap12:Body>
            </soap12:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request  
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {

                    //reading stream  
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console  
                    //Console.WriteLine(ServiceResult);
                    //Console.ReadLine();


                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(ServiceResult);
                    /*var json = JsonConvert.SerializeXmlNode(doc);
                    Serviceres.Close();         
                    var valor = (JObject)JsonConvert.DeserializeObject(json);*/
                    string token = doc.InnerText;/*valor.Envelope.Body.tokenResponse.tokenResult*/;
                    return token;
                }
            }
        }

        public HttpWebRequest CreateSOAPWebRequest()
        {
            //Making Web Request  
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://instancia-tess.azurewebsites.net/adx_ads.asmx");
            //SOAPAction  
            Req.Headers.Add(@"SOAPAction:http://tempuri.org/token");
            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }
    }
}
