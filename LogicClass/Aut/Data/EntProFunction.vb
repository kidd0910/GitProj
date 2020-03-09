'----------------------------------------------------------------------------------
'File Name		: EntProFunction
'Author			: nono
'Description		: EntProFunction 程式功能ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/17	nono		Source Create
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
	'' EntProFunction 程式功能ENT
	'' </summary>
	Public Class EntProFunction 
		Inherits EntSysProgram
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
			Me.TableName	=	"AUTC040"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
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
		
		#Region "FN_NM 功能名稱"
		''' <summary>
		''' FN_NM 功能名稱
		''' </summary>
		Public Property FN_NM As String
			Get
				Return Me.ColumnyMap("FN_NM")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("FN_NM")	=	value
			End Set
		End Property
		#End Region
		
		#Region "IS_DEL 是否刪除"
		''' <summary>
		''' IS_DEL 是否刪除
		''' </summary>
		Public Property IS_DEL As String
			Get
				Return Me.ColumnyMap("IS_DEL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_DEL")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"
		#Region "GetProFunction 取得程式功能 "
		''' <summary>
		''' 取得程式功能 
		''' </summary>
		Public Function GetProFunction() As DataTable
			Return Me.GetProFunction(0, 0)
		End Function
		
		''' <summary>
		''' 取得程式功能 
		''' </summary>
		''' <remarks>
		''' 0.0.1 nono 2009/03/17 新增方法
		''' </remarks>
		Public Function GetProFunction(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
				Me.TableCoumnInfo.Add(New String() {"AUTC040", "M",	"PKNO", "PROG_CD", "FN_CD", "IS_DEL"})
				
				Dim	condition	As	StringBuilder	=	New StringBuilder()
				Me.ProcessQueryCondition(condition, "=", "PKNO",		Me.PKNO)		'PKNO
				Me.ProcessQueryCondition(condition, "=", "PROG_CD",		Me.PROG_CD)		'程式代號
				Me.ProcessQueryCondition(condition, "=", "FN_CD",		Me.FN_CD)		'功能代號
				Me.ProcessQueryCondition(condition, "=", "IS_DEL",		Me.IS_DEL)		'是否刪除

				Me.SqlRetrictions	=	condition.ToString()
				Me.ParserAlias()
				
				'=== 處理說明 ===
				'Select A.Pkno,A.PROG_CD(程式代號),A.PROG_NM(程式名稱),A.FN_CD(功能代號),A.FN_NM(功能名稱),A.IS_DEL(是否刪除)
				'From AUTC040 A,AUTC030 B 
				'where A.PROG_CD(程式代號)=B.PROG_CD(程式代號) and 
				'Pkno=QUERY_COND(查詢條件) and PROG_CD(程式代號)=QUERY_COND(查詢條件) and FN_CD(功能代號)=QUERY_COND(查詢條件) and IS_DEL(是否刪除)=QUERY_COND(查詢條件)
				
				Dim	sql	As	StringBuilder		=	New StringBuilder()
				sql.Append( _
					"SELECT M.PKNO, M.ROWSTAMP, M.PROG_CD, R1.PROG_NM, M.FN_CD, M.FN_NM, M.IS_DEL " & _
					"FROM AUTC040 M WITH(NOLOCK) " & _
					"INNER JOIN AUTC030 R1 WITH(NOLOCK) " & _
					"ON " & _
					"M.PROG_CD	=	R1.PROG_CD ")
				If Me.SqlRetrictions.Length > 0 Then
					sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If
                If pageNo = 0 Then
                    sql.Append("ORDER BY M.PROG_CD,M.FN_CD")
                Else
                    sql.Append("ORDER BY PROG_CD,FN_CD")
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
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "END_MANUAL,BEGIN_MANUAL,END_OUTSIDE,BEGIN_OUTSIDE,END_OUT,BEGIN_OUT,END_OVER,BEGIN_OVER,BEGIN_TIME,END_TIME"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "END_MANUAL,BEGIN_MANUAL,END_OUTSIDE,BEGIN_OUTSIDE,END_OUT,BEGIN_OUT,END_OVER,BEGIN_OVER,BEGIN_TIME,END_TIME"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "END_MANUAL,BEGIN_MANUAL,END_OUTSIDE,BEGIN_OUTSIDE,END_OUT,BEGIN_OUT,END_OVER,BEGIN_OVER,BEGIN_TIME,END_TIME"
            Return MyBase.UpdateByPkNo()
        End Function
	End Class
End NameSpace