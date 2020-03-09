'----------------------------------------------------------------------------------
'File Name		: SYST011
'Author			: CM Huang
'Description		: SYST011 系統參數設定
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/11/18	CM Huang		Source Create
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
    ' SYST011 系統參數設定
    ' </summary>
    Public Class ENT_SYST011
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
            Me.TableName = "SYST011"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "CONFIG_ID"
        '' <summary>
        '' CONFIG_ID
        '' </summary>
        Public Property CONFIG_ID() As String
            Get
                Return Me.ColumnyMap("CONFIG_ID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONFIG_ID") = value
            End Set
        End Property
#End Region

#Region "CONFIG_VALUE"
        '' <summary>
        '' CONFIG_VALUE
        '' </summary>
        Public Property CONFIG_VALUE() As String
            Get
                Return Me.ColumnyMap("CONFIG_VALUE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONFIG_VALUE") = value
            End Set
        End Property
#End Region

#Region "REMARK"
        '' <summary>
        '' REMARK
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.ColumnyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REMARK") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

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

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "CONFIG_VALUE,REMARK"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "CONFIG_VALUE,REMARK"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "CONFIG_VALUE,REMARK"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

