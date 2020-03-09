'----------------------------------------------------------------------------------
'File Name		: APPL021
'Author			:  
'Description		: APPL021 修正意見
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/25	 		Source Create
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
    ' APPL021 修正意見
    ' </summary>
    Public Class ENT_APPL021
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
            Me.TableName = "APPL021"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,MODIFY_DESC"
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

#Region "TAB_FILENAME 項目, REF. SYST010.SYS_KEY='TAB_FILENAME'"
        '' <summary>
        '' TAB_FILENAME 項目, REF. SYST010.SYS_KEY='TAB_FILENAME'
        '' </summary>
        Public Property TAB_FILENAME() As String
            Get
                Return Me.ColumnyMap("TAB_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TAB_FILENAME") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID 紀錄編號, 系統自動編號，排序用"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動編號，排序用
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

#Region "MODIFY_DESC 修正意見"
        '' <summary>
        '' MODIFY_DESC 修正意見
        '' </summary>
        Public Property MODIFY_DESC() As String
            Get
                Return Me.ColumnyMap("MODIFY_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MODIFY_DESC") = value
            End Set
        End Property
#End Region

#Region "M_PKNO 主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO"
        '' <summary>
        '' M_PKNO 主資料基本上與PKNO一樣，若該頁籤有分輸入、顯示不同程式時，顯示的頁籤紀錄輸入頁籤的PKNO
        '' </summary>
        Public Property M_PKNO() As String
            Get
                Return Me.ColumnyMap("M_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ 補正次數"
        '' <summary>
        '' CASE_SEQ 補正次數
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.ColumnyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryJoin() As DataTable
            Return Me.QueryJoin(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   新增方法
        ''' </remarks>
        Public Function QueryJoin(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"APPL021", "M", "CASE_NO", "TAB_FILENAME", "CREATE_TIME", "M_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME ")
                sql.AppendLine(" FROM APPL021 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON (M.TAB_FILENAME = R1.SYS_ID AND R1.SYS_KEY = 'TAB_FILENAME') AND R1.SYS_PRTID = SUBSTRING(M.CASE_NO, 1, 4) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY PKNO ")
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

