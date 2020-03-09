'----------------------------------------------------------------------------------
'File Name		: EntPOSCode
'Author			: 
'Description		: EntPOSCode 人員代碼檔
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/08/27			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Pos.Data
    '' <summary>
    '' EntPOSCode 人員代碼檔
    '' </summary>
    Public Class EntPOSCode
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
            Me.TableName = "POSC010"
            Me.SysName = "POS"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "NO 號碼"
        ''' <summary>
        ''' NO 號碼
        ''' </summary>
        Public Property NO As String
            Get
                Return Me.ColumnyMap("NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NO") = value
            End Set
        End Property
#End Region

#Region "NO_NAME 號碼名稱"
        ''' <summary>
        ''' NO_NAME 號碼名稱
        ''' </summary>
        Public Property NO_NAME As String
            Get
                Return Me.ColumnyMap("NO_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NO_NAME") = value
            End Set
        End Property
#End Region

#Region "NO_SEQ 號碼排序"
        ''' <summary>
        ''' NO_SEQ 號碼排序
        ''' </summary>
        Public Property NO_SEQ As String
            Get
                Return Me.ColumnyMap("NO_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NO_SEQ") = value
            End Set
        End Property
#End Region

#Region "TYPE_CODE 類別代碼"
        ''' <summary>
        ''' TYPE_CODE 類別代碼
        ''' </summary>
        Public Property TYPE_CODE As String
            Get
                Return Me.ColumnyMap("TYPE_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TYPE_CODE") = value
            End Set
        End Property
#End Region

#Region "TYPE_NAME 類別名稱"
        ''' <summary>
        ''' TYPE_NAME 類別名稱
        ''' </summary>
        Public Property TYPE_NAME As String
            Get
                Return Me.ColumnyMap("TYPE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TYPE_NAME") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Property USE_STATE As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"
#Region "GetPOSCodeData 取得人員代碼資料 "
        ''' <summary>
        ''' 取得人員代碼資料 
        ''' </summary>
        Public Function GetPOSCodeData() As DataTable
            Return Me.GetPOSCodeData(0, 0)
        End Function

        ''' <summary>
        ''' 取得人員代碼資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetPOSCodeData(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'SELECT * FROM POSC010 WHERE PKNO=QUERY_COND(查詢條件) AND TYPE_CODE(類別代碼)=QUERY_COND(查詢條件) AND NO(號碼)=QUERY_COND(查詢條件) AND USE_STATE(使用狀態)
                'ORDER BY  TYPE_CODE(類別代碼),NO(號碼),NO_SEQ(號碼排序)
                '=== 處理別名 ===
                Me.TableCoumnInfo.Add(New String() {"POSC010", "M", "PKNO", "TYPE_CODE", "NO", "USE_STATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, M.NO AS SELECT_VALUE, M.NO_NAME AS SELECT_TEXT ")
                sql.AppendLine(" FROM POSC010 M WITH (NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.TYPE_CODE, M.NO, M.NO_SEQ ")
                    Else
                        sql.AppendLine(" ORDER BY TYPE_CODE, NO, NO_SEQ ")
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

#Region "GetDepCodeDDL 取得單位代碼下拉 "
        ''' <summary>
        ''' 取得單位代碼下拉 
        ''' </summary>
        Public Function GetDepCodeDDL() As DataTable
            Return Me.GetDepCodeDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得單位代碼下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDepCodeDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'SELECT PERSON_TYPE(人員類別),DEP_CODE(單位代碼),DEP_NAME(單位名稱) FROM 
                '(SELECT '0' AS PERSON_TYPE(人員類別),NO AS DEP_CODE(單位代碼),NO_NAME AS DEP_NAME(單位名稱),NO_SEQ,'' AS SEQ FROM POSC010 WHERE TYPE_CODE(類別代碼)='0001' AND USE_STATE(使用狀態)=QUERY_COND(查詢條件) 
                'UNION
                'SELECT '1',PKNO AS NO,COM_CNAM AS NO_NAME,NULL,PKNO FROM APPL010 WHERE USE_STATE(使用狀態)=QUERY_COND(查詢條件)) 
                'WHERE PERSON_TYPE(人員類別)=QUERY_COND(查詢條件) AND DEP_CODE(單位代碼)=QUERY_COND(查詢條件)
                'ORDER BY  PERSON_TYPE(人員類別),NO_SEQ,SEQ

                '=== 處理別名 ===
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.PERSON_TYPE, M.DEP_CODE, M.DEP_NAME ")
                sql.AppendLine(" FROM ")
                sql.AppendLine(" ( ")
                sql.AppendLine(" SELECT COM_TYPE AS PERSON_TYPE, PKNO AS DEP_CODE, COM_CNAM AS DEP_NAME, NULL AS NO_SEQ, PKNO AS SEQ, USE_STATE  FROM APPL010  M WITH (NOLOCK) ")
                sql.AppendLine(" ) M ")
                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", "M."))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PERSON_TYPE, M.NO_SEQ, M.SEQ ")
                    Else
                        sql.AppendLine(" ORDER BY PERSON_TYPE, NO_SEQ, SEQ ")
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


#End Region

    End Class
End Namespace

