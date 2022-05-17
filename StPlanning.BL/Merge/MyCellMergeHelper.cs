using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Columns;

namespace StPlanning.BL
{
    public class MyCellMergeHelper
    {
        private List<MyMergedCell> _MergedCells = new List<MyMergedCell>();
        private List<MyMergedCell3> _MergedCells3 = new List<MyMergedCell3>();
        private List<MyMergedCell4> _MergedCells4 = new List<MyMergedCell4>();
        private List<MyMergedCell5> _MergedCells5 = new List<MyMergedCell5>();
        private List<MyMergedCell6> _MergedCells6 = new List<MyMergedCell6>();

        public List<MyMergedCell> MergedCells
        {
            get { return _MergedCells; }
        }

        public List<MyMergedCell3> MergedCells3
        {
            get { return _MergedCells3; }
        }

        public List<MyMergedCell4> MergedCells4
        {
            get { return _MergedCells4; }
        }

        public List<MyMergedCell5> MergedCells5
        {
            get { return _MergedCells5; }
        }

        public List<MyMergedCell6> MergedCells6
        {
            get { return _MergedCells6; }
        }

        MyGridPainter painter;


        GridView _view;

        public MyCellMergeHelper(GridView view)
        {
            _view = view;
            view.CustomDrawCell += new RowCellCustomDrawEventHandler(view_CustomDrawCell);
            view.GridControl.Paint += new PaintEventHandler(GridControl_Paint);
            view.CellValueChanged += new CellValueChangedEventHandler(view_CellValueChanged);
            painter = new MyGridPainter(view);
        }

        public MyMergedCell AddMergedCell(int rowHandle, GridColumn col1, GridColumn col2)
        {
            MyMergedCell cell = new MyMergedCell(rowHandle, col1, col2);
            _MergedCells.Add(cell);
            return cell;
        }

        public MyMergedCell3 AddMergedCell3(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3)
        {
            MyMergedCell3 cell3 = new MyMergedCell3(rowHandle, col1, col2,col3);
            _MergedCells3.Add(cell3);
            return cell3;
        }

        public MyMergedCell4 AddMergedCell4(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3, GridColumn col4)
        {
            MyMergedCell4 cell4 = new MyMergedCell4(rowHandle, col1, col2, col3,col4);
            _MergedCells4.Add(cell4);
            return cell4;
        }

        public MyMergedCell5 AddMergedCell5(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3, GridColumn col4, GridColumn col5)
        {
            MyMergedCell5 cell5 = new MyMergedCell5(rowHandle, col1, col2, col3, col4, col5);
            _MergedCells5.Add(cell5);
            return cell5;
        }

        public MyMergedCell6 AddMergedCell6(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3, GridColumn col4, GridColumn col5, GridColumn col6)
        {
            MyMergedCell6 cell6 = new MyMergedCell6(rowHandle, col1, col2, col3, col4, col5, col6);
            _MergedCells6.Add(cell6);
            return cell6;
        }

        public void AddMergedCell(int rowHandle, int col1, int col2, object value)
        {
            AddMergedCell(rowHandle, _view.Columns[col1], _view.Columns[col2]);
        }

        public void AddMergedCell3(int rowHandle, int col1, int col2, int col3, object value)
        {
            MyMergedCell3 cell = AddMergedCell3(rowHandle, _view.Columns[col1], _view.Columns[col2], _view.Columns[col3]);
            SafeSetMergedCellValue(cell, value);
        }

        public void AddMergedCell4(int rowHandle, int col1, int col2, int col3, int col4, object value)
        {
            MyMergedCell4 cell = AddMergedCell4(rowHandle, _view.Columns[col1], _view.Columns[col2], _view.Columns[col3], _view.Columns[col4]);
            SafeSetMergedCellValue(cell, value);
        }

        public void AddMergedCell5(int rowHandle, int col1, int col2, int col3, int col4, int col5, object value)
        {
            MyMergedCell5 cell = AddMergedCell5(rowHandle, _view.Columns[col1], _view.Columns[col2], _view.Columns[col3], _view.Columns[col4], _view.Columns[col5]);
            SafeSetMergedCellValue(cell, value);
        }

        public void AddMergedCell6(int rowHandle, int col1, int col2, int col3, int col4, int col5, int col6, object value)
        {
            MyMergedCell6 cell= AddMergedCell6(rowHandle, _view.Columns[col1], _view.Columns[col2], _view.Columns[col3], _view.Columns[col4], _view.Columns[col5], _view.Columns[col6]);
            SafeSetMergedCellValue(cell, value);
        }

        public void AddMergedCell(int rowHandle, GridColumn col1, GridColumn col2, object value)
        {
            MyMergedCell cell = AddMergedCell(rowHandle, col1, col2);
            SafeSetMergedCellValue(cell, value);
        }



        public void SafeSetMergedCellValue(MyMergedCell cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
            }
        }

        public void SafeSetMergedCellValue(MyMergedCell3 cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
                SafeSetCellValue(cell.RowHandle, cell.Column3, value);
            }
        }

        public void SafeSetMergedCellValue(MyMergedCell4 cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
                SafeSetCellValue(cell.RowHandle, cell.Column3, value);
                SafeSetCellValue(cell.RowHandle, cell.Column4, value);
            }
        }

        public void SafeSetMergedCellValue(MyMergedCell5 cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
                SafeSetCellValue(cell.RowHandle, cell.Column3, value);
                SafeSetCellValue(cell.RowHandle, cell.Column4, value);
                SafeSetCellValue(cell.RowHandle, cell.Column5, value);
            }
        }

        public void SafeSetMergedCellValue(MyMergedCell6 cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
                SafeSetCellValue(cell.RowHandle, cell.Column3, value);
                SafeSetCellValue(cell.RowHandle, cell.Column4, value);
                SafeSetCellValue(cell.RowHandle, cell.Column5, value);
                SafeSetCellValue(cell.RowHandle, cell.Column6, value);
            }
        }

        public void SafeSetCellValue(int rowHandle, GridColumn column, object value)
        {
            if (_view.GetRowCellValue(rowHandle, column) != value)
                _view.SetRowCellValue(rowHandle, column, value);
        }


        private MyMergedCell GetMergedCell(int rowHandle, GridColumn column)
        {
            foreach (MyMergedCell cell in _MergedCells)
            {
                if (cell.RowHandle == rowHandle && (column == cell.Column1 || column == cell.Column2))
                    return cell;
            }
            return null;
        }

        private bool IsMergedCell(int rowHandle, GridColumn column)
        {
            return GetMergedCell(rowHandle, column) != null;
        }

        private void DrawMergedCells(PaintEventArgs e)
        {
            foreach (MyMergedCell cell in _MergedCells)
            {
                painter.DrawMergedCell(cell, e);
            }

            foreach (MyMergedCell3 cell in _MergedCells3)
            {
                painter.DrawMergedCell(cell, e);
            }

            foreach (MyMergedCell4 cell in _MergedCells4)
            {
                painter.DrawMergedCell(cell, e);
            }

            foreach (MyMergedCell5 cell in _MergedCells5)
            {
                painter.DrawMergedCell(cell, e);
            }

            foreach (MyMergedCell6 cell in _MergedCells6)
            {
                painter.DrawMergedCell(cell, e);
            }
        }


        void view_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SafeSetMergedCellValue(GetMergedCell(e.RowHandle, e.Column), e.Value);  
        }

        void GridControl_Paint(object sender, PaintEventArgs e)
        {
            DrawMergedCells(e);
        }

        void view_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (IsMergedCell(e.RowHandle, e.Column))
                e.Handled = !painter.IsCustomPainting;
        }
     
    }
}