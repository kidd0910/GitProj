'----------------------------------------------------------------------------------
'File Name		: CtDataExchange 
'Author			: 
'Description		: CtDataExchange 資料交換處理Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2010/11/13	   	Source Create
'----------------------------------------------------------------------------------

Imports BAT.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Bat.Business
    ''' <summary>
    ''' CtDataExchange 資料交換處理Ct
    ''' </summary>
    Partial Public Class CtDataExchange
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "BATCH_JOB_SEQ 批次工作序號"
        ''' <summary>
        ''' BATCH_JOB_SEQ 批次工作序號
        ''' </summary>
        Public Property BATCH_JOB_SEQ() As String
            Get
                Return Me.PropertyMap("BATCH_JOB_SEQ")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BATCH_JOB_SEQ") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.PropertyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH") = value
            End Set
        End Property
#End Region

#Region "FILE_NAME 檔案名稱"
        ''' <summary>
        ''' FILE_NAME 檔案名稱
        ''' </summary>
        Public Property FILE_NAME() As String
            Get
                Return Me.PropertyMap("FILE_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FILE_NAME") = value
            End Set
        End Property
#End Region

#Region "EXE_RES 執行結果"
        ''' <summary>
        ''' EXE_RES 執行結果
        ''' </summary>
        Public Property EXE_RES() As String
            Get
                Return Me.PropertyMap("EXE_RES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_RES") = value
            End Set
        End Property
#End Region

#Region "RES_CONTENT 結果內容"
        ''' <summary>
        ''' RES_CONTENT 結果內容
        ''' </summary>
        Public Property RES_CONTENT() As String
            Get
                Return Me.PropertyMap("RES_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("RES_CONTENT") = value
            End Set
        End Property
#End Region

#Region "UNUSUAL_RECORD_FILE 異常記錄檔路徑"
        ''' <summary>
        ''' UNUSUAL_RECORD_FILE 異常記錄檔路徑
        ''' </summary>
        Public Property UNUSUAL_RECORD_FILE() As String
            Get
                Return Me.PropertyMap("UNUSUAL_RECORD_FILE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UNUSUAL_RECORD_FILE") = value
            End Set
        End Property
#End Region

#Region "EXE_TIME 執行時間"
        ''' <summary>
        ''' EXE_TIME 執行時間
        ''' </summary>
        Public Property EXE_TIME() As String
            Get
                Return Me.PropertyMap("EXE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_TIME") = value
            End Set
        End Property
#End Region

#Region "EXE_TYPE 執行種類"
        ''' <summary>
        ''' EXE_TYPE 執行種類
        ''' </summary>
        Public Property EXE_TYPE() As String
            Get
                Return Me.PropertyMap("EXE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EXE_TYPE") = value
            End Set
        End Property
#End Region

#Region "INFO_CONTENT 訊息內容"
        ''' <summary>
        ''' INFO_CONTENT 訊息內容
        ''' </summary>
        Public Property INFO_CONTENT() As String
            Get
                Return Me.PropertyMap("INFO_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INFO_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_EXE 是否執行"
        ''' <summary>
        ''' IS_EXE 是否執行
        ''' </summary>
        Public Property IS_EXE() As String
            Get
                Return Me.PropertyMap("IS_EXE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_EXE") = value
            End Set
        End Property
#End Region

#Region "PROGRAM_CODE 程式代碼"
        ''' <summary>
        ''' PROGRAM_CODE 程式代碼
        ''' </summary>
        Public Property PROGRAM_CODE() As String
            Get
                Return Me.PropertyMap("PROGRAM_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROGRAM_CODE") = value
            End Set
        End Property
#End Region

#Region "SQL_VALUE SQL值"
        ''' <summary>
        ''' SQL_VALUE SQL值
        ''' </summary>
        Public Property SQL_VALUE() As String
            Get
                Return Me.PropertyMap("SQL_VALUE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SQL_VALUE") = value
            End Set
        End Property
#End Region

#Region "TABLE_NM 表格名稱"
        ''' <summary>
        ''' TABLE_NM 表格名稱
        ''' </summary>
        Public Property TABLE_NM() As String
            Get
                Return Me.PropertyMap("TABLE_NM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TABLE_NM") = value
            End Set
        End Property
#End Region

#Region "OUT_TYPE 轉出種類"
        ''' <summary>
        ''' OUT_TYPE 轉出種類(1-學網,2-軍網,3-軍外網)
        ''' </summary>
        Public Property OUT_TYPE() As String
            Get
                Return Me.PropertyMap("OUT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OUT_TYPE") = value
            End Set
        End Property
#End Region
#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===

        End Sub
#End Region

#Region "方法"
#Region "AddSetExchangeData 新增設定交換資料"
        ''' <summary>
        ''' 新增設定交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddSetExchangeData()
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
                'EntSetExchangeData = new EntSetExchangeData()
                'return EntSetExchangeData.Insert()
                Dim EntSetExchangeData As New EntSetExchangeData(Me.DBManager, Me.LogUtil)
                If OUT_TYPE.IndexOf(",") >= 0 Then
                    Dim type As String() = OUT_TYPE.Split(",")
                    For i As Integer = 0 To type.Length - 1
                        If Me.IS_BATCH = "Y" Then
                            EntSetExchangeData.SetUserId("batch")
                        End If

                        EntSetExchangeData.SQL_VALUE = Me.SQL_VALUE    'SQL值
                        EntSetExchangeData.EXE_TIME = Me.EXE_TIME '執行時間
                        EntSetExchangeData.EXE_TYPE = Me.EXE_TYPE '執行種類
                        EntSetExchangeData.IS_EXE = Me.IS_EXE   '是否執行
                        EntSetExchangeData.PROGRAM_CODE = Me.PROGRAM_CODE '程式代碼
                        EntSetExchangeData.TABLE_NM = Me.TABLE_NM '表格名稱
                        EntSetExchangeData.INFO_CONTENT = Me.INFO_CONTENT '訊息內容
                        EntSetExchangeData.OUT_TYPE = type(i)
                        EntSetExchangeData.Insert()
                    Next
                Else
                    If Me.IS_BATCH = "Y" Then
                        EntSetExchangeData.SetUserId("batch")
                    End If
                    EntSetExchangeData.SQL_VALUE = Me.SQL_VALUE    'SQL值
                    EntSetExchangeData.EXE_TIME = Me.EXE_TIME '執行時間
                    EntSetExchangeData.EXE_TYPE = Me.EXE_TYPE '執行種類
                    EntSetExchangeData.IS_EXE = Me.IS_EXE   '是否執行
                    EntSetExchangeData.PROGRAM_CODE = Me.PROGRAM_CODE '程式代碼
                    EntSetExchangeData.TABLE_NM = Me.TABLE_NM '表格名稱
                    EntSetExchangeData.INFO_CONTENT = Me.INFO_CONTENT '訊息內容
                    EntSetExchangeData.OUT_TYPE = OUT_TYPE
                    EntSetExchangeData.Insert()
                End If

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetSetExchangeData 取得設定交換資料"
        ''' <summary>
        ''' 取得設定交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetSetExchangeData() As DataTable
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
                'EntSetExchangeData = new EntSetExchangeData()
                'return EntSetExchangeData.Query()
                Dim EntSetExchangeData As EntSetExchangeData = New EntSetExchangeData(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "IS_EXE", Me.IS_EXE)
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)
                EntSetExchangeData.SqlRetrictions = condition.ToString()
                EntSetExchangeData.OrderBys = "PKNO"

                Dim result As DataTable = EntSetExchangeData.Query()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSetExchangeData 更新設定交換資料"
        ''' <summary>
        ''' 更新設定交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateSetExchangeData()
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
                'EntSetExchangeData = new EntSetExchangeData()
                '組合查詢字串(EntMilGeneralMarkOfCrs.QUERY_COND(查詢條件),"=",PKNO(Pkno))
                'return EntSetExchangeData.Update()
                Dim EntSetExchangeData As EntSetExchangeData = New EntSetExchangeData(Me.DBManager, Me.LogUtil)
                EntSetExchangeData.PKNO = Me.PKNO
                EntSetExchangeData.IS_EXE = Me.IS_EXE
                EntSetExchangeData.EXE_TIME = Me.EXE_TIME
                EntSetExchangeData.INFO_CONTENT = Me.INFO_CONTENT
                EntSetExchangeData.BATCH_JOB_SEQ = Me.BATCH_JOB_SEQ
                EntSetExchangeData.SetUserId("batch")

                EntSetExchangeData.UpdateByPkNo()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateSetExchangeData2 更新設定交換資料2"
        ''' <summary>
        ''' 更新設定交換資料2
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateSetExchangeData2()
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
                'EntSetExchangeData = new EntSetExchangeData()
                '組合查詢字串(EntMilGeneralMarkOfCrs.QUERY_COND(查詢條件),"=",PKNO(Pkno))
                'return EntSetExchangeData.Update()
                Dim EntSetExchangeData As EntSetExchangeData = New EntSetExchangeData(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "BATCH_JOB_SEQ", Me.BATCH_JOB_SEQ)   'PKNO
                EntSetExchangeData.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                EntSetExchangeData.IS_EXE = Me.IS_EXE
                EntSetExchangeData.EXE_TIME = Me.EXE_TIME
                EntSetExchangeData.INFO_CONTENT = Me.INFO_CONTENT

                EntSetExchangeData.Update()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSetExchangeData 刪除設定交換資料"
        ''' <summary>
        ''' 刪除設定交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteSetExchangeData()
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
                'EntSetExchangeData = new EntSetExchangeData()
                '組合查詢字串(EntMilGeneralMarkOfCrs.QUERY_COND(查詢條件),"=",PKNO(Pkno),TABLE_NM(表格名稱),PROGRAM_CODE(程式代碼),EXE_TYPE(執行種類),SQL_VALUE(SQL值),IS_EXE(是否執行))
                'return EntSetExchangeData.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddImpExchangeData 新增匯入交換資料"
        ''' <summary>
        ''' 新增匯入交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddImpExchangeData()
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
                'EntImpExchangeData = new EntImpExchangeData()
                'return EntImpExchangeData.Insert()
                Dim entImpExchangeData As EntImpExchangeData = New EntImpExchangeData(Me.DBManager, Me.LogUtil)
                entImpExchangeData.FILE_NAME = Me.FILE_NAME
                entImpExchangeData.EXE_RES = Me.EXE_RES
                entImpExchangeData.RES_CONTENT = Me.RES_CONTENT
                entImpExchangeData.UNUSUAL_RECORD_FILE = Me.UNUSUAL_RECORD_FILE
                entImpExchangeData.EXE_TIME = Me.EXE_TIME
                entImpExchangeData.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetImpExchangeData 取得匯入交換資料"
        ''' <summary>
        ''' 取得匯入交換資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub GetImpExchangeData()
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
                'EntImpExchangeData = new EntImpExchangeData()
                'return EntImpExchangeData.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region


#End Region
    End Class
End Namespace

