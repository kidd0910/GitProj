Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL023
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL023 = New ENT_APPL023(Me.DBManager, Me.LogUtil)
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

#Region "Ent_APPL023"
        ' <summary>Ent_APPL023</ summary>
        Private Property Ent_APPL023() As ENT_APPL023
            Get
                Return Me.PropertyMap("Ent_APPL023")
            End Get
            Set(ByVal value As ENT_APPL023)
                Me.PropertyMap("Ent_APPL023") = value
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
                Me.Ent_APPL023.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL023.TOPIC_SEQ = Me.TOPIC_SEQ      '
                Me.Ent_APPL023.TOPIC_ANSWER = Me.TOPIC_ANSWER        '
                Me.Ent_APPL023.MARK = Me.MARK        '

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL023.Insert()

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
                'Me.Ent_APPL023.CASE_NO = Me.CASE_NO      '案件編號
                'Me.Ent_APPL023.TOPIC_SEQ = Me.TOPIC_SEQ      '
                Me.Ent_APPL023.TOPIC_ANSWER = Me.TOPIC_ANSWER        '
                Me.Ent_APPL023.MARK = Me.MARK        '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.Ent_APPL023.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL023.Update()

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
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.Ent_APPL023.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL023.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL023.Delete()
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


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL023.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL023.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL023.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL023.Query()
                Else
                    result = Me.Ent_APPL023.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL023.TotalRowCount
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
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)      '
                Me.ProcessQueryCondition(condition, "=", "TOPIC_ANSWER", Me.TOPIC_ANSWER)        '
                Me.ProcessQueryCondition(condition, "=", "MARK", Me.MARK)        '


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL023.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL023.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL023.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL023.QueryReport()

                'If Me.PageNo = 0 Then
                '    result = Me.Ent_APPL023.QueryReport()
                'Else
                '    'result = Me.Ent_APPL023.QueryReport(Me.PageNo, Me.PageSize)
                '    'Me.TotalRowCount = Me.Ent_APPL023.TotalRowCount
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


