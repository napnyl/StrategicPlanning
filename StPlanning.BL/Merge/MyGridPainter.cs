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
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.ViewInfo;

namespace StPlanning.BL
{
    public class MyGridPainter : GridPainter
    {


        public MyGridPainter(GridView view)
            : base(view)
        {

        }

        private bool _IsCustomPainting;
        public bool IsCustomPainting
        {
            get { return _IsCustomPainting; }
            set { _IsCustomPainting = value; }
        }

        public void DrawMergedCell(MyMergedCell cell, PaintEventArgs e)
        {
            int delta = cell.Column1.VisibleIndex - cell.Column2.VisibleIndex;
            if (Math.Abs(delta)>1)
                return;
            GridViewInfo vi = View.GetViewInfo() as GridViewInfo;
            GridCellInfo gridCellInfo1 = vi.GetGridCellInfo(cell.RowHandle, cell.Column1);
            GridCellInfo gridCellInfo2 = vi.GetGridCellInfo(cell.RowHandle, cell.Column2);
            if (gridCellInfo1 == null || gridCellInfo2 == null)
                return;
            Rectangle targetRect = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds);
            gridCellInfo1.Bounds = targetRect;
            gridCellInfo1.CellValueRect = targetRect;
            gridCellInfo2.Bounds = targetRect;
            gridCellInfo2.CellValueRect = targetRect;
            if (delta < 0)
                gridCellInfo1 = gridCellInfo2;
            Rectangle bounds = gridCellInfo1.ViewInfo.Bounds;
            bounds.Width = targetRect.Width;
            bounds.Height = targetRect.Height;
            gridCellInfo1.ViewInfo.Bounds = bounds;
            gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics);
            IsCustomPainting = true;
            GraphicsCache cache = new GraphicsCache(e.Graphics);
            gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds);
            DrawRowCell(new GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1);
            IsCustomPainting = false; ;
        }

        public void DrawMergedCell(MyMergedCell3 cell, PaintEventArgs e)
        {
            int delta = cell.Column1.VisibleIndex - cell.Column3.VisibleIndex;
            if (Math.Abs(delta) > 2)
                return;
            GridViewInfo vi = View.GetViewInfo() as GridViewInfo;
            GridCellInfo gridCellInfo1 = vi.GetGridCellInfo(cell.RowHandle, cell.Column1);
            GridCellInfo gridCellInfo2 = vi.GetGridCellInfo(cell.RowHandle, cell.Column2);
            GridCellInfo gridCellInfo3 = vi.GetGridCellInfo(cell.RowHandle, cell.Column3);
            if (gridCellInfo1 == null || gridCellInfo2 == null || gridCellInfo3 == null)
                return;
            Rectangle targetRec = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds);
            Rectangle targetRect = Rectangle.Union(targetRec, gridCellInfo3.Bounds);
            gridCellInfo1.Bounds = targetRect;
            gridCellInfo1.CellValueRect = targetRect;
            gridCellInfo2.Bounds = targetRect;
            gridCellInfo2.CellValueRect = targetRect;
            gridCellInfo3.Bounds = targetRect;
            gridCellInfo3.CellValueRect = targetRect;
            if (delta < 0)
                gridCellInfo1 = gridCellInfo2;
            Rectangle bounds = gridCellInfo1.ViewInfo.Bounds;
            bounds.Width = targetRect.Width;
            bounds.Height = targetRect.Height;
            gridCellInfo1.ViewInfo.Bounds = bounds;
            gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics);
            IsCustomPainting = true;
            GraphicsCache cache = new GraphicsCache(e.Graphics);
            gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds);
            DrawRowCell(new GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1);
            IsCustomPainting = false; ;
        }

        public void DrawMergedCell(MyMergedCell4 cell, PaintEventArgs e)
        {
            int delta = cell.Column1.VisibleIndex - cell.Column4.VisibleIndex;
            if (Math.Abs(delta) > 3)
                return;
            GridViewInfo vi = View.GetViewInfo() as GridViewInfo;
            GridCellInfo gridCellInfo1 = vi.GetGridCellInfo(cell.RowHandle, cell.Column1);
            GridCellInfo gridCellInfo2 = vi.GetGridCellInfo(cell.RowHandle, cell.Column2);
            GridCellInfo gridCellInfo3 = vi.GetGridCellInfo(cell.RowHandle, cell.Column3);
            GridCellInfo gridCellInfo4 = vi.GetGridCellInfo(cell.RowHandle, cell.Column4);
            if (gridCellInfo1 == null || gridCellInfo2 == null || gridCellInfo3 == null || gridCellInfo4 == null)
                return;
            Rectangle targetRe = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds);
            Rectangle targetRec = Rectangle.Union(targetRe, gridCellInfo3.Bounds);
            Rectangle targetRect = Rectangle.Union(targetRec, gridCellInfo4.Bounds);
            gridCellInfo1.Bounds = targetRect;
            gridCellInfo1.CellValueRect = targetRect;
            gridCellInfo2.Bounds = targetRect;
            gridCellInfo2.CellValueRect = targetRect;
            gridCellInfo3.Bounds = targetRect;
            gridCellInfo3.CellValueRect = targetRect;
            gridCellInfo4.Bounds = targetRect;
            gridCellInfo4.CellValueRect = targetRect;
            if (delta < 0)
                gridCellInfo1 = gridCellInfo2;
            Rectangle bounds = gridCellInfo1.ViewInfo.Bounds;
            bounds.Width = targetRect.Width;
            bounds.Height = targetRect.Height;
            gridCellInfo1.ViewInfo.Bounds = bounds;
            gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics);
            IsCustomPainting = true;
            GraphicsCache cache = new GraphicsCache(e.Graphics);
            gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds);
            DrawRowCell(new GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1);
            IsCustomPainting = false; ;
        }

        public void DrawMergedCell(MyMergedCell5 cell, PaintEventArgs e)
        {
            int delta = cell.Column1.VisibleIndex - cell.Column5.VisibleIndex;
            if (Math.Abs(delta) > 4)
                return;
            GridViewInfo vi = View.GetViewInfo() as GridViewInfo;
            GridCellInfo gridCellInfo1 = vi.GetGridCellInfo(cell.RowHandle, cell.Column1);
            GridCellInfo gridCellInfo2 = vi.GetGridCellInfo(cell.RowHandle, cell.Column2);
            GridCellInfo gridCellInfo3 = vi.GetGridCellInfo(cell.RowHandle, cell.Column3);
            GridCellInfo gridCellInfo4 = vi.GetGridCellInfo(cell.RowHandle, cell.Column4);
            GridCellInfo gridCellInfo5 = vi.GetGridCellInfo(cell.RowHandle, cell.Column5);
            if (gridCellInfo1 == null || gridCellInfo2 == null || gridCellInfo3 == null || gridCellInfo4 == null || gridCellInfo5 == null)
                return;
            Rectangle targetR = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds);
            Rectangle targetRe = Rectangle.Union(targetR, gridCellInfo3.Bounds);
            Rectangle targetRec = Rectangle.Union(targetRe, gridCellInfo4.Bounds);
            Rectangle targetRect = Rectangle.Union(targetRec, gridCellInfo5.Bounds);
            gridCellInfo1.Bounds = targetRect;
            gridCellInfo1.CellValueRect = targetRect;
            gridCellInfo2.Bounds = targetRect;
            gridCellInfo2.CellValueRect = targetRect;
            gridCellInfo3.Bounds = targetRect;
            gridCellInfo3.CellValueRect = targetRect;
            gridCellInfo4.Bounds = targetRect;
            gridCellInfo4.CellValueRect = targetRect;
            gridCellInfo5.Bounds = targetRect;
            gridCellInfo5.CellValueRect = targetRect;
            if (delta < 0)
                gridCellInfo1 = gridCellInfo2;
            Rectangle bounds = gridCellInfo1.ViewInfo.Bounds;
            bounds.Width = targetRect.Width;
            bounds.Height = targetRect.Height;
            gridCellInfo1.ViewInfo.Bounds = bounds;
            gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics);
            IsCustomPainting = true;
            GraphicsCache cache = new GraphicsCache(e.Graphics);
            gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds);
            DrawRowCell(new GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1);
            IsCustomPainting = false; ;
        }

        public void DrawMergedCell(MyMergedCell6 cell, PaintEventArgs e)
        {
            int delta = cell.Column1.VisibleIndex - cell.Column6.VisibleIndex;
            if (Math.Abs(delta) > 5)
                return;
            GridViewInfo vi = View.GetViewInfo() as GridViewInfo;
            GridCellInfo gridCellInfo1 = vi.GetGridCellInfo(cell.RowHandle, cell.Column1);
            GridCellInfo gridCellInfo2 = vi.GetGridCellInfo(cell.RowHandle, cell.Column2);
            GridCellInfo gridCellInfo3 = vi.GetGridCellInfo(cell.RowHandle, cell.Column3);
            GridCellInfo gridCellInfo4 = vi.GetGridCellInfo(cell.RowHandle, cell.Column4);
            GridCellInfo gridCellInfo5 = vi.GetGridCellInfo(cell.RowHandle, cell.Column5);
            GridCellInfo gridCellInfo6 = vi.GetGridCellInfo(cell.RowHandle, cell.Column6);
            if (gridCellInfo1 == null || gridCellInfo2 == null || gridCellInfo3 == null || gridCellInfo4 == null || gridCellInfo5 == null || gridCellInfo6 == null)
                return;
            Rectangle target = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds);
            Rectangle targetR = Rectangle.Union(target, gridCellInfo3.Bounds);
            Rectangle targetRe = Rectangle.Union(targetR, gridCellInfo4.Bounds);
            Rectangle targetRec = Rectangle.Union(targetRe, gridCellInfo5.Bounds);
            Rectangle targetRect = Rectangle.Union(targetRec, gridCellInfo6.Bounds);
            gridCellInfo1.Bounds = targetRect;
            gridCellInfo1.CellValueRect = targetRect;
            gridCellInfo2.Bounds = targetRect;
            gridCellInfo2.CellValueRect = targetRect;
            gridCellInfo3.Bounds = targetRect;
            gridCellInfo3.CellValueRect = targetRect;
            gridCellInfo4.Bounds = targetRect;
            gridCellInfo4.CellValueRect = targetRect;
            gridCellInfo5.Bounds = targetRect;
            gridCellInfo5.CellValueRect = targetRect;
            gridCellInfo6.Bounds = targetRect;
            gridCellInfo6.CellValueRect = targetRect;
            if (delta < 0)
                gridCellInfo1 = gridCellInfo2;
            Rectangle bounds = gridCellInfo1.ViewInfo.Bounds;
            bounds.Width = targetRect.Width;
            bounds.Height = targetRect.Height;
            gridCellInfo1.ViewInfo.Bounds = bounds;
            gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics);
            IsCustomPainting = true;
            GraphicsCache cache = new GraphicsCache(e.Graphics);
            gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds);
            DrawRowCell(new GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1);
            IsCustomPainting = false; ;
        }

    }   
}
