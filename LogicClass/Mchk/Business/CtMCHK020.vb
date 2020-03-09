'ProductName                 : BTEV 
'File Name					 : CtMCHK020 
'Description	             : CtMCHK020 查核單細項Controller
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/01/09  Becky      Source Create
'---------------------------------------------------------------------------

Imports Mchk.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Mchk.Business
    Partial Public Class CtMCHK020
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_MCHK020 = New Ent_MCHK020(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "MCHK010_PKNO 查核表主檔PKNO"
        '' <summary>
        '' MCHK010_PKNO 查核表主檔PKNO
        '' </summary>
        Public Property MCHK010_PKNO() As String
            Get
                Return Me.PropertyMap("MCHK010_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK010_PKNO") = value
            End Set
        End Property
#End Region

#Region "MCHK_ITEM 查核重點"
        '' <summary>
        '' MCHK_ITEM 查核重點
        '' </summary>
        Public Property MCHK_ITEM() As String
            Get
                Return Me.PropertyMap("MCHK_ITEM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_ITEM") = value
            End Set
        End Property
#End Region

#Region "MCHK_RESULT 本會查核情形"
        '' <summary>
        '' MCHK_RESULT 本會查核情形
        '' </summary>
        Public Property MCHK_RESULT() As String
            Get
                Return Me.PropertyMap("MCHK_RESULT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_RESULT") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC 查核情形說明"
        '' <summary>
        '' MCHK_DESC 查核情形說明
        '' </summary>
        Public Property MCHK_DESC() As String
            Get
                Return Me.PropertyMap("MCHK_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_DESC") = value
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

#Region "Ent_MCHK020"
        ' <summary>Ent_MCHK020</ summary>
        Private Property Ent_MCHK020() As Ent_MCHK020
            Get
                Return Me.PropertyMap("Ent_MCHK020")
            End Get
            Set(ByVal value As Ent_MCHK020)
                Me.PropertyMap("Ent_MCHK020") = value
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
                Me.Ent_MCHK020.MCHK010_PKNO = Me.MCHK010_PKNO         '查核表主檔PKNO
                Me.Ent_MCHK020.MCHK_ITEM = Me.MCHK_ITEM        '查核重點
                Me.Ent_MCHK020.MCHK_RESULT = Me.MCHK_RESULT      '本會查核情形
                Me.Ent_MCHK020.MCHK_DESC = Me.MCHK_DESC        '查核情形說明

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_MCHK020.Insert()

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
                Me.Ent_MCHK020.MCHK010_PKNO = Me.MCHK010_PKNO         '查核表主檔PKNO
                Me.Ent_MCHK020.MCHK_ITEM = Me.MCHK_ITEM        '查核重點
                Me.Ent_MCHK020.MCHK_RESULT = Me.MCHK_RESULT      '本會查核情形
                Me.Ent_MCHK020.MCHK_DESC = Me.MCHK_DESC        '查核情形說明

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_MCHK020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_MCHK020.Update()

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
                Me.Ent_MCHK020.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 刪除資料 ===
                If Me.Ent_MCHK020.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_MCHK020.Delete()
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
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "MCHK010_PKNO", Me.MCHK010_PKNO)        '查核表主檔PKNO
                Me.ProcessQueryCondition(condition, "=", "MCHK_ITEM", Me.MCHK_ITEM)      '查核重點
                Me.ProcessQueryCondition(condition, "=", "MCHK_RESULT", Me.MCHK_RESULT)      '本會查核情形
                Me.ProcessQueryCondition(condition, "%LIKE%", "MCHK_DESC", Me.MCHK_DESC)         '查核情形說明

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_MCHK020.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_MCHK020.OrderBys = "PKNO"
                Else
                    Me.Ent_MCHK020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_MCHK020.Query()
                Else
                    result = Me.Ent_MCHK020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_MCHK020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddAns 新增查核結果"
        ''' <summary>
        ''' 新增查核結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Becky 新增方法
        ''' </remarks>
        Public Sub AddAns(ByVal dtAnswer As DataTable)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                'If Me.MCHK010_PKNO Is Nothing Then
                '    faileArguments.Add("MCHK010_PKNO")
                'End If

                ''=== DT問卷選項 ===
                'If Me.MCHK_ITEM Is Nothing Then
                '    faileArguments.Add("MCHK_ITEM")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                For i As Integer = 0 To dtAnswer.Rows.Count - 1

                    Me.Ent_MCHK020.MCHK010_PKNO = dtAnswer.Rows(i)("MCHK010_PKNO").ToString '查核表主檔PKNO
                    Me.Ent_MCHK020.MCHK_ITEM = dtAnswer.Rows(i)("MCHK_ITEM").ToString       '查核重點
                    Me.Ent_MCHK020.MCHK_RESULT = dtAnswer.Rows(i)("MCHK_RESULT").ToString      '本會查核情形
                    Me.Ent_MCHK020.MCHK_DESC = dtAnswer.Rows(i)("MCHK_DESC").ToString       '查核情形說明
                    Me.Ent_MCHK020.Insert()

                Next


                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "delAns 刪除查核結果 "
        ''' <summary>
        ''' 刪除查核結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Becky 新增方法
        ''' </remarks>
        Public Sub delAns()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                'If String.IsNullOrEmpty(Me.SqlRetrictions) And String.IsNullOrEmpty(Me.MCHK010_PKNO) Then
                '    faileArguments.Add("SqlRetrictions or MCHK010_PKNO")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "MCHK010_PKNO", Me.MCHK010_PKNO)
                Me.Ent_MCHK020.SqlRetrictions = Me.ProcessCondition(condition.ToString()) & Me.SqlRetrictions

                '=== 刪除資料 ===
                If Me.Ent_MCHK020.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_MCHK020.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdAns 更新查核結果"
        ''' <summary>
        ''' 更新查核結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Becky 新增方法
        ''' </remarks>
        Public Sub UpdAns(ByVal dtAnswer As DataTable)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If dtAnswer.Rows(0)("PKNO").ToString Is Nothing Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 檢核欄位結束 ===


                '=== 處理修改資料動作 ===
                For i As Integer = 0 To dtAnswer.Rows.Count - 1

                    Me.Ent_MCHK020.MCHK010_PKNO = dtAnswer.Rows(i)("MCHK010_PKNO").ToString '查核表主檔PKNO
                    Me.Ent_MCHK020.MCHK_ITEM = dtAnswer.Rows(i)("MCHK_ITEM").ToString       '查核重點
                    Me.Ent_MCHK020.MCHK_RESULT = dtAnswer.Rows(i)("MCHK_RESULT").ToString      '本會查核情形
                    Me.Ent_MCHK020.MCHK_DESC = dtAnswer.Rows(i)("MCHK_DESC").ToString       '查核情形說明

                    '=== 處理查詢條件 ===
                    Dim condition As StringBuilder = New StringBuilder()
                    '處理批次修改狀態
                    Me.ProcessQueryCondition(condition, "=", "PKNO", dtAnswer.Rows(i)("PKNO").ToString)
                    Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                    Me.Ent_MCHK020.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                    Me.Ent_MCHK020.Update()

                Next

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region
#End Region
    End Class
End Namespace

