Imports System.Text
Imports System.Data.Common 
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log

NameSpace Comm.Data
	Public Class LANGUAGE
		Inherits Acer.Base.EntityBase 
		Implements Acer.Base.IEntityInterface 

	#Region "�غc�l"
		''' <summary>
		''' �غc�l/�B�z�ݩʹ����B�z
		''' </summary>
		''' <param name="dt">DataTable ����</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		''' <summary>
		''' �غc�l/�B�z���ʳB�z
		''' </summary>
		''' <param name="dbManager">DBManager ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	"LANGUAGE"
			Me.SysName	=	"SIS"
            Me.ConnName = "TSBA"
		End Sub
	#End Region

	#Region "�ݩ�"
		''' <summary>
		''' ���o�j��
		''' </summary>
		Public Property PAGE_NM As String
			Get
				Return Me.ColumnyMap("PAGE_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PAGE_NM")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o�Ӷ�
		''' </summary>
		Public Property PAGE_MODE As String
			Get
				Return Me.ColumnyMap("PAGE_MODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PAGE_MODE")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o�y�t
		''' </summary>
		Public Property LANG_TYPE As String
			Get
				Return Me.ColumnyMap("LANG_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("LANG_TYPE")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o���
		''' </summary>
		Public Property MAP_NM As String
			Get
				Return Me.ColumnyMap("MAP_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAP_NM")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o��ӭ�
		''' </summary>
		Public Property MAP_VALUE As String
			Get
				Return Me.ColumnyMap("MAP_VALUE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAP_VALUE")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o��ӻ���
		''' </summary>
		Public Property MAP_DESC As String
			Get
				Return Me.ColumnyMap("MAP_DESC")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAP_DESC")	=	value
			End Set 
		End Property
	#End Region

	#Region "��k"
		''' <summary>
		''' ���o�ߤ@�j��
		''' </summary>
		''' <returns>���G</returns>
		Public Function GetDistinctPAGE_NM() As DataTable
			Dim	conn		As	DbConnection	=	dbManager.GetIConnection(Me.connName)
			Dim	sql		As	StringBuilder	=	New StringBuilder

			sql.Append("SELECT DISTINCT PAGE_NM FROM " & Me.tableName & " ")
										
			Return	dbManager.GetDataSet(conn, sql.ToString).Tables(0)
		End Function

		''' <summary>
		''' ���o�ߤ@�Ӷ�
		''' </summary>
		''' <returns>���G</returns>
		Public Function GetDistinctPAGE_MODE() As DataTable
			Dim	conn		As	DbConnection	=	dbManager.GetIConnection(Me.connName)
			Dim	sql		As	StringBuilder	=	New StringBuilder

			sql.Append("SELECT DISTINCT PAGE_MODE FROM " & Me.tableName & " ")
										
			Return	dbManager.GetDataSet(conn, sql.ToString).Tables(0)
		End Function
	#End Region
	End Class
End NameSpace