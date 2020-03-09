'ProductName                 : TSBA 
'File Name					 : CtAPP1450 
'Description	             : CtAPP1450 APP1450 財務計畫
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/15  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1450
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1450 = New ENT_APP1450(Me.DBManager, Me.LogUtil)
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

#Region "M_INCOME_DESC 主要收入內容"
        '' <summary>
        '' M_INCOME_DESC 主要收入內容
        '' </summary>
        Public Property M_INCOME_DESC() As String
            Get
                Return Me.PropertyMap("M_INCOME_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_INCOME_DESC") = value
            End Set
        End Property
#End Region

#Region "M_INCOME1_AMT 主要收入-第1年"
        '' <summary>
        '' M_INCOME1_AMT 主要收入-第1年
        '' </summary>
        Public Property M_INCOME1_AMT() As String
            Get
                Return Me.PropertyMap("M_INCOME1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_INCOME1_AMT") = value
            End Set
        End Property
#End Region

#Region "M_INCOME2_AMT 主要收入-第2年"
        '' <summary>
        '' M_INCOME2_AMT 主要收入-第2年
        '' </summary>
        Public Property M_INCOME2_AMT() As String
            Get
                Return Me.PropertyMap("M_INCOME2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_INCOME2_AMT") = value
            End Set
        End Property
#End Region

#Region "M_INCOME3_AMT 主要收入-第3年"
        '' <summary>
        '' M_INCOME3_AMT 主要收入-第3年
        '' </summary>
        Public Property M_INCOME3_AMT() As String
            Get
                Return Me.PropertyMap("M_INCOME3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_INCOME3_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME_DESC 其他收入內容"
        '' <summary>
        '' O_INCOME_DESC 其他收入內容
        '' </summary>
        Public Property O_INCOME_DESC() As String
            Get
                Return Me.PropertyMap("O_INCOME_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_INCOME_DESC") = value
            End Set
        End Property
#End Region

#Region "O_INCOME1_AMT 其他收入-第1年"
        '' <summary>
        '' O_INCOME1_AMT 其他收入-第1年
        '' </summary>
        Public Property O_INCOME1_AMT() As String
            Get
                Return Me.PropertyMap("O_INCOME1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_INCOME1_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME2_AMT 其他收入-第2年"
        '' <summary>
        '' O_INCOME2_AMT 其他收入-第2年
        '' </summary>
        Public Property O_INCOME2_AMT() As String
            Get
                Return Me.PropertyMap("O_INCOME2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_INCOME2_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME3_AMT 其他收入-第3年"
        '' <summary>
        '' O_INCOME3_AMT 其他收入-第3年
        '' </summary>
        Public Property O_INCOME3_AMT() As String
            Get
                Return Me.PropertyMap("O_INCOME3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_INCOME3_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST_DESC 主要成本及費用內容"
        '' <summary>
        '' M_COST_DESC 主要成本及費用內容
        '' </summary>
        Public Property M_COST_DESC() As String
            Get
                Return Me.PropertyMap("M_COST_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_COST_DESC") = value
            End Set
        End Property
#End Region

#Region "M_COST1_AMT 主要成本及費用-第1年"
        '' <summary>
        '' M_COST1_AMT 主要成本及費用-第1年
        '' </summary>
        Public Property M_COST1_AMT() As String
            Get
                Return Me.PropertyMap("M_COST1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_COST1_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST2_AMT 主要成本及費用-第2年"
        '' <summary>
        '' M_COST2_AMT 主要成本及費用-第2年
        '' </summary>
        Public Property M_COST2_AMT() As String
            Get
                Return Me.PropertyMap("M_COST2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_COST2_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST3_AMT 主要成本及費用-第3年"
        '' <summary>
        '' M_COST3_AMT 主要成本及費用-第3年
        '' </summary>
        Public Property M_COST3_AMT() As String
            Get
                Return Me.PropertyMap("M_COST3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_COST3_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST1_AMT 其他成本及費用-第1年"
        '' <summary>
        '' O_COST1_AMT 其他成本及費用-第1年
        '' </summary>
        Public Property O_COST1_AMT() As String
            Get
                Return Me.PropertyMap("O_COST1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_COST1_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST2_AMT 其他成本及費用-第2年"
        '' <summary>
        '' O_COST2_AMT 其他成本及費用-第2年
        '' </summary>
        Public Property O_COST2_AMT() As String
            Get
                Return Me.PropertyMap("O_COST2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_COST2_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST3_AMT 其他成本及費用-第3年"
        '' <summary>
        '' O_COST3_AMT 其他成本及費用-第3年
        '' </summary>
        Public Property O_COST3_AMT() As String
            Get
                Return Me.PropertyMap("O_COST3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_COST3_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST_DESC 其他成本及費用內容"
        '' <summary>
        '' O_COST_DESC 其他成本及費用內容
        '' </summary>
        Public Property O_COST_DESC() As String
            Get
                Return Me.PropertyMap("O_COST_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_COST_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1450"
        ' <summary>Ent_APP1450</ summary>
        Private Property Ent_APP1450() As ENT_APP1450
            Get
                Return Me.PropertyMap("Ent_APP1450")
            End Get
            Set(ByVal value As ENT_APP1450)
                Me.PropertyMap("Ent_APP1450") = value
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
                Me.Ent_APP1450.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1450.M_INCOME_DESC = Me.M_INCOME_DESC      '主要收入內容
                Me.Ent_APP1450.M_INCOME1_AMT = Me.M_INCOME1_AMT      '主要收入-第1年
                Me.Ent_APP1450.M_INCOME2_AMT = Me.M_INCOME2_AMT      '主要收入-第2年
                Me.Ent_APP1450.M_INCOME3_AMT = Me.M_INCOME3_AMT      '主要收入-第3年
                Me.Ent_APP1450.O_INCOME_DESC = Me.O_INCOME_DESC      '其他收入內容
                Me.Ent_APP1450.O_INCOME1_AMT = Me.O_INCOME1_AMT      '其他收入-第1年
                Me.Ent_APP1450.O_INCOME2_AMT = Me.O_INCOME2_AMT      '其他收入-第2年
                Me.Ent_APP1450.O_INCOME3_AMT = Me.O_INCOME3_AMT      '其他收入-第3年
                Me.Ent_APP1450.M_COST_DESC = Me.M_COST_DESC      '主要成本及費用內容
                Me.Ent_APP1450.M_COST1_AMT = Me.M_COST1_AMT      '主要成本及費用-第1年
                Me.Ent_APP1450.M_COST2_AMT = Me.M_COST2_AMT      '主要成本及費用-第2年
                Me.Ent_APP1450.M_COST3_AMT = Me.M_COST3_AMT      '主要成本及費用-第3年
                Me.Ent_APP1450.O_COST1_AMT = Me.O_COST1_AMT      '其他成本及費用-第1年
                Me.Ent_APP1450.O_COST2_AMT = Me.O_COST2_AMT      '其他成本及費用-第2年
                Me.Ent_APP1450.O_COST3_AMT = Me.O_COST3_AMT      '其他成本及費用-第3年
                Me.Ent_APP1450.O_COST_DESC = Me.O_COST_DESC      '其他成本及費用內容


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1450.Insert()

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
                Me.Ent_APP1450.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1450.M_INCOME_DESC = Me.M_INCOME_DESC      '主要收入內容
                Me.Ent_APP1450.M_INCOME1_AMT = Me.M_INCOME1_AMT      '主要收入-第1年
                Me.Ent_APP1450.M_INCOME2_AMT = Me.M_INCOME2_AMT      '主要收入-第2年
                Me.Ent_APP1450.M_INCOME3_AMT = Me.M_INCOME3_AMT      '主要收入-第3年
                Me.Ent_APP1450.O_INCOME_DESC = Me.O_INCOME_DESC      '其他收入內容
                Me.Ent_APP1450.O_INCOME1_AMT = Me.O_INCOME1_AMT      '其他收入-第1年
                Me.Ent_APP1450.O_INCOME2_AMT = Me.O_INCOME2_AMT      '其他收入-第2年
                Me.Ent_APP1450.O_INCOME3_AMT = Me.O_INCOME3_AMT      '其他收入-第3年
                Me.Ent_APP1450.M_COST_DESC = Me.M_COST_DESC      '主要成本及費用內容
                Me.Ent_APP1450.M_COST1_AMT = Me.M_COST1_AMT      '主要成本及費用-第1年
                Me.Ent_APP1450.M_COST2_AMT = Me.M_COST2_AMT      '主要成本及費用-第2年
                Me.Ent_APP1450.M_COST3_AMT = Me.M_COST3_AMT      '主要成本及費用-第3年
                Me.Ent_APP1450.O_COST1_AMT = Me.O_COST1_AMT      '其他成本及費用-第1年
                Me.Ent_APP1450.O_COST2_AMT = Me.O_COST2_AMT      '其他成本及費用-第2年
                Me.Ent_APP1450.O_COST3_AMT = Me.O_COST3_AMT      '其他成本及費用-第3年
                Me.Ent_APP1450.O_COST_DESC = Me.O_COST_DESC      '其他成本及費用內容


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1450.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1450.Update()

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
                Me.Ent_APP1450.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1450.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1450.Delete()
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
                Me.ProcessQueryCondition(condition, "%LIKE%", "M_INCOME_DESC", Me.M_INCOME_DESC)         '主要收入內容
                Me.ProcessQueryCondition(condition, "=", "M_INCOME1_AMT", Me.M_INCOME1_AMT)      '主要收入-第1年
                Me.ProcessQueryCondition(condition, "=", "M_INCOME2_AMT", Me.M_INCOME2_AMT)      '主要收入-第2年
                Me.ProcessQueryCondition(condition, "=", "M_INCOME3_AMT", Me.M_INCOME3_AMT)      '主要收入-第3年
                Me.ProcessQueryCondition(condition, "%LIKE%", "O_INCOME_DESC", Me.O_INCOME_DESC)         '其他收入內容
                Me.ProcessQueryCondition(condition, "=", "O_INCOME1_AMT", Me.O_INCOME1_AMT)      '其他收入-第1年
                Me.ProcessQueryCondition(condition, "=", "O_INCOME2_AMT", Me.O_INCOME2_AMT)      '其他收入-第2年
                Me.ProcessQueryCondition(condition, "=", "O_INCOME3_AMT", Me.O_INCOME3_AMT)      '其他收入-第3年
                Me.ProcessQueryCondition(condition, "%LIKE%", "M_COST_DESC", Me.M_COST_DESC)         '主要成本及費用內容
                Me.ProcessQueryCondition(condition, "=", "M_COST1_AMT", Me.M_COST1_AMT)      '主要成本及費用-第1年
                Me.ProcessQueryCondition(condition, "=", "M_COST2_AMT", Me.M_COST2_AMT)      '主要成本及費用-第2年
                Me.ProcessQueryCondition(condition, "=", "M_COST3_AMT", Me.M_COST3_AMT)      '主要成本及費用-第3年
                Me.ProcessQueryCondition(condition, "=", "O_COST1_AMT", Me.O_COST1_AMT)      '其他成本及費用-第1年
                Me.ProcessQueryCondition(condition, "=", "O_COST2_AMT", Me.O_COST2_AMT)      '其他成本及費用-第2年
                Me.ProcessQueryCondition(condition, "=", "O_COST3_AMT", Me.O_COST3_AMT)      '其他成本及費用-第3年
                Me.ProcessQueryCondition(condition, "%LIKE%", "O_COST_DESC", Me.O_COST_DESC)         '其他成本及費用內容

                Me.Ent_APP1450.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1450.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1450.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1450.Query()
                Else
                    result = Me.Ent_APP1450.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1450.TotalRowCount
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

