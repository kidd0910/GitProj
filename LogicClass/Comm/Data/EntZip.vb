'----------------------------------------------------------------------------------
'File Name		: EntZip 郵遞區號
'Author			: Ethan
'Description		: EntZip 郵遞區號 ENT
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
    '' EntZip 郵遞區號 ENT
    '' </summary>
    Public Class EntZip
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
            Me.TableName = "COMC020"
            Me.SysName = "common"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "CODE 代碼"
        ''' <summary>
        ''' CODE 代碼
        ''' </summary>
        Public Property CODE() As String
            Get
                Return Me.ColumnyMap("CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE") = value
            End Set
        End Property
#End Region

#Region "CODE_NAME 代碼名稱"
        ''' <summary>
        ''' CODE_NAME 代碼名稱
        ''' </summary>
        Public Property CODE_NAME() As String
            Get
                Return Me.ColumnyMap("CODE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE_NAME") = value
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

#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace
