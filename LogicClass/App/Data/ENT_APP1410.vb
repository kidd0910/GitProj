'----------------------------------------------------------------------------------
'File Name		: APP1410
'Author			: NCC管理者
'Description		: APP1410 APP1410 員額編制表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/07	NCC管理者		Source Create
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
    ' APP1410 APP1410 員額編制表
    ' </summary>
    Public Class ENT_APP1410
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
            Me.TableName = "APP1410"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,DEPT_NAME,JOB_NAME,MANAGER_NAME"
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

#Region "DEPT_NAME 部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入"
        '' <summary>
        '' DEPT_NAME 部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入
        '' </summary>
        Public Property DEPT_NAME() As String
            Get
                Return Me.ColumnyMap("DEPT_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEPT_NAME") = value
            End Set
        End Property
#End Region

#Region "其他部門-說明"
        '' <summary>
        '' 其他部門-說明
        '' </summary>
        Public Property DEPT_DESC() As String
            Get
                Return Me.ColumnyMap("DEPT_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEPT_DESC") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID 紀錄編號, 系統自動編號"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動編號
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

#Region "MANAGER_NUMBER 主管人數"
        '' <summary>
        '' MANAGER_NUMBER 主管人數
        '' </summary>
        Public Property MANAGER_NUMBER() As String
            Get
                Return Me.ColumnyMap("MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "NON_MANAGER_NUMBER 非主管人數"
        '' <summary>
        '' NON_MANAGER_NUMBER 非主管人數
        '' </summary>
        Public Property NON_MANAGER_NUMBER() As String
            Get
                Return Me.ColumnyMap("NON_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NON_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EMPLOYEE_NUMBER 員工人數"
        '' <summary>
        '' EMPLOYEE_NUMBER 員工人數
        '' </summary>
        Public Property EMPLOYEE_NUMBER() As String
            Get
                Return Me.ColumnyMap("EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "JOB_NAME 主管職稱"
        '' <summary>
        '' JOB_NAME 主管職稱
        '' </summary>
        Public Property JOB_NAME() As String
            Get
                Return Me.ColumnyMap("JOB_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOB_NAME") = value
            End Set
        End Property
#End Region

#Region "MANAGER_NAME 姓名"
        '' <summary>
        '' MANAGER_NAME 姓名
        '' </summary>
        Public Property MANAGER_NAME() As String
            Get
                Return Me.ColumnyMap("MANAGER_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MANAGER_NAME") = value
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

