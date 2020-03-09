'----------------------------------------------------------------------------------
'File Name		: APP1020
'Author			: Sylvia
'Description		: APP1020 外國人直接持有之股份
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/15	Sylvia		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1020 外國人直接持有之股份
    ' </summary>
    Public Class ENT_APP1020
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        ' <summary>
        ' 建構子/處理屬性對應處理
        ' </summary>
        ' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' 建構子/處理異動處理
        ' </summary>
        ' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "APP1020"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,FOREIGNER_SHOLDER_NM,COUNTRY,PROPORTION"
            Me.SET_NULL_FIELD = "DIRECT_SHAREHOLDING"
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "FOREIGNER_SHOLDER_NM 外國股東名稱"
        '' <summary>
        '' FOREIGNER_SHOLDER_NM 外國股東名稱
        '' </summary>
        Public Property FOREIGNER_SHOLDER_NM() As String
            Get
                Return Me.ColumnyMap("FOREIGNER_SHOLDER_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FOREIGNER_SHOLDER_NM") = value
            End Set
        End Property
#End Region

#Region "COUNTRY 國籍"
        '' <summary>
        '' COUNTRY 國籍
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.ColumnyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "DIRECT_SHAREHOLDING 外國人直接持有之股份"
        '' <summary>
        '' DIRECT_SHAREHOLDING 外國人直接持有之股份
        '' </summary>
        Public Property DIRECT_SHAREHOLDING() As String
            Get
                Return Me.ColumnyMap("DIRECT_SHAREHOLDING")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIRECT_SHAREHOLDING") = value
            End Set
        End Property
#End Region

#Region "PROPORTION 所佔比例"
        '' <summary>
        '' PROPORTION 所佔比例
        '' </summary>
        Public Property PROPORTION() As String
            Get
                Return Me.ColumnyMap("PROPORTION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROPORTION") = value
            End Set
        End Property
#End Region



#End Region
    End Class
End Namespace

