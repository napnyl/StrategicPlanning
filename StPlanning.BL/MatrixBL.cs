using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StPlanning.DB;
using DevExpress.XtraEditors;
using System.Net;
using System.Reflection;

namespace StPlanning.BL
{
    public class MatrixBL
    {
        static bool rowNamed = false;

        public static int SaveFodaData(DataTable dt, int idProject)
        {
            int idFoda = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblFoda foda = new tblFoda();
                foda.IdProject = idProject;
                foda.Name = "Foda Nombre";
                foda.Description = "Foda Descripción";
                foda.UserInsert = "Usuario Generico";
                foda.ComputerInsert = Dns.GetHostName();
                foda.DateInsert = DateTime.Now;
                context.tblFoda.Add(foda);
                context.SaveChanges();
                idFoda = (int)foda.Id;

                string rowName = string.Empty;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                //Se inserta en tabla detalle
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        tblFodaDetail fodaDetail = new tblFodaDetail();
                        fodaDetail.IdFoda = foda.Id;
                        fodaDetail.ColumnName = columnNames[j];
                        fodaDetail.Row = i;
                        fodaDetail.Col = j;
                        fodaDetail.Value = !string.IsNullOrEmpty(dt.Rows[i][j].ToString()) ? dt.Rows[i][j].ToString() : null;
                        context.tblFodaDetail.Add(fodaDetail);
                    }
                }

                //Se actualiza proyecto.
                tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                tblProject.FodaUpload = true;

                //Si no ocurrieron problemas, se graba en base.
                context.SaveChanges();
            }
            return idFoda;
        }

        public static int SaveFoData(DataTable dt, int idProject)
        {
            int idFo = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblFo fo = new tblFo();
                fo.IdProject = idProject;
                fo.Name = "Fo Nombre";
                fo.Description = "Fo Descripción";
                fo.RowNumber = dt.Rows.Count;
                fo.ColNumber = dt.Columns.Count - 1;
                fo.UserInsert = "Usuario Generico";
                fo.ComputerInsert = Dns.GetHostName();
                fo.DateInsert = DateTime.Now;
                context.tblFo.Add(fo);
                context.SaveChanges();
                idFo = (int)fo.Id;

                string rowName = string.Empty;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                //Se inserta en tabla detalle
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            rowName = dt.Rows[i][j].ToString();
                        }
                        else
                        {
                            tblFoDetail foDetail = new tblFoDetail();
                            foDetail.IdFo = fo.Id;
                            foDetail.Row = i;
                            foDetail.Col = j - 1;
                            foDetail.RowName = rowName;
                            foDetail.ColName = columnNames[j];
                            if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                foDetail.Value = Convert.ToInt32(dt.Rows[i][j]);
                            else
                                foDetail.Value = null;
                            context.tblFoDetail.Add(foDetail);
                        }
                    }
                }

                //Se actualiza proyecto.
                tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                tblProject.FoUpload = true;

                //Si no ocurrieron problemas, se graba en base.
                context.SaveChanges();
            }
            return idFo;
        }

        public static int SaveDoData(DataTable dt, int idProject)
        {
            int idDo = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblDo doTbl = new tblDo();
                doTbl.IdProject = idProject;
                doTbl.Name = "Do Nombre";
                doTbl.Description = "Do Descripción";
                doTbl.RowNumber = dt.Rows.Count;
                doTbl.ColNumber = dt.Columns.Count - 1;
                doTbl.UserInsert = "Usuario Generico";
                doTbl.ComputerInsert = Dns.GetHostName();
                doTbl.DateInsert = DateTime.Now;
                context.tblDo.Add(doTbl);
                context.SaveChanges();
                idDo = (int)doTbl.Id;

                string rowName = string.Empty;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                //Se inserta en tabla detalle
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            rowName = dt.Rows[i][j].ToString();
                        }
                        else
                        {
                            tblDoDetail doDetail = new tblDoDetail();
                            doDetail.IdDo = idDo;
                            doDetail.Row = i;
                            doDetail.Col = j - 1;
                            doDetail.RowName = rowName;
                            doDetail.ColName = columnNames[j];
                            if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                doDetail.Value = Convert.ToInt32(dt.Rows[i][j]);
                            else
                                doDetail.Value = null;
                            context.tblDoDetail.Add(doDetail);
                        }
                    }
                }

                //Se actualiza proyecto.
                tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                tblProject.DoUpload = true;

                //Si no ocurrieron problemas, se graba en base.
                context.SaveChanges();
            }
            return idDo;
        }

        public static int SaveFaData(DataTable dt, int idProject)
        {
            int idFa = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblFa faTbl = new tblFa();
                faTbl.IdProject = idProject;
                faTbl.Name = "Fa Nombre";
                faTbl.Description = "Fa Descripción";
                faTbl.RowNumber = dt.Rows.Count;
                faTbl.ColNumber = dt.Columns.Count - 1;
                faTbl.UserInsert = "Usuario Generico";
                faTbl.ComputerInsert = Dns.GetHostName();
                faTbl.DateInsert = DateTime.Now;
                context.tblFa.Add(faTbl);
                context.SaveChanges();
                idFa = (int)faTbl.Id;

                string rowName = string.Empty;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                //Se inserta en tabla detalle
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            rowName = dt.Rows[i][j].ToString();
                        }
                        else
                        {
                            tblFaDetail faDetail = new tblFaDetail();
                            faDetail.IdFa = idFa;
                            faDetail.Row = i;
                            faDetail.Col = j - 1;
                            faDetail.RowName = rowName;
                            faDetail.ColName = columnNames[j];
                            if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                faDetail.Value = Convert.ToInt32(dt.Rows[i][j]);
                            else
                                faDetail.Value = null;
                            context.tblFaDetail.Add(faDetail);
                        }
                    }
                }

                //Se actualiza proyecto.
                tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                tblProject.FaUpload = true;

                //Si no ocurrieron problemas, se graba en base.
                context.SaveChanges();
            }
            return idFa;
        }

        public static int SaveDaData(DataTable dt, int idProject)
        {
            int idDa = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblDa daTbl = new tblDa();
                daTbl.IdProject = idProject;
                daTbl.Name = "Da Nombre";
                daTbl.Description = "Da Descripción";
                daTbl.RowNumber = dt.Rows.Count;
                daTbl.ColNumber = dt.Columns.Count - 1;
                daTbl.UserInsert = "Usuario Generico";
                daTbl.ComputerInsert = Dns.GetHostName();
                daTbl.DateInsert = DateTime.Now;
                context.tblDa.Add(daTbl);
                context.SaveChanges();
                idDa = (int)daTbl.Id;

                string rowName = string.Empty;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                //Se inserta en tabla detalle
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            rowName = dt.Rows[i][j].ToString();
                        }
                        else
                        {
                            tblDaDetail daDetail = new tblDaDetail();
                            daDetail.IdDa = idDa;
                            daDetail.Row = i;
                            daDetail.Col = j - 1;
                            daDetail.RowName = rowName;
                            daDetail.ColName = columnNames[j];
                            if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                daDetail.Value = Convert.ToInt32(dt.Rows[i][j]);
                            else
                                daDetail.Value = null;
                            context.tblDaDetail.Add(daDetail);
                        }
                    }
                }

                //Se actualiza proyecto.
                tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                tblProject.DaUpload = true;

                //Si no ocurrieron problemas, se graba en base.
                context.SaveChanges();
            }
            return idDa;
        }

        public static int SaveStrategiesData(DataTable dt, int idProject)
        {
            try
            {
                int idDa = 0;
                string type = string.Empty;
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    //Se inserta en tabla estrategias básica.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][1].ToString().Contains("FORTALEZAS / OPORTUNIDADES"))
                        {
                            type = "FO";
                        }
                        else if (dt.Rows[i][1].ToString().Contains("DEBILIDADES / OPORTUNIDADES"))
                        {
                            type = "DO";
                        }
                        else if (dt.Rows[i][1].ToString().Contains("FORTALEZAS / AMENAZAS"))
                        {
                            type = "FA";
                        }
                        else if (dt.Rows[i][1].ToString().Contains("DEBILIDADES / AMENAZAS"))
                        {
                            type = "DA";
                        }
                        else
                        {
                            tblStrategiesBasic stTbl = new tblStrategiesBasic();
                            stTbl.IdProject = idProject;
                            stTbl.Type = type;
                            stTbl.Crossed = dt.Rows[i][0].ToString();
                            stTbl.Strategy = dt.Rows[i][1].ToString();
                            if (dt.Rows[i][2] != DBNull.Value && dt.Rows[i][2] != null && dt.Rows[i][2] != string.Empty)
                                stTbl.Color = Convert.ToInt32(dt.Rows[i][2]);
                            else
                                stTbl.Color = null;
                            stTbl.Level = dt.Rows[i][3] != null ? dt.Rows[i][3].ToString() : string.Empty;
                            stTbl.UserInsert = "Usuario Generico";
                            stTbl.ComputerInsert = Dns.GetHostName();
                            stTbl.DateInsert = DateTime.Now;
                            context.tblStrategiesBasic.Add(stTbl);
                        }
                    }

                    //Se actualiza proyecto.
                    tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                    tblProject.StrategiesBasicUpload = true;

                    //Si no ocurrieron problemas, se graba en base.
                    context.SaveChanges();
                }
                return idDa;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int SaveManagerStData(DataTable dt, int idProject, string level)
        {
            try
            {
                int idDa = 0;
                string type = string.Empty;
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    //Se inserta en tabla estrategias básica.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tblManagerSt managerStTbl = new tblManagerSt();
                        managerStTbl.IdProject = idProject;
                        managerStTbl.Strategies = dt.Rows[i][0].ToString();
                        managerStTbl.ManagerStrategy = dt.Rows[i][1].ToString();

                        if (dt.Rows[i][2] != DBNull.Value && dt.Rows[i][2] != null && dt.Rows[i][2] != string.Empty)
                            managerStTbl.Color = Convert.ToInt32(dt.Rows[i][2]);
                        else
                            managerStTbl.Color = null;

                        managerStTbl.Level = level;
                        managerStTbl.Perspective = dt.Rows[i][3].ToString();
                        tblProject tblProject = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();

                        //Se actualiza proyecto.
                        if (level.Contains("1"))
                            tblProject.StrategiesManagerUpload = true;
                        else if (level.Contains("2"))
                            tblProject.StrategiesLevel2Upload = true;
                        else if (level.Contains("3"))
                            tblProject.StrategiesLevel3Upload = true;
                        else if (level.Contains("4"))
                            tblProject.StrategiesLevel4Upload = true;

                        managerStTbl.UserInsert = "Usuario Generico";
                        managerStTbl.ComputerInsert = Dns.GetHostName();
                        managerStTbl.DateInsert = DateTime.Now;
                        context.tblManagerSt.Add(managerStTbl);
                    }

                    //Si no ocurrieron problemas, se graba en base.
                    context.SaveChanges();
                }
                return idDa;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static DataTable GetFodaDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            tblFoda fodaTable = new tblFoda();
            List<tblFodaDetail> fodaDetail = new List<tblFodaDetail>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                fodaTable = context.tblFoda.Where(f => f.IdProject == projectId).FirstOrDefault();
                if (fodaTable != null && fodaTable.Id != null)
                    fodaDetail = context.tblFodaDetail.Where(f => f.IdFoda == fodaTable.Id).ToList();
            }

            if (fodaTable != null && fodaTable.Id != null && fodaDetail != null && fodaDetail.Count > 0)
            {
                foreach (var dataRow in fodaDetail.Where(f => f.Row == 0).OrderBy(f => f.Col))
                {
                    dt.Columns.Add(dataRow.ColumnName);
                }

                for (int tableRow = 0; tableRow <= fodaDetail.Max(d => d.Row); tableRow++)
                {
                    DataRow row = dt.NewRow();
                    foreach (var colDetail in fodaDetail.Where(f => f.Row == tableRow).OrderBy(f => f.Col))
                    {
                        row[colDetail.ColumnName] = colDetail.Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public static DataTable GetFoDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            tblFo foTable = new tblFo();
            List<tblFoDetail> foDetail = new List<tblFoDetail>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                foTable = context.tblFo.Where(f => f.IdProject == projectId).FirstOrDefault();
                if (foTable != null && foTable.Id != null)
                    foDetail = context.tblFoDetail.Where(f => f.IdFo == foTable.Id).ToList();
            }

            if (foTable != null && foTable.Id != null && foDetail != null && foDetail.Count > 0)
            {
                dt.Columns.Add("*** FORTALEZAS / OPORTUNIDADES ***");
                foreach (var dataRow in foDetail.Where(f => f.Row == 0).OrderBy(f => f.Col))
                {
                    dt.Columns.Add(dataRow.ColName);
                }

                for (int tableRow = 0; tableRow < foTable.RowNumber; tableRow++)
                {
                    DataRow row = dt.NewRow();
                    foreach (var rowDetail in foDetail.Where(f => f.Row == tableRow).OrderBy(f => f.Col))
                    {
                        if (!rowNamed)
                        {
                            row[0] = rowDetail.RowName;
                            rowNamed = true;
                        }
                        row[(int)rowDetail.Col + 1] = rowDetail.Value;
                    }
                    dt.Rows.Add(row);
                    rowNamed = false;
                }
            }
            return dt;
        }

        public static DataTable GetDoDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            tblDo doTable = new tblDo();
            List<tblDoDetail> doDetail = new List<tblDoDetail>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                doTable = context.tblDo.Where(d => d.IdProject == projectId).FirstOrDefault();
                if (doTable != null && doTable.Id != null)
                    doDetail = context.tblDoDetail.Where(d => d.IdDo == doTable.Id).ToList();
            }
            //dt.Clear();

            if (doTable != null && doTable.Id != null && doDetail != null && doDetail.Count > 0)
            {
                dt.Columns.Add("*** DEBILIDADES / OPORTUNIDADES ***");
                foreach (var dataRow in doDetail.Where(f => f.Row == 0).OrderBy(f => f.Col))
                {
                    dt.Columns.Add(dataRow.ColName);
                }

                for (int tableRow = 0; tableRow < doTable.RowNumber; tableRow++)
                {
                    DataRow row = dt.NewRow();
                    foreach (var rowDetail in doDetail.Where(f => f.Row == tableRow).OrderBy(f => f.Col))
                    {
                        if (!rowNamed)
                        {
                            row[0] = rowDetail.RowName;
                            rowNamed = true;
                        }
                        row[(int)rowDetail.Col + 1] = rowDetail.Value;
                    }
                    dt.Rows.Add(row);
                    rowNamed = false;
                }
            }
            return dt;
        }

        public static DataTable GetFaDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            tblFa faTable = new tblFa();
            List<tblFaDetail> faDetail = new List<tblFaDetail>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                faTable = context.tblFa.Where(f => f.IdProject == projectId).FirstOrDefault();
                if (faTable != null && faTable.Id != null)
                    faDetail = context.tblFaDetail.Where(f => f.IdFa == faTable.Id).ToList();
            }
            //dt.Clear();

            if (faTable != null && faTable.Id != null && faDetail != null && faDetail.Count > 0)
            {
                dt.Columns.Add("*** FORTALEZAS / AMENAZAS ***");
                foreach (var dataRow in faDetail.Where(f => f.Row == 0).OrderBy(f => f.Col))
                {
                    dt.Columns.Add(dataRow.ColName);
                }

                for (int tableRow = 0; tableRow < faTable.RowNumber; tableRow++)
                {
                    DataRow row = dt.NewRow();
                    foreach (var rowDetail in faDetail.Where(f => f.Row == tableRow).OrderBy(f => f.Col))
                    {
                        if (!rowNamed)
                        {
                            row[0] = rowDetail.RowName;
                            rowNamed = true;
                        }
                        row[(int)rowDetail.Col + 1] = rowDetail.Value;
                    }
                    dt.Rows.Add(row);
                    rowNamed = false;
                }
            }
            return dt;
        }

        public static DataTable GetDaDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            tblDa daTable = new tblDa();
            List<tblDaDetail> daDetail = new List<tblDaDetail>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                daTable = context.tblDa.Where(d => d.IdProject == projectId).FirstOrDefault();
                if (daTable != null && daTable.Id != null)
                    daDetail = context.tblDaDetail.Where(d => d.IdDa == daTable.Id).ToList();
            }
            //dt.Clear();

            if (daTable != null && daTable.Id != null && daDetail != null && daDetail.Count > 0)
            {
                dt.Columns.Add("*** DEBILIDADES / AMENAZAS ***");
                foreach (var dataRow in daDetail.Where(f => f.Row == 0).OrderBy(f => f.Col))
                {
                    dt.Columns.Add(dataRow.ColName);
                }

                for (int tableRow = 0; tableRow < daTable.RowNumber; tableRow++)
                {
                    DataRow row = dt.NewRow();
                    foreach (var rowDetail in daDetail.Where(f => f.Row == tableRow).OrderBy(f => f.Col))
                    {
                        if (!rowNamed)
                        {
                            row[0] = rowDetail.RowName;
                            rowNamed = true;
                        }
                        row[(int)rowDetail.Col + 1] = rowDetail.Value;
                    }
                    dt.Rows.Add(row);
                    rowNamed = false;
                }
            }
            return dt;
        }

        public static DataTable GetStBasicDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            List<tblStrategiesBasic> stBasicTable = new List<tblStrategiesBasic>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                stBasicTable = context.tblStrategiesBasic.Where(s => s.IdProject == projectId).ToList();
            }

            if (stBasicTable != null && stBasicTable.Count > 0)
            {
                dt.Columns.Add("CRUCE");
                dt.Columns.Add("DESARROLLO DE ESTRATEGIAS");
                dt.Columns.Add("GRUPO");
                dt.Columns.Add("NIVEL");

                //Fila FO.
                DataRow drFo = dt.NewRow();
                drFo[0] = string.Empty; drFo[1] = "FORTALEZAS / OPORTUNIDADES"; drFo[2] = string.Empty; drFo[3] = string.Empty;
                dt.Rows.Add(drFo);

                //Se insertan los cruces FO.
                foreach (var dr in stBasicTable.Where(s => s.Type == "FO").OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Crossed; drNew[1] = dr.Strategy; drNew[2] = dr.Color; drNew[3] = dr.Level;
                    dt.Rows.Add(drNew);
                }

                //Fila DO.
                DataRow drDo = dt.NewRow();
                drDo[0] = string.Empty; drDo[1] = "DEBILIDADES / OPORTUNIDADES"; drDo[2] = string.Empty; drDo[3] = string.Empty;
                dt.Rows.Add(drDo);

                //Se insertan los cruces DO.
                foreach (var dr in stBasicTable.Where(s => s.Type == "DO").OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Crossed; drNew[1] = dr.Strategy; drNew[2] = dr.Color; drNew[3] = dr.Level;
                    dt.Rows.Add(drNew);
                }

                //Fila FA.
                DataRow drFa = dt.NewRow();
                drFa[0] = string.Empty; drFa[1] = "FORTALEZAS / AMENAZAS"; drFa[2] = string.Empty; drFa[3] = string.Empty;
                dt.Rows.Add(drFa);

                //Se insertan los cruces FA.
                foreach (var dr in stBasicTable.Where(s => s.Type == "FA").OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Crossed; drNew[1] = dr.Strategy; drNew[2] = dr.Color; drNew[3] = dr.Level;
                    dt.Rows.Add(drNew);
                }

                //Fila DA.
                DataRow drDa = dt.NewRow();
                drDa[0] = string.Empty; drDa[1] = "DEBILIDADES / AMENAZAS"; drDa[2] = string.Empty; drDa[3] = string.Empty;
                dt.Rows.Add(drDa);

                //Se insertan los cruces DA.
                foreach (var dr in stBasicTable.Where(s => s.Type == "DA").OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Crossed; drNew[1] = dr.Strategy; drNew[2] = dr.Color; drNew[3] = dr.Level;
                    dt.Rows.Add(drNew);
                }
            }
            return dt;
        }

        public static DataTable GetManagerStDataFromDb(int projectId)
        {
            DataTable dt = new DataTable();
            List<tblManagerSt> managerStTable = new List<tblManagerSt>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                managerStTable = context.tblManagerSt.Where(s => s.IdProject == projectId && s.Level.Contains("1")).ToList();
            }

            if (managerStTable != null && managerStTable.Count > 0)
            {
                dt.Columns.Add("ESTRATEGIAS");
                dt.Columns.Add("DESARROLLO DE ESTRATEGIAS GERENCIALES");
                dt.Columns.Add("GRUPO");
                dt.Columns.Add("PERSPECTIVA");

                foreach (var dr in managerStTable.OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color; drNew[3] = dr.Perspective;
                    dt.Rows.Add(drNew);
                }

                ////Fila FO.
                //DataRow drFo = dt.NewRow();
                //drFo[0] = string.Empty; drFo[1] = "FORTALEZAS / OPORTUNIDADES"; drFo[2] = string.Empty;
                //dt.Rows.Add(drFo);

                ////Se insertan los cruces FO.
                //foreach (var dr in managerStTable.Where(s => s.Type == "FO").OrderBy(s => s.Id))
                //{
                //    DataRow drNew = dt.NewRow();
                //    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color;
                //    dt.Rows.Add(drNew);
                //}

                ////Fila DO.
                //DataRow drDo = dt.NewRow();
                //drDo[0] = string.Empty; drDo[1] = "DEBILIDADES / OPORTUNIDADES"; drDo[2] = string.Empty;
                //dt.Rows.Add(drDo);

                ////Se insertan los cruces DO.
                //foreach (var dr in managerStTable.Where(s => s.Type == "DO").OrderBy(s => s.Id))
                //{
                //    DataRow drNew = dt.NewRow();
                //    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color;
                //    dt.Rows.Add(drNew);
                //}

                ////Fila FA.
                //DataRow drFa = dt.NewRow();
                //drFa[0] = string.Empty; drFa[1] = "FORTALEZAS / AMENAZAS"; drFa[2] = string.Empty;
                //dt.Rows.Add(drFa);

                ////Se insertan los cruces FA.
                //foreach (var dr in managerStTable.Where(s => s.Type == "FA").OrderBy(s => s.Id))
                //{
                //    DataRow drNew = dt.NewRow();
                //    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color;
                //    dt.Rows.Add(drNew);
                //}

                ////Fila DA.
                //DataRow drDa = dt.NewRow();
                //drDa[0] = string.Empty; drDa[1] = "DEBILIDADES / AMENAZAS"; drDa[2] = string.Empty;
                //dt.Rows.Add(drDa);

                ////Se insertan los cruces DA.
                //foreach (var dr in managerStTable.Where(s => s.Type == "DA").OrderBy(s => s.Id))
                //{
                //    DataRow drNew = dt.NewRow();
                //    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color;
                //    dt.Rows.Add(drNew);
                //}
            }
            return dt;
        }

        public static DataTable GetMatrixLevelDataFromDb(int projectId, string level)
        {
            DataTable dt = new DataTable();
            List<tblManagerSt> managerStTable = new List<tblManagerSt>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                managerStTable = context.tblManagerSt.Where(s => s.IdProject == projectId && s.Level.Contains(level)).ToList();
            }

            if (managerStTable != null && managerStTable.Count > 0)
            {
                dt.Columns.Add("ESTRATEGIAS");
                if (level.Contains("1"))
                    dt.Columns.Add("DESARROLLO DE ESTRATEGIAS GERENCIALES");
                else if (level.Contains("2"))
                    dt.Columns.Add("DESARROLLO DE ESTRATEGIAS NIVEL 2");
                else if (level.Contains("3"))
                    dt.Columns.Add("DESARROLLO DE ESTRATEGIAS NIVEL 3");
                else if (level.Contains("4"))
                    dt.Columns.Add("DESARROLLO DE ESTRATEGIAS NIVEL 4");
                dt.Columns.Add("GRUPO");
                dt.Columns.Add("PERSPECTIVA");

                foreach (var dr in managerStTable.OrderBy(s => s.Id))
                {
                    DataRow drNew = dt.NewRow();
                    drNew[0] = dr.Strategies; drNew[1] = dr.ManagerStrategy; drNew[2] = dr.Color; drNew[3] = dr.Perspective;
                    dt.Rows.Add(drNew);
                }
            }
            return dt;
        }

        public static bool ClearAllProjectData(int projectId, bool deleteMaps)
        {
            bool result = false;

            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                var tblProjectMain = context.tblProject.Where(p => p.Id == projectId).FirstOrDefault();

                //Se elimina BSC de nivel 1,2,3 y 4.
                var tblBscDb = context.tblBsc.Where(s => s.IdProject == projectId).ToList();
                foreach (var row in tblBscDb)
                {
                    context.tblBsc.Remove(row);
                }
                context.SaveChanges();
                tblProjectMain.BscUpload1 = false;
                tblProjectMain.BscUpload2 = false;
                tblProjectMain.BscUpload3 = false;
                tblProjectMain.BscUpload4 = false;
                tblProjectMain.BscPubUpload1 = false;
                tblProjectMain.BscPubUpload2 = false;
                tblProjectMain.BscPubUpload3 = false;
                tblProjectMain.BscPubUpload4 = false;

                //Se eliminan datos de mapas estratégico.
                if (deleteMaps)
                {
                    var tblStMaps = context.tblDiagram.Where(s => s.IdProject == projectId).ToList();
                    foreach (var row in tblStMaps)
                    {
                        context.tblDiagram.Remove(row);
                    }
                    context.SaveChanges();
                }

                //Se elimina matriz de estrategias gerencial y de nivel 2,3 y 4.
                var tblManagerSt = context.tblManagerSt.Where(s => s.IdProject == projectId).ToList();
                foreach (var row in tblManagerSt)
                {
                    context.tblManagerSt.Remove(row);
                }
                context.SaveChanges();
                tblProjectMain.StrategiesManagerUpload = false;
                tblProjectMain.StrategiesLevel2Upload = false;
                tblProjectMain.StrategiesLevel3Upload = false;
                tblProjectMain.StrategiesLevel4Upload = false;

                //Se elimina matriz de estrategias básica.
                var tblStBasic = context.tblStrategiesBasic.Where(s => s.IdProject == projectId).ToList();
                foreach (var row in tblStBasic)
                {
                    context.tblStrategiesBasic.Remove(row);
                }
                context.SaveChanges();
                tblProjectMain.StrategiesBasicUpload = false;
                //Se elimina matriz Da y detalles.
                var tblDa = context.tblDa.Where(s => s.IdProject == projectId).FirstOrDefault();
                if (tblDa != null)
                {
                    var tblDaDetail = context.tblDaDetail.Where(s => s.IdDa == tblDa.Id).ToList();
                    foreach (var row in tblDaDetail)
                    {
                        context.tblDaDetail.Remove(row);
                    }
                    context.SaveChanges();
                    context.tblDa.Remove(tblDa);
                    tblProjectMain.DaUpload = false;
                    context.SaveChanges();
                }
                //Se elimina matriz Fa y detalles.
                var tblFa = context.tblFa.Where(s => s.IdProject == projectId).FirstOrDefault();
                if (tblFa != null)
                {
                    var tblFaDetail = context.tblFaDetail.Where(s => s.IdFa == tblFa.Id).ToList();
                    foreach (var row in tblFaDetail)
                    {
                        context.tblFaDetail.Remove(row);
                    }
                    context.SaveChanges();
                    context.tblFa.Remove(tblFa);
                    tblProjectMain.FaUpload = false;
                    context.SaveChanges();
                }
                //Se elimina matriz Do y detalles.
                var tblDo = context.tblDo.Where(s => s.IdProject == projectId).FirstOrDefault();
                if (tblDo != null)
                {
                    var tblDoDetail = context.tblDoDetail.Where(s => s.IdDo == tblDo.Id).ToList();
                    foreach (var row in tblDoDetail)
                    {
                        context.tblDoDetail.Remove(row);
                    }
                    context.SaveChanges();
                    context.tblDo.Remove(tblDo);
                    tblProjectMain.DoUpload = false;
                    context.SaveChanges();
                }
                //Se elimina matriz Fo y detalles.
                var tblFo = context.tblFo.Where(s => s.IdProject == projectId).FirstOrDefault();
                if (tblFo != null)
                {
                    var tblFoDetail = context.tblFoDetail.Where(s => s.IdFo == tblFo.Id).ToList();
                    foreach (var row in tblFoDetail)
                    {
                        context.tblFoDetail.Remove(row);
                    }
                    context.SaveChanges();
                    context.tblFo.Remove(tblFo);
                    tblProjectMain.FoUpload = false;
                    context.SaveChanges();
                }
                //Se elimina matriz Foda y detalles.
                var tblFoda = context.tblFoda.Where(s => s.IdProject == projectId).FirstOrDefault();
                if (tblFoda != null)
                {
                    var tblFodaDetail = context.tblFodaDetail.Where(s => s.IdFoda == tblFoda.Id).ToList();
                    foreach (var row in tblFodaDetail)
                    {
                        context.tblFodaDetail.Remove(row);
                    }
                    context.SaveChanges();
                    context.tblFoda.Remove(tblFoda);
                    tblProjectMain.FodaUpload = false;
                    context.SaveChanges();
                }

                result = true;
            }

            return result;
        }

        public static bool DeleteProject(int projectId)
        {
            bool result = false;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                var tblProject = context.tblProject.Where(p => p.Id == projectId).FirstOrDefault();
                //Se elimina matriz de estrategias gerencial.
                context.tblProject.Remove(tblProject);
                context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
