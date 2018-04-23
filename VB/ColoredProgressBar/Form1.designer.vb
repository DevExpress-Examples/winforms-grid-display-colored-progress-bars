Namespace ColoredProgressBar
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.col1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.col2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.col3 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.col4 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
			Me.col5 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.col6 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
			Me.repositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemProgressBar1, Me.repositoryItemSpinEdit1, Me.repositoryItemButtonEdit1})
			Me.gridControl1.Size = New System.Drawing.Size(1022, 528)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.col1, Me.col2, Me.col3, Me.col4, Me.col5, Me.col6})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.CustomDrawCell += New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(Me.gridView1_CustomDrawCell)
			' 
			' col1
			' 
			Me.col1.Caption = "Manual Draw Without Focus"
			Me.col1.FieldName = "Column"
			Me.col1.Name = "col1"
			Me.col1.OptionsColumn.AllowEdit = False
			Me.col1.OptionsColumn.AllowFocus = False
			Me.col1.Visible = True
			Me.col1.VisibleIndex = 0
			' 
			' col2
			' 
			Me.col2.Caption = "Manual Draw not in Focus"
			Me.col2.FieldName = "Column"
			Me.col2.Name = "col2"
			Me.col2.Visible = True
			Me.col2.VisibleIndex = 1
			' 
			' col3
			' 
			Me.col3.Caption = "Manual Draw Without Editor"
			Me.col3.FieldName = "Column"
			Me.col3.Name = "col3"
			Me.col3.Visible = True
			Me.col3.VisibleIndex = 2
			' 
			' col4
			' 
			Me.col4.Caption = "Manual Draw With Editor"
			Me.col4.ColumnEdit = Me.repositoryItemSpinEdit1
			Me.col4.FieldName = "Column"
			Me.col4.Name = "col4"
			Me.col4.Visible = True
			Me.col4.VisibleIndex = 3
			' 
			' repositoryItemSpinEdit1
			' 
			Me.repositoryItemSpinEdit1.AutoHeight = False
			Me.repositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1"
			' 
			' col5
			' 
			Me.col5.Caption = "Different RepositoryItems"
			Me.col5.FieldName = "Column"
			Me.col5.Name = "col5"
			Me.col5.Visible = True
			Me.col5.VisibleIndex = 4
			' 
			' col6
			' 
			Me.col6.Caption = "Single RepositoryItem"
			Me.col6.ColumnEdit = Me.repositoryItemProgressBar1
			Me.col6.FieldName = "Column"
			Me.col6.Name = "col6"
			Me.col6.Visible = True
			Me.col6.VisibleIndex = 5
			' 
			' repositoryItemProgressBar1
			' 
			Me.repositoryItemProgressBar1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			Me.repositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = False
			Me.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1"
			Me.repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
			Me.repositoryItemProgressBar1.ShowTitle = True
			' 
			' repositoryItemButtonEdit1
			' 
			Me.repositoryItemButtonEdit1.AutoHeight = False
			Me.repositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1022, 528)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private col3 As DevExpress.XtraGrid.Columns.GridColumn
		Private col4 As DevExpress.XtraGrid.Columns.GridColumn
		Private col5 As DevExpress.XtraGrid.Columns.GridColumn
		Private col6 As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
		Private repositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
		Private repositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
		Private col2 As DevExpress.XtraGrid.Columns.GridColumn
		Private col1 As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

