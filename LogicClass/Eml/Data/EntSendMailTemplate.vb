'----------------------------------------------------------------------------------
'File Name		: EntSendMailTemplate
'Author			: Brian Chou
'Description		: EntSendMailTemplate 郵件格式樣本ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/08/22	Brian Chou		Source Create
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
	'' EntSendMailTemplate 郵件格式樣本ENT
	'' </summary>
	Public Class EntSendMailTemplate
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
			Me.TableName = "EMLT040"
			Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "IS_BATCH_SEND 是否透過排程傳送"
		''' <summary>
		''' IS_BATCH_SEND 是否透過排程傳送
		''' </summary>
		Public Property IS_BATCH_SEND() As String
			Get
				Return Me.ColumnyMap("IS_BATCH_SEND")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_BATCH_SEND") = value
			End Set
		End Property
#End Region

#Region "IS_SEND 是否傳送"
		''' <summary>
		''' IS_SEND 是否傳送
		''' </summary>
		Public Property IS_SEND() As String
			Get
				Return Me.ColumnyMap("IS_SEND")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("IS_SEND") = value
			End Set
		End Property
#End Region

#Region "REPLY_ADDR 回信地址"
		''' <summary>
		''' REPLY_ADDR 回信地址
		''' </summary>
		Public Property REPLY_ADDR() As String
			Get
				Return Me.ColumnyMap("REPLY_ADDR")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("REPLY_ADDR") = value
			End Set
		End Property
#End Region

#Region "TMPLT_EXPL 樣本說明"
		''' <summary>
		''' TMPLT_EXPL 樣本說明
		''' </summary>
		Public Property TMPLT_EXPL() As String
			Get
				Return Me.ColumnyMap("TMPLT_EXPL")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_EXPL") = value
			End Set
		End Property
#End Region

#Region "TMPLT_MAIL_CONTENT 樣本信件內容"
		''' <summary>
		''' TMPLT_MAIL_CONTENT 樣本信件內容
		''' </summary>
		Public Property TMPLT_MAIL_CONTENT() As String
			Get
				Return Me.ColumnyMap("TMPLT_MAIL_CONTENT")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_MAIL_CONTENT") = value
			End Set
		End Property
#End Region

#Region "TMPLT_MAIL_SUBJ 樣本信件主旨"
		''' <summary>
		''' TMPLT_MAIL_SUBJ 樣本信件主旨
		''' </summary>
		Public Property TMPLT_MAIL_SUBJ() As String
			Get
				Return Me.ColumnyMap("TMPLT_MAIL_SUBJ")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_MAIL_SUBJ") = value
			End Set
		End Property
#End Region

#Region "TMPLT_NAME 樣本名稱"
		''' <summary>
		''' TMPLT_NAME 樣本名稱
		''' </summary>
		Public Property TMPLT_NAME() As String
			Get
				Return Me.ColumnyMap("TMPLT_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_NAME") = value
			End Set
		End Property
#End Region

#Region "TMPLT_SEQ 樣本序號"
		''' <summary>
		''' TMPLT_SEQ 樣本序號
		''' </summary>
		Public Property TMPLT_SEQ() As String
			Get
				Return Me.ColumnyMap("TMPLT_SEQ")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("TMPLT_SEQ") = value
			End Set
		End Property
#End Region

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

#Region "DUPLICATE_RECEIVER 固定副本"
        ''' <summary>
        ''' DUPLICATE_RECEIVER 固定副本
        ''' </summary>
        Public Property DUPLICATE_RECEIVER() As String
            Get
                Return Me.ColumnyMap("DUPLICATE_RECEIVER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DUPLICATE_RECEIVER") = value
            End Set
        End Property
#End Region

#Region "PARAM_CONTENT 可用參數"
        ''' <summary>
        ''' PARAM_CONTENT 可用參數
        ''' </summary>
        Public Property PARAM_CONTENT() As String
            Get
                Return Me.ColumnyMap("PARAM_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARAM_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_ACCE 包含附件"
        ''' <summary>
        ''' IS_ACCE 包含附件
        ''' </summary>
        Public Property IS_ACCE() As String
            Get
                Return Me.ColumnyMap("IS_ACCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_ACCE") = value
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
                sql.Append(" SELECT * FROM EMLT040 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region

#Region "Null 相關"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "TMPLT_NAME,TMPLT_EXPL,DUPLICATE_RECEIVER,TMPLT_MAIL_SUBJ,TMPLT_MAIL_CONTENT,PARAM_CONTENT,REPLY_ADDR"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "TMPLT_NAME,TMPLT_EXPL,DUPLICATE_RECEIVER,TMPLT_MAIL_SUBJ,TMPLT_MAIL_CONTENT,PARAM_CONTENT,REPLY_ADDR"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "TMPLT_NAME,TMPLT_EXPL,DUPLICATE_RECEIVER,TMPLT_MAIL_SUBJ,TMPLT_MAIL_CONTENT,PARAM_CONTENT,REPLY_ADDR"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region

	End Class
End Namespace

