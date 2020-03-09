'----------------------------------------------------------------------------------
'File Name		: EntSystemTask
'Author			: 
'Description		: EntSystemTask 系統作業ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/14	nono		Source Create
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
	'' EntSystemTask 系統作業ENT
	'' </summary>
	Public Class EntSystemTask 
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
			Me.TableName	=	"AUTC020"
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

		#Region "OPERATE_CD 作業代號"
		''' <summary>
		''' OPERATE_CD 作業代號
		''' </summary>
		Public Property OPERATE_CD As String
			Get
				Return Me.ColumnyMap("OPERATE_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OPERATE_CD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "OPERATE_LEVEL 作業層級"
		''' <summary>
		''' OPERATE_LEVEL 作業層級
		''' </summary>
		Public Property OPERATE_LEVEL As String
			Get
				Return Me.ColumnyMap("OPERATE_LEVEL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OPERATE_LEVEL")	=	value
			End Set
		End Property
		#End Region
		
		#Region "OPERATE_NM 作業名稱"
		''' <summary>
		''' OPERATE_NM 作業名稱
		''' </summary>
		Public Property OPERATE_NM As String
			Get
				Return Me.ColumnyMap("OPERATE_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OPERATE_NM")	=	value
			End Set
		End Property
		#End Region
		
		#Region "OPERATE_SORT 作業排序"
		''' <summary>
		''' OPERATE_SORT 作業排序
		''' </summary>
		Public Property OPERATE_SORT As String
			Get
				Return Me.ColumnyMap("OPERATE_SORT")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("OPERATE_SORT")	=	value
			End Set
		End Property
		#End Region
		
		#Region "SYS_CD 系統代號"
		''' <summary>
		''' SYS_CD 系統代號
		''' </summary>
		Public Property SYS_CD As String
			Get
				Return Me.ColumnyMap("SYS_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SYS_CD")	=	value
			End Set
		End Property
		#End Region
		
		#Region "UPPER_OPERATE_CD 上層作業代號"
		''' <summary>
		''' UPPER_OPERATE_CD 上層作業代號
		''' </summary>
		Public Property UPPER_OPERATE_CD As String
			Get
				Return Me.ColumnyMap("UPPER_OPERATE_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("UPPER_OPERATE_CD")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"
		#Region "GetSystemTask 取得系統作業 "
		''' <summary>
		''' 取得系統作業 
		''' </summary>
		Public Function GetSystemTask() As DataTable
			Return Me.GetSystemTask(0, 0)
		End Function
		
		''' <summary>
		''' 取得系統作業 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono Fix 取得 TotalRowCount 的 Bug
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetSystemTask(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				Me.TableCoumnInfo.Add(New String() {"AUTC020", "M", "PKNO", "SYS_CD", "OPERATE_CD", "UPPER_OPERATE_CD", "OPERATE_LEVEL"})
				'Me.TableCoumnInfo.Add(New String() {"AUTC010", "R1", "SEG"})
				
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",		Me.PKNO)		'PKNO
				Me.ProcessQueryCondition(condition, "=", "SYS_CD",		Me.SYS_CD)		'系統代號
				Me.ProcessQueryCondition(condition, "=", "OPERATE_CD",		Me.OPERATE_CD)		'作業代號
				Me.ProcessQueryCondition(condition, "=", "UPPER_OPERATE_CD",	Me.UPPER_OPERATE_CD)	'上層作業代號
				Me.ProcessQueryCondition(condition, "=", "OPERATE_LEVEL",	Me.OPERATE_LEVEL)	'作業層級

				Me.SqlRetrictions	=	condition.ToString()
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select A.Pkno,A.SYS_CD(系統代號),B.SYS_NM(系統名稱),A.OPERATE_CD(作業代號),A.OPERATE_NM(作業名稱),A.OPERATE_SORT(作業排序),A.UPPER_OPERATE_CD(上層作業代號),A.OPERATE_LEVEL(作業層級)
				'From AUTC020 A,AUTC010 B  
				'where A.SYS_CD(系統代號)=B.SYS_CD(系統代號) and 
				'A.Pkno=QUERY_COND(查詢條件) and A.SYS_CD(系統代號)=QUERY_COND(查詢條件) and A.OPERATE_CD(作業代號)=QUERY_COND(查詢條件) and A.UPPER_OPERATE_CD(上層作業代號)=QUERY_COND(查詢條件) 
				'and A.OPERATE_LEVEL(作業層級)=QUERY_COND(查詢條件) 
				'Order By A.OPERATE_SORT(作業排序)
				
				Dim sql As StringBuilder = New StringBuilder()
				sql.Append("SELECT M.PKNO, M.ROWSTAMP, M.SYS_CD, R1.SYS_NM, M.OPERATE_CD, M.OPERATE_NM, ")
				sql.Append("M.OPERATE_SORT, M.UPPER_OPERATE_CD, R2.OPERATE_NM AS UPPER_OPERATE_CD_NM, M.OPERATE_LEVEL ")
				sql.Append("FROM AUTC020 M WITH(NOLOCK) ")
				sql.Append("LEFT OUTER JOIN AUTC010 R1 WITH(NOLOCK) ON M.SYS_CD = R1.SYS_CD ")
				sql.Append("LEFT JOIN AUTC020 R2 WITH(NOLOCK) ON M.UPPER_OPERATE_CD = R2.OPERATE_CD AND M.SYS_CD = R2.SYS_CD ")
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.SYS_CD,M.OPERATE_SORT")
                Else
                    sql.Append(" ORDER BY SYS_CD,OPERATE_SORT")
                End If

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

		#Region "GetSystemTaskNmDDL 取得系統作業名稱下拉 "
		''' <summary>
		''' 取得系統作業名稱下拉 
		''' </summary>
		Public Function GetSystemTaskNmDDL() As DataTable
			Return Me.GetSystemTaskNmDDL(0, 0)
		End Function
		
		''' <summary>
		''' 取得系統作業名稱下拉 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetSystemTaskNmDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				'Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select distinct OPERATE_CD(作業代號) as value ,作業代號||作業名稱 as text From AUTC020 
				'Where SYS_CD(系統代號)=QUERY_COND(查詢條件)
				
				Dim	sql	As	StringBuilder		=	New StringBuilder()
                sql.Append( _
                 "SELECT OPERATE_CD + '-' + OPERATE_NM AS SELECT_TEXT, OPERATE_CD AS SELECT_VALUE " & _
                 "FROM AUTC020 ")
				If Not String.IsNullOrEmpty(Me.SYS_CD) Then
					sql.Append("WHERE " & _
						"SYS_CD	=	'" & Me.SYS_CD & "' " & _
						"ORDER BY OPERATE_CD")
				End If
					
				Dim	dt	As	DataTable	=	Me.QueryBySql(sql.ToString(), pageNo, pageSize)
				
				Me.ResetColumnProperty()
				
				Return dt
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region


	#End Region
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "OPERATE_SORT"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "OPERATE_SORT"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "OPERATE_SORT"
            Return MyBase.UpdateByPkNo()
        End Function
	End Class
End NameSpace
 
