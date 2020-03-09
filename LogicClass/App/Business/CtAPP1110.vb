'ProductName                 : TSBA 
'File Name					 : CtAPP1110 
'Description	             : CtAPP1110 外國人持股比例計算表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/24  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1110
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1110 = New ENT_APP1110(Me.DBManager, Me.LogUtil)
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

#Region "FOREIGNER_SHOLDER_NM 外國股東名稱"
        '' <summary>
        '' FOREIGNER_SHOLDER_NM 外國股東名稱
        '' </summary>
        Public Property FOREIGNER_SHOLDER_NM() As String
            Get
                Return Me.PropertyMap("FOREIGNER_SHOLDER_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FOREIGNER_SHOLDER_NM") = value
            End Set
        End Property
#End Region

#Region "COUNTRY 國籍"
        '' <summary>
        '' COUNTRY 國籍
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.PropertyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "DIRECT_SHAREHOLDING 直接持股數"
        '' <summary>
        '' DIRECT_SHAREHOLDING 直接持股數
        '' </summary>
        Public Property DIRECT_SHAREHOLDING() As String
            Get
                Return Me.PropertyMap("DIRECT_SHAREHOLDING")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIRECT_SHAREHOLDING") = value
            End Set
        End Property
#End Region

#Region "PROPORTION 所佔比例"
        '' <summary>
        '' PROPORTION 所佔比例
        '' </summary>
        Public Property PROPORTION() As String
            Get
                Return Me.PropertyMap("PROPORTION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROPORTION") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1110"
        ' <summary>Ent_APP1110</ summary>
        Private Property Ent_APP1110() As ENT_APP1110
            Get
                Return Me.PropertyMap("Ent_APP1110")
            End Get
            Set(ByVal value As ENT_APP1110)
                Me.PropertyMap("Ent_APP1110") = value
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
                Me.Ent_APP1110.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1110.FOREIGNER_SHOLDER_NM = Me.FOREIGNER_SHOLDER_NM        '外國股東名稱
                Me.Ent_APP1110.COUNTRY = Me.COUNTRY      '國籍
                Me.Ent_APP1110.DIRECT_SHAREHOLDING = Me.DIRECT_SHAREHOLDING      '直接持股數
                Me.Ent_APP1110.PROPORTION = Me.PROPORTION        '所佔比例


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1110.Insert()

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
                Me.Ent_APP1110.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1110.FOREIGNER_SHOLDER_NM = Me.FOREIGNER_SHOLDER_NM        '外國股東名稱
                Me.Ent_APP1110.COUNTRY = Me.COUNTRY      '國籍
                Me.Ent_APP1110.DIRECT_SHAREHOLDING = Me.DIRECT_SHAREHOLDING      '直接持股數
                Me.Ent_APP1110.PROPORTION = Me.PROPORTION        '所佔比例


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1110.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1110.Update()

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
                Me.Ent_APP1110.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1110.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1110.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "FOREIGNER_SHOLDER_NM", Me.FOREIGNER_SHOLDER_NM)        '外國股東名稱
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)      '國籍
                Me.ProcessQueryCondition(condition, "=", "DIRECT_SHAREHOLDING", Me.DIRECT_SHAREHOLDING)      '直接持股數
                Me.ProcessQueryCondition(condition, "=", "PROPORTION", Me.PROPORTION)        '所佔比例

                Me.Ent_APP1110.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1110.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1110.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1110.Query()
                Else
                    result = Me.Ent_APP1110.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1110.TotalRowCount
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

