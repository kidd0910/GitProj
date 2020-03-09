'----------------------------------------------------------------------------------
'File Name		: SYST010
'Author			: CMHuang
'Description		: SYST010 系統下拉選單代碼維護
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/09/17	CMHuang		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Sys.Data
    ' <summary>
    ' SYST010 系統下拉選單代碼維護
    ' </summary>
    Public Class ENT_SYST010
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
            Me.TableName = "SYST010"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "SYS_KEY,SYS_NAME,SYS_RSV1,SYS_RSV2,SYS_RSV3,SYS_RSV4,REMARK"
            '數字欄位為空時，不要寫入0，寫入NULL
            Me.SET_NULL_FIELD = "SYS_PRTID"
        End Sub
#End Region

#Region "屬性"
#Region "SYS_KEY"
        '' <summary>
        '' SYS_KEY
        '' </summary>
        Public Property SYS_KEY() As String
            Get
                Return Me.ColumnyMap("SYS_KEY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_KEY") = value
            End Set
        End Property
#End Region

#Region "SYS_PRTID"
        '' <summary>
        '' SYS_PRTID
        '' </summary>
        Public Property SYS_PRTID() As String
            Get
                Return Me.ColumnyMap("SYS_PRTID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_PRTID") = value
            End Set
        End Property
#End Region

#Region "SYS_ID"
        '' <summary>
        '' SYS_ID
        '' </summary>
        Public Property SYS_ID() As String
            Get
                Return Me.ColumnyMap("SYS_ID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_ID") = value
            End Set
        End Property
#End Region

#Region "SYS_NAME"
        '' <summary>
        '' SYS_NAME
        '' </summary>
        Public Property SYS_NAME() As String
            Get
                Return Me.ColumnyMap("SYS_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_NAME") = value
            End Set
        End Property
#End Region

#Region "SYS_TYPE"
        '' <summary>
        '' SYS_TYPE
        '' </summary>
        Public Property SYS_TYPE() As String
            Get
                Return Me.ColumnyMap("SYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV1"
        '' <summary>
        '' SYS_RSV1
        '' </summary>
        Public Property SYS_RSV1() As String
            Get
                Return Me.ColumnyMap("SYS_RSV1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_RSV1") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV2"
        '' <summary>
        '' SYS_RSV2
        '' </summary>
        Public Property SYS_RSV2() As String
            Get
                Return Me.ColumnyMap("SYS_RSV2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_RSV2") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV3"
        '' <summary>
        '' SYS_RSV3
        '' </summary>
        Public Property SYS_RSV3() As String
            Get
                Return Me.ColumnyMap("SYS_RSV3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_RSV3") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV4"
        '' <summary>
        '' SYS_RSV4
        '' </summary>
        Public Property SYS_RSV4() As String
            Get
                Return Me.ColumnyMap("SYS_RSV4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_RSV4") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT"
        '' <summary>
        '' SYS_SORT
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.ColumnyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "REMARK"
        '' <summary>
        '' REMARK
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

#Region "LICENSE_NO"
        '' <summary>
        '' LICENSE_NO
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


#Region "NUM_CATEGORY"
        '' <summary>
        '' NUM_CATEGORY
        '' </summary>
        Public Property NUM_CATEGORY() As String
            Get
                Return Me.ColumnyMap("NUM_CATEGORY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NUM_CATEGORY") = value
            End Set
        End Property
#End Region

#Region "NUM_CATEGORY1"
        '' <summary>
        '' NUM_CATEGORY1
        '' </summary>
        Public Property NUM_CATEGORY1() As String
            Get
                Return Me.ColumnyMap("NUM_CATEGORY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NUM_CATEGORY1") = value
            End Set
        End Property
#End Region

#Region "NUM_CATEGORY2"
        '' <summary>
        '' NUM_CATEGORY2
        '' </summary>
        Public Property NUM_CATEGORY2() As String
            Get
                Return Me.ColumnyMap("NUM_CATEGORY2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NUM_CATEGORY2") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號"
        ''' <summary>
        ''' 案件編號
        ''' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE ITEM_TYPE"
        ''' <summary>
        ''' ITEM_TYPE
        ''' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.PropertyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM_TYPE") = value
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
        ''' 0.0.1 CMHuang 新增方法
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME AS SYS_NAME1, isNull(R2.CH_NAME, '') AS UPDATE_USER1, ")
                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(UPDATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME1 , ")
                'sql.AppendLine(" (  CAST(YEAR(UPDATE_TIME) AS VARCHAR(4)) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME2,  ")
                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE1  ")
                sql.AppendLine(" FROM SYST010 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT SYS_KEY, SYS_ID, SYS_NAME, SYS_SORT FROM SYST010 WITH(NOLOCK)) R1 ON M.SYS_PRTID = R1.SYS_ID and M.SYS_KEY= R1.SYS_KEY ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R2 ON M.UPDATE_USER = R2.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query_GetMaxPRTID 查詢目前RPTID的最大序號 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function Query_GetMaxPRTID() As DataTable
            Return Me.Query_GetMaxPRTID(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CMHuang 新增方法
        ''' </remarks>
        Public Function Query_GetMaxPRTID(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME", "MAX_SYS_ID", "MAX_SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" select max(SYS_ID) as MAX_SYS_ID, max(SYS_SORT) as MAX_SYS_SORT ")
                sql.AppendLine(" from SYST010 M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetNumCategoryFromC2 取得號碼種類樹狀資料(從號碼子類別) "
        ''' <summary>
        ''' 取得號碼種類樹狀資料(從號碼子類別)
        ''' </summary>
        Public Function GetNumCategoryFromC2() As DataTable
            Return Me.GetNumCategoryFromC2(0, 0)
        End Function
        ''' <summary>
        ''' 取得號碼種類樹狀資料(從號碼子類別)
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Mark Huang 新增方法
        ''' </remarks>
        Public Function GetNumCategoryFromC2(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "SYS_KEY", Me.SYS_KEY)
                Me.ProcessQueryCondition(condition, "=", "SYS_ID", Me.SYS_ID)
                Me.ProcessQueryCondition(condition, "=", "SYS_PRTID", Me.SYS_PRTID)
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)
                Me.ProcessQueryCondition(condition, "=", "SYS_TYPE", Me.SYS_TYPE)
                Me.ProcessQueryCondition(condition, "=", "SYS_NAME", Me.SYS_NAME)
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)        'PKNO

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()


                Dim sql As New StringBuilder
                sql.Append(" SELECT R2.SYS_ID AS NUM_CATEGORY_ID, R2.SYS_NAME AS NUM_CATEGORY_NAME, ")
                sql.Append(" R1.SYS_ID AS NUM_CATEGORY1_ID, R1.SYS_NAME AS NUM_CATEGORY1_NAME, ")
                sql.Append(" M.SYS_ID AS NUM_CATEGORY2_ID, M.SYS_NAME AS NUM_CATEGORY2_NAME  FROM SYST010 M	")
                sql.Append(" LEFT JOIN SYST010 R1 ON M.SYS_PRTID = R1.SYS_ID AND R1.SYS_KEY='號碼種類' ")
                sql.Append(" LEFT JOIN SYST010 R2 ON R1.SYS_PRTID = R2.SYS_ID AND R2.SYS_KEY='號碼種類' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.SYS_KEY ASC,M.SYS_ID ASC ")
                    Else
                        sql.AppendLine(" ORDER BY M.SYS_KEY ASC,M.SYS_ID ASC ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#End Region


#Region "父參數連動查詢 "
        ''' <summary>
        ''' 父參數連動查詢 
        ''' </summary>
        Public Function PRTID_Query() As DataTable
            Return Me.PRTID_Query(0, 0)
        End Function

        ''' <summary>
        ''' 父參數連動查詢
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CMHuang 新增方法
        ''' </remarks>
        Public Function PRTID_Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT distinct R1.SYS_NAME , R1.SYS_ID, R1.SYS_KEY, R1.SYS_SORT ")
                sql.AppendLine(" FROM SYST010 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT SYS_ID, SYS_NAME, SYS_KEY, SYS_SORT FROM SYST010 WITH(NOLOCK)) R1 ON M.SYS_PRTID = R1.SYS_ID and M.SYS_KEY= R1.SYS_KEY ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_SORT ASC ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_SORT ASC ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "表單 查詢 "
        ''' <summary>
        ''' 查詢 執照號碼、號碼子類別下的核配數量(現況，包括移轉的)
        ''' </summary>        
        Public Function QueryQuantity() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"V_NUMBER_STATUS", "M", "NUM_CATEGORY2", "LICENSE_NO_PKNO", "PKNO", "QUANTITY"})

                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO) 'PKNO
                Me.ProcessQueryCondition(condition, "=", "LICENSE_NO_PKNO", Me.LICENSE_NO)

                Select Case Me.NUM_CATEGORY1
                    Case "11"
                        Me.ProcessQueryCondition(condition, "<", "NUM_CATEGORY2", Me.NUM_CATEGORY2)
                    Case "12"
                        Me.ProcessQueryCondition(condition, "=", "NUM_CATEGORY2", Me.NUM_CATEGORY2)
                    Case "13"
                        Me.ProcessQueryCondition(condition, ">", "NUM_CATEGORY2", Me.NUM_CATEGORY2)
                    Case Else

                End Select

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.Append(" SELECT SUM(QUANTITY) AS QUANTITY FROM V_NUMBER_STATUS M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' 查詢 可使用的號碼種類、號碼類別、號碼子類別的編號與名稱
        ''' </summary>        
        Public Function QueryStatusBySp() As DataTable
            Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
            Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand
            Dim trans As System.Data.SqlClient.SqlTransaction = DBManager.GetDBTransaction(conn)
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                cmd.Connection = conn
                cmd.Transaction = trans
                cmd.CommandTimeout = 600
                cmd.CommandText = "ENT_GET_NUM_CATEGORY"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@LICENSE_NO", IIf(String.IsNullOrEmpty(LICENSE_NO), "", LICENSE_NO))
                cmd.Parameters.AddWithValue("@NUM_CATEGORY", IIf(String.IsNullOrEmpty(NUM_CATEGORY), "", NUM_CATEGORY))
                cmd.Parameters.AddWithValue("@NUM_CATEGORY1", IIf(String.IsNullOrEmpty(NUM_CATEGORY1), "", NUM_CATEGORY1))
                cmd.Parameters.AddWithValue("@NUM_CATEGORY2", IIf(String.IsNullOrEmpty(NUM_CATEGORY2), "", NUM_CATEGORY2))
                Dim adpt As DbDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
                adpt.SelectCommand = cmd
                Dim ds As DataSet = New DataSet()
                adpt.Fill(ds)

                Dim dt As DataTable = ds.Tables(0)

                Me.ResetColumnProperty()
                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "Get系統下拉資料 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function Get系統下拉資料() As DataTable
            Return Me.Get系統下拉資料(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        Public Function Get系統下拉資料(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, M.SYS_ID + '-'+ M.SYS_NAME AS SELECT_TEXT , ")
                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE_NM  ")
                sql.AppendLine(" FROM SYST010 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
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
        ''' 查詢頁籤功能
        ''' </summary>
        ''' <returns></returns>
        Public Function GetTabs() As DataTable
            Return Me.GetTabs(0, 0)
        End Function
        Public Function GetTabs(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_KEY", "SYS_ID", "SYS_PRTID", "USE_STATE", "SYS_TYPE", "SYS_NAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT distinct M.SYS_ID ")
                sql.AppendLine(" FROM SYST010 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_KEY ASC,SYS_ID ASC ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get審X費類別"
        ''' <summary>
        ''' Get審X費類別 
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        Public Function Get審X費類別() As DataTable
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
                Me.TableCoumnInfo.Clear()
                Me.ParserAlias()

                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT DISTINCT SYS_RSV2 ")
                SQL.AppendLine("  FROM SYST010")
                SQL.AppendLine(" WHERE     SYS_KEY = 'PAY_CODE'")
                SQL.AppendLine("       AND SYS_RSV3 IN (SELECT SYS_RSV3")
                SQL.AppendLine("                          FROM SYST010")
                SQL.AppendLine("                         WHERE     SYS_KEY = 'PAY_CODE'")
                SQL.AppendLine("                               AND SYS_ID IN (SELECT PAY_CODE")
                SQL.AppendLine("                                                FROM CSHT010")
                SQL.AppendLine("                                               WHERE     CASE_NO ='" & Me.CASE_NO & "'") 
                SQL.AppendLine("                                                     AND ITEM_TYPE = '" & Me.ITEM_TYPE & "'")
                SQL.AppendLine("                                                     AND ISNULL (CAN_FLAG, '') = ''))")

                SQL.AppendLine(" ORDER BY SYS_RSV2 ASC ")

                Dim dt As DataTable = Me.QueryBySql(SQL.ToString, 0, 0)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get資產類別"
        ''' <summary>
        ''' Get審X費類別 
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        Public Function Get資產類別() As DataTable
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
                Me.TableCoumnInfo.Clear()
                Me.ParserAlias()

                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT SYS_ID, SYS_NAME,SYS_PRTID ")
                SQL.AppendLine("  FROM SYST010")
                SQL.AppendLine(" WHERE SYS_KEY='FINANCE_CODE1' and USE_STATE=1 and SYS_TYPE=1 ")

                SQL.AppendLine(" ORDER BY SYS_SORT ASC ")

                Dim dt As DataTable = Me.QueryBySql(SQL.ToString, 0, 0)

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

