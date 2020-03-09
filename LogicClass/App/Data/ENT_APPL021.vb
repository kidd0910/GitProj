'----------------------------------------------------------------------------------
'File Name		: APPL021
'Author			:  
'Description		: APPL021 �ץ��N��
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/25	 		Source Create
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
    ' APPL021 �ץ��N��
    ' </summary>
    Public Class ENT_APPL021
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
            Me.TableName = "APPL021"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,MODIFY_DESC"
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

#Region "TAB_FILENAME ����, REF. SYST010.SYS_KEY='TAB_FILENAME'"
        '' <summary>
        '' TAB_FILENAME ����, REF. SYST010.SYS_KEY='TAB_FILENAME'
        '' </summary>
        Public Property TAB_FILENAME() As String
            Get
                Return Me.ColumnyMap("TAB_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TAB_FILENAME") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID �����s��, �t�Φ۰ʽs���A�Ƨǥ�"
        '' <summary>
        '' TBL_RECID �����s��, �t�Φ۰ʽs���A�Ƨǥ�
        '' </summary>
        Public Property TBL_RECID() As String
            Get
                Return Me.ColumnyMap("TBL_RECID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TBL_RECID") = value
            End Set
        End Property
#End Region

#Region "MODIFY_DESC �ץ��N��"
        '' <summary>
        '' MODIFY_DESC �ץ��N��
        '' </summary>
        Public Property MODIFY_DESC() As String
            Get
                Return Me.ColumnyMap("MODIFY_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MODIFY_DESC") = value
            End Set
        End Property
#End Region

#Region "M_PKNO �D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO"
        '' <summary>
        '' M_PKNO �D��ư򥻤W�PPKNO�@�ˡA�Y�ӭ��Ҧ�����J�B��ܤ��P�{���ɡA��ܪ����Ҭ�����J���Ҫ�PKNO
        '' </summary>
        Public Property M_PKNO() As String
            Get
                Return Me.ColumnyMap("M_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_PKNO") = value
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
        Public Function QueryJoin() As DataTable
            Return Me.QueryJoin(0, 0)
        End Function

        ''' <summary>
        ''' �d�� 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   �s�W��k
        ''' </remarks>
        Public Function QueryJoin(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL021", "M", "CASE_NO", "TAB_FILENAME", "CREATE_TIME", "M_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME ")
                sql.AppendLine(" FROM APPL021 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON (M.TAB_FILENAME = R1.SYS_ID AND R1.SYS_KEY = 'TAB_FILENAME') AND R1.SYS_PRTID = SUBSTRING(M.CASE_NO, 1, 4) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
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

