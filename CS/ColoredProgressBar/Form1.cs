using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace ColoredProgressBar
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            dt.Columns.Add("Column");
            for (int i = 0; i <= 100;i+=10 )
                dt.Rows.Add(i);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            DRProgressBarHelper drHelper = new DRProgressBarHelper(col5);
            SRProgressBarHelper srHelper = new SRProgressBarHelper(col6);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if ((e.Column == col3) || (e.Column == col4))
            {
                DrawFocusRect(sender, e);
                e.Handled = true;
            }
            if ((e.Column == col3) || (e.Column == col4) || (e.Column == col1) || (e.Column == col2))
            {
                DrawProgressBar(e);
            }
            if (e.Column == col4)
            {
                DrawEditor(e);
                e.Handled = true;
            }
        }

        void DrawFocusRect(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridCellInfo cell = e.Cell as GridCellInfo;
            e.Cache.Paint.FillRectangle(e.Cache, e.Appearance, e.Bounds);
            bool isFocusCell = (cell.State & GridRowCellState.FocusedCell) != 0 && (cell.State & GridRowCellState.GridFocused) != 0;
            if (isFocusCell && (sender as GridView).FocusRectStyle == DrawFocusRectStyle.CellFocus)
                e.Cache.Paint.DrawFocusRectangle(e.Graphics, cell.Bounds, cell.Appearance.GetForeColor(), cell.Appearance.GetBackColor());
        }
        void DrawEditor(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridCellInfo cell = e.Cell as GridCellInfo;
            Point offset = cell.CellValueRect.Location;
            BaseEditPainter pb = cell.ViewInfo.Painter as BaseEditPainter;
            AppearanceObject savedStyle = cell.ViewInfo.PaintAppearance;
            if (!offset.IsEmpty)
                cell.ViewInfo.Offset(offset.X, offset.Y);
            try
            {
                pb.Draw(new ControlGraphicsInfoArgs(cell.ViewInfo, e.Cache, cell.Bounds));
            }
            finally
            {
                if (!offset.IsEmpty)
                    cell.ViewInfo.Offset(-offset.X, -offset.Y);
            }

        }
        void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
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
            e.Cache.Paint.FillRectangle(e.Cache.Graphics, b, rect);
        }
    }
}
