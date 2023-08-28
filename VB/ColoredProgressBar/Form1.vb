Imports System
Imports System.Data
Imports System.Windows.Forms

Namespace ColoredProgressBar

    Public Partial Class Form1
        Inherits Form

        Private dt As DataTable = New DataTable()

        Public Sub New()
            InitializeComponent()
            dt.Columns.Add("Column")
            For i As Integer = 0 To 100 Step 10
                dt.Rows.Add(i)
            Next
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            gridControl1.DataSource = dt
            Dim customPaintedProgressBarHelper As CustomPaintedProgressBarHelper = New CustomPaintedProgressBarHelper(col4)
            Dim drHelper As DRProgressBarHelper = New DRProgressBarHelper(col5)
        End Sub
    End Class
End Namespace
