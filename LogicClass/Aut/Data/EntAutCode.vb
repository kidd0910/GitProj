'----------------------------------------------------------------------------------
'File Name		: EntAutCode
'Author			: 
'Description		: EntAutCode 權限代碼ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/16			Source Create
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
	'' EntAutCode 權限代碼ENT
	'' </summary>
	Public Class EntAutCode 
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
			Me.TableName	=	"AUTC050"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
		#Region "TOTAL_ROW_COUNT 總筆數"
		''' <summary>
		''' TOTAL_ROW_COUNT 總筆數
		''' </summary>
        Public Overloads Property TOTAL_ROW_COUNT() As Integer
            Get
                Return Me.PropertyMap("TOTAL_ROW_COUNT")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("TOTAL_ROW_COUNT") = value
            End Set
        End Property
		#End Region

		#Region "CODE_TYPE 代碼類別"
		''' <summary>
		''' CODE_TYPE 代碼類別
		''' </summary>
		Public Property CODE_TYPE As String
			Get
				Return Me.ColumnyMap("CODE_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CODE_TYPE")	=	value
			End Set
		End Property
		#End Region
		
		#Region "DATA_FIELD_CH 資料欄位中文名稱"
		''' <summary>
		''' DATA_FIELD_CH 資料欄位中文名稱
		''' </summary>
		Public Property DATA_FIELD_CH As String
			Get
				Return Me.ColumnyMap("DATA_FIELD_CH")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("DATA_FIELD_CH")	=	value
			End Set
		End Property
		#End Region
		
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
		
		#Region "NAME_FIELD 名稱欄位"
		''' <summary>
		''' NAME_FIELD 名稱欄位
		''' </summary>
		Public Property NAME_FIELD As String
			Get
				Return Me.ColumnyMap("NAME_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("NAME_FIELD")	=	value
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
		
		#Region "VALUE_FIELD 值欄位"
		''' <summary>
		''' VALUE_FIELD 值欄位
		''' </summary>
		Public Property VALUE_FIELD As String
			Get
				Return Me.ColumnyMap("VALUE_FIELD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("VALUE_FIELD")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"
		#Region "GetAllColumnDD 取得所有欄位資料 "
		''' <summary>
		''' 取得所有欄位資料 
		''' </summary>
		Public Function GetAllColumnDD() As DataTable
			Return Me.GetAllColumnDD(0, 0)
		End Function
		
		''' <summary>
		''' 取得所有欄位資料 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/16 新增方法
		''' </remarks>
		Public Function GetAllColumnDD(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "LIKE%", "COLUMN_NM",	Me.DATA_FIELD_CH)
				Me.ProcessQueryCondition(condition, "LIKE%", "COLUMN_CD",	Me.DATA_FIELD_ENG)

				Me.SqlRetrictions	=	condition.ToString()

				Me.TableCoumnInfo	=	New ArrayList()
				Me.TableCoumnInfo.Add(New String() {"COLUMNDD", "M", "COLUMN_CD", "COLUMN_NM"})
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select 資料項代號,資料項名稱
				'From COLUMNDD  
                'where 專案名稱='國防大學' and 資料項代號 like '查詢條件的資料欄位英文名稱%' and 
				'資料項名稱 like '查詢條件的資料欄位中文名稱%'
				'Order By 資料項代號
				
                Me.ConnName = "DATADICTIONARY"

				Dim	sql	As	StringBuilder		=	New StringBuilder()
                sql.Append( _
                 "SELECT COLUMN_NM AS DATA_FIELD_CH, COLUMN_CD AS DATA_FIELD_ENG " & _
                 "FROM COLUMNDD M " & _
                 "WHERE " & _
                 "PROJ_NM	=	'" & APConfig.GetProperty("DATA_PROJECT") & "' ")
				
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append(" AND " & Me.ProcessCondition(Me.SqlRetrictions))
				End If
                If pageNo = 0 Then
                    sql.Append("ORDER BY M.PKNO")
                Else
                    sql.Append("ORDER BY DATA_FIELD_ENG")
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

		#Region "GetFieldAllValue 取得欄位所有值 "
		''' <summary>
		''' 取得欄位所有值 
		''' </summary>
		Public Function GetFieldAllValue() As DataTable
			Return Me.GetFieldAllValue(0, 0)
		End Function
		
		''' <summary>
		''' 取得欄位所有值 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/19 新增方法
		''' </remarks>
		Public Function GetFieldAllValue(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				'SQL = "Select distinct "+NAME_FIELD(名稱欄位)+" as text,"+VALUE_FIELD(值欄位)+" as value " +
				'"From "+TABLE_NM(表格名稱)
								Dim	sql	As	StringBuilder		=	New StringBuilder()
				sql.Append( _
					"SELECT DISTINCT M." & Me.NAME_FIELD & " AS TEXT, M." & Me.VALUE_FIELD & " AS VALUE " & _
					"FROM " & Me.TABLE_NM & " M ")

                If pageNo = 0 Then
                    sql.Append("ORDER BY M.PKNO")
                Else
                    sql.Append("ORDER BY VALUE")
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

		#Region "GetGroupFieldDDL 取得群組欄位下拉 "
		''' <summary>
		''' 取得群組欄位下拉 
		''' </summary>
		Public Function GetGroupFieldDDL() As DataTable
			Return Me.GetGroupFieldDDL(0, 0)
		End Function
		
		''' <summary>
		''' 取得群組欄位下拉 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function GetGroupFieldDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				'Select distinct DATA_FIELD_CH(資料欄位中文名稱) as text,DATA_FIELD_ENG(資料欄位英文名稱) as value
				'From AUTC050  
				'where CODE_TYPE(代碼類別)='0' Order By FIELD_CODE(欄位代碼)
				
                Dim sql As String = _
                 "SELECT DISTINCT DATA_FIELD_ENG + '-' + DATA_FIELD_CH AS SELECT_TEXT, DATA_FIELD_ENG AS SELECT_VALUE " & _
                 "FROM AUTC050 " & _
                 "WHERE " & _
                 "CODE_TYPE	=	'0' " & _
                 "ORDER BY DATA_FIELD_ENG"
				
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql, pageNo, pageSize)
				
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetProgFieldDDL 取得程式欄位下拉 "
		''' <summary>
		''' 取得程式欄位下拉 
		''' </summary>
		Public Function GetProgFieldDDL() As DataTable
			Return Me.GetProgFieldDDL(0, 0)
		End Function
		
		''' <summary>
		''' 取得程式欄位下拉 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/20 新增方法
		''' </remarks>
		Public Function GetProgFieldDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				'Select distinct DATA_FIELD_CH(資料欄位中文名稱) as text,DATA_FIELD_ENG(資料欄位英文名稱) as value
				'From AUTC050  
				'where CODE_TYPE(代碼類別)='1' Order By FIELD_CODE(欄位代碼)
                Dim sql As String = _
                 "SELECT DISTINCT DATA_FIELD_ENG + '-' + DATA_FIELD_CH AS SELECT_TEXT, DATA_FIELD_ENG AS SELECT_VALUE " & _
                 "FROM AUTC050 " & _
                 "WHERE " & _
                 "CODE_TYPE	=	'1' " & _
                 "ORDER BY DATA_FIELD_ENG"
				
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql, pageNo, pageSize)
				
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