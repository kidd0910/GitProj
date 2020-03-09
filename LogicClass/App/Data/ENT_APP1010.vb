'----------------------------------------------------------------------------------
'File Name		: APP1010
'Author			:  
'Description		: APP1010 申設_直播衛星事業申設申請書_基本資料
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/23	 		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1010 申設_直播衛星事業申設申請書_基本資料
    ' </summary>
    Public Class ENT_APP1010
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        ' <summary>
        ' 建構子/處理屬性對應處理
        ' </summary>
        ' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' 建構子/處理異動處理
        ' </summary>
        ' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "APP1010"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            'Me.LONG_FIELD_NAME = "CASE_NO,APP_PERSON_NM,TOTAL_PROPERTY,SYS_CNAME,SYS_S_CNAME,SYS_ENAME,SYS_S_ENAME,REPRESENTATIVE,PID,COUNTRY,PASSPORT_ID,LIVE_ADDRESS,BUSINESS_ADDRESS,MAILING_ADDRESS,BUSINESS_TEL,CONTACT_PERSON,CONTACT_AREA_CODE,CONTACT_TEL,CONTACT_ADDRESS,CH_RANK_DESC,CABLE_NAME,APPOINT_AREA,BOOKING_PLATFORM,EX_COM_NAME,EX_COM_COUNTRY,APP_NAME,COMPLAINT_TEL,COMPLAINT_OTHER,LICENSE_NO,WEB_URL,SETUP_PURPOSE,CHANGE_STANDARD,ORG_NAME,IN_CHANNEL_NAME,EX_CHANNEL_NAME,IN_COM_NAME1,EX_COM_NAME1,ADD_DESC"
            Me.LONG_FIELD_NAME = "CASE_NO,APP_PERSON_NM,SYS_CNAME,SYS_S_CNAME,SYS_ENAME,SYS_S_ENAME,REPRESENTATIVE,PID,COUNTRY,PASSPORT_ID,LIVE_ADDRESS,BUSINESS_ADDRESS,MAILING_ADDRESS,BUSINESS_TEL,CONTACT_PERSON,CONTACT_AREA_CODE,CONTACT_TEL,CONTACT_ADDRESS,CH_RANK_DESC,CABLE_NAME,APPOINT_AREA,BOOKING_PLATFORM,EX_COM_NAME,EX_COM_COUNTRY,APP_NAME,COMPLAINT_TEL,COMPLAINT_OTHER,LICENSE_NO,WEB_URL,SETUP_PURPOSE,CHANGE_STANDARD,ORG_NAME,IN_CHANNEL_NAME,EX_CHANNEL_NAME,IN_COM_NAME1,EX_COM_NAME1,ADD_DESC"
            Me.SET_NULL_FIELD = "START_SCH_DATE,TOTAL_PROPERTY,FOREIGNER_CAL_BASE_DATE,CH_RANK1,CH_RANK2,CH_RANK3,CH_RANK4,CH_RANK5,CH_RANK6,CH_RANK7,CH_RANK8,CH_RANK9,CH_RANK10,CH_RANK11,CH_RANK12,SETUP_DATE,LICENSE_S_DATE,LICENSE_E_DATE,OPERATION_S_DATE1,OPERATION_E_DATE1,OPERATION_S_DATE2,OPERATION_E_DATE2,EVALUATION_S_DATE,EVALUATION_E_DATE,PLAY_S_DATE,SB_AMT1,SB_AMT2,SB_AMT3,EMPLOYEE_NUMBER,SUBSCRIBE_NUMBER,BASE_CHANNEL_NNUMBER,PAY_CHANNEL_NNUMBER,PUNISH_NUMBER,IN_CHANNEL_NUMBER,EX__CHANNEL_NUMBER"

        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "APP_PERSON_NM 申請人名稱"
        '' <summary>
        '' APP_PERSON_NM 申請人名稱
        '' </summary>
        Public Property APP_PERSON_NM() As String
            Get
                Return Me.ColumnyMap("APP_PERSON_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_PERSON_NM") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE 組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'"
        '' <summary>
        '' ORG_TYPE 組織型態,REF. SYST010.SYS_KEY='ORG_TYPE'
        '' </summary>
        Public Property ORG_TYPE() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE") = value
            End Set
        End Property
#End Region

#Region "TOTAL_PROPERTY 實收資本額"
        '' <summary>
        '' TOTAL_PROPERTY 實收資本額
        '' </summary>
        Public Property TOTAL_PROPERTY() As String
            Get
                Return Me.ColumnyMap("TOTAL_PROPERTY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOTAL_PROPERTY") = value
            End Set
        End Property
#End Region

#Region "DECLARE_1 自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_1 自行聲明事項1,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_1() As String
            Get
                Return Me.ColumnyMap("DECLARE_1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_1") = value
            End Set
        End Property
#End Region

#Region "DECLARE_2 自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_2 自行聲明事項2,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_2() As String
            Get
                Return Me.ColumnyMap("DECLARE_2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_2") = value
            End Set
        End Property
#End Region

#Region "DECLARE_3 自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' DECLARE_3 自行聲明事項3,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property DECLARE_3() As String
            Get
                Return Me.ColumnyMap("DECLARE_3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DECLARE_3") = value
            End Set
        End Property
#End Region

#Region "SYS_CNAME 申請經營之系統服務/頻道名稱(中文)"
        '' <summary>
        '' SYS_CNAME 申請經營之系統服務/頻道名稱(中文)
        '' </summary>
        Public Property SYS_CNAME() As String
            Get
                Return Me.ColumnyMap("SYS_CNAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CNAME") = value
            End Set
        End Property
#End Region

#Region "SYS_S_CNAME 中文簡稱"
        '' <summary>
        '' SYS_S_CNAME 中文簡稱
        '' </summary>
        Public Property SYS_S_CNAME() As String
            Get
                Return Me.ColumnyMap("SYS_S_CNAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_S_CNAME") = value
            End Set
        End Property
#End Region

#Region "SYS_ENAME 申請經營之系統服務/頻道名稱(英文)"
        '' <summary>
        '' SYS_ENAME 申請經營之系統服務/頻道名稱(英文)
        '' </summary>
        Public Property SYS_ENAME() As String
            Get
                Return Me.ColumnyMap("SYS_ENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_ENAME") = value
            End Set
        End Property
#End Region

#Region "SYS_S_ENAME 英文簡稱"
        '' <summary>
        '' SYS_S_ENAME 英文簡稱
        '' </summary>
        Public Property SYS_S_ENAME() As String
            Get
                Return Me.ColumnyMap("SYS_S_ENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_S_ENAME") = value
            End Set
        End Property
#End Region

#Region "REPRESENTATIVE 代表人/負責人"
        '' <summary>
        '' REPRESENTATIVE 代表人/負責人
        '' </summary>
        Public Property REPRESENTATIVE() As String
            Get
                Return Me.ColumnyMap("REPRESENTATIVE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPRESENTATIVE") = value
            End Set
        End Property
#End Region

#Region "IS_FOREIGNER 本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'"
        '' <summary>
        '' IS_FOREIGNER 本國或外國人,REF. SYST010.SYS_KEY='COUNTRY_TYPE'
        '' </summary>
        Public Property IS_FOREIGNER() As String
            Get
                Return Me.ColumnyMap("IS_FOREIGNER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_FOREIGNER") = value
            End Set
        End Property
#End Region

#Region "PID 身份證字號"
        '' <summary>
        '' PID 身份證字號
        '' </summary>
        Public Property PID() As String
            Get
                Return Me.ColumnyMap("PID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PID") = value
            End Set
        End Property
#End Region

#Region "COUNTRY 國籍"
        '' <summary>
        '' COUNTRY 國籍
        '' </summary>
        Public Property COUNTRY() As String
            Get
                Return Me.ColumnyMap("COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY") = value
            End Set
        End Property
#End Region

#Region "PASSPORT_ID 護照號碼"
        '' <summary>
        '' PASSPORT_ID 護照號碼
        '' </summary>
        Public Property PASSPORT_ID() As String
            Get
                Return Me.ColumnyMap("PASSPORT_ID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PASSPORT_ID") = value
            End Set
        End Property
#End Region

#Region "LIVE_CITY 住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' LIVE_CITY 住居所-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property LIVE_CITY() As String
            Get
                Return Me.ColumnyMap("LIVE_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LIVE_CITY") = value
            End Set
        End Property
#End Region

#Region "LIVE_ZIP 住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' LIVE_ZIP 住居所-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property LIVE_ZIP() As String
            Get
                Return Me.ColumnyMap("LIVE_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LIVE_ZIP") = value
            End Set
        End Property
#End Region

#Region "LIVE_ADDRESS 住居所"
        '' <summary>
        '' LIVE_ADDRESS 住居所
        '' </summary>
        Public Property LIVE_ADDRESS() As String
            Get
                Return Me.ColumnyMap("LIVE_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LIVE_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_CITY 營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_CITY 營業地址/事業地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_CITY() As String
            Get
                Return Me.ColumnyMap("BUSINESS_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_CITY") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ZIP 營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' BUSINESS_ZIP 營業地址/事業地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property BUSINESS_ZIP() As String
            Get
                Return Me.ColumnyMap("BUSINESS_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_ZIP") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_ADDRESS 營業地址/事業地址"
        '' <summary>
        '' BUSINESS_ADDRESS 營業地址/事業地址
        '' </summary>
        Public Property BUSINESS_ADDRESS() As String
            Get
                Return Me.ColumnyMap("BUSINESS_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "MAILING_CITY 通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' MAILING_CITY 通訊地址-縣市別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property MAILING_CITY() As String
            Get
                Return Me.ColumnyMap("MAILING_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAILING_CITY") = value
            End Set
        End Property
#End Region

#Region "MAILING_ZIP 通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' MAILING_ZIP 通訊地址-行政區別,可暫不用，REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property MAILING_ZIP() As String
            Get
                Return Me.ColumnyMap("MAILING_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAILING_ZIP") = value
            End Set
        End Property
#End Region

#Region "MAILING_ADDRESS 通訊地址"
        '' <summary>
        '' MAILING_ADDRESS 通訊地址
        '' </summary>
        Public Property MAILING_ADDRESS() As String
            Get
                Return Me.ColumnyMap("MAILING_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAILING_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_AREA_CODE 營業電話區碼"
        '' <summary>
        '' BUSINESS_AREA_CODE 營業電話區碼
        '' </summary>
        Public Property BUSINESS_AREA_CODE() As String
            Get
                Return Me.ColumnyMap("BUSINESS_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "BUSINESS_TEL 營業電話"
        '' <summary>
        '' BUSINESS_TEL 營業電話
        '' </summary>
        Public Property BUSINESS_TEL() As String
            Get
                Return Me.ColumnyMap("BUSINESS_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSINESS_TEL") = value
            End Set
        End Property
#End Region

#Region "START_SCH_DATE 預定開播日期"
        '' <summary>
        '' START_SCH_DATE 預定開播日期
        '' </summary>
        Public Property START_SCH_DATE() As String
            Get
                Return Me.ColumnyMap("START_SCH_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("START_SCH_DATE") = value
            End Set
        End Property
#End Region

#Region "CONTACT_PERSON 聯絡人"
        '' <summary>
        '' CONTACT_PERSON 聯絡人
        '' </summary>
        Public Property CONTACT_PERSON() As String
            Get
                Return Me.ColumnyMap("CONTACT_PERSON")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_PERSON") = value
            End Set
        End Property
#End Region

#Region "CONTACT_AREA_CODE 聯絡電話區碼"
        '' <summary>
        '' CONTACT_AREA_CODE 聯絡電話區碼
        '' </summary>
        Public Property CONTACT_AREA_CODE() As String
            Get
                Return Me.ColumnyMap("CONTACT_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        '' <summary>
        '' CONTACT_TEL 聯絡電話
        '' </summary>
        Public Property CONTACT_TEL() As String
            Get
                Return Me.ColumnyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "EMAIL 電子郵件信箱"
        '' <summary>
        '' EMAIL 電子郵件信箱
        '' </summary>
        Public Property EMAIL() As String
            Get
                Return Me.ColumnyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS_CITY 聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' CONTACT_ADDRESS_CITY 聯絡地址-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property CONTACT_ADDRESS_CITY() As String
            Get
                Return Me.ColumnyMap("CONTACT_ADDRESS_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_ADDRESS_CITY") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS_ZIP 聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' CONTACT_ADDRESS_ZIP 聯絡地址-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property CONTACT_ADDRESS_ZIP() As String
            Get
                Return Me.ColumnyMap("CONTACT_ADDRESS_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_ADDRESS_ZIP") = value
            End Set
        End Property
#End Region

#Region "CONTACT_ADDRESS 聯絡地址"
        '' <summary>
        '' CONTACT_ADDRESS 聯絡地址
        '' </summary>
        Public Property CONTACT_ADDRESS() As String
            Get
                Return Me.ColumnyMap("CONTACT_ADDRESS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_ADDRESS") = value
            End Set
        End Property
#End Region

#Region "FOREIGNER_CAL_BASE_DATE 外國人持股比例計算基準日"
        '' <summary>
        '' FOREIGNER_CAL_BASE_DATE 外國人持股比例計算基準日
        '' </summary>
        Public Property FOREIGNER_CAL_BASE_DATE() As String
            Get
                Return Me.ColumnyMap("FOREIGNER_CAL_BASE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FOREIGNER_CAL_BASE_DATE") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG 限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG 限制級鎖碼,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LOCK_CHANNEL_FLAG() As String
            Get
                Return Me.ColumnyMap("LOCK_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LOCK_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CH_RANK1 新聞-排名"
        '' <summary>
        '' CH_RANK1 新聞-排名
        '' </summary>
        Public Property CH_RANK1() As String
            Get
                Return Me.ColumnyMap("CH_RANK1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK1") = value
            End Set
        End Property
#End Region

#Region "CH_RANK2 財經新聞-排名"
        '' <summary>
        '' CH_RANK2 財經新聞-排名
        '' </summary>
        Public Property CH_RANK2() As String
            Get
                Return Me.ColumnyMap("CH_RANK2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK2") = value
            End Set
        End Property
#End Region

#Region "CH_RANK3 財經股市-排名"
        '' <summary>
        '' CH_RANK3 財經股市-排名
        '' </summary>
        Public Property CH_RANK3() As String
            Get
                Return Me.ColumnyMap("CH_RANK3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK3") = value
            End Set
        End Property
#End Region

#Region "CH_RANK4 兒少-排名"
        '' <summary>
        '' CH_RANK4 兒少-排名
        '' </summary>
        Public Property CH_RANK4() As String
            Get
                Return Me.ColumnyMap("CH_RANK4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK4") = value
            End Set
        End Property
#End Region

#Region "CH_RANK5 戲劇-排名"
        '' <summary>
        '' CH_RANK5 戲劇-排名
        '' </summary>
        Public Property CH_RANK5() As String
            Get
                Return Me.ColumnyMap("CH_RANK5")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK5") = value
            End Set
        End Property
#End Region

#Region "CH_RANK6 電影-排名"
        '' <summary>
        '' CH_RANK6 電影-排名
        '' </summary>
        Public Property CH_RANK6() As String
            Get
                Return Me.ColumnyMap("CH_RANK6")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK6") = value
            End Set
        End Property
#End Region

#Region "CH_RANK7 體育-排名"
        '' <summary>
        '' CH_RANK7 體育-排名
        '' </summary>
        Public Property CH_RANK7() As String
            Get
                Return Me.ColumnyMap("CH_RANK7")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK7") = value
            End Set
        End Property
#End Region

#Region "CH_RANK8 CH_RANK8"
        '' <summary>
        '' CH_RANK8 CH_RANK8
        '' </summary>
        Public Property CH_RANK8() As String
            Get
                Return Me.ColumnyMap("CH_RANK8")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK8") = value
            End Set
        End Property
#End Region

#Region "CH_RANK9 音樂-排名"
        '' <summary>
        '' CH_RANK9 音樂-排名
        '' </summary>
        Public Property CH_RANK9() As String
            Get
                Return Me.ColumnyMap("CH_RANK9")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK9") = value
            End Set
        End Property
#End Region

#Region "CH_RANK10 宗教-排名"
        '' <summary>
        '' CH_RANK10 宗教-排名
        '' </summary>
        Public Property CH_RANK10() As String
            Get
                Return Me.ColumnyMap("CH_RANK10")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK10") = value
            End Set
        End Property
#End Region

#Region "CH_RANK11 綜合-排名"
        '' <summary>
        '' CH_RANK11 綜合-排名
        '' </summary>
        Public Property CH_RANK11() As String
            Get
                Return Me.ColumnyMap("CH_RANK11")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK11") = value
            End Set
        End Property
#End Region

#Region "CH_RANK12 其他類型-排名"
        '' <summary>
        '' CH_RANK12 其他類型-排名
        '' </summary>
        Public Property CH_RANK12() As String
            Get
                Return Me.ColumnyMap("CH_RANK12")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK12") = value
            End Set
        End Property
#End Region

#Region "CH_RANK_DESC 其他類型-說明"
        '' <summary>
        '' CH_RANK_DESC 其他類型-說明
        '' </summary>
        Public Property CH_RANK_DESC() As String
            Get
                Return Me.ColumnyMap("CH_RANK_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_RANK_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCAL_CHANNEL_FLAG 地方頻道,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCAL_CHANNEL_FLAG 地方頻道,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LOCAL_CHANNEL_FLAG() As String
            Get
                Return Me.ColumnyMap("LOCAL_CHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LOCAL_CHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CABLE_NAME 系統名稱"
        '' <summary>
        '' CABLE_NAME 系統名稱
        '' </summary>
        Public Property CABLE_NAME() As String
            Get
                Return Me.ColumnyMap("CABLE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CABLE_NAME") = value
            End Set
        End Property
#End Region

#Region "OPERATION_CITY 經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' OPERATION_CITY 經營區域-縣市別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property OPERATION_CITY() As String
            Get
                Return Me.ColumnyMap("OPERATION_CITY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_CITY") = value
            End Set
        End Property
#End Region

#Region "OPERATION_ZIP 經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'"
        '' <summary>
        '' OPERATION_ZIP 經營區域-行政區別,REF. SYST010.SYS_KEY='CITY_CODE'
        '' </summary>
        Public Property OPERATION_ZIP() As String
            Get
                Return Me.ColumnyMap("OPERATION_ZIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_ZIP") = value
            End Set
        End Property
#End Region

#Region "APPOINT_AREA 指定區域"
        '' <summary>
        '' APPOINT_AREA 指定區域
        '' </summary>
        Public Property APPOINT_AREA() As String
            Get
                Return Me.ColumnyMap("APPOINT_AREA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APPOINT_AREA") = value
            End Set
        End Property
#End Region

#Region "BOOKING_PLATFORM 預訂上架之系統平臺"
        '' <summary>
        '' BOOKING_PLATFORM 預訂上架之系統平臺
        '' </summary>
        Public Property BOOKING_PLATFORM() As String
            Get
                Return Me.ColumnyMap("BOOKING_PLATFORM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BOOKING_PLATFORM") = value
            End Set
        End Property
#End Region

#Region "TRANS_TYPE 節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'"
        '' <summary>
        '' TRANS_TYPE 節目或廣告主要傳輸方式,REF. SYST010.SYS_KEY='TRANS_TYPE'
        '' </summary>
        Public Property TRANS_TYPE() As String
            Get
                Return Me.ColumnyMap("TRANS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TRANS_TYPE") = value
            End Set
        End Property
#End Region

#Region "EX_COM_NAME 境外衛星廣播電視事業名稱"
        '' <summary>
        '' EX_COM_NAME 境外衛星廣播電視事業名稱
        '' </summary>
        Public Property EX_COM_NAME() As String
            Get
                Return Me.ColumnyMap("EX_COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX_COM_NAME") = value
            End Set
        End Property
#End Region

#Region "EX_COM_COUNTRY 境外衛星廣播電視事業國籍"
        '' <summary>
        '' EX_COM_COUNTRY 境外衛星廣播電視事業國籍
        '' </summary>
        Public Property EX_COM_COUNTRY() As String
            Get
                Return Me.ColumnyMap("EX_COM_COUNTRY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX_COM_COUNTRY") = value
            End Set
        End Property
#End Region

#Region "APP_NAME 申請標的"
        '' <summary>
        '' APP_NAME 申請標的
        '' </summary>
        Public Property APP_NAME() As String
            Get
                Return Me.ColumnyMap("APP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APP_NAME") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_AREA_CODE 申訴管道-客服電話區碼"
        '' <summary>
        '' COMPLAINT_AREA_CODE 申訴管道-客服電話區碼
        '' </summary>
        Public Property COMPLAINT_AREA_CODE() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_AREA_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_AREA_CODE") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_TEL 申訴管道-客服電話"
        '' <summary>
        '' COMPLAINT_TEL 申訴管道-客服電話
        '' </summary>
        Public Property COMPLAINT_TEL() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_TEL") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_EMAIL 申訴管道-電子郵件"
        '' <summary>
        '' COMPLAINT_EMAIL 申訴管道-電子郵件
        '' </summary>
        Public Property COMPLAINT_EMAIL() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_EMAIL") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_OTHER 申訴管道-其他"
        '' <summary>
        '' COMPLAINT_OTHER 申訴管道-其他
        '' </summary>
        Public Property COMPLAINT_OTHER() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_OTHER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_OTHER") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO 執照號碼"
        '' <summary>
        '' LICENSE_NO 執照號碼
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.ColumnyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "SETUP_DATE 成立時間"
        '' <summary>
        '' SETUP_DATE 成立時間
        '' </summary>
        Public Property SETUP_DATE() As String
            Get
                Return Me.ColumnyMap("SETUP_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SETUP_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_S_DATE 執照(許可)效期/目前執照期間(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照(許可)效期/目前執照期間(起)
        '' </summary>
        Public Property LICENSE_S_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_S_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_E_DATE 執照(許可)效期/目前執照期間(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照(許可)效期/目前執照期間(迄)
        '' </summary>
        Public Property LICENSE_E_DATE() As String
            Get
                Return Me.ColumnyMap("LICENSE_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_E_DATE") = value
            End Set
        End Property
#End Region

#Region "WEB_URL 電臺網址/事業網址"
        '' <summary>
        '' WEB_URL 電臺網址/事業網址
        '' </summary>
        Public Property WEB_URL() As String
            Get
                Return Me.ColumnyMap("WEB_URL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("WEB_URL") = value
            End Set
        End Property
#End Region

#Region "SETUP_PURPOSE 設臺宗旨"
        '' <summary>
        '' SETUP_PURPOSE 設臺宗旨
        '' </summary>
        Public Property SETUP_PURPOSE() As String
            Get
                Return Me.ColumnyMap("SETUP_PURPOSE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SETUP_PURPOSE") = value
            End Set
        End Property
#End Region

#Region "E_RESULT1 執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'"
        '' <summary>
        '' E_RESULT1 執照期限內第1次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
        '' </summary>
        Public Property E_RESULT1() As String
            Get
                Return Me.ColumnyMap("E_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("E_RESULT1") = value
            End Set
        End Property
#End Region

#Region "E_RESULT2 執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'"
        '' <summary>
        '' E_RESULT2 執照期限內第2次評鑑結果,REF. SYST010.SYS_KEY='RESULT2'
        '' </summary>
        Public Property E_RESULT2() As String
            Get
                Return Me.ColumnyMap("E_RESULT2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("E_RESULT2") = value
            End Set
        End Property
#End Region

#Region "OPERATION_S_DATE1 營運計畫執行期間(起)"
        '' <summary>
        '' OPERATION_S_DATE1 營運計畫執行期間(起)
        '' </summary>
        Public Property OPERATION_S_DATE1() As String
            Get
                Return Me.ColumnyMap("OPERATION_S_DATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_S_DATE1") = value
            End Set
        End Property
#End Region

#Region "OPERATION_E_DATE1 營運計畫執行期間(迄)"
        '' <summary>
        '' OPERATION_E_DATE1 營運計畫執行期間(迄)
        '' </summary>
        Public Property OPERATION_E_DATE1() As String
            Get
                Return Me.ColumnyMap("OPERATION_E_DATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_E_DATE1") = value
            End Set
        End Property
#End Region

#Region "OPERATION_S_DATE2 未來營運計畫期間(起)"
        '' <summary>
        '' OPERATION_S_DATE2 未來營運計畫期間(起)
        '' </summary>
        Public Property OPERATION_S_DATE2() As String
            Get
                Return Me.ColumnyMap("OPERATION_S_DATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_S_DATE2") = value
            End Set
        End Property
#End Region

#Region "OPERATION_E_DATE2 未來營運計畫期間(迄)"
        '' <summary>
        '' OPERATION_E_DATE2 未來營運計畫期間(迄)
        '' </summary>
        Public Property OPERATION_E_DATE2() As String
            Get
                Return Me.ColumnyMap("OPERATION_E_DATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATION_E_DATE2") = value
            End Set
        End Property
#End Region

#Region "RADIO_TYPE 電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'"
        '' <summary>
        '' RADIO_TYPE 電臺類型,REF. SYST010.SYS_KEY='RADIO_TYPE'
        '' </summary>
        Public Property RADIO_TYPE() As String
            Get
                Return Me.ColumnyMap("RADIO_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RADIO_TYPE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_S_DATE 評鑑期間(起)"
        '' <summary>
        '' EVALUATION_S_DATE 評鑑期間(起)
        '' </summary>
        Public Property EVALUATION_S_DATE() As String
            Get
                Return Me.ColumnyMap("EVALUATION_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EVALUATION_S_DATE") = value
            End Set
        End Property
#End Region

#Region "EVALUATION_E_DATE 評鑑期間(迄)"
        '' <summary>
        '' EVALUATION_E_DATE 評鑑期間(迄)
        '' </summary>
        Public Property EVALUATION_E_DATE() As String
            Get
                Return Me.ColumnyMap("EVALUATION_E_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EVALUATION_E_DATE") = value
            End Set
        End Property
#End Region

#Region "PLAY_S_DATE 開播日期"
        '' <summary>
        '' PLAY_S_DATE 開播日期
        '' </summary>
        Public Property PLAY_S_DATE() As String
            Get
                Return Me.ColumnyMap("PLAY_S_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PLAY_S_DATE") = value
            End Set
        End Property
#End Region

#Region "SB_AMT1 前1年度營業額"
        '' <summary>
        '' SB_AMT1 前1年度營業額
        '' </summary>
        Public Property SB_AMT1() As String
            Get
                Return Me.ColumnyMap("SB_AMT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SB_AMT1") = value
            End Set
        End Property
#End Region

#Region "SB_AMT2 前2年度營業額"
        '' <summary>
        '' SB_AMT2 前2年度營業額
        '' </summary>
        Public Property SB_AMT2() As String
            Get
                Return Me.ColumnyMap("SB_AMT2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SB_AMT2") = value
            End Set
        End Property
#End Region

#Region "SB_AMT3 前3年度營業額"
        '' <summary>
        '' SB_AMT3 前3年度營業額
        '' </summary>
        Public Property SB_AMT3() As String
            Get
                Return Me.ColumnyMap("SB_AMT3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SB_AMT3") = value
            End Set
        End Property
#End Region

#Region "EMPLOYEE_NUMBER 員工人數"
        '' <summary>
        '' EMPLOYEE_NUMBER 員工人數
        '' </summary>
        Public Property EMPLOYEE_NUMBER() As String
            Get
                Return Me.ColumnyMap("EMPLOYEE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EMPLOYEE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBE_NUMBER 總訂戶數"
        '' <summary>
        '' SUBSCRIBE_NUMBER 總訂戶數
        '' </summary>
        Public Property SUBSCRIBE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SUBSCRIBE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBSCRIBE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "BASE_CHANNEL_NNUMBER 基本頻道數"
        '' <summary>
        '' BASE_CHANNEL_NNUMBER 基本頻道數
        '' </summary>
        Public Property BASE_CHANNEL_NNUMBER() As String
            Get
                Return Me.ColumnyMap("BASE_CHANNEL_NNUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BASE_CHANNEL_NNUMBER") = value
            End Set
        End Property
#End Region

#Region "PAY_CHANNEL_NNUMBER 付費頻道數"
        '' <summary>
        '' PAY_CHANNEL_NNUMBER 付費頻道數
        '' </summary>
        Public Property PAY_CHANNEL_NNUMBER() As String
            Get
                Return Me.ColumnyMap("PAY_CHANNEL_NNUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAY_CHANNEL_NNUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANGE_STANDARD 收費標準"
        '' <summary>
        '' CHANGE_STANDARD 收費標準
        '' </summary>
        Public Property CHANGE_STANDARD() As String
            Get
                Return Me.ColumnyMap("CHANGE_STANDARD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANGE_STANDARD") = value
            End Set
        End Property
#End Region

#Region "SETUP_ORG_FLAG 建立自律組織,REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SETUP_ORG_FLAG 建立自律組織,REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SETUP_ORG_FLAG() As String
            Get
                Return Me.ColumnyMap("SETUP_ORG_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SETUP_ORG_FLAG") = value
            End Set
        End Property
#End Region

#Region "ORG_NAME 自律組織名稱"
        '' <summary>
        '' ORG_NAME 自律組織名稱
        '' </summary>
        Public Property ORG_NAME() As String
            Get
                Return Me.ColumnyMap("ORG_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_NAME") = value
            End Set
        End Property
#End Region

#Region "PUNISH_NUMBER 評鑑期間核處紀錄件數"
        '' <summary>
        '' PUNISH_NUMBER 評鑑期間核處紀錄件數
        '' </summary>
        Public Property PUNISH_NUMBER() As String
            Get
                Return Me.ColumnyMap("PUNISH_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PUNISH_NUMBER") = value
            End Set
        End Property
#End Region

#Region "IN_CHANNEL_NUMBER 境內頻道數量"
        '' <summary>
        '' IN_CHANNEL_NUMBER 境內頻道數量
        '' </summary>
        Public Property IN_CHANNEL_NUMBER() As String
            Get
                Return Me.ColumnyMap("IN_CHANNEL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_CHANNEL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "IN_CHANNEL_NAME 境內頻道名稱"
        '' <summary>
        '' IN_CHANNEL_NAME 境內頻道名稱
        '' </summary>
        Public Property IN_CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("IN_CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "EX__CHANNEL_NUMBER 境外頻道數量"
        '' <summary>
        '' EX__CHANNEL_NUMBER 境外頻道數量
        '' </summary>
        Public Property EX__CHANNEL_NUMBER() As String
            Get
                Return Me.ColumnyMap("EX__CHANNEL_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX__CHANNEL_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EX_CHANNEL_NAME 境外頻道名稱"
        '' <summary>
        '' EX_CHANNEL_NAME 境外頻道名稱
        '' </summary>
        Public Property EX_CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("EX_CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX_CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "IN_COM_NAME1 境內直播衛星服務經營者名稱"
        '' <summary>
        '' IN_COM_NAME1 境內直播衛星服務經營者名稱
        '' </summary>
        Public Property IN_COM_NAME1() As String
            Get
                Return Me.ColumnyMap("IN_COM_NAME1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_COM_NAME1") = value
            End Set
        End Property
#End Region

#Region "EX_COM_NAME1 境外直播衛星服務經營者名稱"
        '' <summary>
        '' EX_COM_NAME1 境外直播衛星服務經營者名稱
        '' </summary>
        Public Property EX_COM_NAME1() As String
            Get
                Return Me.ColumnyMap("EX_COM_NAME1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX_COM_NAME1") = value
            End Set
        End Property
#End Region

#Region "ADD_DESC ADD_DESC"
        '' <summary>
        '' ADD_DESC ADD_DESC
        '' </summary>
        Public Property ADD_DESC() As String
            Get
                Return Me.ColumnyMap("ADD_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADD_DESC") = value
            End Set
        End Property
#End Region

#Region "IN_COM_FLAG 境內直播衛星服務經營者,Y：有勾選"
        '' <summary>
        '' IN_COM_FLAG 境內直播衛星服務經營者,Y：有勾選
        '' </summary>
        Public Property IN_COM_FLAG() As String
            Get
                Return Me.ColumnyMap("IN_COM_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IN_COM_FLAG") = value
            End Set
        End Property
#End Region

#Region "EX_COM_FLAG 境外直播衛星服務經營者,Y：有勾選"
        '' <summary>
        '' EX_COM_FLAG 境外直播衛星服務經營者,Y：有勾選
        '' </summary>
        Public Property EX_COM_FLAG() As String
            Get
                Return Me.ColumnyMap("EX_COM_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EX_COM_FLAG") = value
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

#Region "與有線電視類比平臺簽約家數"
        ''' <summary>
        ''' 與有線電視類比平臺簽約家數
        ''' </summary>
        Public Property CATV_ANALOGY_SIGN() As String
            Get
                Return Me.ColumnyMap("CATV_ANALOGY_SIGN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CATV_ANALOGY_SIGN") = value
            End Set
        End Property
#End Region

#Region "與有線電視數位平臺簽約家數"
        ''' <summary>
        ''' 與有線電視數位平臺簽約家數
        ''' </summary>
        Public Property CATV_DIGIT_SIGN() As String
            Get
                Return Me.ColumnyMap("CATV_DIGIT_SIGN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CATV_DIGIT_SIGN") = value
            End Set
        End Property
#End Region

#Region "與供公眾收視聽之播送平臺簽約家數"
        ''' <summary>
        ''' 與供公眾收視聽之播送平臺簽約家數
        ''' </summary>
        Public Property PUBLIC_SIGN() As String
            Get
                Return Me.ColumnyMap("PUBLIC_SIGN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PUBLIC_SIGN") = value
            End Set
        End Property
#End Region

#Region "與直播衛星平臺簽約家數"
        ''' <summary>
        ''' 與直播衛星平臺簽約家數
        ''' </summary>
        Public Property SATELLITE_SIGN() As String
            Get
                Return Me.ColumnyMap("SATELLITE_SIGN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SATELLITE_SIGN") = value
            End Set
        End Property
#End Region
#End Region
#Region "自訂方法"
#Region "QueryByCaseNo 查詢 "
        '' <summary>
        '' 查詢 
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function QueryByCaseNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()


                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT Top 1 * ")
                sql.AppendLine(" FROM APP1010  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString.Replace("$.", ""))

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoQueryAll 查詢 "
        ''' <summary>
        '''     ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DoQueryAll() As DataTable
            Return Me.DoQueryAll(0, 0)
        End Function
        '' <summary>
        '' 查詢  for print word use 
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function DoQueryAll(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()


                Dim sql As StringBuilder = New StringBuilder
                sql.AppendLine("SELECT R1.CASE_SEQ, M.*  , ")
                sql.AppendLine("     M.APP_PERSON_NM AS 申請人名稱,")
                sql.AppendLine("     R2.SYS_NAME AS CASE_STATUS_NM ,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='01' THEN '■' ELSE '□' END   AS 組織型態01,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='02' THEN '■' ELSE '□' END   AS 組織型態02,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='03' THEN '■' ELSE '□' END   AS 組織型態03,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='04' THEN '■' ELSE '□' END   AS 組織型態04,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='05' THEN '■' ELSE '□' END   AS 組織型態05,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='06' THEN '■' ELSE '□' END   AS 組織型態06,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='07' THEN '■' ELSE '□' END   AS 組織型態07,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='08' THEN '■' ELSE '□' END   AS 組織型態08,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='09' THEN '■' ELSE '□' END   AS 組織型態09,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='10' THEN '■' ELSE '□' END   AS 組織型態10,")
                sql.AppendLine("     CASE WHEN M.ORG_TYPE ='11' THEN '■' ELSE '□' END   AS 組織型態11,")
                sql.AppendLine("     M.TOTAL_PROPERTY AS 實收資本額,")
                sql.AppendLine("     CASE WHEN M.DECLARE_1 ='Y' THEN '■' ELSE '□' END   AS 聲明1是,")
                sql.AppendLine("     CASE WHEN M.DECLARE_1 ='N' THEN '■' ELSE '□' END   AS 聲明1否,")
                sql.AppendLine("     CASE WHEN M.DECLARE_2 ='Y' THEN '■' ELSE '□' END   AS 聲明2是,")
                sql.AppendLine("     CASE WHEN M.DECLARE_2 ='N' THEN '■' ELSE '□' END   AS 聲明2否,")
                sql.AppendLine("     CASE WHEN M.DECLARE_3 ='Y' THEN '■' ELSE '□' END   AS 聲明3是,")
                sql.AppendLine("     CASE WHEN M.DECLARE_3 ='N' THEN '■' ELSE '□' END   AS 聲明3否,")
                sql.AppendLine("     CASE WHEN M.SETUP_ORG_FLAG ='Y' THEN '■' ELSE '□' END   AS 自律組織是,")
                sql.AppendLine("     CASE WHEN M.SETUP_ORG_FLAG ='N' THEN '■' ELSE '□' END   AS 自律組織否,")
                sql.AppendLine("      M.SYS_CNAME AS 系統服務名稱中文,")
                sql.AppendLine("      M.SYS_S_CNAME AS 系統服務名稱中文簡稱,")
                sql.AppendLine("      M.SYS_ENAME AS 系統服務名稱英文,")
                sql.AppendLine("      M.SYS_S_ENAME AS 系統服務名稱英文簡稱,")
                sql.AppendLine("      M.REPRESENTATIVE AS 代表人,")
                sql.AppendLine("      CASE WHEN M.IS_FOREIGNER ='2' THEN '■' ELSE '□' END   AS 外國人是,")
                sql.AppendLine("      CASE WHEN M.IS_FOREIGNER ='1' THEN '■' ELSE '□' END   AS 外國人否,")
                sql.AppendLine("      M.COUNTRY AS 國籍,M.PASSPORT_ID AS 護照號碼,")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      dbo.TripleDesDecrypt(M.PID) AS 身分證字號,")
                Else
                    sql.AppendLine("      M.PID AS 身分證字號,")
                End If
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      DBO.GET_REGNM (M.LIVE_ZIP) + dbo.TripleDesDecrypt(M.LIVE_ADDRESS) AS 住居所,")
                Else
                    sql.AppendLine("      DBO.GET_REGNM (M.LIVE_ZIP) + M.LIVE_ADDRESS AS 住居所,")
                End If

                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      DBO.GET_REGNM (M.BUSINESS_ZIP) + dbo.TripleDesDecrypt(M.BUSINESS_ADDRESS) AS 營業所地址,")
                Else
                    sql.AppendLine("      DBO.GET_REGNM (M.BUSINESS_ZIP) + M.BUSINESS_ADDRESS AS 營業所地址,")
                End If

                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      DBO.GET_REGNM (M.MAILING_ZIP) + dbo.TripleDesDecrypt(M.MAILING_ADDRESS) AS 通訊地址,")
                Else
                    sql.AppendLine("      DBO.GET_REGNM (M.MAILING_ZIP) + M.MAILING_ADDRESS AS 通訊地址,")
                End If

                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      DBO.GET_REGNM (M.CONTACT_ADDRESS_ZIP) + dbo.TripleDesDecrypt(M.CONTACT_ADDRESS) AS 聯絡地址,")
                Else
                    sql.AppendLine("      DBO.GET_REGNM (M.CONTACT_ADDRESS_ZIP) + M.CONTACT_ADDRESS AS 聯絡地址,")
                End If

                sql.AppendLine("      '('+ ISNULL(M.BUSINESS_AREA_CODE,'  ') +')' + ISNULL(M.BUSINESS_TEL,'') AS 營業電話,")
                sql.AppendLine("      '('+ ISNULL(M.COMPLAINT_AREA_CODE,'  ') +')' + ISNULL(M.COMPLAINT_TEL,'') AS 客服電話,")
                sql.AppendLine("      M.PLAY_S_DATE AS 開播日期 ,")
                sql.AppendLine("      M.START_SCH_DATE AS 預定開播日期 ,")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("      dbo.TripleDesDecrypt(M.CONTACT_PERSON) AS 聯絡人,")
                Else
                    sql.AppendLine("     M.CONTACT_PERSON AS 聯絡人,")
                End If
                sql.AppendLine("      '('+ ISNULL(M.CONTACT_AREA_CODE,'  ') +')' + ISNULL(M.CONTACT_TEL,'') AS 聯絡電話,")
                sql.AppendLine("      M.EMAIL AS 電子郵件信箱,")
                sql.AppendLine("      M.CREATE_TIME AS 申請日期,")
                sql.AppendLine("      CASE WHEN M.LOCK_CHANNEL_FLAG ='Y' THEN '■' ELSE '□' END AS 限制級鎖碼,")
                sql.AppendLine("      CASE WHEN M.LOCK_CHANNEL_FLAG ='N' THEN '■' ELSE '□' END AS 非限制級鎖碼,")
                sql.AppendLine("      CASE WHEN M.LOCAL_CHANNEL_FLAG ='Y' THEN '■' ELSE '□' END AS 地方頻道,")
                sql.AppendLine("      CASE WHEN isnull(M.CABLE_NAME,'')<> '' THEN '■' ELSE '□' END AS 同時為有線廣播電視系統經營者,")
                sql.AppendLine("      CASE WHEN isnull(M.APPOINT_AREA,'')<> '' THEN '■' ELSE '□' END AS 符合本會指定區域內民眾利益及需求,")
                sql.AppendLine("      CASE WHEN isnull(M.BOOKING_PLATFORM,'')<> '' THEN '■' ELSE '□' END AS 預定上架之系統平臺,")
                sql.AppendLine("      CASE WHEN isnull(M.PUNISH_NUMBER,'')<>'' THEN '■' ELSE '□' END AS 核處是,")
                sql.AppendLine("      CASE WHEN isnull(M.PUNISH_NUMBER,'')='' THEN '■' ELSE '□' END AS 核處否,")
                sql.AppendLine("      CASE WHEN isnull(M.IN_COM_FLAG,'') ='Y' THEN '■' ELSE '□' END AS 境內直播經營者,")
                sql.AppendLine("      CASE WHEN isnull(M.EX_COM_FLAG,'')='Y' THEN '■' ELSE '□' END AS 境外直播經營者,")
                'sql.AppendLine("     DBO.GET_REGNM (M.OPERATION_ZIP) as  經營區域 , ")
                sql.AppendLine("      DBO.GET_CITY( M.OPERATION_CITY) + CASE WHEN isnull( M.OPERATION_ZIP,'')<> '' THEN M.OPERATION_ZIP ELSE '' END AS  經營區域 , ")
                sql.AppendLine("      CASE WHEN M.TRANS_TYPE ='1' THEN '■' ELSE '□' END AS 衛星傳輸,")
                sql.AppendLine("      CASE WHEN M.TRANS_TYPE ='2' THEN '■' ELSE '□' END AS 衛星以外方式傳輸 , ")
                sql.AppendLine("      CASE WHEN  R1.CASE_CODE IN ('AA04', 'AA06', 'BA04', 'BA06', 'CA04', 'CA06')  THEN '■' ELSE '□' END AS 購物頻道是,")
                sql.AppendLine("      CASE WHEN  R1.CASE_CODE NOT IN ('AA04', 'AA06', 'BA04', 'BA06', 'CA04', 'CA06') THEN '■' ELSE '□' END AS 一般頻道是   ")
                sql.AppendLine("  FROM APP1010 M ")
                sql.AppendLine("    LEFT JOIN APPL020 R1 on M.CASE_NO  =R1.CASE_NO")
                sql.AppendLine("       LEFT JOIN SYST010 R2  ON R2.SYS_KEY = 'CASE_STATUS' AND R1.CASE_STATUS = R2.SYS_ID")
                sql.AppendLine("       LEFT JOIN APPL010 R3 ON R1.COM_PKNO = R3.PKNO           ")
                sql.AppendLine("       LEFT JOIN POST020 R9")
                sql.AppendLine("       ON R1.CREATE_USER = R9.ACNT ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString.Replace("$.", ""), pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "DoQueryView 查詢 "
        ''' <summary>
        '''  for 綜合查詢
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DoQueryView() As DataTable
            Return Me.DoQueryView(0, 0)
        End Function
        '' <summary>
        '' 查詢  for 綜合查詢
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function DoQueryView(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()


                Dim sql As StringBuilder = New StringBuilder
                'sql.AppendLine(" SELECT *  FROM V_APPL020  ")
                sql.AppendLine(" SELECT   ")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine("    dbo.TripleDesDecrypt(申請者) as 申請者 ")
                Else
                    sql.AppendLine("   申請者 ")
                End If
                sql.AppendLine("    ,CREATE_TIME,案件編號,CASE_NO,BUS_NO,SYS_CNAME,LICENSE_S_DATE,事業類別2,申請項目,組織型態,頻道屬性,鎖碼與否,上架平台_有線電視,上架平台_直播衛星,上架平台_其他公眾收視平台,[縣市別(登記地址)],[縣市別(通訊地址)],案件狀態1,頻道節目屬性_新聞,頻道節目屬性_財經新聞,頻道節目屬性_財經股市,頻道節目屬性_兒少,頻道節目屬性_戲劇,頻道節目屬性_電影,頻道節目屬性_體育,頻道節目屬性_教育文化,頻道節目屬性_音樂,頻道節目屬性_宗教,頻道節目屬性_綜合,頻道節目屬性_其他類型  ")
                sql.AppendLine(" FROM V_APPL020  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    End If
                End If


                Dim dt As DataTable = Me.QueryBySql(sql.ToString.Replace("$.", ""), pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query 查詢 "
        ''' <summary>
        ''' Web Service 查詢 
        ''' </summary>
        Public Function Query_WS() As DataTable
            Return Me.Query_WS(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' Web Service 
        ''' </remarks>
        Public Function Query_WS(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 === 
                'Me.TableCoumnInfo.Add(New String() {"APP1010", "M", "APP_PERSON_NM"})
                'Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT SYS_CNAME ")

                'If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                '    sql.AppendLine(" dbo.TripleDesDecrypt(APP_PERSON_NM) as 'APP_PERSON_NM' ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(REPRESENTATIVE) as 'REPRESENTATIVE'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(LIVE_ADDRESS) as 'LIVE_ADDRESS'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(BUSINESS_ADDRESS) as 'BUSINESS_ADDRESS'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(MAILING_ADDRESS) as 'MAILING_ADDRESS'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(CONTACT_PERSON) as 'CONTACT_PERSON'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(CONTACT_ADDRESS) as 'CONTACT_ADDRESS'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(PID) as 'PID'  ")
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(PASSPORT_ID) as 'PASSPORT_ID'  ")
                'Else
                '    sql.AppendLine("  APP_PERSON_NM ")
                '    sql.AppendLine(" , REPRESENTATIVE ")
                '    sql.AppendLine(" , LIVE_ADDRESS ")
                '    sql.AppendLine(" , BUSINESS_ADDRESS ")
                '    sql.AppendLine(" , MAILING_ADDRESS  ")
                '    sql.AppendLine(" , CONTACT_PERSON  ")
                '    sql.AppendLine(" , CONTACT_ADDRESS  ")
                '    sql.AppendLine(" , PID  ")
                '    sql.AppendLine(" , PASSPORT_ID  ")
                'End If

                'sql.AppendLine(" , CASE_NO, ORG_TYPE, TOTAL_PROPERTY, DECLARE_1, DECLARE_2 ")
                'sql.AppendLine(" , DECLARE_3, SYS_CNAME, SYS_S_CNAME, SYS_ENAME, SYS_S_ENAME ")
                'sql.AppendLine(" , IS_FOREIGNER, COUNTRY, LIVE_CITY, LIVE_ZIP ")
                'sql.AppendLine(" , BUSINESS_CITY, BUSINESS_ZIP ")
                'sql.AppendLine(" , MAILING_CITY, MAILING_ZIP, BUSINESS_AREA_CODE ")
                'sql.AppendLine(" , BUSINESS_TEL, START_SCH_DATE, CONTACT_AREA_CODE  ")
                'sql.AppendLine(" , CONTACT_TEL, EMAIL, CONTACT_ADDRESS_CITY, CONTACT_ADDRESS_ZIP  ")
                'sql.AppendLine(" , FOREIGNER_CAL_BASE_DATE,  LOCK_CHANNEL_FLAG  ")
                'sql.AppendLine(" , CH_RANK1, CH_RANK2, CH_RANK3, CH_RANK4, CH_RANK5, CH_RANK6  ")
                'sql.AppendLine(" , CH_RANK7, CH_RANK8, CH_RANK9, CH_RANK10, CH_RANK11, CH_RANK12  ")
                'sql.AppendLine(" , CH_RANK_DESC, LOCAL_CHANNEL_FLAG, CABLE_NAME, OPERATION_CITY  ")
                'sql.AppendLine(" , OPERATION_ZIP, APPOINT_AREA, BOOKING_PLATFORM, TRANS_TYPE  ")
                'sql.AppendLine(" , EX_COM_NAME, EX_COM_COUNTRY, APP_NAME, COMPLAINT_AREA_CODE  ")
                'sql.AppendLine(" , COMPLAINT_TEL, COMPLAINT_EMAIL, COMPLAINT_OTHER, LICENSE_NO  ")
                'sql.AppendLine(" , SETUP_DATE, LICENSE_S_DATE, LICENSE_E_DATE, WEB_URL  ")
                'sql.AppendLine(" , SETUP_PURPOSE, E_RESULT1, E_RESULT2, OPERATION_S_DATE1  ")
                'sql.AppendLine(" , OPERATION_E_DATE1, OPERATION_S_DATE2, OPERATION_E_DATE2 ")
                'sql.AppendLine(" , RADIO_TYPE, EVALUATION_S_DATE, EVALUATION_E_DATE, PLAY_S_DATE ")
                'sql.AppendLine(" , SB_AMT1, SB_AMT2, SB_AMT3, EMPLOYEE_NUMBER, SUBSCRIBE_NUMBER ")
                'sql.AppendLine(" , BASE_CHANNEL_NNUMBER, PAY_CHANNEL_NNUMBER, CHANGE_STANDARD ")
                'sql.AppendLine(" , SETUP_ORG_FLAG, ORG_NAME, PUNISH_NUMBER, IN_CHANNEL_NUMBER ")
                'sql.AppendLine(" , IN_CHANNEL_NAME, EX__CHANNEL_NUMBER, EX_CHANNEL_NAME, IN_COM_NAME1 ")
                'sql.AppendLine(" , EX_COM_NAME1, ADD_DESC, IN_COM_FLAG, EX_COM_FLAG, PKNO, CREATE_TIME ")
                'sql.AppendLine(" , CREATE_USER, UPDATE_TIME, UPDATE_USER, ROWSTAMP, CATV_ANALOGY_SIGN ")
                'sql.AppendLine(" , CATV_DIGIT_SIGN, PUBLIC_SIGN, SATELLITE_SIGN  ")
                sql.AppendLine(" FROM APP1010  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#Region "QueryStatistics 查詢 "
        '' <summary>
        '' 查詢  for 綜合查詢統計資料  DATASET  兩個TABLE 
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function QueryStatistics() As DataSet
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim 共同條件 As String = Me.SqlRetrictions 'keep value ,因為Me.QueryBySql 執行完會清掉屬性值

                '無線電視  衛星電視
                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT count (DISTINCT com_pkno) AS 申請公司法人數,")
                SQL.AppendLine("       count (1) AS 頻道數,")
                SQL.AppendLine("       count (CASE WHEN org_type = 'C' THEN 1 ELSE NULL END) AS 財團法人,")
                SQL.AppendLine("       count (CASE WHEN org_type = 'F' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 股份有限公司,")
                SQL.AppendLine("       count (CASE WHEN org_type = 'PRE_OFFICE' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 籌備處,")
                SQL.AppendLine("       count (CASE WHEN 上架平台_有線電視 = 'Y' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 有線電視,")
                SQL.AppendLine("       count (CASE WHEN 上架平台_直播衛星 = 'Y' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 直播衛星,")
                SQL.AppendLine("       count (")
                SQL.AppendLine("          CASE")
                SQL.AppendLine("             WHEN 上架平台_其他公眾收視平台 = 'Y' THEN 1")
                SQL.AppendLine("             ELSE NULL")
                SQL.AppendLine("          END)")
                SQL.AppendLine("          AS 其他公眾收視平台,")
                SQL.AppendLine("       count (CH_RANK1) AS 新聞,")
                SQL.AppendLine("       count (CH_RANK2) AS 財經新聞,")
                SQL.AppendLine("       count (CH_RANK3) AS 財經股市,")
                SQL.AppendLine("       count (CH_RANK4) AS 兒少,")
                SQL.AppendLine("       count (CH_RANK5) AS 戲劇,")
                SQL.AppendLine("       count (CH_RANK6) AS 電影,")
                SQL.AppendLine("       count (CH_RANK7) AS 體育,")
                SQL.AppendLine("       count (CH_RANK8) AS 教育文化,")
                SQL.AppendLine("       count (CH_RANK9) AS 音樂,")
                SQL.AppendLine("       count (CH_RANK10) AS 宗教,")
                SQL.AppendLine("       count (CH_RANK11) AS 綜合,")
                SQL.AppendLine("       count (CH_RANK12) AS 其他類型,")
                If Me.R_TYPE = "M" Then
                    SQL.AppendLine("'M' AS UNIT,")
                    SQL.AppendLine("left (CONVERT (VARCHAR (10), 申請日期, 111), 7) AS 時間1")
                ElseIf Me.R_TYPE = "S" Then
                    SQL.AppendLine("'S' AS UNIT,") 'YEAR(申請日期) AS 時間2
                    SQL.AppendLine("CEILING(CAST(Month(申請日期) AS FLOAT)/3) AS 時間1,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間2")
                ElseIf Me.R_TYPE = "H" Then
                    SQL.AppendLine("'H' AS UNIT,")
                    SQL.AppendLine("CEILING(CAST(Month(申請日期) AS FLOAT)/6) AS 時間1,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間2")
                ElseIf Me.R_TYPE = "Y" Then
                    SQL.AppendLine("'Y' AS UNIT,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間1")
                End If

                SQL.AppendLine("  FROM V_APPL020")
                SQL.AppendLine(" WHERE 事業類別1 IN ('無線電視', '衛星電視')")
                If Not String.IsNullOrEmpty(共同條件) Then
                    SQL.AppendLine(" AND " & Me.ProcessCondition(共同條件))
                End If

                If Me.R_TYPE = "M" Then
                    SQL.AppendLine(" GROUP BY left (CONVERT (VARCHAR (10), 申請日期, 111), 7)")
                ElseIf Me.R_TYPE = "S" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期), CEILING(CAST(Month(申請日期) AS FLOAT)/3)")
                ElseIf Me.R_TYPE = "H" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期), CEILING(CAST(Month(申請日期) AS FLOAT)/6)")
                ElseIf Me.R_TYPE = "Y" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期)")
                End If

                Dim dt0 As DataTable = Me.QueryBySql(SQL.ToString.Replace("$.", ""), 0, 0)
                dt0.TableName = "APP5030_01"

                '廣播電臺
                SQL.Length = 0
                SQL.AppendLine("SELECT count (DISTINCT com_pkno) AS 申請公司法人數,")
                SQL.AppendLine("       count (1) AS 頻道數,")
                SQL.AppendLine("       count (CASE WHEN org_type = 'C' THEN 1 ELSE NULL END) AS 財團法人,")
                SQL.AppendLine("       count (CASE WHEN org_type = 'F' THEN 1 ELSE NULL END) AS 股份有限公司,")
                SQL.AppendLine("       count (CASE WHEN 事業類別2 = '區域性廣播事業' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 區域性廣播事業,")
                SQL.AppendLine("       count (CASE WHEN 事業類別2 = '社區性廣播事業' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 社區性廣播事業,")
                SQL.AppendLine("       count (CASE WHEN 事業類別2 = '公營或財團法人電台' THEN 1 ELSE NULL END)")
                SQL.AppendLine("          AS 公營或財團法人電台,        ")
                If Me.R_TYPE = "M" Then
                    SQL.AppendLine("'M' AS UNIT,")
                    SQL.AppendLine("left (CONVERT (VARCHAR (10), 申請日期, 111), 7) AS 時間1")
                ElseIf Me.R_TYPE = "S" Then
                    SQL.AppendLine("'S' AS UNIT,")
                    SQL.AppendLine("CEILING(CAST(Month(申請日期) AS FLOAT)/3) AS 時間1,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間2")
                ElseIf Me.R_TYPE = "H" Then
                    SQL.AppendLine("'H' AS UNIT,")
                    SQL.AppendLine("CEILING(CAST(Month(申請日期) AS FLOAT)/6) AS 時間1,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間2")
                ElseIf Me.R_TYPE = "Y" Then
                    SQL.AppendLine("'Y' AS UNIT,")
                    SQL.AppendLine("YEAR(申請日期) AS 時間1")
                End If

                SQL.AppendLine("  FROM V_APPL020")
                SQL.AppendLine(" WHERE 事業類別1 IN ('廣播電臺')")
                If Not String.IsNullOrEmpty(共同條件) Then
                    SQL.AppendLine(" AND " & Me.ProcessCondition(共同條件))
                End If

                If Me.R_TYPE = "M" Then
                    SQL.AppendLine(" GROUP BY left (CONVERT (VARCHAR (10), 申請日期, 111), 7)")
                ElseIf Me.R_TYPE = "S" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期), CEILING(CAST(Month(申請日期) AS FLOAT)/3)")
                ElseIf Me.R_TYPE = "H" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期), CEILING(CAST(Month(申請日期) AS FLOAT)/6)")
                ElseIf Me.R_TYPE = "Y" Then
                    SQL.AppendLine(" GROUP BY YEAR(申請日期)")
                End If

                Dim dt1 As DataTable = Me.QueryBySql(SQL.ToString.Replace("$.", ""), 0, 0)
                dt1.TableName = "APP5030_02"

                Me.ResetColumnProperty()

                Dim ds As New DataSet
                ds.Tables.Add(dt0.Copy)
                ds.Tables.Add(dt1.Copy)

                Return ds
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query 查詢 QueryORG_TYPE "
        ''' <summary>
        ''' QueryORG_TYPE
        ''' </summary>
        Public Function QueryORG_TYPE() As DataTable
            Return Me.QueryORG_TYPE(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' Web Service 
        ''' </remarks>
        Public Function QueryORG_TYPE(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 === 
                'Me.TableCoumnInfo.Add(New String() {"APP1010", "M", "APP_PERSON_NM"})
                'Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT ORG_TYPE, SYST010.SYS_NAME ")
                sql.AppendLine(" FROM APP1010  ")
                sql.AppendLine(" INNER JOIN SYST010 ON SYS_KEY = 'ORG_TYPE1' and SYST010.SYS_ID = app1010.ORG_TYPE ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                'If Me.OrderBys <> "" Then
                '    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                'Else
                '    If pageNo = 0 Then
                '        sql.AppendLine(" ORDER BY CASE_NO ")
                '    Else
                '        sql.AppendLine(" ORDER BY CASE_NO ")
                '    End If
                'End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region



    End Class
End Namespace

