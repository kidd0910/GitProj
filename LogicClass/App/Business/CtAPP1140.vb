'ProductName                 : TSBA 
'File Name					 : CtAPP1140 
'Description	             : CtAPP1140 改善/改正/承諾/行政處份事項
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/12         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1140
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1140 = New ENT_APP1140(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號, 共用"
        '' <summary>
        '' CASE_NO 案件編號, 共用
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

#Region "COMPLY_TYPE 類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用"
        '' <summary>
        '' COMPLY_TYPE 類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用
        '' </summary>
        Public Property COMPLY_TYPE() As String
            Get
                Return Me.PropertyMap("COMPLY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLY_TYPE") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID 紀錄編號, 系統自動給號程式不須處理, 共用"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動給號程式不須處理, 共用
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

#Region "COMPLY_DESC 執行事項及辦理情形說明"
        '' <summary>
        '' COMPLY_DESC 執行事項及辦理情形說明
        '' </summary>
        Public Property COMPLY_DESC() As String
            Get
                Return Me.PropertyMap("COMPLY_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLY_DESC") = value
            End Set
        End Property
#End Region

#Region "COMPLY_RESULT 執行情形, REF.SYS_KEY='COMPLY_RESULT'"
        '' <summary>
        '' COMPLY_RESULT 執行情形, REF.SYS_KEY='COMPLY_RESULT'
        '' </summary>
        Public Property COMPLY_RESULT() As String
            Get
                Return Me.PropertyMap("COMPLY_RESULT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLY_RESULT") = value
            End Set
        End Property
#End Region

#Region "PAGE_NO 附件頁碼"
        '' <summary>
        '' PAGE_NO 附件頁碼
        '' </summary>
        Public Property PAGE_NO() As String
            Get
                Return Me.PropertyMap("PAGE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAGE_NO") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_ITEM 違規事項/附款或應改善事項內容, 廣播用"
        '' <summary>
        '' IMPROVE_ITEM 違規事項/附款或應改善事項內容, 廣播用
        '' </summary>
        Public Property IMPROVE_ITEM() As String
            Get
                Return Me.PropertyMap("IMPROVE_ITEM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IMPROVE_ITEM") = value
            End Set
        End Property
#End Region

#Region "VIOLATION_ACT 違反之法令, 廣播用"
        '' <summary>
        '' VIOLATION_ACT 違反之法令, 廣播用
        '' </summary>
        Public Property VIOLATION_ACT() As String
            Get
                Return Me.PropertyMap("VIOLATION_ACT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VIOLATION_ACT") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_DESC 改善情形"
        '' <summary>
        '' IMPROVE_DESC 改善情形
        '' </summary>
        Public Property IMPROVE_DESC() As String
            Get
                Return Me.PropertyMap("IMPROVE_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IMPROVE_DESC") = value
            End Set
        End Property
#End Region

#Region "REMARK 備註"
        '' <summary>
        '' REMARK 備註
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.PropertyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1140"
        ' <summary>Ent_APP1140</ summary>
        Private Property Ent_APP1140() As ENT_APP1140
            Get
                Return Me.PropertyMap("Ent_APP1140")
            End Get
            Set(ByVal value As ENT_APP1140)
                Me.PropertyMap("Ent_APP1140") = value
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
                Me.Ent_APP1140.CASE_NO = Me.CASE_NO      '案件編號, 共用
                Me.Ent_APP1140.COMPLY_TYPE = Me.COMPLY_TYPE      '類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用
                Me.Ent_APP1140.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動給號程式不須處理, 共用
                Me.Ent_APP1140.COMPLY_DESC = Me.COMPLY_DESC      '執行事項及辦理情形說明
                Me.Ent_APP1140.COMPLY_RESULT = Me.COMPLY_RESULT      '執行情形, REF.SYS_KEY='COMPLY_RESULT'
                Me.Ent_APP1140.PAGE_NO = Me.PAGE_NO      '附件頁碼
                Me.Ent_APP1140.IMPROVE_ITEM = Me.IMPROVE_ITEM        '違規事項/附款或應改善事項內容, 廣播用
                Me.Ent_APP1140.VIOLATION_ACT = Me.VIOLATION_ACT      '違反之法令, 廣播用
                Me.Ent_APP1140.IMPROVE_DESC = Me.IMPROVE_DESC        '改善情形
                Me.Ent_APP1140.REMARK = Me.REMARK        '備註


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1140.Insert()

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
                Me.Ent_APP1140.CASE_NO = Me.CASE_NO      '案件編號, 共用
                Me.Ent_APP1140.COMPLY_TYPE = Me.COMPLY_TYPE      '類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用
                Me.Ent_APP1140.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動給號程式不須處理, 共用
                Me.Ent_APP1140.COMPLY_DESC = Me.COMPLY_DESC      '執行事項及辦理情形說明
                Me.Ent_APP1140.COMPLY_RESULT = Me.COMPLY_RESULT      '執行情形, REF.SYS_KEY='COMPLY_RESULT'
                Me.Ent_APP1140.PAGE_NO = Me.PAGE_NO      '附件頁碼
                Me.Ent_APP1140.IMPROVE_ITEM = Me.IMPROVE_ITEM        '違規事項/附款或應改善事項內容, 廣播用
                Me.Ent_APP1140.VIOLATION_ACT = Me.VIOLATION_ACT      '違反之法令, 廣播用
                Me.Ent_APP1140.IMPROVE_DESC = Me.IMPROVE_DESC        '改善情形
                Me.Ent_APP1140.REMARK = Me.REMARK        '備註



                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1140.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1140.Update()

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
                Me.Ent_APP1140.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1140.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1140.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, 共用
                Me.ProcessQueryCondition(condition, "=", "COMPLY_TYPE", Me.COMPLY_TYPE)      '類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '紀錄編號, 系統自動給號程式不須處理, 共用
                Me.ProcessQueryCondition(condition, "%LIKE%", "COMPLY_DESC", Me.COMPLY_DESC)         '執行事項及辦理情形說明
                Me.ProcessQueryCondition(condition, "=", "COMPLY_RESULT", Me.COMPLY_RESULT)      '執行情形, REF.SYS_KEY='COMPLY_RESULT'
                Me.ProcessQueryCondition(condition, "=", "PAGE_NO", Me.PAGE_NO)      '附件頁碼
                Me.ProcessQueryCondition(condition, "=", "IMPROVE_ITEM", Me.IMPROVE_ITEM)        '違規事項/附款或應改善事項內容, 廣播用
                Me.ProcessQueryCondition(condition, "=", "VIOLATION_ACT", Me.VIOLATION_ACT)      '違反之法令, 廣播用
                Me.ProcessQueryCondition(condition, "%LIKE%", "IMPROVE_DESC", Me.IMPROVE_DESC)       '改善情形
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '備註

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_APP1140.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1140.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1140.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1140.QueryCData()
                Else
                    result = Me.Ent_APP1140.QueryCData(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1140.TotalRowCount
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

