'ProductName                 : TSBA 
'File Name					 : CtAPP1411 
'Description	             : CtAPP1411 APP1411 員額基本資料
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/15  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1411
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1411 = New ENT_APP1411(Me.DBManager, Me.LogUtil)
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

#Region "BASE_DATE 基準日"
        '' <summary>
        '' BASE_DATE 基準日
        '' </summary>
        Public Property BASE_DATE() As String
            Get
                Return Me.PropertyMap("BASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BASE_DATE") = value
            End Set
        End Property
#End Region

#Region "M_EMPLOYEE_NUMBER 公司男性員額"
        '' <summary>
        '' M_EMPLOYEE_NUMBER 公司男性員額
        '' </summary>
        Public Property M_EMPLOYEE_NUMBER() As String
            Get
                Return Me.PropertyMap("M_EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_MANAGER_NUMBER 男性主管員額"
        '' <summary>
        '' M_MANAGER_NUMBER 男性主管員額
        '' </summary>
        Public Property M_MANAGER_NUMBER() As String
            Get
                Return Me.PropertyMap("M_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_HSCHOOL_NUMBER 高中(職)及以下男性"
        '' <summary>
        '' M_HSCHOOL_NUMBER 高中(職)及以下男性
        '' </summary>
        Public Property M_HSCHOOL_NUMBER() As String
            Get
                Return Me.PropertyMap("M_HSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_HSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_UNIVERSITY_NUMBER 大專、學院及大學男性"
        '' <summary>
        '' M_UNIVERSITY_NUMBER 大專、學院及大學男性
        '' </summary>
        Public Property M_UNIVERSITY_NUMBER() As String
            Get
                Return Me.PropertyMap("M_UNIVERSITY_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_UNIVERSITY_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_GSCHOOL_NUMBER 研究所及以上男性"
        '' <summary>
        '' M_GSCHOOL_NUMBER 研究所及以上男性
        '' </summary>
        Public Property M_GSCHOOL_NUMBER() As String
            Get
                Return Me.PropertyMap("M_GSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_GSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_EMPLOYEE_NUMBER 公司女性員額"
        '' <summary>
        '' W_EMPLOYEE_NUMBER 公司女性員額
        '' </summary>
        Public Property W_EMPLOYEE_NUMBER() As String
            Get
                Return Me.PropertyMap("W_EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("W_EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_MANAGER_NUMBER 女性主管員額"
        '' <summary>
        '' W_MANAGER_NUMBER 女性主管員額
        '' </summary>
        Public Property W_MANAGER_NUMBER() As String
            Get
                Return Me.PropertyMap("W_MANAGER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("W_MANAGER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_HSCHOOL_NUMBER 高中(職)及以下女性"
        '' <summary>
        '' W_HSCHOOL_NUMBER 高中(職)及以下女性
        '' </summary>
        Public Property W_HSCHOOL_NUMBER() As String
            Get
                Return Me.PropertyMap("W_HSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("W_HSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_UNIVERSITY_NUMBER 大專、學院及大學女性"
        '' <summary>
        '' W_UNIVERSITY_NUMBER 大專、學院及大學女性
        '' </summary>
        Public Property W_UNIVERSITY_NUMBER() As String
            Get
                Return Me.PropertyMap("W_UNIVERSITY_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("W_UNIVERSITY_NUMBER") = value
            End Set
        End Property
#End Region

#Region "W_GSCHOOL_NUMBER 研究所及以上女性"
        '' <summary>
        '' W_GSCHOOL_NUMBER 研究所及以上女性
        '' </summary>
        Public Property W_GSCHOOL_NUMBER() As String
            Get
                Return Me.PropertyMap("W_GSCHOOL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("W_GSCHOOL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1411"
        ' <summary>Ent_APP1411</ summary>
        Private Property Ent_APP1411() As ENT_APP1411
            Get
                Return Me.PropertyMap("Ent_APP1411")
            End Get
            Set(ByVal value As ENT_APP1411)
                Me.PropertyMap("Ent_APP1411") = value
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
                Me.Ent_APP1411.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1411.BASE_DATE = Me.BASE_DATE      '基準日
                Me.Ent_APP1411.M_EMPLOYEE_NUMBER = Me.M_EMPLOYEE_NUMBER      '公司男性員額
                Me.Ent_APP1411.M_MANAGER_NUMBER = Me.M_MANAGER_NUMBER        '男性主管員額
                Me.Ent_APP1411.M_HSCHOOL_NUMBER = Me.M_HSCHOOL_NUMBER        '高中(職)及以下男性
                Me.Ent_APP1411.M_UNIVERSITY_NUMBER = Me.M_UNIVERSITY_NUMBER      '大專、學院及大學男性
                Me.Ent_APP1411.M_GSCHOOL_NUMBER = Me.M_GSCHOOL_NUMBER        '研究所及以上男性
                Me.Ent_APP1411.W_EMPLOYEE_NUMBER = Me.W_EMPLOYEE_NUMBER      '公司女性員額
                Me.Ent_APP1411.W_MANAGER_NUMBER = Me.W_MANAGER_NUMBER        '女性主管員額
                Me.Ent_APP1411.W_HSCHOOL_NUMBER = Me.W_HSCHOOL_NUMBER        '高中(職)及以下女性
                Me.Ent_APP1411.W_UNIVERSITY_NUMBER = Me.W_UNIVERSITY_NUMBER      '大專、學院及大學女性
                Me.Ent_APP1411.W_GSCHOOL_NUMBER = Me.W_GSCHOOL_NUMBER        '研究所及以上女性


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1411.Insert()

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
                Me.Ent_APP1411.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1411.BASE_DATE = Me.BASE_DATE      '基準日
                Me.Ent_APP1411.M_EMPLOYEE_NUMBER = Me.M_EMPLOYEE_NUMBER      '公司男性員額
                Me.Ent_APP1411.M_MANAGER_NUMBER = Me.M_MANAGER_NUMBER        '男性主管員額
                Me.Ent_APP1411.M_HSCHOOL_NUMBER = Me.M_HSCHOOL_NUMBER        '高中(職)及以下男性
                Me.Ent_APP1411.M_UNIVERSITY_NUMBER = Me.M_UNIVERSITY_NUMBER      '大專、學院及大學男性
                Me.Ent_APP1411.M_GSCHOOL_NUMBER = Me.M_GSCHOOL_NUMBER        '研究所及以上男性
                Me.Ent_APP1411.W_EMPLOYEE_NUMBER = Me.W_EMPLOYEE_NUMBER      '公司女性員額
                Me.Ent_APP1411.W_MANAGER_NUMBER = Me.W_MANAGER_NUMBER        '女性主管員額
                Me.Ent_APP1411.W_HSCHOOL_NUMBER = Me.W_HSCHOOL_NUMBER        '高中(職)及以下女性
                Me.Ent_APP1411.W_UNIVERSITY_NUMBER = Me.W_UNIVERSITY_NUMBER      '大專、學院及大學女性
                Me.Ent_APP1411.W_GSCHOOL_NUMBER = Me.W_GSCHOOL_NUMBER        '研究所及以上女性


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1411.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1411.Update()

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
                Me.Ent_APP1411.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1411.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1411.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "BASE_DATE", Me.BASE_DATE)      '基準日
                Me.ProcessQueryCondition(condition, "=", "M_EMPLOYEE_NUMBER", Me.M_EMPLOYEE_NUMBER)      '公司男性員額
                Me.ProcessQueryCondition(condition, "=", "M_MANAGER_NUMBER", Me.M_MANAGER_NUMBER)        '男性主管員額
                Me.ProcessQueryCondition(condition, "=", "M_HSCHOOL_NUMBER", Me.M_HSCHOOL_NUMBER)        '高中(職)及以下男性
                Me.ProcessQueryCondition(condition, "=", "M_UNIVERSITY_NUMBER", Me.M_UNIVERSITY_NUMBER)      '大專、學院及大學男性
                Me.ProcessQueryCondition(condition, "=", "M_GSCHOOL_NUMBER", Me.M_GSCHOOL_NUMBER)        '研究所及以上男性
                Me.ProcessQueryCondition(condition, "=", "W_EMPLOYEE_NUMBER", Me.W_EMPLOYEE_NUMBER)      '公司女性員額
                Me.ProcessQueryCondition(condition, "=", "W_MANAGER_NUMBER", Me.W_MANAGER_NUMBER)        '女性主管員額
                Me.ProcessQueryCondition(condition, "=", "W_HSCHOOL_NUMBER", Me.W_HSCHOOL_NUMBER)        '高中(職)及以下女性
                Me.ProcessQueryCondition(condition, "=", "W_UNIVERSITY_NUMBER", Me.W_UNIVERSITY_NUMBER)      '大專、學院及大學女性
                Me.ProcessQueryCondition(condition, "=", "W_GSCHOOL_NUMBER", Me.W_GSCHOOL_NUMBER)        '研究所及以上女性

                Me.Ent_APP1411.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1411.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1411.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1411.Query()
                Else
                    result = Me.Ent_APP1411.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1411.TotalRowCount
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

