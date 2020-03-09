'----------------------------------------------------------------------------------
'File Name		: EntPasswordHis
'Author			: 
'Description		: EntPasswordHis 密碼歷史檔ENT
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
    '' EntPasswordHis 密碼歷史檔ENT
    '' </summary>
    Public Class EntPasswordHis
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
            Me.TableName = "POSH010"
            Me.SysName = "POS"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "PERSON_TYPE 人員類別"
        ''' <summary>
        ''' PERSON_TYPE 人員類別
        ''' </summary>
        Public Property PERSON_TYPE As String
            Get
                Return Me.ColumnyMap("PERSON_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PERSON_TYPE") = value
            End Set
        End Property
#End Region

#Region "PW 密碼"
        ''' <summary>
        ''' PW 密碼
        ''' </summary>
        Public Property PW As String
            Get
                Return Me.ColumnyMap("PW")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PW") = value
            End Set
        End Property
#End Region

#Region "PW_UPD_DATE 密碼修改日期"
        ''' <summary>
        ''' PW_UPD_DATE 密碼修改日期
        ''' </summary>
        Public Property PW_UPD_DATE As String
            Get
                Return Me.ColumnyMap("PW_UPD_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PW_UPD_DATE") = value
            End Set
        End Property
#End Region


#End Region

#Region "自訂方法"

#End Region

    End Class
End Namespace

