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

# 功能介绍
默认模块一键扫描所有漏洞，输入目标地址,选择默认模块，可以一键所有漏洞
Hikvision applyCT模块检测，需要配置ceye token，选择模块可单独选择模块进行漏洞扫描
http://ceye.io/

![image](https://github.com/MInggongK/Hikvision-/blob/main/202406080819451.png)

批量检测模块：

![image](https://github.com/MInggongK/Hikvision-/blob/main/202406080859002.png)

webshell利用模块

内置哥斯拉，冰蝎，蚁剑，JSPcmdshell，测试文件可直接上传（请勿改动文件名）

自定义上传，可选择模块进行上传，输入你要上传的shell代码，保存文件名，点击上传即可

![image](https://github.com/MInggongK/Hikvision-/blob/main/202406080848515.png)

cmshell命令执行模块

![image](https://github.com/MInggongK/Hikvision-/blob/main/202406080907735.png)

验证漏洞是否存在，执行cmdshell命令

![image](https://github.com/MInggongK/Hikvision-/blob/main/202406080909107.png)


