'----------------------------------------------------------------------------------
'File Name		: APP1430
'Author			: NCC管理者
'Description		: APP1430 APP1430 特定節目/活動
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/20	NCC管理者		Source Create
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
    ' APP1430 APP1430 特定節目/活動
    ' </summary>
    Public Class ENT_APP1430
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
            Me.TableName = "APP1430"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,SHOW_NAME,SHOW_LEN,SHOW_NUMBER,SHOW_TIME,PLAN_DESC,SHOW_DATE,ACTIVE_SITE,SERVICE_OBJECT,PART_NUMBER"
            Me.SET_NULL_FIELD = ""
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

#Region "ACTIVE_TYPE 類別，節目：1，活動：2"
        '' <summary>
        '' ACTIVE_TYPE 類別，節目：1，活動：2
        '' </summary>
        Public Property ACTIVE_TYPE() As String
            Get
                Return Me.ColumnyMap("ACTIVE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACTIVE_TYPE") = value
            End Set
        End Property
#End Region

#Region "SHOW_NAME 節目名稱/活動名稱/活動名稱及活動內容"
        '' <summary>
        '' SHOW_NAME 節目名稱/活動名稱/活動名稱及活動內容
        '' </summary>
        Public Property SHOW_NAME() As String
            Get
                Return Me.ColumnyMap("SHOW_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_NAME") = value
            End Set
        End Property
#End Region

#Region "SHOW_LEN 播出長度"
        '' <summary>
        '' SHOW_LEN 播出長度
        '' </summary>
        Public Property SHOW_LEN() As String
            Get
                Return Me.ColumnyMap("SHOW_LEN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_LEN") = value
            End Set
        End Property
#End Region

#Region "SHOW_NUMBER 播出集數/集數"
        '' <summary>
        '' SHOW_NUMBER 播出集數/集數
        '' </summary>
        Public Property SHOW_NUMBER() As String
            Get
                Return Me.ColumnyMap("SHOW_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SHOW_TIME SHOW_TIME"
        '' <summary>
        '' SHOW_TIME SHOW_TIME
        '' </summary>
        Public Property SHOW_TIME() As String
            Get
                Return Me.ColumnyMap("SHOW_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_TIME") = value
            End Set
        End Property
#End Region

#Region "PLAN_DESC 企劃內容/佐證資料/單元主題"
        '' <summary>
        '' PLAN_DESC 企劃內容/佐證資料/單元主題
        '' </summary>
        Public Property PLAN_DESC() As String
            Get
                Return Me.ColumnyMap("PLAN_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PLAN_DESC") = value
            End Set
        End Property
#End Region

#Region "SHOW_DATE 活動時間/播出期間"
        '' <summary>
        '' SHOW_DATE 活動時間/播出期間
        '' </summary>
        Public Property SHOW_DATE() As String
            Get
                Return Me.ColumnyMap("SHOW_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_DATE") = value
            End Set
        End Property
#End Region

#Region "ACTIVE_SITE 活動地點/地點"
        '' <summary>
        '' ACTIVE_SITE 活動地點/地點
        '' </summary>
        Public Property ACTIVE_SITE() As String
            Get
                Return Me.ColumnyMap("ACTIVE_SITE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACTIVE_SITE") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OBJECT 服務對象"
        '' <summary>
        '' SERVICE_OBJECT 服務對象
        '' </summary>
        Public Property SERVICE_OBJECT() As String
            Get
                Return Me.ColumnyMap("SERVICE_OBJECT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_OBJECT") = value
            End Set
        End Property
#End Region

#Region "PART_NUMBER PART_NUMBER"
        '' <summary>
        '' PART_NUMBER PART_NUMBER
        '' </summary>
        Public Property PART_NUMBER() As String
            Get
                Return Me.ColumnyMap("PART_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PART_NUMBER") = value
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
        ''' 0.0.1 NCC管理者 新增方法
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

