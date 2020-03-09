'ProductName                 : TSBA 
'File Name					 : CtAPP1041 
'Description	             : CtAPP1041 營運計畫摘要表_申設(一般頻道)
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/15  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1041
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1041 = New ENT_APP1041(Me.DBManager, Me.LogUtil)
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

#Region "TRANS_TYPE 信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'"
        '' <summary>
        '' TRANS_TYPE 信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'
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

#Region "TRANS_DESC 信號傳輸方式說明"
        '' <summary>
        '' TRANS_DESC 信號傳輸方式說明
        '' </summary>
        Public Property TRANS_DESC() As String
            Get
                Return Me.PropertyMap("TRANS_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRANS_DESC") = value
            End Set
        End Property
#End Region

#Region "TRANS_BACKUP 備援傳輸方式"
        '' <summary>
        '' TRANS_BACKUP 備援傳輸方式
        '' </summary>
        Public Property TRANS_BACKUP() As String
            Get
                Return Me.PropertyMap("TRANS_BACKUP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRANS_BACKUP") = value
            End Set
        End Property
#End Region

#Region "DESC01 爭議處理機制"
        '' <summary>
        '' DESC01 爭議處理機制
        '' </summary>
        Public Property DESC01() As String
            Get
                Return Me.PropertyMap("DESC01")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC01") = value
            End Set
        End Property
#End Region

#Region "DESC02 頻道推廣計畫"
        '' <summary>
        '' DESC02 頻道推廣計畫
        '' </summary>
        Public Property DESC02() As String
            Get
                Return Me.PropertyMap("DESC02")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC02") = value
            End Set
        End Property
#End Region

#Region "DESC03 資訊公開措施規畫"
        '' <summary>
        '' DESC03 資訊公開措施規畫
        '' </summary>
        Public Property DESC03() As String
            Get
                Return Me.PropertyMap("DESC03")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC03") = value
            End Set
        End Property
#End Region

#Region "DESC04 頻道經營理念/定位"
        '' <summary>
        '' DESC04 頻道經營理念/定位
        '' </summary>
        Public Property DESC04() As String
            Get
                Return Me.PropertyMap("DESC04")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC04") = value
            End Set
        End Property
#End Region

#Region "DESC05 市場調查資料"
        '' <summary>
        '' DESC05 市場調查資料
        '' </summary>
        Public Property DESC05() As String
            Get
                Return Me.PropertyMap("DESC05")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC05") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_ATTRIBUTES 頻道屬性"
        '' <summary>
        '' CHANNEL_ATTRIBUTES 頻道屬性
        '' </summary>
        Public Property CHANNEL_ATTRIBUTES() As String
            Get
                Return Me.PropertyMap("CHANNEL_ATTRIBUTES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_ATTRIBUTES") = value
            End Set
        End Property
#End Region

#Region "FIR_SHOW_TYPE 主要節目類型"
        '' <summary>
        '' FIR_SHOW_TYPE 主要節目類型
        '' </summary>
        Public Property FIR_SHOW_TYPE() As String
            Get
                Return Me.PropertyMap("FIR_SHOW_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FIR_SHOW_TYPE") = value
            End Set
        End Property
#End Region

#Region "SEC_SHOW_TYPE 次要節目類型"
        '' <summary>
        '' SEC_SHOW_TYPE 次要節目類型
        '' </summary>
        Public Property SEC_SHOW_TYPE() As String
            Get
                Return Me.PropertyMap("SEC_SHOW_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SEC_SHOW_TYPE") = value
            End Set
        End Property
#End Region

#Region "COUNTRY1 外國-國家1"
        '' <summary>
        '' COUNTRY1 外國-國家1
        '' </summary>
        Public Property COUNTRY1() As String
            Get
                Return Me.PropertyMap("COUNTRY1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY1") = value
            End Set
        End Property
#End Region

#Region "COUNTRY2 外國-國家2"
        '' <summary>
        '' COUNTRY2 外國-國家2
        '' </summary>
        Public Property COUNTRY2() As String
            Get
                Return Me.PropertyMap("COUNTRY2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY2") = value
            End Set
        End Property
#End Region

#Region "COUNTRY3 外國-國家3"
        '' <summary>
        '' COUNTRY3 外國-國家3
        '' </summary>
        Public Property COUNTRY3() As String
            Get
                Return Me.PropertyMap("COUNTRY3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COUNTRY3") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE1 第1年/上半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE1 第1年/上半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE1() As String
            Get
                Return Me.PropertyMap("SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE2 第1年/下半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE2 第1年/下半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE2() As String
            Get
                Return Me.PropertyMap("SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE3 第2年/上半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE3 第2年/上半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE3() As String
            Get
                Return Me.PropertyMap("SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE4 第2年/下半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE4 第2年/下半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE4() As String
            Get
                Return Me.PropertyMap("SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE11 第1年/上半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE11 第1年/上半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE11() As String
            Get
                Return Me.PropertyMap("SHOW_RATE11")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE11") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE12 第1年/下半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE12 第1年/下半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE12() As String
            Get
                Return Me.PropertyMap("SHOW_RATE12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE12") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE13 第2年/上半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE13 第2年/上半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE13() As String
            Get
                Return Me.PropertyMap("SHOW_RATE13")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE13") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE14 第2年/下半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE14 第2年/下半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE14() As String
            Get
                Return Me.PropertyMap("SHOW_RATE14")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE14") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE21 第1年/上半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE21 第1年/上半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE21() As String
            Get
                Return Me.PropertyMap("SHOW_RATE21")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE21") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE22 第1年/下半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE22 第1年/下半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE22() As String
            Get
                Return Me.PropertyMap("SHOW_RATE22")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE22") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE23 第2年/上半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE23 第2年/上半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE23() As String
            Get
                Return Me.PropertyMap("SHOW_RATE23")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE23") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE24 第2年/下半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE24 第2年/下半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE24() As String
            Get
                Return Me.PropertyMap("SHOW_RATE24")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE24") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE31 第1年/上半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE31 第1年/上半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE31() As String
            Get
                Return Me.PropertyMap("SHOW_RATE31")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE31") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE32 第1年/下半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE32 第1年/下半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE32() As String
            Get
                Return Me.PropertyMap("SHOW_RATE32")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE32") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE33 第2年/上半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE33 第2年/上半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE33() As String
            Get
                Return Me.PropertyMap("SHOW_RATE33")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE33") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE34 第2年/下半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE34 第2年/下半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE34() As String
            Get
                Return Me.PropertyMap("SHOW_RATE34")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_RATE34") = value
            End Set
        End Property
#End Region

#Region "LAW_3_8_FLAG 本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LAW_3_8_FLAG 本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LAW_3_8_FLAG() As String
            Get
                Return Me.PropertyMap("LAW_3_8_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LAW_3_8_FLAG") = value
            End Set
        End Property
#End Region

#Region "LAW_DESC 不符合原因"
        '' <summary>
        '' LAW_DESC 不符合原因
        '' </summary>
        Public Property LAW_DESC() As String
            Get
                Return Me.PropertyMap("LAW_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LAW_DESC") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE1 第1年/上半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE1 第1年/上半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE1() As String
            Get
                Return Me.PropertyMap("S_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE2 第1年/下半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE2 第1年/下半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE2() As String
            Get
                Return Me.PropertyMap("S_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE3 第2年/上半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE3 第2年/上半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE3() As String
            Get
                Return Me.PropertyMap("S_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE4 第2年/下半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE4 第2年/下半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE4() As String
            Get
                Return Me.PropertyMap("S_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("S_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE1 第1年/上半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE1 第1年/上半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE1() As String
            Get
                Return Me.PropertyMap("O_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE2 第1年/下半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE2 第1年/下半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE2() As String
            Get
                Return Me.PropertyMap("O_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE3 第2年/上半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE3 第2年/上半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE3() As String
            Get
                Return Me.PropertyMap("O_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE4 第2年/下半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE4 第2年/下半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE4() As String
            Get
                Return Me.PropertyMap("O_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("O_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE1 第1年/上半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE1 第1年/上半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE1() As String
            Get
                Return Me.PropertyMap("N_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("N_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE2 第1年/下半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE2 第1年/下半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE2() As String
            Get
                Return Me.PropertyMap("N_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("N_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE3 第2年/上半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE3 第2年/上半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE3() As String
            Get
                Return Me.PropertyMap("N_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("N_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE4 第2年/下半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE4 第2年/下半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE4() As String
            Get
                Return Me.PropertyMap("N_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("N_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE1 第1年/上半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE1 第1年/上半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE1() As String
            Get
                Return Me.PropertyMap("F_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("F_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE2 第1年/下半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE2 第1年/下半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE2() As String
            Get
                Return Me.PropertyMap("F_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("F_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE3 第2年/上半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE3 第2年/上半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE3() As String
            Get
                Return Me.PropertyMap("F_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("F_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE4 第2年/下半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE4 第2年/下半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE4() As String
            Get
                Return Me.PropertyMap("F_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("F_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "DESC06 傳播本國文化及本國自製節目之實施方案"
        '' <summary>
        '' DESC06 傳播本國文化及本國自製節目之實施方案
        '' </summary>
        Public Property DESC06() As String
            Get
                Return Me.PropertyMap("DESC06")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC06") = value
            End Set
        End Property
#End Region

#Region "DESC07 節目製作自律規範"
        '' <summary>
        '' DESC07 節目製作自律規範
        '' </summary>
        Public Property DESC07() As String
            Get
                Return Me.PropertyMap("DESC07")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC07") = value
            End Set
        End Property
#End Region

#Region "UNIVERSAL_RATE 普遍級-播出比例, 不可大於100"
        '' <summary>
        '' UNIVERSAL_RATE 普遍級-播出比例, 不可大於100
        '' </summary>
        Public Property UNIVERSAL_RATE() As String
            Get
                Return Me.PropertyMap("UNIVERSAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UNIVERSAL_RATE") = value
            End Set
        End Property
#End Region

#Region "PROTECTION_RATE 保護級-播出比例, 不可大於100"
        '' <summary>
        '' PROTECTION_RATE 保護級-播出比例, 不可大於100
        '' </summary>
        Public Property PROTECTION_RATE() As String
            Get
                Return Me.PropertyMap("PROTECTION_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROTECTION_RATE") = value
            End Set
        End Property
#End Region

#Region "SECONDARY12_RATE 輔12級-播出比例, 不可大於100"
        '' <summary>
        '' SECONDARY12_RATE 輔12級-播出比例, 不可大於100
        '' </summary>
        Public Property SECONDARY12_RATE() As String
            Get
                Return Me.PropertyMap("SECONDARY12_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SECONDARY12_RATE") = value
            End Set
        End Property
#End Region

#Region "SECONDARY15_RATE 輔15級-播出比例, 不可大於100"
        '' <summary>
        '' SECONDARY15_RATE 輔15級-播出比例, 不可大於100
        '' </summary>
        Public Property SECONDARY15_RATE() As String
            Get
                Return Me.PropertyMap("SECONDARY15_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SECONDARY15_RATE") = value
            End Set
        End Property
#End Region

#Region "LIMITATION_RATE 限制級-播出比例, 不可大於100"
        '' <summary>
        '' LIMITATION_RATE 限制級-播出比例, 不可大於100
        '' </summary>
        Public Property LIMITATION_RATE() As String
            Get
                Return Me.PropertyMap("LIMITATION_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LIMITATION_RATE") = value
            End Set
        End Property
#End Region

#Region "MAKESHOE_FLAG 製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' MAKESHOE_FLAG 製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property MAKESHOE_FLAG() As String
            Get
                Return Me.PropertyMap("MAKESHOE_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MAKESHOE_FLAG") = value
            End Set
        End Property
#End Region

#Region "MUTICHANNEL_FLAG 同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' MUTICHANNEL_FLAG 同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property MUTICHANNEL_FLAG() As String
            Get
                Return Me.PropertyMap("MUTICHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MUTICHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SELFORG_FLAG 是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SELFORG_FLAG 是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SELFORG_FLAG() As String
            Get
                Return Me.PropertyMap("SELFORG_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SELFORG_FLAG") = value
            End Set
        End Property
#End Region

#Region "ORG_NAME 組織名稱"
        '' <summary>
        '' ORG_NAME 組織名稱
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

#Region "MEETING_FREQ 開會頻率"
        '' <summary>
        '' MEETING_FREQ 開會頻率
        '' </summary>
        Public Property MEETING_FREQ() As String
            Get
                Return Me.PropertyMap("MEETING_FREQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MEETING_FREQ") = value
            End Set
        End Property
#End Region

#Region "MEETING_PEOPLE 人數"
        '' <summary>
        '' MEETING_PEOPLE 人數
        '' </summary>
        Public Property MEETING_PEOPLE() As String
            Get
                Return Me.PropertyMap("MEETING_PEOPLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MEETING_PEOPLE") = value
            End Set
        End Property
#End Region

#Region "DESC08 自律組織替代機制"
        '' <summary>
        '' DESC08 自律組織替代機制
        '' </summary>
        Public Property DESC08() As String
            Get
                Return Me.PropertyMap("DESC08")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC08") = value
            End Set
        End Property
#End Region

#Region "SHOW1_FLAG 新聞/財經新聞"
        '' <summary>
        '' SHOW1_FLAG 新聞/財經新聞
        '' </summary>
        Public Property SHOW1_FLAG() As String
            Get
                Return Me.PropertyMap("SHOW1_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW1_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW1_PAGE 新聞/財經新聞-頁次"
        '' <summary>
        '' SHOW1_PAGE 新聞/財經新聞-頁次
        '' </summary>
        Public Property SHOW1_PAGE() As String
            Get
                Return Me.PropertyMap("SHOW1_PAGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW1_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW2_FLAG 財經股市節目"
        '' <summary>
        '' SHOW2_FLAG 財經股市節目
        '' </summary>
        Public Property SHOW2_FLAG() As String
            Get
                Return Me.PropertyMap("SHOW2_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW2_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW2_PAGE 財經股市節目-頁次"
        '' <summary>
        '' SHOW2_PAGE 財經股市節目-頁次
        '' </summary>
        Public Property SHOW2_PAGE() As String
            Get
                Return Me.PropertyMap("SHOW2_PAGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW2_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW3_FLAG 兒少節目"
        '' <summary>
        '' SHOW3_FLAG 兒少節目
        '' </summary>
        Public Property SHOW3_FLAG() As String
            Get
                Return Me.PropertyMap("SHOW3_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW3_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW3_PAGE 兒少節目-頁次"
        '' <summary>
        '' SHOW3_PAGE 兒少節目-頁次
        '' </summary>
        Public Property SHOW3_PAGE() As String
            Get
                Return Me.PropertyMap("SHOW3_PAGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW3_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW_FLAG 限制級節目"
        '' <summary>
        '' SHOW_FLAG 限制級節目
        '' </summary>
        Public Property SHOW_FLAG() As String
            Get
                Return Me.PropertyMap("SHOW_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW4_PAGE 限制級節目-頁次"
        '' <summary>
        '' SHOW4_PAGE 限制級節目-頁次
        '' </summary>
        Public Property SHOW4_PAGE() As String
            Get
                Return Me.PropertyMap("SHOW4_PAGE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOW4_PAGE") = value
            End Set
        End Property
#End Region

#Region "DESC09 獎勵或違規紀錄"
        '' <summary>
        '' DESC09 獎勵或違規紀錄
        '' </summary>
        Public Property DESC09() As String
            Get
                Return Me.PropertyMap("DESC09")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC09") = value
            End Set
        End Property
#End Region

#Region "CHARGE1_FLAG 收費基準-有線電視（類比）"
        '' <summary>
        '' CHARGE1_FLAG 收費基準-有線電視（類比）
        '' </summary>
        Public Property CHARGE1_FLAG() As String
            Get
                Return Me.PropertyMap("CHARGE1_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE1_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE2_FLAG 收費基準-有線電視（數位）"
        '' <summary>
        '' CHARGE2_FLAG 收費基準-有線電視（數位）
        '' </summary>
        Public Property CHARGE2_FLAG() As String
            Get
                Return Me.PropertyMap("CHARGE2_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE2_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE2_AMT 收費基準-有線電視（數位）-金額"
        '' <summary>
        '' CHARGE2_AMT 收費基準-有線電視（數位）-金額
        '' </summary>
        Public Property CHARGE2_AMT() As String
            Get
                Return Me.PropertyMap("CHARGE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CHARGE3_FLAG 收費基準-其他"
        '' <summary>
        '' CHARGE3_FLAG 收費基準-其他
        '' </summary>
        Public Property CHARGE3_FLAG() As String
            Get
                Return Me.PropertyMap("CHARGE3_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE3_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE3_AMT 收費基準-其他-金額"
        '' <summary>
        '' CHARGE3_AMT 收費基準-其他-金額
        '' </summary>
        Public Property CHARGE3_AMT() As String
            Get
                Return Me.PropertyMap("CHARGE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE3_AMT") = value
            End Set
        End Property
#End Region

#Region "CHARGE4_FLAG 收費基準-直播衛星事業"
        '' <summary>
        '' CHARGE4_FLAG 收費基準-直播衛星事業
        '' </summary>
        Public Property CHARGE4_FLAG() As String
            Get
                Return Me.PropertyMap("CHARGE4_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE4_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE4_AMT 收費基準-直播衛星事業-金額"
        '' <summary>
        '' CHARGE4_AMT 收費基準-直播衛星事業-金額
        '' </summary>
        Public Property CHARGE4_AMT() As String
            Get
                Return Me.PropertyMap("CHARGE4_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE4_AMT") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_NUMBER 客服-專職人數"
        '' <summary>
        '' SERVICE_F_NUMBER 客服-專職人數
        '' </summary>
        Public Property SERVICE_F_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_FLAG 客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SERVICE_F_FLAG 客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SERVICE_F_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_F_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_F_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_DESC 客服-專職-共用說明"
        '' <summary>
        '' SERVICE_F_DESC 客服-專職-共用說明
        '' </summary>
        Public Property SERVICE_F_DESC() As String
            Get
                Return Me.PropertyMap("SERVICE_F_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_F_DESC") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_NUMBER 客服-兼職人數"
        '' <summary>
        '' SERVICE_P_NUMBER 客服-兼職人數
        '' </summary>
        Public Property SERVICE_P_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_FLAG 客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SERVICE_P_FLAG 客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SERVICE_P_FLAG() As String
            Get
                Return Me.PropertyMap("SERVICE_P_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_P_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_DESC 客服-兼職-共用說明"
        '' <summary>
        '' SERVICE_P_DESC 客服-兼職-共用說明
        '' </summary>
        Public Property SERVICE_P_DESC() As String
            Get
                Return Me.PropertyMap("SERVICE_P_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_P_DESC") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_SHARE_NUMBER 客服-共用專職人數"
        '' <summary>
        '' SERVICE_F_SHARE_NUMBER 客服-共用專職人數
        '' </summary>
        Public Property SERVICE_F_SHARE_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_F_SHARE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_F_SHARE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_SHARE_NUMBER 客服-共用兼職人數"
        '' <summary>
        '' SERVICE_P_SHARE_NUMBER 客服-共用兼職人數
        '' </summary>
        Public Property SERVICE_P_SHARE_NUMBER() As String
            Get
                Return Me.PropertyMap("SERVICE_P_SHARE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_P_SHARE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DESC10 國際新聞製播規畫"
        '' <summary>
        '' DESC10 國際新聞製播規畫
        '' </summary>
        Public Property DESC10() As String
            Get
                Return Me.PropertyMap("DESC10")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC10") = value
            End Set
        End Property
#End Region

#Region "DESC11 兒少節目製播規畫"
        '' <summary>
        '' DESC11 兒少節目製播規畫
        '' </summary>
        Public Property DESC11() As String
            Get
                Return Me.PropertyMap("DESC11")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC11") = value
            End Set
        End Property
#End Region

#Region "DESC12 身心障礙者進用服務規畫"
        '' <summary>
        '' DESC12 身心障礙者進用服務規畫
        '' </summary>
        Public Property DESC12() As String
            Get
                Return Me.PropertyMap("DESC12")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC12") = value
            End Set
        End Property
#End Region

#Region "DESC13 創新服務規畫"
        '' <summary>
        '' DESC13 創新服務規畫
        '' </summary>
        Public Property DESC13() As String
            Get
                Return Me.PropertyMap("DESC13")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DESC13") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TRAINING_PLAN 客服人力教育訓練規畫"
        '' <summary>
        '' SERVICE_TRAINING_PLAN 客服人力教育訓練規畫
        '' </summary>
        Public Property SERVICE_TRAINING_PLAN() As String
            Get
                Return Me.PropertyMap("SERVICE_TRAINING_PLAN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SERVICE_TRAINING_PLAN") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1041"
        ' <summary>Ent_APP1041</ summary>
        Private Property Ent_APP1041() As ENT_APP1041
            Get
                Return Me.PropertyMap("Ent_APP1041")
            End Get
            Set(ByVal value As ENT_APP1041)
                Me.PropertyMap("Ent_APP1041") = value
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
                Me.Ent_APP1041.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1041.TRANS_TYPE = Me.TRANS_TYPE        '信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.Ent_APP1041.TRANS_DESC = Me.TRANS_DESC        '信號傳輸方式說明
                Me.Ent_APP1041.TRANS_BACKUP = Me.TRANS_BACKUP        '備援傳輸方式
                Me.Ent_APP1041.DESC01 = Me.DESC01        '爭議處理機制
                Me.Ent_APP1041.DESC02 = Me.DESC02        '頻道推廣計畫
                Me.Ent_APP1041.DESC03 = Me.DESC03        '資訊公開措施規畫
                Me.Ent_APP1041.DESC04 = Me.DESC04        '頻道經營理念/定位
                Me.Ent_APP1041.DESC05 = Me.DESC05        '市場調查資料
                Me.Ent_APP1041.CHANNEL_ATTRIBUTES = Me.CHANNEL_ATTRIBUTES        '頻道屬性
                Me.Ent_APP1041.FIR_SHOW_TYPE = Me.FIR_SHOW_TYPE      '主要節目類型
                Me.Ent_APP1041.SEC_SHOW_TYPE = Me.SEC_SHOW_TYPE      '次要節目類型
                Me.Ent_APP1041.COUNTRY1 = Me.COUNTRY1        '外國-國家1
                Me.Ent_APP1041.COUNTRY2 = Me.COUNTRY2        '外國-國家2
                Me.Ent_APP1041.COUNTRY3 = Me.COUNTRY3        '外國-國家3
                Me.Ent_APP1041.SHOW_RATE1 = Me.SHOW_RATE1        '第1年/上半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE2 = Me.SHOW_RATE2        '第1年/下半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE3 = Me.SHOW_RATE3        '第2年/上半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE4 = Me.SHOW_RATE4        '第2年/下半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE11 = Me.SHOW_RATE11      '第1年/上半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE12 = Me.SHOW_RATE12      '第1年/下半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE13 = Me.SHOW_RATE13      '第2年/上半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE14 = Me.SHOW_RATE14      '第2年/下半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE21 = Me.SHOW_RATE21      '第1年/上半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE22 = Me.SHOW_RATE22      '第1年/下半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE23 = Me.SHOW_RATE23      '第2年/上半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE24 = Me.SHOW_RATE24      '第2年/下半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE31 = Me.SHOW_RATE31      '第1年/上半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE32 = Me.SHOW_RATE32      '第1年/下半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE33 = Me.SHOW_RATE33      '第2年/上半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE34 = Me.SHOW_RATE34      '第2年/下半年/外國3, 不可大於100
                Me.Ent_APP1041.LAW_3_8_FLAG = Me.LAW_3_8_FLAG        '本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.LAW_DESC = Me.LAW_DESC        '不符合原因
                Me.Ent_APP1041.S_SHOW_RATE1 = Me.S_SHOW_RATE1        '第1年/上半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE2 = Me.S_SHOW_RATE2        '第1年/下半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE3 = Me.S_SHOW_RATE3        '第2年/上半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE4 = Me.S_SHOW_RATE4        '第2年/下半年-頻道自製, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE1 = Me.O_SHOW_RATE1        '第1年/上半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE2 = Me.O_SHOW_RATE2        '第1年/下半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE3 = Me.O_SHOW_RATE3        '第2年/上半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE4 = Me.O_SHOW_RATE4        '第2年/下半年-外購節目, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE1 = Me.N_SHOW_RATE1        '第1年/上半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE2 = Me.N_SHOW_RATE2        '第1年/下半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE3 = Me.N_SHOW_RATE3        '第2年/上半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE4 = Me.N_SHOW_RATE4        '第2年/下半年-新播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE1 = Me.F_SHOW_RATE1        '第1年/上半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE2 = Me.F_SHOW_RATE2        '第1年/下半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE3 = Me.F_SHOW_RATE3        '第2年/上半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE4 = Me.F_SHOW_RATE4        '第2年/下半年-首播, 不可大於100
                Me.Ent_APP1041.DESC06 = Me.DESC06        '傳播本國文化及本國自製節目之實施方案
                Me.Ent_APP1041.DESC07 = Me.DESC07        '節目製作自律規範
                Me.Ent_APP1041.UNIVERSAL_RATE = Me.UNIVERSAL_RATE        '普遍級-播出比例, 不可大於100
                Me.Ent_APP1041.PROTECTION_RATE = Me.PROTECTION_RATE      '保護級-播出比例, 不可大於100
                Me.Ent_APP1041.SECONDARY12_RATE = Me.SECONDARY12_RATE        '輔12級-播出比例, 不可大於100
                Me.Ent_APP1041.SECONDARY15_RATE = Me.SECONDARY15_RATE        '輔15級-播出比例, 不可大於100
                Me.Ent_APP1041.LIMITATION_RATE = Me.LIMITATION_RATE      '限制級-播出比例, 不可大於100
                Me.Ent_APP1041.MAKESHOE_FLAG = Me.MAKESHOE_FLAG      '製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.MUTICHANNEL_FLAG = Me.MUTICHANNEL_FLAG        '同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SELFORG_FLAG = Me.SELFORG_FLAG        '是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.ORG_NAME = Me.ORG_NAME        '組織名稱
                Me.Ent_APP1041.MEETING_FREQ = Me.MEETING_FREQ        '開會頻率
                Me.Ent_APP1041.MEETING_PEOPLE = Me.MEETING_PEOPLE        '人數
                Me.Ent_APP1041.DESC08 = Me.DESC08        '自律組織替代機制
                Me.Ent_APP1041.SHOW1_FLAG = Me.SHOW1_FLAG        '新聞/財經新聞
                Me.Ent_APP1041.SHOW1_PAGE = Me.SHOW1_PAGE        '新聞/財經新聞-頁次
                Me.Ent_APP1041.SHOW2_FLAG = Me.SHOW2_FLAG        '財經股市節目
                Me.Ent_APP1041.SHOW2_PAGE = Me.SHOW2_PAGE        '財經股市節目-頁次
                Me.Ent_APP1041.SHOW3_FLAG = Me.SHOW3_FLAG        '兒少節目
                Me.Ent_APP1041.SHOW3_PAGE = Me.SHOW3_PAGE        '兒少節目-頁次
                Me.Ent_APP1041.SHOW_FLAG = Me.SHOW_FLAG      '限制級節目
                Me.Ent_APP1041.SHOW4_PAGE = Me.SHOW4_PAGE        '限制級節目-頁次
                Me.Ent_APP1041.DESC09 = Me.DESC09        '獎勵或違規紀錄
                Me.Ent_APP1041.CHARGE1_FLAG = Me.CHARGE1_FLAG        '收費基準-有線電視（類比）
                Me.Ent_APP1041.CHARGE2_FLAG = Me.CHARGE2_FLAG        '收費基準-有線電視（數位）
                Me.Ent_APP1041.CHARGE2_AMT = Me.CHARGE2_AMT      '收費基準-有線電視（數位）-金額
                Me.Ent_APP1041.CHARGE3_FLAG = Me.CHARGE3_FLAG        '收費基準-其他
                Me.Ent_APP1041.CHARGE3_AMT = Me.CHARGE3_AMT      '收費基準-其他-金額
                Me.Ent_APP1041.CHARGE4_FLAG = Me.CHARGE4_FLAG        '收費基準-直播衛星事業
                Me.Ent_APP1041.CHARGE4_AMT = Me.CHARGE4_AMT      '收費基準-直播衛星事業-金額
                Me.Ent_APP1041.SERVICE_F_NUMBER = Me.SERVICE_F_NUMBER        '客服-專職人數
                Me.Ent_APP1041.SERVICE_F_FLAG = Me.SERVICE_F_FLAG        '客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SERVICE_F_DESC = Me.SERVICE_F_DESC        '客服-專職-共用說明
                Me.Ent_APP1041.SERVICE_P_NUMBER = Me.SERVICE_P_NUMBER        '客服-兼職人數
                Me.Ent_APP1041.SERVICE_P_FLAG = Me.SERVICE_P_FLAG        '客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SERVICE_P_DESC = Me.SERVICE_P_DESC        '客服-兼職-共用說明
                Me.Ent_APP1041.SERVICE_F_SHARE_NUMBER = Me.SERVICE_F_SHARE_NUMBER        '客服-共用專職人數
                Me.Ent_APP1041.SERVICE_P_SHARE_NUMBER = Me.SERVICE_P_SHARE_NUMBER        '客服-共用兼職人數
                Me.Ent_APP1041.DESC10 = Me.DESC10        '國際新聞製播規畫
                Me.Ent_APP1041.DESC11 = Me.DESC11        '兒少節目製播規畫
                Me.Ent_APP1041.DESC12 = Me.DESC12        '身心障礙者進用服務規畫
                Me.Ent_APP1041.DESC13 = Me.DESC13        '創新服務規畫
                Me.Ent_APP1041.SERVICE_TRAINING_PLAN = Me.SERVICE_TRAINING_PLAN      '客服人力教育訓練規畫


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1041.Insert()

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
                Me.Ent_APP1041.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1041.TRANS_TYPE = Me.TRANS_TYPE        '信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.Ent_APP1041.TRANS_DESC = Me.TRANS_DESC        '信號傳輸方式說明
                Me.Ent_APP1041.TRANS_BACKUP = Me.TRANS_BACKUP        '備援傳輸方式
                Me.Ent_APP1041.DESC01 = Me.DESC01        '爭議處理機制
                Me.Ent_APP1041.DESC02 = Me.DESC02        '頻道推廣計畫
                Me.Ent_APP1041.DESC03 = Me.DESC03        '資訊公開措施規畫
                Me.Ent_APP1041.DESC04 = Me.DESC04        '頻道經營理念/定位
                Me.Ent_APP1041.DESC05 = Me.DESC05        '市場調查資料
                Me.Ent_APP1041.CHANNEL_ATTRIBUTES = Me.CHANNEL_ATTRIBUTES        '頻道屬性
                Me.Ent_APP1041.FIR_SHOW_TYPE = Me.FIR_SHOW_TYPE      '主要節目類型
                Me.Ent_APP1041.SEC_SHOW_TYPE = Me.SEC_SHOW_TYPE      '次要節目類型
                Me.Ent_APP1041.COUNTRY1 = Me.COUNTRY1        '外國-國家1
                Me.Ent_APP1041.COUNTRY2 = Me.COUNTRY2        '外國-國家2
                Me.Ent_APP1041.COUNTRY3 = Me.COUNTRY3        '外國-國家3
                Me.Ent_APP1041.SHOW_RATE1 = Me.SHOW_RATE1        '第1年/上半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE2 = Me.SHOW_RATE2        '第1年/下半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE3 = Me.SHOW_RATE3        '第2年/上半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE4 = Me.SHOW_RATE4        '第2年/下半年/本國, 不可大於100
                Me.Ent_APP1041.SHOW_RATE11 = Me.SHOW_RATE11      '第1年/上半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE12 = Me.SHOW_RATE12      '第1年/下半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE13 = Me.SHOW_RATE13      '第2年/上半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE14 = Me.SHOW_RATE14      '第2年/下半年/外國1, 不可大於100
                Me.Ent_APP1041.SHOW_RATE21 = Me.SHOW_RATE21      '第1年/上半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE22 = Me.SHOW_RATE22      '第1年/下半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE23 = Me.SHOW_RATE23      '第2年/上半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE24 = Me.SHOW_RATE24      '第2年/下半年/外國2, 不可大於100
                Me.Ent_APP1041.SHOW_RATE31 = Me.SHOW_RATE31      '第1年/上半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE32 = Me.SHOW_RATE32      '第1年/下半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE33 = Me.SHOW_RATE33      '第2年/上半年/外國3, 不可大於100
                Me.Ent_APP1041.SHOW_RATE34 = Me.SHOW_RATE34      '第2年/下半年/外國3, 不可大於100
                Me.Ent_APP1041.LAW_3_8_FLAG = Me.LAW_3_8_FLAG        '本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.LAW_DESC = Me.LAW_DESC        '不符合原因
                Me.Ent_APP1041.S_SHOW_RATE1 = Me.S_SHOW_RATE1        '第1年/上半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE2 = Me.S_SHOW_RATE2        '第1年/下半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE3 = Me.S_SHOW_RATE3        '第2年/上半年-頻道自製, 不可大於100
                Me.Ent_APP1041.S_SHOW_RATE4 = Me.S_SHOW_RATE4        '第2年/下半年-頻道自製, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE1 = Me.O_SHOW_RATE1        '第1年/上半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE2 = Me.O_SHOW_RATE2        '第1年/下半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE3 = Me.O_SHOW_RATE3        '第2年/上半年-外購節目, 不可大於100
                Me.Ent_APP1041.O_SHOW_RATE4 = Me.O_SHOW_RATE4        '第2年/下半年-外購節目, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE1 = Me.N_SHOW_RATE1        '第1年/上半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE2 = Me.N_SHOW_RATE2        '第1年/下半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE3 = Me.N_SHOW_RATE3        '第2年/上半年-新播, 不可大於100
                Me.Ent_APP1041.N_SHOW_RATE4 = Me.N_SHOW_RATE4        '第2年/下半年-新播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE1 = Me.F_SHOW_RATE1        '第1年/上半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE2 = Me.F_SHOW_RATE2        '第1年/下半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE3 = Me.F_SHOW_RATE3        '第2年/上半年-首播, 不可大於100
                Me.Ent_APP1041.F_SHOW_RATE4 = Me.F_SHOW_RATE4        '第2年/下半年-首播, 不可大於100
                Me.Ent_APP1041.DESC06 = Me.DESC06        '傳播本國文化及本國自製節目之實施方案
                Me.Ent_APP1041.DESC07 = Me.DESC07        '節目製作自律規範
                Me.Ent_APP1041.UNIVERSAL_RATE = Me.UNIVERSAL_RATE        '普遍級-播出比例, 不可大於100
                Me.Ent_APP1041.PROTECTION_RATE = Me.PROTECTION_RATE      '保護級-播出比例, 不可大於100
                Me.Ent_APP1041.SECONDARY12_RATE = Me.SECONDARY12_RATE        '輔12級-播出比例, 不可大於100
                Me.Ent_APP1041.SECONDARY15_RATE = Me.SECONDARY15_RATE        '輔15級-播出比例, 不可大於100
                Me.Ent_APP1041.LIMITATION_RATE = Me.LIMITATION_RATE      '限制級-播出比例, 不可大於100
                Me.Ent_APP1041.MAKESHOE_FLAG = Me.MAKESHOE_FLAG      '製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.MUTICHANNEL_FLAG = Me.MUTICHANNEL_FLAG        '同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SELFORG_FLAG = Me.SELFORG_FLAG        '是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.ORG_NAME = Me.ORG_NAME        '組織名稱
                Me.Ent_APP1041.MEETING_FREQ = Me.MEETING_FREQ        '開會頻率
                Me.Ent_APP1041.MEETING_PEOPLE = Me.MEETING_PEOPLE        '人數
                Me.Ent_APP1041.DESC08 = Me.DESC08        '自律組織替代機制
                Me.Ent_APP1041.SHOW1_FLAG = Me.SHOW1_FLAG        '新聞/財經新聞
                Me.Ent_APP1041.SHOW1_PAGE = Me.SHOW1_PAGE        '新聞/財經新聞-頁次
                Me.Ent_APP1041.SHOW2_FLAG = Me.SHOW2_FLAG        '財經股市節目
                Me.Ent_APP1041.SHOW2_PAGE = Me.SHOW2_PAGE        '財經股市節目-頁次
                Me.Ent_APP1041.SHOW3_FLAG = Me.SHOW3_FLAG        '兒少節目
                Me.Ent_APP1041.SHOW3_PAGE = Me.SHOW3_PAGE        '兒少節目-頁次
                Me.Ent_APP1041.SHOW_FLAG = Me.SHOW_FLAG      '限制級節目
                Me.Ent_APP1041.SHOW4_PAGE = Me.SHOW4_PAGE        '限制級節目-頁次
                Me.Ent_APP1041.DESC09 = Me.DESC09        '獎勵或違規紀錄
                Me.Ent_APP1041.CHARGE1_FLAG = Me.CHARGE1_FLAG        '收費基準-有線電視（類比）
                Me.Ent_APP1041.CHARGE2_FLAG = Me.CHARGE2_FLAG        '收費基準-有線電視（數位）
                Me.Ent_APP1041.CHARGE2_AMT = Me.CHARGE2_AMT      '收費基準-有線電視（數位）-金額
                Me.Ent_APP1041.CHARGE3_FLAG = Me.CHARGE3_FLAG        '收費基準-其他
                Me.Ent_APP1041.CHARGE3_AMT = Me.CHARGE3_AMT      '收費基準-其他-金額
                Me.Ent_APP1041.CHARGE4_FLAG = Me.CHARGE4_FLAG        '收費基準-直播衛星事業
                Me.Ent_APP1041.CHARGE4_AMT = Me.CHARGE4_AMT      '收費基準-直播衛星事業-金額
                Me.Ent_APP1041.SERVICE_F_NUMBER = Me.SERVICE_F_NUMBER        '客服-專職人數
                Me.Ent_APP1041.SERVICE_F_FLAG = Me.SERVICE_F_FLAG        '客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SERVICE_F_DESC = Me.SERVICE_F_DESC        '客服-專職-共用說明
                Me.Ent_APP1041.SERVICE_P_NUMBER = Me.SERVICE_P_NUMBER        '客服-兼職人數
                Me.Ent_APP1041.SERVICE_P_FLAG = Me.SERVICE_P_FLAG        '客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.Ent_APP1041.SERVICE_P_DESC = Me.SERVICE_P_DESC        '客服-兼職-共用說明
                Me.Ent_APP1041.SERVICE_F_SHARE_NUMBER = Me.SERVICE_F_SHARE_NUMBER        '客服-共用專職人數
                Me.Ent_APP1041.SERVICE_P_SHARE_NUMBER = Me.SERVICE_P_SHARE_NUMBER        '客服-共用兼職人數
                Me.Ent_APP1041.DESC10 = Me.DESC10        '國際新聞製播規畫
                Me.Ent_APP1041.DESC11 = Me.DESC11        '兒少節目製播規畫
                Me.Ent_APP1041.DESC12 = Me.DESC12        '身心障礙者進用服務規畫
                Me.Ent_APP1041.DESC13 = Me.DESC13        '創新服務規畫
                Me.Ent_APP1041.SERVICE_TRAINING_PLAN = Me.SERVICE_TRAINING_PLAN      '客服人力教育訓練規畫


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1041.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1041.Update()

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
                Me.Ent_APP1041.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1041.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1041.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "TRANS_TYPE", Me.TRANS_TYPE)        '信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'
                Me.ProcessQueryCondition(condition, "%LIKE%", "TRANS_DESC", Me.TRANS_DESC)       '信號傳輸方式說明
                Me.ProcessQueryCondition(condition, "=", "TRANS_BACKUP", Me.TRANS_BACKUP)        '備援傳輸方式
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC01", Me.DESC01)       '爭議處理機制
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC02", Me.DESC02)       '頻道推廣計畫
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC03", Me.DESC03)       '資訊公開措施規畫
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC04", Me.DESC04)       '頻道經營理念/定位
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC05", Me.DESC05)       '市場調查資料
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_ATTRIBUTES", Me.CHANNEL_ATTRIBUTES)        '頻道屬性
                Me.ProcessQueryCondition(condition, "=", "FIR_SHOW_TYPE", Me.FIR_SHOW_TYPE)      '主要節目類型
                Me.ProcessQueryCondition(condition, "=", "SEC_SHOW_TYPE", Me.SEC_SHOW_TYPE)      '次要節目類型
                Me.ProcessQueryCondition(condition, "=", "COUNTRY1", Me.COUNTRY1)        '外國-國家1
                Me.ProcessQueryCondition(condition, "=", "COUNTRY2", Me.COUNTRY2)        '外國-國家2
                Me.ProcessQueryCondition(condition, "=", "COUNTRY3", Me.COUNTRY3)        '外國-國家3
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE1", Me.SHOW_RATE1)        '第1年/上半年/本國, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE2", Me.SHOW_RATE2)        '第1年/下半年/本國, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE3", Me.SHOW_RATE3)        '第2年/上半年/本國, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE4", Me.SHOW_RATE4)        '第2年/下半年/本國, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE11", Me.SHOW_RATE11)      '第1年/上半年/外國1, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE12", Me.SHOW_RATE12)      '第1年/下半年/外國1, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE13", Me.SHOW_RATE13)      '第2年/上半年/外國1, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE14", Me.SHOW_RATE14)      '第2年/下半年/外國1, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE21", Me.SHOW_RATE21)      '第1年/上半年/外國2, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE22", Me.SHOW_RATE22)      '第1年/下半年/外國2, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE23", Me.SHOW_RATE23)      '第2年/上半年/外國2, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE24", Me.SHOW_RATE24)      '第2年/下半年/外國2, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE31", Me.SHOW_RATE31)      '第1年/上半年/外國3, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE32", Me.SHOW_RATE32)      '第1年/下半年/外國3, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE33", Me.SHOW_RATE33)      '第2年/上半年/外國3, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SHOW_RATE34", Me.SHOW_RATE34)      '第2年/下半年/外國3, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "LAW_3_8_FLAG", Me.LAW_3_8_FLAG)        '本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "LAW_DESC", Me.LAW_DESC)       '不符合原因
                Me.ProcessQueryCondition(condition, "=", "S_SHOW_RATE1", Me.S_SHOW_RATE1)        '第1年/上半年-頻道自製, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "S_SHOW_RATE2", Me.S_SHOW_RATE2)        '第1年/下半年-頻道自製, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "S_SHOW_RATE3", Me.S_SHOW_RATE3)        '第2年/上半年-頻道自製, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "S_SHOW_RATE4", Me.S_SHOW_RATE4)        '第2年/下半年-頻道自製, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "O_SHOW_RATE1", Me.O_SHOW_RATE1)        '第1年/上半年-外購節目, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "O_SHOW_RATE2", Me.O_SHOW_RATE2)        '第1年/下半年-外購節目, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "O_SHOW_RATE3", Me.O_SHOW_RATE3)        '第2年/上半年-外購節目, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "O_SHOW_RATE4", Me.O_SHOW_RATE4)        '第2年/下半年-外購節目, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "N_SHOW_RATE1", Me.N_SHOW_RATE1)        '第1年/上半年-新播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "N_SHOW_RATE2", Me.N_SHOW_RATE2)        '第1年/下半年-新播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "N_SHOW_RATE3", Me.N_SHOW_RATE3)        '第2年/上半年-新播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "N_SHOW_RATE4", Me.N_SHOW_RATE4)        '第2年/下半年-新播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "F_SHOW_RATE1", Me.F_SHOW_RATE1)        '第1年/上半年-首播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "F_SHOW_RATE2", Me.F_SHOW_RATE2)        '第1年/下半年-首播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "F_SHOW_RATE3", Me.F_SHOW_RATE3)        '第2年/上半年-首播, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "F_SHOW_RATE4", Me.F_SHOW_RATE4)        '第2年/下半年-首播, 不可大於100
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC06", Me.DESC06)       '傳播本國文化及本國自製節目之實施方案
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC07", Me.DESC07)       '節目製作自律規範
                Me.ProcessQueryCondition(condition, "=", "UNIVERSAL_RATE", Me.UNIVERSAL_RATE)        '普遍級-播出比例, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "PROTECTION_RATE", Me.PROTECTION_RATE)      '保護級-播出比例, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SECONDARY12_RATE", Me.SECONDARY12_RATE)        '輔12級-播出比例, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "SECONDARY15_RATE", Me.SECONDARY15_RATE)        '輔15級-播出比例, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "LIMITATION_RATE", Me.LIMITATION_RATE)      '限制級-播出比例, 不可大於100
                Me.ProcessQueryCondition(condition, "=", "MAKESHOE_FLAG", Me.MAKESHOE_FLAG)      '製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "MUTICHANNEL_FLAG", Me.MUTICHANNEL_FLAG)        '同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "=", "SELFORG_FLAG", Me.SELFORG_FLAG)        '是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "ORG_NAME", Me.ORG_NAME)       '組織名稱
                Me.ProcessQueryCondition(condition, "=", "MEETING_FREQ", Me.MEETING_FREQ)        '開會頻率
                Me.ProcessQueryCondition(condition, "=", "MEETING_PEOPLE", Me.MEETING_PEOPLE)        '人數
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC08", Me.DESC08)       '自律組織替代機制
                Me.ProcessQueryCondition(condition, "=", "SHOW1_FLAG", Me.SHOW1_FLAG)        '新聞/財經新聞
                Me.ProcessQueryCondition(condition, "=", "SHOW1_PAGE", Me.SHOW1_PAGE)        '新聞/財經新聞-頁次
                Me.ProcessQueryCondition(condition, "=", "SHOW2_FLAG", Me.SHOW2_FLAG)        '財經股市節目
                Me.ProcessQueryCondition(condition, "=", "SHOW2_PAGE", Me.SHOW2_PAGE)        '財經股市節目-頁次
                Me.ProcessQueryCondition(condition, "=", "SHOW3_FLAG", Me.SHOW3_FLAG)        '兒少節目
                Me.ProcessQueryCondition(condition, "=", "SHOW3_PAGE", Me.SHOW3_PAGE)        '兒少節目-頁次
                Me.ProcessQueryCondition(condition, "=", "SHOW_FLAG", Me.SHOW_FLAG)      '限制級節目
                Me.ProcessQueryCondition(condition, "=", "SHOW4_PAGE", Me.SHOW4_PAGE)        '限制級節目-頁次
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC09", Me.DESC09)       '獎勵或違規紀錄
                Me.ProcessQueryCondition(condition, "=", "CHARGE1_FLAG", Me.CHARGE1_FLAG)        '收費基準-有線電視（類比）
                Me.ProcessQueryCondition(condition, "=", "CHARGE2_FLAG", Me.CHARGE2_FLAG)        '收費基準-有線電視（數位）
                Me.ProcessQueryCondition(condition, "=", "CHARGE2_AMT", Me.CHARGE2_AMT)      '收費基準-有線電視（數位）-金額
                Me.ProcessQueryCondition(condition, "=", "CHARGE3_FLAG", Me.CHARGE3_FLAG)        '收費基準-其他
                Me.ProcessQueryCondition(condition, "=", "CHARGE3_AMT", Me.CHARGE3_AMT)      '收費基準-其他-金額
                Me.ProcessQueryCondition(condition, "=", "CHARGE4_FLAG", Me.CHARGE4_FLAG)        '收費基準-直播衛星事業
                Me.ProcessQueryCondition(condition, "=", "CHARGE4_AMT", Me.CHARGE4_AMT)      '收費基準-直播衛星事業-金額
                Me.ProcessQueryCondition(condition, "=", "SERVICE_F_NUMBER", Me.SERVICE_F_NUMBER)        '客服-專職人數
                Me.ProcessQueryCondition(condition, "=", "SERVICE_F_FLAG", Me.SERVICE_F_FLAG)        '客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SERVICE_F_DESC", Me.SERVICE_F_DESC)       '客服-專職-共用說明
                Me.ProcessQueryCondition(condition, "=", "SERVICE_P_NUMBER", Me.SERVICE_P_NUMBER)        '客服-兼職人數
                Me.ProcessQueryCondition(condition, "=", "SERVICE_P_FLAG", Me.SERVICE_P_FLAG)        '客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
                Me.ProcessQueryCondition(condition, "%LIKE%", "SERVICE_P_DESC", Me.SERVICE_P_DESC)       '客服-兼職-共用說明
                Me.ProcessQueryCondition(condition, "=", "SERVICE_F_SHARE_NUMBER", Me.SERVICE_F_SHARE_NUMBER)        '客服-共用專職人數
                Me.ProcessQueryCondition(condition, "=", "SERVICE_P_SHARE_NUMBER", Me.SERVICE_P_SHARE_NUMBER)        '客服-共用兼職人數
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC10", Me.DESC10)       '國際新聞製播規畫
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC11", Me.DESC11)       '兒少節目製播規畫
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC12", Me.DESC12)       '身心障礙者進用服務規畫
                Me.ProcessQueryCondition(condition, "%LIKE%", "DESC13", Me.DESC13)       '創新服務規畫
                Me.ProcessQueryCondition(condition, "=", "SERVICE_TRAINING_PLAN", Me.SERVICE_TRAINING_PLAN)      '客服人力教育訓練規畫

                Me.Ent_APP1041.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1041.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1041.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1041.Query()
                Else
                    result = Me.Ent_APP1041.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1041.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region


#Region "DoWordQuery 進行查詢動作"
        '' <summary>
        '' 進行Word Print查詢動作
        '' </summary>
        Public Function DoWordQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.Ent_APP1041.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1041.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1041.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APP1041.DoWordQuery()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


    End Class
End Namespace

