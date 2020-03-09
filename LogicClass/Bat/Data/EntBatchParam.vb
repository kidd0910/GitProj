'----------------------------------------------------------------------------------
'File Name		: EntBatchParam
'Author			: Ethan
'Description		: EntBatchParam 批次參數ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/25	Ethan		Source Create
'0.0.2      2016/07/19  Steven     GetBatchParam  增加 UPDATE_USER的取得，沒有取得此欄位的話會導致 BAT1100寄信沒有對象而沒寄發
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
    '' EntBatchParam 批次參數ENT
    '' </summary>
    Public Class EntBatchParam
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
            Me.TableName = "BATT020"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
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


#End Region

#Region "自訂方法"
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


                '=== 處理別名轉換 ===
                Me.TableCoumnInfo.Add(New String() {"BATT020", "M", "PKNO", "BATCH_JOB_SEQ", "PROG_CD", "PARAM_SEQ", "PARAM_CONTENT", "PARAM_CD", "UPDATE_USER"})
                Me.TableCoumnInfo.Add(New String() {"BATT010", "R2", "JOB_EXE_STATUS"})
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.Pkno,A.BATCH_JOB_SEQ(批次工作序號),A.PROG_CD(程式代號),A.PARAM_SEQ(參數序號),A.PARAM_CD(參數代號),A.PARAM_CONTENT(參數內容),B.PARAM_NM(參數名稱)
                'From BATT020 A,BATC010 B 
                'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and A.Pkno=QUERY_COND(查詢條件) and A.BATCH_JOB_SEQ(批次工作序號)=QUERY_COND(查詢條件) and A.PROG_CD(程式代號)=QUERY_COND(查詢條件)

                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.PKNO,M.BATCH_JOB_SEQ,M.PROG_CD,M.PARAM_SEQ,M.PARAM_CD,M.PARAM_CONTENT,R1.PARAM_NM,R2.JOB_EXE_STATUS ")
                sql.Append(", M.UPDATE_USER") '2016/7/19 Steven:沒有取得此欄位的話會導致 BAT1100寄信沒有對象而沒寄發
                sql.Append(" FROM BATT020 M WITH(NOLOCK) ")
                sql.Append(" LEFT JOIN BATC010 R1 WITH(NOLOCK) ON M.PROG_CD=R1.PROG_CD AND M.PARAM_SEQ=R1.PARAM_SEQ ")
                sql.Append(" LEFT JOIN BATT010 R2 WITH(NOLOCK) ON M.BATCH_JOB_SEQ=R2.BATCH_JOB_SEQ ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append("WHERE ")
                    sql.Append(Me.SqlRetrictions)
                End If

                sql.Append(" ORDER BY BATCH_JOB_SEQ,PROG_CD,PARAM_SEQ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace
