'----------------------------------------------------------------------------------
'File Name		: APP1070
'Author			: TIM
'Description		: APP1070 課程規畫
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/28	TIM		Source Create
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
    ' APP1070 課程規畫
    ' </summary>
    Public Class ENT_APP1070
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
            Me.TableName = "APP1070"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,COURSE_CATEGORY,COURSE_NAME,BOOK_LEC_NAME,INT_EXT_LECTURER,FUNDING,COURSE_CONTENT,ORGANIZER"
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

#Region "COURSE_CATEGORY 課程類別"
        '' <summary>
        '' COURSE_CATEGORY 課程類別
        '' </summary>
        Public Property COURSE_CATEGORY() As String
            Get
                Return Me.ColumnyMap("COURSE_CATEGORY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COURSE_CATEGORY") = value
            End Set
        End Property
#End Region

#Region "COURSE_NAME 課程名稱"
        '' <summary>
        '' COURSE_NAME 課程名稱
        '' </summary>
        Public Property COURSE_NAME() As String
            Get
                Return Me.ColumnyMap("COURSE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COURSE_NAME") = value
            End Set
        End Property
#End Region

#Region "BOOK_LEC_NAME 預定講師姓名"
        '' <summary>
        '' BOOK_LEC_NAME 預定講師姓名
        '' </summary>
        Public Property BOOK_LEC_NAME() As String
            Get
                Return Me.ColumnyMap("BOOK_LEC_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BOOK_LEC_NAME") = value
            End Set
        End Property
#End Region

#Region "INT_EXT_LECTURER 內外部講師, REF. SYS_KEY='TEACHER_TYPE"
        '' <summary>
        '' INT_EXT_LECTURER 內外部講師, REF. SYS_KEY='TEACHER_TYPE
        '' </summary>
        Public Property INT_EXT_LECTURER() As String
            Get
                Return Me.ColumnyMap("INT_EXT_LECTURER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INT_EXT_LECTURER") = value
            End Set
        End Property
#End Region

#Region "HOUR_NUM 時數"
        '' <summary>
        '' HOUR_NUM 時數
        '' </summary>
        Public Property HOUR_NUM() As String
            Get
                Return Me.ColumnyMap("HOUR_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HOUR_NUM") = value
            End Set
        End Property
#End Region

#Region "FUNDING 經費"
        '' <summary>
        '' FUNDING 經費
        '' </summary>
        Public Property FUNDING() As String
            Get
                Return Me.ColumnyMap("FUNDING")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUNDING") = value
            End Set
        End Property
#End Region

#Region "TRAINING_DATE 時間, 廣播用"
        '' <summary>
        '' TRAINING_DATE 時間, 廣播用
        '' </summary>
        Public Property TRAINING_DATE() As String
            Get
                Return Me.ColumnyMap("TRAINING_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TRAINING_DATE") = value
            End Set
        End Property
#End Region

#Region "COURSE_CONTENT 課程內容, 廣播用"
        '' <summary>
        '' COURSE_CONTENT 課程內容, 廣播用
        '' </summary>
        Public Property COURSE_CONTENT() As String
            Get
                Return Me.ColumnyMap("COURSE_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COURSE_CONTENT") = value
            End Set
        End Property
#End Region

#Region "TRAINING_NUMBER 參訓人數, 廣播用"
        '' <summary>
        '' TRAINING_NUMBER 參訓人數, 廣播用
        '' </summary>
        Public Property TRAINING_NUMBER() As String
            Get
                Return Me.ColumnyMap("TRAINING_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TRAINING_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ORGANIZER 主辦單位, 廣播用"
        '' <summary>
        '' ORGANIZER 主辦單位, 廣播用
        '' </summary>
        Public Property ORGANIZER() As String
            Get
                Return Me.ColumnyMap("ORGANIZER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORGANIZER") = value
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
                'Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT *, CASE INT_EXT_LECTURER   WHEN '1' THEN '內' 	  WHEN '2' THEN '外'  END AS INT_EXT_LECTURER_TXT  ")
                sql.AppendLine(" FROM APP1070 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString.Replace("$.", ""), pageNo, pageSize)

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

