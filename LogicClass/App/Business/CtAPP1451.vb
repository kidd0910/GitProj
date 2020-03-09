'ProductName                 : TSBA 
'File Name					 : CtAPP1451 
'Description	             : CtAPP1451 APP1451 廣播/電視事業年度損益表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/19  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1451
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1451 = New ENT_APP1451(Me.DBManager, Me.LogUtil)
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

#Region "YEAR 年度"
        '' <summary>
        '' YEAR 年度
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.PropertyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "DATA_TYPE 類型, 0：目前，1：未來"
        '' <summary>
        '' DATA_TYPE 類型, 0：目前，1：未來
        '' </summary>
        Public Property DATA_TYPE() As String
            Get
                Return Me.PropertyMap("DATA_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_TYPE") = value
            End Set
        End Property
#End Region

#Region "OPERATING_INCOME 營業收入/收入"
        '' <summary>
        '' OPERATING_INCOME 營業收入/收入
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

#Region "OPERATING_COST 營業成本/成本"
        '' <summary>
        '' OPERATING_COST 營業成本/成本
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

#Region "OPERATING_EXP 營業費用/費用"
        '' <summary>
        '' OPERATING_EXP 營業費用/費用
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

#Region "NON_OPERATING_INCOME 營業外收益及費損"
        '' <summary>
        '' NON_OPERATING_INCOME 營業外收益及費損
        '' </summary>
        Public Property NON_OPERATING_INCOME() As String
            Get
                Return Me.PropertyMap("NON_OPERATING_INCOME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NON_OPERATING_INCOME") = value
            End Set
        End Property
#End Region

#Region "OPERATING_MARGIN 營業毛利"
        '' <summary>
        '' OPERATING_MARGIN 營業毛利
        '' </summary>
        Public Property OPERATING_MARGIN() As String
            Get
                Return Me.PropertyMap("OPERATING_MARGIN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_MARGIN") = value
            End Set
        End Property
#End Region

#Region "OPERATING_PROFIT 營業淨利"
        '' <summary>
        '' OPERATING_PROFIT 營業淨利
        '' </summary>
        Public Property OPERATING_PROFIT() As String
            Get
                Return Me.PropertyMap("OPERATING_PROFIT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATING_PROFIT") = value
            End Set
        End Property
#End Region

#Region "NON_OPERATING_PAY "
        '' <summary>
        '' NON_OPERATING_PAY 
        '' </summary>
        Public Property NON_OPERATING_PAY() As String
            Get
                Return Me.PropertyMap("NON_OPERATING_PAY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NON_OPERATING_PAY") = value
            End Set
        End Property
#End Region

#Region "BEFORE_TAX_INCOME 稅前淨利"
        '' <summary>
        '' BEFORE_TAX_INCOME 稅前淨利
        '' </summary>
        Public Property BEFORE_TAX_INCOME() As String
            Get
                Return Me.PropertyMap("BEFORE_TAX_INCOME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BEFORE_TAX_INCOME") = value
            End Set
        End Property
#End Region

#Region "INCOME_TAX_EXP 所得稅費用"
        '' <summary>
        '' INCOME_TAX_EXP 所得稅費用
        '' </summary>
        Public Property INCOME_TAX_EXP() As String
            Get
                Return Me.PropertyMap("INCOME_TAX_EXP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INCOME_TAX_EXP") = value
            End Set
        End Property
#End Region

#Region "AFTER_TAX_INCOME 稅後淨利"
        '' <summary>
        '' AFTER_TAX_INCOME 稅後淨利
        '' </summary>
        Public Property AFTER_TAX_INCOME() As String
            Get
                Return Me.PropertyMap("AFTER_TAX_INCOME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("AFTER_TAX_INCOME") = value
            End Set
        End Property
#End Region

#Region "END_SURPLUS 期末累積餘絀"
        '' <summary>
        '' END_SURPLUS 期末累積餘絀
        '' </summary>
        Public Property END_SURPLUS() As String
            Get
                Return Me.PropertyMap("END_SURPLUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("END_SURPLUS") = value
            End Set
        End Property
#End Region

#Region "IN_BUDGET 歲入-預算數"
        '' <summary>
        '' IN_BUDGET 歲入-預算數
        '' </summary>
        Public Property IN_BUDGET() As String
            Get
                Return Me.PropertyMap("IN_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_BUDGET") = value
            End Set
        End Property
#End Region

#Region "IN_BALANCED_BUDGET 歲入-決算數"
        '' <summary>
        '' IN_BALANCED_BUDGET 歲入-決算數
        '' </summary>
        Public Property IN_BALANCED_BUDGET() As String
            Get
                Return Me.PropertyMap("IN_BALANCED_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_BALANCED_BUDGET") = value
            End Set
        End Property
#End Region

#Region "IN_EX_RATE 歲入-執行率"
        '' <summary>
        '' IN_EX_RATE 歲入-執行率
        '' </summary>
        Public Property IN_EX_RATE() As String
            Get
                Return Me.PropertyMap("IN_EX_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_EX_RATE") = value
            End Set
        End Property
#End Region

#Region "OUT_BUDGET 歲出-預算數"
        '' <summary>
        '' OUT_BUDGET 歲出-預算數
        '' </summary>
        Public Property OUT_BUDGET() As String
            Get
                Return Me.PropertyMap("OUT_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUT_BUDGET") = value
            End Set
        End Property
#End Region

#Region "OUT_BALANCDE_BUDGET 歲出-決算數"
        '' <summary>
        '' OUT_BALANCDE_BUDGET 歲出-決算數
        '' </summary>
        Public Property OUT_BALANCDE_BUDGET() As String
            Get
                Return Me.PropertyMap("OUT_BALANCDE_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUT_BALANCDE_BUDGET") = value
            End Set
        End Property
#End Region

#Region "OUT_EX_RATE 歲出-執行率"
        '' <summary>
        '' OUT_EX_RATE 歲出-執行率
        '' </summary>
        Public Property OUT_EX_RATE() As String
            Get
                Return Me.PropertyMap("OUT_EX_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUT_EX_RATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1451"
        ' <summary>Ent_APP1451</ summary>
        Private Property Ent_APP1451() As ENT_APP1451
            Get
                Return Me.PropertyMap("Ent_APP1451")
            End Get
            Set(ByVal value As ENT_APP1451)
                Me.PropertyMap("Ent_APP1451") = value
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
                Me.Ent_APP1451.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1451.YEAR = Me.YEAR        '年度
                Me.Ent_APP1451.DATA_TYPE = Me.DATA_TYPE      '類型, 0：目前，1：未來
                Me.Ent_APP1451.OPERATING_INCOME = Me.OPERATING_INCOME        '營業收入/收入
                Me.Ent_APP1451.OPERATING_COST = Me.OPERATING_COST        '營業成本/成本
                Me.Ent_APP1451.OPERATING_EXP = Me.OPERATING_EXP      '營業費用/費用
                Me.Ent_APP1451.NON_OPERATING_INCOME = Me.NON_OPERATING_INCOME        '營業外收益及費損
                Me.Ent_APP1451.OPERATING_MARGIN = Me.OPERATING_MARGIN        '營業毛利
                Me.Ent_APP1451.OPERATING_PROFIT = Me.OPERATING_PROFIT        '營業淨利
                Me.Ent_APP1451.NON_OPERATING_PAY = Me.NON_OPERATING_PAY      '
                Me.Ent_APP1451.BEFORE_TAX_INCOME = Me.BEFORE_TAX_INCOME      '稅前淨利
                Me.Ent_APP1451.INCOME_TAX_EXP = Me.INCOME_TAX_EXP        '所得稅費用
                Me.Ent_APP1451.AFTER_TAX_INCOME = Me.AFTER_TAX_INCOME        '稅後淨利
                Me.Ent_APP1451.END_SURPLUS = Me.END_SURPLUS '期末累積餘絀
                Me.Ent_APP1451.IN_BUDGET = Me.IN_BUDGET '歲入-預算數
                Me.Ent_APP1451.IN_BALANCED_BUDGET = Me.IN_BALANCED_BUDGET '歲入-決算數
                Me.Ent_APP1451.IN_EX_RATE = Me.IN_EX_RATE '歲入-執行率
                Me.Ent_APP1451.OUT_BUDGET = Me.OUT_BUDGET '歲出-預算數
                Me.Ent_APP1451.OUT_BALANCDE_BUDGET = Me.OUT_BALANCDE_BUDGET '歲出-決算數
                Me.Ent_APP1451.OUT_EX_RATE = Me.OUT_EX_RATE'歲出-執行率

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1451.Insert()

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
                Me.Ent_APP1451.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1451.YEAR = Me.YEAR        '年度
                Me.Ent_APP1451.DATA_TYPE = Me.DATA_TYPE      '類型, 0：目前，1：未來
                Me.Ent_APP1451.OPERATING_INCOME = Me.OPERATING_INCOME        '營業收入/收入
                Me.Ent_APP1451.OPERATING_COST = Me.OPERATING_COST        '營業成本/成本
                Me.Ent_APP1451.OPERATING_EXP = Me.OPERATING_EXP      '營業費用/費用
                Me.Ent_APP1451.NON_OPERATING_INCOME = Me.NON_OPERATING_INCOME        '營業外收益及費損
                Me.Ent_APP1451.OPERATING_MARGIN = Me.OPERATING_MARGIN        '營業毛利
                Me.Ent_APP1451.OPERATING_PROFIT = Me.OPERATING_PROFIT        '營業淨利
                Me.Ent_APP1451.NON_OPERATING_PAY = Me.NON_OPERATING_PAY      '
                Me.Ent_APP1451.BEFORE_TAX_INCOME = Me.BEFORE_TAX_INCOME      '稅前淨利
                Me.Ent_APP1451.INCOME_TAX_EXP = Me.INCOME_TAX_EXP        '所得稅費用
                Me.Ent_APP1451.AFTER_TAX_INCOME = Me.AFTER_TAX_INCOME        '稅後淨利
                Me.Ent_APP1451.END_SURPLUS = Me.END_SURPLUS      '期末累積餘絀
                Me.Ent_APP1451.IN_BUDGET = Me.IN_BUDGET '歲入-預算數
                Me.Ent_APP1451.IN_BALANCED_BUDGET = Me.IN_BALANCED_BUDGET '歲入-決算數
                Me.Ent_APP1451.IN_EX_RATE = Me.IN_EX_RATE '歲入-執行率
                Me.Ent_APP1451.OUT_BUDGET = Me.OUT_BUDGET '歲出-預算數
                Me.Ent_APP1451.OUT_BALANCDE_BUDGET = Me.OUT_BALANCDE_BUDGET '歲出-決算數
                Me.Ent_APP1451.OUT_EX_RATE = Me.OUT_EX_RATE '歲出-執行率

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1451.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1451.Update()

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
                Me.ProcessQueryCondition(condition, "=", "DATA_TYPE", Me.DATA_TYPE)
                Me.Ent_APP1451.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1451.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1451.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "DATA_TYPE", Me.DATA_TYPE)      '類型, 0：目前，1：未來
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年度
                Me.ProcessQueryCondition(condition, "=", "OPERATING_INCOME", Me.OPERATING_INCOME)        '營業收入/收入
                Me.ProcessQueryCondition(condition, "=", "OPERATING_COST", Me.OPERATING_COST)        '營業成本/成本
                Me.ProcessQueryCondition(condition, "=", "OPERATING_EXP", Me.OPERATING_EXP)      '營業費用/費用
                Me.ProcessQueryCondition(condition, "=", "NON_OPERATING_INCOME", Me.NON_OPERATING_INCOME)        '營業外收益及費損
                Me.ProcessQueryCondition(condition, "=", "OPERATING_MARGIN", Me.OPERATING_MARGIN)        '營業毛利
                Me.ProcessQueryCondition(condition, "=", "OPERATING_PROFIT", Me.OPERATING_PROFIT)        '營業淨利
                Me.ProcessQueryCondition(condition, "=", "NON_OPERATING_PAY", Me.NON_OPERATING_PAY)      '
                Me.ProcessQueryCondition(condition, "=", "BEFORE_TAX_INCOME", Me.BEFORE_TAX_INCOME)      '稅前淨利
                Me.ProcessQueryCondition(condition, "=", "INCOME_TAX_EXP", Me.INCOME_TAX_EXP)        '所得稅費用
                Me.ProcessQueryCondition(condition, "=", "AFTER_TAX_INCOME", Me.AFTER_TAX_INCOME)        '稅後淨利
                Me.ProcessQueryCondition(condition, "=", "END_SURPLUS", Me.END_SURPLUS)      '期末累積餘絀
                Me.ProcessQueryCondition(condition, "=", "IN_BUDGET", Me.IN_BUDGET) '歲入-預算數
                Me.ProcessQueryCondition(condition, "=", "IN_BALANCED_BUDGET", Me.IN_BALANCED_BUDGET) '歲入-決算數
                Me.ProcessQueryCondition(condition, "=", "IN_EX_RATE", Me.IN_EX_RATE) '歲入-執行率
                Me.ProcessQueryCondition(condition, "=", "OUT_BUDGET", Me.OUT_BUDGET) '歲出-預算數
                Me.ProcessQueryCondition(condition, "=", "OUT_BALANCDE_BUDGET", Me.OUT_BALANCDE_BUDGET) '歲出-決算數
                Me.ProcessQueryCondition(condition, "=", "OUT_EX_RATE", Me.OUT_EX_RATE) '歲出-執行率

                Me.Ent_APP1451.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1451.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1451.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1451.Query()
                Else
                    result = Me.Ent_APP1451.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1451.TotalRowCount
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

