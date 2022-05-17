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

namespace StPlanning.UserControls
{
    public partial class MatrixDA : System.Windows.Forms.Form
    {
        public static DataTable dtDA = new DataTable();
        RepositoryItemComboBox riCombo = new RepositoryItemComboBox();
        public bool daShown = false;
        public string errorMessage = string.Empty;
        public bool fromDb = false;

        public MatrixDA()
        {
            InitializeComponent();
            riCombo.Items.AddRange(Utils.MatrixCalif.general);
            riCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.Add(riCombo);
        }

        private void CreateDaMatrix()
        {
            dtDA.Columns.Add("*** DEBILIDADES / AMENAZAS ***");
            for (int i = 0; i < MatrixFODA.dtA.Rows.Count; i++)
            {
                dtDA.Columns.Add(MatrixFODA.dtA.Rows[i][0].ToString());
            }

            for (int i = 0; i < MatrixFODA.dtD.Rows.Count; i++)
            {
                DataRow drNew = dtDA.NewRow();
                drNew[0] = MatrixFODA.dtD.Rows[i][0].ToString();
                dtDA.Rows.Add(drNew);
            }

            gridControl1.DataSource = dtDA;
        }

        private void MatrixDA_Load(object sender, EventArgs e)
        {
            try
            {
                if (!fromDb)
                {
                    if (MatrixFODA.dtD != null && MatrixFODA.dtD.Rows.Count > 0 && MatrixFODA.dtA != null && MatrixFODA.dtA.Rows.Count > 0)
                    {
                        if (dtDA.Rows.Count == 0)
                        {
                            CreateDaMatrix();
                            daShown = true;
                        }
                        else
                        {
                            if (XtraMessageBox.Show("¿Desea borrar la anterior matriz DA y volver a generar una nueva?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                dtDA = new DataTable();
                                CreateDaMatrix();
                                daShown = true;
                            }
                            else
                            {
                                return;
                            }
                        }
                        SetStrategiesNumber();
                    }
                    else
                    {
                        errorMessage = "Debe cargar una matriz FODA válida antes de continuar!";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Ha ocurrido un error al cargar la Matriz DA!";
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.AbsoluteIndex != 0)
                e.RepositoryItem = riCombo;
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            Main.projectSaved = false;
            if (gridView1.FocusedColumn.AbsoluteIndex == 0)
                e.Cancel = true;
        }

        public int CountStrategiesNumber()
        {
            int result = 0;
            for (int j = 0; j < gridView1.Columns.Count; j++)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns[j]).ToString() == "9")
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.CellValue.ToString() == "9")
            {
                e.Appearance.BackColor = Color.FromArgb(255, 204, 204);
            }
            SetStrategiesNumber();
        }

        private void MatrixDA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain && ((MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0) || (MatrixStrategies.dtStrategies != null && MatrixStrategies.dtStrategies.Rows.Count > 0) || (MatrixLevel2.dtLevel2 != null && MatrixLevel2.dtLevel2.Rows.Count > 0) || (MatrixLevel3.dtLevel3 != null && MatrixLevel3.dtLevel3.Rows.Count > 0) || (MatrixLevel4.dtLevel4 != null && MatrixLevel4.dtLevel4.Rows.Count > 0)
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

        private void MatrixDA_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearStrategiesNumber();
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnDA"].Enabled = true;
            dtDA = new DataTable();
            Main.projectSaved = false;
        }

        public void SetStrategiesNumber()
        {
            int strategiesDA = CountStrategiesNumber();
            ((DevExpress.XtraBars.Ribbon.RibbonStatusBar)(this.Parent.TopLevelControl.Controls[0])).ItemLinks[6].BeginGroup = true;
            ((DevExpress.XtraBars.Ribbon.RibbonStatusBar)(this.Parent.TopLevelControl.Controls[0])).ItemLinks[6].Caption = "<b>Estrategias DA:</b> " + strategiesDA;
        }

        public void ClearStrategiesNumber()
        {
            ((DevExpress.XtraBars.Ribbon.RibbonStatusBar)(this.Parent.TopLevelControl.Controls[0])).ItemLinks[6].BeginGroup = false;
            ((DevExpress.XtraBars.Ribbon.RibbonStatusBar)(this.Parent.TopLevelControl.Controls[0])).ItemLinks[6].Caption = string.Empty;
        }

        private void SetGridViewProperties()
        {
            gridView1 = new GridView(gridControl1);
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            gridView1.OptionsCustomization.AllowFilter = false;
            gridView1.OptionsCustomization.AllowGroup = false;
            gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            gridView1.OptionsCustomization.AllowSort = false;
            gridView1.OptionsDetail.AllowZoomDetail = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
        }

        public void RefreshDaMatrix()
        {
            Main.SeparateFodaMatrix(MatrixFODA.dtFoda);

            for (int i = 0; i < MatrixFODA.dtA.Rows.Count; i++)
            {
                dtDA.Columns[i + 1].ColumnName = MatrixFODA.dtA.Rows[i][0].ToString();
                dtDA.Columns[i + 1].Caption = MatrixFODA.dtA.Rows[i][0].ToString();
            }

            for (int i = 0; i < MatrixFODA.dtD.Rows.Count; i++)
            {
                dtDA.Rows[i][0] = MatrixFODA.dtD.Rows[i][0].ToString();
            }

            gridControl1.DataSource = null;
            SetGridViewProperties();
            gridControl1.MainView = gridView1;
            gridControl1.DataSource = dtDA;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshDaMatrix();
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

            saveDialog.FileName = "Matriz_DA_" + DateTime.Now.ToString("yyyyMMdd");


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
