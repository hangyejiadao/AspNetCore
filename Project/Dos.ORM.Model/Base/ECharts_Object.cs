using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dos.ORM.Model.Base
{
    
    public class Echart_Model
    {

        public Boolean Result
        {
            get;
            set;
        }

        public String Text
        {
            get;
            set;
        }

        public String SubText
        {
            get;
            set;
        }

        public String Message
        {
            get;
            set;
        }

        public Object ECharts
        {
            get;
            set;
        }

    }

    //标题组件，包含主标题和副标题。
    
    public class Echarts_Title
    {
        public Echarts_Title()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        public String text
        {
            get;
            set;
        }

        //private String _x = "center";
        //public String x
        //{
        //    get { return _x; }
        //    set {  _x=value; }
        //}

        public String link
        {
            get;
            set;
        }

        private String _target = "blank";
        public String target
        {
            get { return _target; }
            set { _target = value; }
        }

        //标题文本水平对齐，支持 'left', 'center', 'right'，默认根据标题位置决定。
        public String textAlign
        {
            get;
            set;
        }

        //标题文本垂直对齐，支持 'top', 'middle', 'bottom'，默认根据标题位置决定。
        public String textBaseline
        {
            get;
            set;
        }

        public String subtext
        {
            get;
            set;
        }

        public String sublink
        {
            get;
            set;
        }

        private String _subtarget = "blank";
        public String subtarget
        {
            get { return _subtarget; }
            set { _subtarget = value; }
        }

        private Int32[] _padding = { 5, 5, 5, 5 };
        public Int32[] padding
        {
            get { return _padding; }
            set { _padding = value; }
        }

        private Int32 _itemGap = 10;
        public Int32 itemGap
        {
            get { return _itemGap; }
            set { _itemGap = value; }
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }

        private object _left = "auto";
        public object left
        {
            get { return _left; }
            set { _left = value; }
        }

        private object _top = "auto";
        public object top
        {
            get { return _top; }
            set { _top = value; }
        }

        private object _right = "auto";
        public object right
        {
            get { return _right; }
            set { _right = value; }
        }

        private object _bottom = "auto";
        public object bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        private String _backgroundColor = "transparent";
        public String backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private String _borderColor = "#ccc";
        public String borderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

    }

    //图例组件。
    
    public class Echarts_Legend
    {
        public Echarts_Legend()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }

        private object _left = "auto";
        public object left
        {
            get { return _left; }
            set { _left = value; }
        }

        private object _top = "auto";
        public object top
        {
            get { return _top; }
            set { _top = value; }
        }

        private object _right = "auto";
        public object right
        {
            get { return _right; }
            set { _right = value; }
        }

        private object _bottom = "auto";
        public object bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        private object _width = "auto";
        public object width
        {
            get { return _width; }
            set { _width = value; }
        }

        private object _heigth = "auto";
        public object heigth
        {
            get { return _heigth; }
            set { _heigth = value; }
        }

        private String _orient = "horizontal";
        public String orient
        {
            get { return _orient; }
            set { _orient = value; }
        }

        private String _align = "auto";
        public String align
        {
            get { return _align; }
            set { _align = value; }
        }

        private Int32[] _padding = { 5, 5, 5, 5 };
        public Int32[] padding
        {
            get { return _padding; }
            set { _padding = value; }
        }

        private Int32 _itemGap = 10;
        public Int32 itemGap
        {
            get { return _itemGap; }
            set { _itemGap = value; }
        }

        private Int32 _itemWidth = 25;
        public Int32 itemWidth
        {
            get { return _itemWidth; }
            set { _itemWidth = value; }
        }

        private Int32 _itemHeight = 14;
        public Int32 itemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; }
        }

        public String formatter
        {
            get;
            set;
        }

        private object _selectedMode = true;
        public object selectedMode
        {
            get { return _selectedMode; }
            set { _selectedMode = value; }
        }

        public List<String> data
        {
            get;
            set;
        }

    }

    //直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
    
    public class Echarts_Grid
    {
        public Echarts_Grid()
        {

        }

        public Boolean show
        {
            get;
            set;
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }

        private object _left = "auto";
        public object left
        {
            get { return _left; }
            set { _left = value; }
        }

        private object _top = "auto";
        public object top
        {
            get { return _top; }
            set { _top = value; }
        }

        private object _right = "auto";
        public object right
        {
            get { return _right; }
            set { _right = value; }
        }

        private object _bottom = "auto";
        public object bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        private object _width = "auto";
        public object width
        {
            get { return _width; }
            set { _width = value; }
        }

        private object _heigth = "auto";
        public object heigth
        {
            get { return _heigth; }
            set { _heigth = value; }
        }

        public Boolean containLabel
        {
            get;
            set;
        }

        private String _backgroundColor = "transparent";
        public String backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private String _borderColor = "#ccc";
        public String borderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private Int32 _borderWidth = 1;
        public Int32 borderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }

    }

    //直角坐标系 grid 中的 x 轴，单个 grid 组件最多只能放上下两个 x 轴。
    
    public class Echarts_xAxis
    {
        public Echarts_xAxis()
        {

        }

        public Int32 gridIndex
        {
            get;
            set;
        }

        public String position
        {
            get;
            set;
        }

        public Int32 offset
        {
            get;
            set;
        }

        private String _type = "category";
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String name
        {
            get;
            set;
        }

        private String _nameLocation = "end";
        public String nameLocation
        {
            get { return _nameLocation; }
            set { _nameLocation = value; }
        }

        private Int32 _nameGap = 15;
        public Int32 nameGap
        {
            get { return _nameGap; }
            set { _nameGap = value; }
        }

        private Boolean _boundaryGap = true;
        public Boolean boundaryGap
        {
            get { return _boundaryGap; }
            set { _boundaryGap = value; }
        }

        private object _min = "auto";
        public object min
        {
            get { return _min; }
            set { _min = value; }
        }

        private object _max = "auto";
        public object max
        {
            get { return _max; }
            set { _max = value; }
        }

        public Echarts_Axis_AxisLabel axisLabel
        {
            get;
            set;
        }

        public List<Echarts_Axis_Data> data
        {
            get;
            set;
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        public Int32 z
        {
            get;
            set;
        }
    }

    //直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
    
    public class Echarts_yAxis
    {
        public Echarts_yAxis()
        {

        }

        public Int32 gridIndex
        {
            get;
            set;
        }

        public String position
        {
            get;
            set;
        }

        public Int32 offset
        {
            get;
            set;
        }

        private String _type = "value";
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String name
        {
            get;
            set;
        }

        private String _nameLocation = "end";
        public String nameLocation
        {
            get { return _nameLocation; }
            set { _nameLocation = value; }
        }

        private Int32 _nameGap = 15;
        public Int32 nameGap
        {
            get { return _nameGap; }
            set { _nameGap = value; }
        }

        //private object _min = "auto";
        //public object min
        //{
        //    get { return _min; }
        //    set { _min = value; }
        //}

        //private object _max = "auto";
        //public object max
        //{
        //    get { return _max; }
        //    set { _max = value; }
        //}


        public Int32 interval
        {
            get;
            set;
        }

        public Echarts_Axis_AxisLabel axisLabel
        {
            get;
            set;
        }

        public List<Echarts_Axis_Data> data
        {
            get;
            set;
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        public Int32 z
        {
            get;
            set;
        }

    }

    
    public class Echarts_Axis_AxisLabel
    {

        public Echarts_Axis_AxisLabel()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        public Int32 interval
        {
            get;
            set;
        }

        public Boolean inside
        {
            get;
            set;
        }

        public Int32 rotate
        {
            get;
            set;
        }

        private Int32 _margin = 8;
        public Int32 margin
        {
            get { return _margin; }
            set { _margin = value; }
        }

        public String formatter
        {
            get;
            set;
        }

    }

    //类目数据，在类目轴（type: 'category'）中有效。
    
    public class Echarts_Axis_Data
    {
        public Echarts_Axis_Data()
        {

        }

        public String value
        {
            get;
            set;
        }

        public Echarts_Axis_Data_TextStyle textStyle
        {
            get;
            set;
        }

    }

    //类目标签的文字样式。
    
    public class Echarts_Axis_Data_TextStyle
    {
        public Echarts_Axis_Data_TextStyle()
        {

        }

        private String _color = "#fff";
        public String color
        {
            get { return _color; }
            set { _color = value; }
        }

        public String align
        {
            get;
            set;
        }

        public String baseline
        {
            get;
            set;
        }

        private String _fontStyle = "normal";
        public String fontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }

        private String _fontWeight = "normal";
        public String fontWeight
        {
            get { return _fontWeight; }
            set { _fontWeight = value; }
        }

        private String _fontFamily = "sans-serif";
        public String fontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        private Int32 _fontSize = 12;
        public Int32 fontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

    }

    //提示框组件。
    
    public class ECharts_Tooltip
    {
        public ECharts_Tooltip()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private Boolean _showContent = true;
        public Boolean showContent
        {
            get { return _showContent; }
            set { _showContent = value; }
        }

        private String _trigger = "item";
        public String trigger
        {
            get { return _trigger; }
            set { _trigger = value; }
        }

        private String _triggerOn = "mousemove";
        public String triggerOn
        {
            get { return _triggerOn; }
            set { _triggerOn = value; }
        }

        public Int32 showDelay
        {
            get;
            set;
        }

        private Int32 _hideDelay = 100;
        public Int32 hideDelay
        {
            get { return _hideDelay; }
            set { _hideDelay = value; }
        }

        public Boolean enterable
        {
            get;
            set;
        }

        public String formatter
        {
            get;
            set;
        }

        private String _backgroundColor = "rgba(50,50,50,0.7)";
        public String backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private String _borderColor = "#333";
        public String borderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        public Int32 borderWidth
        {
            get;
            set;
        }

        private Int32[] _padding = { 5, 5, 5, 5 };
        public Int32[] padding
        {
            get { return _padding; }
            set { _padding = value; }
        }

        public ECharts_Tooltip_TextStyle textStyle
        {
            get;
            set;
        }

        public ECharts_Tooltip_AxisPointer axisPointer
        {
            get;
            set;
        }

    }

    
    public class ECharts_Tooltip_TextStyle
    {
        public ECharts_Tooltip_TextStyle()
        {

        }

        private String _color = "#fff";
        public String color
        {
            get { return _color; }
            set { _color = value; }
        }

        private String _fontStyle = "normal";
        public String fontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }

        private String _fontWeight = "normal";
        public String fontWeight
        {
            get { return _fontWeight; }
            set { _fontWeight = value; }
        }

        private String _fontFamily = "sans-serif";
        public String fontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        private Int32 _fontSize = 14;
        public Int32 fontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

    }

    
    public class ECharts_Tooltip_AxisPointer
    {
        public ECharts_Tooltip_AxisPointer()
        {

        }

        private String _type = "line";
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        private String _axis = "auto";
        public String axis
        {
            get { return _axis; }
            set { _axis = value; }
        }

    }


    //工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
    
    public class ECharts_Toolbox
    {
        public ECharts_Toolbox()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _orient = "horizontal";
        public String orient
        {
            get { return _orient; }
            set { _orient = value; }
        }

        private Int32 _itemSize = 15;
        public Int32 itemSize
        {
            get { return _itemSize; }
            set { _itemSize = value; }
        }

        private Int32 _itemGap = 10;
        public Int32 itemGap
        {
            get { return _itemGap; }
            set { _itemGap = value; }
        }

        private Boolean _showTitle = true;
        public Boolean showTitle
        {
            get { return _showTitle; }
            set { _showTitle = value; }
        }

        public ECharts_Toolbox_Feature feature
        {
            get;
            set;
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }

        private object _left = "auto";
        public object left
        {
            get { return _left; }
            set { _left = value; }
        }

        private object _top = "auto";
        public object top
        {
            get { return _top; }
            set { _top = value; }
        }

        private object _right = "auto";
        public object right
        {
            get { return _right; }
            set { _right = value; }
        }

        private object _bottom = "auto";
        public object bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        private object _width = "auto";
        public object width
        {
            get { return _width; }
            set { _width = value; }
        }

        private object _heigth = "auto";
        public object heigth
        {
            get { return _heigth; }
            set { _heigth = value; }
        }
    }

    //各工具配置项。
    
    public class ECharts_Toolbox_Feature
    {
        public ECharts_Toolbox_Feature()
        {

        }

        public ECharts_Toolbox_Feature_SaveAsImage saveAsImage
        {
            get;
            set;
        }

        public ECharts_Toolbox_Feature_Restore restore
        {
            get;
            set;
        }

        public ECharts_Toolbox_Feature_DataView dataView
        {
            get;
            set;
        }

        public ECharts_Toolbox_Feature_MagicType magicType
        {
            get;
            set;
        }
    }

    public class ECharts_Toolbox_Feature_SaveAsImage
    {
        public ECharts_Toolbox_Feature_SaveAsImage()
        {

        }

        private String _type = "png";
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String name
        {
            get;
            set;
        }

        private String _backgroundColor = "auto";
        public String backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _title = "保存为图片";
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        private Int32 _pixelRatio = 1;
        public Int32 pixelRatio
        {
            get { return _pixelRatio; }
            set { _pixelRatio = value; }
        }
    }

    public class ECharts_Toolbox_Feature_Restore
    {
        public ECharts_Toolbox_Feature_Restore()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _title = "还原";
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

    }

    public class ECharts_Toolbox_Feature_DataView
    {
        public ECharts_Toolbox_Feature_DataView()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _title = "数据视图";
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Boolean readOnly
        {
            get;
            set;
        }
    }

    public class ECharts_Toolbox_Feature_MagicType
    {
        public ECharts_Toolbox_Feature_MagicType()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private Array _title = new object[] { "line", "bar" };
        public Array title
        {
            get { return _title; }
            set { _title = value; }
        }

    }

    //除了各个内置的工具按钮外，还可以自定义工具按钮。
    
    public class ECharts_Toolbox_Feature_MyTool
    {
        public ECharts_Toolbox_Feature_MyTool()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        public String title
        {
            get;
            set;
        }

        public String icon
        {
            get;
            set;
        }

        public String onclick
        {
            get;
            set;
        }

    }

    //系列列表
    
    public class Echarts_Series
    {

        public Echarts_Series()
        {

        }

        public String type
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public Int32 xAxisIndex
        {
            get;
            set;
        }

        public Int32 yAxisIndex
        {
            get;
            set;
        }

        public String stack
        {
            get;
            set;
        }

        //图形上的文本标签
        public Echarts_Series_Label label
        {
            get;
            set;
        }

        public Boolean smooth
        {
            get;
            set;
        }

        //柱条的宽度，不设时自适应。支持设置成相对于类目宽度的百分比。
        private object _barWidth = "auto";
        public object barWidth
        {
            get { return _barWidth; }
            set { _barWidth = value; }
        }

        private object _barMaxWidth = "auto";
        public object barMaxWidth
        {
            get { return _barMaxWidth; }
            set { _barMaxWidth = value; }
        }

        //柱间距离，默认为柱形宽度的30%，可设固定值
        private String _barGap = "30%";
        public String barGap
        {
            get { return _barGap; }
            set { _barGap = value; }
        }

        //类目间柱形距离，默认为类目间距的20%，可设固定值
        private String _barCategoryGap = "20%";
        public String barCategoryGap
        {
            get { return _barCategoryGap; }
            set { _barCategoryGap = value; }
        }

        private Array _radius = new object[] { 0, "75%" };
        public Array radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        private Array _center = new object[] { "50%", "50%" };
        public Array center
        {
            get { return _center; }
            set { _center = value; }
        }

        public List<Echarts_Series_Data> data
        {
            get;
            set;
        }

        //图表标线。
        public Echarts_Series_MarkLine markLine
        {
            get;
            set;
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }
    }

    
    public class Echarts_Series_Data
    {

        public String name
        {
            get;
            set;
        }

        public Double value
        {
            get;
            set;
        }

    }

    //系列列表_图形上的文本标签
    
    public class Echarts_Series_Label
    {

        public Echarts_Series_Label()
        {

        }

        public Echarts_Series_Label_Normal normal
        {
            get;
            set;
        }
    }

    
    public class Echarts_Series_Label_Normal
    {

        public Echarts_Series_Label_Normal()
        {

        }

        public Boolean show
        {
            get;
            set;
        }

        private String _position = "inside";
        public String position
        {
            get { return _position; }
            set { _position = value; }
        }

        public String formatter
        {
            get;
            set;
        }
    }

    
    public class Echarts_Series_MarkLine
    {

        public Echarts_Series_MarkLine()
        {

        }

        public Echarts_Series_MarkLine_Label label
        {
            get;
            set;
        }

        public List<Echarts_Series_MarkLine_Data> data
        {
            get;
            set;
        }
    }

    
    public class Echarts_Series_MarkLine_Label
    {

        public Echarts_Series_MarkLine_Label()
        {

        }

        public Echarts_Series_MarkLine_Label_Normal normal
        {
            get;
            set;
        }
    }

    
    public class Echarts_Series_MarkLine_Label_Normal
    {

        public Echarts_Series_MarkLine_Label_Normal()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _position = "inside";
        public String position
        {
            get { return _position; }
            set { _position = value; }
        }

        public String formatter
        {
            get;
            set;
        }
    }

    
    public class Echarts_Series_MarkLine_Data
    {
        public Echarts_Series_MarkLine_Data()
        {

        }

        public String type
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

    }


    //timeline 组件，提供了在多个 ECharts option 间进行切换、播放等操作的功能
    
    public class Echarts_Timeline
    {
        public Echarts_Timeline()
        {

        }

        private Boolean _show = true;
        public Boolean show
        {
            get { return _show; }
            set { _show = value; }
        }

        private String _type = "slider";
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        private String _axisType = "time";
        public String axisType
        {
            get { return _axisType; }
            set { _axisType = value; }
        }

        public Int32 currentIndex
        {
            get;
            set;
        }

        public Boolean autoPlay
        {
            get;
            set;
        }

        public Boolean rewind
        {
            get;
            set;
        }

        private Boolean _loop = true;
        public Boolean loop
        {
            get { return _loop; }
            set { _loop = value; }
        }

        private Int32 _playInterval = 2000;
        public Int32 playInterval
        {
            get { return _playInterval; }
            set { _playInterval = value; }
        }

        private Boolean _realtiime = true;
        public Boolean realtiime
        {
            get { return _realtiime; }
            set { _realtiime = value; }
        }

        private String _controlPosition = "left";
        public String controlPosition
        {
            get { return _controlPosition; }
            set { _controlPosition = value; }
        }

        public Int32 zlevel
        {
            get;
            set;
        }

        private Int32 _z = 2;
        public Int32 z
        {
            get { return _z; }
            set { _z = value; }
        }

        private Int32[] _padding = { 5, 5, 5, 5 };
        public Int32[] padding
        {
            get { return _padding; }
            set { _padding = value; }
        }

        private String _orient = "horizontal";
        public String orient
        {
            get { return _orient; }
            set { _orient = value; }
        }

        public Boolean inverse
        {
            get;
            set;
        }

        private String _symbol = "emptyCircle";
        public String symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public List<String> data
        {
            get;
            set;
        }

    }

    
    public class ECharts_Object
    {

        public ECharts_Object()
        {

        }

        //图例组件
        public Echarts_Title title
        {
            get;
            set;
        }

        //直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
        public Echarts_Grid grid
        {
            get;
            set;
        }

        //图例组件
        public Echarts_Legend legend
        {
            get;
            set;
        }

        //直角坐标系 grid 中的 x 轴，单个 grid 组件最多只能放上下两个 x 轴。
        public List<Echarts_xAxis> xAxis
        {
            get;
            set;
        }

        //直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
        public List<Echarts_yAxis> yAxis
        {
            get;
            set;
        }

        //提示框组件。
        public ECharts_Tooltip tooltip
        {
            get;
            set;
        }

        //工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
        public ECharts_Toolbox toolbox
        {
            get;
            set;
        }

        //系列列表
        public List<Echarts_Series> series
        {
            get;
            set;
        }

    }

    
    public class ECharts_BaseObject
    {
        public ECharts_BaseObject()
        {

        }

        public ECharts_BaseOption baseOption
        {
            get;
            set;
        }

        public List<ECharts_Options> options
        {
            get;
            set;
        }

    }


    /// <summary>
    /// 
    /// </summary>
    /// 

    
    public class ECharts_BaseOption
    {
        public ECharts_BaseOption()
        {

        }

        public Echarts_Title title
        {
            get;
            set;
        }

        public ECharts_Tooltip tooltip
        {
            get;
            set;
        }

        public Echarts_Legend legend
        {
            get;
            set;
        }

        public Echarts_Grid grid
        {
            get;
            set;
        }

        public Echarts_Timeline timeline
        {
            get;
            set;
        }

        public List<Echarts_xAxis> xAxis
        {
            get;
            set;
        }

        public List<Echarts_yAxis> yAxis
        {
            get;
            set;
        }

        public List<Echarts_Series> series
        {
            get;
            set;
        }

    }

    
    public class ECharts_Options
    {
        public ECharts_Options()
        {

        }

        public ECharts_Options_Title title
        {
            get;
            set;
        }

        public List<Echarts_Options_Series> series
        {
            get;
            set;
        }

    }


    //标题组件，包含主标题和副标题。
    
    public class ECharts_Options_Title
    {
        public ECharts_Options_Title()
        {

        }

        public String text
        {
            get;
            set;
        }

        public String subtext
        {
            get;
            set;
        }

        private object _left = "auto";
        public object left
        {
            get { return _left; }
            set { _left = value; }
        }

    }

    //系列列表
    
    public class Echarts_Options_Series
    {

        public Echarts_Options_Series()
        {

        }

        public List<Echarts_Series_Data> data
        {
            get;
            set;
        }


    }

}
