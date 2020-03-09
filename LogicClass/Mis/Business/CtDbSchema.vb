'----------------------------------------------------------------------------------
'File Name		: CtDbSchema 
'Author			: Brian Chou
'Description		: CtDbSchema DBSchema匯出ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/07	Brian Chou   	Source Create
'----------------------------------------------------------------------------------

Imports Mis.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Mis.Business
	''' <summary>
	''' CtDbSchema DBSchema匯出ct
	''' </summary>
	Partial Public Class CtDbSchema
		Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "OWNER OWNER"
		''' <summary>
		''' OWNER OWNER
		''' </summary>
		Public Property OWNER() As String
			Get
				Return Me.PropertyMap("OWNER")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("OWNER") = value
			End Set
		End Property
#End Region

#Region "TABLE_NAME 表格名稱"
		''' <summary>
		''' TABLE_NAME 表格名稱
		''' </summary>
		Public Property TABLE_NAME() As String
			Get
				Return Me.PropertyMap("TABLE_NAME")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("TABLE_NAME") = value
			End Set
		End Property
#End Region

#Region "TABLE_COMMENTS 表格說明"
		''' <summary>
		''' TABLE_COMMENTS 表格說明
		''' </summary>
		Public Property TABLE_COMMENTS() As String
			Get
				Return Me.PropertyMap("TABLE_COMMENTS")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("TABLE_COMMENTS") = value
			End Set
		End Property
#End Region

#Region "DB_TYPE 資料庫類型(Oracle / SQL)"
        ''' <summary>
        ''' DB_TYPE 資料庫類型
        ''' </summary>
        Public Property DB_TYPE() As String
            Get
                Return Me.PropertyMap("DB_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DB_TYPE") = value
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
		Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)

			'=== 關聯 Class ===

		End Sub
#End Region

#Region "方法"

#Region "GetDBTable 取得DBTable"
		''' <summary>
		''' 取得DBTable
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetDBTable() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntDbSchema = new EntDbSchema()
				'return EntDbSchema.GetDbTable_取得Table()

				Dim aEntDbSchema As New EntDbSchema(Me.DBManager, Me.LogUtil)

				aEntDbSchema.OWNER = Me.OWNER
				aEntDbSchema.TABLE_NAME = Me.TABLE_NAME
				aEntDbSchema.TABLE_COMMENTS = Me.TABLE_COMMENTS
				aEntDbSchema.DB_TYPE = Me.DB_TYPE

				Dim result As DataTable

				If Me.PageNo = 0 Then
					result = aEntDbSchema.GetDbTable
				Else
					result = aEntDbSchema.GetDbTable(Me.PageNo, Me.PageSize)
					Me.TotalRowCount = aEntDbSchema.TotalRowCount
				End If

				Me.ResetColumnProperty()

				Return result

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "GetFieldNoCommentTable 取得DBTable"
        ''' <summary>
        ''' 取得Field No Comment 的Table
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetFieldNoCommentTable() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntDbSchema = new EntDbSchema()
                'return EntDbSchema.GetDbTable_取得Table()

                Dim aEntDbSchema As New EntDbSchema(Me.DBManager, Me.LogUtil)

                aEntDbSchema.OWNER = Me.OWNER
                aEntDbSchema.TABLE_NAME = Me.TABLE_NAME
                aEntDbSchema.TABLE_COMMENTS = Me.TABLE_COMMENTS

                Dim result As DataTable

                If Me.PageNo = 0 Then
                    result = aEntDbSchema.GetFieldNoCommentTable
                Else
                    result = aEntDbSchema.GetFieldNoCommentTable(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = aEntDbSchema.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetDBSchema 取得GetDBSchema"
		''' <summary>
		''' 取得GetDBSchema
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetDBSchema() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntDbSchema = new EntDbSchema()
				'return EntDbSchema.GetDbTable_取得Table()

				Dim aEntDbSchema As New EntDbSchema(Me.DBManager, Me.LogUtil)

				aEntDbSchema.OWNER = Me.OWNER
				aEntDbSchema.TABLE_NAME = Me.TABLE_NAME
                aEntDbSchema.DB_TYPE = Me.DB_TYPE

				Dim result As DataTable

				result = aEntDbSchema.GetDBSchema

				Me.ResetColumnProperty()

				Return result

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "GetDBTableIndex 取得GetDBTableIndex"
		''' <summary>
		''' 取得GetDBTableIndex
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetDBTableIndex() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntDbSchema = new EntDbSchema()
				'return EntDbSchema.GetDbTable_取得Table()

				Dim aEntDbSchema As New EntDbSchema(Me.DBManager, Me.LogUtil)

				aEntDbSchema.OWNER = Me.OWNER
                aEntDbSchema.TABLE_NAME = Me.TABLE_NAME
                aEntDbSchema.DB_TYPE = Me.DB_TYPE

				Dim result As DataTable

				result = aEntDbSchema.GetDBTableIndex

				Me.ResetColumnProperty()

				Return result

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "GetDBTableComments 取得GetDBTableComments"
		''' <summary>
		''' 取得GetDBTableComments
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Function GetDBTableComments() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 處理說明 ===
				'EntDbSchema = new EntDbSchema()
				'return EntDbSchema.GetDbTable_取得Table()

				Dim aEntDbSchema As New EntDbSchema(Me.DBManager, Me.LogUtil)

				aEntDbSchema.OWNER = Me.OWNER
				aEntDbSchema.TABLE_NAME = Me.TABLE_NAME
                aEntDbSchema.DB_TYPE = Me.DB_TYPE

				Dim result As DataTable

				result = aEntDbSchema.GetDBTableComments

				Me.ResetColumnProperty()

				Return result

			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region


#End Region
	End Class
End Namespace


