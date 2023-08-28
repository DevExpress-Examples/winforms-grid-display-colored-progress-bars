Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Drawing

Namespace ColoredProgressBar

    Friend Class DRProgressBarHelper

        Private _Column As GridColumn

        Private _View As GridView

        Private _prbLess25 As RepositoryItemProgressBar

        Private _prbLess50 As RepositoryItemProgressBar

        Private _prbLess75 As RepositoryItemProgressBar

        Private _prbLess100 As RepositoryItemProgressBar

        Public Sub New(ByVal column As GridColumn)
            PrbInit()
            _Column = column
            _View = TryCast(_Column.View, GridView)
            AddHandler _View.CustomRowCellEdit, New CustomRowCellEditEventHandler(AddressOf View_CustomRowCellEdit)
        End Sub

        Private Sub PrbInit()
            _prbLess25 = New RepositoryItemProgressBar()
            _prbLess25.StartColor = Color.Red
            _prbLess25.EndColor = Color.Red
            _prbLess25.ShowTitle = True
            _prbLess25.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
            _prbLess25.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
            _prbLess25.LookAndFeel.UseDefaultLookAndFeel = False
            _prbLess50 = New RepositoryItemProgressBar()
            _prbLess50.StartColor = Color.Orange
            _prbLess50.EndColor = Color.Orange
            _prbLess50.ShowTitle = True
            _prbLess50.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
            _prbLess50.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
            _prbLess50.LookAndFeel.UseDefaultLookAndFeel = False
            _prbLess75 = New RepositoryItemProgressBar()
            _prbLess75.StartColor = Color.YellowGreen
            _prbLess75.EndColor = Color.YellowGreen
            _prbLess75.ShowTitle = True
            _prbLess75.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
            _prbLess75.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
            _prbLess75.LookAndFeel.UseDefaultLookAndFeel = False
            _prbLess100 = New RepositoryItemProgressBar()
            _prbLess100.StartColor = Color.Green
            _prbLess100.EndColor = Color.Green
            _prbLess100.ShowTitle = True
            _prbLess100.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
            _prbLess100.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
            _prbLess100.LookAndFeel.UseDefaultLookAndFeel = False
        End Sub

        Private Sub View_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
            If e.Column Is _Column Then
                Dim percent As Integer = Convert.ToInt16(e.CellValue)
                If percent < 25 Then
                    e.RepositoryItem = _prbLess25
                ElseIf percent < 50 Then
                    e.RepositoryItem = _prbLess50
                ElseIf percent < 75 Then
                    e.RepositoryItem = _prbLess75
                ElseIf percent <= 100 Then
                    e.RepositoryItem = _prbLess100
                End If
            End If
        End Sub
    End Class
End Namespace
