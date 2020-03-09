'----------------------------------------------------------------------------------
'File Name		: PatternCt 
'Author			: nono
'Description		: PatternCt Control �{��
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

	#Region "�ݩ�"
		#Region "CLASSOBJ �����ݩ�"
		''' <summary>
		''' CLASSOBJ �����ݩ�
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

		#Region "CLASS_ATTR �����ݩ�"
		''' <summary>
		''' CLASS_ATTR �����ݩ�
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

		#Region "CLASS_OP �����ݩ�"
		''' <summary>
		''' CLASS_OP �����ݩ�
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

		#Region "CLASS_ASSO �����ݩ�"
		''' <summary>
		''' CLASS_ASSO �����ݩ�
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

		#Region "TEMP �]�w���Ȧs"
		''' <summary>
		''' CLASS_ASSO �����ݩ�
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

	#Region "�غc�l"
		''' <summary>
		''' �غc�l
		''' </summary>
		''' <param name="dbManager">dbManager ����</param>
		''' <param name="logUtil">logUtil ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)

			'=== ��l���ݩʪ��A ===
			Me.TEMP		=	False
			Me.CLASS_ATTR	=	New CLASS_ATTR(dbManager, logUtil)
			Me.CLASS_OP	=	New CLASS_OP(dbManager, logUtil)
			Me.CLASSOBJ	=	New CLASSOBJ(dbManager, logUtil)
			Me.CLASS_ASSO	=	New CLASS_ASSO(dbManager, logUtil)
		End Sub
	#End Region

	#Region "��k" 			
		#Region "QueryByPkNo �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryByPkNo() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �ˮ����_�l ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASSOBJ.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASSOBJ.QueryByPkNo()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryAttr �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryAttr() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASS_ATTR.AttrQuery()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryAttr �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryAttrBase() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASS_ATTR.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryOP �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryOP() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASS_OP.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryASSO �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryASSO() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASS_ASSO.Query1()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "QueryClass �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function QueryClass() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				Dim	result	As	DataTable

				'=== �B�z���o�^�Ǹ�� ===
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

		#Region "GetProjList ���o�M�ײM��U��"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function GetProjList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASSOBJ.ProjList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetVerList ���o Ver �U��"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function GetVerList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASSOBJ.VerList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetOPList ���o OP �U��"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function GetOPList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �ˮ����_�l ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASS_OP.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASS_OP.OPList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "GetSysList ���o�t�βM��U��"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function GetSysList() As DataTable
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

				'=== �ˮ����_�l ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.CLASSOBJ.PROJ_NM) Then
					faileArguments.Add("PROJ_NM")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===

				'=== �B�z���o�^�Ǹ�� ===
				Return Me.CLASSOBJ.SysList()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region
	#End Region
	End Class
End NameSpace

