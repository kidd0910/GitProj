'----------------------------------------------------------------------------------
'File Name		: SYST040
'Author			: CM Huang
'Description		: SYST040 排程執行錯誤通知
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/10	CM Huang		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Sys.Data
    ' <summary>
    ' SYST040 排程執行錯誤通知
    ' </summary>
    Public Class ENT_SYST040
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        ' <summary>
        ' 建構子/處理屬性對應處理
        ' </summary>
        ' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' 建構子/處理異動處理
        ' </summary>
        ' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "SYST040"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "DL_PKNO"
        '' <summary>
        '' DL_PKNO
        '' </summary>
        Public Property DL_PKNO() As String
            Get
                Return Me.ColumnyMap("DL_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DL_PKNO") = value
            End Set
        End Property
#End Region

#Region "NOTIFY_FLAG"
        '' <summary>
        '' NOTIFY_FLAG
        '' </summary>
        Public Property NOTIFY_FLAG() As String
            Get
                Return Me.ColumnyMap("NOTIFY_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NOTIFY_FLAG") = value
            End Set
        End Property
#End Region

#Region "NOTIFY_TIME"
        '' <summary>
        '' NOTIFY_TIME
        '' </summary>
        Public Property NOTIFY_TIME() As String
            Get
                Return Me.ColumnyMap("NOTIFY_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NOTIFY_TIME") = value
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

#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"SYST040", "M", "DL_PKNO,NOTIFY_FLAG,NOTIFY_TIME"})

                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT TOP 30 M.*, R1.BATCH_JOB_SEQ, R1.PROG_CD, R1.START_PROCESS_DATE_TIME,R1.UNDERTAKER_ACNT, R2.PROG_NM, ")
                sql.AppendLine(" CASE R1.PROG_TYPE   ")
                sql.AppendLine("   WHEN 0 THEN '稽該' ")
                sql.AppendLine("   WHEN 1 THEN '排程' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS PROG_TYPE1  ")
                sql.AppendLine(" FROM SYST040 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN BATT010 R1 WITH(NOLOCK) ON M.DL_PKNO = R1.BATCH_JOB_SEQ ")
                sql.AppendLine(" LEFT JOIN BATC020 R2 WITH(NOLOCK) ON R1.PROG_CD = R2.PROG_CD AND R1.PROG_TYPE = R2.PROG_TYPE ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.DL_PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY M.DL_PKNO ")
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
#End Region


#Region "新增一筆排程錯誤通知 addErrInfo"
        ''' <summary>
        ''' 新增一筆排程錯誤通知
        ''' 設定屬性:ent.DL_PKNO(排程工作序號), ent.IS_BATCH(若排程用必填"Y")
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub addErrInfo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 批次工作序號 ===
                If String.IsNullOrEmpty(Me.DL_PKNO) Then
                    faileArguments.Add("DL_PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                Dim strK As String = DateUtil.GetCurrTimeMillis

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName, strK)
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                '設定被UPDATE的TABLE
                dba.SetTableName(Me.TableName)

                '排程序號
                If Not String.IsNullOrEmpty(Me.DL_PKNO) Then
                    dba.SetClobColumn("DL_PKNO", Me.DL_PKNO)
                End If

                If Not String.IsNullOrEmpty(Me.IS_BATCH) Then

                    If Me.IS_BATCH = "Y" Then
                        dba.SetClobColumn("UPDATE_USER", "batch")
                        dba.SetClobColumn("CREATE_USER", "batch")
                    Else
                        dba.SetClobColumn("UPDATE_USER", SessionClass.登入帳號)
                        dba.SetClobColumn("CREATE_USER", SessionClass.登入帳號)
                    End If

                Else
                    dba.SetClobColumn("UPDATE_USER", SessionClass.登入帳號)
                    dba.SetClobColumn("CREATE_USER", SessionClass.登入帳號)
                End If
                dba.SetClobColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                dba.SetClobColumn("CREATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))

                dba.SetClobColumn("ROWSTAMP", DateUtil.GetNowTimeMS)
                dba.SetClobColumn("PKNO", Me.GetSequence)
                dba.Insert()

                Me.DBManager.Commit(strK)

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

    End Class
End Namespace

