'----------------------------------------------------------------------------------
'File Name		: APP1451
'Author			: NCC管理者
'Description		: APP1451 APP1451 廣播/電視事業年度損益表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/19	NCC管理者		Source Create
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
    ' APP1451 APP1451 廣播/電視事業年度損益表
    ' </summary>
    Public Class ENT_APP1451
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
            Me.TableName = "APP1451"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO"
            Me.SET_NULL_FIELD = "OPERATING_MARGIN,OPERATING_PROFIT,BEFORE_TAX_INCOME,INCOME_TAX_EXP,AFTER_TAX_INCOME,END_SURPLUS"
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

#Region "YEAR 年度"
        '' <summary>
        '' YEAR 年度
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

#Region "DATA_TYPE 類型, 0：目前，1：未來"
        '' <summary>
        '' DATA_TYPE 類型, 0：目前，1：未來
        '' </summary>
        Public Property DATA_TYPE() As String
            Get
                Return Me.ColumnyMap("DATA_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_TYPE") = value
            End Set
        End Property
#End Region

#Region "OPERATING_INCOME 營業收入/收入"
        '' <summary>
        '' OPERATING_INCOME 營業收入/收入
        '' </summary>
        Public Property OPERATING_INCOME() As String
            Get
                Return Me.ColumnyMap("OPERATING_INCOME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_INCOME") = value
            End Set
        End Property
#End Region

#Region "OPERATING_COST 營業成本/成本"
        '' <summary>
        '' OPERATING_COST 營業成本/成本
        '' </summary>
        Public Property OPERATING_COST() As String
            Get
                Return Me.ColumnyMap("OPERATING_COST")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_COST") = value
            End Set
        End Property
#End Region

#Region "OPERATING_EXP 營業費用/費用"
        '' <summary>
        '' OPERATING_EXP 營業費用/費用
        '' </summary>
        Public Property OPERATING_EXP() As String
            Get
                Return Me.ColumnyMap("OPERATING_EXP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_EXP") = value
            End Set
        End Property
#End Region

#Region "NON_OPERATING_INCOME 營業外收益及費損"
        '' <summary>
        '' NON_OPERATING_INCOME 營業外收益及費損
        '' </summary>
        Public Property NON_OPERATING_INCOME() As String
            Get
                Return Me.ColumnyMap("NON_OPERATING_INCOME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NON_OPERATING_INCOME") = value
            End Set
        End Property
#End Region

#Region "OPERATING_MARGIN 營業毛利"
        '' <summary>
        '' OPERATING_MARGIN 營業毛利
        '' </summary>
        Public Property OPERATING_MARGIN() As String
            Get
                Return Me.ColumnyMap("OPERATING_MARGIN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_MARGIN") = value
            End Set
        End Property
#End Region

#Region "OPERATING_PROFIT 營業淨利"
        '' <summary>
        '' OPERATING_PROFIT 營業淨利
        '' </summary>
        Public Property OPERATING_PROFIT() As String
            Get
                Return Me.ColumnyMap("OPERATING_PROFIT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATING_PROFIT") = value
            End Set
        End Property
#End Region

#Region "NON_OPERATING_PAY NON_OPERATING_PAY"
        '' <summary>
        '' NON_OPERATING_PAY NON_OPERATING_PAY
        '' </summary>
        Public Property NON_OPERATING_PAY() As String
            Get
                Return Me.ColumnyMap("NON_OPERATING_PAY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NON_OPERATING_PAY") = value
            End Set
        End Property
#End Region

#Region "BEFORE_TAX_INCOME 稅前淨利"
        '' <summary>
        '' BEFORE_TAX_INCOME 稅前淨利
        '' </summary>
        Public Property BEFORE_TAX_INCOME() As String
            Get
                Return Me.ColumnyMap("BEFORE_TAX_INCOME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BEFORE_TAX_INCOME") = value
            End Set
        End Property
#End Region

#Region "INCOME_TAX_EXP 所得稅費用"
        '' <summary>
        '' INCOME_TAX_EXP 所得稅費用
        '' </summary>
        Public Property INCOME_TAX_EXP() As String
            Get
                Return Me.ColumnyMap("INCOME_TAX_EXP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INCOME_TAX_EXP") = value
            End Set
        End Property
#End Region

#Region "AFTER_TAX_INCOME 稅後淨利"
        '' <summary>
        '' AFTER_TAX_INCOME 稅後淨利
        '' </summary>
        Public Property AFTER_TAX_INCOME() As String
            Get
                Return Me.ColumnyMap("AFTER_TAX_INCOME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("AFTER_TAX_INCOME") = value
            End Set
        End Property
#End Region

#Region "END_SURPLUS 期末累積餘絀"
        '' <summary>
        '' END_SURPLUS 期末累積餘絀
        '' </summary>
        Public Property END_SURPLUS() As String
            Get
                Return Me.ColumnyMap("END_SURPLUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("END_SURPLUS") = value
            End Set
        End Property
#End Region

#Region "IN_BUDGET 歲入-預算數"
        '' <summary>
        '' IN_BUDGET 歲入-預算數
        '' </summary>
        Public Property IN_BUDGET() As String
            Get
                Return Me.ColumnyMap("IN_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_BUDGET") = value
            End Set
        End Property
#End Region

#Region "IN_BALANCED_BUDGET 歲入-決算數"
        '' <summary>
        '' IN_BALANCED_BUDGET 歲入-決算數
        '' </summary>
        Public Property IN_BALANCED_BUDGET() As String
            Get
                Return Me.ColumnyMap("IN_BALANCED_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_BALANCED_BUDGET") = value
            End Set
        End Property
#End Region

#Region "IN_EX_RATE 歲入-執行率"
        '' <summary>
        '' IN_EX_RATE 歲入-執行率
        '' </summary>
        Public Property IN_EX_RATE() As String
            Get
                Return Me.ColumnyMap("IN_EX_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_EX_RATE") = value
            End Set
        End Property
#End Region

#Region "OUT_BUDGET 歲出-預算數"
        '' <summary>
        '' OUT_BUDGET 歲出-預算數
        '' </summary>
        Public Property OUT_BUDGET() As String
            Get
                Return Me.ColumnyMap("OUT_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUT_BUDGET") = value
            End Set
        End Property
#End Region

#Region "OUT_BALANCDE_BUDGET 歲出-決算數"
        '' <summary>
        '' OUT_BALANCDE_BUDGET 歲出-決算數
        '' </summary>
        Public Property OUT_BALANCDE_BUDGET() As String
            Get
                Return Me.ColumnyMap("OUT_BALANCDE_BUDGET")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUT_BALANCDE_BUDGET") = value
            End Set
        End Property
#End Region

#Region "OUT_EX_RATE 歲出-執行率"
        '' <summary>
        '' OUT_EX_RATE 歲出-執行率
        '' </summary>
        Public Property OUT_EX_RATE() As String
            Get
                Return Me.ColumnyMap("OUT_EX_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUT_EX_RATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1451"
        ' <summary>Ent_APP1451</ summary>
        Private Property Ent_APP1451() As ENT_APP1451
            Get
                Return Me.ColumnyMap("Ent_APP1451")
            End Get
            Set(ByVal value As ENT_APP1451)
                Me.ColumnyMap("Ent_APP1451") = value
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

