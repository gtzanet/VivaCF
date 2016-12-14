using System;
using System.Threading.Tasks;
using System.Web.UI;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using viva2_client;

namespace viva2_client
{
    public  class paymentValues
    {
        public decimal amount;
        public int pr_id;
    }


    public partial class About : Page
    {


        private const string merchantId = "0054fb51-69ca-4416-8e8a-2fa27b0e171b";
        //private const string merchantId = "6466348D-85B2-4CBC-978B-422C688D2D45";
        private const string apiKey = "(QW)1H";


        paymentValues paymentDetails = new paymentValues();

        protected async void Page_Load(object sender, EventArgs e)
        {
            //UserDetails.
            if (Request.HttpMethod == "POST")
            {
                var cl = new RestClient("https://demo.vivapayments.com/api/")
                {
                    Authenticator = new HttpBasicAuthenticator(merchantId, apiKey)
                };
                var request = new RestRequest("transactions", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                request.AddParameter("PaymentToken", Request.Form["vivaWalletToken"]);

                var response = await cl.ExecuteTaskAsync<TransactionResult>(request);

                if (response.Data != null)
                {
                    Response.Write(response.Data.ErrorCode + "--" + response.Data.ErrorText);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ////////////////Response.Write("<br />Successful payment");
                        paymentDetails.amount = decimal.Parse(TextBox1.Text);
                        paymentDetails.pr_id = 7;


                       RegisterAsyncTask(new PageAsyncTask(InsertPayment));
                    }
                }
                else
                    Response.Write(response.ResponseStatus);
            }
        }

        public async Task InsertPayment()
        {
            try
            {

                //string result = await new Payment().SuccessfulPaymentInserton;
                System.Web.HttpCookie aCookie = Request.Cookies["token"];
                string token = "";
                if (aCookie != null) token = Server.HtmlEncode(aCookie.Value);


                HttpContent content;
                string jsonString = "";

                var baseAddress = new Uri("http://localhost:60264/");
                using (var handler1 = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler1) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Post, "api/Payments/");
                    message.Headers.Add("Cookie", "token=" + token);
                    message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    message.Content  =  new StringContent(JsonConvert.SerializeObject(paymentDetails), Encoding.UTF8, "application/json");

                    var result = await client.SendAsync(message);

                    content = result.Content;
                    jsonString = await content.ReadAsStringAsync();

                    result.EnsureSuccessStatusCode();
                }



            }
            catch (Exception e)
            {
                // throw e;
                Response.Redirect("~\\ErrorPage.aspx");
            }
        }
    }

    public class TransactionResult
    {
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public decimal Amount { get; set; }
        public Guid TransactionId { get; set; }
    }





   
}