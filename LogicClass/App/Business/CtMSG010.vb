'ProductName                 : TSBA 
'File Name					 : CtMSG010 
'Description	             : CtMSG010 �T����
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/22         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtMSG010
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_MSG010 = New ENT_MSG010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "MSG_NO "
        '' <summary>
        '' MSG_NO 
        '' </summary>
        Public Property MSG_NO() As String
            Get
                Return Me.PropertyMap("MSG_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MSG_NO") = value
            End Set
        End Property
#End Region

#Region "MSG_DESC "
        '' <summary>
        '' MSG_DESC 
        '' </summary>
        Public Property MSG_DESC() As String
            Get
                Return Me.PropertyMap("MSG_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MSG_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_MSG010"
        ' <summary>Ent_MSG010</ summary>
        Private Property Ent_MSG010() As ENT_MSG010
            Get
                Return Me.PropertyMap("Ent_MSG010")
            End Get
            Set(ByVal value As ENT_MSG010)
                Me.PropertyMap("Ent_MSG010") = value
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
                Me.Ent_MSG010.MSG_NO = Me.MSG_NO         '
                Me.Ent_MSG010.MSG_DESC = Me.MSG_DESC         '


                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_MSG010.Insert()

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
                Me.Ent_MSG010.MSG_NO = Me.MSG_NO         '
                Me.Ent_MSG010.MSG_DESC = Me.MSG_DESC         '


                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_MSG010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_MSG010.Update()

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
                Me.Ent_MSG010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_MSG010.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_MSG010.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "MSG_NO", Me.MSG_NO)        '
                Me.ProcessQueryCondition(condition, "%LIKE%", "MSG_DESC", Me.MSG_DESC)       '

                Me.Ent_MSG010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_MSG010.OrderBys = "PKNO"
                Else
                    Me.Ent_MSG010.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_MSG010.Query()
                Else
                    result = Me.Ent_MSG010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_MSG010.TotalRowCount
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

