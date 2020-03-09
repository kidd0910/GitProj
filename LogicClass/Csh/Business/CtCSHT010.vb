'ProductName                 : TSBA 
'File Name					 : CtCSHT010 
'Description	             : CtCSHT010 ú�ڬ���
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/27         Source Create
'---------------------------------------------------------------------------

Imports Csh.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Csh.Business
    Partial Public Class CtCSHT010
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_CSHT010 = New ENT_CSHT010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��, INSERT�ɼg�J, ����줣��ק�"
        '' <summary>
        '' CASE_NO �ץ�s��, INSERT�ɼg�J, ����줣��ק�
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

#Region "YEAR �~��, INSERT�ɼg�J"
        '' <summary>
        '' YEAR �~��, INSERT�ɼg�J
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.PropertyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�"
        '' <summary>
        '' ITEM_TYPE ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�
        '' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.PropertyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM_TYPE") = value
            End Set
        End Property
#End Region

#Region "PAYMENT_ACNT ú�ڥN�X, �ѷ��J�t�μg�J"
        '' <summary>
        '' PAYMENT_ACNT ú�ڥN�X, �ѷ��J�t�μg�J
        '' </summary>
        Public Property PAYMENT_ACNT() As String
            Get
                Return Me.PropertyMap("PAYMENT_ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAYMENT_ACNT") = value
            End Set
        End Property
#End Region

#Region "COM_PKNO ������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' COM_PKNO ������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
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

#Region "INFORM_DATE �q������, ����줣��ק�"
        '' <summary>
        '' INFORM_DATE �q������, ����줣��ק�
        '' </summary>
        Public Property INFORM_DATE() As String
            Get
                Return Me.PropertyMap("INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INFORM_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_CODE �O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'"
        '' <summary>
        '' PAY_CODE �O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'
        '' </summary>
        Public Property PAY_CODE() As String
            Get
                Return Me.PropertyMap("PAY_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_CODE") = value
            End Set
        End Property
#End Region

#Region "PAY_NAME �O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME"
        '' <summary>
        '' PAY_NAME �O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME
        '' </summary>
        Public Property PAY_NAME() As String
            Get
                Return Me.PropertyMap("PAY_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_NAME") = value
            End Set
        End Property
#End Region

#Region "PAY_COUNT �ƶq"
        '' <summary>
        '' PAY_COUNT �ƶq
        '' </summary>
        Public Property PAY_COUNT() As String
            Get
                Return Me.PropertyMap("PAY_COUNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_COUNT") = value
            End Set
        End Property
#End Region

#Region "PAY_AMT �O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr"
        '' <summary>
        '' PAY_AMT �O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr
        '' </summary>
        Public Property PAY_AMT() As String
            Get
                Return Me.PropertyMap("PAY_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_AMT") = value
            End Set
        End Property
#End Region

#Region "PAY_USER �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_USER �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_USER() As String
            Get
                Return Me.PropertyMap("PAY_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_USER") = value
            End Set
        End Property
#End Region

#Region "PAY_BUS_NO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_BUS_NO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_BUS_NO() As String
            Get
                Return Me.PropertyMap("PAY_BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_BUS_NO") = value
            End Set
        End Property
#End Region

#Region "PAY_TEL �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_TEL �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_TEL() As String
            Get
                Return Me.PropertyMap("PAY_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_TEL") = value
            End Set
        End Property
#End Region

#Region "DATE_LEN "
        '' <summary>
        '' DATE_LEN 
        '' </summary>
        Public Property DATE_LEN() As String
            Get
                Return Me.PropertyMap("DATE_LEN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATE_LEN") = value
            End Set
        End Property
#End Region

#Region "PAY_DEADLINE ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�"
        '' <summary>
        '' PAY_DEADLINE ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�
        '' </summary>
        Public Property PAY_DEADLINE() As String
            Get
                Return Me.PropertyMap("PAY_DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_DEADLINE") = value
            End Set
        End Property
#End Region

#Region "PAY_DATE �ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE"
        '' <summary>
        '' PAY_DATE �ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
        '' </summary>
        Public Property PAY_DATE() As String
            Get
                Return Me.PropertyMap("PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "FINAL_PAY_DATE �ѷ��J�t�μg�J"
        '' <summary>
        '' FINAL_PAY_DATE �ѷ��J�t�μg�J
        '' </summary>
        Public Property FINAL_PAY_DATE() As String
            Get
                Return Me.PropertyMap("FINAL_PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FINAL_PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_STATUS �ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h"
        '' <summary>
        '' PAY_STATUS �ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h
        '' </summary>
        Public Property PAY_STATUS() As String
            Get
                Return Me.PropertyMap("PAY_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_STATUS �ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�"
        '' <summary>
        '' PLEASE_STATUS �ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�
        '' </summary>
        Public Property PLEASE_STATUS() As String
            Get
                Return Me.PropertyMap("PLEASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLEASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_DATE �ѡu�ץ�дڵn���v�\��g�J"
        '' <summary>
        '' PLEASE_DATE �ѡu�ץ�дڵn���v�\��g�J
        '' </summary>
        Public Property PLEASE_DATE() As String
            Get
                Return Me.PropertyMap("PLEASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLEASE_DATE") = value
            End Set
        End Property
#End Region

#Region "REMARK �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' REMARK �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.PropertyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "CAN_FLAG ��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P"
        '' <summary>
        '' CAN_FLAG ��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P
        '' </summary>
        Public Property CAN_FLAG() As String
            Get
                Return Me.PropertyMap("CAN_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CAN_FLAG") = value
            End Set
        End Property
#End Region

#Region "CANCEL_CAUSE �ѷ��J�t�μg�J"
        '' <summary>
        '' CANCEL_CAUSE �ѷ��J�t�μg�J
        '' </summary>
        Public Property CANCEL_CAUSE() As String
            Get
                Return Me.PropertyMap("CANCEL_CAUSE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CANCEL_CAUSE") = value
            End Set
        End Property
#End Region

#Region "CAN_FLAG_DATE �P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C"
        '' <summary>
        '' CAN_FLAG_DATE �P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C
        '' </summary>
        Public Property CAN_FLAG_DATE() As String
            Get
                Return Me.PropertyMap("CAN_FLAG_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CAN_FLAG_DATE") = value
            End Set
        End Property
#End Region

#Region "APPL021_PKNO REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������"
        '' <summary>
        '' APPL021_PKNO REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������
        '' </summary>
        Public Property APPL021_PKNO() As String
            Get
                Return Me.PropertyMap("APPL021_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPL021_PKNO") = value
            End Set
        End Property
#End Region

#Region "RE_PRINT_COUNT "
        '' <summary>
        '' RE_PRINT_COUNT 
        '' </summary>
        Public Property RE_PRINT_COUNT() As String
            Get
                Return Me.PropertyMap("RE_PRINT_COUNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RE_PRINT_COUNT") = value
            End Set
        End Property
#End Region

#Region "SYNC_DATE "
        '' <summary>
        '' SYNC_DATE 
        '' </summary>
        Public Property SYNC_DATE() As String
            Get
                Return Me.PropertyMap("SYNC_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYNC_DATE") = value
            End Set
        End Property
#End Region

#Region "Ent_CSHT010"
        ' <summary>Ent_CSHT010</ summary>
        Private Property Ent_CSHT010() As ENT_CSHT010
            Get
                Return Me.PropertyMap("Ent_CSHT010")
            End Get
            Set(ByVal value As ENT_CSHT010)
                Me.PropertyMap("Ent_CSHT010") = value
            End Set
        End Property
#End Region

#Region "S_INFORM_DATE �}����"
        ''' <summary>
        ''' S_INFORM_DATE �}����
        ''' </summary>
        Public Property S_INFORM_DATE As String
            Get
                Return Me.PropertyMap("S_INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_INFORM_DATE") = value
            End Set
        End Property
#End Region

#Region "E_INFORM_DATE �}����"
        ''' <summary>
        ''' E_INFORM_DATE �}����
        ''' </summary>
        Public Property E_INFORM_DATE As String
            Get
                Return Me.PropertyMap("E_INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("E_INFORM_DATE") = value
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
                Me.Ent_CSHT010.CASE_NO = Me.CASE_NO      '�ץ�s��, INSERT�ɼg�J, ����줣��ק�
                Me.Ent_CSHT010.YEAR = Me.YEAR        '�~��, INSERT�ɼg�J
                Me.Ent_CSHT010.ITEM_TYPE = Me.ITEM_TYPE      'ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�
                Me.Ent_CSHT010.PAYMENT_ACNT = Me.PAYMENT_ACNT        'ú�ڥN�X, �ѷ��J�t�μg�J
                Me.Ent_CSHT010.COM_PKNO = Me.COM_PKNO        '������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.INFORM_DATE = Me.INFORM_DATE      '�q������, ����줣��ק�
                Me.Ent_CSHT010.PAY_CODE = Me.PAY_CODE        '�O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.Ent_CSHT010.PAY_NAME = Me.PAY_NAME        '�O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME
                Me.Ent_CSHT010.PAY_COUNT = Me.PAY_COUNT      '�ƶq
                Me.Ent_CSHT010.PAY_AMT = Me.PAY_AMT      '�O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr
                Me.Ent_CSHT010.PAY_USER = Me.PAY_USER        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.PAY_BUS_NO = Me.PAY_BUS_NO        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.PAY_TEL = Me.PAY_TEL      '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.DATE_LEN = Me.DATE_LEN        '
                Me.Ent_CSHT010.PAY_DEADLINE = Me.PAY_DEADLINE        'ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�
                Me.Ent_CSHT010.PAY_DATE = Me.PAY_DATE        '�ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.Ent_CSHT010.FINAL_PAY_DATE = Me.FINAL_PAY_DATE        '�ѷ��J�t�μg�J
                Me.Ent_CSHT010.PAY_STATUS = Me.PAY_STATUS        '�ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h
                Me.Ent_CSHT010.PLEASE_STATUS = Me.PLEASE_STATUS      '�ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�
                Me.Ent_CSHT010.PLEASE_DATE = Me.PLEASE_DATE      '�ѡu�ץ�дڵn���v�\��g�J
                Me.Ent_CSHT010.REMARK = Me.REMARK        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.CAN_FLAG = Me.CAN_FLAG        '��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P
                Me.Ent_CSHT010.CANCEL_CAUSE = Me.CANCEL_CAUSE        '�ѷ��J�t�μg�J
                Me.Ent_CSHT010.CAN_FLAG_DATE = Me.CAN_FLAG_DATE      '�P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C
                Me.Ent_CSHT010.APPL021_PKNO = Me.APPL021_PKNO        'REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������
                Me.Ent_CSHT010.RE_PRINT_COUNT = Me.RE_PRINT_COUNT        '
                Me.Ent_CSHT010.SYNC_DATE = Me.SYNC_DATE      '


                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_CSHT010.Insert()

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
                'Dim faileArguments As ArrayList = New ArrayList()
                'If String.IsNullOrEmpty(Me.PKNO) Then
                '    faileArguments.Add("PKNO")
                'End If

                'If faileArguments.Count > 0 Then
                '    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                'End If
                '=== �ˮ���쵲�� ===

                '=== �]�w�ݩʰѼ� ===
                Me.Ent_CSHT010.CASE_NO = Me.CASE_NO      '�ץ�s��, INSERT�ɼg�J, ����줣��ק�
                Me.Ent_CSHT010.YEAR = Me.YEAR        '�~��, INSERT�ɼg�J
                Me.Ent_CSHT010.ITEM_TYPE = Me.ITEM_TYPE      'ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�
                'Me.Ent_CSHT010.PAYMENT_ACNT = Me.PAYMENT_ACNT        'ú�ڥN�X, �ѷ��J�t�μg�J
                Me.Ent_CSHT010.COM_PKNO = Me.COM_PKNO        '������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.INFORM_DATE = Me.INFORM_DATE      '�q������, ����줣��ק�
                Me.Ent_CSHT010.PAY_CODE = Me.PAY_CODE        '�O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.Ent_CSHT010.PAY_NAME = Me.PAY_NAME        '�O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME
                Me.Ent_CSHT010.PAY_COUNT = Me.PAY_COUNT      '�ƶq
                Me.Ent_CSHT010.PAY_AMT = Me.PAY_AMT      '�O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr
                Me.Ent_CSHT010.PAY_USER = Me.PAY_USER        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.PAY_BUS_NO = Me.PAY_BUS_NO        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.PAY_TEL = Me.PAY_TEL      '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.DATE_LEN = Me.DATE_LEN        '
                Me.Ent_CSHT010.PAY_DEADLINE = Me.PAY_DEADLINE        'ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�
                Me.Ent_CSHT010.PAY_DATE = Me.PAY_DATE        '�ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.Ent_CSHT010.FINAL_PAY_DATE = Me.FINAL_PAY_DATE        '�ѷ��J�t�μg�J
                Me.Ent_CSHT010.PAY_STATUS = Me.PAY_STATUS        '�ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h
                Me.Ent_CSHT010.PLEASE_STATUS = Me.PLEASE_STATUS      '�ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�
                Me.Ent_CSHT010.PLEASE_DATE = Me.PLEASE_DATE      '�ѡu�ץ�дڵn���v�\��g�J
                Me.Ent_CSHT010.REMARK = Me.REMARK        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.Ent_CSHT010.CAN_FLAG = Me.CAN_FLAG        '��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P
                Me.Ent_CSHT010.CANCEL_CAUSE = Me.CANCEL_CAUSE        '�ѷ��J�t�μg�J
                Me.Ent_CSHT010.CAN_FLAG_DATE = Me.CAN_FLAG_DATE      '�P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C
                Me.Ent_CSHT010.APPL021_PKNO = Me.APPL021_PKNO        'REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������
                Me.Ent_CSHT010.RE_PRINT_COUNT = Me.RE_PRINT_COUNT        '
                Me.Ent_CSHT010.SYNC_DATE = Me.SYNC_DATE      '


                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "PAYMENT_ACNT", Me.PAYMENT_ACNT)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_CSHT010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_CSHT010.Update()

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
                Me.Ent_CSHT010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_CSHT010.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_CSHT010.Delete()
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
                'Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '�ץ�s��, INSERT�ɼg�J, ����줣��ק�
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '�~��, INSERT�ɼg�J
                Me.ProcessQueryCondition(condition, "=", "ITEM_TYPE", Me.ITEM_TYPE)      'ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�
                Me.ProcessQueryCondition(condition, "=", "PAYMENT_ACNT", Me.PAYMENT_ACNT)        'ú�ڥN�X, �ѷ��J�t�μg�J
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.ProcessQueryCondition(condition, "=", "INFORM_DATE", Me.INFORM_DATE)      '�q������, ����줣��ק�
                Me.ProcessQueryCondition(condition, ">=", "INFORM_DATE", Me.S_INFORM_DATE) '�}����
                Me.ProcessQueryCondition(condition, "<=", "INFORM_DATE", Me.E_INFORM_DATE) '�}����
                Me.ProcessQueryCondition(condition, "=", "PAY_CODE", Me.PAY_CODE)        '�O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "PAY_NAME", Me.PAY_NAME)       '�O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME
                Me.ProcessQueryCondition(condition, "=", "PAY_COUNT", Me.PAY_COUNT)      '�ƶq
                Me.ProcessQueryCondition(condition, "=", "PAY_AMT", Me.PAY_AMT)      '�O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr
                Me.ProcessQueryCondition(condition, "%LIKE%", "PAY_USER", Me.PAY_USER)        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.ProcessQueryCondition(condition, "=", "PAY_BUS_NO", Me.PAY_BUS_NO)        '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.ProcessQueryCondition(condition, "=", "PAY_TEL", Me.PAY_TEL)      '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.ProcessQueryCondition(condition, "=", "DATE_LEN", Me.DATE_LEN)        '
                Me.ProcessQueryCondition(condition, "=", "PAY_DEADLINE", Me.PAY_DEADLINE)        'ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�
                Me.ProcessQueryCondition(condition, "=", "PAY_DATE", Me.PAY_DATE)        '�ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.ProcessQueryCondition(condition, "=", "FINAL_PAY_DATE", Me.FINAL_PAY_DATE)        '�ѷ��J�t�μg�J
                Me.ProcessQueryCondition(condition, "=", "PAY_STATUS", Me.PAY_STATUS)        '�ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h
                Me.ProcessQueryCondition(condition, "=", "PLEASE_STATUS", Me.PLEASE_STATUS)      '�ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�
                Me.ProcessQueryCondition(condition, "=", "PLEASE_DATE", Me.PLEASE_DATE)      '�ѡu�ץ�дڵn���v�\��g�J
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '�ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
                Me.ProcessQueryCondition(condition, "=", "CAN_FLAG", Me.CAN_FLAG)        '��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P
                Me.ProcessQueryCondition(condition, "=", "CANCEL_CAUSE", Me.CANCEL_CAUSE)        '�ѷ��J�t�μg�J
                Me.ProcessQueryCondition(condition, "=", "CAN_FLAG_DATE", Me.CAN_FLAG_DATE)      '�P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C
                Me.ProcessQueryCondition(condition, "=", "APPL021_PKNO", Me.APPL021_PKNO)        'REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������
                Me.ProcessQueryCondition(condition, "=", "RE_PRINT_COUNT", Me.RE_PRINT_COUNT)        '
                Me.ProcessQueryCondition(condition, "=", "SYNC_DATE", Me.SYNC_DATE)      '

                '�S����� OR �۩w����
                condition.Append(Me.QUERY_COND)

                Me.Ent_CSHT010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_CSHT010.OrderBys = "PKNO"
                Else
                    Me.Ent_CSHT010.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_CSHT010.Query()
                Else
                    result = Me.Ent_CSHT010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_CSHT010.TotalRowCount
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

