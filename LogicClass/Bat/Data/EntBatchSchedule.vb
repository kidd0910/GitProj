'----------------------------------------------------------------------------------
'File Name		: EntBatchSchedule
'Author			: 
'Description		: EntBatchSchedule 批次排程ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/19			Source Create
'0.0.2      2016/07/29 Steven  添加 SYST010的串接取得執行狀態描述
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Bat.Data
    '' <summary>
    '' EntBatchSchedule 批次排程ENT
    '' </summary>
    Public Class EntBatchSchedule
        Inherits Aut.Data.EntSysProgram
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "BATT010"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
             Me.entBatRecord = New EntBatchRecord(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "entBatRecord "
        ''' <summary>
        ''' entBatRecord 
        ''' </summary>
        Public Property entBatRecord() As EntBatchRecord
            Get
                Return Me.PropertyMap("entBatRecord")
            End Get
            Set(ByVal value As EntBatchRecord)
                Me.PropertyMap("entBatRecord") = value
            End Set
        End Property
#End Region
#Region "BATCH_JOB_SEQ 批次工作序號"
        ''' <summary>
        ''' BATCH_JOB_SEQ 批次工作序號
        ''' </summary>
        Public Property BATCH_JOB_SEQ() As String
            Get
                Return Me.ColumnyMap("BATCH_JOB_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_JOB_SEQ") = value
            End Set
        End Property
#End Region

#Region "END_PROCESS_DATE_TIME 結束處理日期時間"
        ''' <summary>
        ''' END_PROCESS_DATE_TIME 結束處理日期時間
        ''' </summary>
        Public Property END_PROCESS_DATE_TIME() As String
            Get
                Return Me.ColumnyMap("END_PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("END_PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "EXE_RES 執行結果"
        ''' <summary>
        ''' EXE_RES 執行結果
        ''' </summary>
        Public Property EXE_RES() As String
            Get
                Return Me.ColumnyMap("EXE_RES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_RES") = value
            End Set
        End Property
#End Region

#Region "JOB_EXE_STATUS 工作執行狀態"
        ''' <summary>
        ''' JOB_EXE_STATUS 工作執行狀態
        ''' </summary>
        Public Property JOB_EXE_STATUS() As String
            Get
                Return Me.ColumnyMap("JOB_EXE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOB_EXE_STATUS") = value
            End Set
        End Property
#End Region

#Region "JOB_EXE_SEQ 執行順序"
        ''' <summary>
        ''' JOB_EXE_SEQ 執行順序
        ''' </summary>
        Public Property JOB_EXE_SEQ As String
            Get
                Return Me.ColumnyMap("JOB_EXE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOB_EXE_SEQ") = value
            End Set
        End Property
#End Region

#Region "PARAM_CD 參數代號"
        ''' <summary>
        ''' PARAM_CD 參數代號
        ''' </summary>
        Public Property PARAM_CD() As String
            Get
                Return Me.ColumnyMap("PARAM_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_CD") = value
            End Set
        End Property
#End Region

#Region "PARAM_CONTENT 參數內容"
        ''' <summary>
        ''' PARAM_CONTENT 參數內容
        ''' </summary>
        Public Property PARAM_CONTENT() As String
            Get
                Return Me.ColumnyMap("PARAM_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_CONTENT") = value
            End Set
        End Property
#End Region

#Region "PARAM_SEQ 參數序號"
        ''' <summary>
        ''' PARAM_SEQ 參數序號
        ''' </summary>
        Public Property PARAM_SEQ() As String
            Get
                Return Me.ColumnyMap("PARAM_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_SEQ") = value
            End Set
        End Property
#End Region

#Region "PRE_EXE_DATE_TIME 預定執行日期時間"
        ''' <summary>
        ''' PRE_EXE_DATE_TIME 預定執行日期時間
        ''' </summary>
        Public Property PRE_EXE_DATE_TIME() As String
            Get
                Return Me.ColumnyMap("PRE_EXE_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRE_EXE_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "RECORD_CONTENT 記錄內容"
        ''' <summary>
        ''' RECORD_CONTENT 記錄內容
        ''' </summary>
        Public Property RECORD_CONTENT() As String
            Get
                Return Me.ColumnyMap("RECORD_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_CONTENT") = value
            End Set
        End Property
#End Region

#Region "RECORD_NAME 記錄名稱"
        ''' <summary>
        ''' RECORD_NAME 記錄名稱
        ''' </summary>
        Public Property RECORD_NAME() As String
            Get
                Return Me.ColumnyMap("RECORD_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_NAME") = value
            End Set
        End Property
#End Region

#Region "RECORD_SEQ 記錄序號"
        ''' <summary>
        ''' RECORD_SEQ 記錄序號
        ''' </summary>
        Public Property RECORD_SEQ() As String
            Get
                Return Me.ColumnyMap("RECORD_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORD_SEQ") = value
            End Set
        End Property
#End Region

#Region "RES_CONTENT 結果內容"
        ''' <summary>
        ''' RES_CONTENT 結果內容
        ''' </summary>
        Public Property RES_CONTENT() As String
            Get
                Return Me.ColumnyMap("RES_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RES_CONTENT") = value
            End Set
        End Property
#End Region

#Region "START_PROCESS_DATE_TIME 起始處理日期時間"
        ''' <summary>
        ''' START_PROCESS_DATE_TIME 起始處理日期時間
        ''' </summary>
        Public Property START_PROCESS_DATE_TIME() As String
            Get
                Return Me.ColumnyMap("START_PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("START_PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.ColumnyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_BATCH") = value
            End Set
        End Property
#End Region


#Region "INFORM_TARGET 通知對象"
        ''' <summary>
        ''' INFORM_TARGET 通知對象
        ''' </summary>
        Public Property INFORM_TARGET As String
            Get
                Return Me.ColumnyMap("INFORM_TARGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INFORM_TARGET") = value
            End Set
        End Property
#End Region

#Region "OTH_TARGET 其他對象"
        ''' <summary>
        ''' OTH_TARGET 其他對象
        ''' </summary>
        Public Property OTH_TARGET As String
            Get
                Return Me.ColumnyMap("OTH_TARGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTH_TARGET") = value
            End Set
        End Property
#End Region

#Region "PROG_TYPE 程式類別"
        ''' <summary>
        ''' PROG_TYPE 程式類別
        ''' </summary>
        Public Property PROG_TYPE As String
            Get
                Return Me.ColumnyMap("PROG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_TYPE") = value
            End Set
        End Property
#End Region





#Region "UNDERTAKER_ACNT 承辦人"
        ''' <summary>
        ''' UNDERTAKER_ACNT 承辦人
        ''' </summary>
        Public Property UNDERTAKER_ACNT As String
            Get
                Return Me.ColumnyMap("UNDERTAKER_ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNDERTAKER_ACNT") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "AddBatchParam 新增批次參數 "
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
                'EntBatchParam = new EntBatchParam()
                'return EntBatchParam.Insert()

                Dim entBatParam As EntBatchParam = New EntBatchParam(Me.DBManager, Me.LogUtil)

                entBatParam.PARAM_CD = Me.PARAM_CD              '參數代號
                entBatParam.PARAM_CONTENT = Me.PARAM_CONTENT    '參數內容
                entBatParam.PARAM_SEQ = Me.PARAM_SEQ            '參數序號
                entBatParam.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ    '批次工作序號
                entBatParam.PROG_CD = Me.PROG_CD                '程式代號

                entBatParam.Insert()

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddBatchRecord 新增批次記錄 "
        ''' <summary>
        ''' 新增批次記錄 
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
                'EntBatchRecord = new EntBatchRecord()
                'return EntBatchRecord.Insert()

                Dim entBatRecord As EntBatchRecord = New EntBatchRecord(Me.DBManager, Me.LogUtil)

                entBatRecord.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ    '批次工作序號
                entBatRecord.PROG_CD = Me.PROG_CD  '程式代號
                entBatRecord.RECORD_CONTENT = Me.RECORD_CONTENT   '記錄內容
                entBatRecord.RECORD_NAME = Me.RECORD_NAME  '記錄名稱
                entBatRecord.RECORD_SEQ = Me.RECORD_SEQ   '記錄序號

                If Not String.IsNullOrEmpty(Me.IS_BATCH) Then
                    If Me.IS_BATCH = "Y" Then
                        entBatRecord.SetUserId("batch")
                    End If
                End If

                entBatRecord.Insert()

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteBatchParam 刪除批次參數 "
        ''' <summary>
        ''' 刪除批次參數 
        ''' </summary>
        Public Function DeleteBatchParam() As DataTable
            Return Me.DeleteBatchParam(0, 0)
        End Function

        ''' <summary>
        ''' 刪除批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteBatchParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntBatchParam = new EntBatchParam()
                'return EntBatchParam.DeleteByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteBatchRecord 刪除批次記錄 "
        ''' <summary>
        ''' 刪除批次記錄 
        ''' </summary>
        Public Function DeleteBatchRecord() As DataTable
            Return Me.DeleteBatchRecord(0, 0)
        End Function

        ''' <summary>
        ''' 刪除批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteBatchRecord(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntBatchRecord = new EntBatchRecord()
                'return EntBatchRecord.DeleteByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchParam 取得批次參數 "
        ''' <summary>
        ''' 取得批次參數 
        ''' </summary>
        Public Function GetBatchParam() As DataTable
            Return Me.GetBatchParam(0, 0)
        End Function

        ''' <summary>
        ''' 取得批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntBatchParam = new EntBatchParam()
                'return EntBatchParam.GetBatchParam_取得批次參數()

                Dim entBatParam As EntBatchParam = New EntBatchParam(Me.DBManager, Me.LogUtil)

                entBatParam.SqlRetrictions = Me.SqlRetrictions

                Dim dt As DataTable = entBatParam.GetBatchParam(pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchRecord 取得批次記錄 "
        ''' <summary>
        ''' 取得批次記錄 
        ''' </summary>
        Public Function GetBatchRecord() As DataTable
            Return Me.GetBatchRecord(0, 0)
        End Function

        ''' <summary>
        ''' 取得批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchRecord(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                'EntBatchRecord = new EntBatchRecord()
                'return EntBatchRecord.Query()

              
                entBatRecord.SqlRetrictions = Me.SqlRetrictions
                entBatRecord.OrderBys = "PKNO"
                Dim dt As DataTable = entBatRecord.Query(pageNo, pageSize)
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchschedule 取得批次排程 "
        ''' <summary>
        ''' 取得批次排程 
        ''' </summary>
        Public Function GetBatchschedule() As DataTable
            Return Me.GetBatchschedule(0, 0)
        End Function

        ''' <summary>
        ''' 取得批次排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchschedule(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.TableCoumnInfo.Add(New String() {"BATT010", "M", "PKNO", "BATCH_JOB_SEQ", "PROG_CD", "PROG_TYPE", "JOB_EXE_STATUS", "EXE_RES", "PRE_EXE_DATE_TIME"})
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.Pkno,A.BATCH_JOB_SEQ(批次工作序號),B.PROG_NM(程式名稱),A.PROG_CD(程式代號),B.PROG_PATH(程式路徑),B.PROG_EXPL(程式說明),A.PRE_EXE_DATE_TIME(預定執行日期時間),
                'A.START_PROCESS_DATE_TIME(起始處理日期時間),A.END_PROCESS_DATE_TIME(結束處理日期時間),A.JOB_EXE_STATUS(工作執行狀態),A.EXE_RES(執行結果),A.RES_CONTENT(結果內容) 
                'From BATT010 A,AUTC030 B 
                'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and A.Pkno=QUERY_COND(查詢條件) and A.BATCH_JOB_SEQ(批次工作序號)=QUERY_COND(查詢條件) and A.PROG_CD(程式代號)=QUERY_COND(查詢條件) and 
                'A.JOB_EXE_STATUS(工作執行狀態)=QUERY_COND(查詢條件) and A.EXE_RES(執行結果)=QUERY_COND(查詢條件) and A.PRE_EXE_DATE_TIME(預定執行日期時間) between 查詢條件預估執行起日 and 查詢條件預估執行訖日


                Dim sql As StringBuilder = New StringBuilder

                '2016/07/29 Steven : 添加 SYST010的串接取得執行狀態描述
                sql.Append("SELECT M.PKNO,M.BATCH_JOB_SEQ,ISNULL(R1.PROG_NM, R4.PROG_NM) as PROG_NM,M.PROG_CD,R1.PROG_PATH,R1.PROG_EXPL,M.PRE_EXE_DATE_TIME,")
                sql.Append("M.START_PROCESS_DATE_TIME,M.END_PROCESS_DATE_TIME,M.JOB_EXE_STATUS,M.EXE_RES,M.RES_CONTENT,M.BATCH_SEQ,M.BATCH_CYCLE,M.DAYS,M.INFORM_TARGET,M.OTH_TARGET,M.UNDERTAKER_ACNT ")
                sql.Append(" , M.JOB_EXE_SEQ ")
                sql.Append(" , R2.SYS_NAME as JOB_EXE_STATUS_DESC ")
                sql.Append(" , R3.SYS_NAME as PROG_TYPE_DESC ")
                sql.Append(" FROM BATT010 M WITH(NOLOCK) ")
                sql.Append(" LEFT JOIN AUTC030 R1 WITH(NOLOCK) ON M.PROG_CD=R1.PROG_CD ")
                sql.Append(" left join SYST010 R2 on R2.SYS_KEY='JOB_EXE_STATUS' AND cast(R2.SYS_ID as varchar) = M.JOB_EXE_STATUS")
                sql.Append(" left join SYST010 R3 on R3.SYS_KEY='PROG_TYPE' AND cast(R3.SYS_ID as varchar) = M.PROG_TYPE")
                sql.Append(" left join (select prog_cd, prog_nm from batc020) R4 on R4.PROG_CD = M.PROG_CD")
                sql.Append(" WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append("AND ")
                    sql.Append(Me.SqlRetrictions.Replace("$.", ""))
                End If

                '2016/07/29 Steven:為了特殊排序需求，這裡檢查是否有提供額外排序需求
                If String.IsNullOrEmpty(Me.OrderBys) = True Then
                    If pageNo = 0 Then
                        sql.Append(" ORDER BY PRE_EXE_DATE_TIME desc ,BATCH_JOB_SEQ")
                    Else
                        sql.Append(" ORDER BY PRE_EXE_DATE_TIME desc ,BATCH_JOB_SEQ")
                    End If
                Else
                    '自訂排序
                    sql.Append(" order by " + OrderBys)
                End If

                    Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                    Me.ResetColumnProperty()

                    Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetBatchscheduleByWeb 取得批次排程 "
        ''' <summary>
        ''' 取得批次排程 
        ''' </summary>
        Public Function GetBatchscheduleByWeb() As DataTable
            Return Me.GetBatchscheduleByWeb(0, 0)
        End Function

        ''' <summary>
        ''' 取得批次排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchscheduleByWeb(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.TableCoumnInfo.Add(New String() {"BATT010", "M", "PKNO", "BATCH_JOB_SEQ", "PROG_CD", "PROG_TYPE", "JOB_EXE_STATUS", "EXE_RES", "PRE_EXE_DATE_TIME"})
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.Pkno,A.BATCH_JOB_SEQ(批次工作序號),B.PROG_NM(程式名稱),A.PROG_CD(程式代號),B.PROG_PATH(程式路徑),B.PROG_EXPL(程式說明),A.PRE_EXE_DATE_TIME(預定執行日期時間),
                'A.START_PROCESS_DATE_TIME(起始處理日期時間),A.END_PROCESS_DATE_TIME(結束處理日期時間),A.JOB_EXE_STATUS(工作執行狀態),A.EXE_RES(執行結果),A.RES_CONTENT(結果內容) 
                'From BATT010 A,AUTC030 B 
                'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and A.Pkno=QUERY_COND(查詢條件) and A.BATCH_JOB_SEQ(批次工作序號)=QUERY_COND(查詢條件) and A.PROG_CD(程式代號)=QUERY_COND(查詢條件) and 
                'A.JOB_EXE_STATUS(工作執行狀態)=QUERY_COND(查詢條件) and A.EXE_RES(執行結果)=QUERY_COND(查詢條件) and A.PRE_EXE_DATE_TIME(預定執行日期時間) between 查詢條件預估執行起日 and 查詢條件預估執行訖日


                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.PKNO,M.BATCH_JOB_SEQ,R1.PROG_NM,M.PROG_CD,M.PRE_EXE_DATE_TIME,")
                sql.Append("M.START_PROCESS_DATE_TIME,M.END_PROCESS_DATE_TIME,M.JOB_EXE_STATUS,M.EXE_RES,M.RES_CONTENT,M.BATCH_SEQ,M.BATCH_CYCLE,M.DAYS,M.INFORM_TARGET,M.OTH_TARGET ")
                sql.Append("FROM BATT010 M,BATC020 R1 ")
                sql.Append("WHERE M.PROG_CD=R1.PROG_CD ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append("AND ")
                    sql.Append(Me.SqlRetrictions.Replace("$.", ""))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY PRE_EXE_DATE_TIME desc ,BATCH_JOB_SEQ")
                Else
                    sql.Append(" ORDER BY PRE_EXE_DATE_TIME desc ,BATCH_JOB_SEQ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetShExeBatch 取得應執行批次 "
        ''' <summary>
        ''' 取得應執行批次 
        ''' </summary>
        Public Function GetShExeBatch() As DataTable
            Return Me.GetShExeBatch(0, 0)
        End Function

        ''' <summary>
        ''' 取得應執行批次 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetShExeBatch(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.Pkno,A.BATCH_JOB_SEQ(批次工作序號),B.PROG_NM(程式名稱),A.PROG_CD(程式代號),B.PROG_PATH(程式路徑),B.PROG_EXPL(程式說明),A.PRE_EXE_DATE_TIME(預定執行日期時間),
                'A.START_PROCESS_DATE_TIME(起始處理日期時間),A.END_PROCESS_DATE_TIME(結束處理日期時間),A.JOB_EXE_STATUS(工作執行狀態),A.EXE_RES(執行結果),A.RES_CONTENT(結果內容) 
                'From BATT010 A,AUTC030 B 
                'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and PRE_EXE_DATE_TIME(預定執行日期時間)<=SYS_DATE(系統日期) and QUERY_COND(查詢條件)

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateBatchParam 更新批次參數 "
        ''' <summary>
        ''' 更新批次參數 
        ''' </summary>
        Public Function UpdateBatchParam() As DataTable
            Return Me.UpdateBatchParam(0, 0)
        End Function

        ''' <summary>
        ''' 更新批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateBatchParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntBatchParam = new EntBatchParam()
                'return EntBatchParam.UpdateByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateBatchRecord 更新批次記錄 "
        ''' <summary>
        ''' 更新批次記錄 
        ''' </summary>
        Public Function UpdateBatchRecord() As DataTable
            Return Me.UpdateBatchRecord(0, 0)
        End Function

        ''' <summary>
        ''' 更新批次記錄 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateBatchRecord(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntBatchRecord = new EntBatchRecord()
                'return EntBatchRecord.UpdateByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateBatchSchedule 更新批次排程 "
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
				'Update BATT010 Set PRE_EXE_DATE_TIME(預定執行日期時間)=QUERY_COND(查詢條件),START_PROCESS_DATE_TIME(起始處理日期時間)=QUERY_COND(查詢條件),END_PROCESS_DATE_TIME(結束處理日期時間)=QUERY_COND(查詢條件),JOB_EXE_STATUS(工作執行狀態)=QUERY_COND(查詢條件),
				'EXE_RES(執行結果)=QUERY_COND(查詢條件),RES_CONTENT(結果內容)=QUERY_COND(查詢條件) 
				'Where Pkno=QUERY_COND(查詢條件) and BATCH_JOB_SEQ(批次工作序號)=QUERY_COND(查詢條件) and PROG_CD(程式代號)=QUERY_COND(查詢條件)

				Me.SqlRetrictions	=	Me.SqlRetrictions.Replace("$.", "")

				Dim	strK	As	String		=	DateUtil.GetCurrTimeMillis

				Dim	conn	As	DbConnection	=	Me.DBManager.GetIConnection(Me.ConnName,	strK)
				Dim	dba	As	DBAccess	=	Me.DBManager.GetDBAccess(conn)

				'設定被UPDATE的TABLE
				dba.SetTableName(Me.TableName)

				'執行結果
				If Not String.IsNullOrEmpty(Me.EXE_RES) Then
					dba.SetClobColumn("EXE_RES", Me.EXE_RES)
				End If

				'工作執行狀態
				If Not String.IsNullOrEmpty(Me.JOB_EXE_STATUS) Then
					dba.SetClobColumn("JOB_EXE_STATUS", Me.JOB_EXE_STATUS)
                End If

                '2016-08-10 Steven : 新增執行順序欄位的更新 (且要可以清除)
                'If Me.JOB_EXE_SEQ = "" Then
                '    dba.SetClobColumn("JOB_EXE_SEQ", DBNull.Value) '因為是數字類型，不可給空字串
                'Else
                If Not Me.JOB_EXE_SEQ Is Nothing Then
                    dba.SetClobColumn("JOB_EXE_SEQ", Me.JOB_EXE_SEQ)
                End If


                '結束處理日期時間
                If Not String.IsNullOrEmpty(Me.END_PROCESS_DATE_TIME) Then
                    dba.SetClobColumn("END_PROCESS_DATE_TIME", Me.END_PROCESS_DATE_TIME)
                End If

                '結果內容
                If Not String.IsNullOrEmpty(Me.RES_CONTENT) Then
                    If Me.RES_CONTENT.Length > 1800 Then
                        dba.SetClobColumn("RES_CONTENT", Utility.DBStr(Me.RES_CONTENT.Substring(0, 1500)))
                    Else
                        dba.SetClobColumn("RES_CONTENT", Utility.DBStr(Me.RES_CONTENT))
                    End If
                End If

                '起始處理日期時間
                If Not String.IsNullOrEmpty(Me.START_PROCESS_DATE_TIME) Then
                    dba.SetClobColumn("START_PROCESS_DATE_TIME", Me.START_PROCESS_DATE_TIME)
                End If

                '預定執行日期時間
                If Not String.IsNullOrEmpty(Me.PRE_EXE_DATE_TIME) Then
                    dba.SetClobColumn("PRE_EXE_DATE_TIME", Me.PRE_EXE_DATE_TIME)
                End If

                If Not String.IsNullOrEmpty(Me.IS_BATCH) Then

                    If Me.IS_BATCH = "Y" Then
                        dba.SetClobColumn("UPDATE_USER", "batch")
                    Else
                        dba.SetClobColumn("UPDATE_USER", SessionClass.登入帳號)
                    End If

                Else
                    dba.SetClobColumn("UPDATE_USER", SessionClass.登入帳號)
                End If

                dba.SetClobColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                dba.SetClobColumn("ROWSTAMP", DateUtil.GetNowTimeMS)

                Dim updateCount As Integer = dba.Update(" 1=1 " & Me.SqlRetrictions)

                Me.DBManager.Commit(strK)

                Me.ResetColumnProperty()

                Return updateCount
            Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#End Region

    End Class
End Namespace


