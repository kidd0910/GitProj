'----------------------------------------------------------------------------------
'File Name		: AUTC020
'Author			: KuChihWei
'Description		: AUTC020 提報類別
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/24	KuChihWei		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Aut.Data
    ' <summary>
    ' AUTC020 提報類別
    ' </summary>
    Public Class ENT_AUTC020
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
            Me.TableName = "AUTC020"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "SYS_CD"
        '' <summary>
        '' SYS_CD
        '' </summary>
        Public Property SYS_CD() As String
            Get
                Return Me.ColumnyMap("SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CD") = value
            End Set
        End Property
#End Region

#Region "OPERATE_CD"
        '' <summary>
        '' OPERATE_CD
        '' </summary>
        Public Property OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "OPERATE_NM"
        '' <summary>
        '' OPERATE_NM
        '' </summary>
        Public Property OPERATE_NM() As String
            Get
                Return Me.ColumnyMap("OPERATE_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_NM") = value
            End Set
        End Property
#End Region

#Region "OPERATE_SORT"
        '' <summary>
        '' OPERATE_SORT
        '' </summary>
        Public Property OPERATE_SORT() As String
            Get
                Return Me.ColumnyMap("OPERATE_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_SORT") = value
            End Set
        End Property
#End Region

#Region "UPPER_OPERATE_CD"
        '' <summary>
        '' UPPER_OPERATE_CD
        '' </summary>
        Public Property UPPER_OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("UPPER_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPPER_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "OPERATE_LEVEL"
        '' <summary>
        '' OPERATE_LEVEL
        '' </summary>
        Public Property OPERATE_LEVEL() As String
            Get
                Return Me.ColumnyMap("OPERATE_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_LEVEL") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ' ''' <summary>
        ' ''' 查詢 
        ' ''' </summary>
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

        ' ''' <summary>
        ' ''' 查詢 
        ' ''' </summary>
        ' ''' <remarks>
        ' ''' 0.0.1 KuChihWei 新增方法
        ' ''' </remarks>
        'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()

        '        '=== 檢核欄位起始 ===
        '        Dim faileArguments As ArrayList = New ArrayList()

        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== 檢核欄位結束 ===

        '        '=== 處理別名 ===
        '        Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
        '        Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
        '        Me.ParserAlias()

        '        Dim sql As New StringBuilder
        '        sql.AppendLine(" SELECT M.*, R1.COLUMN2 ")
        '        sql.AppendLine(" FROM SCST020 M ")
        '        sql.AppendLine(" LEFT JOIN SCST040 R1 ON M.TUTOR_CLASSNO = R1.TUTOR_CLASSNO ")

        '        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
        '            sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
        '        End If

        '        If Me.OrderBys <> "" Then
        '            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
        '        Else
        '            If pageNo = 0 Then
        '                sql.AppendLine(" ORDER BY M.STNO ")
        '            Else
        '                sql.AppendLine(" ORDER BY STNO ")
        '            End If
        '        End If

        '        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

        '        Me.ResetColumnProperty()

        '        Return dt
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function
#End Region
#Region "GetCategory 提報類別查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function GetRptCategory() As DataTable
            Return Me.GetRptCategory(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 KuChihWei 新增方法
        ''' </remarks>
        Public Function GetRptCategory(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"AUTC020", "M", "SYS_CD"})

                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT REPLACE(OPERATE_CD,SUBSTRING(OPERATE_CD,1,4),'') AS OPERATE_CD ")
                sql.AppendLine(" ,REPLACE(OPERATE_NM  ,SUBSTRING(OPERATE_NM,1,5),'')  AS OPERATE_NM ")
                sql.AppendLine(" FROM AUTC020 M WITH(NOLOCK)")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY OPERATE_SORT ")
                    Else
                        sql.AppendLine(" ORDER BY OPERATE_SORT ")
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
            MyBase.LONG_FIELD_NAME = "OPERATE_NM"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "OPERATE_NM"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "OPERATE_NM"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

