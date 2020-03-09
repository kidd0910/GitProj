'----------------------------------------------------------------------------------
'File Name		: EntBatchRecord
'Author			: Ethan
'Description		: EntBatchRecord 批次記錄
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/25	Ethan		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Bat.Data
    '' <summary>
    '' EntBatchRecord 批次記錄
    '' </summary>
    Public Class EntBatchRecord
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
            Me.TableName = "BATT030"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "BATCH_JOB_SEQ 批次工作序號"
        ''' <summary>
        ''' BATCH_JOB_SEQ 批次工作序號
        ''' </summary>
        Public Property BATCH_JOB_SEQ() As String
            Get
                Return Me.ColumnyMap("BATCH_JOB_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_JOB_SEQ") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RECORD_CONTENT 記錄內容"
        ''' <summary>
        ''' RECORD_CONTENT 記錄內容
        ''' </summary>
        Public Property RECORD_CONTENT() As String
            Get
                Return Me.ColumnyMap("RECORD_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_CONTENT") = value
            End Set
        End Property
#End Region

#Region "RECORD_NAME 記錄名稱"
        ''' <summary>
        ''' RECORD_NAME 記錄名稱
        ''' </summary>
        Public Property RECORD_NAME() As String
            Get
                Return Me.ColumnyMap("RECORD_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_NAME") = value
            End Set
        End Property
#End Region

#Region "RECORD_SEQ 記錄序號"
        ''' <summary>
        ''' RECORD_SEQ 記錄序號
        ''' </summary>
        Public Property RECORD_SEQ() As String
            Get
                Return Me.ColumnyMap("RECORD_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_SEQ") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace
