'----------------------------------------------------------------------------------
'File Name		    : APPL011
'Author			    : Pete
'Description		: APPL011 業者變更資訊
'Modification Log	:
'
'Vers		    Date       	    By		        Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		    2015/08/11	    Pete	    	Source Create
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
    ' APPL010 業者資訊
    ' </summary>
    Public Class ENT_APPL011
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
            Me.TableName = "APPL011"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"

#Region "COM_PKNO"
        '' <summary>
        '' COM_PKNO
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.ColumnyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法 Query"

#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CMHuang 新增方法
        ''' </remarks>
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
                Me.TableCoumnInfo.Add(New String() {"APPL011", "M", "COM_PKNO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, isNull(R1.CH_NAME, '') AS CREATE_USER_NM, ")
                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(M.CREATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(M.CREATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(M.CREATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(M.CREATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(M.CREATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(M.CREATE_TIME) } AS VARCHAR(2)),2) )  AS CREATE_TIME_1 ")

                sql.AppendLine(" FROM APPL011 M ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R1 ON M.CREATE_USER = R1.ACNT ")
                
                If Not String.IsNullOrEmpty(Me.COM_PKNO) Then
                    sql.AppendLine(" WHERE M.COM_PKNO = '" & Utility.DBStr(Me.COM_PKNO) & "' ")
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CREATE_TIME DESC ")
                    Else
                        sql.AppendLine(" ORDER BY CREATE_TIME DESC ")
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

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = ""
            Return MyBase.UpdateByPkNo()
        End Function
#End Region

    End Class
End Namespace

