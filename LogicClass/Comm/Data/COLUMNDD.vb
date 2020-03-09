Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Comm.Data
	Public Class COLUMNDD
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
			Me.TableName	=	GetCurrentMethod.DeclaringType.Name
			Me.ConnName	=	APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE")
		End Sub
	#End Region

	#Region "�ݩ�"
		''' <summary>
		''' ���o���N�X
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
		''' ���o���W��
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
	End Class
End NameSpace