using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtil
{
    public class GeneralUtilExcel
    {
/*        public static XLWorkbook ExecSqlSelectTable_XLWorkbook(string SQLstring, string Connection, string WorksheetName = "WorksheetName")
        {
            DateTime startingAt = DateTime.Now;
            //  DataTable functionReturnValue = default(DataTable);
            System.Data.SqlClient.SqlConnection con = new  System.Data.SqlClient.SqlConnection(Connection);
            SqlDataAdapter da = new SqlDataAdapter(SQLstring, con);
            DataTable dt = new DataTable();
            // try
            {
                da.SelectCommand.CommandTimeout = 200;
                da.Fill(dt);
            }
            DateTime endingAt = DateTime.Now;
            TimeSpan diff = startingAt - endingAt;
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt, WorksheetName);
            return wb;
        }*/
    }
}
