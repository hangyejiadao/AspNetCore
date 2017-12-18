using Dos.ORM.Data.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Data.Business
{
    public class EChartsObjectDAL
    {

        public DataSet GetEChartsReportByItem(string OrganID, string ItemCode, string Year)
        {                   
            var procSection = DB.DbCont.FromProc("UP_GetEChartsReportByItem")
               .AddInParameter("@OrganID", DbType.Guid, OrganID)
               .AddInParameter("@ItemCode", DbType.String, ItemCode)
               .AddInParameter("@Year", DbType.String, Year);

            var ds = procSection.ToDataSet();

            return ds;
        }

        public DataSet GetEChartsReportByMonth(string OrganID, string Month)
        {
            var procSection = DB.DbCont.FromProc("UP_GetEChartsReportByMonth")
               .AddInParameter("@OrganID", DbType.Guid, OrganID)
               .AddInParameter("@Month", DbType.String, Month);

            var ds = procSection.ToDataSet();

            return ds;
        }

    }
}
