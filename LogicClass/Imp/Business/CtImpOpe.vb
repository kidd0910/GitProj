'----------------------------------------------------------------------------------
'File Name		: CtImpOpe 
'Author			: nono
'Description		: CtImpOpe 匯入作業Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/09/05	nono   		Source Create
'0.0.2		2008/11/14	nono		增加傳入固定欄位及參數, 可多筆
'----------------------------------------------------------------------------------

Imports Imp.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports System.IO
Imports comm.Business

NameSpace Imp.Business
	''' <summary>
	''' CtImpOpe 匯入作業Ct
	''' </summary>
	Public partial Class CtImpOpe
		Inherits Acer.Base.ControlBase

	#Region "屬性"
		#Region "ERROR_RESULT[] 錯誤結果[]"
		''' <summary>
		''' ERROR_RESULT[] 錯誤結果[]
		''' </summary>
		Public Property ERROR_RESULT As StringBuilder
			Get
				Return Me.PropertyMap("ERROR_RESULT")
			End Get
			Set(ByVal value As StringBuilder)
				Me.PropertyMap("ERROR_RESULT")	=	value
			End Set
		End Property
		#End Region
		
		#Region "IMP_FILE 匯入檔案"
		''' <summary>
		''' IMP_FILE 匯入檔案
		''' </summary>
		Public Property IMP_FILE As IO.FileInfo
			Get
				Return Me.PropertyMap("EXP_FILE")
			End Get
			Set(ByVal value As IO.FileInfo)
				Me.PropertyMap("EXP_FILE")	=	value
			End Set
		End Property
		#End Region
		
		#Region "IMP_OPERATE_PROG 匯入作業程式代號"
		''' <summary>
		''' IMP_OPERATE_PROG 匯入作業程式代號
		''' </summary>
		Public Property IMP_OPERATE_PROG As String
			Get
				Return Me.PropertyMap("IMP_OPERATE_PROG")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("IMP_OPERATE_PROG")	=	value
			End Set
		End Property
		#End Region

		#Region "STATIC_COLUMN_DATA 固定欄位資訊"
		''' <summary>
		''' STATIC_COLUMN_DATA 固定欄位資訊
		''' </summary>
		Public Property STATIC_COLUMN_DATA As String
			Get
				Return Me.PropertyMap("STATIC_COLUMN_DATA")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("STATIC_COLUMN_DATA")	=	value
			End Set
		End Property
		#End Region

		#Region "VALID_COLUMN_DATA 檢核欄位資訊"
		''' <summary>
		''' VALID_COLUMN_DATA 檢核欄位資訊
		''' </summary>
		Public Property VALID_COLUMN_DATA As String
			Get
				Return Me.PropertyMap("VALID_COLUMN_DATA")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("VALID_COLUMN_DATA")	=	value
			End Set
		End Property
		#End Region

		#Region "TRADE_FAILURE_ISROLLBACK  交易失敗是否rollback "
		''' <summary>
		'''TRADE_FAILURE_ISROLLBACK  交易失敗是否rollback 
		''' </summary>
		Public Property TRADE_FAILURE_ISROLLBACK As String
			Get
				Return Me.PropertyMap("TRADE_FAILURE_ISROLLBACK")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("TRADE_FAILURE_ISROLLBACK")	=	value
			End Set
		End Property
		#End Region

		#Region "SUCESS_COUNT 成功筆數"
		''' <summary>
		''' SUCESS_COUNT 成功筆數"
		''' </summary>
		Public Property SUCESS_COUNT As Integer
			Get
				Return Me.PropertyMap("SUCESS_COUNT")
			End Get
			Set(ByVal value As Integer)
				Me.PropertyMap("SUCESS_COUNT")	=	value
			End Set
		End Property
		#End Region

		#Region "FAILE_COUNT 失敗筆數"
		''' <summary>
		''' FAILE_COUNT 失敗筆數"
		''' </summary>
		Public Property FAILE_COUNT As Integer
			Get
				Return Me.PropertyMap("FAILE_COUNT")
			End Get
			Set(ByVal value As Integer)
				Me.PropertyMap("FAILE_COUNT")	=	value
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
			
			Me.ERROR_RESULT	=	New StringBuilder()
			'=== 關聯 Class ===

		End Sub
	#End Region

	#Region "方法"
		#Region "GetCsvFileName 取得範本檔名"
		''' <summary>
		''' 取得範本檔名 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetCsvFileName() As String
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				'=== 匯入作業程式代號 ===
				If string.IsNullOrEmpty(Me.IMP_OPERATE_PROG) Then
					faileArguments.Add("IMP_OPERATE_PROG")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'set 
				'EntImpCom_匯入共用檔ENT.程式代號=程式代號
				'EntImpCom_匯入共用檔ENT.FILE_NAME(檔案名稱)=FILE_NAME(檔案名稱)
				'
				'EntImpCom_匯入共用檔ENT.GetTableSample_取得檔案格式範本()()

				Dim	ent	As	EntImpCom	=	New EntImpCom(Me.DBManager, Me.LogUtil)
				ent.IMP_OPERATE_PROG = Me.IMP_OPERATE_PROG
				Dim result As String = ent.GetTableSample().Rows(0)("DNLD_MODEL_FILE_NAME").ToString

				Me.ResetColumnProperty()

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetTableSample 取得檔案格式範本"
		''' <summary>
		''' 取得檔案格式範本 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetTableSample() As String
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				'=== 匯入作業程式代號 ===
				If string.IsNullOrEmpty(Me.IMP_OPERATE_PROG) Then
					faileArguments.Add("IMP_OPERATE_PROG")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'set 
				'EntImpCom_匯入共用檔ENT.程式代號=程式代號
				'EntImpCom_匯入共用檔ENT.FILE_NAME(檔案名稱)=FILE_NAME(檔案名稱)
				'
				'EntImpCom_匯入共用檔ENT.GetTableSample_取得檔案格式範本()()

				Dim	ent	As	EntImpCom	=	New EntImpCom(Me.DBManager, Me.LogUtil)
				ent.IMP_OPERATE_PROG = Me.IMP_OPERATE_PROG
				Dim result As String = ent.GetTableSample().Rows(0)("CH_HEADED").ToString

				Me.ResetColumnProperty()

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "ImpData 匯入資料"
		''' <summary>/
		''' 匯入資料 
		''' </summary>
		''' <remarks>
		''' 0.0.2 nono 2009/03/18 增加回傳成功及失敗筆數
		''' 0.0.1 nono 新增方法
		''' </remarks>
		Public Sub ImpData()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				'=== 匯入作業程式代號 ===
				If string.IsNullOrEmpty(Me.IMP_OPERATE_PROG) Then
					faileArguments.Add("IMP_OPERATE_PROG")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'set 
				'EntImpCom_匯入共用檔ENT.程式代號=程式代號
				'EntImpCom_匯入共用檔ENT.FILE_NAME(檔案名稱)=FILE_NAME(檔案名稱)
				'
				'EntImpCom_匯入共用檔ENT.ImpData_匯入資料()
				Dim	ent	As	EntImpCom	=	New EntImpCom(Me.DBManager, Me.LogUtil)
				ent.IMP_FILE		=	Me.IMP_FILE
				ent.STATIC_COLUMN_DATA	=	Me.STATIC_COLUMN_DATA
				ent.VALID_COLUMN_DATA	=	Me.VALID_COLUMN_DATA
				ent.IMP_OPERATE_PROG	=	Me.IMP_OPERATE_PROG
				ent.USE_ID		=	SessionClass.登入帳號
				ent.ImpData()

				Me.TRADE_FAILURE_ISROLLBACK	=	ent.TRADE_FAILURE_ISROLLBACK
				Me.SUCESS_COUNT			=	ent.SUCESS_COUNT
				Me.FAILE_COUNT			=	ent.FAILE_COUNT

				Me.ERROR_RESULT			=	ent.ERROR_RESULT
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region
#End Region

	End Class
End NameSpace

