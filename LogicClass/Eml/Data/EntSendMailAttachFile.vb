﻿'----------------------------------------------------------------------------------
'File Name		: EntSendMailAttachFile
'Author			: Brian Chou
'Description		: EntSendMailAttachFile 附件ENT
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
	'' EntSendMailAttachFile 附件ENT
	'' </summary>
	Public Class EntSendMailAttachFile
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
			Me.TableName = "EMLT020"
			Me.SysName = "EML"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACCE_FILE_NAME 附件檔案名稱"
		''' <summary>
		''' ACCE_FILE_NAME 附件檔案名稱
		''' </summary>
		Public Property ACCE_FILE_NAME() As String
			Get
				Return Me.ColumnyMap("ACCE_FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("ACCE_FILE_NAME") = value
			End Set
		End Property
#End Region

#Region "SEND_SEQ 傳送序號"
		''' <summary>
		''' SEND_SEQ 傳送序號
		''' </summary>
		Public Property SEND_SEQ() As String
			Get
				Return Me.ColumnyMap("SEND_SEQ")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SEND_SEQ") = value
			End Set
		End Property
#End Region

#Region "SYS_FILE_NAME 系統檔案名稱"
		''' <summary>
		''' SYS_FILE_NAME 系統檔案名稱
		''' </summary>
		Public Property SYS_FILE_NAME() As String
			Get
				Return Me.ColumnyMap("SYS_FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("SYS_FILE_NAME") = value
			End Set
		End Property
#End Region

#Region "MAIL_RESERVE_DAYS 郵件保留天數"
        ''' <summary>
        ''' MAIL_RESERVE_DAYS 郵件保留天數
        ''' </summary>
        Public Property MAIL_RESERVE_DAYS() As String
            Get
                Return Me.ColumnyMap("MAIL_RESERVE_DAYS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAIL_RESERVE_DAYS") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "BatchDeleteSendMailAttachFile 批次刪除附件 "
         
        ''' <summary>
        ''' 批次刪除附件 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub BatchDeleteSendMailAttachFile()
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
                '  Me.ParserAlias()

                '=== 處理說明 ===
                '步驟一、取得須刪除郵件之傳送序號
                '使用table:EMLT010
                '取得：傳送序號
                '條件：EMLT010.建立日期 < (SYS_DATE(系統日期)-MAIL_RESERVE_DAYS(郵件保留天數))
                '將取得之資料傳送序號放入DTA
                '
                '步驟二、刪除資料
                'delete table：EMLT020
                '條件：EMLT020.SEND_SEQ(傳送序號) in DTA.SEND_SEQ(傳送序號)

                Dim conn As DbConnection = Me.DBManager.GetIConnection("NTOU")
                Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                Dim sql As String = String.Format("DELETE FROM EMLT020 where SEND_SEQ in (select SEND_SEQ from EMLT010 where create_time < SYSDATE-{0})", IIf(String.IsNullOrEmpty(Me.MAIL_RESERVE_DAYS), "0", Me.MAIL_RESERVE_DAYS))
                dba.Execute(sql)



                Me.ResetColumnProperty() 
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

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
                sql.Append(" SELECT * FROM EMLT020 with (nolock) WHERE 1=1 " & Me.SqlRetrictions.Replace("$.", "") & " ORDER BY PKNO ")

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

