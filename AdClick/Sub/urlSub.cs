using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AdClick.Sub
{
    public class urlSub
    {
        public static string getURL(string urlid)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@id", urlid) };
            string sql = "Select url from urlList where id=@id";
            DataTable dt = DBHelperSQL.Query(sql, pars).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string url = dt.Rows[0]["url"].ToString();
                return url;
            }
            else
            {
                return "";
            }
        }

        public static string[] getCount(string urlid)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@id", urlid) };
            string sql = "Select product,(Select count(id) as t from clickList where urlid=urlList.id) as t from urlList where id=@id";
            DataTable dt = DBHelperSQL.Query(sql, pars).Tables[0];
            string[] arr = new string[2];
            if (dt.Rows.Count > 0)
            {
                arr[0] = dt.Rows[0]["product"].ToString();
                arr[1] = dt.Rows[0]["t"].ToString();
            }
            return arr;
        }

        public static void InsertPro(string product,string url)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@product", product), new SqlParameter("@url", url) };
            string sql = "Insert into urlList (product,url) Values(@product,@url)";
            DBHelperSQL.ExecuteSql(sql, pars);
        }

        public static void InsertURL(string urlid)
        {
            string ip = getIP();
            string os = SystemCheck();
            System.Web.HttpBrowserCapabilities browser =HttpContext.Current.Request.Browser;
            string brows=browser.Browser;
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@ip", ip), new SqlParameter("@urlid", urlid) };
            string sql = "Insert into clickList (ip,urlid,system,browser) values(@ip,@urlid,'" + os + "','" + brows + "')";
            DBHelperSQL.ExecuteSql(sql, pars);
        }

        /// <summary>
        /// 获取本地ip
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            //string hostname = Dns.GetHostName();//得到本机名   
            ////IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址   
            //IPHostEntry localhost = Dns.GetHostEntry(hostname);
            //IPAddress localaddr = localhost.AddressList[0];
            //return localaddr.ToString();

            String hostInfo = Dns.GetHostName();
            System.Net.IPAddress addr;
            addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            String IpAddress = addr.ToString();
            return IpAddress;
        }

        public static string getIP()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (null == result || result == String.Empty)
            {
                return "0.0.0.0";
            }
            return result;
        }

        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUrlList()
        {
            string sql = "Select *,(select count(*) from clickList where urlid=urllist.id) as counts from urllist order by addtime desc";
            return DBHelperSQL.Query(sql).Tables[0];
        }

        /// <summary>
        /// 获取详情列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetClickList(string urlid)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@urlid", urlid) };
            string sql = "Select * from clickList where urlid=@urlid";
            return DBHelperSQL.Query(sql, pars).Tables[0];
        }
        public static DataTable GetClickList(string urlid,string type)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@urlid", urlid), new SqlParameter("@type", type) };
            string sql2 = "Select " + type + " as tyname,count(id) as t,ltrim(cast(count(id)*1.0/(select count(id) from clickList where urlid=1)*100 as dec(10,2)))+'%' as per from clickList where urlid=1 group by " + type + " order by t desc," + type;
            string sql = "Select "+type+" as tyname,count(id) as t from clickList where urlid=@urlid group by "+type+" order by t desc,"+type;
            return DBHelperSQL.Query(sql2, pars).Tables[0];
        }

        /// <summary>
        /// 更新ip list
        /// </summary>
        /// <param name="urlid"></param>
        public static void UpdateClickArea(string urlid)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@urlid", urlid) };
            string sql = "Select * from clickList where urlid=@urlid and (area is null or area='')";
            DataTable dt= DBHelperSQL.Query(sql, pars).Tables[0];

            for (int i=0;i<dt.Rows.Count;i++)
            {
            HttpWebRequest req;
            string strGet = "http://ip.taobao.com/service/getIpInfo.php?ip=" + dt.Rows[i]["ip"];

            
            //var IPs = JsonConvert.DeserializeObject(json, typeof(DataTable));
            //DataTable dt1 = JsonConvert.DeserializeObject<DataTable>(json);
            req = (HttpWebRequest)WebRequest.Create(strGet);  //依据地址创建一个请求对象
            HttpWebResponse response;
            response = (HttpWebResponse)req.GetResponse();    //根据请求得到响应

            Stream s = response.GetResponseStream();          //得到响应流
            
            using (System.IO.StreamReader reader = new System.IO.StreamReader(s))
            {
                string jsons =reader.ReadToEnd();
                JObject jObject = JObject.Parse(jsons);
                if (jObject["code"].ToString() == "0")
                {
                    string Area = jObject["data"]["area"].ToString();
                    string Region = jObject["data"]["region"].ToString();
                    string City = jObject["data"]["city"].ToString();

                    SqlParameter[] par = new SqlParameter[] { new SqlParameter("@Area", Area), new SqlParameter("@Region", Region), new SqlParameter("@City", City), new SqlParameter("@id", dt.Rows[i]["id"]) };
                    string upsql = "Update clickList set Area=@Area,Region=@Region,City=@City where id=@id";
                    DBHelperSQL.ExecuteSql(upsql, par);
                }
            }
            //    string jsons = reader.ReadToEnd();
            //    var a = JsonConvert.SerializeObject(jsons);
            //    //IPList IPs=JsonConvert.DeserializeObject<IPList>(a);
            //    DataTable dt1 = JsonConvert.DeserializeObject<DataTable>(a);

            //    //IPList deserializedProduct = js.DeserializeObject(jsons);

            //    //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //    //string area=serializer.Serialize(testCategory);

            //    //SqlParameter[] par = new SqlParameter[] { new SqlParameter("@Area", IPs.area), new SqlParameter("@City", IPs.city), new SqlParameter("@id", dt.Rows[i]["id"]) };
            //    //string upsql = "Update clickList set Area=@Area,City=@City where id=@id";
            //    //DBHelperSQL.ExecuteSql(upsql, par);
            //}
            

            //XmlTextReader reader = new XmlTextReader(s);      //读出流中的XML内容
            //reader.MoveToContent();                           //跳过第一行<?xml version="1.0" encoding="utf-8">
            //string a = reader.ReadInnerXml();              //将XML的内容赋给lable3
            //reader.Close();      
            }
            
        }

        /// <summary>
        /// 读取管理员ip
        /// </summary>
        /// <returns></returns>
        public static bool ReadAdminXml()
        {
            DataSet myds = new DataSet();
            myds.ReadXml(HttpContext.Current.Server.MapPath("ip.xml"));
            DataTable dt = myds.Tables[0];
            string ip = getIP();
            bool back = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ip == dt.Rows[i]["ip"].ToString())
                {
                    back = true;
                    break;
                }
            }
            return back;
        }

        //获取客户端操作系统版本号
        public static string SystemCheck()
        {
            string Agent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];

            if ((Agent.IndexOf("NT") > 0) || (Agent.IndexOf("Windows") > 0))
            {
                return "Windows";
            }
            else if (Agent.IndexOf("Mac") > 0)
            {
                return "Mac";
            }
            else if (Agent.IndexOf("iPad") > 0)
            {
                return "iPad";
            }
            else if (Agent.IndexOf("iPhone") > 0)
            {
                return "iPhone";
            }
            else if (Agent.IndexOf("Android") > 0) 
            { 
                return "Android";
            }
            return Agent;
            //{
            //    return "Windows NT ";
            //}

            //if (Agent.IndexOf("NT 4.0") > 0)
            //{
            //    return "Windows NT ";
            //}
            //else if (Agent.IndexOf("NT 5.0") > 0)
            //{
            //    return "Windows 2000";
            //}
            //else if (Agent.IndexOf("NT 5.1") > 0)
            //{
            //    return "Windows XP";
            //}
            //else if (Agent.IndexOf("NT 5.2") > 0)
            //{
            //    return "Windows 2003";
            //}
            //else if (Agent.IndexOf("NT 6.0") > 0)
            //{
            //    return "Windows Vista";
            //}
            //else if (Agent.IndexOf("WindowsCE") > 0)
            //{
            //    return "Windows CE";
            //}
            //else if (Agent.IndexOf("NT") > 0)
            //{
            //    return "Windows NT ";
            //}
            //else if (Agent.IndexOf("9x") > 0)
            //{
            //    return "Windows ME";
            //}
            //else if (Agent.IndexOf("98") > 0)
            //{
            //    return "Windows 98";
            //}
            //else if (Agent.IndexOf("95") > 0)
            //{
            //    return "Windows 95";
            //}
            //else if (Agent.IndexOf("Win32") > 0)
            //{
            //    return "Win32";
            //}
            //else if (Agent.IndexOf("Linux") > 0)
            //{
            //    return "Linux";
            //}
            //else if (Agent.IndexOf("SunOS") > 0)
            //{
            //    return "SunOS";
            //}
            //else if (Agent.IndexOf("Mac") > 0)
            //{
            //    return "Mac";
            //}
            //else if (Agent.IndexOf("Linux") > 0)
            //{
            //    return "Linux";
            //}
            //else if (Agent.IndexOf("Windows") > 0)
            //{
            //    return "Windows";
            //}
            //return "未知类型";

        }
    }
}