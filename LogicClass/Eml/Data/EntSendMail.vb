'----------------------------------------------------------------------------------
'File Name		: EntSendMail
'Author			: Brian Chou
'Description		: EntSendMail 郵件ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/08/22	Brian Chou		Source Create
'0.0.2    2015/03/31  Steven        改寫 GetSendSeqNo 的取號方式，改抓 pkno (我看DB內已是如此~但不知為何程式碼沒有~難道是舊版)
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
	'' EntSendMail 郵件ENT
	'' </summary>
	Public Class EntSendMail
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
			Me.TableName = "EMLT010"
			Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntSendMailAddressee = New EntSendMailAddressee(Me.DBManager, Me.LogUtil)
			Me.EntSendMailAttachFile = New EntSendMailAttachFile(Me.DBManager, Me.LogUtil)
			Me.EntSendMailTemplate = New EntSendMailTemplate(Me.DBManager, Me.LogUtil)

			'=== 處理別名 ===
		End Sub
#End Region

#Region "屬性"
#Region "ACCE_FILE_NAME 附件檔案名稱"
		''' <summary>
		''' ACCE_FILE_NAME 附件檔案名稱
		''' </summary>
		Public Property ACCE_FILE_NAME() As String
			Get
				Return Me.ColumnyMap("ACCE_FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ACCE_FILE_NAME") = value
			End Set
		End Property
#End Region

#Region "EntSendMailAddressee 收件人ENT[]"
		''' <summary>
		''' EntSendMailAddressee 收件人ENT[]
		''' </summary>
		Public Property EntSendMailAddressee() As EntSendMailAddressee
			Get
				Return Me.PropertyMap("EntSendMailAddressee")
			End Get
			Set(ByVal value As EntSendMailAddressee)
				Me.PropertyMap("EntSendMailAddressee") = value
			End Set
		End Property
#End Region

#Region "EntSendMailAttachFile 附件ENT[]"
		''' <summary>
		''' EntSendMailAttachFile 附件ENT[]
		''' </summary>
		Public Property EntSendMailAttachFile() As EntSendMailAttachFile
			Get
				Return Me.PropertyMap("EntSendMailAttachFile")
			End Get
			Set(ByVal value As EntSendMailAttachFile)
				Me.PropertyMap("EntSendMailAttachFile") = value
			End Set
		End Property
#End Region

#Region "EntSendMailTemplate 郵件格式樣本ENT"
		''' <summary>
		''' EntSendMailTemplate 郵件格式樣本ENT
		''' </summary>
		Public Property EntSendMailTemplate() As EntSendMailTemplate
			Get
				Return Me.PropertyMap("EntSendMailTemplate")
			End Get
			Set(ByVal value As EntSendMailTemplate)
				Me.PropertyMap("EntSendMailTemplate") = value
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

#Region "IS_FINISHED 是否完成發送"
		''' <summary>
		''' IS_FINISHED 是否完成發送
		''' </summary>
		Public Property IS_FINISHED() As String
			Get
				Return Me.ColumnyMap("IS_FINISHED")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_FINISHED") = value
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

#Region "SYS_FILE_NAME 系統檔案名稱"
		''' <summary>
		''' SYS_FILE_NAME 系統檔案名稱
		''' </summary>
		Public Property SYS_FILE_NAME() As String
			Get
				Return Me.ColumnyMap("SYS_FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SYS_FILE_NAME") = value
			End Set
		End Property
#End Region

#Region "TMPLT_SEQ 樣本序號"
		''' <summary>
		''' TMPLT_SEQ 樣本序號
		''' </summary>
		Public Property TMPLT_SEQ() As String
			Get
				Return Me.ColumnyMap("TMPLT_SEQ")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_SEQ") = value
			End Set
		End Property
#End Region

#Region "TMPLT_NAME 樣本名稱"
		''' <summary>
		''' TMPLT_NAME 樣本名稱
		''' </summary>
		Public Property TMPLT_NAME() As String
			Get
				Return Me.ColumnyMap("TMPLT_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_NAME") = value
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

#Region "IS_ACCE 包含附件"
        ''' <summary>
        ''' IS_ACCE 包含附件
        ''' </summary>
        Public Property IS_ACCE() As String
            Get
                Return Me.ColumnyMap("IS_ACCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_ACCE") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "AddSendMailAddressee 新增收件人 "
		''' <summary>
		''' 新增收件人 
		''' </summary>
		Public Sub AddSendMailAddressee()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 收信人地址 ===
				If String.IsNullOrEmpty(Me.RECEIVER_ADDR) Then
					faileArguments.Add("RECEIVER_ADDR")
				End If
				'=== 收信人姓名 ===
				If String.IsNullOrEmpty(Me.RECEIVER_NAME) Then
					faileArguments.Add("RECEIVER_NAME")
				End If
				'=== 寄送次數 ===
				If String.IsNullOrEmpty(Me.SEND_TIMES) Then
					faileArguments.Add("SEND_TIMES")
				End If
				'=== 傳送序號 ===
				If String.IsNullOrEmpty(Me.SEND_SEQ) Then
					faileArguments.Add("SEND_SEQ")
				End If
				'=== 寄送狀態 ===
				If String.IsNullOrEmpty(Me.SEND_STATUS) Then
					faileArguments.Add("SEND_STATUS")
				End If
				'=== 寄送日期 ===
				If String.IsNullOrEmpty(Me.SEND_DATE) Then
					faileArguments.Add("SEND_DATE")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'AEntSendMailAddressee= New EntSendMailAddressee
				'
				'RECEIVER_TYPE(收信人類別)="T"
				'
				'
                'return.AEntPageMsg.insert()
                '=== 2009/04/3 Sandra add for batch===
                If Me.IS_BATCH = "Y" Then
                    Me.EntSendMailAddressee.SetUserId("batch")
                End If

				Me.EntSendMailAddressee.SEND_SEQ = Me.SEND_SEQ	   '傳送序號
				Me.EntSendMailAddressee.SEND_DATE = Me.SEND_DATE    '寄送日期
				Me.EntSendMailAddressee.SEND_TIMES = Me.SEND_TIMES   '寄送次數
				Me.EntSendMailAddressee.SEND_STATUS = Me.SEND_STATUS  '寄送狀態
				Me.EntSendMailAddressee.RECEIVER_ADDR = Me.RECEIVER_ADDR	'收信人地址
				Me.EntSendMailAddressee.RECEIVER_NAME = Me.RECEIVER_NAME	'收信人姓名
				Me.EntSendMailAddressee.Insert()

				Me.ResetColumnProperty()

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "AddSendMailAttachFile 新增附件 "
		''' <summary>
		''' 新增附件 
		''' </summary>
		Public Sub AddSendMailAttachFile()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 附件檔案名稱 ===
				If String.IsNullOrEmpty(Me.ACCE_FILE_NAME) Then
					faileArguments.Add("ACCE_FILE_NAME")
				End If
				'=== 系統檔案名稱 ===
				If String.IsNullOrEmpty(Me.SYS_FILE_NAME) Then
					faileArguments.Add("SYS_FILE_NAME")
				End If
				'=== 傳送序號 ===
				If String.IsNullOrEmpty(Me.SEND_SEQ) Then
					faileArguments.Add("SEND_SEQ")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'AEntSendMailAttachFile= New EntSendMailAttachFile
				'
				'return.AEntSendMailAttachFile.insert()

				Me.EntSendMailAttachFile.SEND_SEQ = Me.SEND_SEQ	    '傳送序號
				Me.EntSendMailAttachFile.SYS_FILE_NAME = Me.SYS_FILE_NAME	 '系統檔案名稱
				Me.EntSendMailAttachFile.ACCE_FILE_NAME = Me.ACCE_FILE_NAME	  '附件檔案名稱
				Me.EntSendMailAttachFile.Insert()

				Me.ResetColumnProperty()


			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "GetSendMailTemplate 取得郵件格式樣本 "
		''' <summary>
		''' 取得郵件格式樣本 
        ''' </summary>
        ''' 0.0.1 Shanlee 修改
        Public Function GetSendMailTemplate() As DataTable
            Return Me.GetSendMailTemplate(0, 0)
        End Function
        ''' <summary>
        ''' 取得郵件格式樣本 
        ''' </summary>
        Public Function GetSendMailTemplate(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"EMLT040", "M", "PKNO", "TMPLT_SEQ", "TMPLT_NAME"})
                Me.ParserAlias()
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                sql.AppendLine(" FROM EMLT040 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.TMPLT_SEQ ")
                    Else
                        sql.AppendLine(" ORDER BY TMPLT_SEQ ")
                    End If
                End If


                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSendSeqNo  取得傳送序號 "
        ''' <summary>
        ''' 取得傳送序號 
        ''' </summary>
        Public Function GetSendSeqNo() As String
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
                '傳送序號為流水號
                '取得 EMLT010.SEND_SEQ(傳送序號) 目前最大值+1
        '2015/03/31 Steven : 下面方式是 oracle 的指令
        'Dim sql As String = "SELECT SEQ_EMLT010.NEXTVAL FROM DUAL"
        'Dim dt As DataTable = Me.QueryBySql(Sql)
        'Me.ResetColumnProperty()
        'Return dt.Rows(0)(0).ToString

        '改用底層的 pkno 取號機
        Return Me.GetSequence()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSuccessStatus  更新發送信件成功狀態 "
        ''' <summary>
        ''' 更新發送信件成功狀態 
        ''' </summary>
        Public Sub UpdateSuccessStatus()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim conn As DbConnection = Me.DBManager.GetIConnection("TSBA")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                dba.SetTableName("EMLT030")
                dba.SetColumn("SEND_STATUS", "Y")
                dba.SetColumn("SEND_TIMES", "SEND_TIMES + 1", True)
                dba.Update("SEND_SEQ = '" & Me.SEND_SEQ & "' AND RECEIVER_ADDR = '" & Me.RECEIVER_ADDR & "'")

                dba.SetTableName("EMLT010")
                dba.SetColumn("MAIL_ARCVD_NUM", "MAIL_ARCVD_NUM + 1", True)
                dba.Update("SEND_SEQ = '" & Me.SEND_SEQ & "'")

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateFailStatus  更新發送信件失敗狀態 "
        ''' <summary>
        ''' 更新發送信件失敗狀態 
        ''' </summary>
        Public Sub UpdateFailStatus()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim conn As DbConnection = Me.DBManager.GetIConnection("TSBA")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                dba.SetTableName("EMLT030")
                dba.SetColumn("SEND_TIMES", "SEND_TIMES + 1", True)
                dba.Update("SEND_SEQ = '" & Me.SEND_SEQ & "' AND RECEIVER_ADDR = '" & Me.RECEIVER_ADDR & "'")

                dba.SetTableName("EMLT010")
                dba.SetColumn("MAIL_ARCVD_NUM", "MAIL_ARCVD_NUM + 1", True)
                dba.Update("SEND_SEQ = '" & Me.SEND_SEQ & "'")

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateFinishStatus  更新發送結束的狀態 "
		''' <summary>
		''' 更新發送結束的狀態 
		''' </summary>
		Public Sub UpdateFinishStatus()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

                Dim conn As DbConnection = Me.DBManager.GetIConnection("TSBA")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

				dba.SetTableName("EMLT010")
				dba.SetColumn("IS_FINISHED", "Y")
				dba.Update("SEND_SEQ = '" & Me.SEND_SEQ & "'")

				Me.ResetColumnProperty()

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "AddSendMailTemplate 新增郵件格式樣本 "
		''' <summary>
		''' 新增郵件格式樣本 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 周柏成 新增方法
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


				'=== 處理別名轉換 ===
				'Me.ParserAlias()

				'=== 處理說明 ===
				'AEntSendMailTemplatee= New EntSendMailTemplate
				'
				'return.AEntSendMailTemplate.insert()
				Me.EntSendMailTemplate.Insert()

				Me.ResetColumnProperty()

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "UpdateSendMailTemplate 修改郵件格式樣本 "
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


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                '組合查詢字串(
                'EntSendMailTemplate.QUERY_COND(查詢條件),"=",DT郵件格式樣本.pkno,DT郵件格式樣本.TMPLT_SEQ(樣本序號),DT郵件格式樣本.TMPLT_NAME(樣本名稱))
                'EntSendMailTemplate.QUERY_COND(查詢條件)=me.組合查詢字串
                'AEntSendMailTemplate.Update()

                Dim updateCnt As Integer = Me.EntSendMailTemplate.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return updateCnt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region ""
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


                '=== 處理別名轉換 ===
                '      Me.ParserAlias()

                '=== 處理說明 ===
                'delete table：EMLT010
                '條件：EMLT010.建立日期 < (SYS_DATE(系統日期)-MAIL_RESERVE_DAYS(郵件保留天數))


                Me.SqlRetrictions = " create_time < (SYSDATE -" & IIf(String.IsNullOrEmpty(Me.MAIL_RESERVE_DAYS), "0", Me.MAIL_RESERVE_DAYS) & ")"

                Me.Delete()
                Me.ResetColumnProperty()


            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetSendMailCCAddressee 取得附本收件人 "
        ''' <summary>
        ''' 取得附本收件人 
        ''' </summary>
        Public Function GetSendMailCCAddressee() As DataTable
            Return Me.GetSendMailCCAddressee(0, 0)
        End Function

        ''' <summary>
        ''' 取得附本收件人 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Eric 新增方法
        ''' </remarks>
        Public Function GetSendMailCCAddressee(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 處理說明 ===
                '使用table： EMLT070
                '取得：全部欄位
                '條件：查詢條件

                '=== 處理別名轉換 ===
                Dim sql As String = "SELECT * FROM EMLT070 M"

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql &= " WHERE " & Me.ProcessCondition(Me.SqlRetrictions.Replace("$.", "M."))
                End If

                sql &= " ORDER BY M.RECEIVER_NAME "

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteSendMailCCAddressee 刪除附本收件人 "
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'AEntSendMailCCAddressee = NEW  EntSendMailCCAddressee()
                'return AEntSendMailCCAddressee.Delete_刪除()
                Dim EntSendMailCCAddressee As New EntSendMailCCAddressee(Me.DBManager, Me.LogUtil)
                EntSendMailCCAddressee.SqlRetrictions = Me.SqlRetrictions
                Return EntSendMailCCAddressee.Delete()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' Charles 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===

                Dim sql As StringBuilder = New StringBuilder()
                sql.Append(" SELECT * FROM EMLT010 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region


#Region "Null 相關"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "MAIL_SENDER,MAIL_SUBJ,MAIL_CONTENT,REPLY_ADDR"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "MAIL_SENDER,MAIL_SUBJ,MAIL_CONTENT,REPLY_ADDR"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "MAIL_SENDER,MAIL_SUBJ,MAIL_CONTENT,REPLY_ADDR"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region

    End Class
End Namespace

