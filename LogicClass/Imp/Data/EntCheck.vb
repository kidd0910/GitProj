'----------------------------------------------------------------------------------
'File Name		: EntCheck
'Author			: 
'Description		: EntCheck �ˮ�Ent
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/11/21			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Imp.Data
	'' <summary>
	'' EntCheck �ˮ�Ent
	'' </summary>
	Public Class EntCheck
		Inherits Acer.Base.EntityBase
		Implements Acer.Base.IEntityInterface

#Region "�غc�l"
		'' <summary>
		'' �غc�l/�B�z�ݩʹ����B�z
		'' </summary>
		'' <param name="dt">DataTable ����</param>
		Public Sub New(ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		'' <summary>
		'' �غc�l/�B�z���ʳB�z
		'' </summary>
		'' <param name="dbManager">DBManager ����</param>
		Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName = ""
			Me.SysName = "IMP"
            Me.ConnName = "TSBA"

			'=== ���p Class ===
			Me.IMP_FIELD = New Hashtable()
			'=== �B�z�O�W ===
		End Sub
#End Region

#Region "�ݩ�"
#Region "CHECK_ITEM_NAME �ˮֶ��ئW��"
		''' <summary>
		''' CHECK_ITEM_NAME �ˮֶ��ئW��
		''' </summary>
		Public Property CHECK_ITEM_NAME() As String
			Get
				Return Me.ColumnyMap("CHECK_ITEM_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CHECK_ITEM_NAME") = value
			End Set
		End Property
#End Region

#Region "IMP_FIELD[] �פJ����[]"
		''' <summary>
		''' IMP_FIELD[] �פJ����[]
		''' </summary>
		Public Property IMP_FIELD() As Hashtable
			Get
				Return Me.PropertyMap("IMP_FIELD")
			End Get
			Set(ByVal value As Hashtable)
				Me.PropertyMap("IMP_FIELD") = value
			End Set
		End Property
#End Region


#End Region

#Region "�ۭq��k"
#Region "ChkItem �ˮֶ��� "
		
		''' <summary>
		''' �ˮֶ��� 
		''' </summary>
		''' <remarks>
        ''' 0.0.1 �@�� �s�W��k
        ''' 0.0.2 KEN �s�W �ˬdú�O�b�� 2008/12/05
		''' </remarks>
		Public Function ChkItem() As String
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== �ˮ����_�l ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== �ˮֶ��ئW�� ===
				If String.IsNullOrEmpty(Me.CHECK_ITEM_NAME) Then
					faileArguments.Add("CHECK_ITEM_NAME")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
				End If
				'=== �ˮ���쵲�� ===


				Dim msgStr As String = ""

				'=== �ˮֶ��ئW�� ===
				Select Case Me.CHECK_ITEM_NAME
                    
                    Case "�פJ���ľ��c"
                        '�w��C����ƦA���B�z
                      
                End Select

				Me.ResetColumnProperty()

				Return msgStr
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "�ˮ�IP CheckIPAddress"
        ''' <summary>
        ''' �ˮֶ��� 
        ''' </summary>
        ''' 0.0.1 Shanlee �s�W��k
        Public Shared Function CheckIPAddress(ByVal IP As String) As Boolean
            Dim pattern As String = "(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))"
            Dim regex As New System.Text.RegularExpressions.Regex(pattern)
            If regex.Match(IP).Success Then
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#End Region

	End Class
End Namespace

