'----------------------------------------------------------------------------------
'File Name		: SYST001
'Author			: Brian Chou
'Description		: SYST001 測試
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/08/07	Brian Chou		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Pat.Data
    ' <summary>
    ' SYST001 測試
    ' </summary>
    Public Class ENT_SYST001
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
            Me.TableName = "SYST001"
            Me.SysName = "PAT"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "CODE"
        '' <summary>
        '' CODE
        '' </summary>
        Public Property CODE() As String
            Get
                Return Me.ColumnyMap("CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE") = value
            End Set
        End Property
#End Region

#Region "NAME"
        '' <summary>
        '' NAME
        '' </summary>
        Public Property NAME() As String
            Get
                Return Me.ColumnyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NAME") = value
            End Set
        End Property
#End Region

#Region "DATEX"
        '' <summary>
        '' DATEX
        '' </summary>
        Public Property DATEX() As String
            Get
                Return Me.ColumnyMap("DATEX")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATEX") = value
            End Set
        End Property
#End Region

#Region "TAKE_TIME"
        '' <summary>
        '' TAKE_TIME
        '' </summary>
        Public Property TAKE_TIME() As String
            Get
                Return Me.ColumnyMap("TAKE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TAKE_TIME") = value
            End Set
        End Property
#End Region
#End Region


#Region "QueryBySp 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryBySp() As DataTable
            Return Me.QueryBySp(0, 0)
        End Function

        ''' <summary>
        ''' Charles 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryBySp(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Me.TableCoumnInfo.Add(New String() {"SYST001", "M", "CODE", "NAME", "DATEX"})
                Me.ParserAlias()

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand
                cmd.Connection = conn
                cmd.CommandText = "ENT_SYST001_QueryBySp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@PageNo", pageNo)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4)
                cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output

                Dim adpt As DbDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
                adpt.SelectCommand = cmd
                Dim ds As DataSet = New DataSet()
                adpt.Fill(ds)

                Me.TOTAL_ROW_COUNT = IIf(IsDBNull(cmd.Parameters("@RecordCount").Value), 0, cmd.Parameters("@RecordCount").Value)

                Dim dt As DataTable = ds.Tables(0)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region



#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "NAME"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "NAME"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "NAME"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

