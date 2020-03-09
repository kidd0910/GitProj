'ProductName                 : TSBA 
'File Name					 : CtAPP1090 
'Description	             : CtAPP1090 預估綜合損益表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/22  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1090
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1090 = New ENT_APP1090(Me.DBManager, Me.LogUtil)
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

#Region "OPERATING_INCOME 營業收入"
        '' <summary>
        '' OPERATING_INCOME 營業收入
        '' </summary>
        Public Property OPERATING_INCOME() As String
            Get
                Return Me.PropertyMap("OPERATING_INCOME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_INCOME") = value
            End Set
        End Property
#End Region

#Region "OPERATING_COST 營業成本"
        '' <summary>
        '' OPERATING_COST 營業成本
        '' </summary>
        Public Property OPERATING_COST() As String
            Get
                Return Me.PropertyMap("OPERATING_COST")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_COST") = value
            End Set
        End Property
#End Region

#Region "OPERATING_EXP 營業費用"
        '' <summary>
        '' OPERATING_EXP 營業費用
        '' </summary>
        Public Property OPERATING_EXP() As String
            Get
                Return Me.PropertyMap("OPERATING_EXP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_EXP") = value
            End Set
        End Property
#End Region

#Region "OPERATING_COME_EXP 營業外收益及費損"
        '' <summary>
        '' OPERATING_COME_EXP 營業外收益及費損
        '' </summary>
        Public Property OPERATING_COME_EXP() As String
            Get
                Return Me.PropertyMap("OPERATING_COME_EXP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_COME_EXP") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1090"
        ' <summary>Ent_APP1090</ summary>
        Private Property Ent_APP1090() As ENT_APP1090
            Get
                Return Me.PropertyMap("Ent_APP1090")
            End Get
            Set(ByVal value As ENT_APP1090)
                Me.PropertyMap("Ent_APP1090") = value
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
                Me.Ent_APP1090.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1090.FUTURE_YEAR = Me.FUTURE_YEAR      '未來第幾年
                Me.Ent_APP1090.OPERATING_INCOME = Me.OPERATING_INCOME        '營業收入
                Me.Ent_APP1090.OPERATING_COST = Me.OPERATING_COST        '營業成本
                Me.Ent_APP1090.OPERATING_EXP = Me.OPERATING_EXP      '營業費用
                Me.Ent_APP1090.OPERATING_COME_EXP = Me.OPERATING_COME_EXP        '營業外收益及費損


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1090.Insert()

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
                Me.Ent_APP1090.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1090.FUTURE_YEAR = Me.FUTURE_YEAR      '未來第幾年
                Me.Ent_APP1090.OPERATING_INCOME = Me.OPERATING_INCOME        '營業收入
                Me.Ent_APP1090.OPERATING_COST = Me.OPERATING_COST        '營業成本
                Me.Ent_APP1090.OPERATING_EXP = Me.OPERATING_EXP      '營業費用
                Me.Ent_APP1090.OPERATING_COME_EXP = Me.OPERATING_COME_EXP        '營業外收益及費損


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1090.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1090.Update()

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
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP1090.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1090.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1090.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "OPERATING_INCOME", Me.OPERATING_INCOME)        '營業收入
                Me.ProcessQueryCondition(condition, "=", "OPERATING_COST", Me.OPERATING_COST)        '營業成本
                Me.ProcessQueryCondition(condition, "=", "OPERATING_EXP", Me.OPERATING_EXP)      '營業費用
                Me.ProcessQueryCondition(condition, "=", "OPERATING_COME_EXP", Me.OPERATING_COME_EXP)        '營業外收益及費損

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP1090.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1090.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1090.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1090.Query()
                Else
                    result = Me.Ent_APP1090.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1090.TotalRowCount
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

