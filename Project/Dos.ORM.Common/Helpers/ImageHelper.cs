/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Common.Helpers
 * 类名称：ImageHelper
 * 创建时间：2015-12-09 14:15:09
 * 创建人：Quber
 * 创建说明：图片帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 图片帮助类
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 将图片Image转换成Byte[]
        /// </summary>
        /// <param name="img">Image对象</param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image img)
        {
            var imageFormat = ImageFormat.Bmp;
            if (img == null) { return null; }

            byte[] data;

            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(img))
                {
                    bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    data = new byte[ms.Length];
                    ms.Read(data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }
            return data;
        }

        /// <summary>
        /// byte[]转换成Image
        /// </summary>
        /// <param name="bytes">二进制图片流</param>
        /// <returns>Image</returns>
        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null) return null;

            using (var ms = new MemoryStream(bytes))
            {
                Image returnImage = Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }

        #region 原始
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void CutImage(string originalImagePath, string thumbnailPath, int width, int height, string mode = "Cut")
        {
            var strPicPath = originalImagePath;
            var uImage = Image.FromFile(strPicPath);
            var iWidth = uImage.Width < width ? uImage.Width : width;
            var iHeight = uImage.Height < height ? uImage.Height : height;
            uImage.Dispose();

            width = iWidth;
            height = iHeight;

            var originalImage = Image.FromFile(originalImagePath);

            var towidth = width;
            var toheight = height;

            var x = 0;
            var y = 0;
            var ow = originalImage.Width;
            var oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高按比例
                    if (originalImage.Width < width)
                    {
                        towidth = originalImage.Width;
                        toheight = originalImage.Height;
                    }
                    else
                    {
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    break;
                case "H"://指定高，宽按比例
                    if (originalImage.Height < height)
                    {
                        toheight = originalImage.Height;
                        towidth = originalImage.Width;
                    }
                    else
                    {
                        towidth = originalImage.Width * height / originalImage.Height;
                    }
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);

            //新建一个画板
            var g = Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                var path = thumbnailPath.Substring(0, thumbnailPath.LastIndexOf('\\'));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 裁剪图片
        /// </summary>
        /// <param name="bitmap">原始Bitmap</param>
        /// <param name="startX">开始坐标X</param>
        /// <param name="startY">开始坐标Y</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>剪裁后的Bitmap</returns>
        public static Bitmap CropImage(Bitmap bitmap, int startX, int startY, int width, int height)
        {
            if (bitmap == null) { return null; }

            var w = bitmap.Width;
            var h = bitmap.Height;

            if (startX >= w || startY >= h) { return null; }

            width = startX + width > w ? w - startX : width;
            height = startY + height > h ? h - startY : height;

            try
            {
                var bmpOut = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                var g = Graphics.FromImage(bmpOut);
                g.DrawImage(bitmap, new Rectangle(0, 0, width, height), new Rectangle(startX, startY, width, height), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region New
        /// <summary>
        /// 按比例存放缩略图片
        /// </summary>
        /// <param name="sourceFile">原图地址</param>
        /// <param name="saveFile">保存地址</param>
        /// <param name="width">宽度</param>
        public static void GetThumbnail(string sourceFile, string saveFile, int width)
        {
            var iSource = Image.FromFile(sourceFile);
            var height = width * iSource.Height / iSource.Width;
            var samllimg = iSource.GetThumbnailImage(width, height, null, IntPtr.Zero);
            samllimg.Save(saveFile);
        }

        /// <summary>
        /// 存放缩略图
        /// </summary>
        /// <param name="sourceFile">原图地址</param>
        /// <param name="saveFile">保存地址</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static void GetThumbnail(string sourceFile, string saveFile, int width, int height)
        {
            var iSource = Image.FromFile(sourceFile);
            var samllimg = iSource.GetThumbnailImage(width, height, null, IntPtr.Zero);
            samllimg.Save(saveFile);
        }

        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sourceFile">原图片</param>
        /// <param name="saveFile">压缩后保存位置</param>
        /// <param name="width"></param>
        /// <param name="height">高度</param>
        /// <param name="flag">压缩质量（1-100）</param>
        /// <returns></returns>
        public static bool GetPicThumbnail(string sourceFile, string saveFile, int width, int height, int flag)
        {
            var iSource = Image.FromFile(sourceFile);
            var tFormat = iSource.RawFormat;
            int sW, sH;

            //按比例缩放
            var temSize = new Size(iSource.Width, iSource.Height);

            if (temSize.Width > height || temSize.Width > width) //将**改成c#中的或者操作符号
            {
                if ((temSize.Width * height) > (temSize.Height * width))
                {
                    sW = width;
                    sH = (width * temSize.Height) / temSize.Width;
                }
                else
                {
                    sH = height;
                    sW = (temSize.Width * height) / temSize.Height;
                }
            }
            else
            {
                sW = temSize.Width;
                sH = temSize.Height;
            }
            var ob = new Bitmap(width, height);
            var g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((width - sW) / 2, (height - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //以下代码为保存图片时，设置压缩质量
            var ep = new EncoderParameters();
            var qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            var eParam = new EncoderParameter(Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                var arrayIci = ImageCodecInfo.GetImageEncoders();
                var jpegIcIinfo = arrayIci.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));
                if (jpegIcIinfo != null)
                {
                    ob.Save(saveFile, jpegIcIinfo, ep);
                }
                else
                {
                    ob.Save(saveFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }

        /// <summary>   
        /// 在图片上添加水印文字   
        /// </summary>   
        /// <param name="sourceFile">源图片文件</param>   
        /// <param name="waterWords">需要添加到图片上的文字</param>   
        /// <param name="alpha">透明度</param>   
        /// <param name="position">位置</param>   
        /// <param name="saveFile">文件路径</param>   
        /// <returns></returns>   
        public static string DrawWords(string sourceFile, string waterWords, float alpha, ImagePosition position, string saveFile)
        {
            // 判断参数是否有效   
            if (sourceFile == string.Empty || waterWords == string.Empty || Math.Abs(alpha * 10) - 1 < 0 || saveFile == string.Empty)
            {
                return sourceFile;
            }
            //创建一个图片对象用来装载要被添加水印的图片   
            Image imgPhoto = Image.FromFile(sourceFile);

            //获取图片的宽和高   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;

            //建立一个bitmap，和我们需要加水印的图片一样大小   
            var bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

            //SetResolution：设置此 Bitmap 的分辨率   
            //这里直接将我们需要添加水印的图片的分辨率赋给了bitmap   
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            //Graphics：封装一个 GDI+ 绘图图面。   
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            //设置图形的品质   
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

            //将我们要添加水印的图片按照原始大小描绘（复制）到图形中   
            grPhoto.DrawImage(
             imgPhoto,                                           //   要添加水印的图片   
             new Rectangle(0, 0, phWidth, phHeight), //  根据要添加的水印图片的宽和高   
             0,                                                     //  X方向从0点开始描绘   
             0,                                                     // Y方向    
             phWidth,                                            //  X方向描绘长度   
             phHeight,                                           //  Y方向描绘长度   
             GraphicsUnit.Pixel);                              // 描绘的单位，这里用的是像素   

            //根据图片的大小我们来确定添加上去的文字的大小   
            //在这里我们定义一个数组来确定   
            var sizes = new[] { 16, 14, 12, 10, 8, 6, 4 };

            //字体   
            Font crFont = null;
            //矩形的宽度和高度，SizeF有三个属性，分别为Height高，width宽，IsEmpty是否为空   
            var crSize = new SizeF();

            //利用一个循环语句来选择我们要添加文字的型号   
            //直到它的长度比图片的宽度小   
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("arial", sizes[i], FontStyle.Bold);

                //测量用指定的 Font 对象绘制并用指定的 StringFormat 对象格式化的指定字符串。   
                crSize = grPhoto.MeasureString(waterWords, crFont);

                // ushort 关键字表示一种整数数据类型   
                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }

            //截边5%的距离，定义文字显示(由于不同的图片显示的高和宽不同，所以按百分比截取)   

            //定义在图片上文字的位置   
            float wmHeight = crSize.Height;
            float wmWidth = crSize.Width;

            float xPosOfWm;
            float yPosOfWm;

            switch (position)
            {
                case ImagePosition.BottomMiddle:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.Center:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = phHeight / 2;
                    break;
                case ImagePosition.LeftBottom:
                    xPosOfWm = wmWidth;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.LeftTop:
                    xPosOfWm = wmWidth / 2;
                    yPosOfWm = wmHeight / 2;
                    break;
                case ImagePosition.RightTop:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = wmHeight;
                    break;
                case ImagePosition.RigthBottom:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.TopMiddle:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = wmWidth;
                    break;
                default:
                    xPosOfWm = wmWidth;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }

            //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。   
            var strFormat = new StringFormat { Alignment = StringAlignment.Center };

            //定义需要印的文字居中对齐   

            //SolidBrush:定义单色画笔。画笔用于填充图形形状，如矩形、椭圆、扇形、多边形和封闭路径。   
            //这个画笔为描绘阴影的画笔，呈灰色   
            var mAlpha = Convert.ToInt32(256 * alpha);
            var semiTransBrush2 = new SolidBrush(Color.FromArgb(mAlpha, 0, 0, 0));

            //描绘文字信息，这个图层向右和向下偏移一个像素，表示阴影效果   
            //DrawString 在指定矩形并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。   
            grPhoto.DrawString(waterWords,                                    //string of text   
                                       crFont,                                         //font   
                                       semiTransBrush2,                            //Brush   
                                       new PointF(xPosOfWm + 1, yPosOfWm + 1),  //Position   
                                       strFormat);

            //从四个 ARGB 分量（alpha、红色、绿色和蓝色）值创建 Color 结构，这里设置透明度为153   
            //这个画笔为描绘正式文字的笔刷，呈白色   
            var semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            //第二次绘制这个图形，建立在第一次描绘的基础上   
            grPhoto.DrawString(waterWords,                 //string of text   
                                       crFont,                                   //font   
                                       semiTransBrush,                           //Brush   
                                       new PointF(xPosOfWm, yPosOfWm),  //Position   
                                       strFormat);

            //imgPhoto是我们建立的用来装载最终图形的Image对象   
            //bmPhoto是我们用来制作图形的容器，为Bitmap对象   
            imgPhoto = bmPhoto;
            //释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满   
            grPhoto.Dispose();

            //将grPhoto保存   
            imgPhoto.Save(saveFile, ImageFormat.Jpeg);
            imgPhoto.Dispose();

            return saveFile;
        }

        /// <summary>   
        /// 添加图片水印   
        /// </summary>   
        /// <param name="sourceFile">源图片文件名</param>   
        /// <param name="waterImage">水印图片文件名</param>   
        /// <param name="alpha">透明度(0.1-1.0数值越小透明度越高)</param>   
        /// <param name="position">位置</param>   
        /// <param name="saveFile" >图片的路径</param>   
        /// <returns>返回生成于指定文件夹下的水印文件名</returns>   
        public static string DrawImage(string sourceFile, string waterImage, float alpha, ImagePosition position, string saveFile)
        {
            if (sourceFile == string.Empty || waterImage == string.Empty || Math.Abs(alpha * 10) - 1 < 0 || saveFile == string.Empty)
            {
                return sourceFile;
            }
            var imgPhoto = Image.FromFile(sourceFile);

            // 确定其长宽   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;
            // 封装 GDI+ 位图，此位图由图形图像及其属性的像素数据组成。   
            var bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            // 设定分辨率   
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            // 定义一个绘图画面用来装载位图   
            var grPhoto = Graphics.FromImage(bmPhoto);

            //同样，由于水印是图片，我们也需要定义一个Image来装载它   
            Image imgWatermark = new Bitmap(waterImage);
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;

            //SmoothingMode：指定是否将平滑处理（消除锯齿）应用于直线、曲线和已填充区域的边缘。   
            // 成员名称   说明    
            // AntiAlias      指定消除锯齿的呈现。     
            // Default        指定不消除锯齿。     
            // HighQuality  指定高质量、低速度呈现。     
            // HighSpeed   指定高速度、低质量呈现。     
            // Invalid        指定一个无效模式。     
            // None          指定不消除锯齿。    
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            // 第一次描绘，将我们的底图描绘在绘图画面上   
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, GraphicsUnit.Pixel);

            var bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            // 继续，将水印图片装载到一个绘图画面grWatermark   
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            //ImageAttributes 对象包含有关在呈现时如何操作位图和图元文件颜色的信息。   
            var imageAttributes = new ImageAttributes();

            //Colormap: 定义转换颜色的映射   
            var colorMap = new ColorMap
            {
                OldColor = Color.FromArgb(255, 0, 255, 0),
                NewColor = Color.FromArgb(0, 0, 0, 0)
            };

            //我的水印图被定义成拥有绿色背景色的图片被替换成透明   
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {    
           new[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f}, // red红色   
           new[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f}, //green绿色   
           new[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f}, //blue蓝色          
           new[] {0.0f,  0.0f,  0.0f,  alpha, 0.0f}, //透明度        
           new[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};//   

            //  ColorMatrix:定义包含 RGBA 空间坐标的 5 x 5 矩阵。   
            //  ImageAttributes 类的若干方法通过使用颜色矩阵调整图像颜色。   
            var wmColorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default,
             ColorAdjustType.Bitmap);

            //上面设置完颜色，下面开始设置位置   
            int xPosOfWm;
            int yPosOfWm;
            switch (position)
            {
                case ImagePosition.BottomMiddle:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.Center:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case ImagePosition.LeftBottom:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.LeftTop:
                    xPosOfWm = 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.RightTop:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.RigthBottom:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.TopMiddle:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = 10;
                    break;
                default:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }
            grWatermark.DrawImage(imgWatermark, new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight), 0, 0, wmWidth, wmHeight, GraphicsUnit.Pixel, imageAttributes);
            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();

            // 保存文件到服务器的文件夹里面   
            imgPhoto.Save(saveFile, ImageFormat.Jpeg);
            imgPhoto.Dispose();
            imgWatermark.Dispose();
            return saveFile;
        }
        #endregion
    }

    /// <summary>
    /// 图片位置
    /// </summary>
    public enum ImagePosition
    {
        LeftTop,             //左上
        LeftBottom,       //左下
        RightTop,          //右上
        RigthBottom,    //右下
        TopMiddle,       //顶部居中
        BottomMiddle, //底部居中
        Center             //中心
    }
}
