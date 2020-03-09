Imports System.Data.Common 
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log

NameSpace Comm.Data
	Public Class LANGLIST
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
			Me.TableName	=	"LANGLIST"
			Me.SysName	=	"SIS"
            Me.ConnName = "TSBA"
		End Sub
	#End Region

	#Region "屬性"
		''' <summary>
		''' 取得語系
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
		''' 取得語系說明
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
		''' 取得排序
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