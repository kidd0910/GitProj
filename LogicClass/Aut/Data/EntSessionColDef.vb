'----------------------------------------------------------------------------------
'File Name		: EntSessionColDef
'Author			: Shanlee
'Description		: EntSessionColDef Session欄位定義ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/06/10	Shanlee		Source Create
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
    '' EntSessionColDef Session欄位定義ENT
    '' </summary>
    Public Class EntSessionColDef
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
            Me.TableName = "AUTC100"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "DATA_FIELD 資料欄位"
        ''' <summary>
        ''' DATA_FIELD 資料欄位
        ''' </summary>
        Public Property DATA_FIELD() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_ENG 資料欄位英文名稱"
        ''' <summary>
        ''' DATA_FIELD_ENG 資料欄位英文名稱
        ''' </summary>
        Public Property DATA_FIELD_ENG() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_ENG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_ENG") = value
            End Set
        End Property
#End Region

#Region "DATA_FIELD_TYPE 資料欄位類別"
        ''' <summary>
        ''' DATA_FIELD_TYPE 資料欄位類別
        ''' </summary>
        Public Property DATA_FIELD_TYPE() As String
            Get
                Return Me.ColumnyMap("DATA_FIELD_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DATA_FIELD_TYPE") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace

