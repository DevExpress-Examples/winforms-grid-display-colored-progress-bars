using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace ColoredProgressBar
{
    class DRProgressBarHelper
    {
        GridColumn Column;
        GridView View;

        RepositoryItemProgressBar prbLess25;
        RepositoryItemProgressBar prbLess50;
        RepositoryItemProgressBar prbLess75;
        RepositoryItemProgressBar prbLess100;

        public DRProgressBarHelper(GridColumn column)
        {
            PrbInit();
            Column = column;
            View = Column.View as GridView;
            View.CustomRowCellEdit +=new CustomRowCellEditEventHandler(View_CustomRowCellEdit);

        }
        void PrbInit()
        {
            prbLess25 = new RepositoryItemProgressBar();
            prbLess25.StartColor = Color.Red;
            prbLess25.EndColor = Color.Red;
            prbLess25.ShowTitle = true;
            prbLess25.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess25.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess25.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess50 = new RepositoryItemProgressBar();
            prbLess50.StartColor = Color.Orange;
            prbLess50.EndColor = Color.Orange;
            prbLess50.ShowTitle = true;
            prbLess50.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess50.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess50.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess75 = new RepositoryItemProgressBar();
            prbLess75.StartColor = Color.YellowGreen;
            prbLess75.EndColor = Color.YellowGreen;
            prbLess75.ShowTitle = true;
            prbLess75.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess75.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess75.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess100 = new RepositoryItemProgressBar();
            prbLess100.StartColor = Color.Green;
            prbLess100.EndColor = Color.Green;
            prbLess100.ShowTitle = true;
            prbLess100.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess100.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess100.LookAndFeel.UseDefaultLookAndFeel = false;

        }

        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                if (percent < 25)
                    e.RepositoryItem = prbLess25;
                else if (percent < 50)
                    e.RepositoryItem = prbLess50;
                else if (percent < 75)
                    e.RepositoryItem = prbLess75;
                else if (percent <= 100)
                    e.RepositoryItem = prbLess100;
            }
        }

    }
}
