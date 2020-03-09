'----------------------------------------------------------------------------------
'File Name		: CtProcessQuestionary 
'Author			:  
'Description		: CtProcessQuestionary 處理問卷Ct
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
    ''' CtProcessQuestionary 處理問卷Ct
    ''' </summary>
    Partial Public Class CtProcessQuestionary
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "CtQuestionary 問卷Ct"
        ''' <summary>
        ''' CtQuestionary 問卷Ct
        ''' </summary>
        Public Property CtQuestionary() As String
            Get
                Return Me.PropertyMap("CtQuestionary")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CtQuestionary") = value
            End Set
        End Property
#End Region

#Region "EntQuestionaryAmount 問卷結果ENT"
        ''' <summary>
        ''' EntQuestionaryAmount 問卷結果ENT
        ''' </summary>
        Private Property EntQuestionaryAnswer() As EntQuestionaryAnswer
            Get
                Return Me.PropertyMap("	EntQuestionaryAnswer")
            End Get
            Set(ByVal value As EntQuestionaryAnswer)
                Me.PropertyMap("	EntQuestionaryAnswer") = value
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

#Region "STATUS 狀態"
        ''' <summary>
        ''' STATUS 狀態
        ''' </summary>
        Public Property STATUS() As String
            Get
                Return Me.PropertyMap("STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("STATUS") = value
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


#Region "SUBJECT_NO 題目號碼"
        ''' <summary>
        ''' SUBJECT_NO 題目號碼
        ''' </summary>
        Public Property SUBJECT_NO() As String
            Get
                Return Me.PropertyMap("SUBJECT_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_NO") = value
            End Set
        End Property
#End Region

#Region "MENU_NO 選單號碼"
        ''' <summary>
        ''' MENU_NO 選單號碼
        ''' </summary>
        Public Property MENU_NO() As String
            Get
                Return Me.PropertyMap("MENU_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MENU_NO") = value
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
#Region "GetQuestionaryConditional 取得填寫情形表"
        ''' <summary>
        ''' 取得填寫情形表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryConditional() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO) '案件編號

                Me.EntQuestionaryAnswer.SqlRetrictions = condition.ToString()

                Dim ruslt As DataTable = New DataTable
                '=== 處理說明 ===
                'EntQuestionaryAnswer =New EntQuestionaryAnswer
                '
                'EntQuestionaryAnswer.QueryQuestionaryConditional()
                If PageNo = 0 Then
                    ruslt = Me.EntQuestionaryAnswer.QueryQuestionaryConditional()
                Else
                    ruslt = Me.EntQuestionaryAnswer.QueryQuestionaryConditional(PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryAnswer.TotalRowCount
                End If
                Me.ResetColumnProperty()
                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryRecord 取得填答記錄表"
        ''' <summary>
        ''' 取得填答記錄表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetQuestionaryRecord() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                Dim ruslt As DataTable = New DataTable
                '=== 檢核欄位結束 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "UNIT_NO", Me.UNIT_NO) '問卷號碼

                Me.EntQuestionaryAnswer.SqlRetrictions = " 1=1  " & condition.ToString.Replace("$.", "A.")


                '=== 處理說明 ===
                'EntQuestionaryAnswer =New EntQuestionaryAnswer
                '
                If PageNo = 0 Then
                    ruslt = EntQuestionaryAnswer.QueryQuestionaryRecord()
                Else
                    ruslt = EntQuestionaryAnswer.QueryQuestionaryRecord(PageNo, PageSize)
                    Me.TotalRowCount = EntQuestionaryAnswer.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryStatistics 取得問卷題目填答統計表"
        ''' <summary>
        ''' 取得問卷題目填答統計表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryStatistics() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼

                Me.EntQuestionaryAnswer.SqlRetrictions = " 1=1  " & condition.ToString.Replace("$.", "A.")


                '=== 處理說明 ===
                'EntQuestionaryAnswer =New EntQuestionaryAnswer
                '
                Dim ruslt As DataTable = New DataTable
                If Me.PageNo = 0 Then
                    ruslt = EntQuestionaryAnswer.QueryQuestionaryStatistics()

                Else
                    ruslt = EntQuestionaryAnswer.QueryQuestionaryStatistics(PageNo, PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryAnswer.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryAnRate 查詢各題答題率"
        ''' <summary>
        ''' 查詢各題答題率 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryAnRate() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                '建立回傳的DT
                Dim ReturnDt As DataTable = New DataTable
                ReturnDt.Columns.Add(New DataColumn("NUM", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("SUBJECT_CONTENT", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("ANSWER_PERCENT", System.Type.GetType("System.String")))
                Dim qQSTNNR_NO As String = Me.QSTNNR_NO
                Dim CtQuestionary As CtQuestionary = New CtQuestionary(DBManager, LogUtil)
                CtQuestionary.QSTNNR_NO = Me.QSTNNR_NO
                Dim dt As DataTable = CtQuestionary.GetQuestionaryHeading()

                For icount As Integer = 0 To dt.Rows.Count - 1
                    Dim condition As StringBuilder = New StringBuilder()
                    Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                    Me.EntQuestionaryAnswer.SqlRetrictions = " 1=1  " & condition.ToString.Replace("$.", "")
                    Dim a As Integer = EntQuestionaryAnswer.QueryQuestionaryObjCount
                    condition.Length = 0
                    Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                    Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", dt.Rows(icount)("SUBJECT_NO")) '題目號碼

                    Me.EntQuestionaryAnswer.SqlRetrictions = " 1=1  " & condition.ToString.Replace("$.", "")

                    Dim b As Integer = EntQuestionaryAnswer.QueryQuestionaryAnswerCount

                    Dim nRow As DataRow = ReturnDt.NewRow
                    Dim ANSWER_PERCENT As Double = 0
                    If a = 0 Or b = 0 Then
                        ANSWER_PERCENT = 0
                    Else
                        ANSWER_PERCENT = Math.Round(b / a, 2).ToString
                    End If
                    nRow("NUM") = (icount + 1).ToString
                    nRow("SUBJECT_CONTENT") = dt.Rows(icount)("SUBJECT_CONTENT")
                    nRow("ANSWER_PERCENT") = ANSWER_PERCENT
                    ReturnDt.Rows.Add(nRow)
                Next
                '=== 處理說明 ===
                '先取得該張問卷所有題目
                'DT=CtQuestionary_問卷Ct.GetQuestionaryHeading_取得題目()
                '
                '根據每個題目去抓取問卷對象人數跟問卷結果人數
                '計算答題率
                '
                'EntQuestionaryAnswer = New EntQuestionaryAnswer
                '
                'A=EntQuestionaryAnswer.QueryQuestionaryObjCount
                'B=EntQuestionaryAnswer.QueryQuestionaryAnswerCount
                '答題率=B/A
                '
                '4.依照每題的題目內容跟答題率組成DateTable
                '如果分母為0或是分子為0一樣新增一筆DataTable

                Me.ResetColumnProperty()
                Return ReturnDt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryAvg 查詢各題平均值"
        ''' <summary>
        ''' 查詢各題平均值 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryAvg() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '1. 先取得本問卷有多少題目選項
                'CtProcessQuestionary_處理問卷Ct.QueryHeadingItem_查詢問卷題目選項()
                Dim condition2 As StringBuilder = New StringBuilder()

                Me.EntQuestionaryAnswer.QSTNNR_NO = Me.QSTNNR_NO
                Me.ProcessQueryCondition(condition2, "=", "QSTNNR_NO", QSTNNR_NO) '問卷號碼
                EntQuestionaryAnswer.SqlRetrictions = condition2.ToString.Replace("$.QSTNNR_NO", "A.QSTNNR_NO")

                Dim dt As DataTable = Me.EntQuestionaryAnswer.QueryHeadingItem()
                '建立回傳的DT
                Dim ReturnDt As DataTable = New DataTable
                ReturnDt.Columns.Add(New DataColumn("NUM", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("SUBJECT_CONTENT", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("μA", System.Type.GetType("System.String")))

                Dim subject As ArrayList = New ArrayList()
                Dim upsubject As String = String.Empty
                '=== 計算 ===
                For icount As Integer = 0 To dt.Rows.Count - 1
                    If upsubject <> dt.Rows(icount)("SUBJECT_NO").ToString Then
                        subject.Add(dt.Rows(icount)("SUBJECT_NO").ToString)
                        upsubject = dt.Rows(icount)("SUBJECT_NO").ToString
                    End If
                Next

                Dim condition As StringBuilder = New StringBuilder()

                For iCount As Integer = 0 To subject.Count - 1
                    Dim denominator As Double = 0 '分母
                    Dim numerator As Double = 0 '分子
                    Dim SUBJECT_CONTENT As String = String.Empty
                    Dim row() As DataRow = dt.Select("QSTNNR_NO='" & Me.QSTNNR_NO & "' and SUBJECT_NO='" & subject(iCount) & "'")


                    For jCount As Integer = 0 To row.Length - 1
                        SUBJECT_CONTENT = row(jCount)("SUBJECT_CONTENT")
                        condition.Length = 0
                        Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                        Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", subject(iCount)) '問卷號碼
                        Me.ProcessQueryCondition(condition, "=", "MENU_NO", row(jCount)("MENU_NO")) '問卷號碼

                        EntQuestionaryAnswer.SqlRetrictions = condition.ToString.Replace("$.", " ")
                        Dim returvalue As Integer = EntQuestionaryAnswer.QueryWirteItem()
                        denominator += returvalue
                        numerator += (returvalue * CType(row(jCount)("MENU_TROVMGP") / 100, Double))
                    Next
                    Dim nRow As DataRow = ReturnDt.NewRow
                    If (denominator = 0 Or numerator = 0) Then

                        nRow("NUM") = (iCount + 1).ToString
                        nRow("SUBJECT_CONTENT") = SUBJECT_CONTENT
                        nRow("μA") = 0
                    Else
                        nRow("NUM") = (iCount + 1).ToString
                        nRow("SUBJECT_CONTENT") = SUBJECT_CONTENT
                        nRow("μA") = Math.Round((numerator / denominator), 4, MidpointRounding.AwayFromZero).ToString
                    End If
                    ReturnDt.Rows.Add(nRow)
                Next

                '
                '2.DT根據每一個題目選項去抓取該題目
                '2.1-先取得NA(I,J)：填寫第i題第j選項的加總人數
                'EntQuestionaryAnswer = New EntQuestionaryAnswer
                '=EntQuestionaryAnswer.QueryWirteItem()
                '2.2 根據紙本的公式算出每題的平均值
                '
                '3依照每題的題目內容跟題目平均值組成DateTable
                '如果分母為0或是分子為0一樣新增一筆DataTable
                '
                '編號=DataTable流水號
                '題目=SUBJECT_CONTENT(題目內容)
                'μA=題目平均值

                Me.ResetColumnProperty()
                Return ReturnDt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryDirSt 查詢單題向度平均值"
        ''' <summary>
        ''' 查詢單題向度標準差 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryDirSt() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                '建立回傳的DT
                Dim ReturnDt As DataTable = New DataTable
                Dim qstnnrno As String = Me.QSTNNR_NO
                ReturnDt.Columns.Add(New DataColumn("NUM", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("SUBJECT_CONTENT", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("μAV", System.Type.GetType("System.String")))

                Dim CtQuestionary As CtQuestionary = New CtQuestionary(DBManager, LogUtil)
                CtQuestionary.QSTNNR_NO = Me.QSTNNR_NO
                '1.先取得該張問卷所有題目向度
                Dim DT As DataTable = CtQuestionary.GetHeadingDegree()



                Dim avgDT As DataTable = Me.QueryAvg
                Me.QSTNNR_NO = qstnnrno
                Dim denominator As Double = 0 '分母
                Dim numerator As Double = 0 '分子

                For icount As Integer = 0 To DT.Rows.Count - 1
                    '1.1根據每個題目向度去抓取對應到的題目號碼
                    CtQuestionary.QSTNNR_NO = Me.QSTNNR_NO
                    CtQuestionary.VECTOR_NO = DT.Rows(icount)("VECTOR_NO")
                    Dim DT1 As DataTable = CtQuestionary.GetQuestionaryHeading()
                    denominator = 0
                    numerator = 0
                    For jcount As Integer = 0 To DT1.Rows.Count - 1
                        Dim condition As StringBuilder = New StringBuilder()
                        Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                        Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", DT1.Rows(jcount)("SUBJECT_NO"))
                        EntQuestionaryAnswer.SqlRetrictions = condition.ToString.Replace("$.", " ")

                        Dim a As Integer = EntQuestionaryAnswer.QueryWirteHeadingPeople()
                        '取得第i填的平均值
                        Dim row() As DataRow = avgDT.Select("SUBJECT_CONTENT='" & DT1.Rows(jcount)("SUBJECT_CONTENT") & "'")
                        Dim uai As Double = 0
                        If row.Length > 0 Then
                            uai = row(0)("μA")
                        End If
                        denominator += a
                        numerator += (a * uai)
                    Next
                    Dim nRow As DataRow = ReturnDt.NewRow
                    If (denominator = 0 Or numerator = 0) Then

                        nRow("NUM") = (icount + 1).ToString
                        nRow("SUBJECT_CONTENT") = DT.Rows(icount)("VECTOR_NAME")
                        nRow("μAV") = 0
                    Else
                        nRow("NUM") = (icount + 1).ToString
                        nRow("SUBJECT_CONTENT") = DT.Rows(icount)("VECTOR_NAME")
                        nRow("μAV") = Math.Round((numerator / denominator), 4, MidpointRounding.AwayFromZero)
                    End If
                    ReturnDt.Rows.Add(nRow)
                Next
                '=== 處理說明 ===
                '1.先取得該張問卷所有題目向度
                'DT=CtQuestionary_問卷Ct.GetHeadingDegree_取得題目向度()
                '
                '1.1根據每個題目向度去抓取對應到的題目號碼
                'DT1=CtQuestionary_問卷Ct.GetQuestionaryHeading_取得題目()
                '
                '1.1.1再根據每個題目抓取填寫題目加總人數跟題目平均值
                '
                'EntQuestionaryAnswer = New EntQuestionaryAnswer
                '
                'A=EntQuestionaryAnswer.QueryWirteHeadingPeople()
                'B=me.QueryAvg()
                '
                '2.在根據紙本公式計算各題目向度平均值
                '
                '3.依照每題的題目內容跟各題目向度平均值組成DateTable
                '如果分母為0或是分子為0一樣新增一筆DataTable

                Me.ResetColumnProperty()
                Return ReturnDt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QuerySt 查詢各題標準差"
        ''' <summary>
        ''' 查詢各題標準差 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QuerySt() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim sQSTNNR_NO As String = Me.QSTNNR_NO
                Dim Avgdt As DataTable = Me.QueryAvg()
                Me.QSTNNR_NO = sQSTNNR_NO
                Me.EntQuestionaryAnswer.QSTNNR_NO = Me.QSTNNR_NO
                Dim condition2 As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition2, "=", "QSTNNR_NO", QSTNNR_NO) '問卷號碼
                EntQuestionaryAnswer.SqlRetrictions = condition2.ToString.Replace("$.QSTNNR_NO", "A.QSTNNR_NO")

                Dim dt As DataTable = Me.EntQuestionaryAnswer.QueryHeadingItem()
                '建立回傳的DT
                Dim ReturnDt As DataTable = New DataTable
                ReturnDt.Columns.Add(New DataColumn("NUM", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("SUBJECT_CONTENT", System.Type.GetType("System.String")))
                ReturnDt.Columns.Add(New DataColumn("σA", System.Type.GetType("System.String")))
                Dim subject As ArrayList = New ArrayList()
                Dim upsubject As String = String.Empty
                '=== 計算 ===
                For icount As Integer = 0 To dt.Rows.Count - 1
                    If upsubject <> dt.Rows(icount)("SUBJECT_NO").ToString Then
                        subject.Add(dt.Rows(icount)("SUBJECT_NO").ToString)
                        upsubject = dt.Rows(icount)("SUBJECT_NO").ToString
                    End If
                Next
                DBManager.Logger.Append("subjectCount=" & subject.Count)

                For iCount As Integer = 0 To subject.Count - 1
                    '=== 取得NA(I) ===
                    Dim condition As StringBuilder = New StringBuilder()
                    Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                    Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", subject(iCount))
                    EntQuestionaryAnswer.SqlRetrictions = condition.ToString.Replace("$.", " ")

                    Dim NAI As Integer = EntQuestionaryAnswer.QueryWirteHeadingPeople()

                    Dim numerator As Double = 0 '分子
                    Dim SUBJECT_CONTENT As String = String.Empty
                    Dim row() As DataRow = dt.Select("QSTNNR_NO='" & Me.QSTNNR_NO & "' and SUBJECT_NO='" & subject(iCount) & "'")
                    Dim condition1 As StringBuilder = New StringBuilder()
                    For jCount As Integer = 0 To row.Length - 1
                        SUBJECT_CONTENT = row(jCount)("SUBJECT_CONTENT")
                        condition1.Length = 0
                        Me.ProcessQueryCondition(condition1, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                        Me.ProcessQueryCondition(condition1, "=", "SUBJECT_NO", subject(iCount)) '問卷號碼
                        Me.ProcessQueryCondition(condition1, "=", "MENU_NO", row(jCount)("MENU_NO")) '問卷號碼
                        EntQuestionaryAnswer.SqlRetrictions = condition1.ToString.Replace("$.", " ")
                        Dim NAIJ As Integer = EntQuestionaryAnswer.QueryWirteItem()
                        ' === 取得μA ===
                        Dim μrow() As DataRow = Avgdt.Select("SUBJECT_CONTENT='" & SUBJECT_CONTENT & "'")
                        numerator += (NAIJ * ((CType(row(jCount)("MENU_TROVMGP"), Double) / 100 - CType(μrow(0)("μA"), Double)) ^ 2))
                    Next

                    Dim nRow As DataRow = ReturnDt.NewRow
                    If (NAI = 0 Or numerator = 0) Then

                        nRow("NUM") = (iCount + 1).ToString
                        nRow("SUBJECT_CONTENT") = SUBJECT_CONTENT
                        nRow("σA") = 0
                    Else
                        nRow("NUM") = (iCount + 1).ToString
                        nRow("SUBJECT_CONTENT") = SUBJECT_CONTENT
                        DBManager.Logger.Append("numerator=" & numerator)
                        DBManager.Logger.Append("NAI=" & NAI)
                        nRow("σA") = Math.Round(Math.Pow(numerator / NAI, 0.5), 4, MidpointRounding.AwayFromZero)
                    End If
                    ReturnDt.Rows.Add(nRow)
                Next


                '=== 處理說明 ===
                '1. 先取得各題平均值
                'me.QueryAvg_查詢各題題平均值()
                '
                '2. 先取得本問卷有多少題目選項
                'DT=CtProcessQuestionary_處理問卷Ct.QueryHeadingItem_查詢問卷題目選項()
                '
                '3.DT根據每一個題目選項去抓取該題目
                '3.1-先取得NA(I,J)：填寫第i題第j選項的加總人數
                'EntQuestionaryAnswer = New EntQuestionaryAnswer
                '=EntQuestionaryAnswer.QueryWirteItem()
                '3.2 在根據紙本公式計算出標準差
                '
                '4.依照每題的題目內容跟標準差組成DateTable
                '如果分母為0或是分子為0一樣新增一筆DataTable
                '
                '
                '編號=DataTable流水號
                '題目=SUBJECT_CONTENT(題目內容)
                'σA=題目標準差

                Me.ResetColumnProperty()

                Return ReturnDt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetNotWriteObjSQL 取得未填答對象結構"
        ''' <summary>
        ''' 取得未填答對象結構 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetNotWriteObjSQL() As String
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
                'AEntQuestionaryAnswer = NEW EntQuestionaryAnswer()
                '
                'AEntQuestionaryAnswer.QueryNotWriteObjSQL_查詢未填答對象結構()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)             '問卷號碼

                Me.EntQuestionaryAnswer.SqlRetrictions = condition.ToString

                Me.EntQuestionaryAnswer.STATUS = Me.STATUS

                Dim result As String = Me.EntQuestionaryAnswer.QueryNotWriteObjSQL

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryAnswerAmount 取得問卷答案結果"
        ''' <summary>
        ''' 取得問卷答案結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryAnswerAmount() As DataTable
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
                Dim result As DataTable = New DataTable
                Dim condition As StringBuilder = New StringBuilder()

                condition.Length = 0
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)
                Me.ProcessQueryCondition(condition, "=", "MENU_NO", Me.MENU_NO)
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO ", Me.QSTNNR_TARGET_NO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO ", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "ID_TYPE ", Me.ID_TYPE)

                EntQuestionaryAnswer.SqlRetrictions = condition.ToString.Replace("$.", " ")
                result = EntQuestionaryAnswer.QueryQuestionaryAnswerAmount()
                'AEntQuestionaryAnswer = new EntQuestionaryAnswer()
                '
                'AEntQuestionaryAnswer.QueryQuestionaryAnswerAmount_查詢問卷答案結果()
                '
                '<process>
                '
                '</output>
                'Datatable
                '</output>

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

