'ProductName                 : TSBA 
'File Name					 : CtAPP2030 
'Description	             : CtAPP2030 諮詢委員會議開放案件
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
    Partial Public Class CtAPP2030
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP2030 = New Ent_APP2030(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE
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

#Region "CASE_NO 案件編號, REF APPL020.CASE_NO"
        '' <summary>
        '' CASE_NO 案件編號, REF APPL020.CASE_NO
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

#Region "Ent_APP2030"
        ' <summary>Ent_APP2030</ summary>
        Private Property Ent_APP2030() As Ent_APP2030
            Get
                Return Me.PropertyMap("Ent_APP2030")
            End Get
            Set(ByVal value As Ent_APP2030)
                Me.PropertyMap("Ent_APP2030") = value
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
                Me.Ent_APP2030.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.Ent_APP2030.CASE_NO = Me.CASE_NO      '案件編號, REF APPL020.CASE_NO
                Me.Ent_APP2030.SYS_SORT = Me.SYS_SORT '排序

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP2030.Insert()

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
                Me.Ent_APP2030.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.Ent_APP2030.CASE_NO = Me.CASE_NO      '案件編號, REF APPL020.CASE_NO
                Me.Ent_APP2030.SYS_SORT = Me.SYS_SORT '排序

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP2030.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP2030.Update()

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
                'If String.IsNullOrEmpty(Me.PKNO) Then
                '    faileArguments.Add("PKNO")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)
                Me.Ent_APP2030.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP2030.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP2030.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2030.Query()
                Else
                    result = Me.Ent_APP2030.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2030.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryCaseInfo"
        '' <summary>
        '' 查詢案件相關資料
        '' </summary>
        Public Function DoQueryCaseInfo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2030.QueryCaseInfo()
                Else
                    result = Me.Ent_APP2030.QueryCaseInfo(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2030.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function DoQueryCaseInfo1170() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable

                result = Me.Ent_APP2030.QueryCaseInfo1170()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function DoQueryCaseInfo1010() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable

                result = Me.Ent_APP2030.QueryCaseInfo1010()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryMaxSYS_SORT 查詢 MAX SYS_SORT"
        '' <summary>
        '' 查詢 MAX SYS_SORT
        '' </summary>
        Public Function DoQueryMaxSYS_SORT() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                '=== 處理取得回傳資料===
                Dim result As DataTable

                result = Me.Ent_APP2030.QueryMaxSYS_SORT(Me.GROUP_CODE)

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryCaseUseStatus "
        '' <summary>
        '' 
        '' </summary>
        Public Function QueryCaseUseStatus() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2030.QueryCaseUseStatus()
                Else
                    result = Me.Ent_APP2030.QueryCaseUseStatus(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2030.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region " Query for 3.1 "
        '' <summary>
        '' 查詢案件相關資料
        '' </summary>
        Public Function DoQueryCaseInfo_3_1() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, REF APPL020.CASE_NO
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)      '排序

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP2030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2030.QueryCaseInfo_3_1()
                Else
                    result = Me.Ent_APP2030.QueryCaseInfo_3_1(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2030.TotalRowCount
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

