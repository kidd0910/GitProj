'ProductName                 : TSBA 
'File Name					 : CtAPP2010 
'Description	             : CtAPP2010 諮詢委員會議資料
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/21  San      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP2010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP2010 = New Ent_APP2010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼
        '' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.PropertyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "GROUP_NAME 諮詢委員會議名稱"
        '' <summary>
        '' GROUP_NAME 諮詢委員會議名稱
        '' </summary>
        Public Property GROUP_NAME() As String
            Get
                Return Me.PropertyMap("GROUP_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_NAME") = value
            End Set
        End Property
#End Region

#Region "GROUP_LEVEL 暫不用"
        '' <summary>
        '' GROUP_LEVEL 暫不用
        '' </summary>
        Public Property GROUP_LEVEL() As String
            Get
                Return Me.PropertyMap("GROUP_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_LEVEL") = value
            End Set
        End Property
#End Region

#Region "EDU_FG 暫不用"
        '' <summary>
        '' EDU_FG 暫不用
        '' </summary>
        Public Property EDU_FG() As String
            Get
                Return Me.PropertyMap("EDU_FG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDU_FG") = value
            End Set
        End Property
#End Region

#Region "RESS_SYS_CD 暫不用"
        '' <summary>
        '' RESS_SYS_CD 暫不用
        '' </summary>
        Public Property RESS_SYS_CD() As String
            Get
                Return Me.PropertyMap("RESS_SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_SYS_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_OPERATE_CD 暫不用"
        '' <summary>
        '' RESS_OPERATE_CD 暫不用
        '' </summary>
        Public Property RESS_OPERATE_CD() As String
            Get
                Return Me.PropertyMap("RESS_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_PROG_CD 暫不用"
        '' <summary>
        '' RESS_PROG_CD 暫不用
        '' </summary>
        Public Property RESS_PROG_CD() As String
            Get
                Return Me.PropertyMap("RESS_PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESS_PROG_CD") = value
            End Set
        End Property
#End Region

#Region "GROUP_EXPL 群組說明"
        '' <summary>
        '' GROUP_EXPL 群組說明
        '' </summary>
        Public Property GROUP_EXPL() As String
            Get
                Return Me.PropertyMap("GROUP_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_EXPL") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態, 1：啟用，0：停用"
        '' <summary>
        '' USE_STATE 使用狀態, 1：啟用，0：停用
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 隸屬單位, REF. APPL010.PKNO"
        '' <summary>
        '' DEP_CODE 隸屬單位, REF. APPL010.PKNO
        '' </summary>
        Public Property DEP_CODE() As String
            Get
                Return Me.PropertyMap("DEP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEP_CODE") = value
            End Set
        End Property
#End Region

#Region "排序"
        '' <summary>
        '' SYS_SORT 排序
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.PropertyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "MEETING_TYPE 會議類型"
        '' <summary>
        '' MEETING_TYPE 會議類型
        '' </summary>
        Public Property MEETING_TYPE() As String
            Get
                Return Me.PropertyMap("MEETING_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MEETING_TYPE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP2010"
        ' <summary>Ent_APP2010</ summary>
        Private Property Ent_APP2010() As Ent_APP2010
            Get
                Return Me.PropertyMap("Ent_APP2010")
            End Get
            Set(ByVal value As Ent_APP2010)
                Me.PropertyMap("Ent_APP2010") = value
            End Set
        End Property
#End Region


#End Region

#Region "方法"
#Region "DoAdd 處理新增資料動作"
        '' <summary>
        '' 處理新增資料動作
        '' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 設定屬性參數 ===
                Me.Ent_APP2010.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼
                Me.Ent_APP2010.GROUP_NAME = Me.GROUP_NAME       '諮詢委員會議名稱
                Me.Ent_APP2010.GROUP_LEVEL = Me.GROUP_LEVEL      '暫不用
                Me.Ent_APP2010.EDU_FG = Me.EDU_FG       '暫不用
                Me.Ent_APP2010.RESS_SYS_CD = Me.RESS_SYS_CD      '暫不用
                Me.Ent_APP2010.RESS_OPERATE_CD = Me.RESS_OPERATE_CD      '暫不用
                Me.Ent_APP2010.RESS_PROG_CD = Me.RESS_PROG_CD         '暫不用
                Me.Ent_APP2010.GROUP_EXPL = Me.GROUP_EXPL       '群組說明
                Me.Ent_APP2010.USE_STATE = Me.USE_STATE        '使用狀態, 1：啟用，0：停用
                Me.Ent_APP2010.DEP_CODE = Me.DEP_CODE         '隸屬單位, REF. APPL010.PKNO
                Me.Ent_APP2010.SYS_SORT = Me.SYS_SORT         '排序
                Me.Ent_APP2010.MEETING_TYPE = Me.MEETING_TYPE


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP2010.Insert()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoModify 處理修改資料動作"
        '' <summary>
        '' 處理修改資料動作
        '' </summary>
        Public Function DoModify() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Me.Ent_APP2010.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼
                Me.Ent_APP2010.GROUP_NAME = Me.GROUP_NAME       '諮詢委員會議名稱
                Me.Ent_APP2010.GROUP_LEVEL = Me.GROUP_LEVEL      '暫不用
                Me.Ent_APP2010.EDU_FG = Me.EDU_FG       '暫不用
                Me.Ent_APP2010.RESS_SYS_CD = Me.RESS_SYS_CD      '暫不用
                Me.Ent_APP2010.RESS_OPERATE_CD = Me.RESS_OPERATE_CD      '暫不用
                Me.Ent_APP2010.RESS_PROG_CD = Me.RESS_PROG_CD         '暫不用
                Me.Ent_APP2010.GROUP_EXPL = Me.GROUP_EXPL       '群組說明
                Me.Ent_APP2010.USE_STATE = Me.USE_STATE        '使用狀態, 1：啟用，0：停用
                Me.Ent_APP2010.DEP_CODE = Me.DEP_CODE         '隸屬單位, REF. APPL010.PKNO
                Me.Ent_APP2010.SYS_SORT = Me.SYS_SORT         '排序
                Me.Ent_APP2010.MEETING_TYPE = Me.MEETING_TYPE


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP2010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP2010.Update()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoDelete 處理刪除資料動作"
        '' <summary>
        '' 處理刪除資料動作
        '' </summary>
        Public Sub DoDelete()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.Ent_APP2010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP2010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP2010.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "GROUP_NAME", Me.GROUP_NAME)       '諮詢委員會議名稱
                Me.ProcessQueryCondition(condition, "=", "GROUP_LEVEL", Me.GROUP_LEVEL)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)        '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_SYS_CD", Me.RESS_SYS_CD)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_OPERATE_CD", Me.RESS_OPERATE_CD)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_PROG_CD", Me.RESS_PROG_CD)        '暫不用
                Me.ProcessQueryCondition(condition, "=", "GROUP_EXPL", Me.GROUP_EXPL)        '群組說明
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '使用狀態, 1：啟用，0：停用
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)        '隸屬單位, REF. APPL010.PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)        '排序
                Me.ProcessQueryCondition(condition, "=", "MEETING_TYPE", Me.MEETING_TYPE)

                Me.Ent_APP2010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2010.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2010.Query()
                Else
                    result = Me.Ent_APP2010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQueryMeeting() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "GROUP_NAME", Me.GROUP_NAME)       '諮詢委員會議名稱
                Me.ProcessQueryCondition(condition, "=", "GROUP_LEVEL", Me.GROUP_LEVEL)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)        '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_SYS_CD", Me.RESS_SYS_CD)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_OPERATE_CD", Me.RESS_OPERATE_CD)      '暫不用
                Me.ProcessQueryCondition(condition, "=", "RESS_PROG_CD", Me.RESS_PROG_CD)        '暫不用
                Me.ProcessQueryCondition(condition, "=", "GROUP_EXPL", Me.GROUP_EXPL)        '群組說明
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '使用狀態, 1：啟用，0：停用
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)        '隸屬單位, REF. APPL010.PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)        '排序
                Me.ProcessQueryCondition(condition, "=", "MEETING_TYPE", Me.MEETING_TYPE)

                Me.Ent_APP2010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2010.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2010.QueryMeeting()
                Else
                    result = Me.Ent_APP2010.QueryMeeting(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
    End Class
End Namespace

