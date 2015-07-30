using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

namespace TNS.Web.Util
{
    public class ExcelUtil
    {
        private static List<string> getTableHeaders(DataTable dataTable)
        {
            var hearders = new List<string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                hearders.Add(column.ColumnName);
            }
            return hearders;
        }

        private static string getHeadersString(List<string> headers)
        {
            StringBuilder heards = new StringBuilder();
            for (int i = 0; i < headers.Count; i++)
            {
                heards.Append(headers[i]);
                if (i != headers.Count - 1)
                {
                    heards.Append("\t");
                }
            }
            return heards.ToString();
        }
        
        private static string getRowString(DataRow dataRow, List<string> headers)
        {
            StringBuilder sRow = new StringBuilder();
            for (int i = 0; i < headers.Count; i++)
            {
                sRow.Append(dataRow[headers[i]]);
                if (i != headers.Count - 1)
                {
                    sRow.Append("\t");
                }
            } return sRow.ToString();
        }
        
        public static void ToExcel(DataTable dataTable, System.Web.HttpResponseBase response)
        {
            using (StringWriter sw = new StringWriter())
            {
                List<string> headers = getTableHeaders(dataTable);
                string sHeaders = getHeadersString(headers);

                sw.WriteLine(sHeaders);

                foreach (DataRow dr in dataTable.Rows)
                {
                    string sRow = getRowString(dr, headers);
                    sw.WriteLine(sRow);
                }

                response.Clear();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=Teest.xls");
                response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                response.ContentType = "application/vnd.ms-excel";
                response.Write(sw);
                response.End();
            }
        }
    }
}
