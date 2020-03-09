'----------------------------------------------------------------------------------
'File Name		: MSG010
'Author			: sandra
'Description		: MSG010 �T�����e
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2016/11/24	sandra		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Msg.Data
    '' <summary>
    '' MSG010 �T�����e
    '' </summary>
    Public Class ENT_MSG010
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "�غc�l"
        '' <summary>
        '' �غc�l/�B�z�ݩʹ����B�z
        '' </summary>
        '' <param name="dt">DataTable ����</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' �غc�l/�B�z���ʳB�z
        '' </summary>
        '' <param name="dbManager">DBManager ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "MSG010"
            Me.SysName = "MSG"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "MSG_DESC"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "�ݩ�"
#Region "MSG_NO �s��"
        ''' <summary>
        ''' MSG_NO �s��
        ''' </summary>
        Public Property MSG_NO() As Integer
            Get
                Return Me.ColumnyMap("MSG_NO")
            End Get
            Set(ByVal value As Integer)
                Me.ColumnyMap("MSG_NO") = value
            End Set
        End Property
#End Region

#Region "MSG_DESC ���e"
        ''' <summary>
        ''' MSG_DESC ���e
        ''' </summary>
        Public Property MSG_DESC() As String
            Get
                Return Me.ColumnyMap("MSG_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MSG_DESC") = value
            End Set
        End Property
#End Region

#End Region

    End Class
End Namespace

