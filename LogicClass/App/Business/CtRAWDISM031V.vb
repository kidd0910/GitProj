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
    Partial Public Class CtRAWDISM031V
        Inherits Acer.Base.ControlBase


#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.ENT_RAWDISM031V = New ENT_RAWDISM031V(Me.DBManager, Me.LogUtil)
        End Sub
#End Region


#Region "屬性"
#Region "ENT_RAWDISM031V"
        ' <summary>ENT_RAWDISM031V</ summary>
        Private Property ENT_RAWDISM031V() As ENT_RAWDISM031V
            Get
                Return Me.PropertyMap("ENT_RAWDISM031V")
            End Get
            Set(ByVal value As ENT_RAWDISM031V)
                Me.PropertyMap("ENT_RAWDISM031V") = value
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

#Region "頻道內容的編號 "
        Public Property IDENTIFICATION1() As String
            Get
                Return Me.PropertyMap("IDENTIFICATION1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IDENTIFICATION1") = value
            End Set
        End Property
#End Region

#Region "KINDS 申請類別"
        ''' <summary>
        ''' KINDS 申請類別
        ''' </summary>
        Public Property KINDS() As String
            Get
                Return Me.PropertyMap("KINDS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("KINDS") = value
            End Set
        End Property
#End Region

#Region "KINDNM 申請類別名稱"
        ''' <summary>
        ''' KINDNM 申請類別名稱
        ''' </summary>
        Public Property KINDNM() As String
            Get
                Return Me.PropertyMap("KINDNM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("KINDNM") = value
            End Set
        End Property
#End Region

#Region "YM 年月"
        ''' <summary>
        ''' YM 年月
        ''' </summary>
        Public Property YM() As String
            Get
                Return Me.PropertyMap("YM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("YM") = value
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
                Me.ProcessQueryCondition(condition, "=", "KINDS", Me.KINDS)
                Me.ProcessQueryCondition(condition, "=", "KINDNM", Me.KINDNM)
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_NAME", Me.CHANNEL_NAME)
                Me.ProcessQueryCondition(condition, "=", "YM", Me.YM)

                Me.ENT_RAWDISM031V.SqlRetrictions = condition.ToString()

                '特殊條件 Or 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.ENT_RAWDISM031V.OrderBys = " CASE_NO "
                Else
                    Me.ENT_RAWDISM031V.OrderBys = Me.OrderBys
                End If

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.ENT_RAWDISM031V.Query()
                Else
                    result = Me.ENT_RAWDISM031V.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.ENT_RAWDISM031V.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function DoQueryBySQL() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "IDENTIFICATION", Me.IDENTIFICATION)

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Dim result As DataTable

                Dim sql As New StringBuilder
                sql.AppendLine(" select  ")
                sql.AppendLine(" IDENTIFICATION1  ")
                sql.AppendLine(" , max(case when N.KINDS = 1 or N.KINDS = 2  then N.CNAME end) as CNAME  ")
                sql.AppendLine(" , max(case when N.KINDS = 1 then N.CHLNO end) as ANALOGY_CHANNEL_LOCATION  ")
                sql.AppendLine(" , max(case when N.KINDS = 1 then N.ISUQTY end) as ANALOGY_SUBSCRIBER_NUMBER  ")
                sql.AppendLine(" , max(case when N.KINDS = 1 then N.KINDNM end) as KINDNM  ")
                sql.AppendLine(" , max(case when N.KINDS = 2 then N.CHLNO end) as DIGIT_CHANNEL_LOCATION  ")
                sql.AppendLine(" , max(case when N.KINDS = 2 then N.ISUQTY end) as DIGIT_SUBSCRIBER_NUMBER  ")
                sql.AppendLine(" , max(case when N.KINDS = 2 then N.KINDNM end) as KINDNM  ")
                sql.AppendLine(" , max(case when N.KINDS = 3 then N.CHLNO end) as DIGIT_CHANNEL_LOCATION_3  ")
                sql.AppendLine(" , max(case when N.KINDS = 3 then N.ISUQTY end) as DIGIT_SUBSCRIBER_NUMBER_3  ")
                sql.AppendLine(" , max(case when N.KINDS = 3 then N.KINDNM end) as KINDNM_3  ")
                sql.AppendLine(" from ( ")
                sql.AppendLine(" select distinct ")
                sql.AppendLine(" M.IDENTIFICATION1 ")
                sql.AppendLine(" , M.KINDNM ")
                sql.AppendLine(" , M.CNAME ")
                sql.AppendLine(" , M.CHLNO ")
                sql.AppendLine(" , M.ISUQTY ")
                sql.AppendLine(" , M.KINDS ")
                sql.AppendLine(" from RAWDISM031V M ")
                sql.AppendLine(" where M.IDENTIFICATION = '" + Me.IDENTIFICATION + "'")
                sql.AppendLine(" and M.CHANNEL_NAME = '" + Me.CHANNEL_NAME + "'")
                sql.AppendLine(" and M.YM = " + Me.YM)
                sql.AppendLine(" and M.KINDS IN (" + Me.KINDS + ")")
                sql.AppendLine(" ) as N ")
                sql.AppendLine(" group by IDENTIFICATION1 ")

                result = Me.ENT_RAWDISM031V.QueryBySql(sql.ToString)

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
                'Me.ProcessQueryCondition(condition, "IN", "KINDS", Me.KINDS)
                If Not String.IsNullOrEmpty(Me.KINDS) Then
                    condition.Append(" AND $.KINDS IN ('" & Me.KINDS.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "KINDNM", Me.KINDNM)
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_NAME", Me.CHANNEL_NAME)

                Me.ENT_RAWDISM031V.SqlRetrictions = condition.ToString()

                '特殊條件 Or 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.ENT_RAWDISM031V.OrderBys = " CASE_NO "
                Else
                    Me.ENT_RAWDISM031V.OrderBys = Me.OrderBys
                End If

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.ENT_RAWDISM031V.GetMaxDate()
                Else
                    result = Me.ENT_RAWDISM031V.GetMaxDate(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.ENT_RAWDISM031V.TotalRowCount
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

