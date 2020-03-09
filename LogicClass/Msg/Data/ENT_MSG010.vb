'----------------------------------------------------------------------------------
'File Name		: MSG010
'Author			: sandra
'Description		: MSG010 訊息內容
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2016/11/24	sandra		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Msg.Data
    '' <summary>
    '' MSG010 訊息內容
    '' </summary>
    Public Class ENT_MSG010
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
            Me.TableName = "MSG010"
            Me.SysName = "MSG"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "MSG_DESC"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "MSG_NO 編號"
        ''' <summary>
        ''' MSG_NO 編號
        ''' </summary>
        Public Property MSG_NO() As Integer
            Get
                Return Me.ColumnyMap("MSG_NO")
            End Get
            Set(ByVal value As Integer)
                Me.ColumnyMap("MSG_NO") = value
            End Set
        End Property
#End Region

#Region "MSG_DESC 內容"
        ''' <summary>
        ''' MSG_DESC 內容
        ''' </summary>
        Public Property MSG_DESC() As String
            Get
                Return Me.ColumnyMap("MSG_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MSG_DESC") = value
            End Set
        End Property
#End Region

#End Region

    End Class
End Namespace

