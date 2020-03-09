'ProductName                 : TSBA 
'File Name					 : CtAPP1080 
'Description	             : CtAPP1080 申設_預估財務狀況表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/20  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1080
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1080 = New ENT_APP1080(Me.DBManager, Me.LogUtil)
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

#Region "FUTURE_YEAR 未來第幾年"
        '' <summary>
        '' FUTURE_YEAR 未來第幾年
        '' </summary>
        Public Property FUTURE_YEAR() As String
            Get
                Return Me.PropertyMap("FUTURE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FUTURE_YEAR") = value
            End Set
        End Property
#End Region

#Region "FINANCE_CLASS 財務項目種類"
        '' <summary>
        '' FINANCE_CLASS 財務項目種類
        '' </summary>
        Public Property FINANCE_CLASS() As String
            Get
                Return Me.PropertyMap("FINANCE_CLASS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FINANCE_CLASS") = value
            End Set
        End Property
#End Region

#Region "FINANCE_TYPE 財務項目類別"
        '' <summary>
        '' FINANCE_TYPE 財務項目類別
        '' </summary>
        Public Property FINANCE_TYPE() As String
            Get
                Return Me.PropertyMap("FINANCE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FINANCE_TYPE") = value
            End Set
        End Property
#End Region

#Region "FINANCE_DETAILS 財務項目細項"
        '' <summary>
        '' FINANCE_DETAILS 財務項目細項
        '' </summary>
        Public Property FINANCE_DETAILS() As String
            Get
                Return Me.PropertyMap("FINANCE_DETAILS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FINANCE_DETAILS") = value
            End Set
        End Property
#End Region

#Region "ESTIMATED_AMOUNT 預估金額"
        '' <summary>
        '' ESTIMATED_AMOUNT 預估金額
        '' </summary>
        Public Property ESTIMATED_AMOUNT() As String
            Get
                Return Me.PropertyMap("ESTIMATED_AMOUNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ESTIMATED_AMOUNT") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1080"
        ' <summary>Ent_APP1080</ summary>
        Private Property Ent_APP1080() As ENT_APP1080
            Get
                Return Me.PropertyMap("Ent_APP1080")
            End Get
            Set(ByVal value As ENT_APP1080)
                Me.PropertyMap("Ent_APP1080") = value
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
                Me.Ent_APP1080.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1080.FUTURE_YEAR = Me.FUTURE_YEAR      '未來第幾年
                Me.Ent_APP1080.FINANCE_CLASS = Me.FINANCE_CLASS      '財務項目種類
                Me.Ent_APP1080.FINANCE_TYPE = Me.FINANCE_TYPE        '財務項目類別
                Me.Ent_APP1080.FINANCE_DETAILS = Me.FINANCE_DETAILS      '財務項目細項
                Me.Ent_APP1080.ESTIMATED_AMOUNT = Me.ESTIMATED_AMOUNT        '預估金額


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1080.Insert()

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
                Me.Ent_APP1080.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1080.FUTURE_YEAR = Me.FUTURE_YEAR      '未來第幾年
                Me.Ent_APP1080.FINANCE_CLASS = Me.FINANCE_CLASS      '財務項目種類
                Me.Ent_APP1080.FINANCE_TYPE = Me.FINANCE_TYPE        '財務項目類別
                Me.Ent_APP1080.FINANCE_DETAILS = Me.FINANCE_DETAILS      '財務項目細項
                Me.Ent_APP1080.ESTIMATED_AMOUNT = Me.ESTIMATED_AMOUNT        '預估金額


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1080.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1080.Update()

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
                If String.IsNullOrEmpty(Me.PKNO) And String.IsNullOrEmpty(Me.CASE_NO) Then
                    If String.IsNullOrEmpty(Me.PKNO) Then
                        faileArguments.Add("PKNO")
                    End If
                    If String.IsNullOrEmpty(Me.CASE_NO) Then
                        faileArguments.Add("CASE_NO")
                    End If
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "FUTURE_YEAR", Me.FUTURE_YEAR)
                Me.Ent_APP1080.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1080.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1080.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "FUTURE_YEAR", Me.FUTURE_YEAR)      '未來第幾年
                Me.ProcessQueryCondition(condition, "=", "FINANCE_CLASS", Me.FINANCE_CLASS)      '財務項目種類
                Me.ProcessQueryCondition(condition, "=", "FINANCE_TYPE", Me.FINANCE_TYPE)        '財務項目類別
                Me.ProcessQueryCondition(condition, "=", "FINANCE_DETAILS", Me.FINANCE_DETAILS)      '財務項目細項
                Me.ProcessQueryCondition(condition, "=", "ESTIMATED_AMOUNT", Me.ESTIMATED_AMOUNT)        '預估金額

                Me.Ent_APP1080.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1080.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1080.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1080.Query()
                Else
                    result = Me.Ent_APP1080.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1080.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "查詢群組"
        '' <summary>
        '' 查詢群組
        '' </summary>
        Public Function DoQueryByGroup() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                'Me.ProcessQueryCondition(condition, "=", "FUTURE_YEAR", Me.FUTURE_YEAR)      '未來第幾年
                Me.ProcessQueryCondition(condition, "=", "FINANCE_CLASS", Me.FINANCE_CLASS)      '財務項目種類
                Me.ProcessQueryCondition(condition, "=", "FINANCE_TYPE", Me.FINANCE_TYPE)        '財務項目類別
                Me.ProcessQueryCondition(condition, "=", "FINANCE_DETAILS", Me.FINANCE_DETAILS)      '財務項目細項
                Me.ProcessQueryCondition(condition, "=", "ESTIMATED_AMOUNT", Me.ESTIMATED_AMOUNT)        '預估金額

                Me.Ent_APP1080.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1080.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1080.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1080.QueryGroupBy()
                Else
                    'result = Me.Ent_APP1080.QueryGroupBy(Me.PageNo, Me.PageSize)
                    'Me.TotalRowCount = Me.Ent_APP1080.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryStatic 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQueryStatic() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "FUTURE_YEAR", Me.FUTURE_YEAR)      '未來第幾年             
                Me.Ent_APP1080.SqlRetrictions = condition.ToString()
 

                '=== 處理取得回傳資料===
                Dim result As DataTable = Me.Ent_APP1080.DoQueryStatic()

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

