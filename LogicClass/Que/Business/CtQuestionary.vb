'----------------------------------------------------------------------------------
'File Name		: CtQuestionary 
'Author			:  
'Description		: CtQuestionary 問卷Ct
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
Imports File.Data

Namespace Que.Business
    ''' <summary>
    ''' CtQuestionary 問卷Ct
    ''' </summary>
    Partial Public Class CtQuestionary
        Inherits Acer.Base.ControlBase

#Region "屬性"

#Region "ACCE_SOURCE 附件來源"
        ''' <summary>
        ''' ACCE_SOURCE 附件來源
        ''' </summary>
        Public Property ACCE_SOURCE() As String
            Get
                Return Me.PropertyMap("ACCE_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACCE_SOURCE") = value
            End Set
        End Property
#End Region

#Region "ANSWER_RATE 答案比率"
        ''' <summary>
        ''' ANSWER_RATE 答案比率
        ''' </summary>
        Public Property ANSWER_RATE() As String
            Get
                Return Me.PropertyMap("ANSWER_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANSWER_RATE") = value
            End Set
        End Property
#End Region

#Region "CREATE_UNIT 建立單位"
        ''' <summary>
        ''' CREATE_UNIT 建立單位
        ''' </summary>
        Public Property CREATE_UNIT() As String
            Get
                Return Me.PropertyMap("CREATE_UNIT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_UNIT") = value
            End Set
        End Property
#End Region

#Region "CREATE_UNIT_NAME 建立單位名稱"
        ''' <summary>
        ''' CREATE_UNIT_NAME 建立單位名稱
        ''' </summary>
        Public Property CREATE_UNIT_NAME() As String
            Get
                Return Me.PropertyMap("CREATE_UNIT_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_UNIT_NAME") = value
            End Set
        End Property
#End Region

#Region "DATE 日期"
        ''' <summary>
        ''' DATE 日期
        ''' </summary>
        Public Property DATE1() As String
            Get
                Return Me.PropertyMap("DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_DATE 截止日期"
        ''' <summary>
        ''' DEADLINE_DATE 截止日期
        ''' </summary>
        Public Property DEADLINE_DATE() As String
            Get
                Return Me.PropertyMap("DEADLINE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE_DATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_TIME 截止時間"
        ''' <summary>
        ''' DEADLINE_TIME 截止時間
        ''' </summary>
        Public Property DEADLINE_TIME() As String
            Get
                Return Me.PropertyMap("DEADLINE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE_TIME") = value
            End Set
        End Property
#End Region

#Region "DODRAFT_DATE 下稿日期"
        ''' <summary>
        ''' DODRAFT_DATE 下稿日期
        ''' </summary>
        Public Property DODRAFT_DATE() As String
            Get
                Return Me.PropertyMap("DODRAFT_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DODRAFT_DATE") = value
            End Set
        End Property
#End Region

#Region "DOWNLOAD_ADDR 參考網址"
        ''' <summary>
        ''' DOWNLOAD_ADDR 參考網址
        ''' </summary>
        Public Property DOWNLOAD_ADDR() As String
            Get
                Return Me.PropertyMap("DOWNLOAD_ADDR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DOWNLOAD_ADDR") = value
            End Set
        End Property
#End Region

#Region "DTQstCho 問卷選項"
        ''' <summary>
        ''' DTQstCho 問卷選項
        ''' </summary>
        Public Property DTQstCho() As DataTable
            Get
                Return Me.PropertyMap("DTQstCho")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("DTQstCho") = value
            End Set
        End Property
#End Region

#Region "DTQstTar 問卷對象"
        ''' <summary>
        ''' DTQstTar 問卷對象
        ''' </summary>
        Public Property DTQstTar() As DataTable
            Get
                Return Me.PropertyMap("DTQstTar")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("DTQstTar") = value
            End Set
        End Property
#End Region

#Region "EntHeadingDegree 題目向度ENT"
        ''' <summary>
        ''' EntHeadingDegree 題目向度ENT
        ''' </summary>
        Private Property EntHeadingDegree() As EntHeadingDegree
            Get
                Return Me.PropertyMap("EntHeadingDegree")
            End Get
            Set(ByVal value As EntHeadingDegree)
                Me.PropertyMap("EntHeadingDegree") = value
            End Set
        End Property
#End Region

#Region "EntQuestionary 問卷ENT"
        ''' <summary>
        ''' EntQuestionary 問卷ENT
        ''' </summary>
        Private Property EntQuestionary() As EntQuestionary
            Get
                Return Me.PropertyMap("EntQuestionary")
            End Get
            Set(ByVal value As EntQuestionary)
                Me.PropertyMap("EntQuestionary") = value
            End Set
        End Property
#End Region

#Region "EntQuestionaryHeading 問卷單題目ENT"
        ''' <summary>
        ''' EntQuestionaryHeading 問卷單題目ENT
        ''' </summary>
        Private Property EntQuestionaryHeading() As EntQuestionaryHeading
            Get
                Return Me.PropertyMap("EntQuestionaryHeading")
            End Get
            Set(ByVal value As EntQuestionaryHeading)
                Me.PropertyMap("EntQuestionaryHeading") = value
            End Set
        End Property
#End Region

#Region "IS_ANNOUNCE_OUTER 是否發佈校外"
        ''' <summary>
        ''' IS_ANNOUNCE_OUTER 是否發佈校外
        ''' </summary>
        Public Property IS_ANNOUNCE_OUTER() As String
            Get
                Return Me.PropertyMap("IS_ANNOUNCE_OUTER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_ANNOUNCE_OUTER") = value
            End Set
        End Property
#End Region

#Region "IS_DISP_RESULT 是否顯示結果"
        ''' <summary>
        ''' IS_DISP_RESULT 是否顯示結果
        ''' </summary>
        Public Property IS_DISP_RESULT() As String
            Get
                Return Me.PropertyMap("IS_DISP_RESULT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_DISP_RESULT") = value
            End Set
        End Property
#End Region

#Region "IS_FILL 是否必填"
        ''' <summary>
        ''' IS_FILL 是否必填
        ''' </summary>
        Public Property IS_FILL() As String
            Get
                Return Me.PropertyMap("IS_FILL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_FILL") = value
            End Set
        End Property
#End Region

#Region "IS_REPEAT 是否重複"
        ''' <summary>
        ''' IS_REPEAT 是否重複
        ''' </summary>
        Public Property IS_REPEAT() As String
            Get
                Return Me.PropertyMap("IS_REPEAT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_REPEAT") = value
            End Set
        End Property
#End Region

#Region "IS_SIGN 是否記名"
        ''' <summary>
        ''' IS_SIGN 是否記名
        ''' </summary>
        Public Property IS_SIGN() As String
            Get
                Return Me.PropertyMap("IS_SIGN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_SIGN") = value
            End Set
        End Property
#End Region

#Region "IS_USE_SUBJECT_VECTOR 是否使用題目向度"
        ''' <summary>
        ''' IS_USE_SUBJECT_VECTOR 是否使用題目向度
        ''' </summary>
        Public Property IS_USE_SUBJECT_VECTOR() As String
            Get
                Return Me.PropertyMap("IS_USE_SUBJECT_VECTOR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_USE_SUBJECT_VECTOR") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_EXPL 問卷說明"
        ''' <summary>
        ''' QSTNNR_EXPL 問卷說明
        ''' </summary>
        Public Property QSTNNR_EXPL() As String
            Get
                Return Me.PropertyMap("QSTNNR_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_EXPL") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_FORMAT 問卷格式"
        ''' <summary>
        ''' QSTNNR_FORMAT 問卷格式
        ''' </summary>
        Public Property QSTNNR_FORMAT() As String
            Get
                Return Me.PropertyMap("QSTNNR_FORMAT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_FORMAT") = value
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

#Region "QSTNNR_SEQ 問卷排序"
        ''' <summary>
        ''' QSTNNR_SEQ 問卷排序
        ''' </summary>
        Public Property QSTNNR_SEQ() As String
            Get
                Return Me.PropertyMap("QSTNNR_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QSTNNR_SEQ") = value
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

#Region "START_DATE 開始日期"
        ''' <summary>
        ''' START_DATE 開始日期
        ''' </summary>
        Public Property START_DATE() As String
            Get
                Return Me.PropertyMap("START_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("START_DATE") = value
            End Set
        End Property
#End Region

#Region "START_TIME 開始時間"
        ''' <summary>
        ''' START_TIME 開始時間
        ''' </summary>
        Public Property START_TIME() As String
            Get
                Return Me.PropertyMap("START_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("START_TIME") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_BS 題目大小"
        ''' <summary>
        ''' SUBJECT_BS 題目大小
        ''' </summary>
        Public Property SUBJECT_BS() As String
            Get
                Return Me.PropertyMap("SUBJECT_BS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_BS") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_CONTENT 題目內容"
        ''' <summary>
        ''' SUBJECT_CONTENT 題目內容
        ''' </summary>
        Public Property SUBJECT_CONTENT() As String
            Get
                Return Me.PropertyMap("SUBJECT_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_CONTENT") = value
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

#Region "SUBJECT_RMK 題目備註"
        ''' <summary>
        ''' SUBJECT_RMK 題目備註
        ''' </summary>
        Public Property SUBJECT_RMK() As String
            Get
                Return Me.PropertyMap("SUBJECT_RMK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_RMK") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_SEQ 題目排序"
        ''' <summary>
        ''' SUBJECT_SEQ 題目排序
        ''' </summary>
        Public Property SUBJECT_SEQ() As String
            Get
                Return Me.PropertyMap("SUBJECT_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_SEQ") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_STATUS 題目狀態"
        ''' <summary>
        ''' SUBJECT_STATUS 題目狀態
        ''' </summary>
        Public Property SUBJECT_STATUS() As String
            Get
                Return Me.PropertyMap("SUBJECT_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_STATUS") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_STATUS_NO 題目狀態數"
        ''' <summary>
        ''' SUBJECT_STATUS_NO 題目狀態數
        ''' </summary>
        Public Property SUBJECT_STATUS_NO() As String
            Get
                Return Me.PropertyMap("SUBJECT_STATUS_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_STATUS_NO") = value
            End Set
        End Property
#End Region

#Region "PARENT_SNO 父項題目號碼"
        Public Property PARENT_SNO As String
            Get
                Return Me.PropertyMap("PARENT_SNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARENT_SNO") = value
            End Set
        End Property
#End Region

#Region "PARENT_MNO 父項選單號碼"
        Public Property PARENT_MNO As String
            Get
                Return Me.PropertyMap("PARENT_MNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARENT_MNO") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TITLE 題目標號"
        ''' <summary>
        ''' SUBJECT_TITLE 題目標號
        ''' </summary>
        Public Property SUBJECT_TITLE() As String
            Get
                Return Me.PropertyMap("SUBJECT_TITLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_TITLE") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TROVMGP 題目權數"
        ''' <summary>
        ''' SUBJECT_TROVMGP 題目權數
        ''' </summary>
        Public Property SUBJECT_TROVMGP() As String
            Get
                Return Me.PropertyMap("SUBJECT_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_TROVMGP") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TYPE 題目類別"
        ''' <summary>
        ''' SUBJECT_TYPE 題目類別
        ''' </summary>
        Public Property SUBJECT_TYPE() As String
            Get
                Return Me.PropertyMap("SUBJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "UPDRAFT_DATE 上稿日期"
        ''' <summary>
        ''' UPDRAFT_DATE 上稿日期
        ''' </summary>
        Public Property UPDRAFT_DATE() As String
            Get
                Return Me.PropertyMap("UPDRAFT_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPDRAFT_DATE") = value
            End Set
        End Property
#End Region

#Region "VECTOR_BS 向度大小"
        ''' <summary>
        ''' VECTOR_BS 向度大小
        ''' </summary>
        Public Property VECTOR_BS() As String
            Get
                Return Me.PropertyMap("VECTOR_BS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_BS") = value
            End Set
        End Property
#End Region

#Region "VECTOR_NAME 向度名稱"
        ''' <summary>
        ''' VECTOR_NAME 向度名稱
        ''' </summary>
        Public Property VECTOR_NAME() As String
            Get
                Return Me.PropertyMap("VECTOR_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_NAME") = value
            End Set
        End Property
#End Region

#Region "VECTOR_NO 向度號碼"
        ''' <summary>
        ''' VECTOR_NO 向度號碼
        ''' </summary>
        Public Property VECTOR_NO() As String
            Get
                Return Me.PropertyMap("VECTOR_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_NO") = value
            End Set
        End Property
#End Region

#Region "VECTOR_SEQ 向度排序"
        ''' <summary>
        ''' VECTOR_SEQ 向度排序
        ''' </summary>
        Public Property VECTOR_SEQ() As String
            Get
                Return Me.PropertyMap("VECTOR_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_SEQ") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TITLE 向度標號"
        ''' <summary>
        ''' VECTOR_TITLE 向度標號
        ''' </summary>
        Public Property VECTOR_TITLE() As String
            Get
                Return Me.PropertyMap("VECTOR_TITLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_TITLE") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TROVMGP 向度權數"
        ''' <summary>
        ''' VECTOR_TROVMGP 向度權數
        ''' </summary>
        Public Property VECTOR_TROVMGP() As String
            Get
                Return Me.PropertyMap("VECTOR_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_TROVMGP") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TYPE 向度類型"
        ''' <summary>
        ''' VECTOR_TROVMGP 向度類型
        ''' </summary>
        Public Property VECTOR_TYPE() As String
            Get
                Return Me.PropertyMap("VECTOR_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VECTOR_TYPE") = value
            End Set
        End Property
#End Region

#Region "JUMP_CONTENT 跳題內容"
        ''' <summary>
        ''' JUMP_CONTENT 跳題內容
        ''' </summary>
        Public Property JUMP_CONTENT() As String
            Get
                Return Me.PropertyMap("JUMP_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JUMP_CONTENT") = value
            End Set
        End Property
#End Region

#Region "JUMP_NO 跳題號碼"
        ''' <summary>
        ''' JUMP_NO 跳題號碼
        ''' </summary>
        Public Property JUMP_NO() As String
            Get
                Return Me.PropertyMap("JUMP_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JUMP_NO") = value
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

#Region "AYEAR 學年度"
        ''' <summary>
        ''' AYEAR 學年度
        ''' </summary>
        Public Property AYEAR() As String
            Get
                Return Me.PropertyMap("AYEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("AYEAR") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_MAX 題目上限 "
        ''' <summary>
        ''' SUBJECT_MAX 題目上限 
        ''' </summary>
        Public Property SUBJECT_MAX() As String
            Get
                Return Me.PropertyMap("SUBJECT_MAX")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_MAX") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_MIN 題目下限"
        ''' <summary>
        ''' SUBJECT_MIN 題目下限
        ''' </summary>
        Public Property SUBJECT_MIN() As String
            Get
                Return Me.PropertyMap("SUBJECT_MIN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBJECT_MIN") = value
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

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===
            Me.EntHeadingDegree = New EntHeadingDegree(Me.DBManager, Me.LogUtil)
            Me.EntQuestionary = New EntQuestionary(Me.DBManager, Me.LogUtil)
            Me.EntQuestionaryHeading = New EntQuestionaryHeading(Me.DBManager, Me.LogUtil)

        End Sub
#End Region

#Region "方法"
#Region "AddHeadingDegree 新增題目向度"
        ''' <summary>
        ''' 新增題目向度 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddHeadingDegree()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If
                '=== 向度大小 ===
                If String.IsNullOrEmpty(Me.VECTOR_BS) Then
                    faileArguments.Add("VECTOR_BS")
                End If
                '=== 向度權數 ===
                If String.IsNullOrEmpty(Me.VECTOR_TROVMGP) Then
                    faileArguments.Add("VECTOR_TROVMGP")
                End If
                '=== 向度排序 ===
                If String.IsNullOrEmpty(Me.VECTOR_SEQ) Then
                    faileArguments.Add("VECTOR_SEQ")
                End If
                '=== 向度標號 ===
                If String.IsNullOrEmpty(Me.VECTOR_TITLE) Then
                    faileArguments.Add("VECTOR_TITLE")
                End If
                '=== 向度名稱 ===
                If String.IsNullOrEmpty(Me.VECTOR_NAME) Then
                    faileArguments.Add("VECTOR_NAME")
                End If
                '=== 向度類型 ===
                If String.IsNullOrEmpty(Me.VECTOR_TYPE) Then
                    faileArguments.Add("VECTOR_TYPE")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '

                EntHeadingDegree.VECTOR_NO = EntHeadingDegree.QueryDegreeMaxNo
                Me.EntHeadingDegree.VECTOR_NAME = Me.VECTOR_NAME  '向度名稱
                Me.EntHeadingDegree.VECTOR_BS = Me.VECTOR_BS    '向度大小
                Me.EntHeadingDegree.VECTOR_SEQ = Me.VECTOR_SEQ   '向度排序
                Me.EntHeadingDegree.VECTOR_TITLE = Me.VECTOR_TITLE '向度標號
                Me.EntHeadingDegree.VECTOR_TROVMGP = Me.VECTOR_TROVMGP   '向度權數
                Me.EntHeadingDegree.VECTOR_TYPE = Me.VECTOR_TYPE  '向度類型
                Me.EntHeadingDegree.QSTNNR_NO = Me.QSTNNR_NO    '問卷號碼

                '
                EntHeadingDegree.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddQuestionary 新增問卷"
        ''' <summary>
        ''' 新增問卷 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function AddQuestionary() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 截止日期 ===
                If String.IsNullOrEmpty(Me.DEADLINE_DATE) Then
                    faileArguments.Add("DEADLINE_DATE")
                End If

                '=== 問卷說明 ===
                If String.IsNullOrEmpty(Me.QSTNNR_EXPL) Then
                    faileArguments.Add("QSTNNR_EXPL")
                End If

                '=== 問卷標題 ===
                If String.IsNullOrEmpty(Me.QSTNNR_TITLE) Then
                    faileArguments.Add("QSTNNR_TITLE")
                End If
                '=== 開始日期 ===
                If String.IsNullOrEmpty(Me.START_DATE) Then
                    faileArguments.Add("START_DATE")
                End If


                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '
                Dim thisQSTNNR As String = EntQuestionary.QueryQuestionaryMaxNo()
                '
                EntQuestionary.CREATE_UNIT = Me.CREATE_UNIT
                EntQuestionary.IS_DISP_RESULT = Me.IS_DISP_RESULT
                EntQuestionary.IS_USE_SUBJECT_VECTOR = Me.IS_USE_SUBJECT_VECTOR
                EntQuestionary.QSTNNR_FORMAT = Me.QSTNNR_FORMAT
                EntQuestionary.QSTNNR_TITLE = Me.QSTNNR_TITLE
                EntQuestionary.START_DATE = Me.START_DATE
                EntQuestionary.CREATE_UNIT_NAME = Me.CREATE_UNIT_NAME
                EntQuestionary.START_TIME = Me.START_TIME
                EntQuestionary.DODRAFT_DATE = Me.DODRAFT_DATE
                EntQuestionary.ANSWER_RATE = Me.ANSWER_RATE
                EntQuestionary.DOWNLOAD_ADDR = Me.DOWNLOAD_ADDR
                EntQuestionary.QSTNNR_SEQ = Me.QSTNNR_SEQ
                EntQuestionary.ACCE_SOURCE = Me.ACCE_SOURCE
                EntQuestionary.IS_ANNOUNCE_OUTER = Me.IS_ANNOUNCE_OUTER
                EntQuestionary.IS_SIGN = Me.IS_SIGN
                EntQuestionary.UPDRAFT_DATE = Me.UPDRAFT_DATE
                EntQuestionary.DEADLINE_DATE = Me.DEADLINE_DATE
                EntQuestionary.DEADLINE_TIME = Me.DEADLINE_TIME
                EntQuestionary.IS_REPEAT = Me.IS_REPEAT
                EntQuestionary.QSTNNR_EXPL = Me.QSTNNR_EXPL
                EntQuestionary.QSTNNR_NO = thisQSTNNR
                EntQuestionary.Insert()

                Me.ResetColumnProperty()

                Return thisQSTNNR
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddQuestionaryHeading 新增題目"
        ''' <summary>
        ''' 新增題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddQuestionaryHeading()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 是否必填 ===
                'If String.IsNullOrEmpty(Me.IS_FILL) Then
                '    faileArguments.Add("IS_FILL")
                'End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If
                '=== 題目大小 ===
                If String.IsNullOrEmpty(Me.SUBJECT_BS) Then
                    faileArguments.Add("SUBJECT_BS")
                End If
                '=== 題目內容 ===
                If String.IsNullOrEmpty(Me.SUBJECT_CONTENT) Then
                    faileArguments.Add("SUBJECT_CONTENT")
                End If
                '=== 題目類別 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TYPE) Then
                    faileArguments.Add("SUBJECT_TYPE")
                End If
                '=== 題目狀態 ===
                If String.IsNullOrEmpty(Me.SUBJECT_STATUS) Then
                    faileArguments.Add("SUBJECT_STATUS")
                End If
                '=== 題目標號 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TITLE) Then
                    faileArguments.Add("SUBJECT_TITLE")
                End If
                '=== 題目權數 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TROVMGP) Then
                    faileArguments.Add("SUBJECT_TROVMGP")
                End If
                '=== 題目排序 ===
                If String.IsNullOrEmpty(Me.SUBJECT_SEQ) Then
                    faileArguments.Add("SUBJECT_SEQ")
                End If

                '=== DT問卷選項 ===
                If Me.DTQstCho Is Nothing Then
                    faileArguments.Add("DTQstCho")
                Else
                    '=== 檢查DT社團活動規劃有否缺少欄位 ===
                    Dim lostDtColumns As New ArrayList

                    If Me.DTQstCho.Columns.Contains("MENU_NO") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_NO 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_TITLE") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_TITLE 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_CONTENT") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_CONTENT 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_STYLE") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_STYLE 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_TROVMGP") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_TROVMGP 欄位")
                    End If

                    If lostDtColumns.Count > 0 Then
                        Throw New ArgumentException("", Utility.ArrayListToString(lostDtColumns))
                    End If
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '步驟
                '1.先檢核傳入table的欄位跟型態
                '
                '2.新增題目主檔
                '
                '3.將問卷題目選項屬性設定並新增問卷題目選項
                '
                '必傳入問卷選項table
                '欄位為(QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),選項標號,選項內容,選項樣式,選項權數)
                '

                Dim sSUBJECT_NO As String = EntQuestionaryHeading.QueryHeadingMaxNo()
                EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryHeading.SUBJECT_STATUS = Me.SUBJECT_STATUS
                EntQuestionaryHeading.SUBJECT_TITLE = Me.SUBJECT_TITLE
                EntQuestionaryHeading.SUBJECT_CONTENT = Me.SUBJECT_CONTENT
                EntQuestionaryHeading.SUBJECT_TYPE = Me.SUBJECT_TYPE
                EntQuestionaryHeading.SUBJECT_BS = Me.SUBJECT_BS
                EntQuestionaryHeading.SUBJECT_RMK = Me.SUBJECT_RMK
                EntQuestionaryHeading.VECTOR_NO = Me.VECTOR_NO
                EntQuestionaryHeading.IS_FILL = Me.IS_FILL
                EntQuestionaryHeading.SUBJECT_TROVMGP = Me.SUBJECT_TROVMGP
                EntQuestionaryHeading.SUBJECT_SEQ = Me.SUBJECT_SEQ
                EntQuestionaryHeading.SUBJECT_MAX = Me.SUBJECT_MAX
                EntQuestionaryHeading.SUBJECT_MIN = Me.SUBJECT_MIN
                EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                EntQuestionaryHeading.QSTNNR_FORMAT = QSTNNR_FORMAT
                EntQuestionaryHeading.SUBJECT_STATUS_NO = SUBJECT_STATUS_NO '題目狀態數
                EntQuestionaryHeading.PARENT_SNO = Me.PARENT_SNO '父項題目號碼 
                EntQuestionaryHeading.PARENT_MNO = Me.PARENT_MNO '父項選單號碼 
                EntQuestionaryHeading.Insert()

                For i As Integer = 0 To Me.DTQstCho.Rows.Count - 1
                    EntQuestionaryHeading.MENU_NO = DTQstCho.Rows(i)("MENU_NO").ToString
                    EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                    EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                    EntQuestionaryHeading.MENU_TITLE = DTQstCho.Rows(i)("MENU_TITLE").ToString
                    EntQuestionaryHeading.MENU_CONTENT = DTQstCho.Rows(i)("MENU_CONTENT").ToString
                    EntQuestionaryHeading.MENU_STYLE = DTQstCho.Rows(i)("MENU_STYLE").ToString
                    EntQuestionaryHeading.MENU_TROVMGP = DTQstCho.Rows(i)("MENU_TROVMGP").ToString
                    EntQuestionaryHeading.MENU_RMK = DTQstCho.Rows(i)("MENU_RMK").ToString
                    EntQuestionaryHeading.AddItem()
                Next
                '
                'EntQuestionaryHeading.Insert()
                '
                'for i to 問卷選項table rows .count-1
                '
                'EntQuestionaryHeading.EntQuestionaryItem.SUBJECT_NO(題目號碼)[i]=EntQuestionaryHeading.SUBJECT_NO(題目號碼)
                '
                'EntQuestionaryHeading.EntQuestionaryItem.其他欄位[i]=QSTNNR_TARGET(問卷對象)[i]其他欄位
                '
                'EntQuestionaryHeading.AddItem()
                '
                'next

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ChearJuamp 取消跳題"
        ''' <summary>
        ''' 取消跳題 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub ChearJuamp()
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
                'EntQuestionaryHeading NEW EntQuestionaryHeading()
                '
                'EntQuestionaryHeading.JUMP_NO(跳題號碼)=""
                'EntQuestionaryHeading.Update()
                '
                '
                'EntQuestionaryHeading.EntQuestionaryItem.QSTNNR_NO(問卷號碼)=@QSTNNR_NO(問卷號碼)
                '
                '
                'return EntQuestionaryHeading.ClearItem()
                EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryHeading.ClearItem()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "CopyQuestionary 複製問卷"
        ''' <summary>
        ''' 複製問卷 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function CopyQuestionary() As String
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
                '先取得問卷所有資料
                '1主檔,2附加檔案,3題目向度,4問卷對象,
                '5問卷題目,6問卷題目選項
                '
                '
                'EntQuestionary NEW EntQuestionary()
                'dim dt1 as DataTable=me.EntHeadingDegree.
                'Dim DT1 As DataTable = EntQuestionary.GetQuestionary()
                'Dim DT2 As DataTable = EntQuestionary.GetAttachFile()
                'Dim dt3 As DataTable = EntQuestionary.GetHeadingDegree()
                'Dim dt4 As DataTable = EntQuestionary.GetQuestionaryObj()
                'Dim dt5 As DataTable = EntQuestionary.GetHeadingDegree()
                'Dim dt6 As DataTable = EntQuestionary.GetHeadingItem()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼

                Me.EntQuestionary.SqlRetrictions = condition.ToString()
                Dim DT1 As DataTable = Me.EntQuestionary.Query

                If DT1.Rows.Count > 0 Then
                    '//政諺2011/05/04 依QA30423修改:先檢查QSTNNR_TITLE的長度有無超過DD設定的長度
                    Dim ColumnDDMap As Hashtable = MultiProcess.GetCrossSiteValue("COLUMNDD")
                    Dim tmpStruct As Acer.Form.DataDictionaryUtil.ColumnDD = Nothing
                    If ColumnDDMap.ContainsKey("QSTNNR_TITLE") Then
                        tmpStruct = ColumnDDMap("QSTNNR_TITLE")
                        If (DT1.Rows(0)("QSTNNR_TITLE").ToString.Length + 3) > Convert.ToInt32(tmpStruct.Length) Then
                            Return tmpStruct.Length
                        End If
                    End If
                End If

                'Me.ACCE_SOURCE = "QUE1010"
                'Dim DT2 As DataTable = Me.GetAttachFile()

                Me.EntHeadingDegree.SqlRetrictions = condition.ToString()
                Dim DT3 As DataTable = EntHeadingDegree.Query()

                Me.EntQuestionary.SqlRetrictions = condition.ToString()
                Dim DT4 As DataTable = EntQuestionary.QueryQuestionaryObj()

                Me.EntQuestionaryHeading.SqlRetrictions = condition.ToString()
                Dim DT5 As DataTable = Me.EntQuestionaryHeading.Query

                Me.EntQuestionaryHeading.SqlRetrictions = condition.ToString()
                Dim DT6 As DataTable = EntQuestionaryHeading.QueryItem

                Dim CQSTNNR As String = String.Empty

                If DT1.Rows.Count > 0 Then
                    CQSTNNR = EntQuestionary.QueryQuestionaryMaxNo()
                    EntQuestionary.QSTNNR_NO = CQSTNNR
                    EntQuestionary.QSTNNR_TITLE = "複製-" & DT1.Rows(0)("QSTNNR_TITLE").ToString
                    EntQuestionary.CREATE_UNIT = DT1.Rows(0)("CREATE_UNIT").ToString
                    EntQuestionary.IS_DISP_RESULT = DT1.Rows(0)("IS_DISP_RESULT").ToString
                    EntQuestionary.IS_USE_SUBJECT_VECTOR = DT1.Rows(0)("IS_USE_SUBJECT_VECTOR").ToString
                    EntQuestionary.QSTNNR_FORMAT = DT1.Rows(0)("QSTNNR_FORMAT").ToString

                    EntQuestionary.START_DATE = "2099/01/01 00:01:00" 'Convert.ToDateTime(DT1.Rows(0)("START_DATE").ToString).ToString("yyyy/MM/dd")
                    EntQuestionary.START_TIME = "0001"
                    EntQuestionary.CREATE_UNIT_NAME = DT1.Rows(0)("CREATE_UNIT_NAME").ToString
                    'Me.EntQuestionary.UPDRAFT_DATE = Convert.ToDateTime(DT1.Rows(0)("UPDRAFT_DATE")).ToString("yyyy/MM/dd")
                    'EntQuestionary.DODRAFT_DATE = Convert.ToDateTime(DT1.Rows(0)("DODRAFT_DATE")).ToString("yyyy/MM/dd")
                    Me.EntQuestionary.DEADLINE_DATE = "2099/12/31 23:00:00"
                    EntQuestionary.DEADLINE_TIME = "2300"
                    EntQuestionary.ANSWER_RATE = DT1.Rows(0)("ANSWER_RATE").ToString
                    EntQuestionary.DOWNLOAD_ADDR = DT1.Rows(0)("DOWNLOAD_ADDR").ToString
                    EntQuestionary.QSTNNR_SEQ = DT1.Rows(0)("QSTNNR_SEQ").ToString
                    EntQuestionary.IS_ANNOUNCE_OUTER = DT1.Rows(0)("IS_ANNOUNCE_OUTER").ToString
                    EntQuestionary.IS_SIGN = DT1.Rows(0)("IS_SIGN").ToString
                    EntQuestionary.IS_REPEAT = DT1.Rows(0)("IS_REPEAT").ToString
                    EntQuestionary.QSTNNR_EXPL = DT1.Rows(0)("QSTNNR_EXPL").ToString.Replace("'", "''")
                    EntQuestionary.Insert()

                    For icount As Integer = 0 To DT4.Rows.Count - 1
                        EntQuestionary.QSTNNR_NO = CQSTNNR
                        EntQuestionary.QSTNNR_TARGET_NO = DT4.Rows(icount)("QSTNNR_TARGET_NO").ToString
                        EntQuestionary.NAME = DT4.Rows(icount)("NAME").ToString
                        EntQuestionary.UNIT_NO = DT4.Rows(icount)("UNIT_NO").ToString
                        EntQuestionary.DEP_NAME = DT4.Rows(icount)("DEP_NAME").ToString
                        EntQuestionary.AddQuestionaryObj()
                    Next

                    'For icount As Integer = 0 To DT2.Rows.Count - 1
                    '    EntQuestionary.FILE_NO = CQSTNNR
                    '    EntQuestionary.QSTNNR_TARGET_NO = DT2.Rows(icount)("QSTNNR_TARGET_NO").ToString
                    '    EntQuestionary.NAME = DT2.Rows(icount)("NAME").ToString
                    '    EntQuestionary.UNIT_NO = DT2.Rows(icount)("UNIT_NO").ToString
                    '    EntQuestionary.DEP_NAME = DT2.Rows(icount)("DEP_NAME").ToString
                    '    EntQuestionary.AddAttachFile()
                    'Next

                    If DT3.Rows.Count > 0 Then
                        For icount As Integer = 0 To DT3.Rows.Count - 1
                            Dim row As DataRow = DT3.Rows(icount)
                            Dim CVECTOR_NO As String = EntHeadingDegree.QueryDegreeMaxNo()
                            EntHeadingDegree.QSTNNR_NO = CQSTNNR
                            EntHeadingDegree.VECTOR_NO = CVECTOR_NO
                            EntHeadingDegree.VECTOR_TYPE = row("VECTOR_TYPE").ToString
                            EntHeadingDegree.VECTOR_TITLE = row("VECTOR_TITLE").ToString
                            EntHeadingDegree.VECTOR_NAME = row("VECTOR_NAME").ToString
                            EntHeadingDegree.VECTOR_BS = row("VECTOR_BS").ToString
                            EntHeadingDegree.VECTOR_TROVMGP = row("VECTOR_TROVMGP").ToString
                            EntHeadingDegree.VECTOR_SEQ = row("VECTOR_SEQ").ToString
                            EntHeadingDegree.Insert()

                            Dim rowHeading As DataRow() = DT5.Select("QSTNNR_NO='" & DT1.Rows(0)("QSTNNR_NO").ToString & "' AND VECTOR_NO = '" & row("VECTOR_NO").ToString.Trim & "' ")

                            For i As Integer = 0 To rowHeading.Length - 1
                                Dim sSUBJECT_NO As String = EntQuestionaryHeading.QueryHeadingMaxNo()
                                EntQuestionaryHeading.QSTNNR_NO = CQSTNNR
                                EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                                EntQuestionaryHeading.PARENT_SNO = rowHeading(i)("PARENT_SNO").ToString
                                EntQuestionaryHeading.PARENT_MNO = rowHeading(i)("PARENT_MNO").ToString
                                EntQuestionaryHeading.SUBJECT_STATUS_NO = rowHeading(i)("SUBJECT_STATUS_NO").ToString
                                EntQuestionaryHeading.SUBJECT_STATUS = rowHeading(i)("SUBJECT_STATUS").ToString
                                EntQuestionaryHeading.SUBJECT_TITLE = rowHeading(i)("SUBJECT_TITLE").ToString
                                EntQuestionaryHeading.SUBJECT_CONTENT = rowHeading(i)("SUBJECT_CONTENT").ToString
                                EntQuestionaryHeading.SUBJECT_TYPE = rowHeading(i)("SUBJECT_TYPE").ToString
                                EntQuestionaryHeading.SUBJECT_BS = rowHeading(i)("SUBJECT_BS").ToString
                                EntQuestionaryHeading.SUBJECT_RMK = rowHeading(i)("SUBJECT_RMK").ToString
                                EntQuestionaryHeading.VECTOR_NO = CVECTOR_NO
                                EntQuestionaryHeading.IS_FILL = rowHeading(i)("IS_FILL").ToString
                                EntQuestionaryHeading.SUBJECT_TROVMGP = rowHeading(i)("SUBJECT_TROVMGP").ToString
                                EntQuestionaryHeading.SUBJECT_SEQ = rowHeading(i)("SUBJECT_SEQ").ToString
                                EntQuestionaryHeading.QSTNNR_FORMAT = rowHeading(i)("QSTNNR_FORMAT").ToString
                                EntQuestionaryHeading.Insert()

                                Dim row2() As DataRow = DT6.Select(" QSTNNR_NO='" & DT1.Rows(0)("QSTNNR_NO").ToString & "' AND SUBJECT_NO='" & rowHeading(i)("SUBJECT_NO").ToString & "'")

                                For icount2 As Integer = 0 To row2.Length - 1
                                    EntQuestionaryHeading.MENU_NO = row2(icount2)("MENU_NO").ToString
                                    EntQuestionaryHeading.QSTNNR_NO = CQSTNNR
                                    EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                                    EntQuestionaryHeading.MENU_TITLE = row2(icount2)("MENU_TITLE").ToString
                                    EntQuestionaryHeading.MENU_CONTENT = row2(icount2)("MENU_CONTENT").ToString
                                    EntQuestionaryHeading.MENU_STYLE = row2(icount2)("MENU_STYLE").ToString
                                    EntQuestionaryHeading.MENU_TROVMGP = row2(icount2)("MENU_TROVMGP").ToString
                                    EntQuestionaryHeading.AddItem()
                                Next
                            Next
                        Next
                    Else
                        For j As Integer = 0 To DT5.Rows.Count - 1
                            Dim sSUBJECT_NO As String = EntQuestionaryHeading.QueryHeadingMaxNo()
                            EntQuestionaryHeading.QSTNNR_NO = CQSTNNR
                            EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                            EntQuestionaryHeading.PARENT_SNO = DT5.Rows(j)("PARENT_SNO").ToString
                            EntQuestionaryHeading.PARENT_MNO = DT5.Rows(j)("PARENT_MNO").ToString
                            EntQuestionaryHeading.SUBJECT_STATUS_NO = DT5.Rows(j)("SUBJECT_STATUS_NO").ToString
                            EntQuestionaryHeading.SUBJECT_STATUS = DT5.Rows(j)("SUBJECT_STATUS").ToString
                            EntQuestionaryHeading.SUBJECT_TITLE = DT5.Rows(j)("SUBJECT_TITLE").ToString
                            EntQuestionaryHeading.SUBJECT_CONTENT = DT5.Rows(j)("SUBJECT_CONTENT").ToString
                            EntQuestionaryHeading.SUBJECT_TYPE = DT5.Rows(j)("SUBJECT_TYPE").ToString
                            EntQuestionaryHeading.SUBJECT_BS = DT5.Rows(j)("SUBJECT_BS").ToString
                            EntQuestionaryHeading.SUBJECT_RMK = DT5.Rows(j)("SUBJECT_RMK").ToString
                            EntQuestionaryHeading.VECTOR_NO = DT5.Rows(j)("VECTOR_NO").ToString
                            EntQuestionaryHeading.IS_FILL = DT5.Rows(j)("IS_FILL").ToString
                            EntQuestionaryHeading.SUBJECT_TROVMGP = DT5.Rows(j)("SUBJECT_TROVMGP").ToString
                            EntQuestionaryHeading.SUBJECT_SEQ = DT5.Rows(j)("SUBJECT_SEQ").ToString
                            EntQuestionaryHeading.QSTNNR_FORMAT = DT5.Rows(j)("QSTNNR_FORMAT").ToString
                            EntQuestionaryHeading.Insert()

                            Dim row2() As DataRow = DT6.Select(" QSTNNR_NO='" & DT1.Rows(0)("QSTNNR_NO").ToString & "' AND SUBJECT_NO='" & DT5.Rows(j)("SUBJECT_NO") & "'")

                            For icount2 As Integer = 0 To row2.Length - 1
                                EntQuestionaryHeading.MENU_NO = row2(icount2)("MENU_NO").ToString
                                EntQuestionaryHeading.QSTNNR_NO = CQSTNNR
                                EntQuestionaryHeading.SUBJECT_NO = sSUBJECT_NO
                                EntQuestionaryHeading.MENU_TITLE = row2(icount2)("MENU_TITLE").ToString
                                EntQuestionaryHeading.MENU_CONTENT = row2(icount2)("MENU_CONTENT").ToString
                                EntQuestionaryHeading.MENU_STYLE = row2(icount2)("MENU_STYLE").ToString
                                EntQuestionaryHeading.MENU_TROVMGP = row2(icount2)("MENU_TROVMGP").ToString
                                EntQuestionaryHeading.AddItem()
                            Next
                        Next
                    End If

                End If
                Return ""
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteHeadingDegree 刪除題目向度"
        ''' <summary>
        ''' 刪除題目向度 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteHeadingDegree()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== Pkno ===
                If String.IsNullOrEmpty(Me.Pkno) Then
                    faileArguments.Add("Pkno")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntHeadingDegree = New EntHeadingDegree 
                '
                EntHeadingDegree.PKNO = Me.PKNO
                EntHeadingDegree.DeleteByPkNo()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteQuestionary 刪除問卷"
        ''' <summary>
        ''' 刪除問卷 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteQuestionary()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 附件來源 ===
                'If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
                '    faileArguments.Add("ACCE_SOURCE")
                'End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '將問卷資料全部刪除
                '1..刪除主檔
                '2..刪除問卷對象
                '3..刪除附加檔案
                '
                '
                'EntQuestionary New EntQuestionary
                EntQuestionary.SqlRetrictions = " QSTNNR_NO='" & Me.QSTNNR_NO & "'"
                EntQuestionary.Delete()
                '
                'EntQuestionary.EntQuestionaryObj問卷號碼=EntQuestionary.QSTNNR_NO(問卷號碼)
                EntQuestionary.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionary.DeleteQuestionaryObj()
                '
                'EntQuestionary.EntAttachFile.ACCE_SOURCE(附件來源)=EntAttachFile.ACCE_SOURCE(附件來源)
                '
                'EntQuestionary.DeleteAttachFile()

                Dim entFile As EntAttachFile = New EntAttachFile(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                '=== 檢核欄位結束 ===
                Me.ProcessQueryCondition(condition, "=", "ACCE_SOURCE", "QUE1010")      '附件來源
                Me.ProcessQueryCondition(condition, "=", "FILE_NO", Me.QSTNNR_NO)       '檔案號碼

                entFile.SqlRetrictions = " 1=1 " & condition.ToString.Replace("$.", "")
                entFile.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteQuestionaryHeading 刪除題目"
        ''' <summary>
        ''' 刪除題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteQuestionaryHeading()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== Pkno ===
                If String.IsNullOrEmpty(Me.Pkno) Then
                    faileArguments.Add("Pkno")
                End If
                '=== 題目號碼 ===
                If String.IsNullOrEmpty(Me.SUBJECT_NO) Then
                    faileArguments.Add("SUBJECT_NO")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '步驟
                '1.刪除題目主檔
                '
                '2.刪除問卷題目選項
                '
                '必傳入問卷選項table
                '欄位為(QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),選項標號,選項內容,選項樣式,選項權數)
                '
                'EntQuestionaryHeading =New EntQuestionaryHeading
                '
                'EntQuestionaryHeading.DeleteByPkno()
                '
                '
                'EntQuestionaryHeading.EntQuestionaryItem.QSTNNR_NO(問卷號碼)=QSTNNR_NO(問卷號碼)
                'EntQuestionaryHeading.EntQuestionaryItem.SUBJECT_NO(題目號碼)=SUBJECT_NO(題目號碼)
                '
                'EntQuestionaryHeading.DeleteItem()
                '

                Me.EntQuestionaryHeading.PKNO = Me.PKNO
                Me.EntQuestionaryHeading.DeleteByPkNo()

                Me.EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                Me.EntQuestionaryHeading.SUBJECT_NO = Me.SUBJECT_NO

                Me.EntQuestionaryHeading.DeleteItem()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetAttachFile 取得附加檔案"
        ''' <summary>
        ''' 取得附加檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetAttachFile() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 附件來源 ===
                If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
                    faileArguments.Add("ACCE_SOURCE")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntQuestionary New EntQuestionary
                'EntQuestionary.EntAttachFile.QSTNNR_NO(問卷號碼)
                '
                '
                'EntQuestionary.QueryAttachFile()
                Dim condition As StringBuilder = New StringBuilder()
                '=== 檢核欄位結束 ===
                Me.ProcessQueryCondition(condition, "=", "ACCE_SOURCE", Me.ACCE_SOURCE)       '附件來源
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼
                Me.EntQuestionary.SqlRetrictions = condition.ToString()
                EntQuestionary.QSTNNR_NO = Me.QSTNNR_NO

                Me.ResetColumnProperty()

                Return EntQuestionary.QueryAttachFile()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetHeadingDegree 取得題目向度"
        ''' <summary>
        ''' 取得題目向度 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetHeadingDegree() As DataTable
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
                '=== 檢核欄位結束 ===
                Me.ProcessQueryCondition(condition, "=", "Pkno", Me.PKNO)       'Pkno
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "VECTOR_NO", Me.VECTOR_NO)       '向度號碼

                Me.EntHeadingDegree.SqlRetrictions = condition.ToString()
                Me.EntHeadingDegree.OrderBys = "VECTOR_SEQ"
                '=== 處理說明 ===
                'EntHeadingDegree = New EntHeadingDegree 
                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = EntHeadingDegree.Query()
                Else
                    result = EntHeadingDegree.Query(PageNo, PageSize)
                    Me.TotalRowCount = EntHeadingDegree.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetHeadingDegreeDDL 取得題目向度下拉"
        ''' <summary>
        ''' 取得題目向度下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetHeadingDegreeDDL() As DataTable
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
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)   '問卷編號
                Me.EntHeadingDegree.SqlRetrictions = condition.ToString()

                '=== 處理說明 ===
                'EntHeadingDegree = New EntHeadingDegree 
                '
                Dim dt As DataTable = EntHeadingDegree.QueryDegreeDDL()

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetHeadingItem 取得題目選項"
        ''' <summary>
        ''' 取得題目選項 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetHeadingItem() As DataTable
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
                'EntQuestionaryHeading NEW EntQuestionaryHeading()
                '
                'EntQuestionaryHeading.EntQuestionaryItem.QSTNNR_NO(問卷號碼)=@QSTNNR_NO(問卷號碼)
                '
                'EntQuestionaryHeading.EntQuestionaryItem.SUBJECT_NO(題目號碼)=@SUBJECT_NO(題目號碼)
                '
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)   '問卷編號
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)   '問卷編號

                EntQuestionaryHeading.SqlRetrictions = condition.ToString

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = EntQuestionaryHeading.QueryItem()
                Else
                    result = EntQuestionaryHeading.QueryItem(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryHeading.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetHeadingTypeDDL 取得題目類別下拉"
        ''' <summary>
        ''' 取得題目類別下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetHeadingTypeDDL() As DataTable
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
                Dim dt As DataTable = EntQuestionaryHeading.QueryHeadingTypeDDL()

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionary 取得問卷"
        ''' <summary>
        ''' 取得問卷 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetQuestionary() As DataTable
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
                'EntQuestionary.QUERY_COND(查詢條件),"=",Pkno,QSTNNR_NO(問卷號碼))
                '
                '組合查詢字串(
                'EntQuestionary.QUERY_COND(查詢條件),"like%",QSTNNR_TITLE(問卷標題))
                '
                '組合查詢字串(
                'EntQuestionary.QUERY_COND(查詢條件),">=",DEADLINE_DATE(截止日期))
                '
                '

                'EntQuestionary.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                Dim condition As StringBuilder = New StringBuilder()
                '=== 檢核欄位結束 ===
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'pkno
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "QSTNNR_TITLE", Me.QSTNNR_TITLE)       '問卷標題 20160628
                Me.ProcessQueryCondition(condition, "=", "CREATE_UNIT", Me.CREATE_UNIT)
                Me.ProcessQueryCondition(condition, "<=", "UPDRAFT_DATE", Me.UPDRAFT_DATE)       '問卷標題
                Me.ProcessQueryCondition(condition, ">=", "DODRAFT_DATE", Me.DODRAFT_DATE)       '問卷標題
                Me.ProcessQueryCondition(condition, "=", "YEAR(CREATE_TIME)", Me.AYEAR)      '問卷標題	
                Me.ProcessQueryCondition(condition, "<=", "START_DATE", Me.START_DATE)       '問卷標題
                Me.ProcessQueryCondition(condition, ">=", "DEADLINE_DATE", Me.DEADLINE_DATE)         '問卷標題

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.EntQuestionary.SqlRetrictions = condition.ToString().Replace("$.YEAR(CREATE_TIME)", "YEAR(CREATE_TIME)")

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.EntQuestionary.OrderBys = "qstnnr_no desc"
                Else
                    Me.EntQuestionary.OrderBys = Me.OrderBys
                End If

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntQuestionary.Query
                Else
                    result = Me.EntQuestionary.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionary.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryHeading 取得題目"
        ''' <summary>
        ''' 取得題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetQuestionaryHeading() As DataTable
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
                'EntQuestionaryHeading NEW EntQuestionaryHeading()
                '
                '組合查詢字串(
                'EntQuestionaryHeading.QUERY_COND(查詢條件),"=",Pkno,QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),VECTOR_NO(向度號碼))
                '
                'EntQuestionaryHeading.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                'return EntQuestionaryHeading.Query()
                Dim condition As StringBuilder = New StringBuilder()
                '=== 檢核欄位結束 ===
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'Pkno
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)       '題目號碼
                Me.ProcessQueryCondition(condition, "=", "VECTOR_NO", Me.VECTOR_NO)       '向度號碼
                Me.ProcessQueryCondition(condition, "LIKE%", "SUBJECT_CONTENT", Me.SUBJECT_CONTENT)       '向度號碼

                condition.Append(Me.QUERY_COND)

                Me.EntQuestionaryHeading.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                Me.EntQuestionaryHeading.OrderBys = Me.OrderBys

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntQuestionaryHeading.Query
                Else
                    result = Me.EntQuestionaryHeading.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntQuestionaryHeading.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryHeadingData 取得問卷題目資料"
        ''' <summary>
        ''' 取得問卷題目資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub GetQuestionaryHeadingData()
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
                'EntQuestionary NEW EntQuestionary()
                '
                '組合查詢字串(
                'EntQuestionary.QUERY_COND(查詢條件),"=",QSTNNR_NO(問卷號碼))
                '
                '
                'return EntQuestionary.QueryQuestionaryHeading()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetQuestionaryObj 取得問卷對象"
        ''' <summary>
        ''' 取得問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetQuestionaryObj() As DataTable
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
                'EntQuestionary New EntQuestionary
                'EntQuestionary.EntAttachFile.QSTNNR_NO(問卷號碼)
                '
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)       '問卷號碼

                EntQuestionary.SqlRetrictions = condition.ToString

                Dim dt As DataTable = EntQuestionary.QueryQuestionaryObj()

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "SetJuamp 設定跳題"
        ''' <summary>
        ''' 設定跳題 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function SetJuamp() As Integer
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
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)     '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)   '題目號碼
                Me.ProcessQueryCondition(condition, "=", "MENU_NO", Me.MENU_NO)   '選單號碼
                Me.EntQuestionary.SqlRetrictions = condition.ToString

                Me.EntQuestionary.JUMP_NO = Me.JUMP_NO
                Me.EntQuestionary.JUMP_CONTENT = Me.JUMP_CONTENT

                Me.EntQuestionary.UpdateItem()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateHeadingDegree 修改題目向度"
        ''' <summary>
        ''' 修改題目向度 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function UpdateHeadingDegree() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== Pkno ===
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("Pkno")
                End If

                '=== 向度大小 ===
                If String.IsNullOrEmpty(Me.VECTOR_BS) Then
                    faileArguments.Add("VECTOR_BS")
                End If
                '=== 向度權數 ===
                If String.IsNullOrEmpty(Me.VECTOR_TROVMGP) Then
                    faileArguments.Add("VECTOR_TROVMGP")
                End If

                '=== 向度排序 ===
                If String.IsNullOrEmpty(Me.VECTOR_SEQ) Then
                    faileArguments.Add("VECTOR_SEQ")
                End If
                '=== 向度標號 ===
                If String.IsNullOrEmpty(Me.VECTOR_TITLE) Then
                    faileArguments.Add("VECTOR_TITLE")
                End If
                '=== 向度名稱 ===
                If String.IsNullOrEmpty(Me.VECTOR_NAME) Then
                    faileArguments.Add("VECTOR_NAME")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '
                Me.EntHeadingDegree.VECTOR_NAME = Me.VECTOR_NAME  '向度名稱
                Me.EntHeadingDegree.VECTOR_BS = Me.VECTOR_BS    '向度大小
                Me.EntHeadingDegree.VECTOR_SEQ = Me.VECTOR_SEQ   '向度排序
                Me.EntHeadingDegree.VECTOR_TITLE = Me.VECTOR_TITLE '向度標號
                Me.EntHeadingDegree.VECTOR_TROVMGP = Me.VECTOR_TROVMGP   '向度權數
                Me.EntHeadingDegree.VECTOR_TYPE = Me.VECTOR_TYPE  '向度類型
                Me.EntHeadingDegree.QSTNNR_NO = Me.QSTNNR_NO    '問卷號碼
                Me.EntHeadingDegree.PKNO = Me.PKNO
                Me.EntHeadingDegree.VECTOR_TYPE = Me.VECTOR_TYPE
                EntHeadingDegree.ROWSTAMP = Me.ROWSTAMP

                Dim returnValue As Integer = 0

                returnValue = EntHeadingDegree.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return returnValue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateQuestionary 修改問卷"
        ''' <summary>
        ''' 修改問卷 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateQuestionary() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== Pkno ===
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("Pkno")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                Me.EntQuestionary.PKNO = Me.PKNO 'Pkno
                Me.EntQuestionary.UPDRAFT_DATE = Me.UPDRAFT_DATE '上稿日期
                Me.EntQuestionary.DODRAFT_DATE = Me.DODRAFT_DATE '下稿日期
                Me.EntQuestionary.DOWNLOAD_ADDR = Me.DOWNLOAD_ADDR    '參考網址
                Me.EntQuestionary.QSTNNR_SEQ = Me.QSTNNR_SEQ   '問卷排序
                Me.EntQuestionary.QSTNNR_FORMAT = Me.QSTNNR_FORMAT    '問卷格式
                Me.EntQuestionary.QSTNNR_TITLE = Me.QSTNNR_TITLE '問卷標題
                Me.EntQuestionary.QSTNNR_NO = Me.QSTNNR_NO    '問卷號碼
                Me.EntQuestionary.QSTNNR_EXPL = Me.QSTNNR_EXPL  '問卷說明
                Me.EntQuestionary.CREATE_UNIT = Me.CREATE_UNIT  '建立單位
                Me.EntQuestionary.CREATE_UNIT_NAME = Me.CREATE_UNIT_NAME '建立單位名稱
                Me.EntQuestionary.DEADLINE_DATE = Me.DEADLINE_DATE    '截止日期
                Me.EntQuestionary.DEADLINE_TIME = Me.DEADLINE_TIME    '截止時間
                Me.EntQuestionary.IS_USE_SUBJECT_VECTOR = Me.IS_USE_SUBJECT_VECTOR    '是否使用題目向度
                Me.EntQuestionary.IS_ANNOUNCE_OUTER = Me.IS_ANNOUNCE_OUTER    '是否發佈校外
                Me.EntQuestionary.IS_SIGN = Me.IS_SIGN  '是否記名
                Me.EntQuestionary.IS_REPEAT = Me.IS_REPEAT    '是否重複
                Me.EntQuestionary.IS_DISP_RESULT = Me.IS_DISP_RESULT   '是否顯示結果
                Me.EntQuestionary.ANSWER_RATE = Me.ANSWER_RATE  '答案比率
                Me.EntQuestionary.START_DATE = Me.START_DATE   '開始日期
                Me.EntQuestionary.START_TIME = Me.START_TIME   '開始時間


                Dim returnValue As Integer = EntQuestionary.UpdateByPkNo()
                Me.ResetColumnProperty()
                Return returnValue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateQuestionaryHeading 修改題目"
        ''' <summary>
        ''' 修改題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateQuestionaryHeading()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                '=== 題目內容 ===
                If String.IsNullOrEmpty(Me.SUBJECT_CONTENT) Then
                    faileArguments.Add("SUBJECT_CONTENT")
                End If
                '=== 題目類別 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TYPE) Then
                    faileArguments.Add("SUBJECT_TYPE")
                End If
                '=== 題目狀態 ===
                If String.IsNullOrEmpty(Me.SUBJECT_STATUS) Then
                    faileArguments.Add("SUBJECT_STATUS")
                End If
                '=== 題目標號 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TITLE) Then
                    faileArguments.Add("SUBJECT_TITLE")
                End If
                '=== 題目權數 ===
                If String.IsNullOrEmpty(Me.SUBJECT_TROVMGP) Then
                    faileArguments.Add("SUBJECT_TROVMGP")
                End If
                '=== 題目排序 ===
                If String.IsNullOrEmpty(Me.SUBJECT_SEQ) Then
                    faileArguments.Add("SUBJECT_SEQ")
                End If

                '=== DT問卷選項 ===
                If Me.DTQstCho Is Nothing Then
                    faileArguments.Add("DTQstCho")
                Else
                    '=== 檢查DT社團活動規劃有否缺少欄位 ===
                    Dim lostDtColumns As New ArrayList

                    If Me.DTQstCho.Columns.Contains("MENU_NO") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_NO 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_TITLE") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_TITLE 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_CONTENT") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_CONTENT 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_STYLE") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_STYLE 欄位")
                    End If

                    If Me.DTQstCho.Columns.Contains("MENU_TROVMGP") = False Then
                        lostDtColumns.Add("DTQstCho 缺少 MENU_TROVMGP 欄位")
                    End If

                    If lostDtColumns.Count > 0 Then
                        Throw New ArgumentException("", Utility.ArrayListToString(lostDtColumns))
                    End If
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===

                EntQuestionaryHeading.PKNO = Me.PKNO
                'EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryHeading.SUBJECT_STATUS = Me.SUBJECT_STATUS
                EntQuestionaryHeading.SUBJECT_TITLE = Me.SUBJECT_TITLE
                EntQuestionaryHeading.SUBJECT_CONTENT = Me.SUBJECT_CONTENT
                EntQuestionaryHeading.SUBJECT_TYPE = Me.SUBJECT_TYPE
                EntQuestionaryHeading.SUBJECT_BS = Me.SUBJECT_BS
                EntQuestionaryHeading.SUBJECT_RMK = Me.SUBJECT_RMK
                EntQuestionaryHeading.VECTOR_NO = Me.VECTOR_NO
                EntQuestionaryHeading.IS_FILL = Me.IS_FILL
                EntQuestionaryHeading.SUBJECT_TROVMGP = Me.SUBJECT_TROVMGP
                EntQuestionaryHeading.SUBJECT_SEQ = Me.SUBJECT_SEQ
                EntQuestionaryHeading.SUBJECT_MAX = Me.SUBJECT_MAX
                EntQuestionaryHeading.SUBJECT_MIN = Me.SUBJECT_MIN
                EntQuestionaryHeading.QSTNNR_FORMAT = QSTNNR_FORMAT
                'EntQuestionaryHeading.SUBJECT_NO = Me.SUBJECT_NO
                EntQuestionaryHeading.SUBJECT_STATUS_NO = Me.SUBJECT_STATUS_NO '題目狀態數
                EntQuestionaryHeading.PARENT_SNO = Me.PARENT_SNO '父項題目號碼 
                EntQuestionaryHeading.PARENT_MNO = Me.PARENT_MNO '父項選單號碼 
                EntQuestionaryHeading.UpdateByPkNo()

                '先刪除原題目檔
                EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryHeading.SUBJECT_NO = Me.SUBJECT_NO
                EntQuestionaryHeading.DeleteItem()

                '新增題目檔
                For i As Integer = 0 To Me.DTQstCho.Rows.Count - 1
                    EntQuestionaryHeading.MENU_NO = DTQstCho.Rows(i)("MENU_NO").ToString
                    EntQuestionaryHeading.QSTNNR_NO = Me.QSTNNR_NO
                    EntQuestionaryHeading.SUBJECT_NO = Me.SUBJECT_NO
                    EntQuestionaryHeading.MENU_TITLE = DTQstCho.Rows(i)("MENU_TITLE").ToString
                    EntQuestionaryHeading.MENU_CONTENT = DTQstCho.Rows(i)("MENU_CONTENT").ToString
                    EntQuestionaryHeading.MENU_STYLE = DTQstCho.Rows(i)("MENU_STYLE").ToString
                    EntQuestionaryHeading.MENU_TROVMGP = DTQstCho.Rows(i)("MENU_TROVMGP").ToString
                    EntQuestionaryHeading.MENU_RMK = DTQstCho.Rows(i)("MENU_RMK").ToString
                    EntQuestionaryHeading.AddItem()
                Next


                '步驟
                '1.先檢核傳入table的欄位跟型態
                '
                '2.更新題目主檔
                '
                '3.刪除問卷題目選項
                '
                '4.將問卷題目選項屬性設定並新增問卷題目選項
                '
                '必傳入問卷選項table
                '欄位為(QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),選項標號,選項內容,選項樣式,選項權數)
                '
                'EntQuestionaryHeading =New EntQuestionaryHeading
                '
                'EntQuestionaryHeading.UpdateByPkno()
                '
                '
                'EntQuestionaryHeading.EntQuestionaryItem.QSTNNR_NO(問卷號碼)=QSTNNR_NO(問卷號碼)
                'EntQuestionaryHeading.EntQuestionaryItem.SUBJECT_NO(題目號碼)=SUBJECT_NO(題目號碼)
                '
                'EntQuestionaryHeading.DeleteItem()
                '
                '
                'for i to 問卷選項table rows .count-1
                '
                'EntQuestionaryHeading.EntQuestionaryItem.QSTNNR_NO(問卷號碼)[i]=EntQuestionaryHeading.QSTNNR_NO(問卷號碼)
                '
                'EntQuestionaryHeading.EntQuestionaryItem.SUBJECT_NO(題目號碼)[i]=EntQuestionaryHeading.SUBJECT_NO(題目號碼)
                '
                'EntQuestionaryHeading.EntQuestionaryItem.其他欄位[i]=QSTNNR_TARGET(問卷對象)[i]其他欄位
                '
                'EntQuestionaryHeading.AddItem()
                '
                'next

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "QueryItemDDL 查詢文字框下拉"
        ''' <summary>
        ''' 查詢文字框下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryItemDDL() As DataTable
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
                Dim dt As DataTable = EntQuestionary.QueryItemDDL()

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateJumpHeading 修改跳題題目"
        ''' <summary>
        ''' 修改跳題題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateJumpHeading() As Integer
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
                'AEntQuestionary =New EntQuestionary()
                '
                '組合查詢字串(
                'AEntQuestionary.QUERY_COND(查詢條件),"=",QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),PKNO)
                '
                'AEntQuestionary.UpdateJumpHeading_修改跳題題目()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)               'PKNO
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)     '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)   '題目號碼
                Me.EntQuestionary.SqlRetrictions = condition.ToString

                Me.EntQuestionary.JUMP_NO = Me.JUMP_NO

                Dim updateCount As Integer = Me.EntQuestionary.UpdateJumpHeading()

                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetQuestionaryObjSQL 取得問卷對象結構"
        ''' <summary>
        ''' 取得問卷對象結構 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetQuestionaryObjSQL() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 狀態 ===
                If String.IsNullOrEmpty(Me.STATUS) Then
                    faileArguments.Add("STATUS")
                End If
                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntQuestionary = NEW EntQuestionary()
                '
                'AEntQuestionary.QueryQuestionaryObjSQL_查詢問卷對象結構()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)             '問卷號碼

                Me.EntQuestionary.SqlRetrictions = condition.ToString

                Me.EntQuestionary.STATUS = Me.STATUS

                Dim result As String = Me.EntQuestionary.QueryQuestionaryObjSQL

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


