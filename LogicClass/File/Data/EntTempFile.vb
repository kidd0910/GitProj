'----------------------------------------------------------------------------------
'File Name		: EntTempFile
'Author			: nono
'Description		: EntTempFile 暫存檔案ENT
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
	'' EntTempFile 暫存檔案ENT
	'' </summary>
	Public Class EntTempFile 
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
            Me.TableName = "COMT020"
            Me.SysName = "FILE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
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

#Region "FILE_NAME 檔案名稱"
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

#Region "PAGE_NAME 頁面名稱"
        ''' <summary>
        ''' PAGE_NAME 頁面名稱
        ''' </summary>
        Public Property PAGE_NAME() As String
            Get
                Return Me.ColumnyMap("PAGE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAGE_NAME") = value
            End Set
        End Property
#End Region

#Region "USE_ID 使用識別"
        ''' <summary>
        ''' USE_ID 使用識別
        ''' </summary>
        Public Property USE_ID() As String
            Get
                Return Me.ColumnyMap("USE_ID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_ID") = value
            End Set
        End Property
#End Region

#Region "USE_NO 使用號碼"
        ''' <summary>
        ''' USE_NO 使用號碼
        ''' </summary>
        Public Property USE_NO() As String
            Get
                Return Me.ColumnyMap("USE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_NO") = value
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
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "USE_NO"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "USE_NO"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "USE_NO"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region
		
	End Class
End NameSpace
 
