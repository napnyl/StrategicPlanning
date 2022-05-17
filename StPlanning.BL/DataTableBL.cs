using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StPlanning.BL
{
    public class DataTableBL
    {
        public static bool HasBlankCell(DataTable dt)
        {
            bool result = false;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j][i].ToString().Trim() == string.Empty)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    if (!Props[i].Name.ToString().Contains("tbl"))
                        values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        public static DataTable ObjectQueryToDataTable<T>(IEnumerable<T> objlist)
        {
            DataTable dtReturn = new DataTable();

            PropertyInfo[] objProps = null;

            if (objlist == null)
            {
                return dtReturn;
            }

            foreach (T objRec in objlist)
            {
                if (objProps == null)
                {
                    objProps = ((Type)objRec.GetType()).GetProperties();
                    foreach (PropertyInfo objpi in objProps)
                    {
                        Type colType = objpi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(objpi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in objProps)
                {
                    dr[pi.Name] = pi.GetValue(objRec, null) == null ? DBNull.Value : pi.GetValue(objRec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DataTable RemoveEmptyRows(DataTable dt)
        {
            dt = dt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
            return dt;
        }

        public static DataTable KeepOnlyColumn(DataTable dt, int keepColumn)
        {
            DataTable dtResult = dt.Copy();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i != keepColumn)
                    dtResult.Columns.Remove(dt.Columns[i].ToString());
            }
            dtResult = RemoveEmptyRows(dtResult);
            return dtResult;
        }

    }
}
