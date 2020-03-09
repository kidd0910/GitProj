'----------------------------------------------------------------------------------
'File Name		: SYST020
'Author			: CM Huang
'Description		: SYST020 號碼查詢網址管理
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/10/23	CM Huang		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Sys.Data
    ' <summary>
    ' SYST020 號碼查詢網址管理
    ' </summary>
    Public Class ENT_SYST020
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
            Me.TableName = "SYST020"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "INFO_TYPE"
        '' <summary>
        '' INFO_TYPE
        '' </summary>
        Public Property INFO_TYPE() As String
            Get
                Return Me.ColumnyMap("INFO_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INFO_TYPE") = value
            End Set
        End Property
#End Region

#Region "ITEM"
        '' <summary>
        '' ITEM
        '' </summary>
        Public Property ITEM() As String
            Get
                Return Me.ColumnyMap("ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM") = value
            End Set
        End Property
#End Region

#Region "URL"
        '' <summary>
        '' URL
        '' </summary>
        Public Property URL() As String
            Get
                Return Me.ColumnyMap("URL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("URL") = value
            End Set
        End Property
#End Region

#Region "ST_DATE"
        '' <summary>
        '' ST_DATE
        '' </summary>
        Public Property ST_DATE() As String
            Get
                Return Me.ColumnyMap("ST_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ST_DATE") = value
            End Set
        End Property
#End Region

#Region "ED_DATE"
        '' <summary>
        '' ED_DATE
        '' </summary>
        Public Property ED_DATE() As String
            Get
                Return Me.ColumnyMap("ED_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ED_DATE") = value
            End Set
        End Property
#End Region

#Region "USER_TYPE"
        '' <summary>
        '' USER_TYPE
        '' </summary>
        Public Property USER_TYPE() As String
            Get
                Return Me.ColumnyMap("USER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USER_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT"
        '' <summary>
        '' SYS_SORT
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.ColumnyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_SORT") = value
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
                'Me.TableCoumnInfo.Clear()
                Me.TableCoumnInfo.Add(New String() {"SYST020", "M", "ITEM", "URL", "INFO_TYPE", "USER_TYPE", "SYS_SORT", "USE_STATE", "ST_DATE", "ED_DATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, isNull(R2.CH_NAME, '') AS UPDATE_USER1, ")
                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(UPDATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME_1 , ")
                'sql.AppendLine(" (  CAST(YEAR(UPDATE_TIME) AS VARCHAR(4)) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME2,  ")

                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE1 ")

                sql.AppendLine(" FROM SYST020 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R2 ON M.UPDATE_USER = R2.ACNT ")
                'sql.AppendLine(" LEFT JOIN (SELECT USE_NO, ACTUAL_FILENAME as ACTUAL_FILENAME1 FROM COMT020) R3 ON M.PKNO = R3.USE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY INFO_TYPE ASC,ST_DATE ASC")
                    Else
                        sql.AppendLine(" ORDER BY INFO_TYPE ASC,ST_DATE ASC ")
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
#Region "Query2 manual查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function Query2() As DataTable
            Return Me.Query2(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Kevin YU 新增方法
        ''' </remarks>
        Public Function Query2(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.TableCoumnInfo.Clear()
                Me.TableCoumnInfo.Add(New String() {"SYST020", "M", "ITEM", "URL", "INFO_TYPE", "USER_TYPE", "SYS_SORT", "USE_STATE", "ST_DATE", "ED_DATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                'ROW_NUMBER() OVER ( ORDER BY SYS_SORT asc,UPDATE_TIME desc)AS RowNumber, 
                sql.AppendLine(" select M.PKNO, M.ITEM,M.USER_TYPE,M.SYS_SORT, isNull(R2.CH_NAME, '') AS UPDATE_USER1, ")
                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(UPDATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME_1 , ")
                'sql.AppendLine(" (  CAST(YEAR(UPDATE_TIME) AS VARCHAR(4)) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME2,  ")

                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE1,  ")

                sql.AppendLine(" ACTUAL_FILENAME1 ")

                sql.AppendLine(" FROM SYST020 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R2 ON M.UPDATE_USER = R2.ACNT ")
                sql.AppendLine(" LEFT JOIN (SELECT FILE_NO, ACTUAL_FILENAME as ACTUAL_FILENAME1 FROM COMT010 WITH(NOLOCK)) R3 ON M.PKNO = R3.FILE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If
                sql.AppendLine(" group BY M.PKNO,M.INFO_TYPE, M.ITEM,M.USER_TYPE,M.SYS_SORT,R2.CH_NAME,M.USE_STATE,M.UPDATE_TIME,R3.ACTUAL_FILENAME1 ")
                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY " & Me.OrderBys)

                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY INFO_TYPE ASC,SYS_SORT DESC,UPDATE_TIME_1 DESC")
                    Else
                        sql.AppendLine(" ORDER BY INFO_TYPE ASC,SYS_SORT DESC,UPDATE_TIME_1 DESC ")
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

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "ITEM,URL"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "ITEM,URL"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "ITEM,URL"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

