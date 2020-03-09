'ProductName                 : TSBA 
'File Name					 : CtAPP1150 
'Description	             : CtAPP1150 經營代理之頻道
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/06  San      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1150
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1150 = New Ent_APP1150(Me.DBManager, Me.LogUtil)
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

#Region "TBL_RECID 紀錄編號"
        '' <summary>
        '' TBL_RECID 紀錄編號
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

#Region "CHANNEL_NAME 頻道名稱"
        '' <summary>
        '' CHANNEL_NAME 頻道名稱
        '' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.PropertyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_TYPE 頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'"
        '' <summary>
        '' CHANNEL_TYPE 頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'
        '' </summary>
        Public Property CHANNEL_TYPE() As String
            Get
                Return Me.PropertyMap("CHANNEL_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_TYPE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE 執照期限(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照期限(起)
        '' </summary>
        Public Property LICENSE_S_DATE() As String
            Get
                Return Me.PropertyMap("LICENSE_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_S_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_E_DATE 執照期限(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照期限(迄)
        '' </summary>
        Public Property LICENSE_E_DATE() As String
            Get
                Return Me.PropertyMap("LICENSE_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PUNISH_NUMBER 執照期限內核處次數"
        '' <summary>
        '' PUNISH_NUMBER 執照期限內核處次數
        '' </summary>
        Public Property PUNISH_NUMBER() As String
            Get
                Return Me.PropertyMap("PUNISH_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PUNISH_NUMBER") = value
            End Set
        End Property
#End Region

#Region "PUNISH_AMT 執照期限內核處金額"
        '' <summary>
        '' PUNISH_AMT 執照期限內核處金額
        '' </summary>
        Public Property PUNISH_AMT() As String
            Get
                Return Me.PropertyMap("PUNISH_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PUNISH_AMT") = value
            End Set
        End Property
#End Region

#Region "COUNTRY_TYPE 境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'"
        '' <summary>
        '' COUNTRY_TYPE 境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'
        '' </summary>
        Public Property COUNTRY_TYPE() As String
            Get
                Return Me.PropertyMap("COUNTRY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY_TYPE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1150"
        ' <summary>Ent_APP1150</ summary>
        Private Property Ent_APP1150() As Ent_APP1150
            Get
                Return Me.PropertyMap("Ent_APP1150")
            End Get
            Set(ByVal value As Ent_APP1150)
                Me.PropertyMap("Ent_APP1150") = value
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
                Me.Ent_APP1150.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1150.TBL_RECID = Me.TBL_RECID        '紀錄編號
                Me.Ent_APP1150.CHANNEL_NAME = Me.CHANNEL_NAME         '頻道名稱
                Me.Ent_APP1150.CHANNEL_TYPE = Me.CHANNEL_TYPE         '頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'
                Me.Ent_APP1150.LICENSE_S_DATE = Me.LICENSE_S_DATE       '執照期限(起)
                Me.Ent_APP1150.LICENSE_E_DATE = Me.LICENSE_E_DATE       '執照期限(迄)
                Me.Ent_APP1150.PUNISH_NUMBER = Me.PUNISH_NUMBER        '執照期限內核處次數
                Me.Ent_APP1150.PUNISH_AMT = Me.PUNISH_AMT       '執照期限內核處金額
                Me.Ent_APP1150.COUNTRY_TYPE = Me.COUNTRY_TYPE         '境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1150.Insert()

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
                Me.Ent_APP1150.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1150.TBL_RECID = Me.TBL_RECID        '紀錄編號
                Me.Ent_APP1150.CHANNEL_NAME = Me.CHANNEL_NAME         '頻道名稱
                Me.Ent_APP1150.CHANNEL_TYPE = Me.CHANNEL_TYPE         '頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'
                Me.Ent_APP1150.LICENSE_S_DATE = Me.LICENSE_S_DATE       '執照期限(起)
                Me.Ent_APP1150.LICENSE_E_DATE = Me.LICENSE_E_DATE       '執照期限(迄)
                Me.Ent_APP1150.PUNISH_NUMBER = Me.PUNISH_NUMBER        '執照期限內核處次數
                Me.Ent_APP1150.PUNISH_AMT = Me.PUNISH_AMT       '執照期限內核處金額
                Me.Ent_APP1150.COUNTRY_TYPE = Me.COUNTRY_TYPE         '境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1150.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1150.Update()

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
                Me.Ent_APP1150.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1150.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1150.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "TBL_RECID", Me.TBL_RECID)      '紀錄編號
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_NAME", Me.CHANNEL_NAME)       '頻道名稱
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_TYPE", Me.CHANNEL_TYPE)        '頻道屬性,  REF. SYST010.SYS_KEY='CHANNEL_TYPE'
                Me.ProcessQueryCondition(condition, ">=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)        '執照期限(起)
                Me.ProcessQueryCondition(condition, "<=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)        '執照期限(迄)
                Me.ProcessQueryCondition(condition, "=", "PUNISH_NUMBER", Me.PUNISH_NUMBER)      '執照期限內核處次數
                Me.ProcessQueryCondition(condition, "=", "PUNISH_AMT", Me.PUNISH_AMT)        '執照期限內核處金額
                Me.ProcessQueryCondition(condition, "=", "COUNTRY_TYPE", Me.COUNTRY_TYPE)        '境內/境外, REF. SYST010.SYS_KEY='COUNTRY_TYPE1'

                Me.Ent_APP1150.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1150.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1150.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1150.Query()
                Else
                    result = Me.Ent_APP1150.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1150.TotalRowCount
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


