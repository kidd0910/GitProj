'----------------------------------------------------------------------------------
'File Name		: EntColumnRange
'Author			: nono
'Description		: EntColumnRange 欄項範圍ENT
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
	'' EntColumnRange 欄項範圍ENT
	'' </summary>
	Public Class EntColumnRange 
		Inherits EntFunctionColumn
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
			Me.TableName	=	"AUTT060"
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
        Public Overloads Property DATA_FIELD_ENG() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_ENG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_ENG") = value
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
		
		#Region "FN_CD 功能代號"
		''' <summary>
		''' FN_CD 功能代號
		''' </summary>
        Public Overloads Property FN_CD() As String
            Get
                Return Me.ColumnyMap("FN_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FN_CD") = value
            End Set
        End Property
		#End Region
		
		#Region "GROUP_CODE 群組代碼"
		''' <summary>
		''' GROUP_CODE 群組代碼
		''' </summary>
        Public Overloads Property GROUP_CODE() As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
		#End Region
		
		#Region "PROG_CD 程式代號"
		''' <summary>
		''' PROG_CD 程式代號
		''' </summary>
        Public Overloads Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
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

				'=== 處理別名轉換 ===
				Me.TableCoumnInfo	=	New ArrayList()
				Me.TableCoumnInfo.Add(New String() {"AUTT010", "M", 	"PKNO", "GROUP_CODE", "PROG_CD", _
											"FN_CD", "DATA_FIELD_ENG"})
				Me.ParserAlias()

				
				'=== 處理說明 ===
				'Select A.Pkno,A.GROUP_CODE(群組代碼),A.PROG_CD(程式代號),A.FN_CD(功能代號),B.DATA_FIELD_CH(資料欄位中文名稱),A.DATA_FIELD_ENG(資料欄位英文名稱),A.DATA_RANGE_LABEL(資料範圍符號),
				'A.DATA_RANGE_VALUE(資料範圍值),A.SQL_VALUE(SQL值)
				'From AUTT060 A,AUTC050 B   
				'where A.DATA_FIELD_ENG(資料欄位英文名稱)=B.DATA_FIELD_ENG(資料欄位英文名稱) and 
				'A.Pkno=QUERY_COND(查詢條件) and A.群組代號=QUERY_COND(查詢條件) and A.PROG_CD(程式代號)=QUERY_COND(查詢條件) and A.FN_CD(功能代號)=QUERY_COND(查詢條件) 
				'and DATA_FIELD_ENG(資料欄位英文名稱)=QUERY_COND(查詢條件) 
				'Order By ,A.GROUP_CODE(群組代碼),A.PROG_CD(程式代號),A.FN_CD(功能代號),A.DATA_FIELD_ENG(資料欄位英文名稱)
				Dim	sql	As	StringBuilder		=	New StringBuilder()
        sql.Append( _
          "SELECT M.PKNO, M.ROWSTAMP, M.GROUP_CODE, M.PROG_CD, M.FN_CD, R1.DATA_FIELD_CH, " & _
          "M.DATA_FIELD_ENG, M.DATA_RANGE_LABEL, M.DATA_RANGE_VALUE, M.SQL_VALUE " & _
          "FROM AUTT060 M WITH(NOLOCK) " & _
          "INNER JOIN AUTC050 R1 WITH(NOLOCK) " & _
          "ON " & _
          "M.DATA_FIELD_ENG	=	R1.DATA_FIELD_ENG AND " & _
          "R1.CODE_TYPE		=	'1' ")
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.GROUP_CODE, M.PROG_CD, M.FN_CD, M.DATA_FIELD_ENG")
                Else
                    sql.Append(" ORDER BY GROUP_CODE, PROG_CD, FN_CD, DATA_FIELD_ENG")
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


	#End Region
		
	End Class
End NameSpace
 
