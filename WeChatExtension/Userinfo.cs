using System;
using System.Collections.Generic;
using System.Text;

namespace WeChatExtension
{
    public class Userinfo
    {
        public string appid { get; set; }
        public string secret { get; set; }
        public string code { get; set; }
        public string state { get; set; }
        public string urlTocken { get; set; } = "https://api.weixin.qq.com/sns/oauth2/access_token";
    }
}
