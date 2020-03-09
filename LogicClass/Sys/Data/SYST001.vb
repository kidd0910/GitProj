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

	#Region "建構子"
		''' <summary>
		''' 建構子/處理屬性對應處理
		''' </summary>
		''' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
			Me.ColumnFilter	=	externColumn
		End Sub

		''' <summary>
		''' 建構子/處理異動處理
		''' </summary>
		''' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	"SYST001"
			Me.SysName	=	"SYS"
            Me.ConnName = "TSBA"
			Me.ColumnFilter	=	externColumn
		End Sub
	#End Region

	#Region "屬性"
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
		''' 取得部門代碼
		''' </summary>
		''' <value>部門代碼值</value>
		''' <returns>部門代碼</returns>
		Public Property CODE As String
			Get
				Return Me.ColumnyMap("CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CODE")	=	value
			End Set 
		End Property

		''' <summary>
		''' 部門名稱
		''' </summary>
		''' <value>部門名稱值</value>
		''' <returns>部門名稱</returns>
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