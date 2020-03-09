'----------------------------------------------------------------------------------
'File Name		: APP1050
'Author			: TIM
'Description		: APP1050 申設_品管/客服人員資料
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/27	TIM		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APP1050 申設_品管/客服人員資料
    ' </summary>
    Public Class ENT_APP1050
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
            Me.TableName = "APP1050"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,CODE_TYPE,PTTCH_FT,CH_NAME,JOBTITLE,IS_CAREER_SHAR,CAREER_SHAR_NAME"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
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

#Region "CODE_TYPE 類別(1.品管,2.客服)"
        '' <summary>
        '' CODE_TYPE 類別(1.品管,2.客服)
        '' </summary>
        Public Property CODE_TYPE() As String
            Get
                Return Me.ColumnyMap("CODE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CODE_TYPE") = value
            End Set
        End Property
#End Region

#Region "PTTCH_FT 專兼職(1.專職，2.兼職)"
        '' <summary>
        '' PTTCH_FT 專兼職(1.專職，2.兼職)
        '' </summary>
        Public Property PTTCH_FT() As String
            Get
                Return Me.ColumnyMap("PTTCH_FT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PTTCH_FT") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 姓名"
        '' <summary>
        '' CH_NAME 姓名
        '' </summary>
        Public Property CH_NAME() As String
            Get
                Return Me.ColumnyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "JOBTITLE 職稱"
        '' <summary>
        '' JOBTITLE 職稱
        '' </summary>
        Public Property JOBTITLE() As String
            Get
                Return Me.ColumnyMap("JOBTITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JOBTITLE") = value
            End Set
        End Property
#End Region

#Region "IS_CAREER_SHAR 是否與其他事業共用(Y.是，N.否)"
        '' <summary>
        '' IS_CAREER_SHAR 是否與其他事業共用(Y.是，N.否)
        '' </summary>
        Public Property IS_CAREER_SHAR() As String
            Get
                Return Me.ColumnyMap("IS_CAREER_SHAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_CAREER_SHAR") = value
            End Set
        End Property
#End Region

#Region "CAREER_SHAR_NAME 事業共用名稱"
        '' <summary>
        '' CAREER_SHAR_NAME 事業共用名稱
        '' </summary>
        Public Property CAREER_SHAR_NAME() As String
            Get
                Return Me.ColumnyMap("CAREER_SHAR_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CAREER_SHAR_NAME") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "

        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function


        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名 ===
                'Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
                'Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT *, CASE IS_CAREER_SHAR  WHEN 'Y' THEN '是' WHEN 'N' THEN '否'  END AS IS_CAREER_SHAR_TXT ,")
                sql.AppendLine(" CASE PTTCH_FT  WHEN '1' THEN '專職' WHEN '2' THEN '兼職'  END AS PTTCH_FT_TXT ")
                sql.AppendLine(" FROM APP1050 ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString.Replace("$.", ""), pageNo, pageSize)

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

