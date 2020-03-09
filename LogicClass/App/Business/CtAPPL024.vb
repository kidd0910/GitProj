Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL024
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL024 = New ENT_APPL024(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "TOPIC_SEQ "
        '' <summary>
        '' TOPIC_SEQ 
        '' </summary>
        Public Property TOPIC_SEQ() As String
            Get
                Return Me.PropertyMap("TOPIC_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOPIC_SEQ") = value
            End Set
        End Property
#End Region

#Region "TOPIC_ANSWER "
        '' <summary>
        '' TOPIC_ANSWER 
        '' </summary>
        Public Property TOPIC_ANSWER() As String
            Get
                Return Me.PropertyMap("TOPIC_ANSWER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOPIC_ANSWER") = value
            End Set
        End Property
#End Region

#Region "MARK "
        '' <summary>
        '' MARK 
        '' </summary>
        Public Property MARK() As String
            Get
                Return Me.PropertyMap("MARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MARK") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE "
        '' <summary>
        '' CASE_CODE 
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

#Region "ACNT "
        '' <summary>
        '' ACNT 
        '' </summary>
        Public Property ACNT() As String
            Get
                Return Me.PropertyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TYPE "
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

#Region "REVIEW_RESULT "
        '' <summary>
        '' REVIEW_RESULT 
        '' </summary>
        Public Property REVIEW_RESULT() As String
            Get
                Return Me.PropertyMap("REVIEW_RESULT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REVIEW_RESULT") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT "
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

#Region "Ent_APPL024"
        ' <summary>Ent_APPL024</ summary>
        Private Property Ent_APPL024() As ENT_APPL024
            Get
                Return Me.PropertyMap("Ent_APPL024")
            End Get
            Set(ByVal value As ENT_APPL024)
                Me.PropertyMap("Ent_APPL024") = value
            End Set
        End Property
#End Region

#Region "QUERY_COND 查詢條件"
        ''' <summary>
        ''' QUERY_COND 查詢條件
        ''' </summary>
        Public Property QUERY_COND() As String
            Get
                Return Me.PropertyMap("QUERY_COND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QUERY_COND") = value
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
                Me.Ent_APPL024.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL024.TOPIC_SEQ = Me.TOPIC_SEQ
                Me.Ent_APPL024.TOPIC_ANSWER = Me.TOPIC_ANSWER
                Me.Ent_APPL024.MARK = Me.MARK
                Me.Ent_APPL024.ACNT = Me.ACNT
                Me.Ent_APPL024.SUBJECT_TYPE = Me.SUBJECT_TYPE
                Me.Ent_APPL024.SYS_SORT = Me.SYS_SORT
                Me.Ent_APPL024.REVIEW_RESULT = Me.REVIEW_RESULT

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL024.Insert()

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
                'Me.Ent_APPL024.CASE_NO = Me.CASE_NO      '案件編號
                'Me.Ent_APPL024.TOPIC_SEQ = Me.TOPIC_SEQ      '
                Me.Ent_APPL024.TOPIC_ANSWER = Me.TOPIC_ANSWER        '
                Me.Ent_APPL024.MARK = Me.MARK        '
                Me.Ent_APPL024.ACNT = Me.ACNT
                Me.Ent_APPL024.SUBJECT_TYPE = Me.SUBJECT_TYPE
                Me.Ent_APPL024.SYS_SORT = Me.SYS_SORT
                Me.Ent_APPL024.REVIEW_RESULT = Me.REVIEW_RESULT

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.ProcessQueryCondition(condition, "=", "REVIEW_RESULT", Me.REVIEW_RESULT)

                Me.Ent_APPL024.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL024.Update()

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
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.Ent_APPL024.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL024.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL024.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)      '
                Me.ProcessQueryCondition(condition, "=", "TOPIC_ANSWER", Me.TOPIC_ANSWER)        '
                Me.ProcessQueryCondition(condition, "=", "MARK", Me.MARK)        '
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_TYPE", Me.SUBJECT_TYPE)
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)
                Me.ProcessQueryCondition(condition, "=", "REVIEW_RESULT", Me.REVIEW_RESULT)


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL024.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL024.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL024.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL024.Query()
                Else
                    result = Me.Ent_APPL024.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL024.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery Report"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQueryReport() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.Ent_APPL024.CASE_NO = Me.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_ANSWER", Me.TOPIC_ANSWER)
                Me.ProcessQueryCondition(condition, "=", "MARK", Me.MARK)
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                Me.Ent_APPL024.ACNT = Me.ACNT
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_TYPE", Me.SUBJECT_TYPE)
                Me.Ent_APPL024.SUBJECT_TYPE = Me.SUBJECT_TYPE
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT) '
                Me.ProcessQueryCondition(condition, "=", "REVIEW_RESULT", Me.REVIEW_RESULT)


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL024.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL024.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL024.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL024.QueryReport()

                'If Me.PageNo = 0 Then
                '    result = Me.Ent_APPL024.QueryReport()
                'Else
                '    'result = Me.Ent_APPL024.QueryReport(Me.PageNo, Me.PageSize)
                '    'Me.TotalRowCount = Me.Ent_APPL024.TotalRowCount
                'End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery QuerySumMARK"
        '' <summary>
        '' 進行查詢動作 總分
        '' </summary>
        Public Function DoQuerySumMARK() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.Ent_APPL024.CASE_NO = Me.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_ANSWER", Me.TOPIC_ANSWER)
                Me.ProcessQueryCondition(condition, "=", "MARK", Me.MARK)
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_TYPE", Me.SUBJECT_TYPE)
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT) '
                Me.ProcessQueryCondition(condition, "=", "REVIEW_RESULT", Me.REVIEW_RESULT)


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL024.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL024.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL024.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL024.QuerySumMARK()

                'If Me.PageNo = 0 Then
                '    result = Me.Ent_APPL024.QueryReport()
                'Else
                '    'result = Me.Ent_APPL024.QueryReport(Me.PageNo, Me.PageSize)
                '    'Me.TotalRowCount = Me.Ent_APPL024.TotalRowCount
                'End If

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


