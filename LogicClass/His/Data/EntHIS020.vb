'----------------------------------------------------------------------------------
'File Name		: HIS020
'Author			: Becky
'Description		: HIS020 操作紀錄
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2016/12/27	Becky		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace His.Data
    ' <summary>
    ' HIS020 操作紀錄
    ' </summary>
    Public Class ENT_HIS020
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
            Me.TableName = "HIS020"
            Me.SysName = "HIS"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "OP_USER,OP_DESC"
            Me.SET_NULL_FIELD = "OP_DATETIME"
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO CASE_NO"
        '' <summary>
        '' CASE_NO CASE_NO
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

#Region "OP_DESC OP_DESC"
        '' <summary>
        '' OP_DESC OP_DESC
        '' </summary>
        Public Property OP_DESC() As String
            Get
                Return Me.ColumnyMap("OP_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OP_DESC") = value
            End Set
        End Property
#End Region

#Region "新增"
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                ''=== 檢核欄位起始 ===
                'Dim faileArguments As ArrayList = New ArrayList()

                'If faileArguments.Count > 0 Then
                '    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                'End If
                ''=== 檢核欄位結束 ===

                Dim sql As New StringBuilder
                Dim sql_H As New StringBuilder
                Dim sql_COL As New StringBuilder
                Dim sql_VAL As New StringBuilder
                sql_H.AppendLine(" INSERT INTO HIS020 (")
                sql_COL.AppendLine(" CASE_NO,OTHER_UNIT_DESC,CREATE_USER,CREATE_TIME) ")
                sql_VAL.AppendLine(" VALUES('" + Me.CASE_NO + "','" + Me.OTHER_UNIT_DESC + "','" + SessionClass.登入帳號 + "','" + DateUtil.GetNowDateTime + "')")

                sql.Append(sql_H)
                sql.Append(sql_COL)
                sql.Append(sql_VAL)

                Dim result As Integer = 0
                result = Me.Execute(sql.ToString)

                Return result.ToString

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace


