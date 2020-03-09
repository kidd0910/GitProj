'ProductName                 : TSBA 
'File Name					 : CtAPP2020 
'Description	             : CtAPP2020 諮詢委員會議成員
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/22  San      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP2020
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP2020 = New Ent_APP2020(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE
        '' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.PropertyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "ID_FG 暫不用"
        '' <summary>
        '' ID_FG 暫不用
        '' </summary>
        Public Property ID_FG() As String
            Get
                Return Me.PropertyMap("ID_FG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ID_FG") = value
            End Set
        End Property
#End Region

#Region "ACNT 帳號, REF.POST020.ACNT"
        '' <summary>
        '' ACNT 帳號, REF.POST020.ACNT
        '' </summary>
        Public Property ACNT() As String
            Get
                Return Me.PropertyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "Ent_APP2020"
        ' <summary>Ent_APP2020</ summary>
        Private Property Ent_APP2020() As Ent_APP2020
            Get
                Return Me.PropertyMap("Ent_APP2020")
            End Get
            Set(ByVal value As Ent_APP2020)
                Me.PropertyMap("Ent_APP2020") = value
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
                Me.Ent_APP2020.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.Ent_APP2020.ID_FG = Me.ID_FG        '暫不用
                Me.Ent_APP2020.ACNT = Me.ACNT         '帳號, REF.POST020.ACNT


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP2020.Insert()

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
                Me.Ent_APP2020.GROUP_CODE = Me.GROUP_CODE       '諮詢委員會議代碼, REF.APP2010.GROUP_CODE
                Me.Ent_APP2020.ID_FG = Me.ID_FG        '暫不用
                Me.Ent_APP2020.ACNT = Me.ACNT         '帳號, REF.POST020.ACNT


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP2020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP2020.Update()

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
                'If String.IsNullOrEmpty(Me.PKNO) Then
                '    faileArguments.Add("PKNO")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)
                Me.Ent_APP2020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 刪除資料 ===
                If Me.Ent_APP2020.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP2020.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "GROUP_CODE", Me.GROUP_CODE)        '諮詢委員會議代碼, REF.APP2010.GROUP_CODE               
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)        '帳號, REF.POST020.ACNT

                Me.Ent_APP2020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP2020.OrderBys = "PKNO"
                Else
                    Me.Ent_APP2020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP2020.Query()
                Else
                    result = Me.Ent_APP2020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP2020.TotalRowCount
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

