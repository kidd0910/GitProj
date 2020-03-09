'----------------------------------------------------------------------------------
'File Name		: EntInnerNetWKAddr
'Author			: 
'Description		: EntInnerNetWKAddr 內部網路位址ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/16			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Aut.Data
    '' <summary>
    '' EntInnerNetWKAddr 內部網路位址ENT
    '' </summary>
    Public Class EntInnerNetWKAddr
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
            Me.TableName = "AUTC110"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "NETWK_ADDR_1 網路位址1"
        ''' <summary>
        ''' NETWK_ADDR_1 網路位址1
        ''' </summary>
        Public Property NETWK_ADDR_1() As String
            Get
                Return Me.PropertyMap("NETWK_ADDR_1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NETWK_ADDR_1") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_2 網路位址2"
        ''' <summary>
        ''' NETWK_ADDR_2 網路位址2
        ''' </summary>
        Public Property NETWK_ADDR_2() As String
            Get
                Return Me.PropertyMap("NETWK_ADDR_2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NETWK_ADDR_2") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_3 網路位址3"
        ''' <summary>
        ''' NETWK_ADDR_3 網路位址3
        ''' </summary>
        Public Property NETWK_ADDR_3() As String
            Get
                Return Me.PropertyMap("NETWK_ADDR_3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NETWK_ADDR_3") = value
            End Set
        End Property
#End Region

#Region "NETWK_ADDR_4 網路位址4"
        ''' <summary>
        ''' NETWK_ADDR_4 網路位址4
        ''' </summary>
        Public Property NETWK_ADDR_4() As String
            Get
                Return Me.PropertyMap("NETWK_ADDR_4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NETWK_ADDR_4") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "IsInnerNetWK 是否內網 "
        ''' <summary>
        ''' 是否內網 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function IsInnerNetWK() As Boolean
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim Sql As String = _
                "SELECT *  " & _
                "FROM AUTC110 " & _
                "WHERE '" & Me.NETWK_ADDR_1 & "' BETWEEN NETWK_ADDR_S_1 AND NETWK_ADDR_E_1  " & _
                "AND '" & Me.NETWK_ADDR_2 & "' BETWEEN NETWK_ADDR_S_2 AND NETWK_ADDR_E_2  " & _
                "AND '" & Me.NETWK_ADDR_3 & "' BETWEEN NETWK_ADDR_S_3 AND NETWK_ADDR_E_3  " & _
                "AND '" & Me.NETWK_ADDR_4 & "' BETWEEN NETWK_ADDR_S_4 AND NETWK_ADDR_E_4  "
                Dim dt As DataTable = Me.QueryBySql(Sql)

                Dim result As Boolean

                If dt.Rows.Count > 0 Then
                    result = True
                Else
                    result = False
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace