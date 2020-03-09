
Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP0002
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP0002 = New ENT_APP0002(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"

#Region "CASE_CODE"
        '' <summary>
        '' CASE_CODE 案號前四碼
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.PropertyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "TAB_FILE"
        '' <summary>
        '' TAB_FILE 程式代碼
        '' </summary>
        Public Property TAB_FILE() As String
            Get
                Return Me.PropertyMap("TAB_FILE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAB_FILE") = value
            End Set
        End Property
#End Region


#Region "QNO"
        '' <summary>
        '' QNO 題目代號
        '' </summary>
        Public Property QNO() As String
            Get
                Return Me.PropertyMap("QNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO") = value
            End Set
        End Property
#End Region

#Region "QNO_DESC"
        '' <summary>
        '' QNO_DESC 題目內容
        '' </summary>
        Public Property QNO_DESC() As String
            Get
                Return Me.PropertyMap("QNO_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO_DESC") = value
            End Set
        End Property
#End Region

#Region "PKNO"
        '' <summary>
        '' PKNO
        '' </summary>
        Public Property PKNO() As String
            Get
                Return Me.PropertyMap("PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PKNO") = value
            End Set
        End Property
#End Region

#Region "Ent_APP0002"
        ' <summary>Ent_APP0002</ summary>
        Private Property Ent_APP0002() As ENT_APP0002
            Get
                Return Me.PropertyMap("Ent_APP0002")
            End Get
            Set(ByVal value As ENT_APP0002)
                Me.PropertyMap("Ent_APP0002") = value
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
                Me.Ent_APP0002.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0002.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0002.QNO = Me.QNO              '題目代號
                Me.Ent_APP0002.QNO_DESC = Me.QNO_DESC    '題目內容

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP0002.Insert()

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
                Me.Ent_APP0002.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0002.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0002.QNO = Me.QNO              '題目代號
                Me.Ent_APP0002.QNO_DESC = Me.QNO_DESC    '題目內容


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP0002.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP0002.Update()

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
                Me.Ent_APP0002.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 刪除資料 ===
                If Me.Ent_APP0002.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP0002.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)           'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_CODE", Me.CASE_CODE)  '案號前四碼
                Me.ProcessQueryCondition(condition, "=", "TAB_FILE", Me.TAB_FILE)    '程式代碼
                Me.ProcessQueryCondition(condition, "=", "QNO", Me.QNO)              '題目代號
                Me.ProcessQueryCondition(condition, "=", "QNO_DESC", Me.QNO_DESC)    '題目內容

                Me.Ent_APP0002.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP0002.OrderBys = "PKNO"
                Else
                    Me.Ent_APP0002.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP0002.Query()
                Else
                    result = Me.Ent_APP0002.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP0002.TotalRowCount
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
