'----------------------------------------------------------------------------------
'File Name		: SYST050
'Author			: Kevin Yu
'Description		: SYST050 
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2014/03/21	Kevin Yu		Source Create
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
    ' SYST050 
    ' </summary>
    Public Class ENT_SYST050
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
            Me.TableName = "SYST050"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "TBL_RECID"
        '' <summary>
        '' TBL_RECID
        '' </summary>
        Public Property TBL_RECID() As String
            Get
                Return Me.ColumnyMap("TBL_RECID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TBL_RECID") = value
            End Set
        End Property
#End Region

#Region "USERTYPE"
        '' <summary>
        '' USERTYPE
        '' </summary>
        Public Property USERTYPE() As String
            Get
                Return Me.ColumnyMap("USERTYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USERTYPE") = value
            End Set
        End Property
#End Region

#Region "FUNCTIONNAME"
        '' <summary>
        '' FUNCTIONNAME
        '' </summary>
        Public Property FUNCTIONNAME() As String
            Get
                Return Me.ColumnyMap("FUNCTIONNAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUNCTIONNAME") = value
            End Set
        End Property
#End Region

#Region "SUBMITNUMBER"
        '' <summary>
        '' SUBMITNUMBER
        '' </summary>
        Public Property SUBMITNUMBER() As String
            Get
                Return Me.ColumnyMap("SUBMITNUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBMITNUMBER") = value
            End Set
        End Property
#End Region

#Region "RECORRECTNUMBER"
        '' <summary>
        '' RECORRECTNUMBER
        '' </summary>
        Public Property RECORRECTNUMBER() As String
            Get
                Return Me.ColumnyMap("RECORRECTNUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RECORRECTNUMBER") = value
            End Set
        End Property
#End Region

#Region "TMPNUMBER"
        '' <summary>
        '' TMPNUMBER
        '' </summary>
        Public Property TMPNUMBER() As String
            Get
                Return Me.ColumnyMap("TMPNUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TMPNUMBER") = value
            End Set
        End Property
#End Region

#Region "SENTCASENUMBER"
        '' <summary>
        '' SENTCASENUMBER
        '' </summary>
        Public Property SENTCASENUMBER() As String
            Get
                Return Me.ColumnyMap("SENTCASENUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SENTCASENUMBER") = value
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
        ''' 0.0.1 Kevin Yu 新增方法
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
                Me.TableCoumnInfo.Add(New String() {"SYST050", "M", "TBL_RECID", "USERTYPE"})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" select *,  ")
                sql.AppendLine("   CASE USERTYPE  ")
                sql.AppendLine("   WHEN 1 THEN '業者'   ")
                sql.AppendLine("      WHEN 0 THEN 'NCC'  ")
                sql.AppendLine("      ELSE ''  ")
                sql.AppendLine("     END AS USERTYPE1  ")
                sql.AppendLine(" from SYST050 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.TBL_RECID ")
                    Else
                        sql.AppendLine(" ORDER BY TBL_RECID  ")
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
            MyBase.LONG_FIELD_NAME = "FUNCTIONNAME"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "FUNCTIONNAME"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "FUNCTIONNAME"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

