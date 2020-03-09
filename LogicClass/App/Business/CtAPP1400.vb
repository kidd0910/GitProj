'ProductName                 : TSBA 
'File Name					 : CtAPP1400 
'Description	             : CtAPP1400 APP1400 廣播事業申設報告
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/21  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1400
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1400 = New ENT_APP1400(Me.DBManager, Me.LogUtil)
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

#Region "TOPIC_SEQ "
        '' <summary>
        '' TOPIC_SEQ 
        '' </summary>
        Public Property TOPIC_SEQ() As String
            Get
                Return Me.PropertyMap("TOPIC_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOPIC_SEQ") = value
            End Set
        End Property
#End Region

#Region "TOPIC_ANSWER "
        '' <summary>
        '' TOPIC_ANSWER 
        '' </summary>
        Public Property TOPIC_ANSWER() As String
            Get
                Return Me.PropertyMap("TOPIC_ANSWER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOPIC_ANSWER") = value
            End Set
        End Property
#End Region

#Region "TOPIC_RESULT "
        '' <summary>
        '' TOPIC_RESULT 
        '' </summary>
        Public Property TOPIC_RESULT() As String
            Get
                Return Me.PropertyMap("TOPIC_RESULT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOPIC_RESULT") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_FLAG 意見反應管道-客服電話, 勾選為'Y'"
        '' <summary>
        '' SERVICE_TEL_FLAG 意見反應管道-客服電話, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_TEL_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_TEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_EMAIL_FLAG 意見反應管道-官網信箱, 勾選為'Y'"
        '' <summary>
        '' SERVICE_EMAIL_FLAG 意見反應管道-官網信箱, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_EMAIL_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_EMAIL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_EMAIL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_ACTIVE_FLAG 意見反應管道-交流活動, 勾選為'Y'"
        '' <summary>
        '' SERVICE_ACTIVE_FLAG 意見反應管道-交流活動, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_ACTIVE_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_ACTIVE_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_ACTIVE_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER_FLAG 意見反應管道-其他, 勾選為'Y'"
        '' <summary>
        '' SERVICE_OTHER_FLAG 意見反應管道-其他, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_OTHER_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_OTHER_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_OTHER_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER_DESC 意見反應管道-其他-說明, 勾選其他蝕本欄位必填"
        '' <summary>
        '' SERVICE_OTHER_DESC 意見反應管道-其他-說明, 勾選其他蝕本欄位必填
        '' </summary>
        Public Property SERVICE_OTHER_DESC() As String
            Get
                Return Me.PropertyMap("SERVICE_OTHER_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_OTHER_DESC") = value
            End Set
        End Property
#End Region

#Region "M_ACTIVE_NUMBER 主辦活動共計場次"
        '' <summary>
        '' M_ACTIVE_NUMBER 主辦活動共計場次
        '' </summary>
        Public Property M_ACTIVE_NUMBER() As String
            Get
                Return Me.PropertyMap("M_ACTIVE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("M_ACTIVE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "S_ACTIVE_NUMBER 協辦或參加其他活動共計場次"
        '' <summary>
        '' S_ACTIVE_NUMBER 協辦或參加其他活動共計場次
        '' </summary>
        Public Property S_ACTIVE_NUMBER() As String
            Get
                Return Me.PropertyMap("S_ACTIVE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_ACTIVE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL 電話服務專線號碼"
        '' <summary>
        '' SERVICE_TEL 電話服務專線號碼
        '' </summary>
        Public Property SERVICE_TEL() As String
            Get
                Return Me.PropertyMap("SERVICE_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TEL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_INTERNET_DESC 網路留言或其他反應管道"
        '' <summary>
        '' SERVICE_INTERNET_DESC 網路留言或其他反應管道
        '' </summary>
        Public Property SERVICE_INTERNET_DESC() As String
            Get
                Return Me.PropertyMap("SERVICE_INTERNET_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_INTERNET_DESC") = value
            End Set
        End Property
#End Region

#Region "AC_NAME 會計專職人員姓名"
        '' <summary>
        '' AC_NAME 會計專職人員姓名
        '' </summary>
        Public Property AC_NAME() As String
            Get
                Return Me.PropertyMap("AC_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("AC_NAME") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT1 電臺發射機及天線地點是否與核准者相符"
        '' <summary>
        '' DEVICE_RESULT1 電臺發射機及天線地點是否與核准者相符
        '' </summary>
        Public Property DEVICE_RESULT1() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT1") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT1_DESC 電臺發射機及天線地點是否與核准者相符-說明"
        '' <summary>
        '' DEVICE_RESULT1_DESC 電臺發射機及天線地點是否與核准者相符-說明
        '' </summary>
        Public Property DEVICE_RESULT1_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT2 天線鐵塔是否定期維護保養"
        '' <summary>
        '' DEVICE_RESULT2 天線鐵塔是否定期維護保養
        '' </summary>
        Public Property DEVICE_RESULT2() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT2") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT2_DESC 天線鐵塔是否定期維護保養-保養週期"
        '' <summary>
        '' DEVICE_RESULT2_DESC 天線鐵塔是否定期維護保養-保養週期
        '' </summary>
        Public Property DEVICE_RESULT2_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT3 避雷針及警示燈是否定期檢測並正常運作"
        '' <summary>
        '' DEVICE_RESULT3 避雷針及警示燈是否定期檢測並正常運作
        '' </summary>
        Public Property DEVICE_RESULT3() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT3") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT3_DESC 避雷針及警示燈是否定期檢測並正常運作-說明"
        '' <summary>
        '' DEVICE_RESULT3_DESC 避雷針及警示燈是否定期檢測並正常運作-說明
        '' </summary>
        Public Property DEVICE_RESULT3_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT3_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT4 天線鐵塔是否有安全防護措施"
        '' <summary>
        '' DEVICE_RESULT4 天線鐵塔是否有安全防護措施
        '' </summary>
        Public Property DEVICE_RESULT4() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT4") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT4_DESC 天線鐵塔是否有安全防護措施-說明"
        '' <summary>
        '' DEVICE_RESULT4_DESC 天線鐵塔是否有安全防護措施-說明
        '' </summary>
        Public Property DEVICE_RESULT4_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT4_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT4_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT5 發射機接地線是否定期檢測並符合規定"
        '' <summary>
        '' DEVICE_RESULT5 發射機接地線是否定期檢測並符合規定
        '' </summary>
        Public Property DEVICE_RESULT5() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT5")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT5") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT5_DESC 發射機接地線是否定期檢測並符合規定-說明"
        '' <summary>
        '' DEVICE_RESULT5_DESC 發射機接地線是否定期檢測並符合規定-說明
        '' </summary>
        Public Property DEVICE_RESULT5_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT5_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT5_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT6 發射機傳輸品質檢測是否合於標準"
        '' <summary>
        '' DEVICE_RESULT6 發射機傳輸品質檢測是否合於標準
        '' </summary>
        Public Property DEVICE_RESULT6() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT6")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT6") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT6_DESC 發射機傳輸品質檢測是否合於標準-說明"
        '' <summary>
        '' DEVICE_RESULT6_DESC 發射機傳輸品質檢測是否合於標準-說明
        '' </summary>
        Public Property DEVICE_RESULT6_DESC() As String
            Get
                Return Me.PropertyMap("DEVICE_RESULT6_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEVICE_RESULT6_DESC") = value
            End Set
        End Property
#End Region

#Region "MONITOR_FLAG1 是否以人員值班方式監控"
        '' <summary>
        '' MONITOR_FLAG1 是否以人員值班方式監控
        '' </summary>
        Public Property MONITOR_FLAG1() As String
            Get
                Return Me.PropertyMap("MONITOR_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MONITOR_FLAG1") = value
            End Set
        End Property
#End Region

#Region "MONITOR_FLAG2 是否以監控設備方式監控"
        '' <summary>
        '' MONITOR_FLAG2 是否以監控設備方式監控
        '' </summary>
        Public Property MONITOR_FLAG2() As String
            Get
                Return Me.PropertyMap("MONITOR_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MONITOR_FLAG2") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_FLAG1 是否設置工程部門並有正式編制之工程人員"
        '' <summary>
        '' MAINTAIN_FLAG1 是否設置工程部門並有正式編制之工程人員
        '' </summary>
        Public Property MAINTAIN_FLAG1() As String
            Get
                Return Me.PropertyMap("MAINTAIN_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAINTAIN_FLAG1") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_FLAG2 是否以外包方式維護工程設施"
        '' <summary>
        '' MAINTAIN_FLAG2 是否以外包方式維護工程設施
        '' </summary>
        Public Property MAINTAIN_FLAG2() As String
            Get
                Return Me.PropertyMap("MAINTAIN_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAINTAIN_FLAG2") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_ENGINEER_NUMBER 電臺設置工程部門並有正式編制之工程人員數量"
        '' <summary>
        '' MAINTAIN_ENGINEER_NUMBER 電臺設置工程部門並有正式編制之工程人員數量
        '' </summary>
        Public Property MAINTAIN_ENGINEER_NUMBER() As String
            Get
                Return Me.PropertyMap("MAINTAIN_ENGINEER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAINTAIN_ENGINEER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_RESULT1 過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'"
        '' <summary>
        '' IMPROVE_RESULT1 過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'
        '' </summary>
        Public Property IMPROVE_RESULT1() As String
            Get
                Return Me.PropertyMap("IMPROVE_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IMPROVE_RESULT1") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1400"
        ' <summary>Ent_APP1400</ summary>
        Private Property Ent_APP1400() As ENT_APP1400
            Get
                Return Me.PropertyMap("Ent_APP1400")
            End Get
            Set(ByVal value As ENT_APP1400)
                Me.PropertyMap("Ent_APP1400") = value
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
                Me.Ent_APP1400.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1400.TOPIC_SEQ = Me.TOPIC_SEQ      '
                Me.Ent_APP1400.TOPIC_ANSWER = Me.TOPIC_ANSWER        '
                Me.Ent_APP1400.TOPIC_RESULT = Me.TOPIC_RESULT        '
                Me.Ent_APP1400.SERVICE_TEL_FLAG = Me.SERVICE_TEL_FLAG        '意見反應管道-客服電話, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_EMAIL_FLAG = Me.SERVICE_EMAIL_FLAG        '意見反應管道-官網信箱, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_ACTIVE_FLAG = Me.SERVICE_ACTIVE_FLAG      '意見反應管道-交流活動, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_OTHER_FLAG = Me.SERVICE_OTHER_FLAG        '意見反應管道-其他, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_OTHER_DESC = Me.SERVICE_OTHER_DESC        '意見反應管道-其他-說明, 勾選其他蝕本欄位必填
                Me.Ent_APP1400.M_ACTIVE_NUMBER = Me.M_ACTIVE_NUMBER      '主辦活動共計場次
                Me.Ent_APP1400.S_ACTIVE_NUMBER = Me.S_ACTIVE_NUMBER      '協辦或參加其他活動共計場次
                Me.Ent_APP1400.SERVICE_TEL = Me.SERVICE_TEL      '電話服務專線號碼
                Me.Ent_APP1400.SERVICE_INTERNET_DESC = Me.SERVICE_INTERNET_DESC      '網路留言或其他反應管道
                Me.Ent_APP1400.AC_NAME = Me.AC_NAME      '會計專職人員姓名
                Me.Ent_APP1400.DEVICE_RESULT1 = Me.DEVICE_RESULT1        '電臺發射機及天線地點是否與核准者相符
                Me.Ent_APP1400.DEVICE_RESULT1_DESC = Me.DEVICE_RESULT1_DESC      '電臺發射機及天線地點是否與核准者相符-說明
                Me.Ent_APP1400.DEVICE_RESULT2 = Me.DEVICE_RESULT2        '天線鐵塔是否定期維護保養
                Me.Ent_APP1400.DEVICE_RESULT2_DESC = Me.DEVICE_RESULT2_DESC      '天線鐵塔是否定期維護保養-保養週期
                Me.Ent_APP1400.DEVICE_RESULT3 = Me.DEVICE_RESULT3        '避雷針及警示燈是否定期檢測並正常運作
                Me.Ent_APP1400.DEVICE_RESULT3_DESC = Me.DEVICE_RESULT3_DESC      '避雷針及警示燈是否定期檢測並正常運作-說明
                Me.Ent_APP1400.DEVICE_RESULT4 = Me.DEVICE_RESULT4        '天線鐵塔是否有安全防護措施
                Me.Ent_APP1400.DEVICE_RESULT4_DESC = Me.DEVICE_RESULT4_DESC      '天線鐵塔是否有安全防護措施-說明
                Me.Ent_APP1400.DEVICE_RESULT5 = Me.DEVICE_RESULT5        '發射機接地線是否定期檢測並符合規定
                Me.Ent_APP1400.DEVICE_RESULT5_DESC = Me.DEVICE_RESULT5_DESC      '發射機接地線是否定期檢測並符合規定-說明
                Me.Ent_APP1400.DEVICE_RESULT6 = Me.DEVICE_RESULT6        '發射機傳輸品質檢測是否合於標準
                Me.Ent_APP1400.DEVICE_RESULT6_DESC = Me.DEVICE_RESULT6_DESC      '發射機傳輸品質檢測是否合於標準-說明
                Me.Ent_APP1400.MONITOR_FLAG1 = Me.MONITOR_FLAG1      '是否以人員值班方式監控
                Me.Ent_APP1400.MONITOR_FLAG2 = Me.MONITOR_FLAG2      '是否以監控設備方式監控
                Me.Ent_APP1400.MAINTAIN_FLAG1 = Me.MAINTAIN_FLAG1        '是否設置工程部門並有正式編制之工程人員
                Me.Ent_APP1400.MAINTAIN_FLAG2 = Me.MAINTAIN_FLAG2        '是否以外包方式維護工程設施
                Me.Ent_APP1400.MAINTAIN_ENGINEER_NUMBER = Me.MAINTAIN_ENGINEER_NUMBER        '電臺設置工程部門並有正式編制之工程人員數量
                Me.Ent_APP1400.IMPROVE_RESULT1 = Me.IMPROVE_RESULT1      '過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1400.Insert()

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
                'Me.Ent_APP1400.CASE_NO = Me.CASE_NO      '案件編號
                'Me.Ent_APP1400.TOPIC_SEQ = Me.TOPIC_SEQ      '
                Me.Ent_APP1400.TOPIC_ANSWER = Me.TOPIC_ANSWER        '
                Me.Ent_APP1400.TOPIC_RESULT = Me.TOPIC_RESULT        '
                Me.Ent_APP1400.SERVICE_TEL_FLAG = Me.SERVICE_TEL_FLAG        '意見反應管道-客服電話, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_EMAIL_FLAG = Me.SERVICE_EMAIL_FLAG        '意見反應管道-官網信箱, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_ACTIVE_FLAG = Me.SERVICE_ACTIVE_FLAG      '意見反應管道-交流活動, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_OTHER_FLAG = Me.SERVICE_OTHER_FLAG        '意見反應管道-其他, 勾選為'Y'
                Me.Ent_APP1400.SERVICE_OTHER_DESC = Me.SERVICE_OTHER_DESC        '意見反應管道-其他-說明, 勾選其他蝕本欄位必填
                Me.Ent_APP1400.M_ACTIVE_NUMBER = Me.M_ACTIVE_NUMBER      '主辦活動共計場次
                Me.Ent_APP1400.S_ACTIVE_NUMBER = Me.S_ACTIVE_NUMBER      '協辦或參加其他活動共計場次
                Me.Ent_APP1400.SERVICE_TEL = Me.SERVICE_TEL      '電話服務專線號碼
                Me.Ent_APP1400.SERVICE_INTERNET_DESC = Me.SERVICE_INTERNET_DESC      '網路留言或其他反應管道
                Me.Ent_APP1400.AC_NAME = Me.AC_NAME      '會計專職人員姓名
                Me.Ent_APP1400.DEVICE_RESULT1 = Me.DEVICE_RESULT1        '電臺發射機及天線地點是否與核准者相符
                Me.Ent_APP1400.DEVICE_RESULT1_DESC = Me.DEVICE_RESULT1_DESC      '電臺發射機及天線地點是否與核准者相符-說明
                Me.Ent_APP1400.DEVICE_RESULT2 = Me.DEVICE_RESULT2        '天線鐵塔是否定期維護保養
                Me.Ent_APP1400.DEVICE_RESULT2_DESC = Me.DEVICE_RESULT2_DESC      '天線鐵塔是否定期維護保養-保養週期
                Me.Ent_APP1400.DEVICE_RESULT3 = Me.DEVICE_RESULT3        '避雷針及警示燈是否定期檢測並正常運作
                Me.Ent_APP1400.DEVICE_RESULT3_DESC = Me.DEVICE_RESULT3_DESC      '避雷針及警示燈是否定期檢測並正常運作-說明
                Me.Ent_APP1400.DEVICE_RESULT4 = Me.DEVICE_RESULT4        '天線鐵塔是否有安全防護措施
                Me.Ent_APP1400.DEVICE_RESULT4_DESC = Me.DEVICE_RESULT4_DESC      '天線鐵塔是否有安全防護措施-說明
                Me.Ent_APP1400.DEVICE_RESULT5 = Me.DEVICE_RESULT5        '發射機接地線是否定期檢測並符合規定
                Me.Ent_APP1400.DEVICE_RESULT5_DESC = Me.DEVICE_RESULT5_DESC      '發射機接地線是否定期檢測並符合規定-說明
                Me.Ent_APP1400.DEVICE_RESULT6 = Me.DEVICE_RESULT6        '發射機傳輸品質檢測是否合於標準
                Me.Ent_APP1400.DEVICE_RESULT6_DESC = Me.DEVICE_RESULT6_DESC      '發射機傳輸品質檢測是否合於標準-說明
                Me.Ent_APP1400.MONITOR_FLAG1 = Me.MONITOR_FLAG1      '是否以人員值班方式監控
                Me.Ent_APP1400.MONITOR_FLAG2 = Me.MONITOR_FLAG2      '是否以監控設備方式監控
                Me.Ent_APP1400.MAINTAIN_FLAG1 = Me.MAINTAIN_FLAG1        '是否設置工程部門並有正式編制之工程人員
                Me.Ent_APP1400.MAINTAIN_FLAG2 = Me.MAINTAIN_FLAG2        '是否以外包方式維護工程設施
                Me.Ent_APP1400.MAINTAIN_ENGINEER_NUMBER = Me.MAINTAIN_ENGINEER_NUMBER        '電臺設置工程部門並有正式編制之工程人員數量
                Me.Ent_APP1400.IMPROVE_RESULT1 = Me.IMPROVE_RESULT1      '過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)
                Me.Ent_APP1400.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1400.Update()

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
                Me.Ent_APP1400.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1400.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1400.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "TOPIC_SEQ", Me.TOPIC_SEQ)      '
                Me.ProcessQueryCondition(condition, "=", "TOPIC_ANSWER", Me.TOPIC_ANSWER)        '
                Me.ProcessQueryCondition(condition, "=", "TOPIC_RESULT", Me.TOPIC_RESULT)        '
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL_FLAG", Me.SERVICE_TEL_FLAG)        '意見反應管道-客服電話, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SERVICE_EMAIL_FLAG", Me.SERVICE_EMAIL_FLAG)        '意見反應管道-官網信箱, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SERVICE_ACTIVE_FLAG", Me.SERVICE_ACTIVE_FLAG)      '意見反應管道-交流活動, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SERVICE_OTHER_FLAG", Me.SERVICE_OTHER_FLAG)        '意見反應管道-其他, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SERVICE_OTHER_DESC", Me.SERVICE_OTHER_DESC)       '意見反應管道-其他-說明, 勾選其他蝕本欄位必填
                Me.ProcessQueryCondition(condition, "=", "M_ACTIVE_NUMBER", Me.M_ACTIVE_NUMBER)      '主辦活動共計場次
                Me.ProcessQueryCondition(condition, "=", "S_ACTIVE_NUMBER", Me.S_ACTIVE_NUMBER)      '協辦或參加其他活動共計場次
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL", Me.SERVICE_TEL)      '電話服務專線號碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "SERVICE_INTERNET_DESC", Me.SERVICE_INTERNET_DESC)         '網路留言或其他反應管道
                Me.ProcessQueryCondition(condition, "%LIKE%", "AC_NAME", Me.AC_NAME)         '會計專職人員姓名
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT1", Me.DEVICE_RESULT1)        '電臺發射機及天線地點是否與核准者相符
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT1_DESC", Me.DEVICE_RESULT1_DESC)         '電臺發射機及天線地點是否與核准者相符-說明
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT2", Me.DEVICE_RESULT2)        '天線鐵塔是否定期維護保養
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT2_DESC", Me.DEVICE_RESULT2_DESC)         '天線鐵塔是否定期維護保養-保養週期
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT3", Me.DEVICE_RESULT3)        '避雷針及警示燈是否定期檢測並正常運作
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT3_DESC", Me.DEVICE_RESULT3_DESC)         '避雷針及警示燈是否定期檢測並正常運作-說明
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT4", Me.DEVICE_RESULT4)        '天線鐵塔是否有安全防護措施
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT4_DESC", Me.DEVICE_RESULT4_DESC)         '天線鐵塔是否有安全防護措施-說明
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT5", Me.DEVICE_RESULT5)        '發射機接地線是否定期檢測並符合規定
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT5_DESC", Me.DEVICE_RESULT5_DESC)         '發射機接地線是否定期檢測並符合規定-說明
                Me.ProcessQueryCondition(condition, "=", "DEVICE_RESULT6", Me.DEVICE_RESULT6)        '發射機傳輸品質檢測是否合於標準
                Me.ProcessQueryCondition(condition, "%LIKE%", "DEVICE_RESULT6_DESC", Me.DEVICE_RESULT6_DESC)         '發射機傳輸品質檢測是否合於標準-說明
                Me.ProcessQueryCondition(condition, "=", "MONITOR_FLAG1", Me.MONITOR_FLAG1)      '是否以人員值班方式監控
                Me.ProcessQueryCondition(condition, "=", "MONITOR_FLAG2", Me.MONITOR_FLAG2)      '是否以監控設備方式監控
                Me.ProcessQueryCondition(condition, "=", "MAINTAIN_FLAG1", Me.MAINTAIN_FLAG1)        '是否設置工程部門並有正式編制之工程人員
                Me.ProcessQueryCondition(condition, "=", "MAINTAIN_FLAG2", Me.MAINTAIN_FLAG2)        '是否以外包方式維護工程設施
                Me.ProcessQueryCondition(condition, "=", "MAINTAIN_ENGINEER_NUMBER", Me.MAINTAIN_ENGINEER_NUMBER)        '電臺設置工程部門並有正式編制之工程人員數量
                Me.ProcessQueryCondition(condition, "=", "IMPROVE_RESULT1", Me.IMPROVE_RESULT1)      '過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APP1400.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1400.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1400.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1400.Query()
                Else
                    result = Me.Ent_APP1400.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1400.TotalRowCount
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

