using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeChatExtension
{
    public class Oauth2
    {
        public async Task<string> GetOpenID(string appid,string secret,string code, string state,string urlTocken= "https://api.weixin.qq.com/sns/oauth2/access_token")
        {
            //string appid = "wxa2c774b190986dae";
            //string secret = "7727ee720ba694613e2ab91d14357ab8";
            string url = $"{urlTocken}?appid={appid}&secret={secret}&code={code}&grant_type=authorization_code";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "textml;charset=UTF-8";
            string jsonData = "";
            using (HttpWebResponse response1 = (HttpWebResponse)request.GetResponseAsync().Result)
            {
                using (StreamReader sr = new StreamReader(response1.GetResponseStream(), Encoding.UTF8))
                {
                    jsonData = sr.ReadToEnd();
                    sr.Close();
                }
                response1.Close();
            }

            if (string.IsNullOrEmpty(jsonData))
            {
                return string.Empty;
            }
            //{"errcode":41008,"errmsg":"missing code, rid: 61adc662-1abc1c78-034f5708"}

            string jsonString = jsonData;
            JObject json = JObject.Parse(jsonString);
            if (json["openid"] == null) return string.Empty;

            string openid = json["openid"].ToString();
            return openid;

            //string access_token = json["access_token"].ToString();
            //Debug.Print($"access_token:{access_token}");

        }
    }
}
