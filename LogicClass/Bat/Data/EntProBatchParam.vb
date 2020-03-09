'----------------------------------------------------------------------------------
'File Name		: EntProBatchParam
'Author			: 
'Description		: EntProBatchParam 程式批次參數ENT
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
    '' EntProBatchParam 程式批次參數ENT
    '' </summary>
    Public Class EntProBatchParam
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
            Me.TableName = "BATC010"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
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

#Region "PARAM_NM 參數名稱"
        ''' <summary>
        ''' PARAM_NM 參數名稱
        ''' </summary>
        Public Property PARAM_NM() As String
            Get
                Return Me.ColumnyMap("PARAM_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_NM") = value
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
#Region "GetMaxProPrarmNum 取得程式參數最大流水號 "
        ''' <summary>
        ''' 取得程式參數最大流水號 
        ''' </summary>
        Public Function GetMaxProPrarmNum() As DataTable
            Return Me.GetMaxProPrarmNum(0, 0)
        End Function

        ''' <summary>
        ''' 取得程式參數最大流水號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetMaxProPrarmNum(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()



                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select NVL(Max(PARAM_SEQ(參數序號)),'00') from  BATC010
                'Where PROG_CD(程式代號)=QUERY_COND(查詢條件)

                Dim sql As String = ""

                sql = " SELECT NVL(MAX(PARAM_SEQ ),'00') FROM  BATC010 WHERE 1=1 "

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("$.", " ")
                    sql = sql & " AND " & Me.SqlRetrictions
                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetProBatchParam 取得程式批次參數 "
        ''' <summary>
        ''' 取得程式批次參數 
        ''' </summary>
        Public Function GetProBatchParam() As DataTable
            Return Me.GetProBatchParam(0, 0)
        End Function

        ''' <summary>
        ''' 取得程式批次參數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetProBatchParam(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Select A.Pkno,A.PROG_CD(程式代號),B.PROG_NM(程式名稱),A.PARAM_SEQ(參數序號),A.PARAM_CD(參數代號),A.PARAM_NM(參數名稱) from  BATC010 A, AUTC030 B
                'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and A.Pkno查詢條件=and A.PROG_CD(程式代號)=QUERY_COND(查詢條件)

                Dim sql As String = ""
                sql = " SELECT M.*, R.PROG_NM"
                sql = sql & "   FROM BATC010 M LEFT JOIN AUTC030 R ON M.PROG_CD = R.PROG_CD"

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("$.", " ")
                    sql = sql & " where " & Me.SqlRetrictions
                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

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

