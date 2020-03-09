'ProductName                 : TSBA 
'File Name					 : CtAPPL020 
'Description	             : CtAPPL020  
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/20         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL020
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL020 = New ENT_APPL020(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��"
        '' <summary>
        '' CASE_NO �ץ�s��, 
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

#Region "CASE_SEQ �ɥ�����"
        '' <summary>
        '' CASE_SEQ �ɥ�����, 
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

#Region "COM_PKNO �~��PKNO"
        '' <summary>
        '' COM_PKNO �~��PKNO
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.PropertyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE �~�ȥN��"
        '' <summary>
        '' CASE_CODE �~�ȥN��, 
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.PropertyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "DEL_FLAG �R�����O"
        '' <summary>
        '' DEL_FLAG �R�����O, 
        '' </summary>
        Public Property DEL_FLAG() As String
            Get
                Return Me.PropertyMap("DEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CASE_STATUS �ץ�i��"
        '' <summary>
        '' CASE_STATUS �ץ�i��, 
        '' </summary>
        Public Property CASE_STATUS() As String
            Get
                Return Me.PropertyMap("CASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "RESULT1 ��f�f�d���G"
        '' <summary>
        '' RESULT1 ��f�f�d���G, 
        '' </summary>
        Public Property RESULT1() As String
            Get
                Return Me.PropertyMap("RESULT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DATE ��f�f�d�������"
        '' <summary>
        '' RESULT1_DATE ��f�f�d�������
        '' </summary>
        Public Property RESULT1_DATE() As String
            Get
                Return Me.PropertyMap("RESULT1_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DESC ��f�N��"
        '' <summary>
        '' RESULT1_DESC ��f�N��
        '' </summary>
        Public Property RESULT1_DESC() As String
            Get
                Return Me.PropertyMap("RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT2 �Ըߩe���|ĳ�f�d���G"
        '' <summary>
        '' RESULT2 �Ըߩe���|ĳ�f�d���G, 
        '' </summary>
        Public Property RESULT2() As String
            Get
                Return Me.PropertyMap("RESULT2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DATE �Ըߩe���|ĳ�f�d�������"
        '' <summary>
        '' RESULT2_DATE �Ըߩe���|ĳ�f�d�������
        '' </summary>
        Public Property RESULT2_DATE() As String
            Get
                Return Me.PropertyMap("RESULT2_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DESC �Ըߩe���|ĳ�f�d�N��"
        '' <summary>
        '' RESULT2_DESC �Ըߩe���|ĳ�f�d�N��
        '' </summary>
        Public Property RESULT2_DESC() As String
            Get
                Return Me.PropertyMap("RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT3 ���|�e���|ĳ�f�d���G"
        '' <summary>
        '' RESULT3 ���|�e���|ĳ�f�d���G, 
        '' </summary>
        Public Property RESULT3() As String
            Get
                Return Me.PropertyMap("RESULT3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DATE ���|�e���|ĳ�f�d�������"
        '' <summary>
        '' RESULT3_DATE ���|�e���|ĳ�f�d�������
        '' </summary>
        Public Property RESULT3_DATE() As String
            Get
                Return Me.PropertyMap("RESULT3_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DESC ���|�e���|ĳ�f�d�N��"
        '' <summary>
        '' RESULT3_DESC ���|�e���|ĳ�f�d�N��
        '' </summary>
        Public Property RESULT3_DESC() As String
            Get
                Return Me.PropertyMap("RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RESULT3_DESC") = value
            End Set
        End Property
#End Region

#Region "CREATE_USER ��ƫإߪ�"
        '' <summary>
        '' CREATE_USER ��ƫإߪ�
        '' </summary>
        Public Property CREATE_USER() As String
            Get
                Return Me.PropertyMap("CREATE_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_USER") = value
            End Set
        End Property
#End Region

#Region "CREATE_DATE ��ƫإߤ��"
        '' <summary>
        '' CREATE_DATE ��ƫإߤ��
        '' </summary>
        Public Property CREATE_DATE() As String
            Get
                Return Me.PropertyMap("CREATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_DATE") = value
            End Set
        End Property
#End Region

#Region "UPDATE_USER ��ƺ��@��"
        '' <summary>
        '' UPDATE_USER ��ƺ��@��
        '' </summary>
        Public Property UPDATE_USER() As String
            Get
                Return Me.PropertyMap("UPDATE_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPDATE_USER") = value
            End Set
        End Property
#End Region

#Region "UPDATE_DATE ��ƺ��@���"
        '' <summary>
        '' UPDATE_DATE ��ƺ��@���
        '' </summary>
        Public Property UPDATE_DATE() As String
            Get
                Return Me.PropertyMap("UPDATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPDATE_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO ���Ӹ��X"
        '' <summary>
        '' LICENSE_NO ���Ӹ��X
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.PropertyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "CHANG_LICENSE_DATE ���Ӥ��"
        '' <summary>
        '' CHANG_LICENSE_DATE ���Ӥ��
        '' </summary>
        Public Property CHANG_LICENSE_DATE() As String
            Get
                Return Me.PropertyMap("CHANG_LICENSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANG_LICENSE_DATE") = value
            End Set
        End Property
#End Region

#Region "OTHER_UNIT_DESC �|��N��"
        '' <summary>
        '' OTHER_UNIT_DESC �|��N��
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.PropertyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region


#Region "APV_DATE �즸�e�fNCC�ɶ�"
        '' <summary>
        '' APV_DATE �즸�e�fNCC�ɶ�
        '' </summary>
        Public Property APV_DATE() As String
            Get
                Return Me.PropertyMap("APV_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APV_DATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL020"
        ' <summary>Ent_APPL020</ summary>
        Private Property Ent_APPL020() As ENT_APPL020
            Get
                Return Me.PropertyMap("Ent_APPL020")
            End Get
            Set(ByVal value As ENT_APPL020)
                Me.PropertyMap("Ent_APPL020") = value
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
                Me.Ent_APPL020.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL020.CASE_SEQ = Me.CASE_SEQ        '�ɥ�����
                Me.Ent_APPL020.COM_PKNO = Me.COM_PKNO        '�~��PKNO
                Me.Ent_APPL020.CASE_CODE = Me.CASE_CODE      '�~�ȥN��
                Me.Ent_APPL020.DEL_FLAG = Me.DEL_FLAG        '�R�����O
                Me.Ent_APPL020.CASE_STATUS = Me.CASE_STATUS      '�ץ�i��
                Me.Ent_APPL020.RESULT1 = Me.RESULT1      '��f�f�d���G
                Me.Ent_APPL020.RESULT1_DATE = Me.RESULT1_DATE        '��f�f�d�������
                Me.Ent_APPL020.RESULT1_DESC = Me.RESULT1_DESC         '��f�N��
                Me.Ent_APPL020.RESULT2 = Me.RESULT2      '�Ըߩe���|ĳ�f�d���G
                Me.Ent_APPL020.RESULT2_DATE = Me.RESULT2_DATE        '�Ըߩe���|ĳ�f�d�������
                Me.Ent_APPL020.RESULT2_DESC = Me.RESULT2_DESC         '�Ըߩe���|ĳ�f�d�N��
                Me.Ent_APPL020.RESULT3 = Me.RESULT3      '���|�e���|ĳ�f�d���G
                Me.Ent_APPL020.RESULT3_DATE = Me.RESULT3_DATE        '���|�e���|ĳ�f�d�������
                Me.Ent_APPL020.RESULT3_DESC = Me.RESULT3_DESC        '���|�e���|ĳ�f�d�N��
                Me.Ent_APPL020.CREATE_USER = Me.CREATE_USER      '��ƫإߪ�
                Me.Ent_APPL020.CREATE_DATE = Me.CREATE_DATE        '��ƫإߤ��
                Me.Ent_APPL020.UPDATE_USER = Me.UPDATE_USER        '��ƺ��@��
                Me.Ent_APPL020.UPDATE_DATE = Me.UPDATE_DATE        '��ƺ��@���
                Me.Ent_APPL020.LICENSE_NO = Me.LICENSE_NO        '���Ӹ��X
                Me.Ent_APPL020.CHANG_LICENSE_DATE = Me.CHANG_LICENSE_DATE        '���Ӥ��
                Me.Ent_APPL020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '�|��N��
                Me.Ent_APPL020.APV_DATE = Me.APV_DATE

                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_APPL020.Insert()

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
                Me.Ent_APPL020.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL020.CASE_SEQ = Me.CASE_SEQ        '�ɥ�����
                Me.Ent_APPL020.COM_PKNO = Me.COM_PKNO        '�~��PKNO
                Me.Ent_APPL020.CASE_CODE = Me.CASE_CODE      '�~�ȥN��
                Me.Ent_APPL020.DEL_FLAG = Me.DEL_FLAG        '�R�����O
                Me.Ent_APPL020.CASE_STATUS = Me.CASE_STATUS      '�ץ�i��
                Me.Ent_APPL020.RESULT1 = Me.RESULT1      '��f�f�d���G
                Me.Ent_APPL020.RESULT1_DATE = Me.RESULT1_DATE        '��f�f�d�������
                Me.Ent_APPL020.RESULT1_DESC = Me.RESULT1_DESC         '��f�N��
                Me.Ent_APPL020.RESULT2 = Me.RESULT2      '�Ըߩe���|ĳ�f�d���G
                Me.Ent_APPL020.RESULT2_DATE = Me.RESULT2_DATE        '�Ըߩe���|ĳ�f�d�������
                Me.Ent_APPL020.RESULT2_DESC = Me.RESULT2_DESC         '�Ըߩe���|ĳ�f�d�N��
                Me.Ent_APPL020.RESULT3 = Me.RESULT3      '���|�e���|ĳ�f�d���G
                Me.Ent_APPL020.RESULT3_DATE = Me.RESULT3_DATE        '���|�e���|ĳ�f�d�������
                Me.Ent_APPL020.RESULT3_DESC = Me.RESULT3_DESC        '���|�e���|ĳ�f�d�N��
                Me.Ent_APPL020.CREATE_USER = Me.CREATE_USER      '��ƫإߪ�
                Me.Ent_APPL020.CREATE_DATE = Me.CREATE_DATE        '��ƫإߤ��
                Me.Ent_APPL020.UPDATE_USER = Me.UPDATE_USER        '��ƺ��@��
                Me.Ent_APPL020.UPDATE_DATE = Me.UPDATE_DATE        '��ƺ��@���
                Me.Ent_APPL020.LICENSE_NO = Me.LICENSE_NO        '���Ӹ��X
                Me.Ent_APPL020.CHANG_LICENSE_DATE = Me.CHANG_LICENSE_DATE        '���Ӥ��
                Me.Ent_APPL020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC        '�|��N��
                Me.Ent_APPL020.APV_DATE = Me.APV_DATE

                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_APPL020.Update()

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
                Me.Ent_APPL020.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_APPL020.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APPL020.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '�ɥ�����
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '�~��PKNO
                If Not String.IsNullOrEmpty(Me.CASE_CODE) Then
                    condition.Append(" AND $.CASE_CODE IN ('" & Me.CASE_CODE.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "IN", "CASE_CODE", Me.CASE_CODE)      '�~�ȥN��
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '�R�����O
                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND $.CASE_STATUS IN ('" & Me.CASE_STATUS.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS)      '�ץ�i��
                Me.ProcessQueryCondition(condition, "=", "RESULT1", Me.RESULT1)      '��f�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT1_DATE", Me.RESULT1_DATE)        '��f�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT1_DESC", Me.RESULT1_DESC)       '��f�N��
                Me.ProcessQueryCondition(condition, "=", "RESULT2", Me.RESULT2)      '�Ըߩe���|ĳ�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT2_DATE", Me.RESULT2_DATE)        '�Ըߩe���|ĳ�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT2_DESC", Me.RESULT2_DESC)       '�Ըߩe���|ĳ�f�d�N��
                Me.ProcessQueryCondition(condition, "=", "RESULT3", Me.RESULT3)      '���|�e���|ĳ�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT3_DATE", Me.RESULT3_DATE)        '���|�e���|ĳ�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT3_DESC", Me.RESULT3_DESC)       '���|�e���|ĳ�f�d�N��
                Me.ProcessQueryCondition(condition, "=", "CREATE_USER", Me.CREATE_USER)      '��ƫإߪ�
                Me.ProcessQueryCondition(condition, "=", "CREATE_DATE", Me.CREATE_DATE)      '��ƫإߤ��
                Me.ProcessQueryCondition(condition, "=", "UPDATE_USER", Me.UPDATE_USER)      '��ƺ��@��
                Me.ProcessQueryCondition(condition, "=", "UPDATE_DATE", Me.UPDATE_DATE)      '��ƺ��@���
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '���Ӹ��X
                Me.ProcessQueryCondition(condition, "=", "CHANG_LICENSE_DATE", Me.CHANG_LICENSE_DATE)        '���Ӥ��
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC) '�|��N��
                Me.ProcessQueryCondition(condition, "=", "APV_DATE", Me.APV_DATE) '�|��N��


                '�S����� OR �۩w����
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.Query()
                Else
                    result = Me.Ent_APPL020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        '' <summary>
        '' Web Servie�i��d�߰ʧ@
        '' </summary>
        Public Function DoQuery_WS() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '�ץ�s��
                If Me.CASE_NO.Length > 0 Then
                    Me.Ent_APPL020.CASE_NO = Me.CASE_NO
                End If
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '�ɥ�����
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '�~��PKNO
                If Not String.IsNullOrEmpty(Me.CASE_CODE) Then
                    condition.Append(" AND $.CASE_CODE IN ('" & Me.CASE_CODE.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "IN", "CASE_CODE", Me.CASE_CODE)      '�~�ȥN��
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '�R�����O
                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND $.CASE_STATUS IN ('" & Me.CASE_STATUS.Replace(",", "','") & "') ")
                End If
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS)      '�ץ�i��
                Me.ProcessQueryCondition(condition, "=", "RESULT1", Me.RESULT1)      '��f�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT1_DATE", Me.RESULT1_DATE)        '��f�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT1_DESC", Me.RESULT1_DESC)       '��f�N��
                Me.ProcessQueryCondition(condition, "=", "RESULT2", Me.RESULT2)      '�Ըߩe���|ĳ�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT2_DATE", Me.RESULT2_DATE)        '�Ըߩe���|ĳ�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT2_DESC", Me.RESULT2_DESC)       '�Ըߩe���|ĳ�f�d�N��
                Me.ProcessQueryCondition(condition, "=", "RESULT3", Me.RESULT3)      '���|�e���|ĳ�f�d���G
                Me.ProcessQueryCondition(condition, "=", "RESULT3_DATE", Me.RESULT3_DATE)        '���|�e���|ĳ�f�d�������
                Me.ProcessQueryCondition(condition, "%LIKE%", "RESULT3_DESC", Me.RESULT3_DESC)       '���|�e���|ĳ�f�d�N��
                Me.ProcessQueryCondition(condition, "=", "CREATE_USER", Me.CREATE_USER)      '��ƫإߪ�
                Me.ProcessQueryCondition(condition, "=", "CREATE_DATE", Me.CREATE_DATE)      '��ƫإߤ��
                Me.ProcessQueryCondition(condition, "=", "UPDATE_USER", Me.UPDATE_USER)      '��ƺ��@��
                Me.ProcessQueryCondition(condition, "=", "UPDATE_DATE", Me.UPDATE_DATE)      '��ƺ��@���
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '���Ӹ��X
                Me.ProcessQueryCondition(condition, "=", "CHANG_LICENSE_DATE", Me.CHANG_LICENSE_DATE)        '���Ӥ��
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC) '�|��N��
                Me.ProcessQueryCondition(condition, "=", "APV_DATE", Me.APV_DATE) '�|��N��


                '�S����� OR �۩w����
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.Query_WS(0, 0)
                Else
                    result = Me.Ent_APPL020.Query_WS(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function GetCaseList() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== �B�z�d�߱��� ===                 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '�ץ�s��
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '�ɥ�����
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '�~��PKNO
                Me.ProcessQueryCondition(condition, "=", "DEL_FLAG", Me.DEL_FLAG)        '�R�����O

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                result = Me.Ent_APPL020.QueryCaseList()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "�ή׸��d�߾��c���� QueryOrgTypeByCaseNo"
        Public Function QueryOrgTypeByCaseNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO)      '�ץ�s��

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL020.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL020.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL020.QueryOrgTypeByCaseNo()
                Else
                    result = Me.Ent_APPL020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL020.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "�d�X���q�������BY CASE_NO"
        ''' <summary>
        ''' �d�X���q�������BY CASE_NO
        ''' type = APP120324:���W�D�W��
        ''' type = APP120705:�¬d�νs
        ''' </summary>
        Public Function GetCompanyDataByCASE_NO(Optional type As String = "") As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '�ץ�s��

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetCompanyDataByCASE_NO(type)

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "�ꤽ�夶���׸����D��"
        ''' <summary>
        ''' ��SYS_PRTID
        ''' </summary>
        Public Function GetSYSID() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '�ץ�s��
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '�ɥ�����

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSYSID()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function GetSubject_Type01() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '�ץ�s��
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '�ɥ�����

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSubject_Type01()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        'Public Function GetSubject_Type02() As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()

        '        '=== �B�z�d�߱��� === 
        '        Dim condition As StringBuilder = New StringBuilder()
        '        Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '�ץ�s��
        '        Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '�ɥ�����

        '        '�S����� OR �۩w����              
        '        condition.Append(Me.QUERY_COND)
        '        Me.Ent_APPL020.SqlRetrictions = condition.ToString()

        '        '=== �B�z���o�^�Ǹ��===
        '        Dim result As DataTable
        '        result = Me.Ent_APPL020.GetSubject_Type02()

        '        Me.ResetColumnProperty()

        '        Return result
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function

        Public Function GetSubject_Type03() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �B�z�d�߱��� === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_NO", Me.CASE_NO) '�ץ�s��
                Me.ProcessQueryCondition(condition, "=", "A020.CASE_SEQ", Me.CASE_SEQ) '�ɥ�����

                '�S����� OR �۩w����              
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL020.SqlRetrictions = condition.ToString()

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                result = Me.Ent_APPL020.GetSubject_Type03()

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

