'----------------------------------------------------------------------------------
'File Name		: CLASSOBJ
'Author			: nono
'Description		: CLASSOBJ EMClass
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/06/25	nono    	Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Comm.Data
	'' <summary>
	'' EM Class 物件
	'' </summary>
	Public Class CLASSOBJ
		Inherits Acer.Base.EntityBase 
		Implements Acer.Base.IEntityInterface 
		
		Dim	externColumn	As	String	=	""
		
	#Region "建構子"
		'' <summary>
		'' 建構子/處理屬性對應處理
		'' </summary>
		'' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
			Me.ColumnFilter	=	externColumn
		End Sub

		'' <summary>
		'' 建構子/處理異動處理
		'' </summary>
		'' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	GetCurrentMethod.DeclaringType.Name
			Me.SysName	=	"SIS"
			Me.ConnName	=	"DATADICTIONARY"
			Me.ColumnFilter	=	externColumn
		End Sub
	#End Region

	#Region "屬性"
		#Region "TEMP 設定為暫存"
		''' <summary>
		''' CLASS_ASSO 物件屬性
		''' </summary>
		Public Property TEMP As Boolean
			Get
				Return Me.ColumnyMap("TEMP")
			End Get
			Set(ByVal value As Boolean)
				Me.ColumnyMap("TEMP")	=	value
			End Set
		End Property
		#End Region

		#Region "PROJ_NM 專案名稱"
		'' <summary>專案名稱</summary>
		Public Property PROJ_NM As String
			Get
				Return Me.ColumnyMap("PROJ_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PROJ_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "SYS_NM 系統名稱"
		'' <summary>系統名稱</summary>
		Public Property SYS_NM As String
			Get
				Return Me.ColumnyMap("SYS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SYS_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "CLASS_CD CLASS_CD"
		'' <summary>CLASS_CD</summary>
		Public Property CLASS_CD As String
			Get
				Return Me.ColumnyMap("CLASS_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CLASS_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "VER 版本"
		'' <summary>版本</summary>
		Public Property VER As String
			Get
				Return Me.ColumnyMap("VER")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("VER")	=	value
			End Set 
		End Property
		#End Region

		#Region "CLASS_NM CLASS_NM"
		'' <summary>CLASS_NM</summary>
		Public Property CLASS_NM As String
			Get
				Return Me.ColumnyMap("CLASS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CLASS_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "CLASS_TP CLASS_TP"
		'' <summary>CLASS_TP</summary>
		Public Property CLASS_TP As String
			Get
				Return Me.ColumnyMap("CLASS_TP")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CLASS_TP")	=	value
			End Set 
		End Property
		#End Region

		#Region "INH_SYS_NM INH_SYS_NM"
		'' <summary>INH_SYS_NM</summary>
		Public Property INH_SYS_NM As String
			Get
				Return Me.ColumnyMap("INH_SYS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("INH_SYS_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "INH_CLASS_CD INH_CLASS_CD"
		'' <summary>INH_CLASS_CD</summary>
		Public Property INH_CLASS_CD As String
			Get
				Return Me.ColumnyMap("INH_CLASS_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("INH_CLASS_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "INH_CLASS_NM INH_CLASS_NM"
		'' <summary>INH_CLASS_NM</summary>
		Public Property INH_CLASS_NM As String
			Get
				Return Me.ColumnyMap("INH_CLASS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("INH_CLASS_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "TABLE_NM TABLE_NM"
		'' <summary>TABLE_NM</summary>
		Public Property TABLE_NM As String
			Get
				Return Me.ColumnyMap("TABLE_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TABLE_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "KEY_NM KEY_NM"
		'' <summary>KEY_NM</summary>
		Public Property KEY_NM As String
			Get
				Return Me.ColumnyMap("KEY_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("KEY_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "KEY_CD KEY_CD"
		'' <summary>KEY_CD</summary>
		Public Property KEY_CD As String
			Get
				Return Me.ColumnyMap("KEY_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("KEY_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "TABLEINHERITANCE TABLEINHERITANCE"
		'' <summary>TABLEINHERITANCE</summary>
		Public Property TABLEINHERITANCE As String
			Get
				Return Me.ColumnyMap("TABLEINHERITANCE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TABLEINHERITANCE")	=	value
			End Set 
		End Property
		#End Region
	#End Region
	
	#Region "自訂方法"
		Public Function Query1() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				
				If Me.TEMP Then
					Me.TableName	=	"TMP_" & Me.TableName
				End If
				Dim	sql	=	"SELECT * FROM " & Me.TableName & " " & _
							"WHERE " & _
							Me.SqlRetrictions
				If Me.OrderBys <> "" Then
					sql	=	sql & " ORDER BY " & Me.OrderBys
				End If
				Return Me.QueryBySql(sql)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function

		Public Function GetNewerClass(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	sql	=	"SELECT * FROM CLASSOBJ A " & _
							"WHERE " & _
							"VER IN " & _
							"( " & _
							"	SELECT MAX(VER) " & _
							"	FROM CLASSOBJ B " & _
							"	WHERE " & _
							"	A.PROJ_NM	=	B.PROJ_NM AND " & _
							"	A.SYS_NM	=	B.SYS_NM AND " & _
							"	A.CLASS_CD	=	B.CLASS_CD " & _
							")"
				If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
					sql	=	sql & " AND " & Me.SqlRetrictions
				End If
				sql	=	sql & " ORDER BY CLASS_CD "

				Return Me.QueryBySql(sql, pageNo, pageSize)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function

		Public Function VerList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	sql	=	"SELECT DISTINCT VER AS SELECT_TEXT, VER AS SELECT_VALUE " & _
							"FROM " & Me.TableName & " " & _
							"WHERE " & _
							"CLASS_CD	=	'" & Me.CLASS_CD & "' " & _
							"ORDER BY VER"

				Return Me.QueryBySql(sql)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function

		Public Function ProjList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	sql	=	"SELECT DISTINCT PROJ_NM AS SELECT_TEXT, PROJ_NM AS SELECT_VALUE FROM " & Me.TableName & " ORDER BY PROJ_NM"

				Return Me.QueryBySql(sql)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function

		Public Function SysList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	sql	=	"SELECT DISTINCT SYS_NM AS SELECT_TEXT, SYS_NM AS SELECT_VALUE FROM " & Me.TableName & " WHERE PROJ_NM = '" & Me.PROJ_NM & "' ORDER BY SYS_NM"

				Return Me.QueryBySql(sql)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
	#End Region
	End Class
End NameSpace
