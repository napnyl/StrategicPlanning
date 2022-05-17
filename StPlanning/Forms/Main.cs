using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using StPlanning.BL;
using StPlanning.UserControls;
using StPlanning.WorkFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StPlanning
{
    public partial class Main : Form
    {
        public static string projectMainName = string.Empty;
        public static string projectMainVision = string.Empty;
        public static string projectMainDetail = string.Empty;
        public static int projectId = 0;
        public static bool closeFromMain = false;
        public static bool projectSaved = false;
        public static DataTable dtBsc1Temp = new DataTable();
        public static DataTable dtBsc2Temp = new DataTable();
        public static DataTable dtBsc3Temp = new DataTable();
        public static DataTable dtBsc4Temp = new DataTable();
        public static DataTable dtBscPub1Temp = new DataTable();
        public static DataTable dtBscPub2Temp = new DataTable();
        public static DataTable dtBscPub3Temp = new DataTable();
        public static DataTable dtBscPub4Temp = new DataTable();

        MatrixFODA mFoda = new MatrixFODA();
        MatrixFO mFo = new MatrixFO();
        MatrixDO mDo = new MatrixDO();
        MatrixFA mFa = new MatrixFA();
        MatrixDA mDa = new MatrixDA();
        MatrixStrategies mSt = new MatrixStrategies();
        MatrixManagerSt mManagerSt = new MatrixManagerSt();
        MatrixLevel2 mLevel2 = new MatrixLevel2();
        MatrixLevel3 mLevel3 = new MatrixLevel3();
        MatrixLevel4 mLevel4 = new MatrixLevel4();
        frmDiagramTest fDiagram;
        BscLevel1 bscLvl1 = new BscLevel1(null, 1);
        BscLevel2 bscLvl2 = new BscLevel2(null);
        BscLevel3 bscLvl3 = new BscLevel3(null);
        BscLevel4 bscLvl4 = new BscLevel4(null);
        BscPubLevel1 bscPubLvl1 = new BscPubLevel1(null, 2);
        BscPubLevel2 bscPubLvl2 = new BscPubLevel2(null, 2);
        BscPubLevel3 bscPubLvl3 = new BscPubLevel3(null, 2);
        BscPubLevel4 bscPubLvl4 = new BscPubLevel4(null, 2);

        public Main()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-EC");
            InitializeComponent();
            Thread.Sleep(1500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            barTime.Caption = DateTime.Now.ToString("HH:mm:ss");
            InitScreen iScreen = new InitScreen();
            iScreen.Text = "Bienvenido";
            iScreen.MdiParent = this;
            iScreen.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barTime.Caption = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnFoda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                mFoda = new MatrixFODA();
                mFoda.Text = "Matriz FODA";
                mFoda.MdiParent = this;
                mFoda.Show();
                if (mFoda.dataShown)
                {
                    btnFoda.Enabled = false;
                    SplashScreenManager.CloseForm();
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    XtraMessageBox.Show(mFoda.errorMessage);
                    closeFromMain = true;
                    mFoda.Close();
                    closeFromMain = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnFO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Se actualiza el grid de la matriz.
                mFoda.gridView1.CloseEditor();
                mFoda.gridView1.UpdateCurrentRow();

                SplashScreenManager.ShowForm(typeof(WaitForm1));
                mFo = new MatrixFO();
                mFo.Text = "Matriz FO";
                mFo.MdiParent = this;
                mFo.Show();
                if (mFo.foShown)
                {
                    btnFO.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mFo.errorMessage);
                    closeFromMain = true;
                    mFo.Close();
                    closeFromMain = false;
                }
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Se actualiza el grid de la matriz.
                mFoda.gridView1.CloseEditor();
                mFoda.gridView1.UpdateCurrentRow();

                SplashScreenManager.ShowForm(typeof(WaitForm1));
                mDo = new MatrixDO();
                mDo.Text = "Matriz DO";
                mDo.MdiParent = this;
                mDo.Show();
                if (mDo.doShown)
                {
                    btnDO.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mFo.errorMessage);
                    closeFromMain = true;
                    mDo.Close();
                    closeFromMain = false;
                }
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnFA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Se actualiza el grid de la matriz.
                mFoda.gridView1.CloseEditor();
                mFoda.gridView1.UpdateCurrentRow();

                SplashScreenManager.ShowForm(typeof(WaitForm1));
                mFa = new MatrixFA();
                mFa.Text = "Matriz FA";
                mFa.MdiParent = this;
                mFa.Show();
                if (mFa.faShown)
                {
                    btnFA.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mFo.errorMessage);
                    closeFromMain = true;
                    mFa.Close();
                    closeFromMain = false;
                }
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Se actualiza el grid de la matriz.
                mFoda.gridView1.CloseEditor();
                mFoda.gridView1.UpdateCurrentRow();

                SplashScreenManager.ShowForm(typeof(WaitForm1));
                mDa = new MatrixDA();
                mDa.Text = "Matriz DA";
                mDa.MdiParent = this;
                mDa.Show();
                if (mDa.daShown)
                {
                    btnDA.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mFo.errorMessage);
                    closeFromMain = true;
                    mDa.Close();
                    closeFromMain = false;
                }
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnStrategies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mFo.gridView1.CloseEditor();
            mFo.gridView1.UpdateCurrentRow();
            mDo.gridView1.CloseEditor();
            mDo.gridView1.UpdateCurrentRow();
            mFa.gridView1.CloseEditor();
            mFa.gridView1.UpdateCurrentRow();
            mDa.gridView1.CloseEditor();
            mDa.gridView1.UpdateCurrentRow();

            //Se verifica que existan las matrices FO,DO,FA,DA con datos, para poder continuar.
            if (MatrixFO.dtFO != null && MatrixFO.dtFO.Rows.Count > 0 && MatrixDO.dtDO != null && MatrixDO.dtDO.Rows.Count > 0 && MatrixFA.dtFA != null && MatrixFA.dtFA.Rows.Count > 0 && MatrixDA.dtDA != null && MatrixDA.dtDA.Rows.Count > 0
                && (mFo.CountStrategiesNumber() > 0 && mDo.CountStrategiesNumber() > 0 && mFa.CountStrategiesNumber() > 0 && mDa.CountStrategiesNumber() > 0))
            {
                mSt = new MatrixStrategies();
                mSt.Text = "Matriz de Estratégias Básica";
                mSt.MdiParent = this;
                mSt.Show();
                if (mSt.stShown)
                {
                    btnStrategies.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mSt.errorMessage);
                    closeFromMain = true;
                    mSt.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en todas las matrices preliminares antes de continuar!.");
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));

                #region Se actualizan tablas antes de guardar.
                mFoda.gridView1.CloseEditor();
                mFoda.gridView1.UpdateCurrentRow();
                mFo.gridView1.CloseEditor();
                mFo.gridView1.UpdateCurrentRow();
                mDo.gridView1.CloseEditor();
                mDo.gridView1.UpdateCurrentRow();
                mFa.gridView1.CloseEditor();
                mFa.gridView1.UpdateCurrentRow();
                mDa.gridView1.CloseEditor();
                mDa.gridView1.UpdateCurrentRow();
                mSt.gridView1.CloseEditor();
                mSt.gridView1.UpdateCurrentRow();
                mManagerSt.gridView1.CloseEditor();
                mManagerSt.gridView1.UpdateCurrentRow();
                mLevel2.gridView1.CloseEditor();
                mLevel2.gridView1.UpdateCurrentRow();
                mLevel3.gridView1.CloseEditor();
                mLevel3.gridView1.UpdateCurrentRow();
                mLevel4.gridView1.CloseEditor();
                mLevel4.gridView1.UpdateCurrentRow();
                bscLvl1.gridView1.CloseEditor();
                bscLvl1.gridView1.UpdateCurrentRow();
                bscLvl2.gridView1.CloseEditor();
                bscLvl2.gridView1.UpdateCurrentRow();
                bscLvl3.gridView1.CloseEditor();
                bscLvl3.gridView1.UpdateCurrentRow();
                bscLvl4.gridView1.CloseEditor();
                bscLvl4.gridView1.UpdateCurrentRow();
                bscPubLvl1.gridView1.CloseEditor();
                bscPubLvl1.gridView1.UpdateCurrentRow();
                bscPubLvl2.gridView1.CloseEditor();
                bscPubLvl2.gridView1.UpdateCurrentRow();
                bscPubLvl3.gridView1.CloseEditor();
                bscPubLvl3.gridView1.UpdateCurrentRow();
                bscPubLvl4.gridView1.CloseEditor();
                bscPubLvl4.gridView1.UpdateCurrentRow();
                #endregion Se actualizan tablas antes de guardar.

                //Se eliminan asignaciones anteriores.
                MatrixBL.ClearAllProjectData(projectId, false);

                if (MatrixFODA.dtFoda != null && MatrixFODA.dtFoda.Rows.Count > 0)
                {
                    int idFoda = MatrixBL.SaveFodaData(MatrixFODA.dtFoda, projectId);
                }

                if (MatrixFO.dtFO != null && MatrixFO.dtFO.Rows.Count > 0)
                {
                    MatrixBL.SaveFoData(MatrixFO.dtFO, projectId);
                }

                if (MatrixDO.dtDO != null && MatrixDO.dtDO.Rows.Count > 0)
                {
                    MatrixBL.SaveDoData(MatrixDO.dtDO, projectId);
                }

                if (MatrixFA.dtFA != null && MatrixFA.dtFA.Rows.Count > 0)
                {
                    MatrixBL.SaveFaData(MatrixFA.dtFA, projectId);
                }

                if (MatrixDA.dtDA != null && MatrixDA.dtDA.Rows.Count > 0)
                {
                    MatrixBL.SaveDaData(MatrixDA.dtDA, projectId);
                }

                if (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0)
                {
                    MatrixBL.SaveStrategiesData(MatrixStrategies.dtStrategies, projectId);
                }

                if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0)
                {
                    MatrixBL.SaveManagerStData(MatrixManagerSt.dtManagerSt, projectId, "Nivel 1");
                }

                if (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0)
                {
                    MatrixBL.SaveManagerStData(MatrixLevel2.dtLevel2, projectId, "Nivel 2");
                }

                if (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0)
                {
                    MatrixBL.SaveManagerStData(MatrixLevel3.dtLevel3, projectId, "Nivel 3");
                }

                if (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0)
                {
                    MatrixBL.SaveManagerStData(MatrixLevel4.dtLevel4, projectId, "Nivel 4");
                }

                if (BscLevel1.dtBscLevel1 != null && BscLevel1.dtBscLevel1.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscLevel1.dtBscLevel1, projectId, 1, 1);
                }

                if (BscLevel2.dtBscLevel2 != null && BscLevel2.dtBscLevel2.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscLevel2.dtBscLevel2, projectId, 2, 1);
                }

                if (BscLevel3.dtBscLevel3 != null && BscLevel3.dtBscLevel3.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscLevel3.dtBscLevel3, projectId, 3, 1);
                }

                if (BscLevel4.dtBscLevel4 != null && BscLevel4.dtBscLevel4.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscLevel4.dtBscLevel4, projectId, 4, 1);
                }

                if (BscPubLevel1.dtBscLevel1 != null && BscPubLevel1.dtBscLevel1.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscPubLevel1.dtBscLevel1, projectId, 1, 2);
                }

                if (BscPubLevel2.dtBscLevel2 != null && BscPubLevel2.dtBscLevel2.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscPubLevel2.dtBscLevel2, projectId, 2, 2);
                }

                if (BscPubLevel3.dtBscLevel3 != null && BscPubLevel3.dtBscLevel3.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscPubLevel3.dtBscLevel3, projectId, 3, 2);
                }

                if (BscPubLevel4.dtBscLevel4 != null && BscPubLevel4.dtBscLevel4.Rows.Count > 0)
                {
                    BscBL.SaveBscMatrix(BscPubLevel4.dtBscLevel4, projectId, 4, 2);
                }

                SplashScreenManager.CloseForm();
                projectSaved = true;
                XtraMessageBox.Show("Los datos se han guardado con éxito.");
            }
            catch (Exception ex)
            {

            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (projectId != 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro que desea cerrar el proyecto actual?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        MatrixRibbonInit();
                        if (!projectSaved)
                            btnSave_ItemClick(null, null);
                        CloseOpened();
                        projectId = 0;
                        CreateNewProject();
                    }
                }
                else
                {
                    CreateNewProject();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (projectId != 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro que desea cerrar el proyecto actual?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        MatrixRibbonInit();
                        if (!projectSaved)
                            btnSave_ItemClick(null, null);
                        CloseOpened();
                        projectId = 0;
                        OpenProject();
                    }
                }
                else
                {
                    OpenProject();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CloseOpened()
        {
            try
            {
                MatrixFODA.dtFoda = new DataTable();
                MatrixFO.dtFO = new DataTable();
                MatrixDO.dtDO = new DataTable();
                MatrixFA.dtFA = new DataTable();
                MatrixDA.dtDA = new DataTable();
                MatrixStrategies.dtStrategies = new DataTable();
                MatrixManagerSt.dtManagerSt = new DataTable();
                MatrixLevel2.dtLevel2 = new DataTable();
                MatrixLevel3.dtLevel3 = new DataTable();
                MatrixLevel4.dtLevel4 = new DataTable();
                BscLevel1.dtBscLevel1 = new DataTable();
                BscLevel2.dtBscLevel2 = new DataTable();
                BscLevel3.dtBscLevel3 = new DataTable();
                BscLevel4.dtBscLevel4 = new DataTable();

                closeFromMain = true;

                if (mFoda.Visible)
                    mFoda.Close();
                if (mFo.Visible)
                    mFo.Close();
                if (mDo.Visible)
                    mDo.Close();
                if (mFa.Visible)
                    mFa.Close();
                if (mDa.Visible)
                    mDa.Close();
                if (mSt.Visible)
                    mSt.Close();
                if (mManagerSt.Visible)
                    mManagerSt.Close();
                if (mLevel2.Visible)
                    mLevel2.Close();
                if (mLevel3.Visible)
                    mLevel3.Close();
                if (mLevel4.Visible)
                    mLevel4.Close();
                if (bscLvl1.Visible)
                    bscLvl1.Close();
                if (bscLvl2.Visible)
                    bscLvl2.Close();
                if (bscLvl3.Visible)
                    bscLvl3.Close();
                if (bscLvl4.Visible)
                    bscLvl4.Close();
                if (bscPubLvl1.Visible)
                    bscPubLvl1.Close();
                if (bscPubLvl2.Visible)
                    bscPubLvl2.Close();
                if (bscPubLvl3.Visible)
                    bscPubLvl3.Close();
                if (bscPubLvl4.Visible)
                    bscPubLvl4.Close();
                closeFromMain = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void CreateNewProject()
        {
            try
            {
                NewProject np = new NewProject();
                if (projectMainName != string.Empty || projectMainDetail != string.Empty)
                {
                    np.txtProjectName.Text = projectMainName;
                    np.txtDescription.Text = projectMainDetail;
                }
                np.ShowDialog();
                if (!np.projectCancelled)
                {
                    if (!np.projectSaved)
                    {
                        XtraMessageBox.Show(np.errorMessage);
                        btnNew_ItemClick(null, null);
                    }
                    else
                    {
                        projectId = np.projectMainId;
                        XtraMessageBox.Show("El proyecto se ha guardado exitosamente.");
                        projectSaved = true;
                        lblProjectNameStatus.Caption = "<b>Proyecto:</b> " + np.txtProjectName.Text;
                        np.Close();

                        //Si se guarda el proyecto se debe habilitar los controles de matriz y guardado.
                        rpMatrix.Visible = true;
                        rpDataControl.Visible = true;
                        rpDiagrams.Visible = true;
                        rpBsc.Visible = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show(np.errorMessage);
                    np.Close();
                }
                closeFromMain = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ha ocurrido un problema al crear un nuevo proyecto!");
            }
        }

        private void MatrixRibbonInit()
        {
            try
            {
                rpMatrix.Visible = false;
                rpDataControl.Visible = false;
                rpDiagrams.Visible = false;
                rpBsc.Visible = false;
                lblProjectNameStatus.Caption = string.Empty;
                lblFoStrategies.Caption = string.Empty;
                ribbonControl1.StatusBar.ItemLinks[3].BeginGroup = false;
                lblDoStrategies.Caption = string.Empty;
                ribbonControl1.StatusBar.ItemLinks[4].BeginGroup = false;
                lblFaStrategies.Caption = string.Empty;
                ribbonControl1.StatusBar.ItemLinks[5].BeginGroup = false;
                lblDaStrategies.Caption = string.Empty;
                ribbonControl1.StatusBar.ItemLinks[6].BeginGroup = false;

                btnFoda.Enabled = true;
                btnFO.Enabled = true;
                btnDO.Enabled = true;
                btnFA.Enabled = true;
                btnDA.Enabled = true;
                btnStrategies.Enabled = true;
                btnManagerSt.Enabled = true;
                btnManagerLevel2.Enabled = true;
                btnManagerLevel3.Enabled = true;
                btnManagerLevel4.Enabled = true;
                btnDiagramPrivate.Enabled = true;
                btnDiagramPublic.Enabled = true;
                btnBscLevel1.Enabled = true;
                btnBscLevel2.Enabled = true;
                btnBscLevel3.Enabled = true;
                btnBscLevel4.Enabled = true;
                btnPublicBscLevel1.Enabled = true;
                btnPublicBscLevel2.Enabled = true;
                btnPublicBscLevel3.Enabled = true;
                btnPublicBscLevel4.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenProject()
        {
            try
            {
                OpenProject op = new OpenProject();
                op.ShowDialog();
                if (!op.openCancelled)
                {
                    if (!op.projectOpened)
                    {
                        XtraMessageBox.Show(op.errorMessage);
                        btnOpen_ItemClick(null, null);
                    }
                    else
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1));
                        projectId = op.projectMainId;
                        if (op.openFoda)
                        {
                            mFoda = new MatrixFODA();
                            mFoda.Text = "Matriz FODA";
                            mFoda.MdiParent = this;
                            mFoda.fromDb = true;
                            mFoda.Show();
                            mFoda.gridControl1.DataSource = MatrixFODA.dtFoda;
                            //Se separan tablas F,O,D,A para mejor manejo.
                            SeparateFodaMatrix(MatrixFODA.dtFoda);
                            btnFoda.Enabled = false;
                        }
                        else
                            btnFoda.Enabled = true;
                        if (op.openFo)
                        {
                            mFo = new MatrixFO();
                            mFo.Text = "Matriz FO";
                            mFo.MdiParent = this;
                            mFo.fromDb = true;
                            mFo.Show();
                            mFo.gridControl1.DataSource = MatrixFO.dtFO;
                            btnFO.Enabled = false;
                            mFo.SetStrategiesNumber();
                        }
                        else
                            btnFO.Enabled = true;
                        if (op.openDo)
                        {
                            mDo = new MatrixDO();
                            mDo.Text = "Matriz DO";
                            mDo.MdiParent = this;
                            mDo.fromDb = true;
                            mDo.Show();
                            mDo.gridControl1.DataSource = MatrixDO.dtDO;
                            btnDO.Enabled = false;
                            mDo.SetStrategiesNumber();
                        }
                        else
                            btnDO.Enabled = true;
                        if (op.openFa)
                        {
                            mFa = new MatrixFA();
                            mFa.Text = "Matriz FA";
                            mFa.MdiParent = this;
                            mFa.fromDb = true;
                            mFa.Show();
                            mFa.gridControl1.DataSource = MatrixFA.dtFA;
                            btnFA.Enabled = false;
                            mFa.SetStrategiesNumber();
                        }
                        else
                            btnFA.Enabled = true;
                        if (op.openDa)
                        {
                            mDa = new MatrixDA();
                            mDa.Text = "Matriz DA";
                            mDa.MdiParent = this;
                            mDa.fromDb = true;
                            mDa.Show();
                            mDa.gridControl1.DataSource = MatrixDA.dtDA;
                            btnDA.Enabled = false;
                            mDa.SetStrategiesNumber();
                        }
                        else
                            btnDA.Enabled = true;
                        if (op.openStBasic)
                        {
                            mSt = new MatrixStrategies();
                            mSt.Text = "Estratégias Básicas";
                            mSt.MdiParent = this;
                            mSt.fromDb = true;
                            mSt.Show();
                            mSt.gridControl1.DataSource = MatrixStrategies.dtStrategies;
                            mSt.gridView1.BestFitColumns();
                            btnStrategies.Enabled = false;
                        }
                        else
                            btnStrategies.Enabled = true;

                        if (op.openManagerSt)
                        {
                            mManagerSt = new MatrixManagerSt();
                            mManagerSt.Text = "Estratégias Gerenciales";
                            mManagerSt.MdiParent = this;
                            mManagerSt.fromDb = true;
                            mManagerSt.Show();
                            mManagerSt.gridControl1.DataSource = MatrixManagerSt.dtManagerSt;
                            mManagerSt.gridView1.BestFitColumns();
                            btnManagerSt.Enabled = false;
                        }
                        else
                            btnManagerSt.Enabled = true;

                        if (op.openMatrixLevel2)
                        {
                            mLevel2 = new MatrixLevel2();
                            mLevel2.Text = "Estratégias N2";
                            mLevel2.MdiParent = this;
                            mLevel2.fromDb = true;
                            mLevel2.Show();
                            mLevel2.gridControl1.DataSource = MatrixLevel2.dtLevel2;
                            mLevel2.gridView1.BestFitColumns();
                            btnManagerLevel2.Enabled = false;
                        }
                        else
                            btnManagerLevel2.Enabled = true;

                        if (op.openMatrixLevel3)
                        {
                            mLevel3 = new MatrixLevel3();
                            mLevel3.Text = "Estratégias N3";
                            mLevel3.MdiParent = this;
                            mLevel3.fromDb = true;
                            mLevel3.Show();
                            mLevel3.gridControl1.DataSource = MatrixLevel3.dtLevel3;
                            mLevel3.gridView1.BestFitColumns();
                            btnManagerLevel3.Enabled = false;
                        }
                        else
                            btnManagerLevel3.Enabled = true;

                        if (op.openMatrixLevel4)
                        {
                            mLevel4 = new MatrixLevel4();
                            mLevel4.Text = "Estratégias N4";
                            mLevel4.MdiParent = this;
                            mLevel4.fromDb = true;
                            mLevel4.Show();
                            mLevel4.gridControl1.DataSource = MatrixLevel4.dtLevel4;
                            mLevel4.gridView1.BestFitColumns();
                            btnManagerLevel4.Enabled = false;
                        }
                        else
                            btnManagerLevel4.Enabled = true;

                        if (op.openBscLevel1)
                        {
                            if (dtBsc1Temp != null && dtBsc1Temp.Rows.Count > 0)
                                bscLvl1 = new BscLevel1(dtBsc1Temp, 1);
                            else
                                bscLvl1 = new BscLevel1(null, 1);
                            bscLvl1.Text = "BSC N1";
                            bscLvl1.MdiParent = this;
                            bscLvl1.fromDb = true;
                            bscLvl1.Show();
                            bscLvl1.gridControl1.DataSource = BscLevel1.dtBscLevel1;
                            bscLvl1.gridView1.BestFitColumns();
                            btnBscLevel1.Enabled = false;
                        }
                        else
                            btnBscLevel1.Enabled = true;

                        if (op.openBscLevel2)
                        {
                            if (dtBsc2Temp != null && dtBsc2Temp.Rows.Count > 0)
                                bscLvl2 = new BscLevel2(dtBsc2Temp);
                            else
                                bscLvl2 = new BscLevel2(null);
                            bscLvl2.Text = "BSC N2";
                            bscLvl2.MdiParent = this;
                            bscLvl2.fromDb = true;
                            bscLvl2.Show();
                            bscLvl2.gridControl1.DataSource = BscLevel2.dtBscLevel2;
                            bscLvl2.gridView1.BestFitColumns();
                            btnBscLevel2.Enabled = false;
                        }
                        else
                            btnBscLevel2.Enabled = true;

                        if (op.openBscLevel3)
                        {
                            if (dtBsc3Temp != null && dtBsc3Temp.Rows.Count > 0)
                                bscLvl3 = new BscLevel3(dtBsc3Temp);
                            else
                                bscLvl3 = new BscLevel3(null);
                            bscLvl3.Text = "BSC N3";
                            bscLvl3.MdiParent = this;
                            bscLvl3.fromDb = true;
                            bscLvl3.Show();
                            bscLvl3.gridControl1.DataSource = BscLevel3.dtBscLevel3;
                            bscLvl3.gridView1.BestFitColumns();
                            btnBscLevel3.Enabled = false;
                        }
                        else
                            btnBscLevel3.Enabled = true;

                        if (op.openBscLevel4)
                        {
                            if (dtBsc4Temp != null && dtBsc4Temp.Rows.Count > 0)
                                bscLvl4 = new BscLevel4(dtBsc4Temp);
                            else
                                bscLvl4 = new BscLevel4(null);
                            bscLvl4.Text = "BSC N4";
                            bscLvl4.MdiParent = this;
                            bscLvl4.fromDb = true;
                            bscLvl4.Show();
                            bscLvl4.gridControl1.DataSource = BscLevel4.dtBscLevel4;
                            bscLvl4.gridView1.BestFitColumns();
                            btnBscLevel4.Enabled = false;
                        }
                        else
                            btnBscLevel4.Enabled = true;

                        if (op.openBscPubLevel1)
                        {
                            if (dtBscPub1Temp != null && dtBscPub1Temp.Rows.Count > 0)
                                bscPubLvl1 = new BscPubLevel1(dtBscPub1Temp, 2);
                            else
                                bscPubLvl1 = new BscPubLevel1(null, 2);
                            bscPubLvl1.Text = "BSC Pub N1";
                            bscPubLvl1.MdiParent = this;
                            bscPubLvl1.fromDb = true;
                            bscPubLvl1.Show();
                            bscPubLvl1.gridControl1.DataSource = BscPubLevel1.dtBscLevel1;
                            bscPubLvl1.gridView1.BestFitColumns();
                            btnPublicBscLevel1.Enabled = false;
                        }
                        else
                            btnPublicBscLevel1.Enabled = true;

                        if (op.openBscPubLevel2)
                        {
                            if (dtBscPub2Temp != null && dtBscPub2Temp.Rows.Count > 0)
                                bscPubLvl2 = new BscPubLevel2(dtBscPub2Temp, 2);
                            else
                                bscPubLvl2 = new BscPubLevel2(null, 2);
                            bscPubLvl2.Text = "BSC P. Niv. 2";
                            bscPubLvl2.MdiParent = this;
                            bscPubLvl2.fromDb = true;
                            bscPubLvl2.Show();
                            bscPubLvl2.gridControl1.DataSource = BscPubLevel2.dtBscLevel2;
                            bscPubLvl2.gridView1.BestFitColumns();
                            btnPublicBscLevel2.Enabled = false;
                        }
                        else
                            btnPublicBscLevel2.Enabled = true;

                        if (op.openBscPubLevel3)
                        {
                            if (dtBscPub3Temp != null && dtBscPub3Temp.Rows.Count > 0)
                                bscPubLvl3 = new BscPubLevel3(dtBscPub3Temp, 2);
                            else
                                bscPubLvl3 = new BscPubLevel3(null, 2);
                            bscPubLvl3.Text = "BSC P. Niv. 3";
                            bscPubLvl3.MdiParent = this;
                            bscPubLvl3.fromDb = true;
                            bscPubLvl3.Show();
                            bscPubLvl3.gridControl1.DataSource = BscPubLevel3.dtBscLevel3;
                            bscPubLvl3.gridView1.BestFitColumns();
                            btnPublicBscLevel3.Enabled = false;
                        }
                        else
                            btnPublicBscLevel3.Enabled = true;

                        if (op.openBscPubLevel4)
                        {
                            if (dtBscPub4Temp != null && dtBscPub4Temp.Rows.Count > 0)
                                bscPubLvl4 = new BscPubLevel4(dtBscPub4Temp, 2);
                            else
                                bscPubLvl4 = new BscPubLevel4(null, 2);
                            bscPubLvl4.Text = "BSC P. Niv. 4";
                            bscPubLvl4.MdiParent = this;
                            bscPubLvl4.fromDb = true;
                            bscPubLvl4.Show();
                            bscPubLvl4.gridControl1.DataSource = BscPubLevel4.dtBscLevel4;
                            bscPubLvl4.gridView1.BestFitColumns();
                            btnPublicBscLevel4.Enabled = false;
                        }
                        else
                            btnPublicBscLevel4.Enabled = true;

                        SplashScreenManager.CloseForm();
                        XtraMessageBox.Show("El proyecto se ha cargado exitosamente.");
                        projectSaved = true;
                        lblProjectNameStatus.Caption = "<b>Proyecto:</b> " + op.projectMainName;
                        op.Close();

                        //Si se abre el proyecto se debe habilitar los controles de matriz y guardado.
                        rpMatrix.Visible = true;
                        rpDataControl.Visible = true;
                        rpDiagrams.Visible = true;
                        rpBsc.Visible = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show(op.errorMessage);
                    op.Close();
                }
            }
            catch (Exception ex)
            {
                MatrixRibbonInit();
                CloseOpened();
                projectId = 0;

                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Ha ocurrido un problema al abrir el proyecto seleccionado.");

            }
        }

        public static void SeparateFodaMatrix(DataTable dtFoda)
        {
            //Se separan tablas F,O,D,A para mejor manejo.
            MatrixFODA.dtF = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.FMatrix);
            MatrixFODA.dtO = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.OMatrix);
            MatrixFODA.dtD = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.DMatrix);
            MatrixFODA.dtA = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.AMatrix);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (projectId != 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro que desea cerrar el aplicativo?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;

                    }
                    else
                    {
                        if (!projectSaved)
                            btnSave_ItemClick(null, null);
                    }
                }
                else
                {
                    if (XtraMessageBox.Show("¿Está seguro que desea cerrar el aplicativo?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tmWarning_Tick(object sender, EventArgs e)
        {
            try
            {
                if (projectId != 0 && !projectSaved)
                {
                    alertWarning.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.BottomRight;
                    alertWarning.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Slow;
                    alertWarning.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.MoveVertical;
                    alertWarning.Show(this.FindForm(), "Proyecto sin guardar\n\n", "Recuerde guardar su Proyecto, para no perder información!");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                About about = new About();
                about.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnManagerSt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mSt.gridView1.CloseEditor();
            mSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0)
            {
                mManagerSt = new MatrixManagerSt();
                mManagerSt.Text = "Estratégias Gerenciales";
                mManagerSt.MdiParent = this;
                mManagerSt.Show();
                if (mManagerSt.stShown)
                {
                    btnManagerSt.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mManagerSt.errorMessage);
                    closeFromMain = true;
                    mManagerSt.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Básica antes de continuar!.");
            }
        }

        private void btnManagerLevel2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mSt.gridView1.CloseEditor();
            mSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0)
            {
                mLevel2 = new MatrixLevel2();
                mLevel2.Text = "Estratégias N2";
                mLevel2.MdiParent = this;
                mLevel2.Show();
                if (mLevel2.stShown)
                {
                    btnManagerLevel2.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mLevel2.errorMessage);
                    closeFromMain = true;
                    mLevel2.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias antes de continuar!.");
            }
        }

        private void btnManagerLevel3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mSt.gridView1.CloseEditor();
            mSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0)
            {
                mLevel3 = new MatrixLevel3();
                mLevel3.Text = "Estratégias N3";
                mLevel3.MdiParent = this;
                mLevel3.Show();
                if (mLevel3.stShown)
                {
                    btnManagerLevel3.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mLevel3.errorMessage);
                    closeFromMain = true;
                    mLevel3.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias antes de continuar!.");
            }
        }

        private void btnManagerLevel4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mSt.gridView1.CloseEditor();
            mSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0)
            {
                mLevel4 = new MatrixLevel4();
                mLevel4.Text = "Estratégias N4";
                mLevel4.MdiParent = this;
                mLevel4.Show();
                if (mLevel4.stShown)
                {
                    btnManagerLevel4.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(mLevel4.errorMessage);
                    closeFromMain = true;
                    mLevel4.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias antes de continuar!.");
            }
        }

        //Se verifica que la tabla esté llena
        private bool VerifyFilledTable(DataTable dt)
        {
            bool filled = true;

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (row[i] == null || row[i].ToString() == string.Empty)
                    {
                        filled = false;
                        break;
                    }
                }

                if (!filled)
                    break;
            }
            return filled;
        }

        private void btnDiagramPrivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mManagerSt.gridView1.CloseEditor();
            mManagerSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0 && VerifyFilledTable(MatrixManagerSt.dtManagerSt))
            {
                fDiagram = new frmDiagramTest(Utils.DiagramType.Private);
                fDiagram.Text = "Mapa Empresa Privada";
                fDiagram.MdiParent = this;
                fDiagram.Show();
                if (fDiagram.stShown)
                {
                    btnDiagramPrivate.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(fDiagram.errorMessage);
                    closeFromMain = true;
                    fDiagram.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Gerencial antes de continuar!.");
            }
        }

        private void btnDiagramPublic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mManagerSt.gridView1.CloseEditor();
            mManagerSt.gridView1.UpdateCurrentRow();

            //Se verifica que exista la matriz de estrategias con datos, para poder continuar.
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0 && VerifyFilledTable(MatrixManagerSt.dtManagerSt))
            {
                fDiagram = new frmDiagramTest(Utils.DiagramType.Public);
                fDiagram.Text = "Mapa Empresa Pública";
                fDiagram.MdiParent = this;
                fDiagram.Show();
                if (fDiagram.stShown)
                {
                    btnDiagramPublic.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(fDiagram.errorMessage);
                    closeFromMain = true;
                    fDiagram.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Gerencial antes de continuar!.");
            }
        }

        private void btnBscLevel1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mManagerSt.gridView1.CloseEditor();
            mManagerSt.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 1.
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0 && VerifyFilledTable(MatrixManagerSt.dtManagerSt))
            {
                bscLvl1 = new BscLevel1(null, 1);
                bscLvl1.Text = "BSC N1";
                bscLvl1.MdiParent = this;
                bscLvl1.Show();
                if (bscLvl1.stShown)
                {
                    btnBscLevel1.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscLvl1.errorMessage);
                    closeFromMain = true;
                    bscLvl1.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Gerencial antes de continuar!.");
            }
        }

        private void btnBscLevel2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel2.gridView1.CloseEditor();
            mLevel2.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 2.
            if (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0 && VerifyFilledTable(MatrixLevel2.dtLevel2))
            {
                bscLvl2 = new BscLevel2(null);
                bscLvl2.Text = "BSC N2";
                bscLvl2.MdiParent = this;
                bscLvl2.Show();
                if (bscLvl2.stShown)
                {
                    btnBscLevel2.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscLvl2.errorMessage);
                    closeFromMain = true;
                    bscLvl2.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Nivel 2 antes de continuar!.");
            }
        }

        private void btnBscLevel3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel3.gridView1.CloseEditor();
            mLevel3.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 3.
            if (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0 && VerifyFilledTable(MatrixLevel3.dtLevel3))
            {
                bscLvl3 = new BscLevel3(null);
                bscLvl3.Text = "BSC N3";
                bscLvl3.MdiParent = this;
                bscLvl3.Show();
                if (bscLvl3.stShown)
                {
                    btnBscLevel3.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscLvl3.errorMessage);
                    closeFromMain = true;
                    bscLvl3.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Nivel 3 antes de continuar!.");
            }
        }

        private void btnBscLevel4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel4.gridView1.CloseEditor();
            mLevel4.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 4.
            if (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0 && VerifyFilledTable(MatrixLevel4.dtLevel4))
            {
                bscLvl4 = new BscLevel4(null);
                bscLvl4.Text = "BSC N4";
                bscLvl4.MdiParent = this;
                bscLvl4.Show();
                if (bscLvl4.stShown)
                {
                    btnBscLevel4.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscLvl4.errorMessage);
                    closeFromMain = true;
                    bscLvl4.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Nivel 4 antes de continuar!.");
            }
        }

        private void btnPublicBscLevel1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mManagerSt.gridView1.CloseEditor();
            mManagerSt.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 1.
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0 && VerifyFilledTable(MatrixManagerSt.dtManagerSt))
            {
                bscPubLvl1 = new BscPubLevel1(null, 2);
                bscPubLvl1.Text = "BSC Pub N1";
                bscPubLvl1.MdiParent = this;
                bscPubLvl1.Show();
                if (bscPubLvl1.stShown)
                {
                    btnPublicBscLevel1.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscPubLvl1.errorMessage);
                    closeFromMain = true;
                    bscPubLvl1.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz de Estrategias Gerencial antes de continuar!.");
            }
        }

        private void btnPublicBscLevel2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel2.gridView1.CloseEditor();
            mLevel2.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 2.
            if (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0 && VerifyFilledTable(MatrixLevel2.dtLevel2))
            {
                bscPubLvl2 = new BscPubLevel2(null, 2);
                bscPubLvl2.Text = "BSC Pub N2";
                bscPubLvl2.MdiParent = this;
                bscPubLvl2.Show();
                if (bscPubLvl2.stShown)
                {
                    btnPublicBscLevel2.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscPubLvl2.errorMessage);
                    closeFromMain = true;
                    bscPubLvl2.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz Nivel 2 antes de continuar!.");
            }
        }

        private void btnPublicBscLevel3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel3.gridView1.CloseEditor();
            mLevel3.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 3.
            if (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0 && VerifyFilledTable(MatrixLevel3.dtLevel3))
            {
                bscPubLvl3 = new BscPubLevel3(null, 2);
                bscPubLvl3.Text = "BSC Pub N3";
                bscPubLvl3.MdiParent = this;
                bscPubLvl3.Show();
                if (bscPubLvl3.stShown)
                {
                    btnPublicBscLevel3.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscPubLvl3.errorMessage);
                    closeFromMain = true;
                    bscPubLvl3.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz Nivel 3 antes de continuar!.");
            }
        }

        private void btnPublicBscLevel4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Se actualiza el grid de la matriz.
            mLevel4.gridView1.CloseEditor();
            mLevel4.gridView1.UpdateCurrentRow();

            //Se inicia ventana de Balanced Nivel 4.
            if (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0 && VerifyFilledTable(MatrixLevel4.dtLevel4))
            {
                bscPubLvl4 = new BscPubLevel4(null, 2);
                bscPubLvl4.Text = "BSC Pub N4";
                bscPubLvl4.MdiParent = this;
                bscPubLvl4.Show();
                if (bscPubLvl4.stShown)
                {
                    btnPublicBscLevel4.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(bscPubLvl4.errorMessage);
                    closeFromMain = true;
                    bscPubLvl4.Close();
                    closeFromMain = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Debe tener datos en la Matriz Nivel 4 antes de continuar!.");
            }
        }

        public void UpdateDependantMatrix(int level)
        {
            if (mFo.Visible && level == 1)
                mFo.RefreshFoMatrix();
            if (mDo.Visible && level == 1)
                mDo.RefreshDoMatrix();
            if (mFa.Visible && level == 1)
                mFa.RefreshFaMatrix();
            if (mDa.Visible && level == 1)
                mDa.RefreshDaMatrix();
            if (mSt.Visible && level <= 2)
                mSt.RefreshStrategiesMatrix();
            if (mManagerSt.Visible && level <= 3)
                mManagerSt.RefreshManagerStMatrix();
            if (mLevel2.Visible && level <= 3)
                mLevel2.RefreshManagerStMatrix();
            if (mLevel3.Visible && level <= 3)
                mLevel3.RefreshManagerStMatrix();
            if (mLevel4.Visible && level <= 3)
                mLevel4.RefreshManagerStMatrix();
            if (bscLvl1.Visible && level <= 4)
                bscLvl1.RefreshManagerStMatrix();
            if (bscLvl2.Visible && (level < 4 || level == 5))
                bscLvl2.RefreshManagerStMatrix();
            if (bscLvl3.Visible && (level < 4 || level == 6))
                bscLvl3.RefreshManagerStMatrix();
            if (bscLvl4.Visible && (level < 4 || level == 7))
                bscLvl4.RefreshManagerStMatrix();
            if (bscPubLvl1.Visible && level <= 4)
                bscPubLvl1.RefreshManagerStMatrix();
            if (bscPubLvl2.Visible && (level < 4 || level == 5))
                bscPubLvl2.RefreshManagerStMatrix();
            if (bscPubLvl3.Visible && (level < 4 || level == 6))
                bscPubLvl3.RefreshManagerStMatrix();
            if (bscPubLvl4.Visible && (level < 4 || level == 7))
                bscPubLvl4.RefreshManagerStMatrix();
        }
    }
}
