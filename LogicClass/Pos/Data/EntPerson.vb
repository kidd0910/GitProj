'----------------------------------------------------------------------------------
'File Name		: EntPerson
'Author			: 
'Description		: EntPerson 人員主檔ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/08/27			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext

Namespace Pos.Data
    '' <summary>
    '' EntPerson 人員主檔ENT
    '' </summary>
    Public Class EntPerson
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
            Me.TableName = "POST020"
            Me.SysName = "POS"
            Me.ConnName = "TSBA"

            Me.SET_NULL_FIELD = "DEADLINE_SDATE,DEADLINE_EDATE,APPR_ENABLE_TIME"
            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 中文姓名"
        ''' <summary>
        ''' CH_NAME 中文姓名
        ''' </summary>
        Public Property CH_NAME As String
            Get
                Return Me.ColumnyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        ''' <summary>
        ''' CONTACT_TEL 聯絡電話
        ''' </summary>
        Public Property CONTACT_TEL As String
            Get
                Return Me.ColumnyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_EDATE 期限訖日"
        ''' <summary>
        ''' DEADLINE_EDATE 期限訖日
        ''' </summary>
        Public Property DEADLINE_EDATE As String
            Get
                Return Me.ColumnyMap("DEADLINE_EDATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE_EDATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_SDATE 期限起日"
        ''' <summary>
        ''' DEADLINE_SDATE 期限起日
        ''' </summary>
        Public Property DEADLINE_SDATE As String
            Get
                Return Me.ColumnyMap("DEADLINE_SDATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE_SDATE") = value
            End Set
        End Property
#End Region

#Region "DEFAULT_NUM 預設筆數"
        ''' <summary>
        ''' DEFAULT_NUM 預設筆數
        ''' </summary>
        Public Property DEFAULT_NUM As String
            Get
                Return Me.ColumnyMap("DEFAULT_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEFAULT_NUM") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 單位代碼"
        ''' <summary>
        ''' DEP_CODE 單位代碼
        ''' </summary>
        Public Property DEP_CODE As String
            Get
                Return Me.ColumnyMap("DEP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEP_CODE") = value
            End Set
        End Property
#End Region

#Region "EMAIL 電子信箱"
        ''' <summary>
        ''' EMAIL 電子信箱
        ''' </summary>
        Public Property EMAIL As String
            Get
                Return Me.ColumnyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "FONT_SIZE 字型大小"
        ''' <summary>
        ''' FONT_SIZE 字型大小
        ''' </summary>
        Public Property FONT_SIZE As String
            Get
                Return Me.ColumnyMap("FONT_SIZE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FONT_SIZE") = value
            End Set
        End Property
#End Region

#Region "MENU_STYLE 選單樣式"
        ''' <summary>
        ''' MENU_STYLE 選單樣式
        ''' </summary>
        Public Property MENU_STYLE As String
            Get
                Return Me.ColumnyMap("MENU_STYLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_STYLE") = value
            End Set
        End Property
#End Region

#Region "PERSON_TYPE 人員類別"
        ''' <summary>
        ''' PERSON_TYPE 人員類別
        ''' </summary>
        Public Property PERSON_TYPE As String
            Get
                Return Me.ColumnyMap("PERSON_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PERSON_TYPE") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Property USE_STATE As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "IS_ALL 全部執照"
        ''' <summary>
        ''' IS_ALL 全部執照
        ''' </summary>
        Public Property IS_ALL As String
            Get
                Return Me.ColumnyMap("IS_ALL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_ALL") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO_DATA 執照號碼"
        ''' <summary>
        ''' LICENSE_NO_DATA 執照號碼
        ''' </summary>
        Public Property LICENSE_NO_DATA As String
            Get
                Return Me.ColumnyMap("LICENSE_NO_DATA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_NO_DATA") = value
            End Set
        End Property
#End Region

#Region "APPR_ENABLE_TIME 認證期限"
        '' <summary>
        '' APPR_ENABLE_TIME 認證期限
        '' </summary>
        Public Property APPR_ENABLE_TIME() As String
            Get
                Return Me.ColumnyMap("APPR_ENABLE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APPR_ENABLE_TIME") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "GetPerson 取得人員主檔 "
        ''' <summary>
        ''' 取得人員主檔 
        ''' </summary>
        Public Function GetPerson() As DataTable
            Return Me.GetPerson(0, 0)
        End Function

        ''' <summary>
        ''' 取得人員主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetPerson(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'SELECT A.ACNT(帳號),A.PERSON_TYPE(人員類別),A.CH_NAME(中文姓名),A.DEP_CODE(單位代碼),A.EMAIL(電子信箱),A.CONTACT_TEL(聯絡電話),A.DEADLINE_SDATE(期限起日),A.DEADLINE_EDATE(期限訖日),A.USE_STATE(使用狀態),
                'A.FONT_SIZE(字型大小),A.MENU_STYLE(選單樣式),A.DEFAULT_NUM(預設筆數),B.PW(密碼),B.IS_CHANG(是否變更),B.ERROR_TIMES(錯誤次數),B.PW_UPD_DATE(密碼修改日期) 
                'FROM POST020 A,POST010 B ON A.ACNT(帳號)=B.ACNT(帳號) 
                'WHERE A.PKNO=QUERY_COND(查詢條件) AND A.ACNT(帳號)=QUERY_COND(查詢條件) AND A.PERSON_TYPE(人員類別)=QUERY_COND(查詢條件) AND A.CH_NAME(中文姓名) LIKE '%查詢條件%' AND 
                'A.DEP_CODE(單位代碼)=QUERY_COND(查詢條件) AND A.USE_STATE(使用狀態)=QUERY_COND(查詢條件)

                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"POST020", "M", "PKNO", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "USE_STATE"})
                Me.TableCoumnInfo.Add(New String() {"POST010", "R1", "PKNO", "PW", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, ")
                sql.AppendLine(" CONVERT(VARCHAR(10), M.DEADLINE_SDATE, 111)  AS SDATE, ")
                sql.AppendLine(" CONVERT(VARCHAR(10), M.DEADLINE_EDATE, 111)  AS EDATE,  ")
                sql.AppendLine(" R1.PW, ")
                sql.AppendLine(" R1.IS_CHANG, ")    '是否變更
                sql.AppendLine(" R1.ERROR_TIMES, ") '錯誤次數
                sql.AppendLine(" R1.PW_UPD_DATE, ")  '密碼修改日期
                'sql.AppendLine(" R2.NO_NAME AS PERSON_TYPE_NAME, ")  '人員類別中文
                sql.AppendLine(" R2.SYS_NAME AS COM_TYPE_NAME, ")  '人員類別中文
                sql.AppendLine(" R3.COM_CNAM AS DEP_NAME, ")           '單位中文
                sql.AppendLine(" R3.COM_CODE ")           '機構代碼
                sql.AppendLine(" FROM POST020 M WITH (NOLOCK) ")
                sql.AppendLine(" LEFT JOIN POST010 R1 WITH (NOLOCK) ON M.ACNT = R1.ACNT ")
                'sql.AppendLine(" LEFT JOIN POSC010 R2 WITH (NOLOCK) ON M.PERSON_TYPE = R2.NO AND R2.TYPE_CODE = '0006' ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 WITH (NOLOCK) ON M.PERSON_TYPE = R2.SYS_ID AND R2.SYS_KEY = 'COM_TYPE' ")
                sql.AppendLine(" LEFT JOIN APPL010 R3 WITH (NOLOCK) ON M.DEP_CODE = R3.PKNO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.ACNT ")
                    Else
                        sql.AppendLine(" ORDER BY ACNT ")
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

#Region "GetSTF 取得提報承辦人 "
        ''' <summary>
        ''' 取得承辦人
        ''' </summary>
        Public Function GetSTF(Optional ByVal num As Integer = 0) As DataTable
            Return Me.GetSTF(0, 0, num)
        End Function

        ''' <summary>
        ''' 取得提報承辦人
        ''' </summary>
        Public Function GetSTF(ByVal pageNo As Integer, ByVal pageSize As Integer, ByVal num As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"POST020", "M", "PKNO", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "USE_STATE"})
                Me.TableCoumnInfo.Add(New String() {"POST010", "R1", "PKNO", "PW", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE"})

                Dim condition As StringBuilder = New StringBuilder()

                If Current.Session("PERSON_TYPE") = 0 Then
                    'NCC 依所設定執照範圍查詢資料
                    If Current.Session("IS_ALL") <> "Y" Then
                        If Current.Session("LICENSE_NO_DATA") <> "" Then
                            condition.Append(" AND $.LICENSE_NO IN (" & strLicNo() & ")")
                        Else
                            '無任何可用執照，傳回NCC人員
                            Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Current.Session("DEP_CODE"))
                            'condition.Append(" AND 1=2 ")
                        End If
                    End If
                Else
                    '業者 須限定為本公司資料範圍
                    Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Current.Session("DEP_CODE"))
                End If

                condition.Append(" AND ISNULL(M.CH_NAME,'')<>'' ")

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()


                '承辦人清單
                Dim sql As New StringBuilder
                sql.AppendLine("SELECT M.ACNT AS STF, ISNULL(M.ACNT,'') + ' - ' + ISNULL(M.CH_NAME,'') AS LIST , M.CH_NAME FROM  ")
                sql.AppendLine(" POST020 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE 1=1 AND " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY ACNT ASC, CH_NAME ASC ")
                    Else
                        sql.AppendLine(" ORDER BY ACNT ASC, CH_NAME ASC ")
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

#Region "傳回執照代號Session(LICENSE_NO_DATA)字串 for SQL strLicNo"
        ''' <summary>
        ''' 傳回執照代號Session("LICENSE_NO_DATA")字串 for SQL
        ''' </summary>
        ''' <returns>String 執照代號字串</returns>
        ''' <remarks></remarks>
        Private Function strLicNo() As String
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

#End Region

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "LICENSE_NO_DATA,DEADLINE_SDATE,DEADLINE_EDATE"
            MyBase.LONG_FIELD_NAME = "CH_NAME"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "LICENSE_NO_DATA,DEADLINE_SDATE,DEADLINE_EDATE"
            MyBase.LONG_FIELD_NAME = "CH_NAME"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "LICENSE_NO_DATA,DEADLINE_SDATE,DEADLINE_EDATE"
            MyBase.LONG_FIELD_NAME = "CH_NAME"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region
    End Class
End Namespace

