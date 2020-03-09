'----------------------------------------------------------------------------------
'File Name		: CSHT010
'Author			:  
'Description		: CSHT010 ú�ڬ���
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/27	 		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Csh.Data
    ' <summary>
    ' CSHT010 ú�ڬ���
    ' </summary>
    Public Class ENT_CSHT010
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
            Me.TableName = "CSHT010"
            Me.SysName = "CSH"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "PAY_NAME,PAY_USER,PAY_TEL,REMARK,CANCEL_CAUSE"
            Me.SET_NULL_FIELD = "INFORM_DATE,PAY_AMT,PAY_DEADLINE,PAY_DATE,FINAL_PAY_DATE,PLEASE_DATE,CAN_FLAG_DATE,SYNC_DATE"
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��, INSERT�ɼg�J, ����줣��ק�"
        '' <summary>
        '' CASE_NO �ץ�s��, INSERT�ɼg�J, ����줣��ק�
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

#Region "YEAR �~��, INSERT�ɼg�J"
        '' <summary>
        '' YEAR �~��, INSERT�ɼg�J
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.ColumnyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�"
        '' <summary>
        '' ITEM_TYPE ú�ڶ������O, INSERT�ɼg�J, ����줣��ק�, 1: ���w�q 2: �f�d�Oú�ڳ� 3: �f��Oú�ڳ� 4. �f�w�ҩ��Oú�ڳ�
        '' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.ColumnyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM_TYPE") = value
            End Set
        End Property
#End Region

#Region "PAYMENT_ACNT ú�ڥN�X, �ѷ��J�t�μg�J"
        '' <summary>
        '' PAYMENT_ACNT ú�ڥN�X, �ѷ��J�t�μg�J
        '' </summary>
        Public Property PAYMENT_ACNT() As String
            Get
                Return Me.ColumnyMap("PAYMENT_ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAYMENT_ACNT") = value
            End Set
        End Property
#End Region

#Region "COM_PKNO ������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' COM_PKNO ������c�W��, REF. APPL010.PKNO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.ColumnyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "INFORM_DATE �q������, ����줣��ק�"
        '' <summary>
        '' INFORM_DATE �q������, ����줣��ק�
        '' </summary>
        Public Property INFORM_DATE() As String
            Get
                Return Me.ColumnyMap("INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INFORM_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_CODE �O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'"
        '' <summary>
        '' PAY_CODE �O�ΥN�X, REF. SYST010.SYS_KEY='PAY_CODE'
        '' </summary>
        Public Property PAY_CODE() As String
            Get
                Return Me.ColumnyMap("PAY_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_CODE") = value
            End Set
        End Property
#End Region

#Region "PAY_NAME �O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME"
        '' <summary>
        '' PAY_NAME �O�ΦW��, �����s�ɮ�REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_NAME
        '' </summary>
        Public Property PAY_NAME() As String
            Get
                Return Me.ColumnyMap("PAY_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_NAME") = value
            End Set
        End Property
#End Region

#Region "PAY_COUNT �ƶq"
        '' <summary>
        '' PAY_COUNT �ƶq
        '' </summary>
        Public Property PAY_COUNT() As String
            Get
                Return Me.ColumnyMap("PAY_COUNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_COUNT") = value
            End Set
        End Property
#End Region

#Region "PAY_AMT �O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr"
        '' <summary>
        '' PAY_AMT �O��, ����줣��ק�, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010������SYS_RSV1, �n��SYST010.SYS_RSV1���ȥѦr���ন�Ʀr
        '' </summary>
        Public Property PAY_AMT() As String
            Get
                Return Me.ColumnyMap("PAY_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_AMT") = value
            End Set
        End Property
#End Region

#Region "PAY_USER �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_USER �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_USER() As String
            Get
                Return Me.ColumnyMap("PAY_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_USER") = value
            End Set
        End Property
#End Region

#Region "PAY_BUS_NO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_BUS_NO �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_BUS_NO() As String
            Get
                Return Me.ColumnyMap("PAY_BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_BUS_NO") = value
            End Set
        End Property
#End Region

#Region "PAY_TEL �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' PAY_TEL �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property PAY_TEL() As String
            Get
                Return Me.ColumnyMap("PAY_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_TEL") = value
            End Set
        End Property
#End Region

#Region "DATE_LEN DATE_LEN"
        '' <summary>
        '' DATE_LEN DATE_LEN
        '' </summary>
        Public Property DATE_LEN() As String
            Get
                Return Me.ColumnyMap("DATE_LEN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATE_LEN") = value
            End Set
        End Property
#End Region

#Region "PAY_DEADLINE ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�"
        '' <summary>
        '' PAY_DEADLINE ú�Ǵ���=�q�������]�������^+ú�Ǵ����Ѽ�
        '' </summary>
        Public Property PAY_DEADLINE() As String
            Get
                Return Me.ColumnyMap("PAY_DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_DEADLINE") = value
            End Set
        End Property
#End Region

#Region "PAY_DATE �ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE"
        '' <summary>
        '' PAY_DATE �ϥΪ̵n����ú�O�������, ����줣��ק�, �ѡu�f�d�O��ú�ץ�v�B�u�f��O��ú�ץ�v�B�u�}�߼f�w�ҩ��v�\��g�J, ��ƨӦ۩�:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
        '' </summary>
        Public Property PAY_DATE() As String
            Get
                Return Me.ColumnyMap("PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "FINAL_PAY_DATE �ѷ��J�t�μg�J"
        '' <summary>
        '' FINAL_PAY_DATE �ѷ��J�t�μg�J
        '' </summary>
        Public Property FINAL_PAY_DATE() As String
            Get
                Return Me.ColumnyMap("FINAL_PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FINAL_PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_STATUS �ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h"
        '' <summary>
        '' PAY_STATUS �ѷ��J�t�μg�J, REF. SYST010.SYS_KEY='PAY_STATUS', 1:�ݦ�, 2:���־P, 3:�浧�־P, 4:�wú�֦�, 5:��ú��, 6:��ú����, 7:��ú, A:�ݰh, B:�w�h
        '' </summary>
        Public Property PAY_STATUS() As String
            Get
                Return Me.ColumnyMap("PAY_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_STATUS �ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�"
        '' <summary>
        '' PLEASE_STATUS �ѡu�ץ�дڵn���v�\��g�J, 'Y': �]�w���w�д�, ': ���д�
        '' </summary>
        Public Property PLEASE_STATUS() As String
            Get
                Return Me.ColumnyMap("PLEASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PLEASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_DATE �ѡu�ץ�дڵn���v�\��g�J"
        '' <summary>
        '' PLEASE_DATE �ѡu�ץ�дڵn���v�\��g�J
        '' </summary>
        Public Property PLEASE_DATE() As String
            Get
                Return Me.ColumnyMap("PLEASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PLEASE_DATE") = value
            End Set
        End Property
#End Region

#Region "REMARK �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v"
        '' <summary>
        '' REMARK �ѡu�f�d����v�B�u�f�禬��v�B�u�}�߼f�w�ҩ��v�\��g�J�v
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.ColumnyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "CAN_FLAG ��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P"
        '' <summary>
        '' CAN_FLAG ��l�]�p�O'Y': ���P, �ѷ��J�t�μg�J, �����קK���{���|��, �]���w�q�p�U:�ϥΪ̦b���t�Υӽе��P��, �����g�J'Y', ���J�t�νT�w���P��, �����]�|��s��'Y', �P��CAN_FLAG_DATE�|�g�J��Ѥ��, �����P�O���J�t�Φ^�g�̾�.����쬰'�N���Ʀ���, ����쵥��'Y'��ܸӵ���Ƶ��P
        '' </summary>
        Public Property CAN_FLAG() As String
            Get
                Return Me.ColumnyMap("CAN_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CAN_FLAG") = value
            End Set
        End Property
#End Region

#Region "CANCEL_CAUSE �ѷ��J�t�μg�J"
        '' <summary>
        '' CANCEL_CAUSE �ѷ��J�t�μg�J
        '' </summary>
        Public Property CANCEL_CAUSE() As String
            Get
                Return Me.ColumnyMap("CANCEL_CAUSE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CANCEL_CAUSE") = value
            End Set
        End Property
#End Region

#Region "CAN_FLAG_DATE �P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C"
        '' <summary>
        '' CAN_FLAG_DATE �P�B�|�J�t�θ�Ʈɼg�J�A����즳��ƪ�ܸӱb��w�g�T�{���P�C
        '' </summary>
        Public Property CAN_FLAG_DATE() As String
            Get
                Return Me.ColumnyMap("CAN_FLAG_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CAN_FLAG_DATE") = value
            End Set
        End Property
#End Region

#Region "APPL021_PKNO REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������"
        '' <summary>
        '' APPL021_PKNO REF. APPL021.PKNO�Y�b��ն}�f�w�ҩ��ɲ��̡ͪA�n�����f�w�ҩ���PKNO�~������
        '' </summary>
        Public Property APPL021_PKNO() As String
            Get
                Return Me.ColumnyMap("APPL021_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APPL021_PKNO") = value
            End Set
        End Property
#End Region

#Region "RE_PRINT_COUNT RE_PRINT_COUNT"
        '' <summary>
        '' RE_PRINT_COUNT RE_PRINT_COUNT
        '' </summary>
        Public Property RE_PRINT_COUNT() As String
            Get
                Return Me.ColumnyMap("RE_PRINT_COUNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RE_PRINT_COUNT") = value
            End Set
        End Property
#End Region

#Region "SYNC_DATE SYNC_DATE"
        '' <summary>
        '' SYNC_DATE SYNC_DATE
        '' </summary>
        Public Property SYNC_DATE() As String
            Get
                Return Me.ColumnyMap("SYNC_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYNC_DATE") = value
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
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �B�z�O�W ===
                Me.TableCoumnInfo.Add(New String() {"CSHT010", "M", "PKNO", "CASE_NO", "ITEM_TYPE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_RSV1, ")
                sql.AppendLine(" '�O�_�д�' = ")
                sql.AppendLine(" CASE M.PLEASE_STATUS WHEN 'Y' THEN '�w�д�' ELSE '���д�' END, ")
                sql.AppendLine(" '�O�_�־P' = ")
                sql.AppendLine(" CASE M.PAY_STATUS ")
                sql.AppendLine(" WHEN '2' THEN '�w�־P' ")
                sql.AppendLine(" WHEN '3' THEN '�w�־P' ")
                sql.AppendLine(" ELSE '���־P' END,")
                sql.AppendLine(" R4.SYS_NAME AS PAY_STATUS_NM ")
                sql.AppendLine(" FROM CSHT010 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON M.PAY_CODE = R1.SYS_ID AND R1.SYS_KEY = 'PAY_CODE' ")
                sql.AppendLine(" LEFT JOIN SYST010 R4 ON M.PAY_STATUS = R4.SYS_ID AND R4.SYS_KEY = 'PAY_STATUS' ")

                sql.AppendLine(" WHERE 1 = 1")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY PKNO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
    End Class
End Namespace




'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
'    Try
'        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'        Me.LogProperty()

'        '=== �ˮ����_�l ===
'        Dim faileArguments As ArrayList = New ArrayList()

'        If faileArguments.Count > 0 Then
'            Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
'        End If
'        '=== �ˮ���쵲�� ===

'        '=== �B�z�O�W ===
'        Me.TableCoumnInfo.Add(New String() {"CSHT010", "M", "PKNO", "CASE_NO", "ITEM_TYPE"})
'        Me.ParserAlias()

'        Dim sql As New StringBuilder
'        sql.AppendLine(" SELECT M.*, R1.SYS_RSV2, R1.SYS_RSV3, R2.COM_CNAM,R3.BUD_NAME, R3.REV1_RESULT,R3.REV2_RESULT, ")
'        sql.AppendLine(" '�O�_�д�' = ")
'        sql.AppendLine(" CASE M.PLEASE_STATUS WHEN 'Y' THEN '�w�д�' ELSE '���д�' END, ")
'        sql.AppendLine(" '�O�_�־P' = ")
'        sql.AppendLine(" CASE M.PAY_STATUS ")
'        sql.AppendLine(" WHEN '2' THEN '�w�־P' ")
'        sql.AppendLine(" WHEN '3' THEN '�w�־P' ")
'        sql.AppendLine(" ELSE '���־P' END,")
'        sql.AppendLine(" R4.SYS_NAME AS PAY_STATUS_NM, ")
'        sql.AppendLine(" '�ޮv' = ")
'        sql.AppendLine(" CASE M.ITEM_TYPE ")
'        sql.AppendLine(" WHEN '2' THEN R5.CH_NAME ")
'        sql.AppendLine(" WHEN '3' THEN R6.CH_NAME ")
'        sql.AppendLine(" WHEN '4' THEN R6.CH_NAME ")
'        sql.AppendLine(" ELSE NULL END,")
'        sql.AppendLine(" R3.CRT_LICENSE,")
'        sql.AppendLine(" ED_DATE = ")
'        sql.AppendLine(" CASE M.ITEM_TYPE ")
'        sql.AppendLine(" WHEN '2' THEN R3.APV1_E_DATE ")
'        sql.AppendLine(" WHEN '3' THEN R3.APV2_E_DATE ")
'        sql.AppendLine(" WHEN '4' THEN R3.APV2_E_DATE ")
'        sql.AppendLine(" ELSE NULL END,")
'        sql.AppendLine(" '�s��' = ")
'        sql.AppendLine(" CASE M.ITEM_TYPE ")
'        sql.AppendLine(" WHEN '2' THEN R3.APV1_NO ")
'        sql.AppendLine(" WHEN '3' THEN R3.APV2_NO ")
'        sql.AppendLine(" WHEN '4' THEN R3.APV2_NO ")
'        sql.AppendLine(" ELSE NULL END ")
'        sql.AppendLine(" FROM CSHT010 M ")
'        sql.AppendLine(" LEFT JOIN SYST010 R1 ON M.PAY_CODE = R1.SYS_ID AND R1.SYS_KEY = 'PAY_CODE' ")
'        sql.AppendLine(" LEFT JOIN APPL010 R2 ON M.COM_PKNO = R2.PKNO ")
'        sql.AppendLine(" LEFT JOIN APPL020 R3 ON M.CASE_NO = R3.CASE_NO ")
'        sql.AppendLine(" LEFT JOIN SYST010 R4 ON M.PAY_STATUS = R4.SYS_ID AND R4.SYS_KEY = 'PAY_STATUS' ")
'        sql.AppendLine(" LEFT JOIN POST020 R5 ON R3.APV1_ACNT = R5.ACNT ") '�f�d�H��
'        sql.AppendLine(" LEFT JOIN POST020 R6 ON R3.APV2_ACNT = R6.ACNT ") '�f��H��

'        sql.AppendLine(" WHERE 1 = 1")

'        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
'            sql.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
'        End If

'        If Me.OrderBys <> "" Then
'            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
'        Else
'            If pageNo = 0 Then
'                sql.AppendLine(" ORDER BY M.PKNO ")
'            Else
'                sql.AppendLine(" ORDER BY PKNO ")
'            End If
'        End If

'        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

'        Me.ResetColumnProperty()

'        Return dt
'    Finally
'        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'    End Try
'End Function


