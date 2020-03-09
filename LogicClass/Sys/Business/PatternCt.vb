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

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

NameSpace Sys.Business
	Public partial Class PatternCt
		Inherits Acer.Base.ControlBase

	#Region "�ݩ�"
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
		''' ���~�T��
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

	#Region "�غc�l"
		''' <summary>
		''' �غc�l
		''' </summary>
		''' <param name="dbManager">dbManager ����</param>
		''' <param name="logUtil">logUtil ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.SYST001	=	New SYST001(dbManager, logUtil)
		End Sub
	#End Region

	#Region "��k"
 		#Region "DoAdd �B�z�s�W��ưʧ@"
		''' <summary>
		''' �B�z�s�W��ưʧ@
		''' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �]�w�ݩʰѼ� ===
                Me.SYST001.DATEX = Me.DATEX
                Me.SYST001.CODE = Me.CODE
                Me.SYST001.NAME = Me.NAME

                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.SYST001.Insert()

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
		#End Region

		#Region "DoModify �B�z�ק��ưʧ@"
		''' <summary>
		''' �B�z�ק��ưʧ@
		''' </summary>
		Public Function DoModify() As Integer
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== �ˮ����_�l ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===

				'=== �]�w�ݩʰѼ� ===
				Me.SYST001.DATEX	=	Me.DATEX
				Me.SYST001.CODE		=	Me.CODE
				Me.SYST001.NAME		=	Me.NAME
				Me.SYST001.PKNO		=	Me.PKNO
				Me.SYST001.ROWSTAMP	=	Me.ROWSTAMP

				'=== �B�z�ק��ưʧ@ ===
				Dim	updateCount	=	Me.SYST001.UpdateByPkNo()

				'=== ���]����ݩ� ===
				Me.ResetColumnProperty()

				Return updateCount
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "AddQueryOr"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Sub AddQueryOr(ByVal methodName As String)
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
						
				'=== �B�z�d�߱��� ===
				ProcessCondition(methodName)

				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region

		#Region "ProcessCondition �B�z�d�߱���"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
        Private Overloads Sub ProcessCondition(ByVal methodName As String)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)

                Select Case methodName
                    Case "DoQuery"
                        '=== �B�z�d�߱��� ===
                        Dim condition As StringBuilder = New StringBuilder()
                        If Not Me.PKNO Is Nothing Then
                            condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                        End If
                        Me.ProcessQueryCondition(condition, "=", "CODE", Me.CODE)
                        Me.ProcessQueryCondition(condition, "=", "DATEX", Me.DATEX)

                        'Unicode���d��
                        If Not String.IsNullOrEmpty(Me.NAME) Then
                            condition.Append(" AND $.NAME LIKE N'%" & Me.NAME & "%' ")
                        End If

                        '=== �B�z�h�����d�߱��� ===
                        Me.ProcessQueryOrCondition(Me.TmpCondition, condition)

                        Exit Select
                End Select
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
		#End Region

		#Region "DoQuery �i��d�߰ʧ@"
		''' <summary>
		''' �i��d�߰ʧ@
		''' </summary>
		Public Function DoQuery() As DataTable
			Try
				Dim	result	As	DataTable

				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== �B�z�d�߱��� ===
				ProcessCondition("DoQuery")

				Me.SYST001.SqlRetrictions	=	Me.TmpCondition.ToString()
                Me.SYST001.OrderBys = "PKNO"

				'=== �B�z���o�^�Ǹ�� ===
				If Me.PageNo = 0 Then
					result	=	Me.SYST001.Query()
				Else
					result	=	Me.SYST001.Query(Me.PageNo, Me.PageSize)
					Me.TotalRowCount	=	Me.SYST001.TotalRowCount
				End If
				Me.TmpCondition.Length	=	0

				'=== ���]����ݩ� ===
				Me.ResetColumnProperty()

				Return result
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
		#End Region

		#Region "DoDelete �B�z�R����ưʧ@"
		''' <summary>
		''' �B�z�R����ưʧ@
		''' </summary>
		Public Sub DoDelete()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== �ˮ����_�l ===
				Dim	faileArguments	As	ArrayList	=	New ArrayList()
				If string.IsNullOrEmpty(Me.PKNO) Then
					faileArguments.Add("PKNO")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===

				'=== �]�w�ݩʰѼ� ===
				Me.SYST001.PKNO	=	Me.PKNO

				'=== �R����� ===
				Me.SYST001.DeleteByPkNo()

				'=== ���]����ݩ� ===
				Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
		#End Region
	#End Region
	End Class
End NameSpace

