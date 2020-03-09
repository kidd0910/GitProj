'ProductName                 : TSBA 
'File Name					 : CtAUTC030 
'Description	             : CtAUTC030 AUTC030	 �{���O
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/11  NCC�޲z��      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAUTC030
        Inherits Acer.Base.ControlBase

#Region "�غc�l"
        '' <summary>
        '' �غc�l
        '' </summary>
        '' <param name="dbManager">dbManager ����</param>
        '' <param name="logUtil">logUtil ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_AUTC030 = New ENT_AUTC030(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "�ݩ�"
#Region "SYS_CD "
        '' <summary>
        '' SYS_CD 
        '' </summary>
        Public Property SYS_CD() As String
            Get
                Return Me.PropertyMap("SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_CD") = value
            End Set
        End Property
#End Region

#Region "OPERATE_CD "
        '' <summary>
        '' OPERATE_CD 
        '' </summary>
        Public Property OPERATE_CD() As String
            Get
                Return Me.PropertyMap("OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_CD "
        '' <summary>
        '' PROG_CD 
        '' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.PropertyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_NM "
        '' <summary>
        '' PROG_NM 
        '' </summary>
        Public Property PROG_NM() As String
            Get
                Return Me.PropertyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_NM") = value
            End Set
        End Property
#End Region

#Region "PROG_PATH "
        '' <summary>
        '' PROG_PATH 
        '' </summary>
        Public Property PROG_PATH() As String
            Get
                Return Me.PropertyMap("PROG_PATH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_PATH") = value
            End Set
        End Property
#End Region

#Region "PROG_EXPL "
        '' <summary>
        '' PROG_EXPL 
        '' </summary>
        Public Property PROG_EXPL() As String
            Get
                Return Me.PropertyMap("PROG_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_EXPL") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATES "
        '' <summary>
        '' OPEN_DATES 
        '' </summary>
        Public Property OPEN_DATES() As String
            Get
                Return Me.PropertyMap("OPEN_DATES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATES") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATEE "
        '' <summary>
        '' OPEN_DATEE 
        '' </summary>
        Public Property OPEN_DATEE() As String
            Get
                Return Me.PropertyMap("OPEN_DATEE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_DATEE") = value
            End Set
        End Property
#End Region

#Region "USE_STATE "
        '' <summary>
        '' USE_STATE 
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "PROG_SORT "
        '' <summary>
        '' PROG_SORT 
        '' </summary>
        Public Property PROG_SORT() As String
            Get
                Return Me.PropertyMap("PROG_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROG_SORT") = value
            End Set
        End Property
#End Region

#Region "OUTSIDE_USE "
        '' <summary>
        '' OUTSIDE_USE 
        '' </summary>
        Public Property OUTSIDE_USE() As String
            Get
                Return Me.PropertyMap("OUTSIDE_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUTSIDE_USE") = value
            End Set
        End Property
#End Region

#Region "RECRUITST_USE "
        '' <summary>
        '' RECRUITST_USE 
        '' </summary>
        Public Property RECRUITST_USE() As String
            Get
                Return Me.PropertyMap("RECRUITST_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RECRUITST_USE") = value
            End Set
        End Property
#End Region

#Region "CRD_CLASS_USE "
        '' <summary>
        '' CRD_CLASS_USE 
        '' </summary>
        Public Property CRD_CLASS_USE() As String
            Get
                Return Me.PropertyMap("CRD_CLASS_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CRD_CLASS_USE") = value
            End Set
        End Property
#End Region

#Region "OPEN_OUTSIDE "
        '' <summary>
        '' OPEN_OUTSIDE 
        '' </summary>
        Public Property OPEN_OUTSIDE() As String
            Get
                Return Me.PropertyMap("OPEN_OUTSIDE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPEN_OUTSIDE") = value
            End Set
        End Property
#End Region

#Region "Ent_AUTC030"
        ' <summary>Ent_AUTC030</ summary>
        Private Property Ent_AUTC030() As ENT_AUTC030
            Get
                Return Me.PropertyMap("Ent_AUTC030")
            End Get
            Set(ByVal value As ENT_AUTC030)
                Me.PropertyMap("Ent_AUTC030") = value
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
                Me.Ent_AUTC030.SYS_CD = Me.SYS_CD        '
                Me.Ent_AUTC030.OPERATE_CD = Me.OPERATE_CD        '
                Me.Ent_AUTC030.PROG_CD = Me.PROG_CD      '
                Me.Ent_AUTC030.PROG_NM = Me.PROG_NM      '
                Me.Ent_AUTC030.PROG_PATH = Me.PROG_PATH      '
                Me.Ent_AUTC030.PROG_EXPL = Me.PROG_EXPL      '
                Me.Ent_AUTC030.OPEN_DATES = Me.OPEN_DATES        '
                Me.Ent_AUTC030.OPEN_DATEE = Me.OPEN_DATEE        '
                Me.Ent_AUTC030.USE_STATE = Me.USE_STATE      '
                Me.Ent_AUTC030.PROG_SORT = Me.PROG_SORT      '
                Me.Ent_AUTC030.OUTSIDE_USE = Me.OUTSIDE_USE      '
                Me.Ent_AUTC030.RECRUITST_USE = Me.RECRUITST_USE      '
                Me.Ent_AUTC030.CRD_CLASS_USE = Me.CRD_CLASS_USE      '
                Me.Ent_AUTC030.OPEN_OUTSIDE = Me.OPEN_OUTSIDE        '


                '=== �]�w�B�z�s�W�ʧ@ ===
                Dim result As String = Me.Ent_AUTC030.Insert()

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
                Me.Ent_AUTC030.SYS_CD = Me.SYS_CD        '
                Me.Ent_AUTC030.OPERATE_CD = Me.OPERATE_CD        '
                Me.Ent_AUTC030.PROG_CD = Me.PROG_CD      '
                Me.Ent_AUTC030.PROG_NM = Me.PROG_NM      '
                Me.Ent_AUTC030.PROG_PATH = Me.PROG_PATH      '
                Me.Ent_AUTC030.PROG_EXPL = Me.PROG_EXPL      '
                Me.Ent_AUTC030.OPEN_DATES = Me.OPEN_DATES        '
                Me.Ent_AUTC030.OPEN_DATEE = Me.OPEN_DATEE        '
                Me.Ent_AUTC030.USE_STATE = Me.USE_STATE      '
                Me.Ent_AUTC030.PROG_SORT = Me.PROG_SORT      '
                Me.Ent_AUTC030.OUTSIDE_USE = Me.OUTSIDE_USE      '
                Me.Ent_AUTC030.RECRUITST_USE = Me.RECRUITST_USE      '
                Me.Ent_AUTC030.CRD_CLASS_USE = Me.CRD_CLASS_USE      '
                Me.Ent_AUTC030.OPEN_OUTSIDE = Me.OPEN_OUTSIDE        '


                '=== �B�z�d�߱��� ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_AUTC030.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== �B�z�ק��ưʧ@ ===
                Dim updateCount = Me.Ent_AUTC030.Update()

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
                Me.Ent_AUTC030.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== �R����� ===
                If Me.Ent_AUTC030.SqlRetrictions <> "" Then '�w���קK�S��������R
                    Me.Ent_AUTC030.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)        '
                Me.ProcessQueryCondition(condition, "=", "OPERATE_CD", Me.OPERATE_CD)        '
                Me.ProcessQueryCondition(condition, "=", "PROG_CD", Me.PROG_CD)      '
                Me.ProcessQueryCondition(condition, "=", "PROG_NM", Me.PROG_NM)      '
                Me.ProcessQueryCondition(condition, "=", "PROG_PATH", Me.PROG_PATH)      '
                Me.ProcessQueryCondition(condition, "=", "PROG_EXPL", Me.PROG_EXPL)      '
                Me.ProcessQueryCondition(condition, "=", "OPEN_DATES", Me.OPEN_DATES)        '
                Me.ProcessQueryCondition(condition, "=", "OPEN_DATEE", Me.OPEN_DATEE)        '
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '
                Me.ProcessQueryCondition(condition, "=", "PROG_SORT", Me.PROG_SORT)      '
                Me.ProcessQueryCondition(condition, "=", "OUTSIDE_USE", Me.OUTSIDE_USE)      '
                Me.ProcessQueryCondition(condition, "=", "RECRUITST_USE", Me.RECRUITST_USE)      '
                Me.ProcessQueryCondition(condition, "=", "CRD_CLASS_USE", Me.CRD_CLASS_USE)      '
                Me.ProcessQueryCondition(condition, "=", "OPEN_OUTSIDE", Me.OPEN_OUTSIDE)        '

                Me.Ent_AUTC030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_AUTC030.OrderBys = "PKNO"
                Else
                    Me.Ent_AUTC030.OrderBys = Me.OrderBys
                End If

                '=== �B�z���o�^�Ǹ��===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_AUTC030.Query()
                Else
                    result = Me.Ent_AUTC030.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_AUTC030.TotalRowCount
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

