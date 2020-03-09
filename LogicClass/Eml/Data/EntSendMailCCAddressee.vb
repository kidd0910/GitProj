'----------------------------------------------------------------------------------
'File Name		: EntSendMailCCAddressee
'Author			: Brian Chou
'Description		: EntSendMailCCAddressee 附本收件人ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/08/22	Brian Chou		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Eml.Data
        '' <summary>
        '' EntSendMailCCAddressee 附本收件人ENT
        '' </summary>
        Public Class EntSendMailCCAddressee
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
                        Me.TableName = "EMLT070"
                        Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "ACCE_SEQ 附本序號"
        ''' <summary>
        ''' ACCE_SEQ 附本序號
        ''' </summary>
        Public Property ACCE_SEQ() As String
            Get
                Return Me.ColumnyMap("ACCE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACCE_SEQ") = value
            End Set
        End Property
#End Region

#Region "RECEIVER_ADDR 收信人地址"
                ''' <summary>
                ''' RECEIVER_ADDR 收信人地址
                ''' </summary>
                Public Property RECEIVER_ADDR() As String
                        Get
                                Return Me.ColumnyMap("RECEIVER_ADDR")
                        End Get
                        Set(ByVal value As String)
                                Me.ColumnyMap("RECEIVER_ADDR") = value
                        End Set
                End Property
#End Region

#Region "RECEIVER_NAME 收信人姓名"
                ''' <summary>
                ''' RECEIVER_NAME 收信人姓名
                ''' </summary>
                Public Property RECEIVER_NAME() As String
                        Get
                                Return Me.ColumnyMap("RECEIVER_NAME")
                        End Get
                        Set(ByVal value As String)
                                Me.ColumnyMap("RECEIVER_NAME") = value
                        End Set
                End Property
#End Region

#End Region

#Region "自訂方法"

#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' Charles 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
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


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===

                Dim sql As StringBuilder = New StringBuilder()
                sql.Append(" SELECT * FROM EMLT070 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

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

