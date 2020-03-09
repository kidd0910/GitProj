'----------------------------------------------------------------------------------
'File Name		: APP1450
'Author			: NCC管理者
'Description		: APP1450 APP1450 財務計畫
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/12	NCC管理者		Source Create
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
    ' APP1450 APP1450 財務計畫
    ' </summary>
    Public Class ENT_APP1450
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
            Me.TableName = "APP1450"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,M_INCOME_DESC,O_INCOME_DESC,M_COST_DESC"
            Me.SET_NULL_FIELD = "M_INCOME1_AMT,M_INCOME2_AMT,M_INCOME3_AMT,O_INCOME1_AMT,O_INCOME2_AMT,O_INCOME3_AMT,M_COST1_AMT,M_COST2_AMT,M_COST3_AMT,O_COST_DESC,O_COST1_AMT,O_COST2_AMT,O_COST3_AMT"
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

#Region "M_INCOME_DESC 主要收入內容"
        '' <summary>
        '' M_INCOME_DESC 主要收入內容
        '' </summary>
        Public Property M_INCOME_DESC() As String
            Get
                Return Me.ColumnyMap("M_INCOME_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_INCOME_DESC") = value
            End Set
        End Property
#End Region

#Region "M_INCOME1_AMT 主要收入-第1年"
        '' <summary>
        '' M_INCOME1_AMT 主要收入-第1年
        '' </summary>
        Public Property M_INCOME1_AMT() As String
            Get
                Return Me.ColumnyMap("M_INCOME1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_INCOME1_AMT") = value
            End Set
        End Property
#End Region

#Region "M_INCOME2_AMT 主要收入-第2年"
        '' <summary>
        '' M_INCOME2_AMT 主要收入-第2年
        '' </summary>
        Public Property M_INCOME2_AMT() As String
            Get
                Return Me.ColumnyMap("M_INCOME2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_INCOME2_AMT") = value
            End Set
        End Property
#End Region

#Region "M_INCOME3_AMT 主要收入-第3年"
        '' <summary>
        '' M_INCOME3_AMT 主要收入-第3年
        '' </summary>
        Public Property M_INCOME3_AMT() As String
            Get
                Return Me.ColumnyMap("M_INCOME3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_INCOME3_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME_DESC 其他收入內容"
        '' <summary>
        '' O_INCOME_DESC 其他收入內容
        '' </summary>
        Public Property O_INCOME_DESC() As String
            Get
                Return Me.ColumnyMap("O_INCOME_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_INCOME_DESC") = value
            End Set
        End Property
#End Region

#Region "O_INCOME1_AMT 其他收入-第1年"
        '' <summary>
        '' O_INCOME1_AMT 其他收入-第1年
        '' </summary>
        Public Property O_INCOME1_AMT() As String
            Get
                Return Me.ColumnyMap("O_INCOME1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_INCOME1_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME2_AMT 其他收入-第2年"
        '' <summary>
        '' O_INCOME2_AMT 其他收入-第2年
        '' </summary>
        Public Property O_INCOME2_AMT() As String
            Get
                Return Me.ColumnyMap("O_INCOME2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_INCOME2_AMT") = value
            End Set
        End Property
#End Region

#Region "O_INCOME3_AMT 其他收入-第3年"
        '' <summary>
        '' O_INCOME3_AMT 其他收入-第3年
        '' </summary>
        Public Property O_INCOME3_AMT() As String
            Get
                Return Me.ColumnyMap("O_INCOME3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_INCOME3_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST_DESC 主要成本及費用內容"
        '' <summary>
        '' M_COST_DESC 主要成本及費用內容
        '' </summary>
        Public Property M_COST_DESC() As String
            Get
                Return Me.ColumnyMap("M_COST_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_COST_DESC") = value
            End Set
        End Property
#End Region

#Region "M_COST1_AMT 主要成本及費用-第1年"
        '' <summary>
        '' M_COST1_AMT 主要成本及費用-第1年
        '' </summary>
        Public Property M_COST1_AMT() As String
            Get
                Return Me.ColumnyMap("M_COST1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_COST1_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST2_AMT 主要成本及費用-第2年"
        '' <summary>
        '' M_COST2_AMT 主要成本及費用-第2年
        '' </summary>
        Public Property M_COST2_AMT() As String
            Get
                Return Me.ColumnyMap("M_COST2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_COST2_AMT") = value
            End Set
        End Property
#End Region

#Region "M_COST3_AMT 主要成本及費用-第3年"
        '' <summary>
        '' M_COST3_AMT 主要成本及費用-第3年
        '' </summary>
        Public Property M_COST3_AMT() As String
            Get
                Return Me.ColumnyMap("M_COST3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_COST3_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST1_AMT 其他成本及費用-第1年"
        '' <summary>
        '' O_COST1_AMT 其他成本及費用-第1年
        '' </summary>
        Public Property O_COST1_AMT() As String
            Get
                Return Me.ColumnyMap("O_COST1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_COST1_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST_DESC 其他成本及費用內容"
        '' <summary>
        '' M_COST_DESC 主要成本及費用內容
        '' </summary>
        Public Property O_COST_DESC() As String
            Get
                Return Me.ColumnyMap("O_COST_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_COST_DESC") = value
            End Set
        End Property
#End Region

#Region "O_COST2_AMT 其他成本及費用-第2年"
        '' <summary>
        '' O_COST2_AMT 其他成本及費用-第2年
        '' </summary>
        Public Property O_COST2_AMT() As String
            Get
                Return Me.ColumnyMap("O_COST2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_COST2_AMT") = value
            End Set
        End Property
#End Region

#Region "O_COST3_AMT 其他成本及費用-第3年"
        '' <summary>
        '' O_COST3_AMT 其他成本及費用-第3年
        '' </summary>
        Public Property O_COST3_AMT() As String
            Get
                Return Me.ColumnyMap("O_COST3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_COST3_AMT") = value
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

