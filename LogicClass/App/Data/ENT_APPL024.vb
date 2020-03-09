Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1400 APP1400 廣播事業申設報告
    ' </summary>
    Public Class ENT_APPL024
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
            Me.TableName = "APPL024"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,TOPIC_ANSWER"
            Me.SET_NULL_FIELD = ""
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

#Region "TOPIC_SEQ TOPIC_SEQ"
        '' <summary>
        '' TOPIC_SEQ TOPIC_SEQ
        '' </summary>
        Public Property TOPIC_SEQ() As String
            Get
                Return Me.ColumnyMap("TOPIC_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOPIC_SEQ") = value
            End Set
        End Property
#End Region

#Region "TOPIC_ANSWER TOPIC_ANSWER"
        '' <summary>
        '' TOPIC_ANSWER TOPIC_ANSWER
        '' </summary>
        Public Property TOPIC_ANSWER() As String
            Get
                Return Me.ColumnyMap("TOPIC_ANSWER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOPIC_ANSWER") = value
            End Set
        End Property
#End Region

#Region "MARK"
        '' <summary>
        '' MARK
        '' </summary>
        Public Property MARK() As String
            Get
                Return Me.ColumnyMap("MARK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MARK") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE"
        '' <summary>
        '' CASE_CODE
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.ColumnyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_CODE") = value
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

#Region "ACNT"
        '' <summary>
        '' ACNT
        '' </summary>
        Public Property ACNT() As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TYPE"
        '' <summary>
        '' SUBJECT_TYPE
        '' </summary>
        Public Property SUBJECT_TYPE() As String
            Get
                Return Me.ColumnyMap("SUBJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "REVIEW_RESULT"
        '' <summary>
        '' REVIEW_RESULT
        '' </summary>
        Public Property REVIEW_RESULT() As String
            Get
                Return Me.ColumnyMap("REVIEW_RESULT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REVIEW_RESULT") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#Region "Query"
        ''' <summary>
        ''' 查詢 
        ''' </summary>      
        Public Overrides Function Query() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL024", "M", "CASE_CODE", "PKNO", "CASE_NO", "TOPIC_SEQ", "TOPIC_ANSWER", "REVIEW_RESULT", "MARK", "SUBJECT_TYPE", "ACNT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT * FROM APPL024 M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'If Me.OrderBys <> "" Then
                '    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                'Else
                '    If pageNo = 0 Then
                '        sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                '    Else
                '        sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                '    End If
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query Report "
        '' <summary>
        '' 查詢 
        '' </summary>      
        Public Function QueryReport() As DataTable
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
                'Me.TableCoumnInfo.Add(New String() {"APP0003", "M", ""})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT  ")
                sql.AppendLine(" APP0004.CASE_CODE ")
                sql.AppendLine(" ,APP0004.QNO ")
                sql.AppendLine(" ,APP0004.QNO_DESC ")
                sql.AppendLine(" ,APPL024.CASE_NO ")
                sql.AppendLine(" ,APPL024.TOPIC_SEQ ")
                sql.AppendLine(" ,APPL024.TOPIC_ANSWER ")
                sql.AppendLine(" ,APPL024.MARK ")
                sql.AppendLine(" ,APPL024.REVIEW_RESULT ")
                sql.AppendLine(" ,APP0004.SUBJECT_TYPE ")
                sql.AppendLine(" ,APPL024.ACNT ")
                sql.AppendLine(" ,POST020.CH_NAME ")
                sql.AppendLine(" FROM APP0004 ")
                sql.AppendLine(" INNER JOIN APPL024 ON APPL024.TOPIC_SEQ = APP0004.QNO ")
                sql.AppendLine("    AND APPL024.CASE_NO = '" + Me.CASE_NO + "' ")
                sql.AppendLine(" INNER JOIN POST020 ON APPL024.ACNT = POST020.ACNT ")
                sql.AppendLine(" WHERE APP0004.CASE_CODE = '" + Me.CASE_CODE + "' ")
                If Me.SUBJECT_TYPE.Length > 0 Then
                    sql.AppendLine(" AND APP0004.SUBJECT_TYPE IN ('" + Me.SUBJECT_TYPE + "') ")
                End If
                If Me.ACNT.Length > 0 Then
                    sql.AppendLine(" AND APPL024.ACNT = '" + Me.ACNT + "'")
                End If


                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                'End If

                'If Me.OrderBys <> "" Then
                '    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                'Else
                '    If pageNo = 0 Then
                '        sql.AppendLine(" ORDER BY M.STNO ")
                '    Else
                '        sql.AppendLine(" ORDER BY STNO ")
                '    End If
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query Report SUM MARK "
        '' <summary>
        '' 查詢總分
        '' </summary>      
        Public Function QuerySumMARK() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL024", "M", "CASE_CODE", "PKNO", "CASE_NO", "TOPIC_SEQ", "TOPIC_ANSWER", "REVIEW_RESULT", "MARK", "SUBJECT_TYPE", "ACNT"})
                Me.ParserAlias()


                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT distinct ")
                sql.AppendLine(" M.ACNT  ")
                sql.AppendLine(" ,POST020.CH_NAME ")
                sql.AppendLine(" ,(SELECT SUM(MARK) FROM APPL024 THISA024 WHERE THISA024.ACNT = M.ACNT AND THISA024.CASE_NO = '" + Me.CASE_NO + "') as TOTAL_MARK ")
                sql.AppendLine(" FROM APPL024 M ")
                sql.AppendLine(" INNER JOIN POST020 on M.ACNT = POST020.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'If Me.OrderBys <> "" Then
                '    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                'Else
                '    If pageNo = 0 Then
                '        sql.AppendLine(" ORDER BY M.STNO ")
                '    Else
                '        sql.AppendLine(" ORDER BY STNO ")
                '    End If
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "查詢 UpdateUser"
        '' <summary>
        '' 查詢 UpdateUser 
        '' </summary>      
        Public Function QueryUser() As DataTable
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
                'Me.TableCoumnInfo.Add(New String() {"APP0003", "M", ""})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT distinct UPDATE_USER  ")
                sql.AppendLine(" FROM APPL024 ")
                sql.AppendLine(" WHERE CASE_NO = '" + Me.CASE_NO + "' ")



                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                'End If

                'If Me.OrderBys <> "" Then
                '    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                'Else
                '    If pageNo = 0 Then
                '        sql.AppendLine(" ORDER BY M.STNO ")
                '    Else
                '        sql.AppendLine(" ORDER BY STNO ")
                '    End If
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

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

