'----------------------------------------------------------------------------------
'File Name		: SYST030
'Author			: CM Huang
'Description		: SYST030 公告訊息管理
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/10/30	CM Huang		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Sys.Data
    ' <summary>
    ' SYST030 公告訊息管理
    ' </summary>
    Public Class ENT_SYST030
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
            Me.TableName = "SYST030"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "POST_ITEM"
        '' <summary>
        '' POST_ITEM
        '' </summary>
        Public Property POST_ITEM() As String
            Get
                Return Me.ColumnyMap("POST_ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("POST_ITEM") = value
            End Set
        End Property
#End Region

#Region "POST_CONTENT"
        '' <summary>
        '' POST_CONTENT
        '' </summary>
        Public Property POST_CONTENT() As String
            Get
                Return Me.ColumnyMap("POST_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("POST_CONTENT") = value
            End Set
        End Property
#End Region

#Region "USE_TYPE"
        '' <summary>
        '' USE_TYPE
        '' </summary>
        Public Property USE_TYPE() As String
            Get
                Return Me.ColumnyMap("USE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_TYPE") = value
            End Set
        End Property
#End Region

#Region "USER_TYPE"
        '' <summary>
        '' USER_TYPE
        '' </summary>
        Public Property USER_TYPE() As String
            Get
                Return Me.ColumnyMap("USER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USER_TYPE") = value
            End Set
        End Property
#End Region

#Region "ST_DATE"
        '' <summary>
        '' ST_DATE
        '' </summary>
        Public Property ST_DATE() As String
            Get
                Return Me.ColumnyMap("ST_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ST_DATE") = value
            End Set
        End Property
#End Region

#Region "ED_DATE"
        '' <summary>
        '' ED_DATE
        '' </summary>
        Public Property ED_DATE() As String
            Get
                Return Me.ColumnyMap("ED_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ED_DATE") = value
            End Set
        End Property
#End Region

#Region "INF_SOURCE"
        '' <summary>
        '' INF_SOURCE
        '' </summary>
        Public Property INF_SOURCE() As String
            Get
                Return Me.ColumnyMap("INF_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INF_SOURCE") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
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
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
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
                Me.TableCoumnInfo.Add(New String() {"SYST030", "M", "PKNO", "POST_ITEM", "POST_CONTENT", "USE_TYPE", "USER_TYPE", "ST_DATE", "ED_DATE", "INF_SOURCE", "USE_STATE"})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, isNull(R1.CH_NAME, '') AS UPDATE_USER1, ")
                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE1,  ")

                sql.AppendLine(" CASE M.USE_TYPE   ")
                sql.AppendLine("   WHEN 1 THEN '一般公告' ")
                sql.AppendLine("   WHEN 2 THEN '核配' ")
                sql.AppendLine("   WHEN 3 THEN '收回' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_TYPE1,  ")

                sql.AppendLine(" (SELECT COUNT(PKNO) FROM COMT010 WHERE FILE_NO = M.PKNO AND ACCE_SOURCE IN ('SYS2010_02')) as ATT ")

                sql.AppendLine(" FROM SYST030 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R1 ON M.UPDATE_USER = R1.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.ST_DATE ASC, M.UPDATE_TIME ASC ")
                    Else
                        sql.AppendLine(" ORDER BY M.ST_DATE ASC, M.UPDATE_TIME ASC ")
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

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT,INF_SOURCE"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT,INF_SOURCE"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT,INF_SOURCE"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

