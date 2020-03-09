'----------------------------------------------------------------------------------
'File Name		: EntQuestionaryAnswerAmount
'Author			:  
'Description		: EntQuestionaryAnswerAmount 問卷答案結果ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1     2016/11/11       Source Create COPY FROM
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Que.Data
    '' <summary>
    '' EntQuestionaryAnswerAmount 問卷答案結果ENT
    '' </summary>
    Public Class EntQuestionaryAnswerAmount
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
            Me.TableName = "QUET070"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "QSTNNR_NO 問卷號碼"
        ''' <summary>
        ''' QSTNNR_NO 問卷號碼
        ''' </summary>
        Public Property QSTNNR_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_NO") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_NO 題目號碼"
        ''' <summary>
        ''' SUBJECT_NO 題目號碼
        ''' </summary>
        Public Property SUBJECT_NO() As String
            Get
                Return Me.ColumnyMap("SUBJECT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_NO") = value
            End Set
        End Property
#End Region

#Region "MENU_NO 選單號碼"
        ''' <summary>
        ''' MENU_NO 選單號碼
        ''' </summary>
        Public Property MENU_NO() As String
            Get
                Return Me.ColumnyMap("MENU_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_NO") = value
            End Set
        End Property
#End Region

#Region "STAFF_NO 員工編號"
        ''' <summary>
        ''' STAFF_NO 員工編號
        ''' </summary>
        Public Property STAFF_NO() As String
            Get
                Return Me.ColumnyMap("STAFF_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STAFF_NO") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_TARGET_NO 問卷對象號碼"
        ''' <summary>
        ''' QSTNNR_TARGET_NO 問卷對象號碼
        ''' </summary>
        Public Property QSTNNR_TARGET_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_TARGET_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_TARGET_NO") = value
            End Set
        End Property
#End Region

#Region "TEXT_CONTENT 文字內容"
        ''' <summary>
        ''' TEXT_CONTENT 文字內容
        ''' </summary>
        Public Property TEXT_CONTENT() As String
            Get
                Return Me.ColumnyMap("TEXT_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TEXT_CONTENT") = value
            End Set
        End Property
#End Region

#Region "STATUS 狀態"
        ''' <summary>
        ''' STATUS 狀態
        ''' </summary>
        Public Property STATUS() As String
            Get
                Return Me.ColumnyMap("STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STATUS") = value
            End Set
        End Property
#End Region

#Region "ID_TYPE 身分類別"
        ''' <summary>
        ''' ID_TYPE 身分類別
        ''' </summary>
        Public Property ID_TYPE() As String
            Get
                Return Me.ColumnyMap("ID_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ID_TYPE") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號"
        ''' <summary>
        ''' CASE_NO 案件編號
        ''' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace


