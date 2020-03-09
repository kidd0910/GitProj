'----------------------------------------------------------------------------------
'File Name		: SYSC001
'Author			: Sylvia
'Description		: SYSC001 系統下拉選單代碼維護
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/10/20	Sylvia		Source Create
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
    ' SYSC001 系統下拉選單代碼維護
    ' </summary>
    Public Class ENT_SYSC001
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
            Me.TableName = "SYSC001"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CODE_TYPE,CODE_NAME,ITEM_TYPE,ITEM_NAME,IS_USE,SORT,REMARK"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CODE_TYPE 類別代碼"
        '' <summary>
        '' CODE_TYPE 類別代碼
        '' </summary>
        Public Property CODE_TYPE() As String
            Get
                Return Me.ColumnyMap("CODE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE_TYPE") = value
            End Set
        End Property
#End Region

#Region "CODE_NAME 類別名稱"
        '' <summary>
        '' CODE_NAME 類別名稱
        '' </summary>
        Public Property CODE_NAME() As String
            Get
                Return Me.ColumnyMap("CODE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE_NAME") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE 項目代碼"
        '' <summary>
        '' ITEM_TYPE 項目代碼
        '' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.ColumnyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM_TYPE") = value
            End Set
        End Property
#End Region

#Region "ITEM_NAME 項目名稱"
        '' <summary>
        '' ITEM_NAME 項目名稱
        '' </summary>
        Public Property ITEM_NAME() As String
            Get
                Return Me.ColumnyMap("ITEM_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ITEM_NAME") = value
            End Set
        End Property
#End Region

#Region "IS_USE 是否使用(Y-啟用，N-不啟用)"
        '' <summary>
        '' IS_USE 是否使用(Y-啟用，N-不啟用)
        '' </summary>
        Public Property IS_USE() As String
            Get
                Return Me.ColumnyMap("IS_USE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_USE") = value
            End Set
        End Property
#End Region

#Region "SORT 排序"
        '' <summary>
        '' SORT 排序
        '' </summary>
        Public Property SORT() As String
            Get
                Return Me.ColumnyMap("SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SORT") = value
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



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        '' <summary>
        '' 查詢 
        '' </summary>
        '' <remarks>
        '' 0.0.1 Sylvia 新增方法
        '' </remarks>
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
                Me.TableCoumnInfo.Add(New String() {"SYSC001", "M", "ITEM_NAME", "CODE_TYPE", "ITEM_TYPE", "IS_USE", "PKNO"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                sql.AppendLine(" FROM SYSC001 M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CAST(M.SORT AS INT) ")
                    Else
                        sql.AppendLine(" ORDER BY CAST(M.SORT AS INT) ")
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

        Public Function QueryCodeType() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT DISTINCT M.CODE_TYPE ,M.CODE_TYPE+'-'+M.CODE_NAME AS CODE_NAME ")
                sql.AppendLine(" FROM SYSC001 M ")
                sql.AppendLine(" ORDER BY M.CODE_TYPE ")

                'sql.Append("
                '    SELECT DISTINCT M.CODE_TYPE ,M.CODE_TYPE+'-'+M.CODE_NAME AS CODE_NAME
                '    FROM SYSC001 M
                '    ORDER BY M.CODE_TYPE
                '")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function QueryItemType(ByVal codeType As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT ITEM_TYPE ,ITEM_TYPE+'-'+ITEM_NAME AS ITEM_NAME ")
                sql.AppendLine(" FROM SYSC001 ")

                If Not String.IsNullOrEmpty(codeType) Then
                    sql.AppendLine(" WHERE CODE_TYPE = " & codeType)
                Else
                    sql.AppendLine(" WHERE 1 = 2")
                End If

                If Not String.IsNullOrEmpty(Me.OrderBys) Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#End Region



    End Class
End Namespace


