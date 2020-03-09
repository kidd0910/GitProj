'----------------------------------------------------------------------------------
'File Name		: EntCityType
'Author			: Ethan
'Description		: EntCityType 縣市類別ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/11/11	Ethan		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Comm.Data
    '' <summary>
    '' EntCityType 縣市類別ENT
    '' </summary>
    Public Class EntCityType
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
            Me.TableName = "COMC010"
            Me.SysName = "common"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===
            Me.EntZip = New EntZip(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "EntZip 郵遞區號 ENT"
        ''' <summary>
        ''' EntZip_郵遞區號 ENT
        ''' </summary>
        Public Property EntZip() As EntZip
            Get
                Return Me.PropertyMap("EntZip")
            End Get
            Set(ByVal value As EntZip)
                Me.PropertyMap("EntZip") = value
            End Set
        End Property
#End Region

#Region "TYPE_CODE 類別代碼"
        ''' <summary>
        ''' TYPE_CODE 類別代碼
        ''' </summary>
        Public Property TYPE_CODE() As String
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
        Public Property TYPE_NAME() As String
            Get
                Return Me.ColumnyMap("TYPE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TYPE_NAME") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#Region "GetCityDDL 縣市下拉 "
        ''' <summary>
        ''' 縣市下拉 
        ''' </summary>
        Public Function GetCityDDL() As DataTable
            Return Me.GetCityDDL(0, 0)
        End Function

        ''' <summary>
        ''' 縣市下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetCityDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                '這是一個下拉選單
                '
                '使用table COMC010

                Dim sql As String = "SELECT TYPE_CODE AS SELECT_VALUE,TYPE_NAME AS SELECT_TEXT FROM COMC010"

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetZip 取得郵遞區號 "
        ''' <summary>
        ''' 取得郵遞區號 
        ''' </summary>
        Public Function GetZip() As DataTable
            Return Me.GetZip(0, 0)
        End Function

        ''' <summary>
        ''' 取得郵遞區號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetZip(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'EntZip.Query()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetZipDDL 郵遞區號下拉 "
        ''' <summary>
        ''' 郵遞區號下拉 
        ''' </summary>
        Public Function GetZipDDL() As DataTable
            Return Me.GetZipDDL(0, 0)
        End Function

        ''' <summary>
        ''' 郵遞區號下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetZipDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                'Me.ParserAlias()

                '=== 處理說明 ===
                '這是一個下拉選單
                '
                '使用table COMC020

                Dim sql As String = "SELECT CODE AS SELECT_VALUE,CODE + '-' + CODE_NAME AS SELECT_TEXT FROM COMC020 WHERE 1=1 "

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    Me.SqlRetrictions = Me.SqlRetrictions.Replace("$.", "")
                    sql &= Me.SqlRetrictions
                End If
                sql &= "  ORDER BY  CODE"

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

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
