'ProductName                 : TSBA 
'File Name					 : CtAPP1421 
'Description	             : CtAPP1421 APP1421 節目報告書
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/18  NCC管理者      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1421
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1421 = New ENT_APP1421(Me.DBManager, Me.LogUtil)
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

#Region "YEAR 年度"
        '' <summary>
        '' YEAR 年度
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

#Region "DATA_TYPE 類型, 0:：目前，1：未來"
        '' <summary>
        '' DATA_TYPE 類型, 0:：目前，1：未來
        '' </summary>
        Public Property DATA_TYPE() As String
            Get
                Return Me.PropertyMap("DATA_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DATA_TYPE") = value
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

#Region "INTERNAL_HOURS 自製-時數"
        '' <summary>
        '' INTERNAL_HOURS 自製-時數
        '' </summary>
        Public Property INTERNAL_HOURS() As String
            Get
                Return Me.PropertyMap("INTERNAL_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_HOURS") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_RATE 自製-比例"
        '' <summary>
        '' INTERNAL_RATE 自製-比例
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

#Region "INTERNAL_AMT 自製節目-經費"
        '' <summary>
        '' INTERNAL_AMT 自製節目-經費
        '' </summary>
        Public Property INTERNAL_AMT() As String
            Get
                Return Me.PropertyMap("INTERNAL_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_AMT") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_AMT_RATE 自製節目-經費比例"
        '' <summary>
        '' INTERNAL_AMT_RATE 自製節目-經費比例
        '' </summary>
        Public Property INTERNAL_AMT_RATE() As String
            Get
                Return Me.PropertyMap("INTERNAL_AMT_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTERNAL_AMT_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_HOURS 外製/外購-時數"
        '' <summary>
        '' EXTERNAL_HOURS 外製/外購-時數
        '' </summary>
        Public Property EXTERNAL_HOURS() As String
            Get
                Return Me.PropertyMap("EXTERNAL_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_HOURS") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_RATE 外製/外購-比例"
        '' <summary>
        '' EXTERNAL_RATE 外製/外購-比例
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

#Region "EXTERNAL_AMT 外購節目-經費"
        '' <summary>
        '' EXTERNAL_AMT 外購節目-經費
        '' </summary>
        Public Property EXTERNAL_AMT() As String
            Get
                Return Me.PropertyMap("EXTERNAL_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_AMT") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_AMT_RATE 外購節目-經費比例"
        '' <summary>
        '' EXTERNAL_AMT_RATE 外購節目-經費比例
        '' </summary>
        Public Property EXTERNAL_AMT_RATE() As String
            Get
                Return Me.PropertyMap("EXTERNAL_AMT_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXTERNAL_AMT_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_HOURS 聯播-時數"
        '' <summary>
        '' JOIN_HOURS 聯播-時數
        '' </summary>
        Public Property JOIN_HOURS() As String
            Get
                Return Me.PropertyMap("JOIN_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOIN_HOURS") = value
            End Set
        End Property
#End Region

#Region "JOIN_RATE 聯播-比例"
        '' <summary>
        '' JOIN_RATE 聯播-比例
        '' </summary>
        Public Property JOIN_RATE() As String
            Get
                Return Me.PropertyMap("JOIN_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOIN_RATE") = value
            End Set
        End Property
#End Region

#Region "NEW_HOURS 新播-時數"
        '' <summary>
        '' NEW_HOURS 新播-時數
        '' </summary>
        Public Property NEW_HOURS() As String
            Get
                Return Me.PropertyMap("NEW_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NEW_HOURS") = value
            End Set
        End Property
#End Region

#Region "NEW_RATE "
        '' <summary>
        '' NEW_RATE 
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

#Region "FIRST_HOURS 首播-時數"
        '' <summary>
        '' FIRST_HOURS 首播-時數
        '' </summary>
        Public Property FIRST_HOURS() As String
            Get
                Return Me.PropertyMap("FIRST_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FIRST_HOURS") = value
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

#Region "REPLAY_HOURS 重播-時數"
        '' <summary>
        '' REPLAY_HOURS 重播-時數
        '' </summary>
        Public Property REPLAY_HOURS() As String
            Get
                Return Me.PropertyMap("REPLAY_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REPLAY_HOURS") = value
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

#Region "ITEM01_HOURS 國語發音-時數"
        '' <summary>
        '' ITEM01_HOURS 國語發音-時數
        '' </summary>
        Public Property ITEM01_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM01_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM01_HOURS") = value
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

#Region "ITEM02_HOURS 台語發音-時數"
        '' <summary>
        '' ITEM02_HOURS 台語發音-時數
        '' </summary>
        Public Property ITEM02_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM02_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM02_HOURS") = value
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

#Region "ITEM03_HOURS 客語發音-時數"
        '' <summary>
        '' ITEM03_HOURS 客語發音-時數
        '' </summary>
        Public Property ITEM03_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM03_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM03_HOURS") = value
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

#Region "ITEM04_HOURS 原住民語發音-時數"
        '' <summary>
        '' ITEM04_HOURS 原住民語發音-時數
        '' </summary>
        Public Property ITEM04_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM04_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM04_HOURS") = value
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

#Region "ITEM05_HOURS 英語發音-時數"
        '' <summary>
        '' ITEM05_HOURS 英語發音-時數
        '' </summary>
        Public Property ITEM05_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM05_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM05_HOURS") = value
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

#Region "ITEM06_HOURS 其他外國語言發音-時數"
        '' <summary>
        '' ITEM06_HOURS 其他外國語言發音-時數
        '' </summary>
        Public Property ITEM06_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM06_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM06_HOURS") = value
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

#Region "ROC_HOURS 本國-時數"
        '' <summary>
        '' ROC_HOURS 本國-時數
        '' </summary>
        Public Property ROC_HOURS() As String
            Get
                Return Me.PropertyMap("ROC_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ROC_HOURS") = value
            End Set
        End Property
#End Region

#Region "ROC_RATE 本國-比例"
        '' <summary>
        '' ROC_RATE 本國-比例
        '' </summary>
        Public Property ROC_RATE() As String
            Get
                Return Me.PropertyMap("ROC_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ROC_RATE") = value
            End Set
        End Property
#End Region

#Region "HK_HOURS 港澳-時數"
        '' <summary>
        '' HK_HOURS 港澳-時數
        '' </summary>
        Public Property HK_HOURS() As String
            Get
                Return Me.PropertyMap("HK_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HK_HOURS") = value
            End Set
        End Property
#End Region

#Region "HK_RATE 港澳-比例"
        '' <summary>
        '' HK_RATE 港澳-比例
        '' </summary>
        Public Property HK_RATE() As String
            Get
                Return Me.PropertyMap("HK_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HK_RATE") = value
            End Set
        End Property
#End Region

#Region "PRC_HOURS 中國大陸-時數"
        '' <summary>
        '' PRC_HOURS 中國大陸-時數
        '' </summary>
        Public Property PRC_HOURS() As String
            Get
                Return Me.PropertyMap("PRC_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRC_HOURS") = value
            End Set
        End Property
#End Region

#Region "PRC_RATE 中國大陸-時數"
        '' <summary>
        '' PRC_RATE 中國大陸-時數
        '' </summary>
        Public Property PRC_RATE() As String
            Get
                Return Me.PropertyMap("PRC_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PRC_RATE") = value
            End Set
        End Property
#End Region

#Region "JPN_HOURS 日本-時數"
        '' <summary>
        '' JPN_HOURS 日本-時數
        '' </summary>
        Public Property JPN_HOURS() As String
            Get
                Return Me.PropertyMap("JPN_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JPN_HOURS") = value
            End Set
        End Property
#End Region

#Region "JPN_RATE 日本-比例"
        '' <summary>
        '' JPN_RATE 日本-比例
        '' </summary>
        Public Property JPN_RATE() As String
            Get
                Return Me.PropertyMap("JPN_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JPN_RATE") = value
            End Set
        End Property
#End Region

#Region "KOR_HOURS 韓國-時數"
        '' <summary>
        '' KOR_HOURS 韓國-時數
        '' </summary>
        Public Property KOR_HOURS() As String
            Get
                Return Me.PropertyMap("KOR_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("KOR_HOURS") = value
            End Set
        End Property
#End Region

#Region "KOR_RATE 韓國-比例"
        '' <summary>
        '' KOR_RATE 韓國-比例
        '' </summary>
        Public Property KOR_RATE() As String
            Get
                Return Me.PropertyMap("KOR_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("KOR_RATE") = value
            End Set
        End Property
#End Region

#Region "USA_HOURS 美國-時數"
        '' <summary>
        '' USA_HOURS 美國-時數
        '' </summary>
        Public Property USA_HOURS() As String
            Get
                Return Me.PropertyMap("USA_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USA_HOURS") = value
            End Set
        End Property
#End Region

#Region "USA_RATE 美國-比例"
        '' <summary>
        '' USA_RATE 美國-比例
        '' </summary>
        Public Property USA_RATE() As String
            Get
                Return Me.PropertyMap("USA_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USA_RATE") = value
            End Set
        End Property
#End Region

#Region "OTH_HOURS 其他國家或地區-時數"
        '' <summary>
        '' OTH_HOURS 其他國家或地區-時數
        '' </summary>
        Public Property OTH_HOURS() As String
            Get
                Return Me.PropertyMap("OTH_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTH_HOURS") = value
            End Set
        End Property
#End Region

#Region "OTH_RATE 其他國家或地區-比例"
        '' <summary>
        '' OTH_RATE 其他國家或地區-比例
        '' </summary>
        Public Property OTH_RATE() As String
            Get
                Return Me.PropertyMap("OTH_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OTH_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM07_HOURS 新聞政令宣導/新聞-時數"
        '' <summary>
        '' ITEM07_HOURS 新聞政令宣導/新聞-時數
        '' </summary>
        Public Property ITEM07_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM07_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM07_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM07_RATE 新聞政令宣導/新聞-比例"
        '' <summary>
        '' ITEM07_RATE 新聞政令宣導/新聞-比例
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

#Region "ITEM08_HOURS 教育文化-時數"
        '' <summary>
        '' ITEM08_HOURS 教育文化-時數
        '' </summary>
        Public Property ITEM08_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM08_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM08_HOURS") = value
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

#Region "ITEM09_HOURS 公共服務-時數"
        '' <summary>
        '' ITEM09_HOURS 公共服務-時數
        '' </summary>
        Public Property ITEM09_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM09_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM09_HOURS") = value
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

#Region "ITEM10_HOURS 大眾娛樂/娛樂-時數"
        '' <summary>
        '' ITEM10_HOURS 大眾娛樂/娛樂-時數
        '' </summary>
        Public Property ITEM10_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM10_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM10_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM10_RATE 大眾娛樂/娛樂-比例"
        '' <summary>
        '' ITEM10_RATE 大眾娛樂/娛樂-比例
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

#Region "ITEM11_HOURS 兒童-時數"
        '' <summary>
        '' ITEM11_HOURS 兒童-時數
        '' </summary>
        Public Property ITEM11_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM11_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM11_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM11_RATE 兒童-比例"
        '' <summary>
        '' ITEM11_RATE 兒童-比例
        '' </summary>
        Public Property ITEM11_RATE() As String
            Get
                Return Me.PropertyMap("ITEM11_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM11_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM12_HOURS 戲劇-時數"
        '' <summary>
        '' ITEM12_HOURS 戲劇-時數
        '' </summary>
        Public Property ITEM12_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM12_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM12_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM12_RATE 戲劇-比例"
        '' <summary>
        '' ITEM12_RATE 戲劇-比例
        '' </summary>
        Public Property ITEM12_RATE() As String
            Get
                Return Me.PropertyMap("ITEM12_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM12_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM13_HOURS 生活資訊-時數"
        '' <summary>
        '' ITEM13_HOURS 生活資訊-時數
        '' </summary>
        Public Property ITEM13_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM13_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM13_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM13_RATE 生活資訊-比例"
        '' <summary>
        '' ITEM13_RATE 生活資訊-比例
        '' </summary>
        Public Property ITEM13_RATE() As String
            Get
                Return Me.PropertyMap("ITEM13_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM13_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM14_HOURS 財經股市-時數"
        '' <summary>
        '' ITEM14_HOURS 財經股市-時數
        '' </summary>
        Public Property ITEM14_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM14_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM14_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM14_RATE 財經股市-比例"
        '' <summary>
        '' ITEM14_RATE 財經股市-比例
        '' </summary>
        Public Property ITEM14_RATE() As String
            Get
                Return Me.PropertyMap("ITEM14_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM14_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM15_HOURS 體育-時數"
        '' <summary>
        '' ITEM15_HOURS 體育-時數
        '' </summary>
        Public Property ITEM15_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM15_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM15_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM15_RATE 體育-比例"
        '' <summary>
        '' ITEM15_RATE 體育-比例
        '' </summary>
        Public Property ITEM15_RATE() As String
            Get
                Return Me.PropertyMap("ITEM15_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM15_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM999_HOURS 其他-時數"
        '' <summary>
        '' ITEM999_HOURS 其他-時數
        '' </summary>
        Public Property ITEM999_HOURS() As String
            Get
                Return Me.PropertyMap("ITEM999_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM999_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM999_RATE 其他-比例"
        '' <summary>
        '' ITEM999_RATE 其他-比例
        '' </summary>
        Public Property ITEM999_RATE() As String
            Get
                Return Me.PropertyMap("ITEM999_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM999_RATE") = value
            End Set
        End Property
#End Region

#Region "HD_HOURS 高畫質-時數"
        '' <summary>
        '' HD_HOURS 高畫質-時數
        '' </summary>
        Public Property HD_HOURS() As String
            Get
                Return Me.PropertyMap("HD_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HD_HOURS") = value
            End Set
        End Property
#End Region

#Region "HD_RATE 高畫質-比例"
        '' <summary>
        '' HD_RATE 高畫質-比例
        '' </summary>
        Public Property HD_RATE() As String
            Get
                Return Me.PropertyMap("HD_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("HD_RATE") = value
            End Set
        End Property
#End Region

#Region "SD_HOURS 標準畫質-時數"
        '' <summary>
        '' SD_HOURS 標準畫質-時數
        '' </summary>
        Public Property SD_HOURS() As String
            Get
                Return Me.PropertyMap("SD_HOURS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SD_HOURS") = value
            End Set
        End Property
#End Region

#Region "SD_RATE 標準畫質-比例"
        '' <summary>
        '' SD_RATE 標準畫質-比例
        '' </summary>
        Public Property SD_RATE() As String
            Get
                Return Me.PropertyMap("SD_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SD_RATE") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1421"
        ' <summary>Ent_APP1421</ summary>
        Private Property Ent_APP1421() As ENT_APP1421
            Get
                Return Me.PropertyMap("Ent_APP1421")
            End Get
            Set(ByVal value As ENT_APP1421)
                Me.PropertyMap("Ent_APP1421") = value
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
                Me.Ent_APP1421.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1421.YEAR = Me.YEAR        '年度
                Me.Ent_APP1421.DATA_TYPE = Me.DATA_TYPE      '類型, 0:：目前，1：未來
                Me.Ent_APP1421.CHANNEL_NAME = Me.CHANNEL_NAME        '頻道名稱
                Me.Ent_APP1421.INTERNAL_HOURS = Me.INTERNAL_HOURS        '自製-時數
                Me.Ent_APP1421.INTERNAL_RATE = Me.INTERNAL_RATE      '自製-比例
                Me.Ent_APP1421.INTERNAL_AMT = Me.INTERNAL_AMT        '自製節目-經費
                Me.Ent_APP1421.INTERNAL_AMT_RATE = Me.INTERNAL_AMT_RATE      '自製節目-經費比例
                Me.Ent_APP1421.EXTERNAL_HOURS = Me.EXTERNAL_HOURS        '外製/外購-時數
                Me.Ent_APP1421.EXTERNAL_RATE = Me.EXTERNAL_RATE      '外製/外購-比例
                Me.Ent_APP1421.EXTERNAL_AMT = Me.EXTERNAL_AMT        '外購節目-經費
                Me.Ent_APP1421.EXTERNAL_AMT_RATE = Me.EXTERNAL_AMT_RATE      '外購節目-經費比例
                Me.Ent_APP1421.JOIN_HOURS = Me.JOIN_HOURS        '聯播-時數
                Me.Ent_APP1421.JOIN_RATE = Me.JOIN_RATE      '聯播-比例
                Me.Ent_APP1421.NEW_HOURS = Me.NEW_HOURS      '新播-時數
                Me.Ent_APP1421.NEW_RATE = Me.NEW_RATE        '
                Me.Ent_APP1421.FIRST_HOURS = Me.FIRST_HOURS      '首播-時數
                Me.Ent_APP1421.FIRST_RATE = Me.FIRST_RATE        '首播-比例
                Me.Ent_APP1421.REPLAY_HOURS = Me.REPLAY_HOURS        '重播-時數
                Me.Ent_APP1421.REPLAY_RATE = Me.REPLAY_RATE      '重播-比例
                Me.Ent_APP1421.ITEM01_HOURS = Me.ITEM01_HOURS        '國語發音-時數
                Me.Ent_APP1421.ITEM01_RATE = Me.ITEM01_RATE      '國語發音-比例
                Me.Ent_APP1421.ITEM02_HOURS = Me.ITEM02_HOURS        '台語發音-時數
                Me.Ent_APP1421.ITEM02_RATE = Me.ITEM02_RATE      '台語發音-比例
                Me.Ent_APP1421.ITEM03_HOURS = Me.ITEM03_HOURS        '客語發音-時數
                Me.Ent_APP1421.ITEM03_RATE = Me.ITEM03_RATE      '客語發音-比例
                Me.Ent_APP1421.ITEM04_HOURS = Me.ITEM04_HOURS        '原住民語發音-時數
                Me.Ent_APP1421.ITEM04_RATE = Me.ITEM04_RATE      '原住民語發音-比例
                Me.Ent_APP1421.ITEM05_HOURS = Me.ITEM05_HOURS        '英語發音-時數
                Me.Ent_APP1421.ITEM05_RATE = Me.ITEM05_RATE      '英語發音-比例
                Me.Ent_APP1421.ITEM06_HOURS = Me.ITEM06_HOURS        '其他外國語言發音-時數
                Me.Ent_APP1421.ITEM06_RATE = Me.ITEM06_RATE      '其他外國語言發音-比例
                Me.Ent_APP1421.ROC_HOURS = Me.ROC_HOURS      '本國-時數
                Me.Ent_APP1421.ROC_RATE = Me.ROC_RATE        '本國-比例
                Me.Ent_APP1421.HK_HOURS = Me.HK_HOURS        '港澳-時數
                Me.Ent_APP1421.HK_RATE = Me.HK_RATE      '港澳-比例
                Me.Ent_APP1421.PRC_HOURS = Me.PRC_HOURS      '中國大陸-時數
                Me.Ent_APP1421.PRC_RATE = Me.PRC_RATE        '中國大陸-時數
                Me.Ent_APP1421.JPN_HOURS = Me.JPN_HOURS      '日本-時數
                Me.Ent_APP1421.JPN_RATE = Me.JPN_RATE        '日本-比例
                Me.Ent_APP1421.KOR_HOURS = Me.KOR_HOURS      '韓國-時數
                Me.Ent_APP1421.KOR_RATE = Me.KOR_RATE        '韓國-比例
                Me.Ent_APP1421.USA_HOURS = Me.USA_HOURS      '美國-時數
                Me.Ent_APP1421.USA_RATE = Me.USA_RATE        '美國-比例
                Me.Ent_APP1421.OTH_HOURS = Me.OTH_HOURS      '其他國家或地區-時數
                Me.Ent_APP1421.OTH_RATE = Me.OTH_RATE        '其他國家或地區-比例
                Me.Ent_APP1421.ITEM07_HOURS = Me.ITEM07_HOURS        '新聞政令宣導/新聞-時數
                Me.Ent_APP1421.ITEM07_RATE = Me.ITEM07_RATE      '新聞政令宣導/新聞-比例
                Me.Ent_APP1421.ITEM08_HOURS = Me.ITEM08_HOURS        '教育文化-時數
                Me.Ent_APP1421.ITEM08_RATE = Me.ITEM08_RATE      '教育文化-比例
                Me.Ent_APP1421.ITEM09_HOURS = Me.ITEM09_HOURS        '公共服務-時數
                Me.Ent_APP1421.ITEM09_RATE = Me.ITEM09_RATE      '公共服務-比例
                Me.Ent_APP1421.ITEM10_HOURS = Me.ITEM10_HOURS        '大眾娛樂/娛樂-時數
                Me.Ent_APP1421.ITEM10_RATE = Me.ITEM10_RATE      '大眾娛樂/娛樂-比例
                Me.Ent_APP1421.ITEM11_HOURS = Me.ITEM11_HOURS        '兒童-時數
                Me.Ent_APP1421.ITEM11_RATE = Me.ITEM11_RATE      '兒童-比例
                Me.Ent_APP1421.ITEM12_HOURS = Me.ITEM12_HOURS        '戲劇-時數
                Me.Ent_APP1421.ITEM12_RATE = Me.ITEM12_RATE      '戲劇-比例
                Me.Ent_APP1421.ITEM13_HOURS = Me.ITEM13_HOURS        '生活資訊-時數
                Me.Ent_APP1421.ITEM13_RATE = Me.ITEM13_RATE      '生活資訊-比例
                Me.Ent_APP1421.ITEM14_HOURS = Me.ITEM14_HOURS        '財經股市-時數
                Me.Ent_APP1421.ITEM14_RATE = Me.ITEM14_RATE      '財經股市-比例
                Me.Ent_APP1421.ITEM15_HOURS = Me.ITEM15_HOURS        '體育-時數
                Me.Ent_APP1421.ITEM15_RATE = Me.ITEM15_RATE      '體育-比例
                Me.Ent_APP1421.ITEM999_HOURS = Me.ITEM999_HOURS      '其他-時數
                Me.Ent_APP1421.ITEM999_RATE = Me.ITEM999_RATE        '其他-比例
                Me.Ent_APP1421.HD_HOURS = Me.HD_HOURS        '高畫質-時數
                Me.Ent_APP1421.HD_RATE = Me.HD_RATE      '高畫質-比例
                Me.Ent_APP1421.SD_HOURS = Me.SD_HOURS        '標準畫質-時數
                Me.Ent_APP1421.SD_RATE = Me.SD_RATE      '標準畫質-比例


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1421.Insert()

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
                Me.Ent_APP1421.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1421.YEAR = Me.YEAR        '年度
                Me.Ent_APP1421.DATA_TYPE = Me.DATA_TYPE      '類型, 0:：目前，1：未來
                Me.Ent_APP1421.CHANNEL_NAME = Me.CHANNEL_NAME        '頻道名稱
                Me.Ent_APP1421.INTERNAL_HOURS = Me.INTERNAL_HOURS        '自製-時數
                Me.Ent_APP1421.INTERNAL_RATE = Me.INTERNAL_RATE      '自製-比例
                Me.Ent_APP1421.INTERNAL_AMT = Me.INTERNAL_AMT        '自製節目-經費
                Me.Ent_APP1421.INTERNAL_AMT_RATE = Me.INTERNAL_AMT_RATE      '自製節目-經費比例
                Me.Ent_APP1421.EXTERNAL_HOURS = Me.EXTERNAL_HOURS        '外製/外購-時數
                Me.Ent_APP1421.EXTERNAL_RATE = Me.EXTERNAL_RATE      '外製/外購-比例
                Me.Ent_APP1421.EXTERNAL_AMT = Me.EXTERNAL_AMT        '外購節目-經費
                Me.Ent_APP1421.EXTERNAL_AMT_RATE = Me.EXTERNAL_AMT_RATE      '外購節目-經費比例
                Me.Ent_APP1421.JOIN_HOURS = Me.JOIN_HOURS        '聯播-時數
                Me.Ent_APP1421.JOIN_RATE = Me.JOIN_RATE      '聯播-比例
                Me.Ent_APP1421.NEW_HOURS = Me.NEW_HOURS      '新播-時數
                Me.Ent_APP1421.NEW_RATE = Me.NEW_RATE        '
                Me.Ent_APP1421.FIRST_HOURS = Me.FIRST_HOURS      '首播-時數
                Me.Ent_APP1421.FIRST_RATE = Me.FIRST_RATE        '首播-比例
                Me.Ent_APP1421.REPLAY_HOURS = Me.REPLAY_HOURS        '重播-時數
                Me.Ent_APP1421.REPLAY_RATE = Me.REPLAY_RATE      '重播-比例
                Me.Ent_APP1421.ITEM01_HOURS = Me.ITEM01_HOURS        '國語發音-時數
                Me.Ent_APP1421.ITEM01_RATE = Me.ITEM01_RATE      '國語發音-比例
                Me.Ent_APP1421.ITEM02_HOURS = Me.ITEM02_HOURS        '台語發音-時數
                Me.Ent_APP1421.ITEM02_RATE = Me.ITEM02_RATE      '台語發音-比例
                Me.Ent_APP1421.ITEM03_HOURS = Me.ITEM03_HOURS        '客語發音-時數
                Me.Ent_APP1421.ITEM03_RATE = Me.ITEM03_RATE      '客語發音-比例
                Me.Ent_APP1421.ITEM04_HOURS = Me.ITEM04_HOURS        '原住民語發音-時數
                Me.Ent_APP1421.ITEM04_RATE = Me.ITEM04_RATE      '原住民語發音-比例
                Me.Ent_APP1421.ITEM05_HOURS = Me.ITEM05_HOURS        '英語發音-時數
                Me.Ent_APP1421.ITEM05_RATE = Me.ITEM05_RATE      '英語發音-比例
                Me.Ent_APP1421.ITEM06_HOURS = Me.ITEM06_HOURS        '其他外國語言發音-時數
                Me.Ent_APP1421.ITEM06_RATE = Me.ITEM06_RATE      '其他外國語言發音-比例
                Me.Ent_APP1421.ROC_HOURS = Me.ROC_HOURS      '本國-時數
                Me.Ent_APP1421.ROC_RATE = Me.ROC_RATE        '本國-比例
                Me.Ent_APP1421.HK_HOURS = Me.HK_HOURS        '港澳-時數
                Me.Ent_APP1421.HK_RATE = Me.HK_RATE      '港澳-比例
                Me.Ent_APP1421.PRC_HOURS = Me.PRC_HOURS      '中國大陸-時數
                Me.Ent_APP1421.PRC_RATE = Me.PRC_RATE        '中國大陸-時數
                Me.Ent_APP1421.JPN_HOURS = Me.JPN_HOURS      '日本-時數
                Me.Ent_APP1421.JPN_RATE = Me.JPN_RATE        '日本-比例
                Me.Ent_APP1421.KOR_HOURS = Me.KOR_HOURS      '韓國-時數
                Me.Ent_APP1421.KOR_RATE = Me.KOR_RATE        '韓國-比例
                Me.Ent_APP1421.USA_HOURS = Me.USA_HOURS      '美國-時數
                Me.Ent_APP1421.USA_RATE = Me.USA_RATE        '美國-比例
                Me.Ent_APP1421.OTH_HOURS = Me.OTH_HOURS      '其他國家或地區-時數
                Me.Ent_APP1421.OTH_RATE = Me.OTH_RATE        '其他國家或地區-比例
                Me.Ent_APP1421.ITEM07_HOURS = Me.ITEM07_HOURS        '新聞政令宣導/新聞-時數
                Me.Ent_APP1421.ITEM07_RATE = Me.ITEM07_RATE      '新聞政令宣導/新聞-比例
                Me.Ent_APP1421.ITEM08_HOURS = Me.ITEM08_HOURS        '教育文化-時數
                Me.Ent_APP1421.ITEM08_RATE = Me.ITEM08_RATE      '教育文化-比例
                Me.Ent_APP1421.ITEM09_HOURS = Me.ITEM09_HOURS        '公共服務-時數
                Me.Ent_APP1421.ITEM09_RATE = Me.ITEM09_RATE      '公共服務-比例
                Me.Ent_APP1421.ITEM10_HOURS = Me.ITEM10_HOURS        '大眾娛樂/娛樂-時數
                Me.Ent_APP1421.ITEM10_RATE = Me.ITEM10_RATE      '大眾娛樂/娛樂-比例
                Me.Ent_APP1421.ITEM11_HOURS = Me.ITEM11_HOURS        '兒童-時數
                Me.Ent_APP1421.ITEM11_RATE = Me.ITEM11_RATE      '兒童-比例
                Me.Ent_APP1421.ITEM12_HOURS = Me.ITEM12_HOURS        '戲劇-時數
                Me.Ent_APP1421.ITEM12_RATE = Me.ITEM12_RATE      '戲劇-比例
                Me.Ent_APP1421.ITEM13_HOURS = Me.ITEM13_HOURS        '生活資訊-時數
                Me.Ent_APP1421.ITEM13_RATE = Me.ITEM13_RATE      '生活資訊-比例
                Me.Ent_APP1421.ITEM14_HOURS = Me.ITEM14_HOURS        '財經股市-時數
                Me.Ent_APP1421.ITEM14_RATE = Me.ITEM14_RATE      '財經股市-比例
                Me.Ent_APP1421.ITEM15_HOURS = Me.ITEM15_HOURS        '體育-時數
                Me.Ent_APP1421.ITEM15_RATE = Me.ITEM15_RATE      '體育-比例
                Me.Ent_APP1421.ITEM999_HOURS = Me.ITEM999_HOURS      '其他-時數
                Me.Ent_APP1421.ITEM999_RATE = Me.ITEM999_RATE        '其他-比例
                Me.Ent_APP1421.HD_HOURS = Me.HD_HOURS        '高畫質-時數
                Me.Ent_APP1421.HD_RATE = Me.HD_RATE      '高畫質-比例
                Me.Ent_APP1421.SD_HOURS = Me.SD_HOURS        '標準畫質-時數
                Me.Ent_APP1421.SD_RATE = Me.SD_RATE      '標準畫質-比例


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1421.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1421.Update()

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
                Me.Ent_APP1421.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1421.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1421.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub

        Public Sub DoDeleteByCaseNo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.CASE_NO) Then

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
                Me.Ent_APP1421.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1421.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1421.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "YEAR", Me.YEAR)        '年度
                Me.ProcessQueryCondition(condition, "=", "DATA_TYPE", Me.DATA_TYPE)      '類型, 0:：目前，1：未來
                Me.ProcessQueryCondition(condition, "%LIKE%", "CHANNEL_NAME", Me.CHANNEL_NAME)       '頻道名稱
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_HOURS", Me.INTERNAL_HOURS)        '自製-時數
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_RATE", Me.INTERNAL_RATE)      '自製-比例
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_AMT", Me.INTERNAL_AMT)        '自製節目-經費
                Me.ProcessQueryCondition(condition, "=", "INTERNAL_AMT_RATE", Me.INTERNAL_AMT_RATE)      '自製節目-經費比例
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_HOURS", Me.EXTERNAL_HOURS)        '外製/外購-時數
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_RATE", Me.EXTERNAL_RATE)      '外製/外購-比例
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_AMT", Me.EXTERNAL_AMT)        '外購節目-經費
                Me.ProcessQueryCondition(condition, "=", "EXTERNAL_AMT_RATE", Me.EXTERNAL_AMT_RATE)      '外購節目-經費比例
                Me.ProcessQueryCondition(condition, "=", "JOIN_HOURS", Me.JOIN_HOURS)        '聯播-時數
                Me.ProcessQueryCondition(condition, "=", "JOIN_RATE", Me.JOIN_RATE)      '聯播-比例
                Me.ProcessQueryCondition(condition, "=", "NEW_HOURS", Me.NEW_HOURS)      '新播-時數
                Me.ProcessQueryCondition(condition, "=", "NEW_RATE", Me.NEW_RATE)        '
                Me.ProcessQueryCondition(condition, "=", "FIRST_HOURS", Me.FIRST_HOURS)      '首播-時數
                Me.ProcessQueryCondition(condition, "=", "FIRST_RATE", Me.FIRST_RATE)        '首播-比例
                Me.ProcessQueryCondition(condition, "=", "REPLAY_HOURS", Me.REPLAY_HOURS)        '重播-時數
                Me.ProcessQueryCondition(condition, "=", "REPLAY_RATE", Me.REPLAY_RATE)      '重播-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM01_HOURS", Me.ITEM01_HOURS)        '國語發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM01_RATE", Me.ITEM01_RATE)      '國語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM02_HOURS", Me.ITEM02_HOURS)        '台語發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM02_RATE", Me.ITEM02_RATE)      '台語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM03_HOURS", Me.ITEM03_HOURS)        '客語發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM03_RATE", Me.ITEM03_RATE)      '客語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM04_HOURS", Me.ITEM04_HOURS)        '原住民語發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM04_RATE", Me.ITEM04_RATE)      '原住民語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM05_HOURS", Me.ITEM05_HOURS)        '英語發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM05_RATE", Me.ITEM05_RATE)      '英語發音-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM06_HOURS", Me.ITEM06_HOURS)        '其他外國語言發音-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM06_RATE", Me.ITEM06_RATE)      '其他外國語言發音-比例
                Me.ProcessQueryCondition(condition, "=", "ROC_HOURS", Me.ROC_HOURS)      '本國-時數
                Me.ProcessQueryCondition(condition, "=", "ROC_RATE", Me.ROC_RATE)        '本國-比例
                Me.ProcessQueryCondition(condition, "=", "HK_HOURS", Me.HK_HOURS)        '港澳-時數
                Me.ProcessQueryCondition(condition, "=", "HK_RATE", Me.HK_RATE)      '港澳-比例
                Me.ProcessQueryCondition(condition, "=", "PRC_HOURS", Me.PRC_HOURS)      '中國大陸-時數
                Me.ProcessQueryCondition(condition, "=", "PRC_RATE", Me.PRC_RATE)        '中國大陸-時數
                Me.ProcessQueryCondition(condition, "=", "JPN_HOURS", Me.JPN_HOURS)      '日本-時數
                Me.ProcessQueryCondition(condition, "=", "JPN_RATE", Me.JPN_RATE)        '日本-比例
                Me.ProcessQueryCondition(condition, "=", "KOR_HOURS", Me.KOR_HOURS)      '韓國-時數
                Me.ProcessQueryCondition(condition, "=", "KOR_RATE", Me.KOR_RATE)        '韓國-比例
                Me.ProcessQueryCondition(condition, "=", "USA_HOURS", Me.USA_HOURS)      '美國-時數
                Me.ProcessQueryCondition(condition, "=", "USA_RATE", Me.USA_RATE)        '美國-比例
                Me.ProcessQueryCondition(condition, "=", "OTH_HOURS", Me.OTH_HOURS)      '其他國家或地區-時數
                Me.ProcessQueryCondition(condition, "=", "OTH_RATE", Me.OTH_RATE)        '其他國家或地區-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM07_HOURS", Me.ITEM07_HOURS)        '新聞政令宣導/新聞-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM07_RATE", Me.ITEM07_RATE)      '新聞政令宣導/新聞-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM08_HOURS", Me.ITEM08_HOURS)        '教育文化-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM08_RATE", Me.ITEM08_RATE)      '教育文化-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM09_HOURS", Me.ITEM09_HOURS)        '公共服務-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM09_RATE", Me.ITEM09_RATE)      '公共服務-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM10_HOURS", Me.ITEM10_HOURS)        '大眾娛樂/娛樂-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM10_RATE", Me.ITEM10_RATE)      '大眾娛樂/娛樂-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM11_HOURS", Me.ITEM11_HOURS)        '兒童-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM11_RATE", Me.ITEM11_RATE)      '兒童-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM12_HOURS", Me.ITEM12_HOURS)        '戲劇-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM12_RATE", Me.ITEM12_RATE)      '戲劇-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM13_HOURS", Me.ITEM13_HOURS)        '生活資訊-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM13_RATE", Me.ITEM13_RATE)      '生活資訊-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM14_HOURS", Me.ITEM14_HOURS)        '財經股市-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM14_RATE", Me.ITEM14_RATE)      '財經股市-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM15_HOURS", Me.ITEM15_HOURS)        '體育-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM15_RATE", Me.ITEM15_RATE)      '體育-比例
                Me.ProcessQueryCondition(condition, "=", "ITEM999_HOURS", Me.ITEM999_HOURS)      '其他-時數
                Me.ProcessQueryCondition(condition, "=", "ITEM999_RATE", Me.ITEM999_RATE)        '其他-比例
                Me.ProcessQueryCondition(condition, "=", "HD_HOURS", Me.HD_HOURS)        '高畫質-時數
                Me.ProcessQueryCondition(condition, "=", "HD_RATE", Me.HD_RATE)      '高畫質-比例
                Me.ProcessQueryCondition(condition, "=", "SD_HOURS", Me.SD_HOURS)        '標準畫質-時數
                Me.ProcessQueryCondition(condition, "=", "SD_RATE", Me.SD_RATE)      '標準畫質-比例

                Me.Ent_APP1421.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1421.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1421.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1421.Query()
                Else
                    result = Me.Ent_APP1421.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1421.TotalRowCount
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

