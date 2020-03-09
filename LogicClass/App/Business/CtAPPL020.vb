'ProductName                 : TSBA 
'File Name					 : CtAPPL020 
'Description	             : CtAPPL020  
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/20         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL020
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL020 = New ENT_APPL020(Me.DBManager, Me.LogUtil)
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

#Region "COM_PKNO 業者PKNO"
        '' <summary>
        '' COM_PKNO 業者PKNO
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.PropertyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE 業務代號"
        '' <summary>
        '' CASE_CODE 業務代號, 
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

#Region "DEL_FLAG 刪除註記"
        '' <summary>
        '' DEL_FLAG 刪除註記, 
        '' </summary>
        Public Property DEL_FLAG() As String
            Get
                Return Me.PropertyMap("DEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CASE_STATUS 案件進度"
        '' <summary>
        '' CASE_STATUS 案件進度, 
        '' </summary>
        Public Property CASE_STATUS() As String
            Get
                Return Me.PropertyMap("CASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "RESULT1 初審審查結果"
        '' <summary>
        '' RESULT1 初審審查結果, 
        '' </summary>
        Public Property RESULT1() As String
            Get
                Return Me.PropertyMap("RESULT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DATE 初審審查完成日期"
        '' <summary>
        '' RESULT1_DATE 初審審查完成日期
        '' </summary>
        Public Property RESULT1_DATE() As String
            Get
                Return Me.PropertyMap("RESULT1_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DESC 初審意見"
        '' <summary>
        '' RESULT1_DESC 初審意見
        '' </summary>
        Public Property RESULT1_DESC() As String
            Get
                Return Me.PropertyMap("RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT2 諮詢委員會議審查結果"
        '' <summary>
        '' RESULT2 諮詢委員會議審查結果, 
        '' </summary>
        Public Property RESULT2() As String
            Get
                Return Me.PropertyMap("RESULT2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DATE 諮詢委員會議審查完成日期"
        '' <summary>
        '' RESULT2_DATE 諮詢委員會議審查完成日期
        '' </summary>
        Public Property RESULT2_DATE() As String
            Get
                Return Me.PropertyMap("RESULT2_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DESC 諮詢委員會議審查意見"
        '' <summary>
        '' RESULT2_DESC 諮詢委員會議審查意見
        '' </summary>
        Public Property RESULT2_DESC() As String
            Get
                Return Me.PropertyMap("RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT3 本會委員會議審查結果"
        '' <summary>
        '' RESULT3 本會委員會議審查結果, 
        '' </summary>
        Public Property RESULT3() As String
            Get
                Return Me.PropertyMap("RESULT3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DATE 本會委員會議審查完成日期"
        '' <summary>
        '' RESULT3_DATE 本會委員會議審查完成日期
        '' </summary>
        Public Property RESULT3_DATE() As String
            Get
                Return Me.PropertyMap("RESULT3_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DESC 本會委員會議審查意見"
        '' <summary>
        '' RESULT3_DESC 本會委員會議審查意見
        '' </summary>
        Public Property RESULT3_DESC() As String
            Get
                Return Me.PropertyMap("RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3_DESC") = value
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

#Region "LICENSE_NO 執照號碼"
        '' <summary>
        '' LICENSE_NO 執照號碼
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.PropertyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "CHANG_LICENSE_DATE 換照日期"
        '' <summary>
        '' CHANG_LICENSE_DATE 換照日期
        '' </summary>
        Public Property CHANG_LICENSE_DATE() As String
            Get
                Return Me.PropertyMap("CHANG_LICENSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANG_LICENSE_DATE") = value
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


#Region "APV_DATE 初次送審NCC時間"
        '' <summary>
        '' APV_DATE 初次送審NCC時間
        '' </summary>
        Public Property APV_DATE() As String
            Get
                Return Me.PropertyMap("APV_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APV_DATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL020"
        ' <summary>Ent_APPL020</ summary>
        Private Property Ent_APPL020() As ENT_APPL020
            Get
                Return Me.PropertyMap("Ent_APPL020")
            End Get
            Set(ByVal value As ENT_APPL020)
                Me.PropertyMap("Ent_APPL020") = value
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
                Me.Ent_APPL020.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL020.CASE_SEQ = Me.CASE_SEQ        '補正次數
                Me.Ent_APPL020.COM_PKNO = Me.COM_PKNO        '業者PKNO
                Me.Ent_APPL020.CASE_CODE = Me.CASE_CODE      '業務代號
                Me.Ent_APPL020.DEL_FLAG = Me.DEL_FLAG        '刪除註記
                Me.Ent_APPL020.CASE_STATUS = Me.CASE_STATUS      '案件進度
                Me.Ent_APPL020.RESULT1 = Me.RESULT1      '初審審查結果
                Me.Ent_APPL020.RESULT1_DATE = Me.RESULT1_DATE        '初審審查完成日期
                Me.Ent_APPL020.RESULT1_DESC = Me.RESULT1_DESC         '初審意見
                Me.Ent_APPL020.RESULT2 = Me.RESULT2      '諮詢委員會議審查結果
                Me.Ent_APPL020.RESULT2_DATE = Me.RESULT2_DATE        '諮詢委員會議審查完成日期
                Me.Ent_APPL020.RESULT2_DESC = Me.RESULT2_DESC         '諮詢委員會議審查意見
                Me.Ent_APPL020.RESULT3 = Me.RESULT3      '本會委員會議審查結果
                Me.Ent_APPL020.RESULT3_DATE = Me.RESULT3_DATE        '本會委員會議審查完成日期
                Me.Ent_APPL020.RESULT3_DESC = Me.RESULT3_DESC        '本會委員會議審查意見
                Me.Ent_APPL020.CREATE_USER = Me.CREATE_USER      '資料建立者
                Me.Ent_APPL020.CREATE_DATE = Me.CREATE_DATE        '資料建立日期
                Me.Ent_APPL020.UPDATE_USER = Me.UPDATE_USER        '資料維護者
                Me.Ent_APPL020.UPDATE_DATE = Me.UPDATE_DATE        '資料維護日期
                Me.Ent_APPL020.LICENSE_NO = Me.LICENSE_NO        '執照號碼
                Me.Ent_APPL020.CHANG_LICENSE_DATE = Me.CHANG_LICENSE_DATE        '換照日期
                Me.Ent_APPL020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '會辦意見
                Me.Ent_APPL020.APV_DATE = Me.APV_DATE

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL020.Insert()

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
                Me.Ent_APPL020.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL020.CASE_SEQ = Me.CASE_SEQ        '補正次數
                Me.Ent_APPL020.COM_PKNO = Me.COM_PKNO        '業者PKNO
                Me.Ent_APPL020.CASE_CODE = Me.CASE_CODE      '業務代號
                Me.Ent_APPL020.DEL_FLAG = Me.DEL_FLAG        '刪除註記
                Me.Ent_APPL020.CASE_STATUS = Me.CASE_STATUS      '案件進度
                Me.Ent_APPL020.RESULT1 = Me.RESULT1      '初審審查結果
                Me.Ent_APPL020.RESULT1_DATE = Me.RESULT1_DATE        '初審審查完成日期
                Me.Ent_APPL020.RESULT1_DESC = Me.RESULT1_DESC         '初審意見
                Me.Ent_APPL020.RESULT2 = Me.RESULT2      '諮詢委員會議審查結果
                Me.Ent_APPL020.RESULT2_DATE = Me.RESULT2_DATE        '諮詢委員會議審查完成日期
                Me.Ent_APPL020.RESULT2_DESC = Me.RESULT2_DESC         '諮詢委員會議審查意見
                Me.Ent_APPL020.RESULT3 = Me.RESULT3      '本會委員會議審查結果
                Me.Ent_APPL020.RESULT3_DATE = Me.RESULT3_DATE        '本會委員會議審查完成日期
                Me.Ent_APPL020.RESULT3_DESC = Me.RESULT3_DESC        '本會委員會議審查意見
                Me.Ent_APPL020.CREATE_USER = Me.CREATE_USER      '資料建立者
                Me.Ent_APPL020.CREATE_DATE = Me.CREATE_DATE        '資料建立日期
                Me.Ent_APPL020.UPDATE_USER = Me.UPDATE_USER        '資料維護者
                Me.Ent_APPL020.UPDATE_DATE = Me.UPDATE_DATE        '資料維護日期
                Me.Ent_APPL020.LICENSE_NO = Me.LICENSE_NO        '執照號碼
                Me.Ent_APPL020.CHANG_LICENSE_DATE = Me.CHANG_LICENSE_DATE        '換照日期
                Me.Ent_APPL020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '會辦意見
                Me.Ent_APPL020.APV_DATE = Me.APV_DATE

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL020.Update()

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
                Me.Ent_APPL020.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL020.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL020.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '業者PKNO
                If Not String.IsNullOrEmpty(Me.CASE_CODE) Then
                    condition.Append(" AND $.CASE_CODE IN ('" & Me.CASE_CODE.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "IN", "CASE_CODE", Me.CASE_CODE)      '業務代號
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '刪除註記
                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND $.CASE_STATUS IN ('" & Me.CASE_STATUS.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS)      '案件進度
                Me.ProcessQueryCondition(condition, "=", "RESULT1", Me.RESULT1)      '初審審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT1_DATE", Me.RESULT1_DATE)        '初審審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT1_DESC", Me.RESULT1_DESC)       '初審意見
                Me.ProcessQueryCondition(condition, "=", "RESULT2", Me.RESULT2)      '諮詢委員會議審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT2_DATE", Me.RESULT2_DATE)        '諮詢委員會議審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT2_DESC", Me.RESULT2_DESC)       '諮詢委員會議審查意見
                Me.ProcessQueryCondition(condition, "=", "RESULT3", Me.RESULT3)      '本會委員會議審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT3_DATE", Me.RESULT3_DATE)        '本會委員會議審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT3_DESC", Me.RESULT3_DESC)       '本會委員會議審查意見
                Me.ProcessQueryCondition(condition, "=", "CREATE_USER", Me.CREATE_USER)      '資料建立者
                Me.ProcessQueryCondition(condition, "=", "CREATE_DATE", Me.CREATE_DATE)      '資料建立日期
                Me.ProcessQueryCondition(condition, "=", "UPDATE_USER", Me.UPDATE_USER)      '資料維護者
                Me.ProcessQueryCondition(condition, "=", "UPDATE_DATE", Me.UPDATE_DATE)      '資料維護日期
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '執照號碼
                Me.ProcessQueryCondition(condition, "=", "CHANG_LICENSE_DATE", Me.CHANG_LICENSE_DATE)        '換照日期
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC) '會辦意見
                Me.ProcessQueryCondition(condition, "=", "APV_DATE", Me.APV_DATE) '會辦意見


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.Query()
                Else
                    result = Me.Ent_APPL020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        '' <summary>
        '' Web Servie進行查詢動作
        '' </summary>
        Public Function DoQuery_WS() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                If Me.CASE_NO.Length > 0 Then
                    Me.Ent_APPL020.CASE_NO = Me.CASE_NO
                End If
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '補正次數
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '業者PKNO
                If Not String.IsNullOrEmpty(Me.CASE_CODE) Then
                    condition.Append(" AND $.CASE_CODE IN ('" & Me.CASE_CODE.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "IN", "CASE_CODE", Me.CASE_CODE)      '業務代號
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '刪除註記
                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND $.CASE_STATUS IN ('" & Me.CASE_STATUS.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS)      '案件進度
                Me.ProcessQueryCondition(condition, "=", "RESULT1", Me.RESULT1)      '初審審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT1_DATE", Me.RESULT1_DATE)        '初審審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT1_DESC", Me.RESULT1_DESC)       '初審意見
                Me.ProcessQueryCondition(condition, "=", "RESULT2", Me.RESULT2)      '諮詢委員會議審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT2_DATE", Me.RESULT2_DATE)        '諮詢委員會議審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT2_DESC", Me.RESULT2_DESC)       '諮詢委員會議審查意見
                Me.ProcessQueryCondition(condition, "=", "RESULT3", Me.RESULT3)      '本會委員會議審查結果
                Me.ProcessQueryCondition(condition, "=", "RESULT3_DATE", Me.RESULT3_DATE)        '本會委員會議審查完成日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT3_DESC", Me.RESULT3_DESC)       '本會委員會議審查意見
                Me.ProcessQueryCondition(condition, "=", "CREATE_USER", Me.CREATE_USER)      '資料建立者
                Me.ProcessQueryCondition(condition, "=", "CREATE_DATE", Me.CREATE_DATE)      '資料建立日期
                Me.ProcessQueryCondition(condition, "=", "UPDATE_USER", Me.UPDATE_USER)      '資料維護者
                Me.ProcessQueryCondition(condition, "=", "UPDATE_DATE", Me.UPDATE_DATE)      '資料維護日期
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '執照號碼
                Me.ProcessQueryCondition(condition, "=", "CHANG_LICENSE_DATE", Me.CHANG_LICENSE_DATE)        '換照日期
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC) '會辦意見
                Me.ProcessQueryCondition(condition, "=", "APV_DATE", Me.APV_DATE) '會辦意見


                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.Query_WS(0, 0)
                Else
                    result = Me.Ent_APPL020.Query_WS(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function GetCaseList() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 處理查詢條件 ===                 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '補正次數
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '業者PKNO
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '刪除註記

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL020.QueryCaseList()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "用案號查詢機構類型 QueryOrgTypeByCaseNo"
        Public Function QueryOrgTypeByCaseNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO)      '案件編號

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.QueryOrgTypeByCaseNo()
                Else
                    result = Me.Ent_APPL020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "查出公司相關資料BY CASE_NO"
        ''' <summary>
        ''' 查出公司相關資料BY CASE_NO
        ''' type = APP120324:串頻道名稱
        ''' type = APP120705:純查統編
        ''' </summary>
        Public Function GetCompanyDataByCASE_NO(Optional type As String = "") As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '案件編號

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetCompanyDataByCASE_NO(type)

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "串公文介接案號的主旨"
        ''' <summary>
        ''' 取SYS_PRTID
        ''' </summary>
        Public Function GetSYSID() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '案件編號
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '補正次數

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSYSID()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function GetSubject_Type01() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '案件編號
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '補正次數

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSubject_Type01()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        'Public Function GetSubject_Type02() As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()

        '        '=== 處理查詢條件 === 
        '        Dim condition As StringBuilder = New StringBuilder()
        '        Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '案件編號
        '        Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '補正次數

        '        '特殊條件 OR 自定條件              
        '        condition.Append(Me.QUERY_COND)
        '        Me.Ent_APPL020.SqlRetrictions = condition.ToString()

        '        '=== 處理取得回傳資料===
        '        Dim result As DataTable
        '        result = Me.Ent_APPL020.GetSubject_Type02()

        '        Me.ResetColumnProperty()

        '        Return result
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function

        Public Function GetSubject_Type03() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '案件編號
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '補正次數

                '特殊條件 OR 自定條件              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSubject_Type03()

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

