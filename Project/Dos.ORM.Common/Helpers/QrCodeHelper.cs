/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：QrCodeHelper
 * 创建时间：2016-11-10 10:52:07
 * 创建人：Quber
 * 创建说明：二维码、条形码帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 二维码、条形码帮助类
    /// </summary>
    public static class QrCodeHelper
    {
        #region 返回Bitmap对象
        /*
         * 调用方法：
         * 
         * 控制器中：
            public ActionResult ValidateCode()
            {
                var bmpBytes = ImageHelper.ImageToBytes(QrCodeHelper.QrCodeBitmap("我是测试的内容"));
                return File(bmpBytes, @"image/jpeg");
            }
         * 
         * 视图中：
            <img src="@Url.Action("ValidateCode", "Login")?valiId=@DateTime.Now.Ticks" />
         * 
         */

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度，默认为150px</param>
        /// <param name="height">高度，默认为150px</param>
        /// <param name="margin">边距，默认为0</param>
        public static Bitmap QrCodeBitmap(string text, int width = 150, int height = 150, int margin = 0)
        {
            width = width > 150 ? width : 150;
            height = height > 150 ? height : 150;

            var writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                //设置内容编码
                CharacterSet = "UTF-8",
                //设置二维码的宽度和高度
                Width = width,
                Height = height,
                //设置二维码的边距,单位不是固定像素
                Margin = margin
            };
            writer.Options = options;

            Bitmap map = writer.Write(text);
            //map.Save(filePath, ImageFormat.Png);
            //map.Dispose();
            return map;
        }
        #endregion

        #region 保存为图片
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="filePath">保存的相对路径（如：../Content/Upload/）</param>
        /// <param name="width">宽度，默认为150px</param>
        /// <param name="height">高度，默认为150px</param>
        /// <param name="margin">边距，默认为0</param>
        public static void QrCode(string text, string filePath, int width = 150, int height = 150, int margin = 0)
        {
            //创建文件夹
            FileHelper.CreateDir(filePath);

            var fileName = StringHelper.GetRandomStr(10) + ".png";
            filePath = HttpContext.Current.Server.MapPath(filePath + fileName);

            width = width > 150 ? width : 150;
            height = height > 150 ? height : 150;

            var writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                //设置内容编码
                CharacterSet = "UTF-8",
                //设置二维码的宽度和高度
                Width = width,
                Height = height,
                //设置二维码的边距,单位不是固定像素
                Margin = margin
            };
            writer.Options = options;

            Bitmap map = writer.Write(text);
            map.Save(filePath, ImageFormat.Png);
            map.Dispose();
        }

        /// <summary>
        /// 生成二维码（带logo）
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="filePath">保存的相对路径（如：../Content/Upload/）</param>
        /// <param name="logoPath">logo图片相对路径（如：../Content/Images/logo.png）</param>
        /// <param name="width">宽度，默认为150px</param>
        /// <param name="height">高度，默认为150px</param>
        /// <param name="margin">边距，默认为0</param>
        public static void QrCode(string text, string filePath, string logoPath, int width = 150, int height = 150, int margin = 0)
        {
            //创建文件夹
            FileHelper.CreateDir(filePath);

            var fileName = StringHelper.GetRandomStr(10) + ".png";
            filePath = HttpContext.Current.Server.MapPath(filePath + fileName);
            logoPath = HttpContext.Current.Server.MapPath(logoPath);

            width = width > 150 ? width : 150;
            height = height > 150 ? height : 150;

            //Logo图片
            var logo = new Bitmap(logoPath);

            //构造二维码写码器
            var writer = new MultiFormatWriter();
            var hint = new Dictionary<EncodeHintType, object>
            {
                {EncodeHintType.CHARACTER_SET, "UTF-8"},
                {EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H},
                {EncodeHintType.MARGIN, margin}
            };

            //生成二维码 
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width, height, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            //将img转换成bmp格式，否则后面无法创建Graphics对象
            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }

            //将二维码插入图片
            Graphics myGraphic = Graphics.FromImage(bmpimg);

            //白底
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);

            //保存成图片
            bmpimg.Save(filePath, ImageFormat.Png);
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="filePath">保存的相对路径（如：../Content/Upload/）</param>
        /// <param name="width">宽度，默认为150px</param>
        /// <param name="height">高度，默认为150px</param>
        /// <param name="margin">边距，默认为0</param>
        public static void BarCode(string text, string filePath, int width = 150, int height = 50, int margin = 0)
        {
            //创建文件夹
            FileHelper.CreateDir(filePath);

            var fileName = StringHelper.GetRandomStr(10) + ".png";
            filePath = HttpContext.Current.Server.MapPath(filePath + fileName);

            width = width > 150 ? width : 150;
            height = height > 50 ? height : 50;

            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            var writer = new BarcodeWriter { Format = BarcodeFormat.CODE_128 };
            var options = new EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = margin
            };
            writer.Options = options;

            Bitmap map = writer.Write(text);
            map.Save(filePath, ImageFormat.Png);
        }
        #endregion

        #region 读取内容
        /// <summary>
        /// 读取二维码或条形码的内容
        /// </summary>
        /// <param name="filePath">二维码或条形码的相对路径</param>
        /// <returns></returns>
        public static string ReadCode(string filePath)
        {
            filePath = HttpContext.Current.Server.MapPath(filePath);

            var reader = new BarcodeReader { Options = { CharacterSet = "UTF-8" } };
            var map = new Bitmap(filePath);
            Result result = reader.Decode(map);

            return result == null ? "" : result.Text;
        }
        #endregion
    }
}
