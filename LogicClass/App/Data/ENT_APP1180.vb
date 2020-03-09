'----------------------------------------------------------------------------------
'File Name		: APP1180
'Author			:  
'Description		: APP1180 上架統計表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/18	 		Source Create
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
    ' APP1180 上架統計表
    ' </summary>
    Public Class ENT_APP1180
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
            Me.TableName = "APP1180"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,ANALOGY_CHANNEL_LOCATION,DIGIT_CHANNEL_LOCATION,CHANNEL_LOCATION"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號, 共用"
        '' <summary>
        '' CASE_NO 案件編號, 共用
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

#Region "CHSYS_TYPE 系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星"
        '' <summary>
        '' CHSYS_TYPE 系統類型, 新增時系統寫入, 共用, 修改時不處理，1：有線廣播電視系統, 2：其他供公眾收視聽之播送平臺, 3：直播衛星
        '' </summary>
        Public Property CHSYS_TYPE() As String
            Get
                Return Me.ColumnyMap("CHSYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHSYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYSTEM_OPERATOR 有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'"
        '' <summary>
        '' SYSTEM_OPERATOR 有線電視公司/播送系統/直播衛星電視業者, 共用, REF. SYST010.SYS_KEY='SYSTEM_OPERATOR'
        '' </summary>
        Public Property SYSTEM_OPERATOR() As String
            Get
                Return Me.ColumnyMap("SYSTEM_OPERATOR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYSTEM_OPERATOR") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_CHANNEL_LOCATION 類比系統上架情形-頻道位置"
        '' <summary>
        '' ANALOGY_CHANNEL_LOCATION 類比系統上架情形-頻道位置
        '' </summary>
        Public Property ANALOGY_CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("ANALOGY_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "ANALOGY_SUBSCRIBER_NUMBER 類比系統上架情形-訂戶數"
        '' <summary>
        '' ANALOGY_SUBSCRIBER_NUMBER 類比系統上架情形-訂戶數
        '' </summary>
        Public Property ANALOGY_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("ANALOGY_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANALOGY_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "DIGIT_CHANNEL_LOCATION 數位系統上架情形-頻道位置"
        '' <summary>
        '' DIGIT_CHANNEL_LOCATION 數位系統上架情形-頻道位置
        '' </summary>
        Public Property DIGIT_CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("DIGIT_CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "DIGIT_SUBSCRIBER_NUMBER 數位系統上架情形-訂戶數"
        '' <summary>
        '' DIGIT_SUBSCRIBER_NUMBER 數位系統上架情形-訂戶數
        '' </summary>
        Public Property DIGIT_SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("DIGIT_SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DIGIT_SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_LOCATION 頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用"
        '' <summary>
        '' CHANNEL_LOCATION 頻道位置, 其他供公眾收視聽之播送平臺、直播衛星用
        '' </summary>
        Public Property CHANNEL_LOCATION() As String
            Get
                Return Me.ColumnyMap("CHANNEL_LOCATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_LOCATION") = value
            End Set
        End Property
#End Region

#Region "SUBSCRIBER_NUMBER 訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用"
        '' <summary>
        '' SUBSCRIBER_NUMBER 訂戶數, 其他供公眾收視聽之播送平臺、直播衛星用
        '' </summary>
        Public Property SUBSCRIBER_NUMBER() As String
            Get
                Return Me.ColumnyMap("SUBSCRIBER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBSCRIBER_NUMBER") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        '' <summary>
        '' 查詢 
        '' </summary>
        Public Function QueryMergeData() As DataTable
            Return Me.QueryMergeData(0, 0)
        End Function

        '' <summary>
        '' 查詢 
        '' </summary>
        '' <remarks>
        '' 0.0.1   新增方法
        '' </remarks>
        Public Function QueryMergeData(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1180", "M", "PKNO", "CASE_NO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "M", "SYS_SORT"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.SYS_NAME AS 'CH_NAME', R1.SYS_RSV1 AS 'AREA', R1.SYS_SORT ")
                sql.AppendLine(" FROM APP1180 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON M.SYSTEM_OPERATOR = R1.SYS_ID AND R1.SYS_KEY = 'SYSTEM_OPERATOR' ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions.Replace("$.", " ")))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY R1.SYS_SORT ")
                    Else
                        sql.AppendLine(" ORDER BY SYS_SORT ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

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

