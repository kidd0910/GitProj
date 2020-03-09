'----------------------------------------------------------------------------------
'File Name		: APP1420
'Author			:  
'Description		: APP1420 節目播出時數/比例
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/14	 		Source Create
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
    ' APP1420 節目播出時數/比例
    ' </summary>
    Public Class ENT_APP1420
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
            Me.TableName = "APP1420"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO"
            Me.SET_NULL_FIELD = "HOURS_TOTAL,INTERNAL_ALL_RATE,INTERNAL_MASTER_RATE,EXTERNAL_ALL_RATE,EXTERNAL_MASTER_RATE,JOIN_ALL_RATE,JOIN_MASTER_RATE,ITEM01_RATE,ITEM02_RATE,ITEM03_RATE,ITEM04_RATE,ITEM05_RATE,ITEM06_RATE,ITEM07_RATE,ITEM08_RATE,ITEM09_RATE,ITEM10_RATE,INTERNAL_RATE,EXTERNAL_RATE,NEW_RATE,FIRST_RATE,REPLAY_RATE,INSOURCE_RATE,OUTSOURCE_RATE"
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

#Region "YEAR 年期"
        '' <summary>
        '' YEAR 年期
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.ColumnyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "HOURS_TOTAL 播出總時數"
        '' <summary>
        '' HOURS_TOTAL 播出總時數
        '' </summary>
        Public Property HOURS_TOTAL() As String
            Get
                Return Me.ColumnyMap("HOURS_TOTAL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HOURS_TOTAL") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_ALL_RATE 自製節目比率-每日全時段"
        '' <summary>
        '' INTERNAL_ALL_RATE 自製節目比率-每日全時段
        '' </summary>
        Public Property INTERNAL_ALL_RATE() As String
            Get
                Return Me.ColumnyMap("INTERNAL_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_MASTER_RATE 自製節目比率-每日主要時段"
        '' <summary>
        '' INTERNAL_MASTER_RATE 自製節目比率-每日主要時段
        '' </summary>
        Public Property INTERNAL_MASTER_RATE() As String
            Get
                Return Me.ColumnyMap("INTERNAL_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_ALL_RATE 外製節目比率-每日全時段"
        '' <summary>
        '' EXTERNAL_ALL_RATE 外製節目比率-每日全時段
        '' </summary>
        Public Property EXTERNAL_ALL_RATE() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_MASTER_RATE 外製節目比率-每日主要時段"
        '' <summary>
        '' EXTERNAL_MASTER_RATE 外製節目比率-每日主要時段
        '' </summary>
        Public Property EXTERNAL_MASTER_RATE() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_ALL_RATE 聯播節目比率-每日全時段"
        '' <summary>
        '' JOIN_ALL_RATE 聯播節目比率-每日全時段
        '' </summary>
        Public Property JOIN_ALL_RATE() As String
            Get
                Return Me.ColumnyMap("JOIN_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOIN_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_MASTER_RATE 聯播節目比率-每日主要時段"
        '' <summary>
        '' JOIN_MASTER_RATE 聯播節目比率-每日主要時段
        '' </summary>
        Public Property JOIN_MASTER_RATE() As String
            Get
                Return Me.ColumnyMap("JOIN_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOIN_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM01_RATE 國語發音-比例"
        '' <summary>
        '' ITEM01_RATE 國語發音-比例
        '' </summary>
        Public Property ITEM01_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM01_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM01_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM02_RATE 台語發音-比例"
        '' <summary>
        '' ITEM02_RATE 台語發音-比例
        '' </summary>
        Public Property ITEM02_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM02_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM02_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM03_RATE 客語發音-比例"
        '' <summary>
        '' ITEM03_RATE 客語發音-比例
        '' </summary>
        Public Property ITEM03_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM03_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM03_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM04_RATE 原住民語發音-比例"
        '' <summary>
        '' ITEM04_RATE 原住民語發音-比例
        '' </summary>
        Public Property ITEM04_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM04_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM04_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM05_RATE 英語發音-比例"
        '' <summary>
        '' ITEM05_RATE 英語發音-比例
        '' </summary>
        Public Property ITEM05_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM05_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM05_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM06_RATE 其他外國語言發音-比例"
        '' <summary>
        '' ITEM06_RATE 其他外國語言發音-比例
        '' </summary>
        Public Property ITEM06_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM06_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM06_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM07_RATE 新聞政令宣導-比例"
        '' <summary>
        '' ITEM07_RATE 新聞政令宣導-比例
        '' </summary>
        Public Property ITEM07_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM07_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM07_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM08_RATE 教育文化-比例"
        '' <summary>
        '' ITEM08_RATE 教育文化-比例
        '' </summary>
        Public Property ITEM08_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM08_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM08_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM09_RATE 公共服務-比例"
        '' <summary>
        '' ITEM09_RATE 公共服務-比例
        '' </summary>
        Public Property ITEM09_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM09_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM09_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM10_RATE 大眾娛樂-比例"
        '' <summary>
        '' ITEM10_RATE 大眾娛樂-比例
        '' </summary>
        Public Property ITEM10_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM10_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM10_RATE") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_RATE 本國製-比例"
        '' <summary>
        '' INTERNAL_RATE 本國製-比例
        '' </summary>
        Public Property INTERNAL_RATE() As String
            Get
                Return Me.ColumnyMap("INTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_RATE 非本國製-比例"
        '' <summary>
        '' EXTERNAL_RATE 非本國製-比例
        '' </summary>
        Public Property EXTERNAL_RATE() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "NEW_RATE 新播-比例"
        '' <summary>
        '' NEW_RATE 新播-比例
        '' </summary>
        Public Property NEW_RATE() As String
            Get
                Return Me.ColumnyMap("NEW_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NEW_RATE") = value
            End Set
        End Property
#End Region

#Region "FIRST_RATE 首播-比例"
        '' <summary>
        '' FIRST_RATE 首播-比例
        '' </summary>
        Public Property FIRST_RATE() As String
            Get
                Return Me.ColumnyMap("FIRST_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FIRST_RATE") = value
            End Set
        End Property
#End Region

#Region "REPLAY_RATE 重播-比例"
        '' <summary>
        '' REPLAY_RATE 重播-比例
        '' </summary>
        Public Property REPLAY_RATE() As String
            Get
                Return Me.ColumnyMap("REPLAY_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPLAY_RATE") = value
            End Set
        End Property
#End Region

#Region "INSOURCE_RATE 自製-比例"
        '' <summary>
        '' INSOURCE_RATE 自製-比例
        '' </summary>
        Public Property INSOURCE_RATE() As String
            Get
                Return Me.ColumnyMap("INSOURCE_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INSOURCE_RATE") = value
            End Set
        End Property
#End Region

#Region "OUTSOURCE_RATE 外購-比例"
        '' <summary>
        '' OUTSOURCE_RATE 外購-比例
        '' </summary>
        Public Property OUTSOURCE_RATE() As String
            Get
                Return Me.ColumnyMap("OUTSOURCE_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUTSOURCE_RATE") = value
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
        ''' 0.0.1   新增方法
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

