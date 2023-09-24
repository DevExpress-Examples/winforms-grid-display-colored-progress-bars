<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128632209/23.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3193)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Display colored progress bars

![](https://raw.githubusercontent.com/DevExpress-Examples/how-to-use-different-colored-progressbar-in-gridcontrol-e3193/23.1.3%2B/media/winforms-grid-custom-progress-bar.png)

There are several ways to display colored progress bars within grid cells.

## Use RepositoryItemProgressBar objects and handle events

Handle the [CustomRowCellEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomRowCellEdit) to assign different repository items ([RepositoryItemProgressBar](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItemProgressBar)) to data cells. Supports printing and data export.

```csharp
void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
    if (e.Column == _Column) {
        int percent = Convert.ToInt16(e.CellValue);
        if (percent < 25)
            e.RepositoryItem = _prbLess25;
        else if (percent < 50)
            e.RepositoryItem = _prbLess50;
        else if (percent < 75)
            e.RepositoryItem = _prbLess75;
        else if (percent <= 100)
            e.RepositoryItem = _prbLess100;
    }
}
```

## Manually draw progress bars in cells

[Custom painting](https://docs.devexpress.com/WindowsForms/762/controls-and-libraries/data-grid/appearance-and-conditional-formatting/custom-painting/custom-painting-basics) allows you to draw cell content (progress bars) as needed. Note that the Grid control cannot print and export custom painted content out of the box.

```csharp
void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
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
```

## Files to Reivew

* [DifferentRepositoriesProgressBar.cs](./CS/ColoredProgressBar/DifferentRepositoriesProgressBar.cs) (VB: [DifferentRepositoriesProgressBar.vb](./VB/ColoredProgressBar/DifferentRepositoriesProgressBar.vb))
* [CustomPaintedProgressBarHelper.cs](./CS/ColoredProgressBar/CustomPaintedProgressBarHelper.cs) (VB: [CustomPaintedProgressBarHelper.vb](./VB/ColoredProgressBar/CustomPaintedProgressBarHelper.vb))
* [Form1.cs](./CS/ColoredProgressBar/Form1.cs) (VB: [Form1.vb](./VB/ColoredProgressBar/Form1.vb))


## Documentation

* [Assign Different Editors to Cells in a Column](https://docs.devexpress.com/WindowsForms/753/controls-and-libraries/data-grid/data-editing-and-validation/modify-and-validate-cell-values#assign-different-editors-to-cells-in-a-column)
* [Custom Painting](https://docs.devexpress.com/WindowsForms/762/controls-and-libraries/data-grid/appearance-and-conditional-formatting/custom-painting/custom-painting-basics)


## See Also

* [Replace Default Cell Editors - Cheat Sheets and Best Practices](https://supportcenter.devexpress.com/ticket/details/t923817/replace-default-cell-editors-winforms-cheat-sheet)
