Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP0003 審查項目
    ' </summary>
    Public Class ENT_APP0003
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
            Me.TableName = "APP0003"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "QNO_DESC"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"

#Region "CASE_CODE"
        '' <summary>
        '' CASE_CODE 案號前四碼
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.ColumnyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "TAB_FILE"
        '' <summary>
        '' TAB_FILE 程式代碼
        '' </summary>
        Public Property TAB_FILE() As String
            Get
                Return Me.ColumnyMap("TAB_FILE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TAB_FILE") = value
            End Set
        End Property
#End Region


#Region "QNO"
        '' <summary>
        '' QNO 題目代號
        '' </summary>
        Public Property QNO() As String
            Get
                Return Me.ColumnyMap("QNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QNO") = value
            End Set
        End Property
#End Region

#Region "QNO_DESC"
        '' <summary>
        '' QNO_DESC 題目內容
        '' </summary>
        Public Property QNO_DESC() As String
            Get
                Return Me.ColumnyMap("QNO_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QNO_DESC") = value
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



    End Class
End Namespace

