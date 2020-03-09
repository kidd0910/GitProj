Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Comm.Data
	Public Class Sample
		Inherits Acer.Base.EntityBase 
		Implements Acer.Base.IEntityInterface 
	#Region "建構子"
		''' <summary>
		''' 建構子/處理屬性對應處理
		''' </summary>
		''' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		''' <summary>
		''' 建構子/處理異動處理
		''' </summary>
		''' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	GetCurrentMethod.DeclaringType.Name
			Me.ConnName	=	APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE")
		End Sub
	#End Region

	#Region "屬性"
		''' <summary>
		''' 取得欄位代碼
		''' </summary>
		Public Property COLUMN_CD As String
			Get
				Return Me.ColumnyMap("COLUMN_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COLUMN_CD")	=	value
			End Set 
		End Property

		''' <summary>
		''' 取得欄位名稱
		''' </summary>
		Public Property COLUMN_NM As String
			Get
				Return Me.ColumnyMap("COLUMN_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COLUMN_NM")	=	value
			End Set 
		End Property
	#End Region

	#Region "自訂方法"
		Public Function QueryComm010(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Dim	conn	As	DbConnection	=	Me.DBManager.GetIConnection(Me.ConnName)
			
			Dim	sql	As	StringBuilder	=	New StringBuilder()

			sql.Append("SELECT PROJ_CD + ' ' + PROJ_NM AS PROJ, SYS_CD + ' ' + SYS_NM AS SYS, " & _
				   "SYS_PROCESS_EMPNO, SYS_STATUS " & _
				   "FROM PDCCT010 " & _
				   "WHERE 1 = 1 ")

			If Me.COLUMN_CD <> "" Then
				sql.Append("AND PROJ_CD = '" & Me.COLUMN_CD & "'")
			End If

			sql.Append(" ORDER BY PKNO")
					
			Dim	resultData	As	DataTable

			'=== 查詢 ===
			If pageNo > 0 Then
				resultData			=	Me.DBManager.GetPageDataTable(conn, sql.ToString(), pageNo, pageSize)
				Me.PropertyMap("TOTALPAGE")	=	Me.DBManager.GetRowCount()
			Else
				resultData			=	Me.DBManager.GetDataSet(conn, sql.ToString()).Tables(0)
			End If
			
			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			return resultData
		End Function

		''' <summary>
		''' 取得唯一專案
		''' </summary>
		''' <returns>結果</returns>
		Public Function GetDistinctProj() As DataTable
			Dim	conn		As	DbConnection	=	dbManager.GetIConnection(Me.connName)
			Dim	sql		As	StringBuilder	=	New StringBuilder

			sql.Append("SELECT DISTINCT PROJ_CD + ' ' + PROJ_NM AS PROJ, PROJ_NM FROM " & Me.tableName & " ORDER BY PROJ")
										
			Return	dbManager.GetDataSet(conn, sql.ToString).Tables(0)
		End Function

		''' <summary>
		''' 取得唯一專案
		''' </summary>
		''' <returns>結果</returns>
		Public Function GetDistinctSys() As DataTable
			Dim	conn		As	DbConnection	=	dbManager.GetIConnection(Me.connName)
			Dim	sql		As	StringBuilder	=	New StringBuilder

			sql.Append(	"SELECT DISTINCT SYS_CD + ' ' + SYS_NM AS SYS, SYS_CD " & _
					"FROM " & Me.TableName & " " & _
					"WHERE " & _
					"PROJ_NM = '" & Me.COLUMN_CD & "' " & _
					"ORDER BY SYS_CD")
										
			Return	dbManager.GetDataSet(conn, sql.ToString).Tables(0)
		End Function
	#End Region
	End Class
End NameSpace