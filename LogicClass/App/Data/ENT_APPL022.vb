'----------------------------------------------------------------------------------
'File Name		: APPL022
'Author			: �t�κ޲z��
'Description		: APPL022 APPL022 ����D��
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2018/02/02	�t�κ޲z��		Source Create
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
    ' APPL022 APPL022 ����D��
    ' </summary>
    Public Class ENT_APPL022
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
            Me.TableName = "APPL022"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,RCV_TMEME"
            Me.SET_NULL_FIELD = ""
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

#Region "RCV_NO ���帹"
        '' <summary>
        '' RCV_NO ���帹
        '' </summary>
        Public Property RCV_NO() As String
            Get
                Return Me.ColumnyMap("RCV_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RCV_NO") = value
            End Set
        End Property
#End Region

#Region "DEADLINE ������"
        '' <summary>
        '' DEADLINE ������
        '' </summary>
        Public Property DEADLINE() As String
            Get
                Return Me.ColumnyMap("DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE") = value
            End Set
        End Property
#End Region

#Region "DEPID �ӿ���N�X"
        '' <summary>
        '' DEPID �ӿ���N�X
        '' </summary>
        Public Property DEPID() As String
            Get
                Return Me.ColumnyMap("DEPID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEPID") = value
            End Set
        End Property
#End Region

#Region "RCV_DATE ������"
        '' <summary>
        '' RCV_DATE ������
        '' </summary>
        Public Property RCV_DATE() As String
            Get
                Return Me.ColumnyMap("RCV_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RCV_DATE") = value
            End Set
        End Property
#End Region

#Region "RCV_TMEME �D��"
        '' <summary>
        '' RCV_TMEME �D��
        '' </summary>
        Public Property RCV_TMEME() As String
            Get
                Return Me.ColumnyMap("RCV_TMEME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RCV_TMEME") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ �ɥ�����"
        '' <summary>
        '' CASE_SEQ �ɥ�����
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.ColumnyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_SEQ") = value
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
        ''' 0.0.1 �t�κ޲z�� �s�W��k
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

