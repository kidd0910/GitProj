'ProductName                 : BTEV 
'File Name					 : CtSYST001 
'Description	             : CtSYST001 �{���˥�
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2016/11/16  auth      Source Create
'---------------------------------------------------------------------------

Imports Pat.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Pat.Business
    Partial Public Class CtSYST001
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        ''' <summary>
        ''' �غc�l
        ''' </summary>
        ''' <param name="dbManager">dbManager ����</param>
        ''' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_SYST001 = New Ent_SYST001(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "CODE �N�X"
        ''' <summary>
        ''' CODE �N�X
        ''' </summary>
        Public Property CODE() As String
            Get
                Return Me.PropertyMap("CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CODE") = value
            End Set
        End Property
#End Region

#Region "NAME �m�W"
        ''' <summary>
        ''' NAME �m�W
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.PropertyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NAME") = value
            End Set
        End Property
#End Region

#Region "DATEX PATTERN ���"
        ''' <summary>
        ''' DATEX PATTERN ���
        ''' </summary>
        Public Property DATEX() As String
            Get
                Return Me.PropertyMap("DATEX")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATEX") = value
            End Set
        End Property
#End Region

#Region "TAKE_TIME ��Үɶ�"
        ''' <summary>
        ''' TAKE_TIME ��Үɶ�
        ''' </summary>
        Public Property TAKE_TIME() As String
            Get
                Return Me.PropertyMap("TAKE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAKE_TIME") = value
            End Set
        End Property
#End Region

#Region "COLUMN_12 "
        ''' <summary>
        ''' COLUMN_12 
        ''' </summary>
        Public Property COLUMN_12() As String
            Get
                Return Me.PropertyMap("COLUMN_12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COLUMN_12") = value
            End Set
        End Property
#End Region

#Region "Ent_SYST001"
        ' <summary>Ent_SYST001</ summary>
        Private Property Ent_SYST001() As Ent_SYST001
            Get
                Return Me.PropertyMap("Ent_SYST001")
            End Get
            Set(ByVal value As Ent_SYST001)
                Me.PropertyMap("Ent_SYST001") = value
            End Set
        End Property
#End Region


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
                Me.Ent_SYST001.CODE = Me.CODE         '�N�X
                Me.Ent_SYST001.NAME = Me.NAME         '�m�W
                Me.Ent_SYST001.DATEX = Me.DATEX        'PATTERN ���
                Me.Ent_SYST001.TAKE_TIME = Me.TAKE_TIME        '��Үɶ�
                

                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_SYST001.Insert()

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
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �]�w�ݩʰѼ� ===
                Me.Ent_SYST001.CODE = Me.CODE         '�N�X
                Me.Ent_SYST001.NAME = Me.NAME         '�m�W
                Me.Ent_SYST001.DATEX = Me.DATEX        'PATTERN ���
                Me.Ent_SYST001.TAKE_TIME = Me.TAKE_TIME        '��Үɶ�
                 

                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_SYST001.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_SYST001.Update()

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()

                Return updateCount
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
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �]�w�ݩʰѼ� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.Ent_SYST001.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_SYST001.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_SYST001.Delete()
                End If

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()
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
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CODE", Me.CODE)        '�N�X
                Me.ProcessQueryCondition(condition, "%LIKE%", "NAME", Me.NAME)       '�m�W
                Me.ProcessQueryCondition(condition, "=", "DATEX", Me.DATEX)      'PATTERN ���
                Me.ProcessQueryCondition(condition, "=", "TAKE_TIME", Me.TAKE_TIME)      '��Үɶ�
                Me.ProcessQueryCondition(condition, "=", "COLUMN_12", Me.COLUMN_12)      '

                Me.Ent_SYST001.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_SYST001.OrderBys = "PKNO"
                Else
                    Me.Ent_SYST001.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_SYST001.Query()
                Else
                    result = Me.Ent_SYST001.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_SYST001.TotalRowCount
                End If

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

