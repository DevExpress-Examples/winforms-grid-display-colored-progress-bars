Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace ColoredProgressBar
	Friend Class SRProgressBarHelper
		Private Column As GridColumn
		Private View As GridView

		Public Sub New(ByVal column As GridColumn)
			Me.Column = column
			View = TryCast(Me.Column.View, GridView)
			AddHandler View.ShownEditor, AddressOf View_ShownEditor
			AddHandler View.CustomDrawCell, AddressOf View_CustomDrawCell
		End Sub
		Private Sub View_ShownEditor(ByVal sender As Object, ByVal e As EventArgs)
			If View.FocusedColumn IsNot Column Then
				Return
			End If
			Dim pbc As ProgressBarControl = TryCast(View.ActiveEditor, ProgressBarControl)
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

			If e.Column Is Column Then
				Dim percent As Integer = Convert.ToInt16(e.CellValue)
				Dim vi As ProgressBarViewInfo = TryCast((TryCast(e.Cell, GridCellInfo)).ViewInfo, ProgressBarViewInfo)
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
