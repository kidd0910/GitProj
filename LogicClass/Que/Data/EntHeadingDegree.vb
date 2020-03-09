'----------------------------------------------------------------------------------
'File Name		: EntHeadingDegree
'Author			:  
'Description		: EntHeadingDegree 題目向度ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1     2016/11/11       Source Create COPY FROM
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Que.Data
    '' <summary>
    '' EntHeadingDegree 題目向度ENT
    '' </summary>
    Public Class EntHeadingDegree
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
            Me.TableName = "QUET030"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            MyBase.SET_NULL_FIELD = "VECTOR_TYPE,VECTOR_BS,VECTOR_SEQ,VECTOR_TROVMGP"
            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "QSTNNR_NO 問卷號碼"
        ''' <summary>
        ''' QSTNNR_NO 問卷號碼
        ''' </summary>
        Public Property QSTNNR_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_NO") = value
            End Set
        End Property
#End Region

#Region "VECTOR_BS 向度大小"
        ''' <summary>
        ''' VECTOR_BS 向度大小
        ''' </summary>
        Public Property VECTOR_BS() As String
            Get
                Return Me.ColumnyMap("VECTOR_BS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_BS") = value
            End Set
        End Property
#End Region

#Region "VECTOR_NAME 向度名稱"
        ''' <summary>
        ''' VECTOR_NAME 向度名稱
        ''' </summary>
        Public Property VECTOR_NAME() As String
            Get
                Return Me.ColumnyMap("VECTOR_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_NAME") = value
            End Set
        End Property
#End Region

#Region "VECTOR_NO 向度號碼"
        ''' <summary>
        ''' VECTOR_NO 向度號碼
        ''' </summary>
        Public Property VECTOR_NO() As String
            Get
                Return Me.ColumnyMap("VECTOR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_NO") = value
            End Set
        End Property
#End Region

#Region "VECTOR_SEQ 向度排序"
        ''' <summary>
        ''' VECTOR_SEQ 向度排序
        ''' </summary>
        Public Property VECTOR_SEQ() As String
            Get
                Return Me.ColumnyMap("VECTOR_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_SEQ") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TITLE 向度標號"
        ''' <summary>
        ''' VECTOR_TITLE 向度標號
        ''' </summary>
        Public Property VECTOR_TITLE() As String
            Get
                Return Me.ColumnyMap("VECTOR_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_TITLE") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TROVMGP 向度權數"
        ''' <summary>
        ''' VECTOR_TROVMGP 向度權數
        ''' </summary>
        Public Property VECTOR_TROVMGP() As String
            Get
                Return Me.ColumnyMap("VECTOR_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_TROVMGP") = value
            End Set
        End Property
#End Region

#Region "VECTOR_TYPE 向度類型"
        ''' <summary>
        ''' VECTOR_TROVMGP 向度類型
        ''' </summary>
        Public Property VECTOR_TYPE() As String
            Get
                Return Me.ColumnyMap("VECTOR_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_TYPE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "QueryDegreeDDL 查詢向度下拉 "
        ''' <summary>
        ''' 查詢向度下拉 
        ''' </summary>
        Public Function QueryDegreeDDL() As DataTable
            Return Me.QueryDegreeDDL(0, 0)
        End Function

        ''' <summary>
        ''' 查詢向度下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryDegreeDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    faileArguments.Add("SqlRetrictions")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                ' Me.ParserAlias()

                '=== 處理說明 ===
                '這是下拉選單

                Dim sql As String = "SELECT VECTOR_NO AS SELECT_VALUE ,VECTOR_NAME  AS SELECT_TEXT FROM QUET030 WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "")

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryDegreeMaxNo 查詢向度最大號碼 "
        ''' <summary>
        ''' 查詢向度最大號碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryDegreeMaxNo() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    faileArguments.Add("SqlRetrictions")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                '    Me.ParserAlias()

                '=== 處理說明 ===
                '抓取向度最大號碼+1

                Dim sql As String = "SELECT ISNULL(MAX(CONVERT(INT,VECTOR_NO))+1,1) AS MAXNO FROM QUET030 "

                Dim dt As DataTable = Me.QueryBySql(sql)
                Dim ruslt As String = String.Empty
                If dt.Rows.Count > 0 Then
                    ruslt = dt.Rows(0)("maxno").ToString
                Else
                    ruslt = "1"
                End If
                Return ruslt
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace

