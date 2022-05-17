using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StPlanning.BL;
using StPlanning.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace StPlanning.UserControls
{
    public partial class MatrixFODA : System.Windows.Forms.Form
    {
        public static DataTable dtFoda = new DataTable();
        public static DataTable dtF = new DataTable();
        public static DataTable dtO = new DataTable();
        public static DataTable dtD = new DataTable();
        public static DataTable dtA = new DataTable();
        public bool dataShown = false;
        public string errorMessage = string.Empty;
        public bool fromDb = false;

        public MatrixFODA()
        {
            InitializeComponent();
        }

        private int GetMaxRowNumber(DataTable F, DataTable O, DataTable D, DataTable A)
        {
            int result = 0;
            result = F.Rows.Count;
            result = result < O.Rows.Count ? O.Rows.Count : result;
            result = result < D.Rows.Count ? D.Rows.Count : result;
            result = result < A.Rows.Count ? A.Rows.Count : result;
            return result;
        }

        private void DataShow_Load(object sender, EventArgs e)
        {
            try
            {
                if (!fromDb)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    DialogResult result = openFile.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //Se obtiene toda la tabla FODA desde EXCEL.
                        dtFoda = ExcelDataBaseHelper.ImportExcelXLS(openFile.FileName, true);
                        if (dtFoda.Columns.Count > 0 && dtFoda.Rows.Count > 0)
                        {
                            //Se separan tablas F,O,D,A para mejor manejo.
                            dtF = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.FMatrix);
                            dtO = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.OMatrix);
                            dtD = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.DMatrix);
                            dtA = DataTableBL.KeepOnlyColumn(dtFoda, Utils.FodaEnum.AMatrix);

                            if (dtF.Rows.Count > 0 && dtO.Rows.Count > 0 && dtD.Rows.Count > 0 && dtA.Rows.Count > 0)
                            {
                                dtFoda = new DataTable();
                                dtFoda.Columns.Add("FORTALEZAS");
                                dtFoda.Columns.Add("OPORTUNIDADES");
                                dtFoda.Columns.Add("DEBILIDADES");
                                dtFoda.Columns.Add("AMENAZAS");
                                int maxRows = new int[] { dtF.Rows.Count, dtO.Rows.Count, dtD.Rows.Count, dtA.Rows.Count }.Max();
                                for (int i = 0; i < maxRows; i++)
                                {
                                    DataRow dr1 = i < dtF.Rows.Count ? dtF.Rows[i] : null;
                                    DataRow dr2 = i < dtO.Rows.Count ? dtO.Rows[i] : null;
                                    DataRow dr3 = i < dtD.Rows.Count ? dtD.Rows[i] : null;
                                    DataRow dr4 = i < dtA.Rows.Count ? dtA.Rows[i] : null;
                                    dtFoda.Rows.Add(dr1 != null ? dr1[0] : null, dr2 != null ? dr2[0] : null, dr3 != null ? dr3[0] : null, dr4 != null ? dr4[0] : null);
                                }
                                gridControl1.DataSource = dtFoda;
                                dataShown = true;
                            }
                            else
                            {
                                //Se limpian todas las matrices publicas generadas.
                                dtFoda = new DataTable();
                                errorMessage = "El archivo seleccionado contiene columnas sin datos, verifique e intente nuevamente.";
                            }
                        }
                        else
                        {
                            errorMessage = "El archivo seleccionado está incompleto, verifique e intente nuevamente.";
                        }
                    }
                    else
                    {
                        errorMessage = "No se ha cargado ningun archivo!.";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Ha ocurrido un error al cargar la Matriz FODA!";
            }
        }

        private void MatrixFODA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain && ((MatrixFO.dtFO != null && MatrixFO.dtFO.Rows.Count > 0) || (MatrixDO.dtDO != null && MatrixDO.dtDO.Rows.Count > 0) || (MatrixFA.dtFA != null && MatrixFA.dtFA.Rows.Count > 0) || (MatrixDA.dtDA != null && MatrixDA.dtDA.Rows.Count > 0) || (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0) || (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0) || (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0) || (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0) || (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0)
                || (BscLevel1.dtBscLevel1 != null && BscLevel1.dtBscLevel1.Rows.Count > 0) || (BscLevel2.dtBscLevel2 != null && BscLevel2.dtBscLevel2.Rows.Count > 0) || (BscLevel3.dtBscLevel3 != null && BscLevel3.dtBscLevel3.Rows.Count > 0) || (BscLevel4.dtBscLevel4 != null && BscLevel4.dtBscLevel4.Rows.Count > 0) || (BscPubLevel1.dtBscLevel1 != null && BscPubLevel1.dtBscLevel1.Rows.Count > 0) || (BscPubLevel2.dtBscLevel2 != null && BscPubLevel2.dtBscLevel2.Rows.Count > 0) || (BscPubLevel3.dtBscLevel3 != null && BscPubLevel3.dtBscLevel3.Rows.Count > 0) || (BscPubLevel4.dtBscLevel4 != null && BscPubLevel4.dtBscLevel4.Rows.Count > 0)))
            {
                XtraMessageBox.Show("Primero se deben cerrar todas las matrices generadas!");
                e.Cancel = true;
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain)
                {
                    if (XtraMessageBox.Show("¿Está seguro que desea cerrar la matriz actual? Se perderan los datos!", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void MatrixFODA_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnFoda"].Enabled = true;
            dtFoda = new DataTable();
            Main.projectSaved = false;
        }

        

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedValue != DBNull.Value && gridView1.FocusedValue != null && gridView1.FocusedValue != string.Empty)
            {
                Main.projectSaved = false;
                //TODO: Se debe actualizar todas las matrices que dependen de esta.
                //((Main)this.ParentForm).UpdateDependantMatrix(1);
            }
            else
                e.Cancel = true;
        }
    }
}
