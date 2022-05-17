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
    public class ProjectBL
    {
        static bool rowNamed = false;
        public static int SaveMainProject(string projectName, string projectVision, string projectDescription, string userInsert)
        {
            int idProject = 0;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se inserta en tabla principal.
                tblProject project = new tblProject();
                project.Name = projectName;
                project.Vision = projectVision;
                project.Description = projectDescription;
                project.FodaUpload = false;
                project.FoUpload = false;
                project.DoUpload = false;
                project.FaUpload = false;
                project.DaUpload = false;
                project.StrategiesBasicUpload = false;
                project.StrategiesManagerUpload = false;
                project.UserInsert = userInsert;
                project.ComputerInsert = Dns.GetHostName();
                project.DateInsert = DateTime.Now;
                context.tblProject.Add(project);
                context.SaveChanges();
                idProject = (int)project.Id;
            }
            return idProject;
        }

        public static bool EditMainProject(int projectId, string projectName, string projectVision, string projectDescription, string userUpdate)
        {
            bool result = false;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                //Se edita tabla principal.
                var tblProject = context.tblProject.Where(p => p.Id == projectId).FirstOrDefault();
                tblProject.Name = projectName;
                tblProject.Vision = projectVision;
                tblProject.Description = projectDescription;
                tblProject.UserUpdate = userUpdate;
                tblProject.DateUpdate = DateTime.Now;
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public static DataTable GetProjectById(int projectId)
        {
            List<tblProject> tblProject = new List<tblProject>();
            DataTable dt = new DataTable();
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                tblProject = context.tblProject.Where(p => p.Id == projectId).ToList();
            }
            dt = DataTableBL.ToDataTable(tblProject);
            return dt;
        }

        public static DataTable GetProjectList()
        {
            List<tblProject> tblProject;
            DataTable dt = new DataTable();
            try
            {
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    tblProject = context.tblProject.ToList();
                }
                dt = DataTableBL.ToDataTable(tblProject);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public static string GetProjectVision(int projectId)
        {
            string projectVision = string.Empty;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                projectVision = context.tblProject.Where(p => p.Id == projectId).FirstOrDefault().Vision;
            }
            return projectVision;
        }

        public static bool ProjectNameExists(string projectName)
        {
            bool projectExists = false;
            List<tblProject> tblProject;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                tblProject = context.tblProject.ToList();
            }

            foreach (var row in tblProject)
            {
                if (row.Name.ToString().Trim().ToUpper() == projectName.Trim().ToUpper())
                {
                    projectExists = true;
                    break;
                }
            }

            return projectExists;
        }

        public static bool ProjectNameExistWithId(string projectName, int projectId)
        {
            bool projectExists = false;
            List<tblProject> tblProject;
            using (StLiteDBEntities context = new StLiteDBEntities())
            {
                tblProject = context.tblProject.ToList();
            }

            foreach (var row in tblProject)
            {
                if (row.Name.ToString().Trim().ToUpper() == projectName.Trim().ToUpper() && row.Id != projectId)
                {
                    projectExists = true;
                    break;
                }
            }

            return projectExists;
        }

    }
}
