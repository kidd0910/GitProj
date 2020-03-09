'ProductName                 : TSBA 
'File Name					 : CtAPP1170 
'Description	             : CtAPP1170 頻道基本資料
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

NameSpace App.Business
	Public partial Class CtAPP1170
		Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1170 = new Ent_APP1170(Me.DBManager, Me.LogUtil)
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

#Region "ORG_TYPE1 事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'"
        '' <summary>
        '' ORG_TYPE1 事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'
        '' </summary>
        Public Property ORG_TYPE1() As String
            Get
                Return Me.PropertyMap("ORG_TYPE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_TYPE1") = value
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

#Region "ORG_TYPE2 分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'"
        '' <summary>
        '' ORG_TYPE2 分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'
        '' </summary>
        Public Property ORG_TYPE2() As String
            Get
                Return Me.PropertyMap("ORG_TYPE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ORG_TYPE2") = value
            End Set
        End Property
#End Region

#Region "COM_NAME 所屬公司"
        '' <summary>
        '' COM_NAME 所屬公司
        '' </summary>
        Public Property COM_NAME() As String
            Get
                Return Me.PropertyMap("COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_NAME") = value
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

#Region "LICENSE_S_DATE 執照(許可)效期(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照(許可)效期(起)
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

#Region "LICENSE_E_DATE 執照(許可)效期(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照(許可)效期(迄)
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

#Region "CHANNEL_PAY_TYPE 基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'"
        '' <summary>
        '' CHANNEL_PAY_TYPE 基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
        '' </summary>
        Public Property CHANNEL_PAY_TYPE() As String
            Get
                Return Me.PropertyMap("CHANNEL_PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_DESC 說明"
        '' <summary>
        '' CHANNEL_PAY_DESC 說明
        '' </summary>
        Public Property CHANNEL_PAY_DESC() As String
            Get
                Return Me.PropertyMap("CHANNEL_PAY_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_PAY_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG 限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG 限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'

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

#Region "CH_FLAG1 頻道屬性-新聞, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG1 頻道屬性-新聞, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG1() As String
            Get
                Return Me.PropertyMap("CH_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG1") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG2 頻道屬性-財經新聞, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG2 頻道屬性-財經新聞, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG2() As String
            Get
                Return Me.PropertyMap("CH_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG2") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG3 頻道屬性-財經股市, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG3 頻道屬性-財經股市, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG3() As String
            Get
                Return Me.PropertyMap("CH_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG3") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG4 頻道屬性-兒少, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG4 頻道屬性-兒少, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG4() As String
            Get
                Return Me.PropertyMap("CH_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG4") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG5 頻道屬性-戲劇, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG5 頻道屬性-戲劇, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG5() As String
            Get
                Return Me.PropertyMap("CH_FLAG5")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG5") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG6 頻道屬性-電影, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG6 頻道屬性-電影, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG6() As String
            Get
                Return Me.PropertyMap("CH_FLAG6")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG6") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG7 頻道屬性-體育, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG7 頻道屬性-體育, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG7() As String
            Get
                Return Me.PropertyMap("CH_FLAG7")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG7") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG8 頻道屬性-教育文化, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG8 頻道屬性-教育文化, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG8() As String
            Get
                Return Me.PropertyMap("CH_FLAG8")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG8") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG9 頻道屬性-音樂, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG9 頻道屬性-音樂, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG9() As String
            Get
                Return Me.PropertyMap("CH_FLAG9")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG9") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG10 頻道屬性-宗教, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG10 頻道屬性-宗教, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG10() As String
            Get
                Return Me.PropertyMap("CH_FLAG10")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG10") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG11 頻道屬性-綜合, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG11 頻道屬性-綜合, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG11() As String
            Get
                Return Me.PropertyMap("CH_FLAG11")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG11") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG12 頻道屬性-地方頻道, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG12 頻道屬性-地方頻道, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG12() As String
            Get
                Return Me.PropertyMap("CH_FLAG12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG12") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13 頻道屬性-其他類型, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG13 頻道屬性-其他類型, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG13() As String
            Get
                Return Me.PropertyMap("CH_FLAG13")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG13") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13_DESC 頻道屬性-其他類型-說明"
        '' <summary>
        '' CH_FLAG13_DESC 頻道屬性-其他類型-說明
        '' </summary>
        Public Property CH_FLAG13_DESC() As String
            Get
                Return Me.PropertyMap("CH_FLAG13_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_FLAG13_DESC") = value
            End Set
        End Property
#End Region

#Region "CHARGE_STANDARD_AMT 收費標準"
        '' <summary>
        '' CHARGE_STANDARD_AMT 收費標準
        '' </summary>
        Public Property CHARGE_STANDARD_AMT() As String
            Get
                Return Me.PropertyMap("CHARGE_STANDARD_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE_STANDARD_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE1_AMT 前二年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE1_AMT 前二年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE1_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE1_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE1_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE2_AMT 前一年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE2_AMT 前一年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE2_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE3_AMT 本年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE3_AMT 本年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE3_AMT() As String
            Get
                Return Me.PropertyMap("CH_AUTHORIZE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_AUTHORIZE3_AMT") = value
            End Set
        End Property
#End Region

#Region "SALES_AGENT 本年度銷售代理商"
        '' <summary>
        '' SALES_AGENT 本年度銷售代理商
        '' </summary>
        Public Property SALES_AGENT() As String
            Get
                Return Me.PropertyMap("SALES_AGENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_AGENT") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG1 上架方式-有線電視(類比), 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG1 上架方式-有線電視(類比), 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG1() As String
            Get
                Return Me.PropertyMap("SALES_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG1") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG2 上架方式-有線電視(數位), 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG2 上架方式-有線電視(數位), 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG2() As String
            Get
                Return Me.PropertyMap("SALES_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG2") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG3 上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG3 上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG3() As String
            Get
                Return Me.PropertyMap("SALES_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG3") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG4 上架方式-直播衛星, 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG4 上架方式-直播衛星, 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG4() As String
            Get
                Return Me.PropertyMap("SALES_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SALES_FLAG4") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SIGN_NUMBER 簽約家數-類比"
        '' <summary>
        '' ANALOGY_SIGN_NUMBER 簽約家數-類比
        '' </summary>
        Public Property ANALOGY_SIGN_NUMBER() As String
            Get
                Return Me.PropertyMap("ANALOGY_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SIGN_NUMBER 簽約家數-數位"
        '' <summary>
        '' DIGIT_SIGN_NUMBER 簽約家數-數位
        '' </summary>
        Public Property DIGIT_SIGN_NUMBER() As String
            Get
                Return Me.PropertyMap("DIGIT_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SALES_RATE 上架率-類比"
        '' <summary>
        '' ANALOGY_SALES_RATE 上架率-類比
        '' </summary>
        Public Property ANALOGY_SALES_RATE() As String
            Get
                Return Me.PropertyMap("ANALOGY_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ANALOGY_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SALES_RATE 上架率-數位"
        '' <summary>
        '' DIGIT_SALES_RATE 上架率-數位
        '' </summary>
        Public Property DIGIT_SALES_RATE() As String
            Get
                Return Me.PropertyMap("DIGIT_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DIGIT_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_F_NUMBER 頻道專屬人力"
        '' <summary>
        '' CHANNEL_F_NUMBER 頻道專屬人力
        '' </summary>
        Public Property CHANNEL_F_NUMBER() As String
            Get
                Return Me.PropertyMap("CHANNEL_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_F_NUMBER 頻道編審人力-專職"
        '' <summary>
        '' EDIT_F_NUMBER 頻道編審人力-專職
        '' </summary>
        Public Property EDIT_F_NUMBER() As String
            Get
                Return Me.PropertyMap("EDIT_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDIT_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_P_NUMBER 頻道編審人力-兼職"
        '' <summary>
        '' EDIT_P_NUMBER 頻道編審人力-兼職
        '' </summary>
        Public Property EDIT_P_NUMBER() As String
            Get
                Return Me.PropertyMap("EDIT_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDIT_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_AREA 客服電話-區碼"
        '' <summary>
        '' SERVICE_TEL_AREA 客服電話-區碼
        '' </summary>
        Public Property SERVICE_TEL_AREA() As String
            Get
                Return Me.PropertyMap("SERVICE_TEL_AREA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TEL_AREA") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL 客服電話"
        '' <summary>
        '' SERVICE_TEL 客服電話
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

#Region "SERVICE_EMAIL 電子郵件"
        '' <summary>
        '' SERVICE_EMAIL 電子郵件
        '' </summary>
        Public Property SERVICE_EMAIL() As String
            Get
                Return Me.PropertyMap("SERVICE_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_EMAIL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER 其他"
        '' <summary>
        '' SERVICE_OTHER 其他
        '' </summary>
        Public Property SERVICE_OTHER() As String
            Get
                Return Me.PropertyMap("SERVICE_OTHER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_OTHER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_CASE_NUMBER 受理件數-客服"
        '' <summary>
        '' SERVICE_CASE_NUMBER 受理件數-客服
        '' </summary>
        Public Property SERVICE_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_CASE_NUMBER 受理件數-申訴"
        '' <summary>
        '' COMPLAINT_CASE_NUMBER 受理件數-申訴
        '' </summary>
        Public Property COMPLAINT_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("COMPLAINT_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMPLAINT_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "HANDLE_CASE_NUMBER 核處件數"
        '' <summary>
        '' HANDLE_CASE_NUMBER 核處件數
        '' </summary>
        Public Property HANDLE_CASE_NUMBER() As String
            Get
                Return Me.PropertyMap("HANDLE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HANDLE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DATA_DESC 基本資料補充"
        '' <summary>
        '' DATA_DESC 基本資料補充
        '' </summary>
        Public Property DATA_DESC() As String
            Get
                Return Me.PropertyMap("DATA_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_DESC") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1170"
        ' <summary>Ent_APP1170</ summary>
    Private Property  Ent_APP1170() As  Ent_APP1170		
        Get                                         
            Return Me.PropertyMap("Ent_APP1170")        
        End Get                                     
        Set(ByVal value As Ent_APP1170)                 
            Me.PropertyMap("Ent_APP1170") = value       
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
                Me.Ent_APP1170.CASE_NO	=	 Me.CASE_NO		 '案件編號
                Me.Ent_APP1170.CHANNEL_NAME	=	 Me.CHANNEL_NAME		 '頻道名稱
                Me.Ent_APP1170.ORG_TYPE1	=	 Me.ORG_TYPE1		 '事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.Ent_APP1170.COUNTRY	=	 Me.COUNTRY		 '國籍
                Me.Ent_APP1170.ORG_TYPE2	=	 Me.ORG_TYPE2		 '分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.Ent_APP1170.COM_NAME	=	 Me.COM_NAME		 '所屬公司
                Me.Ent_APP1170.EVALUATION_S_DATE	=	 Me.EVALUATION_S_DATE		 '評鑑期間(起)
                Me.Ent_APP1170.EVALUATION_E_DATE	=	 Me.EVALUATION_E_DATE		 '評鑑期間(迄)
                Me.Ent_APP1170.LICENSE_S_DATE	=	 Me.LICENSE_S_DATE		 '執照(許可)效期(起)
                Me.Ent_APP1170.LICENSE_E_DATE	=	 Me.LICENSE_E_DATE		 '執照(許可)效期(迄)
                Me.Ent_APP1170.PLAY_S_DATE	=	 Me.PLAY_S_DATE		 '開播日期
                Me.Ent_APP1170.CHANNEL_PAY_TYPE	=	 Me.CHANNEL_PAY_TYPE		 '基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.Ent_APP1170.CHANNEL_PAY_DESC	=	 Me.CHANNEL_PAY_DESC		 '說明
                Me.Ent_APP1170.LOCK_CHANNEL_FLAG	=	 Me.LOCK_CHANNEL_FLAG		 '限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'

                Me.Ent_APP1170.CH_FLAG1	=	 Me.CH_FLAG1		 '頻道屬性-新聞, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG2	=	 Me.CH_FLAG2		 '頻道屬性-財經新聞, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG3	=	 Me.CH_FLAG3		 '頻道屬性-財經股市, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG4	=	 Me.CH_FLAG4		 '頻道屬性-兒少, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG5	=	 Me.CH_FLAG5		 '頻道屬性-戲劇, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG6	=	 Me.CH_FLAG6		 '頻道屬性-電影, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG7	=	 Me.CH_FLAG7		 '頻道屬性-體育, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG8	=	 Me.CH_FLAG8		 '頻道屬性-教育文化, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG9	=	 Me.CH_FLAG9		 '頻道屬性-音樂, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG10	=	 Me.CH_FLAG10		 '頻道屬性-宗教, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG11	=	 Me.CH_FLAG11		 '頻道屬性-綜合, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG12	=	 Me.CH_FLAG12		 '頻道屬性-地方頻道, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG13	=	 Me.CH_FLAG13		 '頻道屬性-其他類型, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG13_DESC	=	 Me.CH_FLAG13_DESC		 '頻道屬性-其他類型-說明
                Me.Ent_APP1170.CHARGE_STANDARD_AMT	=	 Me.CHARGE_STANDARD_AMT		 '收費標準
                Me.Ent_APP1170.CH_AUTHORIZE1_AMT	=	 Me.CH_AUTHORIZE1_AMT		 '前二年度頻道授權費
                Me.Ent_APP1170.CH_AUTHORIZE2_AMT	=	 Me.CH_AUTHORIZE2_AMT		 '前一年度頻道授權費
                Me.Ent_APP1170.CH_AUTHORIZE3_AMT	=	 Me.CH_AUTHORIZE3_AMT		 '本年度頻道授權費
                Me.Ent_APP1170.SALES_AGENT	=	 Me.SALES_AGENT		 '本年度銷售代理商
                Me.Ent_APP1170.SALES_FLAG1	=	 Me.SALES_FLAG1		 '上架方式-有線電視(類比), 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG2	=	 Me.SALES_FLAG2		 '上架方式-有線電視(數位), 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG3	=	 Me.SALES_FLAG3		 '上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG4	=	 Me.SALES_FLAG4		 '上架方式-直播衛星, 勾選為'Y'
                Me.Ent_APP1170.ANALOGY_SIGN_NUMBER	=	 Me.ANALOGY_SIGN_NUMBER		 '簽約家數-類比
                Me.Ent_APP1170.DIGIT_SIGN_NUMBER	=	 Me.DIGIT_SIGN_NUMBER		 '簽約家數-數位
                Me.Ent_APP1170.ANALOGY_SALES_RATE	=	 Me.ANALOGY_SALES_RATE		 '上架率-類比
                Me.Ent_APP1170.DIGIT_SALES_RATE	=	 Me.DIGIT_SALES_RATE		 '上架率-數位
                Me.Ent_APP1170.CHANNEL_F_NUMBER	=	 Me.CHANNEL_F_NUMBER		 '頻道專屬人力
                Me.Ent_APP1170.EDIT_F_NUMBER	=	 Me.EDIT_F_NUMBER		 '頻道編審人力-專職
                Me.Ent_APP1170.EDIT_P_NUMBER	=	 Me.EDIT_P_NUMBER		 '頻道編審人力-兼職
                Me.Ent_APP1170.SERVICE_TEL_AREA	=	 Me.SERVICE_TEL_AREA		 '客服電話-區碼
                Me.Ent_APP1170.SERVICE_TEL	=	 Me.SERVICE_TEL		 '客服電話
                Me.Ent_APP1170.SERVICE_EMAIL	=	 Me.SERVICE_EMAIL		 '電子郵件
                Me.Ent_APP1170.SERVICE_OTHER	=	 Me.SERVICE_OTHER		 '其他
                Me.Ent_APP1170.SERVICE_CASE_NUMBER	=	 Me.SERVICE_CASE_NUMBER		 '受理件數-客服
                Me.Ent_APP1170.COMPLAINT_CASE_NUMBER	=	 Me.COMPLAINT_CASE_NUMBER		 '受理件數-申訴
                Me.Ent_APP1170.HANDLE_CASE_NUMBER	=	 Me.HANDLE_CASE_NUMBER		 '核處件數
                Me.Ent_APP1170.DATA_DESC	=	 Me.DATA_DESC		 '基本資料補充


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1170.Insert()

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
                Me.Ent_APP1170.CASE_NO	=	 Me.CASE_NO		 '案件編號
                Me.Ent_APP1170.CHANNEL_NAME	=	 Me.CHANNEL_NAME		 '頻道名稱
                Me.Ent_APP1170.ORG_TYPE1	=	 Me.ORG_TYPE1		 '事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.Ent_APP1170.COUNTRY	=	 Me.COUNTRY		 '國籍
                Me.Ent_APP1170.ORG_TYPE2	=	 Me.ORG_TYPE2		 '分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.Ent_APP1170.COM_NAME	=	 Me.COM_NAME		 '所屬公司
                Me.Ent_APP1170.EVALUATION_S_DATE	=	 Me.EVALUATION_S_DATE		 '評鑑期間(起)
                Me.Ent_APP1170.EVALUATION_E_DATE	=	 Me.EVALUATION_E_DATE		 '評鑑期間(迄)
                Me.Ent_APP1170.LICENSE_S_DATE	=	 Me.LICENSE_S_DATE		 '執照(許可)效期(起)
                Me.Ent_APP1170.LICENSE_E_DATE	=	 Me.LICENSE_E_DATE		 '執照(許可)效期(迄)
                Me.Ent_APP1170.PLAY_S_DATE	=	 Me.PLAY_S_DATE		 '開播日期
                Me.Ent_APP1170.CHANNEL_PAY_TYPE	=	 Me.CHANNEL_PAY_TYPE		 '基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.Ent_APP1170.CHANNEL_PAY_DESC	=	 Me.CHANNEL_PAY_DESC		 '說明
                Me.Ent_APP1170.LOCK_CHANNEL_FLAG	=	 Me.LOCK_CHANNEL_FLAG		 '限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'

                Me.Ent_APP1170.CH_FLAG1	=	 Me.CH_FLAG1		 '頻道屬性-新聞, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG2	=	 Me.CH_FLAG2		 '頻道屬性-財經新聞, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG3	=	 Me.CH_FLAG3		 '頻道屬性-財經股市, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG4	=	 Me.CH_FLAG4		 '頻道屬性-兒少, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG5	=	 Me.CH_FLAG5		 '頻道屬性-戲劇, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG6	=	 Me.CH_FLAG6		 '頻道屬性-電影, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG7	=	 Me.CH_FLAG7		 '頻道屬性-體育, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG8	=	 Me.CH_FLAG8		 '頻道屬性-教育文化, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG9	=	 Me.CH_FLAG9		 '頻道屬性-音樂, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG10	=	 Me.CH_FLAG10		 '頻道屬性-宗教, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG11	=	 Me.CH_FLAG11		 '頻道屬性-綜合, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG12	=	 Me.CH_FLAG12		 '頻道屬性-地方頻道, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG13	=	 Me.CH_FLAG13		 '頻道屬性-其他類型, 勾選為'Y'
                Me.Ent_APP1170.CH_FLAG13_DESC	=	 Me.CH_FLAG13_DESC		 '頻道屬性-其他類型-說明
                Me.Ent_APP1170.CHARGE_STANDARD_AMT	=	 Me.CHARGE_STANDARD_AMT		 '收費標準
                Me.Ent_APP1170.CH_AUTHORIZE1_AMT	=	 Me.CH_AUTHORIZE1_AMT		 '前二年度頻道授權費
                Me.Ent_APP1170.CH_AUTHORIZE2_AMT	=	 Me.CH_AUTHORIZE2_AMT		 '前一年度頻道授權費
                Me.Ent_APP1170.CH_AUTHORIZE3_AMT	=	 Me.CH_AUTHORIZE3_AMT		 '本年度頻道授權費
                Me.Ent_APP1170.SALES_AGENT	=	 Me.SALES_AGENT		 '本年度銷售代理商
                Me.Ent_APP1170.SALES_FLAG1	=	 Me.SALES_FLAG1		 '上架方式-有線電視(類比), 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG2	=	 Me.SALES_FLAG2		 '上架方式-有線電視(數位), 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG3	=	 Me.SALES_FLAG3		 '上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'
                Me.Ent_APP1170.SALES_FLAG4	=	 Me.SALES_FLAG4		 '上架方式-直播衛星, 勾選為'Y'
                Me.Ent_APP1170.ANALOGY_SIGN_NUMBER	=	 Me.ANALOGY_SIGN_NUMBER		 '簽約家數-類比
                Me.Ent_APP1170.DIGIT_SIGN_NUMBER	=	 Me.DIGIT_SIGN_NUMBER		 '簽約家數-數位
                Me.Ent_APP1170.ANALOGY_SALES_RATE	=	 Me.ANALOGY_SALES_RATE		 '上架率-類比
                Me.Ent_APP1170.DIGIT_SALES_RATE	=	 Me.DIGIT_SALES_RATE		 '上架率-數位
                Me.Ent_APP1170.CHANNEL_F_NUMBER	=	 Me.CHANNEL_F_NUMBER		 '頻道專屬人力
                Me.Ent_APP1170.EDIT_F_NUMBER	=	 Me.EDIT_F_NUMBER		 '頻道編審人力-專職
                Me.Ent_APP1170.EDIT_P_NUMBER	=	 Me.EDIT_P_NUMBER		 '頻道編審人力-兼職
                Me.Ent_APP1170.SERVICE_TEL_AREA	=	 Me.SERVICE_TEL_AREA		 '客服電話-區碼
                Me.Ent_APP1170.SERVICE_TEL	=	 Me.SERVICE_TEL		 '客服電話
                Me.Ent_APP1170.SERVICE_EMAIL	=	 Me.SERVICE_EMAIL		 '電子郵件
                Me.Ent_APP1170.SERVICE_OTHER	=	 Me.SERVICE_OTHER		 '其他
                Me.Ent_APP1170.SERVICE_CASE_NUMBER	=	 Me.SERVICE_CASE_NUMBER		 '受理件數-客服
                Me.Ent_APP1170.COMPLAINT_CASE_NUMBER	=	 Me.COMPLAINT_CASE_NUMBER		 '受理件數-申訴
                Me.Ent_APP1170.HANDLE_CASE_NUMBER	=	 Me.HANDLE_CASE_NUMBER		 '核處件數
                Me.Ent_APP1170.DATA_DESC	=	 Me.DATA_DESC		 '基本資料補充


    		'=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)                             
		Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)     
 		Me.Ent_APP1170.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1170.Update()

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
 		Me.Ent_APP1170.SqlRetrictions = Me.ProcessCondition(condition.ToString())

 

                '=== 刪除資料 ===
				If Me.Ent_APP1170.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1170.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)		 'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)		 '案件編號
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_NAME", Me.CHANNEL_NAME)		 '頻道名稱
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE1", Me.ORG_TYPE1)		 '事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'
                Me.ProcessQueryCondition(condition, "=", "COUNTRY", Me.COUNTRY)		 '國籍
                Me.ProcessQueryCondition(condition, "=", "ORG_TYPE2", Me.ORG_TYPE2)		 '分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_NAME", Me.COM_NAME)		 '所屬公司
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_S_DATE", Me.EVALUATION_S_DATE)		 '評鑑期間(起)
                Me.ProcessQueryCondition(condition, "=", "EVALUATION_E_DATE", Me.EVALUATION_E_DATE)		 '評鑑期間(迄)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_S_DATE", Me.LICENSE_S_DATE)		 '執照(許可)效期(起)
                Me.ProcessQueryCondition(condition, "=", "LICENSE_E_DATE", Me.LICENSE_E_DATE)		 '執照(許可)效期(迄)
                Me.ProcessQueryCondition(condition, "=", "PLAY_S_DATE", Me.PLAY_S_DATE)		 '開播日期
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_PAY_TYPE", Me.CHANNEL_PAY_TYPE)		 '基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_PAY_DESC", Me.CHANNEL_PAY_DESC)		 '說明
                Me.ProcessQueryCondition(condition, "=", "LOCK_CHANNEL_FLAG", Me.LOCK_CHANNEL_FLAG)		 '限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'

                Me.ProcessQueryCondition(condition, "=", "CH_FLAG1", Me.CH_FLAG1)		 '頻道屬性-新聞, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG2", Me.CH_FLAG2)		 '頻道屬性-財經新聞, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG3", Me.CH_FLAG3)		 '頻道屬性-財經股市, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG4", Me.CH_FLAG4)		 '頻道屬性-兒少, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG5", Me.CH_FLAG5)		 '頻道屬性-戲劇, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG6", Me.CH_FLAG6)		 '頻道屬性-電影, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG7", Me.CH_FLAG7)		 '頻道屬性-體育, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG8", Me.CH_FLAG8)		 '頻道屬性-教育文化, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG9", Me.CH_FLAG9)		 '頻道屬性-音樂, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG10", Me.CH_FLAG10)		 '頻道屬性-宗教, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG11", Me.CH_FLAG11)		 '頻道屬性-綜合, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG12", Me.CH_FLAG12)		 '頻道屬性-地方頻道, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "CH_FLAG13", Me.CH_FLAG13)		 '頻道屬性-其他類型, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "%LIKE%", "CH_FLAG13_DESC", Me.CH_FLAG13_DESC)		 '頻道屬性-其他類型-說明
                Me.ProcessQueryCondition(condition, "=", "CHARGE_STANDARD_AMT", Me.CHARGE_STANDARD_AMT)		 '收費標準
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE1_AMT", Me.CH_AUTHORIZE1_AMT)		 '前二年度頻道授權費
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE2_AMT", Me.CH_AUTHORIZE2_AMT)		 '前一年度頻道授權費
                Me.ProcessQueryCondition(condition, "=", "CH_AUTHORIZE3_AMT", Me.CH_AUTHORIZE3_AMT)		 '本年度頻道授權費
                Me.ProcessQueryCondition(condition, "=", "SALES_AGENT", Me.SALES_AGENT)		 '本年度銷售代理商
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG1", Me.SALES_FLAG1)		 '上架方式-有線電視(類比), 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG2", Me.SALES_FLAG2)		 '上架方式-有線電視(數位), 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG3", Me.SALES_FLAG3)		 '上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "SALES_FLAG4", Me.SALES_FLAG4)		 '上架方式-直播衛星, 勾選為'Y'
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SIGN_NUMBER", Me.ANALOGY_SIGN_NUMBER)		 '簽約家數-類比
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SIGN_NUMBER", Me.DIGIT_SIGN_NUMBER)		 '簽約家數-數位
                Me.ProcessQueryCondition(condition, "=", "ANALOGY_SALES_RATE", Me.ANALOGY_SALES_RATE)		 '上架率-類比
                Me.ProcessQueryCondition(condition, "=", "DIGIT_SALES_RATE", Me.DIGIT_SALES_RATE)		 '上架率-數位
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_F_NUMBER", Me.CHANNEL_F_NUMBER)		 '頻道專屬人力
                Me.ProcessQueryCondition(condition, "=", "EDIT_F_NUMBER", Me.EDIT_F_NUMBER)		 '頻道編審人力-專職
                Me.ProcessQueryCondition(condition, "=", "EDIT_P_NUMBER", Me.EDIT_P_NUMBER)		 '頻道編審人力-兼職
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL_AREA", Me.SERVICE_TEL_AREA)		 '客服電話-區碼
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TEL", Me.SERVICE_TEL)		 '客服電話
                Me.ProcessQueryCondition(condition, "=", "SERVICE_EMAIL", Me.SERVICE_EMAIL)		 '電子郵件
                Me.ProcessQueryCondition(condition, "=", "SERVICE_OTHER", Me.SERVICE_OTHER)		 '其他
                Me.ProcessQueryCondition(condition, "=", "SERVICE_CASE_NUMBER", Me.SERVICE_CASE_NUMBER)		 '受理件數-客服
                Me.ProcessQueryCondition(condition, "=", "COMPLAINT_CASE_NUMBER", Me.COMPLAINT_CASE_NUMBER)		 '受理件數-申訴
                Me.ProcessQueryCondition(condition, "=", "HANDLE_CASE_NUMBER", Me.HANDLE_CASE_NUMBER)		 '核處件數
                Me.ProcessQueryCondition(condition, "%LIKE%", "DATA_DESC", Me.DATA_DESC)		 '基本資料補充

                Me.Ent_APP1170.SqlRetrictions = condition.ToString()

         
                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1170.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1170.OrderBys = Me.OrderBys
                End If
                
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1170.Query()
                Else
                    result = Me.Ent_APP1170.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1170.TotalRowCount
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
End NameSpace

