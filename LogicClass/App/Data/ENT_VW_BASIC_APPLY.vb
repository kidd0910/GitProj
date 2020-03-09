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



Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Namespace App.Data
    Public Class ENT_VW_BASIC_APPLY
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
            Me.TableName = "VW_BASIC_APPLY"
            Me.SysName = "NCC"
            Me.ConnName = "nccmain"
        End Sub
#End Region
#Region "屬性"


#Region "統一編號_身份證號"
        Public Property 統一編號_身份證號() As String
            Get
                Return Me.ColumnyMap("統一編號_身份證號")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("統一編號_身份證號") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法 Query"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 ===
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT Top 1 * FROM VW_BASIC_APPLY ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    'sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                    Else
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
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

