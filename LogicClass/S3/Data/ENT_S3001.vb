'----------------------------------------------------------------------------------
'File Name		: S3001
'Author			: TIM
'Description		: S3001 影音上傳
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/01	TIM		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace S3.Data
    ' <summary>
    ' S3001 影音上傳
    ' </summary>
    Public Class ENT_S3001
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
            Me.TableName = "S3001"
            Me.SysName = "S3"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "FILENAME,OWNER,ETAG"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "FILENAME FILENAME"
        '' <summary>
        '' FILENAME FILENAME
        '' </summary>
        Public Property FILENAME() As String
            Get
                Return Me.ColumnyMap("FILENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILENAME") = value
            End Set
        End Property
#End Region

#Region "OWNER OWNER"
        '' <summary>
        '' OWNER OWNER
        '' </summary>
        Public Property OWNER() As String
            Get
                Return Me.ColumnyMap("OWNER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OWNER") = value
            End Set
        End Property
#End Region

#Region "ETAG ETAG"
        '' <summary>
        '' ETAG ETAG
        '' </summary>
        Public Property ETAG() As String
            Get
                Return Me.ColumnyMap("ETAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ETAG") = value
            End Set
        End Property
#End Region


#Region "BUCKET "
        '' <summary>
        '' BUCKET 
        '' </summary>
        Public Property BUCKET() As String
            Get
                Return Me.ColumnyMap("BUCKET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUCKET") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#End Region



    End Class
End Namespace

