'ProductName                 : TSBA 
'File Name					 : CtSYST010 
'Description	             : CtSYST010  
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/21         Source Create
'---------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Sys.Business
    Partial Public Class CtSYST010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_SYST010 = New ENT_SYST010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "SYS_KEY "
        '' <summary>
        '' SYS_KEY 
        '' </summary>
        Public Property SYS_KEY() As String
            Get
                Return Me.PropertyMap("SYS_KEY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_KEY") = value
            End Set
        End Property
#End Region

#Region "SYS_PRTID "
        '' <summary>
        '' SYS_PRTID 
        '' </summary>
        Public Property SYS_PRTID() As String
            Get
                Return Me.PropertyMap("SYS_PRTID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_PRTID") = value
            End Set
        End Property
#End Region

#Region "SYS_ID "
        '' <summary>
        '' SYS_ID 
        '' </summary>
        Public Property SYS_ID() As String
            Get
                Return Me.PropertyMap("SYS_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_ID") = value
            End Set
        End Property
#End Region

#Region "SYS_NAME "
        '' <summary>
        '' SYS_NAME 
        '' </summary>
        Public Property SYS_NAME() As String
            Get
                Return Me.PropertyMap("SYS_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_NAME") = value
            End Set
        End Property
#End Region

#Region "SYS_TYPE "
        '' <summary>
        '' SYS_TYPE 
        '' </summary>
        Public Property SYS_TYPE() As String
            Get
                Return Me.PropertyMap("SYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV1 "
        '' <summary>
        '' SYS_RSV1 
        '' </summary>
        Public Property SYS_RSV1() As String
            Get
                Return Me.PropertyMap("SYS_RSV1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV1") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV2 "
        '' <summary>
        '' SYS_RSV2 
        '' </summary>
        Public Property SYS_RSV2() As String
            Get
                Return Me.PropertyMap("SYS_RSV2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV2") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV3 "
        '' <summary>
        '' SYS_RSV3 
        '' </summary>
        Public Property SYS_RSV3() As String
            Get
                Return Me.PropertyMap("SYS_RSV3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV3") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV4 "
        '' <summary>
        '' SYS_RSV4 
        '' </summary>
        Public Property SYS_RSV4() As String
            Get
                Return Me.PropertyMap("SYS_RSV4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV4") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT "
        '' <summary>
        '' SYS_SORT 
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.PropertyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "USE_STATE "
        '' <summary>
        '' USE_STATE 
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "REMARK "
        '' <summary>
        '' REMARK 
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.PropertyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "Ent_SYST010"
        ' <summary>Ent_SYST010</ summary>
        Private Property Ent_SYST010() As ENT_SYST010
            Get
                Return Me.PropertyMap("Ent_SYST010")
            End Get
            Set(ByVal value As ENT_SYST010)
                Me.PropertyMap("Ent_SYST010") = value
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
                Me.Ent_SYST010.SYS_KEY = Me.SYS_KEY      '
                Me.Ent_SYST010.SYS_PRTID = Me.SYS_PRTID      '
                Me.Ent_SYST010.SYS_ID = Me.SYS_ID        '
                Me.Ent_SYST010.SYS_NAME = Me.SYS_NAME        '
                Me.Ent_SYST010.SYS_TYPE = Me.SYS_TYPE        '
                Me.Ent_SYST010.SYS_RSV1 = Me.SYS_RSV1        '
                Me.Ent_SYST010.SYS_RSV2 = Me.SYS_RSV2        '
                Me.Ent_SYST010.SYS_RSV3 = Me.SYS_RSV3        '
                Me.Ent_SYST010.SYS_RSV4 = Me.SYS_RSV4        '
                Me.Ent_SYST010.SYS_SORT = Me.SYS_SORT        '
                Me.Ent_SYST010.USE_STATE = Me.USE_STATE      '
                Me.Ent_SYST010.REMARK = Me.REMARK        '


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_SYST010.Insert()

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
                Me.Ent_SYST010.SYS_KEY = Me.SYS_KEY      '
                Me.Ent_SYST010.SYS_PRTID = Me.SYS_PRTID      '
                Me.Ent_SYST010.SYS_ID = Me.SYS_ID        '
                Me.Ent_SYST010.SYS_NAME = Me.SYS_NAME        '
                Me.Ent_SYST010.SYS_TYPE = Me.SYS_TYPE        '
                Me.Ent_SYST010.SYS_RSV1 = Me.SYS_RSV1        '
                Me.Ent_SYST010.SYS_RSV2 = Me.SYS_RSV2        '
                Me.Ent_SYST010.SYS_RSV3 = Me.SYS_RSV3        '
                Me.Ent_SYST010.SYS_RSV4 = Me.SYS_RSV4        '
                Me.Ent_SYST010.SYS_SORT = Me.SYS_SORT        '
                Me.Ent_SYST010.USE_STATE = Me.USE_STATE      '
                Me.Ent_SYST010.REMARK = Me.REMARK        '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_SYST010.Update()

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
                Me.Ent_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_SYST010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_SYST010.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "SYS_KEY", Me.SYS_KEY)      '
                Me.ProcessQueryCondition(condition, "=", "SYS_PRTID", Me.SYS_PRTID)      '
                Me.ProcessQueryCondition(condition, "=", "SYS_ID", Me.SYS_ID)        '
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_NAME", Me.SYS_NAME)       '
                Me.ProcessQueryCondition(condition, "=", "SYS_TYPE", Me.SYS_TYPE)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV1", Me.SYS_RSV1)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV2", Me.SYS_RSV2)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV3", Me.SYS_RSV3)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV4", Me.SYS_RSV4)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)        '
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '

                Me.Ent_SYST010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_SYST010.OrderBys = "PKNO"
                Else
                    Me.Ent_SYST010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_SYST010.Query()
                Else
                    result = Me.Ent_SYST010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_SYST010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQuery_GetMaxPRTID() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_KEY", "SYSTEM_OPERATOR")      '
                Me.ProcessQueryCondition(condition, "=", "SYS_PRTID", 1)      '
                Me.ProcessQueryCondition(condition, "=", "SYS_ID", Me.SYS_ID)        '
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_NAME", Me.SYS_NAME)       '
                Me.ProcessQueryCondition(condition, "=", "SYS_TYPE", Me.SYS_TYPE)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV1", Me.SYS_RSV1)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV2", Me.SYS_RSV2)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV3", Me.SYS_RSV3)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_RSV4", Me.SYS_RSV4)        '
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT)        '
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '

                Me.Ent_SYST010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_SYST010.OrderBys = "PKNO"
                Else
                    Me.Ent_SYST010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_SYST010.Query_GetMaxPRTID()
                Else
                    result = Me.Ent_SYST010.Query_GetMaxPRTID(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_SYST010.TotalRowCount
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

