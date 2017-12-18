/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
  * 命名空间：Dos.ORM.Web.App_Common.Other
 * 类名称：ValidateCode
 * 创建时间：2016-07-30 20:07:56
 * 创建人：Quber
 * 创建说明：验证码生成类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Dos.ORM.WebPC.App_Common.Other
{
    /// <summary>
    /// 验证码生成类
    /// </summary>
    public class ValidateCode
    {
        #region 属性
        #region 验证码长度
        int _length = 4;
        /// <summary>
        /// 验证码长度
        /// </summary>
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        #endregion

        #region 验证码字体大小(为了显示扭曲效果)
        int _fontSize = 22;
        /// <summary>
        /// 验证码字体大小
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
        #endregion

        #region 边框补
        int _padding = 1;
        /// <summary>
        /// 边框补
        /// </summary>
        public int Padding
        {
            get { return _padding; }
            set { _padding = value; }
        }
        #endregion

        #region 是否输出燥点
        bool _chaos = true;
        /// <summary>
        /// 是否输出燥点
        /// </summary>
        public bool Chaos
        {
            get { return _chaos; }
            set { _chaos = value; }
        }
        #endregion

        #region 输出燥点的颜色(默认灰色)
        Color _chaosColor = Color.White;
        /// <summary>
        /// 输出燥点的颜色
        /// </summary>
        public Color ChaosColor
        {
            get { return _chaosColor; }
            set { _chaosColor = value; }
        }
        #endregion

        #region 自定义背景色(默认白色)
        Color _backgroundColor = Color.White;
        /// <summary>
        /// 自定义背景色
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }
        #endregion

        #region 自定义随机颜色数组
        Color[] _colors = { 
            ColorTranslator.FromHtml("#016936"),
            ColorTranslator.FromHtml("#008080"),
            ColorTranslator.FromHtml("#0E6EB8"),
            ColorTranslator.FromHtml("#EE82EE"),

            //ColorTranslator.FromHtml("#1b926c"),
            //ColorTranslator.FromHtml("#B03060"),
            //ColorTranslator.FromHtml("#FE9A76"),
            //ColorTranslator.FromHtml("#FFD700"),
            //ColorTranslator.FromHtml("#32CD32"),
            //ColorTranslator.FromHtml("#016936"),
            //ColorTranslator.FromHtml("#008080"),
            //ColorTranslator.FromHtml("#EE82EE"),
            //ColorTranslator.FromHtml("#B413EC"),
            //ColorTranslator.FromHtml("#FF1493"),
            //ColorTranslator.FromHtml("#A52A2A"),
            //ColorTranslator.FromHtml("#A0A0A0"),
            //ColorTranslator.FromHtml("#000000"),

            //ColorTranslator.FromHtml("#006ac1"),
            //ColorTranslator.FromHtml("#691bb8"),
            //ColorTranslator.FromHtml("#252525"),
            //ColorTranslator.FromHtml("#f4b300"),
            //ColorTranslator.FromHtml("#1faeff"),
            //ColorTranslator.FromHtml("#78ba00"),
            //ColorTranslator.FromHtml("#1b58b8"),
            //ColorTranslator.FromHtml("#ae113d"),
            //ColorTranslator.FromHtml("#199900"),
            //ColorTranslator.FromHtml("#b01e00"),
            //ColorTranslator.FromHtml("#00c13f"),
            //ColorTranslator.FromHtml("#ff2e12"),
            //ColorTranslator.FromHtml("#4617b4"),
            //ColorTranslator.FromHtml("#aa40ff"),

            //ColorTranslator.FromHtml("#A4A4A4"),
            //ColorTranslator.FromHtml("#979797"),
            //ColorTranslator.FromHtml("#8A8A8A"),
            //ColorTranslator.FromHtml("#BEBEBE"),
            //ColorTranslator.FromHtml("#B1B1B1")
         };
        /// <summary>
        /// 自定义随机颜色数组
        /// </summary>
        public Color[] Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }
        #endregion

        #region 自定义字体数组
        string[] _fonts = { "Microsoft YaHei", "Arial", "Georgia" };
        /// <summary>
        /// 自定义字体数组
        /// </summary>
        public string[] Fonts
        {
            get { return _fonts; }
            set { _fonts = value; }
        }
        #endregion

        #region 自定义随机码字符串序列(使用逗号分隔)
        //string _codeSerial = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        string _codeSerial = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        /// <summary>
        /// 自定义随机码字符串序列
        /// </summary>
        public string CodeSerial
        {
            get { return _codeSerial; }
            set { _codeSerial = value; }
        }
        #endregion
        #endregion

        #region 构造

        #endregion

        #region 方法
        #region 创建验证码的图片
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public byte[] CreateValidateGraphic(string code)
        {
            var fSize = FontSize;
            var fWidth = fSize + Padding;
            var imageWidth = (int)(code.Length * fWidth) + 14 + Padding * 2;
            var imageHeight = fSize * 2 + Padding;

            var image = new Bitmap(imageWidth, imageHeight);
            var g = Graphics.FromImage(image);
            try
            {
                g.Clear(BackgroundColor);
                var rand = new Random();

                //给背景添加随机生成的燥点
                if (Chaos)
                {
                    var pen = new Pen(ChaosColor, 2);
                    var c = Length * 10;
                    for (var i = 0; i < c; i++)
                    {
                        var x = rand.Next(image.Width);
                        var y = rand.Next(image.Height);
                        g.DrawRectangle(pen, x, y, 1, 1);
                    }
                }

                var n1 = (imageHeight - FontSize - Padding * 2);
                var n2 = n1 / 4;
                int top1 = n2;
                int top2 = n2 * 2;

                //随机字体和颜色的验证码字符
                for (var i = 0; i < code.Length; i++)
                {
                    int cindex = rand.Next(Colors.Length - 1);
                    int findex = rand.Next(Fonts.Length - 1);
                    var f = new Font(Fonts[findex], fSize, FontStyle.Bold);
                    Brush b = new SolidBrush(Colors[cindex]);
                    int top = 0;
                    top = i % 2 == 1 ? top2 : top1;
                    int left = i * fWidth;
                    g.DrawString(code.Substring(i, 1), f, b, left, top);
                }
                //画一个边框 边框颜色为Color.Gainsboro
                //g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
                g.Dispose();
                //产生波形
                image = TwistImage(image, true, 0, 4);
                var ms = new MemoryStream();
                //将图像保存到指定的流
                image.Save(ms, ImageFormat.Jpeg);
                //输出图片流
                return ms.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion

        #region 产生波形滤镜效果
        private const double Pi = 3.1415926535897932384626433832795;
        private const double Pi2 = 6.283185307179586476925286766559;

        /// <summary>
        /// 正弦曲线Wave扭曲图片
        /// </summary>
        /// <param name="srcBmp">图片路径</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="dMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            var destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            var graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            var dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (var i = 0; i < destBmp.Width; i++)
            {
                for (var j = 0; j < destBmp.Height; j++)
                {
                    double dx = bXDir ? (Pi2 * (double)j) / dBaseAxisLen : (Pi2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    var dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    var color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }
        #endregion

        #region 生成随机字符码
        /// <summary>
        /// 生成随机字符码
        /// </summary>
        /// <param name="codeLen"></param>
        /// <returns></returns>
        public string CreateVerifyCode(int codeLen)
        {
            if (codeLen == 0)
            {
                codeLen = Length;
            }
            var arr = CodeSerial.Split(',');
            var code = "";
            var rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (var i = 0; i < codeLen; i++)
            {
                var randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }
            return code;
        }
        public string CreateVerifyCode()
        {
            return CreateVerifyCode(0);
        }
        #endregion
        #endregion
    }
}