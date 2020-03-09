'----------------------------------------------------------------------------------
'File Name		: EntGroupFunction
'Author			: nono
'Description		: EntGroupFunction 群組功能ENT
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
	'' EntGroupFunction 群組功能ENT
	'' </summary>
	Public Class EntGroupFunction 
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
			Me.TableName	=	"AUTT050"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"

		#Region "DATA_FIELD_ENG 資料欄位英文名稱"
		''' <summary>
		''' DATA_FIELD_ENG 資料欄位英文名稱
		''' </summary>
		Public Property DATA_FIELD_ENG As String
			Get
				Return Me.ColumnyMap("DATA_FIELD_ENG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_FIELD_ENG")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DATA_RANGE_LABEL 資料範圍符號"
		''' <summary>
		''' DATA_RANGE_LABEL 資料範圍符號
		''' </summary>
		Public Property DATA_RANGE_LABEL As String
			Get
				Return Me.ColumnyMap("DATA_RANGE_LABEL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_RANGE_LABEL")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DATA_RANGE_VALUE 資料範圍值"
		''' <summary>
		''' DATA_RANGE_VALUE 資料範圍值
		''' </summary>
		Public Property DATA_RANGE_VALUE As String
			Get
				Return Me.ColumnyMap("DATA_RANGE_VALUE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_RANGE_VALUE")	=	value
			End Set
		End Property
		#End Region
		
		#Region "FIELD_RW_PRVLG 欄位讀寫權限"
		''' <summary>
		''' FIELD_RW_PRVLG 欄位讀寫權限
		''' </summary>
		Public Property FIELD_RW_PRVLG As String
			Get
				Return Me.ColumnyMap("FIELD_RW_PRVLG")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("FIELD_RW_PRVLG")	=	value
			End Set
		End Property
		#End Region
		
		#Region "FN_CD 功能代號"
		''' <summary>
		''' FN_CD 功能代號
		''' </summary>
		Public Property FN_CD As String
			Get
				Return Me.ColumnyMap("FN_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("FN_CD")	=	value
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
		
		#Region "PROG_CD 程式代號"
		''' <summary>
		''' PROG_CD 程式代號
		''' </summary>
		Public Property PROG_CD As String
			Get
				Return Me.ColumnyMap("PROG_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PROG_CD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "SQL_VALUE SQL值"
		''' <summary>
		''' SQL_VALUE SQL值
		''' </summary>
		Public Property SQL_VALUE As String
			Get
				Return Me.ColumnyMap("SQL_VALUE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SQL_VALUE")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"
		#Region "AddColumnRange 新增欄項範圍 "
		''' <summary>
		''' 新增欄項範圍 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Sub AddColumnRange()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRange = new EntColumnRange()
				'return EntColumnRange.Insert()
				Dim	ent	As	EntColumnRange	=	New EntColumnRange(Me.DBManager, Me.LogUtil) 				
				ent.SQL_VALUE		=	Me.SQL_VALUE		'SQL值
				ent.FN_CD		=	Me.FN_CD		'功能代號
				ent.PROG_CD		=	Me.PROG_CD		'程式代號
				ent.GROUP_CODE		=	Me.GROUP_CODE		'群組代碼
				ent.DATA_FIELD_ENG	=	Me.DATA_FIELD_ENG	'資料欄位英文名稱
				ent.DATA_RANGE_VALUE	=	Me.DATA_RANGE_VALUE	'資料範圍值
				ent.DATA_RANGE_LABEL	=	Me.DATA_RANGE_LABEL	'資料範圍符號
				ent.Insert()
				
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "AddColumnRight 新增欄項權限 "
		''' <summary>
		''' 新增欄項權限 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Sub AddColumnRight()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRight = new EntColumnRight()
				'return EntColumnRight.Insert()
				Dim	ent	As	EntColumnRight	=	New EntColumnRight(Me.DBManager, Me.LogUtil) 
				ent.FN_CD		=	Me.FN_CD		'功能代號
				ent.FIELD_RW_PRVLG	=	Me.FIELD_RW_PRVLG	'欄位讀寫權限
				ent.PROG_CD		=	Me.PROG_CD		'程式代號
				ent.GROUP_CODE		=	Me.GROUP_CODE		'群組代碼
				ent.DATA_FIELD_ENG	=	Me.DATA_FIELD_ENG	'資料欄位英文名稱

				ent.Insert()
				
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "DeleteColumnRange 刪除欄項範圍 "
		''' <summary>
		''' 刪除欄項範圍 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Sub DeleteColumnRange()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRange = new EntColumnRange()
				'組合查詢字串(EntProFunction.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號),FN_CD(功能代號))
				'return EntColumnRange.Delete()
				
				Dim	ent	As	EntColumnRange	=	New EntColumnRange(Me.DBManager, Me.LogUtil) 
				'=== 處理查詢條件 ===
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)	'PKNO
				Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)	'群組代碼
				Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)	'程式代號
				Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD)	'功能代號
				ent.SqlRetrictions	=	Me.ProcessCondition(condition.ToString())

				ent.Delete()
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "DeleteColumnRight 刪除欄項權限 "
		''' <summary>
		''' 刪除欄項權限 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Sub DeleteColumnRight()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRight = new EntColumnRight()
				'組合查詢字串(EntProFunction.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號),FN_CD(功能代號),DATA_FIELD_ENG(資料欄位英文名稱))
				'return EntColumnRight.Delete()
				Dim	ent	As	EntColumnRight	=	New EntColumnRight(Me.DBManager, Me.LogUtil) 
				'=== 處理查詢條件 ===
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)	'PKNO
				Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)	'群組代碼
				Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)	'程式代號
				Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD)	'功能代號
				Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG", Me.DATA_FIELD_ENG)	'資料欄位英文名稱
				ent.SqlRetrictions	=	Me.ProcessCondition(condition.ToString())

				ent.Delete()

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "GetColumnRange 取得欄項範圍 "
		''' <summary>
		''' 取得欄項範圍 
		''' </summary>
		Public Function GetColumnRange() As DataTable
			Return Me.GetColumnRange(0, 0)
		End Function
		
		''' <summary>
		''' 取得欄項範圍 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function GetColumnRange(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRange = new EntColumnRange()
				'組合查詢字串(EntProFunction.QUERY_COND(查詢條件),"=",Pkno,GROUP_CODE(群組代碼),PROG_CD(程式代號),FN_CD(功能代號),DATA_FIELD_ENG(資料欄位英文名稱))
				'return EntColumnRange.Query()
				Dim	ent	As	EntColumnRange	=	New EntColumnRange(Me.DBManager, Me.LogUtil) 
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",		Me.PKNO)		'PKNO
				Me.ProcessQueryCondition(condition, "=", "FN_CD",		Me.FN_CD)		'功能代號
				Me.ProcessQueryCondition(condition, "=", "PROG_CD",		Me.PROG_CD)		'程式代號
				Me.ProcessQueryCondition(condition, "=", "GROUP_CODE",		Me.GROUP_CODE)		'群組代碼
				Me.ProcessQueryCondition(condition, "=", "DATA_FIELD_ENG",	Me.DATA_FIELD_ENG)	'資料欄位英文名稱
				ent.SqlRetrictions	=	Me.ProcessCondition(condition.ToString())
				
				Dim	dt	As	DataTable	=	ent.GetColumnRange(pageNo, pageSize)
				if pageNo > 0
					Me.TOTAL_ROW_COUNT = ent.TOTAL_ROW_COUNT 
				End If
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetColumnRight 取得欄項權限 "
		''' <summary>
		''' 取得欄項權限 
		''' </summary>
		Public Function GetColumnRight() As DataTable
			Return Me.GetColumnRight(0, 0)
		End Function
		
		''' <summary>
		''' 取得欄項權限 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function GetColumnRight(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRight = new EntColumnRight()
				'return EntColumnRight.GetColumnRange_取得欄項範圍()
				Dim	ent	As	EntColumnRight	=	New EntColumnRight(Me.DBManager, Me.LogUtil) 				
				ent.PKNO		=	Me.PKNO			'Pkno
				ent.FN_CD		=	Me.FN_CD		'功能代號
				ent.FIELD_RW_PRVLG	=	Me.FIELD_RW_PRVLG	'欄位讀寫權限
				ent.PROG_CD		=	Me.PROG_CD		'程式代號
				ent.GROUP_CODE		=	Me.GROUP_CODE		'群組代碼
				ent.DATA_FIELD_ENG	=	Me.DATA_FIELD_ENG	'資料欄位英文名稱

				Dim	dt	As	DataTable	=	ent.GetColumnRight(pageNo, pageSize)
				If pageNo > 0 Then
					Me.TOTAL_ROW_COUNT	=	ent.TOTAL_ROW_COUNT
    				End If
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "UpdateColumnRange 更新欄項範圍 "
		''' <summary>
		''' 更新欄項範圍 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function UpdateColumnRange() As Integer
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===
				
				'=== 處理說明 ===
				'EntColumnRange = new EntColumnRange()
				'return EntColumnRange.UpdateByPkno()
				Dim	ent	As	EntColumnRange	=	New EntColumnRange(Me.DBManager, Me.LogUtil) 
				ent.PKNO		=	Me.PKNO			'Pkno
				ent.SQL_VALUE		=	Me.SQL_VALUE		'SQL值
				ent.FN_CD		=	Me.FN_CD		'功能代號
				ent.PROG_CD		=	Me.PROG_CD		'程式代號
				ent.GROUP_CODE		=	Me.GROUP_CODE		'群組代碼
				ent.DATA_FIELD_ENG	=	Me.DATA_FIELD_ENG	'資料欄位英文名稱
				ent.DATA_RANGE_VALUE	=	Me.DATA_RANGE_VALUE	'資料範圍值
				ent.DATA_RANGE_LABEL	=	Me.DATA_RANGE_LABEL	'資料範圍符號

				Dim	count	As	Integer			=	ent.UpdateByPkno()
				
				Me.ResetColumnProperty()

				Return count
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "UpdateColumnRight 更新欄項權限 "
		''' <summary>
		''' 更新欄項權限 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function UpdateColumnRight() As Integer
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntColumnRight = new EntColumnRight()
				'return EntColumnRight.UpdateByPkno()
				Dim	ent	As	EntColumnRight	=	New EntColumnRight(Me.DBManager, Me.LogUtil) 
				ent.PKNO		=	Me.PKNO			'Pkno
				ent.FN_CD		=	Me.FN_CD		'功能代號
				ent.FIELD_RW_PRVLG	=	Me.FIELD_RW_PRVLG	'欄位讀寫權限
				ent.PROG_CD		=	Me.PROG_CD		'程式代號
				ent.GROUP_CODE		=	Me.GROUP_CODE		'群組代碼
				ent.DATA_FIELD_ENG	=	Me.DATA_FIELD_ENG	'資料欄位英文名稱

				Dim	count	As	Integer		=	ent.UpdateByPkno()
				
				Me.ResetColumnProperty()

				Return count
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetGroupFunction 取得群組功能 "
		''' <summary>
		''' 取得群組功能 
		''' </summary>
		Public Function GetGroupFunction() As DataTable
			Return Me.GetGroupFunction(0, 0)
		End Function
		
		''' <summary>
		''' 取得群組功能 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/31 新增方法
		''' </remarks>
		Public Function GetGroupFunction(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				Me.TableCoumnInfo.Add(New String() {"AUTT010", "M",	"PKNO", "GROUP_CODE", "PROG_CD", "FN_CD"})
				
				'=== 處理查詢條件 ===
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",	Me.PKNO)		'PKNO
				Me.ProcessQueryCondition(condition, "=", "GROUP_CODE",	Me.GROUP_CODE)		'群組代碼
				Me.ProcessQueryCondition(condition, "=", "PROG_CD",	Me.PROG_CD)		'程式代號
				Me.ProcessQueryCondition(condition, "=", "FN_CD",	Me.FN_CD)		'功能代號
				Me.SqlRetrictions	=	condition.ToString()
				
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select A.Pkno,A.GROUP_CODE(群組代碼),A.PROG_CD(程式代號),A.FN_CD(功能代號),B.FN_NM(功能名稱),B.IS_DEL(是否刪除)
				'From AUTT050 A,AUTC040 B 
				'Where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and A.FN_CD(功能代號)=B.FN_CD(功能代號) and 
				'A.Pkno=QUERY_COND(查詢條件) and A.GROUP_CODE(群組代碼)=QUERY_COND(查詢條件) and A.PROG_CD(程式代號)=QUERY_COND(查詢條件) and A.FN_CD(功能代號)=QUERY_COND(查詢條件)
								Dim	sql	As	StringBuilder		=	New StringBuilder()
        sql.Append( _
          "SELECT M.PKNO, M.ROWSTAMP, M.GROUP_CODE, M.PROG_CD, M.FN_CD, R1.FN_NM, R1.IS_DEL " & _
          "FROM AUTT050 M WITH(NOLOCK) " & _
          "INNER JOIN AUTC040 R1 WITH(NOLOCK) " & _
          "ON " & _
          "M.PROG_CD	=	R1.PROG_CD AND " & _
          "M.FN_CD	=	R1.FN_CD ")
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                sql.Append(" ORDER BY PROG_CD,FN_CD")

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

#Region "GetAUTT050 "
        ''' <summary>
        ''' GetAUTT050 
        ''' </summary>
        Public Function GetAUTT050() As DataTable
            Return Me.GetAUTT050(0, 0)
        End Function

        ''' <summary>
        ''' GetAUTT050 
        ''' </summary>      
        Public Function GetAUTT050(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.TableCoumnInfo = New ArrayList()
                'Me.TableCoumnInfo.Add(New String() {"M", "PKNO", "GROUP_CODE", "PROG_CD", "FN_CD"})

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)       '群組代碼
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)     '程式代號
                Me.ProcessQueryCondition(condition, "=", "FN_CD", Me.FN_CD)     '功能代號
                Me.SqlRetrictions = condition.ToString()

                Me.ParserAlias()

                '=== 處理說明 ===              
                Dim sql As StringBuilder = New StringBuilder()
                sql.Append(" SELECT M.*  ")
                sql.Append(" FROM AUTT050 M WITH(NOLOCK) ")

                If Me.SqlRetrictions.Length > 0 Then
                    sql.Append(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions).ToString.Replace("$.", ""))
                End If

                sql.Append(" ORDER BY PROG_CD,FN_CD")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region

    End Class
End NameSpace
 
