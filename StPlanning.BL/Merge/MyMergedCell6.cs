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
    public class MyMergedCell6
    {

        public MyMergedCell6(int rowHandle, GridColumn col1, GridColumn col2, GridColumn col3, GridColumn col4, GridColumn col5, GridColumn col6)
        {
            _RowHandle = rowHandle;
            _Column1 = col1;
            _Column2 = col2;
            _Column3 = col3;
            _Column4 = col4;
            _Column5 = col5;
            _Column6 = col6;
        }

        private GridColumn _Column6;
        private GridColumn _Column5;
        private GridColumn _Column4;
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

        public GridColumn Column4
        {
            get { return _Column4; }
            set
            {
                _Column4 = value;

            }
        }

        public GridColumn Column5
        {
            get { return _Column5; }
            set
            {
                _Column5 = value;

            }
        }

        public GridColumn Column6
        {
            get { return _Column6; }
            set
            {
                _Column6 = value;

            }
        }

    }
}
