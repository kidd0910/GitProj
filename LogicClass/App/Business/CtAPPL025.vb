Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL025
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL025 = New ENT_APPL025(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號, 
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

#Region "CASE_SEQ 補正次數"
        '' <summary>
        '' CASE_SEQ 補正次數, 
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.PropertyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region

#Region "CREATE_USER 資料建立者"
        '' <summary>
        '' CREATE_USER 資料建立者
        '' </summary>
        Public Property CREATE_USER() As String
            Get
                Return Me.PropertyMap("CREATE_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_USER") = value
            End Set
        End Property
#End Region

#Region "CREATE_DATE 資料建立日期"
        '' <summary>
        '' CREATE_DATE 資料建立日期
        '' </summary>
        Public Property CREATE_DATE() As String
            Get
                Return Me.PropertyMap("CREATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_DATE") = value
            End Set
        End Property
#End Region

#Region "UPDATE_USER 資料維護者"
        '' <summary>
        '' UPDATE_USER 資料維護者
        '' </summary>
        Public Property UPDATE_USER() As String
            Get
                Return Me.PropertyMap("UPDATE_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPDATE_USER") = value
            End Set
        End Property
#End Region

#Region "UPDATE_DATE 資料維護日期"
        '' <summary>
        '' UPDATE_DATE 資料維護日期
        '' </summary>
        Public Property UPDATE_DATE() As String
            Get
                Return Me.PropertyMap("UPDATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPDATE_DATE") = value
            End Set
        End Property
#End Region

#Region "OTHER_UNIT_DESC 會辦意見"
        '' <summary>
        '' OTHER_UNIT_DESC 會辦意見
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.PropertyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL025"
        ' <summary>Ent_APPL025</ summary>
        Private Property Ent_APPL025() As ENT_APPL025
            Get
                Return Me.PropertyMap("Ent_APPL025")
            End Get
            Set(ByVal value As ENT_APPL025)
                Me.PropertyMap("Ent_APPL025") = value
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
                Me.Ent_APPL025.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL025.CASE_SEQ = Me.CASE_SEQ        '補正次數              
                Me.Ent_APPL025.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '會辦意見

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL025.Insert()

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
                Me.Ent_APPL025.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL025.CASE_SEQ = Me.CASE_SEQ        '補正次數               
                Me.Ent_APPL025.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '會辦意見

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL025.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL025.Update()

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
                Me.Ent_APPL025.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 刪除資料 ===
                If Me.Ent_APPL025.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL025.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '補正次數
                Me.ProcessQueryCondition(condition, "=", "CREATE_USER", Me.CREATE_USER)      '資料建立者
                Me.ProcessQueryCondition(condition, "=", "CREATE_DATE", Me.CREATE_DATE)      '資料建立日期
                Me.ProcessQueryCondition(condition, "=", "UPDATE_USER", Me.UPDATE_USER)      '資料維護者
                Me.ProcessQueryCondition(condition, "=", "UPDATE_DATE", Me.UPDATE_DATE)      '資料維護日期
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC) '會辦意見

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL025.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL025.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL025.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL025.Query()
                Else
                    result = Me.Ent_APPL025.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL025.TotalRowCount
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


