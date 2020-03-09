'----------------------------------------------------------------------------------
'File Name		: SYST031
'Author			: CM Huang
'Description		: SYST031 自動公告樣版
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/11/24	CM Huang		Source Create
'0.0.2      2016/07/29  Steven       Query 的 USE_TYPE 改由 SYST010 代碼table取得
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Sys.Data
    ' <summary>
    ' SYST031 自動公告樣版
    ' </summary>
    Public Class ENT_SYST031
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
            Me.TableName = "SYST031"
            Me.SysName = "SYS"
            Me.ConnName = "TSBA"
        End Sub
#End Region

#Region "屬性"
#Region "NUM_CATEGORY1"
        '' <summary>
        '' NUM_CATEGORY1
        '' </summary>
        Public Property NUM_CATEGORY1() As String
            Get
                Return Me.ColumnyMap("NUM_CATEGORY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NUM_CATEGORY1") = value
            End Set
        End Property
#End Region

#Region "USER_TYPE"
        '' <summary>
        '' USER_TYPE
        '' </summary>
        Public Property USER_TYPE() As String
            Get
                Return Me.ColumnyMap("USER_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USER_TYPE") = value
            End Set
        End Property
#End Region

#Region "USE_TYPE"
        '' <summary>
        '' USE_TYPE
        '' </summary>
        Public Property USE_TYPE() As String
            Get
                Return Me.ColumnyMap("USE_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_TYPE") = value
            End Set
        End Property
#End Region

#Region "POST_DAY"
        '' <summary>
        '' 公告天數
        '' </summary>
        Public Property POST_DAY() As String
            Get
                Return Me.ColumnyMap("POST_DAY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("POST_DAY") = value
            End Set
        End Property
#End Region

#Region "POST_ITEM"
        '' <summary>
        '' POST_ITEM
        '' </summary>
        Public Property POST_ITEM() As String
            Get
                Return Me.ColumnyMap("POST_ITEM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("POST_ITEM") = value
            End Set
        End Property
#End Region

#Region "POST_CONTENT"
        '' <summary>
        '' POST_CONTENT
        '' </summary>
        Public Property POST_CONTENT() As String
            Get
                Return Me.ColumnyMap("POST_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("POST_CONTENT") = value
            End Set
        End Property
#End Region

#Region "IS_BATCH 是否批次執行"
        ''' <summary>
        ''' IS_BATCH 是否批次執行
        ''' </summary>
        Public Property IS_BATCH() As String
            Get
                Return Me.PropertyMap("IS_BATCH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_BATCH") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
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
                Me.TableCoumnInfo.Add(New String() {"SYST031", "M", "PKNO,NUM_CATEGORY1,USER_TYPE,USE_TYPE,POST_DAY,POST_ITEM,POST_CONTENT,MOD_1_ID"})
                Me.TableCoumnInfo.Add(New String() {"POST020", "R1", "ACNT,CH_NAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, isNull(R1.CH_NAME, '') AS UPDATE_USER1, ")

                sql.AppendLine(" S1.SYS_ID AS MOD_1_ID, S1.SYS_NAME AS MOD_1_NAME, ")
                sql.AppendLine(" S2.SYS_NAME AS MOD_2_NAME, ")

                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(M.UPDATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(M.UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(M.UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(M.UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(M.UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(M.UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME1 , ")


                sql.AppendLine(" R2.SYS_NAME as USE_TYPE1,   ")
                'sql.AppendLine(" CASE M.USE_TYPE   ")
                'sql.AppendLine("   WHEN 2 THEN '核配' ")
                'sql.AppendLine("   WHEN 3 THEN '收回' ")
                'sql.AppendLine("   ELSE ''   ")
                'sql.AppendLine(" END AS USE_TYPE1,  ")

                sql.AppendLine(" CASE M.USER_TYPE   ")
                sql.AppendLine("   WHEN '1' THEN '民眾' ")
                sql.AppendLine("   WHEN '2' THEN '業者' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USER_TYPE1  ")

                sql.AppendLine(" FROM SYST031 M ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020) R1 ON M.UPDATE_USER = R1.ACNT ")

                sql.AppendLine(" LEFT JOIN (SELECT * FROM SYST010 WHERE SYS_KEY='號碼種類' AND SYS_TYPE=1 ) S2 ON M.NUM_CATEGORY1 = S2.SYS_ID ")
                sql.AppendLine(" LEFT JOIN (SELECT * FROM SYST010 WHERE SYS_KEY='號碼種類' AND SYS_TYPE=1 ) S1 ON S2.SYS_PRTID = S1.SYS_ID ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 on R2.SYS_KEY='USE_TYPE' AND R2.SYS_ID = M.USE_TYPE ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY MOD_1_ID ASC,NUM_CATEGORY1 ASC, USE_TYPE ASC, USER_TYPE ASC ")
                    Else
                        sql.AppendLine(" ORDER BY MOD_1_ID ASC,NUM_CATEGORY1 ASC, USE_TYPE ASC, USER_TYPE ASC ")
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

#Region "Overrides Base Function"
        Public Overrides Function Insert() As String
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "POST_ITEM,POST_CONTENT"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

