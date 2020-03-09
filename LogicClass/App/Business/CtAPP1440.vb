'ProductName                 : TSBA 
'File Name					 : CtAPP1440 
'Description	             : CtAPP1440 APP1440 各項報表申報完成時間
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/21  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1440
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1440 = New ENT_APP1440(Me.DBManager, Me.LogUtil)
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

#Region "YEAR 年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'"
        '' <summary>
        '' YEAR 年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
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

#Region "DECLARE_ITEM 申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'"
        '' <summary>
        '' DECLARE_ITEM 申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
        '' </summary>
        Public Property DECLARE_ITEM() As String
            Get
                Return Me.PropertyMap("DECLARE_ITEM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_ITEM") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_DATE 申報規定期限"
        '' <summary>
        '' DEADLINE_DATE 申報規定期限
        '' </summary>
        Public Property DEADLINE_DATE() As String
            Get
                Return Me.PropertyMap("DEADLINE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE_DATE") = value
            End Set
        End Property
#End Region

#Region "DECLARE_DATE 實際申報日期/完成時間"
        '' <summary>
        '' DECLARE_DATE 實際申報日期/完成時間
        '' </summary>
        Public Property DECLARE_DATE() As String
            Get
                Return Me.PropertyMap("DECLARE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_DATE") = value
            End Set
        End Property
#End Region

#Region "ON_TIME 是否正確準時, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' ON_TIME 是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property ON_TIME() As String
            Get
                Return Me.PropertyMap("ON_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ON_TIME") = value
            End Set
        End Property
#End Region

#Region "DECLARE_DESC 備註"
        '' <summary>
        '' DECLARE_DESC 備註
        '' </summary>
        Public Property DECLARE_DESC() As String
            Get
                Return Me.PropertyMap("DECLARE_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1440"
        ' <summary>Ent_APP1440</ summary>
        Private Property Ent_APP1440() As ENT_APP1440
            Get
                Return Me.PropertyMap("Ent_APP1440")
            End Get
            Set(ByVal value As ENT_APP1440)
                Me.PropertyMap("Ent_APP1440") = value
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
                Me.Ent_APP1440.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1440.YEAR = Me.YEAR        '年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
                Me.Ent_APP1440.DECLARE_ITEM = Me.DECLARE_ITEM        '申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
                Me.Ent_APP1440.DEADLINE_DATE = Me.DEADLINE_DATE      '申報規定期限
                Me.Ent_APP1440.DECLARE_DATE = Me.DECLARE_DATE        '實際申報日期/完成時間
                Me.Ent_APP1440.ON_TIME = Me.ON_TIME      '是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1440.DECLARE_DESC = Me.DECLARE_DESC        '備註


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1440.Insert()

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
                Me.Ent_APP1440.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1440.YEAR = Me.YEAR        '年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
                Me.Ent_APP1440.DECLARE_ITEM = Me.DECLARE_ITEM        '申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
                Me.Ent_APP1440.DEADLINE_DATE = Me.DEADLINE_DATE      '申報規定期限
                Me.Ent_APP1440.DECLARE_DATE = Me.DECLARE_DATE        '實際申報日期/完成時間
                Me.Ent_APP1440.ON_TIME = Me.ON_TIME      '是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1440.DECLARE_DESC = Me.DECLARE_DESC        '備註


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1440.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1440.Update()

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
                Me.Ent_APP1440.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1440.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1440.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_ITEM", Me.DECLARE_ITEM)        '申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
                Me.ProcessQueryCondition(condition, "=", "DEADLINE_DATE", Me.DEADLINE_DATE)      '申報規定期限
                Me.ProcessQueryCondition(condition, "=", "DECLARE_DATE", Me.DECLARE_DATE)        '實際申報日期/完成時間
                Me.ProcessQueryCondition(condition, "=", "ON_TIME", Me.ON_TIME)      '是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "DECLARE_DESC", Me.DECLARE_DESC)       '備註

                Me.Ent_APP1440.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1440.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1440.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1440.Query()
                Else
                    result = Me.Ent_APP1440.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1440.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 查詢項目ID對應NAME
        ''' </summary>
        Public Function Query_ItemWithName() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_ITEM", Me.DECLARE_ITEM)        '申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
                Me.ProcessQueryCondition(condition, "=", "DEADLINE_DATE", Me.DEADLINE_DATE)      '申報規定期限
                Me.ProcessQueryCondition(condition, "=", "DECLARE_DATE", Me.DECLARE_DATE)        '實際申報日期/完成時間
                Me.ProcessQueryCondition(condition, "=", "ON_TIME", Me.ON_TIME)      '是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "DECLARE_DESC", Me.DECLARE_DESC)       '備註

                Me.Ent_APP1440.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1440.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1440.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1440.Query_ItemWithName()
                Else
                    'result = Me.Ent_APP1440.Query_ItemWithName(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1440.TotalRowCount
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

