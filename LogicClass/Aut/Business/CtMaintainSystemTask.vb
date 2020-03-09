'----------------------------------------------------------------------------------
'File Name		: CtMaintainSystemTask 
'Author			: nono
'Description		: CtMaintainSystemTask 維護系統作業ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/14	nono   		Source Create
'----------------------------------------------------------------------------------

Imports Aut.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

NameSpace Aut.Business
	''' <summary>
	''' CtMaintainSystemTask 維護系統作業ct
	''' </summary>
	Public partial Class CtMaintainSystemTask
		Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "OPEN_OUTSIDE 開啟外網使用"
        ''' <summary>
        ''' OPEN_OUTSIDE 開啟外網使用
        ''' </summary>
        Public Property OPEN_OUTSIDE() As String
            Get
                Return Me.PropertyMap("OPEN_OUTSIDE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_OUTSIDE") = value
            End Set
        End Property
#End Region

#Region "CODE_TYPE 代碼類別"
        ''' <summary>
        ''' CODE_TYPE 代碼類別
        ''' </summary>
        Public Property CODE_TYPE() As String
            Get
                Return Me.PropertyMap("CODE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CODE_TYPE") = value
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

#Region "DATA_FIELD_CH 資料欄位中文名稱"
        ''' <summary>
        ''' DATA_FIELD_CH 資料欄位中文名稱
        ''' </summary>
        Public Property DATA_FIELD_CH() As String
            Get
                Return Me.PropertyMap("DATA_FIELD_CH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_FIELD_CH") = value
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

#Region "FN_NM 功能名稱"
        ''' <summary>
        ''' FN_NM 功能名稱
        ''' </summary>
        Public Property FN_NM() As String
            Get
                Return Me.PropertyMap("FN_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FN_NM") = value
            End Set
        End Property
#End Region

#Region "IS_DEL 是否刪除"
        ''' <summary>
        ''' IS_DEL 是否刪除
        ''' </summary>
        Public Property IS_DEL() As String
            Get
                Return Me.PropertyMap("IS_DEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_DEL") = value
            End Set
        End Property
#End Region

#Region "IS_USE 是否使用"
        ''' <summary>
        ''' IS_USE 是否使用
        ''' </summary>
        Public Property IS_USE() As String
            Get
                Return Me.PropertyMap("IS_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_USE") = value
            End Set
        End Property
#End Region

#Region "NAME_FIELD 名稱欄位"
        ''' <summary>
        ''' NAME_FIELD 名稱欄位
        ''' </summary>
        Public Property NAME_FIELD() As String
            Get
                Return Me.PropertyMap("NAME_FIELD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NAME_FIELD") = value
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

#Region "OPEN_DATEE 開放日期訖"
        ''' <summary>
        ''' OPEN_DATEE 開放日期訖
        ''' </summary>
        Public Property OPEN_DATEE() As String
            Get
                Return Me.PropertyMap("OPEN_DATEE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATEE") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATES 開放日期起"
        ''' <summary>
        ''' OPEN_DATES 開放日期起
        ''' </summary>
        Public Property OPEN_DATES() As String
            Get
                Return Me.PropertyMap("OPEN_DATES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATES") = value
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

#Region "OPERATE_LEVEL 作業層級"
        ''' <summary>
        ''' OPERATE_LEVEL 作業層級
        ''' </summary>
        Public Property OPERATE_LEVEL() As String
            Get
                Return Me.PropertyMap("OPERATE_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATE_LEVEL") = value
            End Set
        End Property
#End Region

#Region "OPERATE_NM 作業名稱"
        ''' <summary>
        ''' OPERATE_NM 作業名稱
        ''' </summary>
        Public Property OPERATE_NM() As String
            Get
                Return Me.PropertyMap("OPERATE_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATE_NM") = value
            End Set
        End Property
#End Region

#Region "OPERATE_SORT 作業排序"
        ''' <summary>
        ''' OPERATE_SORT 作業排序
        ''' </summary>
        Public Property OPERATE_SORT() As String
            Get
                Return Me.PropertyMap("OPERATE_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATE_SORT") = value
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

#Region "PROG_EXPL 程式說明"
        ''' <summary>
        ''' PROG_EXPL 程式說明
        ''' </summary>
        Public Property PROG_EXPL() As String
            Get
                Return Me.PropertyMap("PROG_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_EXPL") = value
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

#Region "PROG_PATH 程式路徑"
        ''' <summary>
        ''' PROG_PATH 程式路徑
        ''' </summary>
        Public Property PROG_PATH() As String
            Get
                Return Me.PropertyMap("PROG_PATH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_PATH") = value
            End Set
        End Property
#End Region

#Region "PROG_SORT 程式排序"
        ''' <summary>
        ''' PROG_SORT 程式排序
        ''' </summary>
        Public Property PROG_SORT() As String
            Get
                Return Me.PropertyMap("PROG_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_SORT") = value
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

#Region "SYS_AGT 系統代理人"
        ''' <summary>
        ''' SYS_AGT 系統代理人
        ''' </summary>
        Public Property SYS_AGT() As String
            Get
                Return Me.PropertyMap("SYS_AGT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_AGT") = value
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

#Region "SYS_CHARGE 系統負責人"
        ''' <summary>
        ''' SYS_CHARGE 系統負責人
        ''' </summary>
        Public Property SYS_CHARGE() As String
            Get
                Return Me.PropertyMap("SYS_CHARGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_CHARGE") = value
            End Set
        End Property
#End Region

#Region "SYS_NM 系統名稱"
        ''' <summary>
        ''' SYS_NM 系統名稱
        ''' </summary>
        Public Property SYS_NM() As String
            Get
                Return Me.PropertyMap("SYS_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_NM") = value
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

#Region "UPPER_OPERATE_CD 上層作業代號"
        ''' <summary>
        ''' UPPER_OPERATE_CD 上層作業代號
        ''' </summary>
        Public Property UPPER_OPERATE_CD() As String
            Get
                Return Me.PropertyMap("UPPER_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPPER_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "VALUE_FIELD 值欄位"
        ''' <summary>
        ''' VALUE_FIELD 值欄位
        ''' </summary>
        Public Property VALUE_FIELD() As String
            Get
                Return Me.PropertyMap("VALUE_FIELD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VALUE_FIELD") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 值欄位"
        ''' <summary>
        ''' USE_STATE 值欄位
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

#Region "SYS_SORT 系統排序("
        ''' <summary>
        ''' SYS_SORT 系統排序(
        ''' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.PropertyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_1 網路位址1"
        ''' <summary>
        ''' NETWK_ADDR_1 網路位址1
        ''' </summary>
        Public Overloads Property NETWK_ADDR_1() As Integer
            Get
                Return Me.PropertyMap("NETWK_ADDR_1")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("NETWK_ADDR_1") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_2 網路位址2"
        ''' <summary>
        ''' NETWK_ADDR_2 網路位址2
        ''' </summary>
        Public Overloads Property NETWK_ADDR_2() As Integer
            Get
                Return Me.PropertyMap("NETWK_ADDR_2")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("NETWK_ADDR_2") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_3 網路位址3"
        ''' <summary>
        ''' NETWK_ADDR_3 網路位址3
        ''' </summary>
        Public Overloads Property NETWK_ADDR_3() As Integer
            Get
                Return Me.PropertyMap("NETWK_ADDR_3")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("NETWK_ADDR_3") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_4 網路位址4"
        ''' <summary>
        ''' NETWK_ADDR_4 網路位址4
        ''' </summary>
        Public Overloads Property NETWK_ADDR_4() As Integer
            Get
                Return Me.PropertyMap("NETWK_ADDR_4")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("NETWK_ADDR_4") = value
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
#Region "AddAutCode 新增權限代碼"
        ''' <summary>
        ''' 新增權限代碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Sub AddAutCode()
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.Insert()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                ent.CODE_TYPE = Me.CODE_TYPE        '代碼類別
                ent.VALUE_FIELD = Me.VALUE_FIELD      '值欄位
                ent.NAME_FIELD = Me.NAME_FIELD       '名稱欄位
                ent.TABLE_NM = Me.TABLE_NM     '表格名稱
                ent.DATA_FIELD_CH = Me.DATA_FIELD_CH    '資料欄位中文名稱
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddProFunction 新增程式功能"
        ''' <summary>
        ''' 新增程式功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Sub AddProFunction()
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
                'EntProFunction = new EntProFunction()
                'return EntProFunction.Insert()
                Dim ent As EntProFunction = New EntProFunction(Me.DBManager, Me.LogUtil)
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.FN_NM = Me.FN_NM    '功能名稱
                ent.IS_DEL = Me.IS_DEL   '是否刪除
                ent.PROG_CD = Me.PROG_CD  '程式代號

                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddSysProgram 新增系統程式"
        ''' <summary>
        ''' 新增系統程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' 0.0.2 政諺 2010/09/10 Modify 底層PKNO改為String
        ''' </remarks>
        Public Function AddSysProgram() As String
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
                'EntSysProgram = new EntSysProgram()
                'return EntSysProgram.Insert()
                Dim ent As EntSysProgram = New EntSysProgram(Me.DBManager, Me.LogUtil)
                ent.OPERATE_CD = Me.OPERATE_CD   '作業代號
                ent.OUTSIDE_USE = Me.OUTSIDE_USE  '外網使用
                ent.CRD_CLASS_USE = Me.CRD_CLASS_USE    '學分班使用
                ent.RECRUITST_USE = Me.RECRUITST_USE    '招生使用
                ent.USE_STATE = Me.USE_STATE    '使用狀態
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.PROG_NM = Me.PROG_NM  '程式名稱
                ent.PROG_SORT = Me.PROG_SORT    '程式排序
                ent.PROG_EXPL = Me.PROG_EXPL    '程式說明
                ent.PROG_PATH = Me.PROG_PATH    '程式路徑
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.OPEN_DATEE = Me.OPEN_DATEE   '開放日期訖
                ent.OPEN_DATES = Me.OPEN_DATES   '開放日期起
                ent.OPEN_OUTSIDE = Me.OPEN_OUTSIDE   '開放日期起

                Dim pkno As String = ent.Insert()

                Me.ResetColumnProperty()

                Return pkno
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddSystem 新增系統"
        ''' <summary>
        ''' 新增系統 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub AddSystem()
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
                'EntSystem = new EntSystem()
                'return EntSystem.Insert()

                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.EDU_FG = Me.EDU_FG   '教學務別
                ent.SYS_AGT = Me.SYS_AGT  '系統代理人
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.SYS_NM = Me.SYS_NM   '系統名稱
                ent.SYS_CHARGE = Me.SYS_CHARGE   '系統負責人
                ent.SYS_SORT = Me.SYS_SORT
                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddSystemTask 新增系統作業"
        ''' <summary>
        ''' 新增系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub AddSystemTask()
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
                'EntSystem = new EntSystem()
                'return EntSystem.AddSystemTask_新增系統作業()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_NM = Me.OPERATE_NM       '作業名稱
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.OPERATE_SORT = Me.OPERATE_SORT     '作業排序
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.AddSystemTask()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteAutCode 刪除權限代碼"
        ''' <summary>
        ''' 刪除權限代碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Sub DeleteAutCode()
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
                'EntAutCode = new EntAutCode()
                '組合查詢字串(EntAutCode.QUERY_COND(查詢條件),"=",Pkno,PROG_CD(程式代號),FN_CD(功能代號))
                'return EntAutCode.Delete()

                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "CODE_TYPE", Me.CODE_TYPE) '代碼類別
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)   '資料欄位英文名稱
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_CH", Me.DATA_FIELD_CH) '資料欄位中文名稱
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteProFunction 刪除程式功能"
        ''' <summary>
        ''' 刪除程式功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Sub DeleteProFunction()
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
                'EntProFunction = new EntProFunction()
                '組合查詢字串(EntProFunction.QUERY_COND(查詢條件),"=",Pkno,PROG_CD(程式代號),FN_CD(功能代號))
                'return EntProFunction.Delete()
                Dim ent As EntProFunction = New EntProFunction(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD) '程式代號
                Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD) '功能代號

                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()

                'Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSysProgram 刪除系統程式"
        ''' <summary>
        ''' 刪除系統程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Sub DeleteSysProgram()
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
                'Set CtMaintainSystemTask_維護系統作業ct.PROG_CD(程式代號)=PROG_CD(程式代號)
                'return CtMaintainSystemTask_維護系統作業ct.DeleteProFunction_刪除程式功能()
                Me.DeleteProFunction()

                'EntSysProgram = new EntSysProgram()
                '組合查詢字串(EntSysProgram.QUERY_COND(查詢條件),"=",Pkno,SYS_CD(系統代號),OPERATE_CD(作業代號),PROG_CD(程式代號))
                'return EntSysProgram.Delete()
                Dim ent As EntSysProgram = New EntSysProgram(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)       '系統代號
                Me.ProcessQueryCondition(condition, "=", "OPERATE_CD", Me.OPERATE_CD)   '作業代號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)     '程式代號

                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSystem 刪除系統"
        ''' <summary>
        ''' 刪除系統 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub DeleteSystem()
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
                'EntSystem = new EntSystem()
                '組合查詢字串(EntSystem.QUERY_COND(查詢條件),"=",Pkno,SYS_CD(系統代號),EDU_FG(教學務別))
                'return EntSystem.Delete()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)   '系統代號
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)   '教學務別

                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSystemTask 刪除系統作業"
        ''' <summary>
        ''' 刪除系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub DeleteSystemTask()
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
                'EntSystem = new EntSystem()
                'return EntSystem.DeleteSystemTask_刪除系統作業()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.OPERATE_CD = Me.OPERATE_CD   '作業代號
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.DeleteSystemTask()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetAllColumnDD 取得所有欄位資料"
        ''' <summary>
        ''' 取得所有欄位資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Function GetAllColumnDD() As DataTable
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.GetAllColumnDD_取得所有欄位資料()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                ent.DATA_FIELD_CH = Me.DATA_FIELD_CH    '資料欄位中文名稱
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetAllColumnDD()
                Else
                    result = ent.GetAllColumnDD(Me.PageNo, Me.PageSize)
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

#Region "GetAutCode 取得權限代碼"
        ''' <summary>
        ''' 取得權限代碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Function GetAutCode() As DataTable
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
                'EntAutCode = new EntAutCode()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)

                '組合查詢字串(EntAutCode.QUERY_COND(查詢條件),"=",Pkno,CODE_TYPE(代碼類別),DATA_FIELD_ENG(資料欄位英文名稱),DATA_FIELD_CH(資料欄位中文名稱))
                'return EntAutCode.Query()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "CODE_TYPE", Me.CODE_TYPE) '代碼類別
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)   '資料欄位英文名稱
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_CH", Me.DATA_FIELD_CH) '資料欄位中文名稱

                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.OrderBys = "PKNO"
                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.Query()
                Else
                    result = ent.Query(Me.PageNo, Me.PageSize)
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

#Region "GetFieldAllValue 取得欄位所有值"
        ''' <summary>
        ''' 取得欄位所有值 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function GetFieldAllValue() As DataTable
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.GetFieldAllValue_取得欄位所有值()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                ent.VALUE_FIELD = Me.VALUE_FIELD  '值欄位
                ent.NAME_FIELD = Me.NAME_FIELD   '名稱欄位
                ent.TABLE_NM = Me.TABLE_NM '表格名稱

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetFieldAllValue()
                Else
                    result = ent.GetFieldAllValue(Me.PageNo, Me.PageSize)
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

#Region "GetGroupFieldDDL 取得群組欄位下拉"
        ''' <summary>
        ''' 取得群組欄位下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function GetGroupFieldDDL() As DataTable
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.GetGroupFieldDDL_取得群組欄位下拉()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)

                Dim result As DataTable = ent.GetGroupFieldDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetProFunction 取得程式功能"
        ''' <summary>
        ''' 取得程式功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function GetProFunction() As DataTable
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
                'EntProFunction = new EntProFunction()
                'return EntProFunction.GetProFunction_取得程式功能()
                Dim ent As EntProFunction = New EntProFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.IS_DEL = Me.IS_DEL   '是否刪除
                ent.PROG_CD = Me.PROG_CD  '程式代號

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetProFunction()
                Else
                    result = ent.GetProFunction(Me.PageNo, Me.PageSize)
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

#Region "GetProgFieldDDL 取得程式欄位下拉"
        ''' <summary>
        ''' 取得程式欄位下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetProgFieldDDL() As DataTable
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.GetProgFieldDDL_取得程式欄位下拉()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                Dim result As DataTable = ent.GetProgFieldDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSysProgram 取得系統程式"
        ''' <summary>
        ''' 取得系統程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function GetSysProgram() As DataTable
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
                'EntSysProgram = new EntSysProgram()
                'return EntSysProgram.GetSysProgram_取得系統程式()
                Dim ent As EntSysProgram = New EntSysProgram(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OUTSIDE_USE = Me.OUTSIDE_USE      '外網使用
                ent.CRD_CLASS_USE = Me.CRD_CLASS_USE    '學分班使用
                ent.RECRUITST_USE = Me.RECRUITST_USE    '招生使用
                ent.USE_STATE = Me.USE_STATE        '使用狀態
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.PROG_SORT = Me.PROG_SORT        '程式排序
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.OPEN_DATE = Me.OPEN_DATE        '開放日期

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetSysProgram()
                Else
                    result = ent.GetSysProgram(Me.PageNo, Me.PageSize)
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

#Region "GetSysProgramNmDDL 取得系統程式名稱下拉"
        ''' <summary>
        ''' 取得系統程式名稱下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Function GetSysProgramNmDDL() As DataTable
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
                'EntSysProgram = new EntSysProgram()
                'return EntSysProgram.GetSysProgramNmDDL_取得系統程式名稱下拉()
                Dim ent As EntSysProgram = New EntSysProgram(Me.DBManager, Me.LogUtil)
                ent.SYS_CD = Me.SYS_CD
                ent.OPERATE_CD = Me.OPERATE_CD
                Dim result As DataTable = ent.GetSysProgramNmDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSystem 取得系統"
        ''' <summary>
        ''' 取得系統 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystem() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理查詢條件 ===


                '=== 處理說明 ===
                'EntSystem = new EntSystem()
                'return EntSystem.GetSystem_取得系統()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'PKNO
                ent.EDU_FG = Me.EDU_FG   '教學務別
                ent.SYS_AGT = Me.SYS_AGT  '系統代理人
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.SYS_NM = Me.SYS_NM   '系統名稱
                ent.SYS_CHARGE = Me.SYS_CHARGE   '系統負責人

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetSystem()
                Else
                    result = ent.GetSystem(Me.PageNo, Me.PageSize)
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

#Region "GetSystemNmDDL 取得系統名稱下拉"
        ''' <summary>
        ''' 取得系統名稱下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystemNmDDL() As DataTable
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
                'EntSystem = new EntSystem()
                'return EntSystem.GetSystemNmDDL_取得系統名稱下拉()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = Me.SqlRetrictions
                Dim result As DataTable = ent.GetSystemNmDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetEduFgDDL 取得專案別下拉"
        ''' <summary>
        ''' 取得專案別下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetEduFgDDL() As DataTable
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
                'EntSystem = new EntSystem()
                'return EntSystem.GetSystemNmDDL_取得系統名稱下拉()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                Dim result As DataTable = ent.GetEduFgDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSystemTask 取得系統作業"
        ''' <summary>
        ''' 取得系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystemTask() As DataTable
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
                'EntSystem = new EntSystem()
                'return EntSystem.GetSystemTask_取得系統作業()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.SYS_CD = Me.SYS_CD       '系統代號

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = ent.GetSystemTask()
                Else
                    result = ent.GetSystemTask(Me.PageNo, Me.PageSize)
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

#Region "GetSystemTaskNmDDL 取得系統作業名稱下拉"
        ''' <summary>
        ''' 取得系統作業名稱下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystemTaskNmDDL() As DataTable
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
                'EntSystem = new EntSystem()
                'return EntSystem.GetSystemTaskNmDDL_取得系統作業名稱下拉()
                Dim result As DataTable
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.SYS_CD = Me.SYS_CD
                result = ent.GetSystemTaskNmDDL()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateAutCode 更新權限代碼"
        ''' <summary>
        ''' 更新權限代碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/16 新增方法
        ''' </remarks>
        Public Function UpdateAutCode() As Integer
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
                'EntAutCode = new EntAutCode()
                'return EntAutCode.UpdateByPkno()
                Dim ent As EntAutCode = New EntAutCode(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.CODE_TYPE = Me.CODE_TYPE        '代碼類別
                ent.VALUE_FIELD = Me.VALUE_FIELD      '值欄位
                ent.NAME_FIELD = Me.NAME_FIELD       '名稱欄位
                ent.TABLE_NM = Me.TABLE_NM     '表格名稱
                ent.DATA_FIELD_CH = Me.DATA_FIELD_CH    '資料欄位中文名稱
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                Dim count As Integer = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateProFunction 更新程式功能"
        ''' <summary>
        ''' 更新程式功能 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function UpdateProFunction() As Integer
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
                'EntProFunction = new EntProFunction()
                'return EntProFunction.UpdateByPkno()
                Dim ent As EntProFunction = New EntProFunction(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.FN_CD = Me.FN_CD    '功能代號
                ent.FN_NM = Me.FN_NM    '功能名稱
                ent.IS_DEL = Me.IS_DEL   '是否刪除
                ent.PROG_CD = Me.PROG_CD  '程式代號
                Dim count As Integer = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSysProgram 更新系統程式"
        ''' <summary>
        ''' 更新系統程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/17 新增方法
        ''' </remarks>
        Public Function UpdateSysProgram() As Integer
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
                'EntSysProgram = new EntSysProgram()
                'return EntSysProgram.UpdateByPkno()
                Dim ent As EntSysProgram = New EntSysProgram(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OUTSIDE_USE = Me.OUTSIDE_USE      '外網使用
                ent.CRD_CLASS_USE = Me.CRD_CLASS_USE    '學分班使用
                ent.RECRUITST_USE = Me.RECRUITST_USE    '招生使用
                ent.USE_STATE = Me.USE_STATE        '是否使用
                ent.PROG_CD = Me.PROG_CD      '程式代號
                ent.PROG_NM = Me.PROG_NM      '程式名稱
                ent.PROG_SORT = Me.PROG_SORT        '程式排序
                ent.PROG_EXPL = Me.PROG_EXPL        '程式說明
                ent.PROG_PATH = Me.PROG_PATH        '程式路徑
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.OPEN_DATEE = Me.OPEN_DATEE       '開放日期訖
                ent.OPEN_DATES = Me.OPEN_DATES       '開放日期起
                ent.ROWSTAMP = Me.ROWSTAMP
                ent.OPEN_OUTSIDE = Me.OPEN_OUTSIDE

                Dim count As Integer = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSystem 更新系統"
        ''' <summary>
        ''' 更新系統 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function UpdateSystem() As Integer
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
                'EntSystem = new EntSystem()
                'return EntSystem.UpdateByPkno()
                Dim count As Integer = 0
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.EDU_FG = Me.EDU_FG   '教學務別
                ent.SYS_AGT = Me.SYS_AGT  '系統代理人
                ent.SYS_CD = Me.SYS_CD   '系統代號
                ent.SYS_NM = Me.SYS_NM   '系統名稱
                ent.SYS_CHARGE = Me.SYS_CHARGE   '系統負責人
                ent.PKNO = Me.PKNO
                ent.ROWSTAMP = Me.ROWSTAMP
                ent.SYS_SORT = Me.SYS_SORT

                count = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSystemTask 更新系統作業"
        ''' <summary>
        ''' 更新系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function UpdateSystemTask() As Integer
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
                'EntSystem = new EntSystem()
                'return EntSystem.UpdateSystemTask_更新系統作業()
                Dim ent As EntSystem = New EntSystem(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_NM = Me.OPERATE_NM       '作業名稱
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.OPERATE_SORT = Me.OPERATE_SORT     '作業排序
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.ROWSTAMP = Me.ROWSTAMP

                Dim count As Integer = ent.UpdateSystemTask()
                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "IsInnerNetWK 是否內網"
        ''' <summary>
        ''' 是否內網 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Charles 新增方法
        ''' </remarks>
        Public Function IsInnerNetWK() As Boolean
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理查詢條件 ===


                Dim ent As EntInnerNetWKAddr = New EntInnerNetWKAddr(Me.DBManager, Me.LogUtil)
                ent.NETWK_ADDR_1 = Me.NETWK_ADDR_1
                ent.NETWK_ADDR_2 = Me.NETWK_ADDR_2
                ent.NETWK_ADDR_3 = Me.NETWK_ADDR_3
                ent.NETWK_ADDR_4 = Me.NETWK_ADDR_4

                '=== 處理查詢條件 ===
                Dim result As Boolean = ent.IsInnerNetWK

                '=== 處理取得回傳資料 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
	End Class
End NameSpace