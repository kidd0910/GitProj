'----------------------------------------------------------------------------------
'File Name		: APPL020
'Author			:  
'Description		: APPL020  
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/20	 		Source Create
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
    ' APPL020  
    ' </summary>
    Public Class ENT_APPL020
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
            Me.TableName = "APPL020"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,RESULT1_DESC,RESULT2_DESC,RESULT3_DESC,CREATE_USER,UPDATE_USER"
            Me.SET_NULL_FIELD = "CREATE_DATE,UPDATE_DATE,RESULT1_DATE,RESULT2_DATE,RESULT3_DATE"
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '  新增時給號,案件編號編碼格式：WWWWYYYNNNNNR,
        '  WWWW：4碼，表示業務代號, 
        '  AA01：申設-直播衛星, 
        '　AA02：申設-境外直播衛星, 
        '　AA03：申設-節目供應事業-一般頻道, 
        '　AA04：申設-節目供應事業-購物頻道, 
        '　AA05：申設-境外節目供應事業-一般頻道, 
        '　AA06：申設-境外節目供應事業-購物頻道, 
        '　AB01：申設-無線電視, 
        '　AC01：申設-區域性廣播事業, 
        '　AC02：申設-社區性廣播事業, 
        '　AC03：申設-公營電臺或財團法人, 
        '　BA01：評鑑-直播衛星, 
        '　BA02：評鑑-境外直播衛星, 
        '　BA03：評鑑-節目供應事業-一般頻道, 
        '　BA04：評鑑-節目供應事業-購物頻道, 
        '　BA05：評鑑-境外節目供應事業-一般頻道, 
        '　BA06：評鑑-境外節目供應事業-購物頻道, 
        '　BB01：評鑑-無線電視, 
        '　BC01：評鑑-區域性廣播事業, 
        '　BC02：評鑑-社區性廣播事業, 
        '　BC03：評鑑-公營電臺或財團法人, 
        '　CA01：換照-直播衛星, 
        '　CA02：換照-境外直播衛星, 
        '　CA03：換照-節目供應事業-一般頻道, 
        '　CA04：換照-節目供應事業-購物頻道, 
        '　CA05：換照-境外節目供應事業-一般頻道, 
        '　CA06：換照-境外節目供應事業-購物頻道, 
        '　CB01：換照-無線電視, 
        '　CC01：換照-區域性廣播事業, 
        '　CC02：換照-社區性廣播事業, 
        '　CC03：換照-公營電臺或財團法人, 
        'YYY：3碼，取民國年3碼, 
        'NNNNN：5碼序號，由00001開始，每取號1次加1，每年重置, 
        'R：1碼檢核碼，規則如下：
        'YY(後2碼)/(序號第4碼＋序號第5碼+1)，計算結果取整數的個位數。
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

#Region "CASE_SEQ 補正次數"
        '原案（無補正）為0，補正第1次為1，依此類推"
        '' <summary>
        '' CASE_SEQ 補正次數
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.ColumnyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region

#Region "COM_PKNO 業者PKNO"
        'REF. APPL010.PKNO, 
        '用來紀錄是哪家業者的案件，不使用統編做關聯是考量有業者為籌設中無統編，以及業者統編可能會變更。
        '' <summary>
        '' COM_PKNO 業者PKNO
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.ColumnyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE 業務代號"
        '案件編號前4碼, 
        'REF. SYST010.SYS_KEY=CASE_CODE
        '' <summary>
        '' CASE_CODE 業務代號
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.ColumnyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "DEL_FLAG 刪除註記"
        '0：正常, 
        '1：已刪除"
        '' <summary>
        '' DEL_FLAG 刪除註記
        '' </summary>
        Public Property DEL_FLAG() As String
            Get
                Return Me.ColumnyMap("DEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CASE_STATUS 案件進度"
        'REF. SYST010, SYS_KEY=CASE_STATUS"
        '' <summary>
        '' CASE_STATUS 案件進度
        '' </summary>
        Public Property CASE_STATUS() As String
            Get
                Return Me.ColumnyMap("CASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "RESULT1 初審審查結果"
        'REF. SYST010
        '' <summary>
        '' RESULT1 初審審查結果
        '' </summary>
        Public Property RESULT1() As String
            Get
                Return Me.ColumnyMap("RESULT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DATE 初審審查完成日期"
        '' <summary>
        '' RESULT1_DATE 初審審查完成日期
        '' </summary>
        Public Property RESULT1_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT1_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DESC 初審意見"
        '' <summary>
        '' RESULT1_DESC 初審意見
        '' </summary>
        Public Property RESULT1_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT2 諮詢委員會議審查結果"
        'REF.SYST010
        '' <summary>
        '' RESULT2 諮詢委員會議審查結果 
        '' </summary>
        Public Property RESULT2() As String
            Get
                Return Me.ColumnyMap("RESULT2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DATE 諮詢委員會議審查完成日期"
        '' <summary>
        '' RESULT2_DATE 諮詢委員會議審查完成日期
        '' </summary>
        Public Property RESULT2_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT2_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DESC 諮詢委員會議審查意見"
        '' <summary>
        '' RESULT2_DESC 諮詢委員會議審查意見
        '' </summary>
        Public Property RESULT2_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT3 本會委員會議審查結果"
        'REF. SYST010
        '' <summary>
        '' RESULT3 本會委員會議審查結果 
        '' </summary>
        Public Property RESULT3() As String
            Get
                Return Me.ColumnyMap("RESULT3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DATE 本會委員會議審查完成日期"
        '' <summary>
        '' RESULT3_DATE 本會委員會議審查完成日期
        '' </summary>
        Public Property RESULT3_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT3_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DESC 本會委員會議審查意見"
        '' <summary>
        '' RESULT3_DESC 本會委員會議審查意見
        '' </summary>
        Public Property RESULT3_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3_DESC") = value
            End Set
        End Property
#End Region

#Region "CREATE_USER 資料建立者"
        '' <summary>
        '' CREATE_USER 資料建立者
        '' </summary>
        Public Property CREATE_USER() As String
            Get
                Return Me.ColumnyMap("CREATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_USER") = value
            End Set
        End Property
#End Region

#Region "CREATE_DATE 資料建立日期"
        '' <summary>
        '' CREATE_DATE 資料建立日期
        '' </summary>
        Public Property CREATE_DATE() As String
            Get
                Return Me.ColumnyMap("CREATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_DATE") = value
            End Set
        End Property
#End Region

#Region "UPDATE_USER 資料維護者"
        '' <summary>
        '' UPDATE_USER 資料維護者
        '' </summary>
        Public Property UPDATE_USER() As String
            Get
                Return Me.ColumnyMap("UPDATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_USER") = value
            End Set
        End Property
#End Region

#Region "UPDATE_DATE 資料維護日期"
        '' <summary>
        '' UPDATE_DATE 資料維護日期
        '' </summary>
        Public Property UPDATE_DATE() As String
            Get
                Return Me.ColumnyMap("UPDATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_DATE") = value
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

#Region "CHANG_LICENSE_DATE 換照日期"
        '' <summary>
        '' CHANG_LICENSE_DATE 換照日期
        '' </summary>
        Public Property CHANG_LICENSE_DATE() As String
            Get
                Return Me.ColumnyMap("CHANG_LICENSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANG_LICENSE_DATE") = value
            End Set
        End Property
#End Region

#Region "OTHER_UNIT_DESC 會辦意見"
        '' <summary>
        '' OTHER_UNIT_DESC 會辦意見
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.ColumnyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region

#Region "APV_DATE 初次送審NCC時間"
        '' <summary>
        '' APV_DATE 初次送審NCC時間
        '' </summary>
        Public Property APV_DATE() As String
            Get
                Return Me.ColumnyMap("APV_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APV_DATE") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   新增方法
        ''' </remarks>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                'If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM) AS 'APP_PERSON_NM'  ")
                'Else
                '    sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                'End If
                sql.AppendLine(" , (ROW_NUMBER() OVER (ORDER BY M.PKNO) ) AS ROW_NUM ")
                sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine("  , CASE ")
                sql.AppendLine(" 		WHEN M.CASE_CODE IN ('AA03', 'AA04', 'AA05', 'AA06', 'CA03', 'CA04', 'CA05', 'CA06') THEN  ")
                sql.AppendLine(" 			(SELECT APP1010.SYS_CNAME FROM APP1010 WHERE M.CASE_NO = APP1010.CASE_NO) ")
                sql.AppendLine(" 		WHEN M.CASE_CODE IN ('BA03', 'BA04', 'BA05', 'BA06')  THEN ")
                sql.AppendLine(" 			(SELECT APP1170.CHANNEL_NAME FROM APP1170 WHERE M.CASE_NO = APP1170.CASE_NO) ")
                sql.AppendLine(" 		ELSE '' ")
                sql.AppendLine("    END AS THIS_CASE_CHANNEL_NAME ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' Web Service Query
        ''' </summary>
        ''' <returns></returns>
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
                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                'sql.AppendLine(" , HIS010.CREATE_TIME AS HIS010_CREATE_TIME")
                sql.AppendLine(" , ( select   ")
                sql.AppendLine("        CREATE_TIME as HIS_CREATE_TIME ")
                sql.AppendLine("     from HIS010")
                sql.AppendLine("     where CASE_NO = '" + Me.CASE_NO + "' ")
                sql.AppendLine("     and CASE_STATUS = '10' ")
                sql.AppendLine("     and TBL_RECID = (select min(TBL_RECID) from HIS010 where CASE_NO = '" + Me.CASE_NO + "')")
                sql.AppendLine("    ) AS HIS010_CREATE_TIME ")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM)   ")
                Else
                    sql.AppendLine(" , A.APP_PERSON_NM ")
                End If
                'sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                'sql.AppendLine(" LEFT JOIN HIS010 ON M.CASE_NO = HIS010.CASE_NO AND HIS010.TBL_RECID = (SELECT MIN(TBL_RECID) FROM HIS010 WHERE CASE_NO = '" + Me.CASE_NO + "' GROUP BY CASE_NO ) ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function


        Public Function QueryCaseList() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                '若欄位內容為已加密，則執行SQL時可能會因為特殊符號導致不明錯誤，需串解密Function
                Dim sql As New StringBuilder
                'sql.AppendLine(" SELECT M.*, dbo.TripleDesDecrypt(A.APP_PERSON_NM), B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" SELECT M.* ")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM) ")
                Else
                    sql.AppendLine(" , A.APP_PERSON_NM ")
                End If
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" , ( select   ")
                sql.AppendLine("        CREATE_TIME as HIS_CREATE_TIME ")
                sql.AppendLine("     from HIS010")
                sql.AppendLine("     where CASE_NO = '" + Me.CASE_NO + "' ")
                sql.AppendLine("     and CASE_STATUS = '10' ")
                sql.AppendLine("     and TBL_RECID = (select min(TBL_RECID) from HIS010 where CASE_NO = '" + Me.CASE_NO + "')")
                sql.AppendLine("    ) AS HIS010_CREATE_TIME ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                sql.AppendLine(" ORDER BY M.CASE_NO ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "取回案件資訊"
        Public Function QueryByCaseNo(Optional ByVal CaseNo As String = "") As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT R1.SYS_NAME, R1.SYS_ID, M.CASE_NO, M.CASE_STATUS, R2.SYS_NAME AS 'CASE_STATUS_NM', R3.APP_PERSON_NM, M.CASE_SEQ, R4.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine("    , M.APV_DATE ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON R1.SYS_ID = M.CASE_CODE ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 ON (R2.SYS_ID = M.CASE_STATUS AND R2.SYS_KEY = 'CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 R4 ON (R4.SYS_ID = R2.SYS_RSV2 AND R4.SYS_KEY='CASE_STATUS2') ")
                sql.AppendLine(" LEFT JOIN APP1010 R3 ON R3.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" WHERE M.CASE_NO ='" & CaseNo & "'")
                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "用案號查詢機構類型 QueryOrgTypeByCaseNo"
        ''' <summary>
        ''' 用案號查詢機構類型
        ''' </summary>
        Public Function QueryOrgTypeByCaseNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.ORG_TYPE ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#End Region


#Region "查出公司相關資料BY CASE_NO"
        ''' <summary>
        ''' 查出公司相關資料BY CASE_NO
        ''' type = APP120324:串頻道名稱
        ''' type = APP120705:純查統編
        ''' </summary>
        Public Function GetCompanyDataByCASE_NO(ByVal type As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder

                Select Case type.ToUpper
                    Case "APP120324"
                        sql.AppendLine(" select A010.BUS_NO, A1170.CHANNEL_NAME, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                        sql.AppendLine(" inner join APP1170 A1170 on A020.CASE_NO = A1170.CASE_NO ")
                    Case "CA03", "CA04", "CA05", "CA06"
                        sql.AppendLine(" select A010.BUS_NO, A1010.SYS_CNAME, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                        sql.AppendLine(" inner join APP1010 A1010 on A020.CASE_NO = A1010.CASE_NO  ")
                    Case Else
                        sql.AppendLine(" select A010.BUS_NO, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                End Select

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "串公文介接案號的主旨"
        ''' <summary>
        ''' 串公文介接案號的主旨
        ''' </summary>
        Public Function GetSYSID() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select top 1 S010.SYS_ID ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 串公文介接案號的主旨 Type01
        ''' </summary>
        Public Function GetSubject_Type01() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME, A1010.SYS_CNAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")
                sql.AppendLine(" join APP1010 A1010 on A1010.CASE_NO = A020.CASE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 串公文介接案號的主旨 Type02
        ''' </summary>
        Public Function GetSubject_Type02() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME, A1170.CHANNEL_NAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")
                sql.AppendLine(" join APP1170 A1170 on A020.CASE_NO = A1170.CASE_NO  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 串公文介接案號的主旨 Type03
        ''' </summary>
        Public Function GetSubject_Type03() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

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

