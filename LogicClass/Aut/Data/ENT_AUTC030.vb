﻿'----------------------------------------------------------------------------------
'File Name		: AUTC030
'Author			: KuChihWei
'Description		: AUTC030 提報類別
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
    ' AUTC030 提報類別
    ' </summary>
    Public Class ENT_AUTC030
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
            Me.TableName = "AUTC030"
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

#Region "PROG_CD"
        '' <summary>
        '' PROG_CD
        '' </summary>
        Public Property PROG_CD() As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_NM"
        '' <summary>
        '' PROG_NM
        '' </summary>
        Public Property PROG_NM() As String
            Get
                Return Me.ColumnyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_NM") = value
            End Set
        End Property
#End Region

#Region "PROG_PATH"
        '' <summary>
        '' PROG_PATH
        '' </summary>
        Public Property PROG_PATH() As String
            Get
                Return Me.ColumnyMap("PROG_PATH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_PATH") = value
            End Set
        End Property
#End Region

#Region "PROG_EXPL"
        '' <summary>
        '' PROG_EXPL
        '' </summary>
        Public Property PROG_EXPL() As String
            Get
                Return Me.ColumnyMap("PROG_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_EXPL") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATES"
        '' <summary>
        '' OPEN_DATES
        '' </summary>
        Public Property OPEN_DATES() As String
            Get
                Return Me.ColumnyMap("OPEN_DATES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_DATES") = value
            End Set
        End Property
#End Region

#Region "OPEN_DATEE"
        '' <summary>
        '' OPEN_DATEE
        '' </summary>
        Public Property OPEN_DATEE() As String
            Get
                Return Me.ColumnyMap("OPEN_DATEE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_DATEE") = value
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

#Region "PROG_SORT"
        '' <summary>
        '' PROG_SORT
        '' </summary>
        Public Property PROG_SORT() As String
            Get
                Return Me.ColumnyMap("PROG_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_SORT") = value
            End Set
        End Property
#End Region

#Region "OUTSIDE_USE"
        '' <summary>
        '' OUTSIDE_USE
        '' </summary>
        Public Property OUTSIDE_USE() As String
            Get
                Return Me.ColumnyMap("OUTSIDE_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUTSIDE_USE") = value
            End Set
        End Property
#End Region

#Region "RECRUITST_USE"
        '' <summary>
        '' RECRUITST_USE
        '' </summary>
        Public Property RECRUITST_USE() As String
            Get
                Return Me.ColumnyMap("RECRUITST_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECRUITST_USE") = value
            End Set
        End Property
#End Region

#Region "CRD_CLASS_USE"
        '' <summary>
        '' CRD_CLASS_USE
        '' </summary>
        Public Property CRD_CLASS_USE() As String
            Get
                Return Me.ColumnyMap("CRD_CLASS_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CRD_CLASS_USE") = value
            End Set
        End Property
#End Region

#Region "OPEN_OUTSIDE"
        '' <summary>
        '' OPEN_OUTSIDE
        '' </summary>
        Public Property OPEN_OUTSIDE() As String
            Get
                Return Me.ColumnyMap("OPEN_OUTSIDE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPEN_OUTSIDE") = value
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
#Region "GetRptSubCategory 提報類別查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function GetRptSubCategory() As DataTable
            Return Me.GetRptSubCategory(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 KuChihWei 新增方法
        ''' </remarks>
        Public Function GetRptSubCategory(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"AUTC030", "M", "OPERATE_CD"})

                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT SUBSTRING(PROG_NM,7,1) AS PROG_CD ")
                sql.AppendLine(" ,REPLACE(PROG_NM ,SUBSTRING(PROG_NM,1,7),'') AS PROG_NM ")
                sql.AppendLine(" FROM AUTC030 M WITH(NOLOCK) ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY PROG_NM DESC ")
                    Else
                        sql.AppendLine(" ORDER BY PROG_NM DESC ")
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
            MyBase.LONG_FIELD_NAME = "PROG_NM,PROG_PATH,PROG_EXPL"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "PROG_NM,PROG_PATH,PROG_EXPL"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "PROG_NM,PROG_PATH,PROG_EXPL"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

