'----------------------------------------------------------------------------------
'File Name		: EntDbSchema
'Author			: 
'Description		: EntDbSchema DBSchema匯出ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/05/07			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Mis.Data
	'' <summary>
	'' EntDbSchema DBSchema匯出ENT
	'' </summary>
	Public Class EntDbSchema
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
            Me.SysName = "MIS"
            Me.ConnName = ""

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "TABLE_NAME 表格名稱"
        ''' <summary>
        ''' TABLE_NAME 表格名稱
        ''' </summary>
        Public Property TABLE_NAME() As String
            Get
                Return Me.ColumnyMap("TABLE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TABLE_NAME") = value
            End Set
        End Property
#End Region

#Region "TABLE_COMMENTS 表格說明"
        ''' <summary>
        ''' TABLE_COMMENTS 表格說明
        ''' </summary>
        Public Property TABLE_COMMENTS() As String
            Get
                Return Me.ColumnyMap("TABLE_COMMENTS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TABLE_COMMENTS") = value
            End Set
        End Property
#End Region

#Region "OWNER OWNER"
        ''' <summary>
        ''' OWNER OWNER
        ''' </summary>
        Public Property OWNER() As String
            Get
                Return Me.ColumnyMap("OWNER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OWNER") = value
            End Set
        End Property
#End Region

#Region "DB_TYPE 資料庫類型(Oracle / SQL)"
        ''' <summary>
        ''' DB_TYPE 資料庫類型
        ''' </summary>
        Public Property DB_TYPE() As String
            Get
                Return Me.ColumnyMap("DB_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DB_TYPE") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "GetDbTable 取得DBTable "
        ''' <summary>
        ''' 取得DBTable 
        ''' </summary>
        Public Function GetDbTable() As DataTable
            Return Me.GetDbTable(0, 0)
        End Function

        ''' <summary>
        ''' 取得DBTable
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDbTable(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.ConnName = Me.OWNER

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                Dim sql As String = ""

                If String.IsNullOrEmpty(Me.DB_TYPE) OrElse Me.DB_TYPE = "ORACLE" Then
                    sql = "SELECT DISTINCT TABLE_NAME,COMMENTS AS TABLE_COMMENTS FROM USER_TAB_COMMENTS WHERE 1 = 1 "
                    If Not String.IsNullOrEmpty(Me.TABLE_NAME) Then
                        sql = sql & " AND TABLE_NAME LIKE '" & Utility.DBStr(Me.TABLE_NAME) & "%'"
                    End If
                    If Not String.IsNullOrEmpty(Me.TABLE_COMMENTS) Then
                        sql = sql & " AND COMMENTS LIKE '%" & Utility.DBStr(Me.TABLE_COMMENTS) & "%'"
                    End If
                    sql = sql & " ORDER BY TABLE_NAME"
                Else
                    sql = "SELECT M.name AS TABLE_NAME,(select TOP 1 value As COMMENTS from ::fn_listextendedproperty(NULL, 'user', 'dbo', 'table', M.name , NULL, NULL)) AS TABLE_COMMENTS FROM sys.tables M WHERE 1 = 1 "
                    'WHERE schema_id = '" & Me.OWNER & "'"
                    If Not String.IsNullOrEmpty(Me.TABLE_NAME) Then
                        sql = sql & " AND M.name LIKE '" & Utility.DBStr(Me.TABLE_NAME) & "%'"
                    End If
                    sql = sql & " ORDER BY TABLE_NAME"

                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetFieldNoCommentTable 取得DBTable "
        ''' <summary>
        ''' 取得DBTable 
        ''' </summary>
        Public Function GetFieldNoCommentTable() As DataTable
            Return Me.GetFieldNoCommentTable(0, 0)
        End Function

        ''' <summary>
        ''' 取得DBTable
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetFieldNoCommentTable(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.ConnName = Me.OWNER

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                Dim sql As String = ""
                sql = "SELECT DISTINCT M.TABLE_NAME,R1.COMMENTS AS TABLE_COMMENTS FROM ALL_TAB_COLUMNS M "
                sql &= " LEFT OUTER JOIN ALL_COL_COMMENTS R1 ON R1.OWNER = M.OWNER AND R1.TABLE_NAME = M.TABLE_NAME AND R1.COLUMN_NAME = M.COLUMN_NAME "
                sql &= " WHERE 1 = 1 "
                sql &= " AND M.OWNER = '" & Me.OWNER & "' AND R1.COMMENTS IS NULL "
                If Not String.IsNullOrEmpty(Me.TABLE_NAME) Then
                    sql = sql & " AND M.TABLE_NAME LIKE '" & Utility.DBStr(Me.TABLE_NAME) & "%'"
                End If
                If Not String.IsNullOrEmpty(Me.TABLE_COMMENTS) Then
                    sql = sql & " AND R1.COMMENTS LIKE '%" & Utility.DBStr(Me.TABLE_COMMENTS) & "%'"
                End If
                sql = sql & " ORDER BY TABLE_NAME"

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetDBSchema 取得DBTableSchema "
        ''' <summary>
        ''' 取得DBTable
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDBSchema() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.ConnName = Me.OWNER

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim sql As String = ""

                If String.IsNullOrEmpty(Me.DB_TYPE) OrElse Me.DB_TYPE = "ORACLE" Then
                    sql = "SELECT M.COLUMN_NAME,M.CHAR_LENGTH,M.DATA_LENGTH,M.DATA_PRECISION,M.DATA_SCALE,M.DATA_TYPE,M.NULLABLE,R1.COMMENTS FROM ALL_TAB_COLUMNS M"
                    sql &= " LEFT OUTER JOIN ALL_COL_COMMENTS R1 ON R1.OWNER = M.OWNER AND R1.TABLE_NAME = M.TABLE_NAME AND R1.COLUMN_NAME = M.COLUMN_NAME"
                    sql &= " WHERE M.OWNER = '" & Me.OWNER & "' AND M.TABLE_NAME = '" & Me.TABLE_NAME & "' ORDER BY M.COLUMN_ID"
                Else
                    sql = "SELECT R1.NAME AS COLUMN_NAME,R1.MAX_LENGTH AS CHAR_LENGTH, "
                    sql &= "	R1.MAX_LENGTH AS DATA_LENGTH,R1.PRECISION AS DATA_PRECISION,R1.SCALE AS DATA_SCALE, "
                    sql &= "	UPPER(R2.NAME) AS DATA_TYPE,Case When R1.IS_NULLABLE = 'True' then 'Y' Else 'N' End AS NULLABLE,R3.VALUE AS COMMENTS "
                    sql &= " FROM SYS.TABLES M LEFT JOIN SYS.COLUMNS R1 ON R1.OBJECT_ID = M.OBJECT_ID "
                    sql &= "	LEFT JOIN SYS.TYPES R2 ON R2.USER_TYPE_ID = R1.USER_TYPE_ID  "
                    sql &= "    LEFT JOIN (select objname,value from ::fn_listextendedproperty(NULL, 'user', 'dbo', 'table',N'" & Me.TABLE_NAME & "', 'column', NULL) WHERE name = 'MS_Description') R3 ON (R3.objname collate Chinese_Taiwan_Stroke_CI_AS) = R1.NAME "
                    sql &= "	WHERE M.NAME = '" & Me.TABLE_NAME & "' ORDER BY R1.COLUMN_ID "
                End If

                Dim dt As DataTable = Me.QueryBySql(sql)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetDBTableIndex 取得GetDBTableIndex "
        ''' <summary>
        ''' 取得GetDBTableIndex
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDBTableIndex() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.ConnName = Me.OWNER

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim sql As String = ""
                If String.IsNullOrEmpty(Me.DB_TYPE) OrElse Me.DB_TYPE = "ORACLE" Then
                    sql = "SELECT INDEX_NAME, COLUMN_NAME, COLUMN_POSITION, DESCEND FROM DBA_IND_COLUMNS "
                    sql &= " WHERE TABLE_OWNER = '" & Me.OWNER & "' AND TABLE_NAME = '" & Me.TABLE_NAME & "'"
                Else
                    sql = " SELECT																											"
                    sql &= "     IND.NAME AS INDEX_NAME, COL.NAME AS COLUMN_NAME, IC.INDEX_COLUMN_ID AS COLUMN_POSITION,'ASC' AS DESCEND    "
                    sql &= " FROM                                                                                                           "
                    sql &= "     SYS.INDEXES IND                                                                                            "
                    sql &= " INNER JOIN                                                                                                     "
                    sql &= "     SYS.INDEX_COLUMNS IC ON                                                                                    "
                    sql &= "       IND.OBJECT_ID = IC.OBJECT_ID AND IND.INDEX_ID = IC.INDEX_ID                                              "
                    sql &= " INNER JOIN                                                                                                     "
                    sql &= "     SYS.COLUMNS COL ON                                                                                         "
                    sql &= "       IC.OBJECT_ID = COL.OBJECT_ID AND IC.COLUMN_ID = COL.COLUMN_ID                                            "
                    sql &= " INNER JOIN                                                                                                     "
                    sql &= "     SYS.TABLES T ON                                                                                            "
                    sql &= "       IND.OBJECT_ID = T.OBJECT_ID                                                                              "
                    sql &= " WHERE                                                                                                          "
                    sql &= "      T.NAME = '" & Me.TABLE_NAME & "'                                                                                 "
                    sql &= " ORDER BY                                                                                                       "
                    sql &= "     T.NAME, IND.NAME, IND.INDEX_ID, IC.INDEX_COLUMN_ID                                                         "
                End If

                Dim dt As DataTable = Me.QueryBySql(sql)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetDBTableComments 取得GetDBTableComments "
        ''' <summary>
        ''' 取得GetDBTableComments
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDBTableComments() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.ConnName = Me.OWNER

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                Dim sql As String = ""

                If String.IsNullOrEmpty(Me.DB_TYPE) OrElse Me.DB_TYPE = "ORACLE" Then
                    sql = "SELECT COMMENTS FROM USER_TAB_COMMENTS "
                    sql &= " WHERE TABLE_NAME = '" & Me.TABLE_NAME & "'"
                Else
                    sql = "select TOP 1 value As COMMENTS from ::fn_listextendedproperty(NULL, 'user', 'dbo', 'table',N'" & Me.TABLE_NAME & "', NULL, NULL) "
                End If

                Dim dt As DataTable = Me.QueryBySql(sql)

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


