'----------------------------------------------------------------------------------
'File Name		: APP1170
'Author			:  
'Description		: APP1170 �W�D�򥻸��
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/14	 		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1170 �W�D�򥻸��
    ' </summary>
    Public Class ENT_APP1170
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "�غc�l"
        ' <summary>
        ' �غc�l/�B�z�ݩʹ����B�z
        ' </summary>
        ' <param name="dt">DataTable ����</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' �غc�l/�B�z���ʳB�z
        ' </summary>
        ' <param name="dbManager">DBManager ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "APP1170"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,CHANNEL_NAME,COUNTRY,COM_NAME,CHANNEL_PAY_DESC,CH_FLAG13_DESC,SALES_AGENT,SERVICE_OTHER,DATA_DESC"
            Me.SET_NULL_FIELD = "ANALOGY_SALES_RATE,DIGIT_SALES_RATE,EVALUATION_S_DATE,EVALUATION_E_DATE,LICENSE_S_DATE,LICENSE_E_DATE,PLAY_S_DATE"
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��"
        '' <summary>
        '' CASE_NO �ץ�s��
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_NAME �W�D�W��"
        '' <summary>
        '' CHANNEL_NAME �W�D�W��
        '' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE1 �Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'"
        '' <summary>
        '' ORG_TYPE1 �Ʒ~���O, REF. SYST010.SYS_KEY='ORG_TYPE1'
        '' </summary>
        Public Property ORG_TYPE1() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE1") = value
            End Set
        End Property
#End Region

#Region "COUNTRY ���y"
        '' <summary>
        '' COUNTRY ���y
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.ColumnyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE2 �����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'"
        '' <summary>
        '' ORG_TYPE2 �����q�ΥN�z��, REF.SYST010.SYS_KEY='ORG_TYPE2'
        '' </summary>
        Public Property ORG_TYPE2() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE2") = value
            End Set
        End Property
#End Region

#Region "COM_NAME ���ݤ��q"
        '' <summary>
        '' COM_NAME ���ݤ��q
        '' </summary>
        Public Property COM_NAME() As String
            Get
                Return Me.ColumnyMap("COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_NAME") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_S_DATE ��Ų����(�_)"
        '' <summary>
        '' EVALUATION_S_DATE ��Ų����(�_)
        '' </summary>
        Public Property EVALUATION_S_DATE() As String
            Get
                Return Me.ColumnyMap("EVALUATION_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EVALUATION_S_DATE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_E_DATE ��Ų����(��)"
        '' <summary>
        '' EVALUATION_E_DATE ��Ų����(��)
        '' </summary>
        Public Property EVALUATION_E_DATE() As String
            Get
                Return Me.ColumnyMap("EVALUATION_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EVALUATION_E_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE ����(�\�i)�Ĵ�(�_)"
        '' <summary>
        '' LICENSE_S_DATE ����(�\�i)�Ĵ�(�_)
        '' </summary>
        Public Property LICENSE_S_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_S_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_E_DATE ����(�\�i)�Ĵ�(��)"
        '' <summary>
        '' LICENSE_E_DATE ����(�\�i)�Ĵ�(��)
        '' </summary>
        Public Property LICENSE_E_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PLAY_S_DATE �}�����"
        '' <summary>
        '' PLAY_S_DATE �}�����
        '' </summary>
        Public Property PLAY_S_DATE() As String
            Get
                Return Me.ColumnyMap("PLAY_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PLAY_S_DATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_TYPE ��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'"
        '' <summary>
        '' CHANNEL_PAY_TYPE ��/�I�O, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
        '' </summary>
        Public Property CHANNEL_PAY_TYPE() As String
            Get
                Return Me.ColumnyMap("CHANNEL_PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_DESC ����"
        '' <summary>
        '' CHANNEL_PAY_DESC ����
        '' </summary>
        Public Property CHANNEL_PAY_DESC() As String
            Get
                Return Me.ColumnyMap("CHANNEL_PAY_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_PAY_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG �������X, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG �������X, REF. SYST010.SYS_KEY='RESULT1'

        '' </summary>
        Public Property LOCK_CHANNEL_FLAG() As String
            Get
                Return Me.ColumnyMap("LOCK_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LOCK_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG1 �W�D�ݩ�-�s�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG1 �W�D�ݩ�-�s�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG1() As String
            Get
                Return Me.ColumnyMap("CH_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG1") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG2 �W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG2 �W�D�ݩ�-�]�g�s�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG2() As String
            Get
                Return Me.ColumnyMap("CH_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG2") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG3 �W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG3 �W�D�ݩ�-�]�g�ѥ�, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG3() As String
            Get
                Return Me.ColumnyMap("CH_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG3") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG4 �W�D�ݩ�-���, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG4 �W�D�ݩ�-���, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG4() As String
            Get
                Return Me.ColumnyMap("CH_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG4") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG5 �W�D�ݩ�-���@, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG5 �W�D�ݩ�-���@, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG5() As String
            Get
                Return Me.ColumnyMap("CH_FLAG5")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG5") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG6 �W�D�ݩ�-�q�v, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG6 �W�D�ݩ�-�q�v, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG6() As String
            Get
                Return Me.ColumnyMap("CH_FLAG6")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG6") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG7 �W�D�ݩ�-��|, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG7 �W�D�ݩ�-��|, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG7() As String
            Get
                Return Me.ColumnyMap("CH_FLAG7")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG7") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG8 �W�D�ݩ�-�Ш|���, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG8 �W�D�ݩ�-�Ш|���, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG8() As String
            Get
                Return Me.ColumnyMap("CH_FLAG8")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG8") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG9 �W�D�ݩ�-����, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG9 �W�D�ݩ�-����, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG9() As String
            Get
                Return Me.ColumnyMap("CH_FLAG9")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG9") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG10 �W�D�ݩ�-�v��, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG10 �W�D�ݩ�-�v��, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG10() As String
            Get
                Return Me.ColumnyMap("CH_FLAG10")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG10") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG11 �W�D�ݩ�-��X, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG11 �W�D�ݩ�-��X, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG11() As String
            Get
                Return Me.ColumnyMap("CH_FLAG11")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG11") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG12 �W�D�ݩ�-�a���W�D, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG12 �W�D�ݩ�-�a���W�D, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG12() As String
            Get
                Return Me.ColumnyMap("CH_FLAG12")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG12") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13 �W�D�ݩ�-��L����, �Ŀאּ'Y'"
        '' <summary>
        '' CH_FLAG13 �W�D�ݩ�-��L����, �Ŀאּ'Y'
        '' </summary>
        Public Property CH_FLAG13() As String
            Get
                Return Me.ColumnyMap("CH_FLAG13")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG13") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13_DESC �W�D�ݩ�-��L����-����"
        '' <summary>
        '' CH_FLAG13_DESC �W�D�ݩ�-��L����-����
        '' </summary>
        Public Property CH_FLAG13_DESC() As String
            Get
                Return Me.ColumnyMap("CH_FLAG13_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG13_DESC") = value
            End Set
        End Property
#End Region

#Region "CHARGE_STANDARD_AMT ���O�з�"
        '' <summary>
        '' CHARGE_STANDARD_AMT ���O�з�
        '' </summary>
        Public Property CHARGE_STANDARD_AMT() As String
            Get
                Return Me.ColumnyMap("CHARGE_STANDARD_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE_STANDARD_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE1_AMT �e�G�~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE1_AMT �e�G�~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE1_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE1_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE2_AMT �e�@�~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE2_AMT �e�@�~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE2_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE3_AMT ���~���W�D���v�O"
        '' <summary>
        '' CH_AUTHORIZE3_AMT ���~���W�D���v�O
        '' </summary>
        Public Property CH_AUTHORIZE3_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE3_AMT") = value
            End Set
        End Property
#End Region

#Region "SALES_AGENT ���~�׾P��N�z��"
        '' <summary>
        '' SALES_AGENT ���~�׾P��N�z��
        '' </summary>
        Public Property SALES_AGENT() As String
            Get
                Return Me.ColumnyMap("SALES_AGENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_AGENT") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG1 �W�[�覡-���u�q��(����), �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG1 �W�[�覡-���u�q��(����), �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG1() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG1") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG2 �W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG2 �W�[�覡-���u�q��(�Ʀ�), �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG2() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG2") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG3 �W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG3 �W�[�覡-��L�Ѥ�������ť�����e���O, �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG3() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG3") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG4 �W�[�覡-�����ìP, �Ŀאּ'Y'"
        '' <summary>
        '' SALES_FLAG4 �W�[�覡-�����ìP, �Ŀאּ'Y'
        '' </summary>
        Public Property SALES_FLAG4() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG4") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SIGN_NUMBER ñ���a��-����"
        '' <summary>
        '' ANALOGY_SIGN_NUMBER ñ���a��-����
        '' </summary>
        Public Property ANALOGY_SIGN_NUMBER() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SIGN_NUMBER ñ���a��-�Ʀ�"
        '' <summary>
        '' DIGIT_SIGN_NUMBER ñ���a��-�Ʀ�
        '' </summary>
        Public Property DIGIT_SIGN_NUMBER() As String
            Get
                Return Me.ColumnyMap("DIGIT_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SALES_RATE �W�[�v-����"
        '' <summary>
        '' ANALOGY_SALES_RATE �W�[�v-����
        '' </summary>
        Public Property ANALOGY_SALES_RATE() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SALES_RATE �W�[�v-�Ʀ�"
        '' <summary>
        '' DIGIT_SALES_RATE �W�[�v-�Ʀ�
        '' </summary>
        Public Property DIGIT_SALES_RATE() As String
            Get
                Return Me.ColumnyMap("DIGIT_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_F_NUMBER �W�D�M�ݤH�O"
        '' <summary>
        '' CHANNEL_F_NUMBER �W�D�M�ݤH�O
        '' </summary>
        Public Property CHANNEL_F_NUMBER() As String
            Get
                Return Me.ColumnyMap("CHANNEL_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_F_NUMBER �W�D�s�f�H�O-�M¾"
        '' <summary>
        '' EDIT_F_NUMBER �W�D�s�f�H�O-�M¾
        '' </summary>
        Public Property EDIT_F_NUMBER() As String
            Get
                Return Me.ColumnyMap("EDIT_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDIT_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_P_NUMBER �W�D�s�f�H�O-��¾"
        '' <summary>
        '' EDIT_P_NUMBER �W�D�s�f�H�O-��¾
        '' </summary>
        Public Property EDIT_P_NUMBER() As String
            Get
                Return Me.ColumnyMap("EDIT_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDIT_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_AREA �ȪA�q��-�ϽX"
        '' <summary>
        '' SERVICE_TEL_AREA �ȪA�q��-�ϽX
        '' </summary>
        Public Property SERVICE_TEL_AREA() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL_AREA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL_AREA") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL �ȪA�q��"
        '' <summary>
        '' SERVICE_TEL �ȪA�q��
        '' </summary>
        Public Property SERVICE_TEL() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_EMAIL �q�l�l��"
        '' <summary>
        '' SERVICE_EMAIL �q�l�l��
        '' </summary>
        Public Property SERVICE_EMAIL() As String
            Get
                Return Me.ColumnyMap("SERVICE_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_EMAIL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER ��L"
        '' <summary>
        '' SERVICE_OTHER ��L
        '' </summary>
        Public Property SERVICE_OTHER() As String
            Get
                Return Me.ColumnyMap("SERVICE_OTHER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_OTHER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_CASE_NUMBER ���z���-�ȪA"
        '' <summary>
        '' SERVICE_CASE_NUMBER ���z���-�ȪA
        '' </summary>
        Public Property SERVICE_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_CASE_NUMBER ���z���-�ӶD"
        '' <summary>
        '' COMPLAINT_CASE_NUMBER ���z���-�ӶD
        '' </summary>
        Public Property COMPLAINT_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "HANDLE_CASE_NUMBER �ֳB���"
        '' <summary>
        '' HANDLE_CASE_NUMBER �ֳB���
        '' </summary>
        Public Property HANDLE_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("HANDLE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HANDLE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DATA_DESC �򥻸�ƸɥR"
        '' <summary>
        '' DATA_DESC �򥻸�ƸɥR
        '' </summary>
        Public Property DATA_DESC() As String
            Get
                Return Me.ColumnyMap("DATA_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_DESC") = value
            End Set
        End Property
#End Region



#End Region

#Region "�ۭq��k"
#Region "Query �d�� "
        ''' <summary>
        ''' �d�� 
        ''' </summary>
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

        ''' <summary>
        ''' �d�� 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   �s�W��k
        ''' </remarks>
        'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()
        '
        '        '=== �ˮ����_�l ===
        '        Dim faileArguments As ArrayList = New ArrayList()
        '
        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== �ˮ���쵲�� ===
        '
        '        '=== �B�z�O�W ===
        '        Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
        '        Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
        '        Me.ParserAlias()
        '
        '        Dim sql As New StringBuilder
        '        sql.AppendLine(" SELECT M.*, R1.COLUMN2 ")
        '        sql.AppendLine(" FROM SCST020 M ")
        '        sql.AppendLine(" LEFT JOIN SCST040 R1 ON M.TUTOR_CLASSNO = R1.TUTOR_CLASSNO ")
        '
        '        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
        '            sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
        '        End If
        '
        '        If Me.OrderBys <> "" Then
        '            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
        '        Else
        '            If pageNo = 0 Then
        '                sql.AppendLine(" ORDER BY M.STNO ")
        '            Else
        '                sql.AppendLine(" ORDER BY STNO ")
        '            End If
        '        End If
        '
        '        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)
        '
        '        Me.ResetColumnProperty()
        '
        '        Return dt
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function
#End Region
#End Region



    End Class
End Namespace

