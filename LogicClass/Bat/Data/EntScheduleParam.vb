'----------------------------------------------------------------------------------
'File Name		: EntScheduleParam
'Author			: 
'Description		: EntScheduleParam 排程參數ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/20			Source Create
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
    '' EntScheduleParam 排程參數ENT
    '' </summary>
    Public Class EntScheduleParam
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
            Me.TableName = "BATT050"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "BATCH_SEQ 排程序號"
        ''' <summary>
        ''' BATCH_SEQ 排程序號
        ''' </summary>
        Public Property BATCH_SEQ() As String
            Get
                Return Me.ColumnyMap("BATCH_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_SEQ") = value
            End Set
        End Property
#End Region

#Region "PARAM_CD 參數代號"
        ''' <summary>
        ''' PARAM_CD 參數代號
        ''' </summary>
        Public Property PARAM_CD() As String
            Get
                Return Me.ColumnyMap("PARAM_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_CD") = value
            End Set
        End Property
#End Region

#Region "PARAM_CONTENT 參數內容"
        ''' <summary>
        ''' PARAM_CONTENT 參數內容
        ''' </summary>
        Public Property PARAM_CONTENT() As String
            Get
                Return Me.ColumnyMap("PARAM_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_CONTENT") = value
            End Set
        End Property
#End Region

#Region "PARAM_SEQ 參數序號"
        ''' <summary>
        ''' PARAM_SEQ 參數序號
        ''' </summary>
        Public Property PARAM_SEQ() As String
            Get
                Return Me.ColumnyMap("PARAM_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_SEQ") = value
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


#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace


