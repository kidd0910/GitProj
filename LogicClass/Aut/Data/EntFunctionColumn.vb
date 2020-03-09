'----------------------------------------------------------------------------------
'File Name		: EntFunctionColumn
'Author			: nono
'Description		: EntFunctionColumn 功能欄項ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/20	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Aut.Data
	'' <summary>
	'' EntFunctionColumn 功能欄項ENT
	'' </summary>
	Public Class EntFunctionColumn 
		Inherits EntProFunction
		Implements Acer.Base.IEntityInterface 
		
	#Region "建構子"
		'' <summary>
		'' 建構子/處理屬性對應處理
		'' </summary>
		'' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		'' <summary>
		'' 建構子/處理異動處理
		'' </summary>
		'' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	""
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
		#Region "DATA_FIELD_CH 資料欄位中文名稱"
		''' <summary>
		''' DATA_FIELD_CH 資料欄位中文名稱
		''' </summary>
		Public Property DATA_FIELD_CH As String
			Get
				Return Me.ColumnyMap("DATA_FIELD_CH")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_FIELD_CH")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DATA_FIELD_ENG 資料欄位英文名稱"
		''' <summary>
		''' DATA_FIELD_ENG 資料欄位英文名稱
		''' </summary>
		Public Property DATA_FIELD_ENG As String
			Get
				Return Me.ColumnyMap("DATA_FIELD_ENG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_FIELD_ENG")	=	value
			End Set
		End Property
		#End Region
		
#Region "GROUP_CODE 群組代碼"
        ''' <summary>
        ''' GROUP_CODE 群組代碼
        ''' </summary>
        Public Property GROUP_CODE As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region
		

	#End Region
	
	#Region "自訂方法"

	#End Region
		
	End Class
End NameSpace
 
