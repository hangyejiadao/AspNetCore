using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebPC.Controllers.Base;
using Dos.ORM.WebPC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class SyjDtlController : SubBaseController
    {
        public const string KeyId = "SYJID";
        public const string KeyObj = "TW_SYJZBDto";

        public static readonly string ChartUrl = ConfigurationManager.AppSettings["ChartUrl"];

        // GET: MsSys/BhzDtl
        public ActionResult Index()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId,out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            return View(data);
        }

        #region 跳转到对应的视图

        public ActionResult KY_GJ()
        {
            //图形是万能机
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Wnjs.Select(p => p.PICURL).ToList(), 3, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_GJHJ()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Wnjs.Select(p => p.PICURL).ToList(), 3, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_GJJX()
        {

            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Wnjs.Select(p => p.PICURL).ToList(), 3, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_HNT()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Yljs.Select(p => p.PICURL).ToList(), 3, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_SNJSKY()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Yljs.Select(p => p.PICURL).ToList(), 6, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_SNJSKZ()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Yljs.Select(p => p.PICURL).ToList(), 6, data.SoftUrl);
            return View(data);
        }
        public ActionResult KY_JZSJ()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Yljs.Select(p => p.PICURL).ToList(), 3, data.SoftUrl);
            return View(data);
        }

        public ActionResult KY_SJ()
        {
            string orggId = string.Empty;
            string syjapi = string.Empty;
            var data = GetData(out orggId, out syjapi);
            ViewBag.orggId = orggId;
            ViewBag.syjapi = syjapi;
            CalcaChartData(data.Yljs.Select(p => p.PICURL).ToList(), 6, data.SoftUrl);
            return View(data);
        }
        public ActionResult Prints()
        {
            var Ids = Request.QueryString["Ids"].Split(',');
            string orgId = Request.QueryString["orgId"];
            string syjapi = Request.QueryString["syjapi"];
            List<TW_SYJZBDto> list = new List<TW_SYJZBDto>();
            foreach (var item in Ids)
            {
                if (item != null && orgId != null)
                {
                    var model = HttpClientHelper.Get(syjapi + BHZAPIHelper.GetDyData + item + "/" + orgId);
                    TW_SYJZBDto obj =
                        JsonHelper.JsonToObject<TW_SYJZBDto>(JsonHelper.JsonToObject<OperateModel>(model).Data
                            .ToString());
                    list.Add(obj);
                }
            }
            ViewBag.orgId = orgId;
            ViewBag.syjapi = syjapi;
            return View(list);
        }



        #endregion

        #region 图像处理的方法

        /// <summary>
        /// 直接数据
        /// </summary>
        /// <param name="ascdata"></param>
        /// <param name="labels"></param>
        /// <param name="datas"></param> 
        public void GetChartData(string ascdata, out string labels, out string datas)
        {

            string[] arr = ascdata.Split(';');

            List<string> labellist = new List<string>();
            List<string> datalist = new List<string>();
            for (var i = 0; i < arr.Length; i++)
            {
                string lineStr = arr[i];
                if (lineStr.Contains(':'))
                {
                    labellist.Add(lineStr.Substring(0, lineStr.IndexOf(':')));
                    datalist.Add(lineStr.Substring(lineStr.IndexOf(':') + 1,
                        lineStr.Length - lineStr.IndexOf(':') - 1));
                }
            }
            labels = string.Join(",", labellist);
            datas = string.Join(",", datalist);
        }

        /// <summary>
        /// txt格式
        /// </summary>
        /// <param name="txtUrl"></param>
        /// <param name="labels"></param>
        /// <param name="datas"></param>
        public void GetChartDataByTxt(string txt, out string labels, out string datas)
        {
            List<string> labellist = new List<string>();
            List<string> datalist = new List<string>();
            if (!string.IsNullOrWhiteSpace(txt))
            {
                string lineStr = txt.Replace("\0\r\0\n", "*").Replace("\0", "");
                var strs = lineStr.Split('*');
                foreach (var item in strs)
                {
                    var temps = item.Split('#');
                    labellist.Add(temps[0]);
                    datalist.Add(temps[1]);
                }
                labels = string.Join(",", labellist);
                datas = string.Join(",", datalist);
            }
            else labels = datas = string.Empty;
        }

        /// <summary>
        /// 根据Picurl 解析出图新数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pic"></param>
        /// <param name="labels"></param>
        /// <param name="datas"></param>

        public void GetResultData(string url, out string pic, out string labels, out string datas, string SoftUrl)
        {
            if (url.EndsWith(".jpg") || url.EndsWith(".bmp"))
            {
                pic = SoftUrl + ChartUrl + url;
                labels = datas = string.Empty;
            }
            else if (url.EndsWith(".txt"))
            {
                pic = string.Empty;
                GetChartDataByTxt(HttpClientHelper.GetStr(SoftUrl + ChartUrl + url, Encoding.UTF8), out labels, out datas);

            }
            else
            {
                pic = string.Empty;
                GetChartData(url, out labels, out datas);
            }
        }

        /// <summary>
        /// 提取PicUrl 然后计算出Chart数据
        /// </summary>
        /// <param name="PicUrl"></param>
        /// <param name="n"></param>
        public void CalcaChartData(List<string> picUrls, int n, string softUrl)
        {
            string[] pic = new string[n];
            string[] txtLabel = new string[n];
            string[] txtData = new string[n];
            for (int i = 0; i < n; i++)
            {
                if (picUrls.Count > i)
                    if (picUrls[i] != null) GetResultData(picUrls[i], out pic[i], out txtLabel[i], out txtData[i], softUrl);
                    else pic[i] = txtLabel[i] = txtData[i] = string.Empty;
                else pic[i] = txtLabel[i] = txtData[i] = string.Empty;

            }
            ViewBag.pic = pic;
            ViewBag.txtLabel = txtLabel;
            ViewBag.txtData1 = txtData;
        }

        #endregion


        /// <summary>
        /// 根据syjid查询出TW_SYJZBDto的信息
        /// </summary>
        /// <returns></returns>
        private TW_SYJZBDto GetData(out string orgId, out string syjapi)
        {

            string syjid = Request.QueryString["syjid"];
            orgId = Request.QueryString["orgId"];
            syjapi = Request.QueryString["syjapi"];
            if (syjid != null && orgId != null)
            {
                if (syjid != SessionHelper.Get(KeyId))
                {
                    SessionHelper.Set(KeyId, syjid);
                    var model = HttpClientHelper.Get(syjapi + BHZAPIHelper.GetDyData + syjid + "/" + orgId);
                    TW_SYJZBDto obj =
                        JsonHelper.JsonToObject<TW_SYJZBDto>(JsonHelper.JsonToObject<OperateModel>(model).Data
                            .ToString());
                    SessionHelper.Set(KeyObj, obj);
                    return obj;
                }
                else return SessionHelper.Get(KeyObj) as TW_SYJZBDto;
            }
            return null;
        }
    }
}