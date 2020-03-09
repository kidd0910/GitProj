'ProductName                 : TSBA 
'File Name					 : CtAPPL022 
'Description	             : CtAPPL022 CtAPPL022 ����D��
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2018/02/02  �t�κ޲z��      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL022
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL022 = New ENT_APPL022(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��"
        '' <summary>
        '' CASE_NO �ץ�s��
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "RCV_NO ���帹"
        '' <summary>
        '' RCV_NO ���帹
        '' </summary>
        Public Property RCV_NO() As String
            Get
                Return Me.PropertyMap("RCV_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_NO") = value
            End Set
        End Property
#End Region

#Region "DEADLINE ������"
        '' <summary>
        '' DEADLINE ������
        '' </summary>
        Public Property DEADLINE() As String
            Get
                Return Me.PropertyMap("DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE") = value
            End Set
        End Property
#End Region

#Region "DEPID �ӿ���N�X"
        '' <summary>
        '' DEPID �ӿ���N�X
        '' </summary>
        Public Property DEPID() As String
            Get
                Return Me.PropertyMap("DEPID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEPID") = value
            End Set
        End Property
#End Region

#Region "RCV_DATE ������"
        '' <summary>
        '' RCV_DATE ������
        '' </summary>
        Public Property RCV_DATE() As String
            Get
                Return Me.PropertyMap("RCV_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_DATE") = value
            End Set
        End Property
#End Region

#Region "RCV_TMEME �D��"
        '' <summary>
        '' RCV_TMEME �D��
        '' </summary>
        Public Property RCV_TMEME() As String
            Get
                Return Me.PropertyMap("RCV_TMEME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_TMEME") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ �ɥ�����"
        '' <summary>
        '' CASE_SEQ �ɥ�����
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.PropertyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL022"
        ' <summary>Ent_APPL022</ summary>
        Private Property Ent_APPL022() As ENT_APPL022
            Get
                Return Me.PropertyMap("Ent_APPL022")
            End Get
            Set(ByVal value As ENT_APPL022)
                Me.PropertyMap("Ent_APPL022") = value
            End Set
        End Property
#End Region


#End Region

#Region "��k"
#Region "DoAdd �B�z�s�W��ưʧ@"
        '' <summary>
        '' �B�z�s�W��ưʧ@
        '' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �]�w�ݩʰѼ� ===
                Me.Ent_APPL022.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL022.RCV_NO = Me.RCV_NO        '���帹
                Me.Ent_APPL022.DEADLINE = Me.DEADLINE        '������
                Me.Ent_APPL022.DEPID = Me.DEPID      '�ӿ���N�X
                Me.Ent_APPL022.RCV_DATE = Me.RCV_DATE        '������
                Me.Ent_APPL022.RCV_TMEME = Me.RCV_TMEME      '�D��
                Me.Ent_APPL022.CASE_SEQ = Me.CASE_SEQ        '�ɥ�����


                '=== �]�w�B�z�s�W�ʧ@ ===
                Me.Ent_APPL022.SetUserId("SYSTEM")
                Dim result As String = Me.Ent_APPL022.Insert()

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoModify �B�z�ק��ưʧ@"
        '' <summary>
        '' �B�z�ק��ưʧ@
        '' </summary>
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
                Me.Ent_APPL022.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL022.RCV_NO = Me.RCV_NO        '���帹
                Me.Ent_APPL022.DEADLINE = Me.DEADLINE        '������
                Me.Ent_APPL022.DEPID = Me.DEPID      '�ӿ���N�X
                Me.Ent_APPL022.RCV_DATE = Me.RCV_DATE        '������
                Me.Ent_APPL022.RCV_TMEME = Me.RCV_TMEME      '�D��
                Me.Ent_APPL022.CASE_SEQ = Me.CASE_SEQ        '�ɥ�����


                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL022.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_APPL022.Update()

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoDelete �B�z�R����ưʧ@"
        '' <summary>
        '' �B�z�R����ưʧ@
        '' </summary>
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
                Me.Ent_APPL022.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_APPL022.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APPL022.Delete()
                End If

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#Region "DoQuery �i��d�߰ʧ@"
        '' <summary>
        '' �i��d�߰ʧ@
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '�ץ�s��
                Me.ProcessQueryCondition(condition, "=", "RCV_NO", Me.RCV_NO)        '���帹
                Me.ProcessQueryCondition(condition, "=", "DEADLINE", Me.DEADLINE)        '������
                Me.ProcessQueryCondition(condition, "=", "DEPID", Me.DEPID)      '�ӿ���N�X
                Me.ProcessQueryCondition(condition, "=", "RCV_DATE", Me.RCV_DATE)        '������
                Me.ProcessQueryCondition(condition, "=", "RCV_TMEME", Me.RCV_TMEME)      '�D��
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '�ɥ�����

                Me.Ent_APPL022.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL022.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL022.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL022.Query()
                Else
                    result = Me.Ent_APPL022.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL022.TotalRowCount
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

