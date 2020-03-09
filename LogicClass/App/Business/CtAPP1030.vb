'ProductName                 : TSBA 
'File Name					 : CtAPP1030 
'Description	             : CtAPP1030 董事/監察人/經理人/股東/發起人/認股人/捐助人
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/12/08         Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1030
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1030 = New ENT_APP1030(Me.DBManager, Me.LogUtil)
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

#Region "GROUP_TYPE 名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人"
        '' <summary>
        '' GROUP_TYPE 名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人
        '' </summary>
        Public Property GROUP_TYPE() As String
            Get
                Return Me.PropertyMap("GROUP_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("GROUP_TYPE") = value
            End Set
        End Property
#End Region

#Region "JOB_TITLE 職稱"
        '' <summary>
        '' JOB_TITLE 職稱
        '' </summary>
        Public Property JOB_TITLE() As String
            Get
                Return Me.PropertyMap("JOB_TITLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("JOB_TITLE") = value
            End Set
        End Property
#End Region

#Region "USER_NAME 姓名(法人名稱)"
        '' <summary>
        '' USER_NAME 姓名(法人名稱)
        '' </summary>
        Public Property USER_NAME() As String
            Get
                Return Me.PropertyMap("USER_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USER_NAME") = value
            End Set
        End Property
#End Region

#Region "USER_ID 身分證字號(護照號碼)(法人統一編號)"
        '' <summary>
        '' USER_ID 身分證字號(護照號碼)(法人統一編號)
        '' </summary>
        Public Property USER_ID() As String
            Get
                Return Me.PropertyMap("USER_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USER_ID") = value
            End Set
        End Property
#End Region

#Region "BIRTHDAY_DATE 出生年月日(設立日期)"
        '' <summary>
        '' BIRTHDAY_DATE 出生年月日(設立日期)
        '' </summary>
        Public Property BIRTHDAY_DATE() As String
            Get
                Return Me.PropertyMap("BIRTHDAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BIRTHDAY_DATE") = value
            End Set
        End Property
#End Region

#Region "CITIZENSHIP 國籍"
        '' <summary>
        '' CITIZENSHIP 國籍
        '' </summary>
        Public Property CITIZENSHIP() As String
            Get
                Return Me.PropertyMap("CITIZENSHIP")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CITIZENSHIP") = value
            End Set
        End Property
#End Region

#Region "SHARES_RATE 持(認)股百分比"
        '' <summary>
        '' SHARES_RATE 持(認)股百分比
        '' </summary>
        Public Property SHARES_RATE() As String
            Get
                Return Me.PropertyMap("SHARES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHARES_RATE") = value
            End Set
        End Property
#End Region

#Region "SHARES_AMT 持(認)股金額"
        '' <summary>
        '' SHARES_AMT 持(認)股金額
        '' </summary>
        Public Property SHARES_AMT() As String
            Get
                Return Me.PropertyMap("SHARES_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHARES_AMT") = value
            End Set
        End Property
#End Region

#Region "EXPERIENCE 最高經歷"
        '' <summary>
        '' EXPERIENCE 最高經歷
        '' </summary>
        Public Property EXPERIENCE() As String
            Get
                Return Me.PropertyMap("EXPERIENCE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXPERIENCE") = value
            End Set
        End Property
#End Region

#Region "EDUCATION 最高學歷"
        '' <summary>
        '' EDUCATION 最高學歷
        '' </summary>
        Public Property EDUCATION() As String
            Get
                Return Me.PropertyMap("EDUCATION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EDUCATION") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY1 戶籍地址(事業登記地址)_縣市別"
        '' <summary>
        '' ADDR_CITY1 戶籍地址(事業登記地址)_縣市別
        '' </summary>
        Public Property ADDR_CITY1() As String
            Get
                Return Me.PropertyMap("ADDR_CITY1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR_CITY1") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY2 戶籍地址(事業登記地址)_行政區"
        '' <summary>
        '' ADDR_CITY2 戶籍地址(事業登記地址)_行政區
        '' </summary>
        Public Property ADDR_CITY2() As String
            Get
                Return Me.PropertyMap("ADDR_CITY2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR_CITY2") = value
            End Set
        End Property
#End Region

#Region "ADDR 戶籍地址(事業登記地址)"
        '' <summary>
        '' ADDR 戶籍地址(事業登記地址)
        '' </summary>
        Public Property ADDR() As String
            Get
                Return Me.PropertyMap("ADDR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR") = value
            End Set
        End Property
#End Region

#Region "TEL_CODE 電話_區碼"
        '' <summary>
        '' TEL_CODE 電話_區碼
        '' </summary>
        Public Property TEL_CODE() As String
            Get
                Return Me.PropertyMap("TEL_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TEL_CODE") = value
            End Set
        End Property
#End Region

#Region "TEL 電話"
        '' <summary>
        '' TEL 電話
        '' </summary>
        Public Property TEL() As String
            Get
                Return Me.PropertyMap("TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TEL") = value
            End Set
        End Property
#End Region

#Region "REMARK 備註"
        '' <summary>
        '' REMARK 備註
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

#Region "SHARES_NUMBER 持(認)股數"
        '' <summary>
        '' SHARES_NUMBER 持(認)股數
        '' </summary>
        Public Property SHARES_NUMBER() As String
            Get
                Return Me.PropertyMap("SHARES_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHARES_NUMBER") = value
            End Set
        End Property
#End Region

#Region "LAUNCH_FLAG 是否為發起人"
        '' <summary>
        '' LAUNCH_FLAG 是否為發起人
        '' </summary>
        Public Property LAUNCH_FLAG() As String
            Get
                Return Me.PropertyMap("LAUNCH_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LAUNCH_FLAG") = value
            End Set
        End Property
#End Region

#Region "CONTRIBUTION_AMT 出資額"
        '' <summary>
        '' CONTRIBUTION_AMT 出資額
        '' </summary>
        Public Property CONTRIBUTION_AMT() As String
            Get
                Return Me.PropertyMap("CONTRIBUTION_AMT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTRIBUTION_AMT") = value
            End Set
        End Property
#End Region

#Region "OB_NAME 其他事業持認股/捐助情形-事業名稱"
        '' <summary>
        '' OB_NAME 其他事業持認股/捐助情形-事業名稱
        '' </summary>
        Public Property OB_NAME() As String
            Get
                Return Me.PropertyMap("OB_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OB_NAME") = value
            End Set
        End Property
#End Region

#Region "OB_SHARES_RATE 其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例"
        '' <summary>
        '' OB_SHARES_RATE 其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例
        '' </summary>
        Public Property OB_SHARES_RATE() As String
            Get
                Return Me.PropertyMap("OB_SHARES_RATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OB_SHARES_RATE") = value
            End Set
        End Property
#End Region

#Region "OB_NAME1 其他事業擔任董監事情形-事業名稱"
        '' <summary>
        '' OB_NAME1 其他事業擔任董監事情形-事業名稱
        '' </summary>
        Public Property OB_NAME1() As String
            Get
                Return Me.PropertyMap("OB_NAME1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OB_NAME1") = value
            End Set
        End Property
#End Region

#Region "OB_JOB1 其他事業擔任董監事情形-擔任職務"
        '' <summary>
        '' OB_JOB1 其他事業擔任董監事情形-擔任職務
        '' </summary>
        Public Property OB_JOB1() As String
            Get
                Return Me.PropertyMap("OB_JOB1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OB_JOB1") = value
            End Set
        End Property
#End Region

#Region "OS_NAME1 與其他股東親屬關係-股東名稱"
        '' <summary>
        '' OS_NAME1 與其他股東親屬關係-股東名稱
        '' </summary>
        Public Property OS_NAME1() As String
            Get
                Return Me.PropertyMap("OS_NAME1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OS_NAME1") = value
            End Set
        End Property
#End Region

#Region "OS_JOB1 與其他股東親屬關係-稱謂"
        '' <summary>
        '' OS_JOB1 與其他股東親屬關係-稱謂
        '' </summary>
        Public Property OS_JOB1() As String
            Get
                Return Me.PropertyMap("OS_JOB1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OS_JOB1") = value
            End Set
        End Property
#End Region

#Region "OS_NAME2 與其他發起人親屬關係-發起人名稱"
        '' <summary>
        '' OS_NAME2 與其他發起人親屬關係-發起人名稱
        '' </summary>
        Public Property OS_NAME2() As String
            Get
                Return Me.PropertyMap("OS_NAME2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OS_NAME2") = value
            End Set
        End Property
#End Region

#Region "OS_JOB2 與其他發起人親屬關係-稱謂"
        '' <summary>
        '' OS_JOB2 與其他發起人親屬關係-稱謂
        '' </summary>
        Public Property OS_JOB2() As String
            Get
                Return Me.PropertyMap("OS_JOB2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OS_JOB2") = value
            End Set
        End Property
#End Region

#Region "SHARES_MEMO 捐助財產、金額"
        '' <summary>
        '' SHARES_MEMO 捐助財產、金額
        '' </summary>
        Public Property SHARES_MEMO() As String
            Get
                Return Me.PropertyMap("SHARES_MEMO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHARES_MEMO") = value
            End Set
        End Property
#End Region

#Region "OM_SHARES 其他媒體持股情形"
        '' <summary>
        '' OM_SHARES 其他媒體持股情形
        '' </summary>
        Public Property OM_SHARES() As String
            Get
                Return Me.PropertyMap("OM_SHARES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OM_SHARES") = value
            End Set
        End Property
#End Region

#Region "PUBLIC_FLAG 捐助章程是否規定由該捐助人單獨或共同選任董事"
        '' <summary>
        '' PUBLIC_FLAG 捐助章程是否規定由該捐助人單獨或共同選任董事
        '' </summary>
        Public Property PUBLIC_FLAG() As String
            Get
                Return Me.PropertyMap("PUBLIC_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PUBLIC_FLAG") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1030"
        ' <summary>Ent_APP1030</ summary>
        Private Property Ent_APP1030() As ENT_APP1030
            Get
                Return Me.PropertyMap("Ent_APP1030")
            End Get
            Set(ByVal value As ENT_APP1030)
                Me.PropertyMap("Ent_APP1030") = value
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
                Me.Ent_APP1030.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1030.GROUP_TYPE = Me.GROUP_TYPE        '名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人
                Me.Ent_APP1030.JOB_TITLE = Me.JOB_TITLE      '職稱
                Me.Ent_APP1030.USER_NAME = Me.USER_NAME      '姓名(法人名稱)
                Me.Ent_APP1030.USER_ID = Me.USER_ID      '身分證字號(護照號碼)(法人統一編號)
                Me.Ent_APP1030.BIRTHDAY_DATE = Me.BIRTHDAY_DATE      '出生年月日(設立日期)
                Me.Ent_APP1030.CITIZENSHIP = Me.CITIZENSHIP      '國籍
                Me.Ent_APP1030.SHARES_RATE = Me.SHARES_RATE      '持(認)股百分比
                Me.Ent_APP1030.SHARES_AMT = Me.SHARES_AMT        '持(認)股金額
                Me.Ent_APP1030.EXPERIENCE = Me.EXPERIENCE        '最高經歷
                Me.Ent_APP1030.EDUCATION = Me.EDUCATION      '最高學歷
                Me.Ent_APP1030.ADDR_CITY1 = Me.ADDR_CITY1        '戶籍地址(事業登記地址)_縣市別
                Me.Ent_APP1030.ADDR_CITY2 = Me.ADDR_CITY2        '戶籍地址(事業登記地址)_行政區
                Me.Ent_APP1030.ADDR = Me.ADDR        '戶籍地址(事業登記地址)
                Me.Ent_APP1030.TEL_CODE = Me.TEL_CODE        '電話_區碼
                Me.Ent_APP1030.TEL = Me.TEL      '電話
                Me.Ent_APP1030.REMARK = Me.REMARK        '備註
                Me.Ent_APP1030.SHARES_NUMBER = Me.SHARES_NUMBER      '持(認)股數
                Me.Ent_APP1030.LAUNCH_FLAG = Me.LAUNCH_FLAG      '是否為發起人
                Me.Ent_APP1030.CONTRIBUTION_AMT = Me.CONTRIBUTION_AMT        '出資額
                Me.Ent_APP1030.OB_NAME = Me.OB_NAME      '其他事業持認股/捐助情形-事業名稱
                Me.Ent_APP1030.OB_SHARES_RATE = Me.OB_SHARES_RATE        '其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例
                Me.Ent_APP1030.OB_NAME1 = Me.OB_NAME1        '其他事業擔任董監事情形-事業名稱
                Me.Ent_APP1030.OB_JOB1 = Me.OB_JOB1      '其他事業擔任董監事情形-擔任職務
                Me.Ent_APP1030.OS_NAME1 = Me.OS_NAME1        '與其他股東親屬關係-股東名稱
                Me.Ent_APP1030.OS_JOB1 = Me.OS_JOB1      '與其他股東親屬關係-稱謂
                Me.Ent_APP1030.OS_NAME2 = Me.OS_NAME2        '與其他發起人親屬關係-發起人名稱
                Me.Ent_APP1030.OS_JOB2 = Me.OS_JOB2      '與其他發起人親屬關係-稱謂
                Me.Ent_APP1030.SHARES_MEMO = Me.SHARES_MEMO      '捐助財產、金額
                Me.Ent_APP1030.OM_SHARES = Me.OM_SHARES      '其他媒體持股情形
                Me.Ent_APP1030.PUBLIC_FLAG = Me.PUBLIC_FLAG      '捐助章程是否規定由該捐助人單獨或共同選任董事


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1030.Insert()

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
                Me.Ent_APP1030.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1030.GROUP_TYPE = Me.GROUP_TYPE        '名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人
                Me.Ent_APP1030.JOB_TITLE = Me.JOB_TITLE      '職稱
                Me.Ent_APP1030.USER_NAME = Me.USER_NAME      '姓名(法人名稱)
                Me.Ent_APP1030.USER_ID = Me.USER_ID      '身分證字號(護照號碼)(法人統一編號)
                Me.Ent_APP1030.BIRTHDAY_DATE = Me.BIRTHDAY_DATE      '出生年月日(設立日期)
                Me.Ent_APP1030.CITIZENSHIP = Me.CITIZENSHIP      '國籍
                Me.Ent_APP1030.SHARES_RATE = Me.SHARES_RATE      '持(認)股百分比
                Me.Ent_APP1030.SHARES_AMT = Me.SHARES_AMT        '持(認)股金額
                Me.Ent_APP1030.EXPERIENCE = Me.EXPERIENCE        '最高經歷
                Me.Ent_APP1030.EDUCATION = Me.EDUCATION      '最高學歷
                Me.Ent_APP1030.ADDR_CITY1 = Me.ADDR_CITY1        '戶籍地址(事業登記地址)_縣市別
                Me.Ent_APP1030.ADDR_CITY2 = Me.ADDR_CITY2        '戶籍地址(事業登記地址)_行政區
                Me.Ent_APP1030.ADDR = Me.ADDR        '戶籍地址(事業登記地址)
                Me.Ent_APP1030.TEL_CODE = Me.TEL_CODE        '電話_區碼
                Me.Ent_APP1030.TEL = Me.TEL      '電話
                Me.Ent_APP1030.REMARK = Me.REMARK        '備註
                Me.Ent_APP1030.SHARES_NUMBER = Me.SHARES_NUMBER      '持(認)股數
                Me.Ent_APP1030.LAUNCH_FLAG = Me.LAUNCH_FLAG      '是否為發起人
                Me.Ent_APP1030.CONTRIBUTION_AMT = Me.CONTRIBUTION_AMT        '出資額
                Me.Ent_APP1030.OB_NAME = Me.OB_NAME      '其他事業持認股/捐助情形-事業名稱
                Me.Ent_APP1030.OB_SHARES_RATE = Me.OB_SHARES_RATE        '其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例
                Me.Ent_APP1030.OB_NAME1 = Me.OB_NAME1        '其他事業擔任董監事情形-事業名稱
                Me.Ent_APP1030.OB_JOB1 = Me.OB_JOB1      '其他事業擔任董監事情形-擔任職務
                Me.Ent_APP1030.OS_NAME1 = Me.OS_NAME1        '與其他股東親屬關係-股東名稱
                Me.Ent_APP1030.OS_JOB1 = Me.OS_JOB1      '與其他股東親屬關係-稱謂
                Me.Ent_APP1030.OS_NAME2 = Me.OS_NAME2        '與其他發起人親屬關係-發起人名稱
                Me.Ent_APP1030.OS_JOB2 = Me.OS_JOB2      '與其他發起人親屬關係-稱謂
                Me.Ent_APP1030.SHARES_MEMO = Me.SHARES_MEMO      '捐助財產、金額
                Me.Ent_APP1030.OM_SHARES = Me.OM_SHARES      '其他媒體持股情形
                Me.Ent_APP1030.PUBLIC_FLAG = Me.PUBLIC_FLAG      '捐助章程是否規定由該捐助人單獨或共同選任董事


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1030.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1030.Update()

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
                Me.Ent_APP1030.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1030.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1030.Delete()
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
                Me.ProcessQueryCondition(condition, "=", "GROUP_TYPE", Me.GROUP_TYPE)        '名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人
                Me.ProcessQueryCondition(condition, "=", "JOB_TITLE", Me.JOB_TITLE)      '職稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "USER_NAME", Me.USER_NAME)         '姓名(法人名稱)
                Me.ProcessQueryCondition(condition, "=", "USER_ID", Me.USER_ID)      '身分證字號(護照號碼)(法人統一編號)
                Me.ProcessQueryCondition(condition, "=", "BIRTHDAY_DATE", Me.BIRTHDAY_DATE)      '出生年月日(設立日期)
                Me.ProcessQueryCondition(condition, "=", "CITIZENSHIP", Me.CITIZENSHIP)      '國籍
                Me.ProcessQueryCondition(condition, "=", "SHARES_RATE", Me.SHARES_RATE)      '持(認)股百分比
                Me.ProcessQueryCondition(condition, "=", "SHARES_AMT", Me.SHARES_AMT)        '持(認)股金額
                Me.ProcessQueryCondition(condition, "=", "EXPERIENCE", Me.EXPERIENCE)        '最高經歷
                Me.ProcessQueryCondition(condition, "=", "EDUCATION", Me.EDUCATION)      '最高學歷
                Me.ProcessQueryCondition(condition, "=", "ADDR_CITY1", Me.ADDR_CITY1)        '戶籍地址(事業登記地址)_縣市別
                Me.ProcessQueryCondition(condition, "=", "ADDR_CITY2", Me.ADDR_CITY2)        '戶籍地址(事業登記地址)_行政區
                Me.ProcessQueryCondition(condition, "=", "ADDR", Me.ADDR)        '戶籍地址(事業登記地址)
                Me.ProcessQueryCondition(condition, "=", "TEL_CODE", Me.TEL_CODE)        '電話_區碼
                Me.ProcessQueryCondition(condition, "=", "TEL", Me.TEL)      '電話
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK)       '備註
                Me.ProcessQueryCondition(condition, "=", "SHARES_NUMBER", Me.SHARES_NUMBER)      '持(認)股數
                Me.ProcessQueryCondition(condition, "=", "LAUNCH_FLAG", Me.LAUNCH_FLAG)      '是否為發起人
                Me.ProcessQueryCondition(condition, "=", "CONTRIBUTION_AMT", Me.CONTRIBUTION_AMT)        '出資額
                Me.ProcessQueryCondition(condition, "%LIKE%", "OB_NAME", Me.OB_NAME)         '其他事業持認股/捐助情形-事業名稱
                Me.ProcessQueryCondition(condition, "=", "OB_SHARES_RATE", Me.OB_SHARES_RATE)        '其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例
                Me.ProcessQueryCondition(condition, "%LIKE%", "OB_NAME1", Me.OB_NAME1)       '其他事業擔任董監事情形-事業名稱
                Me.ProcessQueryCondition(condition, "=", "OB_JOB1", Me.OB_JOB1)      '其他事業擔任董監事情形-擔任職務
                Me.ProcessQueryCondition(condition, "%LIKE%", "OS_NAME1", Me.OS_NAME1)       '與其他股東親屬關係-股東名稱
                Me.ProcessQueryCondition(condition, "=", "OS_JOB1", Me.OS_JOB1)      '與其他股東親屬關係-稱謂
                Me.ProcessQueryCondition(condition, "%LIKE%", "OS_NAME2", Me.OS_NAME2)       '與其他發起人親屬關係-發起人名稱
                Me.ProcessQueryCondition(condition, "=", "OS_JOB2", Me.OS_JOB2)      '與其他發起人親屬關係-稱謂
                Me.ProcessQueryCondition(condition, "=", "SHARES_MEMO", Me.SHARES_MEMO)      '捐助財產、金額
                Me.ProcessQueryCondition(condition, "=", "OM_SHARES", Me.OM_SHARES)      '其他媒體持股情形
                Me.ProcessQueryCondition(condition, "=", "PUBLIC_FLAG", Me.PUBLIC_FLAG)      '捐助章程是否規定由該捐助人單獨或共同選任董事

                Me.Ent_APP1030.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1030.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1030.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1030.Query()
                Else
                    result = Me.Ent_APP1030.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1030.TotalRowCount
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

