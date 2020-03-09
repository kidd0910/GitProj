'----------------------------------------------------------------------------------
'File Name		: APP1421
'Author			: NCC管理者
'Description		: APP1421 APP1421 節目報告書
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/18	NCC管理者		Source Create
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
    ' APP1421 APP1421 節目報告書
    ' </summary>
    Public Class ENT_APP1421
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
            Me.TableName = "APP1421"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,CHANNEL_NAME"
            Me.SET_NULL_FIELD = "INTERNAL_HOURS,INTERNAL_RATE,INTERNAL_AMT,INTERNAL_AMT_RATE,EXTERNAL_HOURS,EXTERNAL_RATE,EXTERNAL_AMT,EXTERNAL_AMT_RATE,JOIN_HOURS,JOIN_RATE,NEW_HOURS,NEW_RATE,FIRST_HOURS,FIRST_RATE,REPLAY_HOURS,REPLAY_RATE,ITEM01_HOURS,ITEM01_RATE,ITEM02_HOURS,ITEM02_RATE,ITEM03_HOURS,ITEM03_RATE,ITEM04_HOURS,ITEM04_RATE,ITEM05_HOURS,ITEM05_RATE,ITEM06_HOURS,ITEM06_RATE,ROC_HOURS,ROC_RATE,HK_HOURS,HK_RATE,PRC_HOURS,PRC_RATE,JPN_HOURS,JPN_RATE,KOR_HOURS,KOR_RATE,USA_HOURS,USA_RATE,OTH_HOURS,OTH_RATE,ITEM07_HOURS,ITEM07_RATE,ITEM08_HOURS,ITEM08_RATE,ITEM09_HOURS,ITEM09_RATE,ITEM10_HOURS,ITEM10_RATE,ITEM11_HOURS,ITEM11_RATE,ITEM12_HOURS,ITEM12_RATE,ITEM13_HOURS,ITEM13_RATE,ITEM14_HOURS,ITEM14_RATE,ITEM15_HOURS,ITEM15_RATE,ITEM999_HOURS,ITEM999_RATE,HD_HOURS,HD_RATE,SD_HOURS,SD_RATE"
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

#Region "YEAR 年度"
        '' <summary>
        '' YEAR 年度
        '' </summary>
        Public Property YEAR() As String
            Get
                Return Me.ColumnyMap("YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("YEAR") = value
            End Set
        End Property
#End Region

#Region "DATA_TYPE 類型, 0:：目前，1：未來"
        '' <summary>
        '' DATA_TYPE 類型, 0:：目前，1：未來
        '' </summary>
        Public Property DATA_TYPE() As String
            Get
                Return Me.ColumnyMap("DATA_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_TYPE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_NAME 頻道名稱"
        '' <summary>
        '' CHANNEL_NAME 頻道名稱
        '' </summary>
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_HOURS 自製-時數"
        '' <summary>
        '' INTERNAL_HOURS 自製-時數
        '' </summary>
        Public Property INTERNAL_HOURS() As String
            Get
                Return Me.ColumnyMap("INTERNAL_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_HOURS") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_RATE 自製-比例"
        '' <summary>
        '' INTERNAL_RATE 自製-比例
        '' </summary>
        Public Property INTERNAL_RATE() As String
            Get
                Return Me.ColumnyMap("INTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_AMT 自製節目-經費"
        '' <summary>
        '' INTERNAL_AMT 自製節目-經費
        '' </summary>
        Public Property INTERNAL_AMT() As String
            Get
                Return Me.ColumnyMap("INTERNAL_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_AMT") = value
            End Set
        End Property
#End Region

#Region "INTERNAL_AMT_RATE 自製節目-經費比例"
        '' <summary>
        '' INTERNAL_AMT_RATE 自製節目-經費比例
        '' </summary>
        Public Property INTERNAL_AMT_RATE() As String
            Get
                Return Me.ColumnyMap("INTERNAL_AMT_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTERNAL_AMT_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_HOURS 外製/外購-時數"
        '' <summary>
        '' EXTERNAL_HOURS 外製/外購-時數
        '' </summary>
        Public Property EXTERNAL_HOURS() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_HOURS") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_RATE 外製/外購-比例"
        '' <summary>
        '' EXTERNAL_RATE 外製/外購-比例
        '' </summary>
        Public Property EXTERNAL_RATE() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_RATE") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_AMT 外購節目-經費"
        '' <summary>
        '' EXTERNAL_AMT 外購節目-經費
        '' </summary>
        Public Property EXTERNAL_AMT() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_AMT") = value
            End Set
        End Property
#End Region

#Region "EXTERNAL_AMT_RATE 外購節目-經費比例"
        '' <summary>
        '' EXTERNAL_AMT_RATE 外購節目-經費比例
        '' </summary>
        Public Property EXTERNAL_AMT_RATE() As String
            Get
                Return Me.ColumnyMap("EXTERNAL_AMT_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXTERNAL_AMT_RATE") = value
            End Set
        End Property
#End Region

#Region "JOIN_HOURS 聯播-時數"
        '' <summary>
        '' JOIN_HOURS 聯播-時數
        '' </summary>
        Public Property JOIN_HOURS() As String
            Get
                Return Me.ColumnyMap("JOIN_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOIN_HOURS") = value
            End Set
        End Property
#End Region

#Region "JOIN_RATE 聯播-比例"
        '' <summary>
        '' JOIN_RATE 聯播-比例
        '' </summary>
        Public Property JOIN_RATE() As String
            Get
                Return Me.ColumnyMap("JOIN_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOIN_RATE") = value
            End Set
        End Property
#End Region

#Region "NEW_HOURS 新播-時數"
        '' <summary>
        '' NEW_HOURS 新播-時數
        '' </summary>
        Public Property NEW_HOURS() As String
            Get
                Return Me.ColumnyMap("NEW_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NEW_HOURS") = value
            End Set
        End Property
#End Region

#Region "NEW_RATE NEW_RATE"
        '' <summary>
        '' NEW_RATE NEW_RATE
        '' </summary>
        Public Property NEW_RATE() As String
            Get
                Return Me.ColumnyMap("NEW_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NEW_RATE") = value
            End Set
        End Property
#End Region

#Region "FIRST_HOURS 首播-時數"
        '' <summary>
        '' FIRST_HOURS 首播-時數
        '' </summary>
        Public Property FIRST_HOURS() As String
            Get
                Return Me.ColumnyMap("FIRST_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FIRST_HOURS") = value
            End Set
        End Property
#End Region

#Region "FIRST_RATE 首播-比例"
        '' <summary>
        '' FIRST_RATE 首播-比例
        '' </summary>
        Public Property FIRST_RATE() As String
            Get
                Return Me.ColumnyMap("FIRST_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FIRST_RATE") = value
            End Set
        End Property
#End Region

#Region "REPLAY_HOURS 重播-時數"
        '' <summary>
        '' REPLAY_HOURS 重播-時數
        '' </summary>
        Public Property REPLAY_HOURS() As String
            Get
                Return Me.ColumnyMap("REPLAY_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPLAY_HOURS") = value
            End Set
        End Property
#End Region

#Region "REPLAY_RATE 重播-比例"
        '' <summary>
        '' REPLAY_RATE 重播-比例
        '' </summary>
        Public Property REPLAY_RATE() As String
            Get
                Return Me.ColumnyMap("REPLAY_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REPLAY_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM01_HOURS 國語發音-時數"
        '' <summary>
        '' ITEM01_HOURS 國語發音-時數
        '' </summary>
        Public Property ITEM01_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM01_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM01_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM01_RATE 國語發音-比例"
        '' <summary>
        '' ITEM01_RATE 國語發音-比例
        '' </summary>
        Public Property ITEM01_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM01_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM01_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM02_HOURS 台語發音-時數"
        '' <summary>
        '' ITEM02_HOURS 台語發音-時數
        '' </summary>
        Public Property ITEM02_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM02_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM02_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM02_RATE 台語發音-比例"
        '' <summary>
        '' ITEM02_RATE 台語發音-比例
        '' </summary>
        Public Property ITEM02_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM02_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM02_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM03_HOURS 客語發音-時數"
        '' <summary>
        '' ITEM03_HOURS 客語發音-時數
        '' </summary>
        Public Property ITEM03_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM03_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM03_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM03_RATE 客語發音-比例"
        '' <summary>
        '' ITEM03_RATE 客語發音-比例
        '' </summary>
        Public Property ITEM03_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM03_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM03_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM04_HOURS 原住民語發音-時數"
        '' <summary>
        '' ITEM04_HOURS 原住民語發音-時數
        '' </summary>
        Public Property ITEM04_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM04_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM04_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM04_RATE 原住民語發音-比例"
        '' <summary>
        '' ITEM04_RATE 原住民語發音-比例
        '' </summary>
        Public Property ITEM04_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM04_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM04_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM05_HOURS 英語發音-時數"
        '' <summary>
        '' ITEM05_HOURS 英語發音-時數
        '' </summary>
        Public Property ITEM05_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM05_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM05_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM05_RATE 英語發音-比例"
        '' <summary>
        '' ITEM05_RATE 英語發音-比例
        '' </summary>
        Public Property ITEM05_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM05_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM05_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM06_HOURS 其他外國語言發音-時數"
        '' <summary>
        '' ITEM06_HOURS 其他外國語言發音-時數
        '' </summary>
        Public Property ITEM06_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM06_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM06_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM06_RATE 其他外國語言發音-比例"
        '' <summary>
        '' ITEM06_RATE 其他外國語言發音-比例
        '' </summary>
        Public Property ITEM06_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM06_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM06_RATE") = value
            End Set
        End Property
#End Region

#Region "ROC_HOURS 本國-時數"
        '' <summary>
        '' ROC_HOURS 本國-時數
        '' </summary>
        Public Property ROC_HOURS() As String
            Get
                Return Me.ColumnyMap("ROC_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ROC_HOURS") = value
            End Set
        End Property
#End Region

#Region "ROC_RATE 本國-比例"
        '' <summary>
        '' ROC_RATE 本國-比例
        '' </summary>
        Public Property ROC_RATE() As String
            Get
                Return Me.ColumnyMap("ROC_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ROC_RATE") = value
            End Set
        End Property
#End Region

#Region "HK_HOURS 港澳-時數"
        '' <summary>
        '' HK_HOURS 港澳-時數
        '' </summary>
        Public Property HK_HOURS() As String
            Get
                Return Me.ColumnyMap("HK_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HK_HOURS") = value
            End Set
        End Property
#End Region

#Region "HK_RATE 港澳-比例"
        '' <summary>
        '' HK_RATE 港澳-比例
        '' </summary>
        Public Property HK_RATE() As String
            Get
                Return Me.ColumnyMap("HK_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HK_RATE") = value
            End Set
        End Property
#End Region

#Region "PRC_HOURS 中國大陸-時數"
        '' <summary>
        '' PRC_HOURS 中國大陸-時數
        '' </summary>
        Public Property PRC_HOURS() As String
            Get
                Return Me.ColumnyMap("PRC_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRC_HOURS") = value
            End Set
        End Property
#End Region

#Region "PRC_RATE 中國大陸-時數"
        '' <summary>
        '' PRC_RATE 中國大陸-時數
        '' </summary>
        Public Property PRC_RATE() As String
            Get
                Return Me.ColumnyMap("PRC_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PRC_RATE") = value
            End Set
        End Property
#End Region

#Region "JPN_HOURS 日本-時數"
        '' <summary>
        '' JPN_HOURS 日本-時數
        '' </summary>
        Public Property JPN_HOURS() As String
            Get
                Return Me.ColumnyMap("JPN_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JPN_HOURS") = value
            End Set
        End Property
#End Region

#Region "JPN_RATE 日本-比例"
        '' <summary>
        '' JPN_RATE 日本-比例
        '' </summary>
        Public Property JPN_RATE() As String
            Get
                Return Me.ColumnyMap("JPN_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JPN_RATE") = value
            End Set
        End Property
#End Region

#Region "KOR_HOURS 韓國-時數"
        '' <summary>
        '' KOR_HOURS 韓國-時數
        '' </summary>
        Public Property KOR_HOURS() As String
            Get
                Return Me.ColumnyMap("KOR_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("KOR_HOURS") = value
            End Set
        End Property
#End Region

#Region "KOR_RATE 韓國-比例"
        '' <summary>
        '' KOR_RATE 韓國-比例
        '' </summary>
        Public Property KOR_RATE() As String
            Get
                Return Me.ColumnyMap("KOR_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("KOR_RATE") = value
            End Set
        End Property
#End Region

#Region "USA_HOURS 美國-時數"
        '' <summary>
        '' USA_HOURS 美國-時數
        '' </summary>
        Public Property USA_HOURS() As String
            Get
                Return Me.ColumnyMap("USA_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USA_HOURS") = value
            End Set
        End Property
#End Region

#Region "USA_RATE 美國-比例"
        '' <summary>
        '' USA_RATE 美國-比例
        '' </summary>
        Public Property USA_RATE() As String
            Get
                Return Me.ColumnyMap("USA_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USA_RATE") = value
            End Set
        End Property
#End Region

#Region "OTH_HOURS 其他國家或地區-時數"
        '' <summary>
        '' OTH_HOURS 其他國家或地區-時數
        '' </summary>
        Public Property OTH_HOURS() As String
            Get
                Return Me.ColumnyMap("OTH_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTH_HOURS") = value
            End Set
        End Property
#End Region

#Region "OTH_RATE 其他國家或地區-比例"
        '' <summary>
        '' OTH_RATE 其他國家或地區-比例
        '' </summary>
        Public Property OTH_RATE() As String
            Get
                Return Me.ColumnyMap("OTH_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTH_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM07_HOURS 新聞政令宣導/新聞-時數"
        '' <summary>
        '' ITEM07_HOURS 新聞政令宣導/新聞-時數
        '' </summary>
        Public Property ITEM07_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM07_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM07_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM07_RATE 新聞政令宣導/新聞-比例"
        '' <summary>
        '' ITEM07_RATE 新聞政令宣導/新聞-比例
        '' </summary>
        Public Property ITEM07_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM07_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM07_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM08_HOURS 教育文化-時數"
        '' <summary>
        '' ITEM08_HOURS 教育文化-時數
        '' </summary>
        Public Property ITEM08_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM08_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM08_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM08_RATE 教育文化-比例"
        '' <summary>
        '' ITEM08_RATE 教育文化-比例
        '' </summary>
        Public Property ITEM08_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM08_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM08_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM09_HOURS 公共服務-時數"
        '' <summary>
        '' ITEM09_HOURS 公共服務-時數
        '' </summary>
        Public Property ITEM09_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM09_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM09_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM09_RATE 公共服務-比例"
        '' <summary>
        '' ITEM09_RATE 公共服務-比例
        '' </summary>
        Public Property ITEM09_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM09_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM09_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM10_HOURS 大眾娛樂/娛樂-時數"
        '' <summary>
        '' ITEM10_HOURS 大眾娛樂/娛樂-時數
        '' </summary>
        Public Property ITEM10_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM10_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM10_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM10_RATE 大眾娛樂/娛樂-比例"
        '' <summary>
        '' ITEM10_RATE 大眾娛樂/娛樂-比例
        '' </summary>
        Public Property ITEM10_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM10_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM10_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM11_HOURS 兒童-時數"
        '' <summary>
        '' ITEM11_HOURS 兒童-時數
        '' </summary>
        Public Property ITEM11_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM11_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM11_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM11_RATE 兒童-比例"
        '' <summary>
        '' ITEM11_RATE 兒童-比例
        '' </summary>
        Public Property ITEM11_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM11_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM11_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM12_HOURS 戲劇-時數"
        '' <summary>
        '' ITEM12_HOURS 戲劇-時數
        '' </summary>
        Public Property ITEM12_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM12_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM12_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM12_RATE 戲劇-比例"
        '' <summary>
        '' ITEM12_RATE 戲劇-比例
        '' </summary>
        Public Property ITEM12_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM12_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM12_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM13_HOURS 生活資訊-時數"
        '' <summary>
        '' ITEM13_HOURS 生活資訊-時數
        '' </summary>
        Public Property ITEM13_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM13_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM13_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM13_RATE 生活資訊-比例"
        '' <summary>
        '' ITEM13_RATE 生活資訊-比例
        '' </summary>
        Public Property ITEM13_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM13_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM13_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM14_HOURS 財經股市-時數"
        '' <summary>
        '' ITEM14_HOURS 財經股市-時數
        '' </summary>
        Public Property ITEM14_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM14_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM14_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM14_RATE 財經股市-比例"
        '' <summary>
        '' ITEM14_RATE 財經股市-比例
        '' </summary>
        Public Property ITEM14_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM14_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM14_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM15_HOURS 體育-時數"
        '' <summary>
        '' ITEM15_HOURS 體育-時數
        '' </summary>
        Public Property ITEM15_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM15_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM15_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM15_RATE 體育-比例"
        '' <summary>
        '' ITEM15_RATE 體育-比例
        '' </summary>
        Public Property ITEM15_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM15_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM15_RATE") = value
            End Set
        End Property
#End Region

#Region "ITEM999_HOURS 其他-時數"
        '' <summary>
        '' ITEM999_HOURS 其他-時數
        '' </summary>
        Public Property ITEM999_HOURS() As String
            Get
                Return Me.ColumnyMap("ITEM999_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM999_HOURS") = value
            End Set
        End Property
#End Region

#Region "ITEM999_RATE 其他-比例"
        '' <summary>
        '' ITEM999_RATE 其他-比例
        '' </summary>
        Public Property ITEM999_RATE() As String
            Get
                Return Me.ColumnyMap("ITEM999_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM999_RATE") = value
            End Set
        End Property
#End Region

#Region "HD_HOURS 高畫質-時數"
        '' <summary>
        '' HD_HOURS 高畫質-時數
        '' </summary>
        Public Property HD_HOURS() As String
            Get
                Return Me.ColumnyMap("HD_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HD_HOURS") = value
            End Set
        End Property
#End Region

#Region "HD_RATE 高畫質-比例"
        '' <summary>
        '' HD_RATE 高畫質-比例
        '' </summary>
        Public Property HD_RATE() As String
            Get
                Return Me.ColumnyMap("HD_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HD_RATE") = value
            End Set
        End Property
#End Region

#Region "SD_HOURS 標準畫質-時數"
        '' <summary>
        '' SD_HOURS 標準畫質-時數
        '' </summary>
        Public Property SD_HOURS() As String
            Get
                Return Me.ColumnyMap("SD_HOURS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SD_HOURS") = value
            End Set
        End Property
#End Region

#Region "SD_RATE 標準畫質-比例"
        '' <summary>
        '' SD_RATE 標準畫質-比例
        '' </summary>
        Public Property SD_RATE() As String
            Get
                Return Me.ColumnyMap("SD_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SD_RATE") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 NCC管理者 新增方法
        ''' </remarks>
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
#End Region



    End Class
End Namespace

