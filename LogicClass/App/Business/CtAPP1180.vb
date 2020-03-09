'ProductName                 : TSBA 
'File Name					 : CtAPP1180 
'Description	             : CtAPP1180 上架統計表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/18         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1180
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1180 = New ENT_APP1180(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號, 共用"
        '' <summary>
        '' CASE_NO 案件編號, 共用
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

#Region "CHSYS_TYPE 系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星"
        '' <summary>
        '' CHSYS_TYPE 系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星
        '' </summary>
        Public Property CHSYS_TYPE() As String
            Get
                Return Me.PropertyMap("CHSYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHSYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYSTEM_OPERATOR 有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'"
        '' <summary>
        '' SYSTEM_OPERATOR 有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
        '' </summary>
        Public Property SYSTEM_OPERATOR() As String
            Get
                Return Me.PropertyMap("SYSTEM_OPERATOR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYSTEM_OPERATOR") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_CHANNEL_LOCATION 類比系統上架情形-頻道位置"
        '' <summary>
        '' ANALOGY_CHANNEL_LOCATION 類比系統上架情形-頻道位置
        '' </summary>
        Public Property ANALOGY_CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("ANALOGY_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SUBSCRIBER_NUMBER 類比系統上架情形-訂戶數"
        '' <summary>
        '' ANALOGY_SUBSCRIBER_NUMBER 類比系統上架情形-訂戶數
        '' </summary>
        Public Property ANALOGY_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("ANALOGY_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_CHANNEL_LOCATION 數位系統上架情形-頻道位置"
        '' <summary>
        '' DIGIT_CHANNEL_LOCATION 數位系統上架情形-頻道位置
        '' </summary>
        Public Property DIGIT_CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("DIGIT_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SUBSCRIBER_NUMBER 數位系統上架情形-訂戶數"
        '' <summary>
        '' DIGIT_SUBSCRIBER_NUMBER 數位系統上架情形-訂戶數
        '' </summary>
        Public Property DIGIT_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("DIGIT_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_LOCATION 頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用"
        '' <summary>
        '' CHANNEL_LOCATION 頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用
        '' </summary>
        Public Property CHANNEL_LOCATION() As String
            Get
                Return Me.PropertyMap("CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBER_NUMBER 訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用"
        '' <summary>
        '' SUBSCRIBER_NUMBER 訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用
        '' </summary>
        Public Property SUBSCRIBER_NUMBER() As String
            Get
                Return Me.PropertyMap("SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBSCRIBER_NUMBER") = value
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

#Region "Ent_APP1180"
        ' <summary>Ent_APP1180</ summary>
        Private Property Ent_APP1180() As ENT_APP1180
            Get
                Return Me.PropertyMap("Ent_APP1180")
            End Get
            Set(ByVal value As ENT_APP1180)
                Me.PropertyMap("Ent_APP1180") = value
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
                Me.Ent_APP1180.CASE_NO = Me.CASE_NO      '案件編號, 共用
                Me.Ent_APP1180.CHSYS_TYPE = Me.CHSYS_TYPE        '系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星
                Me.Ent_APP1180.SYSTEM_OPERATOR = Me.SYSTEM_OPERATOR      '有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.Ent_APP1180.ANALOGY_CHANNEL_LOCATION = Me.ANALOGY_CHANNEL_LOCATION        '類比系統上架情形-頻道位置
                Me.Ent_APP1180.ANALOGY_SUBSCRIBER_NUMBER = Me.ANALOGY_SUBSCRIBER_NUMBER      '類比系統上架情形-訂戶數
                Me.Ent_APP1180.DIGIT_CHANNEL_LOCATION = Me.DIGIT_CHANNEL_LOCATION        '數位系統上架情形-頻道位置
                Me.Ent_APP1180.DIGIT_SUBSCRIBER_NUMBER = Me.DIGIT_SUBSCRIBER_NUMBER      '數位系統上架情形-訂戶數
                Me.Ent_APP1180.CHANNEL_LOCATION = Me.CHANNEL_LOCATION        '頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用
                Me.Ent_APP1180.SUBSCRIBER_NUMBER = Me.SUBSCRIBER_NUMBER      '訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1180.Insert()

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
                Me.Ent_APP1180.CASE_NO = Me.CASE_NO      '案件編號, 共用
                Me.Ent_APP1180.CHSYS_TYPE = Me.CHSYS_TYPE        '系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星
                Me.Ent_APP1180.SYSTEM_OPERATOR = Me.SYSTEM_OPERATOR      '有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.Ent_APP1180.ANALOGY_CHANNEL_LOCATION = Me.ANALOGY_CHANNEL_LOCATION        '類比系統上架情形-頻道位置
                Me.Ent_APP1180.ANALOGY_SUBSCRIBER_NUMBER = Me.ANALOGY_SUBSCRIBER_NUMBER      '類比系統上架情形-訂戶數
                Me.Ent_APP1180.DIGIT_CHANNEL_LOCATION = Me.DIGIT_CHANNEL_LOCATION        '數位系統上架情形-頻道位置
                Me.Ent_APP1180.DIGIT_SUBSCRIBER_NUMBER = Me.DIGIT_SUBSCRIBER_NUMBER      '數位系統上架情形-訂戶數
                Me.Ent_APP1180.CHANNEL_LOCATION = Me.CHANNEL_LOCATION        '頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用
                Me.Ent_APP1180.SUBSCRIBER_NUMBER = Me.SUBSCRIBER_NUMBER      '訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1180.Update()

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
        '' 處理刪除資料動作 by CASE_NO
        '' </summary>
        Public Sub DoDeleteByCASE_NO()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                If String.IsNullOrEmpty(Me.CHSYS_TYPE) Then
                    faileArguments.Add("CHSYS_TYPE")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE)
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())

                '=== 刪除資料 ===
                If Me.Ent_APP1180.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1180.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub

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
                Me.Ent_APP1180.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1180.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1180.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, 共用
                Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE)        '系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星
                Me.ProcessQueryCondition(condition, "=", "SYSTEM_OPERATOR", Me.SYSTEM_OPERATOR)      '有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_CHANNEL_LOCATION", Me.ANALOGY_CHANNEL_LOCATION)        '類比系統上架情形-頻道位置
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SUBSCRIBER_NUMBER", Me.ANALOGY_SUBSCRIBER_NUMBER)      '類比系統上架情形-訂戶數
                Me.ProcessQueryCondition(condition, "=", "DIGIT_CHANNEL_LOCATION", Me.DIGIT_CHANNEL_LOCATION)        '數位系統上架情形-頻道位置
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SUBSCRIBER_NUMBER", Me.DIGIT_SUBSCRIBER_NUMBER)      '數位系統上架情形-訂戶數
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_LOCATION", Me.CHANNEL_LOCATION)        '頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用
                Me.ProcessQueryCondition(condition, "=", "SUBSCRIBER_NUMBER", Me.SUBSCRIBER_NUMBER)      '訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用

                condition.Append(Me.QUERY_COND)

                Me.Ent_APP1180.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1180.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1180.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1180.QueryMergeData()
                Else
                    result = Me.Ent_APP1180.QueryMergeData(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1180.TotalRowCount
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

