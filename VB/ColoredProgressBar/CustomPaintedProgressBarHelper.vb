Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Drawing

Namespace ColoredProgressBar

    Public Class CustomPaintedProgressBarHelper

        Private _Column As GridColumn

        Private _View As GridView

        Public Sub New(ByVal column As GridColumn)
            _Column = column
            _View = TryCast(_Column.View, GridView)
            AddHandler _View.CustomDrawCell, New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(AddressOf View_CustomDrawCell)
        End Sub

        Private Sub View_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            If e.Column Is _Column Then
                DrawProgressBar(e)
                e.DefaultDraw()
                e.Handled = True
            End If
        End Sub

        Private Sub DrawProgressBar(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            Dim percent As Integer = Convert.ToInt16(e.CellValue)
            Dim v As Integer = Convert.ToInt32(e.CellValue)
            v = v * e.Bounds.Width \ 100
            Dim rect As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Y, v, e.Bounds.Height)
            Dim b As Brush = Brushes.Green
            If percent < 25 Then
                b = Brushes.Red
            ElseIf percent < 50 Then
                b = Brushes.Orange
            ElseIf percent < 75 Then
                b = Brushes.YellowGreen
            End If

            e.Cache.FillRectangle(b, rect)
        End Sub
    End Class
End Namespace
