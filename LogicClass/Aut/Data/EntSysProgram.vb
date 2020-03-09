'----------------------------------------------------------------------------------
'File Name		: EntSysProgram
'Author			: 
'Description		: EntSysProgram 系統程式ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		nono		2009/03/16			Source Create
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
	'' EntSysProgram 系統程式ENT
	'' </summary>
	Public Class EntSysProgram 
		Inherits EntSystemTask
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
			Me.TableName	=	"AUTC030"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

#Region "屬性"
#Region "OPEN_OUTSIDE 開啟外網使用"
        ''' <summary>
        ''' OPEN_OUTSIDE 開啟外網使用
        ''' </summary>
        Public Property OPEN_OUTSIDE() As String
            Get
                Return Me.ColumnyMap("OPEN_OUTSIDE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_OUTSIDE") = value
            End Set
        End Property
#End Region

#Region "CRD_CLASS_USE 學分班使用"
        ''' <summary>
        ''' CRD_CLASS_USE 學分班使用
        ''' </summary>
        Public Property CRD_CLASS_USE() As String
            Get
                Return Me.ColumnyMap("CRD_CLASS_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CRD_CLASS_USE") = value
            End Set
        End Property
#End Region

        '#Region "IS_USE 是否使用"
        '''' <summary>
        '''' IS_USE 是否使用
        '''' </summary>
        'Public Property IS_USE As String
        '	Get
        '		Return Me.ColumnyMap("IS_USE")
        '	End Get
        '	Set(ByVal value As String)
        '		Me.ColumnyMap("IS_USE")	=	value
        '	End Set
        'End Property
        '#End Region

#Region "USE_STATE 是否使用"
        ''' <summary>
        ''' USE_STATE 是否使用
        ''' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATEE 開放日期訖"
        ''' <summary>
        ''' OPEN_DATEE 開放日期訖
        ''' </summary>
        Public Property OPEN_DATEE() As String
            Get
                Return Me.ColumnyMap("OPEN_DATEE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_DATEE") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATES 開放日期起"
        ''' <summary>
        ''' OPEN_DATES 開放日期起
        ''' </summary>
        Public Property OPEN_DATES() As String
            Get
                Return Me.ColumnyMap("OPEN_DATES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_DATES") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATE 開放日期"
        ''' <summary>
        ''' OPEN_DATE 開放日期
        ''' </summary>
        Public Property OPEN_DATE() As String
            Get
                Return Me.PropertyMap("OPEN_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATE") = value
            End Set
        End Property
#End Region

#Region "OUTSIDE_USE 外網使用"
        ''' <summary>
        ''' OUTSIDE_USE 外網使用
        ''' </summary>
        Public Property OUTSIDE_USE() As String
            Get
                Return Me.ColumnyMap("OUTSIDE_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUTSIDE_USE") = value
            End Set
        End Property
#End Region

#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_EXPL 程式說明"
        ''' <summary>
        ''' PROG_EXPL 程式說明
        ''' </summary>
        Public Property PROG_EXPL() As String
            Get
                Return Me.ColumnyMap("PROG_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_EXPL") = value
            End Set
        End Property
#End Region

#Region "PROG_NM 程式名稱"
        ''' <summary>
        ''' PROG_NM 程式名稱
        ''' </summary>
        Public Property PROG_NM() As String
            Get
                Return Me.ColumnyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_NM") = value
            End Set
        End Property
#End Region

#Region "PROG_PATH 程式路徑"
        ''' <summary>
        ''' PROG_PATH 程式路徑
        ''' </summary>
        Public Property PROG_PATH() As String
            Get
                Return Me.ColumnyMap("PROG_PATH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_PATH") = value
            End Set
        End Property
#End Region

#Region "PROG_SORT 程式排序"
        ''' <summary>
        ''' PROG_SORT 程式排序
        ''' </summary>
        Public Property PROG_SORT() As String
            Get
                Return Me.ColumnyMap("PROG_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_SORT") = value
            End Set
        End Property
#End Region

#Region "RECRUITST_USE 招生使用"
        ''' <summary>
        ''' RECRUITST_USE 招生使用
        ''' </summary>
        Public Property RECRUITST_USE() As String
            Get
                Return Me.ColumnyMap("RECRUITST_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECRUITST_USE") = value
            End Set
        End Property
#End Region

#End Region
	
	#Region "自訂方法"
		#Region "GetSysProgram 取得系統程式 "
		''' <summary>
		''' 取得系統程式 
		''' </summary>
		Public Function GetSysProgram() As DataTable
			Return Me.GetSysProgram(0, 0)
		End Function
		
		''' <summary>
		''' 取得系統程式 
		''' </summary>
		''' <remarks>
		''' 0.0.2 nono 2009/03/31 AUTC020 R1 改為使用 Left join
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetSysProgram(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"AUTC030", "M", "PKNO", "SYS_CD", "OPERATE_CD", "PROG_CD", "OPEN_DATES", _
                       "OPEN_DATEE", "USE_STATE", "OUTSIDE_USE", "RECRUITST_USE", _
                       "CRD_CLASS_USE"})
				
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",		Me.PKNO)		'PKNO
				Me.ProcessQueryCondition(condition, "=", "SYS_CD",		Me.SYS_CD)		'系統代號
				Me.ProcessQueryCondition(condition, "=", "OPERATE_CD",		Me.OPERATE_CD)		'作業代號
				Me.ProcessQueryCondition(condition, "=", "PROG_CD",		Me.PROG_CD)		'程式代號
				Me.ProcessQueryCondition(condition, "<=", "OPEN_DATES",		Me.OPEN_DATE)		'開放日期起
				Me.ProcessQueryCondition(condition, ">=", "OPEN_DATEE",		Me.OPEN_DATE)		'開放日期訖
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '使用狀態
				Me.ProcessQueryCondition(condition, "=", "OUTSIDE_USE",		Me.OUTSIDE_USE)		'外網使用
				Me.ProcessQueryCondition(condition, "=", "RECRUITST_USE",	Me.RECRUITST_USE)	'招生使用
				Me.ProcessQueryCondition(condition, "=", "CRD_CLASS_USE",	Me.CRD_CLASS_USE)	'學分班使用

				Me.SqlRetrictions	=	condition.ToString()
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select A.Pkno,A.SYS_CD(系統代號),C.SYS_NM(系統名稱),A.OPERATE_CD(作業代號),B.OPERATE_NM(作業名稱),A.PROG_CD(程式代號),A.PROG_NM(程式名稱),A.PROG_PATH(程式路徑),A.PROG_EXPL(程式說明),
                'A.OPEN_DATES(開放日期起),A.OPEN_DATEE(開放日期訖),A.USE_STATE(是否使用),A.PROG_SORT(程式排序),A.OUTSIDE_USE(外網使用),A.RECRUITST_USE(招生使用),A.CRD_CLASS_USE(學分班使用) 
				'From AUTC030 A,AUTC020 B,AUTC010 C  
				'where A.SYS_CD(系統代號)=B.SYS_CD(系統代號) and A.OPERATE_CD(作業代號)=B.OPERATE_CD(作業代號) and B.SYS_CD(系統代號)=C.SYS_CD(系統代號) and 
				'Pkno=QUERY_COND(查詢條件) and SYS_CD(系統代號)=QUERY_COND(查詢條件) and OPERATE_CD(作業代號)=QUERY_COND(查詢條件) and PROG_CD(程式代號)=QUERY_COND(查詢條件) and 
                'OPEN_DATES(開放日期起)<=查詢條件的開放日期 and OPEN_DATEE(開放日期訖)>=查詢條件的開放日期 and USE_STATE(是否使用)=QUERY_COND(查詢條件) and 
				'OUTSIDE_USE(外網使用)=QUERY_COND(查詢條件) and RECRUITST_USE(招生使用)=QUERY_COND(查詢條件) and CRD_CLASS_USE(學分班使用)=QUERY_COND(查詢條件)
				
				Dim	sql	As	StringBuilder		=	New StringBuilder()
                sql.Append( _
                 "Select M.PKNO, M.SYS_CD, R2.SYS_NM, M.OPERATE_CD, R1.OPERATE_NM, M.PROG_CD, M.PROG_NM, M.PROG_PATH, M.PROG_EXPL, " & _
                 "M.OPEN_DATES, M.OPEN_DATEE, M.USE_STATE, M.PROG_SORT, M.OUTSIDE_USE, M.RECRUITST_USE, M.CRD_CLASS_USE,M.OPEN_OUTSIDE  " & _
                 "FROM AUTC030 M WITH(NOLOCK) " & _
                 "LEFT OUTER JOIN AUTC020 R1 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.SYS_CD	=	R1.SYS_CD AND " & _
                 "M.OPERATE_CD	=	R1.OPERATE_CD " & _
                 "LEFT JOIN AUTC010 R2 WITH(NOLOCK) " & _
                 "ON " & _
                 "M.SYS_CD	=	R2.SYS_CD ")
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.PROG_CD")
                Else
                    sql.Append(" ORDER BY PROG_CD")
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

		#Region "GetSysProgramNmDDL 取得系統程式名稱下拉 "
		''' <summary>
		''' 取得系統程式名稱下拉 
		''' </summary>
		Public Function GetSysProgramNmDDL() As DataTable
			Return Me.GetSysProgramNmDDL(0, 0)
		End Function
		
		''' <summary>
		''' 取得系統程式名稱下拉 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/16 新增方法
		''' </remarks>
		Public Function GetSysProgramNmDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				'Select distinct PROG_CD(程式代號) as value ,程式代號||程式名稱 as text From AUTC030 
				'Where SYS_CODE(系統代碼)=QUERY_COND(查詢條件) and 作業代碼=作業條件

				Dim	cond	As	String	=	""
				If Not String.IsNullOrEmpty(Me.OPERATE_CD) Then
					cond	=	" AND OPERATE_CD	=	'" & Me.OPERATE_CD & "' "
				End If				
                Dim sql As String = _
                 "SELECT DISTINCT PROG_CD + '-' + PROG_NM AS SELECT_TEXT, PROG_CD AS SELECT_VALUE " & _
                 "FROM AUTC030 " & _
                 "WHERE " & _
                 "SYS_CD		=	'" & Me.SYS_CD & "' " & cond & _
                 "ORDER BY PROG_CD"
				
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql, pageNo, pageSize)
				
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region


	#End Region
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "OPEN_DATES,OPEN_DATEE,PROG_SORT"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "OPEN_DATES,OPEN_DATEE,PROG_SORT"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "OPEN_DATES,OPEN_DATEE,PROG_SORT"
            Return MyBase.UpdateByPkNo()
        End Function
	End Class
End NameSpace