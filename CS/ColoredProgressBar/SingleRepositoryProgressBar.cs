using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Drawing;

namespace ColoredProgressBar {
    class SRProgressBarHelper {
        GridColumn _Column;
        GridView _View;
        public SRProgressBarHelper(GridColumn column) {
            _Column = column;
            _View = _Column.View as GridView;
            _View.ShownEditor += new EventHandler(View_ShownEditor);
            _View.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(View_CustomDrawCell);
        }
        private void View_ShownEditor(object sender, EventArgs e) {
            if (_View.FocusedColumn != _Column)
                return;
            ProgressBarControl pbc = _View.ActiveEditor as ProgressBarControl;
            int percent = Convert.ToInt16(pbc.EditValue);
            if (percent < 25) {
                pbc.Properties.EndColor = Color.Red;
                pbc.Properties.StartColor = Color.Red;
            } else if (percent < 50) {
                pbc.Properties.EndColor = Color.Orange;
                pbc.Properties.StartColor = Color.Orange;
            } else if (percent < 75) {
                pbc.Properties.EndColor = Color.YellowGreen;
                pbc.Properties.StartColor = Color.YellowGreen;
            } else if (percent <= 100) {
                pbc.Properties.EndColor = Color.Green;
                pbc.Properties.StartColor = Color.Green;
            }
        }
        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            if (e.Column == _Column) {
                int percent = Convert.ToInt16(e.CellValue);
                ProgressBarViewInfo vi = (e.Cell as GridCellInfo).ViewInfo as ProgressBarViewInfo;
                if (percent < 25) {
                    vi.ProgressInfo.EndColor = Color.Red;
                    vi.ProgressInfo.StartColor = Color.Red;
                } else if (percent < 50) {
                    vi.ProgressInfo.EndColor = Color.Orange;
                    vi.ProgressInfo.StartColor = Color.Orange;
                } else if (percent < 75) {
                    vi.ProgressInfo.EndColor = Color.YellowGreen;
                    vi.ProgressInfo.StartColor = Color.YellowGreen;
                } else if (percent <= 100) {
                    vi.ProgressInfo.EndColor = Color.Green;
                    vi.ProgressInfo.StartColor = Color.Green;
                }
            }
        }
    }
}
