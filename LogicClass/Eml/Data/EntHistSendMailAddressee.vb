'----------------------------------------------------------------------------------
'File Name		: EntHistSendMailAddressee
'Author			: 
'Description		: EntHistSendMailAddressee 歷史收件人ENT
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
    '' EntHistSendMailAddressee 歷史收件人ENT
    '' </summary>
    Public Class EntHistSendMailAddressee
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
            Me.TableName = "EMLH030"
            Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
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

#Region "RECEIVER_ADDR 收信人地址"
        ''' <summary>
        ''' RECEIVER_ADDR 收信人地址
        ''' </summary>
        Public Property RECEIVER_ADDR() As String
            Get
                Return Me.ColumnyMap("RECEIVER_ADDR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECEIVER_ADDR") = value
            End Set
        End Property
#End Region

#Region "RECEIVER_NAME 收信人姓名"
        ''' <summary>
        ''' RECEIVER_NAME 收信人姓名
        ''' </summary>
        Public Property RECEIVER_NAME() As String
            Get
                Return Me.ColumnyMap("RECEIVER_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECEIVER_NAME") = value
            End Set
        End Property
#End Region

#Region "RECEIVER_TYPE 收信人類別"
        ''' <summary>
        ''' RECEIVER_TYPE 收信人類別
        ''' </summary>
        Public Property RECEIVER_TYPE() As String
            Get
                Return Me.ColumnyMap("RECEIVER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECEIVER_TYPE") = value
            End Set
        End Property
#End Region

#Region "SEND_DATE 寄送日期"
        ''' <summary>
        ''' SEND_DATE 寄送日期
        ''' </summary>
        Public Property SEND_DATE() As String
            Get
                Return Me.ColumnyMap("SEND_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEND_DATE") = value
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

#Region "SEND_STATUS 寄送狀態"
        ''' <summary>
        ''' SEND_STATUS 寄送狀態
        ''' </summary>
        Public Property SEND_STATUS() As String
            Get
                Return Me.ColumnyMap("SEND_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEND_STATUS") = value
            End Set
        End Property
#End Region

#Region "SEND_TIMES 寄送次數"
        ''' <summary>
        ''' SEND_TIMES 寄送次數
        ''' </summary>
        Public Property SEND_TIMES() As String
            Get
                Return Me.ColumnyMap("SEND_TIMES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEND_TIMES") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "BackupSendMailAddressee 備份收件人 "
         
        ''' <summary>
        ''' 備份收件人 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub BackupSendMailAddressee()
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
                '  Me.ParserAlias()

                '=== 處理說明 ===
                '步驟一、取得須備份郵件之傳送序號
                '使用table:EMLT010
                '取得：傳送序號
                '條件：EMLT010.建立日期 < (SYS_DATE(系統日期)-MAIL_RESERVE_DAYS(郵件保留天數))
                '將取得之資料傳送序號放入DTA
                '
                '步驟二、備份資料
                'Insert into：EMLH030
                '資料來源：EMLT030
                '資料取得條件：EMLT030.SEND_SEQ(傳送序號) in DTA.SEND_SEQ(傳送序號)

                Dim sql As String = String.Format("insert into EMLH030 (select *  from EMLT030 where SEND_SEQ in (select SEND_SEQ from EMLT010 where create_time < SYSDATE-{0}))", IIf(String.IsNullOrEmpty(Me.MAIL_RESERVE_DAYS), "0", Me.MAIL_RESERVE_DAYS))

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

