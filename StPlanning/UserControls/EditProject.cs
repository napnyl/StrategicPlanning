using DevExpress.XtraSplashScreen;
using StPlanning.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StPlanning.UserControls
{
    public partial class EditProject : Form
    {
        public bool projectEdit = false;
        public bool projectCancelled = false;
        public string errorMessage = string.Empty;
        public int projectMainId = 0;
        public EditProject()
        {
            InitializeComponent();
        }

        private void btnCancelProject_Click(object sender, EventArgs e)
        {
            errorMessage = "El usuario ha cancelado la edición del Proyecto!";
            projectCancelled = true;
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            //Se verifica que el nombre de proyecto no exista. NP
            if (txtProjectName.Text.Trim() == string.Empty || txtVision.Text.Trim() == string.Empty || txtDescription.Text.Trim() == string.Empty)
            {
                errorMessage = "El campo 'Nombre' y 'Descripción' son obligatorios!";
            }
            else
            {
                if (!ProjectBL.ProjectNameExistWithId(txtProjectName.Text, Main.projectId))
                {
                    //Se edita el nombre y desc. del proyecto.
                    if (ProjectBL.EditMainProject(Main.projectId, txtProjectName.Text, txtVision.Text, txtDescription.Text, "User1"))
                        projectEdit = true;
                }
                else
                {
                    errorMessage = "El nombre del proyecto ya existe!";
                }
            }
            SplashScreenManager.CloseForm();
        }

        private void EditProject_Load(object sender, EventArgs e)
        {
            DataTable project = ProjectBL.GetProjectById(Main.projectId);
            if (project != null && project.Rows.Count > 0)
            {
                txtProjectName.Text = project.Rows[0]["Name"].ToString();
                txtVision.Text = project.Rows[0]["Vision"].ToString();
                txtDescription.Text = project.Rows[0]["Description"].ToString();
            }
        }
    }
}
