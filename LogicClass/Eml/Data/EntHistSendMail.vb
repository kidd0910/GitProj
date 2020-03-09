'----------------------------------------------------------------------------------
'File Name		: EntHistSendMail
'Author			: 
'Description		: EntHistSendMail 歷史郵件ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/08/28			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Eml.Data
    '' <summary>
    '' EntHistSendMail 歷史郵件ENT
    '' </summary>
    Public Class EntHistSendMail
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
            Me.TableName = "EMLH010"
            Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntHistSendMailAddressee = New EntHistSendMailAddressee(Me.DBManager, Me.LogUtil)
            Me.EntHistSendMailAttachFile = New EntHistSendMailAttachFile(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "EntHistSendMailAddressee 歷史收件人ENT[]"
        ''' <summary>
        ''' EntHistSendMailAddressee 歷史收件人ENT[]
        ''' </summary>
        Public Property EntHistSendMailAddressee() As EntHistSendMailAddressee
            Get
                Return Me.PropertyMap("EntHistSendMailAddressee")
            End Get
            Set(ByVal value As EntHistSendMailAddressee)
                Me.PropertyMap("EntHistSendMailAddressee") = value
            End Set
        End Property
#End Region

#Region "EntHistSendMailAttachFile 歷史附件ENT[]"
        ''' <summary>
        ''' EntHistSendMailAttachFile 歷史附件ENT[]
        ''' </summary>
        Public Property EntHistSendMailAttachFile() As EntHistSendMailAttachFile
            Get
                Return Me.PropertyMap("EntHistSendMailAttachFile")
            End Get
            Set(ByVal value As EntHistSendMailAttachFile)
                Me.PropertyMap("EntHistSendMailAttachFile") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH_SEND 是否透過排程傳送"
        ''' <summary>
        ''' IS_BATCH_SEND 是否透過排程傳送
        ''' </summary>
        Public Property IS_BATCH_SEND() As String
            Get
                Return Me.ColumnyMap("IS_BATCH_SEND")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_BATCH_SEND") = value
            End Set
        End Property
#End Region

#Region "MAIL_ARCVD_NUM 信件已接收人數"
        ''' <summary>
        ''' MAIL_ARCVD_NUM 信件已接收人數
        ''' </summary>
        Public Property MAIL_ARCVD_NUM() As String
            Get
                Return Me.ColumnyMap("MAIL_ARCVD_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_ARCVD_NUM") = value
            End Set
        End Property
#End Region

#Region "MAIL_BATCH_NO 郵件批號"
        ''' <summary>
        ''' MAIL_BATCH_NO 郵件批號
        ''' </summary>
        Public Property MAIL_BATCH_NO() As String
            Get
                Return Me.ColumnyMap("MAIL_BATCH_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_BATCH_NO") = value
            End Set
        End Property
#End Region

#Region "MAIL_CONTENT 信件內容"
        ''' <summary>
        ''' MAIL_CONTENT 信件內容
        ''' </summary>
        Public Property MAIL_CONTENT() As String
            Get
                Return Me.ColumnyMap("MAIL_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_CONTENT") = value
            End Set
        End Property
#End Region

#Region "MAIL_RECEIVE_NUM 信件接收人數"
        ''' <summary>
        ''' MAIL_RECEIVE_NUM 信件接收人數
        ''' </summary>
        Public Property MAIL_RECEIVE_NUM() As String
            Get
                Return Me.ColumnyMap("MAIL_RECEIVE_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_RECEIVE_NUM") = value
            End Set
        End Property
#End Region

#Region "MAIL_RESERVE_DAYS 郵件保留天數"
        ''' <summary>
        ''' MAIL_RESERVE_DAYS 郵件保留天數
        ''' </summary>
        Public Property MAIL_RESERVE_DAYS() As String
            Get
                Return Me.ColumnyMap("MAIL_RESERVE_DAYS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_RESERVE_DAYS") = value
            End Set
        End Property
#End Region

#Region "MAIL_SENDER 信件寄件者"
        ''' <summary>
        ''' MAIL_SENDER 信件寄件者
        ''' </summary>
        Public Property MAIL_SENDER() As String
            Get
                Return Me.ColumnyMap("MAIL_SENDER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_SENDER") = value
            End Set
        End Property
#End Region

#Region "MAIL_SUBJ 信件主旨"
        ''' <summary>
        ''' MAIL_SUBJ 信件主旨
        ''' </summary>
        Public Property MAIL_SUBJ() As String
            Get
                Return Me.ColumnyMap("MAIL_SUBJ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_SUBJ") = value
            End Set
        End Property
#End Region

#Region "REPLY_ADDR 回信地址"
        ''' <summary>
        ''' REPLY_ADDR 回信地址
        ''' </summary>
        Public Property REPLY_ADDR() As String
            Get
                Return Me.ColumnyMap("REPLY_ADDR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPLY_ADDR") = value
            End Set
        End Property
#End Region

#Region "SEND_MAIL_PROG 發送信件之程式代號"
        ''' <summary>
        ''' SEND_MAIL_PROG 發送信件之程式代號
        ''' </summary>
        Public Property SEND_MAIL_PROG() As String
            Get
                Return Me.ColumnyMap("SEND_MAIL_PROG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEND_MAIL_PROG") = value
            End Set
        End Property
#End Region

#Region "SEND_SEQ 傳送序號"
        ''' <summary>
        ''' SEND_SEQ 傳送序號
        ''' </summary>
        Public Property SEND_SEQ() As String
            Get
                Return Me.ColumnyMap("SEND_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEND_SEQ") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "BackupSendMail 備份郵件 "
       

        ''' <summary>
        ''' 備份郵件 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub BackupSendMail()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim conn As DbConnection = Me.DBManager.GetIConnection("NTOU")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                'Insert into：EMLH010
                '資料來源：EMLT010
                '資料取得條件：EMLT010.建立日期 < (SYS_DATE(系統日期)-MAIL_RESERVE_DAYS(郵件保留天數))

                Dim sql As String = "insert into EMLH010 (select * from EMLT010 where create_time < (SYSDATE-" & IIf(String.IsNullOrEmpty(Me.MAIL_RESERVE_DAYS), "0", Me.MAIL_RESERVE_DAYS) & "))"

                dba.Execute(sql)

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#End Region

    End Class
End Namespace

