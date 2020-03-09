'ProductName                 : TSBA 
'File Name					 : CtS3001 
'Description	             : CtS3001 影音測試
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/10/31  TIM      Source Create
'---------------------------------------------------------------------------

Imports S3.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace S3.Business
    Partial Public Class CtS3001
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_S3001 = New ENT_S3001(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "FILENAME "
        '' <summary>
        '' FILENAME 
        '' </summary>
        Public Property FILENAME() As String
            Get
                Return Me.PropertyMap("FILENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FILENAME") = value
            End Set
        End Property
#End Region

#Region "OWNER "
        '' <summary>
        '' OWNER 
        '' </summary>
        Public Property OWNER() As String
            Get
                Return Me.PropertyMap("OWNER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OWNER") = value
            End Set
        End Property
#End Region

#Region "ETAG "
        '' <summary>
        '' ETAG 
        '' </summary>
        Public Property ETAG() As String
            Get
                Return Me.PropertyMap("ETAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ETAG") = value
            End Set
        End Property
#End Region

#Region "Ent_S3001"
        ' <summary>Ent_S3001</ summary>
        Private Property Ent_S3001() As ENT_S3001
            Get
                Return Me.PropertyMap("Ent_S3001")
            End Get
            Set(ByVal value As ENT_S3001)
                Me.PropertyMap("Ent_S3001") = value
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
                Me.Ent_S3001.FILENAME = Me.FILENAME      '
                Me.Ent_S3001.OWNER = Me.OWNER        '
                Me.Ent_S3001.ETAG = Me.ETAG      '


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_S3001.Insert()

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
                Me.Ent_S3001.FILENAME = Me.FILENAME      '
                Me.Ent_S3001.OWNER = Me.OWNER        '
                Me.Ent_S3001.ETAG = Me.ETAG      '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_S3001.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_S3001.Update()

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
                Me.Ent_S3001.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_S3001.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_S3001.Delete()
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
                Me.ProcessQueryCondition(condition, "%LIKE%", "FILENAME", Me.FILENAME)       '
                Me.ProcessQueryCondition(condition, "=", "OWNER", Me.OWNER)      '
                Me.ProcessQueryCondition(condition, "=", "ETAG", Me.ETAG)        '

                Me.Ent_S3001.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_S3001.OrderBys = "PKNO"
                Else
                    Me.Ent_S3001.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_S3001.Query()
                Else
                    result = Me.Ent_S3001.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_S3001.TotalRowCount
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

