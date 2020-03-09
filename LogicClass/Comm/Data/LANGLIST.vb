Imports System.Data.Common 
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log

NameSpace Comm.Data
	Public Class LANGLIST
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
			Me.TableName	=	"LANGLIST"
			Me.SysName	=	"SIS"
            Me.ConnName = "TSBA"
		End Sub
	#End Region

	#Region "�ݩ�"
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
		''' ���o�y�t����
		''' </summary>
		Public Property LANG_DESC As String
			Get
				Return Me.ColumnyMap("LANG_DESC")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("LANG_DESC")	=	value
			End Set 
		End Property

		''' <summary>
		''' ���o�Ƨ�
		''' </summary>
		Public Property ORDERBY As String
			Get
				Return Me.ColumnyMap("ORDERBY")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ORDERBY")	=	value
			End Set 
		End Property
	#End Region
	End Class
End NameSpace