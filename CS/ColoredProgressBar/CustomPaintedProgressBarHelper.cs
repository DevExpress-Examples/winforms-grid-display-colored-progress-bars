using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;

namespace ColoredProgressBar {
    public class CustomPaintedProgressBarHelper {
        GridColumn _Column;
        GridView _View;
        public CustomPaintedProgressBarHelper(GridColumn column) {
            _Column = column;
            _View = _Column.View as GridView;
            _View.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(View_CustomDrawCell);
        }
        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            if (e.Column == _Column) {
                DrawProgressBar(e);
                e.DefaultDraw();
                e.Handled = true;
            }
        }
        void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            int percent = Convert.ToInt16(e.CellValue);
            int v = Convert.ToInt32(e.CellValue);
            v = v * e.Bounds.Width / 100;
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, v, e.Bounds.Height);
            Brush b = Brushes.Green;
            if (percent < 25)
                b = Brushes.Red;
            else if (percent < 50)
                b = Brushes.Orange;
            else if (percent < 75)
                b = Brushes.YellowGreen;
            e.Cache.FillRectangle(b, rect);
        }
    }
}
