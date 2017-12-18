/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_ModuleData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_ModuleData : DBBase<BUS_Module>, IBUS_ModuleData
    {


        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<BUS_Module> GetMenus(string RoleID)
        {
            var Exec_SQL = @"SELECT A.*
                               FROM BUS_Module A WITH(NOLOCK) INNER JOIN 
                                    BUS_RoleModule B WITH(NOLOCK) ON A.ID=B.ModuleID 
                              WHERE A.IsHide=0 AND B.RoleID='{0}'
                              ORDER BY A.ModuleCode;";
            var Module = DB.DbCont.FromSql(string.Format(Exec_SQL, RoleID)).ToList<BUS_Module>();
            return Module;
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<BUS_Module> GetSuperMenus(string RoleID)
        {
            var Exec_SQL = @"SELECT A.*
                               FROM BUS_Module A WITH(NOLOCK) INNER JOIN 
                                    BUS_RoleModule B WITH(NOLOCK) ON A.ID=B.ModuleID 
                              WHERE A.IsHide=0 AND B.RoleID='{0}'AND A.ParentID IS NULL
                              ORDER BY A.ModuleCode;";
            var Module = DB.DbCont.FromSql(string.Format(Exec_SQL, RoleID)).ToList<BUS_Module>();
            return Module;
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<BUS_Module> GetModuleMenus(string RoleID, string ModulePid)
        {
//            var Exec_SQL = @"SELECT A.*
//                               FROM BUS_Module A WITH(NOLOCK) INNER JOIN 
//                                    BUS_RoleModule B WITH(NOLOCK) ON A.ID=B.ModuleID 
//                              WHERE A.IsHide=0 AND B.RoleID='{0}' AND A.ParentID='{1}'
//                              ORDER BY A.ModuleCode;";
            var Exec_SQL = @"WITH Temp_Table(ID,ParentID,ModuleCode,ModuleName,PathURL,OrderNum,PicUrl,PicCss,IsHide,Note,TheLevel) AS 
                            (
	                            SELECT ID,ParentID,ModuleCode,ModuleName,PathURL,OrderNum,PicUrl,PicCss,IsHide,Note,0 TheLevel
	                              FROM BUS_Module WITH(NOLOCK)
	                             WHERE ParentID ='{1}' AND IsHide=0
	                             UNION ALL
	                            SELECT A.ID,A.ParentID,A.ModuleCode,A.ModuleName,A.PathURL,A.OrderNum,A.PicUrl,A.PicCss,A.IsHide,A.Note,TheLevel+1
	                              FROM BUS_Module A WITH(NOLOCK) INNER JOIN Temp_Table B ON A.ParentID = B.ID 
	                             WHERE A.IsHide=0 
                            )
                            SELECT A.*
                              FROM Temp_Table A INNER JOIN 
                                   BUS_RoleModule B WITH(NOLOCK) ON A.ID=B.ModuleID 
                              WHERE B.RoleID='{0}' ORDER BY A.ModuleCode;";
            var Module = DB.DbCont.FromSql(string.Format(Exec_SQL, RoleID, ModulePid)).ToList<BUS_Module>();
            return Module;
        }


        /// <summary>
        /// 获取模块管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForModule(Guid moduleId, Guid parentId)
        {
            var exp = ExpHelper.Create<BUS_Module>(null);
            var test = GetModels(exp);

            var oldModuleList = GetModels(exp).ToModelList<BUS_Module, ZTreeModel>();
            var newModuleList = oldModuleList.Select(item => new ZTreeModel
            {
                id = item.id,
                pId = item.pId,
                name = item.name,
                src = item.src,
                open = true,
                @checked = parentId == (Guid)item.id,
                chkDisabled = Guid.Parse(item.id.ToString()) == moduleId
            }).ToList();
            var mainNode = new ZTreeModel
            {
                id = null,
                name = "所有模块",
                open = true,
                @checked = parentId == Guid.Empty
            };
            if (newModuleList.Count >= 0)
            {
                newModuleList.Add(mainNode);
            }

            return newModuleList;
        }


        /// <summary>
        /// 获取角色管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForRole(Guid roleId, List<BUS_RoleModule> roleModuleList)
        {
            var exp = ExpHelper.Create<BUS_Module>(null);

            var oldModuleList = GetModels(exp).ToModelList<BUS_Module, ZTreeModel>();
            var newModuleList = oldModuleList.Select(item => new ZTreeModel
            {
                id = item.id,
                pId = item.pId,
                name = item.name,
                //icon = item.icon,
                src = item.src,
                open = false,// item.open,
                nocheck = item.nocheck,
                chkDisabled = false,
                @checked = roleModuleList.Any(rm => rm.RoleID == roleId && rm.ModuleID == (Guid)item.id),
                halfCheck = item.halfCheck
            }).ToList();

            //增加主节点
            var mainNode = new ZTreeModel
            {
                id = null,
                //pId = s.ParentId,
                name = "所有模块",
                //src = s.ModulePath,
                open = true,
                @checked = false
            };
            if (newModuleList.Count >= 0)
            {
                newModuleList.Add(mainNode);
            }
            return newModuleList;
        }


        #region 统计图

        EChartsObjectDAL _EChartsObject = new EChartsObjectDAL();
        
        //按类型年份查询统计报告 X坐标为月份 
        public Echart_Model GetEChartsReportByItem(string OrganID, string ItemCode, string Year)
        {

            bool result = false;
            string message = string.Empty;
            string text = string.Empty;
            string subtext = string.Empty;
            ECharts_Object ECharts = null;

            try
            {
                var ds = _EChartsObject.GetEChartsReportByItem(OrganID, @ItemCode, Year);

                DataTable dt_title = ds.Tables[0];
                DataTable dt_series = ds.Tables[1];

                result = Convert.ToBoolean(dt_title.Rows[0]["result"]);
                message = dt_title.Rows[0]["message"].ToString();
                text = dt_title.Rows[0]["text"].ToString();
                subtext = dt_title.Rows[0]["subtext"].ToString();
                string legend_data = dt_title.Rows[0]["legend_data"].ToString();
                string xAxis_data = dt_title.Rows[0]["xAxis_data"].ToString();

                if (result)//有数据
                {
                    Echarts_Title Title = new Echarts_Title()
                    {
                        show = true,
                        text = text,
                        subtext = subtext,
                        left = "left"
                    };

                    Echarts_Grid Grid = new Echarts_Grid()
                    {
                        left = "2%",
                        right = "2%", 
                        top = "70",
                        bottom = "30",
                        containLabel = true
                    };

                    ECharts_Tooltip Tooltip = new ECharts_Tooltip()
                    {
                        trigger = "axis",
                        axisPointer = new ECharts_Tooltip_AxisPointer()
                        {
                            type = "shadow",
                            axis = "auto"
                        },
                        textStyle = new ECharts_Tooltip_TextStyle()
                    };

                    Echarts_Legend Legend = new Echarts_Legend()
                    {
                        show = true,
                        left = "center",
                        data = JsonHelper.JsonToObjectList<string>(legend_data)
                    };

                    List<Echarts_xAxis> XAxis = new List<Echarts_xAxis>(){
                        new Echarts_xAxis(){ 
                            type = "category", 
                            data = JsonHelper.JsonToObjectList<Echarts_Axis_Data>(xAxis_data),
                             axisLabel=new Echarts_Axis_AxisLabel(){                                   
                                formatter= "{value}"
                            }
                        }
                    };

                    List<Echarts_yAxis> YAxis = new List<Echarts_yAxis>()
                    {
                        new Echarts_yAxis(){
                            type = "value",
                            name = "数量" ,
                            position="left",                             
                            axisLabel=new Echarts_Axis_AxisLabel(){
                                formatter= "{value}"
                            } 
                        }                                                
                    };

                    List<Echarts_Series> Series = new List<Echarts_Series>();

                    foreach (DataRow row in dt_series.Rows)
                    {

                        Echarts_Series Series_Data = new Echarts_Series()
                        {
                            name = row["series_name"].ToString(),
                            type = row["series_type"].ToString(),
                            barMaxWidth = 35,
                            smooth = true,
                            data = JsonHelper.JsonToObjectList<Echarts_Series_Data>(row["series_data"].ToString()),

                            label = new Echarts_Series_Label()
                            {
                                normal = new Echarts_Series_Label_Normal()
                                {
                                    show = true,
                                    position = "top"
                                }
                            }
                        };

                        Series.Add(Series_Data);    
                    }

                    ECharts = new ECharts_Object()
                    {
                        title = Title,
                        grid = Grid,
                        tooltip = Tooltip,
                        legend = Legend,
                        xAxis = XAxis,
                        yAxis = YAxis,
                        series = Series
                    };

                }
                else //无数据
                {

                }

            }
            catch
            {
                result = false;
                message = "查询错误!";
            }
            finally
            {

            }

            var model = new Echart_Model()
            {
                Result = result,
                Text = text,
                SubText = subtext,
                Message = message,
                ECharts = ECharts
            };

           

            return model;
        }

        //按根据月份查询统计报告 X坐标为项目
        public Echart_Model GetEChartsReportByMonth(string OrganID, string Month)
        {

            bool result = false;
            string message = string.Empty;
            string text = string.Empty;
            string subtext = string.Empty;
            ECharts_Object ECharts = null;

            try
            {
                var ds = _EChartsObject.GetEChartsReportByMonth(OrganID, Month);

                DataTable dt_title = ds.Tables[0];
                DataTable dt_series = ds.Tables[1];

                result = Convert.ToBoolean(dt_title.Rows[0]["result"]);
                message = dt_title.Rows[0]["message"].ToString();
                text = dt_title.Rows[0]["text"].ToString();
                subtext = dt_title.Rows[0]["subtext"].ToString();
                string legend_data = dt_title.Rows[0]["legend_data"].ToString();
                string xAxis_data = dt_title.Rows[0]["xAxis_data"].ToString();

                if (result)//有数据
                {
                    Echarts_Title Title = new Echarts_Title()
                    {
                        show = true,
                        text = text,
                        subtext = subtext,
                        left = "left"
                    };

                    Echarts_Grid Grid = new Echarts_Grid()
                    {
                        left = "2%",
                        right = "2%",
                        top = "80",
                        bottom = "50",
                        containLabel = true
                    };

                    ECharts_Tooltip Tooltip = new ECharts_Tooltip()
                    {
                        trigger = "axis",
                        axisPointer = new ECharts_Tooltip_AxisPointer()
                        {
                            type = "shadow",
                            axis = "auto"
                        },
                        textStyle = new ECharts_Tooltip_TextStyle()
                    };

                    Echarts_Legend Legend = new Echarts_Legend()
                    {
                        show = true,
                        left = "center",
                        data = JsonHelper.JsonToObjectList<string>(legend_data)
                    };

                    List<Echarts_xAxis> XAxis = new List<Echarts_xAxis>(){
                            new Echarts_xAxis(){ 
                                type = "category", 
                                boundaryGap=true,
                                data = JsonHelper.JsonToObjectList<Echarts_Axis_Data>(xAxis_data),
                                axisLabel=new Echarts_Axis_AxisLabel(){
                                      interval=0,
                                        rotate=45,
                                    formatter= "{value}"
                                }
                            }
                        };

                    List<Echarts_yAxis> YAxis = new List<Echarts_yAxis>()
                    {
                        new Echarts_yAxis(){
                            type = "value",
                            name = "数量" ,
                            position="left",                             
                            axisLabel=new Echarts_Axis_AxisLabel(){
                                formatter= "{value}"
                            } 
                        }                                                
                    };

                    List<Echarts_Series> Series = new List<Echarts_Series>();

                    foreach (DataRow row in dt_series.Rows)
                    {

                        Echarts_Series Series_Data = new Echarts_Series()
                        {
                            name = row["series_name"].ToString(),
                            type = row["series_type"].ToString(),
                            barMaxWidth = 35,
                            smooth = true,
                            data = JsonHelper.JsonToObjectList<Echarts_Series_Data>(row["series_data"].ToString()),

                            label = new Echarts_Series_Label()
                            {
                                normal = new Echarts_Series_Label_Normal()
                                {
                                    show = true,
                                    position = "top"
                                }
                            }
                        };

                        Series.Add(Series_Data);    
                    }

                    ECharts = new ECharts_Object()
                    {
                        title = Title,
                        grid = Grid,
                        tooltip = Tooltip,
                        legend = Legend,
                        xAxis = XAxis,
                        yAxis = YAxis,
                        series = Series
                    };

                }
                else //无数据
                {

                }

            }
            catch
            {
                result = false;
                message = "查询错误!";
            }
            finally
            {

            }

            var model = new Echart_Model()
            {
                Result = result,
                Text = text,
                SubText = subtext,
                Message = message,
                ECharts = ECharts
            };

           

            return model;
        }
        
        #endregion


        #region 力学设备数据监控系统

        public DgListModel<TW_SYJZBModel> GetSysData(PostAccessDB pageCon, string StrConn)
        {

            //StrConn = @"Data Source=cdkxc\sql2008;Initial Catalog=HPEServer15i_DataCollection;User ID=hxb;Password=kxrj";
                                 
            string Str_SQL = string.Empty;

            //试验室
            string  Where = " B.OrganID ='" + pageCon.OrganID + "'";
            if (!string.IsNullOrEmpty(pageCon.TypeCode))//类型代码
            {
                Where += string.Format(" AND A.SYLX IN ({0}) ", pageCon.TypeCode);
            }
            if (!string.IsNullOrEmpty(pageCon.StartDate))//开始日期
            {
                Where += " AND A.SYRQ>='" + pageCon.StartDate + "'";            
            }
            if (!string.IsNullOrEmpty(pageCon.EndDate))//结束日期
            {
                Where += " AND A.SYRQ<='" + pageCon.EndDate + "'";
            }
            if (!string.IsNullOrEmpty(pageCon.SampleNum))//样品编号
            {
                Where += " AND A.SJBH like'%" + pageCon.SampleNum + "%'";
            }
            if (!string.IsNullOrEmpty(pageCon.PlacePurpose))//工程部位/用途
            {
                Where += " AND A.CJMC like'%" + pageCon.PlacePurpose + "%'";
            }
            if (!string.IsNullOrEmpty(pageCon.StrengthGrade))//强度等级
            {
                Where += " AND A.SJQD ='" + pageCon.StrengthGrade + "'";
            }
            if (!string.IsNullOrEmpty(pageCon.AgeDays))//龄期(天)
            {
                Where += " AND A.LQ =" + pageCon.AgeDays + "";
            }
            if (!string.IsNullOrEmpty(pageCon.MarkNum))//牌号
            {
                Where += " AND A.PZBM like'%" + pageCon.MarkNum + "%'";
            }
                
            if (pageCon.TableType == 0)//混凝土 100014  砂浆 100131,100133 水泥100134,100135,100136
            {
                Str_SQL = @"SELECT A.*,STUFF((SELECT '，'+D.KYLZ+'' FROM TW_YLJ D WHERE A.SYJID=D.SYJID ORDER BY D.F_GUID DESC FOR XML PATH('')),1,1,'') AS KYLZ,B.EquName 
                              FROM TW_SYJZB A INNER JOIN
                                   RevampEquAndOrgan B ON A.SBBH=B.EquCode AND B.OrganID='{0}'
                             WHERE {1} ORDER BY A.SYRQ DESC";
            }
            else if (pageCon.TableType == 1)//钢筋 100047,100048,100049
            {
                Str_SQL = @"SELECT A.*,STUFF((SELECT '，'+D.LZ+'' FROM TW_WNJ D WHERE A.SYJID=D.SYJID ORDER BY D.SJXH DESC FOR XML PATH('')),1,1,'') AS KYLZ,
                                       STUFF((SELECT '，'+D.QFLZ+'' FROM TW_WNJ D WHERE A.SYJID=D.SYJID ORDER BY D.SJXH DESC FOR XML PATH('')),1,1,'') AS QFLZ,
                                       B.EquName 
                              FROM TW_SYJZB A INNER JOIN
                                   RevampEquAndOrgan B ON A.SBBH=B.EquCode AND B.OrganID='{0}'
                             WHERE {1} ORDER BY A.SYRQ DESC";
            }

            var Exec_SQL = string.Format(Str_SQL, pageCon.OrganID,Where);

            var db = new PetaPoco.Database(StrConn);
            var Module = db.Page<TW_SYJZBModel>(pageCon.PageIndex, pageCon.PageSize, new PetaPoco.Sql(Exec_SQL));
           
            return new DgListModel<TW_SYJZBModel>(Module.Items, Convert.ToInt32(Module.TotalItems));
           
        }

        #endregion

       
    }
}
