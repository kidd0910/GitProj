'----------------------------------------------------------------------------------
'File Name		: 報表查詢
'Author			: CM Huang
'Description	: 報表查詢 (有取Session, 限web用)
'                 無Query
'MEMO           : 手動增加2.3.5.1 / 2.3.5.2 功能權限(0005, 管理者)，加權限給業者管理者群組
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/04	CM Huang		Source Create
'                                       黃金門號欄位名稱不同
'                                       
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext

Namespace Rpt.Data
    ' <summary>
    ' 報表查詢
    ' </summary>
    Public Class ENT_RPTList
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
            Me.TableName = ""
            Me.SysName = ""
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"



#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.PropertyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH") = value
            End Set
        End Property
#End Region

#End Region

#Region "承辦人選單查詢 STFQuery"
        ''' <summary>
        ''' 承辦人選單查詢查詢(以提報資料為主)
        ''' 2.3.5.1 / 2.3.5.2 專用
        ''' </summary>
        ''' <param name="num" >0:2.3.5.1 已結案之承辦清單  / 1:2.3.5.2 承辦統計</param>
        ''' <returns>DataTable (帳號基本欄位, 帳號 - 中文名稱 as LIST)</returns>
        ''' <remarks>
        ''' 登入者若為NCC人員以 3.9.1NCC帳號管理 設定執照為範圍，列出提報資料的所有承辦人欄位
        ''' 登入者若為業者admin，以該業者所有提報資料為範圍列出所有承辦人
        ''' 登入者若為一般業者帳號，承辦人只有本身一項
        ''' </remarks>
        Public Function STFQuery(Optional ByVal num As Integer = 0) As DataTable
            Return Me.STFQuery(0, 0, num)
        End Function

        ''' <summary>
        ''' 承辦人查詢(以提報資料為主)
        ''' 登入者若為NCC人員以 3.9.1NCC帳號管理 設定執照為範圍，列出提報資料的所有承辦人欄位
        ''' 登入者若為業者admin，以該業者所有提報資料為範圍列出所有承辦人
        ''' 登入者若為一般業者帳號，承辦人只有本身一項
        ''' 2.3.5.1 / 2.3.5.2 專用
        ''' </summary>
        ''' <param name="num" >0:2.3.5.1 已結案之承辦清單  / 1:2.3.5.2 承辦統計</param>
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
        Public Function STFQuery(ByVal pageNo As Integer, ByVal pageSize As Integer, ByVal num As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"POST020", "R1", "PKNO", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "USE_STATE"})
                Me.ParserAlias()

                '限制條件
                Dim strLic As String = ""
                Dim strLic2 As String = ""

                If Current.Session("PERSON_TYPE") = 0 Then
                    'NCC 依所設定執照範圍查詢資料
                    If Current.Session("IS_ALL") <> "Y" Then
                        If Current.Session("LICENSE_NO_DATA") <> "" Then
                            strLic = " AND LICENSE_NO IN (" & strLicNo() & ") "
                            strLic2 = " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                        Else
                            '無任何可用執照，不傳回資料
                            strLic = " AND 1=2 "
                            strLic2 = strLic
                        End If

                    End If

                Else

                    '業者 須限定本身資料範圍
                    strLic = " AND APP_PERSON='" & Current.Session("DEP_CODE") & "' "

                    '黃金門號
                    strLic2 = " AND APP_PERSON_PKNO='" & Current.Session("DEP_CODE") & "' "

                    Dim val As String = ""

                    If num = 0 Then
                        '2.3.5.1 已結案清單查詢 權限參數
                        val = Current.Session("RPT1110_FUNC_PERMISSION")
                    ElseIf num = 1 Then
                        '2.3.5.2 承辦統計查詢 權限參數
                        val = Current.Session("RPT1120_FUNC_PERMISSION")
                    End If

                    If val.IndexOf("0005") < 0 Then
                        '非管理者依所設定執照範圍查詢資料
                        If Current.Session("IS_ALL") <> "Y" Then
                            '一般業務承辦人只能為自已

                            strLic &= " AND STF='" & Current.Session("ACNT") & "' "
                            strLic2 &= " AND CONTRACTOR='" & Current.Session("ACNT") & "' "

                            If Current.Session("LICENSE_NO_DATA") <> "" Then
                                strLic &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                                strLic2 &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                            Else
                                '無任何可用執照，不傳回資料
                                strLic &= " AND 1=2 "
                                strLic2 &= " AND 1=2 "
                            End If
                        End If
                    End If


                End If

                '承辦人清單(查詢提報資料)
                Dim sql As New StringBuilder
                sql.AppendLine("SELECT M.*, ISNULL(STF,'') + ' - ' + ISNULL(CH_NAME,'') AS LIST , R1.CH_NAME FROM ( ")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL100 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL110 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL120 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL130 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT CONTRACTOR AS STF FROM APPL140 WHERE ISNULL(CONTRACTOR,'') <> '' AND USE_STATE=7 " & strLic2)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT CONTRACTOR AS STF FROM APPL150 WHERE ISNULL(CONTRACTOR,'') <> '' AND USE_STATE=7 " & strLic2)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL160 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL170 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL180 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine("UNION")
                sql.AppendLine("SELECT DISTINCT STF FROM APPL190 WHERE ISNULL(STF,'') <> '' AND USE_STATE=7 " & strLic)
                sql.AppendLine(") M ")
                sql.AppendLine(" LEFT JOIN POST020 R1 ON M.STF = R1.ACNT ")

                sql.AppendLine(" WHERE ISNULL(R1.CH_NAME,'')<>'' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY STF ASC, CH_NAME ASC ")
                    Else
                        sql.AppendLine(" ORDER BY STF ASC, CH_NAME ASC ")
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


#Region "2.3.5.1 已結案之承辦清單查詢 finQuery / appSQL"

#Region "2.3.5.1 已結案之承辦清單查詢 finQuery"
        ''' <summary>
        ''' 2.3.5.1 已結案之承辦清單
        ''' </summary>
        ''' <param name="num">Int 提報內容(0 表全部1~10)</param>
        ''' <returns>DataTable (LIST, APP_DATE, TITLE, SYS_SORT)</returns>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1110_FUNC_PERMISSION)</remarks>
        Public Function finQuery(ByVal num As Integer) As DataTable
            Return Me.finQuery(0, 0, num)
        End Function

        ''' <summary>
        ''' 2.3.5.1 已結案之承辦清單
        ''' </summary>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1110_FUNC_PERMISSION)</remarks>
        Public Function finQuery(ByVal pageNo As Integer, ByVal pageSize As Integer, Optional ByVal num As Integer = 0) As DataTable
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
                'Me.TableCoumnInfo.Add(New String() {"POST020", "R1", "PKNO", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "USE_STATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder

                If num <> 0 Then
                    '單一提報內容查詢
                    sql.AppendLine("SELECT LICENSE_NO, NUM_CATEGORY1_NAME, ISNULL(STF,'') + ' - ' + ISNULL(CH_NAME,'') AS LIST, M.APP_DATE, M.TITLE, M.SYS_SORT FROM ( ")
                    sql.AppendLine(appSQL(num))

                    If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                        If num = 9 Or num = 10 Then
                            '黃金門號欄位名稱不同
                            sql.AppendLine(" AND " & Replace(Me.ProcessCondition(Me.SqlRetrictions), "STF=", "CONTRACTOR="))
                        Else

                            sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))

                        End If
                    End If

                    sql.AppendLine(") M ")
                    sql.AppendLine(" LEFT JOIN POST020 R1 ON M.STF = R1.ACNT ")


                Else
                    '所有內容查詢
                    Dim flag As Boolean = False

                    sql.AppendLine("SELECT LICENSE_NO, NUM_CATEGORY1_NAME, ISNULL(STF,'') + ' - ' + ISNULL(CH_NAME,'') AS LIST, M.APP_DATE, M.TITLE, M.SYS_SORT FROM ( ")

                    For i As Integer = 1 To 10
                        If Not flag Then
                            flag = True
                        Else
                            sql.AppendLine(" UNION ALL ")
                        End If
                        sql.AppendLine(appSQL(i))

                        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                            If i = 9 Or i = 10 Then
                                '黃金門號欄位名稱不同
                                sql.AppendLine(" AND " & Replace(Me.ProcessCondition(Me.SqlRetrictions), "STF=", "CONTRACTOR="))
                            Else

                                sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))

                            End If
                        End If

                    Next

                    sql.AppendLine(") M ")
                    sql.AppendLine(" LEFT JOIN POST020 R1 ON M.STF = R1.ACNT ")

                End If


                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY LIST ASC, APP_DATE ASC, SYS_SORT ASC ")
                    Else
                        sql.AppendLine(" ORDER BY LIST ASC, APP_DATE ASC, SYS_SORT ASC ")
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


#Region "傳回2.3.5.1已結案之承辦清單查詢SQL appSQL"
        ''' <summary>
        ''' 傳回2.3.5.1已結案之承辦清單查詢SQL
        ''' </summary>
        ''' <param name="num">Int 提報選項(0表示全部1~10)</param>
        ''' <returns>SQL String(STF, APP_DATE, TITLE, SYS_SORT)</returns>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1110_FUNC_PERMISSION)</remarks>
        Function appSQL(Optional ByVal num As Integer = 0) As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim rlt As String = ""
                Select Case num
                    Case 1 '用戶號碼—轉分配資訊
                        rlt = "SELECT R1.LICENSE_NO, R2.SYS_NAME AS NUM_CATEGORY1_NAME, STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'用戶號碼—轉分配資訊' AS TITLE  ,1 AS SYS_SORT FROM APPL100 M INNER JOIN APPL020 R1 ON R1.PKNO = M.LICENSE_NO LEFT JOIN SYST010 R2 ON M.NUM_CATEGORY1 = R2.SYS_ID AND R2.SYS_KEY='號碼種類' WHERE M.USE_STATE = 7 "

                    Case 2 '用戶號碼—使用現況月報
                        rlt = "SELECT R2.LICENSE_NO, MR1.NUM_CATEGORY1_NAME,STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'用戶號碼—使用現況月報' AS TITLE  ,2 AS SYS_SORT FROM APPL130 M LEFT JOIN (  SELECT DISTINCT MA_PKNO   ,STUFF((     SELECT DISTINCT ',' + R2.SYS_NAME     FROM APPL131 IR1     INNER JOIN SYST010 R2 ON IR1.NUM_CATEGORY1 = R2.SYS_ID      AND R2.SYS_KEY = '號碼種類'     WHERE (IR1.MA_PKNO = R1.MA_PKNO)     FOR XML PATH('')     ), 1, 1, '') AS NUM_CATEGORY1_NAME  FROM APPL131 R1  GROUP BY MA_PKNO  ) AS MR1 ON MR1.MA_PKNO = M.PKNO INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 3 '用戶號碼—年度千門使用情形
                        rlt = "SELECT R2.LICENSE_NO, MR1.NUM_CATEGORY1_NAME,STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'用戶號碼—年度千門使用情形' AS TITLE  ,3 AS SYS_SORT FROM APPL160 M LEFT JOIN (  SELECT DISTINCT MA_PKNO   ,STUFF((     SELECT DISTINCT ',' + R2.SYS_NAME     FROM APPL161 IR1     INNER JOIN SYST010 R2 ON IR1.NUM_CATEGORY1 = R2.SYS_ID      AND R2.SYS_KEY = '號碼種類'     WHERE (IR1.MA_PKNO = R1.MA_PKNO)     FOR XML PATH('')     ), 1, 1, '') AS NUM_CATEGORY1_NAME  FROM APPL161 R1  GROUP BY MA_PKNO  ) AS MR1 ON MR1.MA_PKNO = M.PKNO INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7 "

                    Case 4 '用戶號碼—未來使用情形預估
                        rlt = "SELECT R2.LICENSE_NO, MR1.NUM_CATEGORY1_NAME,STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'用戶號碼—未來使用情形預估' AS TITLE  ,4 AS SYS_SORT FROM APPL170 M LEFT JOIN (  SELECT DISTINCT MA_PKNO   ,STUFF((     SELECT DISTINCT ',' + R2.SYS_NAME     FROM APPL171 IR1     INNER JOIN SYST010 R2 ON IR1.NUM_CATEGORY1 = R2.SYS_ID      AND R2.SYS_KEY = '號碼種類'     WHERE (IR1.MA_PKNO = R1.MA_PKNO)     FOR XML PATH('')     ), 1, 1, '') AS NUM_CATEGORY1_NAME  FROM APPL171 R1  GROUP BY MA_PKNO  ) AS MR1 ON MR1.MA_PKNO = M.PKNO INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 5 '電信特殊號碼—受話通數月報
                        rlt = "SELECT R2.LICENSE_NO, IIF(M.OPERATION_CODE = 204, '市話號碼', '行網號碼') AS NUM_CATEGORY1_NAME,STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'電信特殊號碼—受話通數月報' AS TITLE  ,5 AS SYS_SORT FROM APPL110 M INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 6 '電信特殊號碼—收入月報
                        rlt = "SELECT R2.LICENSE_NO, IIF(M.OPERATION_CODE = 204, '市話號碼', '行網號碼') AS NUM_CATEGORY1_NAME,STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'電信特殊號碼—收入月報' AS TITLE  ,6 AS SYS_SORT FROM APPL120 M INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 7 '識別碼—使用現況季報
                        rlt = "SELECT  R2.LICENSE_NO, 'ISPC,NSPC' AS NUM_CATEGORY1_NAME, STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'識別碼—使用現況季報' AS TITLE  ,7 AS SYS_SORT FROM APPL180 M INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 8 '識別碼—未來使用情形預估
                        rlt = "SELECT R2.LICENSE_NO,MR1.NUM_CATEGORY1_NAME, STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'識別碼—未來使用情形預估' AS TITLE  ,8 AS SYS_SORT FROM APPL190 M LEFT JOIN (SELECT MA_PKNO, STUFF(( SELECT DISTINCT ',' + ITEM FROM APPL191 WHERE (MA_PKNO = R1.MA_PKNO) FOR XML PATH('')),1,1,'') AS NUM_CATEGORY1_NAME FROM APPL191 R1 GROUP BY MA_PKNO )  AS MR1 ON MR1.MA_PKNO = M.PKNO  INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO WHERE M.USE_STATE = 7  "

                    Case 9 '黃金門號—年度釋出明細
                        rlt = "SELECT R2.LICENSE_NO,R1.SYS_NAME AS NUM_CATEGORY1_NAME, CONTRACTOR AS STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'黃金門號—年度釋出明細' AS TITLE  ,9 AS SYS_SORT FROM APPL150 M INNER JOIN SYST010 R1 ON M.CATEGORY = R1.SYS_ID AND R1.SYS_KEY = '號碼種類' INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO_PKNO WHERE M.USE_STATE = 7 "

                    Case 10 '黃金門號—選號規則
                        rlt = "SELECT R2.LICENSE_NO,R1.SYS_NAME AS NUM_CATEGORY1_NAME, CONTRACTOR AS STF  ,CONVERT(VARCHAR(10), APP_DATE, 111) AS APP_DATE  ,'黃金門號—選號規則' AS TITLE  ,10 AS SYS_SORT FROM APPL140 M INNER JOIN SYST010 R1 ON M.CATEGORY = R1.SYS_ID AND R1.SYS_KEY = '號碼種類' INNER JOIN APPL020 R2 ON R2.PKNO = M.LICENSE_NO_PKNO WHERE M.USE_STATE = 7  "

                End Select

                If Current.Session("PERSON_TYPE") = 0 Then
                    'NCC 依所設定執照範圍查詢資料
                    If Current.Session("IS_ALL") <> "Y" Then
                        If Current.Session("LICENSE_NO_DATA") <> "" Then
                            If num = 9 Or num = 10 Then
                                rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                            Else
                                rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                            End If
                        Else
                            '無任何可用執照，不傳回資料
                            rlt &= " AND 1=2 "
                        End If
                    End If

                Else

                    '業者 須限定本身資料範圍
                    If num = 9 Or num = 10 Then
                        '黃金門號欄位名稱不同
                        rlt &= " AND APP_PERSON_PKNO='" & Current.Session("DEP_CODE") & "' "
                    Else
                        rlt &= " AND APP_PERSON='" & Current.Session("DEP_CODE") & "' "
                    End If

                    Dim val As String = ""
                    '2.3.5.1 已結案清單查詢
                    val = Current.Session("RPT1110_FUNC_PERMISSION")

                    If val.IndexOf("0005") < 0 Then
                        '非管理者依所設定執照範圍查詢資料
                        If Current.Session("IS_ALL") <> "Y" Then
                            If strLicNo() <> "" Then
                                If num = 9 Or num = 10 Then
                                    rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                                Else
                                    rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                                End If
                            Else
                                '無任何可用執照，不傳回資料
                                rlt &= " AND 1=2 "
                            End If
                        End If
                    End If

                End If

                Return rlt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region


#Region "2.3.5.2 承辦數量統計 numQuery / numSQL"

#Region "2.3.5.2 承辦數量統計 numQuery"
        ''' <summary>
        ''' 2.3.5.2 承辦數量統計
        ''' </summary>
        ''' <returns>DataTable (LIST, APP_DATE, TITLE, SYS_SORT)</returns>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1120_FUNC_PERMISSION)</remarks>
        Public Function numQuery() As DataTable
            Return Me.numQuery(0, 0)
        End Function

        ''' <summary>
        ''' 2.3.5.2 承辦數量統計
        ''' </summary>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1120_FUNC_PERMISSION)</remarks>
        Public Function numQuery(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.TableCoumnInfo.Add(New String() {"POST020", "R1", "PKNO", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "USE_STATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder

                'If num <> 0 Then
                '    '單一提報內容查詢
                '    sql.AppendLine("SELECT ISNULL(CH_NAME,'') AS LIST, RECORRECT_NUM, M.TITLE, M.SYS_SORT FROM ( ")
                '    sql.AppendLine(numSQL(num))

                '    If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '        If num = 9 Or num = 10 Then
                '            '黃金門號欄位名稱不同
                '            sql.AppendLine(" AND " & Replace(Me.ProcessCondition(Me.SqlRetrictions), "STF=", "CONTRACTOR="))
                '        Else

                '            sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))

                '        End If
                '    End If

                '    sql.AppendLine(") M ")
                '    sql.AppendLine(" LEFT JOIN POST020 R1 ON M.STF = R1.ACNT ")


                'Else
                '所有內容查詢
                Dim flag As Boolean = False

                sql.AppendLine("SELECT ISNULL(CH_NAME,'') AS LIST, SUM(M.NUM) as NUM, M.TITLE, M.SYS_SORT, M.GP FROM ( ")

                '已審查
                For i As Integer = 1 To 10
                    If Not flag Then
                        flag = True
                    Else
                        sql.AppendLine(" UNION ALL ")
                    End If
                    sql.AppendLine(numSQL(i))

                    If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                        If i = 9 Or i = 10 Then
                            '黃金門號欄位名稱不同
                            sql.AppendLine(" AND " & Replace(Me.ProcessCondition(Me.SqlRetrictions), "STF=", "CONTRACTOR="))
                        Else

                            sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))

                        End If
                    End If

                Next

                '曾補正
                For i As Integer = 1 To 10
                    If Not flag Then
                        flag = True
                    Else
                        sql.AppendLine(" UNION ALL ")
                    End If
                    sql.AppendLine(recSQL(i))

                    If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                        If i = 9 Or i = 10 Then
                            '黃金門號欄位名稱不同
                            sql.AppendLine(" AND " & Replace(Me.ProcessCondition(Me.SqlRetrictions), "STF=", "CONTRACTOR="))
                        Else

                            sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions))

                        End If
                    End If

                Next
                sql.AppendLine(") M ")
                sql.AppendLine(" LEFT JOIN POST020 R1 ON M.STF = R1.ACNT WHERE ISNULL(CH_NAME,'')<> '' ")

                'End If

                sql.AppendLine(" GROUP BY GP, SYS_SORT, TITLE, CH_NAME ")

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY GP, SYS_SORT, TITLE ,CH_NAME ")
                    Else
                        sql.AppendLine(" ORDER BY GP, SYS_SORT, TITLE ,CH_NAME ")
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


#Region "傳回2.3.5.2 承辦數量統計查詢SQL numSQL / recSQL"
        
        ''' <summary>
        ''' 傳回2.3.5.2 承辦數量統計查詢SQL
        ''' </summary>
        ''' <param name="num">Int 提報選項(0表示全部1~10)</param>
        ''' <returns>SQL String(STF, APP_DATE, TITLE, SYS_SORT)</returns>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1120_FUNC_PERMISSION)</remarks>
        Function numSQL(Optional ByVal num As Integer = 0) As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim rlt As String = ""
                Dim WTR As String = "案件狀態: 已審查"
                Select Case num
                    Case 1
                        rlt = "SELECT STF, 1 as NUM, '用戶號碼—轉分配資訊' AS TITLE, 1 AS SYS_SORT, '" & WTR & "' as GP  FROM APPL100 WHERE USE_STATE=7 "

                    Case 2
                        rlt = "SELECT STF, 1 as NUM, '用戶號碼—使用現況月報' AS TITLE, 2 AS SYS_SORT, '" & WTR & "' as GP FROM APPL130 WHERE USE_STATE=7   "

                    Case 3
                        rlt = "SELECT STF, 1 as NUM, '用戶號碼—年度千門使用情形' AS TITLE, 3 AS SYS_SORT, '" & WTR & "' as GP FROM APPL160 WHERE USE_STATE=7   "

                    Case 4
                        rlt = "SELECT STF, 1 as NUM, '用戶號碼—未來使用情形預估' AS TITLE, 4 AS SYS_SORT, '" & WTR & "' as GP FROM APPL170 WHERE USE_STATE=7   "

                    Case 5
                        rlt = "SELECT STF, 1 as NUM, '電信特殊號碼—受話通數月報' AS TITLE, 5 AS SYS_SORT, '" & WTR & "' as GP FROM APPL110 WHERE USE_STATE=7   "

                    Case 6
                        rlt = "SELECT STF, 1 as NUM, '電信特殊號碼—收入月報' AS TITLE, 6 AS SYS_SORT, '" & WTR & "' as GP FROM APPL120 WHERE USE_STATE=7   "

                    Case 7
                        rlt = "SELECT STF, 1 as NUM, '識別碼—使用現況季報' AS TITLE, 7 AS SYS_SORT, '" & WTR & "' as GP FROM APPL180 WHERE USE_STATE=7   "

                    Case 8
                        rlt = "SELECT STF, 1 as NUM, '識別碼—未來使用情形預估' AS TITLE, 8 AS SYS_SORT, '" & WTR & "' as GP FROM APPL190 WHERE USE_STATE=7   "

                    Case 9
                        rlt = "SELECT CONTRACTOR AS STF, 1 as NUM, '黃金門號—年度釋出明細' AS TITLE, 9 AS SYS_SORT, '" & WTR & "' as GP FROM APPL150 WHERE USE_STATE=7  "

                    Case 10
                        rlt = "SELECT CONTRACTOR AS STF, 1 as NUM, '黃金門號—選號規則' AS TITLE, 10 AS SYS_SORT, '" & WTR & "' as GP FROM APPL140 WHERE USE_STATE=7   "

                End Select

                If Current.Session("PERSON_TYPE") = 0 Then
                    'NCC 依所設定執照範圍查詢資料
                    If Current.Session("IS_ALL") <> "Y" Then
                        If Current.Session("LICENSE_NO_DATA") <> "" Then
                            If num = 9 Or num = 10 Then
                                rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                            Else
                                rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                            End If
                        Else
                            '無任何可用執照，不傳回資料
                            rlt &= " AND 1=2 "
                        End If
                    End If

                Else

                    '業者 須限定本身資料範圍
                    If num = 9 Or num = 10 Then
                        '黃金門號欄位名稱不同
                        rlt &= " AND APP_PERSON_PKNO='" & Current.Session("DEP_CODE") & "' "
                    Else
                        rlt &= " AND APP_PERSON='" & Current.Session("DEP_CODE") & "' "
                    End If

                    Dim val As String = ""
                    '2.3.5.2 承辦數量統計查詢SQL
                    val = Current.Session("RPT1120_FUNC_PERMISSION")

                    If val.IndexOf("0005") < 0 Then
                        '非管理者依所設定執照範圍查詢資料
                        If Current.Session("IS_ALL") <> "Y" Then
                            If strLicNo() <> "" Then
                                If num = 9 Or num = 10 Then
                                    rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                                Else
                                    rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                                End If
                            Else
                                '無任何可用執照，不傳回資料
                                rlt &= " AND 1=2 "
                            End If
                        End If
                    End If

                End If

                Return rlt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 傳回2.3.5.2 承辦數量統計查詢SQL
        ''' </summary>
        ''' <param name="num">Int 提報選項(0表示全部1~10)</param>
        ''' <returns>SQL String(STF, APP_DATE, TITLE, SYS_SORT)</returns>
        ''' <remarks>其中已包函Session身份與權限判斷(PERSON_TYPE, IS_ALL, LICENSE_NO_DATA, DEP_CODE, RPT1120_FUNC_PERMISSION)</remarks>
        Function recSQL(Optional ByVal num As Integer = 0) As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim rlt As String = ""
                Dim WTR As String = "案件狀態: 曾補正"
                Select Case num
                    Case 1
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '用戶號碼—轉分配資訊' AS TITLE, 1 AS SYS_SORT, '" & WTR & "' as GP FROM APPL100 WHERE USE_STATE<>1 "

                    Case 2
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '用戶號碼—使用現況月報' AS TITLE, 2 AS SYS_SORT, '" & WTR & "' as GP FROM APPL130 WHERE USE_STATE<>1 "

                    Case 3
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '用戶號碼—年度千門使用情形' AS TITLE, 3 AS SYS_SORT, '" & WTR & "' as GP FROM APPL160 WHERE USE_STATE<>1 "

                    Case 4
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '用戶號碼—未來使用情形預估' AS TITLE, 4 AS SYS_SORT, '" & WTR & "' as GP FROM APPL170 WHERE USE_STATE<>1 "

                    Case 5
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '電信特殊號碼—受話通數月報' AS TITLE, 5 AS SYS_SORT, '" & WTR & "' as GP FROM APPL110 WHERE USE_STATE<>1 "

                    Case 6
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '電信特殊號碼—收入月報' AS TITLE, 6 AS SYS_SORT, '" & WTR & "' as GP FROM APPL120 WHERE USE_STATE<>1 "

                    Case 7
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '識別碼—使用現況季報' AS TITLE, 7 AS SYS_SORT, '" & WTR & "' as GP FROM APPL180 WHERE USE_STATE<>1 "

                    Case 8
                        rlt = "SELECT STF, ISNULL(RECORRECT_NUM,0) as NUM, '識別碼—未來使用情形預估' AS TITLE, 8 AS SYS_SORT, '" & WTR & "' as GP FROM APPL190 WHERE USE_STATE<>1 "

                    Case 9
                        rlt = "SELECT CONTRACTOR AS STF, ISNULL(RECORRECT_NUM,0) as NUM, '黃金門號—年度釋出明細' AS TITLE, 9 AS SYS_SORT, '" & WTR & "' as GP FROM APPL150 WHERE USE_STATE<>1 "

                    Case 10
                        rlt = "SELECT CONTRACTOR AS STF, ISNULL(RECORRECT_NUM,0) as NUM, '黃金門號—選號規則' AS TITLE, 10 AS SYS_SORT, '" & WTR & "' as GP FROM APPL140 WHERE USE_STATE<>1 "

                End Select

                If Current.Session("PERSON_TYPE") = 0 Then
                    'NCC 依所設定執照範圍查詢資料
                    If Current.Session("IS_ALL") <> "Y" Then
                        If Current.Session("LICENSE_NO_DATA") <> "" Then
                            If num = 9 Or num = 10 Then
                                rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                            Else
                                rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                            End If
                        Else
                            '無任何可用執照，不傳回資料
                            rlt &= " AND 1=2 "
                        End If
                    End If

                Else

                    '業者 須限定本身資料範圍
                    If num = 9 Or num = 10 Then
                        '黃金門號欄位名稱不同
                        rlt &= " AND APP_PERSON_PKNO='" & Current.Session("DEP_CODE") & "' "
                    Else
                        rlt &= " AND APP_PERSON='" & Current.Session("DEP_CODE") & "' "
                    End If

                    Dim val As String = ""
                    '2.3.5.2 承辦數量統計
                    val = Current.Session("RPT1120_FUNC_PERMISSION")

                    If val.IndexOf("0005") < 0 Then
                        '非管理者依所設定執照範圍查詢資料
                        If Current.Session("IS_ALL") <> "Y" Then
                            If strLicNo() <> "" Then
                                If num = 9 Or num = 10 Then
                                    rlt &= " AND LICENSE_NO_PKNO IN (" & strLicNo() & ") "
                                Else
                                    rlt &= " AND LICENSE_NO IN (" & strLicNo() & ") "
                                End If
                            Else
                                '無任何可用執照，不傳回資料
                                rlt &= " AND 1=2 "
                            End If
                        End If
                    End If

                End If

                Return rlt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region


#Region "傳回執照代號Session(LICENSE_NO_DATA)字串 for SQL strLicNo"
        ''' <summary>
        ''' 傳回執照代號Session("LICENSE_NO_DATA")字串 for SQL
        ''' </summary>
        ''' <returns>String 執照代號字串</returns>
        ''' <remarks></remarks>
        Public Function strLicNo() As String
            Dim rlt As String = Current.Session("LICENSE_NO_DATA")
            If rlt <> "" Then
                If Right(rlt, 1) = "," Then
                    rlt = Left(rlt, Len(rlt) - 1)
                End If

                If Left(rlt, 1) = "," Then
                    rlt = Right(rlt, Len(rlt) - 1)
                End If

                rlt = "'" & Replace(rlt, ",", "','") & "'"

                If rlt = "''" Then
                    rlt = ""
                End If
            End If

            Return rlt
        End Function
#End Region


#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

