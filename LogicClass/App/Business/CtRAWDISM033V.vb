'----------------------------------------------------------------------------------
'File Name		: 
'Author			: Edward Wang
'Description		: NCCST連線Table
'Modification Log	:
'
'Vers		Date       	By		        Notes
'----------------------------------------------------------------------------------
'0.0.1		2019/02/21	Edward Wang		Source Create
'----------------------------------------------------------------------------------


Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtRAWDISM033V
        Inherits Acer.Base.ControlBase


#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.ENT_RAWDISM033V = New ENT_RAWDISM033V(Me.DBManager, Me.LogUtil)
        End Sub
#End Region


#Region "屬性"
#Region "ENT_RAWDISM033V"
        ' <summary>ENT_RAWDISM031V</ summary>
        Private Property ENT_RAWDISM033V() As ENT_RAWDISM033V
            Get
                Return Me.PropertyMap("ENT_RAWDISM033V")
            End Get
            Set(ByVal value As ENT_RAWDISM033V)
                Me.PropertyMap("ENT_RAWDISM033V") = value
            End Set
        End Property
#End Region

#Region "統一編號"
        Public Property IDENTIFICATION() As String
            Get
                Return Me.PropertyMap("IDENTIFICATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IDENTIFICATION") = value
            End Set
        End Property
#End Region

#Region "APPLY_CHT_NAME 業者名稱"
        ''' <summary>
        ''' APPLY_CHT_NAME 業者名稱
        ''' </summary>
        Public Property APPLY_CHT_NAME() As String
            Get
                Return Me.PropertyMap("APPLY_CHT_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPLY_CHT_NAME") = value
            End Set
        End Property
#End Region

#Region "YY 年月"
        ''' <summary>
        ''' YM 年月
        ''' </summary>
        Public Property YY() As String
            Get
                Return Me.PropertyMap("YY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("YY") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_NAME 頻道名稱"
        ''' <summary>
        ''' CHANNEL_NAME 頻道名稱
        ''' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.PropertyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_NAME") = value
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
        '' 進行查詢動作
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "IDENTIFICATION", Me.IDENTIFICATION)
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_NAME", Me.CHANNEL_NAME)
                Me.ProcessQueryCondition(condition, "=", "APPLY_CHT_NAME", Me.APPLY_CHT_NAME)
                Me.ProcessQueryCondition(condition, "=", "YY", Me.YY)

                Me.ENT_RAWDISM033V.SqlRetrictions = condition.ToString()

                '特殊條件 Or 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.ENT_RAWDISM031V.OrderBys = " CASE_NO "
                Else
                    Me.ENT_RAWDISM033V.OrderBys = Me.OrderBys
                End If

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.ENT_RAWDISM033V.Query()
                Else
                    result = Me.ENT_RAWDISM033V.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.ENT_RAWDISM033V.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function DoQuerySQL(ByVal IDENTIFICATION As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "IDENTIFICATION", Me.IDENTIFICATION)

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Dim result As DataTable
                'If Me.PageNo = 0 Then
                result = Me.ENT_RAWDISM033V.QueryBySql(String.Format(" SELECT top 1 * From RAWDISM033V Where IDENTIFICATION='{0}'", IDENTIFICATION))

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

        '' <summary>
        '' 找類型條件當中的最大日期(YM)
        '' </summary>
        Public Function GetMaxDate() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "IDENTIFICATION", Me.IDENTIFICATION)
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_NAME", Me.CHANNEL_NAME)
                Me.ProcessQueryCondition(condition, "=", "APPLY_CHT_NAME", Me.APPLY_CHT_NAME)

                Me.ENT_RAWDISM033V.SqlRetrictions = condition.ToString()

                '特殊條件 Or 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.ENT_RAWDISM031V.OrderBys = " CASE_NO "
                Else
                    Me.ENT_RAWDISM033V.OrderBys = Me.OrderBys
                End If

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.ENT_RAWDISM033V.GetMaxDate()
                Else
                    result = Me.ENT_RAWDISM033V.GetMaxDate(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.ENT_RAWDISM033V.TotalRowCount
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



