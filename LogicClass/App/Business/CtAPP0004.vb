Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP0004
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP0004 = New ENT_APP0004(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"


#Region "CASE_CODE"
        '' <summary>
        '' CASE_CODE 案號前四碼
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.PropertyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "TAB_FILE"
        '' <summary>
        '' TAB_FILE 程式代碼
        '' </summary>
        Public Property TAB_FILE() As String
            Get
                Return Me.PropertyMap("TAB_FILE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAB_FILE") = value
            End Set
        End Property
#End Region


#Region "QNO"
        '' <summary>
        '' QNO 題目代號
        '' </summary>
        Public Property QNO() As String
            Get
                Return Me.PropertyMap("QNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO") = value
            End Set
        End Property
#End Region

#Region "QNO_DESC"
        '' <summary>
        '' QNO_DESC 題目內容
        '' </summary>
        Public Property QNO_DESC() As String
            Get
                Return Me.PropertyMap("QNO_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO_DESC") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
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

#Region "SUBJECT_TYPE"
        '' <summary>
        '' SUBJECT_TYPE
        '' </summary>
        Public Property SUBJECT_TYPE() As String
            Get
                Return Me.PropertyMap("SUBJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "ALLOCATE_MARK"
        '' <summary>
        '' SUBJECT_TYPE
        '' </summary>
        Public Property ALLOCATE_MARK() As String
            Get
                Return Me.PropertyMap("ALLOCATE_MARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ALLOCATE_MARK") = value
            End Set
        End Property
#End Region

#Region "INPUT_FLAG"
        '' <summary>
        '' INPUT_FLAG
        '' </summary>
        Public Property INPUT_FLAG() As String
            Get
                Return Me.PropertyMap("INPUT_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INPUT_FLAG") = value
            End Set
        End Property
#End Region

#Region "REMARK"
        '' <summary>
        '' REMARK
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.PropertyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT"
        '' <summary>
        '' SYS_SORT
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

#Region "Ent_APP0004"
        ' <summary>Ent_APP0004</ summary>
        Private Property Ent_APP0004() As ENT_APP0004
            Get
                Return Me.PropertyMap("Ent_APP0004")
            End Get
            Set(ByVal value As ENT_APP0004)
                Me.PropertyMap("Ent_APP0004") = value
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
                Me.Ent_APP0004.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0004.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0004.QNO = Me.QNO              '題目代號
                Me.Ent_APP0004.QNO_DESC = Me.QNO_DESC    '題目內容
                Me.Ent_APP0004.USE_STATE = Me.USE_STATE
                Me.Ent_APP0004.SUBJECT_TYPE = Me.SUBJECT_TYPE
                Me.Ent_APP0004.ALLOCATE_MARK = Me.ALLOCATE_MARK
                Me.Ent_APP0004.INPUT_FLAG = Me.INPUT_FLAG
                Me.Ent_APP0004.REMARK = Me.REMARK
                Me.Ent_APP0004.SYS_SORT = Me.SYS_SORT

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP0004.Insert()

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
                Me.Ent_APP0004.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0004.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0004.QNO = Me.QNO              '題目代號
                Me.Ent_APP0004.QNO_DESC = Me.QNO_DESC    '題目內容
                Me.Ent_APP0004.USE_STATE = Me.USE_STATE
                Me.Ent_APP0004.SUBJECT_TYPE = Me.SUBJECT_TYPE
                Me.Ent_APP0004.ALLOCATE_MARK = Me.ALLOCATE_MARK
                Me.Ent_APP0004.INPUT_FLAG = Me.INPUT_FLAG
                Me.Ent_APP0004.REMARK = Me.REMARK
                Me.Ent_APP0004.SYS_SORT = Me.SYS_SORT


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP0004.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP0004.Update()

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
                Me.Ent_APP0004.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP0004.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP0004.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_CODE", Me.CASE_CODE)  '案號前四碼
                Me.ProcessQueryCondition(condition, "=", "TAB_FILE", Me.TAB_FILE)    '程式代碼
                Me.ProcessQueryCondition(condition, "=", "QNO", Me.QNO)              '題目代號
                Me.ProcessQueryCondition(condition, "=", "QNO_DESC", Me.QNO_DESC)    '題目內容
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_TYPE", Me.SUBJECT_TYPE)
                Me.ProcessQueryCondition(condition, "=", "ALLOCATE_MARK", Me.ALLOCATE_MARK)
                Me.ProcessQueryCondition(condition, "=", "INPUT_FLAG", Me.INPUT_FLAG)
                Me.ProcessQueryCondition(condition, "=", "REMARK", Me.REMARK)
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)

                Me.Ent_APP0004.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP0004.OrderBys = "PKNO"
                Else
                    Me.Ent_APP0004.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP0004.Query()
                Else
                    result = Me.Ent_APP0004.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP0004.TotalRowCount
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




