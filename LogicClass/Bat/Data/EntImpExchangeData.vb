'----------------------------------------------------------------------------------
'File Name		: EntImpExchangeData
'Author			: 
'Description		: EntImpExchangeData 設定交換資料ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2010/11/13			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Bat.Data
    '' <summary>
    '' EntImpExchangeData 設定交換資料ENT
    '' </summary>
    Public Class EntImpExchangeData
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
            Me.TableName = "BATT070"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "FILE_NAME 檔案名稱"
        ''' <summary>
        ''' FILE_NAME 檔案名稱
        ''' </summary>
        Public Property FILE_NAME As String
            Get
                Return Me.ColumnyMap("FILE_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_NAME") = value
            End Set
        End Property
#End Region

#Region "EXE_RES 執行結果"
        ''' <summary>
        ''' EXE_RES 執行結果
        ''' </summary>
        Public Property EXE_RES As String
            Get
                Return Me.ColumnyMap("EXE_RES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_RES") = value
            End Set
        End Property
#End Region

#Region "RES_CONTENT 結果內容"
        ''' <summary>
        ''' RES_CONTENT 結果內容
        ''' </summary>
        Public Property RES_CONTENT As String
            Get
                Return Me.ColumnyMap("RES_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RES_CONTENT") = value
            End Set
        End Property
#End Region

#Region "UNUSUAL_RECORD_FILE 異常記錄檔路徑"
        ''' <summary>
        ''' UNUSUAL_RECORD_FILE 異常記錄檔路徑
        ''' </summary>
        Public Property UNUSUAL_RECORD_FILE As String
            Get
                Return Me.ColumnyMap("UNUSUAL_RECORD_FILE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNUSUAL_RECORD_FILE") = value
            End Set
        End Property
#End Region

#Region "EXE_TIME 執行時間"
        ''' <summary>
        ''' EXE_TIME 執行時間
        ''' </summary>
        Public Property EXE_TIME As String
            Get
                Return Me.ColumnyMap("EXE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_TIME") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace
 
