'----------------------------------------------------------------------------------
'File Name		: EntSetExchangeData
'Author			: 
'Description		: EntSetExchangeData 設定交換資料ENT
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
    '' EntSetExchangeData 設定交換資料ENT
    '' </summary>
    Public Class EntSetExchangeData
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
            Me.TableName = "BATT060"
            Me.SysName = "BAT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "BATCH_JOB_SEQ 批次工作序號"
        ''' <summary>
        ''' BATCH_JOB_SEQ 批次工作序號
        ''' </summary>
        Public Property BATCH_JOB_SEQ() As String
            Get
                Return Me.ColumnyMap("BATCH_JOB_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BATCH_JOB_SEQ") = value
            End Set
        End Property
#End Region

#Region "EXE_TIME 執行時間"
        ''' <summary>
        ''' EXE_TIME 執行時間
        ''' </summary>
        Public Property EXE_TIME() As String
            Get
                Return Me.ColumnyMap("EXE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_TIME") = value
            End Set
        End Property
#End Region

#Region "EXE_TYPE 執行種類"
        ''' <summary>
        ''' EXE_TYPE 執行種類
        ''' </summary>
        Public Property EXE_TYPE() As String
            Get
                Return Me.ColumnyMap("EXE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EXE_TYPE") = value
            End Set
        End Property
#End Region

#Region "INFO_CONTENT 訊息內容"
        ''' <summary>
        ''' INFO_CONTENT 訊息內容
        ''' </summary>
        Public Property INFO_CONTENT() As String
            Get
                Return Me.ColumnyMap("INFO_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INFO_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_EXE 是否執行"
        ''' <summary>
        ''' IS_EXE 是否執行
        ''' </summary>
        Public Property IS_EXE() As String
            Get
                Return Me.ColumnyMap("IS_EXE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_EXE") = value
            End Set
        End Property
#End Region

#Region "PROGRAM_CODE 程式代碼"
        ''' <summary>
        ''' PROGRAM_CODE 程式代碼
        ''' </summary>
        Public Property PROGRAM_CODE() As String
            Get
                Return Me.ColumnyMap("PROGRAM_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROGRAM_CODE") = value
            End Set
        End Property
#End Region

#Region "SQL_VALUE SQL值"
        ''' <summary>
        ''' SQL_VALUE SQL值
        ''' </summary>
        Public Property SQL_VALUE() As String
            Get
                Return Me.ColumnyMap("SQL_VALUE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SQL_VALUE") = value
            End Set
        End Property
#End Region

#Region "TABLE_NM 表格名稱"
        ''' <summary>
        ''' TABLE_NM 表格名稱
        ''' </summary>
        Public Property TABLE_NM() As String
            Get
                Return Me.ColumnyMap("TABLE_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TABLE_NM") = value
            End Set
        End Property
#End Region

#Region "OUT_TYPE 轉出種類"
        ''' <summary>
        ''' OUT_TYPE 轉出種類(1-學網,2-軍網,3-軍外網)
        ''' </summary>
        Public Property OUT_TYPE() As String
            Get
                Return Me.ColumnyMap("OUT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OUT_TYPE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace
 
