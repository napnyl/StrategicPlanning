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
    public partial class NewProject : Form
    {
        public bool projectSaved = false;
        public bool projectCancelled = false;
        public string errorMessage = string.Empty;
        public int projectMainId = 0;
        public NewProject()
        {
            InitializeComponent();
        }

        private void btnCancelProject_Click(object sender, EventArgs e)
        {
            errorMessage = "El usuario ha cancelado la creación del Proyecto!";
            projectCancelled = true;
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));

            //Se verifica que el nombre de proyecto no exista. NP
            if (txtProjectName.Text.Trim() == string.Empty || txtVision.Text.Trim() == string.Empty || txtDescription.Text.Trim() == string.Empty)
            {
                errorMessage = "El campo 'Nombre', 'Visión' y 'Descripción' son obligatorios!";
            }
            else
            {
                if (!ProjectBL.ProjectNameExists(txtProjectName.Text))
                {
                    Main.projectMainName = txtProjectName.Text.Trim();
                    Main.projectMainVision = txtVision.Text.Trim();
                    Main.projectMainDetail = txtDescription.Text.Trim();

                    projectMainId = ProjectBL.SaveMainProject(txtProjectName.Text.Trim(),txtVision.Text.Trim(), txtDescription.Text.Trim(), "User1");
                    projectSaved = true;
                }
                else
                {
                    errorMessage = "El nombre del proyecto ya existe!";
                }
            }
            SplashScreenManager.CloseForm();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            txtProjectName.Text = string.Empty;
            txtVision.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
