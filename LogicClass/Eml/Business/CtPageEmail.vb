'----------------------------------------------------------------------------------
'File Name		: CtPageEmail 
'Author			: Brian Chou
'Description		: CtPageEmail 網頁郵件寄送Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/21	Brian Chou   	Source Create
'----------------------------------------------------------------------------------

Imports Eml.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Acer.Apps
Imports System.Data.Common

Namespace Eml.Business
	''' <summary>
	''' CtPageEmail 網頁郵件寄送Ct
	''' </summary>
	Partial Public Class CtPageEmail
		Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "ARCVD_TYPE 接收類別"
		''' <summary>
		''' ARCVD_TYPE 接收類別
		''' </summary>
		Public Property ARCVD_TYPE() As String
			Get
				Return Me.PropertyMap("ARCVD_TYPE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("ARCVD_TYPE") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NAME 接收類別名稱"
		''' <summary>
		''' ARCVD_TYPE_NAME 接收類別名稱
		''' </summary>
		Public Property ARCVD_TYPE_NAME() As String
			Get
				Return Me.PropertyMap("ARCVD_TYPE_NAME")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("ARCVD_TYPE_NAME") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NO 接收類別編號"
		''' <summary>
		''' ARCVD_TYPE_NO 接收類別編號
		''' </summary>
		Public Property ARCVD_TYPE_NO() As String
			Get
				Return Me.PropertyMap("ARCVD_TYPE_NO")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("ARCVD_TYPE_NO") = value
			End Set
		End Property
#End Region

#Region "EntSendMailApp 郵件寄送申請ENT"
		''' <summary>
		''' EntSendMailApp 郵件寄送申請ENT
		''' </summary>
		Private Property EntSendMailApp() As EntSendMailApp
			Get
				Return Me.PropertyMap("EntSendMailApp")
			End Get
			Set(ByVal value As EntSendMailApp)
				Me.PropertyMap("EntSendMailApp") = value
			End Set
		End Property
#End Region

#Region "IS_INTO_MAIL_FILE 是否轉入郵件檔"
		''' <summary>
		''' IS_INTO_MAIL_FILE 是否轉入郵件檔
		''' </summary>
		Public Property IS_INTO_MAIL_FILE() As String
			Get
				Return Me.PropertyMap("IS_INTO_MAIL_FILE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("IS_INTO_MAIL_FILE") = value
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

#Region "MAIL_NO 郵件編號"
		''' <summary>
		''' MAIL_NO 郵件編號
		''' </summary>
		Public Property MAIL_NO() As String
			Get
				Return Me.PropertyMap("MAIL_NO")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("MAIL_NO") = value
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

#Region "RECEIVER_ID_TYPE 收件者身分類別"
		''' <summary>
		''' RECEIVER_ID_TYPE 收件者身分類別
		''' </summary>
		Public Property RECEIVER_ID_TYPE() As String
			Get
				Return Me.PropertyMap("RECEIVER_ID_TYPE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("RECEIVER_ID_TYPE") = value
			End Set
		End Property
#End Region

#Region "SENDER_EMAIL 寄件者電子信箱"
		''' <summary>
		''' SENDER_EMAIL 寄件者電子信箱
		''' </summary>
		Public Property SENDER_EMAIL() As String
			Get
				Return Me.PropertyMap("SENDER_EMAIL")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("SENDER_EMAIL") = value
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

#Region "SEND_APP_TYPE 寄送申請類別"
		''' <summary>
		''' SEND_APP_TYPE 寄送申請類別
		''' </summary>
		Public Property SEND_APP_TYPE() As String
			Get
				Return Me.PropertyMap("SEND_APP_TYPE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("SEND_APP_TYPE") = value
			End Set
		End Property
#End Region

#Region "EMAIL EMAIL"
		''' <summary>
		''' EMAIL EMAIL
		''' </summary>
		Public Property EMAIL() As String
			Get
				Return Me.PropertyMap("EMAIL")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("EMAIL") = value
			End Set
		End Property
#End Region

#Region "IS_MAIL_BROADCAST 是否一信多發  0:否/1:是"
		''' <summary>
		''' EMAIL EMAIL
		''' </summary>
		Public Property IS_MAIL_BROADCAST() As String
			Get
				Return Me.PropertyMap("IS_MAIL_BROADCAST")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("IS_MAIL_BROADCAST") = value
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
			Me.EntSendMailApp = New EntSendMailApp(Me.DBManager, Me.LogUtil)

		End Sub
#End Region

#Region "方法"
#Region "AddMailRecvSet 新增郵件收件者設定"
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

				'=== 處理說明 ===
				'AEntSendMailApp=NEW EntSendMailApp
				'AEntSendMailApp.AddMailRecvSet_新增郵件收件者設定()
				
				Me.EntSendMailApp.MAIL_BATCH_NO = Me.MAIL_BATCH_NO
				Me.EntSendMailApp.RECEIVER_ID_TYPE = Me.RECEIVER_ID_TYPE
				Me.EntSendMailApp.ARCVD_TYPE = Me.ARCVD_TYPE
				Me.EntSendMailApp.ARCVD_TYPE_NO = Me.ARCVD_TYPE_NO
				Me.EntSendMailApp.ARCVD_TYPE_NAME = Me.ARCVD_TYPE_NAME
				Me.EntSendMailApp.SEND_APP_TYPE = Me.SEND_APP_TYPE
				Me.EntSendMailApp.EMAIL = Me.EMAIL
				Me.EntSendMailApp.AddMailRecvSet()

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "AddMailRecvSetByExchangeData 新增郵件收件者設定by資料交換"
        ''' <summary>
        ''' 新增郵件收件者設定by資料交換
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddMailRecvSetByExchangeData()
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
                'AEntSendMailApp=NEW EntSendMailApp
                'AEntSendMailApp.AddMailRecvSet_新增郵件收件者設定()

                Me.EntSendMailApp.MAIL_BATCH_NO = Me.MAIL_BATCH_NO
                Me.EntSendMailApp.RECEIVER_ID_TYPE = Me.RECEIVER_ID_TYPE
                Me.EntSendMailApp.ARCVD_TYPE = Me.ARCVD_TYPE
                Me.EntSendMailApp.ARCVD_TYPE_NO = Me.ARCVD_TYPE_NO
                Me.EntSendMailApp.ARCVD_TYPE_NAME = Me.ARCVD_TYPE_NAME
                Me.EntSendMailApp.SEND_APP_TYPE = Me.SEND_APP_TYPE
                Me.EntSendMailApp.EMAIL = Me.EMAIL
                Me.EntSendMailApp.AddMailRecvSet()

              
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddSendMailApp 新增郵件寄送申請"
		''' <summary>
		''' 新增郵件寄送申請 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function AddSendMailApp() As String
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 是否轉入郵件檔 ===
				If String.IsNullOrEmpty(Me.IS_INTO_MAIL_FILE) Then
					faileArguments.Add("IS_INTO_MAIL_FILE")
				End If
				'=== 郵件批號 ===
				'If String.IsNullOrEmpty(Me.MAIL_BATCH_NO) Then
				'	faileArguments.Add("MAIL_BATCH_NO")
				'End If
				'=== 信件內容 ===
				If String.IsNullOrEmpty(Me.MAIL_CONTENT) Then
					faileArguments.Add("MAIL_CONTENT")
				End If
				'=== 信件主旨 ===
				If String.IsNullOrEmpty(Me.MAIL_SUBJ) Then
					faileArguments.Add("MAIL_SUBJ")
				End If
				'=== 寄件者電子信箱 ===
				'If String.IsNullOrEmpty(Me.SENDER_EMAIL) Then
				'	faileArguments.Add("SENDER_EMAIL")
				'End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'MAIL_NO(郵件編號)=EntSendMailApp_郵件寄送申請ENT.GetPageEmailSendSeqNo _取得郵件編號()
				'
				'SEND_APP_TYPE(寄送申請類別)=1:電子郵件
				'
				'AEntSendMailApp=NEW EntSendMailApp
				'AEntSendMailApp.Insert()
				'
                '存檔後將該筆郵件編號回傳
                Dim mailno As String = ""
                If Not String.IsNullOrEmpty(Me.MAIL_BATCH_NO) Then
                    mailno = Me.MAIL_BATCH_NO
                Else
                    mailno = Me.EntSendMailApp.GetPageEmailSendSeqNo()
                End If

				Me.EntSendMailApp.MAIL_BATCH_NO = mailno
				Me.EntSendMailApp.SEND_APP_TYPE = Me.SEND_APP_TYPE
				Me.EntSendMailApp.MAIL_CONTENT = Me.MAIL_CONTENT
				Me.EntSendMailApp.MAIL_SUBJ = Me.MAIL_SUBJ
				Me.EntSendMailApp.SENDER_EMAIL = Me.SENDER_EMAIL
				Me.EntSendMailApp.IS_INTO_MAIL_FILE = Me.IS_INTO_MAIL_FILE
				Me.EntSendMailApp.IS_MAIL_BROADCAST = Me.IS_MAIL_BROADCAST
				Me.EntSendMailApp.Insert()

				Me.ResetColumnProperty()

				Return mailno
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "AddSendMailAppByExchangeData 新增郵件寄送申請by資料交換"
        ''' <summary>
        ''' 新增郵件寄送申請by資料交換 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function AddSendMailAppByExchangeData() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 是否轉入郵件檔 ===
                If String.IsNullOrEmpty(Me.IS_INTO_MAIL_FILE) Then
                    faileArguments.Add("IS_INTO_MAIL_FILE")
                End If
                '=== 郵件批號 ===
                'If String.IsNullOrEmpty(Me.MAIL_BATCH_NO) Then
                '	faileArguments.Add("MAIL_BATCH_NO")
                'End If
                '=== 信件內容 ===
                If String.IsNullOrEmpty(Me.MAIL_CONTENT) Then
                    faileArguments.Add("MAIL_CONTENT")
                End If
                '=== 信件主旨 ===
                If String.IsNullOrEmpty(Me.MAIL_SUBJ) Then
                    faileArguments.Add("MAIL_SUBJ")
                End If
                '=== 寄件者電子信箱 ===
                'If String.IsNullOrEmpty(Me.SENDER_EMAIL) Then
                '	faileArguments.Add("SENDER_EMAIL")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'MAIL_NO(郵件編號)=EntSendMailApp_郵件寄送申請ENT.GetPageEmailSendSeqNo _取得郵件編號()
                '
                'SEND_APP_TYPE(寄送申請類別)=1:電子郵件
                '
                'AEntSendMailApp=NEW EntSendMailApp
                'AEntSendMailApp.Insert()
                '
                '存檔後將該筆郵件編號回傳
                Dim mailno As String = Me.EntSendMailApp.GetPageEmailSendSeqNo()

                Me.EntSendMailApp.MAIL_BATCH_NO = mailno
                Me.EntSendMailApp.SEND_APP_TYPE = Me.SEND_APP_TYPE
                Me.EntSendMailApp.MAIL_CONTENT = Me.MAIL_CONTENT
                Me.EntSendMailApp.MAIL_SUBJ = Me.MAIL_SUBJ
                Me.EntSendMailApp.SENDER_EMAIL = Me.SENDER_EMAIL
                Me.EntSendMailApp.IS_INTO_MAIL_FILE = "Y"
                Me.EntSendMailApp.IS_MAIL_BROADCAST = Me.IS_MAIL_BROADCAST
                Me.EntSendMailApp.Insert()

            
                Me.ResetColumnProperty()

                Return mailno
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSendMailTemplate 取得郵件格式樣本"
		''' <summary>
		''' 取得郵件格式樣本 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub GetSendMailTemplate()
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
				'AEntSendMailApp= NEW EntSendMailApp
				'
				'return AEntSendMailApp.UpdateSendMailTemplate_取得郵件格式樣本()

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "GetStdAtDept 取得組織所屬學生"
		''' <summary>
		''' 取得組織所屬學生 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub GetStdAtDept()
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
				'set ASYS_CODE(學制代碼)=ARCVD_TYPE_NO(接收類別編號) 從左邊第1碼 取1碼
				'set DEGREE_CODE(部別代碼)=ARCVD_TYPE_NO(接收類別編號) 從左邊第2碼 取2碼
				'set COLLEGE_CODE(學院代碼)=ARCVD_TYPE_NO(接收類別編號) 從左邊第4碼 取4碼
				'set FACULTY_CODE(系所代碼)=ARCVD_TYPE_NO(接收類別編號) 從左邊第8碼 取4碼
				'set GRADE(年級)=ARCVD_TYPE_NO(接收類別編號) 從左邊第12碼 取1碼
				'set CLASSNO(班級)=ARCVD_TYPE_NO(接收類別編號) 從左邊第13碼 取1碼
				'
				'dt=CtSt_學生Ct.GetSt_取得學生資料()

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "GetPageEmailSendSeqNo 取得郵件批號"
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

                '=== 處理說明 ===
                'MAIL_NO(郵件編號)=EntSendMailApp_郵件寄送申請ENT.GetPageEmailSendSeqNo _取得郵件編號()
                '
                'SEND_APP_TYPE(寄送申請類別)=1:電子郵件
                '
                'AEntSendMailApp=NEW EntSendMailApp
                'AEntSendMailApp.Insert()
                '
                '存檔後將該筆郵件編號回傳
                Dim mailno As String = Me.EntSendMailApp.GetPageEmailSendSeqNo()

                Me.ResetColumnProperty()

                Return mailno
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
	End Class
End Namespace

