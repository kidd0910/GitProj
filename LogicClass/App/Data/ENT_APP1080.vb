'----------------------------------------------------------------------------------
'File Name		: APP1080
'Author			: TIM
'Description		: APP1080 申設_預估財務狀況表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/20	TIM		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1080 申設_預估財務狀況表
    ' </summary>
    Public Class ENT_APP1080
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
            Me.TableName = "APP1080"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,FUTURE_YEAR,FINANCE_CLASS,FINANCE_TYPE,FINANCE_DETAILS"
            Me.SET_NULL_FIELD = "ESTIMATED_AMOUNT"
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "FUTURE_YEAR 未來第幾年"
        '' <summary>
        '' FUTURE_YEAR 未來第幾年
        '' </summary>
        Public Property FUTURE_YEAR() As String
            Get
                Return Me.ColumnyMap("FUTURE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUTURE_YEAR") = value
            End Set
        End Property
#End Region

#Region "FINANCE_CLASS 財務項目種類"
        '' <summary>
        '' FINANCE_CLASS 財務項目種類
        '' </summary>
        Public Property FINANCE_CLASS() As String
            Get
                Return Me.ColumnyMap("FINANCE_CLASS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FINANCE_CLASS") = value
            End Set
        End Property
#End Region

#Region "FINANCE_TYPE 財務項目類別"
        '' <summary>
        '' FINANCE_TYPE 財務項目類別
        '' </summary>
        Public Property FINANCE_TYPE() As String
            Get
                Return Me.ColumnyMap("FINANCE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FINANCE_TYPE") = value
            End Set
        End Property
#End Region

#Region "FINANCE_DETAILS 財務項目細項"
        '' <summary>
        '' FINANCE_DETAILS 財務項目細項
        '' </summary>
        Public Property FINANCE_DETAILS() As String
            Get
                Return Me.ColumnyMap("FINANCE_DETAILS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FINANCE_DETAILS") = value
            End Set
        End Property
#End Region

#Region "ESTIMATED_AMOUNT 預估金額"
        '' <summary>
        '' ESTIMATED_AMOUNT 預估金額
        '' </summary>
        Public Property ESTIMATED_AMOUNT() As String
            Get
                Return Me.ColumnyMap("ESTIMATED_AMOUNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ESTIMATED_AMOUNT") = value
            End Set
        End Property
#End Region


#End Region

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
        ''' 0.0.1 CMHuang 新增方法
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
                Me.TableCoumnInfo.Add(New String() {"APP1080", "M", "CASE_NO", "FUTURE_YEAR", "FINANCE_CLASS", "FINANCE_TYPE", "FINANCE_DETAILS", "ESTIMATED_AMOUNT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*,R1.SYS_NAME ")
                sql.AppendLine(" FROM APP1080 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R1 ON M.FINANCE_DETAILS=R1.SYS_ID AND R1.SYS_KEY='FINANCE_CODE1' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY M.PKNO ")
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

#Region "查詢group by"
        Public Function QueryGroupBy() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1080", "M", "CASE_NO", "FUTURE_YEAR", "FINANCE_CLASS", "FINANCE_TYPE", "FINANCE_DETAILS", "ESTIMATED_AMOUNT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT FUTURE_YEAR ")
                sql.AppendLine(" FROM APP1080 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R1 ON M.FINANCE_DETAILS=R1.SYS_ID AND R1.SYS_KEY='FINANCE_CODE1' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                sql.AppendLine(" GROUP BY FUTURE_YEAR ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryStatic 預估財務統計查詢 "
        ''' <summary>
        ''' 預估財務統計查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   新增方法
        ''' </remarks>
        Public Function DoQueryStatic() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1080", "M", "CASE_NO", "FUTURE_YEAR", "FINANCE_CLASS", "FINANCE_TYPE", "FINANCE_DETAILS", "ESTIMATED_AMOUNT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT CASE_NO,FUTURE_YEAR  , SUM(CASE WHEN FINANCE_TYPE='11' THEN ESTIMATED_AMOUNT ELSE 0 END  ) AS 流動資產總計 ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_TYPE='12' THEN ESTIMATED_AMOUNT ELSE 0 END ) AS 非流動資產總計  ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_CLASS='1' THEN ESTIMATED_AMOUNT ELSE 0 END ) AS 資產總計  ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_TYPE='21' THEN ESTIMATED_AMOUNT ELSE 0 END  ) AS 流動負債總計  ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_TYPE='22' THEN ESTIMATED_AMOUNT ELSE 0 END ) AS 非流動負債總計  ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_TYPE='23' THEN ESTIMATED_AMOUNT ELSE 0 END ) AS 業主權益總計 ")
                sql.AppendLine("    , SUM(CASE WHEN FINANCE_CLASS='2' THEN ESTIMATED_AMOUNT ELSE 0 END ) AS 負債與權益總計 ")
                sql.AppendLine("        FROM APP1080 M  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                sql.AppendLine("    GROUP  BY  CASE_NO , FUTURE_YEAR    ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
    End Class
End Namespace

