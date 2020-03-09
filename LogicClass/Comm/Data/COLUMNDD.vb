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
			Me.TableName	=	GetCurrentMethod.DeclaringType.Name
			Me.ConnName	=	APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE")
		End Sub
	#End Region

	#Region "屬性"
		''' <summary>
		''' 取得欄位代碼
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
		''' 取得欄位名稱
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