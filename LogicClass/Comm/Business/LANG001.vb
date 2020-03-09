'----------------------------------------------------------------------------------
'File Name		: PAT001
'Author			: nono
'Description		: Pattern Control �{��
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

		#Region "LANG001 PageLoad ������l"
		''' <summary>
		''' �j�w�U��
		''' </summary>
		Public Function GetLangListData() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGLIST.Query()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function

		''' <summary>
		''' �j�w�ʺA�U��
		''' </summary>
		Public Function GetPageNum() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGUAGE.GetDistinctPAGE_NM()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function

		''' <summary>
		''' �j�w�ʺA�U��
		''' </summary>
		Public Function GetPageMode() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Return Me.LANGUAGE.GetDistinctPAGE_MODE()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoAdd �B�z�s�W��ưʧ@"
		''' <summary>
		''' �B�z�s�W��ưʧ@
		''' </summary>
		Public Sub DoAdd()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== �]�w�B�z�s�W�ʧ@ ===
			Me.LANGUAGE.Insert()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region

		#Region "DoModifyQuery �i��s��d�߱a�X��ưʧ@"
		''' <summary>
		''' �i��s��d�߱a�X��ưʧ@
		''' </summary>
		Public Function DoModifyQuery() As DataTable
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== �a�X�s���� ===
			Return Me.LANGUAGE.Query()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoModify �B�z�ק��ưʧ@"
		''' <summary>
		''' �B�z�ק��ưʧ@
		''' </summary>
		Public Function DoModify() As Integer
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== �B�z�ק��ưʧ@ ===
			Return Me.LANGUAGE.Update()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoQuery �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function DoQuery()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			Dim	result	As	DataTable
			'=== �B�z���o�^�Ǹ�� ===
			result	=	Me.LANGUAGE.Query(Me.PageNo, Me.PageSize)
			Me.TotalRowCount	=	Me.LANGUAGE.TotalRowCount

			Return result
			
			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Function
		#End Region

		#Region "DoDelete �B�z�R����ưʧ@"
		''' <summary>
		''' �B�z�R����ưʧ@
		''' </summary>
		Public Sub DoDelete()
			Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

			'=== �R����� ===
			Me.LANGUAGE.Delete()

			Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
		End Sub
		#End Region
	End Class
End NameSpace

