'----------------------------------------------------------------------------------
'File Name		: APP1120
'Author			: TIM
'Description		: APP1120 外國人持股比例計算表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/24	TIM		Source Create
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
    ' APP1120 外國人持股比例計算表
    ' </summary>
    Public Class ENT_APP1120
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
            Me.TableName = "APP1120"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,DIRECT_INV_SHARE,COUNTRY"
            Me.SET_NULL_FIELD = "DIRECT_SHARE_RATIO"
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

#Region "DIRECT_INV_SHARE 直接投資股東-A表"
        '' <summary>
        '' DIRECT_INV_SHARE 直接投資股東-A表
        '' </summary>
        Public Property DIRECT_INV_SHARE() As String
            Get
                Return Me.ColumnyMap("DIRECT_INV_SHARE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIRECT_INV_SHARE") = value
            End Set
        End Property
#End Region

#Region "COUNTRY 國籍-A表"
        '' <summary>
        '' COUNTRY 國籍-A表
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.ColumnyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "DIRECT_SHARE_AMOUNT 直接持股金額-A表"
        '' <summary>
        '' DIRECT_SHARE_AMOUNT 直接持股金額-A表
        '' </summary>
        Public Property DIRECT_SHARE_AMOUNT() As String
            Get
                Return Me.ColumnyMap("DIRECT_SHARE_AMOUNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIRECT_SHARE_AMOUNT") = value
            End Set
        End Property
#End Region

#Region "DIRECT_SHARE_RATIO 直接持股比例-A表"
        '' <summary>
        '' DIRECT_SHARE_RATIO 直接持股比例-A表
        '' </summary>
        Public Property DIRECT_SHARE_RATIO() As String
            Get
                Return Me.ColumnyMap("DIRECT_SHARE_RATIO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIRECT_SHARE_RATIO") = value
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

