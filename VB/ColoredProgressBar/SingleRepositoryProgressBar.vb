Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Drawing

Namespace ColoredProgressBar

    Friend Class SRProgressBarHelper

        Private _Column As GridColumn

        Private _View As GridView

        Public Sub New(ByVal column As GridColumn)
            _Column = column
            _View = TryCast(_Column.View, GridView)
            AddHandler _View.ShownEditor, New EventHandler(AddressOf View_ShownEditor)
            AddHandler _View.CustomDrawCell, New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(AddressOf View_CustomDrawCell)
        End Sub

        Private Sub View_ShownEditor(ByVal sender As Object, ByVal e As EventArgs)
            If _View.FocusedColumn IsNot _Column Then Return
            Dim pbc As ProgressBarControl = TryCast(_View.ActiveEditor, ProgressBarControl)
            Dim percent As Integer = Convert.ToInt16(pbc.EditValue)
            If percent < 25 Then
                pbc.Properties.EndColor = Color.Red
                pbc.Properties.StartColor = Color.Red
            ElseIf percent < 50 Then
                pbc.Properties.EndColor = Color.Orange
                pbc.Properties.StartColor = Color.Orange
            ElseIf percent < 75 Then
                pbc.Properties.EndColor = Color.YellowGreen
                pbc.Properties.StartColor = Color.YellowGreen
            ElseIf percent <= 100 Then
                pbc.Properties.EndColor = Color.Green
                pbc.Properties.StartColor = Color.Green
            End If
        End Sub

        Private Sub View_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            If e.Column Is _Column Then
                Dim percent As Integer = Convert.ToInt16(e.CellValue)
                Dim vi As ProgressBarViewInfo = TryCast(TryCast(e.Cell, GridCellInfo).ViewInfo, ProgressBarViewInfo)
                If percent < 25 Then
                    vi.ProgressInfo.EndColor = Color.Red
                    vi.ProgressInfo.StartColor = Color.Red
                ElseIf percent < 50 Then
                    vi.ProgressInfo.EndColor = Color.Orange
                    vi.ProgressInfo.StartColor = Color.Orange
                ElseIf percent < 75 Then
                    vi.ProgressInfo.EndColor = Color.YellowGreen
                    vi.ProgressInfo.StartColor = Color.YellowGreen
                ElseIf percent <= 100 Then
                    vi.ProgressInfo.EndColor = Color.Green
                    vi.ProgressInfo.StartColor = Color.Green
                End If
            End If
        End Sub
    End Class
End Namespace
