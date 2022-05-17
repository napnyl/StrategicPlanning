using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class OpenProject : Form
    {
        public bool projectOpened = false;
        public bool openCancelled = false;
        public string errorMessage = string.Empty;
        public int projectMainId = 0;
        public string projectMainName = string.Empty;
        public bool openFoda = false;
        public bool openFo = false;
        public bool openDo = false;
        public bool openFa = false;
        public bool openDa = false;
        public bool openStBasic = false;
        public bool openManagerSt = false;
        public bool openMatrixLevel2 = false;
        public bool openMatrixLevel3 = false;
        public bool openMatrixLevel4 = false;
        public bool openBscLevel1 = false;
        public bool openBscLevel2 = false;
        public bool openBscLevel3 = false;
        public bool openBscLevel4 = false;
        public bool openBscPubLevel1 = false;
        public bool openBscPubLevel2 = false;
        public bool openBscPubLevel3 = false;
        public bool openBscPubLevel4 = false;
        public DataTable dtProject = new DataTable();

        public OpenProject()
        {
            InitializeComponent();
        }

        private void btnCancelProject_Click(object sender, EventArgs e)
        {
            errorMessage = "La operación ha sido cancelada por el usuario!";
            openCancelled = true;
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                var projectRow = gvProjects.GetFocusedDataRow();
                if (projectRow != null && projectRow["Id"] != null)
                {
                    projectMainId = Convert.ToInt32(projectRow["Id"]);
                    dtProject = ProjectBL.GetProjectById(projectMainId);
                    projectMainName = dtProject.Rows[0]["Name"].ToString();
                    Main.projectMainVision = ProjectBL.GetProjectVision(projectMainId);
                    openFoda = Convert.ToBoolean(dtProject.Rows[0]["FodaUpload"]);
                    if (openFoda)
                        MatrixFODA.dtFoda = MatrixBL.GetFodaDataFromDb(projectMainId);
                    openFo = Convert.ToBoolean(dtProject.Rows[0]["FoUpload"]);
                    if (openFo)
                        MatrixFO.dtFO = MatrixBL.GetFoDataFromDb(projectMainId);
                    openDo = Convert.ToBoolean(dtProject.Rows[0]["DoUpload"]);
                    if (openDo)
                        MatrixDO.dtDO = MatrixBL.GetDoDataFromDb(projectMainId);
                    openFa = Convert.ToBoolean(dtProject.Rows[0]["FaUpload"]);
                    if (openFa)
                        MatrixFA.dtFA = MatrixBL.GetFaDataFromDb(projectMainId);
                    openDa = Convert.ToBoolean(dtProject.Rows[0]["DaUpload"]);
                    if (openDa)
                        MatrixDA.dtDA = MatrixBL.GetDaDataFromDb(projectMainId);
                    openStBasic = Convert.ToBoolean(dtProject.Rows[0]["StrategiesBasicUpload"]);
                    if (openStBasic)
                        MatrixStrategies.dtStrategies = MatrixBL.GetStBasicDataFromDb(projectMainId);
                    openManagerSt = Convert.ToBoolean(dtProject.Rows[0]["StrategiesManagerUpload"]);
                    if (openManagerSt)
                        MatrixManagerSt.dtManagerSt = MatrixBL.GetManagerStDataFromDb(projectMainId);
                    openMatrixLevel2 = Convert.ToBoolean(dtProject.Rows[0]["StrategiesLevel2Upload"]);
                    if (openMatrixLevel2)
                        MatrixLevel2.dtLevel2 = MatrixBL.GetMatrixLevelDataFromDb(projectMainId, "2");
                    openMatrixLevel3 = Convert.ToBoolean(dtProject.Rows[0]["StrategiesLevel3Upload"]);
                    if (openMatrixLevel3)
                        MatrixLevel3.dtLevel3 = MatrixBL.GetMatrixLevelDataFromDb(projectMainId, "3");
                    openMatrixLevel4 = Convert.ToBoolean(dtProject.Rows[0]["StrategiesLevel4Upload"]);
                    if (openMatrixLevel4)
                        MatrixLevel4.dtLevel4 = MatrixBL.GetMatrixLevelDataFromDb(projectMainId, "4");
                    openBscLevel1 = Convert.ToBoolean(dtProject.Rows[0]["BscUpload1"]);
                    if (openBscLevel1)
                        Main.dtBsc1Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 1, 1);
                    openBscLevel2 = Convert.ToBoolean(dtProject.Rows[0]["BscUpload2"]);
                    if (openBscLevel2)
                        Main.dtBsc2Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 2, 1);
                    openBscLevel3 = Convert.ToBoolean(dtProject.Rows[0]["BscUpload3"]);
                    if (openBscLevel3)
                        Main.dtBsc3Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 3, 1);
                    openBscLevel4 = Convert.ToBoolean(dtProject.Rows[0]["BscUpload4"]);
                    if (openBscLevel4)
                        Main.dtBsc4Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 4, 1);
                    openBscPubLevel1 = Convert.ToBoolean(dtProject.Rows[0]["BscPubUpload1"]);
                    if (openBscPubLevel1)
                        Main.dtBscPub1Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 1, 2);
                    openBscPubLevel2 = Convert.ToBoolean(dtProject.Rows[0]["BscPubUpload2"]);
                    if (openBscPubLevel2)
                        Main.dtBscPub2Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 2, 2);
                    openBscPubLevel3 = Convert.ToBoolean(dtProject.Rows[0]["BscPubUpload3"]);
                    if (openBscPubLevel3)
                        Main.dtBscPub3Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 3, 2);
                    openBscPubLevel4 = Convert.ToBoolean(dtProject.Rows[0]["BscPubUpload4"]);
                    if (openBscPubLevel4)
                        Main.dtBscPub4Temp = BscBL.GetBscLevelDataFromDb(projectMainId, 4, 2);
                    projectOpened = true;
                }
                else
                {
                    errorMessage = "Debe seleccionar un proyecto!";
                }
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                errorMessage = "Ha ocurrido un problema al abrir el proyecto!";
                SplashScreenManager.CloseForm();
            }
        }

        private void OpenProject_Load(object sender, EventArgs e)
        {
            int initLocationPoint = (Screen.PrimaryScreen.WorkingArea.Size.Height / 2) - (Screen.PrimaryScreen.WorkingArea.Size.Height / 2) / 2;
            this.Location = new Point(0, initLocationPoint);
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Size.Width;
            int heigthToSet = Screen.PrimaryScreen.WorkingArea.Size.Height / 2;
            this.Width = screenWidth;
            this.Height = heigthToSet;
            this.StartPosition = FormStartPosition.CenterScreen;

            SplashScreenManager.ShowForm(typeof(WaitForm1));
            gcProjects.DataSource = ProjectBL.GetProjectList();
            //gvProjects.BestFitColumns();
            SplashScreenManager.CloseForm();
        }

        private void gvProjects_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void gvProjects_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void gvProjects_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            btnOpenProject.Enabled = false;
            e.Graphics.DrawString("Aún no se ha ingresado ningún Proyecto!", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }

        private void gvProjects_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            // Check whether a row is right-clicked.
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();
                // Add menu item.
                DXMenuItem menuItemDeleteRow = new DXMenuItem("&Eliminar Proyecto",
              new EventHandler(OnDeleteRowClick), imageCollection1.Images[0]);
                menuItemDeleteRow.Tag = new RowInfo(view, rowHandle);
                e.Menu.Items.Add(menuItemDeleteRow);
                DXMenuItem menuItemEditRow = new DXMenuItem("&Editar Proyecto",
              new EventHandler(OnEditRowClick), imageCollection1.Images[1]);
                menuItemEditRow.Tag = new RowInfo(view, rowHandle);
                e.Menu.Items.Add(menuItemEditRow);
            }
        }

        // Create a submenu with a single DeleteRow item.
        DXMenuItem CreateRowSubMenu(GridView view, int rowHandle)
        {
            DXSubMenuItem subMenu = new DXSubMenuItem("Proyecto");
            DXMenuItem menuItemDeleteRow = new DXMenuItem("&Eliminar Proyecto",
              new EventHandler(OnDeleteRowClick), imageCollection1.Images[0]);
            menuItemDeleteRow.Tag = new RowInfo(view, rowHandle);
            subMenu.Items.Add(menuItemDeleteRow);
            return subMenu;
        }

        void OnDeleteRowClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("¿Está seguro que desea eliminar el proyecto seleccionado?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                DXMenuItem item = sender as DXMenuItem;
                RowInfo info = item.Tag as RowInfo;
                int num;
                if (gvProjects.GetFocusedDataRow() != null && gvProjects.GetFocusedDataRow().ItemArray.Count() > 0 && gvProjects.GetFocusedDataRow().ItemArray[0] != null && (int.TryParse(gvProjects.GetFocusedDataRow().ItemArray[0].ToString(), out num)))
                {
                    if (MatrixBL.ClearAllProjectData(Convert.ToInt32(gvProjects.GetFocusedDataRow().ItemArray[0]), true))
                    {
                        if (MatrixBL.DeleteProject(Convert.ToInt32(gvProjects.GetFocusedDataRow().ItemArray[0])))
                        {
                            info.View.DeleteRow(info.RowHandle);
                            SplashScreenManager.CloseForm();
                            XtraMessageBox.Show("El Proyecto ha sido eliminado satisfactoriamente.");
                        }
                        else
                        {
                            SplashScreenManager.CloseForm();
                            XtraMessageBox.Show("No se ha podido eliminar el proyecto!");
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm();
                        XtraMessageBox.Show("No se ha podido eliminar el proyecto!");
                    }
                }
            }
        }

        void OnEditRowClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("¿Está seguro que desea editar el proyecto seleccionado?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                DXMenuItem item = sender as DXMenuItem;
                RowInfo info = item.Tag as RowInfo;
                //info.View.DeleteRow(info.RowHandle);
                //Se elimina el proyecto de la base.
                int num;
                if (gvProjects.GetFocusedDataRow() != null && gvProjects.GetFocusedDataRow().ItemArray.Count() > 0 && gvProjects.GetFocusedDataRow().ItemArray[0] != null && (int.TryParse(gvProjects.GetFocusedDataRow().ItemArray[0].ToString(), out num)))
                {
                    Main.projectId = Convert.ToInt32(gvProjects.GetFocusedDataRow().ItemArray[0]);
                    EditProject editProject = new EditProject();
                    editProject.Text = "Edición de Proyecto";
                    editProject.ShowDialog();
                    if (!editProject.projectEdit)
                    {
                        XtraMessageBox.Show(editProject.errorMessage);
                        editProject.Close();
                    }
                    else
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1));
                        gcProjects.DataSource = ProjectBL.GetProjectList();
                        SplashScreenManager.CloseForm();
                    }
                    Main.projectId = 0;
                }
            }
        }

        //The class that stores menu specific information
        class RowInfo
        {
            public RowInfo(GridView view, int rowHandle)
            {
                this.RowHandle = rowHandle;
                this.View = view;
            }
            public GridView View;
            public int RowHandle;
        }
    }
}
