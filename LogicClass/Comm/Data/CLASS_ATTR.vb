'----------------------------------------------------------------------------------
'File Name		: CLASS_ATTR
'Author			: nono
'Description		: CLASS_ATTR EMClass
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
	Public Class CLASS_ATTR
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

		#Region "MAS_PKNO MAS_PKNO"
		'' <summary>MAS_PKNO</summary>
		Public Property MAS_PKNO As String
			Get
				Return Me.ColumnyMap("MAS_PKNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAS_PKNO")	=	value
			End Set 
		End Property
		#End Region

		#Region "ATTR_CD ATTR_CD"
		'' <summary>ATTR_CD</summary>
		Public Property ATTR_CD As String
			Get
				Return Me.ColumnyMap("ATTR_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ATTR_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "ENT_CD ENT_CD"
		'' <summary>ENT_CD</summary>
		Public Property ENT_CD As String
			Get
				Return Me.ColumnyMap("ENT_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ENT_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "ATTR_NM ATTR_NM"
		'' <summary>ATTR_NM</summary>
		Public Property ATTR_NM As String
			Get
				Return Me.ColumnyMap("ATTR_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ATTR_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "CLASS_PKNO CLASS_PKNO"
		'' <summary>CLASS_PKNO</summary>
		Public Property CLASS_PKNO As String
			Get
				Return Me.ColumnyMap("CLASS_PKNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CLASS_PKNO")	=	value
			End Set 
		End Property
		#End Region
	#End Region
	
	#Region "自訂方法"
		Public Function AttrQuery() As DataTable
			If Me.TEMP Then
				Me.TableName	=	"TMP_" & Me.TableName
			End If
			Dim	sql	=	"SELECT DISTINCT ATTR_CD, ATTR_NM, ATTR_DOC FROM " & Me.TableName & " WHERE " & Me.SqlRetrictions
			If Me.OrderBys <> "" Then
				sql	=	sql & " ORDER BY " & Me.OrderBys
			End If
			Return Me.QueryBySql(sql)
		End Function
	#End Region

	#Region "自訂方法"
		Public Function Query1() As DataTable
			If Me.TEMP Then
				Me.TableName	=	"TMP_" & Me.TableName
			End If
			Dim	sql	=	"SELECT DISTINCT ATTR_CD, ATTR_NM, ENT_CD FROM " & Me.TableName & " WHERE " & Me.SqlRetrictions
			If Me.OrderBys <> "" Then
				sql	=	sql & " ORDER BY " & Me.OrderBys
			End If
			Return Me.QueryBySql(sql)
		End Function
	#End Region
	End Class
End NameSpace
