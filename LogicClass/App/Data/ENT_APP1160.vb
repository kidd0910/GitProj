'----------------------------------------------------------------------------------
'File Name		: APP1160
'Author			: TIM
'Description		: APP1160 員額編制
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/11	TIM		Source Create
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
    ' APP1160 員額編制
    ' </summary>
    Public Class ENT_APP1160
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
            Me.TableName = "APP1160"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,MEMBER_NAME"
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

#Region "MEMBER_NAME 委員姓名"
        '' <summary>
        '' MEMBER_NAME 委員姓名
        '' </summary>
        Public Property MEMBER_NAME() As String
            Get
                Return Me.ColumnyMap("MEMBER_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MEMBER_NAME") = value
            End Set
        End Property
#End Region

#Region "SEX_TYPE 性別, REF. SYST010.SYS_KEY='SEX_TYPE'"
        '' <summary>
        '' SEX_TYPE 性別, REF. SYST010.SYS_KEY='SEX_TYPE'
        '' </summary>
        Public Property SEX_TYPE() As String
            Get
                Return Me.ColumnyMap("SEX_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEX_TYPE") = value
            End Set
        End Property
#End Region

#Region "TEACHER_TYPE 內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'"
        '' <summary>
        '' TEACHER_TYPE 內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'
        '' </summary>
        Public Property TEACHER_TYPE() As String
            Get
                Return Me.ColumnyMap("TEACHER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TEACHER_TYPE") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1160", "M", "CASE_NO", "PKNO"})

                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME as SEX_TYPE_TXT ,R2.SYS_NAME as TEACHER_TYPE_TXT ")
                sql.AppendLine("    FROM APP1160 M ")
                sql.AppendLine("      LEFT JOIN SYST010 R1  ")
                sql.AppendLine("   ON R1.SYS_KEY = 'SEX_TYPE' AND M.SEX_TYPE = R1.SYS_ID  ")
                sql.AppendLine("    LEFT JOIN SYST010 R2  ")
                sql.AppendLine("   ON R2.SYS_KEY = 'TEACHER_TYPE' AND M.TEACHER_TYPE = R2.SYS_ID  ")
                sql.AppendLine("  WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(" AND " & Me.SqlRetrictions.Replace("$.", " "))
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

