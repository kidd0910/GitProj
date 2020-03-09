'----------------------------------------------------------------------------------
'File Name		: CtLogin 
'Author			: Brian Chou
'Description		: CtLogin 登入Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/10/07	Brian Chou   	Source Create
'----------------------------------------------------------------------------------

Imports Session.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase 

Namespace Session.Business
	''' <summary>
	''' CtLogin 登入Ct
	''' </summary>
	Partial Public Class CtLogin
		Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "LOGIN_ACNT 登入帳號"
		''' <summary>
		''' LOGIN_ACNT 登入帳號
		''' </summary>
		Public Property LOGIN_ACNT() As String
			Get
				Return Me.PropertyMap("LOGIN_ACNT")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("LOGIN_ACNT") = value
			End Set
		End Property
#End Region

#Region "ACNT 帳號"
		''' <summary>
		''' ACNT 帳號
		''' </summary>
		Public Property ACNT() As String
			Get
				Return Me.PropertyMap("ACNT")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("ACNT") = value
			End Set
		End Property
#End Region

#Region "PW 密碼"
		''' <summary>
		''' PW 密碼
		''' </summary>
		Public Property PW() As String
			Get
				Return Me.PropertyMap("PW")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("PW") = value
			End Set
		End Property
#End Region

#Region "PERSON_TYPE 人員類別"
		''' <summary>
		''' PERSON_TYPE 人員類別
		''' </summary>
		Public Property PERSON_TYPE() As String
			Get
				Return Me.PropertyMap("PERSON_TYPE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("PERSON_TYPE") = value
			End Set
		End Property
#End Region

#Region "EntSession SessionEnt"
		''' <summary>
		''' EntSession SessionEnt
		''' </summary>
		Public Property EntSession() As EntSession
			Get
				Return Me.PropertyMap("EntSession")
			End Get
			Set(ByVal value As EntSession)
				Me.PropertyMap("EntSession") = value
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
			Me.EntSession = New EntSession(Me.DBManager, Me.LogUtil)
		End Sub
#End Region

#Region "方法"
#Region "ChkPass 檢核密碼"
		''' <summary>
		''' 檢核密碼 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function ChkPass(ByVal hasPortalLogin As Boolean) As Boolean
			Try
				Dim result As Boolean = False

				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 帳號 ===
				If String.IsNullOrEmpty(Me.LOGIN_ACNT) Then
					faileArguments.Add("LOGIN_ACNT")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'組合查詢字串(EntPerson.QUERY_COND(查詢條件),"=",ACNT(帳號))
				'EntPerson.QUERY_COND(查詢條件)=me.組合查詢字串
				'
				'DT=EntPerson.Quert()
				'
				'if DT.Row.count >0 Then 
				' PERSON_TYPE(人員類別)=DT.PERSON_TYPE(人員類別)
				' ACNT(帳號)=DT.ACNT(帳號)
				'GetSession_取得Session()
				'End If

                result = True

                Me.ResetColumnProperty()

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "GetSession 取得Session"
		''' <summary>
		''' 取得Session 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub GetSession()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 帳號 ===
				If String.IsNullOrEmpty(Me.LOGIN_ACNT) Then
					faileArguments.Add("LOGIN_ACNT")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===
              	'=== 處理說明 ===

                Me.EntSession.LOGIN_ACNT = Me.LOGIN_ACNT
                Me.EntSession.SetTeSession()
			
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region


#End Region
	End Class
End Namespace

