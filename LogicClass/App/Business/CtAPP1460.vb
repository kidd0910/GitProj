'ProductName                 : TSBA 
'File Name					 : CtAPP1460 
'Description	             : CtAPP1460 APP1460 建設計畫
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
    Partial Public Class CtAPP1460
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1460 = New ENT_APP1460(Me.DBManager, Me.LogUtil)
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

#Region "RADIO_CITY 電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' RADIO_CITY 電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property RADIO_CITY() As String
            Get
                Return Me.PropertyMap("RADIO_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RADIO_CITY") = value
            End Set
        End Property
#End Region

#Region "RADIO_ZIP 電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' RADIO_ZIP 電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property RADIO_ZIP() As String
            Get
                Return Me.PropertyMap("RADIO_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RADIO_ZIP") = value
            End Set
        End Property
#End Region

#Region "RADIO_ADDRESS 電臺預訂設置地點"
        '' <summary>
        '' RADIO_ADDRESS 電臺預訂設置地點
        '' </summary>
        Public Property RADIO_ADDRESS() As String
            Get
                Return Me.PropertyMap("RADIO_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RADIO_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "PRE_SETUP_DATE 預估設立完成時間"
        '' <summary>
        '' PRE_SETUP_DATE 預估設立完成時間
        '' </summary>
        Public Property PRE_SETUP_DATE() As String
            Get
                Return Me.PropertyMap("PRE_SETUP_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRE_SETUP_DATE") = value
            End Set
        End Property
#End Region

#Region "PRE_POPULATION 預估涵蓋人口數"
        '' <summary>
        '' PRE_POPULATION 預估涵蓋人口數
        '' </summary>
        Public Property PRE_POPULATION() As String
            Get
                Return Me.PropertyMap("PRE_POPULATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRE_POPULATION") = value
            End Set
        End Property
#End Region

#Region "STUDIO_CITY 錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' STUDIO_CITY 錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property STUDIO_CITY() As String
            Get
                Return Me.PropertyMap("STUDIO_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("STUDIO_CITY") = value
            End Set
        End Property
#End Region

#Region "STUDIO_ZIP 錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' STUDIO_ZIP 錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property STUDIO_ZIP() As String
            Get
                Return Me.PropertyMap("STUDIO_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("STUDIO_ZIP") = value
            End Set
        End Property
#End Region

#Region "STUDIO_ADDRESS 錄播音室設置地點"
        '' <summary>
        '' STUDIO_ADDRESS 錄播音室設置地點
        '' </summary>
        Public Property STUDIO_ADDRESS() As String
            Get
                Return Me.PropertyMap("STUDIO_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("STUDIO_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "SITE_NUMBER 錄播音室數量"
        '' <summary>
        '' SITE_NUMBER 錄播音室數量
        '' </summary>
        Public Property SITE_NUMBER() As String
            Get
                Return Me.PropertyMap("SITE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SITE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "M_SITE_NUMBER 主控播音室數量"
        '' <summary>
        '' M_SITE_NUMBER 主控播音室數量
        '' </summary>
        Public Property M_SITE_NUMBER() As String
            Get
                Return Me.PropertyMap("M_SITE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_SITE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_CITY 事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_CITY 事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_CITY() As String
            Get
                Return Me.PropertyMap("BUSINESS_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSINESS_CITY") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ZIP 事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_ZIP 事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_ZIP() As String
            Get
                Return Me.PropertyMap("BUSINESS_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSINESS_ZIP") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ADDRESS 事業營業場所設置地點"
        '' <summary>
        '' BUSINESS_ADDRESS 事業營業場所設置地點
        '' </summary>
        Public Property BUSINESS_ADDRESS() As String
            Get
                Return Me.PropertyMap("BUSINESS_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSINESS_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1460"
        ' <summary>Ent_APP1460</ summary>
        Private Property Ent_APP1460() As ENT_APP1460
            Get
                Return Me.PropertyMap("Ent_APP1460")
            End Get
            Set(ByVal value As ENT_APP1460)
                Me.PropertyMap("Ent_APP1460") = value
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
                Me.Ent_APP1460.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1460.RADIO_CITY = Me.RADIO_CITY        '電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.RADIO_ZIP = Me.RADIO_ZIP      '電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.RADIO_ADDRESS = Me.RADIO_ADDRESS      '電臺預訂設置地點
                Me.Ent_APP1460.PRE_SETUP_DATE = Me.PRE_SETUP_DATE        '預估設立完成時間
                Me.Ent_APP1460.PRE_POPULATION = Me.PRE_POPULATION        '預估涵蓋人口數
                Me.Ent_APP1460.STUDIO_CITY = Me.STUDIO_CITY      '錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.STUDIO_ZIP = Me.STUDIO_ZIP        '錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.STUDIO_ADDRESS = Me.STUDIO_ADDRESS        '錄播音室設置地點
                Me.Ent_APP1460.SITE_NUMBER = Me.SITE_NUMBER      '錄播音室數量
                Me.Ent_APP1460.M_SITE_NUMBER = Me.M_SITE_NUMBER      '主控播音室數量
                Me.Ent_APP1460.BUSINESS_CITY = Me.BUSINESS_CITY      '事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.BUSINESS_ZIP = Me.BUSINESS_ZIP        '事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.BUSINESS_ADDRESS = Me.BUSINESS_ADDRESS        '事業營業場所設置地點


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1460.Insert()

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
                Me.Ent_APP1460.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1460.RADIO_CITY = Me.RADIO_CITY        '電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.RADIO_ZIP = Me.RADIO_ZIP      '電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.RADIO_ADDRESS = Me.RADIO_ADDRESS      '電臺預訂設置地點
                Me.Ent_APP1460.PRE_SETUP_DATE = Me.PRE_SETUP_DATE        '預估設立完成時間
                Me.Ent_APP1460.PRE_POPULATION = Me.PRE_POPULATION        '預估涵蓋人口數
                Me.Ent_APP1460.STUDIO_CITY = Me.STUDIO_CITY      '錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.STUDIO_ZIP = Me.STUDIO_ZIP        '錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.STUDIO_ADDRESS = Me.STUDIO_ADDRESS        '錄播音室設置地點
                Me.Ent_APP1460.SITE_NUMBER = Me.SITE_NUMBER      '錄播音室數量
                Me.Ent_APP1460.M_SITE_NUMBER = Me.M_SITE_NUMBER      '主控播音室數量
                Me.Ent_APP1460.BUSINESS_CITY = Me.BUSINESS_CITY      '事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.BUSINESS_ZIP = Me.BUSINESS_ZIP        '事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1460.BUSINESS_ADDRESS = Me.BUSINESS_ADDRESS        '事業營業場所設置地點


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1460.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1460.Update()

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
                Me.Ent_APP1460.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1460.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1460.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "RADIO_CITY", Me.RADIO_CITY)        '電臺預訂設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "RADIO_ZIP", Me.RADIO_ZIP)      '電臺預訂設置地點-行政區域, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "RADIO_ADDRESS", Me.RADIO_ADDRESS)      '電臺預訂設置地點
                Me.ProcessQueryCondition(condition, "=", "PRE_SETUP_DATE", Me.PRE_SETUP_DATE)        '預估設立完成時間
                Me.ProcessQueryCondition(condition, "=", "PRE_POPULATION", Me.PRE_POPULATION)        '預估涵蓋人口數
                Me.ProcessQueryCondition(condition, "=", "STUDIO_CITY", Me.STUDIO_CITY)      '錄播音室設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "STUDIO_ZIP", Me.STUDIO_ZIP)        '錄播音室設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "STUDIO_ADDRESS", Me.STUDIO_ADDRESS)        '錄播音室設置地點
                Me.ProcessQueryCondition(condition, "=", "SITE_NUMBER", Me.SITE_NUMBER)      '錄播音室數量
                Me.ProcessQueryCondition(condition, "=", "M_SITE_NUMBER", Me.M_SITE_NUMBER)      '主控播音室數量
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY)      '事業營業場所設置地點-縣市別, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ZIP", Me.BUSINESS_ZIP)        '事業營業場所設置地點-行政區, REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ADDRESS", Me.BUSINESS_ADDRESS)        '事業營業場所設置地點

                Me.Ent_APP1460.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1460.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1460.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1460.Query()
                Else
                    result = Me.Ent_APP1460.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1460.TotalRowCount
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

