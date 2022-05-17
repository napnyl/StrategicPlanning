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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;

namespace StPlanning.UserControls
{

    public partial class MatrixStrategies : System.Windows.Forms.Form
    {

        public static DataTable dtStrategies = new DataTable();
        RepositoryItemTextEdit riText = new RepositoryItemTextEdit();
        public bool stShown = false;
        public bool fromDb = false;
        public string errorMessage = string.Empty;
        public MatrixStrategies()
        {
            InitializeComponent();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            //gridView1.BestFitColumns();
            //gridView1.Columns[2].Width = 100;
        }

        private void CreateStrategiesMatrix()
        {
            dtStrategies.Columns.Add("CRUCE");
            dtStrategies.Columns.Add("DESARROLLO DE ESTRATEGIAS");
            dtStrategies.Columns.Add("GRUPO");
            dtStrategies.Columns.Add("NIVEL");

            //Fila FO.
            DataRow drFo = dtStrategies.NewRow();
            drFo[0] = string.Empty; drFo[1] = "FORTALEZAS / OPORTUNIDADES"; drFo[2] = string.Empty; drFo[3] = string.Empty;
            dtStrategies.Rows.Add(drFo);

            //Se insertan los cruces FO.
            List<string> foStrategies = GetStrategiesArray(MatrixFO.dtFO);
            foreach (var item in foStrategies)
            {
                DataRow drNew = dtStrategies.NewRow();
                drNew[0] = item; drNew[1] = string.Empty; drNew[2] = string.Empty; drNew[3] = string.Empty;
                dtStrategies.Rows.Add(drNew);
            }

            //Fila DO.
            DataRow drDo = dtStrategies.NewRow();
            drDo[0] = string.Empty; drDo[1] = "DEBILIDADES / OPORTUNIDADES"; drDo[2] = string.Empty; drDo[3] = string.Empty;
            dtStrategies.Rows.Add(drDo);

            //Se insertan los cruces DO.
            List<string> doStrategies = GetStrategiesArray(MatrixDO.dtDO);
            foreach (var item in doStrategies)
            {
                DataRow drNew = dtStrategies.NewRow();
                drNew[0] = item; drNew[1] = string.Empty; drNew[2] = string.Empty; drNew[3] = string.Empty;
                dtStrategies.Rows.Add(drNew);
            }

            //Fila FA.
            DataRow drFa = dtStrategies.NewRow();
            drFa[0] = string.Empty; drFa[1] = "FORTALEZAS / AMENAZAS"; drFa[2] = string.Empty; drFa[3] = string.Empty;
            dtStrategies.Rows.Add(drFa);

            //Se insertan los cruces FA.
            List<string> faStrategies = GetStrategiesArray(MatrixFA.dtFA);
            foreach (var item in faStrategies)
            {
                DataRow drNew = dtStrategies.NewRow();
                drNew[0] = item; drNew[1] = string.Empty; drNew[2] = string.Empty; drNew[3] = string.Empty;
                dtStrategies.Rows.Add(drNew);
            }

            //Fila DA.
            DataRow drDa = dtStrategies.NewRow();
            drDa[0] = string.Empty; drDa[1] = "DEBILIDADES / AMENAZAS"; drDa[2] = string.Empty; drDa[3] = string.Empty;
            dtStrategies.Rows.Add(drDa);

            //Se insertan los cruces DA.
            List<string> daStrategies = GetStrategiesArray(MatrixDA.dtDA);
            foreach (var item in daStrategies)
            {
                DataRow drNew = dtStrategies.NewRow();
                drNew[0] = item; drNew[1] = string.Empty; drNew[2] = string.Empty; drNew[3] = string.Empty;
                dtStrategies.Rows.Add(drNew);
            }
        }

        private void MatrixStrategies_Load(object sender, EventArgs e)
        {
            try
            {
                if (!fromDb)
                {
                    if (dtStrategies.Rows.Count == 0)
                    {
                        CreateStrategiesMatrix();
                        gridControl1.DataSource = dtStrategies;
                        gridView1.BestFitColumns();
                        stShown = true;
                    }
                    else
                    {
                        if (XtraMessageBox.Show("¿Desea borrar la anterior matriz de estratégias básica y volver a generar una nueva?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            dtStrategies = new DataTable();
                            CreateStrategiesMatrix();
                            gridControl1.DataSource = dtStrategies;
                            gridView1.BestFitColumns();
                            stShown = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Ha ocurrido un error al cargar la Matriz de Estrategias Básica!";
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                string strategy = string.Empty;
                if (e.Column.AbsoluteIndex == 0)
                {
                    return;
                }
                else if (e.Column.AbsoluteIndex == 1)
                {
                    e.RepositoryItem = rmeStrategy;
                }
                else if (e.Column.AbsoluteIndex == 2)
                {
                    strategy = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["DESARROLLO DE ESTRATEGIAS"]);
                    if (strategy != "FORTALEZAS / OPORTUNIDADES" && strategy != "DEBILIDADES / OPORTUNIDADES" && strategy != "FORTALEZAS / AMENAZAS" && strategy != "DEBILIDADES / AMENAZAS")
                    {
                        e.RepositoryItem = repositoryItemColorEdit1;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (e.Column.AbsoluteIndex == 3 && strategy != "FORTALEZAS / OPORTUNIDADES" && strategy != "DEBILIDADES / OPORTUNIDADES" && strategy != "FORTALEZAS / AMENAZAS" && strategy != "DEBILIDADES / AMENAZAS")
                {
                    strategy = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["DESARROLLO DE ESTRATEGIAS"]);
                    if (strategy != "FORTALEZAS / OPORTUNIDADES" && strategy != "DEBILIDADES / OPORTUNIDADES" && strategy != "FORTALEZAS / AMENAZAS" && strategy != "DEBILIDADES / AMENAZAS")
                    {
                        e.RepositoryItem = rcbLevel;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ocurrió un problema: " + ex.Message);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            Main.projectSaved = false;
            string strategy = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["DESARROLLO DE ESTRATEGIAS"]);
            if (gridView1.FocusedColumn.AbsoluteIndex == 0 ||
                strategy == "FORTALEZAS / OPORTUNIDADES" ||
                strategy == "DEBILIDADES / OPORTUNIDADES" ||
                strategy == "FORTALEZAS / AMENAZAS" ||
                strategy == "DEBILIDADES / AMENAZAS"
                )
            {
                e.Cancel = true;
            }
        }

        private List<string> GetStrategiesArray(DataTable dt)
        {
            List<string> strategies = new List<string>(); ;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][j].ToString() == "9")
                    {
                        strategies.Add(dt.Rows[i][0].ToString() + " / " + dt.Columns[j].ToString());
                    }
                }
            }
            return strategies;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            GridView View = sender as GridView;
            string strategy = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DESARROLLO DE ESTRATEGIAS"]);
            if (strategy == "FORTALEZAS / OPORTUNIDADES" || strategy == "DEBILIDADES / OPORTUNIDADES" || strategy == "FORTALEZAS / AMENAZAS" || strategy == "DEBILIDADES / AMENAZAS")
            {
                e.Appearance.FontSizeDelta = 3;
                e.Appearance.BackColor = Color.FromArgb(176, 224, 230);
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            else
            {
                if (e.Column.FieldName == "GRUPO")
                {
                    //gridView1.GetFocusedRowCellDisplayText(e.Column)
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            //Rectangle sortBounds = Rectangle.Empty;
            if (e.Column != null)
            {
                e.Appearance.FontSizeDelta = 4;
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void MatrixStrategies_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain && ((MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0) || (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0) || (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0) || (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0)
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

        private void MatrixStrategies_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnStrategies"].Enabled = true;
            dtStrategies = new DataTable();
            Main.projectSaved = false;
        }

        private void SetGridViewProperties()
        {
            gridView1.ColumnPanelRowHeight = 30;
            gridView1.GridControl = this.gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            gridView1.OptionsCustomization.AllowFilter = false;
            gridView1.OptionsCustomization.AllowGroup = false;
            gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            gridView1.OptionsCustomization.AllowSort = false;
            gridView1.OptionsDetail.AllowZoomDetail = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
        }

        public void RefreshStrategiesMatrix()
        {
            DataTable dtStrategiesTemp = dtStrategies.Copy();
            dtStrategies = new DataTable();
            CreateStrategiesMatrix();

            foreach (DataRow row in dtStrategies.Rows)
            {
                for (int i = 0; i < dtStrategiesTemp.Rows.Count; i++)
                {
                    if (row["CRUCE"] != DBNull.Value && row["CRUCE"] != null && row["CRUCE"] != string.Empty && dtStrategiesTemp.Rows[i][0] != DBNull.Value && dtStrategiesTemp.Rows[i][0] != null && dtStrategiesTemp.Rows[i][0] != string.Empty && row["CRUCE"].ToString() == dtStrategiesTemp.Rows[i][0].ToString())
                    {
                        row["DESARROLLO DE ESTRATEGIAS"] = dtStrategiesTemp.Rows[i][1].ToString();
                        row["GRUPO"] = dtStrategiesTemp.Rows[i][2].ToString();
                        row["NIVEL"] = dtStrategiesTemp.Rows[i][3].ToString();
                        break;
                    }
                }
            }

            gridControl1.DataSource = null;
            SetGridViewProperties();
            gridControl1.MainView = gridView1;
            gridControl1.DataSource = dtStrategies;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshStrategiesMatrix();
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            string filename = "test.xlsx";
            saveDialog.RestoreDirectory = true;
            saveDialog.CheckFileExists = false;
            saveDialog.CheckPathExists = false;
            saveDialog.SupportMultiDottedExtensions = true;
            saveDialog.Filter = "Todos los archivos (*.*)|*.*";

            saveDialog.DefaultExt = System.IO.Path.GetExtension(filename);
            if (saveDialog.DefaultExt.Length > 0)
            {
                saveDialog.AddExtension = true;
                saveDialog.Filter = "Archivos " + saveDialog.DefaultExt + " (*." + saveDialog.DefaultExt + ")|*." + saveDialog.DefaultExt + "|" + saveDialog.Filter;
                saveDialog.FilterIndex = 0;
            }

            saveDialog.FileName = "Estrategias_Basica_" + DateTime.Now.ToString("yyyyMMdd");


            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != string.Empty)
                {
                    gridControl1.ExportToXlsx(saveDialog.FileName);
                    XtraMessageBox.Show("Los datos se han exportado con éxito!.");
                }
                else
                {
                    XtraMessageBox.Show("No ha sido posible exportar los datos!.");
                }
            }
        }
    }
}
