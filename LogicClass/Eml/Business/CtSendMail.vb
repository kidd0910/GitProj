'----------------------------------------------------------------------------------
'File Name		: CtSendMail 
'Author			: Brian Chou
'Description		: CtSendMail 系統郵件寄送Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.2		2009/08/28	Brian Chou   	增加附本發送
'0.0.1		2008/08/23	Brian Chou   	Source Create
'----------------------------------------------------------------------------------

Imports Eml.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Acer.Apps
Imports Acer.File
Imports System.Net.Mail
Imports System.IO
Imports System.Data.Common
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports System.Net

'Imports Bat.Data

Namespace Eml.Business
    ''' <summary>
    ''' CtSendMail 系統郵件寄送Ct
    ''' </summary>
    Partial Public Class CtSendMail
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "DT收件人 DT收件人"
        ''' <summary>
        ''' DT收件人 DT收件人
        ''' </summary>
        Public Property DT收件人() As DataTable
            Get
                Return Me.PropertyMap("DT收件人")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("DT收件人") = value
            End Set
        End Property
#End Region

#Region "DT附件 DT附件"
        ''' <summary>
        ''' DT附件 DT附件
        ''' </summary>
        Public Property DT附件() As DataTable
            Get
                Return Me.PropertyMap("DT附件")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("DT附件") = value
            End Set
        End Property
#End Region

#Region "EntSendMail 郵件ENT"
        ''' <summary>
        ''' EntSendMail 郵件ENT
        ''' </summary>
        Private Property EntSendMail() As EntSendMail
            Get
                Return Me.PropertyMap("EntSendMail")
            End Get
            Set(ByVal value As EntSendMail)
                Me.PropertyMap("EntSendMail") = value
            End Set
        End Property
#End Region

#Region "MAIL_CONTENT 信件內容"
        ''' <summary>
        ''' MAIL_CONTENT 信件內容
        ''' </summary>
        Public Property MAIL_CONTENT() As String
            Get
                Return Me.PropertyMap("MAIL_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAIL_CONTENT") = value
            End Set
        End Property
#End Region

#Region "MAIL_SENDER 信件寄件者"
        ''' <summary>
        ''' MAIL_SENDER 信件寄件者
        ''' </summary>
        Public Property MAIL_SENDER() As String
            Get
                Return Me.PropertyMap("MAIL_SENDER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAIL_SENDER") = value
            End Set
        End Property
#End Region

#Region "MAIL_SUBJ 信件主旨"
        ''' <summary>
        ''' MAIL_SUBJ 信件主旨
        ''' </summary>
        Public Property MAIL_SUBJ() As String
            Get
                Return Me.PropertyMap("MAIL_SUBJ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAIL_SUBJ") = value
            End Set
        End Property
#End Region

#Region "SUCCESS_NUM 成功數"
        Public Property SUCCESS_NUM() As String
            Get
                Return Me.PropertyMap("SUCCESS_NUM")
            End Get
            Set(ByVal Value As String)
                Me.PropertyMap("SUCCESS_NUM") = Value
            End Set
        End Property
#End Region

#Region "FAIL_NUM 失敗數"
        Public Property FAIL_NUM() As String
            Get
                Return Me.PropertyMap("FAIL_NUM")
            End Get
            Set(ByVal Value As String)
                Me.PropertyMap("FAIL_NUM") = Value
            End Set
        End Property
#End Region

#Region "TagHash 內容取代標籤"
        ''' <summary>
        ''' TagHash 內容取代標籤
        ''' </summary>
        Public Property TAGHASH() As Hashtable
            Get
                Return Me.PropertyMap("TagHash")
            End Get
            Set(ByVal value As Hashtable)
                Me.PropertyMap("TagHash") = value
            End Set
        End Property
#End Region

#Region "AttachStruct 附件結構"
        <Serializable()> _
        Public Structure AttachStruct
            Public Sys_File_Name As String
            Public Acce_File_Name As String
            Public Data As Byte()
        End Structure
#End Region

#Region "TMPLT_SEQ 樣本序號"
        ''' <summary>
        ''' TMPLT_SEQ 樣本序號
        ''' </summary>
        Public Property TMPLT_SEQ() As String
            Get
                Return Me.PropertyMap("TMPLT_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TMPLT_SEQ") = value
            End Set
        End Property
#End Region

#Region "TMPLT_NAME 樣本名稱"
        ''' <summary>
        ''' TMPLT_NAME 樣本名稱
        ''' </summary>
        Public Property TMPLT_NAME() As String
            Get
                Return Me.PropertyMap("TMPLT_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TMPLT_NAME") = value
            End Set
        End Property
#End Region

#Region "TMPLT_EXPL 樣本說明"
        ''' <summary>
        ''' TMPLT_EXPL 樣本說明
        ''' </summary>
        Public Property TMPLT_EXPL() As String
            Get
                Return Me.PropertyMap("TMPLT_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TMPLT_EXPL") = value
            End Set
        End Property
#End Region

#Region "ACCE_SEQ 附本編號"
        ''' <summary>
        ''' ACCE_SEQ 附本編號
        ''' </summary>
        Public Property ACCE_SEQ() As String
            Get
                Return Me.PropertyMap("ACCE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACCE_SEQ") = value
            End Set
        End Property
#End Region

#Region "RECEIVER_NAME 收信人姓名"
        ''' <summary>
        ''' RECEIVER_NAME 收信人姓名
        ''' </summary>
        Public Property RECEIVER_NAME() As String
            Get
                Return Me.PropertyMap("RECEIVER_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECEIVER_NAME") = value
            End Set
        End Property
#End Region

#Region "RECEIVER_ADDR 收信人地址"
        ''' <summary>
        ''' RECEIVER_ADDR 收信人地址
        ''' </summary>
        Public Property RECEIVER_ADDR() As String
            Get
                Return Me.PropertyMap("RECEIVER_ADDR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECEIVER_ADDR") = value
            End Set
        End Property
#End Region

#Region "TMPLT_MAIL_SUBJ 樣本信件主旨"
        ''' <summary>
        ''' TMPLT_MAIL_SUBJ 樣本信件主旨
        ''' </summary>
        Public Property TMPLT_MAIL_SUBJ() As String
            Get
                Return Me.PropertyMap("TMPLT_MAIL_SUBJ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TMPLT_MAIL_SUBJ") = value
            End Set
        End Property
#End Region

#Region "TMPLT_MAIL_CONTENT 樣本信件內容"
        ''' <summary>
        ''' TMPLT_MAIL_CONTENT 樣本信件內容
        ''' </summary>
        Public Property TMPLT_MAIL_CONTENT() As String
            Get
                Return Me.PropertyMap("TMPLT_MAIL_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TMPLT_MAIL_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_SEND 是否傳送"
        ''' <summary>
        ''' IS_SEND 是否傳送
        ''' </summary>
        Public Property IS_SEND() As String
            Get
                Return Me.PropertyMap("IS_SEND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_SEND") = value
            End Set
        End Property
#End Region

#Region "REPLY_ADDR 回信地址"
        ''' <summary>
        ''' REPLY_ADDR 回信地址
        ''' </summary>
        Public Property REPLY_ADDR() As String
            Get
                Return Me.PropertyMap("REPLY_ADDR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REPLY_ADDR") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH_SEND 是否透過排程傳送"
        ''' <summary>
        ''' IS_BATCH_SEND 是否透過排程傳送
        ''' </summary>
        Public Property IS_BATCH_SEND() As String
            Get
                Return Me.PropertyMap("IS_BATCH_SEND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH_SEND") = value
            End Set
        End Property
#End Region

#Region "MAIL_BATCH_NO 郵件批號"
        ''' <summary>
        ''' MAIL_BATCH_NO 郵件批號
        ''' </summary>
        Public Property MAIL_BATCH_NO() As String
            Get
                Return Me.PropertyMap("MAIL_BATCH_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAIL_BATCH_NO") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.PropertyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH") = value
            End Set
        End Property
#End Region

#Region "EntSendMailCCAddressee 附本收件人ENT"
        ''' <summary>
        ''' EntSendMail 附本收件人ENT
        ''' </summary>
        Private Property EntSendMailCCAddressee() As EntSendMailCCAddressee
            Get
                Return Me.PropertyMap("EntSendMailCCAddressee")
            End Get
            Set(ByVal value As EntSendMailCCAddressee)
                Me.PropertyMap("EntSendMailCCAddressee") = value
            End Set
        End Property
#End Region

#Region "MAIL_RESERVE_DAYS 郵件保留天數"
        ''' <summary>
        ''' MAIL_RESERVE_DAYS 郵件保留天數
        ''' </summary>
        Public Property MAIL_RESERVE_DAYS() As String
            Get
                Return Me.PropertyMap("MAIL_RESERVE_DAYS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAIL_RESERVE_DAYS") = value
            End Set
        End Property
#End Region

#Region "DUPLICATE_RECEIVER 固定副本"
        ''' <summary>
        ''' DUPLICATE_RECEIVER 固定副本
        ''' </summary>
        Public Property DUPLICATE_RECEIVER() As String
            Get
                Return Me.PropertyMap("DUPLICATE_RECEIVER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DUPLICATE_RECEIVER") = value
            End Set
        End Property
#End Region

#Region "PARAM_CONTENT 可用參數"
        ''' <summary>
        ''' PARAM_CONTENT 可用參數
        ''' </summary>
        Public Property PARAM_CONTENT() As String
            Get
                Return Me.PropertyMap("PARAM_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARAM_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_ACCE 包含附件"
        ''' <summary>
        ''' IS_ACCE 包含附件
        ''' </summary>
        Public Property IS_ACCE() As String
            Get
                Return Me.PropertyMap("IS_ACCE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_ACCE") = value
            End Set
        End Property
#End Region
#End Region

#Region "全域變數"
        Dim hash As Hashtable
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
            Me.EntSendMail = New EntSendMail(Me.DBManager, Me.LogUtil)
            Me.EntSendMailCCAddressee = New EntSendMailCCAddressee(Me.DBManager, Me.LogUtil)

            hash = New Hashtable
        End Sub
#End Region

#Region "方法"

#Region "AddSendMail 新增郵件"
        ''' <summary>
        ''' 新增郵件 
        ''' </summary>
        Public Sub AddSendMail()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 樣本名稱 ===
                If String.IsNullOrEmpty(Me.TMPLT_NAME) Then
                    faileArguments.Add("TMPLT_NAME")
                End If

                '=== 寄件人 ===
                If String.IsNullOrEmpty(Me.MAIL_SENDER) Then
                    faileArguments.Add("MAIL_SENDER")
                End If

                '=== 收件人 ===
                If Me.DT收件人 Is Nothing OrElse Me.DT收件人.Rows.Count = 0 Then
                    faileArguments.Add("DT收件人")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '本method供各系統UI發送郵件使用，請參照東吳程式做法
                '
                'AEntSendMail= New EntSendMail
                'SEND_SEQ(傳送序號)=AEntSendMail.GetSendSeqNo _取得傳送序號
                'AEntSendMail.insert()
                '
                '附件 是 DataTable
                'DT附件(SYS_FILE_NAME(系統檔案名稱),ACCE_FILE_NAME(附件檔案名稱))
                '
                'for i  = 0 to 附件.rows -1
                '    AEntSendMail.EntSendMailAttachFile.SEND_SEQ(傳送序號)=AEntSendMail.SEND_SEQ(傳送序號)
                '    AEntSendMail.EntSendMailAttachFile.其它欄位=附件.其它欄位
                '    EntSendMail.AddSendMailAttachFile_新增附件()
                'next
                '
                'RECEIVER(收件人) 是 DataTable
                'DT收件人(RECEIVER_NAME(收信人姓名),RECEIVER_ADDR(收信人地址),SEND_STATUS(寄送狀態),SEND_TIMES(寄送次數),SEND_DATE(寄送日期),SEND_MAIL_PROG(發送信件之程式代號))
                '
                'for i  = 0 to RECEIVER(收件人).rows -1
                '      AEntSendMail.EntSendMailAddressee.SEND_SEQ(傳送序號)=AEntSendMail.SEND_SEQ(傳送序號)
                '    AEntSendMail.EntSendMailAddressee.其它欄位=RECEIVER(收件人).其它欄位
                '    EntSendMail.AddSendMailAddressee_新增收件人()
                'next

                '=== 取得樣本資料 ===
                Dim tmpltDt As DataTable

                If hash.ContainsKey("TMPLT") Then
                    tmpltDt = CType(hash("TMPLT"), DataTable)
                Else
                    Dim condition As New StringBuilder
                    Me.ProcessQueryCondition(condition, "=", "TMPLT_NAME", Me.TMPLT_NAME)
                    Me.EntSendMail.SqlRetrictions = condition.ToString
                    tmpltDt = Me.EntSendMail.GetSendMailTemplate()
                    hash.Add("TMPLT", tmpltDt)
                End If

                '2017.11.14 Check tmpltDt 
                If tmpltDt.Rows.Count <= 0 Then
                    Exit Sub
                End If

                '=== 檢查樣本資料是否Enabled ===
                If tmpltDt.Rows(0)("IS_SEND").ToString = "N" Then
                    Exit Sub
                End If

                Dim send_seq As String
                send_seq = Me.EntSendMail.GetSequence

                Me.EntSendMail.IS_BATCH = Me.IS_BATCH  '2009/4/3  SAN ADD FOR BATCH 
                Me.EntSendMail.SEND_SEQ = send_seq
                Me.EntSendMail.MAIL_SENDER = Me.MAIL_SENDER

                '=== 若UI有傳入SUBJECT，以UI為主，否則以Template為主 ===
                Me.EntSendMail.MAIL_SUBJ = IIf(Me.MAIL_SUBJ Is Nothing Or Me.MAIL_SUBJ = "", tmpltDt.Rows(0)("TMPLT_MAIL_SUBJ"), Me.MAIL_SUBJ)

                '=== 若UI有傳入CONTENT，以UI為主，否則以Template為主 ===
                Dim content As String
                content = IIf(Me.MAIL_CONTENT Is Nothing Or Me.MAIL_CONTENT = "", tmpltDt.Rows(0)("TMPLT_MAIL_CONTENT"), Me.MAIL_CONTENT)

                '=== 將內容的Tag，用HashTable的值來取代 ===
                Me.EntSendMail.MAIL_CONTENT = IIf(Me.TAGHASH Is Nothing, content, ReplaceMailTag(content, Me.TAGHASH))

                '=== 已傳送數量 ===
                Me.EntSendMail.MAIL_ARCVD_NUM = 0

                '=== 若UI有傳入IS_BATCH_SEND，以UI為主，否則以Template為主 ===
                Me.IS_BATCH_SEND = IIf(Me.IS_BATCH_SEND Is Nothing Or Me.IS_BATCH_SEND = "", tmpltDt.Rows(0)("IS_BATCH_SEND"), Me.IS_BATCH_SEND)
                Me.EntSendMail.IS_BATCH_SEND = Me.IS_BATCH_SEND

                '=== 若UI有傳入REPLY_ADDR，以UI為主，否則以Template為主 ===
                Me.EntSendMail.REPLY_ADDR = IIf(Me.REPLY_ADDR Is Nothing Or Me.REPLY_ADDR = "", tmpltDt.Rows(0)("REPLY_ADDR").ToString(), Me.REPLY_ADDR)

                '=== 是否發送完成，預設為N
                Me.EntSendMail.IS_FINISHED = "N"

                '=== 是否包含附件，預設為Y
                If tmpltDt.Rows(0)("IS_ACCE").ToString = "" Then
                    Me.EntSendMail.IS_ACCE = "1"
                Else
                    Me.EntSendMail.IS_ACCE = tmpltDt.Rows(0)("IS_ACCE").ToString
                End If

                '=== 郵件批號 ===
                Me.EntSendMail.MAIL_BATCH_NO = Me.MAIL_BATCH_NO

                If Me.IS_BATCH = "Y" Then
                    Me.EntSendMail.EntSendMailAddressee.IS_BATCH = "Y"
                    Me.EntSendMail.EntSendMailAddressee.SetUserId("batch")
                Else
                    '//2010/12/20 政諺 修改
                    Me.EntSendMail.EntSendMailAddressee.SetUserId("ACER1")
                End If
                '=== 寫入收件人檔 ===
                Dim receiverCount As Integer = 0
                Dim sendMailProg As String = ""
                If Not Me.DT收件人 Is Nothing Then
                    For i As Integer = 0 To Me.DT收件人.Rows.Count - 1
                        If Not (IsDBNull(DT收件人.Rows(i)("RECEIVER_ADDR")) OrElse DT收件人.Rows(i)("RECEIVER_ADDR").ToString() = "") Then
                            receiverCount += 1
                            Me.EntSendMail.EntSendMailAddressee.SEND_SEQ = send_seq
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_TYPE = DT收件人.Rows(i)("RECEIVER_TYPE").ToString()
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_NAME = DT收件人.Rows(i)("RECEIVER_NAME").ToString()
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_ADDR = DT收件人.Rows(i)("RECEIVER_ADDR").ToString()
                            Me.EntSendMail.EntSendMailAddressee.SEND_STATUS = "N"
                            Me.EntSendMail.EntSendMailAddressee.SEND_TIMES = "0"
                            Me.EntSendMail.EntSendMailAddressee.SEND_DATE = DT收件人.Rows(i)("SEND_DATE").ToString()
                            Me.EntSendMail.EntSendMailAddressee.SEND_MAIL_PROG = DT收件人.Rows(i)("SEND_MAIL_PROG").ToString()
                            Me.EntSendMail.EntSendMailAddressee.Insert()
                        End If
                        sendMailProg = DT收件人.Rows(i)("SEND_MAIL_PROG").ToString()
                    Next
                End If

                'TODO 加上附本
                If tmpltDt.Rows(0)("DUPLICATE_RECEIVER").ToString <> "" Then
                    receiverCount += 1
                    Me.EntSendMail.EntSendMailAddressee.SEND_SEQ = send_seq
                    Me.EntSendMail.EntSendMailAddressee.RECEIVER_TYPE = "C"
                    Me.EntSendMail.EntSendMailAddressee.RECEIVER_NAME = tmpltDt.Rows(0)("DUPLICATE_RECEIVER").ToString
                    Me.EntSendMail.EntSendMailAddressee.RECEIVER_ADDR = tmpltDt.Rows(0)("DUPLICATE_RECEIVER").ToString
                    Me.EntSendMail.EntSendMailAddressee.SEND_STATUS = "N"
                    Me.EntSendMail.EntSendMailAddressee.SEND_TIMES = "0"
                    Me.EntSendMail.EntSendMailAddressee.SEND_DATE = Now.ToString("yyyy/MM/dd HH:mm:ss")
                    Me.EntSendMail.EntSendMailAddressee.SEND_MAIL_PROG = ""
                    Me.EntSendMail.EntSendMailAddressee.Insert()
                End If
               

                '=== 檢查是否有附本 ===
                Dim acceSeq As String
                Dim acceDt As DataTable
                acceSeq = IIf(IsDBNull(tmpltDt.Rows(0)("ACCE_SEQ")), "", tmpltDt.Rows(0)("ACCE_SEQ"))
                If acceSeq <> "" Then
                    Dim condition As StringBuilder = New StringBuilder()
                    Me.ProcessQueryCondition(condition, "=", "ACCE_SEQ", acceSeq)   '附本編號
                    Me.EntSendMailCCAddressee.SqlRetrictions = condition.ToString()
                    acceDt = Me.EntSendMailCCAddressee.Query()
                    For i As Integer = 0 To acceDt.Rows.Count - 1
                        If Not (IsDBNull(acceDt.Rows(i)("RECEIVER_ADDR")) OrElse acceDt.Rows(i)("RECEIVER_ADDR").ToString() = "") Then
                            receiverCount += 1
                            Me.EntSendMail.EntSendMailAddressee.SEND_SEQ = send_seq
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_TYPE = "C"
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_NAME = acceDt.Rows(i)("RECEIVER_NAME").ToString()
                            Me.EntSendMail.EntSendMailAddressee.RECEIVER_ADDR = acceDt.Rows(i)("RECEIVER_ADDR").ToString()
                            Me.EntSendMail.EntSendMailAddressee.SEND_STATUS = "N"
                            Me.EntSendMail.EntSendMailAddressee.SEND_TIMES = "0"
                            Me.EntSendMail.EntSendMailAddressee.SEND_DATE = Now.ToString("yyyy/MM/dd HH:mm:ss")
                            Me.EntSendMail.EntSendMailAddressee.SEND_MAIL_PROG = sendMailProg
                            Me.EntSendMail.EntSendMailAddressee.Insert()
                        End If
                    Next
                End If


                '=== 寫入附件檔 ===
                If Not Me.DT附件 Is Nothing Then
                    For i As Integer = 0 To Me.DT附件.Rows.Count - 1
                        Me.EntSendMail.EntSendMailAttachFile.SEND_SEQ = send_seq
                        Me.EntSendMail.EntSendMailAttachFile.ACCE_FILE_NAME = DT附件.Rows(i)("ACCE_FILE_NAME").ToString()
                        Me.EntSendMail.EntSendMailAttachFile.SYS_FILE_NAME = DT附件.Rows(i)("SYS_FILE_NAME").ToString()
                        Me.EntSendMail.EntSendMailAttachFile.Insert()
                    Next
                End If

                '=== 傳送數量 ===
                Me.EntSendMail.MAIL_RECEIVE_NUM = receiverCount

                '=== 寫入Mail主檔 ===
                '=== 2009/04/3 Sandra add for batch===
                If Me.IS_BATCH = "Y" Then
                    Me.EntSendMail.SetUserId("batch")
                Else
                    '//2010/12/20 政諺 修改
                    Me.EntSendMail.SetUserId("ACER1")
                End If

                Me.EntSendMail.Insert()

                '=== 直接發送，不透過Service去發 ===
                If Me.IS_BATCH_SEND = "N" Then
                    ExeSendMail(send_seq)
                End If

                'Me.ResetColumnProperty()
            Finally
                If Not Me.DT收件人 Is Nothing Then
                    Me.DT收件人.Dispose()
                End If
                If Not Me.DT附件 Is Nothing Then
                    Me.DT附件.Dispose()
                End If

                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "SendMailByExchangeData 新增郵件by資料交換"
        ''' <summary>
        ''' 資料交換 
        ''' </summary>
        Public Sub SendMailByExchangeData()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 樣本名稱 ===
                If String.IsNullOrEmpty(Me.TMPLT_NAME) Then
                    faileArguments.Add("TMPLT_NAME")
                End If

                '=== 寄件人 ===
                If String.IsNullOrEmpty(Me.MAIL_SENDER) Then
                    faileArguments.Add("MAIL_SENDER")
                End If

                '=== 收件人 ===
                If Me.DT收件人 Is Nothing OrElse Me.DT收件人.Rows.Count = 0 Then
                    faileArguments.Add("DT收件人")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '本method供各系統UI發送郵件使用，請參照東吳程式做法
                '
                'AEntSendMail= New EntSendMail
                'SEND_SEQ(傳送序號)=AEntSendMail.GetSendSeqNo _取得傳送序號
                'AEntSendMail.insert()
                '
                '附件 是 DataTable
                'DT附件(SYS_FILE_NAME(系統檔案名稱),ACCE_FILE_NAME(附件檔案名稱))
                '
                'for i  = 0 to 附件.rows -1
                '    AEntSendMail.EntSendMailAttachFile.SEND_SEQ(傳送序號)=AEntSendMail.SEND_SEQ(傳送序號)
                '    AEntSendMail.EntSendMailAttachFile.其它欄位=附件.其它欄位
                '    EntSendMail.AddSendMailAttachFile_新增附件()
                'next
                '
                'RECEIVER(收件人) 是 DataTable
                'DT收件人(RECEIVER_NAME(收信人姓名),RECEIVER_ADDR(收信人地址),SEND_STATUS(寄送狀態),SEND_TIMES(寄送次數),SEND_DATE(寄送日期),SEND_MAIL_PROG(發送信件之程式代號))
                '
                'for i  = 0 to RECEIVER(收件人).rows -1
                '      AEntSendMail.EntSendMailAddressee.SEND_SEQ(傳送序號)=AEntSendMail.SEND_SEQ(傳送序號)
                '    AEntSendMail.EntSendMailAddressee.其它欄位=RECEIVER(收件人).其它欄位
                '    EntSendMail.AddSendMailAddressee_新增收件人()
                'next


                '=== 取得樣本資料 ===
                Dim tmpltDt As DataTable

                If hash.ContainsKey("TMPLT") Then
                    tmpltDt = CType(hash("TMPLT"), DataTable)
                Else
                    Dim condition As New StringBuilder
                    Me.ProcessQueryCondition(condition, "=", "TMPLT_NAME", Me.TMPLT_NAME)
                    Me.EntSendMail.SqlRetrictions = condition.ToString
                    tmpltDt = Me.EntSendMail.GetSendMailTemplate()
                    hash.Add("TMPLT", tmpltDt)
                End If

                '=== 檢查樣本資料是否Enabled ===
                If tmpltDt.Rows(0)("IS_SEND").ToString = "N" Then
                    Exit Sub
                End If

                Dim send_seq As String
                send_seq = Me.EntSendMail.GetSequence

                '=== 若UI有傳入CONTENT，以UI為主，否則以Template為主 ===
                Dim content As String
                content = IIf(Me.MAIL_CONTENT Is Nothing Or Me.MAIL_CONTENT = "", tmpltDt.Rows(0)("TMPLT_MAIL_CONTENT"), Me.MAIL_CONTENT)

                Dim conn As DbConnection = Me.DBManager.GetIConnection("TSBA")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)
                '=== 寫入收件人檔 ===
                Dim receiverCount As Integer = 0
                Dim sendMailProg As String = ""
                For i As Integer = 0 To Me.DT收件人.Rows.Count - 1
                    If Not (IsDBNull(DT收件人.Rows(i)("RECEIVER_ADDR")) OrElse DT收件人.Rows(i)("RECEIVER_ADDR").ToString() = "") Then
                        receiverCount += 1

                        dba.SetTableName("EMLT030")
                        dba.SetColumn("PKNO", Utility.DBStr(Me.EntSendMail.GetSequence))
                        dba.SetColumn("SEND_SEQ", Utility.DBStr(send_seq))
                        dba.SetColumn("RECEIVER_TYPE", Utility.DBStr(DT收件人.Rows(i)("RECEIVER_TYPE").ToString()))
                        dba.SetColumn("RECEIVER_NAME", Utility.DBStr(DT收件人.Rows(i)("RECEIVER_NAME").ToString()))
                        dba.SetColumn("RECEIVER_ADDR", Utility.DBStr(DT收件人.Rows(i)("RECEIVER_ADDR").ToString()))
                        dba.SetColumn("SEND_STATUS", Utility.DBStr("N"))
                        dba.SetColumn("SEND_TIMES", Utility.DBStr("0"))
                        dba.SetColumn("SEND_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                        dba.SetColumn("SEND_MAIL_PROG", Utility.DBStr(DT收件人.Rows(i)("SEND_MAIL_PROG").ToString()))
                        dba.IsRealAction = False
                        dba.Insert()
                        dba.IsRealAction = True

                    End If
                    sendMailProg = DT收件人.Rows(i)("SEND_MAIL_PROG").ToString()
                Next

                '=== 檢查是否有附本 ===
                Dim acceSeq As String
                Dim acceDt As DataTable
                acceSeq = IIf(IsDBNull(tmpltDt.Rows(0)("ACCE_SEQ")), "", tmpltDt.Rows(0)("ACCE_SEQ"))
                If acceSeq <> "" Then
                    Dim condition As StringBuilder = New StringBuilder()
                    Me.ProcessQueryCondition(condition, "=", "ACCE_SEQ", acceSeq)   '附本編號
                    Me.EntSendMailCCAddressee.SqlRetrictions = condition.ToString()
                    acceDt = Me.EntSendMailCCAddressee.Query()
                    For i As Integer = 0 To acceDt.Rows.Count - 1
                        If Not (IsDBNull(acceDt.Rows(i)("RECEIVER_ADDR")) OrElse acceDt.Rows(i)("RECEIVER_ADDR").ToString() = "") Then
                            receiverCount += 1

                            dba.SetTableName("EMLT030")
                            dba.SetColumn("PKNO", Utility.DBStr(Me.EntSendMail.GetSequence))
                            dba.SetColumn("SEND_SEQ", Utility.DBStr(send_seq))
                            dba.SetColumn("RECEIVER_TYPE", Utility.DBStr("C"))
                            dba.SetColumn("RECEIVER_NAME", Utility.DBStr(acceDt.Rows(i)("RECEIVER_NAME").ToString()))
                            dba.SetColumn("RECEIVER_ADDR", Utility.DBStr(acceDt.Rows(i)("RECEIVER_ADDR").ToString()))
                            dba.SetColumn("SEND_STATUS", Utility.DBStr("N"))
                            dba.SetColumn("SEND_TIMES", Utility.DBStr("0"))
                            dba.SetColumn("SEND_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dba.SetColumn("SEND_MAIL_PROG", Utility.DBStr(sendMailProg))
                            dba.IsRealAction = False
                            dba.Insert()
                            dba.IsRealAction = True

                        End If
                    Next
                End If


                '=== 寫入附件檔 ===
                If Not Me.DT附件 Is Nothing Then
                    For i As Integer = 0 To Me.DT附件.Rows.Count - 1
                        dba.SetTableName("EMLT020")
                        dba.SetColumn("PKNO", Utility.DBStr(Me.EntSendMail.GetSequence))
                        dba.SetColumn("SEND_SEQ", Utility.DBStr(send_seq))
                        dba.SetColumn("ACCE_FILE_NAME", Utility.DBStr(DT附件.Rows(i)("ACCE_FILE_NAME").ToString()))
                        dba.SetColumn("SYS_FILE_NAME", Utility.DBStr(DT附件.Rows(i)("SYS_FILE_NAME").ToString()))
                        dba.IsRealAction = False
                        dba.Insert()
                        dba.IsRealAction = True

                    Next
                End If

                '======================
                'EMLT010
                '======================
                dba.SetTableName("EMLT010")
                dba.SetColumn("PKNO", Utility.DBStr(Me.EntSendMail.GetSequence))
                dba.SetColumn("SEND_SEQ", Utility.DBStr(send_seq))
                dba.SetColumn("MAIL_SUBJ", Utility.DBStr(IIf(Me.MAIL_SUBJ Is Nothing Or Me.MAIL_SUBJ = "", tmpltDt.Rows(0)("TMPLT_MAIL_SUBJ"), Me.MAIL_SUBJ)))
                dba.SetColumn("MAIL_CONTENT", Utility.DBStr(IIf(Me.TAGHASH Is Nothing, content, ReplaceMailTag(content, Me.TAGHASH))))
                dba.SetColumn("MAIL_ARCVD_NUM", Utility.DBStr("0"))
                dba.SetColumn("IS_BATCH_SEND", Utility.DBStr("Y"))
                dba.SetColumn("IS_FINISHED", Utility.DBStr("N"))
                dba.SetColumn("MAIL_BATCH_NO", Utility.DBStr(Me.MAIL_BATCH_NO))
                dba.SetColumn("MAIL_RECEIVE_NUM", Utility.DBStr(receiverCount))
                dba.SetColumn("IS_BATCH_SEND", Utility.DBStr("Y"))
                dba.SetColumn("MAIL_SENDER", Utility.DBStr("國防大學系統管理員<nduaca@ndu.edu.tw>"))
                dba.SetColumn("REPLY_ADDR", Utility.DBStr("nduaca@ndu.edu.tw"))
                dba.IsRealAction = False
                dba.Insert()
                dba.IsRealAction = True

            Finally
                If Not Me.DT收件人 Is Nothing Then
                    Me.DT收件人.Dispose()
                End If
                If Not Me.DT附件 Is Nothing Then
                    Me.DT附件.Dispose()
                End If

                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ExeSendMail 執行發送Mail"
        ''' <summary>
        ''' 執行發送Mail
        ''' </summary>
        ''' <param name="send_seq"></param>
        ''' <remarks></remarks>
        Sub ExeSendMail(ByVal send_seq As String)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                '=== 宣告發Mail變數 ===
                Dim mailFrom As String
                Dim mailTo As String
                Dim mailToName As String
                Dim mailToType As String
                Dim mailSubject As String
                Dim mailDescription As String
                Dim mailReplyTo As String
                Dim mailIsAcce As String
                Dim result As Boolean = True

                Dim successNum As Integer = 0
                Dim failNum As Integer = 0

                '=== 取得Mail主檔資料 ===
                Dim dt As DataTable
                Dim condition As New StringBuilder
                Me.ProcessQueryCondition(condition, "=", "SEND_SEQ", send_seq)
                Me.EntSendMail.SqlRetrictions = condition.ToString
                dt = Me.EntSendMail.Query()
                mailFrom = dt.Rows(0)("MAIL_SENDER").ToString()
                mailSubject = dt.Rows(0)("MAIL_SUBJ").ToString()
                mailDescription = dt.Rows(0)("MAIL_CONTENT").ToString()
                mailReplyTo = dt.Rows(0)("REPLY_ADDR").ToString()
                mailIsAcce = dt.Rows(0)("IS_ACCE").ToString()
                '=== 取得附件資料 ===
                Dim dtAttach As DataTable
                Dim attachAryLst As New ArrayList

                '若EMLT010.IS_ACCE = 1才發送附件
                If mailIsAcce = "1" Then
                    Me.EntSendMail.EntSendMailAttachFile.SqlRetrictions = condition.ToString
                    dtAttach = Me.EntSendMail.EntSendMailAttachFile.Query()
                    For i As Integer = 0 To dtAttach.Rows.Count - 1
                        Dim attach As New AttachStruct
                        attach.Sys_File_Name = dtAttach.Rows(i)("SYS_FILE_NAME")
                        attach.Acce_File_Name = dtAttach.Rows(i)("ACCE_FILE_NAME")
                        attachAryLst.Add(attach)
                    Next
                End If
               

                '=== 取得收件人資料 ===
                Dim dtReceiver As DataTable
                Me.EntSendMail.EntSendMailAddressee.SqlRetrictions = condition.ToString
                dtReceiver = Me.EntSendMail.EntSendMailAddressee.Query()
                For i As Integer = 0 To dtReceiver.Rows.Count - 1
                    mailTo = dtReceiver.Rows(i)("RECEIVER_ADDR")
                    mailToName = dtReceiver.Rows(i)("RECEIVER_NAME")
                    mailToType = dtReceiver.Rows(i)("RECEIVER_TYPE")

                    If attachAryLst.Count = 0 Then
                        result = SendMail(mailFrom, mailTo, mailToName, mailToType, mailSubject, mailDescription, mailReplyTo)
                    Else
                        result = SendMail(mailFrom, mailTo, mailToName, mailToType, mailSubject, mailDescription, mailReplyTo, attachAryLst)
                    End If

                    If result Then
                        successNum += 1

                        '=== 更新發送信件成功狀態 ===
                        Me.EntSendMail.SEND_SEQ = send_seq
                        Me.EntSendMail.RECEIVER_ADDR = dtReceiver.Rows(i)("RECEIVER_ADDR")
                        Me.EntSendMail.UpdateSuccessStatus()

                    Else
                        failNum += 1

                        '=== 更新發送信件成功狀態 ===
                        Me.EntSendMail.SEND_SEQ = send_seq
                        Me.EntSendMail.RECEIVER_ADDR = dtReceiver.Rows(i)("RECEIVER_ADDR")
                        Me.EntSendMail.UpdateFailStatus()
                    End If
                Next

                Me.EntSendMail.SEND_SEQ = send_seq
                Me.EntSendMail.UpdateFinishStatus()

                'Me.ResetColumnProperty()

                SUCCESS_NUM = successNum
                FAIL_NUM = failNum
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ReplaceMailTag 取代MailContent中,Tag的內容"
        ''' <summary>
        ''' 取代MailContent中,Tag的內容
        ''' </summary>
        ''' <param name="mailContent"></param>
        ''' <param name="tagHash"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ReplaceMailTag(ByVal mailContent As String, ByVal tagHash As Hashtable) As String
            Dim de As DictionaryEntry
            If Not tagHash Is Nothing Then
                For Each de In tagHash
                    mailContent = Replace(mailContent, "<$" & de.Key & "$>", de.Value.ToString())
                Next
            End If
            Return mailContent

        End Function
#End Region

#Region "SendMail 發送Mail(沒有附件)"
        ''' <summary>
        ''' 發送Mail(沒有附件)
        ''' </summary>
        ''' <param name="mailFrom"></param>
        ''' <param name="mailTo"></param>
        ''' <param name="mailToName"></param>
        ''' <param name="mailToType"></param>
        ''' <param name="mailSubject"></param>
        ''' <param name="mailDescription"></param>
        ''' <param name="mailReplyTo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function SendMail(ByVal mailFrom As String, ByVal mailTo As String, ByVal mailToName As String, ByVal mailToType As String, ByVal mailSubject As String, ByVal mailDescription As String, ByVal mailReplyTo As String) As Boolean
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                Dim mail As SmtpClient
                Dim mailmsg As MailMessage
                Dim result As Boolean = True
                Dim TestMail As String = APConfig.GetProperty("TEST_MAIL")
                Dim SmtpServer As String = APConfig.GetProperty("SMTP_SERVER")

                Dim mailToEncoding As Encoding
                Select Case APConfig.GetProperty("MAIL_TO_ENCODING")
                    Case "big5"
                        mailToEncoding = System.Text.Encoding.GetEncoding("big5")
                    Case "utf8"
                        mailToEncoding = System.Text.Encoding.UTF8
                    Case Else
                        mailToEncoding = System.Text.Encoding.GetEncoding("big5")
                End Select

                Dim subjectEncoding As Encoding
                Select Case APConfig.GetProperty("SUBJECT_ENCODING")
                    Case "big5"
                        subjectEncoding = System.Text.Encoding.GetEncoding("big5")
                    Case "utf8"
                        subjectEncoding = System.Text.Encoding.UTF8
                    Case Else
                        subjectEncoding = System.Text.Encoding.GetEncoding("big5")
                End Select

                Dim bodyEncoding As Encoding
                Select Case APConfig.GetProperty("BODY_ENCODING")
                    Case "big5"
                        bodyEncoding = System.Text.Encoding.GetEncoding("big5")
                    Case "utf8"
                        bodyEncoding = System.Text.Encoding.UTF8
                    Case Else
                        bodyEncoding = System.Text.Encoding.GetEncoding("big5")
                End Select

                Try
                    If TestMail <> "" Then
                        mailTo = TestMail
                    End If

                    mailmsg = New MailMessage()
                    mailmsg.From = New MailAddress(mailFrom)
                    Select Case mailToType
                        Case "T"
                            mailmsg.To.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                        Case "C"
                            mailmsg.CC.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                        Case "B"
                            mailmsg.Bcc.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                    End Select
                    If mailReplyTo <> "" Then
                        'mailmsg.ReplyTo = New MailAddress(mailReplyTo)
                        mailmsg.ReplyToList.Add(New MailAddress(mailReplyTo))
                    End If
                    mailmsg.Subject = mailSubject

                    '=== 內容從檔案取得 ===
                    If Left(mailDescription, 5) = "FILE=" Then
                        Dim contentAry() As String = mailDescription.Split("|")
                        Dim TEMP_UPLOADFILE_PATH As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH")
                        Dim contentArylst As New ArrayList
                        contentArylst = FileUtil.ReadFile(TEMP_UPLOADFILE_PATH & Right(contentAry(0), contentAry(0).Length - 5), System.Text.Encoding.GetEncoding("big5"))
                        Dim contAry() As String = contentArylst.ToArray(GetType(String))

                        mailmsg.Body = Join(contAry, vbCrLf) & IIf(contentAry.Length > 1, contentAry(1), "")
                    Else
                        mailmsg.Body = mailDescription
                    End If

                    mailmsg.SubjectEncoding = subjectEncoding
                    mailmsg.BodyEncoding = bodyEncoding
                    mailmsg.IsBodyHtml = True
                    mailmsg.Priority = MailPriority.High
                    mail = New SmtpClient
                    mail.Host = SmtpServer

                    '=== nono add 2009/09/30 fix w3wp.exe cpu100% problem ===
                    mail.ServicePoint.MaxIdleTime = 1
                    mail.ServicePoint.ConnectionLimit = 1

                    '======= GMail Start =======
                    If Acer.Apps.APConfig.GetProperty("SENDER_ID").ToString <> "" Then
                        mail.Port = 587
                        mail.EnableSsl = True
                        mail.UseDefaultCredentials = False
                        mail.DeliveryMethod = SmtpDeliveryMethod.Network
                        Dim cred As NetworkCredential = New NetworkCredential(Acer.Apps.APConfig.GetProperty("SENDER_ID"), Acer.Apps.APConfig.GetProperty("SENDER_PW"))
                        mail.Credentials = cred
                    End If
                    '======= GMail End =======

                    mail.Send(mailmsg)

                    Me.Logger.Append("MAIL發送完成:" + mailmsg.To.ToString())

                Catch ex As Exception
                    Me.Logger.Append("MAIL發送失敗：" & ex.Message & ex.StackTrace)
                    result = False
                Finally

                End Try

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "SendMail 發送Mail(有附件)"
        ''' <summary>
        ''' 發送Mail(有附件)
        ''' </summary>
        ''' <param name="mailFrom"></param>
        ''' <param name="mailTo"></param>
        ''' <param name="mailToName"></param>
        ''' <param name="mailToType"></param>
        ''' <param name="mailSubject"></param>
        ''' <param name="mailDescription"></param>
        ''' <param name="mailReplyTo"></param>
        ''' <param name="mailAttachment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function sendMail(ByVal mailFrom As String, ByVal mailTo As String, ByVal mailToName As String, ByVal mailToType As String, ByVal mailSubject As String, ByVal mailDescription As String, ByVal mailReplyTo As String, ByVal mailAttachment As ArrayList) As Boolean
            Dim mail As SmtpClient
            Dim mailmsg As MailMessage
            Dim result As Boolean = True
            Dim TestMail As String = APConfig.GetProperty("TEST_MAIL")
            Dim SmtpServer As String = APConfig.GetProperty("SMTP_SERVER")
            Dim AttachPath As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH")

            Dim mailToEncoding As Encoding
            Select Case APConfig.GetProperty("MAIL_TO_ENCODING")
                Case "big5"
                    mailToEncoding = System.Text.Encoding.GetEncoding("big5")
                Case "utf8"
                    mailToEncoding = System.Text.Encoding.UTF8
                Case Else
                    mailToEncoding = System.Text.Encoding.GetEncoding("big5")
            End Select

            Dim subjectEncoding As Encoding
            Select Case APConfig.GetProperty("SUBJECT_ENCODING")
                Case "big5"
                    subjectEncoding = System.Text.Encoding.GetEncoding("big5")
                Case "utf8"
                    subjectEncoding = System.Text.Encoding.UTF8
                Case Else
                    subjectEncoding = System.Text.Encoding.GetEncoding("big5")
            End Select

            Dim bodyEncoding As Encoding
            Select Case APConfig.GetProperty("BODY_ENCODING")
                Case "big5"
                    bodyEncoding = System.Text.Encoding.GetEncoding("big5")
                Case "utf8"
                    bodyEncoding = System.Text.Encoding.UTF8
                Case Else
                    bodyEncoding = System.Text.Encoding.GetEncoding("big5")
            End Select

            Dim i As Integer
            Try
                If TestMail <> "" Then
                    mailTo = TestMail
                End If

                mailmsg = New MailMessage()
                mailmsg.From = New MailAddress(mailFrom)
                Select Case mailToType
                    Case "T"
                        mailmsg.To.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                    Case "C"
                        mailmsg.CC.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                    Case "B"
                        mailmsg.Bcc.Add(New MailAddress(mailTo, mailToName, mailToEncoding))
                End Select
                If mailReplyTo <> "" Then
                    'mailmsg.ReplyTo = New MailAddress(mailReplyTo)
                    mailmsg.ReplyToList.Add(New MailAddress(mailReplyTo))
                End If
                mailmsg.Subject = mailSubject
                '=== 內容從檔案取得 ===
                If Left(mailDescription, 5) = "FILE=" Then
                    Dim contentAry() As String = mailDescription.Split("|")
                    Dim TEMP_UPLOADFILE_PATH As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH")
                    Dim contentArylst As New ArrayList
                    contentArylst = FileUtil.ReadFile(TEMP_UPLOADFILE_PATH & Right(contentAry(0), contentAry(0).Length - 5), System.Text.Encoding.GetEncoding("big5"))
                    Dim contAry() As String = contentArylst.ToArray(GetType(String))

                    mailmsg.Body = Join(contAry, vbCrLf) & IIf(contentAry.Length > 1, contentAry(1), "")
                Else
                    mailmsg.Body = mailDescription
                End If

                mailmsg.SubjectEncoding = subjectEncoding
                mailmsg.BodyEncoding = bodyEncoding
                mailmsg.IsBodyHtml = True
                mailmsg.Priority = MailPriority.High

                Dim fs(0) As FileStream
                For i = 0 To mailAttachment.Count - 1
                    Dim attach As AttachStruct
                    attach = mailAttachment(i)
                    fs(i) = New FileStream(AttachPath & attach.Sys_File_Name, FileMode.Open, FileAccess.Read)
                    mailmsg.Attachments.Add(New Net.Mail.Attachment(fs(i), attach.Acce_File_Name))

                    ReDim Preserve fs(fs.Length)
                Next
                mail = New SmtpClient
                mail.Host = SmtpServer

                '=== nono add 2009/09/30 fix w3wp.exe cpu100% problem ===
                mail.ServicePoint.MaxIdleTime = 1
                mail.ServicePoint.ConnectionLimit = 1

                '======= GMail Start =======
                If Acer.Apps.APConfig.GetProperty("SENDER_ID").ToString <> "" Then
                    mail.Port = 25
                    mail.EnableSsl = True
                    mail.UseDefaultCredentials = False
                    mail.DeliveryMethod = SmtpDeliveryMethod.Network
                    Dim cred As NetworkCredential = New NetworkCredential(Acer.Apps.APConfig.GetProperty("SENDER_ID"), Acer.Apps.APConfig.GetProperty("SENDER_PW"))
                    mail.Credentials = cred
                End If
                '======= GMail End =======

                mail.Send(mailmsg)

                For i = 0 To mailAttachment.Count - 1
                    fs(i).Close()
                Next

            Catch ex As Exception
                Me.Logger.Append("MAIL發送失敗：" & ex.ToString)
                result = False
            Finally

            End Try

            Return result
        End Function
#End Region

#Region "GetSendMailTemplate 取得郵件格式樣本"
        ''' <summary>
        ''' 取得郵件格式樣本 
        ''' </summary>
        ''' 0.0.1 Shanlee 新增
        Public Function GetSendMailTemplate() As DataTable
            Try
                Dim result As DataTable

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                ''=== 檢核欄位起始 ===
                'Dim faileArguments As ArrayList = New ArrayList()
                ''=== 樣本名稱 ===
                'If String.IsNullOrEmpty(Me.TMPLT_NAME) Then
                '    faileArguments.Add("TMPLT_NAME")
                'End If

                'If faileArguments.Count > 0 Then
                '    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                'End If
                ''=== 檢核欄位結束 ===

                '處理說明
                'AEntSendMail = New EntSendMail
                'Return .AEntSendMail.GetSendMailTemplate_取得郵件格式樣本()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                               'PKNO
                Me.ProcessQueryCondition(condition, "=", "TMPLT_SEQ", Me.TMPLT_SEQ)                 'TMPLT_SEQ
                Me.ProcessQueryCondition(condition, "=", "TMPLT_NAME", Me.TMPLT_NAME)                 '樣本名稱
                Me.EntSendMail.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料 ===
                If Me.PageNo = 0 Then
                    result = Me.EntSendMail.GetSendMailTemplate()
                Else
                    result = Me.EntSendMail.GetSendMailTemplate(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntSendMail.TotalRowCount
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddSendMailTemplate 新增郵件格式樣本"
        ''' <summary>
        ''' 新增郵件格式樣本 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddSendMailTemplate()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntSendMail= New EntSendMail
                '
                'return.AEntSendMail.AddSendMailTemplate_新增郵件格式樣本()
                Me.EntSendMail.EntSendMailTemplate.TMPLT_SEQ = Me.TMPLT_SEQ
                Me.EntSendMail.EntSendMailTemplate.TMPLT_NAME = Me.TMPLT_NAME
                Me.EntSendMail.EntSendMailTemplate.TMPLT_EXPL = Me.TMPLT_EXPL
                Me.EntSendMail.EntSendMailTemplate.TMPLT_MAIL_SUBJ = Me.TMPLT_MAIL_SUBJ
                Me.EntSendMail.EntSendMailTemplate.TMPLT_MAIL_CONTENT = Me.TMPLT_MAIL_CONTENT
                Me.EntSendMail.EntSendMailTemplate.IS_SEND = Me.IS_SEND
                Me.EntSendMail.EntSendMailTemplate.IS_BATCH_SEND = Me.IS_BATCH_SEND
                Me.EntSendMail.EntSendMailTemplate.REPLY_ADDR = Me.REPLY_ADDR
                Me.EntSendMail.EntSendMailTemplate.DUPLICATE_RECEIVER = Me.DUPLICATE_RECEIVER
                Me.EntSendMail.EntSendMailTemplate.PARAM_CONTENT = Me.PARAM_CONTENT
                Me.EntSendMail.EntSendMailTemplate.ACCE_SEQ = Me.ACCE_SEQ
                Me.EntSendMail.EntSendMailTemplate.IS_ACCE = Me.IS_ACCE
                Me.EntSendMail.AddSendMailTemplate()


                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateSendMailTemplate 修改郵件格式樣本"
        ''' <summary>
        ''' 修改郵件格式樣本 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 周柏成 新增方法
        ''' </remarks>
        Public Function UpdateSendMailTemplate() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntSendMail= NEW EntSendMail
                '
                'return AEntSendMail.UpdateSendMailTemplate_修改郵件格式樣本()
                Me.EntSendMail.EntSendMailTemplate.PKNO = Me.PKNO
                Me.EntSendMail.EntSendMailTemplate.TMPLT_SEQ = Me.TMPLT_SEQ
                Me.EntSendMail.EntSendMailTemplate.TMPLT_NAME = Me.TMPLT_NAME
                Me.EntSendMail.EntSendMailTemplate.TMPLT_EXPL = Me.TMPLT_EXPL
                Me.EntSendMail.EntSendMailTemplate.TMPLT_MAIL_SUBJ = Me.TMPLT_MAIL_SUBJ
                Me.EntSendMail.EntSendMailTemplate.TMPLT_MAIL_CONTENT = Me.TMPLT_MAIL_CONTENT
                Me.EntSendMail.EntSendMailTemplate.IS_SEND = Me.IS_SEND
                Me.EntSendMail.EntSendMailTemplate.IS_BATCH_SEND = Me.IS_BATCH_SEND
                Me.EntSendMail.EntSendMailTemplate.REPLY_ADDR = Me.REPLY_ADDR
                Me.EntSendMail.EntSendMailTemplate.PARAM_CONTENT = Me.PARAM_CONTENT
                Me.EntSendMail.EntSendMailTemplate.DUPLICATE_RECEIVER = Me.DUPLICATE_RECEIVER
                Me.EntSendMail.EntSendMailTemplate.IS_ACCE = Me.IS_ACCE
                Dim updateCnt As Integer = Me.EntSendMail.UpdateSendMailTemplate()

                Me.ResetColumnProperty()

                Return updateCnt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "BackupSendMail 備份郵件"
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
                Dim EntHistSendMail As EntHistSendMail = New EntHistSendMail(DBManager, LogUtil)
                Dim EntHistSendMailAddressee As EntHistSendMailAddressee = New EntHistSendMailAddressee(DBManager, LogUtil)
                Dim EntHistSendMailAttachFile As EntHistSendMailAttachFile = New EntHistSendMailAttachFile(DBManager, LogUtil)
                '=== 處理說明 ===

                'AEntHistSendMail=NEW EntHistSendMail
                'AEntHistSendMail.BackupSendMail_備份郵件()
                EntHistSendMail.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)
                EntHistSendMail.BackupSendMail()
                '
                'AEntHistSendMailAddressee=NEW EntHistSendMailAddressee
                'AEntHistSendMailAddressee.BackupSendMailAddressee_備份收件人()
                '
                EntHistSendMailAddressee.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)
                EntHistSendMailAddressee.BackupSendMailAddressee()

                'AEntHistSendMailAttachFile=NEW EntHistSendMailAttachFile
                'AEntHistSendMailAttachFile.BackupSendMailAttachFile_備份附件()
                EntHistSendMailAttachFile.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)
                EntHistSendMailAttachFile.BackupSendMailAttachFile()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "BatchDeleteSendMail 批次刪除郵件"
        ''' <summary>
        ''' 批次刪除郵件 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub BatchDeleteSendMail()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim EntSendMail As EntSendMail = New EntSendMail(DBManager, LogUtil)
                Dim EntSendMailAddressee As EntSendMailAddressee = New EntSendMailAddressee(DBManager, LogUtil)
                Dim EntSendMailAttachFile As EntSendMailAttachFile = New EntSendMailAttachFile(DBManager, LogUtil)

                '=== 處理說明 ===
                'AEntSendMailAttachFile=NEW EntSendMailAttachFile
                'AEntSendMailAttachFile.BatchDeleteSendMailAttachFile_批次刪除附件()
                '
                EntSendMailAttachFile.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)

                EntSendMailAttachFile.BatchDeleteSendMailAttachFile()
                'AEntSendMailAddressee=NEW EntSendMailAddressee
                'AEntSendMailAddressee.BatchDeleteSendMailAddressee_批次刪除收件人()
                '
                EntSendMailAddressee.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)

                'AEntSendMail=NEW EntSendMail.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)
                'AEntSendMail.BatchDeleteSendMail_批次刪除郵件()
                EntSendMail.MAIL_RESERVE_DAYS = IIf(String.IsNullOrEmpty(MAIL_RESERVE_DAYS), "0", MAIL_RESERVE_DAYS)
                EntSendMail.BatchDeleteSendMail()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetSendMailCCAddressee 取得附本收件人"
        ''' <summary>
        ''' 取得附本收件人 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Eric 新增方法
        ''' </remarks>
        Public Function GetSendMailCCAddressee() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntSendMail = NEW  EntSendMail()
                '
                '組合查詢字串(
                'AEntSendMail.QUERY_COND(查詢條件),"=",ACCE_SEQ(附本編號),RECEIVER_NAME(收信人姓名),RECEIVER_ADDR(收信人地址))
                'AEntSendMail.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                'return AEntSendMail.GetSendMailCCAddressee_取得附本收件人()

                Dim EntSendMail As New EntSendMail(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ACCE_SEQ", Me.ACCE_SEQ) '附本編號
                Me.ProcessQueryCondition(condition, "=", "RECEIVER_NAME", Me.RECEIVER_NAME) '收信人姓名
                Me.ProcessQueryCondition(condition, "=", "RECEIVER_ADDR", Me.RECEIVER_ADDR) '收信人地址

                EntSendMail.SqlRetrictions = condition.ToString

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = EntSendMail.GetSendMailCCAddressee()
                Else
                    result = EntSendMail.GetSendMailCCAddressee(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntSendMail.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddSendMailCCAddressee 新增附本收件人 "
        ''' <summary>
        ''' 新增附本收件人 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Eric 新增方法
        ''' </remarks>
        Public Sub AddSendMailCCAddressee()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntSendMailCCAddressee = NEW  EntSendMailCCAddressee()
                'return AEntSendMailCCAddressee.Insert_新增()

                Dim EntSendMailCCAddressee As New EntSendMailCCAddressee(Me.DBManager, Me.LogUtil)
                EntSendMailCCAddressee.RECEIVER_ADDR = Me.RECEIVER_ADDR    '收信人地址
                EntSendMailCCAddressee.RECEIVER_NAME = Me.RECEIVER_NAME    '收信人姓名
                EntSendMailCCAddressee.ACCE_SEQ = Me.ACCE_SEQ '附本編號
                EntSendMailCCAddressee.Insert()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSendMailCCAddressee 刪除附本收件人"
        ''' <summary>
        ''' 刪除附本收件人 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Eric 新增方法
        ''' </remarks>
        Public Function DeleteSendMailCCAddressee() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntSendMail = NEW  EntSendMail()
                '
                '組合查詢字串(
                'AEntSendMail.QUERY_COND(查詢條件),"=",ACCE_SEQ(附本編號),RECEIVER_NAME(收信人姓名),RECEIVER_ADDR(收信人地址))
                '
                'AEntSendMail.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                'return AEntSendMail.DeleteSendMailCCAddressee_刪除附本收件人()

                Dim EntSendMail As New EntSendMail(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ACCE_SEQ", Me.ACCE_SEQ) '附本編號
                Me.ProcessQueryCondition(condition, "=", "RECEIVER_NAME", Me.RECEIVER_NAME) '收信人姓名
                Me.ProcessQueryCondition(condition, "=", "RECEIVER_ADDR", Me.RECEIVER_ADDR) '收信人地址

                EntSendMail.SqlRetrictions = condition.ToString

                Me.ResetColumnProperty()

                Return EntSendMail.DeleteSendMailCCAddressee()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region



#End Region
    End Class
End Namespace

