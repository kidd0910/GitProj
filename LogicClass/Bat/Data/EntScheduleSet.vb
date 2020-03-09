'----------------------------------------------------------------------------------
'File Name		: EntScheduleSet
'Author			: 
'Description		: EntScheduleSet 排程設定ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/19			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Bat.Data
    '' <summary>
    '' EntScheduleSet 排程設定ENT
    '' </summary>
    Public Class EntScheduleSet
        Inherits Acer.Base.EntityBase
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
            Me.TableName = "BATT040"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntScheduleParam = New EntScheduleParam(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "BATCH_SEQ 排程序號"
        ''' <summary>
        ''' BATCH_SEQ 排程序號
        ''' </summary>
        Public Property BATCH_SEQ() As String
            Get
                Return Me.ColumnyMap("BATCH_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_SEQ") = value
            End Set
        End Property
#End Region

#Region "DAY_EXE 每日執行"
        ''' <summary>
        ''' DAY_EXE 每日執行
        ''' </summary>
        Public Property DAY_EXE() As String
            Get
                Return Me.ColumnyMap("DAY_EXE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DAY_EXE") = value
            End Set
        End Property
#End Region

#Region "MONTHLY_EXE 每月執行"
        ''' <summary>
        ''' MONTHLY_EXE 每月執行
        ''' </summary>
        Public Property MONTHLY_EXE() As String
            Get
                Return Me.ColumnyMap("MONTHLY_EXE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MONTHLY_EXE") = value
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

#Region "PRE_EXE_DATE 預定執行日期"
        ''' <summary>
        ''' PRE_EXE_DATE 預定執行日期
        ''' </summary>
        Public Property PRE_EXE_DATE() As String
            Get
                Return Me.ColumnyMap("PRE_EXE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRE_EXE_DATE") = value
            End Set
        End Property
#End Region

#Region "PRE_EXE_TIME 預定執行時間"
        ''' <summary>
        ''' PRE_EXE_TIME 預定執行時間
        ''' </summary>
        Public Property PRE_EXE_TIME() As String
            Get
                Return Me.ColumnyMap("PRE_EXE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRE_EXE_TIME") = value
            End Set
        End Property
#End Region

#Region "PROCESS_DATE_TIME 處理日期時間"
        ''' <summary>
        ''' PROCESS_DATE_TIME 處理日期時間
        ''' </summary>
        Public Property PROCESS_DATE_TIME() As String
            Get
                Return Me.ColumnyMap("PROCESS_DATE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROCESS_DATE_TIME") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "WEEKLY_EXE 每週執行"
        ''' <summary>
        ''' WEEKLY_EXE 每週執行
        ''' </summary>
        Public Property WEEKLY_EXE() As String
            Get
                Return Me.ColumnyMap("WEEKLY_EXE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("WEEKLY_EXE") = value
            End Set
        End Property
#End Region

#Region "EntScheduleParam 排程參數ENT"
        ''' <summary>
        ''' EntScheduleParam  排程參數ENT 
        ''' </summary>
        Public Property EntScheduleParam() As EntScheduleParam
            Get
                Return Me.PropertyMap("EntScheduleParam")
            End Get
            Set(ByVal value As EntScheduleParam)
                Me.PropertyMap("EntScheduleParam") = value
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

#Region "BATCH_CYCLE 批次週期"
        ''' <summary>
        ''' BATCH_CYCLE 批次週期
        ''' </summary>
        Public Property BATCH_CYCLE As String
            Get
                Return Me.ColumnyMap("BATCH_CYCLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_CYCLE") = value
            End Set
        End Property
#End Region

#Region "DAYS 天數"
        ''' <summary>
        ''' DAYS 天數
        ''' </summary>
        Public Property DAYS As String
            Get
                Return Me.ColumnyMap("DAYS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DAYS") = value
            End Set
        End Property
#End Region

#Region "EXE_PERIOD_SDATE 執行期間起日"
        ''' <summary>
        ''' EXE_PERIOD_SDATE 執行期間起日
        ''' </summary>
        Public Property EXE_PERIOD_SDATE As String
            Get
                Return Me.ColumnyMap("EXE_PERIOD_SDATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_PERIOD_SDATE") = value
            End Set
        End Property
#End Region

#Region "EXE_PERIOD_EDATE 執行期間訖日"
        ''' <summary>
        ''' EXE_PERIOD_EDATE 執行期間訖日
        ''' </summary>
        Public Property EXE_PERIOD_EDATE As String
            Get
                Return Me.ColumnyMap("EXE_PERIOD_EDATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_PERIOD_EDATE") = value
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
#Region "AddScheduleParam 新增排程參數 "
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


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.Insert()

                EntScheduleParam.PARAM_CD = Me.PARAM_CD
                EntScheduleParam.PARAM_CONTENT = Me.PARAM_CONTENT
                EntScheduleParam.PARAM_SEQ = Me.PARAM_SEQ
                EntScheduleParam.BATCH_SEQ = Me.BATCH_SEQ
                EntScheduleParam.PROG_CD = Me.PROG_CD
                EntScheduleParam.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteScheduleParam 刪除排程參數 "
        ''' <summary>
        ''' 刪除排程參數 
        ''' </summary>
        Public Function DeleteScheduleParam() As DataTable
            Return Me.DeleteScheduleParam(0, 0)
        End Function

        ''' <summary>
        ''' 刪除排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteScheduleParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.DeleteByPkno()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetScheduleParam 取得排程參數 "
        ''' <summary>
        ''' 取得排程參數 
        ''' </summary>
        Public Function GetScheduleParam() As DataTable
            Return Me.GetScheduleParam(0, 0)
        End Function

        ''' <summary>
        ''' 取得排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetScheduleParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                ' Me.ParserAlias()

                '=== 處理說明 ===
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.Query()

                ' Dim sql As String = ""
                EntScheduleParam.SqlRetrictions = Me.SqlRetrictions
                Dim dt As DataTable = EntScheduleParam.Query(pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetScheduleSet 取得排程設定 "
        ''' <summary>
        ''' 取得排程設定 
        ''' </summary>
        Public Function GetScheduleSet() As DataTable
            Return Me.GetScheduleSet(0, 0)
        End Function

        ''' <summary>
        ''' 取得排程設定 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetScheduleSet(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Select A.PKNO(Pkno),A.BATCH_SEQ(排程序號),A.PROG_CD(程式代號),A.PROG_TYPE(程式類別),B.PROG_NM(程式名稱),A.MONTHLY_EXE(每月執行),A.WEEKLY_EXE(每週執行),A.DAY_EXE(每日執行),A.PRE_EXE_DATE(預定執行日期),A.PRE_EXE_TIME(預定執行時間),A.PROCESS_DATE_TIME(處理日期時間),
                'A.BATCH_CYCLE(批次週期),A.DAYS(天數),A.EXE_PERIOD_SDATE(執行期間起日),A.EXE_PERIOD_EDATE(執行期間訖日),A.INFORM_TARGET(通知對象),A.OTH_TARGET(其他對象)  
                'From BATT040 A,AUTC030 B Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號)
                'and PKNO(Pkno)=QUERY_COND(查詢條件) and BATCH_SEQ(排程序號)=QUERY_COND(查詢條件) and PROG_CD(程式代號)=QUERY_COND(查詢條件) and A.PROG_TYPE(程式類別)=QUERY_COND(查詢條件) and BATCH_CYCLE(批次週期)=QUERY_COND(查詢條件) and DAYS(天數)=QUERY_COND(查詢條件) and 
                'EXE_PERIOD_SDATE(執行期間起日) >= '執行年度'+'0101' AND EXE_PERIOD_EDATE(執行期間訖日) <='執行年度'+'1231'

                '=== 處理別名轉換 ===
                Me.TableCoumnInfo.Add(New String() {"BATT040", "M", "PKNO", "BATCH_SEQ", "PROG_CD", "PROG_TYPE", "BATCH_CYCLE", "DAYS", "PRE_EXE_DATE_TIME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.AppendLine(" SELECT M.*, R1.PROG_NM, R3.CH_NAME AS UPDATE_NAME ")
                sql.AppendLine(" FROM BATT040 M LEFT JOIN AUTC030 R1 ON M.PROG_CD = R1.PROG_CD ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020) R3 ON M.UPDATE_USER = R3.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("$.", " ")
                    sql.AppendLine(" WHERE " & Me.SqlRetrictions)
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PROG_CD ")
                    Else
                        sql.AppendLine(" ORDER BY PROG_CD ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetShExeSchedule 取得應執行排程 "
        ''' <summary>
        ''' 取得應執行排程 
        ''' </summary>
        Public Function GetShExeSchedule() As DataTable
            Return Me.GetShExeSchedule(0, 0)
        End Function

        ''' <summary>
        ''' 取得應執行排程 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetShExeSchedule(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select Pkno,BATCH_SEQ(排程序號),PROG_CD(程式代號),MONTHLY_EXE(每月執行),WEEKLY_EXE(每週執行),DAY_EXE(每日執行),PRE_EXE_DATE(預定執行日期),PRE_EXE_TIME(預定執行時間),PROCESS_DATE_TIME(處理日期時間) 
                'From BATT040 Where (NVL(MONTHLY_EXE(每月執行),'')=系統日期的day or NVL(WEEKLY_EXE(每週執行),'')=系統日期的Week or 
                'NVL(DAY_EXE(每日執行),'9999')<=系統日期的時間 or (PRE_EXE_DATE(預定執行日期)=SYS_DATE(系統日期) and NVL(PRE_EXE_TIME(預定執行時間),'9999')<=系統日期的時間)) 
                'and NVL(PROCESS_DATE_TIME(處理日期時間)'') <> SYS_DATE(系統日期)

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateScheduleParam 更新排程參數 "
        ''' <summary>
        ''' 更新排程參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateScheduleParam() As Integer
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
                'EntScheduleParam = new EntScheduleParam()
                'return EntScheduleParam.UpdateByPkno()
                Dim returnValue As Integer = 0
              
                EntScheduleParam.PARAM_CD = Me.PARAM_CD
                EntScheduleParam.PARAM_CONTENT = Me.PARAM_CONTENT
                EntScheduleParam.PARAM_SEQ = Me.PARAM_SEQ
                EntScheduleParam.BATCH_SEQ = Me.BATCH_SEQ
                EntScheduleParam.PROG_CD = Me.PROG_CD
                EntScheduleParam.PKNO = Me.PKNO
                returnValue = EntScheduleParam.UpdateByPkNo
                Me.ResetColumnProperty()

                Return returnValue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region

    End Class
End Namespace


