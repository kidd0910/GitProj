'ProductName                 : TSBA 
'File Name					 : CtAPP1050 
'Description	             : CtAPP1050 申設_品管/客服人員資料
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/27  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1050
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1050 = New ENT_APP1050(Me.DBManager, Me.LogUtil)
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

#Region "CODE_TYPE 類別(1.品管,2.客服)"
        '' <summary>
        '' CODE_TYPE 類別(1.品管,2.客服)
        '' </summary>
        Public Property CODE_TYPE() As String
            Get
                Return Me.PropertyMap("CODE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CODE_TYPE") = value
            End Set
        End Property
#End Region

#Region "PTTCH_FT 專兼職(1.專職，2.兼職)"
        '' <summary>
        '' PTTCH_FT 專兼職(1.專職，2.兼職)
        '' </summary>
        Public Property PTTCH_FT() As String
            Get
                Return Me.PropertyMap("PTTCH_FT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PTTCH_FT") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 姓名"
        '' <summary>
        '' CH_NAME 姓名
        '' </summary>
        Public Property CH_NAME() As String
            Get
                Return Me.PropertyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "JOBTITLE 職稱"
        '' <summary>
        '' JOBTITLE 職稱
        '' </summary>
        Public Property JOBTITLE() As String
            Get
                Return Me.PropertyMap("JOBTITLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOBTITLE") = value
            End Set
        End Property
#End Region

#Region "IS_CAREER_SHAR 是否與其他事業共用(Y.是，N.否)"
        '' <summary>
        '' IS_CAREER_SHAR 是否與其他事業共用(Y.是，N.否)
        '' </summary>
        Public Property IS_CAREER_SHAR() As String
            Get
                Return Me.PropertyMap("IS_CAREER_SHAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_CAREER_SHAR") = value
            End Set
        End Property
#End Region

#Region "CAREER_SHAR_NAME 事業共用名稱"
        '' <summary>
        '' CAREER_SHAR_NAME 事業共用名稱
        '' </summary>
        Public Property CAREER_SHAR_NAME() As String
            Get
                Return Me.PropertyMap("CAREER_SHAR_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CAREER_SHAR_NAME") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1050"
        ' <summary>Ent_APP1050</ summary>
        Private Property Ent_APP1050() As ENT_APP1050
            Get
                Return Me.PropertyMap("Ent_APP1050")
            End Get
            Set(ByVal value As ENT_APP1050)
                Me.PropertyMap("Ent_APP1050") = value
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
                Me.Ent_APP1050.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1050.CODE_TYPE = Me.CODE_TYPE      '類別(1.品管,2.客服)
                Me.Ent_APP1050.PTTCH_FT = Me.PTTCH_FT        '專兼職(1.專職，2.兼職)
                Me.Ent_APP1050.CH_NAME = Me.CH_NAME      '姓名
                Me.Ent_APP1050.JOBTITLE = Me.JOBTITLE        '職稱
                Me.Ent_APP1050.IS_CAREER_SHAR = Me.IS_CAREER_SHAR        '是否與其他事業共用(Y.是，N.否)
                Me.Ent_APP1050.CAREER_SHAR_NAME = Me.CAREER_SHAR_NAME        '事業共用名稱


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1050.Insert()

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
                Me.Ent_APP1050.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1050.CODE_TYPE = Me.CODE_TYPE      '類別(1.品管,2.客服)
                Me.Ent_APP1050.PTTCH_FT = Me.PTTCH_FT        '專兼職(1.專職，2.兼職)
                Me.Ent_APP1050.CH_NAME = Me.CH_NAME      '姓名
                Me.Ent_APP1050.JOBTITLE = Me.JOBTITLE        '職稱
                Me.Ent_APP1050.IS_CAREER_SHAR = Me.IS_CAREER_SHAR        '是否與其他事業共用(Y.是，N.否)
                Me.Ent_APP1050.CAREER_SHAR_NAME = Me.CAREER_SHAR_NAME        '事業共用名稱


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1050.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1050.Update()

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
                Me.Ent_APP1050.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1050.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1050.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CODE_TYPE", Me.CODE_TYPE)      '類別(1.品管,2.客服)
                Me.ProcessQueryCondition(condition, "=", "PTTCH_FT", Me.PTTCH_FT)        '專兼職(1.專職，2.兼職)
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_NAME", Me.CH_NAME)         '姓名
                Me.ProcessQueryCondition(condition, "=", "JOBTITLE", Me.JOBTITLE)        '職稱
                Me.ProcessQueryCondition(condition, "=", "IS_CAREER_SHAR", Me.IS_CAREER_SHAR)        '是否與其他事業共用(Y.是，N.否)
                Me.ProcessQueryCondition(condition, "%LIKE%", "CAREER_SHAR_NAME", Me.CAREER_SHAR_NAME)       '事業共用名稱

                Me.Ent_APP1050.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1050.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1050.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1050.Query()
                Else
                    result = Me.Ent_APP1050.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1050.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoWordQuery 進行Word查詢動作"
        '' <summary>
        '' 進行Word查詢動作
        '' </summary>
        Public Function DoWordQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                '事業共用名稱

                Me.Ent_APP1050.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1050.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1050.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1050.Query()
                Else
                    result = Me.Ent_APP1050.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1050.TotalRowCount
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

