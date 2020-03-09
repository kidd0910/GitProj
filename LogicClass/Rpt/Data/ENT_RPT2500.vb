'----------------------------------------------------------------------------------
'File Name		: RPT2500
'Author			: KuChihWei 
'Description		: RPT2500 線上提報數統計
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/08	KuChihWei	     Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports System.Data.SqlClient

Namespace App.Data
    ' <summary>
    ' RPT2500 線上提報數統計
    ' </summary>
    Public Class ENT_RPT2500
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
            Me.TableName = "APPL130"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "APP_PERSON"
        '' <summary>
        '' APP_PERSON
        '' </summary>
        Public Property APP_PERSON() As String
            Get
                Return Me.ColumnyMap("APP_PERSON")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_PERSON") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO"
        '' <summary>
        '' LICENSE_NO
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.ColumnyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "OPERATION_CODE"
        '' <summary>
        '' OPERATION_CODE
        '' </summary>
        Public Property OPERATION_CODE() As String
            Get
                Return Me.ColumnyMap("OPERATION_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_CODE") = value
            End Set
        End Property
#End Region

#Region "STF"
        '' <summary>
        '' STF
        '' </summary>
        Public Property STF() As String
            Get
                Return Me.ColumnyMap("STF")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STF") = value
            End Set
        End Property
#End Region

#Region "COM_OTEL"
        '' <summary>
        '' COM_OTEL
        '' </summary>
        Public Property COM_OTEL() As String
            Get
                Return Me.ColumnyMap("COM_OTEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_OTEL") = value
            End Set
        End Property
#End Region

#Region "COM_OEMAIL"
        '' <summary>
        '' COM_OEMAIL
        '' </summary>
        Public Property COM_OEMAIL() As String
            Get
                Return Me.ColumnyMap("COM_OEMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_OEMAIL") = value
            End Set
        End Property
#End Region

#Region "NUM_CATEGORY1"
        '' <summary>
        '' NUM_CATEGORY1
        '' </summary>
        Public Property NUM_CATEGORY1() As String
            Get
                Return Me.ColumnyMap("NUM_CATEGORY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NUM_CATEGORY1") = value
            End Set
        End Property
#End Region

#Region "APP_YEAR"
        '' <summary>
        '' APP_YEAR
        '' </summary>
        Public Property APP_YEAR() As String
            Get
                Return Me.ColumnyMap("APP_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_YEAR") = value
            End Set
        End Property
#End Region

#Region "APP_SYEAR"
        '' <summary>
        '' APP_SYEAR
        '' </summary>
        Public Property APP_SYEAR() As String
            Get
                Return Me.ColumnyMap("APP_SYEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_SYEAR") = value
            End Set
        End Property
#End Region

#Region "APP_EYEAR"
        '' <summary>
        '' APP_EYEAR
        '' </summary>
        Public Property APP_EYEAR() As String
            Get
                Return Me.ColumnyMap("APP_EYEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_EYEAR") = value
            End Set
        End Property
#End Region

#Region "APP_MONTH"
        '' <summary>
        '' APP_MONTH
        '' </summary>
        Public Property APP_MONTH() As String
            Get
                Return Me.ColumnyMap("APP_MONTH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_MONTH") = value
            End Set
        End Property
#End Region

#Region "APP_SMONTH"
        '' <summary>
        '' APP_SMONTH
        '' </summary>
        Public Property APP_SMONTH() As String
            Get
                Return Me.ColumnyMap("APP_SMONTH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_SMONTH") = value
            End Set
        End Property
#End Region

#Region "APP_EMONTH"
        '' <summary>
        '' APP_EMONTH
        '' </summary>
        Public Property APP_EMONTH() As String
            Get
                Return Me.ColumnyMap("APP_EMONTH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_EMONTH") = value
            End Set
        End Property
#End Region

#Region "APP_DATE"
        '' <summary>
        '' APP_DATE
        '' </summary>
        Public Property APP_DATE() As String
            Get
                Return Me.ColumnyMap("APP_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_DATE") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "RECORRECT_NUM"
        '' <summary>
        '' RECORRECT_NUM
        '' </summary>
        Public Property RECORRECT_NUM() As String
            Get
                Return Me.ColumnyMap("RECORRECT_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORRECT_NUM") = value
            End Set
        End Property
#End Region

#Region "IS_FORMAL"
        '' <summary>
        '' IS_FORMAL
        '' </summary>
        Public Property IS_FORMAL() As String
            Get
                Return Me.ColumnyMap("IS_FORMAL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_FORMAL") = value
            End Set
        End Property
#End Region

#Region "AUDIT_OPINION"
        '' <summary>
        '' AUDIT_OPINION
        '' </summary>
        Public Property AUDIT_OPINION() As String
            Get
                Return Me.ColumnyMap("AUDIT_OPINION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("AUDIT_OPINION") = value
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
        ''' 0.0.1 Mark Huang 新增方法
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
                Me.TableCoumnInfo.Add(New String() {"APPL130", "M", "PKNO", "APP_PERSON", "LICENSE_NO", "OPERATION_CODE", "STF", "COM_OTEL", "COM_OEMAIL", "NUM_CATEGORY1", "APP_YEAR", "APP_MONTH", "APP_DATE", "USE_STATE", "RECORRECT_NUM", "IS_FORMAL", "AUDIT_OPINION"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON", Me.APP_PERSON)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CODE", Me.OPERATION_CODE)
                Me.ProcessQueryCondition(condition, "=", "STF", Me.STF)
                Me.ProcessQueryCondition(condition, "=", "COM_OTEL", Me.COM_OTEL)
                Me.ProcessQueryCondition(condition, "=", "COM_OEMAIL", Me.COM_OEMAIL)
                Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY1", Me.NUM_CATEGORY1)
                Me.ProcessQueryCondition(condition, "=", "APP_YEAR", Me.APP_YEAR)
                Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                Me.ProcessQueryCondition(condition, "=", "APP_DATE", Me.APP_DATE)
                'Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "RECORRECT_NUM", Me.RECORRECT_NUM)
                Me.ProcessQueryCondition(condition, "=", "IS_FORMAL", Me.IS_FORMAL)
                'Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)

                'Unicode欄位查詢
                If Me.AUDIT_OPINION <> "" Then
                    condition.Append(" AND $.AUDIT_OPINION LIKE N'%" & Me.AUDIT_OPINION & "%' ")
                End If

                If Me.USE_STATE <> "" Then
                    condition.Append(" AND $.USE_STATE IN (" & Me.USE_STATE & ")")
                End If

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.Append(" SELECT M.PKNO, M.APP_PERSON, M.LICENSE_NO, M.OPERATION_CODE ,R2.SYS_NAME AS NUM_CATEGORY1_NAME, ")
                sql.Append(" M.APP_YEAR, M.APP_MONTH, M.APP_DATE, M.STF, M.COM_OTEL, M.COM_OEMAIL, M.NUM_CATEGORY1, M.USE_STATE, ")
                sql.Append(" M.RECORRECT_NUM, M.IS_FORMAL, M.AUDIT_OPINION, ")
                sql.Append(" M.UPDATE_TIME, REPLACE(CONVERT(VARCHAR, M.UPDATE_TIME, 120),'-','/')  AS UPDATE_TIME1, ")
                sql.Append(" M.UPDATE_USER, isNull(R3.CH_NAME, '') AS UPDATE_USER1 ")
                sql.Append(" FROM APPL130 M ")
                'sql.Append(" LEFT JOIN APPL131 R1 ON R1.MA_PKNO = M.PKNO ")
                sql.Append(" LEFT JOIN SYST010 R2 ON M.NUM_CATEGORY1 = R2.SYS_ID AND R2.SYS_KEY='號碼種類' ")
                sql.Append(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020) R3 ON M.UPDATE_USER = R3.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'sql.Append(" GROUP BY M.PKNO, M.APP_PERSON, M.LICENSE_NO, M.OPERATION_CODE, M.APP_YEAR, M.APP_MONTH, ")
                'sql.Append(" M.STF, M.COM_OTEL, M.COM_OEMAIL, M.NUM_CATEGORY1, M.USE_STATE, M.RECORRECT_NUM, M.IS_FORMAL, M.AUDIT_OPINION, ")
                'sql.Append(" M.UPDATE_TIME, M.UPDATE_USER, R3.CH_NAME, R2.SYS_NAME ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.NUM_CATEGORY1, M.APP_YEAR, M.APP_MONTH ASC")
                    Else
                        sql.AppendLine(" ORDER BY NUM_CATEGORY1, APP_YEAR, APP_MONTH ASC")
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

#Region "GetSummary 取得明細資料 "
        ''' <summary>
        ''' 取得總結資料 
        ''' </summary>
        Public Function GetSummary() As DataTable
            Return Me.GetSummary(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function GetSummary(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL130", "M", "PKNO", "APP_PERSON", "LICENSE_NO", "OPERATION_CODE", "STF", "COM_OTEL", "COM_OEMAIL", "NUM_CATEGORY1", "APP_YEAR", "APP_MONTH", "APP_DATE", "USE_STATE", "RECORRECT_NUM", "IS_FORMAL", "AUDIT_OPINION"})
                Me.TableCoumnInfo.Add(New String() {"APPL131", "R1", "PKNO", "MA_PKNO", "COM_CNAM", "REASS_QUANTITY", "VAR_QUANTITY"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})


                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON", Me.APP_PERSON)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CODE", Me.OPERATION_CODE)
                Me.ProcessQueryCondition(condition, "=", "STF", Me.STF)
                Me.ProcessQueryCondition(condition, "=", "COM_OTEL", Me.COM_OTEL)
                Me.ProcessQueryCondition(condition, "=", "COM_OEMAIL", Me.COM_OEMAIL)
                Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY1", Me.NUM_CATEGORY1)
                Me.ProcessQueryCondition(condition, "=", "APP_YEAR", Me.APP_YEAR)
                Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                Me.ProcessQueryCondition(condition, "=", "APP_DATE", Me.APP_DATE)
                'Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "RECORRECT_NUM", Me.RECORRECT_NUM)
                Me.ProcessQueryCondition(condition, "=", "IS_FORMAL", Me.IS_FORMAL)
                'Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)

                'Unicode欄位查詢
                If Me.AUDIT_OPINION <> "" Then
                    condition.Append(" AND $.AUDIT_OPINION LIKE N'%" & Me.AUDIT_OPINION & "%' ")
                End If

                If Me.USE_STATE <> "" Then
                    condition.Append(" AND $.USE_STATE IN (" & Me.USE_STATE & ")")
                End If

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.Append(" SELECT R1.PKNO, R1.MA_PKNO, R1.ITEM, R1.QUANTITY , ")
                sql.Append(" R1.UPDATE_TIME, REPLACE(CONVERT(VARCHAR, R1.UPDATE_TIME, 120),'-','/')  AS UPDATE_TIME1, ")
                sql.Append(" R1.UPDATE_USER, isNull(R3.CH_NAME, '') AS UPDATE_USER1 ")
                sql.Append(" FROM APPL130 M ")
                sql.Append(" LEFT JOIN APPL131 R1 ON R1.MA_PKNO = M.PKNO ")
                sql.Append(" LEFT JOIN SYST010 R2 ON M.NUM_CATEGORY1 = R2.SYS_ID AND R2.SYS_KEY='號碼種類' ")
                sql.Append(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020) R3 ON M.UPDATE_USER = R3.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY R1.UPDATE_TIME")
                    Else
                        sql.AppendLine(" ORDER BY UPDATE_TIME")
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

#Region "QueryYear 查詢年報表 "
        ''' <summary>
        ''' 查詢年報表
        ''' </summary>
        Public Function QueryYear() As DataTable
            Return Me.QueryYear(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function QueryYear(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL130", "M", "PKNO", "APP_PERSON", "LICENSE_NO", "OPERATION_CODE", "STF", "COM_OTEL", "COM_OEMAIL", "NUM_CATEGORY1", "APP_YEAR", "APP_MONTH", "APP_DATE", "USE_STATE", "RECORRECT_NUM", "IS_FORMAL", "AUDIT_OPINION"})
                Me.TableCoumnInfo.Add(New String() {"APPL131", "R1", "PKNO", "MA_PKNO", "NUM_CATEGORY1", "ITEM", "QUANTITY", "DATA_CHK_FLAG"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON", Me.APP_PERSON)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CODE", Me.OPERATION_CODE)
                Me.ProcessQueryCondition(condition, "=", "STF", Me.STF)
                Me.ProcessQueryCondition(condition, "=", "COM_OTEL", Me.COM_OTEL)
                Me.ProcessQueryCondition(condition, "=", "COM_OEMAIL", Me.COM_OEMAIL)
                Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY1", Me.NUM_CATEGORY1)
                'Me.ProcessQueryCondition(condition, "=", "APP_YEAR", Me.APP_YEAR)
                'Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                Me.ProcessQueryCondition(condition, "=", "APP_DATE", Me.APP_DATE)
                'Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "RECORRECT_NUM", Me.RECORRECT_NUM)
                Me.ProcessQueryCondition(condition, "=", "IS_FORMAL", Me.IS_FORMAL)
                'Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)

                'Unicode欄位查詢
                If Me.AUDIT_OPINION <> "" Then
                    condition.Append(" AND $.AUDIT_OPINION LIKE N'%" & Me.AUDIT_OPINION & "%' ")
                End If

                If Me.USE_STATE <> "" Then
                    condition.Append(" AND $.USE_STATE IN (" & Me.USE_STATE & ")")
                End If

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.Append(" SELECT  APP_YEAR,R1.ITEM, SUM(R1.QUANTITY) AS SUM_QUANTITY ")
                sql.Append(" FROM APPL130 M ")
                sql.Append(" INNER JOIN APPL131 R1 ON R1.MA_PKNO = M.PKNO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                Else
                    sql.AppendLine(" WHERE 1=1 ")
                End If

                If Me.APP_SYEAR <> "" AndAlso Me.APP_SMONTH <> "" AndAlso Me.APP_EYEAR <> "" AndAlso Me.APP_EMONTH <> "" Then
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) >= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_SYEAR, Me.APP_SMONTH)
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) <= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_EYEAR, Me.APP_EMONTH)
                End If

                '行動網路只顯示「總數」
                If Me.NUM_CATEGORY1 = "11" Then
                    sql.Append(" AND R1.ITEM IN ('總數') ")
                End If

                sql.Append(" GROUP BY APP_YEAR, ITEM ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY APP_YEAR")
                    Else
                        sql.AppendLine(" ORDER BY APP_YEAR")
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

#Region "QueryQuarter 查詢季報表 "
        ''' <summary>
        ''' 查詢季報表（號碼子類別、Q1、Q2、Q3、Q4）
        ''' </summary>
        Public Function QueryQuarter() As DataTable
            Return Me.QueryQuarter(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function QueryQuarter(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL130", "M", "PKNO", "APP_PERSON", "LICENSE_NO", "OPERATION_CODE", "STF", "COM_OTEL", "COM_OEMAIL", "NUM_CATEGORY1", "APP_YEAR", "APP_MONTH", "APP_DATE", "USE_STATE", "RECORRECT_NUM", "IS_FORMAL", "AUDIT_OPINION"})
                Me.TableCoumnInfo.Add(New String() {"APPL131", "R1", "PKNO", "MA_PKNO", "NUM_CATEGORY1", "ITEM", "QUANTITY", "DATA_CHK_FLAG"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON", Me.APP_PERSON)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CODE", Me.OPERATION_CODE)
                Me.ProcessQueryCondition(condition, "=", "STF", Me.STF)
                Me.ProcessQueryCondition(condition, "=", "COM_OTEL", Me.COM_OTEL)
                Me.ProcessQueryCondition(condition, "=", "COM_OEMAIL", Me.COM_OEMAIL)
                Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY1", Me.NUM_CATEGORY1)
                'Me.ProcessQueryCondition(condition, "=", "APP_YEAR", Me.APP_YEAR)
                'Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                Me.ProcessQueryCondition(condition, "=", "APP_DATE", Me.APP_DATE)
                'Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "RECORRECT_NUM", Me.RECORRECT_NUM)
                Me.ProcessQueryCondition(condition, "=", "IS_FORMAL", Me.IS_FORMAL)
                'Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)

                'Unicode欄位查詢
                If Me.AUDIT_OPINION <> "" Then
                    condition.Append(" AND $.AUDIT_OPINION LIKE N'%" & Me.AUDIT_OPINION & "%' ")
                End If

                If Me.USE_STATE <> "" Then
                    condition.Append(" AND $.USE_STATE IN (" & Me.USE_STATE & ")")
                End If

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.Append(" SELECT ITEM, SUM([Q1]) AS Q1, SUM([Q2]) AS Q2, SUM([Q3]) AS Q3, SUM([Q4]) AS Q4 ")
                sql.Append(" FROM ")
                sql.Append(" (SELECT  APP_YEAR,APP_MONTH,R1.ITEM, R1.QUANTITY, ")
                sql.Append("     'Q'+ CAST(DatePart(QQ ,CAST(CAST(1911 + CAST(M.APP_YEAR AS int) AS VARCHAR) + '-' + M.APP_MONTH + '-' + CAST('15' AS varchar) AS DATETIME)) AS varchar(1)) AS [Quarter] ")
                sql.Append(" FROM APPL130 M ")
                sql.Append("   INNER JOIN APPL131 R1 ON R1.MA_PKNO = M.PKNO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                Else
                    sql.AppendLine(" WHERE 1=1 ")
                End If

                If Me.APP_SYEAR <> "" AndAlso Me.APP_SMONTH <> "" AndAlso Me.APP_EYEAR <> "" AndAlso Me.APP_EMONTH <> "" Then
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) >= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_SYEAR, Me.APP_SMONTH)
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) <= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_EYEAR, Me.APP_EMONTH)
                End If

                '行動網路只顯示「總數」
                If Me.NUM_CATEGORY1 = "11" Then
                    sql.Append(" AND R1.ITEM IN ('總數') ")
                End If

                sql.Append("   GROUP BY APP_YEAR,APP_MONTH, ITEM,QUANTITY ")
                sql.Append(" ) as up ")
                sql.Append(" Pivot ( ")
                sql.Append(" SUM(QUANTITY) ")
                sql.Append(" FOR ")
                sql.Append(" [Quarter] IN ([Q1],[Q2],[Q3],[Q4]) ")
                sql.Append(" ) as p ")
                sql.Append(" GROUP BY ITEM ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY ITEM")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryMonth 查詢月報表 "
        ''' <summary>
        ''' 查詢月報表（年度、Jan、Feb、Mar、Apr、May、Jun、Jul、Aug、Sep、Oct、Nov、Dec）
        ''' </summary>
        Public Function QueryMonth() As DataTable
            Return Me.QueryMonth(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function QueryMonth(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL130", "M", "PKNO", "APP_PERSON", "LICENSE_NO", "OPERATION_CODE", "STF", "COM_OTEL", "COM_OEMAIL", "NUM_CATEGORY1", "APP_YEAR", "APP_MONTH", "APP_DATE", "USE_STATE", "RECORRECT_NUM", "IS_FORMAL", "AUDIT_OPINION"})
                Me.TableCoumnInfo.Add(New String() {"APPL131", "R1", "PKNO", "MA_PKNO", "NUM_CATEGORY1", "ITEM", "QUANTITY", "DATA_CHK_FLAG"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON", Me.APP_PERSON)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CODE", Me.OPERATION_CODE)
                Me.ProcessQueryCondition(condition, "=", "STF", Me.STF)
                Me.ProcessQueryCondition(condition, "=", "COM_OTEL", Me.COM_OTEL)
                Me.ProcessQueryCondition(condition, "=", "COM_OEMAIL", Me.COM_OEMAIL)
                Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY1", Me.NUM_CATEGORY1)
                'Me.ProcessQueryCondition(condition, "=", "APP_YEAR", Me.APP_YEAR)
                'Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                Me.ProcessQueryCondition(condition, "=", "APP_DATE", Me.APP_DATE)
                'Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "RECORRECT_NUM", Me.RECORRECT_NUM)
                Me.ProcessQueryCondition(condition, "=", "IS_FORMAL", Me.IS_FORMAL)
                'Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)

                'Unicode欄位查詢
                If Me.AUDIT_OPINION <> "" Then
                    condition.Append(" AND $.AUDIT_OPINION LIKE N'%" & Me.AUDIT_OPINION & "%' ")
                End If

                If Me.USE_STATE <> "" Then
                    condition.Append(" AND $.USE_STATE IN (" & Me.USE_STATE & ")")
                End If

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder

                sql.Append(" SELECT APP_YEAR, SUM([1]) AS Jan, SUM([2]) AS Feb, SUM([3]) AS Mar, SUM([4]) AS Apr, SUM([5]) AS May, SUM([6]) AS Jun, SUM([7]) AS Jul, SUM([8]) AS Aug, SUM([9]) AS Sep, SUM([10]) AS Oct, SUM([11]) AS Nov, SUM([12]) AS Dec ")
                sql.Append(" FROM ")
                sql.Append(" (SELECT  APP_YEAR,APP_MONTH,R1.ITEM, R1.QUANTITY  ")
                sql.Append(" FROM APPL130 M ")
                sql.Append("   INNER JOIN APPL131 R1 ON R1.MA_PKNO = M.PKNO ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                Else
                    sql.AppendLine(" WHERE 1=1 ")
                End If

                If Me.APP_SYEAR <> "" AndAlso Me.APP_SMONTH <> "" AndAlso Me.APP_EYEAR <> "" AndAlso Me.APP_EMONTH <> "" Then
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) >= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_SYEAR, Me.APP_SMONTH)
                    sql.AppendFormat(" AND CAST(CAST(1911 + CAST(APP_YEAR AS int) AS VARCHAR) + '-' + APP_MONTH + '-' + CAST('15' AS varchar) AS datetime) <= CAST(CAST(1911 + CAST('{0}' AS int) AS VARCHAR) + '-' + '{1}' + '-' + CAST('15' AS varchar) AS datetime)", Me.APP_EYEAR, Me.APP_EMONTH)
                End If

                '行動網路只顯示「總數」
                If Me.NUM_CATEGORY1 = "11" Then
                    sql.Append(" AND R1.ITEM IN ('總數') ")
                End If

                sql.Append("   GROUP BY APP_YEAR, APP_MONTH, ITEM,QUANTITY ")
                sql.Append(" ) as up ")
                sql.Append(" Pivot ( ")
                sql.Append(" SUM(QUANTITY) ")
                sql.Append(" FOR ")
                sql.Append(" APP_MONTH IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ")
                sql.Append(" ) as p  ")
                sql.Append(" GROUP BY APP_YEAR ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY APP_YEAR")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryRPT2500 線上提報數統計 "
        ''' <summary>
        ''' 線上提報數統計（日期起、日期迄、提報類別、提報子類別、網路事業別、顯示週期）
        ''' </summary>
        Public Function QueryRPT2500() As DataTable
            Return Me.QueryRPT2500("", "", "", "", "", "")
        End Function

        ''' <summary>
        ''' 線上提報數統計（日期起、日期迄、提報類別、提報子類別、網路事業別、顯示週期） 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function QueryRPT2500(ByVal SDATE As String, ByVal EDATE As String, ByVal OPERATE_CD As String, ByVal PROG_CD As String, ByVal MOD_2 As String, ByVal DURATION As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()
                Dim SP_NAME As String = ""

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand


                cmd.Connection = conn
                cmd.CommandText = "ENT_RPT2500_QueryBySp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SDATE", SDATE)
                cmd.Parameters.AddWithValue("@EDATE", EDATE)
                cmd.Parameters.AddWithValue("@OPERATE_CD", OPERATE_CD)
                cmd.Parameters.AddWithValue("@PROG_CD", PROG_CD)
                cmd.Parameters.AddWithValue("@APP_PERSON", APP_PERSON)
                cmd.Parameters.AddWithValue("@LICENSE_NO", LICENSE_NO)
                cmd.Parameters.AddWithValue("@MOD_2", MOD_2)
                cmd.Parameters.AddWithValue("@DURATION", DURATION)


                Dim adpt As DbDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
                adpt.SelectCommand = cmd
                Dim ds As DataSet = New DataSet()
                adpt.Fill(ds)

                Dim dt As DataTable = ds.Tables(0)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#Region "ExportRPT2500 線上提報數統計 - excel "
        ''' <summary>
        ''' 線上提報數統計（日期起、日期迄、提報類別、提報子類別、網路事業別、顯示週期）
        ''' </summary>
        Public Function ExportRPT2500() As DataTable
            Return Me.ExportRPT2500("", "", "", "", "", "")
        End Function

        ''' <summary>
        ''' 線上提報數統計（日期起、日期迄、提報類別、提報子類別、網路事業別、顯示週期） 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 KuChihWei 新增方法
        ''' </remarks>
        Public Function ExportRPT2500(ByVal SDATE As String, ByVal EDATE As String, ByVal OPERATE_CD As String, ByVal PROG_CD As String, ByVal MOD_2 As String, ByVal DURATION As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()
                Dim SP_NAME As String = ""

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand


                cmd.Connection = conn
                cmd.CommandText = "ENT_RPT2500_ExportBySp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SDATE", SDATE)
                cmd.Parameters.AddWithValue("@EDATE", EDATE)
                cmd.Parameters.AddWithValue("@OPERATE_CD", OPERATE_CD)
                cmd.Parameters.AddWithValue("@PROG_CD", PROG_CD)
                cmd.Parameters.AddWithValue("@APP_PERSON", APP_PERSON)
                cmd.Parameters.AddWithValue("@LICENSE_NO", LICENSE_NO)
                cmd.Parameters.AddWithValue("@MOD_2", MOD_2)
                cmd.Parameters.AddWithValue("@DURATION", DURATION)


                Dim adpt As DbDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
                adpt.SelectCommand = cmd
                Dim ds As DataSet = New DataSet()
                adpt.Fill(ds)

                Dim dt As DataTable = ds.Tables(0)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "APP_PERSON,LICENSE_NO,STF,COM_OTEL,COM_OEMAIL,AUDIT_OPINION"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "APP_PERSON,LICENSE_NO,STF,COM_OTEL,COM_OEMAIL,AUDIT_OPINION"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "APP_PERSON,LICENSE_NO,STF,COM_OTEL,COM_OEMAIL,AUDIT_OPINION"
            Return MyBase.UpdateByPkNo()
        End Function

        Public Overrides Sub BatchInsert(ByVal dt As DataTable)
            Dim i As Integer
            If (String.IsNullOrEmpty(dt.TableName)) Then
                dt.TableName = Me.TableName
            End If
            Dim timer As Acer.Util.Timer = New Acer.Util.Timer()
            dt.Columns.Add("PKNO")
            dt.Columns.Add("ROWSTAMP")
            dt.Columns.Add("CREATE_TIME", Type.[GetType]("System.DateTime"))
            dt.Columns.Add("CREATE_USER")
            dt.Columns.Add("UPDATE_TIME", Type.[GetType]("System.DateTime"))
            dt.Columns.Add("UPDATE_USER")
            For Each dr As DataRow In dt.Rows
                Dim [property] As String = APConfig.GetProperty("ENCODE_COLUMN")
                Dim chrArray() As Char = {","c}
                Dim encodeColumns As String() = [property].Split(chrArray)
                Dim str As String = APConfig.GetProperty("ENCODE_TYPE")
                chrArray = New Char() {","c}
                Dim encodeTypes As String() = str.Split(chrArray)
                i = 0
                While i < CInt(encodeColumns.Length)
                    If (If(Not encodeTypes(i).Equals("1"), False, dt.Columns.Contains(encodeColumns(i).Replace(" ", "")))) Then
                        If (String.IsNullOrEmpty(dr(encodeColumns(i).Replace(" ", "")).ToString())) Then
                            dr(encodeColumns(i).Replace(" ", "")) = ""
                        Else
                            dr(encodeColumns(i).Replace(" ", "")) = Utility.TripleDesEncrypt(dr(encodeColumns(i).Replace(" ", "")).ToString())
                        End If
                    End If
                    i = i + 1
                End While
                dr("PKNO") = Me.GetSequence()
                dr("CREATE_USER") = Utility.DBStr(Me.CurrentUserId)
                Dim now As DateTime = DateTime.Now
                dr("CREATE_TIME") = now.ToString("yyyy/MM/dd HH:mm:ss")
                dr("UPDATE_USER") = Utility.DBStr(Me.CurrentUserId)
                now = DateTime.Now
                dr("UPDATE_TIME") = now.ToString("yyyy/MM/dd HH:mm:ss")
                dr("ROWSTAMP") = DateUtil.GetNowTimeMS()
            Next
            Dim columnBuff As StringBuilder = New StringBuilder()
            i = 0
            While i < dt.Columns.Count
                columnBuff.Append(String.Concat(",", dt.Columns(i).ColumnName))
                i = i + 1
            End While
            columnBuff.Remove(0, 1)
            If (Me.Logger.IsLog) Then
                Me.Logger.Append(String.Concat("TableName:", dt.TableName, ", ColumnName:", columnBuff.ToString()))
                If (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("Y")) Then
                    Dim data As StringBuilder = New StringBuilder()
                    If (If(dt Is Nothing, True, dt.Rows.Count <= 0)) Then
                        Me.Logger.Append("No Data")
                    Else
                        For Each row As DataRow In dt.Rows
                            i = 0
                            While i < dt.Columns.Count
                                data.Append(String.Concat(",", row(dt.Columns(i).ColumnName).ToString()))
                                i = i + 1
                            End While
                            data.Append("" & vbCrLf & "")
                        Next
                        Me.Logger.Append(String.Concat("Data:", data.Remove(0, 1).ToString()))
                    End If
                End If
                Dim logger As MyLogger = Me.Logger
                Dim diffTime() As Object = {"EntityBase-BatchInsert dt 準備時間：", timer.GetDiffTime(), "ms, 筆數:", dt.Rows.Count}
                logger.Append(String.Concat(diffTime))
            End If

            'Me.DBManager.GetDBAccess(conn).SqlBulryInsert(dt)
            Me.SqlBulryInsert(dt)

        End Sub

        Public Sub SqlBulryInsert(ByVal dt As DataTable)
            Dim timer As Acer.Util.Timer = New Acer.Util.Timer()
            Dim conn As DbConnection = Me.DBManager.GetIConnection("TSBA")
            Dim transaction As DbTransaction = Me.DBManager.GetDBTransaction(conn)

            Dim sqlBulkCopy As System.Data.SqlClient.SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy((DirectCast(conn, SqlConnection)), SqlBulkCopyOptions.FireTriggers, DirectCast(transaction, SqlTransaction)) With
            {
                .DestinationTableName = dt.TableName
            }
            If (If(dt Is Nothing, False, dt.Rows.Count <> 0)) Then
                Dim idx As Integer = 0
                While idx < dt.Columns.Count
                    sqlBulkCopy.ColumnMappings.Add(dt.Columns(idx).ColumnName, dt.Columns(idx).ColumnName)
                    idx = idx + 1
                End While
                sqlBulkCopy.BulkCopyTimeout = 3000
                sqlBulkCopy.WriteToServer(dt)
            End If
            sqlBulkCopy.Close()

            If (If(Not Me.DBManager.GetDBAccess(conn).IsLog, False, Me.Logger.IsLog)) Then
                Dim logger As MyLogger = Me.Logger
                Dim tableName() As Object = {"TABLE:", dt.TableName, " SqlBulryInsert 執行時間：", timer.GetDiffTime(), " ms, 異動筆數:", dt.Rows.Count}
                logger.Append(String.Concat(tableName))
            End If
        End Sub
#End Region


    End Class
End Namespace

