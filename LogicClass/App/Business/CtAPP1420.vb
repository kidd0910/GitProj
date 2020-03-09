'ProductName                 : TSBA 
'File Name					 : CtAPP1420 
'Description	             : CtAPP1420 節目播出時數/比例
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/14         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1420
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1420 = New ENT_APP1420(Me.DBManager, Me.LogUtil)
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

#Region "YEAR 年期"
        '' <summary>
        '' YEAR 年期
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.PropertyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "HOURS_TOTAL 播出總時數"
        '' <summary>
        '' HOURS_TOTAL 播出總時數
        '' </summary>
        Public Property HOURS_TOTAL() As String
            Get
                Return Me.PropertyMap("HOURS_TOTAL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HOURS_TOTAL") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_ALL_RATE 自製節目比率-每日全時段"
        '' <summary>
        '' INTERNAL_ALL_RATE 自製節目比率-每日全時段
        '' </summary>
        Public Property INTERNAL_ALL_RATE() As String
            Get
                Return Me.PropertyMap("INTERNAL_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_MASTER_RATE 自製節目比率-每日主要時段"
        '' <summary>
        '' INTERNAL_MASTER_RATE 自製節目比率-每日主要時段
        '' </summary>
        Public Property INTERNAL_MASTER_RATE() As String
            Get
                Return Me.PropertyMap("INTERNAL_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_ALL_RATE 外製節目比率-每日全時段"
        '' <summary>
        '' EXTERNAL_ALL_RATE 外製節目比率-每日全時段
        '' </summary>
        Public Property EXTERNAL_ALL_RATE() As String
            Get
                Return Me.PropertyMap("EXTERNAL_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_MASTER_RATE 外製節目比率-每日主要時段"
        '' <summary>
        '' EXTERNAL_MASTER_RATE 外製節目比率-每日主要時段
        '' </summary>
        Public Property EXTERNAL_MASTER_RATE() As String
            Get
                Return Me.PropertyMap("EXTERNAL_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_ALL_RATE 聯播節目比率-每日全時段"
        '' <summary>
        '' JOIN_ALL_RATE 聯播節目比率-每日全時段
        '' </summary>
        Public Property JOIN_ALL_RATE() As String
            Get
                Return Me.PropertyMap("JOIN_ALL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOIN_ALL_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_MASTER_RATE 聯播節目比率-每日主要時段"
        '' <summary>
        '' JOIN_MASTER_RATE 聯播節目比率-每日主要時段
        '' </summary>
        Public Property JOIN_MASTER_RATE() As String
            Get
                Return Me.PropertyMap("JOIN_MASTER_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOIN_MASTER_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM01_RATE 國語發音-比例"
        '' <summary>
        '' ITEM01_RATE 國語發音-比例
        '' </summary>
        Public Property ITEM01_RATE() As String
            Get
                Return Me.PropertyMap("ITEM01_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM01_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM02_RATE 台語發音-比例"
        '' <summary>
        '' ITEM02_RATE 台語發音-比例
        '' </summary>
        Public Property ITEM02_RATE() As String
            Get
                Return Me.PropertyMap("ITEM02_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM02_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM03_RATE 客語發音-比例"
        '' <summary>
        '' ITEM03_RATE 客語發音-比例
        '' </summary>
        Public Property ITEM03_RATE() As String
            Get
                Return Me.PropertyMap("ITEM03_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM03_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM04_RATE 原住民語發音-比例"
        '' <summary>
        '' ITEM04_RATE 原住民語發音-比例
        '' </summary>
        Public Property ITEM04_RATE() As String
            Get
                Return Me.PropertyMap("ITEM04_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM04_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM05_RATE 英語發音-比例"
        '' <summary>
        '' ITEM05_RATE 英語發音-比例
        '' </summary>
        Public Property ITEM05_RATE() As String
            Get
                Return Me.PropertyMap("ITEM05_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM05_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM06_RATE 其他外國語言發音-比例"
        '' <summary>
        '' ITEM06_RATE 其他外國語言發音-比例
        '' </summary>
        Public Property ITEM06_RATE() As String
            Get
                Return Me.PropertyMap("ITEM06_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM06_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM07_RATE 新聞政令宣導-比例"
        '' <summary>
        '' ITEM07_RATE 新聞政令宣導-比例
        '' </summary>
        Public Property ITEM07_RATE() As String
            Get
                Return Me.PropertyMap("ITEM07_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM07_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM08_RATE 教育文化-比例"
        '' <summary>
        '' ITEM08_RATE 教育文化-比例
        '' </summary>
        Public Property ITEM08_RATE() As String
            Get
                Return Me.PropertyMap("ITEM08_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM08_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM09_RATE 公共服務-比例"
        '' <summary>
        '' ITEM09_RATE 公共服務-比例
        '' </summary>
        Public Property ITEM09_RATE() As String
            Get
                Return Me.PropertyMap("ITEM09_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM09_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM10_RATE 大眾娛樂-比例"
        '' <summary>
        '' ITEM10_RATE 大眾娛樂-比例
        '' </summary>
        Public Property ITEM10_RATE() As String
            Get
                Return Me.PropertyMap("ITEM10_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM10_RATE") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_RATE 本國製-比例"
        '' <summary>
        '' INTERNAL_RATE 本國製-比例
        '' </summary>
        Public Property INTERNAL_RATE() As String
            Get
                Return Me.PropertyMap("INTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_RATE 非本國製-比例"
        '' <summary>
        '' EXTERNAL_RATE 非本國製-比例
        '' </summary>
        Public Property EXTERNAL_RATE() As String
            Get
                Return Me.PropertyMap("EXTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "NEW_RATE 新播-比例"
        '' <summary>
        '' NEW_RATE 新播-比例
        '' </summary>
        Public Property NEW_RATE() As String
            Get
                Return Me.PropertyMap("NEW_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NEW_RATE") = value
            End Set
        End Property
#End Region

#Region "FIRST_RATE 首播-比例"
        '' <summary>
        '' FIRST_RATE 首播-比例
        '' </summary>
        Public Property FIRST_RATE() As String
            Get
                Return Me.PropertyMap("FIRST_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FIRST_RATE") = value
            End Set
        End Property
#End Region

#Region "REPLAY_RATE 重播-比例"
        '' <summary>
        '' REPLAY_RATE 重播-比例
        '' </summary>
        Public Property REPLAY_RATE() As String
            Get
                Return Me.PropertyMap("REPLAY_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REPLAY_RATE") = value
            End Set
        End Property
#End Region

#Region "INSOURCE_RATE 自製-比例"
        '' <summary>
        '' INSOURCE_RATE 自製-比例
        '' </summary>
        Public Property INSOURCE_RATE() As String
            Get
                Return Me.PropertyMap("INSOURCE_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INSOURCE_RATE") = value
            End Set
        End Property
#End Region

#Region "OUTSOURCE_RATE 外購-比例"
        '' <summary>
        '' OUTSOURCE_RATE 外購-比例
        '' </summary>
        Public Property OUTSOURCE_RATE() As String
            Get
                Return Me.PropertyMap("OUTSOURCE_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUTSOURCE_RATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1420"
        ' <summary>Ent_APP1420</ summary>
        Private Property Ent_APP1420() As ENT_APP1420
            Get
                Return Me.PropertyMap("Ent_APP1420")
            End Get
            Set(ByVal value As ENT_APP1420)
                Me.PropertyMap("Ent_APP1420") = value
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
                Me.Ent_APP1420.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1420.YEAR = Me.YEAR        '年期
                Me.Ent_APP1420.HOURS_TOTAL = Me.HOURS_TOTAL      '播出總時數
                Me.Ent_APP1420.INTERNAL_ALL_RATE = Me.INTERNAL_ALL_RATE      '自製節目比率-每日全時段
                Me.Ent_APP1420.INTERNAL_MASTER_RATE = Me.INTERNAL_MASTER_RATE        '自製節目比率-每日主要時段
                Me.Ent_APP1420.EXTERNAL_ALL_RATE = Me.EXTERNAL_ALL_RATE      '外製節目比率-每日全時段
                Me.Ent_APP1420.EXTERNAL_MASTER_RATE = Me.EXTERNAL_MASTER_RATE        '外製節目比率-每日主要時段
                Me.Ent_APP1420.JOIN_ALL_RATE = Me.JOIN_ALL_RATE      '聯播節目比率-每日全時段
                Me.Ent_APP1420.JOIN_MASTER_RATE = Me.JOIN_MASTER_RATE        '聯播節目比率-每日主要時段
                Me.Ent_APP1420.ITEM01_RATE = Me.ITEM01_RATE      '國語發音-比例
                Me.Ent_APP1420.ITEM02_RATE = Me.ITEM02_RATE      '台語發音-比例
                Me.Ent_APP1420.ITEM03_RATE = Me.ITEM03_RATE      '客語發音-比例
                Me.Ent_APP1420.ITEM04_RATE = Me.ITEM04_RATE      '原住民語發音-比例
                Me.Ent_APP1420.ITEM05_RATE = Me.ITEM05_RATE      '英語發音-比例
                Me.Ent_APP1420.ITEM06_RATE = Me.ITEM06_RATE      '其他外國語言發音-比例
                Me.Ent_APP1420.ITEM07_RATE = Me.ITEM07_RATE      '新聞政令宣導-比例
                Me.Ent_APP1420.ITEM08_RATE = Me.ITEM08_RATE      '教育文化-比例
                Me.Ent_APP1420.ITEM09_RATE = Me.ITEM09_RATE      '公共服務-比例
                Me.Ent_APP1420.ITEM10_RATE = Me.ITEM10_RATE      '大眾娛樂-比例
                Me.Ent_APP1420.INTERNAL_RATE = Me.INTERNAL_RATE      '本國製-比例
                Me.Ent_APP1420.EXTERNAL_RATE = Me.EXTERNAL_RATE      '非本國製-比例
                Me.Ent_APP1420.NEW_RATE = Me.NEW_RATE        '新播-比例
                Me.Ent_APP1420.FIRST_RATE = Me.FIRST_RATE        '首播-比例
                Me.Ent_APP1420.REPLAY_RATE = Me.REPLAY_RATE      '重播-比例
                Me.Ent_APP1420.INSOURCE_RATE = Me.INSOURCE_RATE      '自製-比例
                Me.Ent_APP1420.OUTSOURCE_RATE = Me.OUTSOURCE_RATE        '外購-比例


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1420.Insert()

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
                Me.Ent_APP1420.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1420.YEAR = Me.YEAR        '年期
                Me.Ent_APP1420.HOURS_TOTAL = Me.HOURS_TOTAL      '播出總時數
                Me.Ent_APP1420.INTERNAL_ALL_RATE = Me.INTERNAL_ALL_RATE      '自製節目比率-每日全時段
                Me.Ent_APP1420.INTERNAL_MASTER_RATE = Me.INTERNAL_MASTER_RATE        '自製節目比率-每日主要時段
                Me.Ent_APP1420.EXTERNAL_ALL_RATE = Me.EXTERNAL_ALL_RATE      '外製節目比率-每日全時段
                Me.Ent_APP1420.EXTERNAL_MASTER_RATE = Me.EXTERNAL_MASTER_RATE        '外製節目比率-每日主要時段
                Me.Ent_APP1420.JOIN_ALL_RATE = Me.JOIN_ALL_RATE      '聯播節目比率-每日全時段
                Me.Ent_APP1420.JOIN_MASTER_RATE = Me.JOIN_MASTER_RATE        '聯播節目比率-每日主要時段
                Me.Ent_APP1420.ITEM01_RATE = Me.ITEM01_RATE      '國語發音-比例
                Me.Ent_APP1420.ITEM02_RATE = Me.ITEM02_RATE      '台語發音-比例
                Me.Ent_APP1420.ITEM03_RATE = Me.ITEM03_RATE      '客語發音-比例
                Me.Ent_APP1420.ITEM04_RATE = Me.ITEM04_RATE      '原住民語發音-比例
                Me.Ent_APP1420.ITEM05_RATE = Me.ITEM05_RATE      '英語發音-比例
                Me.Ent_APP1420.ITEM06_RATE = Me.ITEM06_RATE      '其他外國語言發音-比例
                Me.Ent_APP1420.ITEM07_RATE = Me.ITEM07_RATE      '新聞政令宣導-比例
                Me.Ent_APP1420.ITEM08_RATE = Me.ITEM08_RATE      '教育文化-比例
                Me.Ent_APP1420.ITEM09_RATE = Me.ITEM09_RATE      '公共服務-比例
                Me.Ent_APP1420.ITEM10_RATE = Me.ITEM10_RATE      '大眾娛樂-比例
                Me.Ent_APP1420.INTERNAL_RATE = Me.INTERNAL_RATE      '本國製-比例
                Me.Ent_APP1420.EXTERNAL_RATE = Me.EXTERNAL_RATE      '非本國製-比例
                Me.Ent_APP1420.NEW_RATE = Me.NEW_RATE        '新播-比例
                Me.Ent_APP1420.FIRST_RATE = Me.FIRST_RATE        '首播-比例
                Me.Ent_APP1420.REPLAY_RATE = Me.REPLAY_RATE      '重播-比例
                Me.Ent_APP1420.INSOURCE_RATE = Me.INSOURCE_RATE      '自製-比例
                Me.Ent_APP1420.OUTSOURCE_RATE = Me.OUTSOURCE_RATE        '外購-比例


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1420.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1420.Update()

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
                Me.Ent_APP1420.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 刪除資料 ===
                If Me.Ent_APP1420.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1420.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年期
                Me.ProcessQueryCondition(condition, "=", "HOURS_TOTAL", Me.HOURS_TOTAL)      '播出總時數
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_ALL_RATE", Me.INTERNAL_ALL_RATE)      '自製節目比率-每日全時段
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_MASTER_RATE", Me.INTERNAL_MASTER_RATE)        '自製節目比率-每日主要時段
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_ALL_RATE", Me.EXTERNAL_ALL_RATE)      '外製節目比率-每日全時段
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_MASTER_RATE", Me.EXTERNAL_MASTER_RATE)        '外製節目比率-每日主要時段
                Me.ProcessQueryCondition(condition, "=", "JOIN_ALL_RATE", Me.JOIN_ALL_RATE)      '聯播節目比率-每日全時段
                Me.ProcessQueryCondition(condition, "=", "JOIN_MASTER_RATE", Me.JOIN_MASTER_RATE)        '聯播節目比率-每日主要時段
                Me.ProcessQueryCondition(condition, "=", "ITEM01_RATE", Me.ITEM01_RATE)      '國語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM02_RATE", Me.ITEM02_RATE)      '台語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM03_RATE", Me.ITEM03_RATE)      '客語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM04_RATE", Me.ITEM04_RATE)      '原住民語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM05_RATE", Me.ITEM05_RATE)      '英語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM06_RATE", Me.ITEM06_RATE)      '其他外國語言發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM07_RATE", Me.ITEM07_RATE)      '新聞政令宣導-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM08_RATE", Me.ITEM08_RATE)      '教育文化-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM09_RATE", Me.ITEM09_RATE)      '公共服務-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM10_RATE", Me.ITEM10_RATE)      '大眾娛樂-比例
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_RATE", Me.INTERNAL_RATE)      '本國製-比例
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_RATE", Me.EXTERNAL_RATE)      '非本國製-比例
                Me.ProcessQueryCondition(condition, "=", "NEW_RATE", Me.NEW_RATE)        '新播-比例
                Me.ProcessQueryCondition(condition, "=", "FIRST_RATE", Me.FIRST_RATE)        '首播-比例
                Me.ProcessQueryCondition(condition, "=", "REPLAY_RATE", Me.REPLAY_RATE)      '重播-比例
                Me.ProcessQueryCondition(condition, "=", "INSOURCE_RATE", Me.INSOURCE_RATE)      '自製-比例
                Me.ProcessQueryCondition(condition, "=", "OUTSOURCE_RATE", Me.OUTSOURCE_RATE)        '外購-比例

                Me.Ent_APP1420.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1420.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1420.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1420.Query()
                Else
                    result = Me.Ent_APP1420.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1420.TotalRowCount
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

