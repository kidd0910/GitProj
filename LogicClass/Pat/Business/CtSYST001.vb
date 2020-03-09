'ProductName                 : BTEV 
'File Name					 : CtSYST001 
'Description	             : CtSYST001 程式樣本
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2016/11/16  auth      Source Create
'---------------------------------------------------------------------------

Imports Pat.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Pat.Business
    Partial Public Class CtSYST001
        Inherits Acer.Base.ControlBase

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_SYST001 = New Ent_SYST001(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CODE 代碼"
        ''' <summary>
        ''' CODE 代碼
        ''' </summary>
        Public Property CODE() As String
            Get
                Return Me.PropertyMap("CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CODE") = value
            End Set
        End Property
#End Region

#Region "NAME 姓名"
        ''' <summary>
        ''' NAME 姓名
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.PropertyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NAME") = value
            End Set
        End Property
#End Region

#Region "DATEX PATTERN 日期"
        ''' <summary>
        ''' DATEX PATTERN 日期
        ''' </summary>
        Public Property DATEX() As String
            Get
                Return Me.PropertyMap("DATEX")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATEX") = value
            End Set
        End Property
#End Region

#Region "TAKE_TIME 選課時間"
        ''' <summary>
        ''' TAKE_TIME 選課時間
        ''' </summary>
        Public Property TAKE_TIME() As String
            Get
                Return Me.PropertyMap("TAKE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAKE_TIME") = value
            End Set
        End Property
#End Region

#Region "COLUMN_12 "
        ''' <summary>
        ''' COLUMN_12 
        ''' </summary>
        Public Property COLUMN_12() As String
            Get
                Return Me.PropertyMap("COLUMN_12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COLUMN_12") = value
            End Set
        End Property
#End Region

#Region "Ent_SYST001"
        ' <summary>Ent_SYST001</ summary>
        Private Property Ent_SYST001() As Ent_SYST001
            Get
                Return Me.PropertyMap("Ent_SYST001")
            End Get
            Set(ByVal value As Ent_SYST001)
                Me.PropertyMap("Ent_SYST001") = value
            End Set
        End Property
#End Region


#End Region

#Region "方法"
#Region "DoAdd 處理新增資料動作"
        ''' <summary>
        ''' 處理新增資料動作
        ''' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 設定屬性參數 ===
                Me.Ent_SYST001.CODE = Me.CODE         '代碼
                Me.Ent_SYST001.NAME = Me.NAME         '姓名
                Me.Ent_SYST001.DATEX = Me.DATEX        'PATTERN 日期
                Me.Ent_SYST001.TAKE_TIME = Me.TAKE_TIME        '選課時間
                

                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_SYST001.Insert()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoModify 處理修改資料動作"
        ''' <summary>
        ''' 處理修改資料動作
        ''' </summary>
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
                Me.Ent_SYST001.CODE = Me.CODE         '代碼
                Me.Ent_SYST001.NAME = Me.NAME         '姓名
                Me.Ent_SYST001.DATEX = Me.DATEX        'PATTERN 日期
                Me.Ent_SYST001.TAKE_TIME = Me.TAKE_TIME        '選課時間
                 

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_SYST001.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_SYST001.Update()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoDelete 處理刪除資料動作"
        ''' <summary>
        ''' 處理刪除資料動作
        ''' </summary>
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
                Me.Ent_SYST001.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_SYST001.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_SYST001.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#Region "DoQuery 進行查詢動作"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CODE", Me.CODE)        '代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "NAME", Me.NAME)       '姓名
                Me.ProcessQueryCondition(condition, "=", "DATEX", Me.DATEX)      'PATTERN 日期
                Me.ProcessQueryCondition(condition, "=", "TAKE_TIME", Me.TAKE_TIME)      '選課時間
                Me.ProcessQueryCondition(condition, "=", "COLUMN_12", Me.COLUMN_12)      '

                Me.Ent_SYST001.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_SYST001.OrderBys = "PKNO"
                Else
                    Me.Ent_SYST001.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_SYST001.Query()
                Else
                    result = Me.Ent_SYST001.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_SYST001.TotalRowCount
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

