'ProductName                 : TSBA 
'File Name					 : CtAPP1070 
'Description	             : CtAPP1070 課程規畫
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/28  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1070
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1070 = New Ent_APP1070(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "COURSE_CATEGORY 課程類別"
        '' <summary>
        '' COURSE_CATEGORY 課程類別
        '' </summary>
        Public Property COURSE_CATEGORY() As String
            Get
                Return Me.PropertyMap("COURSE_CATEGORY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COURSE_CATEGORY") = value
            End Set
        End Property
#End Region

#Region "COURSE_NAME 課程名稱"
        '' <summary>
        '' COURSE_NAME 課程名稱
        '' </summary>
        Public Property COURSE_NAME() As String
            Get
                Return Me.PropertyMap("COURSE_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COURSE_NAME") = value
            End Set
        End Property
#End Region

#Region "BOOK_LEC_NAME 預定講師姓名"
        '' <summary>
        '' BOOK_LEC_NAME 預定講師姓名
        '' </summary>
        Public Property BOOK_LEC_NAME() As String
            Get
                Return Me.PropertyMap("BOOK_LEC_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BOOK_LEC_NAME") = value
            End Set
        End Property
#End Region

#Region "INT_EXT_LECTURER 內外部講師, REF. SYS_KEY='TEACHER_TYPE"
        '' <summary>
        '' INT_EXT_LECTURER 內外部講師, REF. SYS_KEY='TEACHER_TYPE
        '' </summary>
        Public Property INT_EXT_LECTURER() As String
            Get
                Return Me.PropertyMap("INT_EXT_LECTURER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INT_EXT_LECTURER") = value
            End Set
        End Property
#End Region

#Region "HOUR_NUM 時數"
        '' <summary>
        '' HOUR_NUM 時數
        '' </summary>
        Public Property HOUR_NUM() As String
            Get
                Return Me.PropertyMap("HOUR_NUM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HOUR_NUM") = value
            End Set
        End Property
#End Region

#Region "FUNDING 經費"
        '' <summary>
        '' FUNDING 經費
        '' </summary>
        Public Property FUNDING() As String
            Get
                Return Me.PropertyMap("FUNDING")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FUNDING") = value
            End Set
        End Property
#End Region

#Region "TRAINING_DATE 時間, 廣播用"
        '' <summary>
        '' TRAINING_DATE 時間, 廣播用
        '' </summary>
        Public Property TRAINING_DATE() As String
            Get
                Return Me.PropertyMap("TRAINING_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRAINING_DATE") = value
            End Set
        End Property
#End Region

#Region "COURSE_CONTENT 課程內容, 廣播用"
        '' <summary>
        '' COURSE_CONTENT 課程內容, 廣播用
        '' </summary>
        Public Property COURSE_CONTENT() As String
            Get
                Return Me.PropertyMap("COURSE_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COURSE_CONTENT") = value
            End Set
        End Property
#End Region

#Region "TRAINING_NUMBER 參訓人數, 廣播用"
        '' <summary>
        '' TRAINING_NUMBER 參訓人數, 廣播用
        '' </summary>
        Public Property TRAINING_NUMBER() As String
            Get
                Return Me.PropertyMap("TRAINING_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRAINING_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ORGANIZER 主辦單位, 廣播用"
        '' <summary>
        '' ORGANIZER 主辦單位, 廣播用
        '' </summary>
        Public Property ORGANIZER() As String
            Get
                Return Me.PropertyMap("ORGANIZER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORGANIZER") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1070"
        ' <summary>Ent_APP1070</ summary>
        Private Property Ent_APP1070() As ENT_APP1070
            Get
                Return Me.PropertyMap("Ent_APP1070")
            End Get
            Set(ByVal value As ENT_APP1070)
                Me.PropertyMap("Ent_APP1070") = value
            End Set
        End Property
#End Region


#End Region

#Region "方法"
#Region "DoAdd 處理新增資料動作"
        '' <summary>
        '' 處理新增資料動作
        '' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 設定屬性參數 ===
                Me.Ent_APP1070.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1070.COURSE_CATEGORY = Me.COURSE_CATEGORY      '課程類別
                Me.Ent_APP1070.COURSE_NAME = Me.COURSE_NAME      '課程名稱
                Me.Ent_APP1070.BOOK_LEC_NAME = Me.BOOK_LEC_NAME      '預定講師姓名
                Me.Ent_APP1070.INT_EXT_LECTURER = Me.INT_EXT_LECTURER        '內外部講師, REF. SYS_KEY='TEACHER_TYPE
                Me.Ent_APP1070.HOUR_NUM = Me.HOUR_NUM        '時數
                Me.Ent_APP1070.FUNDING = Me.FUNDING      '經費
                Me.Ent_APP1070.TRAINING_DATE = Me.TRAINING_DATE      '時間, 廣播用
                Me.Ent_APP1070.COURSE_CONTENT = Me.COURSE_CONTENT        '課程內容, 廣播用
                Me.Ent_APP1070.TRAINING_NUMBER = Me.TRAINING_NUMBER      '參訓人數, 廣播用
                Me.Ent_APP1070.ORGANIZER = Me.ORGANIZER      '主辦單位, 廣播用


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1070.Insert()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoModify 處理修改資料動作"
        '' <summary>
        '' 處理修改資料動作
        '' </summary>
        Public Function DoModify() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Me.Ent_APP1070.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1070.COURSE_CATEGORY = Me.COURSE_CATEGORY      '課程類別
                Me.Ent_APP1070.COURSE_NAME = Me.COURSE_NAME      '課程名稱
                Me.Ent_APP1070.BOOK_LEC_NAME = Me.BOOK_LEC_NAME      '預定講師姓名
                Me.Ent_APP1070.INT_EXT_LECTURER = Me.INT_EXT_LECTURER        '內外部講師, REF. SYS_KEY='TEACHER_TYPE
                Me.Ent_APP1070.HOUR_NUM = Me.HOUR_NUM        '時數
                Me.Ent_APP1070.FUNDING = Me.FUNDING      '經費
                Me.Ent_APP1070.TRAINING_DATE = Me.TRAINING_DATE      '時間, 廣播用
                Me.Ent_APP1070.COURSE_CONTENT = Me.COURSE_CONTENT        '課程內容, 廣播用
                Me.Ent_APP1070.TRAINING_NUMBER = Me.TRAINING_NUMBER      '參訓人數, 廣播用
                Me.Ent_APP1070.ORGANIZER = Me.ORGANIZER      '主辦單位, 廣播用



                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1070.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1070.Update()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoDelete 處理刪除資料動作"
        '' <summary>
        '' 處理刪除資料動作
        '' </summary>
        Public Sub DoDelete()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.Ent_APP1070.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1070.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1070.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub

        '' <summary>
        '' 處理刪除資料動作 by CASE_NO
        '' </summary>
        Public Sub DoDeleteByCaseNo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.Ent_APP1070.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1070.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1070.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "COURSE_CATEGORY", Me.COURSE_CATEGORY)      '課程類別
                Me.ProcessQueryCondition(condition, "%LIKE%", "COURSE_NAME", Me.COURSE_NAME)         '課程名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "BOOK_LEC_NAME", Me.BOOK_LEC_NAME)         '預定講師姓名
                Me.ProcessQueryCondition(condition, "=", "INT_EXT_LECTURER", Me.INT_EXT_LECTURER)        '內外部講師, REF. SYS_KEY='TEACHER_TYPE
                Me.ProcessQueryCondition(condition, "=", "HOUR_NUM", Me.HOUR_NUM)        '時數
                Me.ProcessQueryCondition(condition, "=", "FUNDING", Me.FUNDING)      '經費
                Me.ProcessQueryCondition(condition, "=", "TRAINING_DATE", Me.TRAINING_DATE)      '時間, 廣播用
                Me.ProcessQueryCondition(condition, "%LIKE%", "COURSE_CONTENT", Me.COURSE_CONTENT)       '課程內容, 廣播用
                Me.ProcessQueryCondition(condition, "=", "TRAINING_NUMBER", Me.TRAINING_NUMBER)      '參訓人數, 廣播用
                Me.ProcessQueryCondition(condition, "=", "ORGANIZER", Me.ORGANIZER)      '主辦單位, 廣播用

                Me.Ent_APP1070.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1070.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1070.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1070.Query()
                Else
                    result = Me.Ent_APP1070.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1070.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
    End Class
End Namespace

