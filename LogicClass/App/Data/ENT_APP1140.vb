'----------------------------------------------------------------------------------
'File Name		: APP1140
'Author			:  
'Description		: APP1140 改善/改正/承諾/行政處份事項
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/12	 		Source Create
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
    ' APP1140 改善/改正/承諾/行政處份事項
    ' </summary>
    Public Class ENT_APP1140
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
            Me.TableName = "APP1140"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,COMPLY_DESC,PAGE_NO,IMPROVE_ITEM,VIOLATION_ACT,IMPROVE_DESC,REMARK"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號, 共用"
        '' <summary>
        '' CASE_NO 案件編號, 共用
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

#Region "COMPLY_TYPE 類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用"
        '' <summary>
        '' COMPLY_TYPE 類型, REF.SYS_KEY='COMPLY_TYPE', 廣播使用時，為「營運計畫執行情形-行政指導及處分事項之執行情形」頁籤，寫入'C01'，為「未來之營運計畫-行政指導及處分事項之執行情形」，寫入'D01', 共用
        '' </summary>
        Public Property COMPLY_TYPE() As String
            Get
                Return Me.ColumnyMap("COMPLY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLY_TYPE") = value
            End Set
        End Property
#End Region

#Region "TBL_RECID 紀錄編號, 系統自動給號程式不須處理, 共用"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動給號程式不須處理, 共用
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

#Region "COMPLY_DESC 執行事項及辦理情形說明"
        '' <summary>
        '' COMPLY_DESC 執行事項及辦理情形說明
        '' </summary>
        Public Property COMPLY_DESC() As String
            Get
                Return Me.ColumnyMap("COMPLY_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLY_DESC") = value
            End Set
        End Property
#End Region

#Region "COMPLY_RESULT 執行情形, REF.SYS_KEY='COMPLY_RESULT'"
        '' <summary>
        '' COMPLY_RESULT 執行情形, REF.SYS_KEY='COMPLY_RESULT'
        '' </summary>
        Public Property COMPLY_RESULT() As String
            Get
                Return Me.ColumnyMap("COMPLY_RESULT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLY_RESULT") = value
            End Set
        End Property
#End Region

#Region "PAGE_NO 附件頁碼"
        '' <summary>
        '' PAGE_NO 附件頁碼
        '' </summary>
        Public Property PAGE_NO() As String
            Get
                Return Me.ColumnyMap("PAGE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAGE_NO") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_ITEM 違規事項/附款或應改善事項內容, 廣播用"
        '' <summary>
        '' IMPROVE_ITEM 違規事項/附款或應改善事項內容, 廣播用
        '' </summary>
        Public Property IMPROVE_ITEM() As String
            Get
                Return Me.ColumnyMap("IMPROVE_ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IMPROVE_ITEM") = value
            End Set
        End Property
#End Region

#Region "VIOLATION_ACT 違反之法令, 廣播用"
        '' <summary>
        '' VIOLATION_ACT 違反之法令, 廣播用
        '' </summary>
        Public Property VIOLATION_ACT() As String
            Get
                Return Me.ColumnyMap("VIOLATION_ACT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VIOLATION_ACT") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_DESC 改善情形"
        '' <summary>
        '' IMPROVE_DESC 改善情形
        '' </summary>
        Public Property IMPROVE_DESC() As String
            Get
                Return Me.ColumnyMap("IMPROVE_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IMPROVE_DESC") = value
            End Set
        End Property
#End Region

#Region "REMARK 備註"
        '' <summary>
        '' REMARK 備註
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.ColumnyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REMARK") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        '' <summary>
        '' 查詢 
        '' </summary>
        Public Function QueryCData() As DataTable
            Return Me.QueryCData(0, 0)
        End Function

        '' <summary>
        '' 查詢 
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function QueryCData(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1140", "M", "PKNO", "CASE_NO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME AS 'COMPLY_TYPE_NM', R2.SYS_NAME AS 'COMPLY_RESULT_NM' ")
                sql.AppendLine(" FROM APP1140 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON M.COMPLY_TYPE = R1.SYS_ID AND R1.SYS_KEY = 'COMPLY_TYPE' ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 ON M.COMPLY_RESULT = R2.SYS_ID AND R2.SYS_KEY = 'COMPLY_RESULT' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions.Replace("$.", " ")))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CREATE_TIME ")
                    Else
                        sql.AppendLine(" ORDER BY CREATE_TIME ")
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

