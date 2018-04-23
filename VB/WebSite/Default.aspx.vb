Imports Microsoft.VisualBasic
Imports System
Imports System.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private table As DataTable

	Private ReadOnly Property DataTable() As DataTable
		Get
			If Session("DataTable") Is Nothing Then
				InitializeDataTable()
				Session("DataTable") = table
			End If
			table = CType(Session("DataTable"), DataTable)
			Return table
		End Get
	End Property

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		gv.DataSource = DataTable
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			gv.DataBind()
		End If
	End Sub

	Private Sub InitializeDataTable()
		table = New DataTable("Table")
		Dim column As DataColumn

		column = New DataColumn()
		column.DataType = GetType(Integer)
		column.ColumnName = "ID"
		table.Columns.Add(column)

		table.PrimaryKey = New DataColumn() { column }

		column = New DataColumn()
		column.DataType = GetType(DateTime)
		column.ColumnName = "From"
		table.Columns.Add(column)

		column = New DataColumn()
		column.DataType = GetType(DateTime)
		column.ColumnName = "To"
		table.Columns.Add(column)

		PopulateDataTable()
	End Sub

	Private Sub PopulateDataTable()
		Dim row As DataRow
		Dim d As DateTime = DateTime.Now
		For i As Integer = 0 To 1
			row = table.NewRow()
			row("ID") = i
			row("From") = New DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second)
			row("To") = New DateTime(d.Year, d.Month, d.Day + 1, d.Hour + 1, d.Minute, d.Second)
			table.Rows.Add(row)
		Next i
	End Sub
End Class