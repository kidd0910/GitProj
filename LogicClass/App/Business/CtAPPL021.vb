'ProductName                 : TSBA 
'File Name					 : CtAPPL021 
'Description	             : CtAPPL021 �ץ��N��
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/25         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL021
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL021 = New ENT_APPL021(Me.DBManager, Me.LogUtil)
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

#Region "TAB_FILENAME ����, REF. SYST010.SYS_KEY='TAB_FILENAME'"
        '' <summary>
        '' TAB_FILENAME ����, REF. SYST010.SYS_KEY='TAB_FILENAME'
        '' </summary>
        Public Property TAB_FILENAME() As String
            Get
                Return Me.PropertyMap("TAB_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAB_FILENAME") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID �����s��, �t�Φ۰ʽs���A�Ƨǥ�"
        '' <summary>
        '' TBL_RECID �����s��, �t�Φ۰ʽs���A�Ƨǥ�
        '' </summary>
        Public Property TBL_RECID() As String
            Get
                Return Me.PropertyMap("TBL_RECID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TBL_RECID") = value
            End Set
        End Property
#End Region

#Region "MODIFY_DESC �ץ��N��"
        '' <summary>
        '' MODIFY_DESC �ץ��N��
        '' </summary>
        Public Property MODIFY_DESC() As String
            Get
                Return Me.PropertyMap("MODIFY_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MODIFY_DESC") = value
            End Set
        End Property
#End Region

#Region "M_PKNO �D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO"
        '' <summary>
        '' M_PKNO �D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO
        '' </summary>
        Public Property M_PKNO() As String
            Get
                Return Me.PropertyMap("M_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_PKNO") = value
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

#Region "Ent_APPL021"
        ' <summary>Ent_APPL021</ summary>
        Private Property Ent_APPL021() As ENT_APPL021
            Get
                Return Me.PropertyMap("Ent_APPL021")
            End Get
            Set(ByVal value As ENT_APPL021)
                Me.PropertyMap("Ent_APPL021") = value
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
                Me.Ent_APPL021.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL021.TAB_FILENAME = Me.TAB_FILENAME        '����, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.Ent_APPL021.TBL_RECID = Me.TBL_RECID      '�����s��, �t�Φ۰ʽs���A�Ƨǥ�
                Me.Ent_APPL021.MODIFY_DESC = Me.MODIFY_DESC      '�ץ��N��
                Me.Ent_APPL021.M_PKNO = Me.M_PKNO        '�D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO
                Me.Ent_APPL021.CASE_SEQ = Me.CASE_SEQ      '�ɥ�����

                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_APPL021.Insert()

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
                Me.Ent_APPL021.CASE_NO = Me.CASE_NO      '�ץ�s��
                Me.Ent_APPL021.TAB_FILENAME = Me.TAB_FILENAME        '����, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.Ent_APPL021.TBL_RECID = Me.TBL_RECID      '�����s��, �t�Φ۰ʽs���A�Ƨǥ�
                Me.Ent_APPL021.MODIFY_DESC = Me.MODIFY_DESC      '�ץ��N��
                Me.Ent_APPL021.M_PKNO = Me.M_PKNO        '�D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO
                Me.Ent_APPL021.CASE_SEQ = Me.CASE_SEQ      '�ɥ�����

                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL021.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_APPL021.Update()

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
                Me.Ent_APPL021.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_APPL021.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_APPL021.Delete()
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
                Me.ProcessQueryCondition(condition, "%LIKE%", "TAB_FILENAME", Me.TAB_FILENAME)       '����, REF. SYST010.SYS_KEY='TAB_FILENAME'
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '�����s��, �t�Φ۰ʽs���A�Ƨǥ�
                Me.ProcessQueryCondition(condition, "%LIKE%", "MODIFY_DESC", Me.MODIFY_DESC)         '�ץ��N��
                Me.ProcessQueryCondition(condition, "=", "M_PKNO", Me.M_PKNO)        '�D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)      '�ɥ�����

                '�S����� OR �۩w����
                condition.Append(Me.QUERY_COND)

                Me.Ent_APPL021.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL021.OrderBys = " TBL_RECID "
                Else
                    Me.Ent_APPL021.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL021.QueryJoin()
                Else
                    result = Me.Ent_APPL021.QueryJoin(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL021.TotalRowCount
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

