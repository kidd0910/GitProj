'ProductName                 : TSBA 
'File Name					 : CtAPP1410 
'Description	             : CtAPP1410 APP1410 員額編制表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/07  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1410
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1410 = New Ent_APP1410(Me.DBManager, Me.LogUtil)
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

#Region "DEPT_NAME 部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入"
        '' <summary>
        '' DEPT_NAME 部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入
        '' </summary>
        Public Property DEPT_NAME() As String
            Get
                Return Me.PropertyMap("DEPT_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEPT_NAME") = value
            End Set
        End Property
#End Region

#Region "其他部門-說明"
        '' <summary>
        '' 其他部門-說明
        '' </summary>
        Public Property DEPT_DESC() As String
            Get
                Return Me.PropertyMap("DEPT_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEPT_DESC") = value
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

#Region "MANAGER_NUMBER 主管人數"
        '' <summary>
        '' MANAGER_NUMBER 主管人數
        '' </summary>
        Public Property MANAGER_NUMBER() As String
            Get
                Return Me.PropertyMap("MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "NON_MANAGER_NUMBER 非主管人數"
        '' <summary>
        '' NON_MANAGER_NUMBER 非主管人數
        '' </summary>
        Public Property NON_MANAGER_NUMBER() As String
            Get
                Return Me.PropertyMap("NON_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NON_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EMPLOYEE_NUMBER 員工人數"
        '' <summary>
        '' EMPLOYEE_NUMBER 員工人數
        '' </summary>
        Public Property EMPLOYEE_NUMBER() As String
            Get
                Return Me.PropertyMap("EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "JOB_NAME 主管職稱"
        '' <summary>
        '' JOB_NAME 主管職稱
        '' </summary>
        Public Property JOB_NAME() As String
            Get
                Return Me.PropertyMap("JOB_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOB_NAME") = value
            End Set
        End Property
#End Region

#Region "MANAGER_NAME 姓名"
        '' <summary>
        '' MANAGER_NAME 姓名
        '' </summary>
        Public Property MANAGER_NAME() As String
            Get
                Return Me.PropertyMap("MANAGER_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MANAGER_NAME") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1410"
        ' <summary>Ent_APP1410</ summary>
        Private Property Ent_APP1410() As Ent_APP1410
            Get
                Return Me.PropertyMap("Ent_APP1410")
            End Get
            Set(ByVal value As Ent_APP1410)
                Me.PropertyMap("Ent_APP1410") = value
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
                Me.Ent_APP1410.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1410.DEPT_NAME = Me.DEPT_NAME      '部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入
                Me.Ent_APP1410.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號
                Me.Ent_APP1410.MANAGER_NUMBER = Me.MANAGER_NUMBER        '主管人數
                Me.Ent_APP1410.NON_MANAGER_NUMBER = Me.NON_MANAGER_NUMBER        '非主管人數
                Me.Ent_APP1410.EMPLOYEE_NUMBER = Me.EMPLOYEE_NUMBER      '員工人數
                Me.Ent_APP1410.JOB_NAME = Me.JOB_NAME        '主管職稱
                Me.Ent_APP1410.MANAGER_NAME = Me.MANAGER_NAME        '姓名
                Me.Ent_APP1410.DEPT_DESC = Me.DEPT_DESC        '其他部門-說明


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1410.Insert()

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
                Me.Ent_APP1410.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1410.DEPT_NAME = Me.DEPT_NAME      '部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入
                Me.Ent_APP1410.TBL_RECID = Me.TBL_RECID      '紀錄編號, 系統自動編號
                Me.Ent_APP1410.MANAGER_NUMBER = Me.MANAGER_NUMBER        '主管人數
                Me.Ent_APP1410.NON_MANAGER_NUMBER = Me.NON_MANAGER_NUMBER        '非主管人數
                Me.Ent_APP1410.EMPLOYEE_NUMBER = Me.EMPLOYEE_NUMBER      '員工人數
                Me.Ent_APP1410.JOB_NAME = Me.JOB_NAME        '主管職稱
                Me.Ent_APP1410.MANAGER_NAME = Me.MANAGER_NAME        '姓名
                Me.Ent_APP1410.DEPT_DESC = Me.DEPT_DESC        '其他部門-說明


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1410.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1410.Update()

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
                If String.IsNullOrEmpty(Me.PKNO) And String.IsNullOrEmpty(Me.CASE_NO) Then
                    If String.IsNullOrEmpty(Me.PKNO) Then
                        faileArguments.Add("PKNO")
                    End If
                    If String.IsNullOrEmpty(Me.CASE_NO) Then
                        faileArguments.Add("CASE_NO")
                    End If
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.Ent_APP1410.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1410.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1410.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEPT_NAME", Me.DEPT_NAME)         '部門名稱, 申設時自動將所選[行政部門]的名稱存入，若[行政部門]選擇「其他」時，本欄位開放輸入，評鑑、換照時開放輸入
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEPT_DESC", Me.DEPT_DESC)         '部門-其他-說明
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '紀錄編號, 系統自動編號
                Me.ProcessQueryCondition(condition, "=", "MANAGER_NUMBER", Me.MANAGER_NUMBER)        '主管人數
                Me.ProcessQueryCondition(condition, "=", "NON_MANAGER_NUMBER", Me.NON_MANAGER_NUMBER)        '非主管人數
                Me.ProcessQueryCondition(condition, "=", "EMPLOYEE_NUMBER", Me.EMPLOYEE_NUMBER)      '員工人數
                Me.ProcessQueryCondition(condition, "%LIKE%", "JOB_NAME", Me.JOB_NAME)       '主管職稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "MANAGER_NAME", Me.MANAGER_NAME)       '姓名


                Me.Ent_APP1410.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1410.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1410.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1410.Query()
                Else
                    result = Me.Ent_APP1410.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1410.TotalRowCount
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

