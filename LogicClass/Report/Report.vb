'Imports System.Data.Common
'Imports Acer.Apps
'Imports Acer.DB
'Imports Acer.DB.Query
'Imports Acer.Util
'Imports Acer.Log
'Imports System.Reflection.MethodBase
'Imports App.Business
'Imports Novacode
'Imports TemplateEngine.Docx
'Imports Acer.Form.FormUtil
'Imports Sys.Data
'Imports System.Linq
'Imports System.Xml.Linq
'Imports Comm.Common.Common
'Imports System.Data
'Imports Sys.Business
'Imports File.Data
'Imports System.Globalization
'Imports System.Text.RegularExpressions
'Imports App.Data

'Namespace Report
'    Public Class Report
'        Inherits Acer.Base.PageBase
'        'Inherits Acer.Base.ControlBase
'#Region "建構子"
'        Dim _dbManager As DBManager
'        Dim _logUtil As LogUtil
'        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
'            _dbManager = dbManager
'            _logUtil = logUtil
'        End Sub
'#End Region

'#Region "Report"
'        ''' <summary>
'        ''' 產報表
'        ''' </summary>
'        ''' <param name="pageId"></param>
'        ''' <param name="sort"></param>
'        ''' <param name="caseNo"></param>
'        ''' <param name="futureYear">未來幾年</param>
'        ''' <param name="orgType">機關類型</param>
'        ''' <param name="serial">序號，特定報表用</param>
'        ''' <returns></returns>
'        Public Function ReportGenerater(ByVal pageId As String,
'                                        ByVal sort As String,
'                                        ByVal caseNo As String,
'                                        Optional futureYear As String = "",
'                                        Optional orgType As String = "",
'                                        Optional serial As Integer = 0,
'                                        Optional groupCode As String = "") As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                If caseNo.Length <> 0 Then

'                    Dim categoryByCaseNo As String = caseNo.Substring(0, 4)

'                    Select Case categoryByCaseNo
'                        Case "AA01", "AA02", "AA03", "AA04", "AA05", "AC01", "AC02", "AC03"
'                            rptModel = RptA(pageId, sort, caseNo, futureYear, orgType, serial, groupCode)
'                        Case "BA01", "BA02", "BA03", "BA04", "BA05", "BA06", "BB01", "BC01", "BC02", "BC03"
'                            rptModel = RptB(pageId, sort, caseNo, futureYear, orgType, serial, groupCode)
'                        Case "CA01", "CA02", "CA03", "CA04", "CA05", "CA06", "CB01", "CC01", "CC02", "CC03"
'                            rptModel = RptC(pageId, sort, caseNo, futureYear, orgType, serial, groupCode)
'                        Case Else
'                            '...
'                    End Select
'                Else
'                    If pageId = PREMETTING_Model.Key.PreMeeting Then
'                        rptModel = PreMeeting(pageId, sort, caseNo, groupCode)
'                    End If
'                End If

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function RptA(ByVal pageId As String,
'                              ByVal sort As String,
'                              ByVal caseNo As String,
'                              Optional futureYear As String = "",
'                              Optional orgType As String = "",
'                              Optional serial As Integer = 0,
'                              Optional groupCode As String = "") As ReportModel
'            Try
'                Dim rptModel As New ReportModel
'                Select Case pageId
'                    Case "APP110101" '直播衛星事業申請書
'                        rptModel = APP110101(pageId, sort, caseNo)
'                    Case "APP110102" '營運計畫摘要表
'                        rptModel = APP110102(pageId, sort, caseNo)
'                    Case "APP110103" '預估財務狀況表'仍有頁面運算需處理
'                        rptModel = APP110103(pageId, sort, caseNo, futureYear)
'                    Case "APP110104" '預估綜合損益表
'                        rptModel = APP110104(pageId, sort, caseNo)
'                    Case "APP110105" '預期營業收入明細表 
'                        rptModel = APP110105(pageId, sort, caseNo)
'                    Case "APP110106" '預期營業支出明細表   
'                        rptModel = APP110106(pageId, sort, caseNo)
'                    Case "APP110107" '外國人持股比例計算表
'                        rptModel = APP110107(pageId, sort, caseNo)
'                    Case "APP110108" '董事名冊
'                        rptModel = APP110108(pageId, sort, caseNo)
'                    Case "APP110109" '監察人名冊
'                        rptModel = APP110109(pageId, sort, caseNo)
'                    Case "APP110110" '經理人名冊
'                        rptModel = APP110110(pageId, sort, caseNo)
'                    Case "APP110111" '股東名冊
'                        rptModel = APP110111(pageId, sort, caseNo)
'                    Case "APP110113" '認股人名冊
'                        rptModel = APP110113(pageId, sort, caseNo)
'                    Case "APP110201" '境外直播衛星事業申請書
'                        rptModel = APP110201(pageId, sort, caseNo)
'                    Case "APP110301" '節目供應事業一般頻道申請書
'                        rptModel = APP110301(pageId, sort, caseNo)
'                    Case "APP110302" '一般頻道 - 營運計畫摘要表
'                        rptModel = APP110302(pageId, sort, caseNo)
'                    Case "APP110401" '節目供應事業-購物頻道申請書
'                        rptModel = APP110401(pageId, sort, caseNo)
'                    Case "APP110402" '申設-節目供應事業-購物頻道 - 營運計畫摘要表
'                        rptModel = APP110402(pageId, sort, caseNo)
'                    Case "APP110801" '區域性廣播事業-申請書
'                        rptModel = APP110801(pageId, sort, caseNo)
'                    Case "APP110802" '區域性廣播事業-其他項目
'                        '同一檔案包含多頁面集合: APP110802, APP110803, APP110804, APP110805, APP110806, APP110807, APP110808, APP110809
'                        rptModel = APP110802(pageId, sort, caseNo)
'                    Case "APP110810" '區域性廣播事業-股東名冊 
'                        rptModel = APP110810(pageId, sort, caseNo)
'                    Case "APP110813" '區域性廣播事業-董監事名冊(既有事業)/擬任董監事名冊(籌設中廣播事業) 
'                        rptModel = APP110813(pageId, sort, caseNo)
'                    Case "APP110903"
'                        '同一檔案包含多頁面集合: APP110903, APP110904, APP110905, APP110906, APP110907, APP110808, APP110809, APP110810
'                        rptModel = APP110903(pageId, sort, caseNo)
'                    ''''Case "APP110115" '應載細項'暫時先不做
'                    ''''    rptModel = APP110115(pageId, caseNo)
'                    Case "APP210301" '形式審查意見
'                        rptModel = APP210301(pageId, sort, caseNo)
'                    Case "APP210303" '委員審查意見 
'                        rptModel = APP210303(pageId, sort, caseNo, serial)
'                    Case "PreMeeting" '會前會首頁表格
'                        rptModel = PreMeeting(pageId, sort, caseNo, groupCode)
'                End Select
'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function RptC(ByVal pageId As String,
'                              ByVal sort As String,
'                              ByVal caseNo As String,
'                              Optional futureYear As String = "",
'                              Optional orgType As String = "",
'                              Optional serial As Integer = 0,
'                              Optional groupCode As String = "") As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Select Case pageId
'                    Case "APP130101" '換照申請書 
'                        rptModel = APP130101(pageId, sort, caseNo)
'                    Case "APP130102" '未來6年事業營運計畫摘要表
'                        rptModel = APP130102(pageId, sort, caseNo)
'                    Case "APP130121" '評鑑應改善(或改正)事項之執行情形 
'                        rptModel = APP130121(pageId, sort, caseNo)
'                    Case "APP130122" '申設或前次換照及其他行政處分附款及承諾事項或行政指導之執行情形
'                        rptModel = APP130122(pageId, sort, caseNo)
'                    Case "APP130105" '營業收入明細表
'                        rptModel = APP130105(pageId, sort, caseNo)
'                    Case "APP130106" '營業支出明細表
'                        rptModel = APP130106(pageId, sort, caseNo)
'                    Case "APP110108" '董事名冊
'                        rptModel = APP110108(pageId, sort, caseNo)
'                    Case "APP110109" '監察人名冊
'                        rptModel = APP110109(pageId, sort, caseNo)
'                    Case "APP110110" '經理人名冊
'                        rptModel = APP110110(pageId, sort, caseNo)
'                    Case "APP110111" '股東名冊
'                        rptModel = APP110111(pageId, sort, caseNo)
'                    Case "APP110107" '外國人持股比例計算表
'                        rptModel = APP110107(pageId, sort, caseNo)
'                    Case "APP130201" '境外直播衛星事業換照申請書
'                        rptModel = APP130201(pageId, sort, caseNo)
'                    Case "APP130301" '節目供應事業-一般頻道換照申請書 
'                        rptModel = APP130301(pageId, sort, caseNo)
'                    Case "APP130302" '未來6年營運計畫摘要表 
'                        rptModel = APP130302(pageId, sort, caseNo)
'                    Case "APP130402" '未來6年營運計畫摘要表
'                        rptModel = APP130402(pageId, sort, caseNo)
'                    Case "APP130501" '境外節目供應事業-一般頻道換照申請書 
'                        rptModel = APP130501(pageId, sort, caseNo)
'                    Case "APP130701" '無線電視-換發執照申請書
'                        rptModel = APP130701(pageId, sort, caseNo)
'                    '重複'Case "APP120703" 'APP120703,120704
'                    '    rptModel = APP120703(pageId, sort, caseNo)
'                    '重複''Case "APP120707" '120707,120708,120709,120710
'                    '    rptModel = APP120703("APP120703", sort, caseNo)
'                    Case "APP130705" 'APP130705,APP130706,APP130733,APP130734,APP130735,APP130736,APP130737,APP130738,APP130739,APP130740,APP12xx
'                        rptModel = APP130705("APP130733", sort, caseNo)
'                    Case "APP130801" '區域性廣播事業-基本資料 
'                        rptModel = APP130801(pageId, sort, caseNo)
'                    Case "APP120803", "APP120903" '區域性廣播事業-all, 換照-小功率、社區性廣播事業-all, 換照-公營電臺、使用政府預算之財團法人-all 
'                        rptModel = CCReport(pageId, sort, caseNo)
'                    Case "APP120324" '節目供應事業-上架統計表
'                        rptModel = APP120324(pageId, sort, caseNo)
'                    Case "APP210301" '形式審查意見
'                        rptModel = APP210301(pageId, sort, caseNo)
'                    Case "APP210303" '委員審查意見 
'                        rptModel = APP210303(pageId, sort, caseNo, serial)
'                    Case "PreMeeting" '會前會首頁表格
'                        rptModel = PreMeeting(pageId, sort, caseNo, groupCode)
'                End Select

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function RptB(ByVal pageId As String,
'                              ByVal sort As String,
'                              ByVal caseNo As String,
'                              Optional futureYear As String = "",
'                              Optional orgType As String = "",
'                              Optional serial As Integer = 0,
'                              Optional groupCode As String = "") As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Select Case pageId
'                    Case "APP120101" '公司基本資料 
'                        rptModel = APP120101(pageId, sort, caseNo)
'                    Case "APP120121" '申設或換照承諾事項及應改善(或改正)事項之執行情形  
'                        rptModel = APP120121(pageId, sort, caseNo)
'                    Case "APP120122" '其他行政處分附款及承諾事項或行政指導之執行情形  
'                        rptModel = APP120122(pageId, sort, caseNo)
'                    Case "APP120105" '營業收入明細表 
'                        rptModel = APP120105(pageId, sort, caseNo)
'                    Case "APP120106" '營業支出明細表 
'                        rptModel = APP120106(pageId, sort, caseNo)
'                    Case "APP120701" '無線電視-基本資料
'                        rptModel = APP120701(pageId, sort, caseNo)
'                    Case "APP120703" '無線電視-all
'                        rptModel = APP120703(pageId, sort, caseNo)
'                    Case "APP120801" '評鑑-廣播事業-人事結構及行政組織
'                        rptModel = APP120801(pageId, sort, caseNo)
'                    Case "APP120903" '評鑑-廣播事業-all-BC01
'                        rptModel = BCReport(pageId, sort, caseNo)
'                    Case "APP120301" '評鑑-節目供應事業-一般頻道-公司基本資料
'                        rptModel = APP120301(pageId, sort, caseNo)
'                    Case "APP120323" '評鑑-節目供應事業-頻道基本資料 
'                        rptModel = APP120323(pageId, sort, caseNo)
'                    Case "APP120324" '評鑑-節目供應事業-上架統計表
'                        rptModel = APP120324(pageId, sort, caseNo)
'                    Case "APP120423" '評鑑-節目供應事業及境外節目供應事業_購物頻道_頻道基本資料 
'                        rptModel = APP120423(pageId, sort, caseNo)
'                    Case "APP210301" '形式審查意見
'                        rptModel = APP210301(pageId, sort, caseNo)
'                    Case "APP210303" '委員審查意見 
'                        rptModel = APP210303(pageId, sort, caseNo, serial)
'                    Case "PreMeeting" '會前會首頁表格
'                        rptModel = PreMeeting(pageId, sort, caseNo, groupCode)
'                End Select
'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 因此部分有大量共用部分，因而採用此方式製作
'        ''' </summary>
'        Private Function BCReport(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Select Case caseNo.Substring(0, 4)
'                    Case "BC01"
'                        rptModel = BC01("APP120803", sort, caseNo, "_v1")
'                    Case "BC02"
'                        rptModel = BC02("APP120903", sort, caseNo)
'                    Case "BC03"
'                        rptModel = BC01("APP121003", sort, caseNo)
'                End Select
'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function CCReport(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                Dim rptModel As New ReportModel
'                Select Case caseNo.Substring(0, 4)
'                    Case "CC01"
'                        rptModel = CC01("APP130833", sort, caseNo)
'                    Case "CC02"
'                        rptModel = CC02("APP130933", sort, caseNo)
'                    Case "CC03"
'                        rptModel = CC01("APP131033", sort, caseNo)
'                End Select
'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'#Region "CC02"
'        Public Function CC02(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[CC02]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    'result = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Month.ToString().PadLeft(2, "0")))


'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    'Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    'Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    'Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    Dim dateStr As String = GetSubmitDate(caseCode, dt表頭2)

'                    Dim Year As String = ConvertCDate_Year(dateStr)
'                    Dim Month As String = ConvertCDate_Month(dateStr)
'                    Dim Day As String = ConvertCDate_Day(dateStr)

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        'valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1202", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    Dim chk As String = "■", unchk As String = "□"
'                    drA = dt案件.Select("TOPIC_SEQ = '1203'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_03_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_03_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1203", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1204'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_04_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_04_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1204", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1205'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1205", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1206'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("T_M_ACTIVE_NUMBER", Convert.ToString(drA(0)("M_ACTIVE_NUMBER"))))
'                        valuesToFill.Fields.Add(New FieldContent("T_S_ACTIVE_NUMBER", Convert.ToString(drA(0)("S_ACTIVE_NUMBER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1207'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1207", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1208'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_08_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_08_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("SERVICE_TEL", Convert.ToString(drA(0)("SERVICE_TEL"))))
'                        valuesToFill.Fields.Add(New FieldContent("SERVICE_INTERNET_DESC", Convert.ToString(drA(0)("SERVICE_INTERNET_DESC"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1209'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_09_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_09_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1209", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1210'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_10_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_10_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1210", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1211'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_11_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_11_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1211", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1310'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1310", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1401'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1401_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1401_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_AC_NAME", Convert.ToString(drA(0)("AC_NAME"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1402'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("M_TOPIC_RESULT_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_TOPIC_RESULT_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1502'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1502", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        For index As Integer = 1 To 6
'                            valuesToFill.Fields.Add(New FieldContent("M_DEVICE_RESULT" + index.ToString(), If(drA(0)("DEVICE_RESULT" + index.ToString()).ToString() = "Y", "是", "否")))
'                            valuesToFill.Fields.Add(New FieldContent("M_DEVICE_RESULT" + index.ToString() + "_DESC", Convert.ToString(drA(0)("DEVICE_RESULT" + index.ToString() + "_DESC"))))
'                        Next

'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1602_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1602_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MONITOR_FLAG1", If(drA(0)("MONITOR_FLAG1").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MONITOR_FLAG2", If(drA(0)("MONITOR_FLAG2").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1603_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1603_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_FLAG1", If(drA(0)("MAINTAIN_FLAG1").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_FLAG2", If(drA(0)("MAINTAIN_FLAG2").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_ENGINEER_NUMBER", Convert.ToString(drA(0)("MAINTAIN_ENGINEER_NUMBER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1701_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1701_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    Dim IMPROVE_RESULT1 As String = ""
'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then

'                        Dim IR As String = drA(0)("IMPROVE_RESULT1").ToString()
'                        If IR = "1" Then
'                            IMPROVE_RESULT1 = "是，簡要說明如下"
'                        ElseIf IR = "2" Then
'                            IMPROVE_RESULT1 = "否"
'                        ElseIf IR = "3" Then
'                            IMPROVE_RESULT1 = "無違規案件"
'                        Else
'                            IMPROVE_RESULT1 = ""
'                        End If

'                        valuesToFill.Fields.Add(New FieldContent("IMPROVE_RESULT1", IMPROVE_RESULT1))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1801_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1801_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1802_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1802_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1803_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1803_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2101'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2101", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2201", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2202_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2202_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2202", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2302'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2302", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2501", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2601_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2601_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2601", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2801_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2801_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2801", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2802", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If
'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", FormatDate(dr1411, "BASE_DATE")))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                Dim ctrl1 As CtAPP1410 = New CtAPP1410(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.OrderBys = "TBL_RECID ASC"
'                Dim dt As DataTable = ctrl1.DoQuery()

'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1410")

'                    dt.Columns.Add("COUNT")
'                    Dim MN As Integer = 0
'                    Dim NMN As Integer = 0
'                    Dim COUNT As Integer = 0
'                    Dim COUNTS As Integer = 0
'                    For Each dr As DataRow In dt.Rows
'                        COUNT = (Int32.Parse(dr("MANAGER_NUMBER")) + Int32.Parse(dr("NON_MANAGER_NUMBER"))).ToString()
'                        dr("COUNT") = COUNT
'                        MN = MN + Int32.Parse(dr("MANAGER_NUMBER"))
'                        NMN = NMN + Int32.Parse(dr("NON_MANAGER_NUMBER"))
'                        COUNTS = COUNTS + COUNT
'                    Next

'                    Dim New_dr As DataRow = dt.NewRow
'                    New_dr("PKNO") = 0
'                    New_dr("TBL_RECID") = 0
'                    New_dr("DEPT_NAME") = "總計"
'                    New_dr("MANAGER_NUMBER") = MN
'                    New_dr("NON_MANAGER_NUMBER") = NMN
'                    New_dr("COUNT") = COUNTS
'                    dt.Rows.Add(New_dr)


'                    For Each dr1 As DataRow In dt.Rows
'                        tableContent.AddRow(
'                        New FieldContent("DEPT_NAME", Convert.ToString(dr1("DEPT_NAME"))),
'                        New FieldContent("MANAGER_NUMBER", Convert.ToString(dr1("MANAGER_NUMBER"))),
'                        New FieldContent("NON_MANAGER_NUMBER", Convert.ToString(dr1("NON_MANAGER_NUMBER"))),
'                         New FieldContent("COUNT", Convert.ToString(dr1("COUNT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14301 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14301.CASE_NO = caseNo
'                ctrl14301.ACTIVE_TYPE = "1"
'                ctrl14301.OrderBys = "CREATE_TIME ASC"
'                Dim dt14301 As DataTable = ctrl14301.DoQuery()

'                If (dt14301.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-1")

'                    For Each dr14301 As DataRow In dt14301.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14301("SHOW_NAME"))),
'                         New FieldContent("PLAN_DESC", Convert.ToString(dr14301("PLAN_DESC"))),
'                        New FieldContent("SHOW_TIME", Convert.ToString(dr14301("SHOW_TIME"))),
'                        New FieldContent("SHOW_NUMBER", Convert.ToString(dr14301("SHOW_NUMBER"))),
'                         New FieldContent("SHOW_DATE", Convert.ToString(dr14301("SHOW_DATE"))),
'                        New FieldContent("SERVICE_OBJECT", Convert.ToString(dr14301("SERVICE_OBJECT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '1501---begin
'                Dim ctrl1070 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl1070.CASE_NO = caseNo
'                ctrl1070.OrderBys = "CREATE_TIME ASC"
'                Dim dt1070 As DataTable = ctrl1070.DoQuery()

'                If (dt1070.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1070")

'                    For Each dr1070 As DataRow In dt1070.Rows
'                        tableContent.AddRow(
'                        New FieldContent("TRAINING_DATE", Convert.ToString(dr1070("TRAINING_DATE"))),
'                        New FieldContent("COURSE_NAME", Convert.ToString(dr1070("COURSE_NAME"))),
'                        New FieldContent("TRAINING_NUMBER", Convert.ToString(dr1070("TRAINING_NUMBER"))),
'                         New FieldContent("ORGANIZER", Convert.ToString(dr1070("ORGANIZER")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If
'                '1501---End

'                '1803---begin
'                Dim ctrl1440 As CtAPP1440 = New CtAPP1440(_dbManager, _logUtil)
'                ctrl1440.CASE_NO = caseNo
'                ctrl1440.OrderBys = "CREATE_TIME ASC"
'                Dim dt1440 As DataTable = ctrl1440.DoQuery()

'                Dim ctrl1803 As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)
'                ctrl1803.SYS_KEY = "DECLARE_ITEM"
'                ctrl1803.SYS_TYPE = "1"
'                ctrl1803.USE_STATE = "1"
'                ctrl1803.SYS_PRTID = "CC02"
'                'ctrl1803.SYS_ID = DECLARE_ITEMCell.Text
'                ctrl1803.OrderBys = " SYS_SORT "
'                Dim dt1803 As DataTable = ctrl1803.Get系統下拉資料

'                If (dt1440.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1440")

'                    For Each dr1440 As DataRow In dt1440.Rows
'                        Dim drSub As DataRow = dt1803.Select(" SYS_ID = '" + Convert.ToString(dr1440("DECLARE_ITEM")) + "'")(0)
'                        Dim onTime As String = ""
'                        If Convert.ToString(dr1440("ON_TIME")) = "Y" Then
'                            onTime = "是"
'                        Else
'                            onTime = "否"
'                        End If

'                        tableContent.AddRow(
'                        New FieldContent("DECLARE_ITEM", drSub("SYS_NAME")),
'                        New FieldContent("DECLARE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DECLARE_DATE")))),'New FieldContent("DECLARE_DATE", Convert.ToString(dr1440("DECLARE_DATE")).Substring(0, 11)),
'                        New FieldContent("ON_TIME", onTime),
'                        New FieldContent("DECLARE_DESC", Convert.ToString(dr1440("DECLARE_DESC")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If
'                '1803---End

'                '====呼叫Control=====
'                Dim ctrl14302 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14302.CASE_NO = caseNo
'                ctrl14302.ACTIVE_TYPE = "2"
'                ctrl14302.OrderBys = "CREATE_TIME ASC"
'                Dim dt14302 As DataTable = ctrl14302.DoQuery()

'                If (dt14302.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-2")

'                    For Each dr14302 As DataRow In dt14302.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_DATE", Convert.ToString(dr14302("SHOW_DATE"))),
'                        New FieldContent("ACTIVE_SITE", Convert.ToString(dr14302("ACTIVE_SITE"))),
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14302("SHOW_NAME"))),
'                         New FieldContent("SERVICE_OBJECT", Convert.ToString(dr14302("SERVICE_OBJECT"))),
'                         New FieldContent("PART_NUMBER", Convert.ToString(dr14302("PART_NUMBER")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '====呼叫Control=====
'                For I As Integer = 0 To 1
'                    Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                    ctrl3.CASE_NO = caseNo
'                    ctrl3.DATA_TYPE = I.ToString()
'                    ctrl3.OrderBys = "CREATE_TIME ASC"

'                    '=== 呼叫control ===
'                    Dim dt1421 As DataTable = ctrl3.DoQuery()

'                    If dt1421.Rows.Count > 0 Then
'                        Dim tableContent As TableContent
'                        If I = 0 Then
'                            tableContent = New TableContent("APP1421")
'                        Else
'                            tableContent = New TableContent("APP1421-1")
'                        End If
'                        For Each dr2 As DataRow In dt1421.Rows
'                            '塞變數資料
'                            tableContent.AddRow(
'                        New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                        New FieldContent("M_INTERNAL_RATE", Convert.ToString(dr2("INTERNAL_RATE"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                        New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                        New FieldContent("M_JOIN_HOURS", Convert.ToString(dr2("JOIN_HOURS"))),
'                        New FieldContent("M_JOIN_RATE", Convert.ToString(dr2("JOIN_RATE"))),
'                        New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM09_HOURS", Convert.ToString(dr2("ITEM09_HOURS"))),
'                        New FieldContent("M_ITEM09_RATE", Convert.ToString(dr2("ITEM09_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE")))
')
'                        Next

'                        '加入Table資料
'                        valuesToFill.Tables.Add(tableContent)
'                    End If
'                Next


'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}
'                Dim ItemGOVList() As String = {"YEAR", "IN_BUDGET", "IN_BALANCED_BUDGET", "IN_EX_RATE", "OUT_BUDGET", "OUT_BALANCDE_BUDGET", "OUT_EX_RATE"}

'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"
'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrlL020.CASE_NO = caseNo
'                Dim dtL020 As DataTable = ctrlL020.DoQuery()

'                Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)
'                ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()
'                Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                Dim ORG_TYPE As String = ""
'                If dtL010.Rows.Count > 0 Then
'                    ORG_TYPE = dtL010.Rows(0)("ORG_TYPE").ToString()
'                End If

'                If pageId = "APP130833" Then
'                    If dtL020.Rows.Count > 0 Then
'                        If dtL010.Rows.Count > 0 Then
'                            If dt1451.Rows.Count > 0 Then
'                                For Year As Integer = 1 To dt1451.Rows.Count
'                                    If ORG_TYPE = "C" Then
'                                        For Each Item As String In ItemCList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))                                        
'                                            valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "F" Then
'                                        For Each Item As String In ItemFList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "GOV" Then
'                                        For Each Item As String In ItemGOVList
'                                            '格式化貨幣數值
'                                            valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                Next
'                            End If
'                        End If
'                    End If
'                Else
'                    If dt1451.Rows.Count > 0 Then
'                        For Year As Integer = 1 To dt1451.Rows.Count
'                            If ORG_TYPE = "C" Then
'                                For Each Item As String In ItemCList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "F" Then
'                                For Each Item As String In ItemFList
'                                    '格式化貨幣數值
'                                    'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "GOV" Then
'                                For Each Item As String In ItemGOVList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            End If
'                        Next
'                    End If
'                End If

'                '===未來營運====
'                Dim ctrl14512 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl14512.CASE_NO = caseNo
'                ctrl14512.DATA_TYPE = "1"
'                ctrl14512.OrderBys = "YEAR ASC"
'                Dim dt14512 As DataTable = ctrl14512.DoQuery()

'                If pageId = "APP130833" Then
'                    If dtL020.Rows.Count > 0 Then
'                        If dtL010.Rows.Count > 0 Then
'                            If dt14512.Rows.Count > 0 Then
'                                For Year As Integer = 1 To dt14512.Rows.Count
'                                    If ORG_TYPE = "C" Then
'                                        For Each Item As String In ItemCList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "F" Then
'                                        For Each Item As String In ItemFList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "GOV" Then
'                                        For Each Item As String In ItemFList
'                                            '格式化貨幣數值
'                                            valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                Next
'                            End If
'                        End If
'                    End If
'                Else
'                    If dt14512.Rows.Count > 0 Then
'                        For Year As Integer = 1 To dt14512.Rows.Count
'                            If ORG_TYPE = "C" Then
'                                For Each Item As String In ItemCList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "F" Then
'                                For Each Item As String In ItemFList
'                                    '格式化貨幣數值
'                                    'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                    valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "GOV" Then
'                                For Each Item As String In ItemGOVList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                        Next
'                    End If
'                End If

'                '====呼叫Control=====
'                Dim ctrl1140 As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl1140.CASE_NO = caseNo
'                ctrl1140.COMPLY_TYPE = "C01"
'                ctrl1140.OrderBys = "CREATE_TIME ASC"
'                Dim dt1140 As DataTable = ctrl1140.DoQuery()

'                If (dt1140.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1140-1")

'                    For Each dr1140 As DataRow In dt1140.Rows
'                        tableContent.AddRow(
'                        New FieldContent("IMPROVE_ITEM", Convert.ToString(dr1140("IMPROVE_ITEM"))),
'                        New FieldContent("VIOLATION_ACT", Convert.ToString(dr1140("VIOLATION_ACT"))),
'                        New FieldContent("IMPROVE_DESC", Convert.ToString(dr1140("IMPROVE_DESC")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl11402 As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl11402.CASE_NO = caseNo
'                ctrl11402.COMPLY_TYPE = "D01"
'                ctrl11402.OrderBys = "CREATE_TIME ASC"
'                Dim dt11402 As DataTable = ctrl11402.DoQuery()

'                If (dt11402.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1140-2")

'                    For Each dr11402 As DataRow In dt11402.Rows
'                        tableContent.AddRow(
'                        New FieldContent("IMPROVE_ITEM", Convert.ToString(dr11402("IMPROVE_ITEM"))),
'                        New FieldContent("IMPROVE_DESC", Convert.ToString(dr11402("IMPROVE_DESC"))),
'                        New FieldContent("M_REMARK", Convert.ToString(dr11402("REMARK")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'#End Region

'#Region "CC01"
'        Public Function CC01(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[CC]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    'result = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()
'                Dim chk As String = "■", unchk As String = "□"

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Month.ToString().PadLeft(2, "0")))


'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    'Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    'Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    'Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    Dim dateStr As String = GetSubmitDate(caseCode, dt表頭2)

'                    Dim Year As String = ConvertCDate_Year(dateStr)
'                    Dim Month As String = ConvertCDate_Month(dateStr)
'                    Dim Day As String = ConvertCDate_Day(dateStr)

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料
'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1209'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1209", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1210'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1210", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1211'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1211", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1212'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1212", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1213'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1213", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1214'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1214", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1215'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1215", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1216'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1216", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1310'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1310", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1604", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1605'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1605", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1606'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1606", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1607'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1607", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1608'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1608", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1804'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1804", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2101'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2101", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2201", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2202", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2301", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2303", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2501", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2601_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2601_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2601", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2701_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2701_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2701", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2702", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2801_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_2801_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2801", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2802", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    'valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", DateUtil.ConvertFormatDate(dr1411("BASE_DATE"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", FormatDate(dr1411, "BASE_DATE")))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                Dim ctrl1 As CtAPP1410 = New CtAPP1410(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.OrderBys = "TBL_RECID ASC"
'                Dim dt As DataTable = ctrl1.DoQuery()

'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1410")

'                    dt.Columns.Add("COUNT")
'                    Dim MN As Integer = 0
'                    Dim NMN As Integer = 0
'                    Dim COUNT As Integer = 0
'                    Dim COUNTS As Integer = 0
'                    For Each dr As DataRow In dt.Rows
'                        COUNT = (Int32.Parse(dr("MANAGER_NUMBER")) + Int32.Parse(dr("NON_MANAGER_NUMBER"))).ToString()
'                        dr("COUNT") = COUNT
'                        MN = MN + Int32.Parse(dr("MANAGER_NUMBER"))
'                        NMN = NMN + Int32.Parse(dr("NON_MANAGER_NUMBER"))
'                        COUNTS = COUNTS + COUNT
'                    Next

'                    Dim New_dr As DataRow = dt.NewRow
'                    New_dr("PKNO") = 0
'                    New_dr("TBL_RECID") = 0
'                    New_dr("DEPT_NAME") = "總計"
'                    New_dr("MANAGER_NUMBER") = MN
'                    New_dr("NON_MANAGER_NUMBER") = NMN
'                    New_dr("COUNT") = COUNTS
'                    dt.Rows.Add(New_dr)


'                    For Each dr1 As DataRow In dt.Rows
'                        tableContent.AddRow(
'                        New FieldContent("DEPT_NAME", Convert.ToString(dr1("DEPT_NAME"))),
'                        New FieldContent("MANAGER_NUMBER", Convert.ToString(dr1("MANAGER_NUMBER"))),
'                        New FieldContent("NON_MANAGER_NUMBER", Convert.ToString(dr1("NON_MANAGER_NUMBER"))),
'                         New FieldContent("COUNT", Convert.ToString(dr1("COUNT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14301 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14301.CASE_NO = caseNo
'                ctrl14301.ACTIVE_TYPE = "1"
'                ctrl14301.OrderBys = "CREATE_TIME ASC"
'                Dim dt14301 As DataTable = ctrl14301.DoQuery()

'                If (dt14301.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-1")

'                    For Each dr14301 As DataRow In dt14301.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14301("SHOW_NAME"))),
'                        New FieldContent("SHOW_LEN", Convert.ToString(dr14301("SHOW_LEN"))),
'                        New FieldContent("SHOW_NUMBER", Convert.ToString(dr14301("SHOW_NUMBER"))),
'                         New FieldContent("SHOW_TIME", Convert.ToString(dr14301("SHOW_TIME"))),
'                         New FieldContent("PLAN_DESC", Convert.ToString(dr14301("PLAN_DESC")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14302 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14302.CASE_NO = caseNo
'                ctrl14302.ACTIVE_TYPE = "2"
'                ctrl14302.OrderBys = "CREATE_TIME ASC"
'                Dim dt14302 As DataTable = ctrl14302.DoQuery()

'                If (dt14302.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-2")

'                    For Each dr14302 As DataRow In dt14302.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14302("SHOW_NAME"))),
'                        New FieldContent("SHOW_DATE", Convert.ToString(dr14302("SHOW_DATE"))),
'                        New FieldContent("ACTIVE_SITE", Convert.ToString(dr14302("ACTIVE_SITE"))),
'                         New FieldContent("PLAN_DESC", Convert.ToString(dr14302("PLAN_DESC")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '====呼叫Control=====
'                For I As Integer = 0 To 1
'                    Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                    ctrl3.CASE_NO = caseNo
'                    ctrl3.DATA_TYPE = I.ToString()
'                    ctrl3.OrderBys = "CREATE_TIME ASC"

'                    '=== 呼叫control ===
'                    Dim dt1421 As DataTable = ctrl3.DoQuery()

'                    If dt1421.Rows.Count > 0 Then
'                        Dim tableContent As TableContent
'                        If I = 0 Then
'                            tableContent = New TableContent("APP1421")
'                        Else
'                            tableContent = New TableContent("APP1421-1")
'                        End If
'                        For Each dr2 As DataRow In dt1421.Rows
'                            '塞變數資料
'                            tableContent.AddRow(
'                        New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                        New FieldContent("M_INTERNAL_RATE", Convert.ToString(dr2("INTERNAL_RATE"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                        New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                        New FieldContent("M_JOIN_HOURS", Convert.ToString(dr2("JOIN_HOURS"))),
'                        New FieldContent("M_JOIN_RATE", Convert.ToString(dr2("JOIN_RATE"))),
'                        New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM09_HOURS", Convert.ToString(dr2("ITEM09_HOURS"))),
'                        New FieldContent("M_ITEM09_RATE", Convert.ToString(dr2("ITEM09_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE")))
')
'                        Next

'                        '加入Table資料
'                        valuesToFill.Tables.Add(tableContent)
'                    End If
'                Next


'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}
'                Dim ItemGOVList() As String = {"YEAR", "IN_BUDGET", "IN_BALANCED_BUDGET", "IN_EX_RATE", "OUT_BUDGET", "OUT_BALANCDE_BUDGET", "OUT_EX_RATE"}

'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"
'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrlL020.CASE_NO = caseNo
'                Dim dtL020 As DataTable = ctrlL020.DoQuery()

'                Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)
'                ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()
'                Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                Dim ORG_TYPE As String = ""
'                If dtL010.Rows.Count > 0 Then
'                    ORG_TYPE = dtL010.Rows(0)("ORG_TYPE").ToString()
'                End If

'                If pageId = "APP130833" Then
'                    If dtL020.Rows.Count > 0 Then
'                        If dtL010.Rows.Count > 0 Then
'                            If dt1451.Rows.Count > 0 Then
'                                'Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                For Year As Integer = 1 To dt1451.Rows.Count
'                                    If ORG_TYPE = "C" Then
'                                        For Each Item As String In ItemCList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "F" Then
'                                        For Each Item As String In ItemFList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "GOV" Then
'                                        For Each Item As String In ItemGOVList
'                                            '格式化貨幣數值
'                                            valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                Next
'                            End If
'                        End If
'                    End If
'                Else
'                    If dt1451.Rows.Count > 0 Then
'                        'Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                        If ORG_TYPE = "C" Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                For Each Item As String In ItemCList
'                                    'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            Next
'                        End If
'                        If ORG_TYPE = "F" Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                For Each Item As String In ItemFList
'                                    'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            Next
'                        End If
'                        If ORG_TYPE = "GOV" Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                For Each Item As String In ItemGOVList
'                                    valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt1451(Year - 1)(Item))))))
'                                Next
'                            Next
'                        End If
'                    End If
'                End If


'                '===未來營運====
'                Dim ctrl14512 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl14512.CASE_NO = caseNo
'                ctrl14512.DATA_TYPE = "1"
'                ctrl14512.OrderBys = "YEAR ASC"
'                Dim dt14512 As DataTable = ctrl14512.DoQuery()

'                'Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                'ctrlL020.CASE_NO = CaseNo
'                'Dim dtL020 As DataTable = ctrlL020.DoQuery()

'                'Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)
'                'ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()
'                'Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                If pageId = "APP130833" Then
'                    If dtL020.Rows.Count > 0 Then
'                        If dtL010.Rows.Count > 0 Then
'                            If dt14512.Rows.Count > 0 Then
'                                For Year As Integer = 1 To dt14512.Rows.Count
'                                    'Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                    If ORG_TYPE = "C" Then
'                                        For Each Item As String In ItemCList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "F" Then
'                                        For Each Item As String In ItemFList
'                                            '格式化貨幣數值
'                                            'valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                            valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "GOV" Then
'                                        For Each Item As String In ItemGOVList
'                                            '格式化貨幣數值
'                                            valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                        Next
'                                    End If
'                                Next
'                            End If
'                        End If
'                    End If
'                Else
'                    If dt14512.Rows.Count > 0 Then
'                        'Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                        For Year As Integer = 1 To dt14512.Rows.Count
'                            If ORG_TYPE = "C" Then
'                                For Each Item As String In ItemCList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "F" Then
'                                For Each Item As String In ItemFList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                            If ORG_TYPE = "GOV" Then
'                                For Each Item As String In ItemGOVList
'                                    '格式化貨幣數值
'                                    valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString() + "_F", String.Format("{0:#,#;0;0}", ToDecimal(Convert.ToString(dt14512(Year - 1)(Item))))))
'                                Next
'                            End If
'                        Next
'                    End If

'                End If

'                '====呼叫Control=====
'                Dim ctrl1440 As CtAPP1440 = New CtAPP1440(_dbManager, _logUtil)
'                ctrl1440.CASE_NO = caseNo
'                ctrl1440.OrderBys = "CREATE_TIME ASC"
'                Dim dt1440 As DataTable = ctrl1440.Query_ItemWithName()

'                If (dt1440.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1440")

'                    For Each dr1440 As DataRow In dt1440.Rows
'                        tableContent.AddRow(
'                        New FieldContent("YEAR", Convert.ToString(dr1440("YEAR"))),
'                        New FieldContent("DECLARE_ITEM", Convert.ToString(dr1440("SYS_NAME"))),
'                        New FieldContent("DEADLINE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DEADLINE_DATE")))),'     New FieldContent("DEADLINE_DATE", Convert.ToString(dr1440("DEADLINE_DATE")).Substring(0, 10)),
'                         New FieldContent("DECLARE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DECLARE_DATE")))), '     New FieldContent("DECLARE_DATE", Convert.ToString(dr1440("DECLARE_DATE")).Substring(0, 10)),
'                         New FieldContent("DECLARE_DESC", Convert.ToString(dr1440("DECLARE_DESC")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        'Private Function mySubString(ByVal str As String, ByVal startIndex As Integer, ByVal length As Integer) As String
'        '    Try
'        '        _logUtil.MethodStart(GetCurrentMethod.Name)

'        '        Dim result As String = ""

'        '        If str.Length > 0 Then
'        '            result = str.Substring(startIndex, length)
'        '        End If

'        '        Return result

'        '    Finally
'        '    _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'        '    End Try
'        'End Function

'#End Region

'#Region "BC02"
'        Public Function BC02(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[BC02]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    'Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    'Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    'Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    Dim dateStr As String = GetSubmitDate(caseCode, dt表頭2)

'                    Dim Year As String = ConvertCDate_Year(dateStr)
'                    Dim Month As String = ConvertCDate_Month(dateStr)
'                    Dim Day As String = ConvertCDate_Day(dateStr)

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1202", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    Dim chk As String = "■", unchk As String = "□"
'                    drA = dt案件.Select("TOPIC_SEQ = '1203'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_03_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_03_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1203", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1204'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_04_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_04_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1204", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1205'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1205", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1206'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("T_M_ACTIVE_NUMBER", Convert.ToString(drA(0)("M_ACTIVE_NUMBER"))))
'                        valuesToFill.Fields.Add(New FieldContent("T_S_ACTIVE_NUMBER", Convert.ToString(drA(0)("S_ACTIVE_NUMBER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1207'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1207", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1208'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_08_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_08_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("SERVICE_TEL", Convert.ToString(drA(0)("SERVICE_TEL"))))
'                        valuesToFill.Fields.Add(New FieldContent("SERVICE_INTERNET_DESC", NewLineFormated(Convert.ToString(drA(0)("SERVICE_INTERNET_DESC")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1209'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_09_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_09_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1209", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1210'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_10_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_10_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1210", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1211'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_11_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_11_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1211", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1310'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1310", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1401'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1401_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1401_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_AC_NAME", NewLineFormated(Convert.ToString(drA(0)("AC_NAME")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1402'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("M_TOPIC_RESULT_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_TOPIC_RESULT_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1502'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1502", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        For index As Integer = 1 To 6
'                            valuesToFill.Fields.Add(New FieldContent("M_DEVICE_RESULT" + index.ToString(), If(drA(0)("DEVICE_RESULT" + index.ToString()).ToString() = "Y", "是", "否")))
'                            valuesToFill.Fields.Add(New FieldContent("M_DEVICE_RESULT" + index.ToString() + "_DESC", NewLineFormated(Convert.ToString(drA(0)("DEVICE_RESULT" + index.ToString() + "_DESC")))))
'                        Next

'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1602_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1602_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MONITOR_FLAG1", If(drA(0)("MONITOR_FLAG1").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MONITOR_FLAG2", If(drA(0)("MONITOR_FLAG2").ToString() = "Y", chk, unchk)))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1603_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1603_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_FLAG1", If(drA(0)("MAINTAIN_FLAG1").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_FLAG2", If(drA(0)("MAINTAIN_FLAG2").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("M_MAINTAIN_ENGINEER_NUMBER", Convert.ToString(drA(0)("MAINTAIN_ENGINEER_NUMBER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1701_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1701_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    Dim IMPROVE_RESULT1 As String = ""
'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then

'                        Dim IR As String = drA(0)("IMPROVE_RESULT1").ToString()
'                        If IR = "1" Then
'                            IMPROVE_RESULT1 = "是，簡要說明如下"
'                        ElseIf IR = "2" Then
'                            IMPROVE_RESULT1 = "否"
'                        ElseIf IR = "3" Then
'                            IMPROVE_RESULT1 = "無違規案件"
'                        Else
'                            IMPROVE_RESULT1 = ""
'                        End If

'                        valuesToFill.Fields.Add(New FieldContent("IMPROVE_RESULT1", IMPROVE_RESULT1))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1801_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1801_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1802_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1802_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1803_Y", If(drA(0)("TOPIC_RESULT").ToString() = "Y", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_RESULT_1803_N", If(drA(0)("TOPIC_RESULT").ToString() = "N", chk, unchk)))
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If
'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", FormatDate(dr1411, "BASE_DATE")))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                Dim ctrl14301 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14301.CASE_NO = caseNo
'                ctrl14301.ACTIVE_TYPE = "1"
'                ctrl14301.OrderBys = "CREATE_TIME ASC"
'                Dim dt14301 As DataTable = ctrl14301.DoQuery()

'                If (dt14301.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-1")

'                    For Each dr14301 As DataRow In dt14301.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14301("SHOW_NAME"))),
'                        New FieldContent("PLAN_DESC", NewLineFormated(Convert.ToString(dr14301("PLAN_DESC")))),
'                        New FieldContent("SHOW_TIME", Convert.ToString(dr14301("SHOW_TIME"))),
'                         New FieldContent("SHOW_NUMBER", Convert.ToString(dr14301("SHOW_NUMBER"))),
'                         New FieldContent("SHOW_DATE", Convert.ToString(dr14301("SHOW_DATE"))),
'                         New FieldContent("SERVICE_OBJECT", Convert.ToString(dr14301("SERVICE_OBJECT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14302 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14302.CASE_NO = caseNo
'                ctrl14302.ACTIVE_TYPE = "2"
'                ctrl14302.OrderBys = "CREATE_TIME ASC"
'                Dim dt14302 As DataTable = ctrl14302.DoQuery()

'                If (dt14302.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-2")

'                    For Each dr14302 As DataRow In dt14302.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_DATE", Convert.ToString(dr14302("SHOW_DATE"))),
'                        New FieldContent("ACTIVE_SITE", Convert.ToString(dr14302("ACTIVE_SITE"))),
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14302("SHOW_NAME"))),
'                         New FieldContent("SERVICE_OBJECT", Convert.ToString(dr14302("SERVICE_OBJECT"))),
'                         New FieldContent("PART_NUMBER", Convert.ToString(dr14302("PART_NUMBER")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '====呼叫Control=====
'                Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                ctrl3.DATA_TYPE = "0"
'                ctrl3.OrderBys = "CREATE_TIME ASC"

'                '=== 呼叫control ===
'                Dim dt1421 As DataTable = ctrl3.DoQuery()

'                If dt1421.Rows.Count > 0 Then
'                    Dim tableContent As TableContent = New TableContent("APP1421")
'                    For Each dr2 As DataRow In dt1421.Rows
'                        '塞變數資料
'                        tableContent.AddRow(
'                        New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                        New FieldContent("M_INTERNAL_RATE", Convert.ToString(dr2("INTERNAL_RATE"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                        New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                        New FieldContent("M_JOIN_HOURS", Convert.ToString(dr2("JOIN_HOURS"))),
'                        New FieldContent("M_JOIN_RATE", Convert.ToString(dr2("JOIN_RATE"))),
'                        New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM09_HOURS", Convert.ToString(dr2("ITEM09_HOURS"))),
'                        New FieldContent("M_ITEM09_RATE", Convert.ToString(dr2("ITEM09_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE")))
')
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"

'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}
'                Dim ItemGOVList() As String = {"YEAR", "IN_BUDGET", "IN_BALANCED_BUDGET", "IN_EX_RATE", "OUT_BUDGET", "OUT_BALANCDE_BUDGET", "OUT_EX_RATE"}

'                Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)

'                '=== 設定屬性參數 ===
'                ctrlL020.CASE_NO = caseNo

'                Dim dtL020 As DataTable = ctrlL020.DoQuery()
'                If dtL020.Rows.Count > 0 Then
'                    Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)

'                    '=== 設定屬性參數 ===
'                    ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()

'                    Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                    If dtL010.Rows.Count > 0 Then
'                        If dt1451.Rows.Count > 0 Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                If ORG_TYPE = "C" Then
'                                    For Each Item As String In ItemCList
'                                        valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                                If ORG_TYPE = "F" Then
'                                    For Each Item As String In ItemFList
'                                        valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                                If ORG_TYPE = "GOV" Then
'                                    For Each Item As String In ItemGOVList
'                                        valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                            Next
'                        End If
'                    End If
'                End If

'                '====呼叫Control=====
'                Dim ctrl1070 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl1070.CASE_NO = caseNo
'                ctrl1070.OrderBys = "CREATE_TIME ASC"
'                Dim dt1070 As DataTable = ctrl1070.DoQuery()

'                If (dt1070.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1070")

'                    For Each dr1070 As DataRow In dt1070.Rows
'                        tableContent.AddRow(
'                        New FieldContent("TRAINING_DATE", Convert.ToString(dr1070("TRAINING_DATE"))),
'                        New FieldContent("COURSE_NAME", Convert.ToString(dr1070("COURSE_NAME"))),
'                        New FieldContent("TRAINING_NUMBER", Convert.ToString(dr1070("TRAINING_NUMBER"))),
'                         New FieldContent("ORGANIZER", Convert.ToString(dr1070("ORGANIZER"))),
'                         New FieldContent("COURSE_CONTENT", Convert.ToString(dr1070("COURSE_CONTENT")))
'                        )
'                    Next

'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl1140 As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl1140.CASE_NO = caseNo
'                ctrl1140.COMPLY_TYPE = "C01"
'                ctrl1140.OrderBys = "CREATE_TIME ASC"
'                Dim dt1140 As DataTable = ctrl1140.DoQuery()

'                If (dt1140.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1140")

'                    For Each dr1140 As DataRow In dt1140.Rows
'                        tableContent.AddRow(
'                        New FieldContent("IMPROVE_ITEM", Convert.ToString(dr1140("IMPROVE_ITEM"))),
'                        New FieldContent("VIOLATION_ACT", Convert.ToString(dr1140("VIOLATION_ACT"))),
'                        New FieldContent("IMPROVE_DESC", NewLineFormated(Convert.ToString(dr1140("IMPROVE_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl1440 As CtAPP1440 = New CtAPP1440(_dbManager, _logUtil)
'                ctrl1440.CASE_NO = caseNo
'                ctrl1440.OrderBys = "CREATE_TIME ASC"
'                Dim dt1440 As DataTable = ctrl1440.Query_ItemWithName()

'                If (dt1440.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1440")

'                    For Each dr1440 As DataRow In dt1440.Rows
'                        tableContent.AddRow(
'                        New FieldContent("DECLARE_ITEM", Convert.ToString(dr1440("SYS_NAME"))),
'                        New FieldContent("DECLARE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DECLARE_DATE")))),
'                         New FieldContent("ON_TIME", Convert.ToString(dr1440("ON_TIME"))),
'                         New FieldContent("DECLARE_DESC", NewLineFormated(Convert.ToString(dr1440("DECLARE_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'#End Region

'#Region "BC01"
'        Public Function BC01(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String, Optional ByVal sub_param As String = "") As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[BC]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                'Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                Dim Templatefilename As String = ""
'                If sub_param.Length = 0 Then
'                    Templatefilename = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                Else
'                    Templatefilename = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & sub_param & ".DOCX"
'                End If

'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    'Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    'Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    'Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    Dim dateStr As String = GetSubmitDate(caseCode, dt表頭2)

'                    Dim Year As String = ConvertCDate_Year(dateStr)
'                    Dim Month As String = ConvertCDate_Month(dateStr)
'                    Dim Day As String = ConvertCDate_Day(dateStr)

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1209'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1209", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1210'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1210", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1211'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1211", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1212'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1212", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1213'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1213", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1214'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1214", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1215'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1215", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1216'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1216", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1310'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1310", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1604", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1605'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1605", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1606'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1606", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1607'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1607", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1608'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1608", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1804'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1804", NewLineFormated(Convert.ToString(drA(0)("TOPIC_ANSWER")))))
'                    End If
'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    'valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", DateUtil.ConvertFormatDate(dr1411("BASE_DATE"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", FormatDate(dr1411, "BASE_DATE")))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                Dim ctrl1 As CtAPP1410 = New CtAPP1410(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.OrderBys = "TBL_RECID ASC"
'                Dim dt As DataTable = ctrl1.DoQuery()

'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1410")

'                    dt.Columns.Add("COUNT")
'                    Dim MN As Integer = 0
'                    Dim NMN As Integer = 0
'                    Dim COUNT As Integer = 0
'                    Dim COUNTS As Integer = 0
'                    For Each dr As DataRow In dt.Rows
'                        COUNT = (Int32.Parse(dr("MANAGER_NUMBER")) + Int32.Parse(dr("NON_MANAGER_NUMBER"))).ToString()
'                        dr("COUNT") = COUNT
'                        MN = MN + Int32.Parse(dr("MANAGER_NUMBER"))
'                        NMN = NMN + Int32.Parse(dr("NON_MANAGER_NUMBER"))
'                        COUNTS = COUNTS + COUNT
'                    Next

'                    Dim New_dr As DataRow = dt.NewRow
'                    New_dr("PKNO") = 0
'                    New_dr("TBL_RECID") = 0
'                    New_dr("DEPT_NAME") = "總計"
'                    New_dr("MANAGER_NUMBER") = MN
'                    New_dr("NON_MANAGER_NUMBER") = NMN
'                    New_dr("COUNT") = COUNTS
'                    dt.Rows.Add(New_dr)


'                    For Each dr1 As DataRow In dt.Rows
'                        Dim deptName As String = ""
'                        If Convert.ToString(dr1("DEPT_NAME")) = "其他" Then
'                            deptName = Convert.ToString(dr1("DEPT_NAME")) + "(" + Convert.ToString(dr1("DEPT_DESC")) + ")"
'                        Else
'                            deptName = Convert.ToString(dr1("DEPT_NAME"))
'                        End If
'                        tableContent.AddRow(
'                        New FieldContent("DEPT_NAME", deptName),
'                        New FieldContent("MANAGER_NUMBER", Convert.ToString(dr1("MANAGER_NUMBER"))),
'                        New FieldContent("NON_MANAGER_NUMBER", Convert.ToString(dr1("NON_MANAGER_NUMBER"))),
'                         New FieldContent("COUNT", Convert.ToString(dr1("COUNT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14301 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14301.CASE_NO = caseNo
'                ctrl14301.ACTIVE_TYPE = "1"
'                ctrl14301.OrderBys = "CREATE_TIME ASC"
'                Dim dt14301 As DataTable = ctrl14301.DoQuery()

'                If (dt14301.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-1")

'                    For Each dr14301 As DataRow In dt14301.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14301("SHOW_NAME"))),
'                        New FieldContent("SHOW_LEN", Convert.ToString(dr14301("SHOW_LEN"))),
'                        New FieldContent("SHOW_NUMBER", Convert.ToString(dr14301("SHOW_NUMBER"))),
'                         New FieldContent("SHOW_TIME", Convert.ToString(dr14301("SHOW_TIME"))),
'                         New FieldContent("PLAN_DESC", NewLineFormated(Convert.ToString(dr14301("PLAN_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl14302 As CtAPP1430 = New CtAPP1430(_dbManager, _logUtil)
'                ctrl14302.CASE_NO = caseNo
'                ctrl14302.ACTIVE_TYPE = "2"
'                ctrl14302.OrderBys = "CREATE_TIME ASC"
'                Dim dt14302 As DataTable = ctrl14302.DoQuery()

'                If (dt14302.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1430-2")

'                    For Each dr14302 As DataRow In dt14302.Rows
'                        tableContent.AddRow(
'                        New FieldContent("SHOW_NAME", Convert.ToString(dr14302("SHOW_NAME"))),
'                        New FieldContent("SHOW_DATE", Convert.ToString(dr14302("SHOW_DATE"))),
'                        New FieldContent("ACTIVE_SITE", Convert.ToString(dr14302("ACTIVE_SITE"))),
'                         New FieldContent("PLAN_DESC", NewLineFormated(Convert.ToString(dr14302("PLAN_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '====呼叫Control=====
'                Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                ctrl3.DATA_TYPE = "0"
'                ctrl3.OrderBys = "CREATE_TIME ASC"

'                '=== 呼叫control ===
'                Dim dt1421 As DataTable = ctrl3.DoQuery()

'                If dt1421.Rows.Count > 0 Then
'                    Dim tableContent As TableContent = New TableContent("APP1421")
'                    For Each dr2 As DataRow In dt1421.Rows
'                        '塞變數資料
'                        tableContent.AddRow(
'                        New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                        New FieldContent("M_INTERNAL_RATE", Convert.ToString(dr2("INTERNAL_RATE"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                        New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                        New FieldContent("M_JOIN_HOURS", Convert.ToString(dr2("JOIN_HOURS"))),
'                        New FieldContent("M_JOIN_RATE", Convert.ToString(dr2("JOIN_RATE"))),
'                        New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM09_HOURS", Convert.ToString(dr2("ITEM09_HOURS"))),
'                        New FieldContent("M_ITEM09_RATE", Convert.ToString(dr2("ITEM09_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE")))
')
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"

'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}
'                Dim ItemGOVList() As String = {"YEAR", "IN_BUDGET", "IN_BALANCED_BUDGET", "IN_EX_RATE", "OUT_BUDGET", "OUT_BALANCDE_BUDGET", "OUT_EX_RATE"}

'                If pageId = "APP120803" Then
'                    Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)

'                    '=== 設定屬性參數 ===
'                    ctrlL020.CASE_NO = caseNo

'                    Dim dtL020 As DataTable = ctrlL020.DoQuery()
'                    If dtL020.Rows.Count > 0 Then
'                        Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)

'                        '=== 設定屬性參數 ===
'                        ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()

'                        Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                        If dtL010.Rows.Count > 0 Then
'                            If dt1451.Rows.Count > 0 Then
'                                For Year As Integer = 1 To dt1451.Rows.Count
'                                    Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                    If ORG_TYPE = "C" Then
'                                        For Each Item As String In ItemCList
'                                            valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "F" Then
'                                        For Each Item As String In ItemFList
'                                            valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                        Next
'                                    End If
'                                    If ORG_TYPE = "GOV" Then
'                                        For Each Item As String In ItemGOVList
'                                            valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                        Next
'                                    End If
'                                Next
'                            End If
'                        End If
'                    End If
'                Else
'                    If dt1451.Rows.Count > 0 Then
'                        For Year As Integer = 1 To dt1451.Rows.Count
'                            For Each Item As String In ItemFList
'                                valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                            Next
'                        Next
'                        For Year As Integer = 1 To dt1451.Rows.Count
'                            For Each Item As String In ItemGOVList
'                                valuesToFill.Fields.Add(New FieldContent("GOV_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                            Next
'                        Next
'                    End If
'                End If


'                '====呼叫Control=====
'                Dim ctrl1440 As CtAPP1440 = New CtAPP1440(_dbManager, _logUtil)
'                ctrl1440.CASE_NO = caseNo
'                ctrl1440.OrderBys = "CREATE_TIME ASC"
'                Dim dt1440 As DataTable = ctrl1440.Query_ItemWithName()

'                If (dt1440.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1440")

'                    For Each dr1440 As DataRow In dt1440.Rows
'                        tableContent.AddRow(
'                        New FieldContent("YEAR", Convert.ToString(dr1440("YEAR"))),
'                        New FieldContent("DECLARE_ITEM", Convert.ToString(dr1440("SYS_NAME"))),
'                        New FieldContent("DEADLINE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DEADLINE_DATE")))),
'                         New FieldContent("DECLARE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DECLARE_DATE")))),
'                         New FieldContent("DECLARE_DESC", NewLineFormated(Convert.ToString(dr1440("DECLARE_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 當APPL020.CASE_CODE為：BC01、BC02、BC03、CC01、CC02、CC03
'        ''' 封面的的日期，印出該案件的APPL020.APV_DATE，其餘為CREATE_DATE
'        ''' </summary>
'        ''' <param name="caseCode"></param>
'        ''' <param name="dt"></param>        
'        ''' <returns></returns>
'        Private Function GetSubmitDate(ByVal caseCode As String, ByVal dt As DataTable) As String
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rtnDateStr As String = ""

'                _logUtil.Logger.Append("GetSubmitDate dt.Rows.Count.ToString = " + dt.Rows.Count.ToString)

'                If dt.Rows.Count > 0 Then
'                    Select Case caseCode
'                        Case "BC01", "BC02", "BC03", "CC01", "CC02", "CC03"
'                            rtnDateStr = dt.Rows(0)("APV_DATE").ToString
'                        Case Else
'                            rtnDateStr = dt.Rows(0)("CREATE_TIME").ToString
'                    End Select
'                End If

'                Return rtnDateStr

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function FormatDate(ByVal dr As DataRow, ByVal col As String) As String
'            If IsDBNull(dr(col)) Then
'                Return ""
'            Else
'                Return DateUtil.ConvertFormatDate(dr(col))
'            End If
'        End Function
'#End Region

'#Region "APP210303 委員審查意見 "
'        Public Function APP210303(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String, Optional ByVal serial As Integer = 0) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[委員審查意見]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '=== 建立檔案 ===
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)


'                '=== 撈資料 ===
'                '申請項目資料
'                Dim applyItem As String = ""
'                Dim dtST010 As DataTable = GetAPPLY_ITEM(caseCode)
'                If dtST010.Rows.Count > 0 Then
'                    applyItem = dtST010.Rows(0)(APP210303_Model.Column.SYS_NAME).ToString
'                End If

'                'OrgType
'                Dim orgType As String = ""
'                Dim ct1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ct1010.CASE_NO = caseNo
'                Dim dt1010_orgType As DataTable = ct1010.DoQueryORG_TYPE
'                If dt1010_orgType.Rows.Count > 0 Then
'                    If dt1010_orgType.Rows(0)(APP210303_Model.Column.SYS_NAME).ToString.Length > 0 Then
'                        orgType = dt1010_orgType.Rows(0)(APP210303_Model.Column.SYS_NAME).ToString
'                    End If
'                End If

'                '名稱      
'                Dim sName As String = ""
'                Dim sysCName As String = "" '頻道名稱
'                Dim appPersonNM As String = "" '公司名稱
'                ct1010.CASE_NO = caseNo
'                Dim dt1010 As DataTable = ct1010.DoQuery

'                If dt1010.Rows.Count > 0 Then
'                    If dt1010.Rows(0)(APP210303_Model.Column.APP_PERSON_NM).ToString.Length > 0 Then
'                        appPersonNM = dt1010.Rows(0)(APP210303_Model.Column.APP_PERSON_NM).ToString
'                    End If

'                    If dt1010.Rows(0)(APP210303_Model.Column.SYS_CNAME).ToString.Length > 0 Then
'                        sysCName = dt1010.Rows(0)(APP210303_Model.Column.SYS_CNAME).ToString
'                    End If

'                    If sysCName.Length > 0 Then
'                        sName = sysCName
'                    Else
'                        sName = appPersonNM
'                    End If
'                End If

'                '編號
'                Dim iSerial As Integer = 1
'                If serial > 1 Then
'                    iSerial = serial.ToString
'                End If

'                '評分表
'                Dim dtSumMark As DataTable = GetSUM(caseNo)
'                _logUtil.Logger.Append("dtSumMark.Rows.Count.ToString = " + dtSumMark.Rows.Count.ToString)

'                'Create Temp Table
'                Dim dtResult As New DataTable("QryResult")
'                dtResult.Columns.Add(APP210303_Model.Column.ACNT, GetType(String))
'                dtResult.Columns.Add(APP210303_Model.Column.CH_NAME, GetType(String))
'                dtResult.Columns.Add(APP210303_Model.Column.TOTAL_MARK, GetType(String))
'                dtResult.Columns.Add(APP210303_Model.Column.CHECKED_QNO_DESC, GetType(String))

'                If dtSumMark.Rows.Count > 0 Then
'                    For Each row As DataRow In dtSumMark.Rows
'                        Dim r As DataRow = dtResult.NewRow
'                        r(APP210303_Model.Column.ACNT) = row(APP210303_Model.Column.ACNT)
'                        r(APP210303_Model.Column.CH_NAME) = row(APP210303_Model.Column.CH_NAME)
'                        r(APP210303_Model.Column.TOTAL_MARK) = row(APP210303_Model.Column.TOTAL_MARK)
'                        r(APP210303_Model.Column.CHECKED_QNO_DESC) = GetFormatString_QNO_DESC(caseNo, caseCode, row(APP210303_Model.Column.ACNT).ToString)
'                        dtResult.Rows.Add(r)
'                    Next
'                    dtResult.AcceptChanges()
'                Else
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "_APPL024_無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '形式審查意見-預擬審查委員會議總評意見
'                Dim preAns As String = ""
'                Dim dtPreANS As DataTable = GetAPPL023(caseNo)
'                _logUtil.Logger.Append("dtPreANS.Rows.Count.ToString = " + dtPreANS.Rows.Count.ToString)

'                If dtPreANS.Rows.Count > 0 Then
'                    preAns = dtPreANS(0)(APP210303_Model.Column.TOPIC_ANSWER).ToString
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim targetTb As Integer = 1
'                    Dim targetR As Integer = 0
'                    Dim tb As Novacode.Table = document.Tables(targetTb)
'                    Dim tr1 = tb.Rows(targetR)
'                    'Dim tailRow = tb.Rows(0)

'                    '標題名稱置換
'                    document.ReplaceText(APP210303_Model.Report.Text_A, applyItem)
'                    document.ReplaceText(APP210303_Model.Report.Text_B, orgType)
'                    document.ReplaceText(APP210303_Model.Report.Text_C, iSerial)
'                    document.ReplaceText(APP210303_Model.Report.Text_D, sName)

'                    For i As Integer = 0 To dtResult.Rows.Count - 2
'                        tb.InsertRow(tr1, 1)
'                    Next

'                    '塞資料-各評分資訊
'                    Dim rInit As Integer = 0
'                    Dim rCount As Integer = rInit

'                    For Each dr As DataRow In dtResult.Rows
'                        tb.Rows(rCount).Cells(0).Paragraphs.First().ReplaceText(APP210303_Model.Report.Text_E, dr(APP210303_Model.Column.CH_NAME).ToString())
'                        tb.Rows(rCount).Cells(0).Paragraphs.First().ReplaceText(APP210303_Model.Report.Text_F, dr(APP210303_Model.Column.TOTAL_MARK).ToString())

'                        'Get CheckBox And Insert
'                        Dim i As Integer = 1
'                        Dim dt As DataTable = GetCheckList(caseNo, caseCode, dr(APP210303_Model.Column.ACNT).ToString)
'                        For Each r As DataRow In dt.Rows

'                            If dt.Rows.Count > 0 Then
'                                If i > 1 Then
'                                    tb.Rows(rCount).Cells(0).Paragraphs(1).AppendLine()
'                                End If

'                                tb.Rows(rCount).Cells(0).Paragraphs(1).Append(i.ToString + ". " + r(APP210303_Model.Column.QNO_DESC).ToString).FontSize(14)

'                                If r(APP210303_Model.Column.TOPIC_ANSWER).ToString().Length > 0 Then
'                                    tb.Rows(rCount).Cells(0).Paragraphs(1).Append(r(APP210303_Model.Column.TOPIC_ANSWER).ToString).FontSize(14)
'                                End If

'                                i += 1
'                            End If
'                        Next
'                        rCount += 1
'                    Next

'                    'Replace Tags For Remove
'                    For i As Integer = 0 To tb.Rows.Count - 1
'                        tb.Rows(i).Cells(0).Paragraphs(1).ReplaceText(APP210303_Model.Report.Text_G, "")
'                    Next

'                    '預擬審查委員會議總評意見
'                    document.Tables(0).Rows(3).Cells(1).Paragraphs.First().ReplaceText(APP210303_Model.Report.Text_I, preAns)

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' Query評分表總分
'        ''' </summary>
'        Private Function GetSUM(ByVal caseNo As String) As DataTable
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim ctSumMark As CtAPPL024 = New CtAPPL024(_dbManager, _logUtil)
'                ctSumMark.CASE_NO = caseNo
'                ctSumMark.CASE_CODE = caseNo.Substring(0, 4)
'                Dim dtSumMark As DataTable = Me.BindDDFormat(ctSumMark.DoQuerySumMARK(), FormatType.Report)

'                Return dtSumMark

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' Query申請項目 SYST010
'        ''' </summary>
'        Private Function GetAPPLY_ITEM(ByVal caseCode As String) As DataTable
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim ctST010 As CtSYST010 = New CtSYST010(_dbManager, _logUtil)
'                ctST010.SYS_KEY = "CASE_CODE"
'                ctST010.SYS_ID = caseCode
'                Dim dtST010 As DataTable = ctST010.DoQuery()

'                Return dtST010

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 格式化字串資訊
'        ''' 資料: APPL024 CHECKBOX LIST
'        ''' </summary>
'        Private Function GetFormatString_QNO_DESC(ByVal caseNo As String, ByVal caseCode As String, ByVal acnt As String) As String
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim dt As DataTable = GetCheckList(caseNo, caseCode, acnt)
'                Dim str As String = ""
'                Dim i As Integer = 1
'                Dim newLine As String = "<br />"

'                If dt.Rows.Count > 0 Then
'                    For Each row As DataRow In dt.Rows
'                        If str.Length > 0 Then
'                            str += newLine
'                        End If

'                        str += i.ToString + ". " + row(APP210303_Model.Column.QNO_DESC).ToString()

'                        If row(APP210303_Model.Column.TOPIC_ANSWER).ToString().Length > 0 Then
'                            str += newLine + row(APP210303_Model.Column.TOPIC_ANSWER).ToString()
'                        End If

'                        i += 1

'                    Next
'                End If

'                Return str

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 取得APPL024(評分表)所勾選的CHECKBOX題目清單
'        ''' </summary>
'        Private Function GetCheckList(ByVal caseNo As String, ByVal caseCode As String, ByVal acnt As String) As DataTable
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim dt As DataTable

'                Dim ent As ENT_APPL024 = New ENT_APPL024(_dbManager, _logUtil)
'                ent.CASE_NO = caseNo
'                ent.CASE_CODE = caseCode
'                ent.ACNT = acnt
'                ent.SUBJECT_TYPE = "90','91"
'                ent.OrderBys = " APP0004.QNO "
'                dt = ent.QueryReport()

'                Return dt

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 取得APPL023(形式審查意見)資料
'        ''' </summary>
'        Private Function GetAPPL023(ByVal caseNo As String) As DataTable
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim dt As DataTable
'                Dim ct As CtAPPL023 = New CtAPPL023(_dbManager, _logUtil)
'                ct.CASE_NO = caseNo
'                ct.TOPIC_SEQ = APP210303_Model.Column.Key.PRE_ANSWER
'                dt = ct.DoQuery()

'                Return dt

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'#End Region

'#Region "PreMeeting"
'        Public Function PreMeeting(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String, ByVal groupCode As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[會前會首頁資料]"

'                '=== 建立檔案 ===
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & "PreMeetingTemplete" & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '=== 撈資料 ===           
'                'Query公司基本資料
'                Dim dt As DataTable
'                Dim ctrl As CtAPP2030 = New CtAPP2030(_dbManager, _logUtil)
'                ctrl.GROUP_CODE = groupCode
'                ctrl.OrderBys = " M.CASE_NO "
'                dt = ctrl.DoQueryCaseInfo()

'                If dt.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                'Query會議所包含案件的筆數
'                Dim meetingCount As String = dt.Rows.Count

'                'Query會議所包含案件中，不重複的APP1170.CHANNEL_NAME筆數
'                ctrl.GROUP_CODE = groupCode
'                ctrl.OrderBys = " M.CASE_NO "
'                Dim dt1170 As DataTable = ctrl.DoQueryCaseInfo1170()
'                Dim count1170 As String = dt1170.Rows.Count

'                '會議所包含案件中， 不重複的APP1010.APP_PERSON_NM
'                ctrl.GROUP_CODE = groupCode
'                ctrl.OrderBys = " M.CASE_NO "
'                Dim dt1010 As DataTable = ctrl.DoQueryCaseInfo1010()
'                Dim count1010 As String = dt1010.Rows.Count

'                'If dt案件.Rows.Count <= 0 Then
'                '    JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                '    Return ""
'                'End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tNum As Integer = 0
'                    Dim rNum As Integer = 1
'                    Dim tb1 As Novacode.Table = document.Tables(tNum)
'                    Dim tr1 = tb1.Rows(rNum)
'                    'Dim tailRow = tb1.Rows(2)

'                    'Insert Row
'                    For i As Integer = 0 To dt.Rows.Count - 1
'                        tb1.InsertRow(tr1, 2)
'                    Next

'                    'Remove Sample Row
'                    tb1.RemoveRow(1)

'                    '標題名稱置換
'                    document.ReplaceText(PREMETTING_Model.ReportTag.A, dt.Rows(0)(PREMETTING_Model.Column.MEETING_TYPE_NM).ToString)
'                    document.ReplaceText(PREMETTING_Model.ReportTag.B, dt.Rows(0)(PREMETTING_Model.Column.APP_PERSON_NM).ToString)
'                    document.ReplaceText(PREMETTING_Model.ReportTag.C, dt.Rows.Count.ToString)
'                    document.ReplaceText(PREMETTING_Model.ReportTag.D, count1170)
'                    document.ReplaceText(PREMETTING_Model.ReportTag.E, count1010)

'                    'Footer
'                    'If Not document.Footers.odd Is Nothing Then
'                    '    document.Footers.odd.ReplaceText("○○", sysCName)
'                    'End If

'                    '項目置換
'                    Dim iCount As Integer = 1
'                    'For tbCount As Integer = 0 To document.Tables.Count - 1
'                    'For Each dr As DataRow In dt.Rows
'                    For i As Integer = rNum To tb1.Rows.Count - 1
'                        For j As Integer = 0 To tb1.Rows(i).Cells.Count - 1
'                            For k As Integer = 0 To tb1.Rows(i).Cells(j).Paragraphs.Count - 1
'                                '編號
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_0, iCount.ToString)
'                                '公司名稱
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_1, dt.Rows(i - 1)(PREMETTING_Model.Column.APP_PERSON_NM).ToString)
'                                '頻道名稱
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_2, dt.Rows(i - 1)(PREMETTING_Model.Column.CHANNEL_NAME).ToString)
'                                '事業類別
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_3, dt.Rows(i - 1)(PREMETTING_Model.Column.ORG_TYPE1_NM).ToString)
'                                '頻道節目屬性
'                                Dim channelAttr As String = GetChangelFlagName(dt.Rows(i - 1))
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_4, channelAttr)
'                                '發函改進次數
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_5, "")
'                                '發函改進態樣
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_6, "")
'                                '核處次數
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_7, "")
'                                '核處態樣
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_8, "")
'                                '上架方式
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_9, GetPlatformType(dt.Rows(i - 1)(PREMETTING_Model.Column.CASE_NO).ToString))
'                                '頁碼
'                                tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText(PREMETTING_Model.ReportTag.F_10, "")
'                            Next
'                        Next
'                        iCount += 1
'                    Next

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 組頻道類型/屬性字串
'        ''' </summary>
'        Private Function GetChangelFlagName(ByVal row As DataRow) As String
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim channelStr As String = ""

'                If row("LOCK_CHANNEL_FLAG").ToString = "Y" Then
'                    channelStr += "限制級鎖碼頻道"
'                End If

'                If row("CH_FLAG1").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "新聞"
'                End If

'                If row("CH_FLAG2").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "財經新聞"
'                End If

'                If row("CH_FLAG3").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "財經股市"
'                End If
'                If row("CH_FLAG4").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "兒少"
'                End If
'                If row("CH_FLAG5").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "戲劇"
'                End If
'                If row("CH_FLAG6").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "電影"
'                End If

'                If row("CH_FLAG7").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "體育"
'                End If
'                If row("CH_FLAG8").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "教育文化"
'                End If
'                If row("CH_FLAG9").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "音樂"
'                End If
'                If row("CH_FLAG10").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "宗教"
'                End If
'                If row("CH_FLAG1").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "新聞"
'                End If
'                If row("CH_FLAG11").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "綜合"
'                End If
'                If row("CH_FLAG12").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "地方頻道"
'                End If
'                If row("CH_FLAG13").ToString = "Y" Then
'                    If channelStr.Length > 0 Then
'                        channelStr += "、"
'                    End If
'                    channelStr += "其他"
'                    If row("CH_FLAG13_DESC").ToString.Length > 0 Then
'                        channelStr += "-" + row("CH_FLAG13_DESC").ToString
'                    End If
'                End If

'                Return channelStr

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        ''' <summary>
'        ''' 組上架類型字串
'        ''' </summary>
'        Private Function GetPlatformType(ByVal caseNo As String) As String
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim platformStr As String = ""

'                Dim has_chtype_1_ANALOGY_CHANNEL_LOCATION As Boolean = False
'                Dim has_chtype_1_DIGIT_CHANNEL_LOCATION As Boolean = False
'                Dim has_chtype_2 As Boolean = False
'                Dim has_chtype_3 As Boolean = False
'                Const chType_1_ANALOGY As String = "有線類比"
'                Const chType_1_DIGIT As String = "有線數位"
'                Const chType_2 As String = "其他收視聽播送平臺"
'                Const chType_3 As String = "直播衛星"

'                If caseNo.Length > 0 Then
'                    Dim ct As CtAPP1180 = New CtAPP1180(_dbManager, _logUtil)
'                    ct.CASE_NO = caseNo
'                    Dim dt As DataTable = ct.DoQuery()

'                    If dt.Rows.Count > 0 Then

'                        For Each row As DataRow In dt.Rows
'                            If row(PREMETTING_Model.Column.CHSYS_TYPE).ToString = 1 Then
'                                If row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "" And
'                                row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "0" Then
'                                    'platformStr += "有線類比"
'                                    has_chtype_1_ANALOGY_CHANNEL_LOCATION = True
'                                End If

'                                If row(PREMETTING_Model.Column.DIGIT_CHANNEL_LOCATION).ToString <> "" And
'                                row(PREMETTING_Model.Column.DIGIT_CHANNEL_LOCATION).ToString <> "0" Then
'                                    'platformStr += "有線數位"
'                                    has_chtype_1_DIGIT_CHANNEL_LOCATION = True
'                                End If
'                            End If

'                            If row(PREMETTING_Model.Column.CHSYS_TYPE).ToString = 2 Then
'                                'platformStr += "其他收視聽播送平臺"
'                                has_chtype_2 = True
'                                'If row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "" And
'                                'row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "0" Then
'                                '    If platformStr.Length > 0 Then
'                                '        platformStr += ","
'                                '    End If
'                                '    platformStr += "有線數位"
'                                'End If
'                            End If

'                            If row(PREMETTING_Model.Column.CHSYS_TYPE).ToString = 3 Then
'                                has_chtype_3 = True
'                                'platformStr += "直播衛星"
'                                'If row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "" And
'                                'row(PREMETTING_Model.Column.ANALOGY_CHANNEL_LOCATION).ToString <> "0" Then
'                                '    If platformStr.Length > 0 Then
'                                '        platformStr += ","
'                                '    End If
'                                '    platformStr += "直播衛星"
'                                'End If
'                            End If

'                        Next
'                    End If

'                    'Dim has_chtype_1_ANALOGY_CHANNEL_LOCATION As Boolean = False
'                    'Dim has_chtype_1_DIGIT_CHANNEL_LOCATION As Boolean = False
'                    'Dim has_chtype_2 As Boolean = False
'                    'Dim has_chtype_3 As Boolean = False
'                    'platformStr
'                    'Const chType_1_ANALOGY As String = "有線類比"
'                    'Const chType_1_DIGIT As String = "有線數位"
'                    'Const chType_2 As String = "其他收視聽播送平臺"
'                    'Const chType_3 As String = "直播衛星"


'                    If has_chtype_1_ANALOGY_CHANNEL_LOCATION = True Then
'                        platformStr = chType_1_ANALOGY
'                    End If

'                    If has_chtype_1_DIGIT_CHANNEL_LOCATION = True Then
'                        If platformStr.Length = 0 Then
'                            platformStr = chType_1_DIGIT
'                        Else
'                            platformStr += "、" + chType_1_DIGIT
'                        End If
'                    End If

'                    If has_chtype_2 = True Then
'                        If platformStr.Length = 0 Then
'                            platformStr = chType_2
'                        Else
'                            platformStr += "、" + chType_2
'                        End If
'                    End If

'                    If has_chtype_3 = True Then
'                        If platformStr.Length = 0 Then
'                            platformStr = chType_3
'                        Else
'                            platformStr += "、" + chType_3
'                        End If
'                    End If

'                End If

'                Return platformStr

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP210301"
'        Public Function APP210301(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[形式審查意見]"

'                '=== 建立檔案 ===
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"

'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '=== 撈資料 ===
'                'QNO為數字的資料
'                Dim ent As ENT_APPL023 = New ENT_APPL023(_dbManager, _logUtil)
'                ent.CASE_NO = caseNo
'                ent.CASE_CODE = caseNo.Substring(0, 4)
'                Dim dt案件 As DataTable = Me.BindDDFormat(ent.QueryReport(), FormatType.Report)
'                _logUtil.Logger.Append("dt案件.Rows.Count.ToString = " + dt案件.Rows.Count.ToString)
'                'QNO為PRE_ANSWER
'                ent.CASE_NO = caseNo
'                ent.CASE_CODE = caseNo.Substring(0, 4)
'                ent.TOPIC_SEQ = APP210301_Model.Column.PRE_ANSWER
'                Dim dt_PRE_ANSWER As DataTable = Me.BindDDFormat(ent.Query(), FormatType.Report)
'                _logUtil.Logger.Append("dt_PRE_ANSWER.Rows.Count.ToString = " + dt_PRE_ANSWER.Rows.Count.ToString)
'                '撈標題資料
'                Dim ctS010 As CtSYST010 = New CtSYST010(_dbManager, _logUtil)
'                ctS010.SYS_KEY = "CASE_CODE"
'                ctS010.SYS_ID = caseNo.Substring(0, 4)
'                Dim dtS010 As DataTable = ctS010.DoQuery
'                _logUtil.Logger.Append("dtS010.Rows.Count.ToString = " + dtS010.Rows.Count.ToString)

'                Dim A_sys_rsv1 As String = ""
'                If dtS010.Rows.Count > 0 Then
'                    A_sys_rsv1 = dtS010.Rows(0)(APP210301_Model.Column.SYS_RSV1).ToString
'                End If

'                Dim ct1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ct1010.CASE_NO = caseNo
'                Dim dt1010 As DataTable = ct1010.DoQuery
'                Dim B_txtname As String = ""

'                _logUtil.Logger.Append("dt1010.Rows.Count.ToString = " + dt1010.Rows.Count.ToString)

'                If dt1010.Rows.Count > 0 Then
'                    If dt1010.Rows(0)(APP210301_Model.Column.SYS_CNAME).ToString.Length = 0 Then
'                        B_txtname = dt1010.Rows(0)(APP210301_Model.Column.APP_PERSON_NM).ToString
'                    Else
'                        B_txtname = dt1010.Rows(0)(APP210301_Model.Column.SYS_CNAME).ToString + "(" + dt1010.Rows(0)(APP210301_Model.Column.APP_PERSON_NM).ToString + ")"
'                    End If
'                End If

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    'Return ""
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tailRow = tb.Rows(2)

'                    '標題名稱置換
'                    document.ReplaceText(APP210301_Model.Report.Text_A, A_sys_rsv1)
'                    document.ReplaceText(APP210301_Model.Report.Text_B, B_txtname)

'                    Dim aryCount As New ArrayList
'                    For Each r As DataRow In dt案件.Rows
'                        aryCount.Add(r)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設頭兩列，亦即刪除原本範本中的列
'                    tb.RemoveRow(1)
'                    tb.RemoveRow(1)
'                    '重新插入列，排版-將原範本中第二列重新插入，使其可以在最底
'                    tb.InsertRow(tailRow)

'                    '塞資料
'                    Dim _rowCount As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        tb.Rows(_rowCount).Cells(0).Paragraphs.First().ReplaceText(APP210301_Model.Report.Text_C, dr(APP210301_Model.Column.QNO_DESC).ToString())
'                        tb.Rows(_rowCount).Cells(1).Paragraphs.First().ReplaceText(APP210301_Model.Report.Text_D, dr(APP210301_Model.Column.TOPIC_ANSWER).ToString())
'                        tb.Rows(_rowCount).Cells(2).Paragraphs.First().ReplaceText(APP210301_Model.Report.Text_E, dr(APP210301_Model.Column.MARK).ToString())
'                        _rowCount += 1
'                    Next

'                    If dt_PRE_ANSWER.Rows.Count > 0 Then
'                        tb.Rows(_rowCount).Cells(1).Paragraphs.First().ReplaceText(APP210301_Model.Report.Text_F, dt_PRE_ANSWER.Rows(0)(APP210301_Model.Column.TOPIC_ANSWER).ToString())
'                    End If

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel
'                'Catch ex As Exception
'                '    _logUtil.Logger.Append("[REPORT ERROR] = " + ex.ToString)
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120423"
'        Public Function APP120423(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[頻道基本資料]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                Dim docTemplate As String = ""
'                If IsDisplaySubComp(caseCode) Then
'                    docTemplate = pageId
'                Else
'                    docTemplate = pageId + "_v1"
'                End If

'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & docTemplate & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔
'                Dim ctrl As CtAPP1170 = New CtAPP1170(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 塞變數資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '主檔
'                Dim dr As DataRow = dt案件.Rows(0)
'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", dr("CHANNEL_NAME").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("ORG_TYPE1", If(dr("ORG_TYPE1") = "1", "■境內頻道 □境外頻道", "□境內頻道 ■境外頻道")))
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY", dr("COUNTRY").ToString()))
'                'valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", If(dr("ORG_TYPE2") = "1", "■分公司 □代理商", "□分公司 ■代理商")))
'                If IsDisplaySubComp(caseCode) Then
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", If(dr("ORG_TYPE2") = "1", "■分公司 □代理商", "□分公司 ■代理商")))
'                End If

'                valuesToFill.Fields.Add(New FieldContent("COM_NAME", dr("COM_NAME").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE", dr("EVALUATION_S_DATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE", dr("EVALUATION_E_DATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("PLAY_S_DATE", dr("PLAY_S_DATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_PAY_TYPE", If(dr("CHANNEL_PAY_TYPE").ToString() = "1", "■基本 □付費 □其他：　（請說明）", If(dr("CHANNEL_PAY_TYPE").ToString() = "2", "□基本 ■付費 □其他：　（請說明）", "□基本 □付費 ■其他：" & dr("CHANNEL_PAY_DESC")))))
'                valuesToFill.Fields.Add(New FieldContent("LOCK_CHANNEL_FLAG", If(dr("LOCK_CHANNEL_FLAG") = "Y", "■限制級鎖碼 □非限制級鎖碼", "□限制級鎖碼 ■非限制級鎖碼")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE_STANDARD_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CHARGE_STANDARD_AMT").ToString()))))
'                valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE1_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE1_AMT").ToString()))))
'                valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE2_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE2_AMT").ToString()))))
'                valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE3_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE3_AMT").ToString()))))
'                valuesToFill.Fields.Add(New FieldContent("SALES_AGENT", dr("SALES_AGENT").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("SALES_FLAG1", If(dr("SALES_FLAG1") = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SALES_FLAG2", If(dr("SALES_FLAG2") = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SALES_FLAG3", If(dr("SALES_FLAG3") = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SALES_FLAG4", If(dr("SALES_FLAG4") = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("ANALOGY_SIGN_NUMBER", dr("ANALOGY_SIGN_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("ANALOGY_SALES_RATE", dr("ANALOGY_SALES_RATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("DIGIT_SIGN_NUMBER", dr("DIGIT_SIGN_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("DIGIT_SALES_RATE", dr("DIGIT_SALES_RATE").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_F_NUMBER", dr("CHANNEL_F_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("F", If(String.IsNullOrEmpty(dr("EDIT_F_NUMBER").ToString()), "□", "■")))
'                valuesToFill.Fields.Add(New FieldContent("P", If(String.IsNullOrEmpty(dr("EDIT_P_NUMBER").ToString()), "□", "■")))
'                valuesToFill.Fields.Add(New FieldContent("EDIT_F_NUMBER", dr("EDIT_F_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("EDIT_P_NUMBER", dr("EDIT_P_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("YN_TEL", If(String.IsNullOrEmpty(dr("SERVICE_TEL").ToString()), "□", "■")))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_TEL", If(String.IsNullOrEmpty(dr("SERVICE_TEL_AREA").ToString()), dr("SERVICE_TEL").ToString(), dr("SERVICE_TEL_AREA").ToString() & "-" & dr("SERVICE_TEL").ToString())))
'                valuesToFill.Fields.Add(New FieldContent("YN_MAIL", If(String.IsNullOrEmpty(dr("SERVICE_EMAIL").ToString()), "□", "■")))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_EMAIL", dr("SERVICE_EMAIL").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("YN_OTHER", If(String.IsNullOrEmpty(dr("SERVICE_OTHER").ToString()), "□", "■")))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_OTHER", dr("SERVICE_OTHER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_CASE_NUMBER", dr("SERVICE_CASE_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_CASE_NUMBER", dr("COMPLAINT_CASE_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("YN_HANDLE_CASE_NUMBER", If(String.IsNullOrEmpty(dr("HANDLE_CASE_NUMBER").ToString()), "■無 □有", "□無 ■有")))
'                valuesToFill.Fields.Add(New FieldContent("HANDLE_CASE_NUMBER", dr("HANDLE_CASE_NUMBER").ToString()))
'                valuesToFill.Fields.Add(New FieldContent("DATA_DESC", dr("DATA_DESC").ToString()))

'                '=== 將容器資料對應到暫存檔並存檔 ===
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function IsDisplaySubComp(ByVal caseCode As String) As Boolean
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Select Case caseCode
'                    Case "AA05", "AA06", "BA05", "BA06", "CA05", "CA06"
'                        Return True
'                    Case Else
'                        Return False
'                End Select

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120324"
'        Public Function APP120324(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[上架統計表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔
'                Dim ctrl As CtAPP1180 = New CtAPP1180(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo
'                ctrl.CHSYS_TYPE = "1"
'                Dim dt1 As DataTable = ctrl.DoQuery()

'                Dim ctrl2 As CtAPP1180 = New CtAPP1180(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                ctrl2.CHSYS_TYPE = "2"
'                Dim dt2 As DataTable = ctrl2.DoQuery()

'                Dim ctrl3 As CtAPP1180 = New CtAPP1180(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                ctrl3.CHSYS_TYPE = "3"
'                Dim dt3 As DataTable = ctrl3.DoQuery()

'                Dim ctrl0 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl0.CASE_NO = caseNo
'                Dim dt0 As DataTable = ctrl0.DoQuery()


'                'If dt.Rows.Count <= 0 Then
'                '    JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                '    Exit Sub
'                'End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb1 As Novacode.Table = document.Tables(0)
'                    Dim tb2 As Novacode.Table = document.Tables(1)
'                    Dim tb3 As Novacode.Table = document.Tables(2)

'                    '表頭
'                    Select Case caseNo.Substring(0, 4)
'                        Case "CA03", "CA05" '附表六之三          
'                            document.ReplaceText("[二之三]", "六之三")
'                        Case Else '"CA04", "CA06" or others '附表二之三
'                            document.ReplaceText("[二之三]", "二之三")
'                    End Select

'                    '塞空白列---begin
'                    Dim tb1_rowStarIndex As Integer = 3
'                    Dim tb2_rowStarIndex As Integer = 2
'                    Dim tb3_rowStarIndex As Integer = 2

'                    '(一)有線廣播電視系統
'                    Dim tr1 = tb1.Rows(2)
'                    If dt1.Rows.Count > 1 Then
'                        For i As Integer = 0 To dt1.Rows.Count - 2
'                            tb1.InsertRow(tr1, tb1_rowStarIndex)
'                            tb1_rowStarIndex += 1
'                        Next
'                    End If

'                    '(二)其他供公眾收視聽之播送平臺
'                    If dt2.Rows.Count > 1 Then
'                        Dim tr2 = tb2.Rows(1)
'                        For i As Integer = 0 To dt2.Rows.Count - 2
'                            tb2.InsertRow(tr2, tb2_rowStarIndex)
'                            tb2_rowStarIndex += 1
'                        Next
'                    End If

'                    '(三)直播衛星
'                    If dt3.Rows.Count > 1 Then
'                        Dim tr3 = tb3.Rows(1)
'                        For i As Integer = 0 To dt3.Rows.Count - 2
'                            tb3.InsertRow(tr3, tb3_rowStarIndex)
'                            tb3_rowStarIndex += 1
'                        Next
'                    End If
'                    '塞空白列---End

'                    '填值---begin
'                    '(一)有線廣播電視系統
'                    Dim analogy_false As String = "□類比頻道"
'                    Dim analogy_true As String = "■類比頻道"
'                    Dim digital_false As String = "□數位頻道"
'                    Dim digital_true As String = "■數位頻道"
'                    Dim analogy_subscriber_count As Integer = 0
'                    Dim digital_subscriber_count As Integer = 0
'                    Dim analogy_count As Integer = 0
'                    Dim digital_count As Integer = 0
'                    tb1_rowStarIndex = 2
'                    Dim rownum As Integer = 1
'                    For Each dr As DataRow In dt1.Rows
'                        'tb1.Rows(tb1_rowStarIndex).Cells(0).ReplaceText("取代", dr("SYS_SORT").ToString)
'                        tb1.Rows(tb1_rowStarIndex).Cells(0).ReplaceText("取代", rownum.ToString)
'                        tb1.Rows(tb1_rowStarIndex).Cells(1).ReplaceText("取代", dr("AREA").ToString)
'                        tb1.Rows(tb1_rowStarIndex).Cells(2).ReplaceText("取代", dr("CH_NAME").ToString)
'                        If dr("ANALOGY_SUBSCRIBER_NUMBER").ToString() <> "0" Or dr("ANALOGY_CHANNEL_LOCATION").ToString() <> "" Then
'                            tb1.Rows(tb1_rowStarIndex).Cells(3).ReplaceText("取代", analogy_true)
'                            digital_count += 1
'                        Else
'                            tb1.Rows(tb1_rowStarIndex).Cells(3).ReplaceText("取代", analogy_false)
'                        End If
'                        tb1.Rows(tb1_rowStarIndex).Cells(4).ReplaceText("取代", dr("ANALOGY_CHANNEL_LOCATION").ToString)
'                        tb1.Rows(tb1_rowStarIndex).Cells(5).ReplaceText("取代", dr("ANALOGY_SUBSCRIBER_NUMBER").ToString)
'                        If dr("DIGIT_SUBSCRIBER_NUMBER").ToString() <> "0" Or dr("DIGIT_CHANNEL_LOCATION").ToString() <> "" Then
'                            tb1.Rows(tb1_rowStarIndex).Cells(6).ReplaceText("取代", digital_true)
'                            analogy_count += 1
'                        Else
'                            tb1.Rows(tb1_rowStarIndex).Cells(6).ReplaceText("取代", digital_false)
'                        End If
'                        tb1.Rows(tb1_rowStarIndex).Cells(7).ReplaceText("取代", dr("DIGIT_CHANNEL_LOCATION").ToString)
'                        tb1.Rows(tb1_rowStarIndex).Cells(8).ReplaceText("取代", dr("DIGIT_SUBSCRIBER_NUMBER").ToString)

'                        '類比訂戶數合計
'                        analogy_subscriber_count = analogy_subscriber_count + ToDecimal(dr("ANALOGY_SUBSCRIBER_NUMBER").ToString)
'                        '數位訂戶數合計
'                        digital_subscriber_count = digital_subscriber_count + ToDecimal(dr("DIGIT_SUBSCRIBER_NUMBER").ToString)

'                        tb1_rowStarIndex += 1
'                        rownum += 1
'                    Next

'                    '合計
'                    '類比訂戶數合計
'                    tb1.Rows(tb1_rowStarIndex).Cells(2).ReplaceText("[類比訂戶數合計]", analogy_subscriber_count)
'                    '數位訂戶數合計
'                    tb1.Rows(tb1_rowStarIndex).Cells(3).ReplaceText("[數位訂戶數合計]", digital_subscriber_count)
'                    '類比平臺簽約家數
'                    Dim analogy_contract_count As Integer = ToDecimal(dt0.Rows(0)("CATV_ANALOGY_SIGN").ToString)
'                    tb1.Rows(tb1_rowStarIndex + 1).Cells(0).ReplaceText("[類比平臺簽約家數]", analogy_contract_count)
'                    '數位平臺簽約家數
'                    Dim digital_contract_count As Integer = ToDecimal(dt0.Rows(0)("CATV_DIGIT_SIGN").ToString)
'                    tb1.Rows(tb1_rowStarIndex + 1).Cells(0).ReplaceText("[數位平臺簽約家數]", digital_contract_count)
'                    '類比平臺上架率
'                    Dim analogy_opened_percent As Integer = CaculatePercent(analogy_count, analogy_contract_count)
'                    tb1.Rows(tb1_rowStarIndex + 1).Cells(0).ReplaceText("[類比平臺上架率]", analogy_opened_percent)
'                    '數位平臺上架率
'                    Dim digital_opened_percent As Integer = CaculatePercent(digital_count, digital_contract_count)
'                    tb1.Rows(tb1_rowStarIndex + 1).Cells(0).ReplaceText("[數位平臺上架率]", digital_opened_percent)

'                    '(二)其他供公眾收視聽之播送平臺
'                    tb2_rowStarIndex = 1
'                    Dim channel_opened As String = "■"
'                    Dim channel_not_opened As String = "□"
'                    Dim platform_subscriber_count As Integer = 0
'                    Dim platform_contract_count As Integer = dt2.Rows.Count
'                    For Each dr As DataRow In dt2.Rows
'                        tb2.Rows(tb2_rowStarIndex).Cells(0).ReplaceText("取代", dr("SYS_SORT").ToString)
'                        tb2.Rows(tb2_rowStarIndex).Cells(1).ReplaceText("取代", dr("CH_NAME").ToString)
'                        tb2.Rows(tb2_rowStarIndex).Cells(2).ReplaceText("取代", channel_opened)
'                        tb2.Rows(tb2_rowStarIndex).Cells(3).ReplaceText("取代", dr("CHANNEL_LOCATION").ToString)
'                        tb2.Rows(tb2_rowStarIndex).Cells(4).ReplaceText("取代", dr("SUBSCRIBER_NUMBER").ToString)

'                        platform_subscriber_count = platform_subscriber_count + ToDecimal(dr("SUBSCRIBER_NUMBER").ToString)

'                        tb2_rowStarIndex += 1
'                    Next

'                    '合計
'                    '播送平臺訂戶數
'                    tb2.Rows(tb2_rowStarIndex).Cells(0).ReplaceText("[播送平臺訂戶數]", platform_subscriber_count)
'                    '播送平臺簽約數
'                    tb2.Rows(tb2_rowStarIndex).Cells(0).ReplaceText("[播送平臺簽約家數]", platform_contract_count)

'                    '(三)直播衛星
'                    tb3_rowStarIndex = 1
'                    Dim satellite_subscriber_count As Integer = 0
'                    Dim satellite_contract_count As Integer = dt3.Rows.Count
'                    For Each dr As DataRow In dt3.Rows
'                        tb3.Rows(tb3_rowStarIndex).Cells(0).ReplaceText("取代", dr("SYS_SORT").ToString)
'                        tb3.Rows(tb3_rowStarIndex).Cells(1).ReplaceText("取代", dr("CH_NAME").ToString)
'                        tb3.Rows(tb3_rowStarIndex).Cells(2).ReplaceText("取代", channel_opened)
'                        tb3.Rows(tb3_rowStarIndex).Cells(3).ReplaceText("取代", dr("CHANNEL_LOCATION").ToString)
'                        tb3.Rows(tb3_rowStarIndex).Cells(4).ReplaceText("取代", dr("SUBSCRIBER_NUMBER").ToString)

'                        satellite_subscriber_count = satellite_subscriber_count + ToDecimal(dr("SUBSCRIBER_NUMBER").ToString)

'                        tb3_rowStarIndex += 1
'                    Next

'                    '合計
'                    '播送平臺訂戶數
'                    tb3.Rows(tb3_rowStarIndex).Cells(0).ReplaceText("[直播衛星訂戶數]", satellite_subscriber_count)
'                    '直播衛星平臺簽約數
'                    tb3.Rows(tb3_rowStarIndex).Cells(0).ReplaceText("[直播衛星平臺簽約數]", satellite_contract_count)
'                    '填值---End

'                    '將沒填的預設欄位取代修正為空值
'                    For Each row As Row In tb1.Rows
'                        For Each cell As Cell In row.Cells
'                            cell.ReplaceText("取代", "")
'                            cell.ReplaceText("[類比訂戶數合計]", "")
'                            cell.ReplaceText("[數位訂戶數合計]", "")
'                            cell.ReplaceText("[類比平臺簽約家數]", "")
'                            cell.ReplaceText("[數位平臺簽約家數]", "")
'                            cell.ReplaceText("[類比平臺上架率]", "")
'                            cell.ReplaceText("[數位平臺上架率]", "")
'                        Next
'                    Next
'                    For Each row As Row In tb2.Rows
'                        For Each cell As Cell In row.Cells
'                            cell.ReplaceText("取代", "")
'                            cell.ReplaceText("[播送平臺訂戶數]", "")
'                            cell.ReplaceText("[播送平臺簽約家數]", "")
'                        Next
'                    Next
'                    For Each row As Row In tb3.Rows
'                        For Each cell As Cell In row.Cells
'                            cell.ReplaceText("取代", "")
'                            cell.ReplaceText("[直播衛星訂戶數]", "")
'                            cell.ReplaceText("[直播衛星平臺簽約數]", "")
'                        Next
'                    Next

'                    document.Save()

'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function CaculatePercent(a As Integer, b As Integer) As Integer
'            If a = 0 Or b = 0 Then
'                Return 0
'            Else
'                Return (a / b) * 100
'            End If
'        End Function
'#End Region

'#Region "APP120323"
'        Public Function APP120323(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[頻道基本資料]"
'                Dim caseCode As String = caseNo.Substring(0, 4)

'                '範本檔
'                Dim isSub As Boolean = False
'                '是否有需要分公司欄位
'                If IsDisplaySubComp(caseCode) Then
'                    isSub = True
'                Else
'                    isSub = False
'                End If

'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔
'                Dim ctrl As CtAPP1170 = New CtAPP1170(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '節目比例
'                Dim ctrl1420 As CtAPP1420 = New CtAPP1420(_dbManager, _logUtil)
'                ctrl1420.CASE_NO = caseNo
'                Dim dt1420 As DataTable = ctrl1420.DoQuery()

'                '=== 塞變數資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()


'                '主檔
'                Dim dr As DataRow = dt案件.Rows(0)

'                Using document As DocX = DocX.Load(tempfilename)

'                    Dim rNum As Integer = 0
'                    Dim tNum_Main As Integer = 0
'                    _logUtil.Logger.Append("document.Tables.Count=" + document.Tables.Count.ToString + ", tNum_Main=" + tNum_Main.ToString)
'                    Dim tb1 As Novacode.Table = document.Tables(tNum_Main)
'                    '置換內容
'                    For i As Integer = rNum To tb1.Rows.Count - 1
'                        For j As Integer = 0 To tb1.Rows(i).Cells.Count - 1
'                            For k As Integer = 0 To tb1.Rows(i).Cells(j).Paragraphs.Count - 1
'                                If dr IsNot Nothing Then
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CHANNEL_NAME]", dr("CHANNEL_NAME").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[ORG_TYPE1]", If(dr("ORG_TYPE1") = "1", "■境內頻道 □境外頻道", "□境內頻道 ■境外頻道"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[COUNTRY]", dr("COUNTRY").ToString())

'                                    If isSub Then
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[ORG_TYPE2]", If(dr("ORG_TYPE2") = "1", "           ■分公司 □代理商", "           □分公司 ■代理商"))
'                                    Else
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[ORG_TYPE2]", "")
'                                    End If

'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[COM_NAME]", dr("COM_NAME").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[EVALUATION_S_DATE]", dr("EVALUATION_S_DATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[EVALUATION_E_DATE]", dr("EVALUATION_E_DATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[LICENSE_S_DATE]", dr("LICENSE_S_DATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[LICENSE_E_DATE]", dr("LICENSE_E_DATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[PLAY_S_DATE", dr("PLAY_S_DATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CHANNEL_PAY_TYPE]", If(dr("CHANNEL_PAY_TYPE").ToString() = "1", "■基本 □付費 □其他：________（請說明）", If(dr("CHANNEL_PAY_TYPE").ToString() = "2", "□基本 ■付費 □其他：________（請說明）", If(dr("CHANNEL_PAY_TYPE").ToString() = "999", "□基本 □付費 ■其他：" & dr("CHANNEL_PAY_DESC"), "□基本 □付費 □其他：________（請說明）"))))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[LOCK_CHANNEL_FLAG]", If(dr("LOCK_CHANNEL_FLAG") = "Y", "■限制級鎖碼 □非限制級鎖碼", "□限制級鎖碼 ■非限制級鎖碼"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG1]", If(dr("CH_FLAG1") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG2]", If(dr("CH_FLAG2") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG3]", If(dr("CH_FLAG3") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG4]", If(dr("CH_FLAG4") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG5]", If(dr("CH_FLAG5") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG6]", If(dr("CH_FLAG6") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG7]", If(dr("CH_FLAG7") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG8]", If(dr("CH_FLAG8") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG9]", If(dr("CH_FLAG9") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG10]", If(dr("CH_FLAG10") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG11]", If(dr("CH_FLAG11") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG12]", If(dr("CH_FLAG12") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG13]", If(dr("CH_FLAG13") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_FLAG13_DESC]", If(String.IsNullOrEmpty(dr("CH_FLAG13_DESC").ToString()), "________（請說明）", dr("CH_FLAG13_DESC").ToString()))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CHARGE_STANDARD_AMT]", String.Format("{0:#,#;0;0}", ToDecimal(dr("CHARGE_STANDARD_AMT").ToString())))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_AUTHORIZE1_AMT]", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE1_AMT").ToString())))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_AUTHORIZE2_AMT]", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE2_AMT").ToString())))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CH_AUTHORIZE3_AMT]", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE3_AMT").ToString())))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SALES_AGENT]", dr("SALES_AGENT").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SALES_FLAG1]", If(dr("SALES_FLAG1") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SALES_FLAG2]", If(dr("SALES_FLAG2") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SALES_FLAG3]", If(dr("SALES_FLAG3") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SALES_FLAG4]", If(dr("SALES_FLAG4") = "Y", "■", "□"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[ANALOGY_SIGN_NUMBER]", dr("ANALOGY_SIGN_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[ANALOGY_SALES_RATE]", dr("ANALOGY_SALES_RATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[DIGIT_SIGN_NUMBER]", dr("DIGIT_SIGN_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[DIGIT_SALES_RATE]", dr("DIGIT_SALES_RATE").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[CHANNEL_F_NUMBER]", dr("CHANNEL_F_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[F]", If(String.IsNullOrEmpty(dr("EDIT_F_NUMBER").ToString()), "□", "■"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[P]", If(String.IsNullOrEmpty(dr("EDIT_P_NUMBER").ToString()), "□", "■"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[EDIT_F_NUMBER]", dr("EDIT_F_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[EDIT_P_NUMBER]", dr("EDIT_P_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[YN_TEL]", If(String.IsNullOrEmpty(dr("SERVICE_TEL").ToString()), "□", "■"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SERVICE_TEL]", If(String.IsNullOrEmpty(dr("SERVICE_TEL_AREA").ToString()), dr("SERVICE_TEL").ToString(), dr("SERVICE_TEL_AREA").ToString() & "-" & dr("SERVICE_TEL").ToString()))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[YN_MAIL]", If(String.IsNullOrEmpty(dr("SERVICE_EMAIL").ToString()), "□", "■"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SERVICE_EMAIL]", dr("SERVICE_EMAIL").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[YN_OTHER]", If(String.IsNullOrEmpty(dr("SERVICE_OTHER").ToString()), "□", "■"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SERVICE_OTHER]", dr("SERVICE_OTHER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[SERVICE_CASE_NUMBER]", dr("SERVICE_CASE_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[COMPLAINT_CASE_NUMBER]", dr("COMPLAINT_CASE_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[YN_HANDLE_CASE_NUMBER]", If(String.IsNullOrEmpty(dr("HANDLE_CASE_NUMBER").ToString()), "■無 □有", "□無 ■有"))
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[HANDLE_CASE_NUMBER]", dr("HANDLE_CASE_NUMBER").ToString())
'                                    tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[DATA_DESC]", dr("DATA_DESC").ToString())

'                                    '節目比例
'                                    For Each row As DataRow In dt1420.Rows
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[NEW_RATE" + row("YEAR").ToString() + "]", row("NEW_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[FIRST_RATE" + row("YEAR").ToString() + "]", row("FIRST_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[REPLAY_RATE" + row("YEAR").ToString() + "]", row("REPLAY_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[INSOURCE_RATE" + row("YEAR").ToString() + "]", row("INSOURCE_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[OUTSOURCE_RATE" + row("YEAR").ToString() + "]", row("OUTSOURCE_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[INTERNAL_RATE" + row("YEAR").ToString() + "]", row("INTERNAL_RATE").ToString())
'                                        tb1.Rows(i).Cells(j).Paragraphs(k).ReplaceText("[EXTERNAL_RATE" + row("YEAR").ToString() + "]", row("EXTERNAL_RATE").ToString())
'                                    Next

'                                End If
'                            Next
'                        Next
'                    Next

'                    'Old Report---begin
'                    '因產出的檔案在Merge時，發生若有任何標籤，會造成表格不見(其他報表沒這現象)
'                    'valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", dr("CHANNEL_NAME").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("ORG_TYPE1", If(dr("ORG_TYPE1") = "1", "■境內頻道 □境外頻道", "□境內頻道 ■境外頻道")))
'                    'valuesToFill.Fields.Add(New FieldContent("COUNTRY", dr("COUNTRY").ToString()))
'                    ''valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", If(dr("ORG_TYPE2") = "1", "■分公司 □代理商", "□分公司 ■代理商")))
'                    'If IsDisplaySubComp(caseCode) Then
'                    '    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", If(dr("ORG_TYPE2") = "1", "■分公司 □代理商", "□分公司 ■代理商")))
'                    'End If

'                    'valuesToFill.Fields.Add(New FieldContent("COM_NAME", dr("COM_NAME").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE", dr("EVALUATION_S_DATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE", dr("EVALUATION_E_DATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("PLAY_S_DATE", dr("PLAY_S_DATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("CHANNEL_PAY_TYPE", If(dr("CHANNEL_PAY_TYPE").ToString() = "1", "■基本 □付費 □其他：________（請說明）", If(dr("CHANNEL_PAY_TYPE").ToString() = "2", "□基本 ■付費 □其他：________（請說明）", If(dr("CHANNEL_PAY_TYPE").ToString() = "999", "□基本 □付費 ■其他：" & dr("CHANNEL_PAY_DESC"), "□基本 □付費 □其他：________（請說明）"))))) '
'                    'valuesToFill.Fields.Add(New FieldContent("LOCK_CHANNEL_FLAG", If(dr("LOCK_CHANNEL_FLAG") = "Y", "■限制級鎖碼 □非限制級鎖碼", "□限制級鎖碼 ■非限制級鎖碼")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG1", If(dr("CH_FLAG1") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG2", If(dr("CH_FLAG2") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG3", If(dr("CH_FLAG3") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG4", If(dr("CH_FLAG4") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG5", If(dr("CH_FLAG5") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG6", If(dr("CH_FLAG6") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG7", If(dr("CH_FLAG7") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG8", If(dr("CH_FLAG8") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG9", If(dr("CH_FLAG9") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG10", If(dr("CH_FLAG10") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG11", If(dr("CH_FLAG11") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG12", If(dr("CH_FLAG12") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG13", If(dr("CH_FLAG13") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_FLAG13_DESC", If(String.IsNullOrEmpty(dr("CH_FLAG13_DESC").ToString()), "________（請說明）", dr("CH_FLAG13_DESC").ToString())))
'                    'valuesToFill.Fields.Add(New FieldContent("CHARGE_STANDARD_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CHARGE_STANDARD_AMT").ToString()))))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE1_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE1_AMT").ToString()))))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE2_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE2_AMT").ToString()))))
'                    'valuesToFill.Fields.Add(New FieldContent("CH_AUTHORIZE3_AMT", String.Format("{0:#,#;0;0}", ToDecimal(dr("CH_AUTHORIZE3_AMT").ToString()))))
'                    'valuesToFill.Fields.Add(New FieldContent("SALES_AGENT", dr("SALES_AGENT").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("SALES_FLAG1", If(dr("SALES_FLAG1") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("SALES_FLAG2", If(dr("SALES_FLAG2") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("SALES_FLAG3", If(dr("SALES_FLAG3") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("SALES_FLAG4", If(dr("SALES_FLAG4") = "Y", "■", "□")))
'                    'valuesToFill.Fields.Add(New FieldContent("ANALOGY_SIGN_NUMBER", dr("ANALOGY_SIGN_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("ANALOGY_SALES_RATE", dr("ANALOGY_SALES_RATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("DIGIT_SIGN_NUMBER", dr("DIGIT_SIGN_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("DIGIT_SALES_RATE", dr("DIGIT_SALES_RATE").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("CHANNEL_F_NUMBER", dr("CHANNEL_F_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("F", If(String.IsNullOrEmpty(dr("EDIT_F_NUMBER").ToString()), "□", "■")))
'                    'valuesToFill.Fields.Add(New FieldContent("P", If(String.IsNullOrEmpty(dr("EDIT_P_NUMBER").ToString()), "□", "■")))
'                    'valuesToFill.Fields.Add(New FieldContent("EDIT_F_NUMBER", dr("EDIT_F_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("EDIT_P_NUMBER", dr("EDIT_P_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("YN_TEL", If(String.IsNullOrEmpty(dr("SERVICE_TEL").ToString()), "□", "■")))
'                    'valuesToFill.Fields.Add(New FieldContent("SERVICE_TEL", If(String.IsNullOrEmpty(dr("SERVICE_TEL_AREA").ToString()), dr("SERVICE_TEL").ToString(), dr("SERVICE_TEL_AREA").ToString() & "-" & dr("SERVICE_TEL").ToString())))
'                    'valuesToFill.Fields.Add(New FieldContent("YN_MAIL", If(String.IsNullOrEmpty(dr("SERVICE_EMAIL").ToString()), "□", "■")))
'                    'valuesToFill.Fields.Add(New FieldContent("SERVICE_EMAIL", dr("SERVICE_EMAIL").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("YN_OTHER", If(String.IsNullOrEmpty(dr("SERVICE_OTHER").ToString()), "□", "■")))
'                    'valuesToFill.Fields.Add(New FieldContent("SERVICE_OTHER", dr("SERVICE_OTHER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("SERVICE_CASE_NUMBER", dr("SERVICE_CASE_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("COMPLAINT_CASE_NUMBER", dr("COMPLAINT_CASE_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("YN_HANDLE_CASE_NUMBER", If(String.IsNullOrEmpty(dr("HANDLE_CASE_NUMBER").ToString()), "■無 □有", "□無 ■有")))
'                    'valuesToFill.Fields.Add(New FieldContent("HANDLE_CASE_NUMBER", dr("HANDLE_CASE_NUMBER").ToString()))
'                    'valuesToFill.Fields.Add(New FieldContent("DATA_DESC", dr("DATA_DESC").ToString()))

'                    ''節目比例
'                    'For Each row As DataRow In dt1420.Rows
'                    '    valuesToFill.Fields.Add(New FieldContent("NEW_RATE" & row("YEAR").ToString(), row("NEW_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("FIRST_RATE" & row("YEAR").ToString(), row("FIRST_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("REPLAY_RATE" & row("YEAR").ToString(), row("REPLAY_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("INSOURCE_RATE" & row("YEAR").ToString(), row("INSOURCE_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("OUTSOURCE_RATE" & row("YEAR").ToString(), row("OUTSOURCE_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("INTERNAL_RATE" & row("YEAR").ToString(), row("INTERNAL_RATE").ToString()))
'                    '    valuesToFill.Fields.Add(New FieldContent("EXTERNAL_RATE" & row("YEAR").ToString(), row("EXTERNAL_RATE").ToString()))
'                    'Next

'                    ''=== 將容器資料對應到暫存檔並存檔 ===
'                    'Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    '    TP.FillContent(valuesToFill)
'                    '    TP.SaveChanges()

'                    document.Save()

'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120301"
'        Public Function APP120301(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[公司基本資料]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                dt案件.Columns.Add("標題").Expression = "'" + GetApplyName(caseNo.Substring(0, 4)) + "'"
'                Dim dr As DataRow = dt案件.Rows(0)
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"

'                For Each col_nm As DataColumn In dt案件.Columns
'                    If Regex.IsMatch(col_nm.ToString, "實收資本額|SB_AMT1|SB_AMT2|SB_AMT3|EMPLOYEE_NUMBER|SUBSCRIBE_NUMBER|CHANGE_STANDARD", RegexOptions.IgnoreCase) Then
'                        dr(col_nm) = String.Format("{0:#,#;0;0}", ToDecimal(dr(col_nm).ToString))
'                    End If
'                Next

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示                      
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                            End If
'                        End If
'                    Next

'                    document.Save()
'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function


'        Private Function GetApplyName(ByVal appItem As String) As String
'            Dim applyName As String = ""

'            Select Case appItem
'                Case "BA03"
'                    applyName = "節目供應事業-一般頻道"
'                Case "BA04"
'                    applyName = "節目供應事業-購物頻道"
'                Case "BA05"
'                    applyName = "境外節目供應事業-一般頻道"
'                Case "BA06"
'                    applyName = "境外節目供應事業-購物頻道"
'                Case Else
'                    applyName = "未定義"
'            End Select

'            Return applyName

'        End Function
'#End Region


'#Region "APP130801"
'        Public Function APP130801(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[基本資料]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & caseNo.Substring(0, 4) & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_CITY", SYST1010_NAME("CITY_CODE", dr("BUSINESS_CITY"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ZIP", SYST1010_NAME("CITY_CODE", dr("BUSINESS_ZIP"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ADDRESS", dr("BUSINESS_ADDRESS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_AREA_CODE", "( " & dr("BUSINESS_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_TEL", " " & dr("BUSINESS_TEL").ToString))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_AREA_CODE", "( " & dr("COMPLAINT_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_TEL", " " & dr("COMPLAINT_TEL").ToString))
'                valuesToFill.Fields.Add(New FieldContent("REPRESENTATIVE", dr("REPRESENTATIVE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_NO", dr("LICENSE_NO").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SETUP_DATE", dr("SETUP_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_A", IIf(dr("E_RESULT1").ToString = "1", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_B", IIf(dr("E_RESULT1").ToString = "2", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_C", IIf(dr("E_RESULT1").ToString = "3", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_A", IIf(dr("E_RESULT2").ToString = "1", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_B", IIf(dr("E_RESULT2").ToString = "2", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_C", IIf(dr("E_RESULT2").ToString = "3", "■", "□")))

'                If (dr("TOTAL_PROPERTY").ToString.Trim() = "") Then
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", ""))
'                Else
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", String.Format("{0:#,###}", CLng(dr("TOTAL_PROPERTY").ToString))))
'                End If

'                valuesToFill.Fields.Add(New FieldContent("WEB_URL", dr("WEB_URL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_PURPOSE", dr("SETUP_PURPOSE").ToString))

'                Dim RADIO As String() = dr("RADIO_TYPE").ToString.Split(",")

'                Dim RADIO_TYPE As String = ""
'                If (RADIO.Count > 1) Then
'                    For j As Integer = 0 To RADIO.Count - 1
'                        For i As Integer = 1 To 7
'                            If i = RADIO(j) Then
'                                Select Case i
'                                    Case 1
'                                        'RADIO_TYPE += "■AM電台 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG1", "■"))
'                                    Case 2
'                                        'RADIO_TYPE += "■FM電台 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG2", "■"))
'                                    Case 3
'                                        'RADIO_TYPE += "■公司 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG3", "■"))
'                                    Case 4
'                                        'RADIO_TYPE += "■財團法人 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG4", "■"))
'                                    Case 5
'                                        'RADIO_TYPE += "■指定用途電台 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG5", "■"))
'                                    Case 6
'                                        'RADIO_TYPE += "■全域型 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG6", "■"))
'                                    Case 7
'                                        'RADIO_TYPE += "■區域型 "
'                                        valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG7", "■"))
'                                End Select
'                            End If
'                        Next
'                    Next
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130705"
'        Public Function APP130705(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營運計畫]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    'result = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Month.ToString().PadLeft(2, "0")))


'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE1"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE1")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_S_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_S_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_S_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If

'                    If Not String.IsNullOrEmpty(Convert.ToString(dt表頭1.Rows(0)("OPERATION_E_DATE2"))) Then
'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_YEAR2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).AddYears(-1911).Year.ToString().PadLeft(3, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_MONTH2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Month.ToString().PadLeft(2, "0")))

'                        valuesToFill.Fields.Add(New FieldContent("OPERATION_E_DAY2", Convert.ToDateTime(dt表頭1.Rows(0)("OPERATION_E_DATE2")).Day.ToString().PadLeft(2, "0")))
'                    End If
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料
'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1202", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1203'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1203", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1204'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1204", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1205'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1205", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1301", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1303", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1304'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1304", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1305'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1305", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1306'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1306", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1309'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1309", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1604", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1804'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1804", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2101'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2101", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2202", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2301", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2303", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2304'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2304", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2305'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2305", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2306'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2306", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2702", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '2803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_2803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", DateUtil.ConvertFormatDate(dr1411("BASE_DATE"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                For I As Integer = 0 To 1
'                    Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                    ctrl3.CASE_NO = caseNo
'                    ctrl3.DATA_TYPE = I.ToString()
'                    ctrl3.OrderBys = "CREATE_TIME ASC"

'                    '=== 呼叫control ===
'                    Dim dt1421 As DataTable = ctrl3.DoQuery()

'                    If dt1421.Rows.Count > 0 Then
'                        Dim tableContent As TableContent
'                        If I = 0 Then
'                            tableContent = New TableContent("APP1421")
'                        Else
'                            tableContent = New TableContent("APP1421-1")
'                        End If
'                        For Each dr2 As DataRow In dt1421.Rows
'                            '塞變數資料
'                            tableContent.AddRow(
'                        New FieldContent("M_CHANNEL_NAME", Convert.ToString(dr2("CHANNEL_NAME"))),
'                         New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_NEW_HOURS", Convert.ToString(dr2("NEW_HOURS"))),
'                        New FieldContent("M_NEW_RATE", Convert.ToString(dr2("NEW_RATE"))),
'                         New FieldContent("M_FIRST_HOURS", Convert.ToString(dr2("FIRST_HOURS"))),
'                        New FieldContent("M_FIRST_RATE", Convert.ToString(dr2("FIRST_RATE"))),
'                        New FieldContent("M_REPLAY_HOURS", Convert.ToString(dr2("REPLAY_HOURS"))),
'                        New FieldContent("M_REPLAY_RATE", Convert.ToString(dr2("REPLAY_RATE"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                         New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                         New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE"))),
'                         New FieldContent("M_ITEM11_HOURS", Convert.ToString(dr2("ITEM11_HOURS"))),
'                        New FieldContent("M_ITEM11_RATE", Convert.ToString(dr2("ITEM11_RATE"))),
'                         New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM12_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM12_RATE"))),
'                         New FieldContent("M_ITEM11_HOURS", Convert.ToString(dr2("ITEM13_HOURS"))),
'                        New FieldContent("M_ITEM11_RATE", Convert.ToString(dr2("ITEM13_RATE"))),
'                         New FieldContent("M_ITEM14_HOURS", Convert.ToString(dr2("ITEM14_HOURS"))),
'                        New FieldContent("M_ITEM14_RATE", Convert.ToString(dr2("ITEM14_RATE"))),
'                         New FieldContent("M_ITEM15_HOURS", Convert.ToString(dr2("ITEM15_HOURS"))),
'                        New FieldContent("M_ITEM15_RATE", Convert.ToString(dr2("ITEM15_RATE"))),
'                       New FieldContent("M_ITEM999_HOURS", Convert.ToString(dr2("ITEM999_HOURS"))),
'                        New FieldContent("M_ITEM999_RATE", Convert.ToString(dr2("ITEM999_RATE"))),
'                       New FieldContent("M_ROC_HOURS", Convert.ToString(dr2("ROC_HOURS"))),
'                         New FieldContent("M_ROC_RATE", Convert.ToString(dr2("ROC_RATE"))),
'                       New FieldContent("M_HK_HOURS", Convert.ToString(dr2("HK_HOURS"))),
'                         New FieldContent("M_HK_RATE", Convert.ToString(dr2("HK_RATE"))),
'                       New FieldContent("M_PRC_HOURS", Convert.ToString(dr2("PRC_HOURS"))),
'                         New FieldContent("M_PRC_RATE", Convert.ToString(dr2("PRC_RATE"))),
'                       New FieldContent("M_JPN_HOURS", Convert.ToString(dr2("JPN_HOURS"))),
'                         New FieldContent("M_JPN_RATE", Convert.ToString(dr2("JPN_RATE"))),
'                       New FieldContent("M_KOR_HOURS", Convert.ToString(dr2("KOR_HOURS"))),
'                         New FieldContent("M_KOR_RATE", Convert.ToString(dr2("KOR_RATE"))),
'                       New FieldContent("M_USA_HOURS", Convert.ToString(dr2("USA_HOURS"))),
'                         New FieldContent("M_USA_RATE", Convert.ToString(dr2("USA_RATE"))),
'                       New FieldContent("M_OTH_HOURS", Convert.ToString(dr2("OTH_HOURS"))),
'                         New FieldContent("M_OTH_RATE", Convert.ToString(dr2("OTH_RATE"))),
'                       New FieldContent("M_INTERNAL_AMT", Convert.ToString(dr2("INTERNAL_AMT"))),
'                         New FieldContent("M_INTERNAL_AMT_RATE", Convert.ToString(dr2("INTERNAL_AMT_RATE"))),
'                       New FieldContent("M_EXTERNAL_AMT", Convert.ToString(dr2("EXTERNAL_AMT"))),
'                         New FieldContent("M_EXTERNAL_AMT_RATE", Convert.ToString(dr2("EXTERNAL_AMT_RATE"))),
'                       New FieldContent("M_HD_HOURS", Convert.ToString(dr2("HD_HOURS"))),
'                         New FieldContent("M_HD_RATE", Convert.ToString(dr2("HD_RATE"))),
'                       New FieldContent("M_SD_HOURS", Convert.ToString(dr2("SD_HOURS"))),
'                         New FieldContent("M_SD_RATE", Convert.ToString(dr2("SD_RATE")))
')
'                        Next

'                        '加入Table資料
'                        valuesToFill.Tables.Add(tableContent)
'                    End If
'                Next


'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}

'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"
'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                '=== 設定屬性參數 ===
'                ctrlL020.CASE_NO = caseNo

'                Dim dtL020 As DataTable = ctrlL020.DoQuery()
'                '====呼叫Control=====
'                If dtL020.Rows.Count > 0 Then
'                    Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)

'                    '=== 設定屬性參數 ===
'                    ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()

'                    Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                    If dtL010.Rows.Count > 0 Then
'                        If dt1451.Rows.Count > 0 Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                If ORG_TYPE = "C" Then
'                                    For Each Item As String In ItemCList
'                                        valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                                If ORG_TYPE = "F" Then
'                                    For Each Item As String In ItemFList
'                                        valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                            Next
'                        End If
'                    End If
'                End If

'                '===未來營運====
'                Dim ctrl14512 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl14512.CASE_NO = caseNo
'                ctrl14512.DATA_TYPE = "1"
'                ctrl14512.OrderBys = "YEAR ASC"
'                Dim dt14512 As DataTable = ctrl14512.DoQuery()

'                '=== 設定屬性參數 ===
'                ctrlL020.CASE_NO = caseNo
'                dtL020 = ctrlL020.DoQuery()

'                '====呼叫Control=====
'                If dtL020.Rows.Count > 0 Then
'                    Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)

'                    '=== 設定屬性參數 ===
'                    ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()

'                    Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                    If dtL010.Rows.Count > 0 Then
'                        If dt14512.Rows.Count > 0 Then
'                            For Year As Integer = 1 To dt14512.Rows.Count
'                                Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                If ORG_TYPE = "C" Then
'                                    For Each Item As String In ItemCList
'                                        valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                    Next
'                                End If
'                                If ORG_TYPE = "F" Then
'                                    For Each Item As String In ItemFList
'                                        valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString() + "_F", Convert.ToString(dt14512(Year - 1)(Item))))
'                                    Next
'                                End If
'                            Next
'                        End If
'                    End If
'                End If

'                '====呼叫Control=====
'                Dim ctrl1440 As CtAPP1440 = New CtAPP1440(_dbManager, _logUtil)
'                ctrl1440.CASE_NO = caseNo
'                ctrl1440.OrderBys = "CREATE_TIME ASC"
'                Dim dt1440 As DataTable = ctrl1440.Query_ItemWithName()

'                If (dt1440.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1440")

'                    For Each dr1440 As DataRow In dt1440.Rows
'                        tableContent.AddRow(
'                         New FieldContent("YEAR", Convert.ToString(dr1440("YEAR"))),
'                        New FieldContent("DECLARE_ITEM", Convert.ToString(dr1440("SYS_NAME"))),
'                        New FieldContent("DEADLINE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DEADLINE_DATE")))),
'                         New FieldContent("DECLARE_DATE", DateUtil.ConvertFormatDate(Convert.ToString(dr1440("DECLARE_DATE")))),
'                         New FieldContent("DECLARE_DESC", NewLineFormated(Convert.ToString(dr1440("DECLARE_DESC"))))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130701"
'        Public Function APP130701(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[換發執照申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))

'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_CITY", SYST1010_NAME("CITY_CODE", dr("BUSINESS_CITY"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ZIP", SYST1010_NAME("CITY_CODE", dr("BUSINESS_ZIP"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ADDRESS", dr("BUSINESS_ADDRESS").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_AREA_CODE", "( " & dr("BUSINESS_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_TEL", " " & dr("BUSINESS_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_AREA_CODE", "( " & dr("COMPLAINT_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_TEL", " " & dr("COMPLAINT_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("REPRESENTATIVE", dr("REPRESENTATIVE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_NO", dr("LICENSE_NO").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_DATE", dr("SETUP_DATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_A", IIf(dr("E_RESULT1").ToString = "1", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_B", IIf(dr("E_RESULT1").ToString = "2", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT1_C", IIf(dr("E_RESULT1").ToString = "3", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_A", IIf(dr("E_RESULT2").ToString = "1", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_B", IIf(dr("E_RESULT2").ToString = "2", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("E_RESULT2_C", IIf(dr("E_RESULT2").ToString = "3", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE1_Y", dr("OPERATION_S_DATE1").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE1_M", dr("OPERATION_S_DATE1").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE1_D", dr("OPERATION_S_DATE1").ToString.Split("/")(2)))

'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE1_Y", dr("OPERATION_E_DATE1").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE1_M", dr("OPERATION_E_DATE1").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE1_D", dr("OPERATION_E_DATE1").ToString.Split("/")(2)))

'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE2_Y", dr("OPERATION_S_DATE2").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE2_M", dr("OPERATION_S_DATE2").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_SDATE2_D", dr("OPERATION_S_DATE2").ToString.Split("/")(2)))

'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE2_Y", dr("OPERATION_E_DATE2").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE2_M", dr("OPERATION_E_DATE2").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("OPER_EDATE2_D", dr("OPERATION_E_DATE2").ToString.Split("/")(2)))

'                If (dr("TOTAL_PROPERTY").ToString.Trim() = "") Then
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", ""))
'                Else
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", String.Format("{0:#,###}", CLng(dr("TOTAL_PROPERTY").ToString))))
'                End If

'                valuesToFill.Fields.Add(New FieldContent("WEB_URL", dr("WEB_URL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_PURPOSE", dr("SETUP_PURPOSE").ToString))


'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130501"
'        Public Function APP130501(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[換照申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim ctrl2 As CtAPP1150 = New CtAPP1150(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                Dim dt頻道 As DataTable = Me.BindDDFormat(ctrl2.DoQuery(), FormatType.Edit)


'                'COPY 欄位 因為書籤有兩個
'                dt案件.Columns.Add("限制級鎖碼1")
'                dt案件.Columns.Add("非限制級鎖碼1")
'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                dr("實收資本額") = String.Format("{0:#,#;0;0}", ToDecimal(dr("實收資本額").ToString))
'                If dr("購物頻道是").ToString = "■" Then
'                    dr("限制級鎖碼1") = dr("限制級鎖碼")
'                    dr("非限制級鎖碼1") = dr("非限制級鎖碼")
'                    dr("限制級鎖碼") = "□"
'                    dr("非限制級鎖碼") = "□"
'                Else
'                    '一般頻道
'                    dr("限制級鎖碼1") = "□"
'                    dr("非限制級鎖碼1") = "□"
'                End If


'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                            End If
'                        End If
'                    Next

'                    Dim 預設筆數 As Integer = 4
'                    '頻道名稱=============================================
'                    Dim 頻道空白列第一列 = 11
'                    Dim TBL As Novacode.Table = document.Tables(0)
'                    Dim tr_channel As Novacode.Row = TBL.Rows(頻道空白列第一列) ' 頻道空白列第一列

'                    If dt頻道.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt頻道.Rows.Count - 預設筆數 - 1
'                            TBL.InsertRow(tr_channel, 頻道空白列第一列)
'                        Next
'                    End If

'                    '塞資料
'                    Dim tr As Novacode.Row
'                    For i As Integer = 0 To dt頻道.Rows.Count - 1
'                        tr = TBL.Rows(頻道空白列第一列 + i)
'                        tr.Cells(1).ReplaceText("一", (i + 1).ToString())
'                        tr.Cells(2).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_NAME").ToString())
'                        tr.Cells(3).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_TYPE_NM").ToString())
'                        tr.Cells(4).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_S_DATE").ToString())
'                        tr.Cells(5).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_E_DATE").ToString())
'                        tr.Cells(6).ReplaceText("一", dt頻道.Rows(i).Item("PUNISH_NUMBER").ToString())
'                        If (dt頻道.Rows(i).Item("PUNISH_AMT").ToString() = "") Then
'                            tr.Cells(7).ReplaceText("一", "")
'                        Else
'                            tr.Cells(7).ReplaceText("一", String.Format("{0:#,###}", CInt(dt頻道.Rows(i).Item("PUNISH_AMT").ToString)))
'                        End If
'                        tr.Cells(8).ReplaceText("一", dt頻道.Rows(i).Item("COUNTRY_TYPE_NM").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt頻道.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt頻道.Rows.Count - 1 To 預設筆數 - 1
'                            tr = TBL.Rows(頻道空白列第一列 + i)
'                            tr.Cells(1).ReplaceText("一", "")
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                            tr.Cells(6).ReplaceText("一", "")
'                            tr.Cells(7).ReplaceText("一", "")
'                            tr.Cells(8).ReplaceText("一", "")
'                        Next
'                    End If

'                    '其他書籤            
'                    document.Bookmarks("頻道數目總計").SetText(dt頻道.Rows.Count().ToString())
'                    document.Bookmarks("境內數").SetText(dt頻道.Select("COUNTRY_TYPE='1'").Length().ToString())
'                    document.Bookmarks("境外數").SetText(dt頻道.Select("COUNTRY_TYPE='2'").Length().ToString())
'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130402"
'        Public Function APP130402(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[未來6年營運計畫摘要表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1041 = New CtAPP1041(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoWordQuery, FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                'DDL
'                Dim ctrlT As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)

'                '信號傳輸方式
'                ctrlT.SYS_KEY = "TRANS_TYPE"
'                ctrlT.SYS_TYPE = "1"
'                ctrlT.USE_STATE = "1"
'                ctrlT.SYS_ID = dr("TRANS_TYPE").ToString
'                ctrlT.OrderBys = "SYS_ID"
'                Dim dt As DataTable = ctrlT.Get系統下拉資料

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME", SYST1010_NAME("TRANS_TYPE", dr("TRANS_TYPE").ToString)))
'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME_FLAG", IIf(dr("TRANS_TYPE").ToString = "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC", dr("TRANS_DESC").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC_FLAG", IIf(dr("TRANS_TYPE").ToString <> "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_BACKUP", dr("TRANS_BACKUP").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC01", dr("DESC01").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC02", dr("DESC02").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC03", dr("DESC03").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC04", dr("DESC04").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC05", dr("DESC05").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC06", dr("DESC06").ToString))

'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_Y", IIf(dr("MAKESHOE_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_N", IIf(dr("MAKESHOE_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_Y", IIf(dr("MUTICHANNEL_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_N", IIf(dr("MUTICHANNEL_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_Y", IIf(dr("SELFORG_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_N", IIf(dr("SELFORG_FLAG").ToString = "N", "■", "□")))

'                '塞Table資料(品管人員)
'                ''品管人員組織編制與職掌
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是，與" & dr1("CAREER_SHAR_NAME") & "共用", "否"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                valuesToFill.Fields.Add(New FieldContent("DESC07", dr("DESC07").ToString))

'                '各分級級別節目
'                valuesToFill.Fields.Add(New FieldContent("UNIVERSAL_RATE", dr("UNIVERSAL_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROTECTION_RATE", dr("PROTECTION_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY12_RATE", dr("SECONDARY12_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY15_RATE", dr("SECONDARY15_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LIMITATION_RATE", dr("LIMITATION_RATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC09", dr("DESC09").ToString))

'                '塞Table資料(APP1160)
'                '內部自律組織
'                Dim ctrl6 As CtAPP1160 = New CtAPP1160(_dbManager, _logUtil)
'                ctrl6.CASE_NO = caseNo
'                Dim dt委員 As DataTable = ctrl6.DoQuery()

'                If dt委員.Rows.Count > 0 Then
'                    Dim tableContent6 As TableContent = New TableContent("APP1160") 'APP1160為範本中定義的變數名
'                    For Each dr1 As DataRow In dt委員.Rows
'                        tableContent6.AddRow(
'                New FieldContent("MEMBER_NAME", dr1("MEMBER_NAME")),
'                New FieldContent("SEX_TYPE_TXT", dr1("SEX_TYPE_TXT")),
'                New FieldContent("TEACHER_TYPE_TXT", dr1("TEACHER_TYPE_TXT"))
'                )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent6)
'                End If

'                valuesToFill.Fields.Add(New FieldContent("ORG_NAME", dr("ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_FREQ", dr("MEETING_FREQ").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_PEOPLE", dr("MEETING_PEOPLE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC08", dr("DESC08").ToString))

'                '塞Table資料(APP1060)
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                    )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If

'                '塞Table資料(APP1070)
'                '員工教育訓練規畫
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                New FieldContent("FUNDING", String.Format("{0:#,###}", CInt(dr1("FUNDING"))).ToString)
'                )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", CInt(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If

'                '客服部門人力配置
'                Dim ctrl7 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl7.CASE_NO = caseNo
'                ctrl7.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl7.DoQuery()

'                If (dt客服.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_2") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent1.AddRow(
'                New FieldContent("PTTCH_FT_TXT2", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME2", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE2", dr1("JOBTITLE")),
'                New FieldContent("IS_CAREER_SHAR2", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                New FieldContent("IS_CAREER_SHAR_TXT2", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是，與" & dr1("CAREER_SHAR_NAME") & "共用", "否"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_21", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_22", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                '客服人力教育訓練之規畫
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_TRAINING_PLAN", dr("SERVICE_TRAINING_PLAN").ToString))

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130302"
'        Public Function APP130302(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[未來6年營運計畫摘要表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1041 = New CtAPP1041(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoWordQuery, FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                'DDL
'                Dim ctrlT As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)


'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))

'                '信號傳輸方式
'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME", SYST1010_NAME("TRANS_TYPE", dr("TRANS_TYPE").ToString)))
'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME_FLAG", IIf(dr("TRANS_TYPE").ToString = "1", "■"， "□")))

'                '說明
'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC", dr("TRANS_DESC").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC_FLAG", IIf(dr("TRANS_TYPE").ToString <> "1", "■"， "□")))

'                '備援傳輸方式
'                valuesToFill.Fields.Add(New FieldContent("TRANS_BACKUP", dr("TRANS_BACKUP").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC01", dr("DESC01").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC02", dr("DESC02").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC03", dr("DESC03").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC04", dr("DESC04").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC05", dr("DESC05").ToString))

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_ATTRIBUTES", dr("CHANNEL_ATTRIBUTES").ToString))
'                valuesToFill.Fields.Add(New FieldContent("FIR_SHOW_TYPE", dr("FIR_SHOW_TYPE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SEC_SHOW_TYPE", dr("SEC_SHOW_TYPE").ToString))

'                '本國製播節目(含合製/委製)及外國製播節目比例。
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY1", dr("COUNTRY1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY2", dr("COUNTRY2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY3", dr("COUNTRY3").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE1", dr("SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE2", dr("SHOW_RATE2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE1", RATE(dr("SHOW_RATE1").ToString, dr("SHOW_RATE2").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE11", dr("SHOW_RATE11").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE12", dr("SHOW_RATE12").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE11", RATE(dr("SHOW_RATE11").ToString, dr("SHOW_RATE12").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE21", dr("SHOW_RATE21").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE22", dr("SHOW_RATE22").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE21", RATE(dr("SHOW_RATE21").ToString, dr("SHOW_RATE22").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE31", dr("SHOW_RATE31").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE32", dr("SHOW_RATE32").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE31", RATE(dr("SHOW_RATE31").ToString, dr("SHOW_RATE32").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE3", dr("SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE4", dr("SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE3", RATE(dr("SHOW_RATE3").ToString, dr("SHOW_RATE4").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE13", dr("SHOW_RATE13").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE14", dr("SHOW_RATE14").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE13", RATE(dr("SHOW_RATE13").ToString, dr("SHOW_RATE14").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE23", dr("SHOW_RATE23").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE24", dr("SHOW_RATE24").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE23", RATE(dr("SHOW_RATE23").ToString, dr("SHOW_RATE24").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE33", dr("SHOW_RATE33").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE34", dr("SHOW_RATE34").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE33", RATE(dr("SHOW_RATE33").ToString, dr("SHOW_RATE34").ToString)))

'                '符合本法第八條第三項規定
'                valuesToFill.Fields.Add(New FieldContent("LAW_3_8_FLAG", IIf(dr("LAW_3_8_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("LAW_3_8N_FLAG", IIf(dr("LAW_3_8_FLAG").ToString = "N", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("LAW_DESC", dr("LAW_DESC").ToString))

'                '頻道自製及外購節目比例。
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE1", dr("S_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE2", dr("S_SHOW_RATE2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_SRATE1", RATE(dr("S_SHOW_RATE1").ToString, dr("S_SHOW_RATE2").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE1", dr("O_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE2", dr("O_SHOW_RATE2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_ORATE1", RATE(dr("O_SHOW_RATE1").ToString, dr("O_SHOW_RATE2").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE3", dr("S_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE4", dr("S_SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_SRATE2", RATE(dr("S_SHOW_RATE3").ToString, dr("S_SHOW_RATE4").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE3", dr("O_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE4", dr("O_SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_ORATE2", RATE(dr("O_SHOW_RATE3").ToString, dr("O_SHOW_RATE4").ToString)))

'                '新播及首播節目比例。
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE1", dr("N_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE2", dr("N_SHOW_RATE2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_NRATE1", RATE(dr("N_SHOW_RATE1").ToString, dr("N_SHOW_RATE2").ToString)))


'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE1", dr("F_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE2", dr("F_SHOW_RATE2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_FRATE1", RATE(dr("F_SHOW_RATE1").ToString, dr("F_SHOW_RATE2").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE3", dr("N_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE4", dr("N_SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_NRATE2", RATE(dr("N_SHOW_RATE3").ToString, dr("N_SHOW_RATE4").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE3", dr("F_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE4", dr("F_SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_FRATE2", RATE(dr("F_SHOW_RATE3").ToString, dr("F_SHOW_RATE4").ToString)))

'                valuesToFill.Fields.Add(New FieldContent("DESC06", dr("DESC06").ToString))

'                '塞Table資料(品管人員)
'                '品管人員組織編制與職掌
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與" & dr1("CAREER_SHAR_NAME") & "共用", "否"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                valuesToFill.Fields.Add(New FieldContent("DESC07", dr("DESC07").ToString))

'                '各分級級別節目
'                valuesToFill.Fields.Add(New FieldContent("UNIVERSAL_RATE", dr("UNIVERSAL_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROTECTION_RATE", dr("PROTECTION_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY12_RATE", dr("SECONDARY12_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY15_RATE", dr("SECONDARY15_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LIMITATION_RATE", dr("LIMITATION_RATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC09", dr("DESC09").ToString))

'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_Y", IIf(dr("MAKESHOE_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_N", IIf(dr("MAKESHOE_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_Y", IIf(dr("MUTICHANNEL_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_N", IIf(dr("MUTICHANNEL_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_Y", IIf(dr("SELFORG_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_N", IIf(dr("SELFORG_FLAG").ToString = "N", "■", "□")))

'                '塞Table資料(APP1160)
'                '內部自律組織
'                Dim ctrl6 As CtAPP1160 = New CtAPP1160(_dbManager, _logUtil)
'                ctrl6.CASE_NO = caseNo
'                Dim dt委員 As DataTable = ctrl6.DoQuery()

'                If dt委員.Rows.Count > 0 Then
'                    Dim tableContent6 As TableContent = New TableContent("APP1160") 'APP1160為範本中定義的變數名
'                    For Each dr1 As DataRow In dt委員.Rows
'                        tableContent6.AddRow(
'                New FieldContent("MEMBER_NAME", IIf(dr1("MEMBER_NAME") = "", "", dr1("MEMBER_NAME"))),
'                New FieldContent("SEX_TYPE_TXT", IIf(dr1("SEX_TYPE_TXT") = "", "", dr1("SEX_TYPE_TXT"))),
'                New FieldContent("TEACHER_TYPE_TXT", IIf(dr1("TEACHER_TYPE_TXT") = "", "", dr1("TEACHER_TYPE_TXT")))
'                )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent6)
'                End If

'                valuesToFill.Fields.Add(New FieldContent("ORG_NAME", dr("ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_FREQ", dr("MEETING_FREQ").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_PEOPLE", dr("MEETING_PEOPLE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC08", dr("DESC08").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOW1_FLAG", IIf(dr("SHOW1_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW2_FLAG", IIf(dr("SHOW2_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW3_FLAG", IIf(dr("SHOW3_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_FLAG", IIf(dr("SHOW_FLAG").ToString = "Y", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("CHARGE1_FLAG", IIf(dr("CHARGE1_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE2_FLAG", IIf(dr("CHARGE2_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE2_AMT", dr("CHARGE2_AMT").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE3_FLAG", IIf(dr("CHARGE3_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE3_AMT", dr("CHARGE3_AMT").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE4_FLAG", IIf(dr("CHARGE4_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE4_AMT", dr("CHARGE4_AMT").ToString))

'                '塞Table資料(APP1060)
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                    )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If

'                '塞Table資料(APP1070)
'                '員工教育訓練規畫
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                New FieldContent("FUNDING", String.Format("{0:#,###}", CInt(dr1("FUNDING"))).ToString)
'                )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", CInt(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If


'                '塞Table資料(品管人員)
'                '品管人員組織編制與職掌
'                Dim ctrl7 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl7.CASE_NO = caseNo
'                ctrl7.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl7.DoQuery()

'                If (dt客服.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_2") 'APP1050_2為範本中定義的變數名
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent1.AddRow(
'                New FieldContent("PTTCH_FT_TXT2", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME2", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE2", dr1("JOBTITLE")),
'                New FieldContent("IS_CAREER_SHAR2", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                New FieldContent("IS_CAREER_SHAR_TXT2", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是，與" & dr1("CAREER_SHAR_NAME") & "共用", "否"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_21", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_22", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                '客服人力教育訓練之規畫
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_TRAINING_PLAN", dr("SERVICE_TRAINING_PLAN").ToString))

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Protected Function RATE(ByVal rate1 As String, ByVal rate2 As String) As String
'            Dim ratesum As String = ""
'            If (rate1 <> "" And rate2 <> "") Then
'                ratesum = ((CInt(rate1) + CInt(rate2)) / 2).ToString & ".00%"
'            ElseIf (rate1 = "" And rate2 <> "") Then
'                ratesum = CInt(rate2) / 2.ToString & ".00%"
'            ElseIf (rate1 <> "" And rate2 = "") Then
'                ratesum = CInt(rate1) / 2.ToString & ".00%"
'            Else
'                ratesum = ".00%"
'            End If
'            Return ratesum
'        End Function
'#End Region

'#Region "APP130301"
'        Public Function APP130301(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[換照申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                Dim dt股份 As DataTable = ctrl1.DoQuery()

'                Dim ctrl2 As CtAPP1150 = New CtAPP1150(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                Dim dt頻道 As DataTable = Me.BindDDFormat(ctrl2.DoQuery(), FormatType.Edit)

'                'COPY 欄位 因為書籤有兩個
'                dt案件.Columns.Add("限制級鎖碼1")
'                dt案件.Columns.Add("非限制級鎖碼1")
'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                If dr("購物頻道是").ToString = "■" Then
'                    dr("限制級鎖碼1") = dr("限制級鎖碼")
'                    dr("非限制級鎖碼1") = dr("非限制級鎖碼")
'                    dr("限制級鎖碼") = "□"
'                    dr("非限制級鎖碼") = "□"
'                Else
'                    '一般頻道
'                    dr("限制級鎖碼1") = "□"
'                    dr("非限制級鎖碼1") = "□"
'                End If

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                If (bookmark.Name = "實收資本額") Then
'                                    If dr(bookmark.Name).ToString = "" Then
'                                        document.Bookmarks(bookmark.Name).SetText("")
'                                    Else
'                                        document.Bookmarks(bookmark.Name).SetText(String.Format("{0:#,###}", Convert.ToDouble(dr(bookmark.Name))))
'                                    End If
'                                Else
'                                    document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                                End If
'                            End If
'                        End If
'                    Next


'                    '外國人直接持有之股份========================            
'                    Dim tbl_stock As Novacode.Table = document.Tables(0)
'                    Dim tr As Novacode.Row = tbl_stock.Rows(5) ' 股東空白列第一列

'                    Dim 預設筆數 As Integer = 4
'                    If dt股份.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt股份.Rows.Count - 預設筆數 - 1
'                            tbl_stock.InsertRow(tr, 5)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt股份.Rows.Count - 1
'                        tr = tbl_stock.Rows(5 + i)
'                        tr.Cells(2).ReplaceText("一", dt股份.Rows(i).Item("FOREIGNER_SHOLDER_NM").ToString())
'                        tr.Cells(3).ReplaceText("一", dt股份.Rows(i).Item("COUNTRY").ToString())
'                        If (dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString() = "") Then
'                            tr.Cells(4).ReplaceText("一", "")
'                        Else
'                            tr.Cells(4).ReplaceText("一", String.Format("{0:#,###}", CInt(dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString)))
'                        End If
'                        tr.Cells(5).ReplaceText("一", dt股份.Rows(i).Item("PROPORTION").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt股份.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt股份.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(5 + i)
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                        Next
'                    End If


'                    '頻道名稱=============================================
'                    Dim 頻道空白列第一列 = 22 + Math.Max(dt股份.Rows.Count, 預設筆數) - 預設筆數
'                    Dim tbl_channel As Novacode.Table = document.Tables(0)
'                    Dim tr_channel As Novacode.Row = tbl_channel.Rows(頻道空白列第一列) ' 頻道空白列第一列

'                    If dt頻道.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt頻道.Rows.Count - 預設筆數 - 1
'                            tbl_channel.InsertRow(tr_channel, 頻道空白列第一列)
'                        Next
'                    End If

'                    '塞資料

'                    For i As Integer = 0 To dt頻道.Rows.Count - 1
'                        tr = tbl_channel.Rows(頻道空白列第一列 + i)
'                        tr.Cells(1).ReplaceText("一", (i + 1).ToString())
'                        tr.Cells(2).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_NAME").ToString())
'                        tr.Cells(3).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_TYPE_NM").ToString())
'                        tr.Cells(4).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_S_DATE").ToString())
'                        tr.Cells(5).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_E_DATE").ToString())
'                        tr.Cells(6).ReplaceText("一", dt頻道.Rows(i).Item("PUNISH_NUMBER").ToString())
'                        If (dt頻道.Rows(i).Item("PUNISH_AMT").ToString = "") Then
'                            tr.Cells(7).ReplaceText("一", "")
'                        Else
'                            tr.Cells(7).ReplaceText("一", String.Format("{0:#,###}", CInt(dt頻道.Rows(i).Item("PUNISH_AMT").ToString)))
'                        End If
'                        tr.Cells(8).ReplaceText("一", dt頻道.Rows(i).Item("COUNTRY_TYPE_NM").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt頻道.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt頻道.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(頻道空白列第一列 + i)
'                            tr.Cells(1).ReplaceText("一", "")
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                            tr.Cells(6).ReplaceText("一", "")
'                            tr.Cells(7).ReplaceText("一", "")
'                            tr.Cells(8).ReplaceText("一", "")
'                        Next
'                    End If

'                    '其他書籤            
'                    document.Bookmarks("頻道數目總計").SetText(dt頻道.Rows.Count().ToString())
'                    document.Bookmarks("境內數").SetText(dt頻道.Select("COUNTRY_TYPE='1'").Length().ToString())
'                    document.Bookmarks("境外數").SetText(dt頻道.Select("COUNTRY_TYPE='2'").Length().ToString())
'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130201"
'        Public Function APP130201(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[換照申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                dr("實收資本額") = String.Format("{0:#,#;0;0}", ToDecimal(dr("實收資本額").ToString))

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                            End If
'                        End If
'                    Next

'                    document.Save()
'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130106"
'        Public Function APP130106(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營業支出明細表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "2"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                            Key PROJECT_TYPE_ID,
'                            .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                            }

'                    Dim aryCount As New ArrayList
'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM").ToString())
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_ONE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_TWO_YEAR").ToString())))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_THREE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    For Each row As DataRow In dt案件.Rows
'                        Dim thisData_1 As System.Decimal = ToDecimal(row("FUTURE_ONE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_1), 0, thisData_1) Then
'                            tot1 += ToDecimal(thisData_1.ToString)
'                        End If
'                        Dim thisData_2 As System.Decimal = ToDecimal(row("FUTURE_TWO_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_2), 0, thisData_2) Then
'                            tot2 += ToDecimal(thisData_2.ToString)
'                        End If
'                        Dim thisData_3 As System.Decimal = ToDecimal(row("FUTURE_THREE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_3), 0, thisData_3) Then
'                            tot3 += ToDecimal(thisData_3.ToString)
'                        End If
'                    Next

'                    'For I As Integer = 0 To MAIN_REP.Items.Count - 1  '項目 
'                    '    Dim SUB_REP As Repeater = MAIN_REP.Items(I).FindControl("SUB_REP")
'                    '    For J As Integer = 0 To SUB_REP.Items.Count - 1  '細項                  
'                    '        Dim txt1 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_ONE_YEAR")
'                    '        Dim txt2 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_TWO_YEAR")
'                    '        Dim txt3 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_THREE_YEAR")

'                    '        If txt1.Text.Trim <> "" Then
'                    '            tot1 += ToDecimal(txt1.Text.Trim)
'                    '        End If
'                    '        If txt2.Text.Trim <> "" Then
'                    '            tot2 += ToDecimal(txt2.Text.Trim)
'                    '        End If
'                    '        If txt3.Text.Trim <> "" Then
'                    '            tot3 += ToDecimal(txt3.Text.Trim)
'                    '        End If
'                    '    Next
'                    'Next

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot1)))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot2)))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot3)))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130105"
'        Public Function APP130105(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營業收入明細表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "1"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                            Key PROJECT_TYPE_ID,
'                            .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                            }

'                    Dim aryCount As New ArrayList
'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM").ToString())
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_ONE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_TWO_YEAR").ToString())))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_THREE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    For Each row As DataRow In dt案件.Rows
'                        Dim thisData_1 As System.Decimal = ToDecimal(row("FUTURE_ONE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_1), 0, thisData_1) Then
'                            tot1 += ToDecimal(thisData_1.ToString)
'                        End If
'                        Dim thisData_2 As System.Decimal = ToDecimal(row("FUTURE_TWO_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_2), 0, thisData_2) Then
'                            tot2 += ToDecimal(thisData_2.ToString)
'                        End If
'                        Dim thisData_3 As System.Decimal = ToDecimal(row("FUTURE_THREE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_3), 0, thisData_3) Then
'                            tot3 += ToDecimal(thisData_3.ToString)
'                        End If
'                    Next

'                    'For I As Integer = 0 To MAIN_REP.Items.Count - 1  '項目 
'                    '    Dim SUB_REP As Repeater = MAIN_REP.Items(I).FindControl("SUB_REP")
'                    '    For J As Integer = 0 To SUB_REP.Items.Count - 1  '細項                  
'                    '        Dim txt1 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_ONE_YEAR")
'                    '        Dim txt2 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_TWO_YEAR")
'                    '        Dim txt3 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_THREE_YEAR")

'                    '        If txt1.Text.Trim <> "" Then
'                    '            tot1 += ToDecimal(txt1.Text.Trim)
'                    '        End If
'                    '        If txt2.Text.Trim <> "" Then
'                    '            tot2 += ToDecimal(txt2.Text.Trim)
'                    '        End If
'                    '        If txt3.Text.Trim <> "" Then
'                    '            tot3 += ToDecimal(txt3.Text.Trim)
'                    '        End If
'                    '    Next
'                    'Next

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot1)))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot2)))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot3)))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130122"
'        Public Function APP130122(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申設或前次換照及其他行政處分附款及承諾事項或行政指導之執行情形]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl1010.CASE_NO = caseNo '案號
'                Dim dt標頭 As DataTable = Me.BindDDFormat(ctrl1010.DoQuery(), FormatType.Report)
'                Dim channelName = String.Empty
'                Dim licenseStart = String.Empty
'                Dim licenseEnd = String.Empty
'                Dim evaluationStart = String.Empty
'                Dim evaluationEnd = String.Empty


'                If dt標頭.Rows.Count > 0 Then
'                    Dim dr As DataRow = dt標頭.Rows(0)
'                    channelName = If(String.IsNullOrEmpty(dr("SYS_CNAME").ToString()), "", dr("SYS_CNAME"))
'                    licenseStart = If(String.IsNullOrEmpty(dr("LICENSE_S_DATE").ToString()), "   /  /  ", dr("LICENSE_S_DATE"))
'                    licenseEnd = If(String.IsNullOrEmpty(dr("LICENSE_E_DATE").ToString()), "   /  /  ", dr("LICENSE_E_DATE"))
'                    evaluationStart = If(String.IsNullOrEmpty(dr("EVALUATION_S_DATE").ToString()), "   /  /  ", dr("EVALUATION_S_DATE"))
'                    evaluationEnd = If(String.IsNullOrEmpty(dr("EVALUATION_E_DATE").ToString()), "   /  /  ", dr("EVALUATION_E_DATE"))
'                End If

'                '內容
'                Dim ctrl As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                ctrl.QUERY_COND += " AND R1.SYS_PRTID = 'B'"
'                ctrl.OrderBys = " COMPLY_TYPE_NM DESC "
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B01' "
'                Dim dt1 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count1 As Integer = dt1.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B02' "
'                Dim dt2 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count2 As Integer = dt2.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B03' "
'                Dim dt3 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count3 As Integer = dt3.Rows.Count

'                '=== 標頭資訊 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Dim strY = "■有 □無"
'                Dim strN = "□有 ■無"

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", channelName))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", licenseStart))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", licenseEnd))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE", evaluationStart))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE", evaluationEnd))
'                valuesToFill.Fields.Add(New FieldContent("YN1", If(count1 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN2", If(count2 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN3", If(count3 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("COUNT1", count1))
'                valuesToFill.Fields.Add(New FieldContent("COUNT2", count2))
'                valuesToFill.Fields.Add(New FieldContent("COUNT3", count3))

'                '=== 表格資料 ===
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    tb.InsertRow(tr1, 3)
'                    If dt3.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt3.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    tb.InsertRow(tr1, 3)
'                    If dt2.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt2.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    If dt1.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt1.Rows.Count - 2
'                            tb.InsertRow(tr2, 3)
'                        Next
'                    End If

'                    '塞資料
'                    Dim str = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str1 = "■已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str2 = "□已執行" & Chr(10) & "■執行中" & Chr(10) & "□尚未執行"
'                    Dim str3 = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "■尚未執行"

'                    Dim i As Integer = 1
'                    tb.Rows(i).Cells(0).Paragraphs.First().ReplaceText("一", "承諾事項")
'                    If dt1.Rows.Count = 1 Then
'                        tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dt1.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt1.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt1.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("PAGE_NO"))

'                        tb.Rows(i + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(i + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(i + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt1.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt1.Rows
'                            tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            i += 1
'                        Next
'                    Else
'                        Dim _i As Integer = i + 1
'                        For var_i As Integer = i To _i
'                            tb.Rows(var_i).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_i).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_i).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim j As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + 1
'                    tb.Rows(j).Cells(0).Paragraphs.First().ReplaceText("一", "改善事項")
'                    If dt2.Rows.Count = 1 Then
'                        tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dt2.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt2.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt2.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("PAGE_NO"))

'                        tb.Rows(j + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(j + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(j + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt2.Rows
'                            tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            j += 1
'                        Next
'                    Else
'                        Dim _j As Integer = j + 1
'                        For var_j As Integer = j To _j
'                            tb.Rows(var_j).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_j).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_j).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim k As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + If(dt2.Rows.Count < 2, 2, dt2.Rows.Count) + 1
'                    tb.Rows(k).Cells(0).Paragraphs.First().ReplaceText("一", "改正事項")
'                    If dt3.Rows.Count = 1 Then
'                        tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dt3.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt3.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt3.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("PAGE_NO"))

'                        tb.Rows(k + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(k + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(k + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt3.Rows
'                            tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            k += 1
'                        Next
'                    Else
'                        Dim _k As Integer = k + 1
'                        For var_k As Integer = k To _k
'                            tb.Rows(var_k).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_k).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_k).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    document.Save()
'                End Using

'                '=== 將容器資料對應到暫存檔並存檔 ===
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130121"
'        Public Function APP130121(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[評鑑應改善(或改正)事項之執行情形]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl1010.CASE_NO = caseNo '案號
'                Dim dt標頭 As DataTable = Me.BindDDFormat(ctrl1010.DoQuery(), FormatType.Report)
'                Dim channelName = String.Empty
'                Dim licenseStart = String.Empty
'                Dim licenseEnd = String.Empty

'                If dt標頭.Rows.Count > 0 Then
'                    Dim dr As DataRow = dt標頭.Rows(0)
'                    channelName = If(String.IsNullOrEmpty(dr("SYS_CNAME").ToString()), "", dr("SYS_CNAME"))
'                    licenseStart = If(String.IsNullOrEmpty(dr("LICENSE_S_DATE").ToString()), "   /  /  ", dr("LICENSE_S_DATE"))
'                    licenseEnd = If(String.IsNullOrEmpty(dr("LICENSE_E_DATE").ToString()), "   /  /  ", dr("LICENSE_E_DATE"))
'                End If

'                '內容
'                Dim ctrl As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                ctrl.QUERY_COND += " AND R1.SYS_PRTID = 'A'"
'                ctrl.OrderBys = " COMPLY_TYPE_NM DESC "
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A01' "
'                Dim dt1 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count1 As Integer = dt1.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A02' "
'                Dim dt2 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count2 As Integer = dt2.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A03' "
'                Dim dt3 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count3 As Integer = dt3.Rows.Count

'                '=== 標頭資訊 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Dim strY = "■有 □無"
'                Dim strN = "□有 ■無"

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", channelName))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", licenseStart))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", licenseEnd))
'                valuesToFill.Fields.Add(New FieldContent("YN1", If(count1 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN2", If(count2 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN3", If(count3 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("COUNT1", count1))
'                valuesToFill.Fields.Add(New FieldContent("COUNT2", count2))
'                valuesToFill.Fields.Add(New FieldContent("COUNT3", count3))

'                '=== 表格資料 ===
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    tb.InsertRow(tr1, 3)
'                    If dt3.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt3.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    tb.InsertRow(tr1, 3)
'                    If dt2.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt2.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    If dt1.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt1.Rows.Count - 2
'                            tb.InsertRow(tr2, 3)
'                        Next
'                    End If

'                    '塞資料
'                    Dim str = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str1 = "■已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str2 = "□已執行" & Chr(10) & "■執行中" & Chr(10) & "□尚未執行"
'                    Dim str3 = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "■尚未執行"

'                    Dim i As Integer = 1
'                    tb.Rows(i).Cells(0).Paragraphs.First().ReplaceText("一", "承諾事項")
'                    If dt1.Rows.Count = 1 Then
'                        tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dt1.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt1.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt1.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("PAGE_NO"))

'                        tb.Rows(i + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(i + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(i + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt1.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt1.Rows
'                            tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            i += 1
'                        Next
'                    Else
'                        Dim _i As Integer = i + 1
'                        For var_i As Integer = i To _i
'                            tb.Rows(var_i).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_i).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_i).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim j As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + 1
'                    tb.Rows(j).Cells(0).Paragraphs.First().ReplaceText("一", "改善事項")
'                    If dt2.Rows.Count = 1 Then
'                        tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dt2.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt2.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt2.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("PAGE_NO"))

'                        tb.Rows(j + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(j + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(j + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt2.Rows
'                            tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            j += 1
'                        Next
'                    Else
'                        Dim _j As Integer = j + 1
'                        For var_j As Integer = j To _j
'                            tb.Rows(var_j).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_j).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_j).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim k As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + If(dt2.Rows.Count < 2, 2, dt2.Rows.Count) + 1
'                    tb.Rows(k).Cells(0).Paragraphs.First().ReplaceText("一", "改正事項")
'                    If dt3.Rows.Count = 1 Then
'                        tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dt3.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt3.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt3.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("PAGE_NO"))

'                        tb.Rows(k + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(k + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(k + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt3.Rows
'                            tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            k += 1
'                        Next
'                    Else
'                        Dim _k As Integer = k + 1
'                        For var_k As Integer = k To _k
'                            tb.Rows(var_k).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_k).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_k).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    document.Save()
'                End Using

'                '=== 將容器資料對應到暫存檔並存檔 ===
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130102"
'        Public Function APP130102(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[未來6年事業營運計畫摘要表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1040 = New CtAPP1040(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoWordQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSIN_PRO_PLAN", dr("BUSIN_PRO_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DISPUTE_HAN_MECH", dr("DISPUTE_HAN_MECH").ToString))
'                valuesToFill.Fields.Add(New FieldContent("INFORM_DISC_PLAN", dr("INFORM_DISC_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("BUSIN_PHIL_CHAR", dr("BUSIN_PHIL_CHAR").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MARK_RES_DATA", dr("MARK_RES_DATA").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_STRATEGY", dr("CHANNEL_STRATEGY").ToString))

'                valuesToFill.Fields.Add(New FieldContent("NAT_CHANNELS_NUM", dr("NAT_CHANNELS_NUM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("OVER_CHANNELS_NUM", dr("OVER_CHANNELS_NUM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PACK_COM_PLAN", dr("PACK_COM_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SIN_POINT_CHAN_PLAN", dr("SIN_POINT_CHAN_PLAN").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOPPING_CHANNELS", dr("SHOPPING_CHANNELS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TOTAL_CHANNELS", dr("TOTAL_CHANNELS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROPORTION", dr("PROPORTION").ToString))

'                valuesToFill.Fields.Add(New FieldContent("INTER_CON_ORG_NAME", dr("INTER_CON_ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("INTER_CON_ORG_INS", dr("INTER_CON_ORG_INS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE_BASE", dr("CHARGE_BASE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("CHARGE_BASE", dr("CHARGE_BASE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PAT_REF_METHOD", dr("PAT_REF_METHOD").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE_BASE", dr("CHARGE_BASE").ToString))


'                '塞Table資料(品管人員)
'                '品管人員組織編制與職掌
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                    New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                    New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                    )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                '塞Table資料(APP1060)
'                '學經歷介紹
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                    )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If

'                '塞Table資料(APP1070)
'                '員工教育訓練規畫
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                    New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                    New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                    New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                    New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                    New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                    New FieldContent("FUNDING", String.Format("{0:#,###}", CInt(dr1("FUNDING"))).ToString)
'                    )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", CInt(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If

'                '塞Table資料(客服人員)
'                Dim ctrl2 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                ctrl2.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl2.DoQuery()

'                Dim tableContent2 As TableContent = New TableContent("APP1050_2") 'APP1050_2為範本中定義的變數名

'                If (dt客服.Rows.Count > 0) Then
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent2.AddRow(
'                    New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                    New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                    )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT2 = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT2_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT2_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT2))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_1", sum_PTTCH_FT2_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_2", sum_PTTCH_FT2_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent2)

'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP130101"
'        Public Function APP130101(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[換照申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                dr("實收資本額") = String.Format("{0:#,#;0;0}", ToDecimal(dr("實收資本額").ToString))

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                            End If
'                        End If
'                    Next

'                    '外國人直接持有之股份
'                    Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                    ctrl1.CASE_NO = caseNo
'                    Dim dt股份 As DataTable = ctrl1.DoQuery()
'                    Dim tbl_stock As Novacode.Table = document.Tables(0)
'                    Dim tr As Novacode.Row = tbl_stock.Rows(5) ' 股東空白列第一列

'                    '目前預設4筆
'                    If dt股份.Rows.Count > 4 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt股份.Rows.Count - 4 - 1
'                            tbl_stock.InsertRow(tr, 5)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt股份.Rows.Count - 1
'                        tr = tbl_stock.Rows(5 + i)
'                        tr.Cells(2).ReplaceText("一", dt股份.Rows(i).Item("FOREIGNER_SHOLDER_NM").ToString())
'                        tr.Cells(3).ReplaceText("一", dt股份.Rows(i).Item("COUNTRY").ToString())
'                        If (dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString() = "") Then
'                            tr.Cells(4).ReplaceText("一", "")
'                        Else
'                            tr.Cells(4).ReplaceText("一", String.Format("{0:#,###}", CInt(dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString())))
'                        End If
'                        tr.Cells(5).ReplaceText("一", dt股份.Rows(i).Item("PROPORTION").ToString())
'                    Next
'                    '不夠4筆的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt股份.Rows.Count < 4 Then
'                        For i As Integer = dt股份.Rows.Count - 1 To 3
'                            tr = tbl_stock.Rows(5 + i)
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                        Next
'                    End If


'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120801"
'        Public Function APP120801(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[廣播事業評鑑報告書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE1", GetSubDateString(dr, "EVALUATION_S_DATE", 0)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE2", GetSubDateString(dr, "EVALUATION_S_DATE", 1)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE3", GetSubDateString(dr, "EVALUATION_S_DATE", 2)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE1", GetSubDateString(dr, "EVALUATION_E_DATE", 0)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE2", GetSubDateString(dr, "EVALUATION_E_DATE", 1)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE3", GetSubDateString(dr, "EVALUATION_E_DATE", 2)))

'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_CITY", SYST1010_NAME("CITY_CODE", dr("BUSINESS_CITY"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ZIP", SYST1010_NAME("CITY_CODE", dr("BUSINESS_ZIP"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ADDRESS", dr("BUSINESS_ADDRESS").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_AREA_CODE", "( " & dr("BUSINESS_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_TEL", " " & dr("BUSINESS_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_AREA_CODE", "( " & dr("COMPLAINT_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_TEL", " " & dr("COMPLAINT_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("REPRESENTATIVE", dr("REPRESENTATIVE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_NO", dr("LICENSE_NO").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_DATE", dr("SETUP_DATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString))

'                If (dr("TOTAL_PROPERTY").ToString.Trim() = "") Then
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", ""))
'                Else
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", String.Format("{0:#,###}", CLng(dr("TOTAL_PROPERTY").ToString))))
'                End If

'                valuesToFill.Fields.Add(New FieldContent("WEB_URL", dr("WEB_URL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_PURPOSE", dr("SETUP_PURPOSE").ToString))


'                Dim RADIO As String() = dr("RADIO_TYPE").ToString.Split(",")

'                Dim RADIO_TYPE As String = ""

'                For j As Integer = 0 To RADIO.Count - 1
'                    For i As Integer = 1 To 7
'                        If i.ToString = RADIO(j).ToString Then
'                            Select Case i.ToString
'                                Case "1"
'                                    'RADIO_TYPE += "■AM電台 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG1", "■"))
'                                Case "2"
'                                    'RADIO_TYPE += "■FM電台 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG2", "■"))
'                                Case "3"
'                                    'RADIO_TYPE += "■公司 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG3", "■"))
'                                Case "4"
'                                    'RADIO_TYPE += "■財團法人 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG4", "■"))
'                                Case "5"
'                                    'RADIO_TYPE += "■指定用途電台 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG5", "■"))
'                                Case "6"
'                                    'RADIO_TYPE += "■全域型 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG6", "■"))
'                                Case 7
'                                    'RADIO_TYPE += "■區域型 "
'                                    valuesToFill.Fields.Add(New FieldContent("RADIO_FLAG7", "■"))
'                            End Select
'                        End If
'                    Next
'                Next

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function GetSubDateString(ByVal dr As DataRow, ByVal colName As String, ByVal i As Integer) As String

'            If Not dr Is Nothing Then
'                If Not dr(colName) Is Nothing Then
'                    If dr(colName).ToString.Length > 0 Then
'                        Return dr(colName).ToString.Split("/")(i)
'                    Else
'                        Return ""
'                    End If
'                Else
'                    Return ""
'                End If
'            Else
'                Return ""
'            End If

'            Return ""
'        End Function

'        Private Shared Function ConvertCDate_Year(ByVal dateStr As String) As String

'            Dim Year As String = ""

'            If dateStr.Length > 0 Then
'                Year = Convert.ToDateTime(dateStr).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'            End If

'            Return Year

'        End Function

'        Private Shared Function ConvertCDate_Month(ByVal dateStr As String) As String

'            Dim Month As String = ""

'            If dateStr.Length > 0 Then
'                Month = Convert.ToDateTime(dateStr).Month.ToString().PadLeft(2, "0")
'            End If

'            Return Month

'        End Function

'        Private Shared Function ConvertCDate_Day(ByVal dateStr As String) As String

'            Dim Day As String = ""

'            If dateStr.Length > 0 Then
'                Day = Convert.ToDateTime(dateStr).Day.ToString().PadLeft(2, "0")
'            End If

'            Return Day

'        End Function
'#End Region

'#Region "APP120703"
'        Public Function APP120703(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[無線電視]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))

'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", Convert.ToString(dt表頭1.Rows(0)("CONTACT_TEL"))))
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If


'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1202", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1203'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1203", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1204'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1204", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1205'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1205", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1301", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1303", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1304'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1304", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1305'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1305", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1306'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1306", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1309'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1309", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1604'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1604", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1804'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1804", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If
'                End If

'                Dim ctrl2 As CtAPP1411 = New CtAPP1411(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1411 As DataTable = ctrl2.DoQuery()

'                If dt1411.Rows.Count > 0 Then
'                    Dim dr1411 As DataRow = dt1411.Rows(0)

'                    valuesToFill.Fields.Add(New FieldContent("T_BASE_DATE", DateUtil.ConvertFormatDate(dr1411("BASE_DATE"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_EMPLOYEE_NUMBER", Convert.ToString(dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_EMPLOYEE_NUMBER", Convert.ToString(dr1411("W_EMPLOYEE_NUMBER") + dr1411("M_EMPLOYEE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_MANAGER_NUMBER", Convert.ToString(dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("ALL_T_MANAGER_NUMBER", Convert.ToString(dr1411("W_MANAGER_NUMBER") + dr1411("M_MANAGER_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_HSCHOOL_NUMBER", Convert.ToString(dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("HSCHOOL_NUMBER", Convert.ToString(dr1411("W_HSCHOOL_NUMBER") + dr1411("M_HSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_UNIVERSITY_NUMBER", Convert.ToString(dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("UNIVERSITY_NUMBER", Convert.ToString(dr1411("W_UNIVERSITY_NUMBER") + dr1411("M_UNIVERSITY_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_M_GSCHOOL_NUMBER", Convert.ToString(dr1411("M_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("T_W_GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("GSCHOOL_NUMBER", Convert.ToString(dr1411("W_GSCHOOL_NUMBER") + dr1411("M_GSCHOOL_NUMBER"))))
'                End If

'                '====呼叫Control=====
'                Dim ctrl3 As CtAPP1421 = New CtAPP1421(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                ctrl3.DATA_TYPE = "0"
'                ctrl3.OrderBys = "CREATE_TIME ASC"

'                '=== 呼叫control ===
'                Dim dt1421 As DataTable = ctrl3.DoQuery()

'                If dt1421.Rows.Count > 0 Then
'                    Dim tableContent As TableContent = New TableContent("APP1421")
'                    For Each dr2 As DataRow In dt1421.Rows
'                        '塞變數資料
'                        tableContent.AddRow(
'                        New FieldContent("M_CHANNEL_NAME", Convert.ToString(dr2("CHANNEL_NAME"))),
'                         New FieldContent("M_YEAR", Convert.ToString(dr2("YEAR"))),
'                        New FieldContent("M_NEW_HOURS", Convert.ToString(dr2("NEW_HOURS"))),
'                        New FieldContent("M_NEW_RATE", Convert.ToString(dr2("NEW_RATE"))),
'                         New FieldContent("M_FIRST_HOURS", Convert.ToString(dr2("FIRST_HOURS"))),
'                        New FieldContent("M_FIRST_RATE", Convert.ToString(dr2("FIRST_RATE"))),
'                        New FieldContent("M_REPLAY_HOURS", Convert.ToString(dr2("REPLAY_HOURS"))),
'                        New FieldContent("M_REPLAY_RATE", Convert.ToString(dr2("REPLAY_RATE"))),
'                        New FieldContent("M_INTERNAL_HOURS", Convert.ToString(dr2("INTERNAL_HOURS"))),
'                         New FieldContent("M_EXTERNAL_HOURS", Convert.ToString(dr2("EXTERNAL_HOURS"))),
'                         New FieldContent("M_EXTERNAL_RATE", Convert.ToString(dr2("EXTERNAL_RATE"))),
'                         New FieldContent("M_ITEM01_HOURS", Convert.ToString(dr2("ITEM01_HOURS"))),
'                        New FieldContent("M_ITEM01_RATE", Convert.ToString(dr2("ITEM01_RATE"))),
'                          New FieldContent("M_ITEM02_HOURS", Convert.ToString(dr2("ITEM02_HOURS"))),
'                        New FieldContent("M_ITEM02_RATE", Convert.ToString(dr2("ITEM02_RATE"))),
'                        New FieldContent("M_ITEM03_HOURS", Convert.ToString(dr2("ITEM03_HOURS"))),
'                        New FieldContent("M_ITEM03_RATE", Convert.ToString(dr2("ITEM03_RATE"))),
'                        New FieldContent("M_ITEM04_HOURS", Convert.ToString(dr2("ITEM04_HOURS"))),
'                        New FieldContent("M_ITEM04_RATE", Convert.ToString(dr2("ITEM04_RATE"))),
'                        New FieldContent("M_ITEM05_HOURS", Convert.ToString(dr2("ITEM05_HOURS"))),
'                        New FieldContent("M_ITEM05_RATE", Convert.ToString(dr2("ITEM05_RATE"))),
'                        New FieldContent("M_ITEM06_HOURS", Convert.ToString(dr2("ITEM06_HOURS"))),
'                        New FieldContent("M_ITEM06_RATE", Convert.ToString(dr2("ITEM06_RATE"))),
'                        New FieldContent("M_ITEM07_HOURS", Convert.ToString(dr2("ITEM07_HOURS"))),
'                        New FieldContent("M_ITEM07_RATE", Convert.ToString(dr2("ITEM07_RATE"))),
'                        New FieldContent("M_ITEM08_HOURS", Convert.ToString(dr2("ITEM08_HOURS"))),
'                        New FieldContent("M_ITEM08_RATE", Convert.ToString(dr2("ITEM08_RATE"))),
'                        New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM10_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM10_RATE"))),
'                         New FieldContent("M_ITEM11_HOURS", Convert.ToString(dr2("ITEM11_HOURS"))),
'                        New FieldContent("M_ITEM11_RATE", Convert.ToString(dr2("ITEM11_RATE"))),
'                         New FieldContent("M_ITEM10_HOURS", Convert.ToString(dr2("ITEM12_HOURS"))),
'                        New FieldContent("M_ITEM10_RATE", Convert.ToString(dr2("ITEM12_RATE"))),
'                         New FieldContent("M_ITEM11_HOURS", Convert.ToString(dr2("ITEM13_HOURS"))),
'                        New FieldContent("M_ITEM11_RATE", Convert.ToString(dr2("ITEM13_RATE"))),
'                         New FieldContent("M_ITEM14_HOURS", Convert.ToString(dr2("ITEM14_HOURS"))),
'                        New FieldContent("M_ITEM14_RATE", Convert.ToString(dr2("ITEM14_RATE"))),
'                         New FieldContent("M_ITEM15_HOURS", Convert.ToString(dr2("ITEM15_HOURS"))),
'                        New FieldContent("M_ITEM15_RATE", Convert.ToString(dr2("ITEM15_RATE"))),
'                       New FieldContent("M_ITEM999_HOURS", Convert.ToString(dr2("ITEM999_HOURS"))),
'                        New FieldContent("M_ITEM999_RATE", Convert.ToString(dr2("ITEM999_RATE"))),
'                       New FieldContent("M_ROC_HOURS", Convert.ToString(dr2("ROC_HOURS"))),
'                         New FieldContent("M_ROC_RATE", Convert.ToString(dr2("ROC_RATE"))),
'                       New FieldContent("M_HK_HOURS", Convert.ToString(dr2("HK_HOURS"))),
'                         New FieldContent("M_HK_RATE", Convert.ToString(dr2("HK_RATE"))),
'                       New FieldContent("M_PRC_HOURS", Convert.ToString(dr2("PRC_HOURS"))),
'                         New FieldContent("M_PRC_RATE", Convert.ToString(dr2("PRC_RATE"))),
'                       New FieldContent("M_JPN_HOURS", Convert.ToString(dr2("JPN_HOURS"))),
'                         New FieldContent("M_JPN_RATE", Convert.ToString(dr2("JPN_RATE"))),
'                       New FieldContent("M_KOR_HOURS", Convert.ToString(dr2("KOR_HOURS"))),
'                         New FieldContent("M_KOR_RATE", Convert.ToString(dr2("KOR_RATE"))),
'                       New FieldContent("M_USA_HOURS", Convert.ToString(dr2("USA_HOURS"))),
'                         New FieldContent("M_USA_RATE", Convert.ToString(dr2("USA_RATE"))),
'                       New FieldContent("M_OTH_HOURS", Convert.ToString(dr2("OTH_HOURS"))),
'                         New FieldContent("M_OTH_RATE", Convert.ToString(dr2("OTH_RATE"))),
'                       New FieldContent("M_INTERNAL_AMT", Convert.ToString(dr2("INTERNAL_AMT"))),
'                         New FieldContent("M_INTERNAL_AMT_RATE", Convert.ToString(dr2("INTERNAL_AMT_RATE"))),
'                       New FieldContent("M_EXTERNAL_AMT", Convert.ToString(dr2("EXTERNAL_AMT"))),
'                         New FieldContent("M_EXTERNAL_AMT_RATE", Convert.ToString(dr2("EXTERNAL_AMT_RATE"))),
'                       New FieldContent("M_HD_HOURS", Convert.ToString(dr2("HD_HOURS"))),
'                         New FieldContent("M_HD_RATE", Convert.ToString(dr2("HD_RATE"))),
'                       New FieldContent("M_SD_HOURS", Convert.ToString(dr2("SD_HOURS"))),
'                         New FieldContent("M_SD_RATE", Convert.ToString(dr2("SD_RATE")))
')
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '====呼叫Control=====
'                Dim ctrl1451 As CtAPP1451 = New CtAPP1451(_dbManager, _logUtil)
'                ctrl1451.CASE_NO = caseNo
'                ctrl1451.DATA_TYPE = "0"
'                ctrl1451.OrderBys = "YEAR ASC"

'                Dim dt1451 As DataTable = ctrl1451.DoQuery()

'                Dim ItemCList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "NON_OPERATING_INCOME", "OPERATING_MARGIN", "OPERATING_PROFIT", "NON_OPERATING_PAY", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME"}
'                Dim ItemFList() As String = {"YEAR", "OPERATING_INCOME", "OPERATING_COST", "OPERATING_EXP", "BEFORE_TAX_INCOME", "INCOME_TAX_EXP", "AFTER_TAX_INCOME", "END_SURPLUS"}

'                Dim ctrlL020 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)

'                '=== 設定屬性參數 ===
'                ctrlL020.CASE_NO = caseNo

'                Dim dtL020 As DataTable = ctrlL020.DoQuery()
'                If dtL020.Rows.Count > 0 Then
'                    Dim ctrlL010 As CtAPPL010 = New CtAPPL010(_dbManager, _logUtil)

'                    '=== 設定屬性參數 ===
'                    ctrlL010.PKNO = dtL020.Rows(0)("COM_PKNO").ToString()

'                    Dim dtL010 As DataTable = ctrlL010.DoQuery()

'                    If dtL010.Rows.Count > 0 Then
'                        If dt1451.Rows.Count > 0 Then
'                            For Year As Integer = 1 To dt1451.Rows.Count
'                                Dim ORG_TYPE As String = dtL010.Rows(0)("ORG_TYPE").ToString()
'                                If ORG_TYPE = "C" Then
'                                    For Each Item As String In ItemCList
'                                        valuesToFill.Fields.Add(New FieldContent("C_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                                If ORG_TYPE = "F" Then
'                                    For Each Item As String In ItemFList
'                                        valuesToFill.Fields.Add(New FieldContent("F_" + Item + "_" + Year.ToString(), Convert.ToString(dt1451(Year - 1)(Item))))
'                                    Next
'                                End If
'                            Next
'                        End If
'                    End If
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120701"
'        Public Function APP120701(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[基本資料]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))

'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE1", dr("EVALUATION_S_DATE").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE2", dr("EVALUATION_S_DATE").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE3", dr("EVALUATION_S_DATE").ToString.Split("/")(2)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE1", dr("EVALUATION_E_DATE").ToString.Split("/")(0)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE2", dr("EVALUATION_E_DATE").ToString.Split("/")(1)))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE3", dr("EVALUATION_E_DATE").ToString.Split("/")(2)))

'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_CITY", SYST1010_NAME("CITY_CODE", dr("BUSINESS_CITY"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ZIP", SYST1010_NAME("CITY_CODE", dr("BUSINESS_ZIP"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ADDRESS", dr("BUSINESS_ADDRESS").ToString))

'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_AREA_CODE", "( " & dr("BUSINESS_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_TEL", " " & dr("BUSINESS_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_AREA_CODE", "( " & dr("COMPLAINT_AREA_CODE").ToString & " )"))
'                valuesToFill.Fields.Add(New FieldContent("COMPLAINT_TEL", " " & dr("COMPLAINT_TEL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("REPRESENTATIVE", dr("REPRESENTATIVE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_NO", dr("LICENSE_NO").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_DATE", dr("SETUP_DATE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", dr("LICENSE_S_DATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", dr("LICENSE_E_DATE").ToString))

'                If (dr("TOTAL_PROPERTY").ToString.Trim() = "") Then
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", ""))
'                Else
'                    valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", String.Format("{0:#,###}", CLng(dr("TOTAL_PROPERTY").ToString))))
'                End If

'                valuesToFill.Fields.Add(New FieldContent("WEB_URL", dr("WEB_URL").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SETUP_PURPOSE", dr("SETUP_PURPOSE").ToString))

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()

'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function SYST1010_NAME(ByVal syskey As String, ByVal sysid As String) As String
'            Dim ctrlT As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)
'            ctrlT.SYS_KEY = syskey
'            ctrlT.SYS_TYPE = "1"
'            ctrlT.USE_STATE = "1"
'            ctrlT.SYS_ID = sysid
'            ctrlT.OrderBys = "SYS_ID"
'            Dim dt As DataTable = ctrlT.Get系統下拉資料
'            Return dt.Rows(0)("SYS_NAME").ToString()
'        End Function

'#End Region

'#Region "APP120106"
'        Public Function APP120106(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營業支出明細表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "2"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]"
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                            Key PROJECT_TYPE_ID,
'                            .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                            }

'                    Dim aryCount As New ArrayList
'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM").ToString())
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_ONE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_TWO_YEAR").ToString())))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_THREE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    For Each row As DataRow In dt案件.Rows
'                        Dim thisData_1 As System.Decimal = ToDecimal(row("FUTURE_ONE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_1), 0, thisData_1) Then
'                            tot1 += ToDecimal(thisData_1.ToString)
'                        End If
'                        Dim thisData_2 As System.Decimal = ToDecimal(row("FUTURE_TWO_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_2), 0, thisData_2) Then
'                            tot2 += ToDecimal(thisData_2.ToString)
'                        End If
'                        Dim thisData_3 As System.Decimal = ToDecimal(row("FUTURE_THREE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_3), 0, thisData_3) Then
'                            tot3 += ToDecimal(thisData_3.ToString)
'                        End If
'                    Next

'                    'For I As Integer = 0 To MAIN_REP.Items.Count - 1  '項目 
'                    '    Dim SUB_REP As Repeater = MAIN_REP.Items(I).FindControl("SUB_REP")
'                    '    For J As Integer = 0 To SUB_REP.Items.Count - 1  '細項                  
'                    '        Dim txt1 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_ONE_YEAR")
'                    '        Dim txt2 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_TWO_YEAR")
'                    '        Dim txt3 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_THREE_YEAR")

'                    '        If txt1.Text.Trim <> "" Then
'                    '            tot1 += ToDecimal(txt1.Text.Trim)
'                    '        End If
'                    '        If txt2.Text.Trim <> "" Then
'                    '            tot2 += ToDecimal(txt2.Text.Trim)
'                    '        End If
'                    '        If txt3.Text.Trim <> "" Then
'                    '            tot3 += ToDecimal(txt3.Text.Trim)
'                    '        End If
'                    '    Next
'                    'Next

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot1)))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot2)))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot3)))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120105"
'        Public Function APP120105(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營業收入明細表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = "Word範本檔不存在"
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "1"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]"
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                            Key PROJECT_TYPE_ID,
'                            .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                            }

'                    Dim aryCount As New ArrayList
'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM").ToString())
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_ONE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_TWO_YEAR").ToString())))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(dr("FUTURE_THREE_YEAR").ToString())))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    For Each row As DataRow In dt案件.Rows
'                        Dim thisData_1 As System.Decimal = ToDecimal(row("FUTURE_ONE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_1), 0, thisData_1) Then
'                            tot1 += ToDecimal(thisData_1.ToString)
'                        End If
'                        Dim thisData_2 As System.Decimal = ToDecimal(row("FUTURE_TWO_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_2), 0, thisData_2) Then
'                            tot2 += ToDecimal(thisData_2.ToString)
'                        End If
'                        Dim thisData_3 As System.Decimal = ToDecimal(row("FUTURE_THREE_YEAR").ToString)
'                        If IIf(IsDBNull(thisData_3), 0, thisData_3) Then
'                            tot3 += ToDecimal(thisData_3.ToString)
'                        End If
'                    Next

'                    'For I As Integer = 0 To MAIN_REP.Items.Count - 1  '項目 
'                    '    Dim SUB_REP As Repeater = MAIN_REP.Items(I).FindControl("SUB_REP")
'                    '    For J As Integer = 0 To SUB_REP.Items.Count - 1  '細項                  
'                    '        Dim txt1 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_ONE_YEAR")
'                    '        Dim txt2 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_TWO_YEAR")
'                    '        Dim txt3 As TextBox = SUB_REP.Items(J).FindControl("G_FUTURE_THREE_YEAR")

'                    '        If txt1.Text.Trim <> "" Then
'                    '            tot1 += ToDecimal(txt1.Text.Trim)
'                    '        End If
'                    '        If txt2.Text.Trim <> "" Then
'                    '            tot2 += ToDecimal(txt2.Text.Trim)
'                    '        End If
'                    '        If txt3.Text.Trim <> "" Then
'                    '            tot3 += ToDecimal(txt3.Text.Trim)
'                    '        End If
'                    '    Next
'                    'Next

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot1)))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot2)))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", String.Format("{0:#,#;0;0}", ToDecimal(tot3)))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120122"
'        Public Function APP120122(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[其他行政處分附款及承諾事項或行政指導之執行情形]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = "Word範本檔不存在"
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                '標頭
'                Dim ctrl1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl1010.CASE_NO = caseNo '案號
'                Dim dt標頭 As DataTable = Me.BindDDFormat(ctrl1010.DoQuery(), FormatType.Report)
'                Dim channelName = String.Empty
'                Dim licenseStart = String.Empty
'                Dim licenseEnd = String.Empty
'                Dim evaluationStart = String.Empty
'                Dim evaluationEnd = String.Empty

'                If dt標頭.Rows.Count > 0 Then
'                    Dim dr As DataRow = dt標頭.Rows(0)
'                    channelName = If(String.IsNullOrEmpty(dr("SYS_CNAME").ToString()), "", dr("SYS_CNAME"))
'                    licenseStart = If(String.IsNullOrEmpty(dr("LICENSE_S_DATE").ToString()), "   /  /  ", dr("LICENSE_S_DATE"))
'                    licenseEnd = If(String.IsNullOrEmpty(dr("LICENSE_E_DATE").ToString()), "   /  /  ", dr("LICENSE_E_DATE"))
'                    evaluationStart = If(String.IsNullOrEmpty(dr("EVALUATION_S_DATE").ToString()), "   /  /  ", dr("EVALUATION_S_DATE"))
'                    evaluationEnd = If(String.IsNullOrEmpty(dr("EVALUATION_E_DATE").ToString()), "   /  /  ", dr("EVALUATION_E_DATE"))
'                End If

'                '內容
'                Dim ctrl As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                ctrl.QUERY_COND += " AND R1.SYS_PRTID = 'B'"
'                ctrl.OrderBys = " COMPLY_TYPE_NM DESC "
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]"
'                    Return rptModel
'                End If

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B01' "
'                Dim dt1 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count1 As Integer = dt1.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B02' "
'                Dim dt2 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count2 As Integer = dt2.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'B03' "
'                Dim dt3 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count3 As Integer = dt3.Rows.Count

'                '=== 標頭資訊 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Dim strY = "■有 □無"
'                Dim strN = "□有 ■無"

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", channelName))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", licenseStart))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", licenseEnd))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_S_DATE", evaluationStart))
'                valuesToFill.Fields.Add(New FieldContent("EVALUATION_E_DATE", evaluationEnd))
'                valuesToFill.Fields.Add(New FieldContent("YN1", If(count1 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN2", If(count2 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN3", If(count3 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("COUNT1", count1))
'                valuesToFill.Fields.Add(New FieldContent("COUNT2", count2))
'                valuesToFill.Fields.Add(New FieldContent("COUNT3", count3))

'                '=== 表格資料 ===
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    tb.InsertRow(tr1, 3)
'                    If dt3.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt3.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    tb.InsertRow(tr1, 3)
'                    If dt2.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt2.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    If dt1.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt1.Rows.Count - 2
'                            tb.InsertRow(tr2, 3)
'                        Next
'                    End If

'                    '塞資料
'                    Dim str = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str1 = "■已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str2 = "□已執行" & Chr(10) & "■執行中" & Chr(10) & "□尚未執行"
'                    Dim str3 = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "■尚未執行"

'                    Dim i As Integer = 1
'                    tb.Rows(i).Cells(0).Paragraphs.First().ReplaceText("一", "附款")
'                    If dt1.Rows.Count = 1 Then
'                        tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dt1.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt1.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt1.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("PAGE_NO"))

'                        tb.Rows(i + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(i + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(i + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt1.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt1.Rows
'                            tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            i += 1
'                        Next
'                    Else
'                        Dim _i As Integer = i + 1
'                        For var_i As Integer = i To _i
'                            tb.Rows(var_i).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_i).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_i).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim j As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + 1
'                    tb.Rows(j).Cells(0).Paragraphs.First().ReplaceText("一", "承諾事項")
'                    If dt2.Rows.Count = 1 Then
'                        tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dt2.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt2.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt2.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("PAGE_NO"))

'                        tb.Rows(j + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(j + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(j + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt2.Rows
'                            tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            j += 1
'                        Next
'                    Else
'                        Dim _j As Integer = j + 1
'                        For var_j As Integer = j To _j
'                            tb.Rows(var_j).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_j).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_j).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim k As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + If(dt2.Rows.Count < 2, 2, dt2.Rows.Count) + 1
'                    tb.Rows(k).Cells(0).Paragraphs.First().ReplaceText("一", "行政指導")
'                    If dt3.Rows.Count = 1 Then
'                        tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dt3.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt3.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt3.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("PAGE_NO"))

'                        tb.Rows(k + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(k + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(k + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt3.Rows
'                            tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            k += 1
'                        Next
'                    Else
'                        Dim _k As Integer = k + 1
'                        For var_k As Integer = k To _k
'                            tb.Rows(var_k).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_k).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_k).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    document.Save()
'                End Using

'                '=== 將容器資料對應到暫存檔並存檔 ===
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120121"
'        Public Function APP120121(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申設或換照承諾事項及應改善(或改正)事項之執行情形]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = "Word範本檔不存在"
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料                
'                '標頭
'                Dim ctrl1010 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl1010.CASE_NO = caseNo '案號
'                Dim dt標頭 As DataTable = Me.BindDDFormat(ctrl1010.DoQuery(), FormatType.Report)
'                Dim channelName = String.Empty
'                Dim licenseStart = String.Empty
'                Dim licenseEnd = String.Empty

'                If dt標頭.Rows.Count > 0 Then
'                    Dim dr As DataRow = dt標頭.Rows(0)
'                    channelName = If(String.IsNullOrEmpty(dr("SYS_CNAME").ToString()), "", dr("SYS_CNAME"))
'                    licenseStart = If(String.IsNullOrEmpty(dr("LICENSE_S_DATE").ToString()), "   /  /  ", dr("LICENSE_S_DATE"))
'                    licenseEnd = If(String.IsNullOrEmpty(dr("LICENSE_E_DATE").ToString()), "   /  /  ", dr("LICENSE_E_DATE"))
'                End If

'                '內容
'                Dim ctrl As CtAPP1140 = New CtAPP1140(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                ctrl.QUERY_COND += " AND R1.SYS_PRTID = 'A'"
'                ctrl.OrderBys = " COMPLY_TYPE_NM DESC "
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]"
'                    Return rptModel
'                End If

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A01' "
'                Dim dt1 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count1 As Integer = dt1.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A02' "
'                Dim dt2 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count2 As Integer = dt2.Rows.Count

'                dt案件.DefaultView.RowFilter = " COMPLY_TYPE = 'A03' "
'                Dim dt3 As DataTable = dt案件.DefaultView.ToTable()
'                Dim count3 As Integer = dt3.Rows.Count

'                '=== 標頭資訊 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Dim strY = "■有 □無"
'                Dim strN = "□有 ■無"

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_NAME", channelName))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_S_DATE", licenseStart))
'                valuesToFill.Fields.Add(New FieldContent("LICENSE_E_DATE", licenseEnd))
'                valuesToFill.Fields.Add(New FieldContent("YN1", If(count1 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN2", If(count2 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("YN3", If(count3 > 0, strY, strN)))
'                valuesToFill.Fields.Add(New FieldContent("COUNT1", count1))
'                valuesToFill.Fields.Add(New FieldContent("COUNT2", count2))
'                valuesToFill.Fields.Add(New FieldContent("COUNT3", count3))

'                '=== 表格資料 ===
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    tb.InsertRow(tr1, 3)
'                    If dt3.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt3.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    tb.InsertRow(tr1, 3)
'                    If dt2.Rows.Count = 1 Then
'                        tb.InsertRow(tr2, 4)
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt2.Rows.Count - 1
'                            tb.InsertRow(tr2, 4)
'                        Next
'                    Else
'                        tb.InsertRow(tr2, 4)
'                    End If

'                    If dt1.Rows.Count >= 2 Then
'                        For row As Integer = 1 To dt1.Rows.Count - 2
'                            tb.InsertRow(tr2, 3)
'                        Next
'                    End If

'                    '塞資料
'                    Dim str = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str1 = "■已執行" & Chr(10) & "□執行中" & Chr(10) & "□尚未執行"
'                    Dim str2 = "□已執行" & Chr(10) & "■執行中" & Chr(10) & "□尚未執行"
'                    Dim str3 = "□已執行" & Chr(10) & "□執行中" & Chr(10) & "■尚未執行"

'                    Dim i As Integer = 1
'                    tb.Rows(i).Cells(0).Paragraphs.First().ReplaceText("一", "承諾事項")
'                    If dt1.Rows.Count = 1 Then
'                        tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dt1.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt1.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt1.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dt1.Rows(0)("PAGE_NO"))

'                        tb.Rows(i + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(i + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(i + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt1.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt1.Rows
'                            tb.Rows(i).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(i).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(i).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            i += 1
'                        Next
'                    Else
'                        Dim _i As Integer = i + 1
'                        For var_i As Integer = i To _i
'                            tb.Rows(var_i).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_i).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_i).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim j As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + 1
'                    tb.Rows(j).Cells(0).Paragraphs.First().ReplaceText("一", "改善事項")
'                    If dt2.Rows.Count = 1 Then
'                        tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dt2.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt2.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt2.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dt2.Rows(0)("PAGE_NO"))

'                        tb.Rows(j + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(j + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(j + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt2.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt2.Rows
'                            tb.Rows(j).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(j).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(j).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            j += 1
'                        Next
'                    Else
'                        Dim _j As Integer = j + 1
'                        For var_j As Integer = j To _j
'                            tb.Rows(var_j).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_j).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_j).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    Dim k As Integer = If(dt1.Rows.Count < 2, 2, dt1.Rows.Count) + If(dt2.Rows.Count < 2, 2, dt2.Rows.Count) + 1
'                    tb.Rows(k).Cells(0).Paragraphs.First().ReplaceText("一", "改正事項")
'                    If dt3.Rows.Count = 1 Then
'                        tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("COMPLY_DESC"))
'                        tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dt3.Rows(0)("COMPLY_RESULT") = "1", str1, If(dt3.Rows(0)("COMPLY_RESULT") = "2", str2, If(dt3.Rows(0)("COMPLY_RESULT") = "3", str3, ""))))
'                        tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dt3.Rows(0)("PAGE_NO"))

'                        tb.Rows(k + 1).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                        tb.Rows(k + 1).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                        tb.Rows(k + 1).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                    ElseIf dt3.Rows.Count >= 2 Then
'                        For Each dr As DataRow In dt3.Rows
'                            tb.Rows(k).Cells(1).Paragraphs.First().ReplaceText("一", dr("COMPLY_DESC"))
'                            tb.Rows(k).Cells(2).Paragraphs.First().ReplaceText("一", If(dr("COMPLY_RESULT") = "1", str1, If(dr("COMPLY_RESULT") = "2", str2, If(dr("COMPLY_RESULT") = "3", str3, ""))))
'                            tb.Rows(k).Cells(3).Paragraphs.First().ReplaceText("一", dr("PAGE_NO"))
'                            k += 1
'                        Next
'                    Else
'                        Dim _k As Integer = k + 1
'                        For var_k As Integer = k To _k
'                            tb.Rows(var_k).Cells(1).Paragraphs.First().ReplaceText("一", "")
'                            tb.Rows(var_k).Cells(2).Paragraphs.First().ReplaceText("一", str)
'                            tb.Rows(var_k).Cells(3).Paragraphs.First().ReplaceText("一", "")
'                        Next
'                    End If

'                    document.Save()
'                End Using

'                '=== 將容器資料對應到暫存檔並存檔 ===
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP120101"
'        Public Function APP120101(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[公司基本資料]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = "Word範本檔不存在"
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY
'                    Return rptModel
'                End If

'                dt案件.Columns.Add("評鑑期間")
'                dt案件.Columns.Add("執照效期")
'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("PLAY_S_DATE").ToString().Length >= 7 Then
'                    dr("開播日期") = dr("PLAY_S_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                dr("評鑑期間") = DateUtil.FormatCDate(dr("EVALUATION_S_DATE").ToString) + "~" + DateUtil.FormatCDate(dr("EVALUATION_E_DATE").ToString)
'                dr("執照效期") = DateUtil.FormatCDate(dr("LICENSE_S_DATE").ToString) + "~" + DateUtil.FormatCDate(dr("LICENSE_E_DATE").ToString)

'                For Each col_nm As DataColumn In dt案件.Columns
'                    If Regex.IsMatch(col_nm.ToString, "實收資本額|SB_AMT1|SB_AMT2|SB_AMT3|EMPLOYEE_NUMBER|SUBSCRIBE_NUMBER|CHANGE_STANDARD", RegexOptions.IgnoreCase) Then
'                        dr(col_nm) = String.Format("{0:#,#;0;0}", ToDecimal(dr(col_nm).ToString))
'                    End If
'                Next

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()

'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示                      
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                            End If
'                        End If
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110903"
'        Public Function APP110903(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[人事結構及行政組織]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = "Word範本檔不存在"
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    'errmsg = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY
'                    Return rptModel
'                End If

'                Dim drA() As DataRow

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                If dt表頭1.Rows.Count > 0 Then
'                    '處理電話區碼
'                    Dim area As String = dt表頭1.Rows(0)("CONTACT_AREA_CODE").ToString()
'                    Dim tel As String = dt表頭1.Rows(0)("CONTACT_TEL").ToString()
'                    If Not String.IsNullOrEmpty(area) Then
'                        tel = area & "-" & tel
'                    End If

'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))
'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))
'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", tel))
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If

'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料
'                    drA = dt案件.Select("TOPIC_SEQ = '1101'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1101", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If


'                    drA = dt案件.Select("TOPIC_SEQ = '1301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1301", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If


'                    drA = dt案件.Select("TOPIC_SEQ = '1303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1303", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1305'")
'                    If drA.Length > 0 Then
'                        Dim Y As String = "■", N As String = "□"
'                        If drA(0)("SERVICE_TEL_FLAG").ToString() = "Y" Then
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_TEL_FLAG", Y))
'                        Else
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_TEL_FLAG", N))
'                        End If

'                        If drA(0)("SERVICE_EMAIL_FLAG").ToString() = "Y" Then
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_EMAIL_FLA", Y))
'                        Else
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_EMAIL_FLA", N))
'                        End If

'                        If drA(0)("SERVICE_ACTIVE_FLAG").ToString() = "Y" Then
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_ACTIVE_FLAG", Y))
'                        Else
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_ACTIVE_FLAG", N))
'                        End If

'                        If drA(0)("SERVICE_OTHER_FLAG").ToString() = "Y" Then
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_OTHER_FLAG", Y))
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_OTHER_DESC", Convert.ToString(drA(0)("SERVICE_OTHER_DESC"))))
'                        Else
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_OTHER_FLAG", N))
'                            valuesToFill.Fields.Add(New FieldContent("M_SERVICE_OTHER_DESC", Convert.ToString(drA(0)("SERVICE_OTHER_DESC"))))
'                        End If
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1306'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1306", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1401'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1401", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1402'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1402", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1403'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1403", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1404'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1404", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1405'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1405", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1406'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1406", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1408'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1408", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1409'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1409", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1411'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1411", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1412'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1412", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1413'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1413", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1502'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1502", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1703'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1703", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1704'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1704", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1705'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1705", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1706'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1706", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1707'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1707", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1708'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1708", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If
'                End If

'                Dim ctrl1 As CtAPP1410 = New CtAPP1410(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.OrderBys = "TBL_RECID ASC"
'                Dim dt As DataTable = ctrl1.DoQuery()

'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1410")

'                    dt.Columns.Add("COUNT")
'                    Dim MN As Integer = 0
'                    Dim NMN As Integer = 0
'                    Dim COUNT As Integer = 0
'                    Dim COUNTS As Integer = 0
'                    For Each dr As DataRow In dt.Rows
'                        COUNT = (Int32.Parse(dr("MANAGER_NUMBER")) + Int32.Parse(dr("NON_MANAGER_NUMBER"))).ToString()
'                        dr("COUNT") = COUNT
'                        MN = MN + Int32.Parse(dr("MANAGER_NUMBER"))
'                        NMN = NMN + Int32.Parse(dr("NON_MANAGER_NUMBER"))
'                        COUNTS = COUNTS + COUNT
'                    Next

'                    Dim New_dr As DataRow = dt.NewRow
'                    New_dr("PKNO") = 0
'                    New_dr("TBL_RECID") = 0
'                    New_dr("DEPT_NAME") = "總計"
'                    New_dr("MANAGER_NUMBER") = MN
'                    New_dr("NON_MANAGER_NUMBER") = NMN
'                    New_dr("COUNT") = COUNTS
'                    dt.Rows.Add(New_dr)


'                    For Each dr1 As DataRow In dt.Rows
'                        tableContent.AddRow(
'                        New FieldContent("DEPT_NAME", Convert.ToString(dr1("DEPT_NAME"))),
'                        New FieldContent("MANAGER_NUMBER", Convert.ToString(dr1("MANAGER_NUMBER"))),
'                        New FieldContent("NON_MANAGER_NUMBER", Convert.ToString(dr1("NON_MANAGER_NUMBER"))),
'                         New FieldContent("COUNT", Convert.ToString(dr1("COUNT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                Dim ItemList() As String = {"HOURS_TOTAL", "INTERNAL_ALL_RATE", "INTERNAL_MASTER_RATE", "EXTERNAL_ALL_RATE", "EXTERNAL_MASTER_RATE", "JOIN_ALL_RATE", "JOIN_MASTER_RATE", "ITEM01_RATE", "ITEM02_RATE", "ITEM03_RATE", "ITEM04_RATE", "ITEM05_RATE", "ITEM06_RATE", "ITEM07_RATE", "ITEM08_RATE", "ITEM09_RATE", "ITEM10_RATE", "INTERNAL_RATE", "EXTERNAL_RATE"}

'                Dim ctrl2 As CtAPP1420 = New CtAPP1420(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1420 As DataTable = ctrl2.DoQuery()

'                If dt1420.Rows.Count > 0 Then
'                    For Each Item As String In ItemList
'                        For i As Integer = 1 To 3
'                            Dim dr1420() As DataRow
'                            dr1420 = dt1420.Select("Year = '" + i.ToString() + "'")
'                            '塞變數資料
'                            If dr1420.Length > 0 Then
'                                valuesToFill.Fields.Add(New FieldContent(Item & "_" + i.ToString(), Convert.ToString(dr1420(0)(Item))))
'                            End If
'                        Next
'                    Next
'                End If

'                Dim ItemList2() As String = {"M_INCOME_DESC", "M_INCOME1_AMT", "M_INCOME2_AMT", "M_INCOME3_AMT", "O_INCOME_DESC", "O_INCOME1_AMT", "O_INCOME2_AMT", "O_INCOME3_AMT", "M_COST_DESC", "M_COST1_AMT", "M_COST2_AMT", "M_COST3_AMT", "O_COST_DESC", "O_COST1_AMT", "O_COST2_AMT", "O_COST3_AMT"}

'                Dim ctrl3 As CtAPP1450 = New CtAPP1450(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1450 As DataTable = ctrl3.DoQuery()

'                If dt1450.Rows.Count > 0 Then
'                    Dim dr1450 As DataRow = dt1450.Rows(0)
'                    For Each Item As String In ItemList2
'                        '塞變數資料
'                        valuesToFill.Fields.Add(New FieldContent("I_" & Item, Convert.ToString(dr1450(Item))))
'                    Next
'                End If

'                Dim ctrl4 As CtAPP1460 = New CtAPP1460(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1460 As DataTable = ctrl4.DoQuery()
'                Dim dr1460 As DataRow

'                If dt1460.Rows.Count > 0 Then
'                    dr1460 = dt1460.Rows(0)

'                    '塞變數資料
'                    Dim address As String = GetAddr(dr1460("RADIO_CITY"), "") & GetAddr("", dr1460("RADIO_ZIP")) & dr1460("RADIO_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_RADIO_ADDRESS", Convert.ToString(address)))
'                    valuesToFill.Fields.Add(New FieldContent("L_PRE_SETUP_DATE", DateUtil.ConvertFormatDate(dr1460("PRE_SETUP_DATE").ToString())))
'                    valuesToFill.Fields.Add(New FieldContent("L_PRE_POPULATION", Convert.ToString(dr1460("PRE_POPULATION"))))

'                    '塞變數資料
'                    address = GetAddr(dr1460("STUDIO_CITY"), "") & GetAddr("", dr1460("STUDIO_ZIP")) & dr1460("STUDIO_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_STUDIO_ADDRESS", Convert.ToString(address)))
'                    valuesToFill.Fields.Add(New FieldContent("L_SITE_NUMBER", Convert.ToString(dr1460("SITE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("L_M_SITE_NUMBER", Convert.ToString(dr1460("M_SITE_NUMBER"))))

'                    '塞變數資料
'                    address = GetAddr(dr1460("BUSINESS_CITY"), "") & GetAddr("", dr1460("BUSINESS_ZIP")) & dr1460("BUSINESS_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_BUSINESS_ADDRESS", Convert.ToString(address)))

'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110813"
'        Public Function APP110813(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[董監事名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案件編號不存在。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "1"  '董事名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()
'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                If (dt.Rows.Count > 0) Then
'                    Dim tableContent As TableContent = New TableContent("APP1030")

'                    For Each dr As DataRow In dt.Rows
'                        Dim address As String = GetAddr(dr("ADDR_CITY1"), "") & GetAddr("", dr("ADDR_CITY2")) & dr("ADDR")
'                        tableContent.AddRow(
'                        New FieldContent("USER_NAME", Convert.ToString(dr("USER_NAME"))),
'                        New FieldContent("USER_ID", Convert.ToString(dr("USER_ID"))),
'                        New FieldContent("BIRTHDAY_DATE", DateUtil.ConvertFormatDate(dr("BIRTHDAY_DATE"))),
'                        New FieldContent("ADDR", address),
'                        New FieldContent("EXPERIENCE", If(String.IsNullOrEmpty(dr("EXPERIENCE").ToString()), "", dr("EXPERIENCE"))),
'                        New FieldContent("JOB_TITLE", If(String.IsNullOrEmpty(dr("JOB_TITLE").ToString()), "", dr("JOB_TITLE"))),
'                        New FieldContent("OM_SHARES", If(String.IsNullOrEmpty(dr("OM_SHARES").ToString()), "", dr("OM_SHARES"))),
'                        New FieldContent("OB_NAME", If(String.IsNullOrEmpty(dr("OB_NAME").ToString()), "", dr("OB_NAME")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110810"
'        Public Function APP110810(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[股東名冊]"
'                Dim dt As New DataTable

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = msgTitle + errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案件編號不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "4"  '股東名冊
'                ctrl.CASE_NO = caseNo
'                dt = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsnum As Integer = dt.Rows.Count
'                    Dim i As Integer = (rowsnum / 6) + IIf(rowsnum Mod 6 > 0, 1, 0)

'                    For j As Integer = 1 To i - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    Dim l As Integer = 1, m As Integer = 1
'                    For k As Integer = 0 To rowsnum - 1
'                        If (l > 6) Then
'                            l = 1
'                            tb = document.Tables(m)
'                            m += 1
'                        End If
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        tb.Rows(0).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("USER_NAME")))
'                        tb.Rows(1).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("USER_ID")))
'                        tb.Rows(2).Cells(l).ReplaceText("取代", If(String.IsNullOrEmpty(Convert.ToDateTime(dt.Rows(k)("BIRTHDAY_DATE")).ToShortDateString()), "", Convert.ToDateTime(dt.Rows(k)("BIRTHDAY_DATE")).ToShortDateString()))
'                        tb.Rows(3).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("SHARES_NUMBER")))
'                        tb.Rows(4).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("SHARES_RATE")))
'                        tb.Rows(5).Cells(l).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("CONTRIBUTION_AMT").ToString()))
'                        tb.Rows(6).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OB_NAME")))
'                        tb.Rows(7).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OB_SHARES_RATE")))
'                        tb.Rows(8).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OB_NAME1")))
'                        tb.Rows(9).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OB_JOB1")))
'                        tb.Rows(10).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OS_NAME1")))
'                        tb.Rows(11).Cells(l + 1).ReplaceText("取代", Convert.ToString(dt.Rows(k)("OS_JOB1")))
'                        tb.Rows(12).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("EXPERIENCE")))
'                        tb.Rows(13).Cells(l).ReplaceText("取代", address)
'                        tb.Rows(14).Cells(l).ReplaceText("取代", Convert.ToString(dt.Rows(k)("TEL")))
'                        l += 1
'                    Next

'                    For j As Integer = 0 To i - 1
'                        tb = document.Tables(j)
'                        For k As Integer = 0 To 14
'                            For l = 1 To 6
'                                If k > 5 And k < 12 Then
'                                    tb.Rows(k).Cells(l + 1).ReplaceText("取代", "")
'                                Else
'                                    tb.Rows(k).Cells(l).ReplaceText("取代", "")
'                                End If

'                            Next
'                        Next
'                    Next
'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110802"
'        Public Function APP110802(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[廣播事業]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"

'                If Not IO.File.Exists(Templatefilename) Then
'                    'result = "Word範本檔不存在"
'                    'rptModel.ERRMSG = result
'                    'Return rptModel
'                    'Exit Function
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename

'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '主檔資料
'                Dim ctrl As CtAPP1400 = New CtAPP1400(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = ctrl.DoQuery()

'                If dt案件.Rows.Count <= 0 Then
'                    'result = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    'rptModel.ERRMSG = result
'                    'Return rptModel
'                    'Exit Function
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '表頭資料
'                '表頭1
'                Dim ctrl表頭1 As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl表頭1.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭1 As DataTable = ctrl表頭1.DoQuery()
'                '表頭2
'                Dim ctrl表頭2 As CtAPPL020 = New CtAPPL020(_dbManager, _logUtil)
'                ctrl表頭2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt表頭2 As DataTable = ctrl表頭2.DoQuery()

'                Dim drA() As DataRow

'                If dt表頭1.Rows.Count > 0 Then
'                    '處理電話區碼
'                    Dim area As String = dt表頭1.Rows(0)("CONTACT_AREA_CODE").ToString()
'                    Dim tel As String = dt表頭1.Rows(0)("CONTACT_TEL").ToString()
'                    If Not String.IsNullOrEmpty(area) Then
'                        tel = area & "-" & tel
'                    End If

'                    valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dt表頭1.Rows(0)("APP_PERSON_NM"))))
'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_PERSON", Convert.ToString(dt表頭1.Rows(0)("CONTACT_PERSON"))))
'                    valuesToFill.Fields.Add(New FieldContent("CONTACT_TEL", tel))
'                End If

'                If dt表頭2.Rows.Count > 0 Then
'                    Dim Year As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).AddYears(-1911).Year.ToString().PadLeft(3, "0")
'                    Dim Month As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Month.ToString().PadLeft(2, "0")
'                    Dim Day As String = Convert.ToDateTime(dt表頭2.Rows(0)("CREATE_TIME")).Day.ToString().PadLeft(2, "0")

'                    valuesToFill.Fields.Add(New FieldContent("Year", Year))

'                    valuesToFill.Fields.Add(New FieldContent("Month", Month))

'                    valuesToFill.Fields.Add(New FieldContent("Day", Day))
'                End If

'                If dt案件.Rows.Count > 0 Then
'                    '塞變數資料
'                    drA = dt案件.Select("TOPIC_SEQ = '1101'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1101", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1102'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1102", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1201'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1201", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1202'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1202", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1203'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1203", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1204'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1204", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1301'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1301", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1302'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1302", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1303'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1303", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1304'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1304", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1305'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1305", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1306'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1306", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1307'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1307", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1308'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1308", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1401'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1401", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1402'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1402", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1403'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1403", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1404'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1404", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1405'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1405", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1406'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1406", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1407'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1407", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1408'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1408", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1409'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1409", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1410'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1410", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1411'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1411", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1412'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1412", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1413'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1413", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1501'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1501", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1502'")
'                    If drA.Length > 0 Then
'                        Dim M_TOPIC_RESULT As String = ""
'                        If Not String.IsNullOrEmpty(drA(0)("TOPIC_RESULT").ToString()) Then
'                            M_TOPIC_RESULT = If(drA(0)("TOPIC_RESULT").ToString() = "Y", "是", "否")
'                        End If
'                        valuesToFill.Fields.Add(New FieldContent("M_TOPIC_RESULT", Convert.ToString(M_TOPIC_RESULT)))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1503'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1503", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1601'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1601", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1602'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1602", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1603'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1603", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1701'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1701", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1702'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1702", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1703'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1703", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1704'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1704", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1705'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1705", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1706'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1706", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1707'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1707", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1708'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1708", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If
'                    drA = dt案件.Select("TOPIC_SEQ = '1801'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1801", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1802'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1802", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If

'                    drA = dt案件.Select("TOPIC_SEQ = '1803'")
'                    If drA.Length > 0 Then
'                        valuesToFill.Fields.Add(New FieldContent("TOPIC_ANSWER_1803", Convert.ToString(drA(0)("TOPIC_ANSWER"))))
'                    End If
'                End If

'                Dim ctrl1 As CtAPP1410 = New CtAPP1410(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.OrderBys = "TBL_RECID ASC"
'                Dim dt As DataTable = ctrl1.DoQuery()

'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1410")

'                    dt.Columns.Add("COUNT")
'                    Dim MN As Integer = 0
'                    Dim NMN As Integer = 0
'                    Dim COUNT As Integer = 0
'                    Dim COUNTS As Integer = 0
'                    For Each dr As DataRow In dt.Rows
'                        COUNT = (Int32.Parse(dr("MANAGER_NUMBER")) + Int32.Parse(dr("NON_MANAGER_NUMBER"))).ToString()
'                        dr("COUNT") = COUNT
'                        MN = MN + Int32.Parse(dr("MANAGER_NUMBER"))
'                        NMN = NMN + Int32.Parse(dr("NON_MANAGER_NUMBER"))
'                        COUNTS = COUNTS + COUNT
'                    Next

'                    Dim New_dr As DataRow = dt.NewRow
'                    New_dr("PKNO") = 0
'                    New_dr("TBL_RECID") = 0
'                    New_dr("DEPT_NAME") = "總計"
'                    New_dr("MANAGER_NUMBER") = MN
'                    New_dr("NON_MANAGER_NUMBER") = NMN
'                    New_dr("COUNT") = COUNTS
'                    dt.Rows.Add(New_dr)


'                    For Each dr1 As DataRow In dt.Rows
'                        tableContent.AddRow(
'                        New FieldContent("DEPT_NAME", Convert.ToString(dr1("DEPT_NAME"))),
'                        New FieldContent("MANAGER_NUMBER", Convert.ToString(dr1("MANAGER_NUMBER"))),
'                        New FieldContent("NON_MANAGER_NUMBER", Convert.ToString(dr1("NON_MANAGER_NUMBER"))),
'                         New FieldContent("COUNT", Convert.ToString(dr1("COUNT")))
'                        )
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If


'                Dim ItemList() As String = {"HOURS_TOTAL", "INTERNAL_ALL_RATE", "INTERNAL_MASTER_RATE", "EXTERNAL_ALL_RATE", "EXTERNAL_MASTER_RATE", "JOIN_ALL_RATE", "JOIN_MASTER_RATE", "ITEM01_RATE", "ITEM02_RATE", "ITEM03_RATE", "ITEM04_RATE", "ITEM05_RATE", "ITEM06_RATE", "ITEM07_RATE", "ITEM08_RATE", "ITEM09_RATE", "ITEM10_RATE", "INTERNAL_RATE", "EXTERNAL_RATE"}

'                Dim ctrl2 As CtAPP1420 = New CtAPP1420(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1420 As DataTable = ctrl2.DoQuery()

'                If dt1420.Rows.Count > 0 Then
'                    For Each Item As String In ItemList
'                        For i As Integer = 1 To 3
'                            Dim dr1420() As DataRow
'                            dr1420 = dt1420.Select("Year = '" + i.ToString() + "'")
'                            '塞變數資料
'                            If dr1420.Length > 0 Then
'                                valuesToFill.Fields.Add(New FieldContent(Item & "_" + i.ToString(), Convert.ToString(dr1420(0)(Item))))
'                            End If
'                        Next
'                    Next
'                End If

'                Dim ItemList2() As String = {"M_INCOME_DESC", "M_INCOME1_AMT", "M_INCOME2_AMT", "M_INCOME3_AMT", "O_INCOME_DESC", "O_INCOME1_AMT", "O_INCOME2_AMT", "O_INCOME3_AMT", "M_COST_DESC", "M_COST1_AMT", "M_COST2_AMT", "M_COST3_AMT", "O_COST_DESC", "O_COST1_AMT", "O_COST2_AMT", "O_COST3_AMT"}

'                Dim ctrl3 As CtAPP1450 = New CtAPP1450(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1450 As DataTable = ctrl3.DoQuery()

'                If dt1450.Rows.Count > 0 Then
'                    Dim dr1450 As DataRow = dt1450.Rows(0)
'                    For Each Item As String In ItemList2
'                        '塞變數資料
'                        valuesToFill.Fields.Add(New FieldContent("I_" & Item, Convert.ToString(dr1450(Item))))
'                    Next
'                End If

'                Dim ctrl4 As CtAPP1460 = New CtAPP1460(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt1460 As DataTable = ctrl4.DoQuery()
'                Dim dr1460 As DataRow

'                If dt1460.Rows.Count > 0 Then
'                    dr1460 = dt1460.Rows(0)

'                    '塞變數資料
'                    Dim address As String = GetAddr(dr1460("RADIO_CITY"), "") & GetAddr("", dr1460("RADIO_ZIP")) & dr1460("RADIO_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_RADIO_ADDRESS", Convert.ToString(address)))
'                    valuesToFill.Fields.Add(New FieldContent("L_PRE_SETUP_DATE", DateUtil.ConvertFormatDate(dr1460("PRE_SETUP_DATE").ToString())))
'                    valuesToFill.Fields.Add(New FieldContent("L_PRE_POPULATION", Convert.ToString(dr1460("PRE_POPULATION"))))

'                    '塞變數資料
'                    address = GetAddr(dr1460("STUDIO_CITY"), "") & GetAddr("", dr1460("STUDIO_ZIP")) & dr1460("STUDIO_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_STUDIO_ADDRESS", Convert.ToString(address)))
'                    valuesToFill.Fields.Add(New FieldContent("L_SITE_NUMBER", Convert.ToString(dr1460("SITE_NUMBER"))))
'                    valuesToFill.Fields.Add(New FieldContent("L_M_SITE_NUMBER", Convert.ToString(dr1460("M_SITE_NUMBER"))))

'                    '塞變數資料
'                    address = GetAddr(dr1460("BUSINESS_CITY"), "") & GetAddr("", dr1460("BUSINESS_ZIP")) & dr1460("BUSINESS_ADDRESS")

'                    valuesToFill.Fields.Add(New FieldContent("L_BUSINESS_ADDRESS", Convert.ToString(address)))

'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110801"
'        Public Function APP110801(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo

'                '=== 呼叫control ===
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Dim address As String = GetAddr(dr("BUSINESS_CITY"), "") & GetAddr("", dr("BUSINESS_ZIP")) & dr("BUSINESS_ADDRESS")

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", Convert.ToString(dr("APP_PERSON_NM"))))
'                valuesToFill.Fields.Add(New FieldContent("APP_NAME", Convert.ToString(dr("APP_NAME"))))
'                valuesToFill.Fields.Add(New FieldContent("BUSINESS_ADDRESS", address))
'                valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", String.Format(CultureInfo.InvariantCulture,
'                                "{0:0,0}", ToDecimal(IIf(IsDBNull(dr("TOTAL_PROPERTY")), "", dr("TOTAL_PROPERTY"))))))
'                If (Convert.ToString(dr("ORG_TYPE")) = "07") Then
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE1", "■"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", "□"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE3", "□"))
'                ElseIf (Convert.ToString(dr("ORG_TYPE")) = "08") Then
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE1", "□"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", "■"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE3", "□"))
'                Else
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE1", "□"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE2", "□"))
'                    valuesToFill.Fields.Add(New FieldContent("ORG_TYPE3", "■"))
'                End If

'                Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl1.DoQuery()


'                Dim Total_PROPORTION As Decimal
'                If (dt.Rows.Count > 0) Then
'                    Total_PROPORTION = 0
'                    Dim tableContent As TableContent = New TableContent("APP1020")
'                    For Each dr1 As DataRow In dt.Rows
'                        tableContent.AddRow(
'                    New FieldContent("FOREIGNER_SHOLDER_NM", Convert.ToString(dr1("FOREIGNER_SHOLDER_NM"))),
'                    New FieldContent("PROPORTION", Convert.ToString(dr1("PROPORTION")))
'                    )
'                        Total_PROPORTION += ToDecimal(dr1("PROPORTION"))
'                    Next

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent)
'                End If

'                valuesToFill.Fields.Add(New FieldContent("Total_PROPORTION", Convert.ToString(Total_PROPORTION)))

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110402"
'        Public Function APP110402(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營運計畫摘要表]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1041 = New CtAPP1041(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoWordQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                'DDL
'                Dim ctrlT As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)

'                '信號傳輸方式
'                ctrlT.SYS_KEY = "TRANS_TYPE"
'                ctrlT.SYS_TYPE = "1"
'                ctrlT.USE_STATE = "1"
'                ctrlT.SYS_ID = dr("TRANS_TYPE").ToString
'                ctrlT.OrderBys = "SYS_ID"
'                Dim dt As DataTable = ctrlT.Get系統下拉資料

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME", dt.Rows(0)("SYS_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME_FLAG", IIf(dt.Rows(0)("SYS_ID").ToString = "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC", dr("TRANS_DESC").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC_FLAG", IIf(dt.Rows(0)("SYS_ID").ToString <> "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_BACKUP", dr("TRANS_BACKUP").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_FLAG", IIf(dr("SERVICE_F_FLAG").ToString = "Y", "是，與" & dr("SERVICE_F_DESC") & "共用", "否，與" & dr("SERVICE_F_DESC") & "共用")))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_FLAG", IIf(dr("SERVICE_P_FLAG").ToString = "Y", "是，與" & dr("SERVICE_P_DESC") & "共用", "否，與" & dr("SERVICE_P_DESC") & "共用")))

'                valuesToFill.Fields.Add(New FieldContent("DESC01", dr("DESC01").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC02", dr("DESC02").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC03", dr("DESC03").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC04", dr("DESC04").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC05", dr("DESC05").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC06", dr("DESC06").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC07", dr("DESC07").ToString))
'                valuesToFill.Fields.Add(New FieldContent("UNIVERSAL_RATE", dr("UNIVERSAL_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROTECTION_RATE", dr("PROTECTION_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY12_RATE", dr("SECONDARY12_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY15_RATE", dr("SECONDARY15_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LIMITATION_RATE", dr("LIMITATION_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC08", dr("DESC08").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC09", dr("DESC09").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_NUMBER", dr("SERVICE_F_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_NUMBER", dr("SERVICE_P_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_ALL_NUMBER", (ToDecimal(dr("SERVICE_F_NUMBER").ToString) + ToDecimal(dr("SERVICE_P_NUMBER").ToString)).ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_SHARE_NUMBER", dr("SERVICE_F_SHARE_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_SHARE_NUMBER", dr("SERVICE_P_SHARE_NUMBER").ToString))

'                valuesToFill.Fields.Add(New FieldContent("ORG_NAME", dr("ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_FREQ", dr("MEETING_FREQ").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_PEOPLE", dr("MEETING_PEOPLE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG", IIf(dr("SELFORG_FLAG").ToString() = "Y", "是", "否")))


'                '塞Table資料(品管人員)
'                '品管人員組織編制與職掌
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If

'                '塞Table資料(APP1060)
'                '學經歷介紹
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                New FieldContent("CH_NAME", dr1("CH_NAME")),
'                New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If

'                '塞Table資料(APP1160)
'                '內部自律組織
'                Dim ctrl6 As CtAPP1160 = New CtAPP1160(_dbManager, _logUtil)
'                ctrl6.CASE_NO = caseNo
'                Dim dt委員 As DataTable = ctrl6.DoQuery()

'                If dt委員.Rows.Count > 0 Then
'                    Dim tableContent6 As TableContent = New TableContent("APP1160") 'APP1160為範本中定義的變數名
'                    For Each dr1 As DataRow In dt委員.Rows
'                        tableContent6.AddRow(
'                New FieldContent("MEMBER_NAME", dr1("MEMBER_NAME")),
'                New FieldContent("SEX_TYPE_TXT", dr1("SEX_TYPE_TXT")),
'                New FieldContent("TEACHER_TYPE_TXT", dr1("TEACHER_TYPE_TXT"))
'                )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent6)
'                End If

'                '塞Table資料(APP1070)
'                '員工教育訓練規畫
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                New FieldContent("FUNDING", String.Format("{0:#,###}", CInt(dr1("FUNDING"))).ToString)
'                )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", CInt(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If


'                '塞Table資料(客服人員)
'                Dim ctrl2 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                ctrl2.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl2.DoQuery()

'                Dim tableContent2 As TableContent = New TableContent("APP1050_2") 'APP1050_2為範本中定義的變數名

'                If (dt客服.Rows.Count > 0) Then
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent2.AddRow(
'                New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                New FieldContent("CH_NAME", dr1("CH_NAME")),
'                New FieldContent("JOBTITLE", dr1("JOBTITLE"))
'                )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT2 = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT2_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT2_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT2))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_1", sum_PTTCH_FT2_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_2", sum_PTTCH_FT2_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent2)

'                End If

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110401"
'        Public Function APP110401(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申請書]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                Dim dt股份 As DataTable = ctrl1.DoQuery()

'                Dim ctrl2 As CtAPP1150 = New CtAPP1150(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                Dim dt頻道 As DataTable = Me.BindDDFormat(ctrl2.DoQuery(), FormatType.Edit)


'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"


'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()
'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                If (bookmark.Name = "實收資本額") Then
'                                    If dr(bookmark.Name).ToString = "" Then
'                                        document.Bookmarks(bookmark.Name).SetText("")
'                                    Else
'                                        document.Bookmarks(bookmark.Name).SetText(String.Format("{0:#,###}", Convert.ToDouble(dr(bookmark.Name))))
'                                    End If
'                                Else
'                                    document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                                End If
'                            End If
'                        End If
'                    Next


'                    '外國人直接持有之股份========================            
'                    Dim tbl_stock As Novacode.Table = document.Tables(0)
'                    Dim tr As Novacode.Row = tbl_stock.Rows(5) ' 股東空白列第一列

'                    Dim 預設筆數 As Integer = 4
'                    If dt股份.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt股份.Rows.Count - 預設筆數 - 1
'                            tbl_stock.InsertRow(tr, 5)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt股份.Rows.Count - 1
'                        tr = tbl_stock.Rows(5 + i)
'                        tr.Cells(2).ReplaceText("一", dt股份.Rows(i).Item("FOREIGNER_SHOLDER_NM").ToString())
'                        tr.Cells(3).ReplaceText("一", dt股份.Rows(i).Item("COUNTRY").ToString())
'                        If (dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString() = "") Then
'                            tr.Cells(4).ReplaceText("一", "")
'                        Else
'                            tr.Cells(4).ReplaceText("一", String.Format("{0:#,###}", CInt(dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString)))
'                        End If
'                        tr.Cells(5).ReplaceText("一", dt股份.Rows(i).Item("PROPORTION").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt股份.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt股份.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(5 + i)
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                        Next
'                    End If


'                    '頻道名稱=============================================
'                    Dim 頻道空白列第一列 = 24 + Math.Max(dt股份.Rows.Count, 預設筆數) - 預設筆數
'                    Dim tbl_channel As Novacode.Table = document.Tables(0)
'                    Dim tr_channel As Novacode.Row = tbl_channel.Rows(頻道空白列第一列) ' 頻道空白列第一列

'                    If dt頻道.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt頻道.Rows.Count - 預設筆數 - 1
'                            tbl_channel.InsertRow(tr_channel, 頻道空白列第一列)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt頻道.Rows.Count - 1
'                        tr = tbl_channel.Rows(頻道空白列第一列 + i)
'                        tr.Cells(1).ReplaceText("一", (i + 1).ToString())
'                        tr.Cells(2).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_NAME").ToString())
'                        tr.Cells(3).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_TYPE_NM").ToString())
'                        tr.Cells(4).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_S_DATE").ToString())
'                        tr.Cells(5).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_E_DATE").ToString())
'                        tr.Cells(6).ReplaceText("一", dt頻道.Rows(i).Item("PUNISH_NUMBER").ToString())
'                        If (dt頻道.Rows(i).Item("PUNISH_AMT").ToString() = "") Then
'                            tr.Cells(7).ReplaceText("一", "")
'                        Else
'                            tr.Cells(7).ReplaceText("一", String.Format("{0:#,###}", CInt(dt頻道.Rows(i).Item("PUNISH_AMT").ToString)))
'                        End If
'                        tr.Cells(8).ReplaceText("一", dt頻道.Rows(i).Item("COUNTRY_TYPE_NM").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt頻道.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt頻道.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(頻道空白列第一列 + i)
'                            tr.Cells(1).ReplaceText("一", "")
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                            tr.Cells(6).ReplaceText("一", "")
'                            tr.Cells(7).ReplaceText("一", "")
'                            tr.Cells(8).ReplaceText("一", "")
'                        Next
'                    End If

'                    '其他書籤            
'                    document.Bookmarks("頻道數目總計").SetText(dt頻道.Rows.Count().ToString())
'                    document.Bookmarks("境內數").SetText(dt頻道.Select("COUNTRY_TYPE='1'").Length().ToString())
'                    document.Bookmarks("境外數").SetText(dt頻道.Select("COUNTRY_TYPE='2'").Length().ToString())
'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110301"
'        Public Function APP110301(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申請書]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"

'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename

'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                End If

'                Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                Dim dt股份 As DataTable = ctrl1.DoQuery()

'                Dim ctrl2 As CtAPP1150 = New CtAPP1150(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                Dim dt頻道 As DataTable = Me.BindDDFormat(ctrl2.DoQuery(), FormatType.Edit)


'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"


'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()
'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                If (bookmark.Name = "實收資本額") Then
'                                    If dr(bookmark.Name).ToString = "" Then
'                                        document.Bookmarks(bookmark.Name).SetText("")
'                                    Else
'                                        document.Bookmarks(bookmark.Name).SetText(String.Format("{0:#,###}", Convert.ToDouble(dr(bookmark.Name))))
'                                    End If
'                                Else
'                                    document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                                End If
'                            End If
'                        End If
'                    Next


'                    '外國人直接持有之股份========================            
'                    Dim tbl_stock As Novacode.Table = document.Tables(0)
'                    Dim tr As Novacode.Row = tbl_stock.Rows(5) ' 股東空白列第一列

'                    Dim 預設筆數 As Integer = 4
'                    If dt股份.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt股份.Rows.Count - 預設筆數 - 1
'                            tbl_stock.InsertRow(tr, 5)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt股份.Rows.Count - 1
'                        tr = tbl_stock.Rows(5 + i)
'                        tr.Cells(2).ReplaceText("一", dt股份.Rows(i).Item("FOREIGNER_SHOLDER_NM").ToString())
'                        tr.Cells(3).ReplaceText("一", dt股份.Rows(i).Item("COUNTRY").ToString())
'                        If (dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString() = "") Then
'                            tr.Cells(4).ReplaceText("一", "")
'                        Else
'                            tr.Cells(4).ReplaceText("一", String.Format("{0:#,###}", CInt(dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString)))
'                        End If
'                        tr.Cells(5).ReplaceText("一", dt股份.Rows(i).Item("PROPORTION").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt股份.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt股份.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(5 + i)
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                        Next
'                    End If


'                    '頻道名稱=============================================
'                    Dim 頻道空白列第一列 = 33 + Math.Max(dt股份.Rows.Count, 預設筆數) - 預設筆數
'                    Dim tbl_channel As Novacode.Table = document.Tables(0)
'                    Dim tr_channel As Novacode.Row = tbl_channel.Rows(頻道空白列第一列) ' 頻道空白列第一列

'                    If dt頻道.Rows.Count > 預設筆數 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt頻道.Rows.Count - 預設筆數 - 1
'                            tbl_channel.InsertRow(tr_channel, 頻道空白列第一列)
'                        Next
'                    End If

'                    '塞資料

'                    For i As Integer = 0 To dt頻道.Rows.Count - 1
'                        tr = tbl_channel.Rows(頻道空白列第一列 + i)
'                        tr.Cells(1).ReplaceText("一", (i + 1).ToString())
'                        tr.Cells(2).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_NAME").ToString())
'                        tr.Cells(3).ReplaceText("一", dt頻道.Rows(i).Item("CHANNEL_TYPE_NM").ToString())
'                        tr.Cells(4).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_S_DATE").ToString())
'                        tr.Cells(5).ReplaceText("一", dt頻道.Rows(i).Item("LICENSE_E_DATE").ToString())
'                        tr.Cells(6).ReplaceText("一", dt頻道.Rows(i).Item("PUNISH_NUMBER").ToString())
'                        If (dt頻道.Rows(i).Item("PUNISH_AMT").ToString = "") Then
'                            tr.Cells(7).ReplaceText("一", "")
'                        Else
'                            tr.Cells(7).ReplaceText("一", String.Format("{0:#,###}", CInt(dt頻道.Rows(i).Item("PUNISH_AMT").ToString)))
'                        End If
'                        tr.Cells(8).ReplaceText("一", dt頻道.Rows(i).Item("COUNTRY_TYPE_NM").ToString())
'                    Next
'                    '不夠預設筆數的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt頻道.Rows.Count < 預設筆數 Then
'                        For i As Integer = dt頻道.Rows.Count - 1 To 預設筆數 - 1
'                            tr = tbl_stock.Rows(頻道空白列第一列 + i)
'                            tr.Cells(1).ReplaceText("一", "")
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                            tr.Cells(6).ReplaceText("一", "")
'                            tr.Cells(7).ReplaceText("一", "")
'                            tr.Cells(8).ReplaceText("一", "")
'                        Next
'                    End If

'                    '其他書籤            
'                    document.Bookmarks("頻道數目總計").SetText(dt頻道.Rows.Count().ToString())
'                    document.Bookmarks("境內數").SetText(dt頻道.Select("COUNTRY_TYPE='1'").Length().ToString())
'                    document.Bookmarks("境外數").SetText(dt頻道.Select("COUNTRY_TYPE='2'").Length().ToString())
'                    document.Save()
'                End Using

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110302"
'        Public Function APP110302(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[營運計畫摘要表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1041 = New CtAPP1041(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoWordQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                'DDL
'                Dim ctrlT As CtSysOperation = New CtSysOperation(_dbManager, _logUtil)

'                '信號傳輸方式
'                ctrlT.SYS_KEY = "TRANS_TYPE"
'                ctrlT.SYS_TYPE = "1"
'                ctrlT.USE_STATE = "1"
'                ctrlT.SYS_ID = dr("TRANS_TYPE").ToString
'                ctrlT.OrderBys = "SYS_ID"
'                Dim dt As DataTable = ctrlT.Get系統下拉資料

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME", dt.Rows(0)("SYS_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_NAME_FLAG", IIf(dt.Rows(0)("SYS_ID").ToString = "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC", dr("TRANS_DESC").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TRANS_DESC_FLAG", IIf(dt.Rows(0)("SYS_ID").ToString <> "1", "■"， "□")))

'                valuesToFill.Fields.Add(New FieldContent("TRANS_BACKUP", dr("TRANS_BACKUP").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC01", dr("DESC01").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC02", dr("DESC02").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC03", dr("DESC03").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC04", dr("DESC04").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC05", dr("DESC05").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC01", dr("DESC01").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC02", dr("DESC02").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC03", dr("DESC03").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC04", dr("DESC04").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC05", dr("DESC05").ToString))

'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_ATTRIBUTES", dr("CHANNEL_ATTRIBUTES").ToString))
'                valuesToFill.Fields.Add(New FieldContent("FIR_SHOW_TYPE", dr("FIR_SHOW_TYPE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SEC_SHOW_TYPE", dr("SEC_SHOW_TYPE").ToString))

'                '本國製播節目(含合製/委製)及外國製播節目比例。
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY1", dr("COUNTRY1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY2", dr("COUNTRY2").ToString))
'                valuesToFill.Fields.Add(New FieldContent("COUNTRY3", dr("COUNTRY3").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE1", dr("SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE2", dr("SHOW_RATE2").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE1", (ToDecimal(dr("SHOW_RATE1").ToString) + ToDecimal(dr("SHOW_RATE2").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE1", ((If(dr("SHOW_RATE1").ToString.Length > 0, ToDecimal(dr("SHOW_RATE1").ToString), 0) + If(dr("SHOW_RATE2").ToString.Length > 0, ToDecimal(dr("SHOW_RATE2").ToString), 0)) / 2 & ".00%")))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE11", dr("SHOW_RATE11").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE12", dr("SHOW_RATE12").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE11", (ToDecimal(dr("SHOW_RATE11").ToString) + ToDecimal(dr("SHOW_RATE12").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE11", ((If(dr("SHOW_RATE11").ToString.Length > 0, ToDecimal(dr("SHOW_RATE11").ToString), 0) + If(dr("SHOW_RATE12").ToString.Length > 0, ToDecimal(dr("SHOW_RATE12").ToString), 0)) / 2 & ".00%")))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE21", dr("SHOW_RATE21").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE22", dr("SHOW_RATE22").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE21", (ToDecimal(dr("SHOW_RATE21").ToString) + ToDecimal(dr("SHOW_RATE22").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE21", ((If(dr("SHOW_RATE21").ToString.Length > 0, ToDecimal(dr("SHOW_RATE21").ToString), 0) + If(dr("SHOW_RATE22").ToString.Length > 0, ToDecimal(dr("SHOW_RATE22").ToString), 0))) / 2 & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE31", dr("SHOW_RATE31").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE32", dr("SHOW_RATE32").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE31", (ToDecimal(dr("SHOW_RATE31").ToString) + ToDecimal(dr("SHOW_RATE32").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE31", ((If(dr("SHOW_RATE31").ToString.Length > 0, ToDecimal(dr("SHOW_RATE31").ToString), 0) + If(dr("SHOW_RATE32").ToString.Length > 0, ToDecimal(dr("SHOW_RATE32").ToString), 0)) / 2 & ".00%")))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE3", dr("SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE4", dr("SHOW_RATE4").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE3", (ToDecimal(dr("SHOW_RATE3").ToString) + ToDecimal(dr("SHOW_RATE4").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE3", ((If(dr("SHOW_RATE3").ToString.Length > 0, ToDecimal(dr("SHOW_RATE3").ToString), 0) + If(dr("SHOW_RATE4").ToString.Length > 0, ToDecimal(dr("SHOW_RATE4").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE13", dr("SHOW_RATE13").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE14", dr("SHOW_RATE14").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE13", (ToDecimal(dr("SHOW_RATE13").ToString) + ToDecimal(dr("SHOW_RATE14").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE13", ((If(dr("SHOW_RATE13").ToString.Length > 0, ToDecimal(dr("SHOW_RATE13").ToString), 0) + If(dr("SHOW_RATE14").ToString.Length > 0, ToDecimal(dr("SHOW_RATE14").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE23", dr("SHOW_RATE23").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE24", dr("SHOW_RATE24").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE23", (ToDecimal(dr("SHOW_RATE23").ToString) + ToDecimal(dr("SHOW_RATE24").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE23", ((If(dr("SHOW_RATE23").ToString.Length > 0, ToDecimal(dr("SHOW_RATE23").ToString), 0) + If(dr("SHOW_RATE24").ToString.Length > 0, ToDecimal(dr("SHOW_RATE24").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE33", dr("SHOW_RATE33").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_RATE34", dr("SHOW_RATE34").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_RATE33", (ToDecimal(dr("SHOW_RATE33").ToString) + ToDecimal(dr("SHOW_RATE34").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_RATE33", ((If(dr("SHOW_RATE33").ToString.Length > 0, ToDecimal(dr("SHOW_RATE33").ToString), 0) + If(dr("SHOW_RATE34").ToString.Length > 0, ToDecimal(dr("SHOW_RATE34").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("LAW_DESC", dr("LAW_DESC").ToString))

'                '頻道自製及外購節目比例。
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE1", dr("S_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE2", dr("S_SHOW_RATE2").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_S_SHOW_RATE1", (ToDecimal(dr("S_SHOW_RATE1").ToString) + ToDecimal(dr("S_SHOW_RATE2").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_S_SHOW_RATE1", ((If(dr("S_SHOW_RATE1").ToString.Length > 0, ToDecimal(dr("S_SHOW_RATE1").ToString), 0) + If(dr("S_SHOW_RATE2").ToString.Length > 0, ToDecimal(dr("S_SHOW_RATE2").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE1", dr("O_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE2", dr("O_SHOW_RATE2").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_O_SHOW_RATE1", (ToDecimal(dr("O_SHOW_RATE1").ToString) + ToDecimal(dr("O_SHOW_RATE2").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_O_SHOW_RATE1", ((If(dr("O_SHOW_RATE1").ToString.Length > 0, ToDecimal(dr("O_SHOW_RATE1").ToString), 0) + If(dr("O_SHOW_RATE2").ToString.Length > 0, ToDecimal(dr("O_SHOW_RATE2").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE3", dr("S_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("S_SHOW_RATE4", dr("S_SHOW_RATE4").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_S_SHOW_RATE3", (ToDecimal(dr("S_SHOW_RATE3").ToString) + ToDecimal(dr("S_SHOW_RATE4").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_S_SHOW_RATE3", ((If(dr("S_SHOW_RATE3").ToString.Length > 0, ToDecimal(dr("S_SHOW_RATE3").ToString), 0) + If(dr("S_SHOW_RATE4").ToString.Length > 0, ToDecimal(dr("S_SHOW_RATE4").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE3", dr("O_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("O_SHOW_RATE4", dr("O_SHOW_RATE4").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SUM_O_SHOW_RATE4", ((ToDecimal(dr("O_SHOW_RATE3").ToString) + ToDecimal(dr("O_SHOW_RATE4").ToString))) / 2.ToString & ".00%"))

'                '新播及首播節目比例。
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE1", dr("N_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE2", dr("N_SHOW_RATE2").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_N_SHOW_RATE1", (ToDecimal(dr("N_SHOW_RATE1").ToString) + ToDecimal(dr("N_SHOW_RATE2").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_N_SHOW_RATE1", ((If(dr("N_SHOW_RATE1").ToString.Length > 0, ToDecimal(dr("N_SHOW_RATE1").ToString), 0) + If(dr("N_SHOW_RATE2").ToString.Length > 0, ToDecimal(dr("N_SHOW_RATE2").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE1", dr("F_SHOW_RATE1").ToString))
'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE2", dr("F_SHOW_RATE2").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_F_SHOW_RATE1", (ToDecimal(dr("F_SHOW_RATE1").ToString) + ToDecimal(dr("F_SHOW_RATE2").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_F_SHOW_RATE1", ((If(dr("F_SHOW_RATE1").ToString.Length > 0, ToDecimal(dr("F_SHOW_RATE1").ToString), 0) + If(dr("F_SHOW_RATE2").ToString.Length > 0, ToDecimal(dr("F_SHOW_RATE2").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE3", dr("N_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("N_SHOW_RATE4", dr("N_SHOW_RATE4").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_N_SHOW_RATE3", (ToDecimal(dr("N_SHOW_RATE3").ToString) + ToDecimal(dr("N_SHOW_RATE4").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_N_SHOW_RATE3", ((If(dr("N_SHOW_RATE3").ToString.Length > 0, ToDecimal(dr("N_SHOW_RATE3").ToString), 0) + If(dr("N_SHOW_RATE4").ToString.Length > 0, ToDecimal(dr("N_SHOW_RATE4").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE3", dr("F_SHOW_RATE3").ToString))
'                valuesToFill.Fields.Add(New FieldContent("F_SHOW_RATE4", dr("F_SHOW_RATE4").ToString))
'                'valuesToFill.Fields.Add(New FieldContent("SUM_F_SHOW_RATE3", (ToDecimal(dr("F_SHOW_RATE3").ToString) + ToDecimal(dr("F_SHOW_RATE4").ToString)).ToString & ".00%"))
'                valuesToFill.Fields.Add(New FieldContent("SUM_F_SHOW_RATE3", ((If(dr("F_SHOW_RATE3").ToString.Length > 0, ToDecimal(dr("F_SHOW_RATE3").ToString), 0) + If(dr("F_SHOW_RATE4").ToString.Length > 0, ToDecimal(dr("F_SHOW_RATE4").ToString), 0))) / 2.ToString & ".00%"))

'                valuesToFill.Fields.Add(New FieldContent("DESC06", dr("DESC06").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC07", dr("DESC07").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC08", dr("DESC08").ToString))

'                '各分級級別節目
'                valuesToFill.Fields.Add(New FieldContent("UNIVERSAL_RATE", dr("UNIVERSAL_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROTECTION_RATE", dr("PROTECTION_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY12_RATE", dr("SECONDARY12_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SECONDARY15_RATE", dr("SECONDARY15_RATE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("LIMITATION_RATE", dr("LIMITATION_RATE").ToString))


'                valuesToFill.Fields.Add(New FieldContent("ORG_NAME", dr("ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_FREQ", dr("MEETING_FREQ").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MEETING_PEOPLE", dr("MEETING_PEOPLE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOW1_PAGE", dr("SHOW1_PAGE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW2_PAGE", dr("SHOW2_PAGE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW3_PAGE", dr("SHOW3_PAGE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOW4_PAGE", dr("SHOW4_PAGE").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC09", dr("DESC09").ToString))

'                valuesToFill.Fields.Add(New FieldContent("CHARGE2_AMT", dr("CHARGE2_AMT").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE3_AMT", dr("CHARGE3_AMT").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE4_AMT", dr("CHARGE4_AMT").ToString))

'                '客服部門人力配置
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_NUMBER", dr("SERVICE_F_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_NUMBER", dr("SERVICE_P_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_ALL_NUMBER", (ToDecimal(dr("SERVICE_F_NUMBER").ToString) + ToDecimal(dr("SERVICE_P_NUMBER").ToString)).ToString))

'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_FLAG", IIf(dr("SERVICE_F_FLAG").ToString = "Y", "是， 與" & dr("SERVICE_F_DESC") & "共用", "否， 與" & dr("SERVICE_F_DESC") & "共用")))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_FLAG", IIf(dr("SERVICE_P_FLAG").ToString = "Y", "是， 與" & dr("SERVICE_P_DESC") & "共用", "否， 與" & dr("SERVICE_P_DESC") & "共用")))

'                valuesToFill.Fields.Add(New FieldContent("SERVICE_F_SHARE_NUMBER", dr("SERVICE_F_SHARE_NUMBER").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SERVICE_P_SHARE_NUMBER", dr("SERVICE_P_SHARE_NUMBER").ToString))

'                valuesToFill.Fields.Add(New FieldContent("DESC10", dr("DESC10").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC11", dr("DESC11").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC12", dr("DESC12").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DESC13", dr("DESC13").ToString))

'                valuesToFill.Fields.Add(New FieldContent("SHOW1_FLAG", IIf(dr("SHOW1_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW2_FLAG", IIf(dr("SHOW2_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW3_FLAG", IIf(dr("SHOW3_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SHOW_FLAG", IIf(dr("SHOW_FLAG").ToString = "Y", "", "□")))

'                '符合本法第八條第三項規定
'                valuesToFill.Fields.Add(New FieldContent("LAW_3_8_FLAG", IIf(dr("LAW_3_8_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("LAW_3_8N_FLAG", IIf(dr("LAW_3_8_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("CHARGE1_FLAG", IIf(dr("CHARGE1_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE2_FLAG", IIf(dr("CHARGE2_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE3_FLAG", IIf(dr("CHARGE3_FLAG").ToString = "Y", "", "□")))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE4_FLAG", IIf(dr("CHARGE4_FLAG").ToString = "Y", "", "□")))

'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_Y", IIf(dr("MAKESHOE_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MAKESHOE_FLAG_N", IIf(dr("MAKESHOE_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_Y", IIf(dr("MUTICHANNEL_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("MUTICHANNEL_FLAG_N", IIf(dr("MUTICHANNEL_FLAG").ToString = "N", "■", "□")))

'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_Y", IIf(dr("SELFORG_FLAG").ToString = "Y", "■", "□")))
'                valuesToFill.Fields.Add(New FieldContent("SELFORG_FLAG_N", IIf(dr("SELFORG_FLAG").ToString = "N", "■", "□")))

'                '塞Table資料(品管人員)
'                '品管人員組織編制與職掌
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                    New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                    New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是, 與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                    )
'                    Next

'                    '合計
'                    'Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    'Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    'Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    'valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    'valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    'valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If


'                '塞Table資料(APP1160)
'                '內部自律組織
'                Dim ctrl6 As CtAPP1160 = New CtAPP1160(_dbManager, _logUtil)
'                ctrl6.CASE_NO = caseNo
'                Dim dt委員 As DataTable = ctrl6.DoQuery()

'                If dt委員.Rows.Count > 0 Then
'                    Dim tableContent6 As TableContent = New TableContent("APP1160") 'APP1160為範本中定義的變數名
'                    For Each dr1 As DataRow In dt委員.Rows
'                        tableContent6.AddRow(
'                    New FieldContent("MEMBER_NAME", dr1("MEMBER_NAME")),
'                    New FieldContent("SEX_TYPE_TXT", dr1("SEX_TYPE_TXT")),
'                    New FieldContent("TEACHER_TYPE_TXT", dr1("TEACHER_TYPE_TXT"))
'                    )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent6)
'                End If


'                '塞Table資料(APP1060)
'                '學經歷介紹
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                    )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If


'                '塞Table資料(APP1070)
'                '員工教育訓練規畫
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                    New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                    New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                    New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                    New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                    New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                    New FieldContent("FUNDING", String.Format("{0:#,###}", ToDecimal(dr1("FUNDING"))).ToString)
'                    )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", ToDecimal(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If


'                '塞Table資料(客服人員)
'                Dim ctrl2 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                ctrl2.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl2.DoQuery()

'                Dim tableContent2 As TableContent = New TableContent("APP1050_2") 'APP1050_2為範本中定義的變數名

'                If (dt客服.Rows.Count > 0) Then
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent2.AddRow(
'                    New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                    New FieldContent("CH_NAME", dr1("CH_NAME")),
'                    New FieldContent("JOBTITLE", dr1("JOBTITLE"))
'                    )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT2 = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT2_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT2_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT2))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_1", sum_PTTCH_FT2_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_2", sum_PTTCH_FT2_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent2)

'                End If


'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()

'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110101"
'        Public Function APP110101(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申請書]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename

'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    _logUtil.Logger.Append(errmsg)
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"

'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()
'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                If (bookmark.Name = "實收資本額") Then
'                                    If dr(bookmark.Name).ToString = "" Then
'                                        document.Bookmarks(bookmark.Name).SetText("")
'                                    Else
'                                        document.Bookmarks(bookmark.Name).SetText(String.Format("{0:#,###}", Convert.ToDouble(dr(bookmark.Name))))
'                                    End If
'                                Else
'                                    document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                                End If
'                            End If
'                        End If
'                    Next

'                    '外國人直接持有之股份
'                    Dim ctrl1 As CtAPP1020 = New CtAPP1020(_dbManager, _logUtil)
'                    ctrl1.CASE_NO = caseNo
'                    Dim dt股份 As DataTable = ctrl1.DoQuery()
'                    Dim tbl_stock As Novacode.Table = document.Tables(0)
'                    Dim tr As Novacode.Row = tbl_stock.Rows(5) ' 股東空白列第一列

'                    '目前預設4筆
'                    If dt股份.Rows.Count > 4 Then
'                        '插入空白列
'                        For i As Integer = 0 To dt股份.Rows.Count - 4 - 1
'                            tbl_stock.InsertRow(tr, 5)
'                        Next
'                    End If

'                    '塞資料
'                    For i As Integer = 0 To dt股份.Rows.Count - 1
'                        tr = tbl_stock.Rows(5 + i)
'                        tr.Cells(2).ReplaceText("一", dt股份.Rows(i).Item("FOREIGNER_SHOLDER_NM").ToString())
'                        tr.Cells(3).ReplaceText("一", dt股份.Rows(i).Item("COUNTRY").ToString())
'                        If (dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString() = "") Then
'                            tr.Cells(4).ReplaceText("一", "")
'                        Else
'                            tr.Cells(4).ReplaceText("一", String.Format("{0:#,###}", CInt(dt股份.Rows(i).Item("DIRECT_SHAREHOLDING").ToString())))
'                        End If
'                        tr.Cells(5).ReplaceText("一", dt股份.Rows(i).Item("PROPORTION").ToString())
'                    Next
'                    '不夠4筆的空白資料 把"一"清掉 呵呵為什麼是一哩
'                    If dt股份.Rows.Count < 4 Then
'                        For i As Integer = dt股份.Rows.Count - 1 To 3
'                            tr = tbl_stock.Rows(5 + i)
'                            tr.Cells(2).ReplaceText("一", "")
'                            tr.Cells(3).ReplaceText("一", "")
'                            tr.Cells(4).ReplaceText("一", "")
'                            tr.Cells(5).ReplaceText("一", "")
'                        Next
'                    End If

'                    document.Save()

'                End Using

'                'Return tempfilename
'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110102"
'        Public Function APP110102(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim msgTitle As String = "[營運計畫摘要表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    rptModel.Message = msgTitle + "Word範本檔不存在"
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1040 = New CtAPP1040(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = BindDDFormat(ctrl.DoWordQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Script = "alert('無任何資料,請先新增並儲存資料後再執行[列印]。');location.reload();"
'                    rptModel.Message = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SYS_CNAME", dr("SYS_CNAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("BUSIN_PRO_PLAN", dr("BUSIN_PRO_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("DISPUTE_HAN_MECH", dr("DISPUTE_HAN_MECH").ToString))
'                valuesToFill.Fields.Add(New FieldContent("INFORM_DISC_PLAN", dr("INFORM_DISC_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("BUSIN_PHIL_CHAR", dr("BUSIN_PHIL_CHAR").ToString))
'                valuesToFill.Fields.Add(New FieldContent("MARK_RES_DATA", dr("MARK_RES_DATA").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHANNEL_STRATEGY", dr("CHANNEL_STRATEGY").ToString))
'                valuesToFill.Fields.Add(New FieldContent("NAT_CHANNELS_NUM", dr("NAT_CHANNELS_NUM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("OVER_CHANNELS_NUM", dr("OVER_CHANNELS_NUM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PACK_COM_PLAN", dr("PACK_COM_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SIN_POINT_CHAN_PLAN", dr("SIN_POINT_CHAN_PLAN").ToString))
'                valuesToFill.Fields.Add(New FieldContent("SHOPPING_CHANNELS", dr("SHOPPING_CHANNELS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TOTAL_CHANNELS", dr("TOTAL_CHANNELS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PROPORTION", dr("PROPORTION").ToString))
'                valuesToFill.Fields.Add(New FieldContent("INTER_CON_ORG_NAME", dr("INTER_CON_ORG_NAME").ToString))
'                valuesToFill.Fields.Add(New FieldContent("INTER_CON_ORG_INS", dr("INTER_CON_ORG_INS").ToString))
'                valuesToFill.Fields.Add(New FieldContent("CHARGE_BASE", dr("CHARGE_BASE").ToString))
'                valuesToFill.Fields.Add(New FieldContent("PAT_REF_METHOD", dr("PAT_REF_METHOD").ToString))


'                '塞Table資料(品管人員)
'                Dim ctrl1 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                ctrl1.CODE_TYPE = "1"
'                Dim dt品管 As DataTable = ctrl1.DoQuery()

'                If (dt品管.Rows.Count > 0) Then

'                    Dim tableContent1 As TableContent = New TableContent("APP1050_1") 'APP1050_1為範本中定義的變數名
'                    For Each dr1 As DataRow In dt品管.Rows
'                        tableContent1.AddRow(
'                        New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                        New FieldContent("CH_NAME", dr1("CH_NAME")),
'                        New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                        New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "Y", "", "")),
'                        New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                        )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT = dt品管.Rows.Count.ToString
'                    Dim sum_PTTCH_FT_1 = dt品管.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT_2 = dt品管.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT", sum_PTTCH_FT))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_1", sum_PTTCH_FT_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT_2", sum_PTTCH_FT_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If



'                '塞Table資料(APP1060)
'                Dim ctrl3 As CtAPP1060 = New CtAPP1060(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dt組織 As DataTable = ctrl3.DoQuery()

'                If dt組織.Rows.Count > 0 Then
'                    Dim tableContent3 As TableContent = New TableContent("APP1060") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt組織.Rows
'                        tableContent3.AddRow(
'                        New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                        New FieldContent("CH_NAME", dr1("CH_NAME")),
'                        New FieldContent("LEARN_EXP_INTRO", dr1("LEARN_EXP_INTRO"))
'                        )
'                    Next
'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent3)
'                End If

'                '塞Table資料(APP1070)
'                Dim ctrl4 As CtAPP1070 = New CtAPP1070(_dbManager, _logUtil)
'                ctrl4.CASE_NO = caseNo
'                Dim dt課程 As DataTable = ctrl4.DoQuery()

'                If dt課程.Rows.Count > 0 Then
'                    Dim tableContent4 As TableContent = New TableContent("APP1070") 'APP1060為範本中定義的變數名
'                    For Each dr1 As DataRow In dt課程.Rows
'                        tableContent4.AddRow(
'                        New FieldContent("COURSE_CATEGORY", dr1("COURSE_CATEGORY")),
'                        New FieldContent("COURSE_NAME", dr1("COURSE_NAME")),
'                        New FieldContent("BOOK_LEC_NAME", dr1("BOOK_LEC_NAME")),
'                        New FieldContent("INT_EXT_LECTURER", IIf(dr1("INT_EXT_LECTURER").ToString = "1", "內", "外")),
'                        New FieldContent("HOUR_NUM", dr1("HOUR_NUM")),
'                        New FieldContent("FUNDING", String.Format("{0:#,###}", CInt(dr1("FUNDING"))).ToString)
'                        )
'                    Next

'                    '合計
'                    Dim sum_HOUR_NUM = dt課程.Compute("sum(HOUR_NUM)", String.Empty).ToString
'                    Dim sum_FUNDING = String.Format("{0:#,###}", CInt(dt課程.Compute("sum(FUNDING)", String.Empty).ToString)).ToString
'                    valuesToFill.Fields.Add(New FieldContent("sum_HOUR_NUM", sum_HOUR_NUM))
'                    valuesToFill.Fields.Add(New FieldContent("sum_FUNDING", sum_FUNDING))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent4)
'                End If


'                '塞Table資料(客服人員)
'                Dim ctrl2 As CtAPP1050 = New CtAPP1050(_dbManager, _logUtil)
'                ctrl2.CASE_NO = caseNo
'                ctrl2.CODE_TYPE = "2"
'                Dim dt客服 As DataTable = ctrl2.DoQuery()

'                Dim tableContent2 As TableContent = New TableContent("APP1050_2") 'APP1050_2為範本中定義的變數名

'                If (dt客服.Rows.Count > 0) Then
'                    For Each dr1 As DataRow In dt客服.Rows
'                        tableContent2.AddRow(
'                        New FieldContent("PTTCH_FT_TXT", dr1("PTTCH_FT_TXT")),
'                        New FieldContent("CH_NAME", dr1("CH_NAME")),
'                        New FieldContent("JOBTITLE", dr1("JOBTITLE")),
'                        New FieldContent("IS_CAREER_SHAR", IIf(dr1("IS_CAREER_SHAR").ToString() = "N", "", "")),
'                        New FieldContent("IS_CAREER_SHAR_TXT", IIf(dr1("IS_CAREER_SHAR").ToString = "Y", "是,與 " & dr1("CAREER_SHAR_NAME") & " 共用", "否"))
'                        )
'                    Next

'                    '合計
'                    Dim sum_PTTCH_FT2 = dt客服.Rows.Count.ToString
'                    Dim sum_PTTCH_FT2_1 = dt客服.Select("PTTCH_FT='1'").Count
'                    Dim sum_PTTCH_FT2_2 = dt客服.Select("PTTCH_FT='2'").Count

'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2", sum_PTTCH_FT2))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_1", sum_PTTCH_FT2_1))
'                    valuesToFill.Fields.Add(New FieldContent("sum_PTTCH_FT2_2", sum_PTTCH_FT2_2))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent2)

'                End If


'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()

'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110103"
'        Private Function APP110103(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String, ByVal futureYear As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim rptData As New APP110103_REPORT_DATA_MODEL
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[預估財務狀況表]"
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"

'                If Not IO.File.Exists(Templatefilename) Then
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '查詢報表資料
'                Dim ctrl As CtAPP1080 = New CtAPP1080(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo
'                Dim dtGroupBy = ctrl.DoQueryByGroup() '查詢群組

'                '宣告範本容器
'                Dim dataSetCount As Integer = dtGroupBy.Rows.Count '總共有多少組資料(by Group)

'                '暫存檔
'                'Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_FUTUTR_YEAR_" & futureYear & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                Using document As DocX = DocX.Load(tempfilename)

'                    Dim tb As Novacode.Table = document.Tables(0)

'                    rptData = BalanceMaping(caseNo, futureYear)

'                    tb.Rows(0).Cells(0).ReplaceText("[FUTURE_YEAR]",
'                                                    futureYear)
'                    '---值---
'                    '一般值
'                    tb.Rows(3).Cells(2).ReplaceText("取代", rptData.AMOUNT(0).col_x)
'                    tb.Rows(3).Cells(6).ReplaceText("取代", rptData.AMOUNT(0).col_y)
'                    tb.Rows(4).Cells(2).ReplaceText("取代", rptData.AMOUNT(1).col_x)
'                    tb.Rows(4).Cells(6).ReplaceText("取代", rptData.AMOUNT(1).col_y)
'                    tb.Rows(5).Cells(2).ReplaceText("取代", rptData.AMOUNT(2).col_x)
'                    tb.Rows(5).Cells(6).ReplaceText("取代", rptData.AMOUNT(2).col_y)
'                    tb.Rows(6).Cells(2).ReplaceText("取代", rptData.AMOUNT(3).col_x)
'                    tb.Rows(6).Cells(6).ReplaceText("取代", rptData.AMOUNT(3).col_y)
'                    tb.Rows(7).Cells(2).ReplaceText("取代", rptData.AMOUNT(4).col_x)
'                    tb.Rows(7).Cells(6).ReplaceText("取代", rptData.AMOUNT(4).col_y)
'                    tb.Rows(8).Cells(2).ReplaceText("取代", rptData.AMOUNT(5).col_x)
'                    tb.Rows(8).Cells(6).ReplaceText("取代", rptData.AMOUNT(5).col_y)

'                    tb.Rows(9).Cells(2).ReplaceText("取代", rptData.AMOUNT(6).col_x)
'                    tb.Rows(9).Cells(6).ReplaceText("取代", rptData.AMOUNT(6).col_y)
'                    tb.Rows(10).Cells(2).ReplaceText("取代", rptData.AMOUNT(7).col_x)
'                    tb.Rows(10).Cells(6).ReplaceText("取代", rptData.AMOUNT(7).col_y)
'                    tb.Rows(11).Cells(2).ReplaceText("取代", rptData.AMOUNT(8).col_x)
'                    tb.Rows(11).Cells(6).ReplaceText("取代", rptData.AMOUNT(8).col_y)
'                    tb.Rows(12).Cells(2).ReplaceText("取代", rptData.AMOUNT(9).col_x)
'                    tb.Rows(12).Cells(6).ReplaceText("取代", rptData.AMOUNT(9).col_y)
'                    tb.Rows(13).Cells(2).ReplaceText("取代", rptData.AMOUNT(10).col_x)
'                    tb.Rows(13).Cells(6).ReplaceText("取代", rptData.AMOUNT(10).col_y)
'                    tb.Rows(14).Cells(2).ReplaceText("取代", rptData.AMOUNT(11).col_x)
'                    tb.Rows(14).Cells(6).ReplaceText("取代", rptData.AMOUNT(11).col_y)

'                    tb.Rows(17).Cells(2).ReplaceText("取代", rptData.AMOUNT(12).col_x)
'                    tb.Rows(17).Cells(6).ReplaceText("取代", rptData.AMOUNT(12).col_y)
'                    tb.Rows(18).Cells(2).ReplaceText("取代", rptData.AMOUNT(13).col_x)
'                    tb.Rows(18).Cells(6).ReplaceText("取代", rptData.AMOUNT(13).col_y)
'                    tb.Rows(19).Cells(2).ReplaceText("取代", rptData.AMOUNT(14).col_x)
'                    tb.Rows(19).Cells(6).ReplaceText("取代", rptData.AMOUNT(14).col_y)
'                    tb.Rows(20).Cells(2).ReplaceText("取代", rptData.AMOUNT(15).col_x)
'                    tb.Rows(20).Cells(6).ReplaceText("取代", rptData.AMOUNT(15).col_y)
'                    tb.Rows(21).Cells(2).ReplaceText("取代", rptData.AMOUNT(16).col_x)
'                    tb.Rows(21).Cells(6).ReplaceText("取代", rptData.AMOUNT(16).col_y)

'                    tb.Rows(22).Cells(2).ReplaceText("取代", rptData.AMOUNT(17).col_x)
'                    tb.Rows(22).Cells(6).ReplaceText("取代", rptData.AMOUNT(17).col_y)
'                    tb.Rows(23).Cells(6).ReplaceText("取代", rptData.AMOUNT(18).col_y)

'                    tb.Rows(24).Cells(2).ReplaceText("取代", rptData.AMOUNT(19).col_x)
'                    tb.Rows(24).Cells(6).ReplaceText("取代", rptData.AMOUNT(19).col_y)
'                    tb.Rows(25).Cells(2).ReplaceText("取代", rptData.AMOUNT(20).col_x)
'                    tb.Rows(25).Cells(6).ReplaceText("取代", rptData.AMOUNT(20).col_y)

'                    tb.Rows(28).Cells(2).ReplaceText("取代", rptData.AMOUNT(21).col_x)
'                    tb.Rows(28).Cells(6).ReplaceText("取代", rptData.AMOUNT(21).col_y)
'                    tb.Rows(29).Cells(2).ReplaceText("取代", rptData.AMOUNT(22).col_x)
'                    tb.Rows(29).Cells(6).ReplaceText("取代", rptData.AMOUNT(22).col_y)
'                    tb.Rows(30).Cells(2).ReplaceText("取代", rptData.AMOUNT(23).col_x)
'                    tb.Rows(30).Cells(6).ReplaceText("取代", rptData.AMOUNT(23).col_y)
'                    tb.Rows(31).Cells(2).ReplaceText("取代", rptData.AMOUNT(24).col_x)
'                    tb.Rows(31).Cells(6).ReplaceText("取代", rptData.AMOUNT(24).col_y)
'                    tb.Rows(32).Cells(2).ReplaceText("取代", rptData.AMOUNT(25).col_x)
'                    tb.Rows(32).Cells(6).ReplaceText("取代", rptData.AMOUNT(25).col_y)

'                    '總計
'                    '流動資產總計,流動負債總計	
'                    tb.Rows(15).Cells(2).ReplaceText("取代", rptData.SUB_TOTAL(0).col_x)
'                    tb.Rows(15).Cells(6).ReplaceText("取代", rptData.SUB_TOTAL(0).col_y)

'                    '非流動資產總計
'                    tb.Rows(23).Cells(2).ReplaceText("取代", rptData.SUB_TOTAL(1).col_x)
'                    '非流動負債總計
'                    tb.Rows(26).Cells(6).ReplaceText("取代", rptData.SUB_TOTAL(1).col_y)
'                    '權益總計
'                    tb.Rows(33).Cells(6).ReplaceText("取代", rptData.SUB_TOTAL(2).col_y)

'                    '資產總計
'                    tb.Rows(35).Cells(1).ReplaceText("取代", rptData.TOTAL(0).col_x)
'                    '負債及權益總計
'                    tb.Rows(35).Cells(4).ReplaceText("取代", rptData.TOTAL(0).col_y)

'                    '---百分比---
'                    '一般值
'                    tb.Rows(3).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(0).col_x)
'                    tb.Rows(3).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(0).col_y)
'                    tb.Rows(4).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(1).col_x)
'                    tb.Rows(4).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(1).col_y)
'                    tb.Rows(5).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(2).col_x)
'                    tb.Rows(5).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(2).col_y)
'                    tb.Rows(6).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(3).col_x)
'                    tb.Rows(6).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(3).col_y)
'                    tb.Rows(7).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(4).col_x)
'                    tb.Rows(7).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(4).col_y)
'                    tb.Rows(8).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(5).col_x)
'                    tb.Rows(8).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(5).col_y)

'                    tb.Rows(9).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(6).col_x)
'                    tb.Rows(9).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(6).col_y)
'                    tb.Rows(10).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(7).col_x)
'                    tb.Rows(10).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(7).col_y)
'                    tb.Rows(11).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(8).col_x)
'                    tb.Rows(11).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(8).col_y)
'                    tb.Rows(12).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(9).col_x)
'                    tb.Rows(12).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(9).col_y)
'                    tb.Rows(13).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(10).col_x)
'                    tb.Rows(13).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(10).col_y)
'                    tb.Rows(14).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(11).col_x)
'                    tb.Rows(14).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(11).col_y)

'                    tb.Rows(17).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(12).col_x)
'                    tb.Rows(17).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(12).col_y)
'                    tb.Rows(18).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(13).col_x)
'                    tb.Rows(18).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(13).col_y)
'                    tb.Rows(19).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(14).col_x)
'                    tb.Rows(19).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(14).col_y)
'                    tb.Rows(20).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(15).col_x)
'                    tb.Rows(20).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(15).col_y)
'                    tb.Rows(21).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(16).col_x)
'                    tb.Rows(21).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(16).col_y)

'                    tb.Rows(22).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(17).col_x)
'                    tb.Rows(22).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(17).col_y)
'                    tb.Rows(23).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(18).col_y)

'                    tb.Rows(24).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(19).col_x)
'                    tb.Rows(24).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(19).col_y)
'                    tb.Rows(25).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(20).col_x)
'                    tb.Rows(25).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(20).col_y)

'                    tb.Rows(28).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(21).col_x)
'                    tb.Rows(28).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(21).col_y)
'                    tb.Rows(29).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(22).col_x)
'                    tb.Rows(29).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(22).col_y)
'                    tb.Rows(30).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(23).col_x)
'                    tb.Rows(30).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(23).col_y)
'                    tb.Rows(31).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(24).col_x)
'                    tb.Rows(31).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(24).col_y)
'                    tb.Rows(32).Cells(3).ReplaceText("取代", rptData.PERCENT.AMOUNT(25).col_x)
'                    tb.Rows(32).Cells(7).ReplaceText("取代", rptData.PERCENT.AMOUNT(25).col_y)

'                    '總計
'                    '流動資產總計,流動負債總計	
'                    tb.Rows(15).Cells(3).ReplaceText("取代", rptData.PERCENT.SUB_TOTAL(0).col_x)
'                    tb.Rows(15).Cells(7).ReplaceText("取代", rptData.PERCENT.SUB_TOTAL(0).col_y)

'                    '非流動資產總計
'                    tb.Rows(23).Cells(3).ReplaceText("取代", rptData.PERCENT.SUB_TOTAL(1).col_x)
'                    '非流動負債總計
'                    tb.Rows(26).Cells(7).ReplaceText("取代", rptData.PERCENT.SUB_TOTAL(1).col_y)
'                    '權益總計
'                    tb.Rows(33).Cells(7).ReplaceText("取代", rptData.PERCENT.SUB_TOTAL(2).col_y)

'                    '資產總計
'                    tb.Rows(35).Cells(2).ReplaceText("取代", rptData.PERCENT.TOTAL(0))
'                    '負債及權益總計
'                    tb.Rows(35).Cells(5).ReplaceText("取代", rptData.PERCENT.TOTAL(1))

'                    document.Save()

'                End Using

'                Return rptModel
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function

'#Region "BalanceMaping 執行顯示資產負債資料動作"
'        ''' <summary>
'        ''' 執行BIND  動作
'        ''' </summary>
'        Private Function BalanceMaping(ByVal caseNo As String, futureYear As String) As APP110103_REPORT_DATA_MODEL
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '=== 呼叫 Control 進行查詢動作 ===
'                Dim ctrl As CtAPP1080 = New CtAPP1080(_dbManager, _logUtil)

'                ctrl.CASE_NO = caseNo
'                ctrl.FUTURE_YEAR = futureYear
'                Dim dt As DataTable = ctrl.DoQuery()

'                Dim rptData = New APP110103_REPORT_DATA_MODEL()

'                '將資料對號入座    
'                '在目前資料結構下，以此方式實作
'                Dim numList_1 As New List(Of String)(New String() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
'                Dim numList_2 As New List(Of String)(New String() {"01", "02", "03", "04", "05", "06"})
'                Dim numList_3 As New List(Of String)(New String() {"07", "08", "09"})
'                Dim numList_4 As New List(Of String)(New String() {"01", "02", "03", "04", "05"})
'                Dim tmp1 As String = ""
'                Dim tmp2 As String = ""
'                For Each num As String In numList_1
'                    tmp1 = ""
'                    tmp2 = ""

'                    If dt.Select("FINANCE_DETAILS ='11" + num + "'").Length = 0 Then
'                        tmp1 = ""
'                    Else
'                        tmp1 = dt.Select("FINANCE_DETAILS ='11" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If

'                    If dt.Select("FINANCE_DETAILS ='21" + num + "'").Length = 0 Then
'                        tmp2 = ""
'                    Else
'                        tmp2 = dt.Select("FINANCE_DETAILS ='21" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If

'                    rptData.AMOUNT.Add(New AMOUNT With {
'                                   .col_x = tmp1,
'                                   .col_y = tmp2
'                                   })
'                Next

'                For Each num As String In numList_2
'                    tmp1 = ""
'                    tmp2 = ""
'                    If dt.Select("FINANCE_DETAILS ='12" + num + "'").Length = 0 Then
'                        tmp1 = ""
'                    Else
'                        tmp1 = dt.Select("FINANCE_DETAILS ='12" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If

'                    If dt.Select("FINANCE_DETAILS ='22" + num + "'").Length = 0 Then
'                        tmp2 = ""
'                    Else
'                        tmp2 = dt.Select("FINANCE_DETAILS ='22" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If
'                    rptData.AMOUNT.Add(New AMOUNT With {
'                                   .col_x = tmp1,
'                                   .col_y = tmp2
'                                   })
'                Next

'                For Each num As String In numList_3
'                    tmp1 = ""
'                    tmp2 = ""
'                    If dt.Select("FINANCE_DETAILS ='22" + num + "'").Length = 0 Then
'                        tmp2 = ""
'                    Else
'                        tmp2 = dt.Select("FINANCE_DETAILS ='22" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If
'                    rptData.AMOUNT.Add(New AMOUNT With {
'                                   .col_x = "",
'                                   .col_y = tmp2
'                                   })
'                Next

'                For Each num As String In numList_4
'                    tmp1 = ""
'                    tmp2 = ""
'                    If dt.Select("FINANCE_DETAILS ='23" + num + "'").Length = 0 Then
'                        tmp2 = ""
'                    Else
'                        tmp2 = dt.Select("FINANCE_DETAILS ='23" + num + "'")(0).Item("ESTIMATED_AMOUNT").ToString()
'                    End If
'                    rptData.AMOUNT.Add(New AMOUNT With {
'                                   .col_x = "",
'                                   .col_y = tmp2
'                                   })
'                Next

'                rptData = CaculateStatic(rptData)

'                Return rptData

'                ''=== 隱藏結束處理中動作 ===
'                Me.JScript.HideProcess()
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function

'        Private Function CaculateStatic(ByVal rptData As APP110103_REPORT_DATA_MODEL) As APP110103_REPORT_DATA_MODEL
'            Try
'                Dim tot1 As Decimal = 0
'                Dim tot2 As Decimal = 0
'                Dim subtot1 As Decimal = 0
'                Dim subtot2 As Decimal = 0
'                Dim tmpCount As Integer = 0
'                Dim sub_sum_lv1 As Integer = 12
'                Dim sub_sum_lv2 As Integer = 21
'                Dim sub_sum_lv3 As Integer = 26

'                '---總計---
'                For Each amount As AMOUNT In rptData.AMOUNT
'                    '小計加總
'                    '總計加總
'                    If amount.col_x.Length > 0 Then
'                        tot1 += ToDecimal(amount.col_x)
'                        subtot1 += ToDecimal(amount.col_x)
'                    End If
'                    If amount.col_y.Length > 0 Then
'                        tot2 += ToDecimal(amount.col_y)
'                        subtot2 += ToDecimal(amount.col_y)
'                    End If

'                    '小計結算
'                    tmpCount = tmpCount + 1
'                    If tmpCount = sub_sum_lv1 Or tmpCount = sub_sum_lv2 Or tmpCount = sub_sum_lv3 Then
'                        rptData.SUB_TOTAL.Add(New SUB_TOTAL With {
'                                              .col_x = ToFormattedDecimal(subtot1),
'                                              .col_y = ToFormattedDecimal(subtot2)})
'                        subtot1 = 0
'                        subtot2 = 0
'                    End If
'                Next

'                '總計結算
'                rptData.TOTAL.Add(New TOTAL With {
'                                  .col_x = ToFormattedDecimal(tot1),
'                                  .col_y = ToFormattedDecimal(tot2)})


'                '---比例---
'                '小類比例
'                tmpCount = 0
'                Dim sub_percent_1 As String = ""
'                Dim sub_percent_2 As String = ""
'                For Each amount As AMOUNT In rptData.AMOUNT
'                    sub_percent_1 = ""
'                    sub_percent_2 = ""
'                    If amount.col_x <> "" And tot1 <> 0 Then
'                        sub_percent_1 = ToDecimal(Math.Round(IIf(tot1 = 0, 0, (ToDecimal(amount.col_x.Trim) * 100 / tot1)), 2, MidpointRounding.AwayFromZero)).ToString("F")
'                    End If
'                    If amount.col_y <> "" And tot2 <> 0 Then
'                        sub_percent_2 = ToDecimal(Math.Round(IIf(tot2 = 0, 0, (ToDecimal(amount.col_y.Trim) * 100 / tot2)), 2, MidpointRounding.AwayFromZero)).ToString("F")
'                    End If

'                    rptData.PERCENT.AMOUNT.Add(New AMOUNT With {.col_x = sub_percent_1, .col_y = sub_percent_2})
'                Next

'                '中類比例
'                Dim mid_ratio_1 As String = ""
'                Dim mid_ratio_2 As String = ""
'                For Each subtotal As SUB_TOTAL In rptData.SUB_TOTAL
'                    mid_ratio_1 = ""
'                    mid_ratio_2 = ""
'                    If subtotal.col_x <> "" And tot1 <> 0 Then
'                        mid_ratio_1 = ToDecimal(Math.Round(IIf(tot1 = 0, 0, (ToDecimal(subtotal.col_x.Trim) * 100 / tot1)), 2, MidpointRounding.AwayFromZero)).ToString("F")
'                    End If
'                    If subtotal.col_y <> "" And tot2 <> 0 Then
'                        mid_ratio_2 = ToDecimal(Math.Round(IIf(tot2 = 0, 0, (ToDecimal(subtotal.col_y.Trim) * 100 / tot2)), 2, MidpointRounding.AwayFromZero)).ToString("F")
'                    End If

'                    rptData.PERCENT.SUB_TOTAL.Add(New SUB_TOTAL With {.col_x = mid_ratio_1, .col_y = mid_ratio_2})
'                Next

'                '總計比例
'                rptData.PERCENT.TOTAL.Add(Math.Round(100, 2, MidpointRounding.AwayFromZero).ToString("F"))
'                rptData.PERCENT.TOTAL.Add(Math.Round(100, 2, MidpointRounding.AwayFromZero).ToString("F"))

'                Return rptData
'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region
'#End Region

'#Region "APP110104"
'        Public Function APP110104(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[預估綜合損益表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '撈資料
'                Dim ctrl As CtAPP1090 = New CtAPP1090(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                ctrl.QUERY_COND = " AND FUTURE_YEAR IN ('1','2','3') "
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                'Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                Dim i As Integer = 1
'                For Each dr As DataRow In dt案件.Rows
'                    '小計
'                    Dim str收入 As String = ToFormattedDecimal(If(IsDBNull(dr("OPERATING_INCOME")), "", dr("OPERATING_INCOME")))
'                    Dim str成本 As String = ToFormattedDecimal(If(IsDBNull(dr("OPERATING_COST")), "", dr("OPERATING_COST")))
'                    Dim str費用 As String = ToFormattedDecimal(If(IsDBNull(dr("OPERATING_EXP")), "", dr("OPERATING_EXP")))
'                    Dim str業外收益及費損 As String = ToFormattedDecimal(If(IsDBNull(dr("OPERATING_COME_EXP")), "", dr("OPERATING_COME_EXP")))

'                    Dim str營業毛利 As String = ToFormattedDecimal(str收入.Trim) - ToDecimal(str成本.Trim)
'                    Dim str營業淨利 As String = ToFormattedDecimal(str營業毛利.Trim) - ToDecimal(str費用.Trim)
'                    Dim str稅前淨利 As String = ToFormattedDecimal(str營業淨利.Trim) + ToDecimal(str業外收益及費損.Trim)

'                    '比例
'                    Dim str收入比例 As String = String.Empty
'                    Dim str成本比例 As String = String.Empty
'                    Dim str毛利比例 As String = String.Empty
'                    Dim str費用比例 As String = String.Empty
'                    Dim str淨利比例 As String = String.Empty
'                    Dim str業外收益及費損比例 As String = String.Empty
'                    Dim str稅前淨利比例 As String = String.Empty

'                    If str收入.Trim() <> "" Then
'                        str收入比例 = "100.00"

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str成本比例 = Math.Round(ToDecimal(str成本.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str成本比例 = 0
'                        End If

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str毛利比例 = Math.Round(ToDecimal(str營業毛利.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str毛利比例 = 0
'                        End If

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str費用比例 = Math.Round(ToDecimal(str費用.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str費用比例 = 0
'                        End If

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str淨利比例 = Math.Round(ToDecimal(str營業淨利.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str淨利比例 = 0
'                        End If

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str業外收益及費損比例 = Math.Round(ToDecimal(str業外收益及費損.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str業外收益及費損比例 = 0
'                        End If

'                        If str收入.Trim().Length > 0 And str收入.Trim() <> "0" Then
'                            str稅前淨利比例 = Math.Round(ToDecimal(str稅前淨利.Trim()) * 100 / ToDecimal(str收入.Trim()), 2, MidpointRounding.AwayFromZero).ToString("F")
'                        Else
'                            str稅前淨利比例 = 0
'                        End If

'                    End If

'                    '塞變數資料
'                    valuesToFill.Fields.Add(New FieldContent("OPERATING_INCOME" & i, str收入))
'                    valuesToFill.Fields.Add(New FieldContent("OPERATING_COST" & i, str成本))
'                    valuesToFill.Fields.Add(New FieldContent("OPERATING_EXP" & i, str費用))
'                    valuesToFill.Fields.Add(New FieldContent("OPERATING_COME_EXP" & i, str業外收益及費損))

'                    valuesToFill.Fields.Add(New FieldContent("GROSSPROFIT" & i, str營業毛利))
'                    valuesToFill.Fields.Add(New FieldContent("NETPROFIT" & i, str營業淨利))
'                    valuesToFill.Fields.Add(New FieldContent("BEFTAXPROFIT" & i, str稅前淨利))

'                    valuesToFill.Fields.Add(New FieldContent("INCOME_PERCENT" & i, str收入比例))
'                    valuesToFill.Fields.Add(New FieldContent("OST_PERCENT" & i, str成本比例))
'                    valuesToFill.Fields.Add(New FieldContent("GROSSPROFI_PERCENT" & i, str毛利比例))
'                    valuesToFill.Fields.Add(New FieldContent("EXP_PERCENT" & i, str費用比例))
'                    valuesToFill.Fields.Add(New FieldContent("NETPROFI_PERCENT" & i, str淨利比例))
'                    valuesToFill.Fields.Add(New FieldContent("COME_EXP_PERCENT" & i, str業外收益及費損比例))
'                    valuesToFill.Fields.Add(New FieldContent("BEFTAX_PERCENT" & i, str稅前淨利比例))

'                    i += 1
'                Next

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                ''下載並刪除暫存檔
'                'Response.Redirect("/TSBA/Utility/download_word.aspx?name=" & tempfilename)
'                'Me.JScript.HideProcess()
'                'Return tempfilename
'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110105"
'        Public Function APP110105(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[預期營業收入明細表]"

'                '=== 建立檔案 ===
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '=== 撈資料 ===
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "1"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件.AsEnumerable
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                                    Key PROJECT_TYPE_ID,
'                                    .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                                    }

'                    Dim aryCount As New ArrayList

'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM").ToString())
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_ONE_YEAR").ToString()))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_TWO_YEAR").ToString()))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_THREE_YEAR").ToString()))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    tot1 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_ONE_YEAR)", ""), "0"))
'                    tot2 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_TWO_YEAR)", ""), "0"))
'                    tot3 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_THREE_YEAR)", ""), "0"))

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot1))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot2))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot3))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110106"
'        Public Function APP110106(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[預期營業支出明細表]"

'                '=== 建立檔案 ===
'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '=== 撈資料 ===
'                Dim ctrl As CtAPP1100 = New CtAPP1100(_dbManager, _logUtil)
'                ctrl.ACC_TYPE = "2"
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    'return ""
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 表格資料 ===
'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim tr1 = tb.Rows(1)
'                    Dim tr2 = tb.Rows(2)

'                    '塞空白列
'                    Dim query = From row In dt案件
'                                Group row By PROJECT_TYPE_ID = row.Field(Of String)("PROJECT_TYPE_ID") Into typegroup = Group
'                                Select New With {
'                            Key PROJECT_TYPE_ID,
'                            .COUNT = typegroup.Count(Function(r) r.Field(Of String)("PROJECT_TYPE_ID"))
'                            }

'                    Dim aryCount As New ArrayList
'                    For Each x As Object In query
'                        aryCount.Add(x.COUNT)
'                    Next

'                    For i As Integer = aryCount.Count - 1 To 0 Step -1
'                        For j As Integer = 1 To aryCount(i)
'                            tb.InsertRow(tr2, 3)
'                        Next
'                        tb.InsertRow(tr1, 3)
'                    Next

'                    '移除預設兩列
'                    tb.RemoveRow(2)
'                    tb.RemoveRow(1)

'                    '塞資料
'                    Dim _row As Integer = 1
'                    Dim preId As String = String.Empty
'                    For Each dr As DataRow In dt案件.Rows
'                        If dr("PROJECT_TYPE_ID") <> preId Then
'                            tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("PROJECT_TYPE_NM"))
'                            tb.Rows(_row).Height = 35
'                            _row += 1
'                        End If

'                        tb.Rows(_row).Cells(0).Paragraphs.First().ReplaceText("一", dr("SYS_NAME").ToString())
'                        tb.Rows(_row).Cells(1).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_ONE_YEAR").ToString()))
'                        tb.Rows(_row).Cells(2).Paragraphs.First().ReplaceText("一", dr("ONE_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(3).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_TWO_YEAR").ToString()))
'                        tb.Rows(_row).Cells(4).Paragraphs.First().ReplaceText("一", dr("TWO_TOTAL_REV_RATIO").ToString())
'                        tb.Rows(_row).Cells(5).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(dr("FUTURE_THREE_YEAR").ToString()))
'                        tb.Rows(_row).Cells(6).Paragraphs.First().ReplaceText("一", dr("THREE_TOTAL_REV_RATIO").ToString())

'                        preId = dr("PROJECT_TYPE_ID")
'                        _row += 1
'                    Next

'                    '計算總數
'                    Dim tot1 As Decimal = 0
'                    Dim tot2 As Decimal = 0
'                    Dim tot3 As Decimal = 0

'                    tot1 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_ONE_YEAR)", ""), "0"))
'                    tot2 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_TWO_YEAR)", ""), "0"))
'                    tot3 = ToDecimal(Utility.CheckNull(dt案件.Compute("sum(FUTURE_THREE_YEAR)", ""), "0"))

'                    tb.Rows(tb.RowCount - 1).Cells(1).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot1))
'                    tb.Rows(tb.RowCount - 1).Cells(3).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot2))
'                    tb.Rows(tb.RowCount - 1).Cells(5).Paragraphs.First().ReplaceText("一", ToFormattedDecimal(tot3))

'                    document.Save()
'                End Using

'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110107"
'        Private Function APP110107(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[外國人持股比例計算表]"

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & caseNo.Substring(0, 2) & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQuery(), FormatType.Report)

'                If dt案件.Rows.Count <= 0 Then
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)

'                '宣告範本容器
'                Dim valuesToFill As Content = Nothing
'                valuesToFill = New Content()

'                '塞變數資料
'                valuesToFill.Fields.Add(New FieldContent("APP_PERSON_NM", dr("APP_PERSON_NM").ToString))
'                valuesToFill.Fields.Add(New FieldContent("TOTAL_PROPERTY", If(dr("TOTAL_PROPERTY").ToString <> "", String.Format("{0:#,###}", CLng(dr("TOTAL_PROPERTY"))).ToString, "0")))
'                If Not IsDBNull(dr("FOREIGNER_CAL_BASE_DATE")) Then
'                    If Not dr("FOREIGNER_CAL_BASE_DATE") Is Nothing Then
'                        If Not dr("FOREIGNER_CAL_BASE_DATE").ToString.Length = 0 Then
'                            valuesToFill.Fields.Add(New FieldContent("FORCALBASEDATE_Y", dr("FOREIGNER_CAL_BASE_DATE").ToString.Split("/")(0)))
'                            valuesToFill.Fields.Add(New FieldContent("FORCALBASEDATE_M", dr("FOREIGNER_CAL_BASE_DATE").ToString.Split("/")(1)))
'                            valuesToFill.Fields.Add(New FieldContent("FORCALBASEDATE_D", dr("FOREIGNER_CAL_BASE_DATE").ToString.Split("/")(2)))
'                        End If
'                    End If
'                End If

'                '塞Table資料(A表)
'                Dim ctrl1 As CtAPP1120 = New CtAPP1120(_dbManager, _logUtil)
'                ctrl1.CASE_NO = caseNo
'                Dim dtA As DataTable = ctrl1.DoQuery()

'                If (dtA.Rows.Count > 0) Then
'                    Dim i = 0
'                    Dim tableContent1 As TableContent = New TableContent("APP1120")
'                    For Each dr1 As DataRow In dtA.Rows
'                        i += 1
'                        tableContent1.AddRow(
'                    New FieldContent("No", i),
'                New FieldContent("DIRECT_INV_SHARE", dr1("DIRECT_INV_SHARE")),
'                New FieldContent("COUNTRY", dr1("COUNTRY")),
'                New FieldContent("DIRECT_SHARE_RATIO", dr1("DIRECT_SHARE_RATIO").ToString()),
'                New FieldContent("DIRECT_SHARE_AMOUNT", String.Format("{0: #,###}", CInt(dr1("DIRECT_SHARE_AMOUNT"))).ToString)
'                )
'                    Next

'                    '合計
'                    Dim sum_DIRECT_SHARE_RATIO = dtA.Compute("SUM(DIRECT_SHARE_RATIO)", String.Empty).ToString()
'                    valuesToFill.Fields.Add(New FieldContent("sum_DIRECT_SHARE_RATIO", sum_DIRECT_SHARE_RATIO))
'                    valuesToFill.Fields.Add(New FieldContent("sum_DIRECT_SHARE_RATIO2", sum_DIRECT_SHARE_RATIO))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent1)
'                End If



'                '塞Table資料(APP1130)
'                Dim ctrl3 As CtAPP1130 = New CtAPP1130(_dbManager, _logUtil)
'                ctrl3.CASE_NO = caseNo
'                Dim dtB As DataTable = ctrl3.DoQuery()

'                If dtB.Rows.Count > 0 Then
'                    Dim tableContent2 As TableContent = New TableContent("APP1130")
'                    Dim i = 0
'                    For Each dr1 As DataRow In dtB.Rows
'                        i = i + 1
'                        tableContent2.AddRow(
'                New FieldContent("No", i),
'                New FieldContent("DIRECT_COR_SHARE", dr1("DIRECT_COR_SHARE")),
'                New FieldContent("DIRECT_IDNO", dr1("DIRECT_IDNO")),
'                New FieldContent("DIRECT_SHARE_RATIO_1", dr1("DIRECT_SHARE_RATIO_1").ToString()),
'                New FieldContent("DIRECT_INV_OBJECT", dr1("DIRECT_INV_OBJECT")),
'                New FieldContent("INDIRECT_APPLIC_RATIO", dr1("INDIRECT_APPLIC_RATIO").ToString()),
'                New FieldContent("FOREIG_DIRECT_INV_SHARE", dr1("FOREIG_DIRECT_INV_SHARE")),
'                New FieldContent("COUNTRY_1", dr1("COUNTRY_1")),
'                New FieldContent("DIRECT_SHARE_RATIO_2", dr1("DIRECT_SHARE_RATIO_2").ToString()),
'                New FieldContent("FOREIG_INDIRECT_APPLIC_RATIO", dr1("FOREIG_INDIRECT_APPLIC_RATIO").ToString())
'                )
'                    Next

'                    '合計
'                    Dim sum_FOREIG_INDIRECT_APPLIC_RATIO = dtB.Compute("SUM(FOREIG_INDIRECT_APPLIC_RATIO)", String.Empty).ToString()
'                    valuesToFill.Fields.Add(New FieldContent("sum_FOREIG_INDIRECT_APPLIC_RATIO", sum_FOREIG_INDIRECT_APPLIC_RATIO))

'                    '加入Table資料
'                    valuesToFill.Tables.Add(tableContent2)
'                End If



'                '將容器資料對應到暫存檔並存檔
'                Using TP As TemplateProcessor = New TemplateProcessor(tempfilename).SetRemoveContentControls(True)
'                    TP.FillContent(valuesToFill)
'                    TP.SaveChanges()

'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110108"
'        Private Function APP110108(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[董事名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案號為空"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "1"  '董事名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsNum As Integer = dt.Rows.Count
'                    Dim pageNum As Integer = (rowsNum / 6) + IIf(rowsNum Mod 6 > 0, 1, 0)

'                    '=== 處理加頁與斷頁符號 ===
'                    For j As Integer = 1 To pageNum - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    '=== 處理資料 ===
'                    Dim pageRow As Integer = 1  '頁面筆數
'                    Dim tableNum As Integer = 1 '表格index
'                    'Dim rows As Integer = 1     '總資料筆數

'                    For k As Integer = 0 To rowsNum - 1
'                        '若大於六筆，則加一頁
'                        If (pageRow > 6) Then
'                            pageRow = 1
'                            tb = document.Tables(tableNum)
'                            tableNum += 1
'                        End If

'                        '處理地址
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        '取代內容
'                        tb.Rows(0).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("JOB_TITLE").ToString())
'                        tb.Rows(1).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_NAME").ToString())
'                        tb.Rows(2).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_ID").ToString())
'                        tb.Rows(3).Cells(pageRow).ReplaceText("取代", DateUtil.ConvertFormatDate(dt.Rows(k)("BIRTHDAY_DATE").ToString()))
'                        tb.Rows(4).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("CITIZENSHIP").ToString())
'                        tb.Rows(5).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("SHARES_RATE").ToString())
'                        tb.Rows(6).Cells(pageRow).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("SHARES_AMT").ToString()))
'                        tb.Rows(7).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EXPERIENCE").ToString())
'                        tb.Rows(8).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EDUCATION").ToString())
'                        tb.Rows(9).Cells(pageRow).ReplaceText("取代", address)
'                        tb.Rows(10).Cells(pageRow).ReplaceText("取代", If(String.IsNullOrEmpty(dt.Rows(k)("TEL_CODE").ToString()), dt.Rows(k)("TEL").ToString(), dt.Rows(k)("TEL_CODE").ToString() & "-" & dt.Rows(k)("TEL").ToString()))
'                        tb.Rows(12).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("REMARK").ToString())
'                        pageRow += 1
'                        'rows += 1
'                    Next

'                    '將無資料的格子以空白取代
'                    For j As Integer = 0 To pageNum - 1
'                        tb = document.Tables(j)
'                        For row As Integer = 0 To 12
'                            For col As Integer = 1 To 6
'                                tb.Rows(row).Cells(col).ReplaceText("取代", "")
'                            Next
'                        Next
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'        Private Function GetAddr(ByVal id1 As String, ByVal id2 As String) As String
'            'Dim dt As DataTable = Application("DT_ADDR")
'            Dim ctrl As New CtSYST010(_dbManager, _logUtil)
'            ctrl.SYS_KEY = "CITY_CODE"
'            ctrl.SYS_TYPE = "1"
'            Dim dt As DataTable = ctrl.DoQuery

'            If Not String.IsNullOrEmpty(id1) Then
'                dt.DefaultView.RowFilter = " SYS_ID ='" & id1 & "' AND ISNULL(SYS_PRTID,'') = '' "

'                If dt.DefaultView.Count = 1 Then
'                    Return dt.DefaultView(0).Item("SYS_NAME").ToString
'                Else
'                    Return ""
'                End If
'            End If

'            If Not String.IsNullOrEmpty(id2) Then
'                dt.DefaultView.RowFilter = " SYS_ID ='" & id2 & "' AND ISNULL(SYS_PRTID,'') <> '' "

'                If dt.DefaultView.Count = 1 Then
'                    Return dt.DefaultView(0).Item("SYS_NAME").ToString
'                Else
'                    Return ""
'                End If
'            End If

'            Return ""
'        End Function
'#End Region

'#Region "APP110109"
'        Private Function APP110109(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[監察人名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    rptModel.Message = msgTitle + "案號為空"
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "2"  '監察人名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY ' "無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsNum As Integer = dt.Rows.Count
'                    Dim pageNum As Integer = (rowsNum / 6) + IIf(rowsNum Mod 6 > 0, 1, 0)

'                    '=== 處理加頁與斷頁符號 ===
'                    For j As Integer = 1 To pageNum - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    '=== 處理資料 ===
'                    Dim pageRow As Integer = 1  '頁面筆數
'                    Dim tableNum As Integer = 1 '表格index
'                    'Dim rows As Integer = 1     '總資料筆數

'                    For k As Integer = 0 To rowsNum - 1
'                        '若大於六筆，則加一頁
'                        If (pageRow > 6) Then
'                            pageRow = 1
'                            tb = document.Tables(tableNum)
'                            tableNum += 1
'                        End If

'                        '處理地址
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        '取代內容
'                        tb.Rows(0).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("JOB_TITLE").ToString())
'                        tb.Rows(1).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_NAME").ToString())
'                        tb.Rows(2).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_ID").ToString())
'                        tb.Rows(3).Cells(pageRow).ReplaceText("取代", DateUtil.ConvertFormatDate(dt.Rows(k)("BIRTHDAY_DATE").ToString()))
'                        tb.Rows(4).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("CITIZENSHIP").ToString())
'                        tb.Rows(5).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("SHARES_RATE").ToString())
'                        tb.Rows(6).Cells(pageRow).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("SHARES_AMT").ToString()))
'                        tb.Rows(7).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EXPERIENCE").ToString())
'                        tb.Rows(8).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EDUCATION").ToString())
'                        tb.Rows(9).Cells(pageRow).ReplaceText("取代", address)
'                        tb.Rows(10).Cells(pageRow).ReplaceText("取代", If(String.IsNullOrEmpty(dt.Rows(k)("TEL_CODE").ToString()), dt.Rows(k)("TEL").ToString(), dt.Rows(k)("TEL_CODE").ToString() & "-" & dt.Rows(k)("TEL").ToString()))
'                        tb.Rows(12).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("REMARK").ToString())
'                        pageRow += 1
'                        'rows += 1
'                    Next

'                    '將無資料的格子以空白取代
'                    For j As Integer = 0 To pageNum - 1
'                        tb = document.Tables(j)
'                        For row As Integer = 0 To 12
'                            For col As Integer = 1 To 6
'                                tb.Rows(row).Cells(col).ReplaceText("取代", "")
'                            Next
'                        Next
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110110"
'        Private Function APP110110(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[經理人名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案號為空"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "3"  '股東名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsNum As Integer = dt.Rows.Count
'                    Dim pageNum As Integer = (rowsNum / 6) + IIf(rowsNum Mod 6 > 0, 1, 0)

'                    '=== 處理加頁與斷頁符號 ===
'                    For j As Integer = 1 To pageNum - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    '=== 處理資料 ===
'                    Dim pageRow As Integer = 1  '頁面筆數
'                    Dim tableNum As Integer = 1 '表格index
'                    'Dim rows As Integer = 1     '總資料筆數

'                    For k As Integer = 0 To rowsNum - 1
'                        '若大於六筆，則加一頁
'                        If (pageRow > 6) Then
'                            pageRow = 1
'                            tb = document.Tables(tableNum)
'                            tableNum += 1
'                        End If

'                        '處理地址
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        '取代內容
'                        tb.Rows(0).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("JOB_TITLE").ToString())
'                        tb.Rows(1).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_NAME").ToString())
'                        tb.Rows(2).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_ID").ToString())
'                        tb.Rows(3).Cells(pageRow).ReplaceText("取代", DateUtil.ConvertFormatDate(dt.Rows(k)("BIRTHDAY_DATE").ToString()))
'                        tb.Rows(4).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("CITIZENSHIP").ToString())
'                        tb.Rows(5).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("SHARES_RATE").ToString())
'                        tb.Rows(6).Cells(pageRow).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("SHARES_AMT").ToString()))
'                        tb.Rows(7).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EXPERIENCE").ToString())
'                        tb.Rows(8).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EDUCATION").ToString())
'                        tb.Rows(9).Cells(pageRow).ReplaceText("取代", address)
'                        tb.Rows(10).Cells(pageRow).ReplaceText("取代", If(String.IsNullOrEmpty(dt.Rows(k)("TEL_CODE").ToString()), dt.Rows(k)("TEL").ToString(), dt.Rows(k)("TEL_CODE").ToString() & "-" & dt.Rows(k)("TEL").ToString()))
'                        tb.Rows(12).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("REMARK").ToString())
'                        pageRow += 1
'                        'rows += 1
'                    Next

'                    '將無資料的格子以空白取代
'                    For j As Integer = 0 To pageNum - 1
'                        tb = document.Tables(j)
'                        For row As Integer = 0 To 12
'                            For col As Integer = 1 To 6
'                                tb.Rows(row).Cells(col).ReplaceText("取代", "")
'                            Next
'                        Next
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110111"
'        Private Function APP110111(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[股東名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案號為空"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "4"  '股東名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsNum As Integer = dt.Rows.Count
'                    Dim pageNum As Integer = (rowsNum / 6) + IIf(rowsNum Mod 6 > 0, 1, 0)

'                    '=== 處理加頁與斷頁符號 ===
'                    For j As Integer = 1 To pageNum - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    '=== 處理資料 ===
'                    Dim pageRow As Integer = 1  '頁面筆數
'                    Dim tableNum As Integer = 1 '表格index
'                    'Dim rows As Integer = 1     '總資料筆數

'                    For k As Integer = 0 To rowsNum - 1
'                        '若大於六筆，則加一頁
'                        If (pageRow > 6) Then
'                            pageRow = 1
'                            tb = document.Tables(tableNum)
'                            tableNum += 1
'                        End If

'                        '處理地址
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        '取代內容
'                        'tb.Rows(0).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("JOB_TITLE").ToString())
'                        tb.Rows(1).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_NAME").ToString())
'                        tb.Rows(2).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_ID").ToString())
'                        tb.Rows(3).Cells(pageRow).ReplaceText("取代", DateUtil.ConvertFormatDate(dt.Rows(k)("BIRTHDAY_DATE").ToString()))
'                        tb.Rows(4).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("CITIZENSHIP").ToString())
'                        tb.Rows(5).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("SHARES_RATE").ToString())
'                        tb.Rows(6).Cells(pageRow).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("SHARES_AMT").ToString()))
'                        tb.Rows(7).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EXPERIENCE").ToString())
'                        tb.Rows(8).Cells(pageRow).ReplaceText("取代", address)
'                        tb.Rows(9).Cells(pageRow).ReplaceText("取代", If(String.IsNullOrEmpty(dt.Rows(k)("TEL_CODE").ToString()), dt.Rows(k)("TEL").ToString(), dt.Rows(k)("TEL_CODE").ToString() & "-" & dt.Rows(k)("TEL").ToString()))
'                        tb.Rows(11).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("REMARK").ToString())
'                        pageRow += 1
'                        'rows += 1
'                    Next

'                    '將無資料的格子以空白取代
'                    For j As Integer = 0 To pageNum - 1
'                        tb = document.Tables(j)
'                        For row As Integer = 0 To 11
'                            For col As Integer = 1 To 6
'                                tb.Rows(row).Cells(col).ReplaceText("取代", "")
'                            Next
'                        Next
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110113"
'        Private Function APP110113(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[認股人名冊]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                If Not IO.File.Exists(Templatefilename) Then
'                    'JScript.Script = "alert('Word範本檔不存在');location.reload();"
'                    errmsg = msgTitle + "Word範本檔不存在"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)

'                If String.IsNullOrEmpty(caseNo) Then
'                    errmsg = msgTitle + "案號為空"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                '=== 呼叫control ===
'                Dim ctrl As CtAPP1030 = New CtAPP1030(_dbManager, _logUtil)
'                ctrl.GROUP_TYPE = "6"  '認股人名冊
'                ctrl.CASE_NO = caseNo
'                Dim dt As DataTable = ctrl.DoQuery()

'                If dt.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Using document As DocX = DocX.Load(tempfilename)
'                    Dim tb As Novacode.Table = document.Tables(0)
'                    Dim rowsNum As Integer = dt.Rows.Count
'                    Dim pageNum As Integer = (rowsNum / 6) + IIf(rowsNum Mod 6 > 0, 1, 0)

'                    '=== 處理加頁與斷頁符號 ===
'                    For j As Integer = 1 To pageNum - 1
'                        document.Tables(0).InsertTableAfterSelf(tb)
'                        document.Tables(0).InsertPageBreakAfterSelf()
'                    Next

'                    '=== 處理資料 ===
'                    Dim pageRow As Integer = 1  '頁面筆數
'                    Dim tableNum As Integer = 1 '表格index
'                    'Dim rows As Integer = 1     '總資料筆數

'                    For k As Integer = 0 To rowsNum - 1
'                        '若大於六筆，則加一頁
'                        If (pageRow > 6) Then
'                            pageRow = 1
'                            tb = document.Tables(tableNum)
'                            tableNum += 1
'                        End If

'                        '處理地址
'                        Dim address As String = GetAddr(dt.Rows(k)("ADDR_CITY1"), "") & GetAddr("", dt.Rows(k)("ADDR_CITY2")) & dt.Rows(k)("ADDR")

'                        '取代內容
'                        tb.Rows(0).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("JOB_TITLE").ToString())
'                        tb.Rows(1).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_NAME").ToString())
'                        tb.Rows(2).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("USER_ID").ToString())
'                        tb.Rows(3).Cells(pageRow).ReplaceText("取代", DateUtil.ConvertFormatDate(dt.Rows(k)("BIRTHDAY_DATE").ToString()))
'                        tb.Rows(4).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("CITIZENSHIP").ToString())
'                        tb.Rows(5).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("SHARES_RATE").ToString())
'                        tb.Rows(6).Cells(pageRow).ReplaceText("取代", ToFormattedDecimal(dt.Rows(k)("SHARES_AMT").ToString()))
'                        tb.Rows(7).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EXPERIENCE").ToString())
'                        tb.Rows(8).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("EDUCATION").ToString())
'                        tb.Rows(9).Cells(pageRow).ReplaceText("取代", address)
'                        tb.Rows(10).Cells(pageRow).ReplaceText("取代", If(String.IsNullOrEmpty(dt.Rows(k)("TEL_CODE").ToString()), dt.Rows(k)("TEL").ToString(), dt.Rows(k)("TEL_CODE").ToString() & "-" & dt.Rows(k)("TEL").ToString()))
'                        tb.Rows(11).Cells(pageRow).ReplaceText("取代", If(dt.Rows(k)("LAUNCH_FLAG").ToString() = "Y", "■是 □否", "□是 ■否"))
'                        tb.Rows(12).Cells(pageRow).ReplaceText("取代", dt.Rows(k)("REMARK").ToString())
'                        pageRow += 1
'                        'rows += 1
'                    Next

'                    '將無資料的格子以空白取代
'                    For j As Integer = 0 To pageNum - 1
'                        tb = document.Tables(j)
'                        For row As Integer = 0 To 12
'                            For col As Integer = 1 To 6
'                                tb.Rows(row).Cells(col).ReplaceText("取代", "")
'                            Next
'                        Next
'                    Next

'                    document.Save()
'                End Using

'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'#Region "APP110201"
'        Private Function APP110201(ByVal pageId As String, ByVal sort As String, ByVal caseNo As String) As ReportModel
'            Try
'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                Dim rptModel As New ReportModel
'                Dim errmsg As String = ""
'                Dim msgTitle As String = "[申請書]"

'                _logUtil.MethodStart(GetCurrentMethod.Name)

'                '範本檔
'                Dim Templatefilename As String = APConfig.GetProperty("DOCX_TEMPLATE_PATH") & pageId & ".DOCX"
'                '暫存檔
'                Dim tempfilename As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & sort & "_" & msgTitle & "_" & caseNo & "_" & DateUtil.GetNowTimeMS & ".DOCX"
'                rptModel.FileFullPath = tempfilename
'                '複製範本檔成暫存檔
'                System.IO.File.Copy(Templatefilename, tempfilename)
'                _logUtil.Logger.Append("複製範本檔成暫存檔:" & tempfilename)

'                '主檔資料
'                Dim ctrl As CtAPP1010 = New CtAPP1010(_dbManager, _logUtil)
'                ctrl.CASE_NO = caseNo '案號
'                Dim dt案件 As DataTable = Me.BindDDFormat(ctrl.DoQueryAll(), FormatType.Edit)

'                If dt案件.Rows.Count <= 0 Then
'                    'JScript.Alert("無任何資料,請先新增並儲存資料後再執行[列印]。")
'                    'Return ""
'                    errmsg = msgTitle + MESSAGE.DATA_EMPTY '"無任何資料,請先新增並儲存資料後再執行[列印]。"
'                    rptModel.Message = errmsg
'                    Return rptModel
'                End If

'                Dim dr As DataRow = dt案件.Rows(0)
'                If dr("START_SCH_DATE").ToString().Length >= 7 Then
'                    dr("預定開播日期") = "中華民國" & dr("START_SCH_DATE").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                End If
'                dr("申請日期") = "中華民國" & dr("CREATE_TIME").ToString.Replace("/", "").Insert(3, "年").Insert(6, "月") & "日"
'                '書籤定義在 dt_自訂欄位
'                'Dim dt_自訂欄位 As DataTable = Me.GetDtBySql("TSBA", "SELECT * FROM SYST012 ORDER BY SORT ")
'                Dim ent As ENT_SYST012 = New ENT_SYST012(_dbManager, _logUtil)
'                Dim dt_自訂欄位 As DataTable = ent.Query()
'                Dim dr_select As DataRow()
'                Using document As Novacode.DocX = Novacode.DocX.Load(tempfilename)
'                    '置換書籤
'                    For Each bookmark As Novacode.Bookmark In document.Bookmarks
'                        dr_select = dt_自訂欄位.Select("S_FIELD_BOOKMARK ='" & bookmark.Name & "'")
'                        If dr_select.Length > 0 Then
'                            If (dt案件.Columns.Contains(dr_select(0).Item("S_FIELD").ToString)) Then
'                                document.Bookmarks(bookmark.Name).SetText(dr(dr_select(0).Item("S_FIELD").ToString).ToString)
'                            End If
'                        Else
'                            '特殊欄位 資料有就顯示
'                            If (dt案件.Columns.Contains(bookmark.Name)) Then
'                                If (bookmark.Name = "實收資本額") Then
'                                    If dr(bookmark.Name).ToString = "" Then
'                                        document.Bookmarks(bookmark.Name).SetText("")
'                                    Else
'                                        document.Bookmarks(bookmark.Name).SetText(String.Format("{0:#,###}", Convert.ToDouble(dr(bookmark.Name))))
'                                    End If
'                                Else
'                                    document.Bookmarks(bookmark.Name).SetText(dr(bookmark.Name).ToString)
'                                End If
'                            End If
'                        End If
'                    Next

'                    document.Save()
'                End Using


'                Return rptModel

'            Finally
'                _logUtil.MethodEnd(GetCurrentMethod.Name)
'            End Try
'        End Function
'#End Region

'        '#Region "APP110115"
'        '        Private Function APP110115(ByVal pageId As String, ByVal caseNo As String) As ReportModel
'        '            Try
'        '                Dim rptModel As New ReportModel
'        '                Dim errmsg As String = ""
'        '                Dim acce_source_param As String = pageId + "_DOC_1" 'ex: APP110115_DOC_1
'        '                Dim a_name As String = "" '檔案實際檔名與相對位置
'        '                Dim fpath As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & a_name '下載存放位置與儲存檔名

'        '                _logUtil.MethodStart(GetCurrentMethod.Name)

'        '                Dim condition As StringBuilder = New StringBuilder()
'        '                If caseNo.Length = 0 Then
'        '                    errmsg = MESSAGE.CASE_NO_IS_EMPTY
'        '                    rptModel.Message = errmsg
'        '                    Return rptModel
'        '                End If

'        '                Dim ent As EntAttachFile = New EntAttachFile(_dbManager, _logUtil)
'        '                Me.ProcessQueryCondition(condition, "=", "CASE_NO", caseNo)
'        '                Me.ProcessQueryCondition(condition, "=", "ACCE_SOURCE", acce_source_param)
'        '                Me.ProcessQueryCondition(condition, "=", "FILE_NO", "1")

'        '                ent.SqlRetrictions = condition.ToString()
'        '                ent.OrderBys = "CASE_NO ASC"

'        '                Dim dt As DataTable = ent.Query()

'        '                For Each dataRow As DataRow In dt.Rows
'        '                    Dim actualFileName As String = dataRow("ACTUAL_FILENAME")
'        '                    If actualFileName.Length > 0 Then
'        '                        a_name = caseNo + "/" + actualFileName
'        '                        _logUtil.Logger.Append("ACTUAL_FILENAME and Path = " + a_name)
'        '                        _logUtil.Logger.Append("Download Destination = " + Cf(fpath))
'        '                        downloadFile(a_name, Cf(fpath))
'        '                        rptModel.FileList.Add(actualFileName)
'        '                        a_name = ""
'        '                    End If
'        '                Next

'        '                Return rptModel

'        '            Finally
'        '                _logUtil.MethodEnd(GetCurrentMethod.Name)
'        '            End Try
'        '        End Function

'        '        Private Sub downloadFile(ByVal filepath As String, ByVal path As String)
'        '            Try
'        '                _logUtil.Logger.Append("d file 1")
'        '                If APConfig.GetProperty("FTPS_ADDRESS") <> "" Then
'        '                    _logUtil.Logger.Append("d file 2")
'        '                    filepath = APConfig.GetProperty("FTPS_FILE") & filepath
'        '                    _logUtil.Logger.Append("d file 3")
'        '                    'Comm.Common.Common.FTPSDownload(filepath.ToString.Replace("\", "/"), path)
'        '                    _logUtil.Logger.Append("filePath 1= " + filepath.ToString.Replace("\", "/"))
'        '                    _logUtil.Logger.Append("filePath 2= " + path)
'        '                    _logUtil.Logger.Append("d file 4")
'        '                End If
'        '            Catch ex As System.Net.WebException
'        '                '=== 當錯誤為找不到該目錄或檔案忽略該錯誤, (測試每次都會出現此問題所以忽略) ===
'        '                If ex.Message.IndexOf("550") = -1 Then
'        '                    Throw
'        '                End If
'        '            Finally
'        '                _logUtil.MethodEnd(GetCurrentMethod.Name)
'        '            End Try
'        '        End Sub

'        '#Region "Cf 調整反斜線"
'        '        Private Function Cf(ByVal path As String) As String
'        '            Return path.Replace("\\", "\").Replace("\/", "\").Replace("/", "\")
'        '        End Function
'        '#End Region
'        '#End Region

'#End Region

'#Region "Model"
'        Public Class ReportModel
'            Public Message As String = ""
'            Public FileFullPath As String = ""
'            'Public FileList As New List(Of String)
'        End Class

'#Region "Model APP210301"
'        Private Class APP210301_Model
'            Public Class Column
'                Public Const TOPIC_SEQ = "TOPIC_SEQ"
'                Public Const TOPIC_ANSWER = "TOPIC_ANSWER"
'                Public Const PRE_ANSWER = "PRE_ANSWER"
'                Public Const MARK = "MARK"
'                Public Const QNO = "QNO"
'                Public Const QNO_DESC = "QNO_DESC"
'                Public Const SYS_RSV1 = "SYS_RSV1"
'                Public Const APP_PERSON_NM = "APP_PERSON_NM"
'                Public Const SYS_CNAME = "SYS_CNAME"
'            End Class

'            Public Class Report
'                Public Const Text_A = "[A]"
'                Public Const Text_B = "[B]"
'                Public Const Text_C = "[C]"
'                Public Const Text_D = "[D]"
'                Public Const Text_E = "[E]"
'                Public Const Text_F = "[F]"
'                Public Const Text_G = "[G]"
'                Public Const Text_H = "[H]"
'                Public Const Text_I = "[I]"
'            End Class
'        End Class
'#End Region

'#Region "Model APP210303"
'        Private Class APP210303_Model
'            Public Class Column
'                Public Const SYS_NAME As String = "SYS_NAME"
'                Public Const APP_PERSON_NM As String = "APP_PERSON_NM"
'                Public Const SYS_CNAME As String = "SYS_CNAME"
'                Public Const CH_NAME As String = "CH_NAME"
'                Public Const TOTAL_MARK As String = "TOTAL_MARK"
'                Public Const CHECKED_QNO_DESC As String = "CHECKED_QNO_DESC"
'                Public Const QNO As String = "QNO"
'                Public Const QNO_DESC As String = "QNO_DESC"
'                Public Const TOPIC_SEQ As String = "TOPIC_SEQ"
'                Public Const TOPIC_ANSWER As String = "TOPIC_ANSWER"
'                Public Const ACNT As String = "ACNT"
'                Public Class Key
'                    Public Const PRE_ANSWER As String = "PRE_ANSWER"
'                End Class
'            End Class

'            Public Class Report
'                Public Const Text_A = "[A]"
'                Public Const Text_B = "[B]"
'                Public Const Text_C = "[C]"
'                Public Const Text_D = "[D]"
'                Public Const Text_E = "[E]"
'                Public Const Text_F = "[F]"
'                Public Const Text_G = "[G]"
'                Public Const Text_H = "[H]"
'                Public Const Text_I = "[I]"
'            End Class
'        End Class
'#End Region

'#Region "PreMeeting"
'        Public Class PREMETTING_Model
'            Public Class Column
'                Public Const CASE_NO As String = "CASE_NO"
'                Public Const APP_PERSON_NM As String = "APP_PERSON_NM"
'                Public Const SYS_CNAME As String = "SYS_CNAME"
'                Public Const ORG_TYPE1_NM As String = "ORG_TYPE1_NM"
'                Public Const ORG_TYPE1 As String = "ORG_TYPE1"
'                Public Const CHANNEL_NAME As String = "CHANNEL_NAME"
'                Public Const MEETING_TYPE_NM As String = "MEETING_TYPE_NM"
'                Public Const MEETING_TYPE As String = "MEETING_TYPE"
'                Public Const CHSYS_TYPE As String = "CHSYS_TYPE"
'                Public Const ANALOGY_CHANNEL_LOCATION As String = "ANALOGY_CHANNEL_LOCATION"
'                Public Const DIGIT_CHANNEL_LOCATION As String = "DIGIT_CHANNEL_LOCATION"
'            End Class
'            Public Class Key
'                Public Const PKNO As String = "PKNO"
'                Public Const GROUP_CODE As String = "GROUP_CODE"
'                Public Const PageId_APP210303 As String = "APP210303"
'                Public Const ReviewFormTemplete As String = "ReviewFormTemplete"
'                Public Const EmptyTemplete As String = "EmptyTemplete"
'                Public Const PreMeetingTemplete As String = "PreMeetingTemplete"
'                Public Const PreMeeting As String = "PreMeeting"
'            End Class
'            Public Class ReportTag
'                Public Const A = "[A]"
'                Public Const B = "[B]"
'                Public Const C = "[C]"
'                Public Const D = "[D]"
'                Public Const E = "[E]"
'                Public Const F_0 = "[F_0]"
'                Public Const F_1 = "[F_1]"
'                Public Const F_2 = "[F_2]"
'                Public Const F_3 = "[F_3]"
'                Public Const F_4 = "[F_4]"
'                Public Const F_5 = "[F_5]"
'                Public Const F_6 = "[F_6]"
'                Public Const F_7 = "[F_7]"
'                Public Const F_8 = "[F_8]"
'                Public Const F_9 = "[F_9]"
'                Public Const F_10 = "[F_10]"
'            End Class
'        End Class
'#End Region


'#Region "Model APP110103_REPORT_DATA_MODEL"
'        Private Class APP110103_REPORT_DATA_MODEL
'            Public AMOUNT As New List(Of AMOUNT)
'            Public TOTAL As New List(Of TOTAL)
'            Public SUB_TOTAL As New List(Of SUB_TOTAL)
'            Public PERCENT As New PERCENT
'        End Class

'        Private Class AMOUNT
'            Public col_x As String = ""
'            Public col_y As String = ""
'        End Class

'        Private Class SUB_TOTAL
'            Public col_x As String = ""
'            Public col_y As String = ""
'        End Class
'        Private Class TOTAL
'            Public col_x As String = ""
'            Public col_y As String = ""
'        End Class
'        Private Class PERCENT
'            Public AMOUNT As New List(Of AMOUNT)
'            Public SUB_TOTAL As New List(Of SUB_TOTAL)
'            Public TOTAL As New List(Of String)
'        End Class
'        Public Class MESSAGE
'            Public Const CASE_NO_IS_EMPTY As String = "案號為空"
'            Public Const DATA_EMPTY As String = "無任何資料,請先新增並儲存資料後再執行[列印]。"
'        End Class
'#End Region
'#End Region
'    End Class

'End Namespace
