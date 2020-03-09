'----------------------------------------------------------------------------------
'File Name		: APP1041
'Author			: TIM
'Description		: APP1041 營運計畫摘要表_申設(一般頻道)
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/15	TIM		Source Create
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
    ' APP1041 營運計畫摘要表_申設(一般頻道)
    ' </summary>
    Public Class ENT_APP1041
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
            Me.TableName = "APP1041"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,TRANS_DESC,TRANS_BACKUP,DESC01,DESC02,DESC03,DESC04,DESC05,CHANNEL_ATTRIBUTES,FIR_SHOW_TYPE,SEC_SHOW_TYPE,COUNTRY1,COUNTRY2,COUNTRY3,LAW_DESC,DESC06,DESC07,ORG_NAME,MEETING_FREQ,MEETING_PEOPLE,DESC08,SHOW1_PAGE,SHOW2_PAGE,SHOW3_PAGE,SHOW4_PAGE,DESC09,SERVICE_F_DESC,SERVICE_P_DESC,DESC10,DESC11,DESC12,DESC13,SERVICE_TRAINING_PLAN"
            Me.SET_NULL_FIELD = "SHOW_RATE1,SHOW_RATE2,SHOW_RATE3,SHOW_RATE4,SHOW_RATE11,SHOW_RATE12,SHOW_RATE13,SHOW_RATE14,SHOW_RATE21,SHOW_RATE22,SHOW_RATE23,SHOW_RATE24,SHOW_RATE31,SHOW_RATE32,SHOW_RATE33,SHOW_RATE34,S_SHOW_RATE1,S_SHOW_RATE2,S_SHOW_RATE3,S_SHOW_RATE4,O_SHOW_RATE1,O_SHOW_RATE2,O_SHOW_RATE3,O_SHOW_RATE4,N_SHOW_RATE1,N_SHOW_RATE2,N_SHOW_RATE3,N_SHOW_RATE4,F_SHOW_RATE1,F_SHOW_RATE2,F_SHOW_RATE3,F_SHOW_RATE4,UNIVERSAL_RATE,PROTECTION_RATE,SECONDARY12_RATE,SECONDARY15_RATE,LIMITATION_RATE"
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

#Region "TRANS_TYPE 信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'"
        '' <summary>
        '' TRANS_TYPE 信號傳輸方式, REF. SYST010.SYS_KEY='TRANS_TYPE'
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

#Region "TRANS_DESC 信號傳輸方式說明"
        '' <summary>
        '' TRANS_DESC 信號傳輸方式說明
        '' </summary>
        Public Property TRANS_DESC() As String
            Get
                Return Me.ColumnyMap("TRANS_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TRANS_DESC") = value
            End Set
        End Property
#End Region

#Region "TRANS_BACKUP 備援傳輸方式"
        '' <summary>
        '' TRANS_BACKUP 備援傳輸方式
        '' </summary>
        Public Property TRANS_BACKUP() As String
            Get
                Return Me.ColumnyMap("TRANS_BACKUP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TRANS_BACKUP") = value
            End Set
        End Property
#End Region

#Region "DESC01 爭議處理機制"
        '' <summary>
        '' DESC01 爭議處理機制
        '' </summary>
        Public Property DESC01() As String
            Get
                Return Me.ColumnyMap("DESC01")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC01") = value
            End Set
        End Property
#End Region

#Region "DESC02 頻道推廣計畫"
        '' <summary>
        '' DESC02 頻道推廣計畫
        '' </summary>
        Public Property DESC02() As String
            Get
                Return Me.ColumnyMap("DESC02")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC02") = value
            End Set
        End Property
#End Region

#Region "DESC03 資訊公開措施規畫"
        '' <summary>
        '' DESC03 資訊公開措施規畫
        '' </summary>
        Public Property DESC03() As String
            Get
                Return Me.ColumnyMap("DESC03")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC03") = value
            End Set
        End Property
#End Region

#Region "DESC04 頻道經營理念/定位"
        '' <summary>
        '' DESC04 頻道經營理念/定位
        '' </summary>
        Public Property DESC04() As String
            Get
                Return Me.ColumnyMap("DESC04")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC04") = value
            End Set
        End Property
#End Region

#Region "DESC05 市場調查資料"
        '' <summary>
        '' DESC05 市場調查資料
        '' </summary>
        Public Property DESC05() As String
            Get
                Return Me.ColumnyMap("DESC05")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC05") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_ATTRIBUTES 頻道屬性"
        '' <summary>
        '' CHANNEL_ATTRIBUTES 頻道屬性
        '' </summary>
        Public Property CHANNEL_ATTRIBUTES() As String
            Get
                Return Me.ColumnyMap("CHANNEL_ATTRIBUTES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_ATTRIBUTES") = value
            End Set
        End Property
#End Region

#Region "FIR_SHOW_TYPE 主要節目類型"
        '' <summary>
        '' FIR_SHOW_TYPE 主要節目類型
        '' </summary>
        Public Property FIR_SHOW_TYPE() As String
            Get
                Return Me.ColumnyMap("FIR_SHOW_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FIR_SHOW_TYPE") = value
            End Set
        End Property
#End Region

#Region "SEC_SHOW_TYPE 次要節目類型"
        '' <summary>
        '' SEC_SHOW_TYPE 次要節目類型
        '' </summary>
        Public Property SEC_SHOW_TYPE() As String
            Get
                Return Me.ColumnyMap("SEC_SHOW_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEC_SHOW_TYPE") = value
            End Set
        End Property
#End Region

#Region "COUNTRY1 外國-國家1"
        '' <summary>
        '' COUNTRY1 外國-國家1
        '' </summary>
        Public Property COUNTRY1() As String
            Get
                Return Me.ColumnyMap("COUNTRY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY1") = value
            End Set
        End Property
#End Region

#Region "COUNTRY2 外國-國家2"
        '' <summary>
        '' COUNTRY2 外國-國家2
        '' </summary>
        Public Property COUNTRY2() As String
            Get
                Return Me.ColumnyMap("COUNTRY2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY2") = value
            End Set
        End Property
#End Region

#Region "COUNTRY3 外國-國家3"
        '' <summary>
        '' COUNTRY3 外國-國家3
        '' </summary>
        Public Property COUNTRY3() As String
            Get
                Return Me.ColumnyMap("COUNTRY3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COUNTRY3") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE1 第1年/上半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE1 第1年/上半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE1() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE2 第1年/下半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE2 第1年/下半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE2() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE3 第2年/上半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE3 第2年/上半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE3() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE4 第2年/下半年/本國, 不可大於100"
        '' <summary>
        '' SHOW_RATE4 第2年/下半年/本國, 不可大於100
        '' </summary>
        Public Property SHOW_RATE4() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE11 第1年/上半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE11 第1年/上半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE11() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE11")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE11") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE12 第1年/下半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE12 第1年/下半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE12() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE12")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE12") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE13 第2年/上半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE13 第2年/上半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE13() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE13")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE13") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE14 第2年/下半年/外國1, 不可大於100"
        '' <summary>
        '' SHOW_RATE14 第2年/下半年/外國1, 不可大於100
        '' </summary>
        Public Property SHOW_RATE14() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE14")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE14") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE21 第1年/上半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE21 第1年/上半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE21() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE21")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE21") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE22 第1年/下半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE22 第1年/下半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE22() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE22")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE22") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE23 第2年/上半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE23 第2年/上半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE23() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE23")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE23") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE24 第2年/下半年/外國2, 不可大於100"
        '' <summary>
        '' SHOW_RATE24 第2年/下半年/外國2, 不可大於100
        '' </summary>
        Public Property SHOW_RATE24() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE24")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE24") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE31 第1年/上半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE31 第1年/上半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE31() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE31")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE31") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE32 第1年/下半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE32 第1年/下半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE32() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE32")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE32") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE33 第2年/上半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE33 第2年/上半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE33() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE33")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE33") = value
            End Set
        End Property
#End Region

#Region "SHOW_RATE34 第2年/下半年/外國3, 不可大於100"
        '' <summary>
        '' SHOW_RATE34 第2年/下半年/外國3, 不可大於100
        '' </summary>
        Public Property SHOW_RATE34() As String
            Get
                Return Me.ColumnyMap("SHOW_RATE34")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_RATE34") = value
            End Set
        End Property
#End Region

#Region "LAW_3_8_FLAG 本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LAW_3_8_FLAG 本法第八條第三項規定, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property LAW_3_8_FLAG() As String
            Get
                Return Me.ColumnyMap("LAW_3_8_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LAW_3_8_FLAG") = value
            End Set
        End Property
#End Region

#Region "LAW_DESC 不符合原因"
        '' <summary>
        '' LAW_DESC 不符合原因
        '' </summary>
        Public Property LAW_DESC() As String
            Get
                Return Me.ColumnyMap("LAW_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LAW_DESC") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE1 第1年/上半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE1 第1年/上半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE1() As String
            Get
                Return Me.ColumnyMap("S_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("S_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE2 第1年/下半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE2 第1年/下半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE2() As String
            Get
                Return Me.ColumnyMap("S_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("S_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE3 第2年/上半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE3 第2年/上半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE3() As String
            Get
                Return Me.ColumnyMap("S_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("S_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "S_SHOW_RATE4 第2年/下半年-頻道自製, 不可大於100"
        '' <summary>
        '' S_SHOW_RATE4 第2年/下半年-頻道自製, 不可大於100
        '' </summary>
        Public Property S_SHOW_RATE4() As String
            Get
                Return Me.ColumnyMap("S_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("S_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE1 第1年/上半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE1 第1年/上半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE1() As String
            Get
                Return Me.ColumnyMap("O_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE2 第1年/下半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE2 第1年/下半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE2() As String
            Get
                Return Me.ColumnyMap("O_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE3 第2年/上半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE3 第2年/上半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE3() As String
            Get
                Return Me.ColumnyMap("O_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "O_SHOW_RATE4 第2年/下半年-外購節目, 不可大於100"
        '' <summary>
        '' O_SHOW_RATE4 第2年/下半年-外購節目, 不可大於100
        '' </summary>
        Public Property O_SHOW_RATE4() As String
            Get
                Return Me.ColumnyMap("O_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("O_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE1 第1年/上半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE1 第1年/上半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE1() As String
            Get
                Return Me.ColumnyMap("N_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("N_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE2 第1年/下半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE2 第1年/下半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE2() As String
            Get
                Return Me.ColumnyMap("N_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("N_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE3 第2年/上半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE3 第2年/上半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE3() As String
            Get
                Return Me.ColumnyMap("N_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("N_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "N_SHOW_RATE4 第2年/下半年-新播, 不可大於100"
        '' <summary>
        '' N_SHOW_RATE4 第2年/下半年-新播, 不可大於100
        '' </summary>
        Public Property N_SHOW_RATE4() As String
            Get
                Return Me.ColumnyMap("N_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("N_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE1 第1年/上半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE1 第1年/上半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE1() As String
            Get
                Return Me.ColumnyMap("F_SHOW_RATE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("F_SHOW_RATE1") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE2 第1年/下半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE2 第1年/下半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE2() As String
            Get
                Return Me.ColumnyMap("F_SHOW_RATE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("F_SHOW_RATE2") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE3 第2年/上半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE3 第2年/上半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE3() As String
            Get
                Return Me.ColumnyMap("F_SHOW_RATE3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("F_SHOW_RATE3") = value
            End Set
        End Property
#End Region

#Region "F_SHOW_RATE4 第2年/下半年-首播, 不可大於100"
        '' <summary>
        '' F_SHOW_RATE4 第2年/下半年-首播, 不可大於100
        '' </summary>
        Public Property F_SHOW_RATE4() As String
            Get
                Return Me.ColumnyMap("F_SHOW_RATE4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("F_SHOW_RATE4") = value
            End Set
        End Property
#End Region

#Region "DESC06 傳播本國文化及本國自製節目之實施方案"
        '' <summary>
        '' DESC06 傳播本國文化及本國自製節目之實施方案
        '' </summary>
        Public Property DESC06() As String
            Get
                Return Me.ColumnyMap("DESC06")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC06") = value
            End Set
        End Property
#End Region

#Region "DESC07 節目製作自律規範"
        '' <summary>
        '' DESC07 節目製作自律規範
        '' </summary>
        Public Property DESC07() As String
            Get
                Return Me.ColumnyMap("DESC07")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC07") = value
            End Set
        End Property
#End Region

#Region "UNIVERSAL_RATE 普遍級-播出比例, 不可大於100"
        '' <summary>
        '' UNIVERSAL_RATE 普遍級-播出比例, 不可大於100
        '' </summary>
        Public Property UNIVERSAL_RATE() As String
            Get
                Return Me.ColumnyMap("UNIVERSAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNIVERSAL_RATE") = value
            End Set
        End Property
#End Region

#Region "PROTECTION_RATE 保護級-播出比例, 不可大於100"
        '' <summary>
        '' PROTECTION_RATE 保護級-播出比例, 不可大於100
        '' </summary>
        Public Property PROTECTION_RATE() As String
            Get
                Return Me.ColumnyMap("PROTECTION_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROTECTION_RATE") = value
            End Set
        End Property
#End Region

#Region "SECONDARY12_RATE 輔12級-播出比例, 不可大於100"
        '' <summary>
        '' SECONDARY12_RATE 輔12級-播出比例, 不可大於100
        '' </summary>
        Public Property SECONDARY12_RATE() As String
            Get
                Return Me.ColumnyMap("SECONDARY12_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SECONDARY12_RATE") = value
            End Set
        End Property
#End Region

#Region "SECONDARY15_RATE 輔15級-播出比例, 不可大於100"
        '' <summary>
        '' SECONDARY15_RATE 輔15級-播出比例, 不可大於100
        '' </summary>
        Public Property SECONDARY15_RATE() As String
            Get
                Return Me.ColumnyMap("SECONDARY15_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SECONDARY15_RATE") = value
            End Set
        End Property
#End Region

#Region "LIMITATION_RATE 限制級-播出比例, 不可大於100"
        '' <summary>
        '' LIMITATION_RATE 限制級-播出比例, 不可大於100
        '' </summary>
        Public Property LIMITATION_RATE() As String
            Get
                Return Me.ColumnyMap("LIMITATION_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LIMITATION_RATE") = value
            End Set
        End Property
#End Region

#Region "MAKESHOE_FLAG 製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' MAKESHOE_FLAG 製播新聞或財經新聞, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property MAKESHOE_FLAG() As String
            Get
                Return Me.ColumnyMap("MAKESHOE_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAKESHOE_FLAG") = value
            End Set
        End Property
#End Region

#Region "MUTICHANNEL_FLAG 同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' MUTICHANNEL_FLAG 同時經營多家頻道, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property MUTICHANNEL_FLAG() As String
            Get
                Return Me.ColumnyMap("MUTICHANNEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MUTICHANNEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SELFORG_FLAG 是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SELFORG_FLAG 是否有設置內部自律組織, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SELFORG_FLAG() As String
            Get
                Return Me.ColumnyMap("SELFORG_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SELFORG_FLAG") = value
            End Set
        End Property
#End Region

#Region "ORG_NAME 組織名稱"
        '' <summary>
        '' ORG_NAME 組織名稱
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

#Region "MEETING_FREQ 開會頻率"
        '' <summary>
        '' MEETING_FREQ 開會頻率
        '' </summary>
        Public Property MEETING_FREQ() As String
            Get
                Return Me.ColumnyMap("MEETING_FREQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MEETING_FREQ") = value
            End Set
        End Property
#End Region

#Region "MEETING_PEOPLE 人數"
        '' <summary>
        '' MEETING_PEOPLE 人數
        '' </summary>
        Public Property MEETING_PEOPLE() As String
            Get
                Return Me.ColumnyMap("MEETING_PEOPLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MEETING_PEOPLE") = value
            End Set
        End Property
#End Region

#Region "DESC08 自律組織替代機制"
        '' <summary>
        '' DESC08 自律組織替代機制
        '' </summary>
        Public Property DESC08() As String
            Get
                Return Me.ColumnyMap("DESC08")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC08") = value
            End Set
        End Property
#End Region

#Region "SHOW1_FLAG 新聞/財經新聞"
        '' <summary>
        '' SHOW1_FLAG 新聞/財經新聞
        '' </summary>
        Public Property SHOW1_FLAG() As String
            Get
                Return Me.ColumnyMap("SHOW1_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW1_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW1_PAGE 新聞/財經新聞-頁次"
        '' <summary>
        '' SHOW1_PAGE 新聞/財經新聞-頁次
        '' </summary>
        Public Property SHOW1_PAGE() As String
            Get
                Return Me.ColumnyMap("SHOW1_PAGE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW1_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW2_FLAG 財經股市節目"
        '' <summary>
        '' SHOW2_FLAG 財經股市節目
        '' </summary>
        Public Property SHOW2_FLAG() As String
            Get
                Return Me.ColumnyMap("SHOW2_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW2_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW2_PAGE 財經股市節目-頁次"
        '' <summary>
        '' SHOW2_PAGE 財經股市節目-頁次
        '' </summary>
        Public Property SHOW2_PAGE() As String
            Get
                Return Me.ColumnyMap("SHOW2_PAGE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW2_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW3_FLAG 兒少節目"
        '' <summary>
        '' SHOW3_FLAG 兒少節目
        '' </summary>
        Public Property SHOW3_FLAG() As String
            Get
                Return Me.ColumnyMap("SHOW3_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW3_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW3_PAGE 兒少節目-頁次"
        '' <summary>
        '' SHOW3_PAGE 兒少節目-頁次
        '' </summary>
        Public Property SHOW3_PAGE() As String
            Get
                Return Me.ColumnyMap("SHOW3_PAGE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW3_PAGE") = value
            End Set
        End Property
#End Region

#Region "SHOW_FLAG 限制級節目"
        '' <summary>
        '' SHOW_FLAG 限制級節目
        '' </summary>
        Public Property SHOW_FLAG() As String
            Get
                Return Me.ColumnyMap("SHOW_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW_FLAG") = value
            End Set
        End Property
#End Region

#Region "SHOW4_PAGE 限制級節目-頁次"
        '' <summary>
        '' SHOW4_PAGE 限制級節目-頁次
        '' </summary>
        Public Property SHOW4_PAGE() As String
            Get
                Return Me.ColumnyMap("SHOW4_PAGE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOW4_PAGE") = value
            End Set
        End Property
#End Region

#Region "DESC09 獎勵或違規紀錄"
        '' <summary>
        '' DESC09 獎勵或違規紀錄
        '' </summary>
        Public Property DESC09() As String
            Get
                Return Me.ColumnyMap("DESC09")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC09") = value
            End Set
        End Property
#End Region

#Region "CHARGE1_FLAG 收費基準-有線電視（類比）"
        '' <summary>
        '' CHARGE1_FLAG 收費基準-有線電視（類比）
        '' </summary>
        Public Property CHARGE1_FLAG() As String
            Get
                Return Me.ColumnyMap("CHARGE1_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE1_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE2_FLAG 收費基準-有線電視（數位）"
        '' <summary>
        '' CHARGE2_FLAG 收費基準-有線電視（數位）
        '' </summary>
        Public Property CHARGE2_FLAG() As String
            Get
                Return Me.ColumnyMap("CHARGE2_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE2_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE2_AMT 收費基準-有線電視（數位）-金額"
        '' <summary>
        '' CHARGE2_AMT 收費基準-有線電視（數位）-金額
        '' </summary>
        Public Property CHARGE2_AMT() As String
            Get
                Return Me.ColumnyMap("CHARGE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CHARGE3_FLAG 收費基準-其他"
        '' <summary>
        '' CHARGE3_FLAG 收費基準-其他
        '' </summary>
        Public Property CHARGE3_FLAG() As String
            Get
                Return Me.ColumnyMap("CHARGE3_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE3_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE3_AMT 收費基準-其他-金額"
        '' <summary>
        '' CHARGE3_AMT 收費基準-其他-金額
        '' </summary>
        Public Property CHARGE3_AMT() As String
            Get
                Return Me.ColumnyMap("CHARGE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE3_AMT") = value
            End Set
        End Property
#End Region

#Region "CHARGE4_FLAG 收費基準-直播衛星事業"
        '' <summary>
        '' CHARGE4_FLAG 收費基準-直播衛星事業
        '' </summary>
        Public Property CHARGE4_FLAG() As String
            Get
                Return Me.ColumnyMap("CHARGE4_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE4_FLAG") = value
            End Set
        End Property
#End Region

#Region "CHARGE4_AMT 收費基準-直播衛星事業-金額"
        '' <summary>
        '' CHARGE4_AMT 收費基準-直播衛星事業-金額
        '' </summary>
        Public Property CHARGE4_AMT() As String
            Get
                Return Me.ColumnyMap("CHARGE4_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE4_AMT") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_NUMBER 客服-專職人數"
        '' <summary>
        '' SERVICE_F_NUMBER 客服-專職人數
        '' </summary>
        Public Property SERVICE_F_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_FLAG 客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SERVICE_F_FLAG 客服-專職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SERVICE_F_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_F_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_F_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_DESC 客服-專職-共用說明"
        '' <summary>
        '' SERVICE_F_DESC 客服-專職-共用說明
        '' </summary>
        Public Property SERVICE_F_DESC() As String
            Get
                Return Me.ColumnyMap("SERVICE_F_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_F_DESC") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_NUMBER 客服-兼職人數"
        '' <summary>
        '' SERVICE_P_NUMBER 客服-兼職人數
        '' </summary>
        Public Property SERVICE_P_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_FLAG 客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' SERVICE_P_FLAG 客服-兼職-是否與其他事業共用, REF. SYST010.SYS_KEY='RESULT1'
        '' </summary>
        Public Property SERVICE_P_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_P_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_P_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_DESC 客服-兼職-共用說明"
        '' <summary>
        '' SERVICE_P_DESC 客服-兼職-共用說明
        '' </summary>
        Public Property SERVICE_P_DESC() As String
            Get
                Return Me.ColumnyMap("SERVICE_P_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_P_DESC") = value
            End Set
        End Property
#End Region

#Region "SERVICE_F_SHARE_NUMBER 客服-共用專職人數"
        '' <summary>
        '' SERVICE_F_SHARE_NUMBER 客服-共用專職人數
        '' </summary>
        Public Property SERVICE_F_SHARE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_F_SHARE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_F_SHARE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_P_SHARE_NUMBER 客服-共用兼職人數"
        '' <summary>
        '' SERVICE_P_SHARE_NUMBER 客服-共用兼職人數
        '' </summary>
        Public Property SERVICE_P_SHARE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_P_SHARE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_P_SHARE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DESC10 國際新聞製播規畫"
        '' <summary>
        '' DESC10 國際新聞製播規畫
        '' </summary>
        Public Property DESC10() As String
            Get
                Return Me.ColumnyMap("DESC10")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC10") = value
            End Set
        End Property
#End Region

#Region "DESC11 兒少節目製播規畫"
        '' <summary>
        '' DESC11 兒少節目製播規畫
        '' </summary>
        Public Property DESC11() As String
            Get
                Return Me.ColumnyMap("DESC11")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC11") = value
            End Set
        End Property
#End Region

#Region "DESC12 身心障礙者進用服務規畫"
        '' <summary>
        '' DESC12 身心障礙者進用服務規畫
        '' </summary>
        Public Property DESC12() As String
            Get
                Return Me.ColumnyMap("DESC12")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC12") = value
            End Set
        End Property
#End Region

#Region "DESC13 創新服務規畫"
        '' <summary>
        '' DESC13 創新服務規畫
        '' </summary>
        Public Property DESC13() As String
            Get
                Return Me.ColumnyMap("DESC13")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DESC13") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TRAINING_PLAN 客服人力教育訓練規畫"
        '' <summary>
        '' SERVICE_TRAINING_PLAN 客服人力教育訓練規畫
        '' </summary>
        Public Property SERVICE_TRAINING_PLAN() As String
            Get
                Return Me.ColumnyMap("SERVICE_TRAINING_PLAN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TRAINING_PLAN") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "

        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function


        'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()
        '
        '        '=== 檢核欄位起始 ===
        '        Dim faileArguments As ArrayList = New ArrayList()
        '
        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== 檢核欄位結束 ===
        '
        '        '=== 處理別名 ===
        '        Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
        '        Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
        '        Me.ParserAlias()
        '
        '        Dim sql As New StringBuilder
        '        sql.AppendLine(" SELECT M.*, R1.COLUMN2 ")
        '        sql.AppendLine(" FROM SCST020 M ")
        '        sql.AppendLine(" LEFT JOIN SCST040 R1 ON M.TUTOR_CLASSNO = R1.TUTOR_CLASSNO ")
        '
        '        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
        '            sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
        '        End If
        '
        '        If Me.OrderBys <> "" Then
        '            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
        '        Else
        '            If pageNo = 0 Then
        '                sql.AppendLine(" ORDER BY M.STNO ")
        '            Else
        '                sql.AppendLine(" ORDER BY STNO ")
        '            End If
        '        End If
        '
        '        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)
        '
        '        Me.ResetColumnProperty()
        '
        '        Return dt
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function
#End Region

#Region "DoWordQuery 查詢 "

        Public Function DoWordQuery() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1041", "M", ""})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "R1", "APP_PERSON_NM", "SYS_CNAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.APP_PERSON_NM ,R1.SYS_CNAME ")
                sql.AppendLine(" FROM APP1041 M ")
                sql.AppendLine(" LEFT JOIN APP1010 R1 ON M.CASE_NO = R1.CASE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.PKNO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, 0, 0)

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

