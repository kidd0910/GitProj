'----------------------------------------------------------------------------------
'File Name		: APP0001
'Author			: TIM
'Description		: APP0001 應載細項
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/22	TIM		Source Create
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
    ' APP0001 應載細項
    ' </summary>
    Public Class ENT_APP0001
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
            Me.TableName = "APP0001"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "DESC1,DESC2"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CASE_CODE 業務種類代碼, REF. SYST010.SYS_KEY='CASE_CODE'"
        '' <summary>
        '' CASE_CODE 業務種類代碼, REF. SYST010.SYS_KEY='CASE_CODE'
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

#Region "FILE_NO 章節編號, 衛星廣播：紀錄應載細項的章節編號 / 電視：紀錄章節編號 / 廣播：紀錄章節編號"
        '' <summary>
        '' FILE_NO 章節編號, 衛星廣播：紀錄應載細項的章節編號 / 電視：紀錄章節編號 / 廣播：紀錄章節編號
        '' </summary>
        Public Property FILE_NO() As String
            Get
                Return Me.ColumnyMap("FILE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_NO") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT 排序"
        '' <summary>
        '' SYS_SORT 排序
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.ColumnyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "TAB_TYPE "
        '' <summary>
        '' TAB_TYPE 
        '' </summary>
        Public Property TAB_TYPE() As String
            Get
                Return Me.ColumnyMap("TAB_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TAB_TYPE") = value
            End Set
        End Property
#End Region

#Region "DESC1 應載細項"
        '' <summary>
        '' DESC1 應載細項
        '' </summary>
        Public Property DESC1() As String
            Get
                Return Me.ColumnyMap("DESC1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC1") = value
            End Set
        End Property
#End Region

#Region "DESC2 填寫說明"
        '' <summary>
        '' DESC2 填寫說明
        '' </summary>
        Public Property DESC2() As String
            Get
                Return Me.ColumnyMap("DESC2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC2") = value
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

