'----------------------------------------------------------------------------------
'File Name		: PAT001
'Author			: nono
'Description		: Pattern Control 程式
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/05/01	nono    	Source Create
'----------------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Form
Imports System.Reflection.MethodBase

NameSpace Comm.Business
	Public partial Class MultiLanguage
		Inherits Acer.Base.ControlBase

		#Region "LANG001 PageLoad 頁面初始"
		''' <summary>
		''' 綁定下拉
		''' </summary>
		Public Function GetLangListData() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGLIST.Query()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function

		''' <summary>
		''' 綁定動態下拉
		''' </summary>
		Public Function GetPageNum() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGUAGE.GetDistinctPAGE_NM()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function

		''' <summary>
		''' 綁定動態下拉
		''' </summary>
		Public Function GetPageMode() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGUAGE.GetDistinctPAGE_MODE()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoAdd 處理新增資料動作"
		''' <summary>
		''' 處理新增資料動作
		''' </summary>
		Public Sub DoAdd()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== 設定處理新增動作 ===
			Me.LANGUAGE.Insert()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region

		#Region "DoModifyQuery 進行編輯查詢帶出資料動作"
		''' <summary>
		''' 進行編輯查詢帶出資料動作
		''' </summary>
		Public Function DoModifyQuery() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== 帶出編輯資料 ===
			Return Me.LANGUAGE.Query()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoModify 處理修改資料動作"
		''' <summary>
		''' 處理修改資料動作
		''' </summary>
		Public Function DoModify() As Integer
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== 處理修改資料動作 ===
			Return Me.LANGUAGE.Update()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoQuery 進行查詢動作"
		''' <summary>
		''' 進行查詢動作
		''' </summary>
		Public Function DoQuery()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Dim	result	As	DataTable
			'=== 處理取得回傳資料 ===
			result	=	Me.LANGUAGE.Query(Me.PageNo, Me.PageSize)
			Me.TotalRowCount	=	Me.LANGUAGE.TotalRowCount

			Return result
			
			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoDelete 處理刪除資料動作"
		''' <summary>
		''' 處理刪除資料動作
		''' </summary>
		Public Sub DoDelete()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== 刪除資料 ===
			Me.LANGUAGE.Delete()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region
	End Class
End NameSpace

