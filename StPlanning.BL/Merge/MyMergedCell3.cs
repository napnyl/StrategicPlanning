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
using DevExpress.XtraGrid.Columns;

namespace StPlanning.BL
{
    public class MyMergedCell3
    {

        public MyMergedCell3(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3)
        {
            _RowHandle = rowHandle;
            _Column1 = col1;
            _Column2 = col2;
            _Column3 = col3;
        }

        private GridColumn _Column3;
        private GridColumn _Column2;
        private GridColumn _Column1;

        private int _RowHandle;
        public int RowHandle
        {
            get { return _RowHandle; }
            set { _RowHandle = value; }
        }


        public GridColumn Column1
        {
            get { return _Column1; }
            set
            {
                _Column1 = value;

            }
        }


        public GridColumn Column2
        {
            get { return _Column2; }
            set
            {
                _Column2 = value;

            }
        }

        public GridColumn Column3
        {
            get { return _Column3; }
            set
            {
                _Column3 = value;

            }
        }

    }
}
