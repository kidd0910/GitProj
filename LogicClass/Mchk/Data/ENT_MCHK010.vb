'----------------------------------------------------------------------------------
'File Name		: MCHK010
'Author			: Becky
'Description		: MCHK010 查核單
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/01/09	Becky		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Mchk.Data
    ' <summary>
    ' MCHK010 查核單
    ' </summary>
    Public Class ENT_MCHK010
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
            Me.TableName = "MCHK010"
            Me.SysName = "MCHK"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "MCHK_NO,TECH_NAME,CHK_NAME,MCHK_DESC1,MCHK_DESC2"
            Me.SET_NULL_FIELD = "MCHK_DATE,REPLY_DATE,CLOSE_DATE"
        End Sub
#End Region

#Region "屬性"
#Region "MCHK_STATUS MCHK_STATUS"
        '' <summary>
        '' MCHK_STATUS MCHK_STATUS
        '' </summary>
        Public Property MCHK_STATUS() As String
            Get
                Return Me.ColumnyMap("MCHK_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_STATUS") = value
            End Set
        End Property
#End Region

#Region "MCHK_NO 查核代號"
        '' <summary>
        '' MCHK_NO 查核代號
        '' </summary>
        Public Property MCHK_NO() As String
            Get
                Return Me.ColumnyMap("MCHK_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_NO") = value
            End Set
        End Property
#End Region

#Region "APPL010_PKNO 查核審驗機構"
        '' <summary>
        '' APPL010_PKNO 查核審驗機構
        '' </summary>
        Public Property APPL010_PKNO() As String
            Get
                Return Me.ColumnyMap("APPL010_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APPL010_PKNO") = value
            End Set
        End Property
#End Region

#Region "MCHK_DATE 實地查核日期"
        '' <summary>
        '' MCHK_DATE 實地查核日期
        '' </summary>
        Public Property MCHK_DATE() As String
            Get
                Return Me.ColumnyMap("MCHK_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_DATE") = value
            End Set
        End Property
#End Region

#Region "TECH_NAME 電機技師"
        '' <summary>
        '' TECH_NAME 電機技師
        '' </summary>
        Public Property TECH_NAME() As String
            Get
                Return Me.ColumnyMap("TECH_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TECH_NAME") = value
            End Set
        End Property
#End Region

#Region "CHK_NAME NCC查核人員"
        '' <summary>
        '' CHK_NAME NCC查核人員
        '' </summary>
        Public Property CHK_NAME() As String
            Get
                Return Me.ColumnyMap("CHK_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHK_NAME") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC1 本會查核意見"
        '' <summary>
        '' MCHK_DESC1 本會查核意見
        '' </summary>
        Public Property MCHK_DESC1() As String
            Get
                Return Me.ColumnyMap("MCHK_DESC1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_DESC1") = value
            End Set
        End Property
#End Region

#Region "REPLY_DATE 總處回復日期"
        '' <summary>
        '' REPLY_DATE 總處回復日期
        '' </summary>
        Public Property REPLY_DATE() As String
            Get
                Return Me.ColumnyMap("REPLY_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPLY_DATE") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC2 審驗總處說明"
        '' <summary>
        '' MCHK_DESC2 審驗總處說明
        '' </summary>
        Public Property MCHK_DESC2() As String
            Get
                Return Me.ColumnyMap("MCHK_DESC2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MCHK_DESC2") = value
            End Set
        End Property
#End Region

#Region "CLOSE_DATE 結案日期"
        '' <summary>
        '' CLOSE_DATE 結案日期
        '' </summary>
        Public Property CLOSE_DATE() As String
            Get
                Return Me.ColumnyMap("CLOSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CLOSE_DATE") = value
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
        ''' 0.0.1 Becky 新增方法
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
                Me.TableCoumnInfo.Add(New String() {"MCHK010", "M", "PKNO", "MCHK_STATUS", "MCHK_NO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.COM_CNAM, R2.SYS_NAME AS MCHK_STATUS_NM ")
                sql.AppendLine(" FROM MCHK010 M ")
                sql.AppendLine(" LEFT JOIN APPL010 R1 ON M.APPL010_PKNO = R1.PKNO ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 ON R2.SYS_KEY = 'MCHK_STATUS' AND M.MCHK_STATUS = R2.SYS_ID ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY PKNO ")
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

#Region "Get上傳檔案"
        ''' <summary>
        ''' Get查核重點 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Becky 新增方法
        ''' </remarks>
        Public Function Get上傳檔案() As DataTable
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
                Me.TableCoumnInfo.Clear()
                Me.ParserAlias()

                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT M.* ")
                SQL.AppendLine("FROM COMT010 M ")
                SQL.AppendLine("WHERE FILE_NO = '" & Me.PKNO & "' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    SQL.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
                End If
                SQL.AppendLine("ORDER BY M.CREATE_TIME")


                Dim dt As DataTable = Me.QueryBySql(SQL.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get查核重點"
        ''' <summary>
        ''' Get上傳檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Becky 新增方法
        ''' </remarks>
        Public Function Get查核重點() As DataTable
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
                Me.TableCoumnInfo.Clear()
                Me.ParserAlias()

                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT M.SYS_ID,")
                SQL.AppendLine("       M.SYS_NAME AS TITLE,")
                SQL.AppendLine("       R1.MCHK_DESC,R1.PKNO,")
                SQL.AppendLine("       R2.SYS_ID AS MCHK_RESULT")
                SQL.AppendLine("  FROM SYST010 M")
                SQL.AppendLine("       LEFT JOIN MCHK020 R1")
                SQL.AppendLine("          ON M.SYS_ID = R1.MCHK_ITEM AND R1.MCHK010_PKNO = '" & Me.PKNO & "'")
                SQL.AppendLine("       LEFT JOIN SYST010 R2")
                SQL.AppendLine("          ON R2.SYS_KEY = 'MCHK_RESULT' AND R2.SYS_ID = R1.MCHK_RESULT")
                SQL.AppendLine(" WHERE     M.SYS_KEY = 'MCHK_ITEM'")
                SQL.AppendLine("       AND M.SYS_PRTID = ''")
                SQL.AppendLine("       AND M.SYS_TYPE = 1")
                SQL.AppendLine("       AND M.USE_STATE = 1")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    SQL.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
                End If
                SQL.AppendLine("ORDER BY M.SYS_SORT")


                Dim dt As DataTable = Me.QueryBySql(SQL.ToString)

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


