using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
//using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using ATXBSAPP.ViewModels;
using ATXBSAPP.Views;
using static ATXBSAPP.ViewModels.WebinarVewModel;

namespace ATXAPP
{
    public class RestServiceWebinar
    {
        HttpClient _client;

        public RestServiceWebinar()
        {
            _client = new HttpClient();

        }
        static string serviceUri = "https://atx.crm.dynamics.com/";
        static string redirectUrl = "https://atx.api.crm.dynamics.com/api/data/v9.1/";
        List<ValueW> res = null;
        
        public async Task<List<ValueW>> GetWeatherData3Async()
        {
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
                HttpResponseMessage responses = await httpClient.GetAsync("atx_webinars?$select=atx_name,atx_descripcion,atx_fechadeinicio,atx_fechadefinalizacion,atx_linkderegistro,createdby&$orderby=atx_fechadeinicio%20desc");
                responses.EnsureSuccessStatusCode();
                string json = "";
                if (responses.IsSuccessStatusCode)
                {
                    json = await responses.Content.ReadAsStringAsync();

                    Console.WriteLine("json");
                }

                JObject information = JObject.Parse(json);

                string json2 = JsonConvert.SerializeObject(information["value"]);


                res = (List<ValueW>)JsonConvert.DeserializeObject(json2, typeof(List<ValueW>));



                Console.WriteLine("ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return res;
        }

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
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://atxcrmws.azurewebsites.net/adx_ads.asmx");
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
