'----------------------------------------------------------------------------------
'File Name		: 
'Author			: Edward Wang
'Description		: SYBASE連線Table
'Modification Log	:
'
'Vers		Date       	By		        Notes
'----------------------------------------------------------------------------------
'0.0.1		2018/03/20	Edward Wang		Source Create
'----------------------------------------------------------------------------------


Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtVW_BASIC_APPLY
        Inherits Acer.Base.ControlBase



#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_VW_BASIC_APPLY = New ENT_VW_BASIC_APPLY(Me.DBManager, Me.LogUtil)
        End Sub
#End Region


#Region "屬性"
#Region "統一編號_身份證號"
        Public Property UID() As String
            Get
                'Return Me.PropertyMap("統一編號_身份證號")
                Return Me.PropertyMap("UID")
            End Get
            Set(ByVal value As String)
                'Me.PropertyMap("統一編號_身份證號") = value
                Me.PropertyMap("UID") = value
            End Set
        End Property
#End Region

#Region "Ent_VW_BASIC_APPLY"
        ' <summary>Ent_VW_BASIC_APPLY</ summary>
        Private Property Ent_VW_BASIC_APPLY() As ENT_VW_BASIC_APPLY
            Get
                Return Me.PropertyMap("Ent_VW_BASIC_APPLY")
            End Get
            Set(ByVal value As ENT_VW_BASIC_APPLY)
                Me.PropertyMap("Ent_VW_BASIC_APPLY") = value
            End Set
        End Property
#End Region

#Region "QUERY_COND 查詢條件"
        ''' <summary>
        ''' QUERY_COND 查詢條件
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


#Region "方法"
#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作 for 綜合查詢
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "統一編號_身份證號", Me.UID)

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.Ent_VW_BASIC_APPLY.OrderBys = " CASE_NO "
                Else
                    Me.Ent_VW_BASIC_APPLY.OrderBys = Me.OrderBys
                End If
                Me.Ent_VW_BASIC_APPLY.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_VW_BASIC_APPLY.Query()
                Else
                    result = Me.Ent_VW_BASIC_APPLY.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_VW_BASIC_APPLY.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function DoQuerySQL(ByVal UID As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "統一編號_身份證號", Me.UID)

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                'If (String.IsNullOrEmpty(Me.OrderBys)) Then
                '    'Me.Ent_VW_BASIC_APPLY.OrderBys = " CASE_NO "
                'Else
                '    Me.Ent_VW_BASIC_APPLY.OrderBys = Me.OrderBys
                'End If
                'Me.Ent_VW_BASIC_APPLY.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable
                'If Me.PageNo = 0 Then
                result = Me.Ent_VW_BASIC_APPLY.QueryBySql(String.Format(" SELECT top 1 * From VW_BASIC_APPLY Where 統一編號_身份證號='{0}'", UID))
                'result = Me.Ent_VW_BASIC_APPLY.QueryBySql(String.Format(" SELECT top 1 * From VW_BASIC_APPLY"))

                'Else
                '    result = Me.Ent_VW_BASIC_APPLY.Query(Me.PageNo, Me.PageSize)
                '    Me.TotalRowCount = Me.Ent_VW_BASIC_APPLY.TotalRowCount
                'End If

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

