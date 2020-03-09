'----------------------------------------------------------------------------------
'File Name		: APP2030
'Author			: San
'Description		: APP2030 諮詢委員會議開放案件
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/21	San		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace App.Data
    ' <summary>
    ' APP2030 諮詢委員會議開放案件
    ' </summary>
    Public Class ENT_APP2030
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
            Me.TableName = "APP2030"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE
        '' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號, REF APPL020.CASE_NO"
        '' <summary>
        '' CASE_NO 案件編號, REF APPL020.CASE_NO
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

#Region "SYS_SORT 排序"
        '' <summary>
        '' SYS_SORT 排序
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
        ''' 0.0.1   新增方法
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO", "SYS_SORT", "CASE_NO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R3", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*,R1.COM_PKNO, R4.APP_PERSON_NM, R2.SYS_NAME AS 'CASE_CODE_NM', R3.SYS_NAME AS 'CASE_STATUS_NM'  ")
                sql.AppendLine("  , CASE ")
                sql.AppendLine(" 		WHEN R1.CASE_CODE IN ('AA03', 'AA04', 'AA05', 'AA06', 'CA03', 'CA04', 'CA05', 'CA06') THEN  ")
                sql.AppendLine(" 			(SELECT APP1010.SYS_CNAME FROM APP1010 WHERE M.CASE_NO = APP1010.CASE_NO) ")
                sql.AppendLine(" 		WHEN R1.CASE_CODE IN ('BA03', 'BA04', 'BA05', 'BA06')  THEN ")
                sql.AppendLine(" 			(SELECT APP1170.CHANNEL_NAME FROM APP1170 WHERE M.CASE_NO = APP1170.CASE_NO) ")
                sql.AppendLine(" 		ELSE '' ")
                sql.AppendLine("    END AS THIS_CASE_CHANNEL_NAME ")
                sql.AppendLine("  FROM APP2030 M    ")
                sql.AppendLine("   LEFT JOIN APPL020 R1 ON M.CASE_NO = R1.CASE_NO   ")
                sql.AppendLine("   LEFT JOIN SYST010 R2 ON (R2.SYS_ID = R1.CASE_CODE AND R2.SYS_KEY='CASE_CODE')  ")
                sql.AppendLine("   LEFT JOIN SYST010 R3 ON (R3.SYS_ID = R1.CASE_STATUS AND R3.SYS_KEY='CASE_STATUS')  ")
                sql.AppendLine("   LEFT JOIN APP1010 R4 ON M.CASE_NO = R4.CASE_NO  ")
                sql.AppendLine("  WHERE 1 = 1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
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

#Region "QueryCaseInfo "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryCaseInfo() As DataTable
            Return Me.QueryCaseInfo(0, 0)
        End Function

        ''' <summary>
        ''' DoQueryCaseInfo
        ''' </summary>      
        Function QueryCaseInfo(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT  ")
                sql.AppendLine(" APP1010.CASE_NO ")
                sql.AppendLine(" , APP1010.APP_PERSON_NM ")
                sql.AppendLine(" , APP1010.SYS_CNAME ")
                sql.AppendLine(" , APP1170.ORG_TYPE1 ")
                sql.AppendLine(" , APP1170.CHANNEL_NAME ")
                sql.AppendLine(" , (select SYS_NAME from SYST010 where SYS_KEY='ORG_TYPE1' and SYS_ID=APP1170.ORG_TYPE1) as ORG_TYPE1_NM ")
                sql.AppendLine(", APP2010.MEETING_TYPE ")
                sql.AppendLine(", (select SYS_NAME from SYST010 where SYS_KEY='MEETING_TYPE' and SYS_ID=APP2010.MEETING_TYPE) as MEETING_TYPE_NM ")
                sql.AppendLine(" , APP1170.LOCK_CHANNEL_FLAG ")
                sql.AppendLine(" , APP1170.CH_FLAG1 ")
                sql.AppendLine(" , APP1170.CH_FLAG2 ")
                sql.AppendLine(" , APP1170.CH_FLAG3 ")
                sql.AppendLine(" , APP1170.CH_FLAG4 ")
                sql.AppendLine(" , APP1170.CH_FLAG5 ")
                sql.AppendLine(" , APP1170.CH_FLAG6 ")
                sql.AppendLine(" , APP1170.CH_FLAG7 ")
                sql.AppendLine(" , APP1170.CH_FLAG8 ")
                sql.AppendLine(" , APP1170.CH_FLAG9 ")
                sql.AppendLine(" , APP1170.CH_FLAG10 ")
                sql.AppendLine(" , APP1170.CH_FLAG11 ")
                sql.AppendLine(" , APP1170.CH_FLAG12 ")
                sql.AppendLine(" , APP1170.CH_FLAG13 ")
                sql.AppendLine(" , APP1170.CH_FLAG13_DESC ")
                sql.AppendLine(" FROM APP2030  M  ")
                sql.AppendLine(" LEFT JOIN APP1010 On APP1010.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" LEFT JOIN APP1170 On APP1170.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" LEFT JOIN APP2010 on APP2010.GROUP_CODE = M.GROUP_CODE ")
                sql.AppendLine("  WHERE 1 = 1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" And " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.CASE_NO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' distinct
        ''' DoQueryCaseInfo_1170 
        ''' </summary>      
        Function QueryCaseInfo1170() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" Select DISTINCT ")
                sql.AppendLine("    M.CASE_NO ")
                sql.AppendLine("    , APP1170.CHANNEL_NAME ")
                sql.AppendLine(" FROM APP2030  M ")
                sql.AppendLine(" INNER JOIN APP1170 On APP1170.CASE_NO = M.CASE_NO ")
                sql.AppendLine("  WHERE 1 = 1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" And " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.CASE_NO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' distinct
        ''' DoQueryCaseInfo_1010
        ''' </summary>      
        Function QueryCaseInfo1010() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" Select DISTINCT ")
                sql.AppendLine("    M.CASE_NO ")
                sql.AppendLine("    , APP1010.APP_PERSON_NM ")
                sql.AppendLine(" FROM APP2030 M ")
                sql.AppendLine(" INNER JOIN APP1010 On APP1010.CASE_NO = M.CASE_NO ")
                sql.AppendLine("  WHERE 1 = 1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" And " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.CASE_NO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryCaseUseStatus() As DataTable
            Return Me.QueryCaseUseStatus(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   新增方法
        ''' </remarks>
        Public Function QueryCaseUseStatus(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "CASE_NO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" Select M.*, R1.USE_STATE, R1.GROUP_NAME ")
                sql.AppendLine(" FROM APP2030 M ")
                sql.AppendLine(" LEFT JOIN APP2010 R1 On (M.GROUP_CODE = R1.GROUP_CODE) ")
                sql.AppendLine(" JOIN APP2020 R2 On (M.GROUP_CODE = R2.GROUP_CODE) And (R2.ACNT = '" + SessionClass.員工編號 + "')")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                'End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
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

#Region "Query 查詢 MAX SYS_SORT "
        ''' <summary>
        ''' 查詢 MAX SYS_SORT
        ''' </summary>
        Public Function QueryMaxSYS_SORT(ByVal GROUP_CODE As String) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine("  SELECT ISNULL((SELECT  MAX(SYS_SORT) FROM APP2030 WHERE GROUP_CODE = '" + GROUP_CODE + "' ) ,0) as MAX_SYS_SORT  ")

                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "QueryCaseInfo for 3.1"
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryCaseInfo_3_1() As DataTable
            Return Me.QueryCaseInfo_3_1(0, 0)
        End Function

        ''' <summary>
        ''' DoQueryCaseInfo
        ''' </summary>      
        Function QueryCaseInfo_3_1(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2030", "M", "GROUP_CODE", "PKNO", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT  ")
                sql.AppendLine(" (ROW_NUMBER() OVER (ORDER BY M.CASE_NO, M.SYS_SORT) ) AS ROW_NUM  ")
                sql.AppendLine(" , APP1010.CASE_NO ")
                sql.AppendLine(" , APP1010.APP_PERSON_NM ")
                sql.AppendLine(" , APP1010.SYS_CNAME ")
                sql.AppendLine(" , APP1170.ORG_TYPE1 ")
                sql.AppendLine(" , APP1170.CHANNEL_NAME ")
                sql.AppendLine(" , (select SYS_NAME from SYST010 where SYS_KEY='ORG_TYPE1' and SYS_ID=APP1170.ORG_TYPE1) as ORG_TYPE1_NM ")
                sql.AppendLine(", APP2010.MEETING_TYPE ")
                sql.AppendLine(", (select SYS_NAME from SYST010 where SYS_KEY='MEETING_TYPE' and SYS_ID=APP2010.MEETING_TYPE) as MEETING_TYPE_NM ")
                sql.AppendLine(" , APP1170.LOCK_CHANNEL_FLAG ")
                sql.AppendLine(" , APP1170.CH_FLAG1 ")
                sql.AppendLine(" , APP1170.CH_FLAG2 ")
                sql.AppendLine(" , APP1170.CH_FLAG3 ")
                sql.AppendLine(" , APP1170.CH_FLAG4 ")
                sql.AppendLine(" , APP1170.CH_FLAG5 ")
                sql.AppendLine(" , APP1170.CH_FLAG6 ")
                sql.AppendLine(" , APP1170.CH_FLAG7 ")
                sql.AppendLine(" , APP1170.CH_FLAG8 ")
                sql.AppendLine(" , APP1170.CH_FLAG9 ")
                sql.AppendLine(" , APP1170.CH_FLAG10 ")
                sql.AppendLine(" , APP1170.CH_FLAG11 ")
                sql.AppendLine(" , APP1170.CH_FLAG12 ")
                sql.AppendLine(" , APP1170.CH_FLAG13 ")
                sql.AppendLine(" , APP1170.CH_FLAG13_DESC ")
                sql.AppendLine(" , M.SYS_SORT ")
                sql.AppendLine(" , APP2010.GROUP_NAME ")
                sql.AppendLine(" , SYST010.SYS_NAME AS CASE_CODE_NM ")
                sql.AppendLine(" , APPL020.CASE_CODE ")
                sql.AppendLine(" , (select SYS_NAME from SYST010 where SYS_ID = APPL020.CASE_STATUS and SYS_KEY = 'CASE_STATUS' ) as CASE_STATUS_NM ")
                sql.AppendLine("  , CASE ")
                sql.AppendLine(" 		WHEN APPL020.CASE_CODE IN ('AA03', 'AA04', 'AA05', 'AA06', 'CA03', 'CA04', 'CA05', 'CA06') THEN  ")
                sql.AppendLine(" 			APP1010.SYS_CNAME ")
                sql.AppendLine(" 		WHEN APPL020.CASE_CODE IN ('BA03', 'BA04', 'BA05', 'BA06')  THEN ")
                sql.AppendLine(" 			APP1170.CHANNEL_NAME  ")
                sql.AppendLine(" 		ELSE '' ")
                sql.AppendLine("    END AS THIS_CASE_CHANNEL_NAME ")
                sql.AppendLine(" FROM APP2030  M  ")
                sql.AppendLine(" LEFT JOIN APP1010 ON APP1010.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" LEFT JOIN APP1170 ON APP1170.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" LEFT JOIN APP2010 ON APP2010.GROUP_CODE = M.GROUP_CODE  AND USE_STATE = 1 ")
                sql.AppendLine(" LEFT JOIN APP2020 ON M.GROUP_CODE = APP2020.GROUP_CODE AND APP2020.ACNT =  '" + SessionClass.員工編號 + "'")
                sql.AppendLine(" INNER JOIN APPL020  ")
                sql.AppendLine("    ON M.CASE_NO = APPL020.CASE_NO   ")
                sql.AppendLine("    AND APPL020.CASE_STATUS in ('20','31','39','29')    ")
                sql.AppendLine("    AND APPL020.CASE_NO IN (SELECT CASE_NO FROM GET_CASE_RIGHT ('" + SessionClass.員工編號 + "' ))      ")
                sql.AppendLine(" LEFT JOIN SYST010 ON (SYST010.SYS_ID = APPL020.CASE_CODE AND SYST010.SYS_KEY='CASE_CODE')  ")
                sql.AppendLine("  WHERE 1 = 1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" And " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                'sql.AppendLine(" ORDER BY M.CASE_NO, M.SYS_SORT ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.CASE_NO ")
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

    End Class
End Namespace

