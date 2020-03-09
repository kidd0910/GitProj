'----------------------------------------------------------------------------------
'File Name		: EntTable
'Author			: nono
'Description		: EntTable 下載格式Ent
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/09/06	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Imp.Data
	'' <summary>
	'' EntTable 下載格式Ent
	'' </summary>
	Public Class EntTable 
		Inherits Acer.Base.EntityBase
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
			Me.TableName	=	"IMPC010"
			Me.SysName	=	"IMP"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
		#Region "CHECK_ITEM_NAME 檢核項目名稱"
		''' <summary>
		''' CHECK_ITEM_NAME 檢核項目名稱
		''' </summary>
		Public Property CHECK_ITEM_NAME As String
			Get
				Return Me.ColumnyMap("CHECK_ITEM_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CHECK_ITEM_NAME")	=	value
			End Set
		End Property
		#End Region
		
		#Region "CH_HEADED 中文表頭"
		''' <summary>
		''' CH_HEADED 中文表頭
		''' </summary>
		Public Property CH_HEADED As String
			Get
				Return Me.ColumnyMap("CH_HEADED")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CH_HEADED")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DEL_ENG_FIELD 刪除用英文欄項"
		''' <summary>
		''' DEL_ENG_FIELD 刪除用英文欄項
		''' </summary>
		Public Property DEL_ENG_FIELD As String
			Get
				Return Me.ColumnyMap("DEL_ENG_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DEL_ENG_FIELD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DNLD_MODEL_FILE_NAME 下載範例檔案名稱"
		''' <summary>
		''' DNLD_MODEL_FILE_NAME 下載範例檔案名稱
		''' </summary>
		Public Property DNLD_MODEL_FILE_NAME As String
			Get
				Return Me.ColumnyMap("DNLD_MODEL_FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DNLD_MODEL_FILE_NAME")	=	value
			End Set
		End Property
		#End Region
		
		#Region "IMP_OPERATE_PROG 匯入作業程式代號"
		''' <summary>
		''' IMP_OPERATE_PROG 匯入作業程式代號
		''' </summary>
		Public Property IMP_OPERATE_PROG As String
			Get
				Return Me.ColumnyMap("IMP_OPERATE_PROG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IMP_OPERATE_PROG")	=	value
			End Set
		End Property
		#End Region
		
		#Region "IMP_TABLE_NAME 匯入表格名稱"
		''' <summary>
		''' IMP_TABLE_NAME 匯入表格名稱
		''' </summary>
		Public Property IMP_TABLE_NAME As String
			Get
				Return Me.ColumnyMap("IMP_TABLE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IMP_TABLE_NAME")	=	value
			End Set
		End Property
		#End Region
		
		#Region "INS_ENG_FIELD 新增用英文欄項"
		''' <summary>
		''' INS_ENG_FIELD 新增用英文欄項
		''' </summary>
		Public Property INS_ENG_FIELD As String
			Get
				Return Me.ColumnyMap("INS_ENG_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("INS_ENG_FIELD")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"

	#End Region
		
	End Class
End NameSpace