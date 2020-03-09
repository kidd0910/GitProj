'----------------------------------------------------------------------------------
'File Name		: CLASS_ASSO
'Author			: 
'Description		: CLASS_ASSO EMClass
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/07/09	    	Source Create
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
	'' EM Class ����
	'' </summary>
	Public Class CLASS_ASSO
		Inherits Acer.Base.EntityBase 
		Implements Acer.Base.IEntityInterface 
		
		Dim	externColumn	As	String	=	""
		
	#Region "�غc�l"
		'' <summary>
		'' �غc�l/�B�z�ݩʹ����B�z
		'' </summary>
		'' <param name="dt">DataTable ����</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
			Me.ColumnFilter	=	externColumn
		End Sub

		'' <summary>
		'' �غc�l/�B�z���ʳB�z
		'' </summary>
		'' <param name="dbManager">DBManager ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	GetCurrentMethod.DeclaringType.Name
			Me.SysName	=	"Comm"
			Me.ConnName	=	"DATADICTIONARY"
			Me.ColumnFilter	=	externColumn
		End Sub
	#End Region

	#Region "�ݩ�"
		#Region "TEMP �]�w���Ȧs"
		''' <summary>
		''' CLASS_ASSO �����ݩ�
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

		#Region "PROJ_NM �M�צW��"
		'' <summary>�M�צW��</summary>
		Public Property PROJ_NM As String
			Get
				Return Me.ColumnyMap("PROJ_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PROJ_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "SYS_NM �t�ΦW��"
		'' <summary>�t�ΦW��</summary>
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

		#Region "REF_SYS_NM REF_SYS_NM"
		'' <summary>REF_SYS_NM</summary>
		Public Property REF_SYS_NM As String
			Get
				Return Me.ColumnyMap("REF_SYS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("REF_SYS_NM")	=	value
			End Set 
		End Property
		#End Region

		#Region "REF_CLASS_CD REF_CLASS_CD"
		'' <summary>REF_CLASS_CD</summary>
		Public Property REF_CLASS_CD As String
			Get
				Return Me.ColumnyMap("REF_CLASS_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("REF_CLASS_CD")	=	value
			End Set 
		End Property
		#End Region

		#Region "REF_CLASS_NM REF_CLASS_NM"
		'' <summary>REF_CLASS_NM</summary>
		Public Property REF_CLASS_NM As String
			Get
				Return Me.ColumnyMap("REF_CLASS_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("REF_CLASS_NM")	=	value
			End Set 
		End Property
		#End Region
	#End Region
	
	#Region "�ۭq��k"
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
