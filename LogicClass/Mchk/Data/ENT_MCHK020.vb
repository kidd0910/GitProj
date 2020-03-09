'----------------------------------------------------------------------------------
'File Name		: MCHK020
'Author			: Becky
'Description		: MCHK020 查核單細項
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/01/09	Becky		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Mchk.Data
    ' <summary>
    ' MCHK020 查核單
    ' </summary>
    Public Class ENT_MCHK020
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
            Me.TableName = "MCHK020"
            Me.SysName = "MCHK"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "MCHK_DESC"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "MCHK010_PKNO 查核表主檔PKNO"
        '' <summary>
        '' MCHK010_PKNO 查核表主檔PKNO
        '' </summary>
        Public Property MCHK010_PKNO() As String
            Get
                Return Me.ColumnyMap("MCHK010_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK010_PKNO") = value
            End Set
        End Property
#End Region

#Region "MCHK_ITEM 查核重點"
        '' <summary>
        '' MCHK_ITEM 查核重點
        '' </summary>
        Public Property MCHK_ITEM() As String
            Get
                Return Me.ColumnyMap("MCHK_ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_ITEM") = value
            End Set
        End Property
#End Region

#Region "MCHK_RESULT 本會查核情形"
        '' <summary>
        '' MCHK_RESULT 本會查核情形
        '' </summary>
        Public Property MCHK_RESULT() As String
            Get
                Return Me.ColumnyMap("MCHK_RESULT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_RESULT") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC 查核情形說明"
        '' <summary>
        '' MCHK_DESC 查核情形說明
        '' </summary>
        Public Property MCHK_DESC() As String
            Get
                Return Me.ColumnyMap("MCHK_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_DESC") = value
            End Set
        End Property
#End Region

#End Region
    End Class
End Namespace

