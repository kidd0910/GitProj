'----------------------------------------------------------------------------------
'File Name		: EntLoginAcntGroup
'Author			: Shanlee
'Description		: EntLoginAcntGroup 登入帳號群組ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/06/10	Shanlee		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Aut.Data
    '' <summary>
    '' EntLoginAcntGroup 登入帳號群組ENT
    '' </summary>
    Public Class EntLoginAcntGroup
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
            Me.TableName = "AUTT080"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT() As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_ENG 資料欄位英文名稱"
        ''' <summary>
        ''' DATA_FIELD_ENG 資料欄位英文名稱
        ''' </summary>
        Public Property DATA_FIELD_ENG() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_ENG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_ENG") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_TYPE 資料欄位類別"
        ''' <summary>
        ''' DATA_FIELD_TYPE 資料欄位類別
        ''' </summary>
        Public Property DATA_FIELD_TYPE() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_TYPE") = value
            End Set
        End Property
#End Region

#Region "GROUP_CODE 群組代碼"
        ''' <summary>
        ''' GROUP_CODE 群組代碼
        ''' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "SQL_VALUE SQL值"
        ''' <summary>
        ''' SQL_VALUE SQL值
        ''' </summary>
        Public Property SQL_VALUE() As String
            Get
                Return Me.ColumnyMap("SQL_VALUE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SQL_VALUE") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "GetGroupDefAllAcnt 取得所有群組定義帳號 "
        ''' <summary>
        ''' 取得所有群組定義帳號 
        ''' </summary>
        Public Function GetGroupDefAllAcnt() As DataTable
            Return Me.GetGroupDefAllAcnt(0, 0)
        End Function

        ''' <summary>
        ''' 取得所有群組定義帳號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetGroupDefAllAcnt(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.ParserAlias()
                Dim sql As String = ""
                Dim condition As StringBuilder = New StringBuilder()
                'Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)     '資料欄位英文名稱
                If Not String.IsNullOrEmpty(Me.SQL_VALUE) And Not String.IsNullOrEmpty(Me.DATA_FIELD_ENG) Then
                    condition.Append(Me.DATA_FIELD_ENG & " IN (" & Me.SQL_VALUE & ") ")
                End If
               
                '=== 處理說明 ===
                Select Case Me.DATA_FIELD_TYPE
                    Case "0"
                        '    SQL = "SELECT ACNT as 帳號 FROM POST010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                        sql = "SELECT ACNT  FROM POST010 "

                    Case "1"
                        sql = "SELECT * FROM (" & _
                            "SELECT A.*, A.ACNT AS TCH_CODE,C.DEP_CODE, C.DEP_NAME, D.NO_NAME AS JOBTITLE_NAME," & _
                            "E.NO_NAME AS LEVEL_NAME, F.NO_NAME AS OJOB_NAME,B.JOBTITLE_CODE,B.LEVEL_CODE,B.PTTCH_FT," & _
                            "G.ACNT AS UNIT_DIRECTOR_CODE, G.CH_NAME AS UNIT_DIRECTOR_NAME " & _
                            "FROM POST020 A " & _
                            "LEFT OUTER JOIN POST030 B ON B.ACNT = A.ACNT " & _
                            "LEFT OUTER JOIN ORGT010 C ON C.DEP_CODE = B.DEP_CODE " & _
                            "LEFT OUTER JOIN POSC010 D " & _
                            "ON D.TYPE_CODE = '0001' AND D.NO = B.JOBTITLE_CODE " & _
                            "LEFT OUTER JOIN POSC010 E " & _
                            "ON E.TYPE_CODE = '0002' AND E.NO = B.LEVEL_CODE " & _
                            "LEFT OUTER JOIN POSC010 F " & _
                            "ON F.TYPE_CODE = '0004' AND F.NO = A.NATION_CODE " & _
                            "LEFT OUTER JOIN POST020 G ON G.ACNT = C.UNIT_DIRECTOR_CODE )"

                    Case "2"
                        '    SQL = "SELECT STNO as 帳號 FROM ENRT010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                        sql = "SELECT STNO as ACNT  FROM ENRT010  "

                    Case "3"
                        sql = "SELECT * FROM (SELECT  A.CH_NAME, A.TEL_MOBILE, A.EMAIL, A.LESSOR_PW, A.END_ACNT, A.END_REASON, A.PKNO, " & _
                        "A.CREATE_TIME, A.CREATE_USER, A.UPDATE_TIME, A.UPDATE_USER, A.ROWSTAMP, A.IDNO AS ACNT , A.REGISTRANT_TITLE, " & _
                        "A.REGISTRANT_NAME, A.REGISTRANT_BIRTHDATE, A.TEL_FAMILY, A.TEL_OFFICE " & _
                        ", B.AREA_NO, B.ZIP_NO, B.RENT_ADDR, B.START_QUERY, B.BUILDING_TYPE, B.SEX_LIMIT, B.LIVE_STATUS, " & _
                         "B.RENT_AMT_ALLIN_EXPENSE, B.STALL_KIND, B.ATTIC_OVERPRINT, B.RENT_AMT_DICKER, B.TOTAL_STOREY, " & _
                         "B.EXIST_STOREY, B.ROOM_NUM, B.SALON_NUM, B.BATHROOM_NUM, B.GROUND_NUM, B.BUILDING_AGE, B.ALLIN_STALL, " & _
                         "B.RENT_AMT, B.PAWN_AMT, B.MANAGE_FEE, B.RMK, B.START_QUERY_DATE, B.START_QUERY_PERSON, B.APP_DATE, " & _
                         "B.AUDIT_STATUS, B.AUDIT_EXPL, B.AUDIT_PERSON, B.AUDIT_DATETIME " & _
                         "FROM SDOT010 A LEFT OUTER JOIN SDOT020 B ON A.IDNO	=	B.IDNO ) "

                    Case "4"
                        '    SQL = "Select ACNT as 帳號 from SCDT040 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                        sql = "SELECT ACNT FROM SCDT040 "
                    Case "5"
                        '    SQL = "Select REG_ACNT as 帳號 from CDTT010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                        sql = "SELECT REG_ACNT AS ACNT FROM CDTT010 "
                    Case "6"
                        '    SQL = "Select SUBSTRING(PAYMENT_ACNT,6,10) as 帳號 from RECT130 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                        sql = "SELECT SUBSTRING(PAYMENT_ACNT,6,10) AS ACNT FROM RECT130 "
                End Select
                'if dt1.DATA_FIELD_TYPE(資料欄位類別)="0" then { //PERSON_TYPE(人員類別)
                '    SQL = "SELECT ACNT as 帳號 FROM POST010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="1" then { //教職員
                '    SQL = "SELECT ACNT as 帳號 FROM ("
                '    "SELECT A.*, A.ACNT AS TCH_CODE,C.DEP_CODE, C.DEP_NAME, D.NO_NAME AS JOBTITLE_NAME," +
                '    "E.NO_NAME AS LEVEL_NAME, F.NO_NAME AS OJOB_NAME,B.JOBTITLE_CODE,B.LEVEL_CODE,B.PTTCH_FT," +
                '    "G.ACNT AS UNIT_DIRECTOR_CODE, G.CH_NAME AS UNIT_DIRECTOR_NAME " +
                '    "FROM POST020 A " +
                '    "LEFT OUTER JOIN POST030 B ON B.ACNT = A.ACNT " +
                '    "LEFT OUTER JOIN ORGT010 C ON C.DEP_CODE = B.DEP_CODE " +
                '    "LEFT OUTER JOIN POSC010 D " +
                '    "ON D.TYPE_CODE = '0001' AND D.NO = B.JOBTITLE_CODE " +
                '    "LEFT OUTER JOIN POSC010 E " +
                '    "ON E.TYPE_CODE = '0002' AND E.NO = B.LEVEL_CODE " +
                '    "LEFT OUTER JOIN POSC010 F " +
                '    "ON F.TYPE_CODE = '0004' AND F.NO = A.NATION_CODE " +
                '    "LEFT OUTER JOIN POST020 G ON G.ACNT = C.UNIT_DIRECTOR_CODE ) WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="2" then { //學生
                '    SQL = "SELECT STNO as 帳號 FROM ENRT010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="3" then { //房東
                '    SQL = "SELECT IDNO as 帳號 FROM (SELECT  A.CH_NAME, A.TEL_MOBILE, A.EMAIL, A.LESSOR_PW, A.END_ACNT, A.END_REASON, A.PKNO, " +
                '    "A.CREATE_TIME, A.CREATE_USER, A.UPDATE_TIME, A.UPDATE_USER, A.ROWSTAMP, A.IDNO, A.REGISTRANT_TITLE, " +
                '    "A.REGISTRANT_NAME, A.REGISTRANT_BIRTHDATE, A.TEL_FAMILY, A.TEL_OFFICE " +
                '	", B.AREA_NO, B.ZIP_NO, B.RENT_ADDR, B.START_QUERY, B.BUILDING_TYPE, B.SEX_LIMIT, B.LIVE_STATUS, " +
                '	"B.RENT_AMT_ALLIN_EXPENSE, B.STALL_KIND, B.ATTIC_OVERPRINT, B.RENT_AMT_DICKER, B.TOTAL_STOREY, " +
                '	"B.EXIST_STOREY, B.ROOM_NUM, B.SALON_NUM, B.BATHROOM_NUM, B.GROUND_NUM, B.BUILDING_AGE, B.ALLIN_STALL, " +
                '	"B.RENT_AMT, B.PAWN_AMT, B.MANAGE_FEE, B.RMK, B.START_QUERY_DATE, B.START_QUERY_PERSON, B.APP_DATE, " +
                '	"B.AUDIT_STATUS, B.AUDIT_EXPL, B.AUDIT_PERSON, B.AUDIT_DATETIME " +
                '	"FROM SDOT010 A LEFT OUTER JOIN SDOT020 B ON A.IDNO	=	B.IDNO ) WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="4" then { //廠商
                '    SQL = "Select ACNT as 帳號 from SCDT040 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="5" then { //學分班 
                '    SQL = "Select REG_ACNT as 帳號 from CDTT010 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}
                'else if dt1.DATA_FIELD_TYPE(資料欄位類別)="6" then { //招生
                '    SQL = "Select SUBSTRING(PAYMENT_ACNT,6,10) as 帳號 from RECT130 WHERE " + DATA_FIELD_ENG(資料欄位英文名稱) + " in (" + SQL_VALUE(SQL值) + ")"
                '}

                If Not String.IsNullOrEmpty(condition.ToString) Then
                    sql &= " WHERE " & condition.ToString.Replace("$.", "")
                End If
                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

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

