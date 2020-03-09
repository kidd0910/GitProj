Imports System.Data.Common 
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log

NameSpace Sys.Data
	''' <summary>
	''' EM Class SYST001
	''' </summary>
	''' <remarks></remarks>
	Public Class SYST001
		Inherits Acer.Base.EntityBase 
		Implements Acer.Base.IEntityInterface 

		Dim	externColumn	As	String	=	""

	#Region "�غc�l"
		''' <summary>
		''' �غc�l/�B�z�ݩʹ����B�z
		''' </summary>
		''' <param name="dt">DataTable ����</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
			Me.ColumnFilter	=	externColumn
		End Sub

		''' <summary>
		''' �غc�l/�B�z���ʳB�z
		''' </summary>
		''' <param name="dbManager">DBManager ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	"SYST001"
			Me.SysName	=	"SYS"
            Me.ConnName = "TSBA"
			Me.ColumnFilter	=	externColumn
		End Sub
	#End Region

	#Region "�ݩ�"
		#Region "DATEX DATEX"
		''' <summary>DATEX</summary>
		Public Property DATEX As String
			Get
				Return Me.ColumnyMap("DATEX")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATEX")	=	value
			End Set 
		End Property
		#End Region


		''' <summary>
		''' ���o�����N�X
		''' </summary>
		''' <value>�����N�X��</value>
		''' <returns>�����N�X</returns>
		Public Property CODE As String
			Get
				Return Me.ColumnyMap("CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CODE")	=	value
			End Set 
		End Property

		''' <summary>
		''' �����W��
		''' </summary>
		''' <value>�����W�٭�</value>
		''' <returns>�����W��</returns>
		Public Property NAME As String
			Get
				Return Me.ColumnyMap("NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("NAME")	=	value
			End Set
		End Property
	#End Region
	End Class
End NameSpace