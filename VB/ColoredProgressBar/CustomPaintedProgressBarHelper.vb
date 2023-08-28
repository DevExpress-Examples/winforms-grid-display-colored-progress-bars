Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
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
                e.DefaultDraw()
                DrawProgressBar(e)
                DrawEditor(e)
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

            e.Cache.Paint.FillRectangle(e.Cache.Graphics, b, rect)
        End Sub

        Private Sub DrawEditor(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            Dim cell As GridCellInfo = TryCast(e.Cell, GridCellInfo)
            Dim offset As Point = cell.CellValueRect.Location
            Dim pb As BaseEditPainter = TryCast(cell.ViewInfo.Painter, BaseEditPainter)
            If Not offset.IsEmpty Then cell.ViewInfo.Offset(offset.X, offset.Y)
            Try
                pb.Draw(New ControlGraphicsInfoArgs(cell.ViewInfo, e.Cache, cell.Bounds))
            Finally
                If Not offset.IsEmpty Then cell.ViewInfo.Offset(-offset.X, -offset.Y)
            End Try
        End Sub
    End Class
End Namespace
