
Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data

    Partial Public Class ENT_APP0002
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
            Me.TableName = "APP0002"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            'Me.LONG_FIELD_NAME = "DESC1,DESC2"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region


#Region "屬性"

#Region "CASE_CODE"
        '' <summary>
        '' CASE_CODE 案號前四碼
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.PropertyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "TAB_FILE"
        '' <summary>
        '' TAB_FILE 程式代碼
        '' </summary>
        Public Property TAB_FILE() As String
            Get
                Return Me.PropertyMap("TAB_FILE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TAB_FILE") = value
            End Set
        End Property
#End Region


#Region "QNO"
        '' <summary>
        '' QNO 題目代號
        '' </summary>
        Public Property QNO() As String
            Get
                Return Me.PropertyMap("QNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO") = value
            End Set
        End Property
#End Region

#Region "QNO_DESC"
        '' <summary>
        '' QNO_DESC 題目內容
        '' </summary>
        Public Property QNO_DESC() As String
            Get
                Return Me.PropertyMap("QNO_DESC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QNO_DESC") = value
            End Set
        End Property
#End Region

#Region "PKNO"
        '' <summary>
        '' PKNO
        '' </summary>
        Public Property PKNO() As String
            Get
                Return Me.PropertyMap("PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PKNO") = value
            End Set
        End Property
#End Region
#End Region

    End Class
End Namespace