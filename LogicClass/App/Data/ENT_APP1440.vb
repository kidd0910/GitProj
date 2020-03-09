'----------------------------------------------------------------------------------
'File Name		: APP1440
'Author			: NCC管理者
'Description		: APP1440 APP1440 各項報表申報完成時間
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/21	NCC管理者		Source Create
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
    ' APP1440 APP1440 各項報表申報完成時間
    ' </summary>
    Public Class ENT_APP1440
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
            Me.TableName = "APP1440"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,DECLARE_DESC"
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

#Region "YEAR 年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'"
        '' <summary>
        '' YEAR 年度, 社區型廣播不須輸入此欄位，所以在DB設定欄位預設值為'NONE'
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

#Region "DECLARE_ITEM 申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'"
        '' <summary>
        '' DECLARE_ITEM 申報項目/項目, REF, SYST010.SYS_KEY='DECLARE_ITEM'
        '' </summary>
        Public Property DECLARE_ITEM() As String
            Get
                Return Me.ColumnyMap("DECLARE_ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_ITEM") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_DATE 申報規定期限"
        '' <summary>
        '' DEADLINE_DATE 申報規定期限
        '' </summary>
        Public Property DEADLINE_DATE() As String
            Get
                Return Me.ColumnyMap("DEADLINE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE_DATE") = value
            End Set
        End Property
#End Region

#Region "DECLARE_DATE 實際申報日期/完成時間"
        '' <summary>
        '' DECLARE_DATE 實際申報日期/完成時間
        '' </summary>
        Public Property DECLARE_DATE() As String
            Get
                Return Me.ColumnyMap("DECLARE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_DATE") = value
            End Set
        End Property
#End Region

#Region "ON_TIME 是否正確準時, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' ON_TIME 是否正確準時, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property ON_TIME() As String
            Get
                Return Me.ColumnyMap("ON_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ON_TIME") = value
            End Set
        End Property
#End Region

#Region "DECLARE_DESC 備註"
        '' <summary>
        '' DECLARE_DESC 備註
        '' </summary>
        Public Property DECLARE_DESC() As String
            Get
                Return Me.ColumnyMap("DECLARE_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_DESC") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢項目ID對應NAME
        ''' </summary>
        Public Function Query_ItemWithName() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select * ")
                sql.AppendLine(" from APP1440 AP140 ")
                sql.AppendLine(" join SYST010 S010 ")
                sql.AppendLine(" on S010.SYS_KEY = 'DECLARE_ITEM' ")
                sql.AppendLine(" and S010.SYS_TYPE = 1 ")
                sql.AppendLine(" and S010.USE_STATE = 1 ")
                sql.AppendLine(" and S010.SYS_PRTID = 'CC01' ")
                sql.AppendLine(" and AP140.DECLARE_ITEM = S010.SYS_ID ")
                sql.AppendLine(" where 1 = 1  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

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

