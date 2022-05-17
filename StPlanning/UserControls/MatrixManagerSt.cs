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

    public partial class MatrixManagerSt : System.Windows.Forms.Form
    {

        public static DataTable dtManagerSt = new DataTable();
        RepositoryItemTextEdit riText = new RepositoryItemTextEdit();
        public bool stShown = false;
        public bool fromDb = false;
        public string errorMessage = string.Empty;
        string foStr = "FORTALEZAS / OPORTUNIDADES";
        string doStr = "DEBILIDADES / OPORTUNIDADES";
        string faStr = "FORTALEZAS / AMENAZAS";
        string daStr = "DEBILIDADES / AMENAZAS";
        string headSt = "ESTRATEGIAS";
        string headManagerSt = "DESARROLLO DE ESTRATEGIAS GERENCIALES";
        string headGroup = "GRUPO";
        string headPerspective = "PERSPECTIVA";

        public MatrixManagerSt()
        {
            InitializeComponent();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void MatrixManagerSt_Load(object sender, EventArgs e)
        {
            if (!fromDb)
            {
                if (dtManagerSt.Rows.Count == 0)
                {
                    CreateManagerStMatrix();
                    stShown = true;
                }
                else
                {
                    if (XtraMessageBox.Show("¿Desea borrar la anterior matriz de estratégias básica y volver a generar una nueva?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dtManagerSt = new DataTable();
                        CreateManagerStMatrix();
                        stShown = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void CreateManagerStMatrix()
        {
            dtManagerSt = GroupStrategies(MatrixStrategies.dtStrategies);
            gridControl1.DataSource = dtManagerSt;
            gridView1.BestFitColumns();
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.AbsoluteIndex == 0 )
            {
                e.RepositoryItem = repositoryItemMemoEdit1;
            }
            else if (e.Column.AbsoluteIndex == 1)
            {
                e.RepositoryItem = rmeStrategy;
            }
            else if (e.Column.AbsoluteIndex == 2)
            {
                e.RepositoryItem = repositoryItemColorEdit1;
            }
            else if (e.Column.AbsoluteIndex == 3)
            {
                e.RepositoryItem = repositoryItemComboBox1;
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            Main.projectSaved = false;

            if (gridView1.FocusedColumn.AbsoluteIndex == 0 || gridView1.FocusedColumn.AbsoluteIndex == 2)
            {
                e.Cancel = true;
            }
        }

        private DataTable GroupStrategies(DataTable dt)
        {
            DataTable dtManager = new DataTable();
            dtManager.Columns.Add(headSt);
            dtManager.Columns.Add(headManagerSt);
            dtManager.Columns.Add(headGroup);
            dtManager.Columns.Add(headPerspective);

            foreach (DataRow row in dt.Rows)
            {
                //Se verifica que las estrategias sean de nivel 1,
                if (row[3].ToString().Contains("1"))
                {
                    int lookUpResult = -1;
                    if (row[2] != DBNull.Value && row[2] != null && row[2] != string.Empty && dtManager.Rows.Count > 0)
                        lookUpResult = LookUpColor(dtManager, Convert.ToInt32(row[2]), dt.Rows.IndexOf(row));

                    if (lookUpResult == -1 || row[2] == null || row[2] == string.Empty)
                    {
                        DataRow drManagerSt = dtManager.NewRow();

                        if (row[1] != foStr && row[1] != doStr && row[1] != faStr && row[1] != daStr)
                        {
                            drManagerSt[0] = row[1];
                            drManagerSt[1] = string.Empty;
                            drManagerSt[2] = row[2];
                            dtManager.Rows.Add(drManagerSt);
                        }
                    }
                    else
                    {
                        dtManager.Rows[lookUpResult][0] = dtManager.Rows[lookUpResult][0].ToString() + "\n" + row[1];
                    }
                }
            }

            //Se verifican las estrategias que pasaron directo y se copian como estrategias de nivel.
            foreach (DataRow row in dtManager.Rows)
            {
                if (row[0] != null && row[0].ToString() != string.Empty && !row[0].ToString().Contains("\n"))
                {
                    row[1] = row[0];
                }
            }

            return dtManager;
        }

        //private int LookUpColor(DataTable dt, int color, int currentIndex, int stTypeIn)
        //{
        //    int index = -1;
        //    int stType = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if ((row[2] != DBNull.Value && row[2] != null && row[2] != string.Empty ? Convert.ToInt32(row[2]) : -1) == color && stTypeIn == stType)
        //        {
        //            if (dt.Rows.IndexOf(row) < currentIndex)
        //            {
        //                index = dt.Rows.IndexOf(row);
        //                break;
        //            }
        //        }
        //    }

        //    return index;
        //}

        private int LookUpColor(DataTable dt, int color, int currentIndex)
        {
            int index = -1;
            foreach (DataRow row in dt.Rows)
            {
                if ((row[2] != DBNull.Value && row[2] != null && row[2] != string.Empty ? Convert.ToInt32(row[2]) : -1) == color)
                {
                    if (dt.Rows.IndexOf(row) < currentIndex)
                    {
                        index = dt.Rows.IndexOf(row);
                        break;
                    }
                }
            }

            return index;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            GridView View = sender as GridView;
            string strategy = View.GetRowCellDisplayText(e.RowHandle, View.Columns[headManagerSt]);
            e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
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

        private void MatrixManagerSt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain && ((BscLevel1.dtBscLevel1 != null && BscLevel1.dtBscLevel1.Rows.Count > 0) || (BscPubLevel1.dtBscLevel1 != null && BscPubLevel1.dtBscLevel1.Rows.Count > 0)))
            {
                XtraMessageBox.Show("Primero se debe cerrar la matriz BSC de Nivel 1 Generada!");
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

        private void MatrixManagerSt_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnManagerSt"].Enabled = true;
            dtManagerSt = new DataTable();
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
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
        }

        public void RefreshManagerStMatrix()
        {
            DataTable dtManagerStTemp = dtManagerSt.Copy();
            dtManagerSt = new DataTable();
            dtManagerSt = GroupStrategies(MatrixStrategies.dtStrategies);

            foreach (DataRow row in dtManagerSt.Rows)
            {
                if (dtManagerStTemp.Rows.Count == dtManagerSt.Rows.Count)
                {
                    if (dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][1] != DBNull.Value && dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][1] != null)
                    {
                        row[headManagerSt] = dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][1].ToString();
                    }
                    if (dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][2] != DBNull.Value && dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][2] != null)
                    {
                        row[headGroup] = dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][2].ToString();
                    }
                    if (dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][3] != DBNull.Value && dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][3] != null)
                    {
                        row[headPerspective] = dtManagerStTemp.Rows[dtManagerSt.Rows.IndexOf(row)][3].ToString();
                    }
                }
                else if (dtManagerStTemp.Rows.Count > dtManagerSt.Rows.Count)
                {
                    for (int i = 0; i < dtManagerStTemp.Rows.Count; i++)
                    {
                        if (row[headSt].ToString().Contains(dtManagerStTemp.Rows[i][0].ToString()))
                        {
                            if (row[headManagerSt].ToString().Length == 0)
                            {
                                row[headPerspective] = dtManagerStTemp.Rows[i][3];
                                row[headManagerSt] = dtManagerStTemp.Rows[i][1];
                            }
                            else
                            {
                                if (!row[headManagerSt].ToString().Contains(dtManagerStTemp.Rows[i][1].ToString()))
                                    row[headManagerSt] = row[headManagerSt] + ", " + dtManagerStTemp.Rows[i][1];
                            }
                        }
                    }
                }
                else if (dtManagerStTemp.Rows.Count < dtManagerSt.Rows.Count)
                {
                    for (int i = 0; i < dtManagerStTemp.Rows.Count; i++)
                    {
                        if (dtManagerStTemp.Rows[i][0].ToString().Contains(row[headSt].ToString()))
                        {
                            row[headPerspective] = dtManagerStTemp.Rows[i][3];
                            row[headManagerSt] = dtManagerStTemp.Rows[i][1];
                            break;
                        }
                    }
                }
            }

            gridControl1.DataSource = null;
            SetGridViewProperties();
            gridControl1.MainView = gridView1;
            gridControl1.DataSource = dtManagerSt;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshManagerStMatrix();
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

            saveDialog.FileName = "Estrategias_Gerencial_" + DateTime.Now.ToString("yyyyMMdd");


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
