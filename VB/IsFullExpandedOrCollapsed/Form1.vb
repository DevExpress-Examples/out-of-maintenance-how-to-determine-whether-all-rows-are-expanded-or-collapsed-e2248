Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace IsFullExpandedOrCollapsed
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.Columns("Discontinued").Group()
			gridView1.Columns("Category").Group()
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
			gridView1.OptionsView.ShowAutoFilterRow = True
		End Sub

		Private Function IsFullExpanded(ByVal view As GridView) As Boolean
			If view.GroupCount = 0 Then
				Return True
			End If
			If view.DataRowCount = 0 Then
				Return True
			End If
			For i As Integer = -1 To Integer.MinValue + 1 Step -1
				If (Not view.IsValidRowHandle(i)) Then
					Return True
				End If
				If view.IsGroupRow(i) AndAlso (Not view.GetRowExpanded(i)) Then
					Return False
				End If
			Next i
			Return True
		End Function

		Private Function IsFullCollapsed(ByVal view As GridView) As Boolean
			If view.GroupCount = 0 Then
				Return False
			End If
			If view.DataRowCount = 0 Then
				Return False
			End If
			For i As Integer = -1 To Integer.MinValue + 1 Step -1
				If (Not view.IsValidRowHandle(i)) Then
					Return True
				End If
				If view.IsGroupRow(i) AndAlso view.GetRowExpanded(i) Then
					Return False
				End If
			Next i
			Return True
		End Function

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			MessageBox.Show(String.Format("Fully exapanded: {0}" & Constants.vbLf & "Fully collapsed: {1}", IsFullExpanded(gridView1), IsFullCollapsed(gridView1)))
		End Sub
	End Class
End Namespace
