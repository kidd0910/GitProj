'----------------------------------------------------------------------------------
'File Name		: EntQuestionaryObj
'Author			:  
'Description		: EntQuestionaryObj 問卷對象ENT
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
    '' EntQuestionaryObj 問卷對象ENT
    '' </summary>
    Public Class EntQuestionaryObj
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
            Me.TableName = "QUET020"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntQuestionary = New EntQuestionary(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "DEP_NAME 單位名稱"
        ''' <summary>
        ''' DEP_NAME 單位名稱
        ''' </summary>
        Public Property DEP_NAME() As String
            Get
                Return Me.ColumnyMap("DEP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEP_NAME") = value
            End Set
        End Property
#End Region

#Region "EntQuestionary 問卷ENT"
        ''' <summary>
        ''' EntQuestionary 問卷ENT
        ''' </summary>
        Public Property EntQuestionary() As EntQuestionary
            Get
                Return Me.PropertyMap("EntQuestionary")
            End Get
            Set(ByVal value As EntQuestionary)
                Me.PropertyMap("EntQuestionary") = value
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

#Region "NAME 姓名"
        ''' <summary>
        ''' NAME 姓名
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.ColumnyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NAME") = value
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

#Region "UNIT_NO 單位號碼"
        ''' <summary>
        ''' UNIT_NO 單位號碼
        ''' </summary>
        Public Property UNIT_NO() As String
            Get
                Return Me.ColumnyMap("UNIT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNIT_NO") = value
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

#End Region

#Region "自訂方法"

#Region "QueryQuestionaryObjSQL 查詢問卷對象結構 "
        ''' <summary>
        ''' 查詢問卷對象結構 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryObjSQL() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理說明 ===
                'STATUS(狀態)=1,回傳校內
                'STATUS(狀態)=2,回傳校外
                '回傳這2個TABLE的SQL 字串
                'SELECT ENRT010.NAME(姓名),ENRT010.STNO(學號),ENRT010.INNER_EMAIL(校內電子信箱),ENRT010.OUTER_EMAIL(校外電子信箱)
                'FROM QUET020 LEFT OUTER JOIN ENRT010 ON QUET020.QSTNNR_TARGET_NO(問卷對象號碼)=ENRT010.STNO(學號)
                '
                'WHERE QUET020.QSTNNR_NO(問卷號碼)=QSTNNR_NO(問卷號碼)

                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.QSTNNR_TARGET_NO,")
                sql.Append("CASE WHEN R1.STNO IS NULL THEN R2.CH_NAME ELSE R1.CH_NAME END AS CH_NAME,")

                Select Case Me.STATUS
                    Case "1" '校內
                        sql.Append("CASE WHEN R1.STNO IS NULL THEN R2.EMAIL ELSE R1.INNER_EMAIL END AS EMAIL ")

                    Case "2" '校外
                        sql.Append("CASE WHEN R1.STNO IS NULL THEN R2.EMAIL1 ELSE CAST(R1.OUTER_EMAIL AS NVARCHAR2 (255)) END AS EMAIL ")

                End Select

                sql.Append("FROM QUET020 M ")
                sql.Append("LEFT JOIN ENRT010 R1 ON M.QSTNNR_TARGET_NO = R1.STNO ")
                sql.Append("LEFT JOIN POST020 R2 ON M.QSTNNR_TARGET_NO=R2.ACNT ")
                sql.Append("WHERE 1=1 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(Me.SqlRetrictions.Replace("$.", "M."))
                End If

                Me.ResetColumnProperty()

                Return sql.ToString
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace

