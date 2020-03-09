'----------------------------------------------------------------------------------
'File Name		: CLASS_OP
'Author			: nono
'Description		: CLASS_OP EMClass
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
	Public Class CLASS_OP
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

		#Region "PROCESS PROCESS"
		'' <summary>PROCESS</summary>
		Public Property PROCESS As String
			Get
				Return Me.ColumnyMap("PROCESS")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PROCESS")	=	value
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

		#Region "OP_CD OP_CD"
		'' <summary>OP_CD</summary>
		Public Property OP_CD As String
			Get
				Return Me.ColumnyMap("OP_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OP_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "OP_NM OP_NM"
		'' <summary>OP_NM</summary>
		Public Property OP_NM As String
			Get
				Return Me.ColumnyMap("OP_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OP_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "INPUT_PKNO INPUT_PKNO"
		'' <summary>INPUT_PKNO</summary>
		Public Property INPUT_PKNO As String
			Get
				Return Me.ColumnyMap("INPUT_PKNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("INPUT_PKNO")	=	value
			End Set 
		End Property
		#End Region

		#Region "OPTINPUT_PKNO OPTINPUT_PKNO"
		'' <summary>OPTINPUT_PKNO</summary>
		Public Property OPTINPUT_PKNO As String
			Get
				Return Me.ColumnyMap("OPTINPUT_PKNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OPTINPUT_PKNO")	=	value
			End Set 
		End Property
		#End Region

		#Region "OUTPUT OUTPUT"
		'' <summary>OUTPUT</summary>
		Public Property OUTPUT As String
			Get
				Return Me.ColumnyMap("OUTPUT")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OUTPUT")	=	value
			End Set 
		End Property
		#End Region
	#End Region
	
	#Region "自訂方法"
		Public Function OPList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                Dim sql = "SELECT DISTINCT OP_CD + '-' + OP_NM AS SELECT_TEXT, OP_CD AS SELECT_VALUE " & _
       "FROM " & Me.TableName & " " & _
       "WHERE " & _
       "MAS_PKNO	=	'" & Me.PKNO & "' " & _
       "ORDER BY OP_CD"

				Return Me.QueryBySql(sql)
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function

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
	#End Region
	End Class
End NameSpace
