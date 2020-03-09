'ProductName                 : TSBA 
'File Name					 : CtAPPL021 
'Description	             : CtAPPL021 修正意見
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/25         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL021
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL021 = New ENT_APPL021(Me.DBManager, Me.LogUtil)
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

#Region "TAB_FILENAME 項目, REF. SYST010.SYS_KEY='TAB_FILENAME'"
        '' <summary>
        '' TAB_FILENAME 項目, REF. SYST010.SYS_KEY='TAB_FILENAME'
        '' </summary>
        Public Property TAB_FILENAME() As String
            Get
                Return Me.PropertyMap("TAB_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAB_FILENAME") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID 紀錄編號, 系統自動編號，排序用"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動編號，排序用
        '' </summary>
        Public Property TBL_RECID() As String
            Get
                Return Me.PropertyMap("TBL_RECID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TBL_RECID") = value
            End Set
        End Property
#End Region

#Region "MODIFY_DESC 修正意見"
        '' <summary>
        '' MODIFY_DESC 修正意見
        '' </summary>
        Public Property MODIFY_DESC() As String
            Get
                Return Me.PropertyMap("MODIFY_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MODIFY_DESC") = value
            End Set
        End Property
#End Region

#Region "M_PKNO 主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO"
        '' <summary>
        '' M_PKNO 主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO
        '' </summary>
        Public Property M_PKNO() As String
            Get
                Return Me.PropertyMap("M_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ 補正次數"
        '' <summary>
        '' CASE_SEQ 補正次數
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

#Region "Ent_APPL021"
        ' <summary>Ent_APPL021</ summary>
        Private Property Ent_APPL021() As ENT_APPL021
            Get
                Return Me.PropertyMap("Ent_APPL021")
            End Get
            Set(ByVal value As ENT_APPL021)
                Me.PropertyMap("Ent_APPL021") = value
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
                Me.Ent_APPL021.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL021.TAB_FILENAME = Me.TAB_FILENAME        '項目, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.Ent_APPL021.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號，排序用
                Me.Ent_APPL021.MODIFY_DESC = Me.MODIFY_DESC      '修正意見
                Me.Ent_APPL021.M_PKNO = Me.M_PKNO        '主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO
                Me.Ent_APPL021.CASE_SEQ = Me.CASE_SEQ      '補正次數

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL021.Insert()

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
                Me.Ent_APPL021.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL021.TAB_FILENAME = Me.TAB_FILENAME        '項目, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.Ent_APPL021.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號，排序用
                Me.Ent_APPL021.MODIFY_DESC = Me.MODIFY_DESC      '修正意見
                Me.Ent_APPL021.M_PKNO = Me.M_PKNO        '主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO
                Me.Ent_APPL021.CASE_SEQ = Me.CASE_SEQ      '補正次數

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL021.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL021.Update()

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
                Me.Ent_APPL021.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL021.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL021.Delete()
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
                Me.ProcessQueryCondition(condition, "%LIKE%", "TAB_FILENAME", Me.TAB_FILENAME)       '項目, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '紀錄編號, 系統自動編號，排序用
                Me.ProcessQueryCondition(condition, "%LIKE%", "MODIFY_DESC", Me.MODIFY_DESC)         '修正意見
                Me.ProcessQueryCondition(condition, "=", "M_PKNO", Me.M_PKNO)        '主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)      '補正次數

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APPL021.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL021.OrderBys = " TBL_RECID "
                Else
                    Me.Ent_APPL021.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL021.QueryJoin()
                Else
                    result = Me.Ent_APPL021.QueryJoin(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL021.TotalRowCount
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

