'ProductName                 : TSBA 
'File Name					 : CtAPP1170 
'Description	             : CtAPP1170 �W�D�򥻸��
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/14         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

NameSpace App.Business
	Public partial Class CtAPP1170
		Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1170 = new Ent_APP1170(Me.DBManager, Me.LogUtil)
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

#Region "CHANNEL_NAME �W�D�W��"
        '' <summary>
        '' CHANNEL_NAME �W�D�W��
        '' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.PropertyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE1 �Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'"
        '' <summary>
        '' ORG_TYPE1 �Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'
        '' </summary>
        Public Property ORG_TYPE1() As String
            Get
                Return Me.PropertyMap("ORG_TYPE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_TYPE1") = value
            End Set
        End Property
#End Region

#Region "COUNTRY ���y"
        '' <summary>
        '' COUNTRY ���y
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.PropertyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE2 �����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'"
        '' <summary>
        '' ORG_TYPE2 �����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'
        '' </summary>
        Public Property ORG_TYPE2() As String
            Get
                Return Me.PropertyMap("ORG_TYPE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_TYPE2") = value
            End Set
        End Property
#End Region

#Region "COM_NAME ���ݤ��q"
        '' <summary>
        '' COM_NAME ���ݤ��q
        '' </summary>
        Public Property COM_NAME() As String
            Get
                Return Me.PropertyMap("COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_NAME") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_S_DATE ��Ų����(�_)"
        '' <summary>
        '' EVALUATION_S_DATE ��Ų����(�_)
        '' </summary>
        Public Property EVALUATION_S_DATE() As String
            Get
                Return Me.PropertyMap("EVALUATION_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EVALUATION_S_DATE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_E_DATE ��Ų����(��)"
        '' <summary>
        '' EVALUATION_E_DATE ��Ų����(��)
        '' </summary>
        Public Property EVALUATION_E_DATE() As String
            Get
                Return Me.PropertyMap("EVALUATION_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EVALUATION_E_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE ����(�\�i)�Ĵ�(�_)"
        '' <summary>
        '' LICENSE_S_DATE ����(�\�i)�Ĵ�(�_)
        '' </summary>
        Public Property LICENSE_S_DATE() As String
            Get
                Return Me.PropertyMap("LICENSE_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_S_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_E_DATE ����(�\�i)�Ĵ�(��)"
        '' <summary>
        '' LICENSE_E_DATE ����(�\�i)�Ĵ�(��)
        '' </summary>
        Public Property LICENSE_E_DATE() As String
            Get
                Return Me.PropertyMap("LICENSE_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PLAY_S_DATE �}�����"
        '' <summary>
        '' PLAY_S_DATE �}�����
        '' </summary>
        Public Property PLAY_S_DATE() As String
            Get
                Return Me.PropertyMap("PLAY_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLAY_S_DATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_TYPE ��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'"
        '' <summary>
        '' CHANNEL_PAY_TYPE ��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
        '' </summary>
        Public Property CHANNEL_PAY_TYPE() As String
            Get
                Return Me.PropertyMap("CHANNEL_PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_DESC ����"
        '' <summary>
        '' CHANNEL_PAY_DESC ����
        '' </summary>
        Public Property CHANNEL_PAY_DESC() As String
            Get
                Return Me.PropertyMap("CHANNEL_PAY_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_PAY_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG �������X, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG �������X, REF. SYST010.SYS_KEY='RESULT1'

        '' </summary>
        Public Property LOCK_CHANNEL_FLAG() As String
            Get
                Return Me.PropertyMap("LOCK_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LOCK_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG1 �W�D�ݩ�-�s�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG1 �W�D�ݩ�-�s�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG1() As String
            Get
                Return Me.PropertyMap("CH_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG1") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG2 �W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG2 �W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG2() As String
            Get
                Return Me.PropertyMap("CH_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG2") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG3 �W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG3 �W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG3() As String
            Get
                Return Me.PropertyMap("CH_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG3") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG4 �W�D�ݩ�-���, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG4 �W�D�ݩ�-���, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG4() As String
            Get
                Return Me.PropertyMap("CH_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG4") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG5 �W�D�ݩ�-���@, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG5 �W�D�ݩ�-���@, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG5() As String
            Get
                Return Me.PropertyMap("CH_FLAG5")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG5") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG6 �W�D�ݩ�-�q�v, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG6 �W�D�ݩ�-�q�v, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG6() As String
            Get
                Return Me.PropertyMap("CH_FLAG6")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG6") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG7 �W�D�ݩ�-��|, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG7 �W�D�ݩ�-��|, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG7() As String
            Get
                Return Me.PropertyMap("CH_FLAG7")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG7") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG8 �W�D�ݩ�-�Ш|���, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG8 �W�D�ݩ�-�Ш|���, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG8() As String
            Get
                Return Me.PropertyMap("CH_FLAG8")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG8") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG9 �W�D�ݩ�-����, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG9 �W�D�ݩ�-����, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG9() As String
            Get
                Return Me.PropertyMap("CH_FLAG9")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG9") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG10 �W�D�ݩ�-�v��, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG10 �W�D�ݩ�-�v��, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG10() As String
            Get
                Return Me.PropertyMap("CH_FLAG10")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG10") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG11 �W�D�ݩ�-��X, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG11 �W�D�ݩ�-��X, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG11() As String
            Get
                Return Me.PropertyMap("CH_FLAG11")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG11") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG12 �W�D�ݩ�-�a���W�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG12 �W�D�ݩ�-�a���W�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG12() As String
            Get
                Return Me.PropertyMap("CH_FLAG12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG12") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13 �W�D�ݩ�-��L����, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG13 �W�D�ݩ�-��L����, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG13() As String
            Get
                Return Me.PropertyMap("CH_FLAG13")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG13") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13_DESC �W�D�ݩ�-��L����-����"
        '' <summary>
        '' CH_FLAG13_DESC �W�D�ݩ�-��L����-����
        '' </summary>
        Public Property CH_FLAG13_DESC() As String
            Get
                Return Me.PropertyMap("CH_FLAG13_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG13_DESC") = value
            End Set
        End Property
#End Region

#Region "CHARGE_STANDARD_AMT ���O�з�"
        '' <summary>
        '' CHARGE_STANDARD_AMT ���O�з�
        '' </summary>
        Public Property CHARGE_STANDARD_AMT() As String
            Get
                Return Me.PropertyMap("CHARGE_STANDARD_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE_STANDARD_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE1_AMT �e�G�~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE1_AMT �e�G�~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE1_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE1_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE2_AMT �e�@�~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE2_AMT �e�@�~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE2_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE3_AMT ���~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE3_AMT ���~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE3_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE3_AMT") = value
            End Set
        End Property
#End Region

#Region "SALES_AGENT ���~�׾P��N�z��"
        '' <summary>
        '' SALES_AGENT ���~�׾P��N�z��
        '' </summary>
        Public Property SALES_AGENT() As String
            Get
                Return Me.PropertyMap("SALES_AGENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_AGENT") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG1 �W�[�覡-���u�q��(����), �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG1 �W�[�覡-���u�q��(����), �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG1() As String
            Get
                Return Me.PropertyMap("SALES_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG1") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG2 �W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG2 �W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG2() As String
            Get
                Return Me.PropertyMap("SALES_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG2") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG3 �W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG3 �W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG3() As String
            Get
                Return Me.PropertyMap("SALES_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG3") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG4 �W�[�覡-�����ìP, �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG4 �W�[�覡-�����ìP, �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG4() As String
            Get
                Return Me.PropertyMap("SALES_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG4") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SIGN_NUMBER ñ���a��-����"
        '' <summary>
        '' ANALOGY_SIGN_NUMBER ñ���a��-����
        '' </summary>
        Public Property ANALOGY_SIGN_NUMBER() As String
            Get
                Return Me.PropertyMap("ANALOGY_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SIGN_NUMBER ñ���a��-�Ʀ�"
        '' <summary>
        '' DIGIT_SIGN_NUMBER ñ���a��-�Ʀ�
        '' </summary>
        Public Property DIGIT_SIGN_NUMBER() As String
            Get
                Return Me.PropertyMap("DIGIT_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SALES_RATE �W�[�v-����"
        '' <summary>
        '' ANALOGY_SALES_RATE �W�[�v-����
        '' </summary>
        Public Property ANALOGY_SALES_RATE() As String
            Get
                Return Me.PropertyMap("ANALOGY_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SALES_RATE �W�[�v-�Ʀ�"
        '' <summary>
        '' DIGIT_SALES_RATE �W�[�v-�Ʀ�
        '' </summary>
        Public Property DIGIT_SALES_RATE() As String
            Get
                Return Me.PropertyMap("DIGIT_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_F_NUMBER �W�D�M�ݤH�O"
        '' <summary>
        '' CHANNEL_F_NUMBER �W�D�M�ݤH�O
        '' </summary>
        Public Property CHANNEL_F_NUMBER() As String
            Get
                Return Me.PropertyMap("CHANNEL_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_F_NUMBER �W�D�s�f�H�O-�M¾"
        '' <summary>
        '' EDIT_F_NUMBER �W�D�s�f�H�O-�M¾
        '' </summary>
        Public Property EDIT_F_NUMBER() As String
            Get
                Return Me.PropertyMap("EDIT_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDIT_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_P_NUMBER �W�D�s�f�H�O-��¾"
        '' <summary>
        '' EDIT_P_NUMBER �W�D�s�f�H�O-��¾
        '' </summary>
        Public Property EDIT_P_NUMBER() As String
            Get
                Return Me.PropertyMap("EDIT_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDIT_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_AREA �ȪA�q��-�ϽX"
        '' <summary>
        '' SERVICE_TEL_AREA �ȪA�q��-�ϽX
        '' </summary>
        Public Property SERVICE_TEL_AREA() As String
            Get
                Return Me.PropertyMap("SERVICE_TEL_AREA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TEL_AREA") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL �ȪA�q��"
        '' <summary>
        '' SERVICE_TEL �ȪA�q��
        '' </summary>
        Public Property SERVICE_TEL() As String
            Get
                Return Me.PropertyMap("SERVICE_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TEL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_EMAIL �q�l�l��"
        '' <summary>
        '' SERVICE_EMAIL �q�l�l��
        '' </summary>
        Public Property SERVICE_EMAIL() As String
            Get
                Return Me.PropertyMap("SERVICE_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_EMAIL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER ��L"
        '' <summary>
        '' SERVICE_OTHER ��L
        '' </summary>
        Public Property SERVICE_OTHER() As String
            Get
                Return Me.PropertyMap("SERVICE_OTHER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_OTHER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_CASE_NUMBER ���z���-�ȪA"
        '' <summary>
        '' SERVICE_CASE_NUMBER ���z���-�ȪA
        '' </summary>
        Public Property SERVICE_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_CASE_NUMBER ���z���-�ӶD"
        '' <summary>
        '' COMPLAINT_CASE_NUMBER ���z���-�ӶD
        '' </summary>
        Public Property COMPLAINT_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("COMPLAINT_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "HANDLE_CASE_NUMBER �ֳB���"
        '' <summary>
        '' HANDLE_CASE_NUMBER �ֳB���
        '' </summary>
        Public Property HANDLE_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("HANDLE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HANDLE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DATA_DESC �򥻸�ƸɥR"
        '' <summary>
        '' DATA_DESC �򥻸�ƸɥR
        '' </summary>
        Public Property DATA_DESC() As String
            Get
                Return Me.PropertyMap("DATA_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1170"
        ' <summary>Ent_APP1170</ summary>
    Private Property  Ent_APP1170() As  Ent_APP1170		
        Get                                         
            Return Me.PropertyMap("Ent_APP1170")        
        End Get                                     
        Set(ByVal value As Ent_APP1170)                 
            Me.PropertyMap("Ent_APP1170") = value       
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
                Me.Ent_APP1170.CASE_NO	=	 Me.CASE_NO		 '�ץ�s��
                Me.Ent_APP1170.CHANNEL_NAME	=	 Me.CHANNEL_NAME		 '�W�D�W��
                Me.Ent_APP1170.ORG_TYPE1	=	 Me.ORG_TYPE1		 '�Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.Ent_APP1170.COUNTRY	=	 Me.COUNTRY		 '���y
                Me.Ent_APP1170.ORG_TYPE2	=	 Me.ORG_TYPE2		 '�����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.Ent_APP1170.COM_NAME	=	 Me.COM_NAME		 '���ݤ��q
                Me.Ent_APP1170.EVALUATION_S_DATE	=	 Me.EVALUATION_S_DATE		 '��Ų����(�_)
                Me.Ent_APP1170.EVALUATION_E_DATE	=	 Me.EVALUATION_E_DATE		 '��Ų����(��)
                Me.Ent_APP1170.LICENSE_S_DATE	=	 Me.LICENSE_S_DATE		 '����(�\�i)�Ĵ�(�_)
                Me.Ent_APP1170.LICENSE_E_DATE	=	 Me.LICENSE_E_DATE		 '����(�\�i)�Ĵ�(��)
                Me.Ent_APP1170.PLAY_S_DATE	=	 Me.PLAY_S_DATE		 '�}�����
                Me.Ent_APP1170.CHANNEL_PAY_TYPE	=	 Me.CHANNEL_PAY_TYPE		 '��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.Ent_APP1170.CHANNEL_PAY_DESC	=	 Me.CHANNEL_PAY_DESC		 '����
                Me.Ent_APP1170.LOCK_CHANNEL_FLAG	=	 Me.LOCK_CHANNEL_FLAG		 '�������X, REF. SYST010.SYS_KEY='RESULT1'

                Me.Ent_APP1170.CH_FLAG1	=	 Me.CH_FLAG1		 '�W�D�ݩ�-�s�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG2	=	 Me.CH_FLAG2		 '�W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG3	=	 Me.CH_FLAG3		 '�W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG4	=	 Me.CH_FLAG4		 '�W�D�ݩ�-���, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG5	=	 Me.CH_FLAG5		 '�W�D�ݩ�-���@, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG6	=	 Me.CH_FLAG6		 '�W�D�ݩ�-�q�v, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG7	=	 Me.CH_FLAG7		 '�W�D�ݩ�-��|, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG8	=	 Me.CH_FLAG8		 '�W�D�ݩ�-�Ш|���, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG9	=	 Me.CH_FLAG9		 '�W�D�ݩ�-����, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG10	=	 Me.CH_FLAG10		 '�W�D�ݩ�-�v��, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG11	=	 Me.CH_FLAG11		 '�W�D�ݩ�-��X, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG12	=	 Me.CH_FLAG12		 '�W�D�ݩ�-�a���W�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG13	=	 Me.CH_FLAG13		 '�W�D�ݩ�-��L����, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG13_DESC	=	 Me.CH_FLAG13_DESC		 '�W�D�ݩ�-��L����-����
                Me.Ent_APP1170.CHARGE_STANDARD_AMT	=	 Me.CHARGE_STANDARD_AMT		 '���O�з�
                Me.Ent_APP1170.CH_AUTHORIZE1_AMT	=	 Me.CH_AUTHORIZE1_AMT		 '�e�G�~���W�D���v�O
                Me.Ent_APP1170.CH_AUTHORIZE2_AMT	=	 Me.CH_AUTHORIZE2_AMT		 '�e�@�~���W�D���v�O
                Me.Ent_APP1170.CH_AUTHORIZE3_AMT	=	 Me.CH_AUTHORIZE3_AMT		 '���~���W�D���v�O
                Me.Ent_APP1170.SALES_AGENT	=	 Me.SALES_AGENT		 '���~�׾P��N�z��
                Me.Ent_APP1170.SALES_FLAG1	=	 Me.SALES_FLAG1		 '�W�[�覡-���u�q��(����), �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG2	=	 Me.SALES_FLAG2		 '�W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG3	=	 Me.SALES_FLAG3		 '�W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG4	=	 Me.SALES_FLAG4		 '�W�[�覡-�����ìP, �Ŀאּ'Y'
                Me.Ent_APP1170.ANALOGY_SIGN_NUMBER	=	 Me.ANALOGY_SIGN_NUMBER		 'ñ���a��-����
                Me.Ent_APP1170.DIGIT_SIGN_NUMBER	=	 Me.DIGIT_SIGN_NUMBER		 'ñ���a��-�Ʀ�
                Me.Ent_APP1170.ANALOGY_SALES_RATE	=	 Me.ANALOGY_SALES_RATE		 '�W�[�v-����
                Me.Ent_APP1170.DIGIT_SALES_RATE	=	 Me.DIGIT_SALES_RATE		 '�W�[�v-�Ʀ�
                Me.Ent_APP1170.CHANNEL_F_NUMBER	=	 Me.CHANNEL_F_NUMBER		 '�W�D�M�ݤH�O
                Me.Ent_APP1170.EDIT_F_NUMBER	=	 Me.EDIT_F_NUMBER		 '�W�D�s�f�H�O-�M¾
                Me.Ent_APP1170.EDIT_P_NUMBER	=	 Me.EDIT_P_NUMBER		 '�W�D�s�f�H�O-��¾
                Me.Ent_APP1170.SERVICE_TEL_AREA	=	 Me.SERVICE_TEL_AREA		 '�ȪA�q��-�ϽX
                Me.Ent_APP1170.SERVICE_TEL	=	 Me.SERVICE_TEL		 '�ȪA�q��
                Me.Ent_APP1170.SERVICE_EMAIL	=	 Me.SERVICE_EMAIL		 '�q�l�l��
                Me.Ent_APP1170.SERVICE_OTHER	=	 Me.SERVICE_OTHER		 '��L
                Me.Ent_APP1170.SERVICE_CASE_NUMBER	=	 Me.SERVICE_CASE_NUMBER		 '���z���-�ȪA
                Me.Ent_APP1170.COMPLAINT_CASE_NUMBER	=	 Me.COMPLAINT_CASE_NUMBER		 '���z���-�ӶD
                Me.Ent_APP1170.HANDLE_CASE_NUMBER	=	 Me.HANDLE_CASE_NUMBER		 '�ֳB���
                Me.Ent_APP1170.DATA_DESC	=	 Me.DATA_DESC		 '�򥻸�ƸɥR


                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_APP1170.Insert()

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
                Me.Ent_APP1170.CASE_NO	=	 Me.CASE_NO		 '�ץ�s��
                Me.Ent_APP1170.CHANNEL_NAME	=	 Me.CHANNEL_NAME		 '�W�D�W��
                Me.Ent_APP1170.ORG_TYPE1	=	 Me.ORG_TYPE1		 '�Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.Ent_APP1170.COUNTRY	=	 Me.COUNTRY		 '���y
                Me.Ent_APP1170.ORG_TYPE2	=	 Me.ORG_TYPE2		 '�����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.Ent_APP1170.COM_NAME	=	 Me.COM_NAME		 '���ݤ��q
                Me.Ent_APP1170.EVALUATION_S_DATE	=	 Me.EVALUATION_S_DATE		 '��Ų����(�_)
                Me.Ent_APP1170.EVALUATION_E_DATE	=	 Me.EVALUATION_E_DATE		 '��Ų����(��)
                Me.Ent_APP1170.LICENSE_S_DATE	=	 Me.LICENSE_S_DATE		 '����(�\�i)�Ĵ�(�_)
                Me.Ent_APP1170.LICENSE_E_DATE	=	 Me.LICENSE_E_DATE		 '����(�\�i)�Ĵ�(��)
                Me.Ent_APP1170.PLAY_S_DATE	=	 Me.PLAY_S_DATE		 '�}�����
                Me.Ent_APP1170.CHANNEL_PAY_TYPE	=	 Me.CHANNEL_PAY_TYPE		 '��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.Ent_APP1170.CHANNEL_PAY_DESC	=	 Me.CHANNEL_PAY_DESC		 '����
                Me.Ent_APP1170.LOCK_CHANNEL_FLAG	=	 Me.LOCK_CHANNEL_FLAG		 '�������X, REF. SYST010.SYS_KEY='RESULT1'

                Me.Ent_APP1170.CH_FLAG1	=	 Me.CH_FLAG1		 '�W�D�ݩ�-�s�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG2	=	 Me.CH_FLAG2		 '�W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG3	=	 Me.CH_FLAG3		 '�W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG4	=	 Me.CH_FLAG4		 '�W�D�ݩ�-���, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG5	=	 Me.CH_FLAG5		 '�W�D�ݩ�-���@, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG6	=	 Me.CH_FLAG6		 '�W�D�ݩ�-�q�v, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG7	=	 Me.CH_FLAG7		 '�W�D�ݩ�-��|, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG8	=	 Me.CH_FLAG8		 '�W�D�ݩ�-�Ш|���, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG9	=	 Me.CH_FLAG9		 '�W�D�ݩ�-����, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG10	=	 Me.CH_FLAG10		 '�W�D�ݩ�-�v��, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG11	=	 Me.CH_FLAG11		 '�W�D�ݩ�-��X, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG12	=	 Me.CH_FLAG12		 '�W�D�ݩ�-�a���W�D, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG13	=	 Me.CH_FLAG13		 '�W�D�ݩ�-��L����, �Ŀאּ'Y'
                Me.Ent_APP1170.CH_FLAG13_DESC	=	 Me.CH_FLAG13_DESC		 '�W�D�ݩ�-��L����-����
                Me.Ent_APP1170.CHARGE_STANDARD_AMT	=	 Me.CHARGE_STANDARD_AMT		 '���O�з�
                Me.Ent_APP1170.CH_AUTHORIZE1_AMT	=	 Me.CH_AUTHORIZE1_AMT		 '�e�G�~���W�D���v�O
                Me.Ent_APP1170.CH_AUTHORIZE2_AMT	=	 Me.CH_AUTHORIZE2_AMT		 '�e�@�~���W�D���v�O
                Me.Ent_APP1170.CH_AUTHORIZE3_AMT	=	 Me.CH_AUTHORIZE3_AMT		 '���~���W�D���v�O
                Me.Ent_APP1170.SALES_AGENT	=	 Me.SALES_AGENT		 '���~�׾P��N�z��
                Me.Ent_APP1170.SALES_FLAG1	=	 Me.SALES_FLAG1		 '�W�[�覡-���u�q��(����), �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG2	=	 Me.SALES_FLAG2		 '�W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG3	=	 Me.SALES_FLAG3		 '�W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'
                Me.Ent_APP1170.SALES_FLAG4	=	 Me.SALES_FLAG4		 '�W�[�覡-�����ìP, �Ŀאּ'Y'
                Me.Ent_APP1170.ANALOGY_SIGN_NUMBER	=	 Me.ANALOGY_SIGN_NUMBER		 'ñ���a��-����
                Me.Ent_APP1170.DIGIT_SIGN_NUMBER	=	 Me.DIGIT_SIGN_NUMBER		 'ñ���a��-�Ʀ�
                Me.Ent_APP1170.ANALOGY_SALES_RATE	=	 Me.ANALOGY_SALES_RATE		 '�W�[�v-����
                Me.Ent_APP1170.DIGIT_SALES_RATE	=	 Me.DIGIT_SALES_RATE		 '�W�[�v-�Ʀ�
                Me.Ent_APP1170.CHANNEL_F_NUMBER	=	 Me.CHANNEL_F_NUMBER		 '�W�D�M�ݤH�O
                Me.Ent_APP1170.EDIT_F_NUMBER	=	 Me.EDIT_F_NUMBER		 '�W�D�s�f�H�O-�M¾
                Me.Ent_APP1170.EDIT_P_NUMBER	=	 Me.EDIT_P_NUMBER		 '�W�D�s�f�H�O-��¾
                Me.Ent_APP1170.SERVICE_TEL_AREA	=	 Me.SERVICE_TEL_AREA		 '�ȪA�q��-�ϽX
                Me.Ent_APP1170.SERVICE_TEL	=	 Me.SERVICE_TEL		 '�ȪA�q��
                Me.Ent_APP1170.SERVICE_EMAIL	=	 Me.SERVICE_EMAIL		 '�q�l�l��
                Me.Ent_APP1170.SERVICE_OTHER	=	 Me.SERVICE_OTHER		 '��L
                Me.Ent_APP1170.SERVICE_CASE_NUMBER	=	 Me.SERVICE_CASE_NUMBER		 '���z���-�ȪA
                Me.Ent_APP1170.COMPLAINT_CASE_NUMBER	=	 Me.COMPLAINT_CASE_NUMBER		 '���z���-�ӶD
                Me.Ent_APP1170.HANDLE_CASE_NUMBER	=	 Me.HANDLE_CASE_NUMBER		 '�ֳB���
                Me.Ent_APP1170.DATA_DESC	=	 Me.DATA_DESC		 '�򥻸�ƸɥR


    		'=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                             
		Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)     
 		Me.Ent_APP1170.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_APP1170.Update()

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
 		Me.Ent_APP1170.SqlRetrictions = Me.ProcessCondition(condition.ToString())

 

                '=== �R����� ===
				If Me.Ent_APP1170.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APP1170.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)		 'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)		 '�ץ�s��
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_NAME", Me.CHANNEL_NAME)		 '�W�D�W��
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE1", Me.ORG_TYPE1)		 '�Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)		 '���y
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE2", Me.ORG_TYPE2)		 '�����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_NAME", Me.COM_NAME)		 '���ݤ��q
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_S_DATE", Me.EVALUATION_S_DATE)		 '��Ų����(�_)
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_E_DATE", Me.EVALUATION_E_DATE)		 '��Ų����(��)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)		 '����(�\�i)�Ĵ�(�_)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)		 '����(�\�i)�Ĵ�(��)
                Me.ProcessQueryCondition(condition, "=", "PLAY_S_DATE", Me.PLAY_S_DATE)		 '�}�����
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_PAY_TYPE", Me.CHANNEL_PAY_TYPE)		 '��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_PAY_DESC", Me.CHANNEL_PAY_DESC)		 '����
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG)		 '�������X, REF. SYST010.SYS_KEY='RESULT1'

                Me.ProcessQueryCondition(condition, "=", "CH_FLAG1", Me.CH_FLAG1)		 '�W�D�ݩ�-�s�D, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG2", Me.CH_FLAG2)		 '�W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG3", Me.CH_FLAG3)		 '�W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG4", Me.CH_FLAG4)		 '�W�D�ݩ�-���, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG5", Me.CH_FLAG5)		 '�W�D�ݩ�-���@, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG6", Me.CH_FLAG6)		 '�W�D�ݩ�-�q�v, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG7", Me.CH_FLAG7)		 '�W�D�ݩ�-��|, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG8", Me.CH_FLAG8)		 '�W�D�ݩ�-�Ш|���, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG9", Me.CH_FLAG9)		 '�W�D�ݩ�-����, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG10", Me.CH_FLAG10)		 '�W�D�ݩ�-�v��, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG11", Me.CH_FLAG11)		 '�W�D�ݩ�-��X, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG12", Me.CH_FLAG12)		 '�W�D�ݩ�-�a���W�D, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG13", Me.CH_FLAG13)		 '�W�D�ݩ�-��L����, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_FLAG13_DESC", Me.CH_FLAG13_DESC)		 '�W�D�ݩ�-��L����-����
                Me.ProcessQueryCondition(condition, "=", "CHARGE_STANDARD_AMT", Me.CHARGE_STANDARD_AMT)		 '���O�з�
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE1_AMT", Me.CH_AUTHORIZE1_AMT)		 '�e�G�~���W�D���v�O
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE2_AMT", Me.CH_AUTHORIZE2_AMT)		 '�e�@�~���W�D���v�O
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE3_AMT", Me.CH_AUTHORIZE3_AMT)		 '���~���W�D���v�O
                Me.ProcessQueryCondition(condition, "=", "SALES_AGENT", Me.SALES_AGENT)		 '���~�׾P��N�z��
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG1", Me.SALES_FLAG1)		 '�W�[�覡-���u�q��(����), �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG2", Me.SALES_FLAG2)		 '�W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG3", Me.SALES_FLAG3)		 '�W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG4", Me.SALES_FLAG4)		 '�W�[�覡-�����ìP, �Ŀאּ'Y'
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SIGN_NUMBER", Me.ANALOGY_SIGN_NUMBER)		 'ñ���a��-����
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SIGN_NUMBER", Me.DIGIT_SIGN_NUMBER)		 'ñ���a��-�Ʀ�
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SALES_RATE", Me.ANALOGY_SALES_RATE)		 '�W�[�v-����
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SALES_RATE", Me.DIGIT_SALES_RATE)		 '�W�[�v-�Ʀ�
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_F_NUMBER", Me.CHANNEL_F_NUMBER)		 '�W�D�M�ݤH�O
                Me.ProcessQueryCondition(condition, "=", "EDIT_F_NUMBER", Me.EDIT_F_NUMBER)		 '�W�D�s�f�H�O-�M¾
                Me.ProcessQueryCondition(condition, "=", "EDIT_P_NUMBER", Me.EDIT_P_NUMBER)		 '�W�D�s�f�H�O-��¾
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL_AREA", Me.SERVICE_TEL_AREA)		 '�ȪA�q��-�ϽX
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL", Me.SERVICE_TEL)		 '�ȪA�q��
                Me.ProcessQueryCondition(condition, "=", "SERVICE_EMAIL", Me.SERVICE_EMAIL)		 '�q�l�l��
                Me.ProcessQueryCondition(condition, "=", "SERVICE_OTHER", Me.SERVICE_OTHER)		 '��L
                Me.ProcessQueryCondition(condition, "=", "SERVICE_CASE_NUMBER", Me.SERVICE_CASE_NUMBER)		 '���z���-�ȪA
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_CASE_NUMBER", Me.COMPLAINT_CASE_NUMBER)		 '���z���-�ӶD
                Me.ProcessQueryCondition(condition, "=", "HANDLE_CASE_NUMBER", Me.HANDLE_CASE_NUMBER)		 '�ֳB���
                Me.ProcessQueryCondition(condition, "%LIKE%", "DATA_DESC", Me.DATA_DESC)		 '�򥻸�ƸɥR

                Me.Ent_APP1170.SqlRetrictions = condition.ToString()

         
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1170.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1170.OrderBys = Me.OrderBys
                End If
                
                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1170.Query()
                Else
                    result = Me.Ent_APP1170.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1170.TotalRowCount
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
End NameSpace

