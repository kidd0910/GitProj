'----------------------------------------------------------------------------------
'File Name		: APP1150
'Author			: San
'Description		: APP1150 經營代理之頻道
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/06	San		Source Create
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
    ' APP1150 經營代理之頻道
    ' </summary>
    Public Class ENT_APP1150
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
            Me.TableName = "APP1150"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,CHANNEL_NAME"
            Me.SET_NULL_FIELD = "PUNISH_AMT,LICENSE_S_DATE,LICENSE_E_DATE"
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

#Region "TBL_RECID 紀錄編號"
        '' <summary>
        '' TBL_RECID 紀錄編號
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

#Region "CHANNEL_NAME 頻道名稱"
        '' <summary>
        '' CHANNEL_NAME 頻道名稱
        '' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_TYPE 頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'"
        '' <summary>
        '' CHANNEL_TYPE 頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'
        '' </summary>
        Public Property CHANNEL_TYPE() As String
            Get
                Return Me.ColumnyMap("CHANNEL_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_TYPE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE 執照期限(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照期限(起)
        '' </summary>
        Public Property LICENSE_S_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_S_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_E_DATE 執照期限(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照期限(迄)
        '' </summary>
        Public Property LICENSE_E_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PUNISH_NUMBER 執照期限內核處次數"
        '' <summary>
        '' PUNISH_NUMBER 執照期限內核處次數
        '' </summary>
        Public Property PUNISH_NUMBER() As String
            Get
                Return Me.ColumnyMap("PUNISH_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PUNISH_NUMBER") = value
            End Set
        End Property
#End Region

#Region "PUNISH_AMT 執照期限內核處金額"
        '' <summary>
        '' PUNISH_AMT 執照期限內核處金額
        '' </summary>
        Public Property PUNISH_AMT() As String
            Get
                Return Me.ColumnyMap("PUNISH_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PUNISH_AMT") = value
            End Set
        End Property
#End Region

#Region "COUNTRY_TYPE 境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'"
        '' <summary>
        '' COUNTRY_TYPE 境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'
        '' </summary>
        Public Property COUNTRY_TYPE() As String
            Get
                Return Me.ColumnyMap("COUNTRY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY_TYPE") = value
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
                Me.TableCoumnInfo.Add(New String() {"APP1150", "M", "CASE_NO"})

                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME as CHANNEL_TYPE_NM ,R2.SYS_NAME as COUNTRY_TYPE_NM ")
                sql.AppendLine("    FROM APP1150 M ")
                sql.AppendLine("      LEFT JOIN SYST010 R1  ")
                sql.AppendLine("   ON R1.SYS_KEY = 'CHANNEL_TYPE' AND M.CHANNEL_TYPE = R1.SYS_ID  ")
                sql.AppendLine("    LEFT JOIN SYST010 R2  ")
                sql.AppendLine("   ON R2.SYS_KEY = 'COUNTRY_TYPE1' AND M.COUNTRY_TYPE = R2.SYS_ID  ")
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


