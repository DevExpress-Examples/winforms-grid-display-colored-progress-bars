using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ColoredProgressBar
{
    class SRProgressBarHelper
    {
        GridColumn Column;
        GridView View;

        public SRProgressBarHelper(GridColumn column)
        {
            Column = column;
            View = Column.View as GridView;
            View.ShownEditor +=new EventHandler(View_ShownEditor);
            View.CustomDrawCell +=new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(View_CustomDrawCell);
        }
        private void View_ShownEditor(object sender, EventArgs e)
        {
            if (View.FocusedColumn != Column)
                return;
            ProgressBarControl pbc = View.ActiveEditor as ProgressBarControl;
            int percent = Convert.ToInt16(pbc.EditValue);
            if (percent < 25)
            {
                pbc.Properties.EndColor = Color.Red;
                pbc.Properties.StartColor = Color.Red;
            }
            else if (percent < 50)
            {
                pbc.Properties.EndColor = Color.Orange;
                pbc.Properties.StartColor = Color.Orange;
            }
            else if (percent < 75)
            {
                pbc.Properties.EndColor = Color.YellowGreen;
                pbc.Properties.StartColor = Color.YellowGreen;
            }
            else if (percent <= 100)
            {
                pbc.Properties.EndColor = Color.Green;
                pbc.Properties.StartColor = Color.Green;
            }


        }

        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                ProgressBarViewInfo vi = (e.Cell as GridCellInfo).ViewInfo as ProgressBarViewInfo;
                if (percent < 25)
                {
                    vi.ProgressInfo.EndColor = Color.Red;
                    vi.ProgressInfo.StartColor = Color.Red;
                }
                else if (percent < 50)
                {
                    vi.ProgressInfo.EndColor = Color.Orange;
                    vi.ProgressInfo.StartColor = Color.Orange;
                }
                else if (percent < 75)
                {
                    vi.ProgressInfo.EndColor = Color.YellowGreen;
                    vi.ProgressInfo.StartColor = Color.YellowGreen;
                }
                else if (percent <= 100)
                {
                    vi.ProgressInfo.EndColor = Color.Green;
                    vi.ProgressInfo.StartColor = Color.Green;
                }
            }
        }


    }
}
