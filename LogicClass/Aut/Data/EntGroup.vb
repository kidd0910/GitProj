'----------------------------------------------------------------------------------
'File Name		: EntGroup
'Author			: 
'Description		: EntGroup 群組ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/18	nono		Source Create
'0.0.2      2016/08/05  Steven  修正 GetAcntAllGroup 裡面的sql (with(nolock)要放在 alias name 之後)
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

NameSpace Aut.Data
	'' <summary>
	'' EntGroup 群組ENT
	'' </summary>
	Public Class EntGroup 
		Inherits Acer.Base.EntityBase
		Implements Acer.Base.IEntityInterface 
		
#Region "建構子"
        '' <summaryEntGroup
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
            Me.TableName = "AUTT010"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "USE_FG 使用別"
        ''' <summary>
        ''' USE_FG 使用別
        ''' </summary>
        Public Property USE_FG() As String
            Get
                Return Me.ColumnyMap("USE_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_FG") = value
            End Set
        End Property
#End Region

#Region "SYS_DATE 系統日期"
        ''' <summary>
        ''' SYS_DATE 系統日期
        ''' </summary>
        Public Property SYS_DATE() As String
            Get
                Return Me.ColumnyMap("SYS_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_DATE") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATE 開放日期"
        ''' <summary>
        ''' OPEN_DATE 開放日期
        ''' </summary>
        Public Property OPEN_DATE() As String
            Get
                Return Me.ColumnyMap("OPEN_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_DATE") = value
            End Set
        End Property
#End Region

#Region "RECRUITST_USE 招生使用"
        ''' <summary>
        ''' RECRUITST_USE 招生使用
        ''' </summary>
        Public Property RECRUITST_USE() As String
            Get
                Return Me.ColumnyMap("RECRUITST_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECRUITST_USE") = value
            End Set
        End Property
#End Region

#Region "CRD_CLASS_USE 學分班使用"
        ''' <summary>
        ''' CRD_CLASS_USE 學分班使用
        ''' </summary>
        Public Property CRD_CLASS_USE() As String
            Get
                Return Me.ColumnyMap("CRD_CLASS_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CRD_CLASS_USE") = value
            End Set
        End Property
#End Region

#Region "OUTSIDE_USE 外網使用"
        ''' <summary>
        ''' OUTSIDE_USE 外網使用
        ''' </summary>
        Public Property OUTSIDE_USE() As String
            Get
                Return Me.ColumnyMap("OUTSIDE_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUTSIDE_USE") = value
            End Set
        End Property
#End Region

#Region "TOTAL_ROW_COUNT 總筆數"
        ''' <summary>
        ''' TOTAL_ROW_COUNT 總筆數
        ''' </summary>
        Public Overloads Property TOTAL_ROW_COUNT() As Integer
            Get
                Return Me.ColumnyMap("TOTAL_ROW_COUNT")
            End Get
            Set(ByVal value As Integer)
                Me.ColumnyMap("TOTAL_ROW_COUNT") = value
            End Set
        End Property
#End Region

#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT() As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "CORRE_ACNT_FIELD 對應帳號欄位"
        ''' <summary>
        ''' CORRE_ACNT_FIELD 對應帳號欄位
        ''' </summary>
        Public Property CORRE_ACNT_FIELD() As String
            Get
                Return Me.ColumnyMap("CORRE_ACNT_FIELD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CORRE_ACNT_FIELD") = value
            End Set
        End Property
#End Region

#Region "CORRE_NAME_FIELD 對應姓名欄位"
        ''' <summary>
        ''' CORRE_NAME_FIELD 對應姓名欄位
        ''' </summary>
        Public Property CORRE_NAME_FIELD() As String
            Get
                Return Me.ColumnyMap("CORRE_NAME_FIELD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CORRE_NAME_FIELD") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_ENG 資料欄位英文名稱"
        ''' <summary>
        ''' DATA_FIELD_ENG 資料欄位英文名稱
        ''' </summary>
        Public Property DATA_FIELD_ENG() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_ENG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_ENG") = value
            End Set
        End Property
#End Region

#Region "DATA_RANGE_LABEL 資料範圍符號"
        ''' <summary>
        ''' DATA_RANGE_LABEL 資料範圍符號
        ''' </summary>
        Public Property DATA_RANGE_LABEL() As String
            Get
                Return Me.ColumnyMap("DATA_RANGE_LABEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_RANGE_LABEL") = value
            End Set
        End Property
#End Region

#Region "DATA_RANGE_VALUE 資料範圍值"
        ''' <summary>
        ''' DATA_RANGE_VALUE 資料範圍值
        ''' </summary>
        Public Property DATA_RANGE_VALUE() As String
            Get
                Return Me.ColumnyMap("DATA_RANGE_VALUE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_RANGE_VALUE") = value
            End Set
        End Property
#End Region

#Region "EDU_FG 教學務別"
        ''' <summary>
        ''' EDU_FG 教學務別
        ''' </summary>
        Public Property EDU_FG() As String
            Get
                Return Me.ColumnyMap("EDU_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDU_FG") = value
            End Set
        End Property
#End Region

#Region "GROUP_CODE 群組代碼"
        ''' <summary>
        ''' GROUP_CODE 群組代碼
        ''' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "GROUP_EXPL 群組說明"
        ''' <summary>
        ''' GROUP_EXPL 群組說明
        ''' </summary>
        Public Property GROUP_EXPL() As String
            Get
                Return Me.ColumnyMap("GROUP_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_EXPL") = value
            End Set
        End Property
#End Region

#Region "GROUP_LEVEL 群組層級"
        ''' <summary>
        ''' GROUP_LEVEL 群組層級
        ''' </summary>
        Public Property GROUP_LEVEL() As String
            Get
                Return Me.ColumnyMap("GROUP_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_LEVEL") = value
            End Set
        End Property
#End Region

#Region "GROUP_NAME 群組名稱"
        ''' <summary>
        ''' GROUP_NAME 群組名稱
        ''' </summary>
        Public Property GROUP_NAME() As String
            Get
                Return Me.ColumnyMap("GROUP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_NAME") = value
            End Set
        End Property
#End Region

#Region "ID_FG 身分別"
        ''' <summary>
        ''' ID_FG 身分別
        ''' </summary>
        Public Property ID_FG() As String
            Get
                Return Me.ColumnyMap("ID_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ID_FG") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "OPERATE_CD 作業代號"
        ''' <summary>
        ''' OPERATE_CD 作業代號
        ''' </summary>
        Public Property OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_OPERATE_CD 負責作業代號"
        ''' <summary>
        ''' RESS_OPERATE_CD 負責作業代號
        ''' </summary>
        Public Property RESS_OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("RESS_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_PROG_CD 負責程式代號"
        ''' <summary>
        ''' RESS_PROG_CD 負責程式代號
        ''' </summary>
        Public Property RESS_PROG_CD() As String
            Get
                Return Me.ColumnyMap("RESS_PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_SYS_CD 負責系統代號"
        ''' <summary>
        ''' RESS_SYS_CD 負責系統代號
        ''' </summary>
        Public Property RESS_SYS_CD() As String
            Get
                Return Me.ColumnyMap("RESS_SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_SYS_CD") = value
            End Set
        End Property
#End Region

#Region "SQL_VALUE SQL值"
        ''' <summary>
        ''' SQL_VALUE SQL值
        ''' </summary>
        Public Property SQL_VALUE() As String
            Get
                Return Me.ColumnyMap("SQL_VALUE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SQL_VALUE") = value
            End Set
        End Property
#End Region

#Region "SYS_CD 系統代號"
        ''' <summary>
        ''' SYS_CD 系統代號
        ''' </summary>
        Public Property SYS_CD() As String
            Get
                Return Me.ColumnyMap("SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CD") = value
            End Set
        End Property
#End Region

#Region "TABLE_NM 表格名稱"
        ''' <summary>
        ''' TABLE_NM 表格名稱
        ''' </summary>
        Public Property TABLE_NM() As String
            Get
                Return Me.ColumnyMap("TABLE_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TABLE_NM") = value
            End Set
        End Property
#End Region

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

#Region "CH_NAME 中文姓名"
        ''' <summary>
        ''' CH_NAME 中文姓名
        ''' </summary>
        Public Property CH_NAME() As String
            Get
                Return Me.ColumnyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "PROG_NM 程式名稱"
        ''' <summary>
        ''' PROG_NM 程式名稱
        ''' </summary>
        Public Property PROG_NM() As String
            Get
                Return Me.ColumnyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_NM") = value
            End Set
        End Property
#End Region
#End Region
	
#Region "自訂方法"
#Region "AddGroupMember 新增群組成員 "
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
                'EntGroupMember = new EntGroupMember()
                'return EntGroupMember.Insert()
                Dim ent As EntGroupMember = New EntGroupMember(Me.DBManager, Me.LogUtil)
                ent.ACNT = Me.ACNT     '帳號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.ID_FG = Me.ID_FG    '身分別
                ent.Insert()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddGroupRightRange 新增群組權限範圍 "
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntGroupRightRange = new EntGroupRightRange()
                'return EntGroupRightRange.Insert()
                Dim ent As EntGroupRightRange = New EntGroupRightRange(Me.DBManager, Me.LogUtil)
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號
                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddProgremMenu 新增程式目錄 "
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
                'EntProgremMenu = new EntProgremMenu()
                'return EntProgremMenu.Insert()
                Dim ent As EntProgremMenu = New EntProgremMenu(Me.DBManager, Me.LogUtil)
                ent.PROG_CD = Me.PROG_CD  '程式代號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroupMember 刪除群組成員 "
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
                'EntGroupMember = new EntGroupMember()
                '組合查詢字串(EntProFunction.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),ID_FG(身分別),ACNT(帳號))
                'return EntGroupMember.Delete()
                Dim ent As EntGroupMember = New EntGroupMember(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)   '群組代碼
                Me.ProcessQueryCondition(condition, "=", "ID_FG", Me.ID_FG) '身分別
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   '帳號
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteGroupRightRange 刪除群組權限範圍 "
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
                'EntGroupRightRange = new EntGroupRightRange()
                '組合查詢字串(EntGroupRightRange.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),DATA_FIELD_ENG(資料欄位英文名稱))
                'return EntGroupRightRange.Delete()
                Dim ent As EntGroupRightRange = New EntGroupRightRange(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)   '群組代碼
                Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)   '資料欄位英文名稱
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                ent.Delete()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteProgremMenu 刪除程式目錄 "
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
                'EntProgremMenu = new EntProgremMenu()
                '組合查詢字串(EntGroup.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號))
                'return EntProgremMenu.Delete()
                Dim ent As EntProgremMenu = New EntProgremMenu(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)    'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)  '群組代碼
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD) '程式代號
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetGroup 取得群組 "
        ''' <summary>
        ''' 取得群組 
        ''' </summary>
        Public Function GetGroup() As DataTable
            Return Me.GetGroup(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/18 新增方法
        ''' </remarks>
        Public Function GetGroup(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo = New ArrayList()
                Me.TableCoumnInfo.Add(New String() {"AUTT010", "M", "PKNO", "GROUP_CODE", "GROUP_LEVEL", _
                       "EDU_FG", "RESS_SYS_CD", "RESS_OPERATE_CD", _
                       "RESS_PROG_CD", "DEP_CODE", "USE_STATE"})

                Dim condition As StringBuilder = New StringBuilder()
                'where 
                'A and A.GROUP_LEVEL(群組層級)=QUERY_COND(查詢條件) and A.EDU_FG(教學務別)=QUERY_COND(查詢條件) and 
                'A.RESS_SOND(查詢條_USE(是否使用)=QUERY_COND(查詢條件)

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                'Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)      '群組代碼
                If Not String.IsNullOrEmpty(Me.GROUP_CODE) Then
                    condition.Append(" AND $.GROUP_CODE IN ('" & Me.GROUP_CODE.Replace(",", "','") & "') ")     '目前在學狀況
                End If
                Me.ProcessQueryCondition(condition, "=", "GROUP_LEVEL", Me.GROUP_LEVEL)     '群組層級
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)      '教學務別
                Me.ProcessQueryCondition(condition, "=", "RESS_SYS_CD", Me.RESS_SYS_CD)     '負責系統代號
                Me.ProcessQueryCondition(condition, "=", "RESS_OPERATE_CD", Me.RESS_OPERATE_CD) '負責作業代號
                Me.ProcessQueryCondition(condition, "=", "RESS_PROG_CD", Me.RESS_PROG_CD)    '負責程式代號
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)       '使用狀態
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)    '單位代碼
                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.Pkno,A.GROUP_CODE(群組代碼),A.GROUP_NAME(群組名稱),A.GROUP_LEVEL(群組層級),A.EDU_FG(教學務別),A.RESS_SYS_CD(負責系統代號),B.RESS_SYS_NM(負責系統名稱),A.RESS_OPERATE_CD(負責作業代號),C.RESS_OPERATE_NM(負責作業名稱),
                'A.RESS_PROG_NM(負責程式名稱),D.RESS_PROG_CD(負責程式代號),A.GROUP_EXPL(群組說明),A.USE_STATE(使用狀態)
                'From AUTT010 A,AUTC010 B,AUTC020 C,AUTC030 D  
                'where A.SYS_CD(系統代號)=B.SYS_CD(系統代號) and A.SYS_CD(系統代號)=C.SYS_CD(系統代號) and A.OPERATE_CD(作業代號)=B.OPERATE_CD(作業代號) and A.PROG_CD(程式代號)=C.PROG_CD(程式代號) and 
                'A.Pkno=QUERY_COND(查詢條件) and A.GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and A.GROUP_LEVEL(群組層級)=QUERY_COND(查詢條件) and A.EDU_FG(教學務別)=QUERY_COND(查詢條件) and 
                'A.RESS_SYS_CD(負責系統代號)=QUERY_COND(查詢條件) and A.RESS_OPERATE_CD(負責作業代號)=QUERY_COND(查詢條件) and A.RESS_PROG_CD(負責程式代號)=QUERY_COND(查詢條件) and A.USE_STATE(使用狀態)=QUERY_COND(查詢條件)

                Dim sql As StringBuilder = New StringBuilder()
                sql.Append( _
                 "SELECT M.PKNO, M.ROWSTAMP, M.GROUP_CODE, M.GROUP_NAME, M.GROUP_LEVEL, M.EDU_FG, " & _
                 "M.RESS_SYS_CD, R1.SYS_NM, M.RESS_OPERATE_CD, R2.OPERATE_NM, " & _
                 "M.RESS_PROG_CD, R3.PROG_NM, M.GROUP_EXPL, M.USE_STATE ,M.DEP_CODE  " & _
                 "FROM AUTT010 M WITH(NOLOCK) " & _
                 "LEFT OUTER JOIN AUTC010 R1 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.RESS_SYS_CD	=	R1.SYS_CD " & _
                 "LEFT OUTER JOIN AUTC020 R2 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.RESS_SYS_CD		=	R2.SYS_CD AND " & _
                 "M.RESS_OPERATE_CD	=	R2.OPERATE_CD " & _
                 "LEFT OUTER JOIN AUTC030 R3 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.RESS_SYS_CD	=	R3.SYS_CD AND " & _
                 "M.RESS_OPERATE_CD	=	R3.OPERATE_CD AND " & _
                 "M.RESS_PROG_CD		=	R3.PROG_CD ")
                If Me.SqlRetrictions.Length > 0 Then
                    sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If pageNo = 0 Then
                    sql.Append("ORDER BY M.PKNO")
                Else
                    sql.Append("ORDER BY PKNO")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupMember 取得群組成員 "
        ''' <summary>
        ''' 取得群組成員 
        ''' </summary>
        Public Function GetGroupMember() As DataTable
            Return Me.GetGroupMember(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupMember(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntGroupMember = new EntGroupMember()
                'return EntGroupMember.GetGroupMember_取得群組成員()
                Dim ent As EntGroupMember = New EntGroupMember(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO     'Pkno
                ent.ACNT = Me.ACNT     '帳號
                ent.GROUP_CODE = Me.GROUP_CODE   '群組代碼
                ent.ID_FG = Me.ID_FG    '身分別

                '=== 處理查詢條件 ===
                Dim result As DataTable
                If pageNo = 0 Then
                    result = ent.GetGroupMember()

                    '=== 處理取得回傳資料 ===
                    Me.ResetColumnProperty()
                Else
                    result = ent.GetGroupMember(pageNo, pageSize)

                    '=== 處理取得回傳資料 ===
                    Me.ResetColumnProperty()

                    Me.TOTAL_ROW_COUNT = ent.TotalRowCount
                End If
              


                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupOthProg 取得群組其他所有程式 "
        ''' <summary>
        ''' 取得群組其他所有程式 
        ''' </summary>
        Public Function GetGroupOthProg() As DataTable
            Return Me.GetGroupOthProg(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組其他所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupOthProg(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo = New ArrayList()
                Me.TableCoumnInfo.Add(New String() {"AUTC030", "M", "PKNO", "OPERATE_CD", "USE_STATE", _
           "PROG_CD", "SYS_CD"})
                'where
                'Pkno=QUERY_COND(查詢條件) and SYS_CD(系統代號)=QUERY_COND(查詢條件) and OPERATE_CD(作業代號)=QUERY_COND(查詢條件)  and PROG_CD(程式代號)=QUERY_COND(查詢條件) and 
                'and USE_STATE(使用狀態)=QUERY_COND(查詢條件) and  PROG_CD(程式代號) not in 
                '(Select distinct PROG_CD(程式代號) From AUTT030 Where GROUP_CODE(群組代碼)=QUERY_COND(查詢條件))
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)    'PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)  '系統代號
                Me.ProcessQueryCondition(condition, "=", "OPERATE_CD", Me.OPERATE_CD)  '作業代號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD) '程式代號
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)  '使用狀態
                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select Pkno,PROG_CD(程式代號),PROG_NM(程式名稱),SYS_CD(系統代號),OPERATE_CD(作業代號)
                'From AUTC030 
                'where 
                'Pkno=QUERY_COND(查詢條件) and SYS_CD(系統代號)=QUERY_COND(查詢條件) and OPERATE_CD(作業代號)=QUERY_COND(查詢條件)  and PROG_CD(程式代號)=QUERY_COND(查詢條件) and 
                'and USE_STATE(使用狀態)=QUERY_COND(查詢條件) and  PROG_CD(程式代號) not in 
                '(Select distinct PROG_CD(程式代號) From AUTT030 Where GROUP_CODE(群組代碼)=QUERY_COND(查詢條件))

                Dim sql As StringBuilder = New StringBuilder()
                sql.Append( _
                 "SELECT M.PKNO, M.ROWSTAMP, M.PROG_CD, M.PROG_NM, M.SYS_CD, M.OPERATE_CD, R1.SYS_NM, R2.OPERATE_NM " & _
                 "FROM AUTC030 M WITH(NOLOCK) " & _
                 "LEFT JOIN AUTC010 R1 WITH(NOLOCK) ON R1.SYS_CD = M.SYS_CD " & _
                 "LEFT JOIN AUTC020 R2 WITH(NOLOCK) ON R2.OPERATE_CD = M.OPERATE_CD " & _
                 "WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                If Me.SqlRetrictions.Length > 0 Then
                    sql.Append("AND ")
                End If
                sql.Append( _
                 "PROG_CD	NOT IN " & _
                 "( " & _
                 "	SELECT DISTINCT PROG_CD " & _
                 "	FROM AUTT030 " & _
                 "	WHERE " & _
                 "	GROUP_CODE	=	'" & Me.GROUP_CODE & "' " & _
                 ")")

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.PROG_CD ASC ")
                Else
                    sql.Append(" ORDER BY PROG_CD ASC ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupProg 取得群組所有程式 "
        ''' <summary>
        ''' 取得群組所有程式 
        ''' </summary>
        Public Function GetGroupProg() As DataTable
            Return Me.GetGroupProg(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.2 nono 2009/04/01 判斷 Me.OPEN_DATE 有值才加入條件
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function GetGroupProg(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo = New ArrayList()
                Me.TableCoumnInfo.Add(New String() {"AUTT010", "M", "PKNO", "GROUP_CODE", "USE_STATE"})
                Me.TableCoumnInfo.Add(New String() {"AUTC030", "R2", "OPEN_DATES", "OPEN_DATEE", _
           "OUTSIDE_USE", "RECRUITST_USE", "CRD_CLASS_USE", "SYS_CD"})
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "OUTSIDE_USE", Me.OUTSIDE_USE)     '外網使用
                Me.ProcessQueryCondition(condition, "=", "CRD_CLASS_USE", Me.CRD_CLASS_USE)   '學分班使用
                Me.ProcessQueryCondition(condition, "=", "RECRUITST_USE", Me.RECRUITST_USE)   '招生使用
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)       '是否使用
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)      '群組代碼
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)      '群組代碼
                'Me.ProcessQueryCondition(condition, "<=", "OPEN_DATES",		Me.OPEN_DATE)		'開放日期
                'Me.ProcessQueryCondition(condition, ">=", "OPEN_DATEE",		Me.OPEN_DATE)		'開放日期
                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                '=== 0.0.2 nono 2009/04/01 判斷 Me.OPEN_DATE 有值才加入條件 ===
                Dim condition1 As String = ""
                If Not String.IsNullOrEmpty(Me.OPEN_DATE) Then
                    condition1 = " AND '" & Me.OPEN_DATE & "' BETWEEN NVL(R2.OPEN_DATES,'2001/01/01') AND NVL(R2.OPEN_DATEE,'9999/12/31') "
                End If

                '=== 處理說明 ===
                'Select A.GROUP_CODE(群組代碼),A.GROUP_NAME(群組名稱),B.PROG_CD(程式代號),C.PROG_NM(程式名稱),C.SYS_CD(系統代號),D.SYS_NM(系統名稱),C.OPERATE_CD(作業代號),E.OPERATE_NM(作業名稱) 
                'From AUTT010 A,AUTT030 B,AUTC030 C,AUTC020 D,AUTC010 E 
                'Where A.GROUP_CODE(群組代碼)=B.GROUP_CODE(群組代碼) and B.PROG_CD(程式代號)=C.PROG_CD(程式代號) and C.SYS_CD(系統代號)=D.SYS_CD(系統代號) and C.OPERATE_CD(作業代號)=D.OPERATE_CD(作業代號) and 
                'D.SYS_CD(系統代號)=E.SYS_CD(系統代號) and A.GROUP_CODE(群組代碼)=QUERY_COND(查詢條件)  and C.USE_STATE(是否使用)=QUERY_COND(查詢條件) and  
                'C.OPEN_DATES(開放日期起)<=查詢條件的開放日期 and C.OPEN_DATEE(開放日期訖)>=查詢條件的開放日期 and 
                'C.OUTSIDE_USE(外網使用)=QUERY_COND(查詢條件) and C.RECRUITST_USE(招生使用)=QUERY_COND(查詢條件) and C.CRD_CLASS_USE(學分班使用)=QUERY_COND(查詢條件) 
                'Order By A.GROUP_CODE(群組代碼),C.SYS_CD(系統代號),C.OPERATE_CD(作業代號),C.PROG_SORT(程式排序)
                Dim sql As StringBuilder = New StringBuilder()
                sql.Append( _
                 "SELECT M.PKNO, M.ROWSTAMP, M.GROUP_CODE, M.GROUP_NAME, R1.PROG_CD, R2.PROG_NM, R2.PROG_PATH, R2.PROG_EXPL, " & _
                 "R2.SYS_CD, R4.SYS_NM, R3.OPERATE_CD, R3.UPPER_OPERATE_CD, R3.OPERATE_NM, R3.OPERATE_SORT, R2.PROG_SORT,R2.PKNO AS AUTC020_PKNO " & _
                 "FROM AUTT010 M WITH(NOLOCK) " & _
                 "INNER JOIN AUTT030 R1 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.GROUP_CODE	=	R1.GROUP_CODE " & _
                 "INNER JOIN AUTC030 R2 WITH(NOLOCK) " & _
                 "ON " & _
                 "R1.PROG_CD	=	R2.PROG_CD " & condition1 & _
                 "LEFT OUTER JOIN AUTC020 R3 WITH(NOLOCK) " & _
                 "ON " & _
                 "R2.SYS_CD	=	R3.SYS_CD AND " & _
                 "R2.OPERATE_CD	=	R3.OPERATE_CD " & _
                 "LEFT OUTER JOIN AUTC010 R4 WITH(NOLOCK) " & _
                 "ON " & _
                 "R2.SYS_CD	=	R4.SYS_CD ")


                If Me.SqlRetrictions.Length > 0 Then
                    sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'sql.Append(" ORDER BY R2.SYS_CD ")
                If pageNo = 0 Then
                    sql.Append(" ORDER BY R1.PROG_CD  ")
                Else
                    sql.Append(" ORDER BY PROG_CD  ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupRightRange 取得群組權限範圍 "
        ''' <summary>
        ''' 取得群組權限範圍 
        ''' </summary>
        Public Function GetGroupRightRange() As DataTable
            Return Me.GetGroupRightRange(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組權限範圍 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/19 新增方法
        ''' </remarks>
        Public Function GetGroupRightRange(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntGroupRightRange = new EntGroupRightRange()
                'return EntGroupRightRange.GetGroupRightRange_取得群組權限範圍()
                Dim ent As EntGroupRightRange = New EntGroupRightRange(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱

                Dim dt As DataTable = ent.GetGroupRightRange(pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = ent.TOTAL_ROW_COUNT()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetProgremMenu 取得程式目錄 "
        ''' <summary>
        ''' 取得程式目錄 
        ''' </summary>
        Public Function GetProgremMenu() As DataTable
            Return Me.GetProgremMenu(0, 0)
        End Function

        ''' <summary>
        ''' 取得程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetProgremMenu(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntProgremMenu = new EntProgremMenu()
                '組合查詢字串(EntGroup.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號))
                'return EntProgremMenu.Query()
                Dim ent As EntProgremMenu = New EntProgremMenu(Me.DBManager, Me.LogUtil)

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)   '群組代碼
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD) '程式代號
                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                Dim dt As DataTable = ent.Query(pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = ent.TotalRowCount()
                End If

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetRoleIDTable 取得角色別對應表格 "
        ''' <summary>
        ''' 取得角色別對應表格 
        ''' </summary>
        Public Function GetRoleIDTable() As DataTable
            Return Me.GetRoleIDTable(0, 0)
        End Function

        ''' <summary>
        ''' 取得角色別對應表格 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetRoleIDTable(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntGroupMember = new EntGroupMember
                'return EntGroupMember.GetRoleIDTable_取得角色別對應表格()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateGroupMember 更新群組成員 "
        ''' <summary>
        ''' 更新群組成員 
        ''' </summary>
        Public Function UpdateGroupMember() As DataTable
            Return Me.UpdateGroupMember(0, 0)
        End Function

        ''' <summary>
        ''' 更新群組成員 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateGroupMember(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntGroupMember = new EntGroupMember()
                'return EntGroupMember.UpdateByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateGroupRightRange 更新群組權限範圍 "
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
                'EntGroupRightRange = new EntGroupRightRange()
                'return EntGroupRightRange.UpdateByPkno()
                Dim ent As EntGroupRightRange = New EntGroupRightRange(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.SQL_VALUE = Me.SQL_VALUE        'SQL值
                ent.GROUP_CODE = Me.GROUP_CODE       '群組代碼
                ent.DATA_FIELD_ENG = Me.DATA_FIELD_ENG   '資料欄位英文名稱
                ent.DATA_RANGE_VALUE = Me.DATA_RANGE_VALUE '資料範圍值
                ent.DATA_RANGE_LABEL = Me.DATA_RANGE_LABEL '資料範圍符號
                ent.ROWSTAMP = Me.ROWSTAMP

                Dim count As Integer = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateProgremMenu 更新程式目錄 "
        ''' <summary>
        ''' 更新程式目錄 
        ''' </summary>
        Public Function UpdateProgremMenu() As DataTable
            Return Me.UpdateProgremMenu(0, 0)
        End Function

        ''' <summary>
        ''' 更新程式目錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateProgremMenu(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntProgremMenu = new EntProgremMenu()
                'return EntProgremMenu.UpdateByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetGroupDDL 取得群組下拉 "
        ''' <summary>
        ''' 取得群組下拉 
        ''' </summary>
        Public Function GetGroupDDL() As DataTable
            Return Me.GetGroupDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得群組下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/20 新增方法
        ''' </remarks>
        Public Function GetGroupDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Select GROUP_CODE(群組代碼) as value,GROUP_NAME(群組名稱) as text 
                'From AUTT010 
                'Order By GROUP_CODE(群組代碼)
                Dim sql As StringBuilder = New StringBuilder()
                sql.Append( _
                 "SELECT GROUP_CODE + '-' + GROUP_NAME AS SELECT_TEXT, GROUP_CODE AS SELECT_VALUE  " & _
                 "FROM AUTT010 WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
                End If

                sql.Append(" ORDER BY GROUP_CODE ")
                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetAcntAllProg 取得帳號所有程式 "
        ''' <summary>
        ''' 取得帳號所有程式 
        ''' </summary>
        Public Function GetAcntAllProg() As DataTable
            Return Me.GetAcntAllProg(0, 0)
        End Function

        ''' <summary>
        ''' 取得帳號所有程式 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/26 新增方法
        ''' </remarks>
        Public Function GetAcntAllProg(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntGroupMember = new EntGroupMember()
                'return EntGroupMember.GetAcntAllProg_取得帳號所有程式()
                Dim ent As EntGroupMember = New EntGroupMember(Me.DBManager, Me.LogUtil)
                ent.USE_FG = Me.USE_FG   '使用別
                ent.ACNT = Me.ACNT     '帳號
                ent.SYS_DATE = Me.SYS_DATE '系統日期
                ent.ID_FG = Me.ID_FG    '身分別

                Dim dt As DataTable = ent.GetAcntAllProg(pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetAcntAllGroup 取得帳號所有群組 "
        ''' <summary>
        ''' 取得帳號所有群組 
        ''' </summary>
        Public Function GetAcntAllGroup() As DataTable
            Return Me.GetAcntAllGroup(0, 0)
        End Function

        ''' <summary>
        ''' 取得帳號所有群組 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetAcntAllGroup(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Set ArrayList GROUP_SET(群組集合) = new ArrayList
                'EntGroup = new EntGroup()
                'dt=EntGroup.GetGroupRightRange_取得群組權限範圍()
                '逐筆讀取dt {
                '    if SQL_VALUE(SQL值) is not null then {	
                '	    將SQL值的@LOGIN_ACNT取代為帳號並執行該SQL 
                '		如果查詢出來欄位資料=ACNT(帳號) then GROUP_SET(群組集合).Add(GROUP_CODE(群組代碼))
                '	}
                '	else 判斷 Session的資料欄位英文名稱職是否在 DATA_RANGE_LABEL(資料範圍符號) + DATA_RANGE_VALUE(資料範圍值) 的範圍內 then GROUP_SET(群組集合).Add(GROUP_CODE(群組代碼))	
                '}
                '
                'SELECT '2' AS GROUP_TYPE(群組類別),GROUP_CODE(群組代碼),GROUP_NAME(群組名稱) FROM AUTT010 WHERE GROUP_CODE(群組代碼) IN (GROUP_SET(群組集合)) 
                'UNION 
                'SELECT '1',A.GROUP_CODE(群組代碼),B.GROUP_NAME(群組名稱) FROM AUTT040 A LEFT JOIN AUTT010 
                'ON A.GROUP_CODE(群組代碼)=B.GROUP_CODE(群組代碼) WHERE ACNT=ACNT(帳號)
                Dim GROUP_CODE As String = Me.GROUP_CODE
                Dim PROG_CD As String = Me.PROG_CD
                Dim PROG_NM As String = Me.PROG_NM

                Dim result As DataTable = New DataTable

                result.Columns.Add("GROUP_CODE")
                result.Columns.Add("GROUP_NAME")
                result.Columns.Add("PERSON_TYPE")
                result.Columns.Add("ACNT")
                result.Columns.Add("CH_NAME")
                result.Columns.Add("PROG_CD")
                result.Columns.Add("PROG_NM")
                result.Columns.Add("FN_NM")

                '取得所有人員帳號
                Dim posDt As DataTable = Me.QueryBySql("SELECT M.ACNT,M.CH_NAME,R1.SYS_NAME AS PERSON_TYPE_NAME FROM POST020 M WITH(NOLOCK)  LEFT JOIN SYST010 R1 WITH(NOLOCK) ON M.PERSON_TYPE = R1.SYS_ID AND R1.SYS_KEY='COM_TYPE'  WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "M.") & " ORDER BY ACNT")

                '取得所有群組程式對應
                Dim sql As StringBuilder = New StringBuilder()
                sql.AppendLine("SELECT M.GROUP_CODE, M.GROUP_NAME, R1.PROG_CD, R2.PROG_NM ")
                sql.AppendLine("FROM AUTT010 M WITH(NOLOCK) ")
                sql.AppendLine("INNER JOIN AUTT030 R1 WITH(NOLOCK) ON M.GROUP_CODE	=	R1.GROUP_CODE ")
                sql.AppendLine("INNER JOIN AUTC030 R2 WITH(NOLOCK) ON R1.PROG_CD	=	R2.PROG_CD AND R2.USE_STATE='1' ")
                sql.AppendLine("WHERE 1=1 ")
                If Not String.IsNullOrEmpty(GROUP_CODE) Then
                    sql.AppendLine(" AND M.GROUP_CODE='" & GROUP_CODE & "' ")
                End If
                If Not String.IsNullOrEmpty(PROG_CD) Then
                    sql.AppendLine(" AND R1.PROG_CD LIKE '%" & PROG_CD & "%' ")
                End If
                If Not String.IsNullOrEmpty(PROG_NM) Then
                    sql.AppendLine(" AND R2.PROG_NM LIKE '%" & PROG_NM & "%' ")
                End If
                Dim progDt As DataTable = Me.QueryBySql(sql.ToString)

                '取得所有群組程式對應功能
                sql.Length = 0
                sql.AppendLine("SELECT M.GROUP_CODE, M.PROG_CD, M.FN_CD, R1.FN_NM, R1.IS_DEL  ")
                sql.AppendLine("FROM AUTT050 M WITH(NOLOCK)  ")
                sql.AppendLine("INNER JOIN AUTC040 R1 WITH(NOLOCK) ON M.PROG_CD	=	R1.PROG_CD AND M.FN_CD	=	R1.FN_CD  ")
                Dim fnDt As DataTable = Me.QueryBySql(sql.ToString)


                '取得群組權限範圍
                Dim EntGroupRightRange As EntGroupRightRange = New EntGroupRightRange(Me.DBManager, Me.LogUtil)
                Dim dt1 As DataTable = EntGroupRightRange.GetGroupRightRange()

                For Each posDr As DataRow In posDt.Rows
                    Dim groupCode As String = ""
                    For Each dr As DataRow In dt1.Rows
                        If Not String.IsNullOrEmpty(dr.Item("SQL_VALUE").ToString) AndAlso (dr.Item("SQL_VALUE").ToString.IndexOf("@LOGIN_ACNT") >= 0 Or dr.Item("SQL_VALUE").ToString.IndexOf("@ACNT") >= 0) Then
                            Dim tmpdt2 As DataTable = Me.QueryBySql(dr.Item("SQL_VALUE").ToString.Replace("@LOGIN_ACNT", "'" & posDr.Item("ACNT").ToString & "'").Replace("@ACNT", "'" & posDr.Item("ACNT").ToString & "'"))
                            If tmpdt2.Rows.Count > 0 Then
                                groupCode &= dr.Item("GROUP_CODE").ToString & ","
                            End If
                        ElseIf Not String.IsNullOrEmpty(dr.Item("DATA_RANGE_VALUE").ToString) Then
                            If dr.Item("DATA_RANGE_VALUE").ToString = posDr.Item("ACNT").ToString Then
                                groupCode &= dr.Item("GROUP_CODE").ToString & ","
                            End If
                        Else
                            Try
                                Dim tmpdt2 As DataTable = Me.QueryBySql(dr.Item("SQL_VALUE").ToString.Replace("@LOGIN_ACNT", "'" & posDr.Item("ACNT").ToString & "'").Replace("@ACNT", "'" & posDr.Item("ACNT").ToString & "'"))
                                If tmpdt2.Select(tmpdt2.Columns(0).Caption & "='" & posDr.Item("ACNT").ToString & "'").Length > 0 Then
                                    groupCode &= dr.Item("GROUP_CODE").ToString & ","
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    groupCode.TrimEnd(",")
                    sql.Length = 0
                    sql.AppendLine("SELECT  ")
                    sql.AppendLine("DISTINCT M.GROUP_CODE,R1.GROUP_NAME ")
                    sql.AppendLine("FROM  ")
                    sql.AppendLine("( ")
                    sql.AppendLine("	SELECT '2' AS GROUP_TYPE,GROUP_CODE FROM AUTT010 WITH(NOLOCK) WHERE GROUP_CODE IN ('" & groupCode.Replace(",", "','") & "') ")
                    sql.AppendLine("	UNION ")
                    sql.AppendLine("	SELECT '1' AS GROUP_TYPE,GROUP_CODE FROM AUTT020 WITH(NOLOCK) WHERE ACNT='" & posDr.Item("ACNT").ToString & "' ")
                    sql.AppendLine(") M ")
                    sql.AppendLine("LEFT JOIN AUTT010 R1 WITH(NOLOCK) ON M.GROUP_CODE=R1.GROUP_CODE ")
                    sql.AppendLine("WHERE 1=1 ORDER BY GROUP_CODE ")

                    Dim groupDt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                    For Each groupDr As DataRow In groupDt.Rows
                        Dim progDr As DataRow() = progDt.Select("GROUP_CODE='" & groupDr.Item("GROUP_CODE").ToString & "'", "GROUP_CODE,PROG_CD")
                        For n As Integer = 0 To progDr.Length - 1
                            Dim resultDr As DataRow = result.NewRow

                            Dim FN_NM As String = ""
                            Dim fnDr As DataRow() = fnDt.Select("GROUP_CODE='" & progDr(n).Item("GROUP_CODE").ToString & "' AND PROG_CD='" & progDr(n).Item("PROG_CD").ToString & "'", "FN_CD")
                            For r As Integer = 0 To fnDr.Length - 1
                                FN_NM &= fnDr(r).Item("FN_NM").ToString & "  "
                            Next

                            resultDr.Item("GROUP_CODE") = progDr(n).Item("GROUP_CODE").ToString
                            resultDr.Item("GROUP_NAME") = progDr(n).Item("GROUP_NAME").ToString
                            resultDr.Item("PERSON_TYPE") = posDr.Item("PERSON_TYPE_NAME").ToString
                            resultDr.Item("ACNT") = posDr.Item("ACNT").ToString
                            resultDr.Item("CH_NAME") = posDr.Item("CH_NAME").ToString
                            resultDr.Item("PROG_CD") = progDr(n).Item("PROG_CD").ToString
                            resultDr.Item("PROG_NM") = progDr(n).Item("PROG_NM").ToString
                            resultDr.Item("FN_NM") = FN_NM

                            result.Rows.Add(resultDr)
                        Next
                    Next
                Next

                Dim tmpDV As DataView = result.DefaultView
                tmpDV.Sort = "GROUP_CODE,PERSON_TYPE,ACNT,PROG_CD"
                result = tmpDV.ToTable()


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