'----------------------------------------------------------------------------------
'File Name		: EntQuestionaryAnswer
'Author			:  
'Description		: EntQuestionaryAnswer 問卷結果ENT
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
    '' EntQuestionaryAnswer 問卷結果ENT
    '' </summary>
    Public Class EntQuestionaryAnswer
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
            Me.TableName = "QUET060"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntQuestionaryAnswerAmount = New EntQuestionaryAnswerAmount(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "EntQuestionaryAnswerAmount 問卷答案結果ENT[]"
        ''' <summary>
        ''' EntQuestionaryAnswerAmount 問卷答案結果ENT[]
        ''' </summary>
        Public Property EntQuestionaryAnswerAmount() As EntQuestionaryAnswerAmount
            Get
                Return Me.PropertyMap("EntQuestionaryAnswerAmount")
            End Get
            Set(ByVal value As EntQuestionaryAnswerAmount)
                Me.PropertyMap("EntQuestionaryAnswerAmount") = value
            End Set
        End Property
#End Region

#Region "NAME 姓名"
        ''' <summary>
        ''' NAME 姓名
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.ColumnyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NAME") = value
            End Set
        End Property
#End Region

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

#Region "QSTNNR_TARGET_NO 問卷對象號碼"
        ''' <summary>
        ''' QSTNNR_TARGET_NO 問卷對象號碼
        ''' </summary>
        Public Property QSTNNR_TARGET_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_TARGET_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_TARGET_NO") = value
            End Set
        End Property
#End Region

#Region "SEX 性別"
        ''' <summary>
        ''' SEX 性別
        ''' </summary>
        Public Property SEX() As String
            Get
                Return Me.ColumnyMap("SEX")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEX") = value
            End Set
        End Property
#End Region

#Region "EMAIL EMAIL"
        ''' <summary>
        ''' EMAIL EMAIL
        ''' </summary>
        Public Property EMAIL() As String
            Get
                Return Me.ColumnyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "CRRS_COMPANY_TEL 通訊公司電話"
        ''' <summary>
        ''' CRRS_COMPANY_TEL 通訊公司電話
        ''' </summary>
        Public Property CRRS_COMPANY_TEL() As String
            Get
                Return Me.ColumnyMap("CRRS_COMPANY_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CRRS_COMPANY_TEL") = value
            End Set
        End Property
#End Region

#Region "UNIT_NO 單位號碼"
        ''' <summary>
        ''' UNIT_NO 單位號碼
        ''' </summary>
        Public Property UNIT_NO() As String
            Get
                Return Me.ColumnyMap("UNIT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNIT_NO") = value
            End Set
        End Property
#End Region

#Region "DEP_NAME 單位名稱"
        ''' <summary>
        ''' DEP_NAME 單位名稱
        ''' </summary>
        Public Property DEP_NAME() As String
            Get
                Return Me.ColumnyMap("DEP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEP_NAME") = value
            End Set
        End Property
#End Region

#Region "ID_TYPE 身分類別"
        ''' <summary>
        ''' ID_TYPE 身分類別
        ''' </summary>
        Public Property ID_TYPE() As String
            Get
                Return Me.ColumnyMap("ID_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ID_TYPE") = value
            End Set
        End Property
#End Region

#Region "STATUS 狀態"
        ''' <summary>
        ''' STATUS 狀態
        ''' </summary>
        Public Property STATUS() As String
            Get
                Return Me.ColumnyMap("STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STATUS") = value
            End Set
        End Property
#End Region

#Region "IS_ANNOUNCE_OUTER 是否發佈校外"
        ''' <summary>
        ''' IS_ANNOUNCE_OUTER 是否發佈校外
        ''' </summary>
        Public Property IS_ANNOUNCE_OUTER() As String
            Get
                Return Me.ColumnyMap("IS_ANNOUNCE_OUTER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_ANNOUNCE_OUTER") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號"
        ''' <summary>
        ''' CASE_NO 案件編號
        ''' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "PAY_TYPE 案件類別"
        ''' <summary>
        ''' PAY_TYPE 案件類別
        ''' </summary>
        Public Property PAY_TYPE() As String
            Get
                Return Me.ColumnyMap("PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "TEXT_CONTENT 文字內容"
        ''' <summary>
        ''' TEXT_CONTENT 文字內容
        ''' </summary>
        Public Property TEXT_CONTENT() As String
            Get
                Return Me.ColumnyMap("TEXT_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TEXT_CONTENT") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "AddQuestionaryAnswerAmount 新增問卷答案結果 "
        ''' <summary>
        ''' 新增問卷答案結果 
        ''' </summary>
        Public Function AddQuestionaryAnswerAmount() As DataTable
            Return Me.AddQuestionaryAnswerAmount(0, 0)
        End Function

        ''' <summary>
        ''' 新增問卷答案結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function AddQuestionaryAnswerAmount(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 姓名 ===
                If String.IsNullOrEmpty(Me.NAME) Then
                    faileArguments.Add("NAME")
                End If
                '=== 性別 ===
                If String.IsNullOrEmpty(Me.SEX) Then
                    faileArguments.Add("SEX")
                End If
                '=== 問卷對象號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_TARGET_NO) Then
                    faileArguments.Add("QSTNNR_TARGET_NO")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntQuestionaryAnswer = New EntQuestionaryAnswer
                '
                'EntQuestionaryAnswer.Insert()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryHeadingItem 查詢問卷題目選項 "
        ''' <summary>
        ''' 查詢問卷題目選項 
        ''' </summary>
        Public Function QueryHeadingItem() As DataTable
            Return Me.QueryHeadingItem(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷題目選項 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryHeadingItem(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該張問卷的全部問題跟問題選項
                '
                '使用table
                '問卷主檔 QUET010
                '問卷題目 QUET040
                'QSTNNR_ITEM(問卷選項) QUET050
                '
                'table 關係
                'QUET010  跟 QUET040 跟問卷號碼,問卷題目  關聯
                'QUET040  跟 QUET050 跟問卷號碼,問卷題目,MENU_NO(選單號碼) 關聯

                Dim sql As String = "select a.QSTNNR_NO,b.SUBJECT_NO,b.SUBJECT_CONTENT,c.MENU_NO,c.MENU_CONTENT , c.MENU_TROVMGP " & _
                                   " from " & _
                                   "     QUET010   a left join QUET040 b " & _
                                  "          on a.QSTNNR_NO=b.QSTNNR_NO " & _
                                  "  left join QUET050 c " & _
                                  "    on c.QSTNNR_NO=b.QSTNNR_NO and c.SUBJECT_NO=b.SUBJECT_NO where " & Me.SqlRetrictions & _
                                " order by a.QSTNNR_NO,b.SUBJECT_NO,c.MENU_NO"

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryAnswerCount 問卷結果人數 "
        ''' <summary>
        ''' 問卷結果人數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryAnswerCount() As Integer
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
                Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該張問卷的問題對象人數
                '
                '使用table
                'QSTNNR_TARGET(問卷對象) QUET020

                Dim sql As String = "SELECT 1 FROM QUET070 WHERE " & Me.SqlRetrictions
                Dim returnValue As Integer = 0


                Dim dt As DataTable = Me.QueryBySql(sql)
                If dt.Rows.Count > 0 Then
                    returnValue = dt.Rows.Count
                End If

                Me.ResetColumnProperty()

                Return returnValue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryConditional 查詢填寫情形表 "
        ''' <summary>
        ''' 查詢填寫情形表 
        ''' </summary>
        Public Function QueryQuestionaryConditional() As DataTable
            Return Me.QueryQuestionaryConditional(0, 0)
        End Function

        ''' <summary>
        ''' 查詢填寫情形表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryConditional(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該張問卷的需要填寫人的填寫狀況
                '
                '使用table
                '問卷結果 QUET060
                'QSTNNR_ANSWER_RES(問卷答案結果) QUET070
                '
                'table 關係
                'QUET060  跟 QUET070 跟問卷號碼,QSTNNR_TARGET_NO(問卷對象號碼)=STAFF_NO(員工編號) 關聯
                '
                'IS_WRITE(是否填寫)=QUET070.員工編號有資料顯示是否則 顯示 否

                'Dim sql As String = "select DISTINCT  A.SEX,a.QSTNNR_NO,DEP_NAME,a.QSTNNR_TARGET_NO,NAME,case when b.QSTNNR_TARGET_NO is null then '否' else '是' end IS_WRITE " & _
                '                    " from QUET060 a left outer join QUET070 b " & _
                '                    " on a.QSTNNR_NO=b.QSTNNR_NO and a.QSTNNR_TARGET_NO=b.QSTNNR_TARGET_NO " & _
                '                    " where " & Me.SqlRetrictions


                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT DISTINCT")
                SQL.AppendLine("       M.DEP_NAME,")
                SQL.AppendLine("       M.QSTNNR_TARGET_NO,")
                SQL.AppendLine("       M.NAME,")
                SQL.AppendLine("       M.QSTNNR_NO,")
                SQL.AppendLine("       (CASE WHEN R4.QSTNNR_TARGET_NO IS NULL THEN 'N' ELSE 'Y' END)")
                SQL.AppendLine("          AS IS_WRITE")
                SQL.AppendLine("  FROM QUET020 M")
                SQL.AppendLine("       LEFT JOIN POST020 R1 ON M.QSTNNR_TARGET_NO = R1.ACNT")
                SQL.AppendLine("       LEFT JOIN (SELECT DISTINCT R3.QSTNNR_NO, R3.QSTNNR_TARGET_NO")
                SQL.AppendLine("                    FROM QUET060 R3) R4")
                SQL.AppendLine("          ON     M.QSTNNR_NO = R4.QSTNNR_NO")
                SQL.AppendLine("             AND M.QSTNNR_TARGET_NO = R4.QSTNNR_TARGET_NO")
                SQL.AppendLine(" WHERE 1 = 1  ")

                If Me.SqlRetrictions <> "" Then
                    SQL.Append(Me.SqlRetrictions.Replace("$.", "M."))
                End If

                If pageNo = 0 Then
                    SQL.Append(" ORDER BY M.DEP_NAME,M.QSTNNR_TARGET_NO ")
                Else
                    SQL.Append(" ORDER BY DEP_NAME,QSTNNR_TARGET_NO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(SQL.ToString(), pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryObj 查詢問卷對象資料 "
        ''' <summary>
        ''' 查詢問卷對象資料 
        ''' </summary>
        Public Function QueryQuestionaryObj() As DataTable
            Return Me.QueryQuestionaryObj(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷對象資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryObj(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理說明 ===
                'from QUET010
                'left join QUET020 on QSTNNR_NO(問卷號碼)

                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.QSTNNR_NO, M.QSTNNR_TITLE, M.CREATE_UNIT_NAME, M.UPDRAFT_DATE, M.DODRAFT_DATE,M.IS_REPEAT,M.START_DATE,M.DEADLINE_DATE ")
                sql.Append("FROM QUET010 M ")

                '判斷是否內外網
                If String.IsNullOrEmpty(Me.IS_ANNOUNCE_OUTER) Then
                    sql.Append("LEFT JOIN QUET020 R1  ON M.QSTNNR_NO = R1.QSTNNR_NO ")
                End If

                sql.Append("WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("$.", "M.")
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("M.QSTNNR_TARGET_NO", "R1.QSTNNR_TARGET_NO")
                    sql.Append(Me.SqlRetrictions)
                End If
                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.QSTNNR_NO ")
                Else
                    sql.Append(" ORDER BY QSTNNR_NO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryObjCount 查詢問卷對象人數 "

        ''' <summary>
        ''' 查詢問卷對象人數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryObjCount() As Integer
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
                Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該張問卷的填答人數
                '
                '使用table
                'QSTNNR_ANSWER_RES(問卷答案結果) QUET070

                Dim sql As String = "SELECT 1 FROM QUET020 WHERE " & Me.SqlRetrictions
                Dim returnValue As Integer = 0


                Dim dt As DataTable = Me.QueryBySql(sql)
                If dt.Rows.Count > 0 Then
                    returnValue = dt.Rows.Count
                End If

                Me.ResetColumnProperty()

                Return returnValue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryRecord 查詢填答記錄表 "
        ''' <summary>
        ''' 查詢填答記錄表 
        ''' </summary>
        Public Function QueryQuestionaryRecord() As DataTable
            Return Me.QueryQuestionaryRecord(0, 0)
        End Function

        ''' <summary>
        ''' 查詢填答記錄表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryRecord(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該張問卷的填答人記錄資料
                '
                '使用table
                '問卷題目  QUET040
                '問卷題目選項 QUET050
                '問卷結果 QUET060
                'QSTNNR_ANSWER_RES(問卷答案結果) QUET070
                '
                'table 關係
                'QUET060  跟 QUET070 跟問卷號碼,QSTNNR_TARGET_NO(問卷對象號碼)=STAFF_NO(員工編號) 關聯
                'QUET040  跟 QUET050 跟問卷號碼 ,題目號碼關聯
                'QUET050  跟 QUET070 跟問卷號碼 ,SUBJECT_NO(題目號碼),選項號碼 關聯
                '
                '編號=table流水號1開始
                '答案=MENU_TITLE(選單標號)+ MENU_CONTENT(選單內容)
                '題目=SUBJECT_TITLE(題目標號)+SUBJECT_CONTENT(題目內容)
                'SEX(性別)=1顯示男 2顯示女

                Dim sql As String = "SELECT DISTINCT " & _
                 " A.QSTNNR_NO,DEP_NAME,B.QSTNNR_TARGET_NO,A.NAME,A.SEX,D.SUBJECT_CONTENT,C.MENU_CONTENT,B.TEXT_CONTENT " & _
                " FROM QUET060 A " & _
                " LEFT JOIN QUET070 B ON B.QSTNNR_NO=A.QSTNNR_NO AND B.QSTNNR_TARGET_NO=A.QSTNNR_TARGET_NO " & _
                " LEFT JOIN QUET050 C ON C.QSTNNR_NO=B.QSTNNR_NO AND C.SUBJECT_NO=B.SUBJECT_NO AND C.MENU_NO=B.MENU_NO " & _
                " LEFT JOIN QUET040 D ON D.QSTNNR_NO=C.QSTNNR_NO AND D.SUBJECT_NO=C.SUBJECT_NO  " & _
                " WHERE " & Me.SqlRetrictions
                If pageNo = 0 Then
                    sql &= " ORDER BY A.QSTNNR_NO"
                Else
                    sql &= " ORDER BY QSTNNR_NO"
                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryStatistics 查詢問卷題目填答統計表 "
        ''' <summary>
        ''' 查詢問卷題目填答統計表 
        ''' </summary>
        Public Function QueryQuestionaryStatistics() As DataTable
            Return Me.QueryQuestionaryStatistics(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷題目填答統計表 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryStatistics(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.ParserAlias()

                '=== 處理說明 ===
                '顯示該問卷的每個題目的各個選項有幾人回答
                '
                '使用table  
                '問卷主檔 QUET010  
                '問卷題目 QUET040
                '問卷題目選項 QUET050
                'QSTNNR_ANSWER_RES(問卷答案結果) QUET070
                '
                'table 關係
                'QUET010  跟 QUET040 跟問卷號碼關聯
                'QUET050 跟QUET040 用問卷號碼,SUBJECT_NO(題目號碼) 關聯
                'QUET050 跟QUET070 用問卷號碼 , SUBJECT_NO(題目號碼) , 選項號碼 關聯
                '
                '
                '答案=MENU_CONTENT(選單內容)
                '填答數量=各個選項的填寫人筆數

                Dim sql As String = "SELECT DISTINCT A.QSTNNR_NO,B.SUBJECT_NO,C.MENU_NO,B.SUBJECT_CONTENT,C.MENU_CONTENT,COUNT(D.QSTNNR_NO) AS COUNTER FROM " & _
                " QUET010 A " & _
                " LEFT JOIN QUET040 B ON A.QSTNNR_NO=B.QSTNNR_NO " & _
                " LEFT JOIN QUET050 C ON B.QSTNNR_NO=C.QSTNNR_NO AND B.SUBJECT_NO=C.SUBJECT_NO " & _
                " LEFT JOIN QUET070 D ON C.QSTNNR_NO=D.QSTNNR_NO AND C.SUBJECT_NO=D.SUBJECT_NO AND C.MENU_NO=D.MENU_NO " & _
                " WHERE " & Me.SqlRetrictions & " " & _
                " GROUP BY A.QSTNNR_NO,B.SUBJECT_NO,C.MENU_NO,B.SUBJECT_CONTENT,C.MENU_CONTENT "
                If pageNo = 0 Then
                    sql &= " ORDER BY A.QSTNNR_NO,B.SUBJECT_NO,C.MENU_NO"
                Else
                    sql &= " ORDER BY QSTNNR_NO,SUBJECT_NO,MENU_NO"
                End If


                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryWirteHeadingPeople 查詢填寫題目的人數 "
        ''' <summary>
        ''' 查詢填寫題目的人數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryWirteHeadingPeople() As Integer
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
                '顯示該張問卷的單一題目的總人數
                '
                '使用table
                '問卷主檔 QUET010
                '問卷題目 QUET040
                '
                'table 關係
                'QUET010  跟 QUET040 跟問卷號碼,問卷題目  關聯
                '
                'if 總人數= "" or null = 0

                Dim sql As String = "select count(QSTNNR_TARGET_NO) as counter " & _
                " from " & _
                " quet070 a " & _
                " where 1=1 " & Me.SqlRetrictions


                Dim dt As DataTable = Me.QueryBySql(sql)

                Dim returnvalue As Integer = 0

                If dt.Rows.Count > 0 Then
                    returnvalue = CType(dt.Rows(0)("counter").ToString(), Integer)
                End If

                Me.ResetColumnProperty()
                Return returnvalue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryWirteItem 查詢填寫題目選項的人數 "


        ''' <summary>
        ''' 查詢填寫題目選項的人數 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryWirteItem() As Integer
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
                '顯示該張問卷的單一題目的總人數
                '
                '使用table
                '問卷主檔 QUET010
                '問卷題目 QUET040
                '
                'table 關係
                'QUET010  跟 QUET040 跟問卷號碼,問卷題目  關聯
                '
                'if 總人數= "" or null = 0

                Dim sql As String = "select COUNT(QSTNNR_NO) as counter " & _
                " from " & _
                " QUET070   " & _
                " where 1=1 " & Me.SqlRetrictions


                Dim dt As DataTable = Me.QueryBySql(sql)

                Dim returnvalue As Integer = 0

                If dt.Rows.Count > 0 Then
                    returnvalue = CType(dt.Rows(0)("counter").ToString(), Integer)
                End If

                Me.ResetColumnProperty()
                Return returnvalue
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryNotWriteObjSQL 查詢未填答對象結構 "
        ''' <summary>
        ''' 查詢未填答對象結構 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryNotWriteObjSQL() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理說明 ===
                '使用table-QUET020,QUET060(以QUET020為主)
                'table join -以問卷號碼當JOIN KEY
                '
                '判斷QUET060.問卷對象號碼是空的 ,就表示沒有填

                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.QSTNNR_TARGET_NO,")
                sql.Append("CASE WHEN R2.STNO IS NULL THEN R3.CH_NAME ELSE R2.CH_NAME END AS CH_NAME,")

                Select Case Me.STATUS
                    Case "1" '校內
                        sql.Append("CASE WHEN R2.STNO IS NULL THEN R3.EMAIL ELSE R2.INNER_EMAIL END AS EMAIL ")

                    Case "2" '校外
                        sql.Append("CASE WHEN R2.STNO IS NULL THEN R3.EMAIL1 ELSE CAST(R2.OUTER_EMAIL AS NVARCHAR2 (255)) END AS EMAIL ")

                End Select

                sql.Append("FROM QUET020 M ")
                sql.Append("LEFT JOIN QUET060 R1 ON M.QSTNNR_NO=R1.QSTNNR_NO AND M.QSTNNR_TARGET_NO=R1.QSTNNR_TARGET_NO ")
                sql.Append("LEFT JOIN ENRT010 R2 ON M.QSTNNR_TARGET_NO = R2.STNO ")
                sql.Append("LEFT JOIN POST020 R3 ON M.QSTNNR_TARGET_NO=R3.ACNT ")
                sql.Append("WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(Me.SqlRetrictions.Replace("$.", "M."))
                End If

                sql.Append(" AND R1.QSTNNR_NO IS NULL ")

                Me.ResetColumnProperty()

                Return sql.ToString
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryAnswerAmount 查詢問卷答案結果 "
        ''' <summary>
        ''' 查詢問卷答案結果 
        ''' </summary>
        Public Function QueryQuestionaryAnswerAmount() As DataTable
            Return Me.QueryQuestionaryAnswerAmount(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷答案結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryAnswerAmount(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                ' Me.ParserAlias()

                '=== 處理說明 ===
                'AEntQuestionaryAnswerAmount = new EntQuestionaryAnswerAmount()
                '
                '組合查詢字串(
                'AEntQuestionaryAnswerAmount.QUERY_COND(查詢條件),"=",QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),MENU_NO(選單號碼))
                '
                'AEntQuestionaryAnswerAmount.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                Dim result As DataTable = New DataTable
                If String.IsNullOrEmpty(Me.SqlRetrictions.ToString) Then
                    Dim condition As StringBuilder = New StringBuilder()

                    condition.Length = 0
                    Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO) '問卷號碼
                    Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO ", Me.QSTNNR_TARGET_NO) '問卷號碼

                    EntQuestionaryAnswerAmount.SqlRetrictions = condition.ToString.Replace("$.", " ")

                Else
                    EntQuestionaryAnswerAmount.SqlRetrictions = Me.SqlRetrictions.Replace("$.", " ")

                End If
                result = EntQuestionaryAnswerAmount.Query(pageNo, pageSize)
                'AEntQuestionaryAnswerAmount.Query()
                '<process>
                '
                '</output>
                'Datatable
                '</output>



                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteQuestionaryAnswerAmount 刪除問卷答案結果 "
        ''' <summary>
        ''' 刪除問卷答案結果 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 政諺2011/05/03 新增方法
        ''' </remarks>
        Public Sub DeleteQuestionaryAnswerAmount()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷對象號碼 ===
                'If String.IsNullOrEmpty(Me.QSTNNR_TARGET_NO) Then
                '    faileArguments.Add("QSTNNR_TARGET_NO")
                'End If
                '=== 問卷號碼 ===
                'If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                '    faileArguments.Add("QSTNNR_NO")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                '=== 處理別名轉換 ===
                Me.ParserAlias()
                '=== 處理說明 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_TARGET_NO", QSTNNR_TARGET_NO)
                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", QSTNNR_NO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "ID_TYPE", ID_TYPE)
                Dim AEntQuestionaryAnswerAmount As New EntQuestionaryAnswerAmount(Me.DBManager, Me.LogUtil)
                AEntQuestionaryAnswerAmount.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                AEntQuestionaryAnswerAmount.Delete()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region
#End Region

    End Class
End Namespace


