'ProductName                 : TSBA 
'File Name					 : CtAPP1430 
'Description	             : CtAPP1430 APP1430 特定節目/活動
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/20  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1430
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1430 = New ENT_APP1430(Me.DBManager, Me.LogUtil)
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

#Region "ACTIVE_TYPE 類別，節目：1，活動：2"
        '' <summary>
        '' ACTIVE_TYPE 類別，節目：1，活動：2
        '' </summary>
        Public Property ACTIVE_TYPE() As String
            Get
                Return Me.PropertyMap("ACTIVE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACTIVE_TYPE") = value
            End Set
        End Property
#End Region

#Region "SHOW_NAME 節目名稱/活動名稱/活動名稱及活動內容"
        '' <summary>
        '' SHOW_NAME 節目名稱/活動名稱/活動名稱及活動內容
        '' </summary>
        Public Property SHOW_NAME() As String
            Get
                Return Me.PropertyMap("SHOW_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_NAME") = value
            End Set
        End Property
#End Region

#Region "SHOW_LEN 播出長度"
        '' <summary>
        '' SHOW_LEN 播出長度
        '' </summary>
        Public Property SHOW_LEN() As String
            Get
                Return Me.PropertyMap("SHOW_LEN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_LEN") = value
            End Set
        End Property
#End Region

#Region "SHOW_NUMBER 播出集數/集數"
        '' <summary>
        '' SHOW_NUMBER 播出集數/集數
        '' </summary>
        Public Property SHOW_NUMBER() As String
            Get
                Return Me.PropertyMap("SHOW_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SHOW_TIME "
        '' <summary>
        '' SHOW_TIME 
        '' </summary>
        Public Property SHOW_TIME() As String
            Get
                Return Me.PropertyMap("SHOW_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_TIME") = value
            End Set
        End Property
#End Region

#Region "PLAN_DESC 企劃內容/佐證資料/單元主題"
        '' <summary>
        '' PLAN_DESC 企劃內容/佐證資料/單元主題
        '' </summary>
        Public Property PLAN_DESC() As String
            Get
                Return Me.PropertyMap("PLAN_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLAN_DESC") = value
            End Set
        End Property
#End Region

#Region "SHOW_DATE 活動時間/播出期間"
        '' <summary>
        '' SHOW_DATE 活動時間/播出期間
        '' </summary>
        Public Property SHOW_DATE() As String
            Get
                Return Me.PropertyMap("SHOW_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_DATE") = value
            End Set
        End Property
#End Region

#Region "ACTIVE_SITE 活動地點/地點"
        '' <summary>
        '' ACTIVE_SITE 活動地點/地點
        '' </summary>
        Public Property ACTIVE_SITE() As String
            Get
                Return Me.PropertyMap("ACTIVE_SITE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACTIVE_SITE") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OBJECT 服務對象"
        '' <summary>
        '' SERVICE_OBJECT 服務對象
        '' </summary>
        Public Property SERVICE_OBJECT() As String
            Get
                Return Me.PropertyMap("SERVICE_OBJECT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_OBJECT") = value
            End Set
        End Property
#End Region

#Region "PART_NUMBER "
        '' <summary>
        '' PART_NUMBER 
        '' </summary>
        Public Property PART_NUMBER() As String
            Get
                Return Me.PropertyMap("PART_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PART_NUMBER") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1430"
        ' <summary>Ent_APP1430</ summary>
        Private Property Ent_APP1430() As ENT_APP1430
            Get
                Return Me.PropertyMap("Ent_APP1430")
            End Get
            Set(ByVal value As ENT_APP1430)
                Me.PropertyMap("Ent_APP1430") = value
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
                Me.Ent_APP1430.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1430.ACTIVE_TYPE = Me.ACTIVE_TYPE      '類別，節目：1，活動：2
                Me.Ent_APP1430.SHOW_NAME = Me.SHOW_NAME      '節目名稱/活動名稱/活動名稱及活動內容
                Me.Ent_APP1430.SHOW_LEN = Me.SHOW_LEN        '播出長度
                Me.Ent_APP1430.SHOW_NUMBER = Me.SHOW_NUMBER      '播出集數/集數
                Me.Ent_APP1430.SHOW_TIME = Me.SHOW_TIME      '
                Me.Ent_APP1430.PLAN_DESC = Me.PLAN_DESC      '企劃內容/佐證資料/單元主題
                Me.Ent_APP1430.SHOW_DATE = Me.SHOW_DATE      '活動時間/播出期間
                Me.Ent_APP1430.ACTIVE_SITE = Me.ACTIVE_SITE      '活動地點/地點
                Me.Ent_APP1430.SERVICE_OBJECT = Me.SERVICE_OBJECT        '服務對象
                Me.Ent_APP1430.PART_NUMBER = Me.PART_NUMBER      '


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1430.Insert()

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
                Me.Ent_APP1430.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1430.ACTIVE_TYPE = Me.ACTIVE_TYPE      '類別，節目：1，活動：2
                Me.Ent_APP1430.SHOW_NAME = Me.SHOW_NAME      '節目名稱/活動名稱/活動名稱及活動內容
                Me.Ent_APP1430.SHOW_LEN = Me.SHOW_LEN        '播出長度
                Me.Ent_APP1430.SHOW_NUMBER = Me.SHOW_NUMBER      '播出集數/集數
                Me.Ent_APP1430.SHOW_TIME = Me.SHOW_TIME      '
                Me.Ent_APP1430.PLAN_DESC = Me.PLAN_DESC      '企劃內容/佐證資料/單元主題
                Me.Ent_APP1430.SHOW_DATE = Me.SHOW_DATE      '活動時間/播出期間
                Me.Ent_APP1430.ACTIVE_SITE = Me.ACTIVE_SITE      '活動地點/地點
                Me.Ent_APP1430.SERVICE_OBJECT = Me.SERVICE_OBJECT        '服務對象
                Me.Ent_APP1430.PART_NUMBER = Me.PART_NUMBER      '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1430.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1430.Update()

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
                Me.Ent_APP1430.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1430.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1430.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "ACTIVE_TYPE", Me.ACTIVE_TYPE)      '類別，節目：1，活動：2
                Me.ProcessQueryCondition(condition, "%LIKE%", "SHOW_NAME", Me.SHOW_NAME)         '節目名稱/活動名稱/活動名稱及活動內容
                Me.ProcessQueryCondition(condition, "=", "SHOW_LEN", Me.SHOW_LEN)        '播出長度
                Me.ProcessQueryCondition(condition, "=", "SHOW_NUMBER", Me.SHOW_NUMBER)      '播出集數/集數
                Me.ProcessQueryCondition(condition, "=", "SHOW_TIME", Me.SHOW_TIME)      '
                Me.ProcessQueryCondition(condition, "%LIKE%", "PLAN_DESC", Me.PLAN_DESC)         '企劃內容/佐證資料/單元主題
                Me.ProcessQueryCondition(condition, "=", "SHOW_DATE", Me.SHOW_DATE)      '活動時間/播出期間
                Me.ProcessQueryCondition(condition, "=", "ACTIVE_SITE", Me.ACTIVE_SITE)      '活動地點/地點
                Me.ProcessQueryCondition(condition, "=", "SERVICE_OBJECT", Me.SERVICE_OBJECT)        '服務對象
                Me.ProcessQueryCondition(condition, "=", "PART_NUMBER", Me.PART_NUMBER)      '

                Me.Ent_APP1430.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1430.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1430.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1430.Query()
                Else
                    result = Me.Ent_APP1430.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1430.TotalRowCount
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

