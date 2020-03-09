'----------------------------------------------------------------------------------
'File Name		: APP1460
'Author			: NCC管理者
'Description		: APP1460 APP1460 建設計畫
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/13	NCC管理者		Source Create
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
    ' APP1460 APP1460 建設計畫
    ' </summary>
    Public Class ENT_APP1460
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
            Me.TableName = "APP1460"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,RADIO_ADDRESS,PRE_POPULATION,STUDIO_ADDRESS,BUSINESS_ADDRESS"
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

#Region "RADIO_CITY 電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' RADIO_CITY 電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property RADIO_CITY() As String
            Get
                Return Me.ColumnyMap("RADIO_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RADIO_CITY") = value
            End Set
        End Property
#End Region

#Region "RADIO_ZIP 電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' RADIO_ZIP 電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property RADIO_ZIP() As String
            Get
                Return Me.ColumnyMap("RADIO_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RADIO_ZIP") = value
            End Set
        End Property
#End Region

#Region "RADIO_ADDRESS 電臺預訂設置地點"
        '' <summary>
        '' RADIO_ADDRESS 電臺預訂設置地點
        '' </summary>
        Public Property RADIO_ADDRESS() As String
            Get
                Return Me.ColumnyMap("RADIO_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RADIO_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "PRE_SETUP_DATE 預估設立完成時間"
        '' <summary>
        '' PRE_SETUP_DATE 預估設立完成時間
        '' </summary>
        Public Property PRE_SETUP_DATE() As String
            Get
                Return Me.ColumnyMap("PRE_SETUP_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRE_SETUP_DATE") = value
            End Set
        End Property
#End Region

#Region "PRE_POPULATION 預估涵蓋人口數"
        '' <summary>
        '' PRE_POPULATION 預估涵蓋人口數
        '' </summary>
        Public Property PRE_POPULATION() As String
            Get
                Return Me.ColumnyMap("PRE_POPULATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRE_POPULATION") = value
            End Set
        End Property
#End Region

#Region "STUDIO_CITY 錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' STUDIO_CITY 錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property STUDIO_CITY() As String
            Get
                Return Me.ColumnyMap("STUDIO_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STUDIO_CITY") = value
            End Set
        End Property
#End Region

#Region "STUDIO_ZIP 錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' STUDIO_ZIP 錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property STUDIO_ZIP() As String
            Get
                Return Me.ColumnyMap("STUDIO_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STUDIO_ZIP") = value
            End Set
        End Property
#End Region

#Region "STUDIO_ADDRESS 錄播音室設置地點"
        '' <summary>
        '' STUDIO_ADDRESS 錄播音室設置地點
        '' </summary>
        Public Property STUDIO_ADDRESS() As String
            Get
                Return Me.ColumnyMap("STUDIO_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STUDIO_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "SITE_NUMBER 錄播音室數量"
        '' <summary>
        '' SITE_NUMBER 錄播音室數量
        '' </summary>
        Public Property SITE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SITE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SITE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_SITE_NUMBER 主控播音室數量"
        '' <summary>
        '' M_SITE_NUMBER 主控播音室數量
        '' </summary>
        Public Property M_SITE_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_SITE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_SITE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_CITY 事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_CITY 事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_CITY() As String
            Get
                Return Me.ColumnyMap("BUSINESS_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_CITY") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ZIP 事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_ZIP 事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_ZIP() As String
            Get
                Return Me.ColumnyMap("BUSINESS_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_ZIP") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ADDRESS 事業營業場所設置地點"
        '' <summary>
        '' BUSINESS_ADDRESS 事業營業場所設置地點
        '' </summary>
        Public Property BUSINESS_ADDRESS() As String
            Get
                Return Me.ColumnyMap("BUSINESS_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_ADDRESS") = value
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

