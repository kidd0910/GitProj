Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP0003
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP0003 = New ENT_APP0003(Me.DBManager, Me.LogUtil)
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

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP0003"
        ' <summary>Ent_APP0003</ summary>
        Private Property Ent_APP0003() As ENT_APP0003
            Get
                Return Me.PropertyMap("Ent_APP0003")
            End Get
            Set(ByVal value As ENT_APP0003)
                Me.PropertyMap("Ent_APP0003") = value
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
                Me.Ent_APP0003.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0003.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0003.QNO = Me.QNO              '題目代號
                Me.Ent_APP0003.QNO_DESC = Me.QNO_DESC    '題目內容
                Me.Ent_APP0003.USE_STATE = Me.USE_STATE

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP0003.Insert()

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
                Me.Ent_APP0003.CASE_CODE = Me.CASE_CODE  '案號前四碼
                Me.Ent_APP0003.TAB_FILE = Me.TAB_FILE    '程式代碼
                Me.Ent_APP0003.QNO = Me.QNO              '題目代號
                Me.Ent_APP0003.QNO_DESC = Me.QNO_DESC    '題目內容
                Me.Ent_APP0003.USE_STATE = Me.USE_STATE


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP0003.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP0003.Update()

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
                Me.Ent_APP0003.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP0003.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP0003.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)

                Me.Ent_APP0003.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP0003.OrderBys = "PKNO"
                Else
                    Me.Ent_APP0003.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP0003.Query()
                Else
                    result = Me.Ent_APP0003.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP0003.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GenContent 產生應載細項內容"

        ''' <summary>
        ''' 產生應載細項內容(HTML)
        ''' </summary>
        ''' <param name="CaseCode">申辦項目代碼</param>
        ''' <param name="FileNo">頁面區塊代碼</param>
        ''' <param name="Tab_Type">頁面代碼</param>
        Public Function GenContent(ByVal CaseCode As String, ByVal FileNo As String, Optional ByVal Tab_Type As String = "1") As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "CASE_CODE", CaseCode)
                Me.ProcessQueryCondition(condition, "=", "FILE_NO", FileNo)
                Me.ProcessQueryCondition(condition, "=", "TAB_TYPE", Tab_Type)
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)

                Me.Ent_APP0003.SqlRetrictions = condition.ToString()
                Me.Ent_APP0003.OrderBys = " SYS_SORT "

                '=== 處理取得回傳資料===
                Dim dt As DataTable = Me.Ent_APP0003.Query()

                '=== 產生回傳HTML TAG 資料===
                Dim txtStartTable As String = "<table width='100%' border='0' cellpadding='3' cellspacing='0' bordercolor='#3366CC' bordercolordark='#FFFFFF' class='dataTable'>"
                Dim txtHeader As String = "<tr><td align='center' nowrap  Class='dataHeader'>應載細項</td><td align ='center' nowrap  Class='dataHeader'>填寫說明</td></tr>"
                Dim txtEndTable As String = "</table>"

                Dim txtContent As New StringBuilder
                txtContent.AppendLine(txtStartTable)
                txtContent.AppendLine(txtHeader)

                If (dt.Rows.Count > 0) Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        txtContent.AppendFormat("<tr><td Class='dataColor02'>{0}</td>", dt.Rows(i).Item("DESC1").ToString)
                        txtContent.AppendFormat("<td class='dataColor02'>{0}</td></tr>", dt.Rows(i).Item("DESC2").ToString)
                    Next
                Else '無資料時顯示
                    txtContent.AppendFormat("<tr><td Class='dataColor02'>{0}</td>", "<div class='txtTitle'>無相關資料</div>")
                    txtContent.AppendFormat("<td class='dataColor02'>{0}</td></tr>", "<div class='txtTitle'>無相關資料</div>")
                End If


                txtContent.AppendLine(txtEndTable)

                Me.ResetColumnProperty()

                Return txtContent.ToString
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#End Region

#End Region
    End Class
End Namespace



