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

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

NameSpace Sys.Business
	Public partial Class PatternCt
		Inherits Acer.Base.ControlBase

	#Region "屬性"
		#Region "CODE"
		''' <summary>
		''' CODE
		''' </summary>
		Public Property CODE As String
			Get
				Return Me.PropertyMap("CODE")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("CODE")	=	value
			End Set
		End Property
		#End Region

		#Region "NAME"
		''' <summary>
		''' NAME
		''' </summary>
		Public Property NAME As String
			Get
				Return Me.PropertyMap("NAME")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("NAME")	=	value
			End Set
		End Property
		#End Region

		#Region "DATEX"
		''' <summary>
		''' DATEX
		''' </summary>
		Public Property DATEX As String
			Get
				Return Me.PropertyMap("DATEX")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("DATEX")	=	value
			End Set
		End Property
		#End Region

		Private Property SYST001 As SYST001
			Get
				Return Me.PropertyMap("SYST001")
			End Get
			Set(ByVal value As SYST001)
				Me.PropertyMap("SYST001")	=	value
			End Set
		End Property

		''' <summary>
		''' 錯誤訊息
		''' </summary>
		Public Property ErrCode As Message
			Get
				Return Me.PropertyMap("Message")
			End Get
			Set(ByVal value As Message)
				Me.PropertyMap("Message")	=	value
			End Set
		End Property
	#End Region

	#Region "建構子"
		''' <summary>
		''' 建構子
		''' </summary>
		''' <param name="dbManager">dbManager 物件</param>
		''' <param name="logUtil">logUtil 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.SYST001	=	New SYST001(dbManager, logUtil)
		End Sub
	#End Region

	#Region "方法"
 		#Region "DoAdd 處理新增資料動作"
		''' <summary>
		''' 處理新增資料動作
		''' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 設定屬性參數 ===
                Me.SYST001.DATEX = Me.DATEX
                Me.SYST001.CODE = Me.CODE
                Me.SYST001.NAME = Me.NAME

                '=== 設定處理新增動作 ===
                Dim result As String = Me.SYST001.Insert()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
		#End Region

		#Region "DoModify 處理修改資料動作"
		''' <summary>
		''' 處理修改資料動作
		''' </summary>
		Public Function DoModify() As Integer
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 設定屬性參數 ===
				Me.SYST001.DATEX	=	Me.DATEX
				Me.SYST001.CODE		=	Me.CODE
				Me.SYST001.NAME		=	Me.NAME
				Me.SYST001.PKNO		=	Me.PKNO
				Me.SYST001.ROWSTAMP	=	Me.ROWSTAMP

				'=== 處理修改資料動作 ===
				Dim	updateCount	=	Me.SYST001.UpdateByPkNo()

				'=== 重設欄位屬性 ===
				Me.ResetColumnProperty()

				Return updateCount
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "AddQueryOr"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Sub AddQueryOr(ByVal methodName As String)
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
						
				'=== 處理查詢條件 ===
				ProcessCondition(methodName)

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "ProcessCondition 處理查詢條件"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
        Private Overloads Sub ProcessCondition(ByVal methodName As String)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                Select Case methodName
                    Case "DoQuery"
                        '=== 處理查詢條件 ===
                        Dim condition As StringBuilder = New StringBuilder()
                        If Not Me.PKNO Is Nothing Then
                            condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                        End If
                        Me.ProcessQueryCondition(condition, "=", "CODE", Me.CODE)
                        Me.ProcessQueryCondition(condition, "=", "DATEX", Me.DATEX)

                        'Unicode欄位查詢
                        If Not String.IsNullOrEmpty(Me.NAME) Then
                            condition.Append(" AND $.NAME LIKE N'%" & Me.NAME & "%' ")
                        End If

                        '=== 處理多筆的查詢條件 ===
                        Me.ProcessQueryOrCondition(Me.TmpCondition, condition)

                        Exit Select
                End Select
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
		#End Region

		#Region "DoQuery 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function DoQuery() As DataTable
			Try
				Dim	result	As	DataTable

				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 處理查詢條件 ===
				ProcessCondition("DoQuery")

				Me.SYST001.SqlRetrictions	=	Me.TmpCondition.ToString()
                Me.SYST001.OrderBys = "PKNO"

				'=== 處理取得回傳資料 ===
				If Me.PageNo = 0 Then
					result	=	Me.SYST001.Query()
				Else
					result	=	Me.SYST001.Query(Me.PageNo, Me.PageSize)
					Me.TotalRowCount	=	Me.SYST001.TotalRowCount
				End If
				Me.TmpCondition.Length	=	0

				'=== 重設欄位屬性 ===
				Me.ResetColumnProperty()

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "DoDelete 處理刪除資料動作"
		''' <summary>
		''' 處理刪除資料動作
		''' </summary>
		Public Sub DoDelete()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===

				'=== 設定屬性參數 ===
				Me.SYST001.PKNO	=	Me.PKNO

				'=== 刪除資料 ===
				Me.SYST001.DeleteByPkNo()

				'=== 重設欄位屬性 ===
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region
	#End Region
	End Class
End NameSpace

