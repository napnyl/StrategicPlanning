using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace StPlanning.BL
{
    public class ExcelDataBaseHelper
    {
        public static object OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                XtraMessageBox.Show("No se encontró el archivo");
                return null;
            }
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            var adapter = new OleDbDataAdapter("select * from [Hoja1$]", connectionString);
            var ds = new DataSet();
            string tableName = "excelData";
            adapter.Fill(ds, tableName);
            DataTable data = ds.Tables[tableName];
            return data;
        }

        public static DataTable ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            cmd.CommandType = CommandType.Text;

                            DataTable outputTable = new DataTable(sheet);
                            output.Tables.Add(outputTable);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return output.Tables.Count > 0 ? output.Tables[0] : null;
        }
    }
}
