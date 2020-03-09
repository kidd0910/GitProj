'----------------------------------------------------------------------------------
'File Name		: APP1411
'Author			: NCC管理者
'Description		: APP1411 APP1411 員額基本資料
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/15	NCC管理者		Source Create
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
    ' APP1411 APP1411 員額基本資料
    ' </summary>
    Public Class ENT_APP1411
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
            Me.TableName = "APP1411"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO"
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

#Region "BASE_DATE 基準日"
        '' <summary>
        '' BASE_DATE 基準日
        '' </summary>
        Public Property BASE_DATE() As String
            Get
                Return Me.ColumnyMap("BASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BASE_DATE") = value
            End Set
        End Property
#End Region

#Region "M_EMPLOYEE_NUMBER 公司男性員額"
        '' <summary>
        '' M_EMPLOYEE_NUMBER 公司男性員額
        '' </summary>
        Public Property M_EMPLOYEE_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_MANAGER_NUMBER 男性主管員額"
        '' <summary>
        '' M_MANAGER_NUMBER 男性主管員額
        '' </summary>
        Public Property M_MANAGER_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_HSCHOOL_NUMBER 高中(職)及以下男性"
        '' <summary>
        '' M_HSCHOOL_NUMBER 高中(職)及以下男性
        '' </summary>
        Public Property M_HSCHOOL_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_HSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_HSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_UNIVERSITY_NUMBER 大專、學院及大學男性"
        '' <summary>
        '' M_UNIVERSITY_NUMBER 大專、學院及大學男性
        '' </summary>
        Public Property M_UNIVERSITY_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_UNIVERSITY_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_UNIVERSITY_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_GSCHOOL_NUMBER 研究所及以上男性"
        '' <summary>
        '' M_GSCHOOL_NUMBER 研究所及以上男性
        '' </summary>
        Public Property M_GSCHOOL_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_GSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_GSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_EMPLOYEE_NUMBER 公司女性員額"
        '' <summary>
        '' W_EMPLOYEE_NUMBER 公司女性員額
        '' </summary>
        Public Property W_EMPLOYEE_NUMBER() As String
            Get
                Return Me.ColumnyMap("W_EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("W_EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_MANAGER_NUMBER 女性主管員額"
        '' <summary>
        '' W_MANAGER_NUMBER 女性主管員額
        '' </summary>
        Public Property W_MANAGER_NUMBER() As String
            Get
                Return Me.ColumnyMap("W_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("W_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_HSCHOOL_NUMBER 高中(職)及以下女性"
        '' <summary>
        '' W_HSCHOOL_NUMBER 高中(職)及以下女性
        '' </summary>
        Public Property W_HSCHOOL_NUMBER() As String
            Get
                Return Me.ColumnyMap("W_HSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("W_HSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_UNIVERSITY_NUMBER 大專、學院及大學女性"
        '' <summary>
        '' W_UNIVERSITY_NUMBER 大專、學院及大學女性
        '' </summary>
        Public Property W_UNIVERSITY_NUMBER() As String
            Get
                Return Me.ColumnyMap("W_UNIVERSITY_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("W_UNIVERSITY_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_GSCHOOL_NUMBER 研究所及以上女性"
        '' <summary>
        '' W_GSCHOOL_NUMBER 研究所及以上女性
        '' </summary>
        Public Property W_GSCHOOL_NUMBER() As String
            Get
                Return Me.ColumnyMap("W_GSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("W_GSCHOOL_NUMBER") = value
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

