Imports Acer.Form

NameSpace Comm.Business
    Public Class SessionClass
        Private pPropertyMap As Hashtable = New Hashtable()

        Private ReadOnly Property PropertyMap As Hashtable
            Get
                Return Me.pPropertyMap
            End Get
        End Property

        Public Sub New()

        End Sub

#Region "ACNT 員工編號"
        ''' <summary>
        ''' ACNT 員工編號
        ''' </summary>
        Public Shared Property 員工編號() As String
            Get
                Return FormUtil.Session("ACNT")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("ACNT") = value
            End Set
        End Property
#End Region

#Region "EMAIL 電子信箱"
        ''' <summary>
        ''' EMAIL 電子信箱
        ''' </summary>
        Public Shared Property 電子信箱() As String
            Get
                Return FormUtil.Session("EMAIL")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("EMAIL") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 中文姓名"
        ''' <summary>
        ''' CH_NAME 中文姓名
        ''' </summary>
        Public Shared Property 中文姓名() As String
            Get
                Return FormUtil.Session("CH_NAME")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "LOGIN_ACNT 登入帳號"
        ''' <summary>
        ''' LOGIN_ACNT 登入帳號
        ''' </summary>
        Public Shared Property 登入帳號() As String
            Get
                Return FormUtil.Session("LOGIN_ACNT")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("LOGIN_ACNT") = value
            End Set
        End Property
#End Region

#Region "LOGIN_ACNT 登入帳號-模擬前"
        ''' <summary>
        ''' LOGIN_ACNT 登入帳號-模擬前
        ''' </summary>
        Public Shared Property 登入帳號_模擬前() As String
            Get
                Return FormUtil.Session("LOGIN_ACNT_SRC")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("LOGIN_ACNT_SRC") = value
            End Set
        End Property
#End Region


#Region "FONT_SIZE 字型大小"
        ''' <summary>
        ''' FONT_SIZE 字型大小
        ''' </summary>
        Public Shared Property 字型大小() As String
            Get
                Return FormUtil.Session("FONT_SIZE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("FONT_SIZE") = value
            End Set
        End Property
#End Region

#Region "MENU_STYLE 樣式"
        ''' <summary>
        ''' STYLE 樣式
        ''' </summary>
        Public Shared Property 樣式() As String
            Get
                Return FormUtil.Session("MENU_STYLE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("MENU_STYLE") = value
            End Set
        End Property
#End Region

#Region "PERSON_TYPE 人員類別"
        ''' <summary>
        ''' PERSON_TYPE 人員類別
        ''' </summary>
        Public Shared Property 人員類別() As String
            Get
                Return FormUtil.Session("PERSON_TYPE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("PERSON_TYPE") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 部門代碼"
        ''' <summary>
        ''' DEP_CODE 部門代碼
        ''' </summary>
        Public Shared Property 部門代碼() As String
            Get
                Return FormUtil.Session("DEP_CODE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("DEP_CODE") = value
            End Set
        End Property
#End Region

#Region "DEP_NAME 部門名稱"
        ''' <summary>
        ''' DEP_NAME 部門名稱
        ''' </summary>
        Public Shared Property 部門名稱() As String
            Get
                Return FormUtil.Session("DEP_NAME")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("DEP_NAME") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Shared Property 使用狀態() As String
            Get
                Return FormUtil.Session("USE_STATE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_SDATE 帳號期限起日"
        ''' <summary>
        ''' DEADLINE_SDATE 帳號期限起日
        ''' </summary>
        Public Shared Property 帳號期限起日() As String
            Get
                Return FormUtil.Session("DEADLINE_SDATE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("DEADLINE_SDATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_EDATE 帳號期限訖日"
        ''' <summary>
        ''' DEADLINE_EDATE 帳號期限訖日
        ''' </summary>
        Public Shared Property 帳號期限訖日() As String
            Get
                Return FormUtil.Session("DEADLINE_EDATE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("DEADLINE_EDATE") = value
            End Set
        End Property
#End Region

#Region "DEFAULT_NUM 每頁筆數"
        ''' <summary>
        ''' DEFAULT_NUM 每頁筆數
        ''' </summary>
        Public Shared Property 每頁筆數() As String
            Get
                Return FormUtil.Session("DEFAULT_NUM")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("DEFAULT_NUM") = value
            End Set
        End Property
#End Region

#Region "DATA_FILTER 資料權限"
        ''' <summary>
        ''' DATA_FILTER 資料權限
        ''' </summary>
        Public Shared Property 資料權限() As DataTable
            Get
                Return FormUtil.Session("DATA_FILTER")
            End Get
            Set(ByVal value As DataTable)
                FormUtil.Session("DATA_FILTER") = value
            End Set
        End Property
#End Region

#Region "GROUP 群組"
        ''' <summary>
        ''' STATUS_NAME 群組
        ''' </summary>
        Public Shared Property 群組() As String
            Get
                Return FormUtil.Session("GROUP")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("GROUP") = value
            End Set
        End Property
#End Region

#Region "LOGIN_PAGE 登入頁"
        ''' <summary>
        ''' LOGIN_PAGE 登入頁
        ''' </summary>
        Public Shared Property 登入頁() As String
            Get
                Return FormUtil.Session("LOGIN_PAGE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("LOGIN_PAGE") = value
            End Set
        End Property
#End Region

#Region "IS_ALL 所有執照"
        ''' <summary>
        ''' IS_ALL 所有執照
        ''' </summary>
        Public Shared Property 所有執照() As String
            Get
                Return FormUtil.Session("IS_ALL")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("IS_ALL") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO_DATA 執照號碼"
        ''' <summary>
        ''' LICENSE_NO_DATA 執照號碼
        ''' </summary>
        Public Shared Property 執照號碼() As String
            Get
                Return FormUtil.Session("LICENSE_NO_DATA")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("LICENSE_NO_DATA") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        ''' <summary>
        ''' CONTACT_TEL 聯絡電話
        ''' </summary>
        Public Shared Property 聯絡電話() As String
            Get
                Return FormUtil.Session("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "ETOKEN E政府介接"
        ''' <summary>
        ''' ETOKEN E政府介接
        ''' </summary>
        Public Shared Property E政府() As String
            Get
                Return FormUtil.Session("ETOKEN")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("ETOKEN") = value
            End Set
        End Property
#End Region

#Region "憑證卡號"
        ''' <summary>
        ''' 憑證卡號
        ''' </summary>
        Public Shared Property 憑證卡號() As String
            Get
                Return FormUtil.Session("CERCARDNUMBER")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("CERCARDNUMBER") = value
            End Set
        End Property

#End Region

#Region "憑證類型"
        ''' <summary>
        ''' 憑證類型
        ''' </summary>
        Public Shared Property 憑證類型() As String
            Get
                Return FormUtil.Session("CATYPE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("CATYPE") = value
            End Set
        End Property
#End Region

#Region "COM_CODE 機構代碼"
        ''' <summary>
        ''' COM_CODE 機構代碼
        ''' </summary>
        Public Shared Property 機構代碼() As String
            Get
                Return FormUtil.Session("COM_CODE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("COM_CODE") = value
            End Set
        End Property
#End Region

#Region "MENU_TYPE 選單類型"
        ''' <summary>
        ''' MENU_TYPE 選單類型
        ''' </summary>
        Public Shared Property MENU_TYPE() As String
            Get
                Return FormUtil.Session("MENU_TYPE")
            End Get
            Set(ByVal value As String)
                FormUtil.Session("MENU_TYPE") = value
            End Set
        End Property
#End Region

#Region "S3檔案上傳紀錄於DB的資訊暫存"
        Public Shared Property FileInfo() As FILE_INFO
            Get
                Return FormUtil.Session("FILE_INFO")
            End Get
            Set(ByVal value As FILE_INFO)
                FormUtil.Session("FILE_INFO") = value
            End Set
        End Property

        <Serializable> Public Class FILE_INFO
            Private _LIMIT As String = ""
            Private _ADDONLY As String = ""
            Private _READONLY As String = ""
            Private _BTNNAME As String = ""
            Private _KEYID As String = ""
            Private _MEMO As String = ""
            Private _CANDEL As String = ""
            Private _SIZE As String = ""
            Private _RSIZE As String = ""
            Private _SORTBY As String = ""
            Private _HASREMARK As String = ""
            Private _HASATTACHREMARK As String = ""
            Private _SORT As String = ""
            Private _CASENO As String = ""
            Private _FILENO As String = ""
            Private _FPATH As String = ""
            Private _SOURCE_FILE_NAME As String = ""
            Private _REMARK As String = ""
            Private _SORT_VALUE As String = ""
            Private _PAGENAME As String = ""


            Public Property PAGENAME() As String
                Get
                    Return _PAGENAME
                End Get
                Set(ByVal value As String)
                    _PAGENAME = value
                End Set
            End Property

            Public Property SORT_VALUE() As String
                Get
                    Return _SORT_VALUE
                End Get
                Set(ByVal value As String)
                    _SORT_VALUE = value
                End Set
            End Property

            Public Property REMARK() As String
                Get
                    Return _REMARK
                End Get
                Set(ByVal value As String)
                    _REMARK = value
                End Set
            End Property
            Public Property FPATH() As String
                Get
                    Return _FPATH
                End Get
                Set(ByVal value As String)
                    _FPATH = value
                End Set
            End Property


            Public Property FILENO() As String
                Get
                    Return _FILENO
                End Get
                Set(ByVal value As String)
                    _FILENO = value
                End Set
            End Property

            Public Property CASENO() As String
                Get
                    Return _CASENO
                End Get
                Set(ByVal value As String)
                    _CASENO = value
                End Set
            End Property

            Public Property SORT() As String
                Get
                    Return _SORT
                End Get
                Set(ByVal value As String)
                    _SORT = value
                End Set
            End Property

            Public Property HASATTACHREMARK() As String
                Get
                    Return _HASATTACHREMARK
                End Get
                Set(ByVal value As String)
                    _HASATTACHREMARK = value
                End Set
            End Property

            Public Property HASREMARK() As String
                Get
                    Return _HASREMARK
                End Get
                Set(ByVal value As String)
                    _HASREMARK = value
                End Set
            End Property


            Public Property SORTBY() As String
                Get
                    Return _SORTBY
                End Get
                Set(ByVal value As String)
                    _SORTBY = value
                End Set
            End Property

            Public Property RSIZE() As String
                Get
                    Return _RSIZE
                End Get
                Set(ByVal value As String)
                    _RSIZE = value
                End Set
            End Property

            Public Property SIZE() As String
                Get
                    Return _SIZE
                End Get
                Set(ByVal value As String)
                    _SIZE = value
                End Set
            End Property

            Public Property CANDEL() As String
                Get
                    Return _CANDEL
                End Get
                Set(ByVal value As String)
                    _CANDEL = value
                End Set
            End Property

            Public Property MEMO() As String
                Get
                    Return _MEMO
                End Get
                Set(ByVal value As String)
                    _MEMO = value
                End Set
            End Property


            Public Property KEYID() As String
                Get
                    Return _KEYID
                End Get
                Set(ByVal value As String)
                    _KEYID = value
                End Set
            End Property

            Public Property BTNNAME() As String
                Get
                    Return _BTNNAME
                End Get
                Set(ByVal value As String)
                    _BTNNAME = value
                End Set
            End Property

            Public Property ISREADONLY() As String
                Get
                    Return _READONLY
                End Get
                Set(ByVal value As String)
                    _READONLY = value
                End Set
            End Property

            Public Property ADDONLY() As String
                Get
                    Return _ADDONLY
                End Get
                Set(ByVal value As String)
                    _ADDONLY = value
                End Set
            End Property

            Public Property LIMIT() As String
                Get
                    Return _LIMIT
                End Get
                Set(ByVal value As String)
                    _LIMIT = value
                End Set
            End Property
            Public Property SOURCE_FILE_NAME() As String
                Get
                    Return _SOURCE_FILE_NAME
                End Get
                Set(ByVal value As String)
                    _SOURCE_FILE_NAME = value
                End Set
            End Property
        End Class
#End Region

#Region "自訂方法"
#Region "SessionAbandon SessionAbandon "
        ''' <summary>
        ''' SessionAbandon
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 周柏成 新增方法
        ''' </remarks>
        Public Shared Sub SessionAbandon()
            FormUtil.Session.Abandon()
        End Sub
#End Region
#End Region
    End Class
End NameSpace

