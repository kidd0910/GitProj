Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP2020 諮詢委員會議成員
    ' </summary>
    Public Class ENT_APPL025
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
            Me.TableName = "APPL025"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = ""
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"

#Region "CASE_NO"
        '' <summary>
        '' CASE_NO
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ"
        '' <summary>
        '' CASE_SEQ
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.ColumnyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region


#Region "OTHER_UNIT_DESC"
        '' <summary>
        '' OTHER_UNIT_DESC
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.ColumnyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region

#Region "CREATE_USER 資料建立者"
        '' <summary>
        '' CREATE_USER 資料建立者
        '' </summary>
        Public Property CREATE_USER() As String
            Get
                Return Me.ColumnyMap("CREATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_USER") = value
            End Set
        End Property
#End Region

#Region "CREATE_DATE 資料建立日期"
        '' <summary>
        '' CREATE_DATE 資料建立日期
        '' </summary>
        Public Property CREATE_DATE() As String
            Get
                Return Me.ColumnyMap("CREATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_DATE") = value
            End Set
        End Property
#End Region

#Region "UPDATE_USER 資料維護者"
        '' <summary>
        '' UPDATE_USER 資料維護者
        '' </summary>
        Public Property UPDATE_USER() As String
            Get
                Return Me.ColumnyMap("UPDATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_USER") = value
            End Set
        End Property
#End Region

#Region "UPDATE_DATE 資料維護日期"
        '' <summary>
        '' UPDATE_DATE 資料維護日期
        '' </summary>
        Public Property UPDATE_DATE() As String
            Get
                Return Me.ColumnyMap("UPDATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_DATE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#End Region


    End Class
End Namespace



