'----------------------------------------------------------------------------------
'File Name		: APP1060
'Author			: TIM
'Description		: APP1060 學經歷介紹
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/28	TIM		Source Create
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
    ' APP1060 學經歷介紹
    ' </summary>
    Public Class ENT_APP1060
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
            Me.TableName = "APP1060"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,JOBTITLE,CH_NAME,LEARN_EXP_INTRO"
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

#Region "JOBTITLE 職稱"
        '' <summary>
        '' JOBTITLE 職稱
        '' </summary>
        Public Property JOBTITLE() As String
            Get
                Return Me.ColumnyMap("JOBTITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOBTITLE") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 姓名"
        '' <summary>
        '' CH_NAME 姓名
        '' </summary>
        Public Property CH_NAME() As String
            Get
                Return Me.ColumnyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "LEARN_EXP_INTRO 學經歷介紹"
        '' <summary>
        '' LEARN_EXP_INTRO 學經歷介紹
        '' </summary>
        Public Property LEARN_EXP_INTRO() As String
            Get
                Return Me.ColumnyMap("LEARN_EXP_INTRO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LEARN_EXP_INTRO") = value
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

        '        '=== 檢核欄位起始 ===
        '        Dim faileArguments As ArrayList = New ArrayList()

        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== 檢核欄位結束 ===

        '        '=== 處理別名 ===
        '        'Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
        '        'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
        '        Me.ParserAlias()

        '        Dim sql As New StringBuilder
        '        sql.AppendLine(" SELECT M.*, ")
        '        sql.AppendLine(" FROM APP1060 M ")

        '        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
        '            sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
        '        End If

        '        If Me.OrderBys <> "" Then
        '            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
        '        Else
        '            If pageNo = 0 Then
        '                sql.AppendLine(" ORDER BY M.STNO ")
        '            Else
        '                sql.AppendLine(" ORDER BY STNO ")
        '            End If
        '        End If

        '        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

        '        Me.ResetColumnProperty()

        '        Return dt
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function

#End Region
#End Region



    End Class
End Namespace

