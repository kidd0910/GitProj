'----------------------------------------------------------------------------------
'File Name		: EntAttachFile
'Author			: nono
'Description		: EntAttachFile 共用附加檔案ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/08/30	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace File.Data
	'' <summary>
	'' EntAttachFile 共用附加檔案ENT
	'' </summary>
	Public Class EntAttachFile 
		Inherits Acer.Base.EntityBase
		Implements Acer.Base.IEntityInterface 
		
#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "COMT010"
            Me.SysName = "FILE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACCE_SOURCE 附件來源"
        ''' <summary>
        ''' ACCE_SOURCE 附件來源
        ''' </summary>
        Public Property ACCE_SOURCE() As String
            Get
                Return Me.ColumnyMap("ACCE_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACCE_SOURCE") = value
            End Set
        End Property
#End Region

#Region "ACTUAL_FILENAME 實際檔名"
        ''' <summary>
        ''' ACTUAL_FILENAME 實際檔名
        ''' </summary>
        Public Property ACTUAL_FILENAME() As String
            Get
                Return Me.ColumnyMap("ACTUAL_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACTUAL_FILENAME") = value
            End Set
        End Property
#End Region

#Region "FILE_NAME 原始檔案名稱"
        ''' <summary>
        ''' FILE_NAME 檔案名稱
        ''' </summary>
        Public Property FILE_NAME() As String
            Get
                Return Me.ColumnyMap("FILE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_NAME") = value
            End Set
        End Property
#End Region

#Region "FILE_ACCESS_PATH 檔案存取路徑"
        ''' <summary>
        ''' FILE_ACCESS_PATH 檔案存取路徑
        ''' </summary>
        Public Property FILE_ACCESS_PATH() As String
            Get
                Return Me.ColumnyMap("FILE_ACCESS_PATH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_ACCESS_PATH") = value
            End Set
        End Property
#End Region

#Region "FILE_EXPL 檔案說明"
        ''' <summary>
        ''' FILE_EXPL 檔案說明
        ''' </summary>
        Public Property FILE_EXPL() As String
            Get
                Return Me.ColumnyMap("FILE_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_EXPL") = value
            End Set
        End Property
#End Region

#Region "FILE_NO 檔案號碼"
        ''' <summary>
        ''' FILE_NO 檔案號碼
        ''' </summary>
        Public Property FILE_NO() As String
            Get
                Return Me.ColumnyMap("FILE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_NO") = value
            End Set
        End Property
#End Region

#Region "UPLD_DATE 上傳日期"
        ''' <summary>
        ''' UPLD_DATE 上傳日期
        ''' </summary>
        Public Property UPLD_DATE() As String
            Get
                Return Me.ColumnyMap("UPLD_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPLD_DATE") = value
            End Set
        End Property
#End Region

#Region "FILE_SORT 檔案排序"
        ''' <summary>
        ''' FILE_SORT 檔案排序
        ''' </summary>
        Public Property FILE_SORT() As String
            Get
                Return Me.ColumnyMap("FILE_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_SORT") = value
            End Set
        End Property
#End Region
#End Region
	
#Region "自訂方法"

#End Region
		
	End Class
End NameSpace
 
