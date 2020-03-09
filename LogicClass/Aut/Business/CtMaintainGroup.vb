'----------------------------------------------------------------------------------
'File Name		: CtMaintainGroup 
'Author			: nono
'Description		: CtMaintainGroup 維護群組ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/17	nono   	Source Create
'----------------------------------------------------------------------------------

Imports Aut.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Aut.Business
    ''' <summary>
    ''' CtMaintainGroup 維護群組ct
    ''' </summary>
    Partial Public Class CtMaintainGroup
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "USE_FG 使用別"
        ''' <summary>
        ''' USE_FG 使用別
        ''' </summary>
        Public Property USE_FG() As String
            Get
                Return Me.PropertyMap("USE_FG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_FG") = value
            End Set
        End Property
#End Region

#Region "SYS_DATE 系統日期"
        ''' <summary>
        ''' SYS_DATE 系統日期
        ''' </summary>
        Public Property SYS_DATE() As String
            Get
                Return Me.PropertyMap("SYS_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_DATE") = value
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

#Region "CORRE_ACNT_FIELD 對應帳號欄位"
        ''' <summary>
        ''' CORRE_ACNT_FIELD 對應帳號欄位
        ''' </summary>
        Public Property CORRE_ACNT_FIELD() As String
            Get
                Return Me.PropertyMap("CORRE_ACNT_FIELD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CORRE_ACNT_FIELD") = value
            End Set
        End Property
#End Region

#Region "CORRE_NAME_FIELD 對應姓名欄位"
        ''' <summary>
        ''' CORRE_NAME_FIELD 對應姓名欄位
        ''' </summary>
        Public Property CORRE_NAME_FIELD() As String
            Get
                Return Me.PropertyMap("CORRE_NAME_FIELD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CORRE_NAME_FIELD") = value
            End Set
        End Property
#End Region

#Region "CRD_CLASS_USE 學分班使用"
        ''' <summary>
        ''' CRD_CLASS_USE 學分班使用
        ''' </summary>
        Public Property CRD_CLASS_USE() As String
            Get
                Return Me.PropertyMap("CRD_CLASS_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CRD_CLASS_USE") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_ENG 資料欄位英文名稱"
        ''' <summary>
        ''' DATA_FIELD_ENG 資料欄位英文名稱
        ''' </summary>
        Public Property DATA_FIELD_ENG() As String
            Get
                Return Me.PropertyMap("DATA_FIELD_ENG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_FIELD_ENG") = value
            End Set
        End Property
#End Region

#Region "DATA_RANGE_LABEL 資料範圍符號"
        ''' <summary>
        ''' DATA_RANGE_LABEL 資料範圍符號
        ''' </summary>
        Public Property DATA_RANGE_LABEL() As String
            Get
                Return Me.PropertyMap("DATA_RANGE_LABEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_RANGE_LABEL") = value
            End Set
        End Property
#End Region

#Region "DATA_RANGE_VALUE 資料範圍值"
        ''' <summary>
        ''' DATA_RANGE_VALUE 資料範圍值
        ''' </summary>
        Public Property DATA_RANGE_VALUE() As String
            Get
                Return Me.PropertyMap("DATA_RANGE_VALUE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_RANGE_VALUE") = value
            End Set
        End Property
#End Region

#Region "EDU_FG 教學務別"
        ''' <summary>
        ''' EDU_FG 教學務別
        ''' </summary>
        Public Property EDU_FG() As String
            Get
                Return Me.PropertyMap("EDU_FG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDU_FG") = value
            End Set
        End Property
#End Region

#Region "FIELD_RW_PRVLG 欄位讀寫權限"
        ''' <summary>
        ''' FIELD_RW_PRVLG 欄位讀寫權限
        ''' </summary>
        Public Property FIELD_RW_PRVLG() As String
            Get
                Return Me.PropertyMap("FIELD_RW_PRVLG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FIELD_RW_PRVLG") = value
            End Set
        End Property
#End Region

#Region "FN_CD 功能代號"
        ''' <summary>
        ''' FN_CD 功能代號
        ''' </summary>
        Public Property FN_CD() As String
            Get
                Return Me.PropertyMap("FN_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FN_CD") = value
            End Set
        End Property
#End Region

#Region "GROUP_CODE 群組代碼"
        ''' <summary>
        ''' GROUP_CODE 群組代碼
        ''' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.PropertyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "GROUP_EXPL 群組說明"
        ''' <summary>
        ''' GROUP_EXPL 群組說明
        ''' </summary>
        Public Property GROUP_EXPL() As String
            Get
                Return Me.PropertyMap("GROUP_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_EXPL") = value
            End Set
        End Property
#End Region

#Region "GROUP_LEVEL 群組層級"
        ''' <summary>
        ''' GROUP_LEVEL 群組層級
        ''' </summary>
        Public Property GROUP_LEVEL() As String
            Get
                Return Me.PropertyMap("GROUP_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_LEVEL") = value
            End Set
        End Property
#End Region

#Region "GROUP_NAME 群組名稱"
        ''' <summary>
        ''' GROUP_NAME 群組名稱
        ''' </summary>
        Public Property GROUP_NAME() As String
            Get
                Return Me.PropertyMap("GROUP_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_NAME") = value
            End Set
        End Property
#End Region

#Region "ID_FG 身分別"
        ''' <summary>
        ''' ID_FG 身分別
        ''' </summary>
        Public Property ID_FG() As String
            Get
                Return Me.PropertyMap("ID_FG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ID_FG") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATE 開放日期"
        ''' <summary>
        ''' OPEN_DATE 開放日期
        ''' </summary>
        Public Property OPEN_DATE() As String
            Get
                Return Me.PropertyMap("OPEN_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATE") = value
            End Set
        End Property
#End Region

#Region "OPERATE_CD 作業代號"
        ''' <summary>
        ''' OPERATE_CD 作業代號
        ''' </summary>
        Public Property OPERATE_CD() As String
            Get
                Return Me.PropertyMap("OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "OUTSIDE_USE 外網使用"
        ''' <summary>
        ''' OUTSIDE_USE 外網使用
        ''' </summary>
        Public Property OUTSIDE_USE() As String
            Get
                Return Me.PropertyMap("OUTSIDE_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUTSIDE_USE") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.PropertyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RECRUITST_USE 招生使用"
        ''' <summary>
        ''' RECRUITST_USE 招生使用
        ''' </summary>
        Public Property RECRUITST_USE() As String
            Get
                Return Me.PropertyMap("RECRUITST_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECRUITST_USE") = value
            End Set
        End Property
#End Region

#Region "RESS_OPERATE_CD 負責作業代號"
        ''' <summary>
        ''' RESS_OPERATE_CD 負責作業代號
        ''' </summary>
        Public Property RESS_OPERATE_CD() As String
            Get
                Return Me.PropertyMap("RESS_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_PROG_CD 負責程式代號"
        ''' <summary>
        ''' RESS_PROG_CD 負責程式代號
        ''' </summary>
        Public Property RESS_PROG_CD() As String
            Get
                Return Me.PropertyMap("RESS_PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_SYS_CD 負責系統代號"
        ''' <summary>
        ''' RESS_SYS_CD 負責系統代號
        ''' </summary>
        Public Property RESS_SYS_CD() As String
            Get
                Return Me.PropertyMap("RESS_SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_SYS_CD") = value
            End Set
        End Property
#End Region

#Region "SQL_VALUE SQL值"
        ''' <summary>
        ''' SQL_VALUE SQL值
        ''' </summary>
        Public Property SQL_VALUE() As String
            Get
                Return Me.PropertyMap("SQL_VALUE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SQL_VALUE") = value
            End Set
        End Property
#End Region

#Region "SYS_CD 系統代號"
        ''' <summary>
        ''' SYS_CD 系統代號
        ''' </summary>
        Public Property SYS_CD() As String
            Get
                Return Me.PropertyMap("SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_CD") = value
            End Set
        End Property
#End Region

#Region "TABLE_NM 表格名稱"
        ''' <summary>
        ''' TABLE_NM 表格名稱
        ''' </summary>
        Public Property TABLE_NM() As String
            Get
                Return Me.PropertyMap("TABLE_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TABLE_NM") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD 資料欄位"
        ''' <summary>
        ''' DATA_FIELD 資料欄位
        ''' </summary>
        Public Property DATA_FIELD() As String
            Get
                Return Me.PropertyMap("DATA_FIELD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_FIELD") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_TYPE 資料欄位類別"
        ''' <summary>
        ''' DATA_FIELD_TYPE 資料欄位類別
        ''' </summary>
        Public Property DATA_FIELD_TYPE() As String
            Get
                Return Me.PropertyMap("DATA_FIELD_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_FIELD_TYPE") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 單位代碼"
        ''' <summary>
        ''' DEP_CODE 單位代碼
        ''' </summary>
        Public Property DEP_CODE() As String
            Get
                Return Me.PropertyMap("DEP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEP_CODE") = value
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

#Region "CH_NAME 中文姓名"
        ''' <summary>
        ''' CH_NAME 中文姓名
        ''' </summary>
        Public Property CH_NAME() As String
            Get
                Return Me.PropertyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "PROG_NM 程式名稱"
        ''' <summary>
        ''' PROG_NM 程式名稱
        ''' </summary>
        Public Property PROG_NM() As String
            Get
                Return Me.PropertyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_NM") = value
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
#Region "GetAcntAllGroup 取得帳號所有群組"
        ''' <summary>
        ''' 取得帳號所有群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetAcntAllGroup() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetAcntAllGroup_取得帳號所有群組()

                Dim EntGroup As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "PERSON_TYPE", Me.PERSON_TYPE)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "CH_NAME", Me.CH_NAME)   'PKNO
                EntGroup.GROUP_CODE = Me.GROUP_CODE
                EntGroup.PROG_CD = Me.PROG_CD
                EntGroup.PROG_NM = Me.PROG_NM
                EntGroup.SqlRetrictions = condition.ToString()
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = EntGroup.GetAcntAllGroup()
                Else
                    result = EntGroup.GetAcntAllGroup(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntGroup.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddColumnRange 新增欄項範圍"
        ''' <summary>
        ''' 新增欄項範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub AddColumnRange()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.AddColumnRange_新增欄項範圍()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號
                ent.AddColumnRange()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddColumnRight 新增欄項權限"
        ''' <summary>
        ''' 新增欄項權限 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub AddColumnRight()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.AddColumnRight_新增欄項權限()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.FIELD_RW_PRVLG = Me.FIELD_RW_PRVLG   '欄位讀寫權限
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.AddColumnRight()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddGroup 新增群組"
        ''' <summary>
        ''' 新增群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/18 新增方法
        ''' 0.0.2 政諺 2010/09/10 Modify 底層PKNO改為String
        ''' </remarks>
        Public Function AddGroup() As String
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
                'EntGroup = new EntGroup()
                'return EntGroup.Insert()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.EDU_FG = Me.EDU_FG   '教學務別
                ent.USE_STATE = Me.USE_STATE   '使用狀態
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.GROUP_NAME = Me.GROUP_NAME   '群組名稱
                ent.GROUP_LEVEL = Me.GROUP_LEVEL  '群組層級
                ent.GROUP_EXPL = Me.GROUP_EXPL   '群組說明
                ent.RESS_OPERATE_CD = Me.RESS_OPERATE_CD  '負責作業代號
                ent.RESS_PROG_CD = Me.RESS_PROG_CD '負責程式代號
                ent.RESS_SYS_CD = Me.RESS_SYS_CD  '負責系統代號
                ent.DEP_CODE = Me.DEP_CODE  '單位代碼
                Dim pkno As String = ent.Insert()

                Me.ResetColumnProperty()

                Return pkno
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddGroupFunction 新增群組功能"
        ''' <summary>
        ''' 新增群組功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub AddGroupFunction()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.Insert()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddGroupMember 新增群組成員"
        ''' <summary>
        ''' 新增群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub AddGroupMember()
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
                'EntGroup = new EntGroup()
                'return EntGroup.AddGroupMember_新增群組成員()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.ACNT = Me.ACNT     '帳號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.ID_FG = Me.ID_FG    '身分別

                ent.AddGroupMember()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddGroupRightRange 新增群組權限範圍"
        ''' <summary>
        ''' 新增群組權限範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Sub AddGroupRightRange()
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
                'EntGroup = new EntGroup()
                'return EntGroup.AddGroupRightRange_新增群組權限範圍()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.SQL_VALUE = Me.SQL_VALUE    'SQL值
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號
                ent.AddGroupRightRange()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddProgremMenu 新增程式目錄"
        ''' <summary>
        ''' 新增程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub AddProgremMenu()
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
                'EntGroup = new EntGroup()
                'return EntGroup.AddProgremMenu_新增程式目錄()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼

                ent.AddProgremMenu()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteColumnRange 刪除欄項範圍"
        ''' <summary>
        ''' 刪除欄項範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub DeleteColumnRange()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.DeleteColumnRange_刪除欄項範圍()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                ent.DeleteColumnRange()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteColumnRight 刪除欄項權限"
        ''' <summary>
        ''' 刪除欄項權限 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub DeleteColumnRight()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.DeleteColumnRight_刪除欄項權限()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.FIELD_RW_PRVLG = Me.FIELD_RW_PRVLG   '欄位讀寫權限
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                ent.DeleteColumnRight()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroup 刪除群組"
        ''' <summary>
        ''' 刪除群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/04/07 新增方法
        ''' </remarks>
        Public Sub DeleteGroup()
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
                'EntGroup = new EntGroup()
                '組合查詢字串(EntGroup.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),GROUP_LEVEL(群組層級),EDU_FG(教學務別),RESS_SYS_CD(負責系統代號),RESS_OPERATE_CD(負責作業代號),RESS_PROG_CD(負責程式代號),USE_STATE(使用狀態))
                'return EntGroup.Delete()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'PKNO
                ent.EDU_FG = Me.EDU_FG       '教學務別
                ent.USE_STATE = Me.USE_STATE        '使用狀態
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.GROUP_LEVEL = Me.GROUP_LEVEL      '群組層級
                ent.RESS_OPERATE_CD = Me.RESS_OPERATE_CD  '負責作業代號
                ent.RESS_PROG_CD = Me.RESS_PROG_CD     '負責程式代號
                ent.RESS_SYS_CD = Me.RESS_SYS_CD      '負責系統代號

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)       '群組代碼
                Me.ProcessQueryCondition(condition, "=", "GROUP_LEVEL", Me.GROUP_LEVEL)     '群組層級
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)           '教學務別
                Me.ProcessQueryCondition(condition, "=", "RESS_SYS_CD", Me.RESS_SYS_CD)     '負責系統代號
                Me.ProcessQueryCondition(condition, "=", "RESS_OPERATE_CD", Me.RESS_OPERATE_CD) '負責作業代號
                Me.ProcessQueryCondition(condition, "=", "RESS_PROG_CD", Me.RESS_PROG_CD)   '負責程式代號
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)         '使用狀態
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                ent.Delete()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroupFunction 刪除群組功能"
        ''' <summary>
        ''' 刪除群組功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub DeleteGroupFunction()
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
                'EntGroupFunction = new EntGroupFunction()
                '組合查詢字串(EntGroup.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號),FN_CD(功能代號))
                'return EntGroupFunction.Delete()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)   '群組代碼
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)     '程式代號
                Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD)     '功能代號
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroupMember 刪除群組成員"
        ''' <summary>
        ''' 刪除群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/24 新增方法
        ''' </remarks>
        Public Sub DeleteGroupMember()
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
                'EntGroup = new EntGroup()
                'return EntGroup.DeleteGroupMember_刪除群組成員()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'PKNO
                ent.ACNT = Me.ACNT     '帳號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.ID_FG = Me.ID_FG    '身分別
                ent.DeleteGroupMember()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroupRightRange 刪除群組權限範圍"
        ''' <summary>
        ''' 刪除群組權限範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Sub DeleteGroupRightRange()
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
                'EntGroup = new EntGroup()
                'return EntGroup.DeleteGroupRightRange_刪除群組權限範圍()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DeleteGroupRightRange()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteProgremMenu 刪除程式目錄"
        ''' <summary>
        ''' 刪除程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub DeleteProgremMenu()
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
                'EntGroup = new EntGroup()
                'return EntGroup.DeleteProgremMenu_刪除程式目錄()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.DeleteProgremMenu()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetColumnRange 取得欄項範圍"
        ''' <summary>
        ''' 取得欄項範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetColumnRange() As DataTable
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.GetColumnRange_取得欄項範圍()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetColumnRange()
                Else
                    result = ent.GetColumnRange(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetColumnRight 取得欄項權限"
        ''' <summary>
        ''' 取得欄項權限 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetColumnRight() As DataTable
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.GetColumnRight_取得欄項權限()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.FIELD_RW_PRVLG = Me.FIELD_RW_PRVLG   '欄位讀寫權限
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetColumnRight()
                Else
                    result = ent.GetColumnRight(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroup 取得群組"
        ''' <summary>
        ''' 取得群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function GetGroup() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroup_取得群組()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.EDU_FG = Me.EDU_FG       '教學務別
                ent.USE_STATE = Me.USE_STATE        '使用狀態
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.GROUP_LEVEL = Me.GROUP_LEVEL      '群組層級
                ent.RESS_OPERATE_CD = Me.RESS_OPERATE_CD  '負責作業代號
                ent.RESS_PROG_CD = Me.RESS_PROG_CD     '負責程式代號
                ent.RESS_SYS_CD = Me.RESS_SYS_CD      '負責系統代號
                ent.DEP_CODE = Me.DEP_CODE          '單位代碼
                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroup()
                Else
                    result = ent.GetGroup(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TotalRowCount
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupFunction 取得群組功能"
        ''' <summary>
        ''' 取得群組功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupFunction() As DataTable
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
                'EntGroupFunction = new EntGroupFunction()
                '組合查詢字串(EntGroup.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號),FN_CD(功能代號))
                'return EntGroupFunction.Query()
                '=== 2009/03/31 改成 ===
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.GetGroupFunction_取得群組功能()

                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'PKNO
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroupFunction()
                Else
                    result = ent.GetGroupFunction(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TotalRowCount()
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetAUTT050"
        ''' <summary>
        ''' GetAUTT050 
        ''' </summary>       
        Public Function GetAUTT050() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                'Dim condition As StringBuilder = New StringBuilder()
                'Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                'Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD)       '功能代號
                'Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)     '程式代號
                'Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)  '群組代碼
                ent.PKNO = Me.PKNO     'PKNO
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼

                'ent.SqlRetrictions = condition.ToString()

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetAUTT050()
                Else
                    result = ent.GetAUTT050(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TotalRowCount()
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupMember 取得群組成員"
        ''' <summary>
        ''' 取得群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupMember() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroupMember_取得群組成員()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.ACNT = Me.ACNT     '帳號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.ID_FG = Me.ID_FG    '身分別

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroupMember()
                Else
                    result = ent.GetGroupMember(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupOthProg 取得群組其他所有程式"
        ''' <summary>
        ''' 取得群組其他所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupOthProg() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroupOthProg_取得群組其他所有程式()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.OPERATE_CD = Me.OPERATE_CD   '作業代號
                ent.USE_STATE = Me.USE_STATE    '使用狀態
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroupOthProg()
                Else
                    result = ent.GetGroupOthProg(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TotalRowCount 
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupProg 取得群組所有程式"
        ''' <summary>
        ''' 取得群組所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function GetGroupProg() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroupProg_取得群組所有程式()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.OUTSIDE_USE = Me.OUTSIDE_USE      '外網使用
                ent.CRD_CLASS_USE = Me.CRD_CLASS_USE    '學分班使用
                ent.RECRUITST_USE = Me.RECRUITST_USE    '招生使用
                ent.USE_STATE = Me.USE_STATE        '使用狀態
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.OPEN_DATE = Me.OPEN_DATE        '開放日期
                ent.SYS_CD = Me.SYS_CD        '開放日期


                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroupProg()
                Else
                    result = ent.GetGroupProg(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TotalRowCount
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupRightRange 取得群組權限範圍"
        ''' <summary>
        ''' 取得群組權限範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function GetGroupRightRange() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroupRightRange_取得群組權限範圍()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetGroupRightRange()
                Else
                    result = ent.GetGroupRightRange(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetProgremMenu 取得程式目錄"
        ''' <summary>
        ''' 取得程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetProgremMenu() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetProgremMenu_取得程式目錄()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetProgremMenu()
                Else
                    result = ent.GetProgremMenu(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetRoleIDTable 取得角色別對應表格"
        ''' <summary>
        ''' 取得角色別對應表格 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Sub GetRoleIDTable()
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
                'EntGroup = new EntGroup
                'return EntGroup.GetRoleIDTable_取得角色別對應表格()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateColumnRange 更新欄項範圍"
        ''' <summary>
        ''' 更新欄項範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function UpdateColumnRange() As Integer
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.UpdateColumnRange_更新欄項範圍()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號

                Dim count As Integer = ent.UpdateColumnRange()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateColumnRight 更新欄項權限"
        ''' <summary>
        ''' 更新欄項權限 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function UpdateColumnRight() As Integer
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.UpdateColumnRight_更新欄項權限()
                Dim ent As EntGroupFunction = New EntGroupFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.FN_CD = Me.FN_CD        '功能代號
                ent.FIELD_RW_PRVLG = Me.FIELD_RW_PRVLG   '欄位讀寫權限
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                Dim count As Integer = ent.UpdateColumnRight()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateGroup 更新群組"
        ''' <summary>
        ''' 更新群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/18 新增方法
        ''' </remarks>
        Public Function UpdateGroup() As Integer
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
                'EntGroup = new EntGroup()
                'return EntGroup.UpdateByPkno()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.EDU_FG = Me.EDU_FG       '教學務別
                ent.USE_STATE = Me.USE_STATE        '使用狀態
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.GROUP_NAME = Me.GROUP_NAME       '群組名稱
                ent.GROUP_LEVEL = Me.GROUP_LEVEL      '群組層級
                ent.GROUP_EXPL = Me.GROUP_EXPL       '群組說明
                ent.RESS_OPERATE_CD = Me.RESS_OPERATE_CD  '負責作業代號
                ent.RESS_PROG_CD = Me.RESS_PROG_CD     '負責程式代號
                ent.RESS_SYS_CD = Me.RESS_SYS_CD      '負責系統代號
                ent.ROWSTAMP = Me.ROWSTAMP

                Dim count = ent.UpdateByPkNo()
                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateGroupFunction 更新群組功能"
        ''' <summary>
        ''' 更新群組功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateGroupFunction()
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
                'EntGroupFunction = new EntGroupFunction()
                'return EntGroupFunction.UpdateByPkno()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateGroupMember 更新群組成員"
        ''' <summary>
        ''' 更新群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateGroupMember()
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
                'EntGroup = new EntGroup()
                'return EntGroup.UpdateGroupMember_更新群組成員()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateGroupRightRange 更新群組權限範圍"
        ''' <summary>
        ''' 更新群組權限範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function UpdateGroupRightRange() As Integer
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
                'EntGroup = new EntGroup()
                'return EntGroup.UpdateGroupRightRange_更新群組權限範圍()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號
                ent.ROWSTAMP = Me.ROWSTAMP
                Dim count As Integer = ent.UpdateGroupRightRange()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateProgremMenu 更新程式目錄"
        ''' <summary>
        ''' 更新程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateProgremMenu()
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
                'EntGroup = new EntGroup()
                'return EntGroup.UpdateProgremMenu_更新程式目錄()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetGroupDDL 取得群組下拉"
        ''' <summary>
        ''' 取得群組下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupDDL() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetGroupDDL_取得群組下拉()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)      'PKNO

                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable = ent.GetGroupDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetAcntAllProg 取得帳號所有程式"
        ''' <summary>
        ''' 取得帳號所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/26 新增方法
        ''' </remarks>
        Public Function GetAcntAllProg() As DataTable
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
                'EntGroup = new EntGroup()
                'return EntGroup.GetAcntAllProg_取得帳號所有程式()
                Dim ent As EntGroup = New EntGroup(Me.DBManager, Me.LogUtil)
                ent.USE_FG = Me.USE_FG   '使用別
                ent.ACNT = Me.ACNT     '帳號
                ent.SYS_DATE = Me.SYS_DATE '系統日期
                ent.ID_FG = Me.ID_FG    '身分別

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetAcntAllProg()
                Else
                    result = ent.GetAcntAllProg(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = ent.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteLoginAcntGroup 刪除登入帳號群組"
        ''' <summary>
        ''' 刪除登入帳號群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteLoginAcntGroup()
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
                'EntLoginAcntGroup = new EntLoginAcntGroup()
                '組合查詢字串(EntLoginAcntGroup.QUERY_COND(查詢條件),"=",Pkno,ACNT(帳號),GROUP_CODE(群組代碼))
                'return EntLoginAcntGroup.Delete()
                '=== 處理查詢條件 ===
                Dim EntLoginAcntGroup As EntLoginAcntGroup = New EntLoginAcntGroup(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)       '帳號
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)     '群組代碼
                EntLoginAcntGroup.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                EntLoginAcntGroup.Delete()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetSessionColDef 取得Session欄位定義"
        ''' <summary>
        ''' 取得Session欄位定義 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetSessionColDef() As DataTable
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
                'EntSessionColDef = new EntSessionColDef()
                '組合查詢字串(EntSessionColDef.QUERY_COND(查詢條件),"=",Pkno,DATA_FIELD(資料欄位),DATA_FIELD_ENG(資料欄位英文名稱))
                'return EntSessionColDef.Query()
                Dim EntSessionColDef As EntSessionColDef = New EntSessionColDef(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD", Me.DATA_FIELD)       '資料欄位
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)     '資料欄位英文名稱
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_TYPE", Me.DATA_FIELD_TYPE)     '資料欄位類別
                EntSessionColDef.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = EntSessionColDef.Query()
                Else
                    result = EntSessionColDef.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntSessionColDef.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetLoginAcntGroup 取得登入帳號群組"
        ''' <summary>
        ''' 取得登入帳號群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetLoginAcntGroup() As DataTable
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
                'EntLoginAcntGroup = new EntLoginAcntGroup()
                '組合查詢字串(EntLoginAcntGroup.QUERY_COND(查詢條件),"=",Pkno,ACNT(帳號),GROUP_CODE(群組代碼))
                'return EntLoginAcntGroup.Query()

                Dim EntLoginAcntGroup As EntLoginAcntGroup = New EntLoginAcntGroup(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)       '帳號
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)     '群組代碼
                EntLoginAcntGroup.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = EntLoginAcntGroup.Query()
                Else
                    result = EntLoginAcntGroup.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntLoginAcntGroup.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupDefAllAcnt 取得所有群組定義帳號"
        ''' <summary>
        ''' 取得所有群組定義帳號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetGroupDefAllAcnt() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===   
                Dim EntLoginAcntGroup As EntLoginAcntGroup = New EntLoginAcntGroup(Me.DBManager, Me.LogUtil)
                EntLoginAcntGroup.SQL_VALUE = Me.SQL_VALUE    'SQL值
                EntLoginAcntGroup.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                EntLoginAcntGroup.DATA_FIELD_TYPE = Me.DATA_FIELD_TYPE  '資料欄位類別

                '=== 處理說明 ===
                'EntLoginAcntGroup = new EntLoginAcntGroup
                'return EntLoginAcntGroup.GetGroupDefAllAcnt_取得所有群組定義帳號()

                'Dim condition As StringBuilder = New StringBuilder()
                'Me.ProcessQueryCondition(condition, "=", "SQL_VALUE", Me.SQL_VALUE)          'SQL值
                'Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)     '資料欄位英文名稱
                'Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_TYPE", Me.DATA_FIELD_TYPE)     '資料欄位類別
                'EntLoginAcntGroup.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = EntLoginAcntGroup.GetGroupDefAllAcnt()
                Else
                    result = EntLoginAcntGroup.GetGroupDefAllAcnt(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntLoginAcntGroup.TOTAL_ROW_COUNT
                End If
                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()
                Return result
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddLoginAcntGroup 新增登入帳號群組"
        ''' <summary>
        ''' 新增登入帳號群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddLoginAcntGroup()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim EntLoginAcntGroup As New EntLoginAcntGroup(Me.DBManager, Me.LogUtil)
                EntLoginAcntGroup.ACNT = Me.ACNT '帳號
                EntLoginAcntGroup.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                EntLoginAcntGroup.Insert()
                '=== 處理說明 ===
                'EntLoginAcntGroup = new EntLoginAcntGroup()
                'return EntLoginAcntGroup.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "取得登入者群組"
        ''' <summary>
        ''' 取得登入者的所有群組
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAcntAllGroup(ByVal acnt As String) As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.Name)

                Dim result As New StringBuilder
                Dim ctrl As New CtMaintainGroup(Me.DBManager, Me.LogUtil)
                Dim dt As DataTable
                '利用帳號及身份別取得群組
                Dim tmpIdFg As String = ""
                ctrl.ACNT = acnt
                dt = ctrl.GetGroupMember()

                For i As Integer = 0 To dt.Rows.Count - 1
                    If result.ToString = "" Then
                        result.Append(dt.Rows(i)("GROUP_CODE").ToString.Trim)
                    Else
                        result.Append("," & dt.Rows(i)("GROUP_CODE").ToString.Trim)
                    End If
                Next

                '利用條件取得登入者所有群組
                Dim dataFieldEng As String = ""
                Dim dataRangeLabel As String = ""
                Dim dataRangeValue As String = ""
                Dim sqlValue As String = ""
                Dim groupDt As DataTable
                Dim sqlDt As DataTable

                Dim proc As Acer.Form.CacheProcess = New Acer.Form.CacheProcess(DBManager)
                'groupDt = New DataTable
                'groupDt = proc.GetCacheData("AUTT040").Clone
                groupDt = ctrl.GetGroupRightRange()

                groupDt.Columns.Add("CHECKFLAG", Type.GetType("System.String"))
                For i As Integer = 0 To groupDt.Rows.Count - 1
                    dataFieldEng = IIf(IsDBNull(groupDt.Rows(i)("DATA_FIELD_ENG")), "", groupDt.Rows(i)("DATA_FIELD_ENG"))
                    dataRangeLabel = IIf(IsDBNull(groupDt.Rows(i)("DATA_RANGE_LABEL")), "", groupDt.Rows(i)("DATA_RANGE_LABEL"))
                    dataRangeValue = IIf(IsDBNull(groupDt.Rows(i)("DATA_RANGE_VALUE")), "", groupDt.Rows(i)("DATA_RANGE_VALUE"))
                    sqlValue = IIf(IsDBNull(groupDt.Rows(i)("SQL_VALUE")), "", groupDt.Rows(i)("SQL_VALUE"))

                    If sqlValue <> "" Then
                        '將SQL中@KET取代成Session的值
                        sqlValue = ReplaceKeyToSession(sqlValue)
                        sqlDt = Me.DBManager.GetDataSet(Me.DBManager.GetIConnection("TSBA"), sqlValue).Tables(0)
                        If sqlDt.Select(sqlDt.Columns(0).ColumnName & "= '" & HttpContext.Current.Session(dataFieldEng) & "'").Length > 0 Then
                            groupDt.Rows(i)("CHECKFLAG") = "Y"
                        Else
                            groupDt.Rows(i)("CHECKFLAG") = "N"
                        End If
                    Else
                        Select Case dataRangeLabel.ToUpper
                            '只能輸入<,>,=,IN
                            Case "<"
                                If HttpContext.Current.Session(dataFieldEng) < dataRangeValue Then
                                    groupDt.Rows(i)("CHECKFLAG") = "Y"
                                Else
                                    groupDt.Rows(i)("CHECKFLAG") = "N"
                                End If
                            Case ">"
                                If HttpContext.Current.Session(dataFieldEng) > dataRangeValue Then
                                    groupDt.Rows(i)("CHECKFLAG") = "Y"
                                Else
                                    groupDt.Rows(i)("CHECKFLAG") = "N"
                                End If
                            Case "="
                                If HttpContext.Current.Session(dataFieldEng) = dataRangeValue Then
                                    groupDt.Rows(i)("CHECKFLAG") = "Y"
                                Else
                                    groupDt.Rows(i)("CHECKFLAG") = "N"
                                End If
                            Case "IN"
                                If HttpContext.Current.Session(dataFieldEng) = "" Or HttpContext.Current.Session(dataFieldEng) Is Nothing Then
                                    groupDt.Rows(i)("CHECKFLAG") = "N"
                                Else
                                    If InStr(dataRangeValue, HttpContext.Current.Session(dataFieldEng)) > 0 Then
                                        groupDt.Rows(i)("CHECKFLAG") = "Y"
                                    Else
                                        groupDt.Rows(i)("CHECKFLAG") = "N"
                                    End If
                                End If
                            Case Else
                                groupDt.Rows(i)("CHECKFLAG") = "N"
                        End Select
                    End If
                Next

                '判斷同一群組的條件，要都符合才能算
                groupDt = groupDt.DefaultView.ToTable(True, New String() {"GROUP_CODE", "CHECKFLAG"})
                For i As Integer = 0 To groupDt.Rows.Count - 1
                    '只要CHECKFLAG有一個N，就不符合
                    If groupDt.Select("GROUP_CODE = '" & groupDt.Rows(i)("GROUP_CODE") & "' AND CHECKFLAG = 'N'").Length = 0 Then
                        If result.ToString = "" Then
                            result.Append(groupDt.Rows(i)("GROUP_CODE").ToString.Trim)
                        Else
                            result.Append("," & groupDt.Rows(i)("GROUP_CODE").ToString.Trim)
                        End If
                    End If
                Next

                '新版
                'Dim proc As Acer.Form.CacheProcess = New Acer.Form.CacheProcess(DBManager)
                'Dim groupDt As DataTable
                'groupDt = proc.GetCacheData("AUTT080")

                'Dim tmp_dr() As DataRow
                'Dim result As New StringBuilder
                'tmp_dr = groupDt.Select("ACNT = '" & SessionClass.登入帳號 & "'")
                'For i As Integer = 0 To tmp_dr.Length - 1
                '	result.Append(IIf(result.ToString = "", tmp_dr(i)("GROUP_CODE"), "," & tmp_dr(i)("GROUP_CODE")))
                'Next

                '=== nono add 2009/11/5 依據 AUTT010 USE_STATE 欄位判斷是否要該群組 ===
                Dim groupAry As String() = result.ToString().Split(",")
                Dim autt010Dt As DataTable = proc.GetCacheData("AUTT010")
                Dim newGroup As StringBuilder = New StringBuilder()
                For i As Integer = 0 To groupAry.Length - 1
                    If autt010Dt.Select("GROUP_CODE = '" & groupAry(i).Trim() & "' AND USE_STATE = '1'").Length > 0 Then
                        newGroup.Append(groupAry(i).Trim() & ",")
                    End If
                Next

                Return newGroup.ToString().TrimEnd(",")

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 將@KEY取代成session值
        ''' </summary>
        ''' <param name="s"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function ReplaceKeyToSession(ByVal s As String) As String
            Dim sb As New StringBuilder

            Dim pattern As String = "@\w+"
            Dim regexp As RegularExpressions.Regex = New RegularExpressions.Regex(pattern)
            Dim matches As RegularExpressions.MatchCollection = RegularExpressions.Regex.Matches(s, pattern)
            Dim from As Integer = 0
            Dim i As Integer
            Dim sessionKey As String

            Dim item As RegularExpressions.Match

            For Each item In matches
                i = item.Length - 1
                sessionKey = item.Value.Substring(0, i + 1)

                sb.Append(s.Substring(from, item.Index - from))
                sb.Append("'" & HttpContext.Current.Session(sessionKey.Replace("@", "")) & "'")
                from = item.Index + item.Length
            Next

            sb.Append(s.Substring(from))

            Return sb.ToString()
        End Function

        ''' <summary>
        ''' 檢查傳入的字元是否為 ASCII 的英文字母。 
        ''' 由於 Char.IsLetter 方法會把中文字也視為字母，因此有些需要 
        ''' 判斷 ASCII 英文字母的場合，就可以用此方法。 
        ''' </summary>
        ''' <param name="ch"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsAsciiLetter(ByVal ch As Char) As Boolean
            Dim value As Integer = Convert.ToInt32(ch)
            If value >= 41 And value <= 90 Then
                Return True
            End If
            If value >= 97 And value <= 122 Then
                Return True
            End If
            Return False
        End Function
#End Region
#End Region
    End Class
End Namespace