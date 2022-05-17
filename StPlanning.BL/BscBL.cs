using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StPlanning.DB;
using DevExpress.XtraEditors;
using System.Net;

namespace StPlanning.BL
{
    public class BscBL
    {
        public static bool SaveBscMatrix(DataTable dt, int idProject, int mainLevel, int type)
        {
            bool result = false;

            try
            {
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 2)
                        {
                            tblBsc bsc = new tblBsc();
                            bsc.IdProject = idProject;
                            bsc.MainLevel = mainLevel;
                            bsc.Type = type;
                            bsc.Perspective = dt.Rows[i][0].ToString();
                            bsc.StObjectives = dt.Rows[i][2].ToString();
                            if (dt.Rows[i][1] != DBNull.Value && dt.Rows[i][1] != null && dt.Rows[i][1].ToString() != string.Empty)
                                bsc.ValueSt = dt.Rows[i][1].ToString();
                            if (dt.Rows[i][3] != DBNull.Value && dt.Rows[i][3] != null && dt.Rows[i][3].ToString() != string.Empty)
                                bsc.Kpis = dt.Rows[i][3].ToString();
                            if (dt.Rows[i][4] != DBNull.Value && dt.Rows[i][4] != null && dt.Rows[i][4].ToString() != string.Empty)
                                bsc.OpDefinition = dt.Rows[i][4].ToString();
                            if (dt.Rows[i][5] != DBNull.Value && dt.Rows[i][5] != null && dt.Rows[i][5].ToString() != string.Empty)
                                bsc.ActuationFreq = dt.Rows[i][5].ToString();
                            if (dt.Rows[i][6] != DBNull.Value && dt.Rows[i][6] != null && dt.Rows[i][6].ToString() != string.Empty)
                                bsc.CaptDataFreq = dt.Rows[i][6].ToString();
                            if (dt.Rows[i][7] != DBNull.Value && dt.Rows[i][7] != null && dt.Rows[i][7].ToString() != string.Empty)
                                bsc.Levels = dt.Rows[i][7].ToString();
                            if (dt.Rows[i][8] != DBNull.Value && dt.Rows[i][8] != null && dt.Rows[i][8].ToString() != string.Empty)
                                bsc.Goal = dt.Rows[i][8].ToString();
                            if (dt.Rows[i][9] != DBNull.Value && dt.Rows[i][9] != null && dt.Rows[i][9].ToString() != string.Empty)
                                bsc.RedVar = dt.Rows[i][9].ToString();
                            if (dt.Rows[i][10] != DBNull.Value && dt.Rows[i][10] != null && dt.Rows[i][10].ToString() != string.Empty)
                                bsc.YellVar = dt.Rows[i][10].ToString();
                            if (dt.Rows[i][11] != DBNull.Value && dt.Rows[i][11] != null && dt.Rows[i][11].ToString() != string.Empty)
                                bsc.GreVar = dt.Rows[i][11].ToString();
                            if (dt.Rows[i][12] != DBNull.Value && dt.Rows[i][12] != null && dt.Rows[i][12].ToString() != string.Empty)
                                bsc.GoalResp = dt.Rows[i][12].ToString();
                            if (dt.Rows[i][13] != DBNull.Value && dt.Rows[i][13] != null && dt.Rows[i][13].ToString() != string.Empty)
                                bsc.StInitiative = dt.Rows[i][13].ToString();
                            if (dt.Rows[i][14] != DBNull.Value && dt.Rows[i][14] != null && dt.Rows[i][14].ToString() != string.Empty)
                                bsc.ImpleResp = dt.Rows[i][14].ToString();
                            if (dt.Rows[i][15] != DBNull.Value && dt.Rows[i][15] != null && dt.Rows[i][15].ToString() != string.Empty)
                                bsc.DateInit = Convert.ToDateTime(dt.Rows[i][15]);
                            if (dt.Rows[i][16] != DBNull.Value && dt.Rows[i][16] != null && dt.Rows[i][16].ToString() != string.Empty)
                                bsc.DateEnd = Convert.ToDateTime(dt.Rows[i][16]);

                            context.tblBsc.Add(bsc);
                        }
                    }

                    result = true;

                    var tblProjectMain = context.tblProject.Where(p => p.Id == idProject).FirstOrDefault();
                    if (mainLevel == 1 && type == 1)
                        tblProjectMain.BscUpload1 = true;
                    else if (mainLevel == 2 && type == 1)
                        tblProjectMain.BscUpload2 = true;
                    else if (mainLevel == 3 && type == 1)
                        tblProjectMain.BscUpload3 = true;
                    else if (mainLevel == 4 && type == 1)
                        tblProjectMain.BscUpload4 = true;
                    else if (mainLevel == 1 && type == 2)
                        tblProjectMain.BscPubUpload1 = true;
                    else if (mainLevel == 2 && type == 2)
                        tblProjectMain.BscPubUpload2 = true;
                    else if (mainLevel == 3 && type == 2)
                        tblProjectMain.BscPubUpload3 = true;
                    else if (mainLevel == 4 && type == 2)
                        tblProjectMain.BscPubUpload4 = true;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static DataTable GetBscLevelDataFromDb(int projectId, int mainLevel, int type)
        {
            DataTable dt = new DataTable();
            List<tblBsc> bscTable = new List<tblBsc>();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                bscTable = context.tblBsc.Where(s => s.IdProject == projectId && s.MainLevel == mainLevel && s.Type == type).ToList();
            }

            if (bscTable != null && bscTable.Count > 0)
            {
                dt = DataTableBL.ToDataTable(bscTable);
            }
            return dt;
        }

    }
}
