'----------------------------------------------------------------------------------
'File Name		: APP1030
'Author			:  
'Description		: APP1030 董事/監察人/經理人/股東/發起人/認股人/捐助人
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/08	 		Source Create
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
    ' APP1030 董事/監察人/經理人/股東/發起人/認股人/捐助人
    ' </summary>
    Public Class ENT_APP1030
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
            Me.TableName = "APP1030"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,JOB_TITLE,USER_NAME,USER_ID,CITIZENSHIP,SHARES_RATE,EXPERIENCE,EDUCATION,ADDR,TEL_CODE,TEL,REMARK,LAUNCH_FLAG,OB_NAME,OB_SHARES_RATE,OB_NAME1,OB_JOB1,OS_NAME1,OS_JOB1,OS_NAME2,OS_JOB2,SHARES_MEMO,OM_SHARES,PUBLIC_FLAG"
            Me.SET_NULL_FIELD = "SHARES_AMT,SHARES_NUMBER,CONTRIBUTION_AMT,BIRTHDAY_DATE"
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

#Region "GROUP_TYPE 名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人"
        '' <summary>
        '' GROUP_TYPE 名冊類別，1：董事（電台：董監事），2：監察人，3：經理人，4：股東，5：發起人，6：認股人，7：捐助人
        '' </summary>
        Public Property GROUP_TYPE() As String
            Get
                Return Me.ColumnyMap("GROUP_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_TYPE") = value
            End Set
        End Property
#End Region

#Region "JOB_TITLE 職稱"
        '' <summary>
        '' JOB_TITLE 職稱
        '' </summary>
        Public Property JOB_TITLE() As String
            Get
                Return Me.ColumnyMap("JOB_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOB_TITLE") = value
            End Set
        End Property
#End Region

#Region "USER_NAME 姓名(法人名稱)"
        '' <summary>
        '' USER_NAME 姓名(法人名稱)
        '' </summary>
        Public Property USER_NAME() As String
            Get
                Return Me.ColumnyMap("USER_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USER_NAME") = value
            End Set
        End Property
#End Region

#Region "USER_ID 身分證字號(護照號碼)(法人統一編號)"
        '' <summary>
        '' USER_ID 身分證字號(護照號碼)(法人統一編號)
        '' </summary>
        Public Property USER_ID() As String
            Get
                Return Me.ColumnyMap("USER_ID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USER_ID") = value
            End Set
        End Property
#End Region

#Region "BIRTHDAY_DATE 出生年月日(設立日期)"
        '' <summary>
        '' BIRTHDAY_DATE 出生年月日(設立日期)
        '' </summary>
        Public Property BIRTHDAY_DATE() As String
            Get
                Return Me.ColumnyMap("BIRTHDAY_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BIRTHDAY_DATE") = value
            End Set
        End Property
#End Region

#Region "CITIZENSHIP 國籍"
        '' <summary>
        '' CITIZENSHIP 國籍
        '' </summary>
        Public Property CITIZENSHIP() As String
            Get
                Return Me.ColumnyMap("CITIZENSHIP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CITIZENSHIP") = value
            End Set
        End Property
#End Region

#Region "SHARES_RATE 持(認)股百分比"
        '' <summary>
        '' SHARES_RATE 持(認)股百分比
        '' </summary>
        Public Property SHARES_RATE() As String
            Get
                Return Me.ColumnyMap("SHARES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHARES_RATE") = value
            End Set
        End Property
#End Region

#Region "SHARES_AMT 持(認)股金額"
        '' <summary>
        '' SHARES_AMT 持(認)股金額
        '' </summary>
        Public Property SHARES_AMT() As String
            Get
                Return Me.ColumnyMap("SHARES_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHARES_AMT") = value
            End Set
        End Property
#End Region

#Region "EXPERIENCE 最高經歷"
        '' <summary>
        '' EXPERIENCE 最高經歷
        '' </summary>
        Public Property EXPERIENCE() As String
            Get
                Return Me.ColumnyMap("EXPERIENCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXPERIENCE") = value
            End Set
        End Property
#End Region

#Region "EDUCATION 最高學歷"
        '' <summary>
        '' EDUCATION 最高學歷
        '' </summary>
        Public Property EDUCATION() As String
            Get
                Return Me.ColumnyMap("EDUCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDUCATION") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY1 戶籍地址(事業登記地址)_縣市別"
        '' <summary>
        '' ADDR_CITY1 戶籍地址(事業登記地址)_縣市別
        '' </summary>
        Public Property ADDR_CITY1() As String
            Get
                Return Me.ColumnyMap("ADDR_CITY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR_CITY1") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY2 戶籍地址(事業登記地址)_行政區"
        '' <summary>
        '' ADDR_CITY2 戶籍地址(事業登記地址)_行政區
        '' </summary>
        Public Property ADDR_CITY2() As String
            Get
                Return Me.ColumnyMap("ADDR_CITY2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR_CITY2") = value
            End Set
        End Property
#End Region

#Region "ADDR 戶籍地址(事業登記地址)"
        '' <summary>
        '' ADDR 戶籍地址(事業登記地址)
        '' </summary>
        Public Property ADDR() As String
            Get
                Return Me.ColumnyMap("ADDR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR") = value
            End Set
        End Property
#End Region

#Region "TEL_CODE 電話_區碼"
        '' <summary>
        '' TEL_CODE 電話_區碼
        '' </summary>
        Public Property TEL_CODE() As String
            Get
                Return Me.ColumnyMap("TEL_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TEL_CODE") = value
            End Set
        End Property
#End Region

#Region "TEL 電話"
        '' <summary>
        '' TEL 電話
        '' </summary>
        Public Property TEL() As String
            Get
                Return Me.ColumnyMap("TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TEL") = value
            End Set
        End Property
#End Region

#Region "REMARK 備註"
        '' <summary>
        '' REMARK 備註
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.ColumnyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "SHARES_NUMBER 持(認)股數"
        '' <summary>
        '' SHARES_NUMBER 持(認)股數
        '' </summary>
        Public Property SHARES_NUMBER() As String
            Get
                Return Me.ColumnyMap("SHARES_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHARES_NUMBER") = value
            End Set
        End Property
#End Region

#Region "LAUNCH_FLAG 是否為發起人"
        '' <summary>
        '' LAUNCH_FLAG 是否為發起人
        '' </summary>
        Public Property LAUNCH_FLAG() As String
            Get
                Return Me.ColumnyMap("LAUNCH_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LAUNCH_FLAG") = value
            End Set
        End Property
#End Region

#Region "CONTRIBUTION_AMT 出資額"
        '' <summary>
        '' CONTRIBUTION_AMT 出資額
        '' </summary>
        Public Property CONTRIBUTION_AMT() As String
            Get
                Return Me.ColumnyMap("CONTRIBUTION_AMT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTRIBUTION_AMT") = value
            End Set
        End Property
#End Region

#Region "OB_NAME 其他事業持認股/捐助情形-事業名稱"
        '' <summary>
        '' OB_NAME 其他事業持認股/捐助情形-事業名稱
        '' </summary>
        Public Property OB_NAME() As String
            Get
                Return Me.ColumnyMap("OB_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OB_NAME") = value
            End Set
        End Property
#End Region

#Region "OB_SHARES_RATE 其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例"
        '' <summary>
        '' OB_SHARES_RATE 其他事業持認股情形-占具表決權股份比例/其他事業捐助情形-捐助比例
        '' </summary>
        Public Property OB_SHARES_RATE() As String
            Get
                Return Me.ColumnyMap("OB_SHARES_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OB_SHARES_RATE") = value
            End Set
        End Property
#End Region

#Region "OB_NAME1 其他事業擔任董監事情形-事業名稱"
        '' <summary>
        '' OB_NAME1 其他事業擔任董監事情形-事業名稱
        '' </summary>
        Public Property OB_NAME1() As String
            Get
                Return Me.ColumnyMap("OB_NAME1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OB_NAME1") = value
            End Set
        End Property
#End Region

#Region "OB_JOB1 其他事業擔任董監事情形-擔任職務"
        '' <summary>
        '' OB_JOB1 其他事業擔任董監事情形-擔任職務
        '' </summary>
        Public Property OB_JOB1() As String
            Get
                Return Me.ColumnyMap("OB_JOB1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OB_JOB1") = value
            End Set
        End Property
#End Region

#Region "OS_NAME1 與其他股東親屬關係-股東名稱"
        '' <summary>
        '' OS_NAME1 與其他股東親屬關係-股東名稱
        '' </summary>
        Public Property OS_NAME1() As String
            Get
                Return Me.ColumnyMap("OS_NAME1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OS_NAME1") = value
            End Set
        End Property
#End Region

#Region "OS_JOB1 與其他股東親屬關係-稱謂"
        '' <summary>
        '' OS_JOB1 與其他股東親屬關係-稱謂
        '' </summary>
        Public Property OS_JOB1() As String
            Get
                Return Me.ColumnyMap("OS_JOB1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OS_JOB1") = value
            End Set
        End Property
#End Region

#Region "OS_NAME2 與其他發起人親屬關係-發起人名稱"
        '' <summary>
        '' OS_NAME2 與其他發起人親屬關係-發起人名稱
        '' </summary>
        Public Property OS_NAME2() As String
            Get
                Return Me.ColumnyMap("OS_NAME2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OS_NAME2") = value
            End Set
        End Property
#End Region

#Region "OS_JOB2 與其他發起人親屬關係-稱謂"
        '' <summary>
        '' OS_JOB2 與其他發起人親屬關係-稱謂
        '' </summary>
        Public Property OS_JOB2() As String
            Get
                Return Me.ColumnyMap("OS_JOB2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OS_JOB2") = value
            End Set
        End Property
#End Region

#Region "SHARES_MEMO 捐助財產、金額"
        '' <summary>
        '' SHARES_MEMO 捐助財產、金額
        '' </summary>
        Public Property SHARES_MEMO() As String
            Get
                Return Me.ColumnyMap("SHARES_MEMO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHARES_MEMO") = value
            End Set
        End Property
#End Region

#Region "OM_SHARES 其他媒體持股情形"
        '' <summary>
        '' OM_SHARES 其他媒體持股情形
        '' </summary>
        Public Property OM_SHARES() As String
            Get
                Return Me.ColumnyMap("OM_SHARES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OM_SHARES") = value
            End Set
        End Property
#End Region

#Region "PUBLIC_FLAG 捐助章程是否規定由該捐助人單獨或共同選任董事"
        '' <summary>
        '' PUBLIC_FLAG 捐助章程是否規定由該捐助人單獨或共同選任董事
        '' </summary>
        Public Property PUBLIC_FLAG() As String
            Get
                Return Me.ColumnyMap("PUBLIC_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PUBLIC_FLAG") = value
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

