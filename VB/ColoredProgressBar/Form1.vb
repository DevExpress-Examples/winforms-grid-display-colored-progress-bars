Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Namespace ColoredProgressBar
	Partial Public Class Form1
		Inherits Form

		Private dt As New DataTable()
		Public Sub New()
			InitializeComponent()
			dt.Columns.Add("Column")
			For i As Integer = 0 To 100 Step 10
				dt.Rows.Add(i)
			Next i
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			gridControl1.DataSource = dt
			Dim drHelper As New DRProgressBarHelper(col5)
			Dim srHelper As New SRProgressBarHelper(col6)
		End Sub

		Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gridView1.CustomDrawCell

			If (e.Column Is col3) OrElse (e.Column Is col4) Then
				DrawFocusRect(sender, e)
				e.Handled = True
			End If
			If (e.Column Is col3) OrElse (e.Column Is col4) OrElse (e.Column Is col1) OrElse (e.Column Is col2) Then
				DrawProgressBar(e)
			End If
			If e.Column Is col4 Then
				DrawEditor(e)
				e.Handled = True
			End If
		End Sub

		Private Sub DrawFocusRect(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
			Dim cell As GridCellInfo = TryCast(e.Cell, GridCellInfo)
			e.Cache.Paint.FillRectangle(e.Cache, e.Appearance, e.Bounds)
			Dim isFocusCell As Boolean = (cell.State And GridRowCellState.FocusedCell) <> 0 AndAlso (cell.State And GridRowCellState.GridFocused) <> 0
			If isFocusCell AndAlso (TryCast(sender, GridView)).FocusRectStyle = DrawFocusRectStyle.CellFocus Then
				e.Cache.Paint.DrawFocusRectangle(e.Graphics, cell.Bounds, cell.Appearance.GetForeColor(), cell.Appearance.GetBackColor())
			End If
		End Sub
		Private Sub DrawEditor(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
			Dim cell As GridCellInfo = TryCast(e.Cell, GridCellInfo)
			Dim offset As Point = cell.CellValueRect.Location
			Dim pb As BaseEditPainter = TryCast(cell.ViewInfo.Painter, BaseEditPainter)
			Dim savedStyle As AppearanceObject = cell.ViewInfo.PaintAppearance
			If Not offset.IsEmpty Then
				cell.ViewInfo.Offset(offset.X, offset.Y)
			End If
			Try
				pb.Draw(New ControlGraphicsInfoArgs(cell.ViewInfo, e.Cache, cell.Bounds))
			Finally
				If Not offset.IsEmpty Then
					cell.ViewInfo.Offset(-offset.X, -offset.Y)
				End If
			End Try

		End Sub
		Private Sub DrawProgressBar(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
			Dim percent As Integer = Convert.ToInt16(e.CellValue)

			Dim v As Integer = Convert.ToInt32(e.CellValue)
			v = v * e.Bounds.Width \ 100
			Dim rect As New Rectangle(e.Bounds.X, e.Bounds.Y, v, e.Bounds.Height)
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
	End Class
End Namespace
