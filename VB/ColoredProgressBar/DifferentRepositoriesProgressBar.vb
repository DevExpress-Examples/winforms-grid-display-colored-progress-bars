Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing

Namespace ColoredProgressBar
	Friend Class DRProgressBarHelper
		Private Column As GridColumn
		Private View As GridView

		Private prbLess25 As RepositoryItemProgressBar
		Private prbLess50 As RepositoryItemProgressBar
		Private prbLess75 As RepositoryItemProgressBar
		Private prbLess100 As RepositoryItemProgressBar

		Public Sub New(ByVal column As GridColumn)
			PrbInit()
			Me.Column = column
			View = TryCast(Me.Column.View, GridView)
			AddHandler View.CustomRowCellEdit, AddressOf View_CustomRowCellEdit

		End Sub
		Private Sub PrbInit()
			prbLess25 = New RepositoryItemProgressBar()
			prbLess25.StartColor = Color.Red
			prbLess25.EndColor = Color.Red
			prbLess25.ShowTitle = True
			prbLess25.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
			prbLess25.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			prbLess25.LookAndFeel.UseDefaultLookAndFeel = False

			prbLess50 = New RepositoryItemProgressBar()
			prbLess50.StartColor = Color.Orange
			prbLess50.EndColor = Color.Orange
			prbLess50.ShowTitle = True
			prbLess50.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
			prbLess50.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			prbLess50.LookAndFeel.UseDefaultLookAndFeel = False

			prbLess75 = New RepositoryItemProgressBar()
			prbLess75.StartColor = Color.YellowGreen
			prbLess75.EndColor = Color.YellowGreen
			prbLess75.ShowTitle = True
			prbLess75.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
			prbLess75.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			prbLess75.LookAndFeel.UseDefaultLookAndFeel = False

			prbLess100 = New RepositoryItemProgressBar()
			prbLess100.StartColor = Color.Green
			prbLess100.EndColor = Color.Green
			prbLess100.ShowTitle = True
			prbLess100.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
			prbLess100.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			prbLess100.LookAndFeel.UseDefaultLookAndFeel = False

		End Sub

		Private Sub View_CustomRowCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
			If e.Column Is Column Then
				Dim percent As Integer = Convert.ToInt16(e.CellValue)
				If percent < 25 Then
					e.RepositoryItem = prbLess25
				ElseIf percent < 50 Then
					e.RepositoryItem = prbLess50
				ElseIf percent < 75 Then
					e.RepositoryItem = prbLess75
				ElseIf percent <= 100 Then
					e.RepositoryItem = prbLess100
				End If
			End If
		End Sub

	End Class
End Namespace
