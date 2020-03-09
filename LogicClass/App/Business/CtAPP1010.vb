'ProductName                 : TSBA 
'File Name					 : CtAPP1010 
'Description	             : CtAPP1010 申設_直播衛星事業申設申請書_基本資料
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/23         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1010 = New ENT_APP1010(Me.DBManager, Me.LogUtil)
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

#Region "APP_PERSON_NM 申請人名稱"
        '' <summary>
        '' APP_PERSON_NM 申請人名稱
        '' </summary>
        Public Property APP_PERSON_NM() As String
            Get
                Return Me.PropertyMap("APP_PERSON_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APP_PERSON_NM") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE 組織型態, REF. SYST010.SYS_KEY='ORG_TYPE'"
        '' <summary>
        '' ORG_TYPE 組織型態, REF. SYST010.SYS_KEY='ORG_TYPE'
        '' </summary>
        Public Property ORG_TYPE() As String
            Get
                Return Me.PropertyMap("ORG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_TYPE") = value
            End Set
        End Property
#End Region

#Region "TOTAL_PROPERTY 實收資本額"
        '' <summary>
        '' TOTAL_PROPERTY 實收資本額
        '' </summary>
        Public Property TOTAL_PROPERTY() As String
            Get
                Return Me.PropertyMap("TOTAL_PROPERTY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOTAL_PROPERTY") = value
            End Set
        End Property
#End Region

#Region "DECLARE_1 自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_1 自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_1() As String
            Get
                Return Me.PropertyMap("DECLARE_1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_1") = value
            End Set
        End Property
#End Region

#Region "DECLARE_2 自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_2 自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_2() As String
            Get
                Return Me.PropertyMap("DECLARE_2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_2") = value
            End Set
        End Property
#End Region

#Region "DECLARE_3 自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_3 自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_3() As String
            Get
                Return Me.PropertyMap("DECLARE_3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DECLARE_3") = value
            End Set
        End Property
#End Region

#Region "SYS_CNAME 申請經營之系統服務/頻道名稱(中文)"
        '' <summary>
        '' SYS_CNAME 申請經營之系統服務/頻道名稱(中文)
        '' </summary>
        Public Property SYS_CNAME() As String
            Get
                Return Me.PropertyMap("SYS_CNAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_CNAME") = value
            End Set
        End Property
#End Region

#Region "SYS_S_CNAME 中文簡稱"
        '' <summary>
        '' SYS_S_CNAME 中文簡稱
        '' </summary>
        Public Property SYS_S_CNAME() As String
            Get
                Return Me.PropertyMap("SYS_S_CNAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_S_CNAME") = value
            End Set
        End Property
#End Region

#Region "SYS_ENAME 申請經營之系統服務/頻道名稱(英文)"
        '' <summary>
        '' SYS_ENAME 申請經營之系統服務/頻道名稱(英文)
        '' </summary>
        Public Property SYS_ENAME() As String
            Get
                Return Me.PropertyMap("SYS_ENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_ENAME") = value
            End Set
        End Property
#End Region

#Region "SYS_S_ENAME 英文簡稱"
        '' <summary>
        '' SYS_S_ENAME 英文簡稱
        '' </summary>
        Public Property SYS_S_ENAME() As String
            Get
                Return Me.PropertyMap("SYS_S_ENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_S_ENAME") = value
            End Set
        End Property
#End Region

#Region "REPRESENTATIVE 代表人/負責人"
        '' <summary>
        '' REPRESENTATIVE 代表人/負責人
        '' </summary>
        Public Property REPRESENTATIVE() As String
            Get
                Return Me.PropertyMap("REPRESENTATIVE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REPRESENTATIVE") = value
            End Set
        End Property
#End Region

#Region "IS_FOREIGNER 本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'"
        '' <summary>
        '' IS_FOREIGNER 本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
        '' </summary>
        Public Property IS_FOREIGNER() As String
            Get
                Return Me.PropertyMap("IS_FOREIGNER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_FOREIGNER") = value
            End Set
        End Property
#End Region

#Region "PID 身份證字號"
        '' <summary>
        '' PID 身份證字號
        '' </summary>
        Public Property PID() As String
            Get
                Return Me.PropertyMap("PID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PID") = value
            End Set
        End Property
#End Region

#Region "BUS_NO 統一編號"
        '' <summary>
        '' BUS_NO 統一編號
        '' </summary>
        Public Property BUS_NO() As String
            Get
                Return Me.PropertyMap("BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUS_NO") = value
            End Set
        End Property
#End Region

#Region "COUNTRY 國籍"
        '' <summary>
        '' COUNTRY 國籍
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.PropertyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "PASSPORT_ID 護照號碼"
        '' <summary>
        '' PASSPORT_ID 護照號碼
        '' </summary>
        Public Property PASSPORT_ID() As String
            Get
                Return Me.PropertyMap("PASSPORT_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PASSPORT_ID") = value
            End Set
        End Property
#End Region

#Region "LIVE_CITY 住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' LIVE_CITY 住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property LIVE_CITY() As String
            Get
                Return Me.PropertyMap("LIVE_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LIVE_CITY") = value
            End Set
        End Property
#End Region

#Region "LIVE_ZIP 住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' LIVE_ZIP 住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property LIVE_ZIP() As String
            Get
                Return Me.PropertyMap("LIVE_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LIVE_ZIP") = value
            End Set
        End Property
#End Region

#Region "LIVE_ADDRESS 住居所"
        '' <summary>
        '' LIVE_ADDRESS 住居所
        '' </summary>
        Public Property LIVE_ADDRESS() As String
            Get
                Return Me.PropertyMap("LIVE_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LIVE_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_CITY 營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_CITY 營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
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

#Region "BUSINESS_ZIP 營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_ZIP 營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
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

#Region "BUSINESS_ADDRESS 營業地址/事業地址"
        '' <summary>
        '' BUSINESS_ADDRESS 營業地址/事業地址
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

#Region "MAILING_CITY 通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' MAILING_CITY 通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property MAILING_CITY() As String
            Get
                Return Me.PropertyMap("MAILING_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAILING_CITY") = value
            End Set
        End Property
#End Region

#Region "MAILING_ZIP 通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' MAILING_ZIP 通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property MAILING_ZIP() As String
            Get
                Return Me.PropertyMap("MAILING_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAILING_ZIP") = value
            End Set
        End Property
#End Region

#Region "MAILING_ADDRESS 通訊地址"
        '' <summary>
        '' MAILING_ADDRESS 通訊地址
        '' </summary>
        Public Property MAILING_ADDRESS() As String
            Get
                Return Me.PropertyMap("MAILING_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAILING_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_AREA_CODE 營業電話區碼"
        '' <summary>
        '' BUSINESS_AREA_CODE 營業電話區碼
        '' </summary>
        Public Property BUSINESS_AREA_CODE() As String
            Get
                Return Me.PropertyMap("BUSINESS_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSINESS_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_TEL 營業電話"
        '' <summary>
        '' BUSINESS_TEL 營業電話
        '' </summary>
        Public Property BUSINESS_TEL() As String
            Get
                Return Me.PropertyMap("BUSINESS_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSINESS_TEL") = value
            End Set
        End Property
#End Region

#Region "START_SCH_DATE 預定開播日期"
        '' <summary>
        '' START_SCH_DATE 預定開播日期
        '' </summary>
        Public Property START_SCH_DATE() As String
            Get
                Return Me.PropertyMap("START_SCH_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("START_SCH_DATE") = value
            End Set
        End Property
#End Region

#Region "CONTACT_PERSON 聯絡人"
        '' <summary>
        '' CONTACT_PERSON 聯絡人
        '' </summary>
        Public Property CONTACT_PERSON() As String
            Get
                Return Me.PropertyMap("CONTACT_PERSON")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_PERSON") = value
            End Set
        End Property
#End Region

#Region "CONTACT_AREA_CODE 聯絡電話區碼"
        '' <summary>
        '' CONTACT_AREA_CODE 聯絡電話區碼
        '' </summary>
        Public Property CONTACT_AREA_CODE() As String
            Get
                Return Me.PropertyMap("CONTACT_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        '' <summary>
        '' CONTACT_TEL 聯絡電話
        '' </summary>
        Public Property CONTACT_TEL() As String
            Get
                Return Me.PropertyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "EMAIL 電子郵件信箱"
        '' <summary>
        '' EMAIL 電子郵件信箱
        '' </summary>
        Public Property EMAIL() As String
            Get
                Return Me.PropertyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS_CITY 聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' CONTACT_ADDRESS_CITY 聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property CONTACT_ADDRESS_CITY() As String
            Get
                Return Me.PropertyMap("CONTACT_ADDRESS_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_ADDRESS_CITY") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS_ZIP 聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' CONTACT_ADDRESS_ZIP 聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property CONTACT_ADDRESS_ZIP() As String
            Get
                Return Me.PropertyMap("CONTACT_ADDRESS_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_ADDRESS_ZIP") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS 聯絡地址"
        '' <summary>
        '' CONTACT_ADDRESS 聯絡地址
        '' </summary>
        Public Property CONTACT_ADDRESS() As String
            Get
                Return Me.PropertyMap("CONTACT_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "FOREIGNER_CAL_BASE_DATE 外國人持股比例計算基準日"
        '' <summary>
        '' FOREIGNER_CAL_BASE_DATE 外國人持股比例計算基準日
        '' </summary>
        Public Property FOREIGNER_CAL_BASE_DATE() As String
            Get
                Return Me.PropertyMap("FOREIGNER_CAL_BASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FOREIGNER_CAL_BASE_DATE") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG 限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG 限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LOCK_CHANNEL_FLAG() As String
            Get
                Return Me.PropertyMap("LOCK_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LOCK_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CH_RANK1 新聞-排名"
        '' <summary>
        '' CH_RANK1 新聞-排名
        '' </summary>
        Public Property CH_RANK1() As String
            Get
                Return Me.PropertyMap("CH_RANK1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK1") = value
            End Set
        End Property
#End Region

#Region "CH_RANK2 財經新聞-排名"
        '' <summary>
        '' CH_RANK2 財經新聞-排名
        '' </summary>
        Public Property CH_RANK2() As String
            Get
                Return Me.PropertyMap("CH_RANK2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK2") = value
            End Set
        End Property
#End Region

#Region "CH_RANK3 財經股市-排名"
        '' <summary>
        '' CH_RANK3 財經股市-排名
        '' </summary>
        Public Property CH_RANK3() As String
            Get
                Return Me.PropertyMap("CH_RANK3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK3") = value
            End Set
        End Property
#End Region

#Region "CH_RANK4 兒少-排名"
        '' <summary>
        '' CH_RANK4 兒少-排名
        '' </summary>
        Public Property CH_RANK4() As String
            Get
                Return Me.PropertyMap("CH_RANK4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK4") = value
            End Set
        End Property
#End Region

#Region "CH_RANK5 戲劇-排名"
        '' <summary>
        '' CH_RANK5 戲劇-排名
        '' </summary>
        Public Property CH_RANK5() As String
            Get
                Return Me.PropertyMap("CH_RANK5")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK5") = value
            End Set
        End Property
#End Region

#Region "CH_RANK6 電影-排名"
        '' <summary>
        '' CH_RANK6 電影-排名
        '' </summary>
        Public Property CH_RANK6() As String
            Get
                Return Me.PropertyMap("CH_RANK6")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK6") = value
            End Set
        End Property
#End Region

#Region "CH_RANK7 體育-排名"
        '' <summary>
        '' CH_RANK7 體育-排名
        '' </summary>
        Public Property CH_RANK7() As String
            Get
                Return Me.PropertyMap("CH_RANK7")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK7") = value
            End Set
        End Property
#End Region

#Region "CH_RANK8 CH_RANK8"
        '' <summary>
        '' CH_RANK8 CH_RANK8
        '' </summary>
        Public Property CH_RANK8() As String
            Get
                Return Me.PropertyMap("CH_RANK8")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK8") = value
            End Set
        End Property
#End Region

#Region "CH_RANK9 音樂-排名"
        '' <summary>
        '' CH_RANK9 音樂-排名
        '' </summary>
        Public Property CH_RANK9() As String
            Get
                Return Me.PropertyMap("CH_RANK9")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK9") = value
            End Set
        End Property
#End Region

#Region "CH_RANK10 宗教-排名"
        '' <summary>
        '' CH_RANK10 宗教-排名
        '' </summary>
        Public Property CH_RANK10() As String
            Get
                Return Me.PropertyMap("CH_RANK10")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK10") = value
            End Set
        End Property
#End Region

#Region "CH_RANK11 綜合-排名"
        '' <summary>
        '' CH_RANK11 綜合-排名
        '' </summary>
        Public Property CH_RANK11() As String
            Get
                Return Me.PropertyMap("CH_RANK11")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK11") = value
            End Set
        End Property
#End Region

#Region "CH_RANK12 其他類型-排名"
        '' <summary>
        '' CH_RANK12 其他類型-排名
        '' </summary>
        Public Property CH_RANK12() As String
            Get
                Return Me.PropertyMap("CH_RANK12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK12") = value
            End Set
        End Property
#End Region

#Region "CH_RANK_DESC 其他類型-說明"
        '' <summary>
        '' CH_RANK_DESC 其他類型-說明
        '' </summary>
        Public Property CH_RANK_DESC() As String
            Get
                Return Me.PropertyMap("CH_RANK_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_RANK_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCAL_CHANNEL_FLAG 地方頻道,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCAL_CHANNEL_FLAG 地方頻道,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LOCAL_CHANNEL_FLAG() As String
            Get
                Return Me.PropertyMap("LOCAL_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LOCAL_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CABLE_NAME 系統名稱"
        '' <summary>
        '' CABLE_NAME 系統名稱
        '' </summary>
        Public Property CABLE_NAME() As String
            Get
                Return Me.PropertyMap("CABLE_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CABLE_NAME") = value
            End Set
        End Property
#End Region

#Region "OPERATION_CITY 經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' OPERATION_CITY 經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property OPERATION_CITY() As String
            Get
                Return Me.PropertyMap("OPERATION_CITY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_CITY") = value
            End Set
        End Property
#End Region

#Region "OPERATION_ZIP 經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' OPERATION_ZIP 經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property OPERATION_ZIP() As String
            Get
                Return Me.PropertyMap("OPERATION_ZIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_ZIP") = value
            End Set
        End Property
#End Region

#Region "APPOINT_AREA 指定區域"
        '' <summary>
        '' APPOINT_AREA 指定區域
        '' </summary>
        Public Property APPOINT_AREA() As String
            Get
                Return Me.PropertyMap("APPOINT_AREA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPOINT_AREA") = value
            End Set
        End Property
#End Region

#Region "BOOKING_PLATFORM 預訂上架之系統平臺"
        '' <summary>
        '' BOOKING_PLATFORM 預訂上架之系統平臺
        '' </summary>
        Public Property BOOKING_PLATFORM() As String
            Get
                Return Me.PropertyMap("BOOKING_PLATFORM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BOOKING_PLATFORM") = value
            End Set
        End Property
#End Region

#Region "TRANS_TYPE 節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'"
        '' <summary>
        '' TRANS_TYPE 節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
        '' </summary>
        Public Property TRANS_TYPE() As String
            Get
                Return Me.PropertyMap("TRANS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRANS_TYPE") = value
            End Set
        End Property
#End Region

#Region "EX_COM_NAME 境外衛星廣播電視事業名稱"
        '' <summary>
        '' EX_COM_NAME 境外衛星廣播電視事業名稱
        '' </summary>
        Public Property EX_COM_NAME() As String
            Get
                Return Me.PropertyMap("EX_COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX_COM_NAME") = value
            End Set
        End Property
#End Region

#Region "EX_COM_COUNTRY 境外衛星廣播電視事業國籍"
        '' <summary>
        '' EX_COM_COUNTRY 境外衛星廣播電視事業國籍
        '' </summary>
        Public Property EX_COM_COUNTRY() As String
            Get
                Return Me.PropertyMap("EX_COM_COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX_COM_COUNTRY") = value
            End Set
        End Property
#End Region

#Region "APP_NAME 申請標的"
        '' <summary>
        '' APP_NAME 申請標的
        '' </summary>
        Public Property APP_NAME() As String
            Get
                Return Me.PropertyMap("APP_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APP_NAME") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_AREA_CODE 申訴管道-客服電話區碼"
        '' <summary>
        '' COMPLAINT_AREA_CODE 申訴管道-客服電話區碼
        '' </summary>
        Public Property COMPLAINT_AREA_CODE() As String
            Get
                Return Me.PropertyMap("COMPLAINT_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_TEL 申訴管道-客服電話"
        '' <summary>
        '' COMPLAINT_TEL 申訴管道-客服電話
        '' </summary>
        Public Property COMPLAINT_TEL() As String
            Get
                Return Me.PropertyMap("COMPLAINT_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_TEL") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_EMAIL 申訴管道-電子郵件"
        '' <summary>
        '' COMPLAINT_EMAIL 申訴管道-電子郵件
        '' </summary>
        Public Property COMPLAINT_EMAIL() As String
            Get
                Return Me.PropertyMap("COMPLAINT_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_EMAIL") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_OTHER 申訴管道-其他"
        '' <summary>
        '' COMPLAINT_OTHER 申訴管道-其他
        '' </summary>
        Public Property COMPLAINT_OTHER() As String
            Get
                Return Me.PropertyMap("COMPLAINT_OTHER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_OTHER") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO 執照號碼"
        '' <summary>
        '' LICENSE_NO 執照號碼
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.PropertyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "SETUP_DATE 成立時間"
        '' <summary>
        '' SETUP_DATE 成立時間
        '' </summary>
        Public Property SETUP_DATE() As String
            Get
                Return Me.PropertyMap("SETUP_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SETUP_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE 執照(許可)效期/目前執照期間(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照(許可)效期/目前執照期間(起)
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

#Region "LICENSE_E_DATE 執照(許可)效期/目前執照期間(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照(許可)效期/目前執照期間(迄)
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

#Region "WEB_URL 電臺網址/事業網址"
        '' <summary>
        '' WEB_URL 電臺網址/事業網址
        '' </summary>
        Public Property WEB_URL() As String
            Get
                Return Me.PropertyMap("WEB_URL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("WEB_URL") = value
            End Set
        End Property
#End Region

#Region "SETUP_PURPOSE 設臺宗旨"
        '' <summary>
        '' SETUP_PURPOSE 設臺宗旨
        '' </summary>
        Public Property SETUP_PURPOSE() As String
            Get
                Return Me.PropertyMap("SETUP_PURPOSE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SETUP_PURPOSE") = value
            End Set
        End Property
#End Region

#Region "E_RESULT1 執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'"
        '' <summary>
        '' E_RESULT1 執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
        '' </summary>
        Public Property E_RESULT1() As String
            Get
                Return Me.PropertyMap("E_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("E_RESULT1") = value
            End Set
        End Property
#End Region

#Region "E_RESULT2 執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'"
        '' <summary>
        '' E_RESULT2 執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
        '' </summary>
        Public Property E_RESULT2() As String
            Get
                Return Me.PropertyMap("E_RESULT2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("E_RESULT2") = value
            End Set
        End Property
#End Region

#Region "OPERATION_S_DATE1 營運計畫執行期間(起)"
        '' <summary>
        '' OPERATION_S_DATE1 營運計畫執行期間(起)
        '' </summary>
        Public Property OPERATION_S_DATE1() As String
            Get
                Return Me.PropertyMap("OPERATION_S_DATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_S_DATE1") = value
            End Set
        End Property
#End Region

#Region "OPERATION_E_DATE1 營運計畫執行期間(迄)"
        '' <summary>
        '' OPERATION_E_DATE1 營運計畫執行期間(迄)
        '' </summary>
        Public Property OPERATION_E_DATE1() As String
            Get
                Return Me.PropertyMap("OPERATION_E_DATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_E_DATE1") = value
            End Set
        End Property
#End Region

#Region "OPERATION_S_DATE2 未來營運計畫期間(起)"
        '' <summary>
        '' OPERATION_S_DATE2 未來營運計畫期間(起)
        '' </summary>
        Public Property OPERATION_S_DATE2() As String
            Get
                Return Me.PropertyMap("OPERATION_S_DATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_S_DATE2") = value
            End Set
        End Property
#End Region

#Region "OPERATION_E_DATE2 未來營運計畫期間(迄)"
        '' <summary>
        '' OPERATION_E_DATE2 未來營運計畫期間(迄)
        '' </summary>
        Public Property OPERATION_E_DATE2() As String
            Get
                Return Me.PropertyMap("OPERATION_E_DATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OPERATION_E_DATE2") = value
            End Set
        End Property
#End Region

#Region "RADIO_TYPE 電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'"
        '' <summary>
        '' RADIO_TYPE 電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
        '' </summary>
        Public Property RADIO_TYPE() As String
            Get
                Return Me.PropertyMap("RADIO_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RADIO_TYPE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_S_DATE 評鑑期間(起)"
        '' <summary>
        '' EVALUATION_S_DATE 評鑑期間(起)
        '' </summary>
        Public Property EVALUATION_S_DATE() As String
            Get
                Return Me.PropertyMap("EVALUATION_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EVALUATION_S_DATE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_E_DATE 評鑑期間(迄)"
        '' <summary>
        '' EVALUATION_E_DATE 評鑑期間(迄)
        '' </summary>
        Public Property EVALUATION_E_DATE() As String
            Get
                Return Me.PropertyMap("EVALUATION_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EVALUATION_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PLAY_S_DATE 開播日期"
        '' <summary>
        '' PLAY_S_DATE 開播日期
        '' </summary>
        Public Property PLAY_S_DATE() As String
            Get
                Return Me.PropertyMap("PLAY_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PLAY_S_DATE") = value
            End Set
        End Property
#End Region

#Region "SB_AMT1 前1年度營業額"
        '' <summary>
        '' SB_AMT1 前1年度營業額
        '' </summary>
        Public Property SB_AMT1() As String
            Get
                Return Me.PropertyMap("SB_AMT1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SB_AMT1") = value
            End Set
        End Property
#End Region

#Region "SB_AMT2 前2年度營業額"
        '' <summary>
        '' SB_AMT2 前2年度營業額
        '' </summary>
        Public Property SB_AMT2() As String
            Get
                Return Me.PropertyMap("SB_AMT2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SB_AMT2") = value
            End Set
        End Property
#End Region

#Region "SB_AMT3 前3年度營業額"
        '' <summary>
        '' SB_AMT3 前3年度營業額
        '' </summary>
        Public Property SB_AMT3() As String
            Get
                Return Me.PropertyMap("SB_AMT3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SB_AMT3") = value
            End Set
        End Property
#End Region

#Region "EMPLOYEE_NUMBER 員工人數"
        '' <summary>
        '' EMPLOYEE_NUMBER 員工人數
        '' </summary>
        Public Property EMPLOYEE_NUMBER() As String
            Get
                Return Me.PropertyMap("EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBE_NUMBER 總訂戶數"
        '' <summary>
        '' SUBSCRIBE_NUMBER 總訂戶數
        '' </summary>
        Public Property SUBSCRIBE_NUMBER() As String
            Get
                Return Me.PropertyMap("SUBSCRIBE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SUBSCRIBE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "BASE_CHANNEL_NNUMBER 基本頻道數"
        '' <summary>
        '' BASE_CHANNEL_NNUMBER 基本頻道數
        '' </summary>
        Public Property BASE_CHANNEL_NNUMBER() As String
            Get
                Return Me.PropertyMap("BASE_CHANNEL_NNUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BASE_CHANNEL_NNUMBER") = value
            End Set
        End Property
#End Region

#Region "PAY_CHANNEL_NNUMBER 付費頻道數"
        '' <summary>
        '' PAY_CHANNEL_NNUMBER 付費頻道數
        '' </summary>
        Public Property PAY_CHANNEL_NNUMBER() As String
            Get
                Return Me.PropertyMap("PAY_CHANNEL_NNUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAY_CHANNEL_NNUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANGE_STANDARD 收費標準"
        '' <summary>
        '' CHANGE_STANDARD 收費標準
        '' </summary>
        Public Property CHANGE_STANDARD() As String
            Get
                Return Me.PropertyMap("CHANGE_STANDARD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANGE_STANDARD") = value
            End Set
        End Property
#End Region

#Region "SETUP_ORG_FLAG 建立自律組織,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SETUP_ORG_FLAG 建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SETUP_ORG_FLAG() As String
            Get
                Return Me.PropertyMap("SETUP_ORG_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SETUP_ORG_FLAG") = value
            End Set
        End Property
#End Region

#Region "ORG_NAME 自律組織名稱"
        '' <summary>
        '' ORG_NAME 自律組織名稱
        '' </summary>
        Public Property ORG_NAME() As String
            Get
                Return Me.PropertyMap("ORG_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_NAME") = value
            End Set
        End Property
#End Region

#Region "PUNISH_NUMBER 評鑑期間核處紀錄件數"
        '' <summary>
        '' PUNISH_NUMBER 評鑑期間核處紀錄件數
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

#Region "IN_CHANNEL_NUMBER 境內頻道數量"
        '' <summary>
        '' IN_CHANNEL_NUMBER 境內頻道數量
        '' </summary>
        Public Property IN_CHANNEL_NUMBER() As String
            Get
                Return Me.PropertyMap("IN_CHANNEL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_CHANNEL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "IN_CHANNEL_NAME 境內頻道名稱"
        '' <summary>
        '' IN_CHANNEL_NAME 境內頻道名稱
        '' </summary>
        Public Property IN_CHANNEL_NAME() As String
            Get
                Return Me.PropertyMap("IN_CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "EX__CHANNEL_NUMBER 境外頻道數量"
        '' <summary>
        '' EX__CHANNEL_NUMBER 境外頻道數量
        '' </summary>
        Public Property EX__CHANNEL_NUMBER() As String
            Get
                Return Me.PropertyMap("EX__CHANNEL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX__CHANNEL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EX_CHANNEL_NAME 境外頻道名稱"
        '' <summary>
        '' EX_CHANNEL_NAME 境外頻道名稱
        '' </summary>
        Public Property EX_CHANNEL_NAME() As String
            Get
                Return Me.PropertyMap("EX_CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX_CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "IN_COM_NAME1 境內直播衛星服務經營者名稱"
        '' <summary>
        '' IN_COM_NAME1 境內直播衛星服務經營者名稱
        '' </summary>
        Public Property IN_COM_NAME1() As String
            Get
                Return Me.PropertyMap("IN_COM_NAME1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_COM_NAME1") = value
            End Set
        End Property
#End Region

#Region "EX_COM_NAME1 境外直播衛星服務經營者名稱"
        '' <summary>
        '' EX_COM_NAME1 境外直播衛星服務經營者名稱
        '' </summary>
        Public Property EX_COM_NAME1() As String
            Get
                Return Me.PropertyMap("EX_COM_NAME1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX_COM_NAME1") = value
            End Set
        End Property
#End Region

#Region "ADD_DESC "
        '' <summary>
        '' ADD_DESC 
        '' </summary>
        Public Property ADD_DESC() As String
            Get
                Return Me.PropertyMap("ADD_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADD_DESC") = value
            End Set
        End Property
#End Region

#Region "IN_COM_FLAG 境內直播衛星服務經營者,Y：有勾選"
        '' <summary>
        '' IN_COM_FLAG 境內直播衛星服務經營者,Y：有勾選
        '' </summary>
        Public Property IN_COM_FLAG() As String
            Get
                Return Me.PropertyMap("IN_COM_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IN_COM_FLAG") = value
            End Set
        End Property
#End Region

#Region "EX_COM_FLAG 境外直播衛星服務經營者,Y：有勾選"
        '' <summary>
        '' EX_COM_FLAG 境外直播衛星服務經營者,Y：有勾選
        '' </summary>
        Public Property EX_COM_FLAG() As String
            Get
                Return Me.PropertyMap("EX_COM_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EX_COM_FLAG") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1010"
        ' <summary>Ent_APP1010</ summary>
        Private Property Ent_APP1010() As ENT_APP1010
            Get
                Return Me.PropertyMap("Ent_APP1010")
            End Get
            Set(ByVal value As ENT_APP1010)
                Me.PropertyMap("Ent_APP1010") = value
            End Set
        End Property
#End Region

#Region "CREATE_TIME_S 申請日期(日期擇一填寫)"
        ''' <summary>
        ''' CREATE_TIME_S 申請日期(日期擇一填寫)
        ''' </summary>
        Public Property CREATE_TIME_S As String
            Get
                Return Me.PropertyMap("CREATE_TIME_S")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_TIME_S") = value
            End Set
        End Property
#End Region

#Region "CREATE_TIME_E 申請日期(日期擇一填寫)"
        ''' <summary>
        ''' CREATE_TIME_E 申請日期(日期擇一填寫)
        ''' </summary>
        Public Property CREATE_TIME_E As String
            Get
                Return Me.PropertyMap("CREATE_TIME_E")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CREATE_TIME_E") = value
            End Set
        End Property
#End Region

 
#Region "ISSUED_LICENSE_DATE_S 發照日期(日期擇一填寫)"
        ''' <summary>
        ''' ISSUED_LICENSE_DATE_S 發照日期(日期擇一填寫)
        ''' </summary>
        Public Property ISSUED_LICENSE_DATE_S As String
            Get
                Return Me.PropertyMap("ISSUED_LICENSE_DATE_S")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ISSUED_LICENSE_DATE_S") = value
            End Set
        End Property
#End Region

#Region "ISSUED_LICENSE_DATE_E 發照日期(日期擇一填寫)"
        ''' <summary>
        ''' ISSUED_LICENSE_DATE_E 發照日期(日期擇一填寫)
        ''' </summary>
        Public Property ISSUED_LICENSE_DATE_E As String
            Get
                Return Me.PropertyMap("ISSUED_LICENSE_DATE_E")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ISSUED_LICENSE_DATE_E") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV 事業類別"
        ''' <summary>
        ''' SYS_RSV 事業類別
        ''' </summary>
        Public Property SYS_RSV As String
            Get
                Return Me.PropertyMap("SYS_RSV")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV2 事業類別"
        ''' <summary>
        ''' SYS_RSV2 事業類別
        ''' </summary>
        Public Property SYS_RSV2 As String
            Get
                Return Me.PropertyMap("SYS_RSV2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV2") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV1 申請項目"
        ''' <summary>
        ''' SYS_RSV1 申請項目
        ''' </summary>
        Public Property SYS_RSV1 As String
            Get
                Return Me.PropertyMap("SYS_RSV1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV1") = value
            End Set
        End Property
#End Region

#Region "CHSYS_TYPE 上架平台(僅衛廣，可複選)"
        ''' <summary>
        ''' CHSYS_TYPE 上架平台(僅衛廣，可複選)
        ''' </summary>
        Public Property CHSYS_TYPE As String
            Get
                Return Me.PropertyMap("CHSYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHSYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SHOW_ATTRIBUTE 頻道節目屬性(可複選)"
        ''' <summary>
        ''' SHOW_ATTRIBUTE 頻道節目屬性(可複選)
        ''' </summary>
        Public Property SHOW_ATTRIBUTE As String
            Get
                Return Me.PropertyMap("SHOW_ATTRIBUTE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_ATTRIBUTE") = value
            End Set
        End Property
#End Region

#Region "CASE_STATUS 案件狀態"
        ''' <summary>
        ''' CASE_STATUS 案件狀態
        ''' </summary>
        Public Property CASE_STATUS As String
            Get
                Return Me.PropertyMap("CASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_STATUS") = value
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

#Region "R_TYPE 報表類別"
        ''' <summary>
        ''' R_TYPE 報表類別
        ''' </summary>
        Public Property R_TYPE() As String
            Get
                Return Me.PropertyMap("R_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("R_TYPE") = value
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
                Me.Ent_APP1010.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1010.APP_PERSON_NM = Me.APP_PERSON_NM      '申請人名稱
                Me.Ent_APP1010.ORG_TYPE = Me.ORG_TYPE        '組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
                Me.Ent_APP1010.TOTAL_PROPERTY = Me.TOTAL_PROPERTY        '實收資本額
                Me.Ent_APP1010.DECLARE_1 = Me.DECLARE_1      '自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.DECLARE_2 = Me.DECLARE_2      '自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.DECLARE_3 = Me.DECLARE_3      '自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.SYS_CNAME = Me.SYS_CNAME      '申請經營之系統服務/頻道名稱(中文)
                Me.Ent_APP1010.SYS_S_CNAME = Me.SYS_S_CNAME      '中文簡稱
                Me.Ent_APP1010.SYS_ENAME = Me.SYS_ENAME      '申請經營之系統服務/頻道名稱(英文)
                Me.Ent_APP1010.SYS_S_ENAME = Me.SYS_S_ENAME      '英文簡稱
                Me.Ent_APP1010.REPRESENTATIVE = Me.REPRESENTATIVE        '代表人/負責人
                Me.Ent_APP1010.IS_FOREIGNER = Me.IS_FOREIGNER        '本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
                Me.Ent_APP1010.PID = Me.PID      '身份證字號
                Me.Ent_APP1010.COUNTRY = Me.COUNTRY      '國籍
                Me.Ent_APP1010.PASSPORT_ID = Me.PASSPORT_ID      '護照號碼
                Me.Ent_APP1010.LIVE_CITY = Me.LIVE_CITY      '住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.LIVE_ZIP = Me.LIVE_ZIP        '住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.LIVE_ADDRESS = Me.LIVE_ADDRESS        '住居所
                Me.Ent_APP1010.BUSINESS_CITY = Me.BUSINESS_CITY      '營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.BUSINESS_ZIP = Me.BUSINESS_ZIP        '營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.BUSINESS_ADDRESS = Me.BUSINESS_ADDRESS        '營業地址/事業地址
                Me.Ent_APP1010.MAILING_CITY = Me.MAILING_CITY        '通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.MAILING_ZIP = Me.MAILING_ZIP      '通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.MAILING_ADDRESS = Me.MAILING_ADDRESS      '通訊地址
                Me.Ent_APP1010.BUSINESS_AREA_CODE = Me.BUSINESS_AREA_CODE        '營業電話區碼
                Me.Ent_APP1010.BUSINESS_TEL = Me.BUSINESS_TEL        '營業電話
                Me.Ent_APP1010.START_SCH_DATE = Me.START_SCH_DATE        '預定開播日期
                Me.Ent_APP1010.CONTACT_PERSON = Me.CONTACT_PERSON        '聯絡人
                Me.Ent_APP1010.CONTACT_AREA_CODE = Me.CONTACT_AREA_CODE      '聯絡電話區碼
                Me.Ent_APP1010.CONTACT_TEL = Me.CONTACT_TEL      '聯絡電話
                Me.Ent_APP1010.EMAIL = Me.EMAIL      '電子郵件信箱
                Me.Ent_APP1010.CONTACT_ADDRESS_CITY = Me.CONTACT_ADDRESS_CITY        '聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.CONTACT_ADDRESS_ZIP = Me.CONTACT_ADDRESS_ZIP      '聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.CONTACT_ADDRESS = Me.CONTACT_ADDRESS      '聯絡地址
                Me.Ent_APP1010.FOREIGNER_CAL_BASE_DATE = Me.FOREIGNER_CAL_BASE_DATE      '外國人持股比例計算基準日
                Me.Ent_APP1010.LOCK_CHANNEL_FLAG = Me.LOCK_CHANNEL_FLAG      '限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.CH_RANK1 = Me.CH_RANK1        '新聞-排名
                Me.Ent_APP1010.CH_RANK2 = Me.CH_RANK2        '財經新聞-排名
                Me.Ent_APP1010.CH_RANK3 = Me.CH_RANK3        '財經股市-排名
                Me.Ent_APP1010.CH_RANK4 = Me.CH_RANK4        '兒少-排名
                Me.Ent_APP1010.CH_RANK5 = Me.CH_RANK5        '戲劇-排名
                Me.Ent_APP1010.CH_RANK6 = Me.CH_RANK6        '電影-排名
                Me.Ent_APP1010.CH_RANK7 = Me.CH_RANK7        '體育-排名
                Me.Ent_APP1010.CH_RANK8 = Me.CH_RANK8        'CH_RANK8
                Me.Ent_APP1010.CH_RANK9 = Me.CH_RANK9        '音樂-排名
                Me.Ent_APP1010.CH_RANK10 = Me.CH_RANK10      '宗教-排名
                Me.Ent_APP1010.CH_RANK11 = Me.CH_RANK11      '綜合-排名
                Me.Ent_APP1010.CH_RANK12 = Me.CH_RANK12      '其他類型-排名
                Me.Ent_APP1010.CH_RANK_DESC = Me.CH_RANK_DESC        '其他類型-說明
                Me.Ent_APP1010.LOCAL_CHANNEL_FLAG = Me.LOCAL_CHANNEL_FLAG        '地方頻道,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.CABLE_NAME = Me.CABLE_NAME        '系統名稱
                Me.Ent_APP1010.OPERATION_CITY = Me.OPERATION_CITY        '經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.OPERATION_ZIP = Me.OPERATION_ZIP      '經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.APPOINT_AREA = Me.APPOINT_AREA        '指定區域
                Me.Ent_APP1010.BOOKING_PLATFORM = Me.BOOKING_PLATFORM        '預訂上架之系統平臺
                Me.Ent_APP1010.TRANS_TYPE = Me.TRANS_TYPE        '節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.Ent_APP1010.EX_COM_NAME = Me.EX_COM_NAME      '境外衛星廣播電視事業名稱
                Me.Ent_APP1010.EX_COM_COUNTRY = Me.EX_COM_COUNTRY        '境外衛星廣播電視事業國籍
                Me.Ent_APP1010.APP_NAME = Me.APP_NAME        '申請標的
                Me.Ent_APP1010.COMPLAINT_AREA_CODE = Me.COMPLAINT_AREA_CODE      '申訴管道-客服電話區碼
                Me.Ent_APP1010.COMPLAINT_TEL = Me.COMPLAINT_TEL      '申訴管道-客服電話
                Me.Ent_APP1010.COMPLAINT_EMAIL = Me.COMPLAINT_EMAIL      '申訴管道-電子郵件
                Me.Ent_APP1010.COMPLAINT_OTHER = Me.COMPLAINT_OTHER      '申訴管道-其他
                Me.Ent_APP1010.LICENSE_NO = Me.LICENSE_NO        '執照號碼
                Me.Ent_APP1010.SETUP_DATE = Me.SETUP_DATE        '成立時間
                Me.Ent_APP1010.LICENSE_S_DATE = Me.LICENSE_S_DATE        '執照(許可)效期/目前執照期間(起)
                Me.Ent_APP1010.LICENSE_E_DATE = Me.LICENSE_E_DATE        '執照(許可)效期/目前執照期間(迄)
                Me.Ent_APP1010.WEB_URL = Me.WEB_URL      '電臺網址/事業網址
                Me.Ent_APP1010.SETUP_PURPOSE = Me.SETUP_PURPOSE      '設臺宗旨
                Me.Ent_APP1010.E_RESULT1 = Me.E_RESULT1      '執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.Ent_APP1010.E_RESULT2 = Me.E_RESULT2      '執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.Ent_APP1010.OPERATION_S_DATE1 = Me.OPERATION_S_DATE1      '營運計畫執行期間(起)
                Me.Ent_APP1010.OPERATION_E_DATE1 = Me.OPERATION_E_DATE1      '營運計畫執行期間(迄)
                Me.Ent_APP1010.OPERATION_S_DATE2 = Me.OPERATION_S_DATE2      '未來營運計畫期間(起)
                Me.Ent_APP1010.OPERATION_E_DATE2 = Me.OPERATION_E_DATE2      '未來營運計畫期間(迄)
                Me.Ent_APP1010.RADIO_TYPE = Me.RADIO_TYPE        '電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
                Me.Ent_APP1010.EVALUATION_S_DATE = Me.EVALUATION_S_DATE      '評鑑期間(起)
                Me.Ent_APP1010.EVALUATION_E_DATE = Me.EVALUATION_E_DATE      '評鑑期間(迄)
                Me.Ent_APP1010.PLAY_S_DATE = Me.PLAY_S_DATE      '開播日期
                Me.Ent_APP1010.SB_AMT1 = Me.SB_AMT1      '前1年度營業額
                Me.Ent_APP1010.SB_AMT2 = Me.SB_AMT2      '前2年度營業額
                Me.Ent_APP1010.SB_AMT3 = Me.SB_AMT3      '前3年度營業額
                Me.Ent_APP1010.EMPLOYEE_NUMBER = Me.EMPLOYEE_NUMBER      '員工人數
                Me.Ent_APP1010.SUBSCRIBE_NUMBER = Me.SUBSCRIBE_NUMBER        '總訂戶數
                Me.Ent_APP1010.BASE_CHANNEL_NNUMBER = Me.BASE_CHANNEL_NNUMBER        '基本頻道數
                Me.Ent_APP1010.PAY_CHANNEL_NNUMBER = Me.PAY_CHANNEL_NNUMBER      '付費頻道數
                Me.Ent_APP1010.CHANGE_STANDARD = Me.CHANGE_STANDARD      '收費標準
                Me.Ent_APP1010.SETUP_ORG_FLAG = Me.SETUP_ORG_FLAG        '建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.ORG_NAME = Me.ORG_NAME        '自律組織名稱
                Me.Ent_APP1010.PUNISH_NUMBER = Me.PUNISH_NUMBER      '評鑑期間核處紀錄件數
                Me.Ent_APP1010.IN_CHANNEL_NUMBER = Me.IN_CHANNEL_NUMBER      '境內頻道數量
                Me.Ent_APP1010.IN_CHANNEL_NAME = Me.IN_CHANNEL_NAME      '境內頻道名稱
                Me.Ent_APP1010.EX__CHANNEL_NUMBER = Me.EX__CHANNEL_NUMBER        '境外頻道數量
                Me.Ent_APP1010.EX_CHANNEL_NAME = Me.EX_CHANNEL_NAME      '境外頻道名稱
                Me.Ent_APP1010.IN_COM_NAME1 = Me.IN_COM_NAME1        '境內直播衛星服務經營者名稱
                Me.Ent_APP1010.EX_COM_NAME1 = Me.EX_COM_NAME1        '境外直播衛星服務經營者名稱
                Me.Ent_APP1010.ADD_DESC = Me.ADD_DESC        '
                Me.Ent_APP1010.IN_COM_FLAG = Me.IN_COM_FLAG      '境內直播衛星服務經營者,Y：有勾選
                Me.Ent_APP1010.EX_COM_FLAG = Me.EX_COM_FLAG      '境外直播衛星服務經營者,Y：有勾選


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1010.Insert()

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
                Me.Ent_APP1010.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1010.APP_PERSON_NM = Me.APP_PERSON_NM      '申請人名稱
                Me.Ent_APP1010.ORG_TYPE = Me.ORG_TYPE        '組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
                Me.Ent_APP1010.TOTAL_PROPERTY = Me.TOTAL_PROPERTY        '實收資本額
                Me.Ent_APP1010.DECLARE_1 = Me.DECLARE_1      '自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.DECLARE_2 = Me.DECLARE_2      '自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.DECLARE_3 = Me.DECLARE_3      '自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.SYS_CNAME = Me.SYS_CNAME      '申請經營之系統服務/頻道名稱(中文)
                Me.Ent_APP1010.SYS_S_CNAME = Me.SYS_S_CNAME      '中文簡稱
                Me.Ent_APP1010.SYS_ENAME = Me.SYS_ENAME      '申請經營之系統服務/頻道名稱(英文)
                Me.Ent_APP1010.SYS_S_ENAME = Me.SYS_S_ENAME      '英文簡稱
                Me.Ent_APP1010.REPRESENTATIVE = Me.REPRESENTATIVE        '代表人/負責人
                Me.Ent_APP1010.IS_FOREIGNER = Me.IS_FOREIGNER        '本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
                Me.Ent_APP1010.PID = Me.PID      '身份證字號
                Me.Ent_APP1010.COUNTRY = Me.COUNTRY      '國籍
                Me.Ent_APP1010.PASSPORT_ID = Me.PASSPORT_ID      '護照號碼
                Me.Ent_APP1010.LIVE_CITY = Me.LIVE_CITY      '住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.LIVE_ZIP = Me.LIVE_ZIP        '住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.LIVE_ADDRESS = Me.LIVE_ADDRESS        '住居所
                Me.Ent_APP1010.BUSINESS_CITY = Me.BUSINESS_CITY      '營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.BUSINESS_ZIP = Me.BUSINESS_ZIP        '營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.BUSINESS_ADDRESS = Me.BUSINESS_ADDRESS        '營業地址/事業地址
                Me.Ent_APP1010.MAILING_CITY = Me.MAILING_CITY        '通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.MAILING_ZIP = Me.MAILING_ZIP      '通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.MAILING_ADDRESS = Me.MAILING_ADDRESS      '通訊地址
                Me.Ent_APP1010.BUSINESS_AREA_CODE = Me.BUSINESS_AREA_CODE        '營業電話區碼
                Me.Ent_APP1010.BUSINESS_TEL = Me.BUSINESS_TEL        '營業電話
                Me.Ent_APP1010.START_SCH_DATE = Me.START_SCH_DATE        '預定開播日期
                Me.Ent_APP1010.CONTACT_PERSON = Me.CONTACT_PERSON        '聯絡人
                Me.Ent_APP1010.CONTACT_AREA_CODE = Me.CONTACT_AREA_CODE      '聯絡電話區碼
                Me.Ent_APP1010.CONTACT_TEL = Me.CONTACT_TEL      '聯絡電話
                Me.Ent_APP1010.EMAIL = Me.EMAIL      '電子郵件信箱
                Me.Ent_APP1010.CONTACT_ADDRESS_CITY = Me.CONTACT_ADDRESS_CITY        '聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.CONTACT_ADDRESS_ZIP = Me.CONTACT_ADDRESS_ZIP      '聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.CONTACT_ADDRESS = Me.CONTACT_ADDRESS      '聯絡地址
                Me.Ent_APP1010.FOREIGNER_CAL_BASE_DATE = Me.FOREIGNER_CAL_BASE_DATE      '外國人持股比例計算基準日
                Me.Ent_APP1010.LOCK_CHANNEL_FLAG = Me.LOCK_CHANNEL_FLAG      '限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.CH_RANK1 = Me.CH_RANK1        '新聞-排名
                Me.Ent_APP1010.CH_RANK2 = Me.CH_RANK2        '財經新聞-排名
                Me.Ent_APP1010.CH_RANK3 = Me.CH_RANK3        '財經股市-排名
                Me.Ent_APP1010.CH_RANK4 = Me.CH_RANK4        '兒少-排名
                Me.Ent_APP1010.CH_RANK5 = Me.CH_RANK5        '戲劇-排名
                Me.Ent_APP1010.CH_RANK6 = Me.CH_RANK6        '電影-排名
                Me.Ent_APP1010.CH_RANK7 = Me.CH_RANK7        '體育-排名
                Me.Ent_APP1010.CH_RANK8 = Me.CH_RANK8        'CH_RANK8
                Me.Ent_APP1010.CH_RANK9 = Me.CH_RANK9        '音樂-排名
                Me.Ent_APP1010.CH_RANK10 = Me.CH_RANK10      '宗教-排名
                Me.Ent_APP1010.CH_RANK11 = Me.CH_RANK11      '綜合-排名
                Me.Ent_APP1010.CH_RANK12 = Me.CH_RANK12      '其他類型-排名
                Me.Ent_APP1010.CH_RANK_DESC = Me.CH_RANK_DESC        '其他類型-說明
                Me.Ent_APP1010.LOCAL_CHANNEL_FLAG = Me.LOCAL_CHANNEL_FLAG        '地方頻道,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.CABLE_NAME = Me.CABLE_NAME        '系統名稱
                Me.Ent_APP1010.OPERATION_CITY = Me.OPERATION_CITY        '經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.OPERATION_ZIP = Me.OPERATION_ZIP      '經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.Ent_APP1010.APPOINT_AREA = Me.APPOINT_AREA        '指定區域
                Me.Ent_APP1010.BOOKING_PLATFORM = Me.BOOKING_PLATFORM        '預訂上架之系統平臺
                Me.Ent_APP1010.TRANS_TYPE = Me.TRANS_TYPE        '節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.Ent_APP1010.EX_COM_NAME = Me.EX_COM_NAME      '境外衛星廣播電視事業名稱
                Me.Ent_APP1010.EX_COM_COUNTRY = Me.EX_COM_COUNTRY        '境外衛星廣播電視事業國籍
                Me.Ent_APP1010.APP_NAME = Me.APP_NAME        '申請標的
                Me.Ent_APP1010.COMPLAINT_AREA_CODE = Me.COMPLAINT_AREA_CODE      '申訴管道-客服電話區碼
                Me.Ent_APP1010.COMPLAINT_TEL = Me.COMPLAINT_TEL      '申訴管道-客服電話
                Me.Ent_APP1010.COMPLAINT_EMAIL = Me.COMPLAINT_EMAIL      '申訴管道-電子郵件
                Me.Ent_APP1010.COMPLAINT_OTHER = Me.COMPLAINT_OTHER      '申訴管道-其他
                Me.Ent_APP1010.LICENSE_NO = Me.LICENSE_NO        '執照號碼
                Me.Ent_APP1010.SETUP_DATE = Me.SETUP_DATE        '成立時間
                Me.Ent_APP1010.LICENSE_S_DATE = Me.LICENSE_S_DATE        '執照(許可)效期/目前執照期間(起)
                Me.Ent_APP1010.LICENSE_E_DATE = Me.LICENSE_E_DATE        '執照(許可)效期/目前執照期間(迄)
                Me.Ent_APP1010.WEB_URL = Me.WEB_URL      '電臺網址/事業網址
                Me.Ent_APP1010.SETUP_PURPOSE = Me.SETUP_PURPOSE      '設臺宗旨
                Me.Ent_APP1010.E_RESULT1 = Me.E_RESULT1      '執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.Ent_APP1010.E_RESULT2 = Me.E_RESULT2      '執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.Ent_APP1010.OPERATION_S_DATE1 = Me.OPERATION_S_DATE1      '營運計畫執行期間(起)
                Me.Ent_APP1010.OPERATION_E_DATE1 = Me.OPERATION_E_DATE1      '營運計畫執行期間(迄)
                Me.Ent_APP1010.OPERATION_S_DATE2 = Me.OPERATION_S_DATE2      '未來營運計畫期間(起)
                Me.Ent_APP1010.OPERATION_E_DATE2 = Me.OPERATION_E_DATE2      '未來營運計畫期間(迄)
                Me.Ent_APP1010.RADIO_TYPE = Me.RADIO_TYPE        '電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
                Me.Ent_APP1010.EVALUATION_S_DATE = Me.EVALUATION_S_DATE      '評鑑期間(起)
                Me.Ent_APP1010.EVALUATION_E_DATE = Me.EVALUATION_E_DATE      '評鑑期間(迄)
                Me.Ent_APP1010.PLAY_S_DATE = Me.PLAY_S_DATE      '開播日期
                Me.Ent_APP1010.SB_AMT1 = Me.SB_AMT1      '前1年度營業額
                Me.Ent_APP1010.SB_AMT2 = Me.SB_AMT2      '前2年度營業額
                Me.Ent_APP1010.SB_AMT3 = Me.SB_AMT3      '前3年度營業額
                Me.Ent_APP1010.EMPLOYEE_NUMBER = Me.EMPLOYEE_NUMBER      '員工人數
                Me.Ent_APP1010.SUBSCRIBE_NUMBER = Me.SUBSCRIBE_NUMBER        '總訂戶數
                Me.Ent_APP1010.BASE_CHANNEL_NNUMBER = Me.BASE_CHANNEL_NNUMBER        '基本頻道數
                Me.Ent_APP1010.PAY_CHANNEL_NNUMBER = Me.PAY_CHANNEL_NNUMBER      '付費頻道數
                Me.Ent_APP1010.CHANGE_STANDARD = Me.CHANGE_STANDARD      '收費標準
                Me.Ent_APP1010.SETUP_ORG_FLAG = Me.SETUP_ORG_FLAG        '建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1010.ORG_NAME = Me.ORG_NAME        '自律組織名稱
                Me.Ent_APP1010.PUNISH_NUMBER = Me.PUNISH_NUMBER      '評鑑期間核處紀錄件數
                Me.Ent_APP1010.IN_CHANNEL_NUMBER = Me.IN_CHANNEL_NUMBER      '境內頻道數量
                Me.Ent_APP1010.IN_CHANNEL_NAME = Me.IN_CHANNEL_NAME      '境內頻道名稱
                Me.Ent_APP1010.EX__CHANNEL_NUMBER = Me.EX__CHANNEL_NUMBER        '境外頻道數量
                Me.Ent_APP1010.EX_CHANNEL_NAME = Me.EX_CHANNEL_NAME      '境外頻道名稱
                Me.Ent_APP1010.IN_COM_NAME1 = Me.IN_COM_NAME1        '境內直播衛星服務經營者名稱
                Me.Ent_APP1010.EX_COM_NAME1 = Me.EX_COM_NAME1        '境外直播衛星服務經營者名稱
                Me.Ent_APP1010.ADD_DESC = Me.ADD_DESC        '
                Me.Ent_APP1010.IN_COM_FLAG = Me.IN_COM_FLAG      '境內直播衛星服務經營者,Y：有勾選
                Me.Ent_APP1010.EX_COM_FLAG = Me.EX_COM_FLAG      '境外直播衛星服務經營者,Y：有勾選


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1010.Update()

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
                Me.Ent_APP1010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1010.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON_NM", Me.APP_PERSON_NM)      '申請人名稱
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE", Me.ORG_TYPE)        '組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
                Me.ProcessQueryCondition(condition, "=", "TOTAL_PROPERTY", Me.TOTAL_PROPERTY)        '實收資本額
                Me.ProcessQueryCondition(condition, "=", "DECLARE_1", Me.DECLARE_1)      '自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_2", Me.DECLARE_2)      '自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_3", Me.DECLARE_3)      '自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_CNAME", Me.SYS_CNAME)         '申請經營之系統服務/頻道名稱(中文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_CNAME", Me.SYS_S_CNAME)         '中文簡稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_ENAME", Me.SYS_ENAME)         '申請經營之系統服務/頻道名稱(英文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_ENAME", Me.SYS_S_ENAME)         '英文簡稱
                Me.ProcessQueryCondition(condition, "=", "REPRESENTATIVE", Me.REPRESENTATIVE)        '代表人/負責人
                Me.ProcessQueryCondition(condition, "=", "IS_FOREIGNER", Me.IS_FOREIGNER)        '本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
                Me.ProcessQueryCondition(condition, "=", "PID", Me.PID)      '身份證字號
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)      '國籍
                Me.ProcessQueryCondition(condition, "=", "PASSPORT_ID", Me.PASSPORT_ID)      '護照號碼
                Me.ProcessQueryCondition(condition, "=", "LIVE_CITY", Me.LIVE_CITY)      '住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ZIP", Me.LIVE_ZIP)        '住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ADDRESS", Me.LIVE_ADDRESS)        '住居所
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY)      '營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ZIP", Me.BUSINESS_ZIP)        '營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ADDRESS", Me.BUSINESS_ADDRESS)        '營業地址/事業地址
                Me.ProcessQueryCondition(condition, "=", "MAILING_CITY", Me.MAILING_CITY)        '通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ZIP", Me.MAILING_ZIP)      '通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ADDRESS", Me.MAILING_ADDRESS)      '通訊地址
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_AREA_CODE", Me.BUSINESS_AREA_CODE)        '營業電話區碼
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_TEL", Me.BUSINESS_TEL)        '營業電話
                Me.ProcessQueryCondition(condition, "=", "START_SCH_DATE", Me.START_SCH_DATE)        '預定開播日期
                Me.ProcessQueryCondition(condition, "=", "CONTACT_PERSON", Me.CONTACT_PERSON)        '聯絡人
                Me.ProcessQueryCondition(condition, "=", "CONTACT_AREA_CODE", Me.CONTACT_AREA_CODE)      '聯絡電話區碼
                Me.ProcessQueryCondition(condition, "=", "CONTACT_TEL", Me.CONTACT_TEL)      '聯絡電話
                Me.ProcessQueryCondition(condition, "=", "EMAIL", Me.EMAIL)      '電子郵件信箱
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_CITY", Me.CONTACT_ADDRESS_CITY)        '聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_ZIP", Me.CONTACT_ADDRESS_ZIP)      '聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS", Me.CONTACT_ADDRESS)      '聯絡地址
                Me.ProcessQueryCondition(condition, "=", "FOREIGNER_CAL_BASE_DATE", Me.FOREIGNER_CAL_BASE_DATE)      '外國人持股比例計算基準日
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG)      '限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "CH_RANK1", Me.CH_RANK1)        '新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK2", Me.CH_RANK2)        '財經新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK3", Me.CH_RANK3)        '財經股市-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK4", Me.CH_RANK4)        '兒少-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK5", Me.CH_RANK5)        '戲劇-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK6", Me.CH_RANK6)        '電影-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK7", Me.CH_RANK7)        '體育-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK8", Me.CH_RANK8)        'CH_RANK8
                Me.ProcessQueryCondition(condition, "=", "CH_RANK9", Me.CH_RANK9)        '音樂-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK10", Me.CH_RANK10)      '宗教-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK11", Me.CH_RANK11)      '綜合-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK12", Me.CH_RANK12)      '其他類型-排名
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_RANK_DESC", Me.CH_RANK_DESC)       '其他類型-說明
                Me.ProcessQueryCondition(condition, "=", "LOCAL_CHANNEL_FLAG", Me.LOCAL_CHANNEL_FLAG)        '地方頻道,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CABLE_NAME", Me.CABLE_NAME)       '系統名稱
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CITY", Me.OPERATION_CITY)        '經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_ZIP", Me.OPERATION_ZIP)      '經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "APPOINT_AREA", Me.APPOINT_AREA)        '指定區域
                Me.ProcessQueryCondition(condition, "=", "BOOKING_PLATFORM", Me.BOOKING_PLATFORM)        '預訂上架之系統平臺
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE)        '節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME", Me.EX_COM_NAME)         '境外衛星廣播電視事業名稱
                Me.ProcessQueryCondition(condition, "=", "EX_COM_COUNTRY", Me.EX_COM_COUNTRY)        '境外衛星廣播電視事業國籍
                Me.ProcessQueryCondition(condition, "%LIKE%", "APP_NAME", Me.APP_NAME)       '申請標的
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_AREA_CODE", Me.COMPLAINT_AREA_CODE)      '申訴管道-客服電話區碼
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_TEL", Me.COMPLAINT_TEL)      '申訴管道-客服電話
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_EMAIL", Me.COMPLAINT_EMAIL)      '申訴管道-電子郵件
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_OTHER", Me.COMPLAINT_OTHER)      '申訴管道-其他
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '執照號碼
                Me.ProcessQueryCondition(condition, "=", "SETUP_DATE", Me.SETUP_DATE)        '成立時間
                Me.ProcessQueryCondition(condition, "=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)        '執照(許可)效期/目前執照期間(起)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)        '執照(許可)效期/目前執照期間(迄)
                Me.ProcessQueryCondition(condition, "=", "WEB_URL", Me.WEB_URL)      '電臺網址/事業網址
                Me.ProcessQueryCondition(condition, "=", "SETUP_PURPOSE", Me.SETUP_PURPOSE)      '設臺宗旨
                Me.ProcessQueryCondition(condition, "=", "E_RESULT1", Me.E_RESULT1)      '執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "E_RESULT2", Me.E_RESULT2)      '執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE1", Me.OPERATION_S_DATE1)      '營運計畫執行期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE1", Me.OPERATION_E_DATE1)      '營運計畫執行期間(迄)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE2", Me.OPERATION_S_DATE2)      '未來營運計畫期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE2", Me.OPERATION_E_DATE2)      '未來營運計畫期間(迄)
                Me.ProcessQueryCondition(condition, "=", "RADIO_TYPE", Me.RADIO_TYPE)        '電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_S_DATE", Me.EVALUATION_S_DATE)      '評鑑期間(起)
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_E_DATE", Me.EVALUATION_E_DATE)      '評鑑期間(迄)
                Me.ProcessQueryCondition(condition, "=", "PLAY_S_DATE", Me.PLAY_S_DATE)      '開播日期
                Me.ProcessQueryCondition(condition, "=", "SB_AMT1", Me.SB_AMT1)      '前1年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT2", Me.SB_AMT2)      '前2年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT3", Me.SB_AMT3)      '前3年度營業額
                Me.ProcessQueryCondition(condition, "=", "EMPLOYEE_NUMBER", Me.EMPLOYEE_NUMBER)      '員工人數
                Me.ProcessQueryCondition(condition, "=", "SUBSCRIBE_NUMBER", Me.SUBSCRIBE_NUMBER)        '總訂戶數
                Me.ProcessQueryCondition(condition, "=", "BASE_CHANNEL_NNUMBER", Me.BASE_CHANNEL_NNUMBER)        '基本頻道數
                Me.ProcessQueryCondition(condition, "=", "PAY_CHANNEL_NNUMBER", Me.PAY_CHANNEL_NNUMBER)      '付費頻道數
                Me.ProcessQueryCondition(condition, "=", "CHANGE_STANDARD", Me.CHANGE_STANDARD)      '收費標準
                Me.ProcessQueryCondition(condition, "=", "SETUP_ORG_FLAG", Me.SETUP_ORG_FLAG)        '建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "ORG_NAME", Me.ORG_NAME)       '自律組織名稱
                Me.ProcessQueryCondition(condition, "=", "PUNISH_NUMBER", Me.PUNISH_NUMBER)      '評鑑期間核處紀錄件數
                Me.ProcessQueryCondition(condition, "=", "IN_CHANNEL_NUMBER", Me.IN_CHANNEL_NUMBER)      '境內頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_CHANNEL_NAME", Me.IN_CHANNEL_NAME)         '境內頻道名稱
                Me.ProcessQueryCondition(condition, "=", "EX__CHANNEL_NUMBER", Me.EX__CHANNEL_NUMBER)        '境外頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_CHANNEL_NAME", Me.EX_CHANNEL_NAME)         '境外頻道名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_COM_NAME1", Me.IN_COM_NAME1)       '境內直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME1", Me.EX_COM_NAME1)       '境外直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "ADD_DESC", Me.ADD_DESC)       '
                Me.ProcessQueryCondition(condition, "=", "IN_COM_FLAG", Me.IN_COM_FLAG)      '境內直播衛星服務經營者,Y：有勾選
                Me.ProcessQueryCondition(condition, "=", "EX_COM_FLAG", Me.EX_COM_FLAG)      '境外直播衛星服務經營者,Y：有勾選

                Me.Ent_APP1010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1010.Query()
                Else
                    result = Me.Ent_APP1010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery get ORG_TYPE"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQueryORG_TYPE() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON_NM", Me.APP_PERSON_NM)      '申請人名稱
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE", Me.ORG_TYPE)        '組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
                Me.ProcessQueryCondition(condition, "=", "TOTAL_PROPERTY", Me.TOTAL_PROPERTY)        '實收資本額
                Me.ProcessQueryCondition(condition, "=", "DECLARE_1", Me.DECLARE_1)      '自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_2", Me.DECLARE_2)      '自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_3", Me.DECLARE_3)      '自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_CNAME", Me.SYS_CNAME)         '申請經營之系統服務/頻道名稱(中文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_CNAME", Me.SYS_S_CNAME)         '中文簡稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_ENAME", Me.SYS_ENAME)         '申請經營之系統服務/頻道名稱(英文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_ENAME", Me.SYS_S_ENAME)         '英文簡稱
                Me.ProcessQueryCondition(condition, "=", "REPRESENTATIVE", Me.REPRESENTATIVE)        '代表人/負責人
                Me.ProcessQueryCondition(condition, "=", "IS_FOREIGNER", Me.IS_FOREIGNER)        '本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
                Me.ProcessQueryCondition(condition, "=", "PID", Me.PID)      '身份證字號
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)      '國籍
                Me.ProcessQueryCondition(condition, "=", "PASSPORT_ID", Me.PASSPORT_ID)      '護照號碼
                Me.ProcessQueryCondition(condition, "=", "LIVE_CITY", Me.LIVE_CITY)      '住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ZIP", Me.LIVE_ZIP)        '住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ADDRESS", Me.LIVE_ADDRESS)        '住居所
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY)      '營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ZIP", Me.BUSINESS_ZIP)        '營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ADDRESS", Me.BUSINESS_ADDRESS)        '營業地址/事業地址
                Me.ProcessQueryCondition(condition, "=", "MAILING_CITY", Me.MAILING_CITY)        '通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ZIP", Me.MAILING_ZIP)      '通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ADDRESS", Me.MAILING_ADDRESS)      '通訊地址
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_AREA_CODE", Me.BUSINESS_AREA_CODE)        '營業電話區碼
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_TEL", Me.BUSINESS_TEL)        '營業電話
                Me.ProcessQueryCondition(condition, "=", "START_SCH_DATE", Me.START_SCH_DATE)        '預定開播日期
                Me.ProcessQueryCondition(condition, "=", "CONTACT_PERSON", Me.CONTACT_PERSON)        '聯絡人
                Me.ProcessQueryCondition(condition, "=", "CONTACT_AREA_CODE", Me.CONTACT_AREA_CODE)      '聯絡電話區碼
                Me.ProcessQueryCondition(condition, "=", "CONTACT_TEL", Me.CONTACT_TEL)      '聯絡電話
                Me.ProcessQueryCondition(condition, "=", "EMAIL", Me.EMAIL)      '電子郵件信箱
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_CITY", Me.CONTACT_ADDRESS_CITY)        '聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_ZIP", Me.CONTACT_ADDRESS_ZIP)      '聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS", Me.CONTACT_ADDRESS)      '聯絡地址
                Me.ProcessQueryCondition(condition, "=", "FOREIGNER_CAL_BASE_DATE", Me.FOREIGNER_CAL_BASE_DATE)      '外國人持股比例計算基準日
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG)      '限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "CH_RANK1", Me.CH_RANK1)        '新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK2", Me.CH_RANK2)        '財經新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK3", Me.CH_RANK3)        '財經股市-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK4", Me.CH_RANK4)        '兒少-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK5", Me.CH_RANK5)        '戲劇-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK6", Me.CH_RANK6)        '電影-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK7", Me.CH_RANK7)        '體育-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK8", Me.CH_RANK8)        'CH_RANK8
                Me.ProcessQueryCondition(condition, "=", "CH_RANK9", Me.CH_RANK9)        '音樂-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK10", Me.CH_RANK10)      '宗教-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK11", Me.CH_RANK11)      '綜合-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK12", Me.CH_RANK12)      '其他類型-排名
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_RANK_DESC", Me.CH_RANK_DESC)       '其他類型-說明
                Me.ProcessQueryCondition(condition, "=", "LOCAL_CHANNEL_FLAG", Me.LOCAL_CHANNEL_FLAG)        '地方頻道,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CABLE_NAME", Me.CABLE_NAME)       '系統名稱
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CITY", Me.OPERATION_CITY)        '經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_ZIP", Me.OPERATION_ZIP)      '經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "APPOINT_AREA", Me.APPOINT_AREA)        '指定區域
                Me.ProcessQueryCondition(condition, "=", "BOOKING_PLATFORM", Me.BOOKING_PLATFORM)        '預訂上架之系統平臺
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE)        '節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME", Me.EX_COM_NAME)         '境外衛星廣播電視事業名稱
                Me.ProcessQueryCondition(condition, "=", "EX_COM_COUNTRY", Me.EX_COM_COUNTRY)        '境外衛星廣播電視事業國籍
                Me.ProcessQueryCondition(condition, "%LIKE%", "APP_NAME", Me.APP_NAME)       '申請標的
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_AREA_CODE", Me.COMPLAINT_AREA_CODE)      '申訴管道-客服電話區碼
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_TEL", Me.COMPLAINT_TEL)      '申訴管道-客服電話
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_EMAIL", Me.COMPLAINT_EMAIL)      '申訴管道-電子郵件
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_OTHER", Me.COMPLAINT_OTHER)      '申訴管道-其他
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '執照號碼
                Me.ProcessQueryCondition(condition, "=", "SETUP_DATE", Me.SETUP_DATE)        '成立時間
                Me.ProcessQueryCondition(condition, "=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)        '執照(許可)效期/目前執照期間(起)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)        '執照(許可)效期/目前執照期間(迄)
                Me.ProcessQueryCondition(condition, "=", "WEB_URL", Me.WEB_URL)      '電臺網址/事業網址
                Me.ProcessQueryCondition(condition, "=", "SETUP_PURPOSE", Me.SETUP_PURPOSE)      '設臺宗旨
                Me.ProcessQueryCondition(condition, "=", "E_RESULT1", Me.E_RESULT1)      '執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "E_RESULT2", Me.E_RESULT2)      '執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE1", Me.OPERATION_S_DATE1)      '營運計畫執行期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE1", Me.OPERATION_E_DATE1)      '營運計畫執行期間(迄)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE2", Me.OPERATION_S_DATE2)      '未來營運計畫期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE2", Me.OPERATION_E_DATE2)      '未來營運計畫期間(迄)
                Me.ProcessQueryCondition(condition, "=", "RADIO_TYPE", Me.RADIO_TYPE)        '電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_S_DATE", Me.EVALUATION_S_DATE)      '評鑑期間(起)
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_E_DATE", Me.EVALUATION_E_DATE)      '評鑑期間(迄)
                Me.ProcessQueryCondition(condition, "=", "PLAY_S_DATE", Me.PLAY_S_DATE)      '開播日期
                Me.ProcessQueryCondition(condition, "=", "SB_AMT1", Me.SB_AMT1)      '前1年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT2", Me.SB_AMT2)      '前2年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT3", Me.SB_AMT3)      '前3年度營業額
                Me.ProcessQueryCondition(condition, "=", "EMPLOYEE_NUMBER", Me.EMPLOYEE_NUMBER)      '員工人數
                Me.ProcessQueryCondition(condition, "=", "SUBSCRIBE_NUMBER", Me.SUBSCRIBE_NUMBER)        '總訂戶數
                Me.ProcessQueryCondition(condition, "=", "BASE_CHANNEL_NNUMBER", Me.BASE_CHANNEL_NNUMBER)        '基本頻道數
                Me.ProcessQueryCondition(condition, "=", "PAY_CHANNEL_NNUMBER", Me.PAY_CHANNEL_NNUMBER)      '付費頻道數
                Me.ProcessQueryCondition(condition, "=", "CHANGE_STANDARD", Me.CHANGE_STANDARD)      '收費標準
                Me.ProcessQueryCondition(condition, "=", "SETUP_ORG_FLAG", Me.SETUP_ORG_FLAG)        '建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "ORG_NAME", Me.ORG_NAME)       '自律組織名稱
                Me.ProcessQueryCondition(condition, "=", "PUNISH_NUMBER", Me.PUNISH_NUMBER)      '評鑑期間核處紀錄件數
                Me.ProcessQueryCondition(condition, "=", "IN_CHANNEL_NUMBER", Me.IN_CHANNEL_NUMBER)      '境內頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_CHANNEL_NAME", Me.IN_CHANNEL_NAME)         '境內頻道名稱
                Me.ProcessQueryCondition(condition, "=", "EX__CHANNEL_NUMBER", Me.EX__CHANNEL_NUMBER)        '境外頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_CHANNEL_NAME", Me.EX_CHANNEL_NAME)         '境外頻道名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_COM_NAME1", Me.IN_COM_NAME1)       '境內直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME1", Me.EX_COM_NAME1)       '境外直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "ADD_DESC", Me.ADD_DESC)       '
                Me.ProcessQueryCondition(condition, "=", "IN_COM_FLAG", Me.IN_COM_FLAG)      '境內直播衛星服務經營者,Y：有勾選
                Me.ProcessQueryCondition(condition, "=", "EX_COM_FLAG", Me.EX_COM_FLAG)      '境外直播衛星服務經營者,Y：有勾選

                Me.Ent_APP1010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1010.QueryORG_TYPE()
                Else
                    result = Me.Ent_APP1010.QueryORG_TYPE(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQuery 進行查詢動作 for web service"
        '' <summary>
        '' 進行查詢動作 for web service
        '' </summary>
        Public Function DoQuery_WS() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "APP_PERSON_NM", Me.APP_PERSON_NM)      '申請人名稱
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE", Me.ORG_TYPE)        '組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
                Me.ProcessQueryCondition(condition, "=", "TOTAL_PROPERTY", Me.TOTAL_PROPERTY)        '實收資本額
                Me.ProcessQueryCondition(condition, "=", "DECLARE_1", Me.DECLARE_1)      '自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_2", Me.DECLARE_2)      '自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "DECLARE_3", Me.DECLARE_3)      '自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_CNAME", Me.SYS_CNAME)         '申請經營之系統服務/頻道名稱(中文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_CNAME", Me.SYS_S_CNAME)         '中文簡稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_ENAME", Me.SYS_ENAME)         '申請經營之系統服務/頻道名稱(英文)
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_S_ENAME", Me.SYS_S_ENAME)         '英文簡稱
                Me.ProcessQueryCondition(condition, "=", "REPRESENTATIVE", Me.REPRESENTATIVE)        '代表人/負責人
                Me.ProcessQueryCondition(condition, "=", "IS_FOREIGNER", Me.IS_FOREIGNER)        '本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
                Me.ProcessQueryCondition(condition, "=", "PID", Me.PID)      '身份證字號
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)      '國籍
                Me.ProcessQueryCondition(condition, "=", "PASSPORT_ID", Me.PASSPORT_ID)      '護照號碼
                Me.ProcessQueryCondition(condition, "=", "LIVE_CITY", Me.LIVE_CITY)      '住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ZIP", Me.LIVE_ZIP)        '住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "LIVE_ADDRESS", Me.LIVE_ADDRESS)        '住居所
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY)      '營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ZIP", Me.BUSINESS_ZIP)        '營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_ADDRESS", Me.BUSINESS_ADDRESS)        '營業地址/事業地址
                Me.ProcessQueryCondition(condition, "=", "MAILING_CITY", Me.MAILING_CITY)        '通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ZIP", Me.MAILING_ZIP)      '通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "MAILING_ADDRESS", Me.MAILING_ADDRESS)      '通訊地址
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_AREA_CODE", Me.BUSINESS_AREA_CODE)        '營業電話區碼
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_TEL", Me.BUSINESS_TEL)        '營業電話
                Me.ProcessQueryCondition(condition, "=", "START_SCH_DATE", Me.START_SCH_DATE)        '預定開播日期
                Me.ProcessQueryCondition(condition, "=", "CONTACT_PERSON", Me.CONTACT_PERSON)        '聯絡人
                Me.ProcessQueryCondition(condition, "=", "CONTACT_AREA_CODE", Me.CONTACT_AREA_CODE)      '聯絡電話區碼
                Me.ProcessQueryCondition(condition, "=", "CONTACT_TEL", Me.CONTACT_TEL)      '聯絡電話
                Me.ProcessQueryCondition(condition, "=", "EMAIL", Me.EMAIL)      '電子郵件信箱
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_CITY", Me.CONTACT_ADDRESS_CITY)        '聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS_ZIP", Me.CONTACT_ADDRESS_ZIP)      '聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "CONTACT_ADDRESS", Me.CONTACT_ADDRESS)      '聯絡地址
                Me.ProcessQueryCondition(condition, "=", "FOREIGNER_CAL_BASE_DATE", Me.FOREIGNER_CAL_BASE_DATE)      '外國人持股比例計算基準日
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG)      '限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "CH_RANK1", Me.CH_RANK1)        '新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK2", Me.CH_RANK2)        '財經新聞-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK3", Me.CH_RANK3)        '財經股市-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK4", Me.CH_RANK4)        '兒少-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK5", Me.CH_RANK5)        '戲劇-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK6", Me.CH_RANK6)        '電影-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK7", Me.CH_RANK7)        '體育-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK8", Me.CH_RANK8)        'CH_RANK8
                Me.ProcessQueryCondition(condition, "=", "CH_RANK9", Me.CH_RANK9)        '音樂-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK10", Me.CH_RANK10)      '宗教-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK11", Me.CH_RANK11)      '綜合-排名
                Me.ProcessQueryCondition(condition, "=", "CH_RANK12", Me.CH_RANK12)      '其他類型-排名
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_RANK_DESC", Me.CH_RANK_DESC)       '其他類型-說明
                Me.ProcessQueryCondition(condition, "=", "LOCAL_CHANNEL_FLAG", Me.LOCAL_CHANNEL_FLAG)        '地方頻道,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CABLE_NAME", Me.CABLE_NAME)       '系統名稱
                Me.ProcessQueryCondition(condition, "=", "OPERATION_CITY", Me.OPERATION_CITY)        '經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_ZIP", Me.OPERATION_ZIP)      '經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
                Me.ProcessQueryCondition(condition, "=", "APPOINT_AREA", Me.APPOINT_AREA)        '指定區域
                Me.ProcessQueryCondition(condition, "=", "BOOKING_PLATFORM", Me.BOOKING_PLATFORM)        '預訂上架之系統平臺
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE)        '節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME", Me.EX_COM_NAME)         '境外衛星廣播電視事業名稱
                Me.ProcessQueryCondition(condition, "=", "EX_COM_COUNTRY", Me.EX_COM_COUNTRY)        '境外衛星廣播電視事業國籍
                Me.ProcessQueryCondition(condition, "%LIKE%", "APP_NAME", Me.APP_NAME)       '申請標的
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_AREA_CODE", Me.COMPLAINT_AREA_CODE)      '申訴管道-客服電話區碼
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_TEL", Me.COMPLAINT_TEL)      '申訴管道-客服電話
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_EMAIL", Me.COMPLAINT_EMAIL)      '申訴管道-電子郵件
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_OTHER", Me.COMPLAINT_OTHER)      '申訴管道-其他
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO", Me.LICENSE_NO)        '執照號碼
                Me.ProcessQueryCondition(condition, "=", "SETUP_DATE", Me.SETUP_DATE)        '成立時間
                Me.ProcessQueryCondition(condition, "=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)        '執照(許可)效期/目前執照期間(起)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)        '執照(許可)效期/目前執照期間(迄)
                Me.ProcessQueryCondition(condition, "=", "WEB_URL", Me.WEB_URL)      '電臺網址/事業網址
                Me.ProcessQueryCondition(condition, "=", "SETUP_PURPOSE", Me.SETUP_PURPOSE)      '設臺宗旨
                Me.ProcessQueryCondition(condition, "=", "E_RESULT1", Me.E_RESULT1)      '執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "E_RESULT2", Me.E_RESULT2)      '執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE1", Me.OPERATION_S_DATE1)      '營運計畫執行期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE1", Me.OPERATION_E_DATE1)      '營運計畫執行期間(迄)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_S_DATE2", Me.OPERATION_S_DATE2)      '未來營運計畫期間(起)
                Me.ProcessQueryCondition(condition, "=", "OPERATION_E_DATE2", Me.OPERATION_E_DATE2)      '未來營運計畫期間(迄)
                Me.ProcessQueryCondition(condition, "=", "RADIO_TYPE", Me.RADIO_TYPE)        '電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_S_DATE", Me.EVALUATION_S_DATE)      '評鑑期間(起)
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_E_DATE", Me.EVALUATION_E_DATE)      '評鑑期間(迄)
                Me.ProcessQueryCondition(condition, "=", "PLAY_S_DATE", Me.PLAY_S_DATE)      '開播日期
                Me.ProcessQueryCondition(condition, "=", "SB_AMT1", Me.SB_AMT1)      '前1年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT2", Me.SB_AMT2)      '前2年度營業額
                Me.ProcessQueryCondition(condition, "=", "SB_AMT3", Me.SB_AMT3)      '前3年度營業額
                Me.ProcessQueryCondition(condition, "=", "EMPLOYEE_NUMBER", Me.EMPLOYEE_NUMBER)      '員工人數
                Me.ProcessQueryCondition(condition, "=", "SUBSCRIBE_NUMBER", Me.SUBSCRIBE_NUMBER)        '總訂戶數
                Me.ProcessQueryCondition(condition, "=", "BASE_CHANNEL_NNUMBER", Me.BASE_CHANNEL_NNUMBER)        '基本頻道數
                Me.ProcessQueryCondition(condition, "=", "PAY_CHANNEL_NNUMBER", Me.PAY_CHANNEL_NNUMBER)      '付費頻道數
                Me.ProcessQueryCondition(condition, "=", "CHANGE_STANDARD", Me.CHANGE_STANDARD)      '收費標準
                Me.ProcessQueryCondition(condition, "=", "SETUP_ORG_FLAG", Me.SETUP_ORG_FLAG)        '建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "ORG_NAME", Me.ORG_NAME)       '自律組織名稱
                Me.ProcessQueryCondition(condition, "=", "PUNISH_NUMBER", Me.PUNISH_NUMBER)      '評鑑期間核處紀錄件數
                Me.ProcessQueryCondition(condition, "=", "IN_CHANNEL_NUMBER", Me.IN_CHANNEL_NUMBER)      '境內頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_CHANNEL_NAME", Me.IN_CHANNEL_NAME)         '境內頻道名稱
                Me.ProcessQueryCondition(condition, "=", "EX__CHANNEL_NUMBER", Me.EX__CHANNEL_NUMBER)        '境外頻道數量
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_CHANNEL_NAME", Me.EX_CHANNEL_NAME)         '境外頻道名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "IN_COM_NAME1", Me.IN_COM_NAME1)       '境內直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "EX_COM_NAME1", Me.EX_COM_NAME1)       '境外直播衛星服務經營者名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "ADD_DESC", Me.ADD_DESC)       '
                Me.ProcessQueryCondition(condition, "=", "IN_COM_FLAG", Me.IN_COM_FLAG)      '境內直播衛星服務經營者,Y：有勾選
                Me.ProcessQueryCondition(condition, "=", "EX_COM_FLAG", Me.EX_COM_FLAG)      '境外直播衛星服務經營者,Y：有勾選

                Me.Ent_APP1010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1010.Query_WS()
                Else
                    result = Me.Ent_APP1010.Query_WS(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryAll 進行查詢動作"
        '' <summary>
        '' 進行查詢動作 for print word use
        '' </summary>
        Public Function DoQueryAll() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then
                    faileArguments.Add("CASE_NO")
                End If

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "M.CASE_NO", Me.CASE_NO)      '案件編號

                Me.Ent_APP1010.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = " M.CASE_NO "
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1010.DoQueryAll()
                Else
                    result = Me.Ent_APP1010.DoQueryAll(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryView 進行查詢動作"
        '' <summary>
        '' 進行查詢動作 for 綜合查詢
        '' </summary>
        Public Function DoQueryView() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()


                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, ">=", "CREATE_TIME", Me.CREATE_TIME_S) '申請日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, "<=", "CREATE_TIME", Me.CREATE_TIME_E) '申請日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, ">=", "LICENSE_S_DATE", Me.LICENSE_S_DATE) '許可日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, "<=", "LICENSE_E_DATE", Me.LICENSE_E_DATE) '許可日期(日期擇一填寫)                 
                Me.ProcessQueryCondition(condition, "=", "事業類別1", Me.SYS_RSV) '事業類別
                Me.ProcessQueryCondition(condition, "=", "事業類別2", Me.SYS_RSV2) '事業類別
                Me.ProcessQueryCondition(condition, "=", "申請項目", Me.SYS_RSV1) '申請項目
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE", Me.ORG_TYPE) '組織型態
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE) '傳輸方式(僅衛廣)
                Me.ProcessQueryCondition(condition, "=", "頻道屬性", Me.LOCAL_CHANNEL_FLAG) '頻道屬性(僅衛廣)
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG) '鎖碼與否(僅衛廣)
                'Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE) '上架平台(僅衛廣，可複選)
                'Me.ProcessQueryCondition(condition, "=", "SHOW_ATTRIBUTE", Me.SHOW_ATTRIBUTE) '頻道節目屬性(可複選)
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY) '縣市別(登記地址)
                Me.ProcessQueryCondition(condition, "=", "MAILING_CITY", Me.MAILING_CITY) '縣市別(通訊地址)
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS) '案件狀態
                Me.ProcessQueryCondition(condition, "=", "BUS_NO", Me.BUS_NO) '統一編號
                Me.ProcessQueryCondition(condition, "=", "SYS_CNAME", Me.SYS_CNAME) '頻道名稱
                Me.ProcessQueryCondition(condition, "=", "申請者", Me.APP_PERSON_NM) '公司名稱

                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND CASE_STATUS in ('" + Me.CASE_STATUS.ToString().Replace(",", "','") + "')")
                End If

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = " CASE_NO "
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If
                Me.Ent_APP1010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1010.DoQueryView()
                Else
                    result = Me.Ent_APP1010.DoQueryView(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1010.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result
 
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryStatistics 進行查詢動作"
        '' <summary>
        '' 進行查詢動作 for 綜合查詢
        '' </summary>
        Public Function QueryStatistics() As DataSet
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim faileArguments As ArrayList = New ArrayList()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, ">=", "CREATE_TIME", Me.CREATE_TIME_S) '申請日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, "<=", "CREATE_TIME", Me.CREATE_TIME_E) '申請日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, ">=", "LICENSE_S_DATE", Me.LICENSE_S_DATE) '許可日期(日期擇一填寫)
                Me.ProcessQueryCondition(condition, "<=", "LICENSE_E_DATE", Me.LICENSE_E_DATE) '許可日期(日期擇一填寫)                 
                Me.ProcessQueryCondition(condition, "=", "事業類別1", Me.SYS_RSV) '事業類別
                Me.ProcessQueryCondition(condition, "=", "事業類別2", Me.SYS_RSV2) '事業類別
                Me.ProcessQueryCondition(condition, "=", "申請項目", Me.SYS_RSV1) '申請項目
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE", Me.ORG_TYPE) '組織型態
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE) '傳輸方式(僅衛廣)
                Me.ProcessQueryCondition(condition, "=", "頻道屬性", Me.LOCAL_CHANNEL_FLAG) '頻道屬性(僅衛廣)
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG) '鎖碼與否(僅衛廣)
                'Me.ProcessQueryCondition(condition, "=", "CHSYS_TYPE", Me.CHSYS_TYPE) '上架平台(僅衛廣，可複選)
                'Me.ProcessQueryCondition(condition, "=", "SHOW_ATTRIBUTE", Me.SHOW_ATTRIBUTE) '頻道節目屬性(可複選)
                Me.ProcessQueryCondition(condition, "=", "BUSINESS_CITY", Me.BUSINESS_CITY) '縣市別(登記地址)
                Me.ProcessQueryCondition(condition, "=", "MAILING_CITY", Me.MAILING_CITY) '縣市別(通訊地址)
                'Me.ProcessQueryCondition(condition, "=", "CASE_STATUS", Me.CASE_STATUS) '案件狀態
                If Not String.IsNullOrEmpty(Me.CASE_STATUS) Then
                    condition.Append(" AND CASE_STATUS in ('" + Me.CASE_STATUS.ToString().Replace(",", "','") + "')")
                End If

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                '報表類別
                If (String.IsNullOrEmpty(Me.R_TYPE)) Then
                    Me.Ent_APP1010.R_TYPE = "M"
                Else
                    Me.Ent_APP1010.R_TYPE = Me.R_TYPE
                End If

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1010.OrderBys = " CASE_NO "
                Else
                    Me.Ent_APP1010.OrderBys = Me.OrderBys
                End If

                Me.Ent_APP1010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataSet = Me.Ent_APP1010.QueryStatistics()

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

