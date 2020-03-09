'----------------------------------------------------------------------------------
'File Name		: CtWriteQuestionary 
'Author			:  
'Description		: CtWriteQuestionary 填寫問卷Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1     2016/11/11       Source Create COPY FROM
'----------------------------------------------------------------------------------

Imports Que.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Que.Business
    ''' <summary>
    ''' CtWriteQuestionary 填寫問卷Ct
    ''' </summary>
    Partial Public Class CtWriteQuestionary
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "DATE 日期"
        ''' <summary>
        ''' DATE 日期
        ''' </summary>
        Public Property DATEE() As String
            Get
                Return Me.PropertyMap("DATEE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATEE") = value
            End Set
        End Property
#End Region

#Region "DEP_NAME 單位名稱"
        ''' <summary>
        ''' DEP_NAME 單位名稱
        ''' </summary>
        Public Property DEP_NAME() As String
            Get
                Return Me.PropertyMap("DEP_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEP_NAME") = value
            End Set
        End Property
#End Region

#Region "EntQuestionaryAnswer 問卷結果ENT"
        ''' <summary>
        ''' EntQuestionaryAnswer 問卷結果ENT
        ''' </summary>
        Private Property EntQuestionaryAnswer() As EntQuestionaryAnswer
            Get
                Return Me.PropertyMap("EntQuestionaryAmount")
            End Get
            Set(ByVal value As EntQuestionaryAnswer)
                Me.PropertyMap("EntQuestionaryAmount") = value
            End Set
        End Property
#End Region

#Region "NAME 姓名"
        ''' <summary>
        ''' NAME 姓名
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.PropertyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NAME") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_ANSWER_RES 問卷答案結果"
        ''' <summary>
        ''' QSTNNR_ANSWER_RES 問卷答案結果
        ''' </summary>
        Public Property QSTNNR_ANSWER_RES() As DataTable
            Get
                Return Me.PropertyMap("QSTNNR_ANSWER_RES")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("QSTNNR_ANSWER_RES") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_NO 問卷號碼"
        ''' <summary>
        ''' QSTNNR_NO 問卷號碼
        ''' </summary>
        Public Property QSTNNR_NO() As String
            Get
                Return Me.PropertyMap("QSTNNR_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_NO") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_TARGET_NO 問卷對象號碼"
        ''' <summary>
        ''' QSTNNR_TARGET_NO 問卷對象號碼
        ''' </summary>
        Public Property QSTNNR_TARGET_NO() As String
            Get
                Return Me.PropertyMap("QSTNNR_TARGET_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_TARGET_NO") = value
            End Set
        End Property
#End Region

#Region "SEG 時間"
        ''' <summary>
        ''' SEG 時間
        ''' </summary>
        Public Property SEG() As String
            Get
                Return Me.PropertyMap("SEG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SEG") = value
            End Set
        End Property
#End Region

#Region "SEX 性別"
        ''' <summary>
        ''' SEX 性別
        ''' </summary>
        Public Property SEX() As String
            Get
                Return Me.PropertyMap("SEX")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SEX") = value
            End Set
        End Property
#End Region

#Region "UNIT_NO 單位號碼"
        ''' <summary>
        ''' UNIT_NO 單位號碼
        ''' </summary>
        Public Property UNIT_NO() As String
            Get
                Return Me.PropertyMap("UNIT_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UNIT_NO") = value
            End Set
        End Property
#End Region

#Region "ID_TYPE 身分類別"
        ''' <summary>
        ''' ID_TYPE 身分類別
        ''' </summary>
        Public Property ID_TYPE() As String
            Get
                Return Me.PropertyMap("ID_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ID_TYPE") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_TITLE 問卷標題"
        ''' <summary>
        ''' QSTNNR_TITLE 問卷標題
        ''' </summary>
        Public Property QSTNNR_TITLE() As String
            Get
                Return Me.PropertyMap("QSTNNR_TITLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_TITLE") = value
            End Set
        End Property
#End Region

#Region "EMAIL EMAIL"
        ''' <summary>
        ''' EMAIL EMAIL
        ''' </summary>
        Public Property EMAIL() As String
            Get
                Return Me.PropertyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "CRRS_COMPANY_TEL 電話"
        ''' <summary>
        ''' M_CRRS_COMPANY_TEL 電話
        ''' </summary>
        Public Property CRRS_COMPANY_TEL() As String
            Get
                Return Me.PropertyMap("CRRS_COMPANY_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CRRS_COMPANY_TEL") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號"
        ''' <summary>
        ''' CASE_NO 案件編號
        ''' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "PAY_TYPE 案件類別"
        ''' <summary>
        ''' PAY_TYPE 案件類別
        ''' </summary>
        Public Property PAY_TYPE() As String
            Get
                Return Me.PropertyMap("PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "TEXT_CONTENT 文字內容"
        ''' <summary>
        ''' TEXT_CONTENT 文字內容
        ''' </summary>
        Public Property TEXT_CONTENT() As String
            Get
                Return Me.PropertyMap("TEXT_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TEXT_CONTENT") = value
            End Set
        End Property
#End Region

#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===
            Me.EntQuestionaryAnswer = New EntQuestionaryAnswer(Me.DBManager, Me.LogUtil)

        End Sub
#End Region

#Region "方法"
#Region "AddQuestionaryAnswer 新增問卷結果"
        ''' <summary>
        ''' 新增問卷結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddQuestionaryAnswer()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 姓名 ===
                'If String.IsNullOrEmpty(Me.NAME) Then
                '    faileArguments.Add("NAME")
                'End If
                ''=== 性別 ===
                'If String.IsNullOrEmpty(Me.SEX) Then
                '    faileArguments.Add("SEX")
                'End If
                '=== 問卷對象號碼 ===
                'If String.IsNullOrEmpty(Me.QSTNNR_TARGET_NO) Then
                '    faileArguments.Add("QSTNNR_TARGET_NO")
                'End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                '=== DT問卷選項 ===
                If Me.QSTNNR_ANSWER_RES Is Nothing Then
                    faileArguments.Add("QSTNNR_ANSWER_RES")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                ' 步驟1.先檢核傳入table的欄位跟型態()

                '2:新增問卷結果主檔()
                '3:.將問卷答案結果屬性設定並新增問卷答案結果()
                EntQuestionaryAnswer.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryAnswer.UNIT_NO = Me.UNIT_NO
                EntQuestionaryAnswer.DEP_NAME = Me.DEP_NAME
                EntQuestionaryAnswer.ID_TYPE = Me.ID_TYPE
                EntQuestionaryAnswer.QSTNNR_TARGET_NO = Me.QSTNNR_TARGET_NO
                EntQuestionaryAnswer.NAME = Me.NAME
                EntQuestionaryAnswer.CASE_NO = Me.CASE_NO
                EntQuestionaryAnswer.PAY_TYPE = Me.PAY_TYPE
                EntQuestionaryAnswer.TEXT_CONTENT = Me.TEXT_CONTENT
                'EntQuestionaryAnswer.SEX = Me.SEX           
                EntQuestionaryAnswer.Insert()

                For i As Integer = 0 To Me.QSTNNR_ANSWER_RES.Rows.Count - 1

                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.QSTNNR_NO = QSTNNR_ANSWER_RES.Rows(i)("QSTNNR_NO").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.SUBJECT_NO = QSTNNR_ANSWER_RES.Rows(i)("SUBJECT_NO").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.MENU_NO = QSTNNR_ANSWER_RES.Rows(i)("MENU_NO").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.ID_TYPE = QSTNNR_ANSWER_RES.Rows(i)("ID_TYPE").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.CASE_NO = QSTNNR_ANSWER_RES.Rows(i)("CASE_NO").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.QSTNNR_TARGET_NO = Me.QSTNNR_TARGET_NO
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.TEXT_CONTENT = QSTNNR_ANSWER_RES.Rows(i)("TEXT_CONTENT").ToString
                    EntQuestionaryAnswer.EntQuestionaryAnswerAmount.Insert()
                Next


                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetQuestionaryObj 查詢問卷對象資料內網"
        ''' <summary>
        ''' 查詢問卷對象資料內網 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryObj() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntQuestionary NEW EntQuestionary()
                '
                '組合查詢字串(
                'EntQuestionary.QUERY_COND(查詢條件),"=",QSTNNR_TARGET_NO(問卷對象號碼))
                '
                'EntQuestionary.QUERY_COND(查詢條件)=me.組合查詢字串
                '+ START_DATE(開始日期)+START_TIME(開始時間)>=日期時間
                '   DEADLINE_DATE(截止日期)+DEADLINE_TIME(截止時間)>=日期時間
                '
                '
                'EntQuestionary.QueryQuestionaryObj()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO", Me.QSTNNR_TARGET_NO)       '問卷對象號碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "QSTNNR_TITLE", Me.QSTNNR_TITLE)           '問卷標題   20160628
                'Me.ProcessQueryCondition(condition, "<=", "START_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))     '開始日期
                'Me.ProcessQueryCondition(condition, ">=", "DEADLINE_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))   '截止日期
                condition.Append(" AND ((")
                condition.Append("$.START_DATE <='" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "'")
                condition.Append(" AND $.DEADLINE_DATE  >='" & Now.ToString("yyyy/MM/dd ") & "'")
                condition.Append("))")
                Me.EntQuestionaryAnswer.SqlRetrictions = condition.ToString()

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = Me.EntQuestionaryAnswer.QueryQuestionaryObj
                Else
                    result = Me.EntQuestionaryAnswer.QueryQuestionaryObj(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryAnswer.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryObjOut 查詢問卷對象資料外網"
        ''' <summary>
        ''' 查詢問卷對象資料外網 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryObjOut() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()


                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntQuestionary NEW EntQuestionary()
                '
                '組合查詢字串(
                'EntQuestionary.QUERY_COND(查詢條件)," <> ",QSTNNR_TARGET_NO(問卷對象號碼))
                '
                'EntQuestionary.QUERY_COND(查詢條件)=me.組合查詢字串
                '+ START_DATE(開始日期)+START_TIME(開始時間)>=DATE(日期)+SEG(時間)
                '   DEADLINE_DATE(截止日期)+DEADLINE_TIME(截止時間)>=DATE(日期)+SEG(時間)
                '+IS_ANNOUNCE_OUTER(是否發佈校外)=1
                '
                'EntQuestionary.QueryQuestionaryObj()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "%LIKE%", "QSTNNR_TITLE", Me.QSTNNR_TITLE)           '問卷標題  20160628
                '  Me.ProcessQueryCondition(condition, "<=", "START_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))     '開始日期
                '  Me.ProcessQueryCondition(condition, ">=", "DEADLINE_DATE", Now.ToString("yyyy/MM/dd HH:mm:ss"))   '截止日期
                Me.ProcessQueryCondition(condition, "=", "IS_ANNOUNCE_OUTER", "1")           '是否發佈校外
                condition.Append(" AND ((")
                'condition.Append("$.START_DATE <='" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "'")
                'condition.Append(" AND $.DEADLINE_DATE >='" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "'")

                'condition.Append(" ) OR (")

                condition.Append("$.UPDRAFT_DATE <='" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "'")
                'condition.Append(" AND $.DODRAFT_DATE  >='" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "'")  20160701判斷多了_時_分_秒 導致截止日期會提前一天
                condition.Append(" AND $.DODRAFT_DATE  >='" & Now.ToString("yyyy/MM/dd") & "'")
                condition.Append("))")
                EntQuestionaryAnswer.IS_ANNOUNCE_OUTER = "1"

                EntQuestionaryAnswer.SqlRetrictions = condition.ToString()

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = Me.EntQuestionaryAnswer.QueryQuestionaryObj
                Else
                    result = Me.EntQuestionaryAnswer.QueryQuestionaryObj(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryAnswer.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryAnswer 取得問卷結果"
        ''' <summary>
        ''' 取得問卷結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryAnswer() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)                     '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO", Me.QSTNNR_TARGET_NO)       '問卷對象號碼
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)       '問卷案件編號
                Me.ProcessQueryCondition(condition, "=", "PAY_TYPE", Me.PAY_TYPE)       '問卷案件類別
                Me.ProcessQueryCondition(condition, "=", "ID_TYPE", Me.ID_TYPE)       '問卷案件類別

                EntQuestionaryAnswer.SqlRetrictions = condition.ToString()

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = Me.EntQuestionaryAnswer.Query
                Else
                    result = Me.EntQuestionaryAnswer.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryAnswer.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteQuestionaryAnswer 刪除問卷結果"
        ''' <summary>
        ''' 刪除問卷結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 2011/05/03 政諺 新增方法
        ''' </remarks>
        Public Sub DeleteQuestionaryAnswer()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷對象號碼 ===
                'If String.IsNullOrEmpty(Me.QSTNNR_TARGET_NO) Then
                '    faileArguments.Add("QSTNNR_TARGET_NO")
                'End If
                '=== 問卷號碼 ===
                'If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                '    faileArguments.Add("QSTNNR_NO")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                Dim tmpQSTNNR_TARGET_NO As String = QSTNNR_TARGET_NO
                Dim tmpQSTNNR_NO As String = QSTNNR_NO
                Dim tmpCASE_NO As String = CASE_NO
                Dim tmpID_TYPE As String = ID_TYPE
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO", QSTNNR_TARGET_NO)
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", tmpQSTNNR_NO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", tmpCASE_NO)
                Me.ProcessQueryCondition(condition, "=", "ID_TYPE", tmpID_TYPE)
                '=== 處理說明 ===
                '//刪除問卷結果QUET060
                Dim AEntQuestionaryAnswer As New EntQuestionaryAnswer(Me.DBManager, Me.LogUtil)
                AEntQuestionaryAnswer.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                AEntQuestionaryAnswer.Delete()
                '//刪除問卷答案結果QUET070
                AEntQuestionaryAnswer.QSTNNR_NO = tmpQSTNNR_NO
                AEntQuestionaryAnswer.QSTNNR_TARGET_NO = tmpQSTNNR_TARGET_NO
                AEntQuestionaryAnswer.CASE_NO = tmpCASE_NO
                AEntQuestionaryAnswer.ID_TYPE = tmpID_TYPE
                AEntQuestionaryAnswer.DeleteQuestionaryAnswerAmount() '刪除問卷答案結果()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region
#End Region
    End Class
End Namespace


