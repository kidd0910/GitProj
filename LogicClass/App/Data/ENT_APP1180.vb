'----------------------------------------------------------------------------------
'File Name		: APP1180
'Author			:  
'Description		: APP1180 �W�[�έp��
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/18	 		Source Create
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
    ' APP1180 �W�[�έp��
    ' </summary>
    Public Class ENT_APP1180
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
            Me.TableName = "APP1180"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,ANALOGY_CHANNEL_LOCATION,DIGIT_CHANNEL_LOCATION,CHANNEL_LOCATION"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��, �@��"
        '' <summary>
        '' CASE_NO �ץ�s��, �@��
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

#Region "CHSYS_TYPE �t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP"
        '' <summary>
        '' CHSYS_TYPE �t������, �s�W�ɨt�μg�J, �@��, �ק�ɤ��B�z�A1�G���u�s���q���t��, 2�G��L�Ѥ�������ť�����e���O, 3�G�����ìP
        '' </summary>
        Public Property CHSYS_TYPE() As String
            Get
                Return Me.ColumnyMap("CHSYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHSYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYSTEM_OPERATOR ���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'"
        '' <summary>
        '' SYSTEM_OPERATOR ���u�q�����q/���e�t��/�����ìP�q���~��, �@��, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
        '' </summary>
        Public Property SYSTEM_OPERATOR() As String
            Get
                Return Me.ColumnyMap("SYSTEM_OPERATOR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYSTEM_OPERATOR") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_CHANNEL_LOCATION ����t�ΤW�[����-�W�D��m"
        '' <summary>
        '' ANALOGY_CHANNEL_LOCATION ����t�ΤW�[����-�W�D��m
        '' </summary>
        Public Property ANALOGY_CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("ANALOGY_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SUBSCRIBER_NUMBER ����t�ΤW�[����-�q���"
        '' <summary>
        '' ANALOGY_SUBSCRIBER_NUMBER ����t�ΤW�[����-�q���
        '' </summary>
        Public Property ANALOGY_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_CHANNEL_LOCATION �Ʀ�t�ΤW�[����-�W�D��m"
        '' <summary>
        '' DIGIT_CHANNEL_LOCATION �Ʀ�t�ΤW�[����-�W�D��m
        '' </summary>
        Public Property DIGIT_CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("DIGIT_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SUBSCRIBER_NUMBER �Ʀ�t�ΤW�[����-�q���"
        '' <summary>
        '' DIGIT_SUBSCRIBER_NUMBER �Ʀ�t�ΤW�[����-�q���
        '' </summary>
        Public Property DIGIT_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("DIGIT_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_LOCATION �W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��"
        '' <summary>
        '' CHANNEL_LOCATION �W�D��m, ��L�Ѥ�������ť�����e���O�B�����ìP��
        '' </summary>
        Public Property CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBER_NUMBER �q���, ��L�Ѥ�������ť�����e���O�B�����ìP��"
        '' <summary>
        '' SUBSCRIBER_NUMBER �q���, ��L�Ѥ�������ť�����e���O�B�����ìP��
        '' </summary>
        Public Property SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region



#End Region

#Region "�ۭq��k"
#Region "Query �d�� "
        '' <summary>
        '' �d�� 
        '' </summary>
        Public Function QueryMergeData() As DataTable
            Return Me.QueryMergeData(0, 0)
        End Function

        '' <summary>
        '' �d�� 
        '' </summary>
        '' <remarks>
        '' 0.0.1   �s�W��k
        '' </remarks>
        Public Function QueryMergeData(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1180", "M", "PKNO", "CASE_NO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME AS 'CH_NAME', R1.SYS_RSV1 AS 'AREA', R1.SYS_SORT ")
                sql.AppendLine(" FROM APP1180 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON M.SYSTEM_OPERATOR = R1.SYS_ID AND R1.SYS_KEY = 'SYSTEM_OPERATOR' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions.Replace("$.", " ")))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY R1.SYS_SORT ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_SORT ")
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

