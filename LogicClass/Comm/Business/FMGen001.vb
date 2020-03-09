Imports Acer.Log 
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Form 
Imports Acer.File
Imports Acer.Apps
Imports System.Data.Common
Imports System.Reflection.MethodBase
Imports System.Collections
Imports Acer.Form.FormUtil
Imports Comm.Data
Imports System.IO

NameSpace Comm.Business
	''' <summary>
	''' FM Class FMGen001
	''' </summary>
	''' <remarks></remarks> 
	Public Class FMGen001
		Inherits Acer.Base.FMBase

	#Region "屬性設定"
		#Region "TableName"
		''' <summary>
		''' TableName
		''' </summary>
		Public Property TableName As String
			Get
				Return Me.PropertyMap("TableName")
			End Get
			Set(ByVal value As string)
				Me.PropertyMap("TableName")	=	value
			End Set
		End Property
		#End Region	
	#End Region

	#Region "建構子"
		''' <summary>
		''' 建構子
		''' </summary>
		''' <param name="page">Page 物件</param>
		Public Sub New (ByVal page As Acer.Base.PageBase)
			MyBase.New(page)
		End Sub
	#End Region

	#Region "方法"
		#Region "Do01PageLoad 01 頁面 PageLoad 事件"
		''' <summary>
		''' 處理修改資料動作
		''' </summary>
		Public Sub Do01PageLoad()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			If Not Me.Page.IsPostBack Then
				'=== 抓取資料來源 ===
				Dim	dl	As	DropDownList	=	Me.DropDownList("DATA_SOURCE")
				Dim	content	As	ArrayList	=	FileUtil.ReadFile(APConfig.GetProperty("REAL_PATH") & "\conf\db.conf", "#", System.Text.Encoding.Default)
				Dim	conStr	AS	String

				For i As Integer = 0 To content.Count - 1
					conStr	=	content(i).ToString.Split("_")(0)
					dl.Items.Add(New ListItem(conStr, conStr))
				Next
				FormUtil.SetDropdownListEmptyList(dl, UIType.Query)
			End If

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region

		#Region "InitTableList 初始化 Table 清單下拉選項"
		''' <summary>
		''' 初始化 Table 清單下拉選項
		''' </summary>
		''' <remarks></remarks>
		Public Sub InitTableList()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Dim	conn	As	DbConnection	=	Me.DBManager.GetIConnection(Me.DropDownList("DATA_SOURCE").SelectedValue)
			Dim	dl	As	DropDownList	=	Me.DropDownList("TABLE_LIST")
			Dim	dBType	As	String		=	Me.DBManager.GetDBType(conn)
			Dim	table	AS	String

			dl.Items.Clear()

			If dBType = "SQL2005" Then
				Dim	rs	As	IDBResult	=	dbManager.GetResultSet(conn)

				rs.ExecuteQuery("SELECT NAME FROM SYS.TABLES WHERE TYPE='U' ORDER BY NAME")
				
				While rs.Next
					table	=	rs.GetString("NAME")
					dl.Items.Add(New ListItem(table, table))
				End While
			ElseIf dBType = "ORACLE" Then
				Dim	dt	As	DataTable	=	conn.GetSchema("Tables")

				Dim	dataAl	As	ArrayList	=	new ArrayList()
				For i As Integer = 0 to dt.Rows.Count - 1
					'If dt.Rows(i)("TABLE_NAME").ToString.IndexOf("CLASS") <> -1 Then
					'	table	=	dt.Rows(i)("TABLE_NAME")
					'	dl.Items.Add(New ListItem(table, table))
					'End If
					If dt.Rows(i)("TABLE_NAME").ToString.IndexOf("$") <> -1 Or _
					dt.Rows(i)("TABLE_NAME").ToString.IndexOf("SDO_") <> -1 Or _
					dt.Rows(i)("TABLE_NAME").ToString.IndexOf("WWV_") <> -1 Or _
					dt.Rows(i)("TABLE_NAME").ToString.IndexOf("HELP") <> -1 Then
						Continue For
					End If
					table	=	dt.Rows(i)("TABLE_NAME")
					dl.Items.Add(New ListItem(table, table))
				Next
			End If
			FormUtil.SetDropdownListEmptyList(dl, UIType.Query)

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region

		#Region "InitColumnList 初始化 欄位清單選項"
		''' <summary>
		''' 初始化 欄位清單選項
		''' </summary>
		''' <remarks></remarks>
		Public Sub InitColumnList()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Dim	conn	As	DbConnection	=	dbManager.GetIConnection(Me.DropDownList("DATA_SOURCE").SelectedValue)
			Dim	dBType	As	String		=	Me.DBManager.GetDBType(conn)
			Dim	sql	As	String		=	""
				
			If dBType = "SQL2005" Then
				sql	=	"SELECT B.NAME, 'x' As CNAME " & _
						"FROM SYS.TABLES A " & _
						"INNER JOIN SYS.COLUMNS B " & _
						"ON " & _
						"A.OBJECT_ID = B.OBJECT_ID " & _
						"WHERE " & _
						"A.NAME = '" & Me.TableName & "'"
			ElseIf dBType = "ORACLE" Then
				sql	=	"SELECT COLUMN_NAME AS NAME, 'x' As CNAME  " & _
						"FROM USER_TAB_COLUMNS " & _
						"WHERE " & _
						"TABLE_NAME	=	'" & Me.TableName & "' "
			End If

			Dim	dt	As	DataTable	=	Me.DBManager.GetDataSet(conn, sql).Tables(0)
			Dim	tmpDt	As	DataTable
			Dim	data	As	COLUMNDD	=	New COLUMNDD(Me.DBManager, Me.LogUtil)

			For i As Integer = 0 To dt.Rows.Count - 1
				data.SqlRetrictions	=	"COLUMN_CD='" & dt.Rows(i)("NAME") & "'"
				tmpDt	=	data.Query()
				If tmpDt.Rows.Count = 0 Then
					dt.Rows(i)("CNAME")	=	dt.Rows(i)("NAME")
				Else
					dt.Rows(i)("CNAME")	=	tmpDt.Rows(0)("COLUMN_NM")
				End If
			Next
			Me.ResultData	=	dt

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region

		#Region "GetTemplate 取得樣本"
			Public Function GetTemplate(ByVal fileName) As String
				Dim	reader	As	StreamReader	=	Nothing
				Dim	content	As	StringBuilder	=	New StringBuilder()
				Try
					reader	=	New StreamReader(Me.GetType().Assembly.GetManifestResourceStream(fileName), System.Text.Encoding.ASCII)
					Dim	lineStr		As	String	=	""

					While Not lineStr Is Nothing
						lineStr	=	reader.ReadLine()
						If lineStr Is Nothing Then
							Continue While
						Else
							content.Append(lineStr & vbCrLf)
						End If
					End While
					Return content.ToString()
				Catch ex As Exception
					Throw
				Finally
					If Not reader Is Nothing Then
						reader.Dispose()
					End If
				End Try
			End Function
		#End Region
	#End Region
	End Class
End NameSpace