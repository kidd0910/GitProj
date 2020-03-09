'----------------------------------------------------------------------------------
'File Name		: EntGroupMember
'Author			: nono
'Description		: EntGroupMember 群組成員ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/20	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Aut.Data
	'' <summary>
	'' EntGroupMember 群組成員ENT
	'' </summary>
	Public Class EntGroupMember 
		Inherits Acer.Base.EntityBase
		Implements Acer.Base.IEntityInterface 
		
	#Region "建構子"
		'' <summary>
		'' 建構子/處理屬性對應處理
		'' </summary>
		'' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		'' <summary>
		'' 建構子/處理異動處理
		'' </summary>
		'' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	"AUTT020"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
		#Region "USE_FG 使用別"
		''' <summary>
		''' USE_FG 使用別
		''' </summary>
		Public Property USE_FG As String
			Get
				Return Me.ColumnyMap("USE_FG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("USE_FG")	=	value
			End Set
		End Property
		#End Region

		#Region "SYS_DATE 系統日期"
		''' <summary>
		''' SYS_DATE 系統日期
		''' </summary>
		Public Property SYS_DATE As String
			Get
				Return Me.ColumnyMap("SYS_DATE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SYS_DATE")	=	value
			End Set
		End Property
		#End Region

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
		
		#Region "CORRE_ACNT_FIELD 對應帳號欄位"
		''' <summary>
		''' CORRE_ACNT_FIELD 對應帳號欄位
		''' </summary>
		Public Property CORRE_ACNT_FIELD As String
			Get
				Return Me.ColumnyMap("CORRE_ACNT_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CORRE_ACNT_FIELD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "CORRE_NAME_FIELD 對應姓名欄位"
		''' <summary>
		''' CORRE_NAME_FIELD 對應姓名欄位
		''' </summary>
		Public Property CORRE_NAME_FIELD As String
			Get
				Return Me.ColumnyMap("CORRE_NAME_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CORRE_NAME_FIELD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "GROUP_CODE 群組代碼"
		''' <summary>
		''' GROUP_CODE 群組代碼
		''' </summary>
		Public Property GROUP_CODE As String
			Get
				Return Me.ColumnyMap("GROUP_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("GROUP_CODE")	=	value
			End Set
		End Property
		#End Region
		
		#Region "ID_FG 身分別"
		''' <summary>
		''' ID_FG 身分別
		''' </summary>
		Public Property ID_FG As String
			Get
				Return Me.ColumnyMap("ID_FG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ID_FG")	=	value
			End Set
		End Property
		#End Region
		
		#Region "TABLE_NM 表格名稱"
		''' <summary>
		''' TABLE_NM 表格名稱
		''' </summary>
		Public Property TABLE_NM As String
			Get
				Return Me.ColumnyMap("TABLE_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TABLE_NM")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"
		#Region "GetGroupMember 取得群組成員 "
		''' <summary>
		''' 取得群組成員 
		''' </summary>
		Public Function GetGroupMember() As DataTable
			Return Me.GetGroupMember(0, 0)
		End Function
		
		''' <summary>
		''' 取得群組成員 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function GetGroupMember(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理別名轉換 ===
				Me.TableCoumnInfo	=	New ArrayList()
				Me.TableCoumnInfo.Add(New String() {"AUTT010", "M", 	"PKNO", "ACNT", "GROUP_CODE", "ID_FG"})
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",	Me.PKNO)	'PKNO
				Me.ProcessQueryCondition(condition, "=", "ACNT",	Me.ACNT)	'帳號
				Me.ProcessQueryCondition(condition, "=", "GROUP_CODE",	Me.GROUP_CODE)	'群組代碼
				Me.ProcessQueryCondition(condition, "=", "ID_FG",	Me.ID_FG)	'身分別
				Me.SqlRetrictions	=	condition.ToString()
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select *,B.GROUP_NAME(群組名稱) from (
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.CH_NAME(中文姓名) as CH_NAME(中文姓名) From AUTT020 A,ENRT010 B 
				'Where A.ID_FG(身分別)='01' and A.ACNT(帳號)=B.STNO(學號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) 
				'Union All
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.CH_NAME(中文姓名) as CH_NAME(中文姓名) From AUTT020 A,POST020 B 
				'Where A.ID_FG(身分別)='02' and A.ACNT(帳號)=B.ACNT(帳號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) 
				'Union All
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.CH_NAME(中文姓名) as CH_NAME(中文姓名) From AUTT020 A,SDOT010 B 
				'Where A.ID_FG(身分別)='03' and A.ACNT(帳號)=B.IDNO(身分證字號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) 
				'Union All
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.NAME(姓名) as CH_NAME(中文姓名) From AUTT020 A,RECT130 B 
				'Where A.ID_FG(身分別)='04' and A.ACNT(帳號)=B.PAYMENT_ACNT(繳費帳號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) 
				'Union All
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.NAME(姓名) as CH_NAME(中文姓名) From AUTT020 A,CDTT010 B 
				'Where A.ID_FG(身分別)='05' and A.ACNT(帳號)=B.REG_ACNT(報名帳號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) 
				'Union All
				'Select A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號),B.COMPANY_NAME(公司名稱) as CH_NAME(中文姓名) From AUTT020 A,SCDT040 B 
				'Where A.ID_FG(身分別)='06' and A.ACNT(帳號)=B.ACNT(帳號) and GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and ID_FG(身分別)=QUERY_COND(查詢條件) and ACNT(帳號)=QUERY_COND(查詢條件) )
				'A,AUTT010 B Where A.GROUP_CODE(群組代碼)=B.GROUP_CODE(群組代碼) 
				'Order By A.GROUP_CODE(群組代碼),A.ID_FG(身分別),A.ACNT(帳號)

                Dim sql As StringBuilder = New StringBuilder()

                sql.AppendLine(" SELECT M.*,")
                sql.AppendLine("        R1.CH_NAME,")
                sql.AppendLine("        R1.PERSON_TYPE,")
                sql.AppendLine("        R1.EMAIL,")
                sql.AppendLine("        R1.CONTACT_TEL,")
                sql.AppendLine("        R1.DEADLINE_SDATE,")
                sql.AppendLine("        R1.DEADLINE_EDATE,")
                sql.AppendLine("        R1.USE_STATE,")
                sql.AppendLine("        R2.NO_NAME AS PERSON_TYPE_NAME,R3.GROUP_NAME,")
                sql.AppendLine("        R4.DEP_NAME")
                sql.AppendLine("   FROM             AUTT020 M WITH(NOLOCK) ")
                sql.AppendLine("                 INNER JOIN")
                sql.AppendLine("                    POST020 R1 WITH(NOLOCK) ")
                sql.AppendLine("                 ON M.ACNT = R1.ACNT")
                sql.AppendLine("              LEFT JOIN")
                sql.AppendLine("                 POSC010 R2 WITH(NOLOCK) ")
                sql.AppendLine("              ON R1.PERSON_TYPE = R2.NO AND R2.TYPE_CODE = '0006'")
                sql.AppendLine("           LEFT JOIN")
                sql.AppendLine("              AUTT010 R3 WITH(NOLOCK) ")
                sql.AppendLine("           ON M.GROUP_CODE = R3.GROUP_CODE")
                sql.AppendLine("        LEFT JOIN")
                sql.AppendLine("    ( SELECT '0' AS PERSON_TYPE, NO AS DEP_CODE, NO_NAME AS DEP_NAME, NO_SEQ, '' AS SEQ, USE_STATE FROM POSC010 WITH(NOLOCK) WHERE TYPE_CODE = '0001' ")
                sql.AppendLine("    UNION ")
                sql.AppendLine("    SELECT '1' AS PERSON_TYPE, PKNO AS DEP_CODE, COM_CNAM AS DEP_NAME, NULL, PKNO AS SEQ, USE_STATE  FROM APPL010 ) R4 ")
                sql.AppendLine("        ON R1.DEP_CODE = R4.DEP_CODE ")
                sql.AppendLine("  WHERE 1 = 1 ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" AND " & Me.SqlRetrictions.Replace("$.", " "))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.GROUP_CODE, M.ID_FG, M.ACNT ")
                Else
                    sql.Append(" ORDER BY GROUP_CODE, ID_FG, ACNT ")
                End If
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql.ToString(), pageNo, pageSize)
				If pageNo > 0 Then
					Me.TOTAL_ROW_COUNT	=	Me.TotalRowCount()
    				End If
				Me.ResetColumnProperty()
				
				Return dt

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetRoleIDTable 取得角色別對應表格 "
		''' <summary>
		''' 取得角色別對應表格 
		''' </summary>
		Public Function GetRoleIDTable() As DataTable
			Return Me.GetRoleIDTable(0, 0)
		End Function
		
		''' <summary>
		''' 取得角色別對應表格 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetRoleIDTable(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

	
				'=== 處理別名轉換 ===
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Set TABLE_NM(表格名稱)=""
				'Set CORRE_ACNT_FIELD(對應帳號欄位)=""
				'Set CORRE_NAME_FIELD(對應姓名欄位)=""
				'if ID_FG(身分別) = "01" then  { //學生
				'    TABLE_NM(表格名稱)="ENRT010"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="STNO"
				'    CORRE_NAME_FIELD(對應姓名欄位)="CH_NAME"
				'    
				'}
				'else if ID_FG(身分別) = "02" then  { //教職員
				'    TABLE_NM(表格名稱)="POST020"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="ACNT"
				'    CORRE_NAME_FIELD(對應姓名欄位)="CH_NAME"
				'    
				'}
				'else if ID_FG(身分別) = "03" then  { //房東
				'    TABLE_NM(表格名稱)="SDOT010"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="IDNO"
				'    CORRE_NAME_FIELD(對應姓名欄位)="CH_NAME"
				'    
				'}
				'else if ID_FG(身分別) = "04" then  { //招生考生
				'    TABLE_NM(表格名稱)="RECT130"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="PAYMENT_ACNT"
				'    CORRE_NAME_FIELD(對應姓名欄位)="NAME"
				'    
				'}
				'else if ID_FG(身分別) = "05" then  { //學分班學生
				'    TABLE_NM(表格名稱)="CDTT010"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="REG_ACNT"
				'    CORRE_NAME_FIELD(對應姓名欄位)="NAME"
				'    
				'}
				'else if ID_FG(身分別) = "06" then  { //廠商
				'    TABLE_NM(表格名稱)="SCDT040"
				'    CORRE_ACNT_FIELD(對應帳號欄位)="ACNT"
				'    CORRE_NAME_FIELD(對應姓名欄位)="COMPANY_NAME"
				'    
				'}
				
				Dim	sql	As	String		=	""
				
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql, pageNo, pageSize)
				
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetAcntAllProg 取得帳號所有程式 "
		''' <summary>
		''' 取得帳號所有程式 
		''' </summary>
		Public Function GetAcntAllProg() As DataTable
			Return Me.GetAcntAllProg(0, 0)
		End Function
		
		''' <summary>
		''' 取得帳號所有程式 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/26 新增方法
		''' </remarks>
		Public Function GetAcntAllProg(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理別名轉換 ===
				Me.TableCoumnInfo	=	New ArrayList()
				Me.TableCoumnInfo.Add(New String() {"AUTT010", "M", 	"ACNT", "ID_FG"})
				
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "ACNT",	Me.ACNT)		'帳號
				Me.ProcessQueryCondition(condition, "=", "ID_FG",	Me.ID_FG)		'身分別
				Me.SqlRetrictions	=	condition.ToString()
				Me.ParserAlias()

				'=== 處理說明 ===
				'//ID_FG(身分別)=>01:學生,02:教職員,03:房東,04:招生,05:學分班,06:廠商
				'Select A.GROUP_CODE(群組代碼),C.PROG_CD(程式代號),C.PROG_NM(程式名稱),C.PROG_PATH(程式路徑),C.PROG_EXPL(程式說明),D.OPERATE_NM(作業名稱),E.SYS_NM(系統名稱) 
				'From AUTT020 A,AUTT030 B,AUTC030 C,AUTC020 D,AUTC010 E 
				'Where 
				'A.GROUP_CODE(群組代碼)=B.GROUP_CODE(群組代碼) and B.PROG_CD(程式代號)=C.PROG_CD(程式代號) and C.SYS_CD(系統代號)=D.SYS_CD(系統代號) and C.OPERATE_CD(作業代號)=D.OPERATE_CD(作業代號) and 
                'C.SYS_CD(系統代號)=E.SYS_CD(系統代號) and SYS_DATE(系統日期) between C.OPEN_DATES(開放日期起) and C.OPEN_DATEE(開放日期訖) and C.USE_STATE(是否使用)='1' and 
				'A.ID_FG(身分別)=QUERY_COND(查詢條件) and A.ACNT(帳號)=QUERY_COND(查詢條件) and 
				'
				'if USE_FG(使用別)="1" //表示外網 
				'    C.OUTSIDE_USE(外網使用)='1'
				'else if USE_FG(使用別)="2" //表示招生login使用 
				'    C.RECRUITST_USE(招生使用)='1'
				'else if USE_FG(使用別)="3" //表示學分班login使用
				'    C.CRD_CLASS_USE(學分班使用)='1'
				'
				'
				'Order By C.SYS_CD(系統代號),D.OPERATE_SORT(作業排序),C.PROG_SORT(程式排序)

				Dim	sql1	As	StringBuilder		=	New StringBuilder()
                sql1.Append( _
                 "SELECT DISTINCT R2.SYS_CD, R4.SYS_NM, R2.PROG_CD, R2.PROG_NM, R2.PROG_PATH, R2.PROG_EXPL," & _
                 "R3.OPERATE_CD, R3.UPPER_OPERATE_CD, R3.OPERATE_NM, R3.OPERATE_SORT, R2.PROG_SORT " & _
                 "FROM AUTT020 M " & _
                 "LEFT JOIN AUTT030 R1 " & _
                 "ON " & _
                 "M.GROUP_CODE	=	R1.GROUP_CODE " & _
                 "INNER JOIN AUTC030 R2 " & _
                 "ON " & _
                 "R1.PROG_CD	=	R2.PROG_CD AND " & _
                 "'" & Me.SYS_DATE & "' BETWEEN NVL(R2.OPEN_DATES,'2001/01/01') AND NVL(R2.OPEN_DATEE,'9999/12/31') AND " & _
                 "R2.USE_STATE	=	'1' " & _
                 "LEFT JOIN AUTC020 R3 " & _
                 "ON " & _
                 "R2.SYS_CD	=	R3.SYS_CD AND " & _
                 "R2.OPERATE_CD	=	R3.OPERATE_CD " & _
                 "LEFT JOIN AUTC010 R4 " & _
                 "ON " & _
                 "R2.SYS_CD	=	R4.SYS_CD ")
				
				'if USE_FG(使用別)="1" //表示外網 
				'    C.OUTSIDE_USE(外網使用)='1'
				If Me.USE_FG = "1" Then
					Me.SqlRetrictions	&=	" AND R2.OUTSIDE_USE	=	'1'"
				'else if USE_FG(使用別)="2" //表示招生login使用 
				'    C.RECRUITST_USE(招生使用)='1'
				Else If Me.USE_FG = "2" Then
					Me.SqlRetrictions	&=	" AND R2.RECRUITST_USE	=	'1'"
				'else if USE_FG(使用別)="3" //表示學分班login使用
				'    C.CRD_CLASS_USE(學分班使用)='1'
				Else If Me.USE_FG = "3" Then
					Me.SqlRetrictions	&=	" AND R2.CRD_CLASS_USE	=	'1'"
				End If

				If Me.SqlRetrictions.Length > 0 Then
					sql1.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
				End If

                If pageNo = 0 Then
                    sql1.Append(" ORDER BY R2.SYS_CD ")
                Else
                    sql1.Append(" ORDER BY SYS_CD ")
                End If

				Dim	dt1	As	DataTable	=	Me.QueryBySql(sql1.ToString(), pageNo, pageSize)
				If pageNo > 0 Then
					Me.TOTAL_ROW_COUNT	=	Me.TotalRowCount()
    				End If
				Me.ResetColumnProperty()
				
				Return dt1
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

	#End Region
		
	End Class
End NameSpace
 
