'ProductName                 : TSBA 
'File Name					 : CtAPP1180 
'Description	             : CtAPP1180 �W�[�έp��
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/18         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1180
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1180 = New ENT_APP1180(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��, �@��"
        '' <summary>
        '' CASE_NO �ץ�s��, �@��
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

#Region "CHSYS_TYPE �t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP"
        '' <summary>
        '' CHSYS_TYPE �t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP
        '' </summary>
        Public Property CHSYS_TYPE() As String
            Get
                Return Me.PropertyMap("CHSYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHSYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYSTEM_OPERATOR ���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'"
        '' <summary>
        '' SYSTEM_OPERATOR ���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
        '' </summary>
        Public Property SYSTEM_OPERATOR() As String
            Get
                Return Me.PropertyMap("SYSTEM_OPERATOR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYSTEM_OPERATOR") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_CHANNEL_LOCATION ����t�ΤW�[����-�W�D��m"
        '' <summary>
        '' ANALOGY_CHANNEL_LOCATION ����t�ΤW�[����-�W�D��m
        '' </summary>
        Public Property ANALOGY_CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("ANALOGY_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SUBSCRIBER_NUMBER ����t�ΤW�[����-�q���"
        '' <summary>
        '' ANALOGY_SUBSCRIBER_NUMBER ����t�ΤW�[����-�q���
        '' </summary>
        Public Property ANALOGY_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("ANALOGY_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_CHANNEL_LOCATION �Ʀ�t�ΤW�[����-�W�D��m"
        '' <summary>
        '' DIGIT_CHANNEL_LOCATION �Ʀ�t�ΤW�[����-�W�D��m
        '' </summary>
        Public Property DIGIT_CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("DIGIT_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SUBSCRIBER_NUMBER �Ʀ�t�ΤW�[����-�q���"
        '' <summary>
        '' DIGIT_SUBSCRIBER_NUMBER �Ʀ�t�ΤW�[����-�q���
        '' </summary>
        Public Property DIGIT_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("DIGIT_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_LOCATION �W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��"
        '' <summary>
        '' CHANNEL_LOCATION �W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��
        '' </summary>
        Public Property CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBER_NUMBER �q���, ��L�Ѥ�������ť�����e���O�B�����ìP��"
        '' <summary>
        '' SUBSCRIBER_NUMBER �q���, ��L�Ѥ�������ť�����e���O�B�����ìP��
        '' </summary>
        Public Property SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region


#Region "QUERY_COND �d�߱���"
        ''' <summary>
        ''' QUERY_COND �d�߱���
        ''' </summary>
        Public Property QUERY_COND() As String
            Get
                Return Me.PropertyMap("QUERY_COND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QUERY_COND") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1180"
        ' <summary>Ent_APP1180</ summary>
        Private Property Ent_APP1180() As ENT_APP1180
            Get
                Return Me.PropertyMap("Ent_APP1180")
            End Get
            Set(ByVal value As ENT_APP1180)
                Me.PropertyMap("Ent_APP1180") = value
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
                Me.Ent_APP1180.CASE_NO = Me.CASE_NO      '�ץ�s��, �@��
                Me.Ent_APP1180.CHSYS_TYPE = Me.CHSYS_TYPE        '�t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP
                Me.Ent_APP1180.SYSTEM_OPERATOR = Me.SYSTEM_OPERATOR      '���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.Ent_APP1180.ANALOGY_CHANNEL_LOCATION = Me.ANALOGY_CHANNEL_LOCATION        '����t�ΤW�[����-�W�D��m
                Me.Ent_APP1180.ANALOGY_SUBSCRIBER_NUMBER = Me.ANALOGY_SUBSCRIBER_NUMBER      '����t�ΤW�[����-�q���
                Me.Ent_APP1180.DIGIT_CHANNEL_LOCATION = Me.DIGIT_CHANNEL_LOCATION        '�Ʀ�t�ΤW�[����-�W�D��m
                Me.Ent_APP1180.DIGIT_SUBSCRIBER_NUMBER = Me.DIGIT_SUBSCRIBER_NUMBER      '�Ʀ�t�ΤW�[����-�q���
                Me.Ent_APP1180.CHANNEL_LOCATION = Me.CHANNEL_LOCATION        '�W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��
                Me.Ent_APP1180.SUBSCRIBER_NUMBER = Me.SUBSCRIBER_NUMBER      '�q���, ��L�Ѥ�������ť�����e���O�B�����ìP��


                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_APP1180.Insert()

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
                Me.Ent_APP1180.CASE_NO = Me.CASE_NO      '�ץ�s��, �@��
                Me.Ent_APP1180.CHSYS_TYPE = Me.CHSYS_TYPE        '�t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP
                Me.Ent_APP1180.SYSTEM_OPERATOR = Me.SYSTEM_OPERATOR      '���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.Ent_APP1180.ANALOGY_CHANNEL_LOCATION = Me.ANALOGY_CHANNEL_LOCATION        '����t�ΤW�[����-�W�D��m
                Me.Ent_APP1180.ANALOGY_SUBSCRIBER_NUMBER = Me.ANALOGY_SUBSCRIBER_NUMBER      '����t�ΤW�[����-�q���
                Me.Ent_APP1180.DIGIT_CHANNEL_LOCATION = Me.DIGIT_CHANNEL_LOCATION        '�Ʀ�t�ΤW�[����-�W�D��m
                Me.Ent_APP1180.DIGIT_SUBSCRIBER_NUMBER = Me.DIGIT_SUBSCRIBER_NUMBER      '�Ʀ�t�ΤW�[����-�q���
                Me.Ent_APP1180.CHANNEL_LOCATION = Me.CHANNEL_LOCATION        '�W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��
                Me.Ent_APP1180.SUBSCRIBER_NUMBER = Me.SUBSCRIBER_NUMBER      '�q���, ��L�Ѥ�������ť�����e���O�B�����ìP��


                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_APP1180.Update()

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
        '' �B�z�R����ưʧ@ by CASE_NO
        '' </summary>
        Public Sub DoDeleteByCASE_NO()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If String.IsNullOrEmpty(Me.CHSYS_TYPE) Then
                    faileArguments.Add("CHSYS_TYPE")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �]�w�ݩʰѼ� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE)
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== �R����� ===
                If Me.Ent_APP1180.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APP1180.Delete()
                End If

                '=== ���]����ݩ� ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub

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
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_APP1180.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APP1180.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '�ץ�s��, �@��
                Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE)        '�t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP
                Me.ProcessQueryCondition(condition, "=", "SYSTEM_OPERATOR", Me.SYSTEM_OPERATOR)      '���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_CHANNEL_LOCATION", Me.ANALOGY_CHANNEL_LOCATION)        '����t�ΤW�[����-�W�D��m
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SUBSCRIBER_NUMBER", Me.ANALOGY_SUBSCRIBER_NUMBER)      '����t�ΤW�[����-�q���
                Me.ProcessQueryCondition(condition, "=", "DIGIT_CHANNEL_LOCATION", Me.DIGIT_CHANNEL_LOCATION)        '�Ʀ�t�ΤW�[����-�W�D��m
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SUBSCRIBER_NUMBER", Me.DIGIT_SUBSCRIBER_NUMBER)      '�Ʀ�t�ΤW�[����-�q���
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_LOCATION", Me.CHANNEL_LOCATION)        '�W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��
                Me.ProcessQueryCondition(condition, "=", "SUBSCRIBER_NUMBER", Me.SUBSCRIBER_NUMBER)      '�q���, ��L�Ѥ�������ť�����e���O�B�����ìP��

                condition.Append(Me.QUERY_COND)

                Me.Ent_APP1180.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1180.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1180.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1180.QueryMergeData()
                Else
                    result = Me.Ent_APP1180.QueryMergeData(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1180.TotalRowCount
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

