'----------------------------------------------------------------------------------
'File Name		: EntMailRecvSet
'Author			: Brian Chou
'Description		: EntMailRecvSet 郵件收件者設定ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/17	Brian Chou		Source Create
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
	'' EntMailRecvSet 郵件收件者設定ENT
	'' </summary>
	Public Class EntMailRecvSet
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
			Me.TableName = "EMLT060"
			Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ARCVD_TYPE 接收類別"
		''' <summary>
		''' ARCVD_TYPE 接收類別
		''' </summary>
		Public Property ARCVD_TYPE() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NAME 接收類別名稱"
		''' <summary>
		''' ARCVD_TYPE_NAME 接收類別名稱
		''' </summary>
		Public Property ARCVD_TYPE_NAME() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE_NAME") = value
			End Set
		End Property
#End Region

#Region "ARCVD_TYPE_NO 接收類別編號"
		''' <summary>
		''' ARCVD_TYPE_NO 接收類別編號
		''' </summary>
		Public Property ARCVD_TYPE_NO() As String
			Get
				Return Me.ColumnyMap("ARCVD_TYPE_NO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ARCVD_TYPE_NO") = value
			End Set
		End Property
#End Region

#Region "MAIL_BATCH_NO 郵件批號"
		''' <summary>
		''' MAIL_BATCH_NO 郵件批號
		''' </summary>
		Public Property MAIL_BATCH_NO() As String
			Get
				Return Me.ColumnyMap("MAIL_BATCH_NO")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MAIL_BATCH_NO") = value
			End Set
		End Property
#End Region

#Region "RECEIVER_ID_TYPE 收件者身分類別"
		''' <summary>
		''' RECEIVER_ID_TYPE 收件者身分類別
		''' </summary>
		Public Property RECEIVER_ID_TYPE() As String
			Get
				Return Me.ColumnyMap("RECEIVER_ID_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("RECEIVER_ID_TYPE") = value
			End Set
		End Property
#End Region

#Region "SEND_APP_TYPE 寄送申請類別"
		''' <summary>
		''' SEND_APP_TYPE 寄送申請類別
		''' </summary>
		Public Property SEND_APP_TYPE() As String
			Get
				Return Me.ColumnyMap("SEND_APP_TYPE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SEND_APP_TYPE") = value
			End Set
		End Property
#End Region


#Region "EMAIL EMAIL"
		''' <summary>
		''' EMAIL EMAIL
		''' </summary>
		Public Property EMAIL() As String
			Get
				Return Me.ColumnyMap("EMAIL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("EMAIL") = value
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
                sql.Append(" SELECT * FROM EMLT060 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

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

