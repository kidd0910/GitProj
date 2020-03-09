'ProductName                 : TSBA 
'File Name					 : CtAPPL022 
'Description	             : CtAPPL022 CtAPPL022 收文主檔
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2018/02/02  系統管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL022
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL022 = New ENT_APPL022(Me.DBManager, Me.LogUtil)
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

#Region "RCV_NO 收文號"
        '' <summary>
        '' RCV_NO 收文號
        '' </summary>
        Public Property RCV_NO() As String
            Get
                Return Me.PropertyMap("RCV_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_NO") = value
            End Set
        End Property
#End Region

#Region "DEADLINE 限辦日期"
        '' <summary>
        '' DEADLINE 限辦日期
        '' </summary>
        Public Property DEADLINE() As String
            Get
                Return Me.PropertyMap("DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE") = value
            End Set
        End Property
#End Region

#Region "DEPID 承辦單位代碼"
        '' <summary>
        '' DEPID 承辦單位代碼
        '' </summary>
        Public Property DEPID() As String
            Get
                Return Me.PropertyMap("DEPID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEPID") = value
            End Set
        End Property
#End Region

#Region "RCV_DATE 收文日期"
        '' <summary>
        '' RCV_DATE 收文日期
        '' </summary>
        Public Property RCV_DATE() As String
            Get
                Return Me.PropertyMap("RCV_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_DATE") = value
            End Set
        End Property
#End Region

#Region "RCV_TMEME 主旨"
        '' <summary>
        '' RCV_TMEME 主旨
        '' </summary>
        Public Property RCV_TMEME() As String
            Get
                Return Me.PropertyMap("RCV_TMEME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RCV_TMEME") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ 補正次數"
        '' <summary>
        '' CASE_SEQ 補正次數
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.PropertyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL022"
        ' <summary>Ent_APPL022</ summary>
        Private Property Ent_APPL022() As ENT_APPL022
            Get
                Return Me.PropertyMap("Ent_APPL022")
            End Get
            Set(ByVal value As ENT_APPL022)
                Me.PropertyMap("Ent_APPL022") = value
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
                Me.Ent_APPL022.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL022.RCV_NO = Me.RCV_NO        '收文號
                Me.Ent_APPL022.DEADLINE = Me.DEADLINE        '限辦日期
                Me.Ent_APPL022.DEPID = Me.DEPID      '承辦單位代碼
                Me.Ent_APPL022.RCV_DATE = Me.RCV_DATE        '收文日期
                Me.Ent_APPL022.RCV_TMEME = Me.RCV_TMEME      '主旨
                Me.Ent_APPL022.CASE_SEQ = Me.CASE_SEQ        '補正次數


                '=== 設定處理新增動作 ===
                Me.Ent_APPL022.SetUserId("SYSTEM")
                Dim result As String = Me.Ent_APPL022.Insert()

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
                Me.Ent_APPL022.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APPL022.RCV_NO = Me.RCV_NO        '收文號
                Me.Ent_APPL022.DEADLINE = Me.DEADLINE        '限辦日期
                Me.Ent_APPL022.DEPID = Me.DEPID      '承辦單位代碼
                Me.Ent_APPL022.RCV_DATE = Me.RCV_DATE        '收文日期
                Me.Ent_APPL022.RCV_TMEME = Me.RCV_TMEME      '主旨
                Me.Ent_APPL022.CASE_SEQ = Me.CASE_SEQ        '補正次數


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL022.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL022.Update()

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
                Me.Ent_APPL022.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL022.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL022.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "RCV_NO", Me.RCV_NO)        '收文號
                Me.ProcessQueryCondition(condition, "=", "DEADLINE", Me.DEADLINE)        '限辦日期
                Me.ProcessQueryCondition(condition, "=", "DEPID", Me.DEPID)      '承辦單位代碼
                Me.ProcessQueryCondition(condition, "=", "RCV_DATE", Me.RCV_DATE)        '收文日期
                Me.ProcessQueryCondition(condition, "=", "RCV_TMEME", Me.RCV_TMEME)      '主旨
                Me.ProcessQueryCondition(condition, "=", "CASE_SEQ", Me.CASE_SEQ)        '補正次數

                Me.Ent_APPL022.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL022.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL022.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL022.Query()
                Else
                    result = Me.Ent_APPL022.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL022.TotalRowCount
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

