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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace StPlanning.UserControls
{

    public partial class BscLevel1 : System.Windows.Forms.Form
    {
        public static DataTable dtBscLevel1 = new DataTable();
        RepositoryItemTextEdit riText = new RepositoryItemTextEdit();
        public bool stShown = false;
        public bool fromDb = false;
        public string errorMessage = string.Empty;

        string headPerspective = "PERSPECTIVA";
        string headStValue = "ESTRATEGIA DE VALOR";
        string headStObject = "OBJETIVOS ESTRATÉGICOS";
        string headKpis = "KPI'S (DESC)";
        string headOpDef = "DEFINICIÓN OPERACIONAL";
        string headActFrec = "FRECUENCIA DE ACTUACIÓN";
        string headDataCapFrec = "FRECUENCIA DE CAPTURA DE DATOS";
        string headLevels = "NIVELES";
        string headGoal = "META";
        string headVariations = "VARIACIONES";
        string headVarRed = "ROJO";
        string headVarYellow = "AMARILLO";
        string headVarGreen = "VERDE";
        string headResponsible = "RESPONSABLE DE METAS";
        string headStInit = "INICIATIVA ESTRATÉGICA";
        string headLeader = "LIDER DE IMPLEMENTACIÓN";
        string headInitDate = "FECHA INICIO";
        string headEndDate = "FECHA FIN";

        string financialPers = "Financiero";
        string clientPers = "Cliente";
        string processPers = "Proceso Int.";
        string growthPers = "Aprendizaje y C.";

        private MyCellMergeHelper _Helper;
        MemoEdit edit = null;
        DateEdit dateEdit = null;
        DataTable externalDt = new DataTable();
        int type = 0;

        public BscLevel1(DataTable dt, int typeIn)
        {
            InitializeComponent();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            type = typeIn;

            if (dt != null && dt.Rows.Count > 0)
            {
                externalDt = dt;
                CreateManagerStMatrix();
                FillFromExternalDt(externalDt);
            }
        }

        private void MatrixManagerSt_Load(object sender, EventArgs e)
        {
            if (!fromDb)
            {
                if (dtBscLevel1.Rows.Count == 0)
                {
                    CreateManagerStMatrix();
                    stShown = true;
                }
                else
                {
                    if (XtraMessageBox.Show("¿Desea borrar la anterior tabla BCS Nivel 1 y volver a generar una nueva?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dtBscLevel1 = new DataTable();
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

        private void FillFromExternalDt(DataTable dt)
        {
            int rowCount = 0;
            foreach (DataRow row in dtBscLevel1.Rows)
            {
                if (dtBscLevel1.Rows.IndexOf(row) > 2)
                {
                    rowCount++;

                    if (rowCount <= dt.Rows.Count)
                    {
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][5] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][5] != null)
                        {
                            row["col2"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][5].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][7] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][7] != null)
                        {
                            row["col4"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][7].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][8] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][8] != null)
                        {
                            row["col5"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][8].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][9] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][9] != null)
                        {
                            row["col6"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][9].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][10] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][10] != null)
                        {
                            row["col7"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][10].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][11] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][11] != null)
                        {
                            row["col8"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][11].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][12] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][12] != null)
                        {
                            row["col9"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][12].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][13] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][13] != null)
                        {
                            row["col10"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][13].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][14] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][14] != null)
                        {
                            row["col11"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][14].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][15] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][15] != null)
                        {
                            row["col12"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][15].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][16] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][16] != null)
                        {
                            row["col13"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][16].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][17] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][17] != null)
                        {
                            row["col14"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][17].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][18] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][18] != null)
                        {
                            row["col15"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][18].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][19] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][19] != null)
                        {
                            row["col16"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][19].ToString();
                        }
                        if (dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][20] != DBNull.Value && dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][20] != null)
                        {
                            row["col17"] = dt.Rows[dtBscLevel1.Rows.IndexOf(row) - 3][20].ToString();
                        }
                    }
                    else
                        break;
                }
            }
        }

        private void CreateManagerStMatrix()
        {
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0)
            {
                dtBscLevel1 = GroupStrategies(MatrixManagerSt.dtManagerSt);
                gridControl1.DataSource = dtBscLevel1;

                //Se realiza merge inicial.
                _Helper = new MyCellMergeHelper(gridView1);
                _Helper.AddMergedCell3(0, 0, 1, 2, "DIRECCIÓN - OBJETIVOS");
                _Helper.AddMergedCell5(0, 3, 4, 5, 6, 7, "MEDIDAS");
                _Helper.AddMergedCell5(0, 8, 9, 10, 11, 12, "METAS");
                _Helper.AddMergedCell4(0, 13, 14, 15, 16, "MEDIOS");
                _Helper.AddMergedCell3(1, 9, 10, 11, headVariations);

                gridView1.BestFitColumns();
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle > 2)
            {
                if (e.Column.AbsoluteIndex == 1 || e.Column.AbsoluteIndex == 2 || e.Column.AbsoluteIndex == 3 || e.Column.AbsoluteIndex == 4 || e.Column.AbsoluteIndex == 12 || e.Column.AbsoluteIndex == 13 || e.Column.AbsoluteIndex == 14)
                {
                    e.RepositoryItem = rmeValueSt;
                }
                else if (e.Column.AbsoluteIndex == 7 || e.Column.AbsoluteIndex == 8)
                {
                    e.RepositoryItem = rseNumber;
                }
                else if (e.Column.AbsoluteIndex == 15)
                {
                    e.RepositoryItem = rdeInit;
                }
                else if (e.Column.AbsoluteIndex == 16)
                {
                    e.RepositoryItem = rdeEnd;
                }
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            Main.projectSaved = false;

            if (gridView1.FocusedColumn.AbsoluteIndex == 0 || gridView1.FocusedColumn.AbsoluteIndex == 2 || gridView1.FocusedRowHandle <= 2)
            {
                e.Cancel = true;
            }
        }

        private DataTable GroupStrategies(DataTable dtIn)
        {
            //Se ordena la tabla de entrada para manejar tipo empresa privada/pública.
            DataTable dtOut = dtIn.Copy();
            DataColumn c = dtOut.Columns.Add("Sort", typeof(int));
            if (type == 1)
                c.Expression = "iif(" + headPerspective + "='" + financialPers + "', 0, iif(" + headPerspective + "='" + clientPers + "', 1, iif(" + headPerspective + "='" + processPers + "', 2, 3)))";
            else if (type == 2)
                c.Expression = "iif(" + headPerspective + "='" + clientPers + "', 0, iif(" + headPerspective + "='" + processPers + "', 1, iif(" + headPerspective + "='" + growthPers + "', 2, 3)))";
            DataView dv = dtOut.DefaultView;
            dv.Sort = "Sort";
            DataTable dt = dv.ToTable();

            DataTable dtManager = new DataTable();

            dtManager.Columns.Add("col1");
            dtManager.Columns.Add("col2");
            dtManager.Columns.Add("col3");
            dtManager.Columns.Add("col4");
            dtManager.Columns.Add("col5");
            dtManager.Columns.Add("col6");
            dtManager.Columns.Add("col7");
            dtManager.Columns.Add("col8");
            dtManager.Columns.Add("col9");
            dtManager.Columns.Add("col10");
            dtManager.Columns.Add("col11");
            dtManager.Columns.Add("col12");
            dtManager.Columns.Add("col13");
            dtManager.Columns.Add("col14");
            dtManager.Columns.Add("col15");
            dtManager.Columns.Add("col16");
            dtManager.Columns.Add("col17");

            if (dtManager.Columns.Count > 0)
            {
                if (1 == 1)
                {
                    DataRow dataRow = dtManager.Rows.Add();
                    dataRow[0] = "1"; dataRow[1] = "2"; dataRow[2] = "3"; dataRow[3] = "4"; dataRow[4] = "5"; dataRow[5] = "6"; dataRow[6] = "7";
                    dataRow[7] = "8"; dataRow[8] = "9"; dataRow[9] = "10"; dataRow[10] = "11"; dataRow[11] = "12"; dataRow[12] = "13"; dataRow[13] = "14";
                    dataRow[14] = "15"; dataRow[15] = "16"; dataRow[16] = "17";
                }
                if (1 == 1)
                {
                    DataRow dataRow = dtManager.Rows.Add();
                    dataRow[0] = headPerspective; dataRow[1] = headStValue; dataRow[2] = headStObject; dataRow[3] = headKpis; dataRow[4] = headOpDef; dataRow[5] = headActFrec; dataRow[6] = headDataCapFrec;
                    dataRow[7] = headLevels; dataRow[8] = headGoal; dataRow[9] = headVariations; dataRow[10] = headVariations; dataRow[11] = headVariations; dataRow[12] = headResponsible;
                    dataRow[13] = headStInit; dataRow[14] = headLeader; dataRow[15] = headInitDate; dataRow[16] = headEndDate;
                }
                if (1 == 1)
                {
                    DataRow dataRow = dtManager.Rows.Add();
                    dataRow[0] = headPerspective; dataRow[1] = headStValue; dataRow[2] = headStObject; dataRow[3] = headKpis; dataRow[4] = headOpDef; dataRow[5] = headActFrec; dataRow[6] = headDataCapFrec;
                    dataRow[7] = headLevels; dataRow[8] = headGoal; dataRow[9] = headVarRed; dataRow[10] = headVarYellow; dataRow[11] = headVarGreen; dataRow[12] = headResponsible;
                    dataRow[13] = headStInit; dataRow[14] = headLeader; dataRow[15] = headInitDate; dataRow[16] = headEndDate;
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (row[3].ToString().Contains(financialPers))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            DataRow dataRow = dtManager.Rows.Add();
                            dataRow[0] = financialPers; dataRow[1] = string.Empty; dataRow[2] = row[1]; dataRow[3] = string.Empty; dataRow[4] = string.Empty; dataRow[5] = string.Empty; dataRow[6] = string.Empty;
                            dataRow[7] = string.Empty; dataRow[8] = string.Empty; dataRow[9] = string.Empty; dataRow[10] = string.Empty; dataRow[11] = string.Empty; dataRow[12] = string.Empty; dataRow[13] = string.Empty;
                            dataRow[14] = string.Empty; dataRow[15] = string.Empty; dataRow[16] = string.Empty;
                        }
                    }
                    else if (row[3].ToString().Contains(clientPers))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            DataRow dataRow = dtManager.Rows.Add();
                            dataRow[0] = clientPers; dataRow[1] = string.Empty; dataRow[2] = row[1]; dataRow[3] = string.Empty; dataRow[4] = string.Empty; dataRow[5] = string.Empty; dataRow[6] = string.Empty;
                            dataRow[7] = string.Empty; dataRow[8] = string.Empty; dataRow[9] = string.Empty; dataRow[10] = string.Empty; dataRow[11] = string.Empty; dataRow[12] = string.Empty; dataRow[13] = string.Empty;
                            dataRow[14] = string.Empty; dataRow[15] = string.Empty; dataRow[16] = string.Empty;
                        }
                    }
                    else if (row[3].ToString().Contains(processPers))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            DataRow dataRow = dtManager.Rows.Add();
                            dataRow[0] = processPers; dataRow[1] = string.Empty; dataRow[2] = row[1]; dataRow[3] = string.Empty; dataRow[4] = string.Empty; dataRow[5] = string.Empty; dataRow[6] = string.Empty;
                            dataRow[7] = string.Empty; dataRow[8] = string.Empty; dataRow[9] = string.Empty; dataRow[10] = string.Empty; dataRow[11] = string.Empty; dataRow[12] = string.Empty; dataRow[13] = string.Empty;
                            dataRow[14] = string.Empty; dataRow[15] = string.Empty; dataRow[16] = string.Empty;
                        }
                    }
                    else if (row[3].ToString().Contains(growthPers))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            DataRow dataRow = dtManager.Rows.Add();
                            dataRow[0] = growthPers; dataRow[1] = string.Empty; dataRow[2] = row[1]; dataRow[3] = string.Empty; dataRow[4] = string.Empty; dataRow[5] = string.Empty; dataRow[6] = string.Empty;
                            dataRow[7] = string.Empty; dataRow[8] = string.Empty; dataRow[9] = string.Empty; dataRow[10] = string.Empty; dataRow[11] = string.Empty; dataRow[12] = string.Empty; dataRow[13] = string.Empty;
                            dataRow[14] = string.Empty; dataRow[15] = string.Empty; dataRow[16] = string.Empty;
                        }
                    }
                }
            }

            return dtManager;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = System.Drawing.Color.DarkGray;
            }
            else if (e.RowHandle == 1)
            {
                e.Appearance.BackColor = Color.FromArgb(0, 145, 240);
            }
            else if (e.RowHandle == 2 && (e.Column.FieldName == "col10"))
            {
                e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            }
            else if (e.RowHandle == 2 && (e.Column.FieldName == "col11"))
            {
                e.Appearance.BackColor = System.Drawing.Color.Yellow;
            }
            else if (e.RowHandle == 2 && (e.Column.FieldName == "col12"))
            {
                e.Appearance.BackColor = System.Drawing.Color.LightGreen;
            }
            //else if (e.RowHandle > 2 && (e.Column.FieldName == "col8") && e.CellValue != null && e.CellValue.ToString() != string.Empty)
            //{
            //    if (Convert.ToInt32(e.CellValue) < 20)
            //        e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            //    else if (Convert.ToInt32(e.CellValue) == 20)
            //        e.Appearance.BackColor = System.Drawing.Color.Yellow;
            //    else if (Convert.ToInt32(e.CellValue) > 20)
            //        e.Appearance.BackColor = System.Drawing.Color.LightGreen;
            //    else
            //        e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
            //}
            else
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                e.Appearance.FontSizeDelta = 4;
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void MatrixManagerSt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.closeFromMain)
            {
                if (XtraMessageBox.Show("¿Está seguro que desea cerrar la tabla actual? Se perderan los datos!", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MatrixManagerSt_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnBscLevel1"].Enabled = true;
            dtBscLevel1 = new DataTable();
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
            if (MatrixManagerSt.dtManagerSt != null && MatrixManagerSt.dtManagerSt.Rows.Count > 0)
            {
                DataTable dtBscLevel1Temp = dtBscLevel1.Copy();
                dtBscLevel1 = new DataTable();
                dtBscLevel1 = GroupStrategies(MatrixManagerSt.dtManagerSt);

                foreach (DataRow row in dtBscLevel1.Rows)
                {
                    if (dtBscLevel1.Rows.IndexOf(row) <= (dtBscLevel1Temp.Rows.Count - 1))
                    {
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][1] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][1] != null)
                        {
                            row["col2"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][1].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][3] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][3] != null)
                        {
                            row["col4"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][3].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][4] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][4] != null)
                        {
                            row["col5"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][4].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][5] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][5] != null)
                        {
                            row["col6"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][5].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][6] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][6] != null)
                        {
                            row["col7"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][6].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][7] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][7] != null)
                        {
                            row["col8"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][7].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][8] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][8] != null)
                        {
                            row["col9"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][8].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][9] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][9] != null)
                        {
                            row["col10"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][9].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][10] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][10] != null)
                        {
                            row["col11"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][10].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][11] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][11] != null)
                        {
                            row["col12"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][11].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][12] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][12] != null)
                        {
                            row["col13"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][12].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][13] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][13] != null)
                        {
                            row["col14"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][13].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][14] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][14] != null)
                        {
                            row["col15"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][14].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][15] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][15] != null)
                        {
                            row["col16"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][15].ToString();
                        }
                        if (dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][16] != DBNull.Value && dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][16] != null)
                        {
                            row["col17"] = dtBscLevel1Temp.Rows[dtBscLevel1.Rows.IndexOf(row)][16].ToString();
                        }
                    }
                }

                gridControl1.DataSource = null;
                SetGridViewProperties();
                gridControl1.MainView = gridView1;
                gridControl1.DataSource = dtBscLevel1;

                //Se realiza merge inicial.
                _Helper = new MyCellMergeHelper(gridView1);
                _Helper.AddMergedCell3(0, 0, 1, 2, "DIRECCIÓN - OBJETIVOS");
                _Helper.AddMergedCell5(0, 3, 4, 5, 6, 7, "MEDIDAS");
                _Helper.AddMergedCell5(0, 8, 9, 10, 11, 12, "METAS");
                _Helper.AddMergedCell4(0, 13, 14, 15, 16, "MEDIOS");
                _Helper.AddMergedCell3(1, 9, 10, 11, headVariations);

                gridView1.BestFitColumns();
            }
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

            saveDialog.FileName = "BSC_Nivel1_" + DateTime.Now.ToString("yyyyMMdd");


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

        private void gridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.RowHandle1 > 2 && (e.Column.FieldName == "col2" || e.Column.FieldName == "col4" || e.Column.FieldName == "col5" || e.Column.FieldName == "col6" || e.Column.FieldName == "col7" || e.Column.FieldName == "col8" || e.Column.FieldName == "col9" || e.Column.FieldName == "col10" || e.Column.FieldName == "col11" || e.Column.FieldName == "col12" || e.Column.FieldName == "col13" || e.Column.FieldName == "col14" || e.Column.FieldName == "col15" || e.Column.FieldName == "col16" || e.Column.FieldName == "col17"))
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hInfo = view.CalcHitInfo(e.X, e.Y);
            if (hInfo.RowHandle > 2 && hInfo.Column.AbsoluteIndex != 0 && hInfo.Column.AbsoluteIndex != 2 && hInfo.Column.AbsoluteIndex != 15 && hInfo.Column.AbsoluteIndex != 16)
            {
                if (hInfo.InRowCell)
                {
                    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
                    if (cInfo is GridMergedCellInfo)
                    {
                        edit = new MemoEdit();
                        edit.Bounds = cInfo.Bounds;
                        edit.Text = cInfo.CellValue.ToString();
                        gridControl1.Controls.Add(edit);
                    }
                }
            }
            else if (hInfo.RowHandle > 2 && (hInfo.Column.AbsoluteIndex == 15 || hInfo.Column.AbsoluteIndex == 16))
            {
                if (hInfo.InRowCell)
                {
                    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
                    if (cInfo is GridMergedCellInfo)
                    {
                        dateEdit = new DateEdit();
                        dateEdit.Bounds = cInfo.Bounds;
                        dateEdit.Text = cInfo.CellValue.ToString();
                        gridControl1.Controls.Add(dateEdit);
                    }
                }
            }
        }
    }
}
