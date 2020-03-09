'ProductName                 : TSBA 
'File Name					 : CtSYSC001 
'Description	             : CtSYSC001 系統下拉選單代碼維護
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/10/20  Sylvia      Source Create
'---------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Sys.Business
    Partial Public Class CtSYSC001
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_SYSC001 = New ENT_SYSC001(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CODE_TYPE 類別代碼"
        '' <summary>
        '' CODE_TYPE 類別代碼
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

#Region "CODE_NAME 類別名稱"
        '' <summary>
        '' CODE_NAME 類別名稱
        '' </summary>
        Public Property CODE_NAME() As String
            Get
                Return Me.PropertyMap("CODE_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CODE_NAME") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE 項目代碼"
        '' <summary>
        '' ITEM_TYPE 項目代碼
        '' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.PropertyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM_TYPE") = value
            End Set
        End Property
#End Region

#Region "ITEM_NAME 項目名稱"
        '' <summary>
        '' ITEM_NAME 項目名稱
        '' </summary>
        Public Property ITEM_NAME() As String
            Get
                Return Me.PropertyMap("ITEM_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM_NAME") = value
            End Set
        End Property
#End Region

#Region "IS_USE 是否使用(Y-啟用，N-不啟用)"
        '' <summary>
        '' IS_USE 是否使用(Y-啟用，N-不啟用)
        '' </summary>
        Public Property IS_USE() As String
            Get
                Return Me.PropertyMap("IS_USE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_USE") = value
            End Set
        End Property
#End Region

#Region "SORT 排序"
        '' <summary>
        '' SORT 排序
        '' </summary>
        Public Property SORT() As String
            Get
                Return Me.PropertyMap("SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SORT") = value
            End Set
        End Property
#End Region

#Region "REMARK 備註"
        '' <summary>
        '' REMARK 備註
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

#Region "Ent_SYSC001"
        ' <summary>Ent_SYSC001</ summary>
        Private Property Ent_SYSC001() As ENT_SYSC001
            Get
                Return Me.PropertyMap("Ent_SYSC001")
            End Get
            Set(ByVal value As ENT_SYSC001)
                Me.PropertyMap("Ent_SYSC001") = value
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
                Me.Ent_SYSC001.CODE_TYPE = Me.CODE_TYPE      '類別代碼
                Me.Ent_SYSC001.CODE_NAME = Me.CODE_NAME      '類別名稱
                Me.Ent_SYSC001.ITEM_TYPE = Me.ITEM_TYPE      '項目代碼
                Me.Ent_SYSC001.ITEM_NAME = Me.ITEM_NAME      '項目名稱
                Me.Ent_SYSC001.IS_USE = Me.IS_USE        '是否使用(Y-啟用，N-不啟用)
                Me.Ent_SYSC001.SORT = Me.SORT      '排序
                Me.Ent_SYSC001.REMARK = Me.REMARK        '備註


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_SYSC001.Insert()

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
                Me.Ent_SYSC001.CODE_TYPE = Me.CODE_TYPE      '類別代碼
                Me.Ent_SYSC001.CODE_NAME = Me.CODE_NAME      '類別名稱
                Me.Ent_SYSC001.ITEM_TYPE = Me.ITEM_TYPE      '項目代碼
                Me.Ent_SYSC001.ITEM_NAME = Me.ITEM_NAME      '項目名稱
                Me.Ent_SYSC001.IS_USE = Me.IS_USE        '是否使用(Y-啟用，N-不啟用)
                Me.Ent_SYSC001.SORT = Me.SORT      '排序
                Me.Ent_SYSC001.REMARK = Me.REMARK        '備註


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.Ent_SYSC001.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_SYSC001.Update()

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
                Me.Ent_SYSC001.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_SYSC001.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_SYSC001.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub

        Public Function DeleteByPkNo() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.Ent_SYSC001.PKNO = Me.PKNO

                Dim result As Integer = Me.Ent_SYSC001.DeleteByPkNo()

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
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                'Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "')")
                End If
                Me.ProcessQueryCondition(condition, "=", "CODE_TYPE", Me.CODE_TYPE)      '類別代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "CODE_NAME", Me.CODE_NAME)         '類別名稱
                Me.ProcessQueryCondition(condition, "=", "ITEM_TYPE", Me.ITEM_TYPE)      '項目代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "ITEM_NAME", Me.ITEM_NAME)         '項目名稱
                Me.ProcessQueryCondition(condition, "=", "IS_USE", Me.IS_USE)        '是否使用(Y-啟用，N-不啟用)
                Me.ProcessQueryCondition(condition, "=", "SORT", Me.SORT)      '排序
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '備註

                Me.Ent_SYSC001.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_SYSC001.OrderBys = "PKNO"
                Else
                    Me.Ent_SYSC001.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_SYSC001.Query()
                Else
                    result = Me.Ent_SYSC001.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_SYSC001.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

        Public Function QueryCodeType() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim result As DataTable
                result = Me.Ent_SYSC001.QueryCodeType()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function QueryItemType(ByVal codeType As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim condition As StringBuilder = New StringBuilder()

                Me.Ent_SYSC001.OrderBys = "CAST(SORT AS INT)"

                Dim result As DataTable = Me.Ent_SYSC001.QueryItemType(codeType)

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function


        Public Function QueryByPkNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.Ent_SYSC001.PKNO = Me.PKNO

                Dim result As DataTable = Me.Ent_SYSC001.QueryByPkNo()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
    End Class
End Namespace

