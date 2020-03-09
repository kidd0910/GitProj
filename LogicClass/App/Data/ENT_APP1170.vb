'----------------------------------------------------------------------------------
'File Name		: APP1170
'Author			:  
'Description		: APP1170 頻道基本資料
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/14	 		Source Create
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
    ' APP1170 頻道基本資料
    ' </summary>
    Public Class ENT_APP1170
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
            Me.TableName = "APP1170"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,CHANNEL_NAME,COUNTRY,COM_NAME,CHANNEL_PAY_DESC,CH_FLAG13_DESC,SALES_AGENT,SERVICE_OTHER,DATA_DESC"
            Me.SET_NULL_FIELD = "ANALOGY_SALES_RATE,DIGIT_SALES_RATE,EVALUATION_S_DATE,EVALUATION_E_DATE,LICENSE_S_DATE,LICENSE_E_DATE,PLAY_S_DATE"
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

#Region "ORG_TYPE1 事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'"
        '' <summary>
        '' ORG_TYPE1 事業類別, REF. SYST010.SYS_KEY='ORG_TYPE1'
        '' </summary>
        Public Property ORG_TYPE1() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE1") = value
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

#Region "ORG_TYPE2 分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'"
        '' <summary>
        '' ORG_TYPE2 分公司或代理商, REF.SYST010.SYS_KEY='ORG_TYPE2'
        '' </summary>
        Public Property ORG_TYPE2() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE2") = value
            End Set
        End Property
#End Region

#Region "COM_NAME 所屬公司"
        '' <summary>
        '' COM_NAME 所屬公司
        '' </summary>
        Public Property COM_NAME() As String
            Get
                Return Me.ColumnyMap("COM_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_NAME") = value
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

#Region "LICENSE_S_DATE 執照(許可)效期(起)"
        '' <summary>
        '' LICENSE_S_DATE 執照(許可)效期(起)
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

#Region "LICENSE_E_DATE 執照(許可)效期(迄)"
        '' <summary>
        '' LICENSE_E_DATE 執照(許可)效期(迄)
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

#Region "CHANNEL_PAY_TYPE 基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'"
        '' <summary>
        '' CHANNEL_PAY_TYPE 基本/付費, REF. SYST010.SYS_KEY='CHANNEL_PAY_TYPE'
        '' </summary>
        Public Property CHANNEL_PAY_TYPE() As String
            Get
                Return Me.ColumnyMap("CHANNEL_PAY_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_PAY_TYPE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_PAY_DESC 說明"
        '' <summary>
        '' CHANNEL_PAY_DESC 說明
        '' </summary>
        Public Property CHANNEL_PAY_DESC() As String
            Get
                Return Me.ColumnyMap("CHANNEL_PAY_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_PAY_DESC") = value
            End Set
        End Property
#End Region

#Region "LOCK_CHANNEL_FLAG 限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'"
        '' <summary>
        '' LOCK_CHANNEL_FLAG 限制級鎖碼, REF. SYST010.SYS_KEY='RESULT1'

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

#Region "CH_FLAG1 頻道屬性-新聞, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG1 頻道屬性-新聞, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG1() As String
            Get
                Return Me.ColumnyMap("CH_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG1") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG2 頻道屬性-財經新聞, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG2 頻道屬性-財經新聞, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG2() As String
            Get
                Return Me.ColumnyMap("CH_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG2") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG3 頻道屬性-財經股市, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG3 頻道屬性-財經股市, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG3() As String
            Get
                Return Me.ColumnyMap("CH_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG3") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG4 頻道屬性-兒少, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG4 頻道屬性-兒少, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG4() As String
            Get
                Return Me.ColumnyMap("CH_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG4") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG5 頻道屬性-戲劇, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG5 頻道屬性-戲劇, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG5() As String
            Get
                Return Me.ColumnyMap("CH_FLAG5")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG5") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG6 頻道屬性-電影, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG6 頻道屬性-電影, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG6() As String
            Get
                Return Me.ColumnyMap("CH_FLAG6")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG6") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG7 頻道屬性-體育, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG7 頻道屬性-體育, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG7() As String
            Get
                Return Me.ColumnyMap("CH_FLAG7")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG7") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG8 頻道屬性-教育文化, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG8 頻道屬性-教育文化, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG8() As String
            Get
                Return Me.ColumnyMap("CH_FLAG8")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG8") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG9 頻道屬性-音樂, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG9 頻道屬性-音樂, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG9() As String
            Get
                Return Me.ColumnyMap("CH_FLAG9")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG9") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG10 頻道屬性-宗教, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG10 頻道屬性-宗教, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG10() As String
            Get
                Return Me.ColumnyMap("CH_FLAG10")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG10") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG11 頻道屬性-綜合, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG11 頻道屬性-綜合, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG11() As String
            Get
                Return Me.ColumnyMap("CH_FLAG11")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG11") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG12 頻道屬性-地方頻道, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG12 頻道屬性-地方頻道, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG12() As String
            Get
                Return Me.ColumnyMap("CH_FLAG12")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG12") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13 頻道屬性-其他類型, 勾選為'Y'"
        '' <summary>
        '' CH_FLAG13 頻道屬性-其他類型, 勾選為'Y'
        '' </summary>
        Public Property CH_FLAG13() As String
            Get
                Return Me.ColumnyMap("CH_FLAG13")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG13") = value
            End Set
        End Property
#End Region

#Region "CH_FLAG13_DESC 頻道屬性-其他類型-說明"
        '' <summary>
        '' CH_FLAG13_DESC 頻道屬性-其他類型-說明
        '' </summary>
        Public Property CH_FLAG13_DESC() As String
            Get
                Return Me.ColumnyMap("CH_FLAG13_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_FLAG13_DESC") = value
            End Set
        End Property
#End Region

#Region "CHARGE_STANDARD_AMT 收費標準"
        '' <summary>
        '' CHARGE_STANDARD_AMT 收費標準
        '' </summary>
        Public Property CHARGE_STANDARD_AMT() As String
            Get
                Return Me.ColumnyMap("CHARGE_STANDARD_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE_STANDARD_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE1_AMT 前二年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE1_AMT 前二年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE1_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE1_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE1_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE2_AMT 前一年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE2_AMT 前一年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE2_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE2_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE2_AMT") = value
            End Set
        End Property
#End Region

#Region "CH_AUTHORIZE3_AMT 本年度頻道授權費"
        '' <summary>
        '' CH_AUTHORIZE3_AMT 本年度頻道授權費
        '' </summary>
        Public Property CH_AUTHORIZE3_AMT() As String
            Get
                Return Me.ColumnyMap("CH_AUTHORIZE3_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_AUTHORIZE3_AMT") = value
            End Set
        End Property
#End Region

#Region "SALES_AGENT 本年度銷售代理商"
        '' <summary>
        '' SALES_AGENT 本年度銷售代理商
        '' </summary>
        Public Property SALES_AGENT() As String
            Get
                Return Me.ColumnyMap("SALES_AGENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_AGENT") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG1 上架方式-有線電視(類比), 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG1 上架方式-有線電視(類比), 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG1() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG1") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG2 上架方式-有線電視(數位), 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG2 上架方式-有線電視(數位), 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG2() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG2") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG3 上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG3 上架方式-其他供公眾收視聽之播送平臺, 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG3() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG3") = value
            End Set
        End Property
#End Region

#Region "SALES_FLAG4 上架方式-直播衛星, 勾選為'Y'"
        '' <summary>
        '' SALES_FLAG4 上架方式-直播衛星, 勾選為'Y'
        '' </summary>
        Public Property SALES_FLAG4() As String
            Get
                Return Me.ColumnyMap("SALES_FLAG4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SALES_FLAG4") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SIGN_NUMBER 簽約家數-類比"
        '' <summary>
        '' ANALOGY_SIGN_NUMBER 簽約家數-類比
        '' </summary>
        Public Property ANALOGY_SIGN_NUMBER() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SIGN_NUMBER 簽約家數-數位"
        '' <summary>
        '' DIGIT_SIGN_NUMBER 簽約家數-數位
        '' </summary>
        Public Property DIGIT_SIGN_NUMBER() As String
            Get
                Return Me.ColumnyMap("DIGIT_SIGN_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SIGN_NUMBER") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SALES_RATE 上架率-類比"
        '' <summary>
        '' ANALOGY_SALES_RATE 上架率-類比
        '' </summary>
        Public Property ANALOGY_SALES_RATE() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SALES_RATE 上架率-數位"
        '' <summary>
        '' DIGIT_SALES_RATE 上架率-數位
        '' </summary>
        Public Property DIGIT_SALES_RATE() As String
            Get
                Return Me.ColumnyMap("DIGIT_SALES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SALES_RATE") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_F_NUMBER 頻道專屬人力"
        '' <summary>
        '' CHANNEL_F_NUMBER 頻道專屬人力
        '' </summary>
        Public Property CHANNEL_F_NUMBER() As String
            Get
                Return Me.ColumnyMap("CHANNEL_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_F_NUMBER 頻道編審人力-專職"
        '' <summary>
        '' EDIT_F_NUMBER 頻道編審人力-專職
        '' </summary>
        Public Property EDIT_F_NUMBER() As String
            Get
                Return Me.ColumnyMap("EDIT_F_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDIT_F_NUMBER") = value
            End Set
        End Property
#End Region

#Region "EDIT_P_NUMBER 頻道編審人力-兼職"
        '' <summary>
        '' EDIT_P_NUMBER 頻道編審人力-兼職
        '' </summary>
        Public Property EDIT_P_NUMBER() As String
            Get
                Return Me.ColumnyMap("EDIT_P_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDIT_P_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_AREA 客服電話-區碼"
        '' <summary>
        '' SERVICE_TEL_AREA 客服電話-區碼
        '' </summary>
        Public Property SERVICE_TEL_AREA() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL_AREA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL_AREA") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL 客服電話"
        '' <summary>
        '' SERVICE_TEL 客服電話
        '' </summary>
        Public Property SERVICE_TEL() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_EMAIL 電子郵件"
        '' <summary>
        '' SERVICE_EMAIL 電子郵件
        '' </summary>
        Public Property SERVICE_EMAIL() As String
            Get
                Return Me.ColumnyMap("SERVICE_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_EMAIL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER 其他"
        '' <summary>
        '' SERVICE_OTHER 其他
        '' </summary>
        Public Property SERVICE_OTHER() As String
            Get
                Return Me.ColumnyMap("SERVICE_OTHER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_OTHER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_CASE_NUMBER 受理件數-客服"
        '' <summary>
        '' SERVICE_CASE_NUMBER 受理件數-客服
        '' </summary>
        Public Property SERVICE_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("SERVICE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "COMPLAINT_CASE_NUMBER 受理件數-申訴"
        '' <summary>
        '' COMPLAINT_CASE_NUMBER 受理件數-申訴
        '' </summary>
        Public Property COMPLAINT_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("COMPLAINT_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COMPLAINT_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "HANDLE_CASE_NUMBER 核處件數"
        '' <summary>
        '' HANDLE_CASE_NUMBER 核處件數
        '' </summary>
        Public Property HANDLE_CASE_NUMBER() As String
            Get
                Return Me.ColumnyMap("HANDLE_CASE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("HANDLE_CASE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DATA_DESC 基本資料補充"
        '' <summary>
        '' DATA_DESC 基本資料補充
        '' </summary>
        Public Property DATA_DESC() As String
            Get
                Return Me.ColumnyMap("DATA_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_DESC") = value
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
        ''' 0.0.1   新增方法
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

