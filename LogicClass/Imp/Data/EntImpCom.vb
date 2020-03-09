'----------------------------------------------------------------------------------
'File Name		: EntImpCom
'Author			: nono
'Description		: EntImpCom 匯入共用檔ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.3		2009/05/22	Ethan		匯入的處理註記若為”成功”，則ENRT350.MK應該inster為”0”
'0.0.3		2008/01/12	nono		處理欄位當ＤＤ設定為數字前補零則自動補 0
'0.0.2		2008/11/14	nono		增加傳入固定欄位及參數, 可多筆
'0.0.1		2008/09/05	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports System.IO
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports Acer.Form
Imports Acer.Form.DataDictionaryUtil
Imports Acer.Base
Imports Acer.File
Imports Bat.Data
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions

Namespace Imp.Data
    '' <summary>
    '' EntImpCom 匯入共用檔ENT
    '' </summary>
    Public Class EntImpCom
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = ""
            Me.SysName = "IMP"
            Me.ConnName = "TSBA"

            Me.ERROR_RESULT = New StringBuilder()

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ERROR_RESULT[] 錯誤結果[]"
        ''' <summary>
        ''' ERROR_RESULT[] 錯誤結果[]
        ''' </summary>
        Public Property ERROR_RESULT() As StringBuilder
            Get
                Return Me.PropertyMap("ERROR_RESULT")
            End Get
            Set(ByVal value As StringBuilder)
                Me.PropertyMap("ERROR_RESULT") = value
            End Set
        End Property
#End Region

#Region "USE_ID 使用者帳號"
        ''' <summary>
        ''' USE_ID 使用者帳號
        ''' </summary>
        Public Property USE_ID() As String
            Get
                Return Me.PropertyMap("USE_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_ID") = value
            End Set
        End Property
#End Region

#Region "IMP_FILE 匯入檔案"
        ''' <summary>
        ''' IMP_FILE 匯入檔案
        ''' </summary>
        Public Property IMP_FILE() As IO.FileInfo
            Get
                Return Me.PropertyMap("IMP_FILE")
            End Get
            Set(ByVal value As IO.FileInfo)
                Me.PropertyMap("IMP_FILE") = value
            End Set
        End Property
#End Region

#Region "IMP_OPERATE_PROG 匯入作業程式代號"
        ''' <summary>
        ''' IMP_OPERATE_PROG 匯入作業程式代號
        ''' </summary>
        Public Property IMP_OPERATE_PROG() As String
            Get
                Return Me.ColumnyMap("IMP_OPERATE_PROG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IMP_OPERATE_PROG") = value
            End Set
        End Property
#End Region

#Region "STATIC_COLUMN_DATA 固定欄位資訊"
        ''' <summary>
        ''' STATIC_COLUMN_DATA 固定欄位資訊
        ''' </summary>
        Public Property STATIC_COLUMN_DATA() As String
            Get
                Return Me.PropertyMap("STATIC_COLUMN_DATA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("STATIC_COLUMN_DATA") = value
            End Set
        End Property
#End Region

#Region "VALID_COLUMN_DATA 檢核欄位資訊"
        ''' <summary>
        ''' VALID_COLUMN_DATA 檢核欄位資訊
        ''' </summary>
        Public Property VALID_COLUMN_DATA() As String
            Get
                Return Me.PropertyMap("VALID_COLUMN_DATA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VALID_COLUMN_DATA") = value
            End Set
        End Property
#End Region

#Region "TRADE_FAILURE_ISROLLBACK  交易失敗是否rollback "
        ''' <summary>
        '''TRADE_FAILURE_ISROLLBACK  交易失敗是否rollback 
        ''' </summary>
        Public Property TRADE_FAILURE_ISROLLBACK() As String
            Get
                Return Me.PropertyMap("TRADE_FAILURE_ISROLLBACK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TRADE_FAILURE_ISROLLBACK") = value
            End Set
        End Property
#End Region

#Region "SUCESS_COUNT 成功筆數"
        ''' <summary>
        ''' SUCESS_COUNT 成功筆數"
        ''' </summary>
        Public Property SUCESS_COUNT() As Integer
            Get
                Return Me.PropertyMap("SUCESS_COUNT")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("SUCESS_COUNT") = value
            End Set
        End Property
#End Region

#Region "FAILE_COUNT 失敗筆數"
        ''' <summary>
        ''' FAILE_COUNT 失敗筆數"
        ''' </summary>
        Public Property FAILE_COUNT() As Integer
            Get
                Return Me.PropertyMap("FAILE_COUNT")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("FAILE_COUNT") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"

#Region "GetTableSample 取得檔案格式範本 "
        ''' <summary>
        ''' 取得檔案格式範本 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 新增方法
        ''' </remarks>
        Public Function GetTableSample() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                Me.SkipProperty = True

                '請NoNo自由發揮,謝謝
                Dim ent As EntTable = New EntTable(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = "IMP_OPERATE_PROG = '" & Me.IMP_OPERATE_PROG & "'"
                Dim dt As DataTable = ent.Query()

                If dt.Rows.Count = 0 Then
                    Throw New Exception("必須設定匯入檔 IMPC010 資料, 程式代號:" & Me.IMP_OPERATE_PROG)
                End If

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "ImpData 匯入資料 "
        ''' <summary>
        ''' 匯入資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/04/16 新增方法
        ''' </remarks>
        Public Sub ImpData()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 取得檔案格式等設定資料 ===
                Dim dt As DataTable = Me.GetTableSample()
                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)

                '=== 回塞 '交易失敗是否 rollback' 屬性 ===
                Me.TRADE_FAILURE_ISROLLBACK = dt.Rows(0)("TRADE_FAILURE_ISROLLBACK").ToString()
                Dim cHeader As String() = dt.Rows(0)("CH_HEADED").ToString().Split(",")

                '=== 檢查表頭是否一致 ===
                'If Me.IMP_FILE.Extension.ToUpper() = ".CSV" Then
                '    Dim line As String() = System.IO.File.ReadAllLines(Me.IMP_FILE.FullName, System.Text.Encoding.GetEncoding("big5"))
                '    If line(0).Trim <> dt.Rows(0)("CH_HEADED").ToString().Trim() Then
                '        Me.ERROR_RESULT.Append("欄位資料不符, 請檢查!!<br>")
                '        Exit Sub
                '    End If
                'End If

                '=== 存放中文表頭資料 ===
                Dim headerMap As Hashtable = New Hashtable()
                Dim header As String() = dt.Rows(0)("INS_ENG_FIELD").ToString().Split(",")
                '=== 設定中文表頭資訊 ===
                For idx As Integer = 0 To cHeader.Length - 1
                    headerMap(header(idx).Trim()) = cHeader(idx).Trim()
                Next

                If dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2142_02" Then
                    'BIOleDbData(dt, headerMap)
                Else
                    ImpOleDbData(dt, headerMap)
                End If


            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ImpOleDbData 匯入資料 "
        ''' <summary>
        ''' 匯入資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.2 nono 2009/03/18 增加回傳成功及失敗筆數
        ''' 0.0.1 nono 新增方法
        ''' </remarks>
        Public Sub ImpOleDbData(ByVal dt As DataTable, ByVal headerMap As Hashtable)
            Dim file As IO.StreamReader = Nothing

            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                '先取得DT=EntTable_下載格式Ent
                '
                'open FILE_NAME(檔案名稱)
                '第一行為DD的中文名稱
                'if DT.CHECK_ITEM_NAME(檢核項目名稱) 不等於 null
                '
                'AEntCheck_檢核Ent=NEW EntCheck_檢核Ent
                '
                '逐筆檢核匯入檔案的資料
                '傳入AEntCheck_檢核Ent.ChkItem_檢核項目(INS_ENG_FIELD(新增用英文欄項))

                '=== 取得檔案格式等設定資料 ===
                Dim ColumnDDMap As Hashtable = MultiProcess.GetCrossSiteValue("COLUMNDD")

                Dim dataDt As DataTable

                '=== nono add 2009/03/10 ODBC 匯入使用 ===
                If dt.Rows(0)("CHECK_ITEM_NAME").ToString().IndexOf("ODBC") <> -1 Then
                    If Not file Is Nothing Then
                        file.Close()
                        file.Dispose()
                    End If

                    ImpODBCData(dt, headerMap)
                    Exit Sub
                End If

                If Me.IMP_FILE.Extension.ToUpper() = ".CSV" Or Me.IMP_FILE.Extension.ToUpper() = ".TXT" Then
                    dataDt = Me.GetCsvDataTable(headerMap)
                Else
                    dataDt = Me.GetExcelDataTable(headerMap)
                End If
                '=== 取得檔案內容 ===
                Dim cHeader As String() = dt.Rows(0)("CH_HEADED").ToString().Split(",")
                Dim header As String() = dt.Rows(0)("INS_ENG_FIELD").ToString().Split(",")
                Dim line As StringBuilder = New StringBuilder()
                '===	存放中文表頭資料	===
                Dim delRow As String()
                '===	存放每列資料	===
                Dim rowMap As Hashtable = New Hashtable()

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim dbaIns As DBAccess = Me.DBManager.GetDBAccess(conn)
                Dim dbaDel As DBAccess = Me.DBManager.GetDBAccess(conn)
                Dim cond As StringBuilder = New StringBuilder()
                Dim processCount As Integer

                '=== 回塞 '交易失敗是否 rollback' 屬性 ===
                Me.TRADE_FAILURE_ISROLLBACK = dt.Rows(0)("TRADE_FAILURE_ISROLLBACK").ToString()

                Me.SUCESS_COUNT = 0
                Me.FAILE_COUNT = 0
                For i As Integer = 0 To dataDt.Rows.Count - 1
                    '=== 當第一筆資料為空白行不處理 ===
                    If dataDt.Rows(i)(0).ToString() = "" Then
                        Continue For
                    End If

                    Dim str As String = ""
                    For rIdx As Integer = 0 To dataDt.Columns.Count - 1
                        If rIdx <> 0 Then
                            str += ","
                        End If

                        str += dataDt.Rows(i)(rIdx).ToString()
                    Next

                    line = New StringBuilder
                    If Not String.IsNullOrEmpty(str) Then
                        If line.Length > 0 Then
                            line.Append("<br>")
                        End If

                        line.Append(str)
                    End If

                    For Each ch As String In cHeader
                        If Not dataDt.Columns.Contains(ch) Then
                            Me.ERROR_RESULT.Append(String.Format("找不到必要的欄位名稱：{0}。<br>", ch))
                            Exit For
                        End If
                    Next

                    '=== 記數處理筆數 ===
                    processCount = processCount + 1

                    '=== 設定表格 ===
                    dbaIns.SetTableName(dt.Rows(0)("IMP_TABLE_NAME"))

                    '=== 處理欄位 ===
                    Dim tmpStruct As ColumnDD = Nothing
                    Dim tmpRowData As String = ""
                    '=== TNA2142_02 使用 ===
                    Dim tmpHaveTaxAmt As Int32 = 0
                    Dim tmpIsNoTax As String = ""
                    For idx As Integer = 0 To header.Length - 1

                        '=== 判斷當為後面字串且為空時處理 ===
                        Try
                            tmpRowData = Utility.DBStr(dataDt.Rows(i)(idx).ToString().Trim()).Trim()

                            '2010/10/14 add snippet by nono. in case of inserting data in chinese format.
                            If dataDt.Columns(idx).DataType.Name = "DateTime" Then
                                If Not String.IsNullOrEmpty(tmpRowData) Then
                                    tmpRowData = Convert.ToDateTime(tmpRowData).ToString("yyyy/MM/dd HH:mm:ss")
                                End If
                            End If
                            '===============================
                        Catch Ex As IndexOutOfRangeException
                            tmpRowData = ""
                        End Try

                        rowMap(header(idx).Trim()) = tmpRowData
                        '=== 為 OMIT 表示不處理 ===
                        If Not header(idx).Trim().StartsWith("OMIT") Then
                            '=== 處理 DD 必須補 0 的欄位 ===

                            If ColumnDDMap.ContainsKey(header(idx).Trim()) Then
                                tmpStruct = ColumnDDMap(header(idx).Trim())
                                '=== 數字前補 0  ===
                                If tmpStruct.UIType = "Z" Then
                                    tmpRowData = tmpRowData.PadLeft(Convert.ToInt32(tmpStruct.Length), "0")
                                End If
                            End If

                            '加密欄位
                            'IDNO,RESIDENCE_NO,PASSPORT_NO,FATHER_IDNO,MOTHER_IDNO,GUARDIAN_IDNO,SPOUSE_IDNO
                            'Select Case header(idx).Trim()
                            '	Case "IDNO", "RESIDENCE_NO", "PASSPORT_NO", "FATHER_IDNO", "MOTHER_IDNO", "GUARDIAN_IDNO", "SPOUSE_IDNO"
                            '		If Not String.IsNullOrEmpty(tmpRowData) Then
                            '                                 tmpRowData = TripleDesEncrypt(tmpRowData)
                            '		End If
                            'End Select

                            '特殊處理欄位
                            If dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2142_02" Then
                                '賣出日期
                                If header(idx).Trim() = "SELL_DATE" Then
                                    If tmpRowData <> "" Then
                                        tmpRowData = Convert.ToInt16(tmpRowData.ToString.Substring(0, 3)) + 1911 & tmpRowData.Substring(3, 6)
                                    End If
                                End If
                                If header(idx).Trim() = "HAVE_TAX_AMT" Then
                                    If tmpRowData <> "" AndAlso IsNumeric(tmpRowData) Then
                                        tmpHaveTaxAmt = Convert.ToInt32(tmpRowData)
                                    End If
                                End If
                                If header(idx).Trim() = "IS_NO_TAX" Then
                                    If tmpRowData <> "" Then
                                        tmpIsNoTax = tmpRowData
                                    End If
                                End If
                            End If

                            '正常欄位
                            dbaIns.SetColumn(header(idx).Trim(), tmpRowData)

                        End If
                    Next

                    'TNA2142_02要額外計算未稅金額
                    If dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2142_02" Then
                        If tmpIsNoTax = "Y" Then
                            dbaIns.SetColumn("UNIT_PRICE", Math.Round(tmpHaveTaxAmt / 1.05, 0, MidpointRounding.AwayFromZero))
                            dbaIns.SetColumn("NO_TAX_AMT", tmpHaveTaxAmt)
                        Else
                            dbaIns.SetColumn("UNIT_PRICE", tmpHaveTaxAmt)
                            dbaIns.SetColumn("NO_TAX_AMT", Math.Round(tmpHaveTaxAmt / 1.05, 0, MidpointRounding.AwayFromZero))
                        End If
                    End If

                    '=== 處理自訂欄位值 ===
                    If Not String.IsNullOrEmpty(Me.STATIC_COLUMN_DATA) Then
                        If Me.STATIC_COLUMN_DATA.IndexOf("|") <> -1 Then
                            Dim dataAry() As String = Me.STATIC_COLUMN_DATA.Split("|")
                            For i1 As Integer = 0 To dataAry.Length - 1 Step 2
                                dbaIns.SetColumn(dataAry(i1), Utility.DBStr(dataAry(i1 + 1)))
                            Next
                        End If
                    End If

                    Dim updateCount As Integer = 0

                    '=== 處理檢核 ===
                    If Not IsDBNull(dt.Rows(0)("CHECK_ITEM_NAME")) Then
                        If Not Me.CheckRowData(rowMap, dt.Rows(0)("CHECK_ITEM_NAME"), line.ToString(), i + 1) Then
                            Me.FAILE_COUNT = Me.FAILE_COUNT + 1
                            Continue For
                        End If
                    End If

                    Try
                        '=== 先更新資料 ===
                        If Not IsDBNull(dt.Rows(0)("DEL_ENG_FIELD")) Then
                            delRow = dt.Rows(0)("DEL_ENG_FIELD").ToString().Split(",")

                            cond.Length = 0
                            cond.Append("1=1")
                            For dIdx As Integer = 0 To delRow.Length - 1

                                'TNA2141_01要額外計算未稅金額
                                If dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2141_02" And delRow(dIdx) = "MA_PKNO" Then
                                    If Not String.IsNullOrEmpty(Me.STATIC_COLUMN_DATA) Then
                                        tmpRowData = Me.STATIC_COLUMN_DATA.Split("|")(1)
                                    End If
                                ElseIf dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2142_02" And delRow(dIdx) = "CATEGORY" Then
                                    If Not String.IsNullOrEmpty(Me.STATIC_COLUMN_DATA) Then
                                        tmpRowData = Me.STATIC_COLUMN_DATA.Split("|")(3)
                                    End If
                                ElseIf dt.Rows(0)("IMP_OPERATE_PROG").ToString() = "TNA2142_02" And delRow(dIdx) = "SELL_DATE" Then
                                    If rowMap(delRow(dIdx)).ToString <> "" Then
                                        tmpRowData = Convert.ToInt16(rowMap(delRow(dIdx)).ToString.Substring(0, 3)) + 1911 & rowMap(delRow(dIdx)).Substring(3, 6)
                                    End If
                                Else
                                    tmpRowData = rowMap(delRow(dIdx))
                                End If

                                '=== 處理 DD 必須補 0 的欄位 ===
                                If ColumnDDMap.ContainsKey(delRow(dIdx).Trim()) Then
                                    tmpStruct = ColumnDDMap(delRow(dIdx).Trim())
                                    '=== 數字前補 0  ===
                                    Me.Logger.Append("tmpStruct.UIType=====" & tmpStruct.UIType)
                                    If tmpStruct.UIType = "Z" Then

                                        tmpRowData = tmpRowData.PadLeft(Convert.ToInt32(tmpStruct.Length), "0")
                                        rowMap(delRow(dIdx)) = tmpRowData
                                    End If
                                End If

                                cond.Append(" AND " & delRow(dIdx) & " = '" & tmpRowData & "'")
                            Next

                            'dbaDel.Delete(cond.ToString())
                            '=== 處理資料篩選(權限) ===
                            If Not String.IsNullOrEmpty(Me.VALID_COLUMN_DATA) Then
                                If Me.VALID_COLUMN_DATA.IndexOf("|") <> -1 Then
                                    Dim dataAry() As String = Me.VALID_COLUMN_DATA.Split("|")
                                    For i1 As Integer = 0 To dataAry.Length - 1 Step 2
                                        '=== 過濾設定欄位不存在 ===
                                        If rowMap(dataAry(i1)) = Nothing Then
                                            Throw New Exception("VALID_COLUMN_DATA 設定欄位不存在匯入欄位中, 欄位名稱:" & dataAry(i))
                                        End If

                                        '=== 篩選值不存在時處理動作 ===

                                        If ("$" & dataAry(i1 + 1) & "$").IndexOf("$" & rowMap(dataAry(i1)) & "$") = -1 Then
                                            Me.ERROR_RESULT.Append(headerMap(dataAry(i1 + 1)) & "資料必須為: " & dataAry(i1 + 1).Replace("$", ",") & " 資料行-" & line.ToString() & "<br>")
                                        End If
                                    Next
                                End If
                            End If

                            dbaIns.SetColumn("UPDATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            updateCount = dbaIns.Update(cond.ToString())

                            If updateCount > 0 Then
                                '若已存在資料，則UPDATE，UPDATE後要再處理別的動作
                            End If
                        End If

                        '=== 寫入資料庫 ===
                        If dt.Rows(0)("CHECK_ITEM_NAME").ToString <> "新增不處理" And updateCount = 0 Then
                            Me.SysName = dt.Rows(0)("IMP_TABLE_NAME").ToString().Substring(0, 3).ToUpper()

                            dbaIns.SetColumn("PKNO", Me.GetSequence())
                            dbaIns.SetColumn("CREATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("CREATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dbaIns.SetColumn("UPDATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dbaIns.SetColumn("ROWSTAMP", DateUtil.GetNowTimeMS())

                            dbaIns.Insert()

                        End If
                        Me.SUCESS_COUNT = Me.SUCESS_COUNT + 1

                    Catch ex As Exception
                        Me.ERROR_RESULT.Append("資料新增失敗: " & line.ToString() & "<br>")

                        'Message=無法以唯一索引 'APPL141_I01' 在物件 'dbo.APPL141' 中插入重複的索引鍵資料列。重複的索引鍵值是 (A00GUKYM, XXYYZZ)。
                        If ex.Message.Contains("重複的索引鍵值") Then
                            Me.ERROR_RESULT.Append("失敗原因:重複的黃金門號選號規則")
                        End If
                        'Me.ERROR_RESULT.Append("失敗原因:" + ex.Message)
                        Me.Logger.Append(line.ToString() & ", 失敗原因:" + ex.Message)
                        Me.FAILE_COUNT = Me.FAILE_COUNT + 1
                    End Try
                Next

                '=== 無處理資料時秀錯誤訊息 ===
                If processCount = 0 Then
                    Me.ERROR_RESULT.Append("匯入失敗: 無資料可供匯入處理<br>")
                End If

                Me.ResetColumnProperty()
            Finally
                If Not file Is Nothing Then
                    file.Close()
                    file.Dispose()
                End If
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ImpODBCData 匯入資料 "
        ''' <summary>
        ''' 匯入資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.2 nono 2009/03/18 增加回傳成功及失敗筆數
        ''' 0.0.1 nono 新增方法
        ''' </remarks>
        Public Sub ImpODBCData(ByVal dt As DataTable, ByVal headerMap As Hashtable)
            Dim oleConn As OleDbConnection = Nothing
            Dim folder As String = Me.IMP_FILE.DirectoryName & "/" & FormUtil.Session.SessionID & "/"
            Dim ColumnDDMap As Hashtable = MultiProcess.GetCrossSiteValue("COLUMNDD")

            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim header As String() = dt.Rows(0)("INS_ENG_FIELD").ToString().Split(",")
                '=== 存放每列資料 ===
                Dim rowMap As Hashtable = New Hashtable()
                Dim delRow As String()
                Dim line As StringBuilder = New StringBuilder()

                '=== 搬檔產生 Schema.ini ===
                FileUtil.CreateDir(folder)
                '=== 搬檔 ===
                IO.File.Move(Me.IMP_FILE.FullName, folder & Me.IMP_FILE.Name)
                '=== 建立 Schema.ini ===
                Dim tmp As StringBuilder = New StringBuilder()
                tmp.Append("[" & Me.IMP_FILE.Name & "]" & vbCrLf & _
                  "ColNameHeader=True" & vbCrLf & _
                  "Format=CSVDelimited")
                For i As Integer = 0 To headerMap.Keys.Count - 1
                    tmp.Append(vbCrLf & "Col" & (i + 1) & "=CustomerNumber Text")
                Next
                IO.File.WriteAllText(folder & "Schema.ini", tmp.ToString())

                '=== 取得檔案內容 ===
                oleConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Me.IMP_FILE.DirectoryName & "/" & FormUtil.Session.SessionID & "/" + ";Extended Properties='Text;'")
                oleConn.Open()

                '=== 讀取csv檔 ===
                Dim csvDt As DataTable = New DataTable()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" & Me.IMP_FILE.Name & "]", oleConn)
                adapter.Fill(csvDt)

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim dbaIns As DBAccess = Me.DBManager.GetDBAccess(conn)
                Dim dbaDel As DBAccess = Me.DBManager.GetDBAccess(conn)
                Dim cond As StringBuilder = New StringBuilder()
                Dim processCount As Integer = 0

                Me.SUCESS_COUNT = 0
                Me.FAILE_COUNT = 0

                processCount = 0
                For i As Integer = 0 To csvDt.Rows.Count - 1
                    '=== 當第一筆資料為空白行不處理 ===
                    If csvDt.Rows(i)(0).ToString() = "" Then
                        Continue For
                    End If

                    For rIdx As Integer = 0 To csvDt.Columns.Count - 1
                        If rIdx <> 0 Then
                            line.Append(",")
                        End If
                        line.Append(csvDt.Rows(i)(rIdx).ToString())
                    Next

                    '=== 記數處理筆數 ===
                    processCount = processCount + 1

                    '=== 設定表格 ===
                    dbaIns.SetTableName(dt.Rows(0)("IMP_TABLE_NAME"))

                    '=== 處理欄位 ===
                    Dim tmpStruct As ColumnDD = Nothing
                    Dim tmpRowData As String = ""

                    Dim errMsg As String = ""
                    For idx As Integer = 0 To header.Length - 1
                        tmpRowData = Utility.DBStr(csvDt.Rows(i)(idx).ToString().Trim())
                        rowMap(header(idx).Trim()) = tmpRowData

                        '=== 為 OMIT 表示不處理 ===
                        If Not header(idx).Trim().StartsWith("OMIT") Then
                            '=== 處理 DD 必須補 0 的欄位 ===
                            If ColumnDDMap.ContainsKey(header(idx).Trim()) Then
                                tmpStruct = ColumnDDMap(header(idx).Trim())
                                '=== 數字前補 0  ===
                                If tmpStruct.UIType = "Z" Then
                                    tmpRowData = tmpRowData.ToString.PadLeft(Convert.ToInt32(tmpStruct.Length), "0")
                                End If
                            End If

                            dbaIns.SetColumn(header(idx).Trim(), tmpRowData)
                        End If
                    Next

                    '=== 處理自訂欄位值 ===
                    If Not String.IsNullOrEmpty(Me.STATIC_COLUMN_DATA) Then
                        If Me.STATIC_COLUMN_DATA.IndexOf("|") <> -1 Then
                            Dim dataAry() As String = Me.STATIC_COLUMN_DATA.Split("|")
                            For j As Integer = 0 To dataAry.Length - 1 Step 2
                                dbaIns.SetColumn(dataAry(j), Utility.DBStr(dataAry(j + 1)))
                            Next
                        End If
                    End If

                    Dim updateCount As Integer = 0

                    '=== 處理檢核 ===
                    If dt.Rows(0)("CHECK_ITEM_NAME").ToString() <> "" Then
                        If Not Me.CheckRowData(rowMap, dt.Rows(0)("CHECK_ITEM_NAME"), line.ToString(), i + 1) Then
                            Continue For
                        End If
                    End If

                    Try
                        '=== 先更新資料 ===
                        If dt.Rows(0)("DEL_ENG_FIELD").ToString() <> "" Then
                            delRow = dt.Rows(0)("DEL_ENG_FIELD").ToString().Split(",")

                            cond.Length = 0
                            cond.Append("1=1")
                            For dIdx As Integer = 0 To delRow.Length - 1
                                tmpRowData = rowMap(delRow(dIdx))

                                '=== 處理 DD 必須補 0 的欄位 ===
                                If ColumnDDMap.ContainsKey(delRow(dIdx).Trim()) Then
                                    tmpStruct = ColumnDDMap(delRow(dIdx).Trim())
                                    '=== 數字前補 0  ===
                                    If tmpStruct.UIType = "Z" Then
                                        tmpRowData = tmpRowData.ToString.PadLeft(Convert.ToInt32(tmpStruct.Length), "0")
                                        rowMap(delRow(dIdx)) = tmpRowData
                                    End If
                                End If
                                cond.Append(" AND " & delRow(dIdx) & " = '" & tmpRowData & "'")
                            Next
                            'dbaDel.Delete(cond.ToString())
                            '=== 處理資料篩選(權限) ===
                            If Not String.IsNullOrEmpty(Me.VALID_COLUMN_DATA) Then
                                If Me.VALID_COLUMN_DATA.IndexOf("|") <> -1 Then
                                    Dim dataAry() As String = Me.VALID_COLUMN_DATA.Split("|")
                                    For j As Integer = 0 To dataAry.Length - 1 Step 2
                                        '=== 過濾設定欄位不存在 ===
                                        If rowMap(dataAry(j)) = Nothing Then
                                            Throw New Exception("VALID_COLUMN_DATA 設定欄位不存在匯入欄位中, 欄位名稱:" & dataAry(j))
                                        End If

                                        '=== 篩選值不存在時處理動作 ===
                                        If ("$" & dataAry(j + 1) & "$").IndexOf("$" & rowMap(dataAry(j)) & "$") = -1 Then
                                            Me.ERROR_RESULT.Append(headerMap(dataAry(i + 1)) & "資料必須為: " & dataAry(i + 1).Replace("$", ",") & " 資料行-" & line.ToString() & "<br>")
                                        End If
                                    Next
                                End If
                            End If

                            dbaIns.SetColumn("UPDATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dbaIns.SetColumn("ROWSTAMP", DateUtil.GetNowTimeMS())

                            '  updatestatue = dbaDel.Update(cond.ToString())
                            updateCount = dbaIns.Update(cond.ToString())
                        End If

                        '=== 寫入資料庫 ===
                        If dt.Rows(0)("CHECK_ITEM_NAME").ToString <> "新增不處理" And updateCount = 0 Then
                            Me.SysName = dt.Rows(0)("IMP_TABLE_NAME").ToString().Substring(0, 3).ToUpper() 'Me.IMP_OPERATE_PROG.Substring(0, 3).ToUpper()
                            Me.TableName = dt.Rows(0)("IMP_TABLE_NAME").ToString()
                            dbaIns.SetColumn("PKNO", Me.GetSequence())
                            dbaIns.SetColumn("CREATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("CREATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dbaIns.SetColumn("UPDATE_USER", Utility.DBStr(Me.USE_ID))
                            dbaIns.SetColumn("UPDATE_TIME", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            dbaIns.SetColumn("ROWSTAMP", DateUtil.GetNowTimeMS())

                            dbaIns.Insert()
                        End If
                        Me.SUCESS_COUNT = Me.SUCESS_COUNT + 1
                    Catch ex As Exception
                        Me.ERROR_RESULT.Append("資料新增失敗: " & line.ToString() & "<br>")
                        'Me.ERROR_RESULT.Append("失敗原因:" + ex.Message)
                        Me.Logger.Append(line.ToString() & ", 失敗原因:" + ex.Message)
                        Me.FAILE_COUNT = Me.FAILE_COUNT + 1
                    End Try
                Next

                '=== 無處理資料時秀錯誤訊息 ===
                If processCount = 0 Then
                    Me.ERROR_RESULT.Append("匯入失敗: 無資料可供匯入處理<br>")
                End If

                Me.ResetColumnProperty()
            Finally
                If Not oleConn Is Nothing Then
                    oleConn.Close()
                End If

                IO.File.Delete(folder & Me.IMP_FILE.Name)
                IO.File.Delete(folder & "Schema.ini")
                IO.Directory.Delete(folder)
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetCsvDataTable 取得 CSV 的資料來源的 Datatable"
        ''' <summary>
        ''' 取得 CSV 的資料來源的 Datatable
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/04/16 新增方法
        ''' </remarks>
        Private Function GetCsvDataTable(ByVal headerMap As Hashtable) As DataTable
            Dim folder As String = Me.IMP_FILE.DirectoryName & "/" & FormUtil.Session.SessionID & "/"
            Dim oleConn As OleDbConnection = Nothing

            Try
                '=== 搬檔產生 Schema.ini ===
                FileUtil.CreateDir(folder)

                '=== 搬檔 ===
                If Not IO.File.Exists(folder & Me.IMP_FILE.Name) Then
                    IO.File.Move(Me.IMP_FILE.FullName, folder & Me.IMP_FILE.Name)
                End If

                Try
                    '=== 讀取csv檔 ===
                    Dim csvDt As DataTable = New DataTable()

                    For Each key As String In headerMap.Keys
                        csvDt.Columns.Add(key, System.Type.GetType("System.String"))
                    Next

                    Using sr As StreamReader = New StreamReader(Me.IMP_FILE.DirectoryName & "/" & FormUtil.Session.SessionID & "/" & Me.IMP_FILE.Name, System.Text.Encoding.GetEncoding(950), True)

                        Dim line As String = sr.ReadLine() '第一行跳過

                        line = sr.ReadLine()

                        Dim c As Char = IIf(line.IndexOf(",") > 0, ",", ControlChars.Tab)
                        Dim idx As Integer = 1
                        Do While (Not line Is Nothing)

                            Dim items As String() = line.Split(c)

                            If items.Length = headerMap.Keys.Count Then
                                Dim chkDate As Boolean = True
                                Try
                                    Convert.ToDateTime(items(2)).ToString("yyyy/MM/dd")
                                    Convert.ToDateTime(items(3)).ToString("yyyy/MM/dd")
                                Catch ex As Exception
                                    chkDate = False
                                End Try
                                If Not chkDate Then
                                    Me.ERROR_RESULT.AppendFormat("第" & idx & "筆: " & line & " 日期格式錯誤, 請檢查<br>")
                                ElseIf items(4).ToString.Trim = "" Then
                                    Me.ERROR_RESULT.AppendFormat("第" & idx & "筆: " & line & " 選號規則空白, 請檢查<br>")
                                Else
                                    Dim dr As DataRow = csvDt.NewRow()

                                    Dim i As Integer = 0
                                    For Each key As String In headerMap.Keys
                                        dr(key) = items(i).Trim
                                        i = i + 1
                                    Next

                                    csvDt.Rows.Add(dr)
                                End If
                            Else
                                Me.ERROR_RESULT.AppendFormat("第" & idx & "筆: " & line & " 欄位數量不符(匯入欄位數{0},系統欄位數{1} ), 請檢查<br>", items.Length, headerMap.Keys.Count)
                            End If

                            idx = idx + 1
                            line = sr.ReadLine()
                        Loop

                    End Using

                    Return csvDt
                Catch ex As Exception
                    Return Nothing
                End Try
            Finally

                For Each fn As String In IO.Directory.GetFiles(folder)
                    IO.File.Delete(fn)
                Next
                'IO.File.Delete(folder & Me.IMP_FILE.Name)

                If IO.Directory.GetFiles(folder).Length = 0 Then
                    IO.Directory.Delete(folder)
                End If

            End Try
        End Function
#End Region

#Region "GetExcelDataTable 取得 Excel 的資料來源的 Datatable"
        ''' <summary>
        ''' 取得 Excel 的資料來源的 Datatable
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/04/16 新增方法
        ''' </remarks>
        Private Function GetExcelDataTable(ByVal headerMap As Hashtable) As DataTable
            Dim oleConn As OleDbConnection = Nothing
            Try
                Dim ds As DataSet = New DataSet()
                Dim connStr As String = _
                 "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                 "Data Source=" & Me.IMP_FILE.FullName & ";" & _
                 "Extended Properties='Excel 8.0;IMEX=1;'"
                oleConn = New OleDbConnection(connStr)
                Try
                    oleConn.Open()

                    Dim dt As DataTable = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

                    'Dim oda As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" & dt.Rows(1)("TABLE_NAME") & "]", connStr)
                    '                    oda.TableMappings.Add("Table", "ExcelTest")
                    '                    oda.Fill(ds)
                    'thomas modify 2009/12/29==>'Excel有隱藏sheet為'Sheet1$'_,所以'Sheet1$'才是正確的
                    For Each dr As DataRow In dt.Rows
                        If dr("TABLE_NAME").ToString.EndsWith("$'") Or dr("TABLE_NAME").ToString.EndsWith("$") Then
                            Dim oda As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" & dr("TABLE_NAME").ToString & "]", connStr)
                            oda.TableMappings.Add("Table", "ExcelTest")
                            oda.Fill(ds)
                        End If
                    Next
                    Return ds.Tables(0)
                Catch ex As Exception
                    Return Nothing
                End Try
            Finally
                If Not oleConn Is Nothing Then
                    oleConn.Close()
                End If
            End Try
        End Function
#End Region

#Region "CheckRowData 檢查資料列資料"
        Private Function CheckRowData(ByVal rowMap As Hashtable, ByVal chkType As String, ByVal fullStr As String, ByVal idx As Integer) As Boolean
            Dim err As New StringBuilder
            Select Case chkType
                Case "匯入年度釋出明細"
                    Try
                        If rowMap("DOOR_NO").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[門號] 不可空白, 請檢查<br>")
                        End If

                        If IsNumeric(rowMap("DOOR_NO").ToString) = False Then
                            err.Append("第" & idx & "筆: " & fullStr & "[門號] 必須完全由數字組合而成, 請檢查<br>")
                        End If

                        If rowMap("HAVE_TAX_AMT").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[釋出金額(含稅)] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("HAVE_TAX_AMT").ToString <> "" AndAlso Not IsNumeric(rowMap("HAVE_TAX_AMT").ToString) Then
                            err.Append("第" & idx & "筆: " & fullStr & "[釋出金額(含稅)] 限輸入數字, 請檢查<br>")
                        End If

                        If rowMap("HAVE_TAX_AMT").ToString <> "" AndAlso Convert.ToInt32(rowMap("HAVE_TAX_AMT").ToString) <= 0 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[釋出金額(含稅)] 需大於0, 請檢查<br>")
                        End If

                        If rowMap("SELL_DATE").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[賣出日期] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("YYMM").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 不可空白, 請檢查<br>")
                        End If

                        If Me.IMP_FILE.Extension.ToUpper() = ".CSV" Or Me.IMP_FILE.Extension.ToUpper() = ".TXT" Then
                            If rowMap("SELL_DATE").ToString <> "" AndAlso Not IsDate(rowMap("SELL_DATE")) Then
                                err.Append("第" & idx & "筆: " & fullStr & "[賣出日期] 限輸入西元日期(yyyy/MM/dd), 請檢查<br>")
                            End If

                            If rowMap("YYMM").ToString <> "" AndAlso Not IsDate(rowMap("YYMM")) Then
                                err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 限輸入西元年月(yyy/MM/dd), 請檢查<br>")
                            End If

                            If rowMap("SELL_DATE").ToString <> "" AndAlso Date.Compare(rowMap("YYMM"), rowMap("SELL_DATE")) < 0 Then
                                err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 出帳年月需大於等於賣出日期<br>")
                            End If
                        Else
                            If rowMap("SELL_DATE").ToString <> "" AndAlso (rowMap("SELL_DATE").ToString.Length <> 9 OrElse Not IsDate(Convert.ToInt16(rowMap("SELL_DATE").ToString.Substring(0, 3)) + 1911 & rowMap("SELL_DATE").ToString.Substring(3, 6))) Then
                                err.Append("第" & idx & "筆: " & fullStr & "[賣出日期] 限輸入日期(yyy/MM/dd), 請檢查<br>")
                            End If

                            If rowMap("YYMM").ToString <> "" AndAlso Not IsDate(Convert.ToInt16(rowMap("YYMM").ToString.Substring(0, 3)) + 1911 & "/" & rowMap("YYMM").ToString.Substring(3, 2) & "/01") Then
                                err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 限輸入年月(yyyMM)共5碼, 請檢查<br>")
                            End If

                            If rowMap("SELL_DATE").ToString <> "" AndAlso rowMap("YYMM").ToString AndAlso rowMap("YYMM").ToString < rowMap("SELL_DATE").ToString.Replace("/", "").Substring(0, 5) Then
                                err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 出帳年月需大於等於賣出日期<br>")
                            End If
                        End If

                        If rowMap("YYMM").ToString <> "" AndAlso rowMap("YYMM").ToString = DateUtil.GetNowCDate.Substring(0, 3) & "01" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[出帳年月] 出帳年月不能是今年一月, 請檢查<br>")
                        End If

                        If rowMap("IS_NO_TAX").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[是否免稅] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("IS_NO_TAX").ToString <> "" AndAlso (rowMap("IS_NO_TAX").ToString.ToUpper <> "Y" AndAlso rowMap("IS_NO_TAX").ToString.ToUpper <> "N") Then
                            err.Append("第" & idx & "筆: " & fullStr & "[是否免稅] 限輸入Y或N, 請檢查<br>")
                        End If


                    Catch ex As Exception
                        Me.Logger.Append(ex.Message)
                        err.Append("第" & idx & "筆: " & fullStr & " 有誤, 請檢查<br>")
                    End Try
                Case "匯入選號規則"
                    Try
                        If rowMap("RULE_TYPE").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[規則別] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("RULE_TYPE").ToString <> "" AndAlso (Not IsNumeric(rowMap("RULE_TYPE").ToString) OrElse rowMap("RULE_TYPE").ToString.Length > 3) Then
                            err.Append("第" & idx & "筆: " & fullStr & "[規則別] 限輸入3位數字, 請檢查<br>")
                        End If

                        If rowMap("GOLD_NO_RULE").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[門號規則] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("GOLD_NO_RULE").ToString.IndexOf("M") <> 0 Then
                            If rowMap("GOLD_NO_RULE").ToString.IndexOf("M") > 0 Then
                                err.Append("第" & idx & "筆: " & fullStr & "[門號規則] M 只能單獨使用, 請檢查<br>")
                            Else
                                If rowMap("GOLD_NO_RULE").ToString <> "" Then
                                    Dim tmp As String = ""
                                    If rowMap("GOLD_NO_RULE").ToString.StartsWith("{") AndAlso rowMap("GOLD_NO_RULE").ToString.EndsWith("}") Then
                                        tmp = rowMap("GOLD_NO_RULE").ToString.TrimStart("{").TrimEnd("}")
                                    Else
                                        tmp = rowMap("GOLD_NO_RULE").ToString
                                    End If

                                    Dim pattern As String = "[0-9ABCDEFVWXYZ]"
                                    Dim regexp As Regex = New Regex(pattern)
                                    Dim matches As MatchCollection = Regex.Matches(tmp, pattern, RegexOptions.IgnoreCase)
                                    If matches.Count <> tmp.Length Then
                                        err.Append("第" & idx & "筆: " & fullStr & "[門號規則] 不符規則, 請檢查<br>")
                                    End If
                                End If
                            End If
                        End If

                        If rowMap("APPLY_AMT").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[價格] 不可空白, 請檢查<br>")
                        End If

                        If rowMap("APPLY_AMT").ToString <> "" AndAlso Not IsNumeric(rowMap("APPLY_AMT").ToString) Then
                            err.Append("第" & idx & "筆: " & fullStr & "[價格] 限輸入數字, 請檢查<br>")
                        End If

                        If rowMap("APPLY_AMT").ToString <> "" AndAlso Convert.ToInt32(rowMap("APPLY_AMT").ToString) <= 0 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[價格] 需大於0, 請檢查<br>")
                        End If

                        If rowMap("MK_1").ToString <> "" AndAlso rowMap("MK_1").ToString <> "Y" AndAlso rowMap("MK_1").ToString <> "N" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[A~F是否包含4] 限輸入Y或N, 請檢查<br>")
                        End If

                        If rowMap("MK_2").ToString <> "" AndAlso rowMap("MK_2").ToString <> "Y" AndAlso rowMap("MK_2").ToString <> "N" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[V~Z是否包含4] 限輸入Y或N, 請檢查<br>")
                        End If

                        If rowMap("MK_3").ToString <> "" AndAlso rowMap("MK_3").ToString <> "Y" AndAlso rowMap("MK_3").ToString <> "N" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[最未碼是否包含4] 限輸入Y或N, 請檢查<br>")
                        End If
                    Catch ex As Exception
                        Me.Logger.Append(ex.Message)
                        err.Append("第" & idx & "筆: " & fullStr & " 有誤, 請檢查<br>")
                    End Try
                Case "匯入金融機構"
                    Try
                        If rowMap("FINANCE_INSTTT_CODE").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[金融機關代碼]不可空白, 請檢查<br>")
                        End If
                        If rowMap("FINANCE_INSTTT_NM").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[金融機關名稱] 不可空白, 請檢查<br>")
                        End If
                        If rowMap("FINANCE_INSTTT_CODE").ToString <> "" AndAlso rowMap("FINANCE_INSTTT_CODE").ToString.Length > 7 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[金融機關代碼] 限輸入7個字, 請檢查<br>")
                        End If
                        If rowMap("FINANCE_INSTTT_NM").ToString <> "" AndAlso rowMap("FINANCE_INSTTT_NM").ToString.Length > 20 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[金融機關名稱] 限輸入20個字, 請檢查<br>")
                        End If
                        If rowMap("TEL").ToString <> "" AndAlso rowMap("TEL").ToString.Length > 20 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[電話] 限輸入20個字, 請檢查<br>")
                        End If
                        If rowMap("ADDR").ToString <> "" AndAlso rowMap("ADDR").ToString.Length > 100 Then
                            err.Append("第" & idx & "筆: " & fullStr & "[地址] 限輸入100個字, 請檢查<br>")
                        End If
                        '測試
                        If rowMap("TEL").ToString = "" Then
                            err.Append("第" & idx & "筆: " & fullStr & "[電話] 不可為空白, 請檢查<br>")
                        End If
                    Catch ex As Exception
                        err.Append("第" & idx & "筆: " & fullStr & " 有誤, 請檢查<br>")
                    End Try
            End Select

            If err.ToString <> "" Then
                Me.ERROR_RESULT.Append(err.ToString)
                Return False
            Else
                Return True
            End If


        End Function
#End Region

#Region "TripleDesEncrypt 將字串加密"
        ''' <summary>
        ''' TripleDesEncrypt 將字串加密
        ''' </summary>
        ''' <param name="str">要加密的字串</param>
        ''' <returns>加密後字串</returns>
        Function TripleDesEncrypt(ByVal str As String) As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.Name)

                If String.IsNullOrEmpty(str) Then
                    Return ""
                End If

                Dim des As New TripleDESCryptoServiceProvider()
                Dim keyStr As String = APConfig.GetProperty("pwdkey1")
                Dim ivStr As String = APConfig.GetProperty("pwdkey2")

                des.Key = Convert.FromBase64String(keyStr)
                des.IV = Convert.FromBase64String(ivStr)
                des.Mode = CipherMode.ECB
                des.Padding = PaddingMode.PKCS7

                Dim ms As New MemoryStream()
                Dim cs As New CryptoStream(ms, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write)
                Dim sw As New StreamWriter(cs)

                sw.Write(str)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()

                Dim result As String = System.Convert.ToBase64String(ms.GetBuffer(), 0, System.Convert.ToInt32(ms.Length))

                sw.Close()
                cs.Close()
                ms.Close()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region
    End Class
End Namespace

