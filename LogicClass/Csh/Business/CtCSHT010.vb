'ProductName                 : TSBA 
'File Name					 : CtCSHT010 
'Description	             : CtCSHT010 繳款紀錄
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/27         Source Create
'---------------------------------------------------------------------------

Imports Csh.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Csh.Business
    Partial Public Class CtCSHT010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_CSHT010 = New ENT_CSHT010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號, INSERT時寫入, 本欄位不能修改"
        '' <summary>
        '' CASE_NO 案件編號, INSERT時寫入, 本欄位不能修改
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

#Region "YEAR 年度, INSERT時寫入"
        '' <summary>
        '' YEAR 年度, INSERT時寫入
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

#Region "ITEM_TYPE 繳款項目類別, INSERT時寫入, 本欄位不能修改, 1: 未定義 2: 審查費繳款單 3: 審驗費繳款單 4. 審定證明費繳款單"
        '' <summary>
        '' ITEM_TYPE 繳款項目類別, INSERT時寫入, 本欄位不能修改, 1: 未定義 2: 審查費繳款單 3: 審驗費繳款單 4. 審定證明費繳款單
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

#Region "PAYMENT_ACNT 繳款代碼, 由歲入系統寫入"
        '' <summary>
        '' PAYMENT_ACNT 繳款代碼, 由歲入系統寫入
        '' </summary>
        Public Property PAYMENT_ACNT() As String
            Get
                Return Me.PropertyMap("PAYMENT_ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAYMENT_ACNT") = value
            End Set
        End Property
#End Region

#Region "COM_PKNO 收件機構名稱, REF. APPL010.PKNO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」"
        '' <summary>
        '' COM_PKNO 收件機構名稱, REF. APPL010.PKNO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.PropertyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "INFORM_DATE 通知單日期, 本欄位不能修改"
        '' <summary>
        '' INFORM_DATE 通知單日期, 本欄位不能修改
        '' </summary>
        Public Property INFORM_DATE() As String
            Get
                Return Me.PropertyMap("INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INFORM_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_CODE 費用代碼, REF. SYST010.SYS_KEY='PAY_CODE'"
        '' <summary>
        '' PAY_CODE 費用代碼, REF. SYST010.SYS_KEY='PAY_CODE'
        '' </summary>
        Public Property PAY_CODE() As String
            Get
                Return Me.PropertyMap("PAY_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_CODE") = value
            End Set
        End Property
#End Region

#Region "PAY_NAME 費用名稱, 紀錄存檔時REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_NAME"
        '' <summary>
        '' PAY_NAME 費用名稱, 紀錄存檔時REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_NAME
        '' </summary>
        Public Property PAY_NAME() As String
            Get
                Return Me.PropertyMap("PAY_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_NAME") = value
            End Set
        End Property
#End Region

#Region "PAY_COUNT 數量"
        '' <summary>
        '' PAY_COUNT 數量
        '' </summary>
        Public Property PAY_COUNT() As String
            Get
                Return Me.PropertyMap("PAY_COUNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_COUNT") = value
            End Set
        End Property
#End Region

#Region "PAY_AMT 費用, 本欄位不能修改, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_RSV1, 要把SYST010.SYS_RSV1的值由字串轉成數字"
        '' <summary>
        '' PAY_AMT 費用, 本欄位不能修改, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_RSV1, 要把SYST010.SYS_RSV1的值由字串轉成數字
        '' </summary>
        Public Property PAY_AMT() As String
            Get
                Return Me.PropertyMap("PAY_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_AMT") = value
            End Set
        End Property
#End Region

#Region "PAY_USER 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」"
        '' <summary>
        '' PAY_USER 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
        '' </summary>
        Public Property PAY_USER() As String
            Get
                Return Me.PropertyMap("PAY_USER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_USER") = value
            End Set
        End Property
#End Region

#Region "PAY_BUS_NO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」"
        '' <summary>
        '' PAY_BUS_NO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
        '' </summary>
        Public Property PAY_BUS_NO() As String
            Get
                Return Me.PropertyMap("PAY_BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_BUS_NO") = value
            End Set
        End Property
#End Region

#Region "PAY_TEL 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」"
        '' <summary>
        '' PAY_TEL 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
        '' </summary>
        Public Property PAY_TEL() As String
            Get
                Return Me.PropertyMap("PAY_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_TEL") = value
            End Set
        End Property
#End Region

#Region "DATE_LEN "
        '' <summary>
        '' DATE_LEN 
        '' </summary>
        Public Property DATE_LEN() As String
            Get
                Return Me.PropertyMap("DATE_LEN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATE_LEN") = value
            End Set
        End Property
#End Region

#Region "PAY_DEADLINE 繳納期限=通知單日期（收件日期）+繳納期限天數"
        '' <summary>
        '' PAY_DEADLINE 繳納期限=通知單日期（收件日期）+繳納期限天數
        '' </summary>
        Public Property PAY_DEADLINE() As String
            Get
                Return Me.PropertyMap("PAY_DEADLINE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_DEADLINE") = value
            End Set
        End Property
#End Region

#Region "PAY_DATE 使用者登錄的繳費完成日期, 本欄位不能修改, 由「審查費待繳案件」、「審驗費待繳案件」、「開立審定證明」功能寫入, 資料來自於:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE"
        '' <summary>
        '' PAY_DATE 使用者登錄的繳費完成日期, 本欄位不能修改, 由「審查費待繳案件」、「審驗費待繳案件」、「開立審定證明」功能寫入, 資料來自於:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
        '' </summary>
        Public Property PAY_DATE() As String
            Get
                Return Me.PropertyMap("PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "FINAL_PAY_DATE 由歲入系統寫入"
        '' <summary>
        '' FINAL_PAY_DATE 由歲入系統寫入
        '' </summary>
        Public Property FINAL_PAY_DATE() As String
            Get
                Return Me.PropertyMap("FINAL_PAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FINAL_PAY_DATE") = value
            End Set
        End Property
#End Region

#Region "PAY_STATUS 由歲入系統寫入, REF. SYST010.SYS_KEY='PAY_STATUS', 1:待收, 2:整批核銷, 3:單筆核銷, 4:預繳核收, 5:分繳中, 6:分繳完畢, 7:暫繳, A:待退, B:已退"
        '' <summary>
        '' PAY_STATUS 由歲入系統寫入, REF. SYST010.SYS_KEY='PAY_STATUS', 1:待收, 2:整批核銷, 3:單筆核銷, 4:預繳核收, 5:分繳中, 6:分繳完畢, 7:暫繳, A:待退, B:已退
        '' </summary>
        Public Property PAY_STATUS() As String
            Get
                Return Me.PropertyMap("PAY_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_STATUS 由「案件請款登錄」功能寫入, 'Y': 設定為已請款, ': 未請款"
        '' <summary>
        '' PLEASE_STATUS 由「案件請款登錄」功能寫入, 'Y': 設定為已請款, ': 未請款
        '' </summary>
        Public Property PLEASE_STATUS() As String
            Get
                Return Me.PropertyMap("PLEASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLEASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "PLEASE_DATE 由「案件請款登錄」功能寫入"
        '' <summary>
        '' PLEASE_DATE 由「案件請款登錄」功能寫入
        '' </summary>
        Public Property PLEASE_DATE() As String
            Get
                Return Me.PropertyMap("PLEASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLEASE_DATE") = value
            End Set
        End Property
#End Region

#Region "REMARK 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」"
        '' <summary>
        '' REMARK 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
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

#Region "CAN_FLAG 原始設計是'Y': 註銷, 由歲入系統寫入, 但為避免有程式漏改, 因此定義如下:使用者在本系統申請註銷時, 本欄位寫入'Y', 歲入系統確定註銷時, 本欄位也會更新為'Y', 同時CAN_FLAG_DATE會寫入當天日期, 做為判別歲入系統回寫依據.本欄位為'代表資料有效, 本欄位等於'Y'表示該筆資料註銷"
        '' <summary>
        '' CAN_FLAG 原始設計是'Y': 註銷, 由歲入系統寫入, 但為避免有程式漏改, 因此定義如下:使用者在本系統申請註銷時, 本欄位寫入'Y', 歲入系統確定註銷時, 本欄位也會更新為'Y', 同時CAN_FLAG_DATE會寫入當天日期, 做為判別歲入系統回寫依據.本欄位為'代表資料有效, 本欄位等於'Y'表示該筆資料註銷
        '' </summary>
        Public Property CAN_FLAG() As String
            Get
                Return Me.PropertyMap("CAN_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CAN_FLAG") = value
            End Set
        End Property
#End Region

#Region "CANCEL_CAUSE 由歲入系統寫入"
        '' <summary>
        '' CANCEL_CAUSE 由歲入系統寫入
        '' </summary>
        Public Property CANCEL_CAUSE() As String
            Get
                Return Me.PropertyMap("CANCEL_CAUSE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CANCEL_CAUSE") = value
            End Set
        End Property
#End Region

#Region "CAN_FLAG_DATE 同步稅入系統資料時寫入，本欄位有資料表示該帳單已經確認註銷。"
        '' <summary>
        '' CAN_FLAG_DATE 同步稅入系統資料時寫入，本欄位有資料表示該帳單已經確認註銷。
        '' </summary>
        Public Property CAN_FLAG_DATE() As String
            Get
                Return Me.PropertyMap("CAN_FLAG_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CAN_FLAG_DATE") = value
            End Set
        End Property
#End Region

#Region "APPL021_PKNO REF. APPL021.PKNO若帳單試開審定證明時產生者，要紀錄審定證明的PKNO才能找到資料"
        '' <summary>
        '' APPL021_PKNO REF. APPL021.PKNO若帳單試開審定證明時產生者，要紀錄審定證明的PKNO才能找到資料
        '' </summary>
        Public Property APPL021_PKNO() As String
            Get
                Return Me.PropertyMap("APPL021_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPL021_PKNO") = value
            End Set
        End Property
#End Region

#Region "RE_PRINT_COUNT "
        '' <summary>
        '' RE_PRINT_COUNT 
        '' </summary>
        Public Property RE_PRINT_COUNT() As String
            Get
                Return Me.PropertyMap("RE_PRINT_COUNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RE_PRINT_COUNT") = value
            End Set
        End Property
#End Region

#Region "SYNC_DATE "
        '' <summary>
        '' SYNC_DATE 
        '' </summary>
        Public Property SYNC_DATE() As String
            Get
                Return Me.PropertyMap("SYNC_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYNC_DATE") = value
            End Set
        End Property
#End Region

#Region "Ent_CSHT010"
        ' <summary>Ent_CSHT010</ summary>
        Private Property Ent_CSHT010() As ENT_CSHT010
            Get
                Return Me.PropertyMap("Ent_CSHT010")
            End Get
            Set(ByVal value As ENT_CSHT010)
                Me.PropertyMap("Ent_CSHT010") = value
            End Set
        End Property
#End Region

#Region "S_INFORM_DATE 開單日期"
        ''' <summary>
        ''' S_INFORM_DATE 開單日期
        ''' </summary>
        Public Property S_INFORM_DATE As String
            Get
                Return Me.PropertyMap("S_INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_INFORM_DATE") = value
            End Set
        End Property
#End Region

#Region "E_INFORM_DATE 開單日期"
        ''' <summary>
        ''' E_INFORM_DATE 開單日期
        ''' </summary>
        Public Property E_INFORM_DATE As String
            Get
                Return Me.PropertyMap("E_INFORM_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("E_INFORM_DATE") = value
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
                Me.Ent_CSHT010.CASE_NO = Me.CASE_NO      '案件編號, INSERT時寫入, 本欄位不能修改
                Me.Ent_CSHT010.YEAR = Me.YEAR        '年度, INSERT時寫入
                Me.Ent_CSHT010.ITEM_TYPE = Me.ITEM_TYPE      '繳款項目類別, INSERT時寫入, 本欄位不能修改, 1: 未定義 2: 審查費繳款單 3: 審驗費繳款單 4. 審定證明費繳款單
                Me.Ent_CSHT010.PAYMENT_ACNT = Me.PAYMENT_ACNT        '繳款代碼, 由歲入系統寫入
                Me.Ent_CSHT010.COM_PKNO = Me.COM_PKNO        '收件機構名稱, REF. APPL010.PKNO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.INFORM_DATE = Me.INFORM_DATE      '通知單日期, 本欄位不能修改
                Me.Ent_CSHT010.PAY_CODE = Me.PAY_CODE        '費用代碼, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.Ent_CSHT010.PAY_NAME = Me.PAY_NAME        '費用名稱, 紀錄存檔時REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_NAME
                Me.Ent_CSHT010.PAY_COUNT = Me.PAY_COUNT      '數量
                Me.Ent_CSHT010.PAY_AMT = Me.PAY_AMT      '費用, 本欄位不能修改, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_RSV1, 要把SYST010.SYS_RSV1的值由字串轉成數字
                Me.Ent_CSHT010.PAY_USER = Me.PAY_USER        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.PAY_BUS_NO = Me.PAY_BUS_NO        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.PAY_TEL = Me.PAY_TEL      '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.DATE_LEN = Me.DATE_LEN        '
                Me.Ent_CSHT010.PAY_DEADLINE = Me.PAY_DEADLINE        '繳納期限=通知單日期（收件日期）+繳納期限天數
                Me.Ent_CSHT010.PAY_DATE = Me.PAY_DATE        '使用者登錄的繳費完成日期, 本欄位不能修改, 由「審查費待繳案件」、「審驗費待繳案件」、「開立審定證明」功能寫入, 資料來自於:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.Ent_CSHT010.FINAL_PAY_DATE = Me.FINAL_PAY_DATE        '由歲入系統寫入
                Me.Ent_CSHT010.PAY_STATUS = Me.PAY_STATUS        '由歲入系統寫入, REF. SYST010.SYS_KEY='PAY_STATUS', 1:待收, 2:整批核銷, 3:單筆核銷, 4:預繳核收, 5:分繳中, 6:分繳完畢, 7:暫繳, A:待退, B:已退
                Me.Ent_CSHT010.PLEASE_STATUS = Me.PLEASE_STATUS      '由「案件請款登錄」功能寫入, 'Y': 設定為已請款, ': 未請款
                Me.Ent_CSHT010.PLEASE_DATE = Me.PLEASE_DATE      '由「案件請款登錄」功能寫入
                Me.Ent_CSHT010.REMARK = Me.REMARK        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.CAN_FLAG = Me.CAN_FLAG        '原始設計是'Y': 註銷, 由歲入系統寫入, 但為避免有程式漏改, 因此定義如下:使用者在本系統申請註銷時, 本欄位寫入'Y', 歲入系統確定註銷時, 本欄位也會更新為'Y', 同時CAN_FLAG_DATE會寫入當天日期, 做為判別歲入系統回寫依據.本欄位為'代表資料有效, 本欄位等於'Y'表示該筆資料註銷
                Me.Ent_CSHT010.CANCEL_CAUSE = Me.CANCEL_CAUSE        '由歲入系統寫入
                Me.Ent_CSHT010.CAN_FLAG_DATE = Me.CAN_FLAG_DATE      '同步稅入系統資料時寫入，本欄位有資料表示該帳單已經確認註銷。
                Me.Ent_CSHT010.APPL021_PKNO = Me.APPL021_PKNO        'REF. APPL021.PKNO若帳單試開審定證明時產生者，要紀錄審定證明的PKNO才能找到資料
                Me.Ent_CSHT010.RE_PRINT_COUNT = Me.RE_PRINT_COUNT        '
                Me.Ent_CSHT010.SYNC_DATE = Me.SYNC_DATE      '


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_CSHT010.Insert()

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
                'Dim faileArguments As ArrayList = New ArrayList()
                'If String.IsNullOrEmpty(Me.PKNO) Then
                '    faileArguments.Add("PKNO")
                'End If

                'If faileArguments.Count > 0 Then
                '    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                'End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Me.Ent_CSHT010.CASE_NO = Me.CASE_NO      '案件編號, INSERT時寫入, 本欄位不能修改
                Me.Ent_CSHT010.YEAR = Me.YEAR        '年度, INSERT時寫入
                Me.Ent_CSHT010.ITEM_TYPE = Me.ITEM_TYPE      '繳款項目類別, INSERT時寫入, 本欄位不能修改, 1: 未定義 2: 審查費繳款單 3: 審驗費繳款單 4. 審定證明費繳款單
                'Me.Ent_CSHT010.PAYMENT_ACNT = Me.PAYMENT_ACNT        '繳款代碼, 由歲入系統寫入
                Me.Ent_CSHT010.COM_PKNO = Me.COM_PKNO        '收件機構名稱, REF. APPL010.PKNO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.INFORM_DATE = Me.INFORM_DATE      '通知單日期, 本欄位不能修改
                Me.Ent_CSHT010.PAY_CODE = Me.PAY_CODE        '費用代碼, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.Ent_CSHT010.PAY_NAME = Me.PAY_NAME        '費用名稱, 紀錄存檔時REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_NAME
                Me.Ent_CSHT010.PAY_COUNT = Me.PAY_COUNT      '數量
                Me.Ent_CSHT010.PAY_AMT = Me.PAY_AMT      '費用, 本欄位不能修改, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_RSV1, 要把SYST010.SYS_RSV1的值由字串轉成數字
                Me.Ent_CSHT010.PAY_USER = Me.PAY_USER        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.PAY_BUS_NO = Me.PAY_BUS_NO        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.PAY_TEL = Me.PAY_TEL      '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.DATE_LEN = Me.DATE_LEN        '
                Me.Ent_CSHT010.PAY_DEADLINE = Me.PAY_DEADLINE        '繳納期限=通知單日期（收件日期）+繳納期限天數
                Me.Ent_CSHT010.PAY_DATE = Me.PAY_DATE        '使用者登錄的繳費完成日期, 本欄位不能修改, 由「審查費待繳案件」、「審驗費待繳案件」、「開立審定證明」功能寫入, 資料來自於:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.Ent_CSHT010.FINAL_PAY_DATE = Me.FINAL_PAY_DATE        '由歲入系統寫入
                Me.Ent_CSHT010.PAY_STATUS = Me.PAY_STATUS        '由歲入系統寫入, REF. SYST010.SYS_KEY='PAY_STATUS', 1:待收, 2:整批核銷, 3:單筆核銷, 4:預繳核收, 5:分繳中, 6:分繳完畢, 7:暫繳, A:待退, B:已退
                Me.Ent_CSHT010.PLEASE_STATUS = Me.PLEASE_STATUS      '由「案件請款登錄」功能寫入, 'Y': 設定為已請款, ': 未請款
                Me.Ent_CSHT010.PLEASE_DATE = Me.PLEASE_DATE      '由「案件請款登錄」功能寫入
                Me.Ent_CSHT010.REMARK = Me.REMARK        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.Ent_CSHT010.CAN_FLAG = Me.CAN_FLAG        '原始設計是'Y': 註銷, 由歲入系統寫入, 但為避免有程式漏改, 因此定義如下:使用者在本系統申請註銷時, 本欄位寫入'Y', 歲入系統確定註銷時, 本欄位也會更新為'Y', 同時CAN_FLAG_DATE會寫入當天日期, 做為判別歲入系統回寫依據.本欄位為'代表資料有效, 本欄位等於'Y'表示該筆資料註銷
                Me.Ent_CSHT010.CANCEL_CAUSE = Me.CANCEL_CAUSE        '由歲入系統寫入
                Me.Ent_CSHT010.CAN_FLAG_DATE = Me.CAN_FLAG_DATE      '同步稅入系統資料時寫入，本欄位有資料表示該帳單已經確認註銷。
                Me.Ent_CSHT010.APPL021_PKNO = Me.APPL021_PKNO        'REF. APPL021.PKNO若帳單試開審定證明時產生者，要紀錄審定證明的PKNO才能找到資料
                Me.Ent_CSHT010.RE_PRINT_COUNT = Me.RE_PRINT_COUNT        '
                Me.Ent_CSHT010.SYNC_DATE = Me.SYNC_DATE      '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "PAYMENT_ACNT", Me.PAYMENT_ACNT)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_CSHT010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_CSHT010.Update()

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
                Me.Ent_CSHT010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_CSHT010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_CSHT010.Delete()
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
                'Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號, INSERT時寫入, 本欄位不能修改
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年度, INSERT時寫入
                Me.ProcessQueryCondition(condition, "=", "ITEM_TYPE", Me.ITEM_TYPE)      '繳款項目類別, INSERT時寫入, 本欄位不能修改, 1: 未定義 2: 審查費繳款單 3: 審驗費繳款單 4. 審定證明費繳款單
                Me.ProcessQueryCondition(condition, "=", "PAYMENT_ACNT", Me.PAYMENT_ACNT)        '繳款代碼, 由歲入系統寫入
                Me.ProcessQueryCondition(condition, "=", "COM_PKNO", Me.COM_PKNO)        '收件機構名稱, REF. APPL010.PKNO 由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.ProcessQueryCondition(condition, "=", "INFORM_DATE", Me.INFORM_DATE)      '通知單日期, 本欄位不能修改
                Me.ProcessQueryCondition(condition, ">=", "INFORM_DATE", Me.S_INFORM_DATE) '開單日期
                Me.ProcessQueryCondition(condition, "<=", "INFORM_DATE", Me.E_INFORM_DATE) '開單日期
                Me.ProcessQueryCondition(condition, "=", "PAY_CODE", Me.PAY_CODE)        '費用代碼, REF. SYST010.SYS_KEY='PAY_CODE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "PAY_NAME", Me.PAY_NAME)       '費用名稱, 紀錄存檔時REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_NAME
                Me.ProcessQueryCondition(condition, "=", "PAY_COUNT", Me.PAY_COUNT)      '數量
                Me.ProcessQueryCondition(condition, "=", "PAY_AMT", Me.PAY_AMT)      '費用, 本欄位不能修改, REF. SYS_ID WHERE SYS_KEY='PAY_CODE' FROM SYST010對應的SYS_RSV1, 要把SYST010.SYS_RSV1的值由字串轉成數字
                Me.ProcessQueryCondition(condition, "%LIKE%", "PAY_USER", Me.PAY_USER)        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.ProcessQueryCondition(condition, "=", "PAY_BUS_NO", Me.PAY_BUS_NO)        '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.ProcessQueryCondition(condition, "=", "PAY_TEL", Me.PAY_TEL)      '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.ProcessQueryCondition(condition, "=", "DATE_LEN", Me.DATE_LEN)        '
                Me.ProcessQueryCondition(condition, "=", "PAY_DEADLINE", Me.PAY_DEADLINE)        '繳納期限=通知單日期（收件日期）+繳納期限天數
                Me.ProcessQueryCondition(condition, "=", "PAY_DATE", Me.PAY_DATE)        '使用者登錄的繳費完成日期, 本欄位不能修改, 由「審查費待繳案件」、「審驗費待繳案件」、「開立審定證明」功能寫入, 資料來自於:APPL020.APV1_S_DATE OR APPL020.APV2_S_DATED OR APPL020.APPROVE_S_DATE
                Me.ProcessQueryCondition(condition, "=", "FINAL_PAY_DATE", Me.FINAL_PAY_DATE)        '由歲入系統寫入
                Me.ProcessQueryCondition(condition, "=", "PAY_STATUS", Me.PAY_STATUS)        '由歲入系統寫入, REF. SYST010.SYS_KEY='PAY_STATUS', 1:待收, 2:整批核銷, 3:單筆核銷, 4:預繳核收, 5:分繳中, 6:分繳完畢, 7:暫繳, A:待退, B:已退
                Me.ProcessQueryCondition(condition, "=", "PLEASE_STATUS", Me.PLEASE_STATUS)      '由「案件請款登錄」功能寫入, 'Y': 設定為已請款, ': 未請款
                Me.ProcessQueryCondition(condition, "=", "PLEASE_DATE", Me.PLEASE_DATE)      '由「案件請款登錄」功能寫入
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '由「審查收件」、「審驗收件」、「開立審定證明」功能寫入」
                Me.ProcessQueryCondition(condition, "=", "CAN_FLAG", Me.CAN_FLAG)        '原始設計是'Y': 註銷, 由歲入系統寫入, 但為避免有程式漏改, 因此定義如下:使用者在本系統申請註銷時, 本欄位寫入'Y', 歲入系統確定註銷時, 本欄位也會更新為'Y', 同時CAN_FLAG_DATE會寫入當天日期, 做為判別歲入系統回寫依據.本欄位為'代表資料有效, 本欄位等於'Y'表示該筆資料註銷
                Me.ProcessQueryCondition(condition, "=", "CANCEL_CAUSE", Me.CANCEL_CAUSE)        '由歲入系統寫入
                Me.ProcessQueryCondition(condition, "=", "CAN_FLAG_DATE", Me.CAN_FLAG_DATE)      '同步稅入系統資料時寫入，本欄位有資料表示該帳單已經確認註銷。
                Me.ProcessQueryCondition(condition, "=", "APPL021_PKNO", Me.APPL021_PKNO)        'REF. APPL021.PKNO若帳單試開審定證明時產生者，要紀錄審定證明的PKNO才能找到資料
                Me.ProcessQueryCondition(condition, "=", "RE_PRINT_COUNT", Me.RE_PRINT_COUNT)        '
                Me.ProcessQueryCondition(condition, "=", "SYNC_DATE", Me.SYNC_DATE)      '

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.Ent_CSHT010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_CSHT010.OrderBys = "PKNO"
                Else
                    Me.Ent_CSHT010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_CSHT010.Query()
                Else
                    result = Me.Ent_CSHT010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_CSHT010.TotalRowCount
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

