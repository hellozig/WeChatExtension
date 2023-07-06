#  获取微信用户的OpenID

---
***


**用户需要关注微信服务号，服务号需要认证**

+ appid：微信服务号的appid
+ secret微信服务号的开发密码
+ code可以从微信跳转获取
+ state随意
+ urlTocken目前固定。


示例
```c#
var guid =await  Oauth2.CheckOpenID(openid);
```
_http://www.diguisoft.com_