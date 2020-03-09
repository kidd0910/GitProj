'ProductName                 : BTEV 
'File Name					 : CtMCHK010 
'Description	             : CtMCHK010 查核單Controller
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/01/09  Becky      Source Create
'---------------------------------------------------------------------------

Imports Mchk.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Acer.Apps

Namespace Mchk.Business
    Partial Public Class CtMCHK010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_MCHK010 = New ENT_MCHK010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "MCHK_STATUS "
        '' <summary>
        '' MCHK_STATUS 
        '' </summary>
        Public Property MCHK_STATUS() As String
            Get
                Return Me.PropertyMap("MCHK_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_STATUS") = value
            End Set
        End Property
#End Region

#Region "MCHK_NO 查核代號"
        '' <summary>
        '' MCHK_NO 查核代號
        '' </summary>
        Public Property MCHK_NO() As String
            Get
                Return Me.PropertyMap("MCHK_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_NO") = value
            End Set
        End Property
#End Region

#Region "APPL010_PKNO 查核審驗機構"
        '' <summary>
        '' APPL010_PKNO 查核審驗機構
        '' </summary>
        Public Property APPL010_PKNO() As String
            Get
                Return Me.PropertyMap("APPL010_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPL010_PKNO") = value
            End Set
        End Property
#End Region

#Region "MCHK_DATE 實地查核日期"
        '' <summary>
        '' MCHK_DATE 實地查核日期
        '' </summary>
        Public Property MCHK_DATE() As String
            Get
                Return Me.PropertyMap("MCHK_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_DATE") = value
            End Set
        End Property
#End Region

#Region "TECH_NAME 電機技師"
        '' <summary>
        '' TECH_NAME 電機技師
        '' </summary>
        Public Property TECH_NAME() As String
            Get
                Return Me.PropertyMap("TECH_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TECH_NAME") = value
            End Set
        End Property
#End Region

#Region "CHK_NAME NCC查核人員"
        '' <summary>
        '' CHK_NAME NCC查核人員
        '' </summary>
        Public Property CHK_NAME() As String
            Get
                Return Me.PropertyMap("CHK_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHK_NAME") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC1 本會查核意見"
        '' <summary>
        '' MCHK_DESC1 本會查核意見
        '' </summary>
        Public Property MCHK_DESC1() As String
            Get
                Return Me.PropertyMap("MCHK_DESC1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_DESC1") = value
            End Set
        End Property
#End Region

#Region "REPLY_DATE 總處回復日期"
        '' <summary>
        '' REPLY_DATE 總處回復日期
        '' </summary>
        Public Property REPLY_DATE() As String
            Get
                Return Me.PropertyMap("REPLY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REPLY_DATE") = value
            End Set
        End Property
#End Region

#Region "MCHK_DESC2 審驗總處說明"
        '' <summary>
        '' MCHK_DESC2 審驗總處說明
        '' </summary>
        Public Property MCHK_DESC2() As String
            Get
                Return Me.PropertyMap("MCHK_DESC2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MCHK_DESC2") = value
            End Set
        End Property
#End Region

#Region "CLOSE_DATE 結案日期"
        '' <summary>
        '' CLOSE_DATE 結案日期
        '' </summary>
        Public Property CLOSE_DATE() As String
            Get
                Return Me.PropertyMap("CLOSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CLOSE_DATE") = value
            End Set
        End Property
#End Region

#Region "QUERY_COND 查詢條件"
        ''' <summary>
        ''' QUERY_COND 查詢條件
        ''' </summary>
        Public Property QUERY_COND() As String
            Get
                Return Me.PropertyMap("QUERY_COND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QUERY_COND") = value
            End Set
        End Property
#End Region

#Region "Ent_MCHK010"
        ' <summary>Ent_MCHK010</ summary>
        Private Property Ent_MCHK010() As ENT_MCHK010
            Get
                Return Me.PropertyMap("Ent_MCHK010")
            End Get
            Set(ByVal value As ENT_MCHK010)
                Me.PropertyMap("Ent_MCHK010") = value
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
                Me.Ent_MCHK010.MCHK_STATUS = Me.MCHK_STATUS      '
                Me.Ent_MCHK010.MCHK_NO = Me.MCHK_NO      '查核代號
                Me.Ent_MCHK010.APPL010_PKNO = Me.APPL010_PKNO         '查核審驗機構
                Me.Ent_MCHK010.MCHK_DATE = Me.MCHK_DATE        '實地查核日期
                Me.Ent_MCHK010.TECH_NAME = Me.TECH_NAME        '電機技師
                Me.Ent_MCHK010.CHK_NAME = Me.CHK_NAME         'NCC查核人員
                Me.Ent_MCHK010.MCHK_DESC1 = Me.MCHK_DESC1       '本會查核意見
                Me.Ent_MCHK010.REPLY_DATE = Me.REPLY_DATE       '總處回復日期
                Me.Ent_MCHK010.MCHK_DESC2 = Me.MCHK_DESC2       '審驗總處說明
                Me.Ent_MCHK010.CLOSE_DATE = Me.CLOSE_DATE       '結案日期


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_MCHK010.Insert()

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
                Me.Ent_MCHK010.MCHK_STATUS = Me.MCHK_STATUS      '
                Me.Ent_MCHK010.MCHK_NO = Me.MCHK_NO      '查核代號
                Me.Ent_MCHK010.APPL010_PKNO = Me.APPL010_PKNO         '查核審驗機構
                Me.Ent_MCHK010.MCHK_DATE = Me.MCHK_DATE        '實地查核日期
                Me.Ent_MCHK010.TECH_NAME = Me.TECH_NAME        '電機技師
                Me.Ent_MCHK010.CHK_NAME = Me.CHK_NAME         'NCC查核人員
                Me.Ent_MCHK010.MCHK_DESC1 = Me.MCHK_DESC1       '本會查核意見
                Me.Ent_MCHK010.REPLY_DATE = Me.REPLY_DATE       '總處回復日期
                Me.Ent_MCHK010.MCHK_DESC2 = Me.MCHK_DESC2       '審驗總處說明
                Me.Ent_MCHK010.CLOSE_DATE = Me.CLOSE_DATE       '結案日期


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                '處理批次修改狀態
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_MCHK010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_MCHK010.Update()

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

                '處理批次刪除
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.Ent_MCHK010.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '需先刪除子表 MCHK020
                'Dim Ent_MCHK020 As New ENT_MCHK020(Me.DBManager, Me.LogUtil)
                'Ent_MCHK020.SqlRetrictions = " MCHK010_PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') "
                'Ent_MCHK020.delAns()
                Dim ctrlAns As CtMCHK020 = New CtMCHK020(Me.DBManager, Me.LogUtil)
                ctrlAns.SqlRetrictions = " MCHK010_PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') "
                ctrlAns.delAns()

                Dim ENT As File.Data.EntAttachFile = New File.Data.EntAttachFile(Me.DBManager, Me.LogUtil)

                ENT.SqlRetrictions = " FILE_NO IN ('" & Me.PKNO.Replace(",", "','") & "') AND ACCE_SOURCE = 'APP4210_02' "
                ENT.OrderBys = "PKNO"
                Dim fileDt As DataTable = ENT.Query()

                ENT.SqlRetrictions = " FILE_NO IN ('" & Me.PKNO.Replace(",", "','") & "') AND ACCE_SOURCE = 'APP4210_02' "
                ENT.Delete()

                For i As Integer = 0 To fileDt.Rows.Count - 1
                    If System.IO.File.Exists(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & "/APP/" & fileDt.Rows(i)("ACTUAL_FILENAME").ToString) Then
                        System.IO.File.Delete(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & "/APP/" & fileDt.Rows(i)("ACTUAL_FILENAME").ToString)
                    End If
                Next

                '=== 刪除資料 ===
                If Me.Ent_MCHK010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_MCHK010.Delete()
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
                '處理批次修改狀態
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "MCHK_STATUS", Me.MCHK_STATUS)      '
                Me.ProcessQueryCondition(condition, "=", "MCHK_NO", Me.MCHK_NO)      '查核代號
                Me.ProcessQueryCondition(condition, "=", "APPL010_PKNO", Me.APPL010_PKNO)        '查核審驗機構
                Me.ProcessQueryCondition(condition, "=", "MCHK_DATE", Me.MCHK_DATE)      '實地查核日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "TECH_NAME", Me.TECH_NAME)         '電機技師
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHK_NAME", Me.CHK_NAME)       'NCC查核人員
                Me.ProcessQueryCondition(condition, "%LIKE%", "MCHK_DESC1", Me.MCHK_DESC1)       '本會查核意見
                Me.ProcessQueryCondition(condition, "=", "REPLY_DATE", Me.REPLY_DATE)        '總處回復日期
                Me.ProcessQueryCondition(condition, "%LIKE%", "MCHK_DESC2", Me.MCHK_DESC2)       '審驗總處說明
                Me.ProcessQueryCondition(condition, "=", "CLOSE_DATE", Me.CLOSE_DATE)        '結案日期

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_MCHK010.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_MCHK010.OrderBys = "PKNO"
                Else
                    Me.Ent_MCHK010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_MCHK010.Query()
                Else
                    result = Me.Ent_MCHK010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_MCHK010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get上傳檔案"
        ''' <summary>
        ''' Get上傳檔案
        ''' </summary>
        Public Function Get上傳檔案() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.Ent_MCHK010.PKNO = Me.PKNO

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_MCHK010.SqlRetrictions = condition.ToString()


                '=== 處理取得回傳資料===
                Dim result As DataTable = Me.Ent_MCHK010.Get上傳檔案()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get查核重點"
        ''' <summary>
        ''' Get上傳檔案
        ''' </summary>
        Public Function Get查核重點() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.Ent_MCHK010.PKNO = Me.PKNO

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_MCHK010.SqlRetrictions = condition.ToString()


                '=== 處理取得回傳資料===
                Dim result As DataTable = Me.Ent_MCHK010.Get查核重點()

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

