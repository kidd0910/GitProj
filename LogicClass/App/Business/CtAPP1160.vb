'ProductName                 : TSBA 
'File Name					 : CtAPP1160 
'Description	             : CtAPP1160 員額編制
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/11  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1160
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1160 = New ENT_APP1160(Me.DBManager, Me.LogUtil)
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

#Region "TBL_RECID 紀錄編號, 系統自動編號"
        '' <summary>
        '' TBL_RECID 紀錄編號, 系統自動編號
        '' </summary>
        Public Property TBL_RECID() As String
            Get
                Return Me.PropertyMap("TBL_RECID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TBL_RECID") = value
            End Set
        End Property
#End Region

#Region "MEMBER_NAME 委員姓名"
        '' <summary>
        '' MEMBER_NAME 委員姓名
        '' </summary>
        Public Property MEMBER_NAME() As String
            Get
                Return Me.PropertyMap("MEMBER_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MEMBER_NAME") = value
            End Set
        End Property
#End Region

#Region "SEX_TYPE 性別, REF. SYST010.SYS_KEY='SEX_TYPE'"
        '' <summary>
        '' SEX_TYPE 性別, REF. SYST010.SYS_KEY='SEX_TYPE'
        '' </summary>
        Public Property SEX_TYPE() As String
            Get
                Return Me.PropertyMap("SEX_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SEX_TYPE") = value
            End Set
        End Property
#End Region

#Region "TEACHER_TYPE 內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'"
        '' <summary>
        '' TEACHER_TYPE 內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'
        '' </summary>
        Public Property TEACHER_TYPE() As String
            Get
                Return Me.PropertyMap("TEACHER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TEACHER_TYPE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1160"
        ' <summary>Ent_APP1160</ summary>
        Private Property Ent_APP1160() As ENT_APP1160
            Get
                Return Me.PropertyMap("Ent_APP1160")
            End Get
            Set(ByVal value As ENT_APP1160)
                Me.PropertyMap("Ent_APP1160") = value
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
                Me.Ent_APP1160.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1160.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號
                Me.Ent_APP1160.MEMBER_NAME = Me.MEMBER_NAME      '委員姓名
                Me.Ent_APP1160.SEX_TYPE = Me.SEX_TYPE        '性別, REF. SYST010.SYS_KEY='SEX_TYPE'
                Me.Ent_APP1160.TEACHER_TYPE = Me.TEACHER_TYPE        '內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1160.Insert()

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
                Me.Ent_APP1160.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1160.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號
                Me.Ent_APP1160.MEMBER_NAME = Me.MEMBER_NAME      '委員姓名
                Me.Ent_APP1160.SEX_TYPE = Me.SEX_TYPE        '性別, REF. SYST010.SYS_KEY='SEX_TYPE'
                Me.Ent_APP1160.TEACHER_TYPE = Me.TEACHER_TYPE        '內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1160.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1160.Update()

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
                Me.Ent_APP1160.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1160.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1160.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '紀錄編號, 系統自動編號
                Me.ProcessQueryCondition(condition, "%LIKE%", "MEMBER_NAME", Me.MEMBER_NAME)         '委員姓名
                Me.ProcessQueryCondition(condition, "=", "SEX_TYPE", Me.SEX_TYPE)        '性別, REF. SYST010.SYS_KEY='SEX_TYPE'
                Me.ProcessQueryCondition(condition, "=", "TEACHER_TYPE", Me.TEACHER_TYPE)        '內/外部委員, REF. SYST010.SYS_KEY='TEACHER_TYPE'

                Me.Ent_APP1160.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1160.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1160.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1160.Query()
                Else
                    result = Me.Ent_APP1160.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1160.TotalRowCount
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

