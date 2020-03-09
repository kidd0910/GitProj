'----------------------------------------------------------------------------------
'File Name		: EntBatchProg
'Author			: 
'Description		: EntBatchProg 批次程式名稱ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/11/11			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Bat.Data
    '' <summary>
    '' EntBatchProg 批次程式名稱ENT
    '' </summary>
    Public Class EntBatchProg
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "BATC020"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "PROG_CD 程式代號"
        ''' <summary>
        ''' PROG_CD 程式代號
        ''' </summary>
        Public Property PROG_CD As String
            Get
                Return Me.ColumnyMap("PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_CD") = value
            End Set
        End Property
#End Region

#Region "PROG_NM 程式名稱"
        ''' <summary>
        ''' PROG_NM 程式名稱
        ''' </summary>
        Public Property PROG_NM As String
            Get
                Return Me.ColumnyMap("PROG_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_NM") = value
            End Set
        End Property
#End Region

#Region "PROG_TYPE 程式類別"
        ''' <summary>
        ''' PROG_TYPE 程式類別
        ''' </summary>
        Public Property PROG_TYPE As String
            Get
                Return Me.ColumnyMap("PROG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROG_TYPE") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "GetBatchProgramDDL 取得批次程式下拉 "
        ''' <summary>
        ''' 取得批次程式下拉 
        ''' </summary>
        Public Function GetBatchProgramDDL() As DataTable
            Return Me.GetBatchProgramDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得批次程式下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetBatchProgramDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'Select PROG_CD(程式代號) as value ,程式代號||程式名稱 as text From BATC020 
                'Where PROG_TYPE(程式類別)=QUERY_COND(查詢條件)

                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"BATC020", "M", "PROG_TYPE"})
                Me.ParserAlias()
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.PROG_CD AS SELECT_VALUE, M.PROG_NM AS SELECT_TEXT ")
                sql.AppendLine(" FROM BATC020 M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PROG_CD ")
                    Else
                        sql.AppendLine(" ORDER BY PROG_CD ")
                    End If
                End If


                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region

    End Class
End Namespace

