'ProductName                 : TSBA 
'File Name					 : CtAPP1100 
'Description	             : CtAPP1100 預期營業收入明細表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/23  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1100
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1100 = New ENT_APP1100(Me.DBManager, Me.LogUtil)
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


#Region "ACC_TYPE 會計科目(1.收入，2.支出)"
        '' <summary>
        '' ACC_TYPE 會計科目(1.收入，2.支出)
        '' </summary>
        Public Property ACC_TYPE() As String
            Get
                Return Me.PropertyMap("ACC_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACC_TYPE") = value
            End Set
        End Property
#End Region

#Region "PROJECT_TYPE 項目種類"
        '' <summary>
        '' PROJECT_TYPE 項目種類(1.收入，2.支出)
        '' </summary>
        Public Property PROJECT_TYPE() As String
            Get
                Return Me.PropertyMap("PROJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "PROJECT_CLASS 項目類別"
        '' <summary>
        '' PROJECT_CLASS 項目類別
        '' </summary>
        Public Property PROJECT_CLASS() As String
            Get
                Return Me.PropertyMap("PROJECT_CLASS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROJECT_CLASS") = value
            End Set
        End Property
#End Region

#Region "FUTURE_ONE_YEAR 未來第1年"
        '' <summary>
        '' FUTURE_ONE_YEAR 未來第1年
        '' </summary>
        Public Property FUTURE_ONE_YEAR() As String
            Get
                Return Me.PropertyMap("FUTURE_ONE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FUTURE_ONE_YEAR") = value
            End Set
        End Property
#End Region

#Region "ONE_TOTAL_REV_RATIO 第1年占總營收之比例"
        '' <summary>
        '' ONE_TOTAL_REV_RATIO 第1年占總營收之比例
        '' </summary>
        Public Property ONE_TOTAL_REV_RATIO() As String
            Get
                Return Me.PropertyMap("ONE_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ONE_TOTAL_REV_RATIO") = value
            End Set
        End Property
#End Region

#Region "FUTURE_TWO_YEAR 未來第2年"
        '' <summary>
        '' FUTURE_TWO_YEAR 未來第2年
        '' </summary>
        Public Property FUTURE_TWO_YEAR() As String
            Get
                Return Me.PropertyMap("FUTURE_TWO_YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FUTURE_TWO_YEAR") = value
            End Set
        End Property
#End Region

#Region "TWO_TOTAL_REV_RATIO 未來第2年占總營收之比例"
        '' <summary>
        '' TWO_TOTAL_REV_RATIO 未來第2年占總營收之比例
        '' </summary>
        Public Property TWO_TOTAL_REV_RATIO() As String
            Get
                Return Me.PropertyMap("TWO_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TWO_TOTAL_REV_RATIO") = value
            End Set
        End Property
#End Region

#Region "FUTURE_THREE_YEAR 未來第3年"
        '' <summary>
        '' FUTURE_THREE_YEAR 未來第3年
        '' </summary>
        Public Property FUTURE_THREE_YEAR() As String
            Get
                Return Me.PropertyMap("FUTURE_THREE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FUTURE_THREE_YEAR") = value
            End Set
        End Property
#End Region

#Region "THREE_TOTAL_REV_RATIO 未來第3年占總營收之比例"
        '' <summary>
        '' THREE_TOTAL_REV_RATIO 未來第3年占總營收之比例
        '' </summary>
        Public Property THREE_TOTAL_REV_RATIO() As String
            Get
                Return Me.PropertyMap("THREE_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("THREE_TOTAL_REV_RATIO") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1100"
        ' <summary>Ent_APP1100</ summary>
        Private Property Ent_APP1100() As ENT_APP1100
            Get
                Return Me.PropertyMap("Ent_APP1100")
            End Get
            Set(ByVal value As ENT_APP1100)
                Me.PropertyMap("Ent_APP1100") = value
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
                Me.Ent_APP1100.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1100.ACC_TYPE = Me.ACC_TYPE
                Me.Ent_APP1100.PROJECT_TYPE = Me.PROJECT_TYPE        '項目種類(1.收入，2.支出)
                Me.Ent_APP1100.PROJECT_CLASS = Me.PROJECT_CLASS      '項目類別
                Me.Ent_APP1100.FUTURE_ONE_YEAR = Me.FUTURE_ONE_YEAR      '未來第1年
                Me.Ent_APP1100.ONE_TOTAL_REV_RATIO = Me.ONE_TOTAL_REV_RATIO      '第1年占總營收之比例
                Me.Ent_APP1100.FUTURE_TWO_YEAR = Me.FUTURE_TWO_YEAR      '未來第2年
                Me.Ent_APP1100.TWO_TOTAL_REV_RATIO = Me.TWO_TOTAL_REV_RATIO      '未來第2年占總營收之比例
                Me.Ent_APP1100.FUTURE_THREE_YEAR = Me.FUTURE_THREE_YEAR      '未來第3年
                Me.Ent_APP1100.THREE_TOTAL_REV_RATIO = Me.THREE_TOTAL_REV_RATIO      '未來第3年占總營收之比例


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1100.Insert()

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
                Me.Ent_APP1100.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1100.ACC_TYPE = Me.ACC_TYPE
                Me.Ent_APP1100.PROJECT_TYPE = Me.PROJECT_TYPE        '項目種類
                Me.Ent_APP1100.PROJECT_CLASS = Me.PROJECT_CLASS      '項目類別
                Me.Ent_APP1100.FUTURE_ONE_YEAR = Me.FUTURE_ONE_YEAR      '未來第1年
                Me.Ent_APP1100.ONE_TOTAL_REV_RATIO = Me.ONE_TOTAL_REV_RATIO      '第1年占總營收之比例
                Me.Ent_APP1100.FUTURE_TWO_YEAR = Me.FUTURE_TWO_YEAR      '未來第2年
                Me.Ent_APP1100.TWO_TOTAL_REV_RATIO = Me.TWO_TOTAL_REV_RATIO      '未來第2年占總營收之比例
                Me.Ent_APP1100.FUTURE_THREE_YEAR = Me.FUTURE_THREE_YEAR      '未來第3年
                Me.Ent_APP1100.THREE_TOTAL_REV_RATIO = Me.THREE_TOTAL_REV_RATIO      '未來第3年占總營收之比例


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1100.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1100.Update()

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
                Me.ProcessQueryCondition(condition, "=", "ACC_TYPE", Me.ACC_TYPE)
                Me.Ent_APP1100.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1100.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1100.Delete()
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

                '因為entity需要判斷，所以特別指定值 1/22
                Me.Ent_APP1100.ACC_TYPE = Me.ACC_TYPE

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "ACC_TYPE", Me.ACC_TYPE)      '
                Me.ProcessQueryCondition(condition, "=", "PROJECT_TYPE", Me.PROJECT_TYPE)        '項目種類(1.收入，2.支出)
                Me.ProcessQueryCondition(condition, "=", "PROJECT_CLASS", Me.PROJECT_CLASS)      '項目類別
                Me.ProcessQueryCondition(condition, "=", "FUTURE_ONE_YEAR", Me.FUTURE_ONE_YEAR)      '未來第1年
                Me.ProcessQueryCondition(condition, "=", "ONE_TOTAL_REV_RATIO", Me.ONE_TOTAL_REV_RATIO)      '第1年占總營收之比例
                Me.ProcessQueryCondition(condition, "=", "FUTURE_TWO_YEAR", Me.FUTURE_TWO_YEAR)      '未來第2年
                Me.ProcessQueryCondition(condition, "=", "TWO_TOTAL_REV_RATIO", Me.TWO_TOTAL_REV_RATIO)      '未來第2年占總營收之比例
                Me.ProcessQueryCondition(condition, "=", "FUTURE_THREE_YEAR", Me.FUTURE_THREE_YEAR)      '未來第3年
                Me.ProcessQueryCondition(condition, "=", "THREE_TOTAL_REV_RATIO", Me.THREE_TOTAL_REV_RATIO)      '未來第3年占總營收之比例

                Me.Ent_APP1100.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1100.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1100.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1100.Query()
                Else
                    result = Me.Ent_APP1100.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1100.TotalRowCount
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

