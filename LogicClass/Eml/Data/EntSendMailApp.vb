'----------------------------------------------------------------------------------
'File Name		: EntSendMailApp
'Author			: Bran Chou
'Description		: EntSendMailApp 郵件寄送申請ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/17	Bran Chou		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Eml.Data
	'' <summary>
	'' EntSendMailApp 郵件寄送申請ENT
	'' </summary>
	Public Class EntSendMailApp
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
			Me.TableName = "EMLT050"
			Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntMailRecvSet = New EntMailRecvSet(Me.DBManager, Me.LogUtil)

			'=== 處理別名 ===
		End Sub
#End Region

#Region "屬性"
#Region "ARCVD_TYPE 接收類別"
		''' <summary>
		''' ARCVD_TYPE 接收類別
		''' </summary>
		Public Property ARCVD_TYPE() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NAME 接收類別名稱"
		''' <summary>
		''' ARCVD_TYPE_NAME 接收類別名稱
		''' </summary>
		Public Property ARCVD_TYPE_NAME() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE_NAME") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NO 接收類別編號"
		''' <summary>
		''' ARCVD_TYPE_NO 接收類別編號
		''' </summary>
		Public Property ARCVD_TYPE_NO() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE_NO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE_NO") = value
			End Set
		End Property
#End Region

#Region "EntMailRecvSet 郵件收件者設定ENT[]"
		''' <summary>
		''' EntMailRecvSet 郵件收件者設定ENT[]
		''' </summary>
		Public Property EntMailRecvSet() As EntMailRecvSet
			Get
				Return Me.PropertyMap("EntMailRecvSet")
			End Get
			Set(ByVal value As EntMailRecvSet)
				Me.PropertyMap("EntMailRecvSet") = value
			End Set
		End Property
#End Region

#Region "IS_INTO_MAIL_FILE 是否轉入郵件檔"
		''' <summary>
		''' IS_INTO_MAIL_FILE 是否轉入郵件檔
		''' </summary>
		Public Property IS_INTO_MAIL_FILE() As String
			Get
				Return Me.ColumnyMap("IS_INTO_MAIL_FILE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_INTO_MAIL_FILE") = value
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

#Region "MAIL_NO 郵件編號"
		''' <summary>
		''' MAIL_NO 郵件編號
		''' </summary>
		Public Property MAIL_NO() As String
			Get
				Return Me.ColumnyMap("MAIL_NO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAIL_NO") = value
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

#Region "RECEIVER_ID_TYPE 收件者身分類別"
		''' <summary>
		''' RECEIVER_ID_TYPE 收件者身分類別
		''' </summary>
		Public Property RECEIVER_ID_TYPE() As String
			Get
				Return Me.ColumnyMap("RECEIVER_ID_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("RECEIVER_ID_TYPE") = value
			End Set
		End Property
#End Region

#Region "SENDER_EMAIL 寄件者電子信箱"
		''' <summary>
		''' SENDER_EMAIL 寄件者電子信箱
		''' </summary>
		Public Property SENDER_EMAIL() As String
			Get
				Return Me.ColumnyMap("SENDER_EMAIL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SENDER_EMAIL") = value
			End Set
		End Property
#End Region

#Region "SEND_APP_TYPE 寄送申請類別"
		''' <summary>
		''' SEND_APP_TYPE 寄送申請類別
		''' </summary>
		Public Property SEND_APP_TYPE() As String
			Get
				Return Me.ColumnyMap("SEND_APP_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SEND_APP_TYPE") = value
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

#Region "EMAIL EMAIL"
		''' <summary>
		''' EMAIL EMAIL
		''' </summary>
		Public Property EMAIL() As String
			Get
				Return Me.ColumnyMap("EMAIL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("EMAIL") = value
			End Set
		End Property
#End Region

#Region "IS_MAIL_BROADCAST 是否一信多發  0:否/1:是"
		''' <summary>
		''' EMAIL EMAIL
		''' </summary>
		Public Property IS_MAIL_BROADCAST() As String
			Get
				Return Me.ColumnyMap("IS_MAIL_BROADCAST")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_MAIL_BROADCAST") = value
			End Set
		End Property
#End Region

#End Region

#Region "自訂方法"
#Region "AddMailRecvSet 新增郵件收件者設定 "
		''' <summary>
		''' 新增郵件收件者設定 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub AddMailRecvSet()
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
				'set SEND_APP_TYPE(寄送申請類別)=1:電子郵件
				'AEntMailRecvSet=NEW EntMailRecvSet
				'AEntMailRecvSet.Insert()
				Me.EntMailRecvSet.MAIL_BATCH_NO = Me.MAIL_BATCH_NO
				Me.EntMailRecvSet.RECEIVER_ID_TYPE = Me.RECEIVER_ID_TYPE
				Me.EntMailRecvSet.ARCVD_TYPE = Me.ARCVD_TYPE
				Me.EntMailRecvSet.ARCVD_TYPE_NO = Me.ARCVD_TYPE_NO
				Me.EntMailRecvSet.ARCVD_TYPE_NAME = Me.ARCVD_TYPE_NAME
				Me.EntMailRecvSet.SEND_APP_TYPE = Me.SEND_APP_TYPE
				Me.EntMailRecvSet.EMAIL = Me.EMAIL
				Me.EntMailRecvSet.Insert()


				Me.ResetColumnProperty()

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "GetPageEmailSendSeqNo  取得郵件批號 "
		''' <summary>
		''' 取得郵件批號 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetPageEmailSendSeqNo() As String
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
				'郵件編號為流水號
				'取得 EMLT050.MAIL_NO(郵件編號) 目前最大值+1
				Dim mailno As String = ""

                Dim sql As String = "SELECT MAX(MAIL_BATCH_NO) AS MAIL_NO FROM EMLT050 WHERE MAIL_BATCH_NO LIKE 'M" & "%' "

				Dim dt As DataTable = Me.QueryBySql(sql)

				If dt.Rows.Count > 0 Then
					If IsDBNull(dt.Rows(0)(0)) Then
                        mailno = "M" & "00001"
					Else
                        mailno = "M" & (CInt(dt.Rows(0)(0).ToString.Substring(4, 6)) + 1).ToString.PadLeft(5, "0")
					End If
				End If

				Me.ResetColumnProperty()

				Return mailno
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "GetSendMailTemplate 取得郵件格式樣本 "
		''' <summary>
		''' 取得郵件格式樣本 
		''' </summary>
		Public Function GetSendMailTemplate() As DataTable
			Return Me.GetSendMailTemplate(0, 0)
		End Function

		''' <summary>
		''' 取得郵件格式樣本 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetSendMailTemplate(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 樣本序號 ===
				If String.IsNullOrEmpty(Me.TMPLT_SEQ) Then
					faileArguments.Add("TMPLT_SEQ")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===


				'=== 處理別名轉換 ===
				Me.ParserAlias()

				'=== 處理說明 ===
				'取得 EMLT040  
				'條件 EMLT040 .TMPLT_SEQ(樣本序號)=TMPLT_SEQ(樣本序號)

				Dim sql As String = ""

				Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

				Me.ResetColumnProperty()

				Return dt
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
                sql.Append(" SELECT * FROM EMLT050 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region

	End Class
End Namespace

