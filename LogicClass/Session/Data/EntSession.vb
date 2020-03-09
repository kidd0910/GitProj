'----------------------------------------------------------------------------------
'File Name		: EntSession
'Author			: Brian Chou
'Description		: EntSession SessionENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/10/07	Brian Chou		Source Create
'0.0.2      2009/06/03  楊智能  登入類別為學生多存放系所簡稱
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Session.Data
	'' <summary>
	'' EntSession SessionENT
	'' </summary>
	Public Class EntSession
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
			Me.TableName = ""
			Me.SysName = "SESSION"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===
			'=== 處理別名 ===
		End Sub
#End Region

#Region "屬性"
#Region "DEP_CODE 單位代碼"
		''' <summary>
		''' DEP_CODE 單位代碼
		''' </summary>
		Public Property DEP_CODE() As String
			Get
				Return Me.ColumnyMap("DEP_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DEP_CODE") = value
			End Set
		End Property
#End Region

#Region "STAFF_NO 員工編號"
        ''' <summary>
        ''' STAFF_NO 員工編號
        ''' </summary>
        Public Property STAFF_NO() As String
            Get
                Return Me.ColumnyMap("STAFF_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STAFF_NO") = value
            End Set
        End Property
#End Region

#Region "COLLEGE_CODE 學院代碼"
		''' <summary>
		''' COLLEGE_CODE 學院代碼
		''' </summary>
		Public Property COLLEGE_CODE() As String
			Get
				Return Me.ColumnyMap("COLLEGE_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COLLEGE_CODE") = value
			End Set
		End Property
#End Region

#Region "EMAIL 電子信箱"
		''' <summary>
		''' EMAIL 電子信箱
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

#Region "ENGNAME 英文姓名"
		''' <summary>
		''' ENGNAME 英文姓名
		''' </summary>
		Public Property ENGNAME() As String
			Get
				Return Me.ColumnyMap("ENGNAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ENGNAME") = value
			End Set
		End Property
#End Region

#Region "GRADE 年級"
		''' <summary>
		''' GRADE 年級
		''' </summary>
		Public Property GRADE() As String
			Get
				Return Me.ColumnyMap("GRADE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("GRADE") = value
			End Set
		End Property
#End Region

#Region "PERSON_TYPE 人員類別"
		''' <summary>
		''' PERSON_TYPE 人員類別
		''' </summary>
		Public Property PERSON_TYPE() As String
			Get
				Return Me.ColumnyMap("PERSON_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PERSON_TYPE") = value
			End Set
		End Property
#End Region

#Region "STNO 學號"
		''' <summary>
		''' STNO 學號
		''' </summary>
		Public Property STNO() As String
			Get
				Return Me.ColumnyMap("STNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("STNO") = value
			End Set
		End Property
#End Region

#Region "STUDY_STATUS 在學狀態"
		''' <summary>
		''' STUDY_STATUS 在學狀態
		''' </summary>
		Public Property STUDY_STATUS() As String
			Get
				Return Me.ColumnyMap("STUDY_STATUS")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("STUDY_STATUS") = value
			End Set
		End Property
#End Region

#Region "FACULTY_CODE 系所代碼"
		''' <summary>
		''' FACULTY_CODE 系所代碼
		''' </summary>
		Public Property FACULTY_CODE() As String
			Get
				Return Me.ColumnyMap("FACULTY_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("FACULTY_CODE") = value
			End Set
		End Property
#End Region

#Region "COMBINATION_UNIT_NAME 組合單位名稱"
		''' <summary>
		''' COMBINATION_UNIT_NAME 組合單位名稱
		''' </summary>
		Public Property COMBINATION_UNIT_NAME() As String
			Get
				Return Me.ColumnyMap("COMBINATION_UNIT_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COMBINATION_UNIT_NAME") = value
			End Set
		End Property
#End Region

#Region "GRP_CODE 組別代碼"
		''' <summary>
		''' GRP_CODE 組別代碼
		''' </summary>
		Public Property GRP_CODE() As String
			Get
				Return Me.ColumnyMap("GRP_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("GRP_CODE") = value
			End Set
		End Property
#End Region

#Region "NAME 姓名"
		''' <summary>
		''' NAME 姓名
		''' </summary>
		Public Property NAME() As String
			Get
				Return Me.ColumnyMap("NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("NAME") = value
			End Set
		End Property
#End Region

#Region "COMBINATION_UNIT_CODE 組合單位代碼"
		''' <summary>
		''' COMBINATION_UNIT_CODE 組合單位代碼
		''' </summary>
		Public Property COMBINATION_UNIT_CODE() As String
			Get
				Return Me.ColumnyMap("COMBINATION_UNIT_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COMBINATION_UNIT_CODE") = value
			End Set
		End Property
#End Region

#Region "DEGREE_CODE 部別代碼"
		''' <summary>
		''' DEGREE_CODE 部別代碼
		''' </summary>
		Public Property DEGREE_CODE() As String
			Get
				Return Me.ColumnyMap("DEGREE_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DEGREE_CODE") = value
			End Set
		End Property
#End Region

#Region "GRP_NAME 組別名稱"
		''' <summary>
		''' GRP_NAME 組別名稱
		''' </summary>
		Public Property GRP_NAME() As String
			Get
				Return Me.ColumnyMap("GRP_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("GRP_NAME") = value
			End Set
		End Property
#End Region

#Region "SEX 性別"
		''' <summary>
		''' SEX 性別
		''' </summary>
		Public Property SEX() As String
			Get
				Return Me.ColumnyMap("SEX")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SEX") = value
			End Set
		End Property
#End Region

#Region "LOGIN_ACNT 登入帳號"
        ''' <summary>
        ''' LOGIN_ACNT 登入帳號
        ''' </summary>
        Public Property LOGIN_ACNT() As String
            Get
                Return Me.ColumnyMap("LOGIN_ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LOGIN_ACNT") = value
            End Set
        End Property
#End Region

#Region "STUDY_STATUS_NAME 在學狀態名稱"
		''' <summary>
		''' STUDY_STATUS_NAME 在學狀態名稱
		''' </summary>
		Public Property STUDY_STATUS_NAME() As String
			Get
				Return Me.ColumnyMap("STUDY_STATUS_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("STUDY_STATUS_NAME") = value
			End Set
		End Property
#End Region

#Region "ASYS_CODE 學制代碼"
		''' <summary>
		''' ASYS_CODE 學制代碼
		''' </summary>
		Public Property ASYS_CODE() As String
			Get
				Return Me.ColumnyMap("ASYS_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ASYS_CODE") = value
			End Set
		End Property
#End Region

#Region "CLASSNO 班級"
		''' <summary>
		''' CLASSNO 班級
		''' </summary>
		Public Property CLASSNO() As String
			Get
				Return Me.ColumnyMap("CLASSNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CLASSNO") = value
			End Set
		End Property
#End Region

#Region "COLLEGE_NAME 學院名稱"
		''' <summary>
		''' COLLEGE_NAME 學院名稱
		''' </summary>
		Public Property COLLEGE_NAME() As String
			Get
				Return Me.ColumnyMap("COLLEGE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("COLLEGE_NAME") = value
			End Set
		End Property
#End Region

#Region "DEP_NAME 單位名稱"
		''' <summary>
		''' DEP_NAME 單位名稱
		''' </summary>
		Public Property DEP_NAME() As String
			Get
				Return Me.ColumnyMap("DEP_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DEP_NAME") = value
			End Set
		End Property
#End Region

#Region "FACULTY_NAME 系所名稱"
        ''' <summary>
        ''' FACULTY_NAME 系所名稱
        ''' </summary>
        Public Property FACULTY_NAME() As String
            Get
                Return Me.ColumnyMap("FACULTY_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FACULTY_NAME") = value
            End Set
        End Property
#End Region

#Region "SMS 學期"
		''' <summary>
		''' SMS 學期
		''' </summary>
		Public Property SMS() As String
			Get
				Return Me.ColumnyMap("SMS")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SMS") = value
			End Set
		End Property
#End Region

#Region "ASYS_NAME 學制名稱"
		''' <summary>
		''' ASYS_NAME 學制名稱
		''' </summary>
		Public Property ASYS_NAME() As String
			Get
				Return Me.ColumnyMap("ASYS_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ASYS_NAME") = value
			End Set
		End Property
#End Region

#Region "AYEAR 學年度"
		''' <summary>
		''' AYEAR 學年度
		''' </summary>
		Public Property AYEAR() As String
			Get
				Return Me.ColumnyMap("AYEAR")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("AYEAR") = value
			End Set
		End Property
#End Region

#Region "DEGREE_NAME 部別名稱"
		''' <summary>
		''' DEGREE_NAME 部別名稱
		''' </summary>
		Public Property DEGREE_NAME() As String
			Get
				Return Me.ColumnyMap("DEGREE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DEGREE_NAME") = value
			End Set
		End Property
#End Region

#Region "IDNO 身分證字號"
		''' <summary>
		''' IDNO 身分證字號
		''' </summary>
		Public Property IDNO() As String
			Get
				Return Me.ColumnyMap("IDNO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IDNO") = value
			End Set
		End Property
#End Region

#Region "VER 版本"
		''' <summary>
		''' VER 版本
		''' </summary>
		Public Property VER() As String
			Get
				Return Me.ColumnyMap("VER")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("VER") = value
			End Set
		End Property
#End Region

#Region "LOGIN_PAGE 登入頁"
        ''' <summary>
        ''' LOGIN_PAGE 登入頁
        ''' </summary>
        Public Property LOGIN_PAGE() As String
            Get
                Return Me.PropertyMap("LOGIN_PAGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LOGIN_PAGE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "SetTeSession 設定教職員Session "
		
		''' <summary>
		''' 設定教職員Session 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub SetTeSession()
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

                Dim ent As New Pos.Data.EntPerson(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = " AND $.ACNT = '" & Me.LOGIN_ACNT & "' "
                Dim dt As DataTable = ent.GetPerson()

                If dt.Rows.Count > 0 Then
                    'SessionClass.登入帳號 = dt.Rows(0)("ACNT").ToString.Trim
                    SessionClass.員工編號 = dt.Rows(0)("ACNT").ToString.Trim
                    SessionClass.電子信箱 = dt.Rows(0)("EMAIL").ToString.Trim
                    SessionClass.中文姓名 = dt.Rows(0)("CH_NAME").ToString.Trim
                    SessionClass.字型大小 = dt.Rows(0)("FONT_SIZE").ToString.Trim
                    SessionClass.樣式 = dt.Rows(0)("MENU_STYLE").ToString.Trim
                    SessionClass.帳號期限起日 = dt.Rows(0)("DEADLINE_SDATE").ToString.Trim
                    SessionClass.帳號期限訖日 = dt.Rows(0)("DEADLINE_EDATE").ToString.Trim
                    SessionClass.使用狀態 = dt.Rows(0)("USE_STATE").ToString.Trim
                    SessionClass.人員類別 = dt.Rows(0)("PERSON_TYPE").ToString.Trim
                    SessionClass.部門代碼 = dt.Rows(0)("DEP_CODE").ToString.Trim
                    SessionClass.部門名稱 = dt.Rows(0)("DEP_NAME").ToString.Trim
                    SessionClass.每頁筆數 = dt.Rows(0)("DEFAULT_NUM").ToString.Trim
                    SessionClass.所有執照 = dt.Rows(0)("IS_ALL").ToString.Trim
                    SessionClass.執照號碼 = dt.Rows(0)("LICENSE_NO_DATA").ToString.Trim
                    SessionClass.聯絡電話 = dt.Rows(0)("CONTACT_TEL").ToString.Trim
                    SessionClass.機構代碼 = dt.Rows(0)("COM_CODE").ToString.Trim
                End If
                Me.ResetColumnProperty()

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#End Region

    End Class
End Namespace

