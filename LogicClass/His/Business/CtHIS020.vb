'ProductName                 : BTEV 
'File Name					 : CtHIS020 
'Description	             : CtHIS020 操作紀錄
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2016/12/27  Becky      Source Create
'---------------------------------------------------------------------------

Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports His.Data

Namespace His.Business
    Partial Public Class CtHIS020
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_HIS020 = New ENT_HIS020(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO "
        '' <summary>
        '' CASE_NO 
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

#Region "OTHER_UNIT_DESC "
        '' <summary>
        '' OTHER_UNIT_DESC 
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.PropertyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region


#Region "TBL_RECID "
        '' <summary>
        '' TBL_RECID 
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

#Region "OP_DESC "
        '' <summary>
        '' OP_DESC 
        '' </summary>
        Public Property OP_DESC() As String
            Get
                Return Me.PropertyMap("OP_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OP_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_HIS020"
        ' <summary>Ent_HIS020</ summary>
        Private Property Ent_HIS020() As ENT_HIS020
            Get
                Return Me.PropertyMap("Ent_HIS020")
            End Get
            Set(ByVal value As ENT_HIS020)
                Me.PropertyMap("Ent_HIS020") = value
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

                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                '=== 設定屬性參數 ===
                Me.Ent_HIS020.CASE_NO = Me.CASE_NO      '
                Me.Ent_HIS020.OP_DESC = Me.OP_DESC      '
                Me.Ent_HIS020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_HIS020.DoAdd()

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
                'If String.IsNullOrEmpty(Me.PKNO) Then
                '    faileArguments.Add("PKNO")
                'End If
                If String.IsNullOrEmpty(Me.TBL_RECID) Then
                    faileArguments.Add("TBL_RECID")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Me.Ent_HIS020.CASE_NO = Me.CASE_NO
                Me.Ent_HIS020.OP_DESC = Me.OP_DESC
                Me.Ent_HIS020.OTHER_UNIT_DESC = Me.OTHER_UNIT_DESC



                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_HIS020.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_HIS020.Update()

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
                If String.IsNullOrEmpty(Me.TBL_RECID) Then
                    faileArguments.Add("TBL_RECID")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)
                Me.Ent_HIS020.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_HIS020.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_HIS020.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "TBL_RECID", Me.TBL_RECID)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '
                Me.ProcessQueryCondition(condition, "%LIKE%", "OP_DESC", Me.OP_DESC)         '
                Me.ProcessQueryCondition(condition, "=", "OTHER_UNIT_DESC", Me.OTHER_UNIT_DESC)      '

                Me.Ent_HIS020.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    'Me.Ent_HIS020.OrderBys = "PKNO"
                Else
                    Me.Ent_HIS020.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_HIS020.Query()
                Else
                    result = Me.Ent_HIS020.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_HIS020.TotalRowCount
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

