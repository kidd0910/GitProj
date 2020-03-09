'----------------------------------------------------------------------------------
'File Name		: CtMaintainBatch 
'Author			: 
'Description		: CtMaintainBatch 維護批次Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/19	   	Source Create
'0.0.2      2016/07/28   Steven  增加 GetBatchProgram() 函數，取得 BATC020紀錄
'----------------------------------------------------------------------------------

Imports Bat.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Bat.Business
    ''' <summary>
    ''' CtMaintainBatch 維護批次Ct
    ''' </summary>
    Partial Public Class CtMaintainBatch
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "BATCH_JOB_SEQ 批次工作序號"
        ''' <summary>
        ''' BATCH_JOB_SEQ 批次工作序號
        ''' </summary>
        Public Property BATCH_JOB_SEQ() As String
            Get
                Return Me.PropertyMap("BATCH_JOB_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BATCH_JOB_SEQ") = value
            End Set
        End Property
#End Region

#Region "BATCH_SEQ 排程序號"
        ''' <summary>
        ''' BATCH_SEQ 排程序號
        ''' </summary>
        Public Property BATCH_SEQ() As String
            Get
                Return Me.PropertyMap("BATCH_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BATCH_SEQ") = value
            End Set
        End Property
#End Region

#Region "DAY_EXE 每日執行"
        ''' <summary>
        ''' DAY_EXE 每日執行
        ''' </summary>
        Public Property DAY_EXE() As String
            Get
                Return Me.PropertyMap("DAY_EXE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DAY_EXE") = value
            End Set
        End Property
#End Region

#Region "END_PROCESS_DATE_TIME 結束處理日期時間"
        ''' <summary>
        ''' END_PROCESS_DATE_TIME 結束處理日期時間
        ''' </summary>
        Public Property END_PROCESS_DATE_TIME() As String
            Get
                Return Me.PropertyMap("END_PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("END_PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "ESTMT_EXE_EDATE 預估執行訖日"
        ''' <summary>
        ''' ESTMT_EXE_EDATE 預估執行訖日
        ''' </summary>
        Public Property ESTMT_EXE_EDATE() As String
            Get
                Return Me.PropertyMap("ESTMT_EXE_EDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ESTMT_EXE_EDATE") = value
            End Set
        End Property
#End Region

#Region "ESTMT_EXE_SDATE 預估執行起日"
        ''' <summary>
        ''' ESTMT_EXE_SDATE 預估執行起日
        ''' </summary>
        Public Property ESTMT_EXE_SDATE() As String
            Get
                Return Me.PropertyMap("ESTMT_EXE_SDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ESTMT_EXE_SDATE") = value
            End Set
        End Property
#End Region

#Region "EXE_RES 執行結果"
        ''' <summary>
        ''' EXE_RES 執行結果
        ''' </summary>
        Public Property EXE_RES() As String
            Get
                Return Me.PropertyMap("EXE_RES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_RES") = value
            End Set
        End Property
#End Region

#Region "JOB_EXE_STATUS 工作執行狀態"
        ''' <summary>
        ''' JOB_EXE_STATUS 工作執行狀態
        ''' </summary>
        Public Property JOB_EXE_STATUS() As String
            Get
                Return Me.PropertyMap("JOB_EXE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOB_EXE_STATUS") = value
            End Set
        End Property
#End Region

#Region "JOB_EXE_SEQ 執行順序"
        ''' <summary>
        ''' JOB_EXE_SEQ 執行順序
        ''' </summary>
        Public Property JOB_EXE_SEQ() As String
            Get
                Return Me.PropertyMap("JOB_EXE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOB_EXE_SEQ") = value
            End Set
        End Property
#End Region

#Region "MORE_JOB_EXE_STATUS 多個工作執行狀態"
        ''' <summary>
        ''' MORE_JOB_EXE_STATUS 多個工作執行狀態
        ''' </summary>
        Public Property MORE_JOB_EXE_STATUS() As String
            Get
                Return Me.PropertyMap("MORE_JOB_EXE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MORE_JOB_EXE_STATUS") = value
            End Set
        End Property
#End Region

#Region "MONTHLY_EXE 每月執行"
        ''' <summary>
        ''' MONTHLY_EXE 每月執行
        ''' </summary>
        Public Property MONTHLY_EXE() As String
            Get
                Return Me.PropertyMap("MONTHLY_EXE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MONTHLY_EXE") = value
            End Set
        End Property
#End Region

#Region "PARAM_CD 參數代號"
        ''' <summary>
        ''' PARAM_CD 參數代號
        ''' </summary>
        Public Property PARAM_CD() As String
            Get
                Return Me.PropertyMap("PARAM_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARAM_CD") = value
            End Set
        End Property
#End Region

#Region "PARAM_CONTENT 參數內容"
        ''' <summary>
        ''' PARAM_CONTENT 參數內容
        ''' </summary>
        Public Property PARAM_CONTENT() As String
            Get
                Return Me.PropertyMap("PARAM_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARAM_CONTENT") = value
            End Set
        End Property
#End Region

#Region "PARAM_NM 參數名稱"
        ''' <summary>
        ''' PARAM_NM 參數名稱
        ''' </summary>
        Public Property PARAM_NM() As String
            Get
                Return Me.PropertyMap("PARAM_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARAM_NM") = value
            End Set
        End Property
#End Region

#Region "PARAM_SEQ 參數序號"
        ''' <summary>
        ''' PARAM_SEQ 參數序號
        ''' </summary>
        Public Property PARAM_SEQ() As String
            Get
                Return Me.PropertyMap("PARAM_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PARAM_SEQ") = value
            End Set
        End Property
#End Region

#Region "PRE_EXE_DATE 預定執行日期"
        ''' <summary>
        ''' PRE_EXE_DATE 預定執行日期
        ''' </summary>
        Public Property PRE_EXE_DATE() As String
            Get
                Return Me.PropertyMap("PRE_EXE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRE_EXE_DATE") = value
            End Set
        End Property
#End Region

#Region "PRE_EXE_DATE_TIME 預定執行日期時間"
        ''' <summary>
        ''' PRE_EXE_DATE_TIME 預定執行日期時間
        ''' </summary>
        Public Property PRE_EXE_DATE_TIME() As String
            Get
                Return Me.PropertyMap("PRE_EXE_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRE_EXE_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "PRE_EXE_TIME 預定執行時間"
        ''' <summary>
        ''' PRE_EXE_TIME 預定執行時間
        ''' </summary>
        Public Property PRE_EXE_TIME() As String
            Get
                Return Me.PropertyMap("PRE_EXE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRE_EXE_TIME") = value
            End Set
        End Property
#End Region

#Region "PROCESS_DATE_TIME 處理日期時間"
        ''' <summary>
        ''' PROCESS_DATE_TIME 處理日期時間
        ''' </summary>
        Public Property PROCESS_DATE_TIME() As String
            Get
                Return Me.PropertyMap("PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.PropertyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "RECORD_CONTENT 記錄內容"
        ''' <summary>
        ''' RECORD_CONTENT 記錄內容
        ''' </summary>
        Public Property RECORD_CONTENT() As String
            Get
                Return Me.PropertyMap("RECORD_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECORD_CONTENT") = value
            End Set
        End Property
#End Region

#Region "RECORD_NAME 記錄名稱"
        ''' <summary>
        ''' RECORD_NAME 記錄名稱
        ''' </summary>
        Public Property RECORD_NAME() As String
            Get
                Return Me.PropertyMap("RECORD_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECORD_NAME") = value
            End Set
        End Property
#End Region

#Region "RECORD_SEQ 記錄序號"
        ''' <summary>
        ''' RECORD_SEQ 記錄序號
        ''' </summary>
        Public Property RECORD_SEQ() As String
            Get
                Return Me.PropertyMap("RECORD_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECORD_SEQ") = value
            End Set
        End Property
#End Region

#Region "RES_CONTENT 結果內容"
        ''' <summary>
        ''' RES_CONTENT 結果內容
        ''' </summary>
        Public Property RES_CONTENT() As String
            Get
                Return Me.PropertyMap("RES_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RES_CONTENT") = value
            End Set
        End Property
#End Region

#Region "START_PROCESS_DATE_TIME 起始處理日期時間"
        ''' <summary>
        ''' START_PROCESS_DATE_TIME 起始處理日期時間
        ''' </summary>
        Public Property START_PROCESS_DATE_TIME() As String
            Get
                Return Me.PropertyMap("START_PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("START_PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "WEEKLY_EXE 每週執行"
        ''' <summary>
        ''' WEEKLY_EXE 每週執行
        ''' </summary>
        Public Property WEEKLY_EXE() As String
            Get
                Return Me.PropertyMap("WEEKLY_EXE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("WEEKLY_EXE") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.PropertyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH") = value
            End Set
        End Property
#End Region

#Region "PROG_TYPE 程式類別"
        ''' <summary>
        ''' PROG_TYPE 程式類別
        ''' </summary>
        Public Property PROG_TYPE As String
            Get
                Return Me.PropertyMap("PROG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_TYPE") = value
            End Set
        End Property
#End Region

#Region "BATCH_CYCLE 批次週期"
        ''' <summary>
        ''' BATCH_CYCLE 批次週期
        ''' </summary>
        Public Property BATCH_CYCLE As String
            Get
                Return Me.PropertyMap("BATCH_CYCLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BATCH_CYCLE") = value
            End Set
        End Property
#End Region

#Region "EXE_YEAR 執行年度"
        ''' <summary>
        ''' EXE_YEAR 執行年度
        ''' </summary>
        Public Property EXE_YEAR As String
            Get
                Return Me.PropertyMap("EXE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_YEAR") = value
            End Set
        End Property
#End Region

#Region "DAYS 天數"
        ''' <summary>
        ''' DAYS 天數
        ''' </summary>
        Public Property DAYS As String
            Get
                Return Me.PropertyMap("DAYS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DAYS") = value
            End Set
        End Property
#End Region


#Region "EntBatchProg 批次程式名稱ENT"
        ''' <summary>
        ''' EntBatchProg 批次程式名稱ENT
        ''' </summary>
        Private Property EntBatchProg() As EntBatchProg
            Get
                Return Me.PropertyMap("EntBatchProg")
            End Get
            Set(ByVal value As EntBatchProg)
                Me.PropertyMap("EntBatchProg") = value
            End Set
        End Property
#End Region

#Region "EXE_PERIOD_SDATE 執行期間起日"
        ''' <summary>
        ''' EXE_PERIOD_SDATE 執行期間起日
        ''' </summary>
        Public Property EXE_PERIOD_SDATE As String
            Get
                Return Me.PropertyMap("EXE_PERIOD_SDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_PERIOD_SDATE") = value
            End Set
        End Property
#End Region

#Region "EXE_PERIOD_EDATE 執行期間訖日"
        ''' <summary>
        ''' EXE_PERIOD_EDATE 執行期間訖日
        ''' </summary>
        Public Property EXE_PERIOD_EDATE As String
            Get
                Return Me.PropertyMap("EXE_PERIOD_EDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_PERIOD_EDATE") = value
            End Set
        End Property
#End Region

#Region "INFORM_TARGET 通知對象"
        ''' <summary>
        ''' INFORM_TARGET 通知對象
        ''' </summary>
        Public Property INFORM_TARGET As String
            Get
                Return Me.PropertyMap("INFORM_TARGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INFORM_TARGET") = value
            End Set
        End Property
#End Region

#Region "OTH_TARGET 其他對象"
        ''' <summary>
        ''' OTH_TARGET 其他對象
        ''' </summary>
        Public Property OTH_TARGET As String
            Get
                Return Me.PropertyMap("OTH_TARGET")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTH_TARGET") = value
            End Set
        End Property
#End Region

#Region "UNDERTAKER_ACNT 承辦人"
        ''' <summary>
        ''' UNDERTAKER_ACNT 承辦人
        ''' </summary>
        Public Property UNDERTAKER_ACNT As String
            Get
                Return Me.PropertyMap("UNDERTAKER_ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UNDERTAKER_ACNT") = value
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
            Me.EntBatchProg = New EntBatchProg(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "方法"
#Region "AddBatchParam 新增批次參數"
        ''' <summary>
        ''' 新增批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddBatchParam()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 批次工作序號 ===
                If String.IsNullOrEmpty(Me.BATCH_JOB_SEQ) Then
                    faileArguments.Add("BATCH_JOB_SEQ")
                End If

                '=== 程式代號 ===
                If String.IsNullOrEmpty(Me.PROG_CD) Then
                    faileArguments.Add("PROG_CD")
                End If

                '=== 參數序號 ===
                If String.IsNullOrEmpty(Me.PARAM_SEQ) Then
                    faileArguments.Add("PARAM_SEQ")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.AddBatchParam_新增批次參數()

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)

                entBatSch.PARAM_CD = Me.PARAM_CD '參數代號
                entBatSch.PARAM_CONTENT = Me.PARAM_CONTENT    '參數內容
                entBatSch.PARAM_SEQ = Me.PARAM_SEQ    '參數序號
                entBatSch.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ    '批次工作序號
                entBatSch.PROG_CD = Me.PROG_CD  '程式代號

                entBatSch.AddBatchParam()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddBatchRecord 新增批次記錄"
        ''' <summary>
        ''' 新增批次記錄BATT010
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddBatchRecord()
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.AddBatchRecord_新增批次記錄()

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)

                entBatSch.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ      '批次工作序號
                entBatSch.PROG_CD = Me.PROG_CD                  '程式代號
                entBatSch.RECORD_CONTENT = Me.RECORD_CONTENT    '記錄內容
                entBatSch.RECORD_NAME = Me.RECORD_NAME          '記錄名稱
                entBatSch.RECORD_SEQ = Me.RECORD_SEQ            '記錄序號
                entBatSch.IS_BATCH = Me.IS_BATCH
                entBatSch.AddBatchRecord()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddBatchSchedule 新增批次排程"
        ''' <summary>
        ''' 新增批次排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddBatchSchedule()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 批次工作序號 ===
                If String.IsNullOrEmpty(Me.BATCH_JOB_SEQ) Then
                    faileArguments.Add("BATCH_JOB_SEQ")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.Insert()

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)

                entBatSch.EXE_RES = Me.EXE_RES                                '執行結果
                entBatSch.JOB_EXE_STATUS = Me.JOB_EXE_STATUS                  '工作執行狀態
                entBatSch.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ                    '批次工作序號
                entBatSch.PROG_CD = Me.PROG_CD                                '程式代號
                entBatSch.END_PROCESS_DATE_TIME = Me.END_PROCESS_DATE_TIME    '結束處理日期時間
                entBatSch.RES_CONTENT = Me.RES_CONTENT                        '結果內容
                entBatSch.START_PROCESS_DATE_TIME = Me.START_PROCESS_DATE_TIME  '起始處理日期時間
                entBatSch.PRE_EXE_DATE_TIME = Me.PRE_EXE_DATE_TIME            '預定執行日期時間
                entBatSch.INFORM_TARGET = Me.INFORM_TARGET
                entBatSch.OTH_TARGET = Me.OTH_TARGET
                entBatSch.PROG_TYPE = Me.PROG_TYPE
                entBatSch.UNDERTAKER_ACNT = Me.UNDERTAKER_ACNT
                entBatSch.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddProBatchParam 新增程式批次參數"
        ''' <summary>
        ''' 新增程式批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddProBatchParam()
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
                'EntProBatchParam = new EntProBatchParam()
                'return EntProBatchParam.Insert()
                Dim AEntProBatchParam As New EntProBatchParam(Me.DBManager, Me.LogUtil)
                AEntProBatchParam.PKNO = Me.PKNO
                AEntProBatchParam.PROG_CD = Me.PROG_CD
                AEntProBatchParam.PARAM_SEQ = Me.PARAM_SEQ
                AEntProBatchParam.PARAM_CD = Me.PARAM_CD
                AEntProBatchParam.PARAM_NM = Me.PARAM_NM

                AEntProBatchParam.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddScheduleParam 新增排程參數"
        ''' <summary>
        ''' 新增排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddScheduleParam()
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
                Dim EntScheduleSet As EntScheduleSet = New EntScheduleSet(DBManager, LogUtil)
                'return EntScheduleParam.AddScheduleParam_新增排程參數()
                EntScheduleSet.PARAM_CD = Me.PARAM_CD
                EntScheduleSet.PARAM_CONTENT = Me.PARAM_CONTENT
                EntScheduleSet.PARAM_SEQ = Me.PARAM_SEQ
                EntScheduleSet.BATCH_SEQ = Me.BATCH_SEQ
                EntScheduleSet.PROG_CD = Me.PROG_CD

                EntScheduleSet.AddScheduleParam()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddScheduleSet 新增排程設定"
        ''' <summary>
        ''' 新增排程設定 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddScheduleSet()
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
                'EntScheduleSet = new EntScheduleSet()
                'return EntScheduleSet.Insert()
                Dim AEntScheduleSet As New EntScheduleSet(Me.DBManager, Me.LogUtil)
                AEntScheduleSet.BATCH_SEQ = Me.BATCH_SEQ
                AEntScheduleSet.PROG_CD = Me.PROG_CD
                AEntScheduleSet.PROG_TYPE = Me.PROG_TYPE
                AEntScheduleSet.MONTHLY_EXE = Me.MONTHLY_EXE
                AEntScheduleSet.WEEKLY_EXE = Me.WEEKLY_EXE
                AEntScheduleSet.DAY_EXE = Me.DAY_EXE
                AEntScheduleSet.PRE_EXE_DATE = Me.PRE_EXE_DATE
                AEntScheduleSet.PRE_EXE_TIME = Me.PRE_EXE_TIME
                AEntScheduleSet.PROCESS_DATE_TIME = Me.PROCESS_DATE_TIME
                AEntScheduleSet.BATCH_CYCLE = Me.BATCH_CYCLE
                AEntScheduleSet.DAYS = Me.DAYS
                AEntScheduleSet.EXE_PERIOD_SDATE = Me.EXE_PERIOD_SDATE
                AEntScheduleSet.EXE_PERIOD_EDATE = Me.EXE_PERIOD_EDATE
                AEntScheduleSet.INFORM_TARGET = Me.INFORM_TARGET
                AEntScheduleSet.OTH_TARGET = Me.OTH_TARGET
                AEntScheduleSet.UNDERTAKER_ACNT = Me.UNDERTAKER_ACNT
                AEntScheduleSet.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteBatchParam 刪除批次參數"
        ''' <summary>
        ''' 刪除批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteBatchParam()
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.DeleteBatchParam_刪除批次參數()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteBatchRecord 刪除批次記錄"
        ''' <summary>
        ''' 刪除批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteBatchRecord()
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.DeleteBatchRecord_刪除批次記錄()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteBatchSchedule 刪除批次排程"
        ''' <summary>
        ''' 刪除批次排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteBatchSchedule()
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
                Dim ent As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO
                ent.DeleteByPkNo()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteProBatchParam 刪除程式批次參數"
        ''' <summary>
        ''' 刪除程式批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteProBatchParam()
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
                'EntProBatchParam = new EntProBatchParam()
                'return EntProBatchParam.DeleteByPkno()
                Dim AEntProBatchParam As New EntProBatchParam(Me.DBManager, Me.LogUtil)
                AEntProBatchParam.PKNO = Me.PKNO
                AEntProBatchParam.DeleteByPkNo()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteScheduleParam 刪除排程參數"
        ''' <summary>
        ''' 刪除排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteScheduleParam()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== Pkno ===
                If String.IsNullOrEmpty(Me.BATCH_SEQ) Then
                    faileArguments.Add("BATCH_SEQ")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.DeleteScheduleParam_刪除排程參數()
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "BATCH_SEQ", Me.BATCH_SEQ)

                Dim AEntScheduleParam As New EntScheduleParam(Me.DBManager, Me.LogUtil)
                AEntScheduleParam.SqlRetrictions = Me.ProcessCondition(condition.ToString)
                AEntScheduleParam.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteScheduleSet 刪除排程設定"
        ''' <summary>
        ''' 刪除排程設定 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteScheduleSet()
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
                'EntScheduleSet = new EntScheduleSet()
                'return EntScheduleSet.DeleteByPkno()

                Dim AEntScheduleSet As New EntScheduleSet(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)      'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_SEQ", Me.BATCH_SEQ)
                AEntScheduleSet.SqlRetrictions = Me.ProcessCondition(condition.ToString)
                AEntScheduleSet.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetBatchParam 取得批次參數"
        ''' <summary>
        ''' 取得批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchParam() As DataTable
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.GetBatchParam_取得批次參數()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                           'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)         '批次工作序號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)                     '程式代號
                Me.ProcessQueryCondition(condition, "=", "PARAM_CD", Me.PARAM_CD)                   '參數代號
                Me.ProcessQueryCondition(condition, "LIKE%", "PARAM_CONTENT", Me.PARAM_CONTENT)     '參數內容
                Me.ProcessQueryCondition(condition, "=", "PARAM_SEQ", Me.PARAM_SEQ)                 '參數序號
                Me.ProcessQueryCondition(condition, "=", "JOB_EXE_STATUS", Me.JOB_EXE_STATUS)       '工作執行狀態

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)
                entBatSch.SqlRetrictions = condition.ToString

                '=== 處理取得回傳資料 ===
                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = entBatSch.GetBatchParam
                Else
                    result = entBatSch.GetBatchParam(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = entBatSch.TOTAL_ROW_COUNT
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchRecord 取得批次記錄"
        ''' <summary>
        ''' 取得批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchRecord() As DataTable
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.GetBatchRecord_取得批次記錄()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                           'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)         '批次工作序號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)                     '程式代號
                Me.ProcessQueryCondition(condition, "LIKE%", "RECORD_CONTENT", Me.RECORD_CONTENT)   '記錄內容
                Me.ProcessQueryCondition(condition, "=", "RECORD_NAME", Me.RECORD_NAME)             '執行結果
                Me.ProcessQueryCondition(condition, "=", "RECORD_SEQ", Me.RECORD_SEQ)               '記錄序號

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)
                entBatSch.SqlRetrictions = condition.ToString

                '=== 處理取得回傳資料 ===
                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = entBatSch.GetBatchRecord
                Else
                    result = entBatSch.GetBatchRecord(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = entBatSch.entBatRecord.TotalRowCount ' .TOTAL_ROW_COUNT
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchSchedule 取得批次排程"
        ''' <summary>
        ''' 取得批次排程 
        ''' </summary>
        ''' <param name="bMoreType">預設false, 若為true 則抓取 prog_type in (1,2,3) 之項目</param> 
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchSchedule(Optional ByVal bMoreType As Boolean = False) As DataTable
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.GetBatchschedule_取得批次排程()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                           'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)         '批次工作序號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)                     '程式代號                
                Me.ProcessQueryCondition(condition, "=", "JOB_EXE_STATUS", Me.JOB_EXE_STATUS)       '工作執行狀態
                'Me.ProcessQueryCondition(condition, "IN", "JOB_EXE_STATUS", Me.MORE_JOB_EXE_STATUS) '多個工作執行狀態
                Me.ProcessQueryCondition(condition, "=", "EXE_RES", Me.EXE_RES)                     '執行結果
                Me.ProcessQueryCondition(condition, ">=", "CONVERT(varchar,M.PRE_EXE_DATE_TIME,111)", Me.ESTMT_EXE_SDATE)  '預估執行起日
                Me.ProcessQueryCondition(condition, "<=", "CONVERT(varchar,M.PRE_EXE_DATE_TIME,111)", Me.ESTMT_EXE_EDATE)  '預估執行訖日

                '若上面方式可行，就不用這邊設定了
                If Not String.IsNullOrEmpty(Me.MORE_JOB_EXE_STATUS) Then
                    condition.Append(" AND JOB_EXE_STATUS in (" + Me.MORE_JOB_EXE_STATUS + ")")
                End If


                '2016/07/28 Steven : 特別設限, 避免跟 in (1,2,3) 衝突
                If Not bMoreType Then
                    Me.ProcessQueryCondition(condition, "=", "PROG_TYPE", Me.PROG_TYPE)                     'PROG_TYPE
                Else
                    condition.Append(" AND PROG_TYPE in ('1','2','3') ")
                End If

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)
                entBatSch.SqlRetrictions = condition.ToString
                entBatSch.OrderBys = Me.OrderBys

                '=== 處理取得回傳資料 ===
                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = entBatSch.GetBatchschedule()
                Else
                    result = entBatSch.GetBatchschedule(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = entBatSch.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetMaxProPrarmNum 取得程式參數最大流水號"
        ''' <summary>
        ''' 取得程式參數最大流水號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetMaxProPrarmNum() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 程式代號 ===
                If String.IsNullOrEmpty(Me.PROG_CD) Then
                    faileArguments.Add("PROG_CD")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntProBatchParam = new EntProBatchParam()
                'return EntProBatchParam.GetMaxProPrarmNum_取得程式參數最大流水號()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)      'PROG_CD

                Dim AEntProBatchParam As New EntProBatchParam(Me.DBManager, Me.LogUtil)
                AEntProBatchParam.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Return AEntProBatchParam.GetMaxProPrarmNum().Rows(0).Item(0).ToString

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetProBatchParam 取得程式批次參數"
        ''' <summary>
        ''' 取得程式批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetProBatchParam() As DataTable
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
                'EntProBatchParam = new EntProBatchParam()
                'return EntProBatchParam.GetProBatchParam_取得程式批次參數()
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "M.PKNO", Me.PKNO)      'PKNO
                Me.ProcessQueryCondition(condition, "=", "M.PROG_CD", Me.PROG_CD)

                Dim AEntProBatchParam As New EntProBatchParam(Me.DBManager, Me.LogUtil)

                AEntProBatchParam.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = AEntProBatchParam.GetProBatchParam()
                Else
                    result = AEntProBatchParam.GetProBatchParam(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = AEntProBatchParam.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetScheduleParam 取得排程參數"
        ''' <summary>
        ''' 取得排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetScheduleParam() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim EntScheduleSet As EntScheduleSet = New EntScheduleSet(DBManager, LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)      'PKNO
                Me.ProcessQueryCondition(condition, "=", "PARAM_CD", Me.PARAM_CD)
                Me.ProcessQueryCondition(condition, "=", "PARAM_CONTENT", Me.PARAM_CONTENT)
                Me.ProcessQueryCondition(condition, "=", "PARAM_SEQ", Me.PARAM_SEQ)
                Me.ProcessQueryCondition(condition, "=", "BATCH_SEQ", Me.BATCH_SEQ)
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)
                EntScheduleSet.SqlRetrictions = Me.ProcessCondition(condition.ToString)
                Dim dt As DataTable = New DataTable
                '=== 處理說明 ===



                'return EntScheduleParam.GetScheduleParam_取得排程參數()
                If Me.PageNo = 0 Then
                    dt = EntScheduleSet.GetScheduleParam
                Else
                    dt = EntScheduleSet.GetScheduleParam(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = EntScheduleSet.EntScheduleParam.TotalRowCount
                End If
                Me.ResetColumnProperty()
                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetScheduleSet 取得排程設定"
        ''' <summary>
        ''' 取得排程設定 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetScheduleSet() As DataTable
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
                'EntScheduleSet = new EntScheduleSet()
                'return EntScheduleSet.GetScheduleSet_取得排程設定()

                Dim condition As StringBuilder = New StringBuilder()
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.AppendLine(" AND M.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "M.BATCH_SEQ", Me.BATCH_SEQ)
                Me.ProcessQueryCondition(condition, "=", "M.PROG_CD", Me.PROG_CD)
                Me.ProcessQueryCondition(condition, "=", "M.PROG_TYPE", Me.PROG_TYPE)
                Me.ProcessQueryCondition(condition, "=", "M.BATCH_CYCLE", Me.BATCH_CYCLE)
                Me.ProcessQueryCondition(condition, "=", "M.DAYS", Me.DAYS)
                If Not String.IsNullOrEmpty(Me.EXE_YEAR) Then
                    Me.ProcessQueryCondition(condition, ">=", "CONVERT(varchar,M.EXE_PERIOD_SDATE,111)", Convert.ToInt16(Me.EXE_YEAR) + 1911 & "/01/01")
                    Me.ProcessQueryCondition(condition, "<=", "CONVERT(varchar,M.EXE_PERIOD_SDATE,111)", Convert.ToInt16(Me.EXE_YEAR) + 1911 & "/12/31")
                End If
               
                Dim AEntScheduleSet As New EntScheduleSet(Me.DBManager, Me.LogUtil)

                AEntScheduleSet.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = AEntScheduleSet.GetScheduleSet()
                Else
                    result = AEntScheduleSet.GetScheduleSet(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = AEntScheduleSet.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetShExeBatch 取得應執行批次"
        ''' <summary>
        ''' 取得應執行批次 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub GetShExeBatch()
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
                'EntScheduleSet = new EntScheduleSet()
                'return EntScheduleSet.GetShExeBatch_取得應執行批次()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetShExeSchedule 取得應執行排程"
        ''' <summary>
        ''' 取得應執行排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub GetShExeSchedule()
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
                'EntScheduleSet = new EntScheduleSet()
                'return EntScheduleSet.GetShExeSchedule_取得應執行排程()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateBatchParam 更新批次參數"
        ''' <summary>
        ''' 更新批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateBatchParam()
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.UpdateBatchParam_更新批次參數()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateBatchRecord 更新批次記錄"
        ''' <summary>
        ''' 更新批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateBatchRecord()
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.UpdateBatchRecord_更新批次記錄()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateBatchSchedule 更新批次排程"
        ''' <summary>
        ''' 更新批次排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateBatchSchedule() As Integer
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
                'EntBatchSchedule = new EntBatchSchedule()
                'return EntBatchSchedule.UpdateByPkno()

                Dim condition As StringBuilder = New StringBuilder
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                           'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)         '批次工作序號
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)                     '程式代號

                Dim entBatSch As EntBatchSchedule = New EntBatchSchedule(Me.DBManager, Me.LogUtil)

                entBatSch.SqlRetrictions = condition.ToString

                entBatSch.PKNO = Me.PKNO                                        'Pkno
                entBatSch.EXE_RES = Me.EXE_RES                                  '執行結果
                If Not String.IsNullOrEmpty(Me.JOB_EXE_STATUS) Then entBatSch.JOB_EXE_STATUS = Me.JOB_EXE_STATUS '工作執行狀態
                If Not String.IsNullOrEmpty(Me.BATCH_JOB_SEQ) Then entBatSch.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ '批次工作序號
                If Not String.IsNullOrEmpty(Me.PROG_CD) Then entBatSch.PROG_CD = Me.PROG_CD '程式代號
                If Not String.IsNullOrEmpty(Me.END_PROCESS_DATE_TIME) Then entBatSch.END_PROCESS_DATE_TIME = Me.END_PROCESS_DATE_TIME '結束處理日期時間
                If Not String.IsNullOrEmpty(Me.RES_CONTENT) Then entBatSch.RES_CONTENT = Me.RES_CONTENT '結果內容
                If Not String.IsNullOrEmpty(Me.START_PROCESS_DATE_TIME) Then entBatSch.START_PROCESS_DATE_TIME = Me.START_PROCESS_DATE_TIME '起始處理日期時間
                If Not String.IsNullOrEmpty(Me.PRE_EXE_DATE_TIME) Then entBatSch.PRE_EXE_DATE_TIME = Me.PRE_EXE_DATE_TIME '預定執行日期時間
                If Not String.IsNullOrEmpty(Me.IS_BATCH) Then entBatSch.IS_BATCH = Me.IS_BATCH
                If Not String.IsNullOrEmpty(Me.JOB_EXE_SEQ) Then entBatSch.JOB_EXE_SEQ = Me.JOB_EXE_SEQ '工作順序
                Dim updateCount As Integer = entBatSch.UpdateBatchSchedule

                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateProBatchParam 更新程式批次參數"
        ''' <summary>
        ''' 更新程式批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateProBatchParam() As Integer
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
                'EntProBatchParam = new EntProBatchParam()
                'return EntProBatchParam.UpdateByPkno()

                Dim AEntProBatchParam As New EntProBatchParam(Me.DBManager, Me.LogUtil)
                AEntProBatchParam.PKNO = Me.PKNO
                AEntProBatchParam.PROG_CD = Me.PROG_CD
                AEntProBatchParam.PARAM_SEQ = Me.PARAM_SEQ
                AEntProBatchParam.PARAM_CD = Me.PARAM_CD
                AEntProBatchParam.PARAM_NM = Me.PARAM_NM


                Dim updateCount As Integer = AEntProBatchParam.UpdateByPkNo()

                Me.ResetColumnProperty()
                Return updateCount
 
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateScheduleParam 更新排程參數"
        ''' <summary>
        ''' 更新排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateScheduleParam()
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
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.UpdateScheduleParam_更新排程參數()
                Dim EntScheduleSet As EntScheduleSet = New EntScheduleSet(DBManager, LogUtil)

                EntScheduleSet.PARAM_CD = Me.PARAM_CD
                EntScheduleSet.PARAM_CONTENT = Me.PARAM_CONTENT
                EntScheduleSet.PARAM_SEQ = Me.PARAM_SEQ
                EntScheduleSet.BATCH_SEQ = Me.BATCH_SEQ
                EntScheduleSet.PROG_CD = Me.PROG_CD
                EntScheduleSet.PKNO = Me.PKNO
                EntScheduleSet.UpdateByPkNo()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateScheduleSet 更新排程設定"
        ''' <summary>
        ''' 更新排程設定 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateScheduleSet() As Integer
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
                'EntScheduleSet = new EntScheduleSet()
                '組合查詢字串(EntScheduleSet.QUERY_COND(查詢條件),"=",Pkno,BATCH_SEQ(排程序號),PROG_CD(程式代號))
                'return EntScheduleSet.Update()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "BATCH_SEQ", Me.BATCH_SEQ)   'BATCH_SEQ
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)   'PROG_CD
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO

                Dim AEntScheduleSet As New EntScheduleSet(Me.DBManager, Me.LogUtil)
                AEntScheduleSet.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                AEntScheduleSet.PKNO = Me.PKNO
                AEntScheduleSet.BATCH_SEQ = Me.BATCH_SEQ
                AEntScheduleSet.PROG_CD = Me.PROG_CD
                AEntScheduleSet.PROG_TYPE = Me.PROG_TYPE
                AEntScheduleSet.MONTHLY_EXE = Me.MONTHLY_EXE
                AEntScheduleSet.WEEKLY_EXE = Me.WEEKLY_EXE
                AEntScheduleSet.DAY_EXE = Me.DAY_EXE
                AEntScheduleSet.PRE_EXE_DATE = Me.PRE_EXE_DATE
                AEntScheduleSet.PRE_EXE_TIME = Me.PRE_EXE_TIME
                AEntScheduleSet.PROCESS_DATE_TIME = Me.PROCESS_DATE_TIME
                AEntScheduleSet.BATCH_CYCLE = Me.BATCH_CYCLE
                AEntScheduleSet.DAYS = Me.DAYS
                AEntScheduleSet.EXE_PERIOD_SDATE = Me.EXE_PERIOD_SDATE
                AEntScheduleSet.EXE_PERIOD_EDATE = Me.EXE_PERIOD_EDATE
                AEntScheduleSet.INFORM_TARGET = Me.INFORM_TARGET
                AEntScheduleSet.OTH_TARGET = Me.OTH_TARGET
                AEntScheduleSet.UNDERTAKER_ACNT = Me.UNDERTAKER_ACNT

                Dim updateCount As Integer = AEntScheduleSet.Update()

                Me.ResetColumnProperty()
                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

        ''' <summary>
        ''' 查詢排程紀錄 BATC020
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBatchProgram() As DataTable
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
                'EntBatchProg = new EntBatchProg()
                'return EntBatchProg.GetBatchProgramDDL_取得批次程式下拉()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)   'PROG_CD
                Me.ProcessQueryCondition(condition, "=", "PROG_TYPE", Me.PROG_TYPE)   'PROG_TYPE
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.EntBatchProg.SqlRetrictions = condition.ToString()
                Me.EntBatchProg.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.EntBatchProg.Query()               
                Me.ResetColumnProperty()
                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#Region "GetBatchProgramDDL 取得批次程式下拉"
        ''' <summary>
        ''' 取得批次程式下拉
        ''' </summary>
        ''' <param name="bMoreType">預設false, 若為true 則抓取 prog_type in (1,2,3) 之項目</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBatchProgramDDL(Optional ByVal bMoreType As Boolean = False) As DataTable
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
                'EntBatchProg = new EntBatchProg()
                'return EntBatchProg.GetBatchProgramDDL_取得批次程式下拉()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()              
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                '2016/07/28 Steven : 特別設限, 避免跟 in (1,2,3) 衝突
                If Not bMoreType Then
                    Me.ProcessQueryCondition(condition, "=", "PROG_TYPE", Me.PROG_TYPE) 'PROG_TYPE
                Else
                    condition.Append(" AND PROG_TYPE in ('1','2','3') ")
                End If
                Me.EntBatchProg.SqlRetrictions = condition.ToString()
                Me.EntBatchProg.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntBatchProg.GetBatchProgramDDL()
                Else
                    result = Me.EntBatchProg.GetBatchProgramDDL(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntBatchProg.TotalRowCount
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


