'----------------------------------------------------------------------------------
'File Name		: CtScheduleInfo
'Author			: CM Huang
'Description		: CtScheduleInfo 排程錯誤通知
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/11	CM Huang   	Source Create
'----------------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Sys.Business
    ''' <summary>
    ''' CtScheduleInfo
    ''' </summary>
    Partial Public Class CtScheduleInfo
        Inherits Acer.Base.ControlBase

#Region "屬性"

#Region "DL_PKNO"
        '' <summary>
        '' SYS_KEY
        '' </summary>
        Public Property DL_PKNO() As String
            Get
                Return Me.PropertyMap("DL_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DL_PKNO") = value
            End Set
        End Property
#End Region

#Region "NOTIFY_FLAG"
        '' <summary>
        '' SYS_PRTID
        '' </summary>
        Public Property NOTIFY_FLAG() As String
            Get
                Return Me.PropertyMap("NOTIFY_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NOTIFY_FLAG") = value
            End Set
        End Property
#End Region

#Region "NOTIFY_TIME"
        '' <summary>
        '' SYS_ID
        '' </summary>
        Public Property NOTIFY_TIME() As String
            Get
                Return Me.PropertyMap("NOTIFY_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NOTIFY_TIME") = value
            End Set
        End Property
#End Region


#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===

        End Sub
#End Region

#Region "方法"


#Region "寫入一筆排程錯誤"
        ''' <summary>
        ''' 寫入一筆排程錯誤
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
        Public Sub ErrInfo(ByVal key As String)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 寫入資料 ===
                Dim ent As ENT_SYST040 = New ENT_SYST040(Me.DBManager, Me.LogUtil)
                ent.DL_PKNO = key
                ent.IS_BATCH = "Y"
                ent.addErrInfo()
                ent = Nothing

                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#End Region
    End Class
End Namespace