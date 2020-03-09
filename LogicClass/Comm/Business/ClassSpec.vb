'----------------------------------------------------------------------------------
'File Name		: PatternCt 
'Author			: nono
'Description		: PatternCt Control 程式
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/05/01	nono    	Source Create
'----------------------------------------------------------------------------------

Imports Comm.Data
Imports Acer.Util
Imports Acer.Log
Imports Acer.DB
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

NameSpace Comm.Business
	Public partial Class ClassSpec
		Inherits Acer.Base.ControlBase

	#Region "屬性"
		#Region "CLASSOBJ 物件屬性"
		''' <summary>
		''' CLASSOBJ 物件屬性
		''' </summary>
		Public Property CLASSOBJ As CLASSOBJ
			Get
				Return Me.PropertyMap("CLASSOBJ")
			End Get
			Set(ByVal value As CLASSOBJ)
				Me.PropertyMap("CLASSOBJ")	=	value
			End Set
		End Property
		#End Region

		#Region "CLASS_ATTR 物件屬性"
		''' <summary>
		''' CLASS_ATTR 物件屬性
		''' </summary>
		Public Property CLASS_ATTR As CLASS_ATTR
			Get
				Return Me.PropertyMap("CLASS_ATTR")
			End Get
			Set(ByVal value As CLASS_ATTR)
				Me.PropertyMap("CLASS_ATTR")	=	value
			End Set
		End Property
		#End Region

		#Region "CLASS_OP 物件屬性"
		''' <summary>
		''' CLASS_OP 物件屬性
		''' </summary>
		Public Property CLASS_OP As CLASS_OP
			Get
				Return Me.PropertyMap("CLASS_OP")
			End Get
			Set(ByVal value As CLASS_OP)
				Me.PropertyMap("CLASS_OP")	=	value
			End Set
		End Property
		#End Region

		#Region "CLASS_ASSO 物件屬性"
		''' <summary>
		''' CLASS_ASSO 物件屬性
		''' </summary>
		Public Property CLASS_ASSO As CLASS_ASSO
			Get
				Return Me.PropertyMap("CLASS_ASSO")
			End Get
			Set(ByVal value As CLASS_ASSO)
				Me.PropertyMap("CLASS_ASSO")	=	value
			End Set
		End Property
		#End Region

		#Region "TEMP 設定為暫存"
		''' <summary>
		''' CLASS_ASSO 物件屬性
		''' </summary>
		Public Property TEMP As Boolean
			Get
				Return Me.PropertyMap("TEMP")
			End Get
			Set(ByVal value As Boolean)
				Me.PropertyMap("TEMP")	=	value
			End Set
		End Property
		#End Region
	#End Region

	#Region "建構子"
		''' <summary>
		''' 建構子
		''' </summary>
		''' <param name="dbManager">dbManager 物件</param>
		''' <param name="logUtil">logUtil 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)

			'=== 初始話屬性狀態 ===
			Me.TEMP		=	False
			Me.CLASS_ATTR	=	New CLASS_ATTR(dbManager, logUtil)
			Me.CLASS_OP	=	New CLASS_OP(dbManager, logUtil)
			Me.CLASSOBJ	=	New CLASSOBJ(dbManager, logUtil)
			Me.CLASS_ASSO	=	New CLASS_ASSO(dbManager, logUtil)
		End Sub
	#End Region

	#Region "方法" 			
		#Region "QueryByPkNo 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryByPkNo() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASSOBJ.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理取得回傳資料 ===
				Return Me.CLASSOBJ.QueryByPkNo()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryAttr 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryAttr() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASS_ATTR.AttrQuery()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryAttr 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryAttrBase() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASS_ATTR.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryOP 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryOP() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASS_OP.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryASSO 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryASSO() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASS_ASSO.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryClass 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function QueryClass() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	result	As	DataTable

				'=== 處理取得回傳資料 ===
				If Me.PageNo = 0 Then
					result			=	Me.CLASSOBJ.Query1()
				Else
					result			=	Me.CLASSOBJ.GetNewerClass(Me.PageNo, Me.PageSize)
					Me.TotalRowCount	=	Me.CLASSOBJ.TotalRowCount
				End If

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetProjList 取得專案清單下拉"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function GetProjList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASSOBJ.ProjList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetVerList 取得 Ver 下拉"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function GetVerList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 處理取得回傳資料 ===
				Return Me.CLASSOBJ.VerList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetOPList 取得 OP 下拉"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function GetOPList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASS_OP.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理取得回傳資料 ===
				Return Me.CLASS_OP.OPList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetSysList 取得系統清單下拉"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function GetSysList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASSOBJ.PROJ_NM) Then
					faileArguments.Add("PROJ_NM")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理取得回傳資料 ===
				Return Me.CLASSOBJ.SysList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region
	#End Region
	End Class
End NameSpace

