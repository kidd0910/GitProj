'----------------------------------------------------------------------------------
'File Name		: EntQuestionaryItem
'Author			:  
'Description		: EntQuestionaryItem 問卷單選項ENT
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
    '' EntQuestionaryItem 問卷單選項ENT
    '' </summary>
    Public Class EntQuestionaryItem
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
            Me.TableName = "QUET050"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "JUMP_CONTENT 跳題內容"
        ''' <summary>
        ''' JUMP_CONTENT 跳題內容
        ''' </summary>
        Public Property JUMP_CONTENT() As String
            Get
                Return Me.ColumnyMap("JUMP_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_CONTENT") = value
            End Set
        End Property
#End Region

#Region "JUMP_NO 跳題號碼"
        ''' <summary>
        ''' JUMP_NO 跳題號碼
        ''' </summary>
        Public Property JUMP_NO() As String
            Get
                Return Me.ColumnyMap("JUMP_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_NO") = value
            End Set
        End Property
#End Region

#Region "MENU_CONTENT 選單內容"
        ''' <summary>
        ''' MENU_CONTENT 選單內容
        ''' </summary>
        Public Property MENU_CONTENT() As String
            Get
                Return Me.ColumnyMap("MENU_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_CONTENT") = value
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

#Region "MENU_STYLE 選單樣式"
        ''' <summary>
        ''' MENU_STYLE 選單樣式
        ''' </summary>
        Public Property MENU_STYLE() As String
            Get
                Return Me.ColumnyMap("MENU_STYLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_STYLE") = value
            End Set
        End Property
#End Region

#Region "MENU_TITLE 選單標號"
        ''' <summary>
        ''' MENU_TITLE 選單標號
        ''' </summary>
        Public Property MENU_TITLE() As String
            Get
                Return Me.ColumnyMap("MENU_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_TITLE") = value
            End Set
        End Property
#End Region

#Region "MENU_TROVMGP 選單權數"
        ''' <summary>
        ''' MENU_TROVMGP 選單權數
        ''' </summary>
        Public Property MENU_TROVMGP() As String
            Get
                Return Me.ColumnyMap("MENU_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_TROVMGP") = value
            End Set
        End Property
#End Region

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

#Region "MENU_RMK 選單備註"
		''' <summary>
		''' MENU_RMK 選單備註
		''' </summary>
		Public Property MENU_RMK() As String
			Get
				Return Me.ColumnyMap("MENU_RMK")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("MENU_RMK") = value
			End Set
		End Property
#End Region
#End Region

#Region "自訂方法"

#Region "QueryItemMaxNo 查詢最大選單號碼 "
        ''' <summary>
        ''' 查詢最大選單號碼 
        ''' </summary>
        Public Function QueryItemMaxNo() As DataTable
            Return Me.QueryItemMaxNo(0, 0)
        End Function

        ''' <summary>
        ''' 查詢最大選單號碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryItemMaxNo(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    faileArguments.Add("SqlRetrictions")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                '抓取選項最大號碼+1

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

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


