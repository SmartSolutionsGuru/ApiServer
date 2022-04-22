using OtpNet;
using System.Net;
using System.Text;

namespace SmartSolutions.ApiServer.Otp
{
    public class OtpService
    {

        #region [private Members]
        private readonly byte[] salt;
        string MyApiKey = "923230437552-10dd108f-43ee-4b03-9de8-c8891295f4ae"; //Your API Key At Sendpk.com
        string toNumber = "923077723670"; //Recipient cell phone number with country code
        string Masking = "SMS Alert"; //Your Company Brand Name
        string MessageText = "SMS Sent using .Net";
        #endregion
        #region [Constructor]
        public OtpService()
        {

            var key = "abcdefghijklmnopqrstuvwxyz0123456789";
            salt = Encoding.ASCII.GetBytes(key);
            var otp = new Totp(secretKey: salt);
            Random random = new Random();
            int value = random.Next(1001, 9999);
            //var result = SendSMS(Masking, toNumber, MessageText: value.ToString(), "923230437552", "Babahs@1977");
        }
        #endregion

        #region [Public Methods]
        public void InitalizeOtp()
        {
            var otp = new Totp(secretKey: salt);
        }
       
        /// <summary>
        /// SMS Sending Message Method 
        /// </summary>
        /// <param name="Masking"></param>
        /// <param name="toNumber"></param>
        /// <param name="MessageText"></param>
        /// <param name="MyUsername"></param>
        /// <param name="MyPassword"></param>
        /// <returns></returns>
        public string SendSMS(string Masking, string toNumber, string MessageText, string MyUsername, string MyPassword)
        {
            ///TODO: Have to Personalize Message for sending
            String URI = "http://Sendpk.com" +
            "/api/sms.php?" +
            "api_key=" + MyApiKey +
            "&sender=" + Masking +
            "&mobile=" + toNumber +
            "&message=" + Uri.UnescapeDataString(MessageText) +
            "//&message=" + System.Net.WebUtility.UrlEncode(MessageText);
            try
            {
                using (var client = new WebClient())
                {
                    byte[] response = client.UploadValues(URI, new System.Collections.Specialized.NameValueCollection()
                    {
                        {
                            "api_key",
                            MyApiKey

                        },
                        {
                            "number",
                            toNumber
                        },
                        {
                            "message_text",
                            MessageText
                        }
                    });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    //Session["OTP"] = value;

                }
                //WebRequest req = WebRequest.Create(URI);
                //WebResponse resp = req.GetResponse();
                //var sr = new System.IO.StreamReader(resp.GetResponseStream());
                //return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                var httpWebResponse = ex.Response as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return "404:URL not found :" + URI;
                            break;
                        case HttpStatusCode.BadRequest:
                            return "400:Bad Request";
                            break;
                        default:
                            return httpWebResponse.StatusCode.ToString();
                    }
                }
            }
            return null;
            #endregion
        }
    }
}
