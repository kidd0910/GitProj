'----------------------------------------------------------------------------------
'File Name		: APP1090
'Author			: TIM
'Description		: APP1090 預估綜合損益表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/22	TIM		Source Create
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
    ' APP1090 預估綜合損益表
    ' </summary>
    Public Class ENT_APP1090
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        ' <summary>
        ' 建構子/處理屬性對應處理
        ' </summary>
        ' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' 建構子/處理異動處理
        ' </summary>
        ' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "APP1090"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,FUTURE_YEAR"
            Me.SET_NULL_FIELD = "OPERATING_INCOME,OPERATING_COST,OPERATING_EXP,OPERATING_COME_EXP"
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
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

#Region "FUTURE_YEAR 未來第幾年"
        '' <summary>
        '' FUTURE_YEAR 未來第幾年
        '' </summary>
        Public Property FUTURE_YEAR() As String
            Get
                Return Me.ColumnyMap("FUTURE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUTURE_YEAR") = value
            End Set
        End Property
#End Region

#Region "OPERATING_INCOME 營業收入"
        '' <summary>
        '' OPERATING_INCOME 營業收入
        '' </summary>
        Public Property OPERATING_INCOME() As String
            Get
                Return Me.ColumnyMap("OPERATING_INCOME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_INCOME") = value
            End Set
        End Property
#End Region

#Region "OPERATING_COST 營業成本"
        '' <summary>
        '' OPERATING_COST 營業成本
        '' </summary>
        Public Property OPERATING_COST() As String
            Get
                Return Me.ColumnyMap("OPERATING_COST")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_COST") = value
            End Set
        End Property
#End Region

#Region "OPERATING_EXP 營業費用"
        '' <summary>
        '' OPERATING_EXP 營業費用
        '' </summary>
        Public Property OPERATING_EXP() As String
            Get
                Return Me.ColumnyMap("OPERATING_EXP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_EXP") = value
            End Set
        End Property
#End Region

#Region "OPERATING_COME_EXP 營業外收益及費損"
        '' <summary>
        '' OPERATING_COME_EXP 營業外收益及費損
        '' </summary>
        Public Property OPERATING_COME_EXP() As String
            Get
                Return Me.ColumnyMap("OPERATING_COME_EXP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_COME_EXP") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 TIM 新增方法
        ''' </remarks>
        'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()
        '
        '        '=== 檢核欄位起始 ===
        '        Dim faileArguments As ArrayList = New ArrayList()
        '
        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== 檢核欄位結束 ===
        '
        '        '=== 處理別名 ===
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

