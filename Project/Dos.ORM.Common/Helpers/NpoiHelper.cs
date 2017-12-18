/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：NpoiHelper
 * 创建时间：2016-11-16 17:18:51
 * 创建人：Quber
 * 创建说明：NPOI Excel帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// NPOI Excel帮助类
    /// </summary>
    public static class NpoiHelper
    {
        /// <summary>
        /// 默认导出的临时文件地址
        /// </summary>
        private static string exportPath = "/Content/Export/Temp/";

        /// <summary>
        /// 将DataTable导出为Excel
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="fileName">文件名称（此参数不传递，则返回时间名称。不包含后缀，会自动追加.xlsx后缀）</param>
        /// <param name="filePath">导出的相对文件路径</param>
        public static string ExportToXls(DataTable dataTable, string fileName = null, string filePath = null)
        {
            var dts = new List<DataTable> { dataTable };

            return ExportToXls(dts, fileName, filePath);
        }

        /// <summary>
        /// 将DataSet导出为Excel
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="fileName">文件名称（此参数不传递，则返回时间名称。不包含后缀，会自动追加.xlsx后缀）</param>
        /// <param name="filePath">导出的相对文件路径</param>
        public static string ExportToXls(DataSet dataSet, string fileName = null, string filePath = null)
        {
            List<DataTable> dts = dataSet.Tables.Cast<DataTable>().ToList();

            return ExportToXls(dts, fileName, filePath);
        }

        /// <summary>
        /// 将DataTable集合导出为Excel
        /// </summary>
        /// <param name="dataTables"></param>
        /// <param name="fileName">文件名称（此参数不传递，则返回时间名称。不包含后缀，会自动追加.xlsx后缀）</param>
        /// <param name="filePath">导出的相对文件路径</param>
        public static string ExportToXls(IEnumerable<DataTable> dataTables, string fileName = null, string filePath = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = exportPath + DateTime.Now.ToString("yyyyMMdd") + "/";
            }

            //创建文件夹
            FileHelper.CreateDir(filePath);

            var fileFullName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                fileFullName = fileName + "_" + fileFullName;
            }
            filePath = filePath + fileFullName;

            IWorkbook workbook = new XSSFWorkbook();
            var i = 0;

            foreach (DataTable dt in dataTables)
            {
                string sheetName = string.IsNullOrEmpty(dt.TableName) ? "Sheet " + (++i) : dt.TableName;
                ISheet sheet = workbook.CreateSheet(sheetName);

                IRow headerRow = sheet.CreateRow(0);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string columnName = string.IsNullOrEmpty(dt.Columns[j].ColumnName) ? "Column " + j : dt.Columns[j].ColumnName;
                    headerRow.CreateCell(j).SetCellValue(columnName);
                }

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    DataRow dr = dt.Rows[a];
                    IRow row = sheet.CreateRow(a + 1);
                    for (int b = 0; b < dt.Columns.Count; b++)
                    {
                        row.CreateCell(b).SetCellValue(dr[b] != DBNull.Value ? dr[b].ToString() : string.Empty);
                    }
                }
            }

            using (FileStream fs = File.Create(HttpContext.Current.Server.MapPath(filePath)))
            {
                workbook.Write(fs);

                return filePath;
            }
        }

        /// <summary>
        /// 将Excel转换为DataTable集合
        /// </summary>
        /// <param name="xlsFile">Excel的相对路径</param>
        /// <returns></returns>
        public static List<DataTable> ImportToDt(string xlsFile)
        {
            xlsFile = HttpContext.Current.Server.MapPath(xlsFile);

            if (!File.Exists(xlsFile)) throw new FileNotFoundException("文件不存在");

            List<DataTable> result = new List<DataTable>();
            Stream stream = new MemoryStream(File.ReadAllBytes(xlsFile));
            IWorkbook workbook = new XSSFWorkbook(stream);

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                DataTable dt = new DataTable();
                ISheet sheet = workbook.GetSheetAt(i);
                IRow headerRow = sheet.GetRow(0);

                int cellCount = headerRow.LastCellNum;
                for (int j = headerRow.FirstCellNum; j < cellCount; j++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(j).StringCellValue);
                    dt.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;
                for (int a = (sheet.FirstRowNum + 1); a < rowCount; a++)
                {
                    IRow row = sheet.GetRow(a);
                    if (row == null) continue;

                    DataRow dr = dt.NewRow();
                    for (int b = row.FirstCellNum; b < cellCount; b++)
                    {
                        if (row.GetCell(b) == null) continue;
                        dr[b] = row.GetCell(b).ToString();
                    }

                    dt.Rows.Add(dr);
                }
                result.Add(dt);
            }
            stream.Close();

            return result;
        }
    }
}
