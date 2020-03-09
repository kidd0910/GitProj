'----------------------------------------------------------------------------------
'File Name		: EntMaxNo
'Author			: Ethan
'Description		: EntMaxNo 最大號ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/09/16	Ethan		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Max.Data
    '' <summary>
    '' EntMaxNo 最大號ENT
    '' </summary>
    Public Class EntMaxNo
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
            Me.TableName = "MAXC010"
            Me.SysName = "MAX"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "ASSORTMENT_CODE 分類代碼"
        ''' <summary>
        ''' ASSORTMENT_CODE 分類代碼
        ''' </summary>
        Public Property ASSORTMENT_CODE() As String
            Get
                Return Me.ColumnyMap("ASSORTMENT_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ASSORTMENT_CODE") = value
            End Set
        End Property
#End Region

#Region "COND_CHARA 條件字串"
        ''' <summary>
        ''' COND_CHARA 條件字串
        ''' </summary>
        Public Property COND_CHARA() As String
            Get
                Return Me.ColumnyMap("COND_CHARA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COND_CHARA") = value
            End Set
        End Property
#End Region

#Region "SEQUENCE_NO_LEN 流水號碼長度"
        ''' <summary>
        ''' SEQUENCE_NO_LEN 流水號碼長度
        ''' </summary>
        Public Property SEQUENCE_NO_LEN() As String
            Get
                Return Me.ColumnyMap("SEQUENCE_NO_LEN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SEQUENCE_NO_LEN") = value
            End Set
        End Property
#End Region

#Region "SYS_CODE 系統代碼"
        ''' <summary>
        ''' SYS_CODE 系統代碼
        ''' </summary>
        Public Property SYS_CODE() As String
            Get
                Return Me.ColumnyMap("SYS_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CODE") = value
            End Set
        End Property
#End Region

#Region "USE_MAX_NO 使用最大號碼"
        ''' <summary>
        ''' USE_MAX_NO 使用最大號碼
        ''' </summary>
        Public Property USE_MAX_NO() As String
            Get
                Return Me.ColumnyMap("USE_MAX_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_MAX_NO") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#Region "GetLastNoFromEnt 取得最後使用號碼 "
        ''' <summary>
        ''' 取得最後使用號碼 
        ''' </summary>
        Public Function GetLastNoFromEnt() As Integer
            Return Me.GetLastNoFromEnt(0, 0)
        End Function

        ''' <summary>
        ''' 取得最後使用號碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetLastNoFromEnt(ByVal pageNo As Integer, ByVal pageSize As Integer) As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.QUERY_COND) Then
                '    faileArguments.Add("QUERY_COND")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'select  USE_MAX_NO(使用最大號碼)  from   MAXC010
                ' 
                'QUERY_COND(查詢條件)

                Dim sql As String = "SELECT USE_MAX_NO FROM MAXC010 "

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql &= "WHERE " & Me.SqlRetrictions.Replace("$.", "")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Dim intNo As Integer = 0

                If dt.Rows.Count > 0 Then
                    intNo = CInt(dt.Rows(0).Item("USE_MAX_NO").ToString)
                End If

                Me.ResetColumnProperty()

                Return intNo
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetNewNoFromEnt 取得最後使用號碼 "
        ''' <summary>
        ''' 取得最後使用號碼 
        ''' </summary>
        Public Function GetNewNoFromEnt() As Integer
            Return Me.GetNewNoFromEnt(0, 0)
        End Function

        ''' <summary>
        ''' 取得最後使用號碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetNewNoFromEnt(ByVal pageNo As Integer, ByVal pageSize As Integer) As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.QUERY_COND) Then
                '    faileArguments.Add("QUERY_COND")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'select  USE_MAX_NO(使用最大號碼)  from   MAXC010
                ' 
                'QUERY_COND(查詢條件)

                'retun + 1

                Dim sql As String = "SELECT USE_MAX_NO FROM MAXC010 "

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql &= "WHERE " & Me.SqlRetrictions
                End If

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Dim intNo As Integer = 0

                If dt.Rows.Count > 0 Then
                    intNo = CInt(dt.Rows(0).Item("USE_MAX_NO").ToString) + 1
                Else
                    intNo += 1
                End If

                Me.ResetColumnProperty()

                Return intNo
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Null 相關"
        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "SEQUENCE_NO_LEN,USE_MAX_NO"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "SEQUENCE_NO_LEN,USE_MAX_NO"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "SEQUENCE_NO_LEN,USE_MAX_NO"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


#End Region

    End Class
End Namespace
