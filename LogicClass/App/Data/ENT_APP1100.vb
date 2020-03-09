'----------------------------------------------------------------------------------
'File Name		: APP1100
'Author			: TIM
'Description		: APP1100 預期營業收入明細表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/23	TIM		Source Create
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
    ' APP1100 預期營業收入明細表
    ' </summary>
    Public Class ENT_APP1100
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
            Me.TableName = "APP1100"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,PROJECT_TYPE,PROJECT_CLASS"
            Me.SET_NULL_FIELD = "FUTURE_ONE_YEAR,FUTURE_TWO_YEAR,FUTURE_THREE_YEAR,ONE_TOTAL_REV_RATIO,TWO_TOTAL_REV_RATIO,THREE_TOTAL_REV_RATIO"
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

#Region "ACC_TYPE 會計科目(1.收入，2.支出)"
        '' <summary>
        '' ACC_TYPE 會計科目(1.收入，2.支出)
        '' </summary>
        Public Property ACC_TYPE() As String
            Get
                Return Me.ColumnyMap("ACC_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACC_TYPE") = value
            End Set
        End Property
#End Region

#Region "PROJECT_TYPE 項目種類"
        '' <summary>
        '' PROJECT_TYPE 項目種類(1.收入，2.支出)
        '' </summary>
        Public Property PROJECT_TYPE() As String
            Get
                Return Me.ColumnyMap("PROJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "PROJECT_CLASS 項目類別"
        '' <summary>
        '' PROJECT_CLASS 項目類別
        '' </summary>
        Public Property PROJECT_CLASS() As String
            Get
                Return Me.ColumnyMap("PROJECT_CLASS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROJECT_CLASS") = value
            End Set
        End Property
#End Region


#Region "FUTURE_ONE_YEAR 未來第1年"
        '' <summary>
        '' FUTURE_ONE_YEAR 未來第1年
        '' </summary>
        Public Property FUTURE_ONE_YEAR() As String
            Get
                Return Me.ColumnyMap("FUTURE_ONE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUTURE_ONE_YEAR") = value
            End Set
        End Property
#End Region

#Region "ONE_TOTAL_REV_RATIO 第1年占總營收之比例"
        '' <summary>
        '' ONE_TOTAL_REV_RATIO 第1年占總營收之比例
        '' </summary>
        Public Property ONE_TOTAL_REV_RATIO() As String
            Get
                Return Me.ColumnyMap("ONE_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ONE_TOTAL_REV_RATIO") = value
            End Set
        End Property
#End Region

#Region "FUTURE_TWO_YEAR 未來第2年"
        '' <summary>
        '' FUTURE_TWO_YEAR 未來第2年
        '' </summary>
        Public Property FUTURE_TWO_YEAR() As String
            Get
                Return Me.ColumnyMap("FUTURE_TWO_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUTURE_TWO_YEAR") = value
            End Set
        End Property
#End Region

#Region "TWO_TOTAL_REV_RATIO 未來第2年占總營收之比例"
        '' <summary>
        '' TWO_TOTAL_REV_RATIO 未來第2年占總營收之比例
        '' </summary>
        Public Property TWO_TOTAL_REV_RATIO() As String
            Get
                Return Me.ColumnyMap("TWO_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TWO_TOTAL_REV_RATIO") = value
            End Set
        End Property
#End Region

#Region "FUTURE_THREE_YEAR 未來第3年"
        '' <summary>
        '' FUTURE_THREE_YEAR 未來第3年
        '' </summary>
        Public Property FUTURE_THREE_YEAR() As String
            Get
                Return Me.ColumnyMap("FUTURE_THREE_YEAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FUTURE_THREE_YEAR") = value
            End Set
        End Property
#End Region

#Region "THREE_TOTAL_REV_RATIO 未來第3年占總營收之比例"
        '' <summary>
        '' THREE_TOTAL_REV_RATIO 未來第3年占總營收之比例
        '' </summary>
        Public Property THREE_TOTAL_REV_RATIO() As String
            Get
                Return Me.ColumnyMap("THREE_TOTAL_REV_RATIO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("THREE_TOTAL_REV_RATIO") = value
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
        ''' 0.0.1 CMHuang 新增方法
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
                'Me.TableCoumnInfo.Add(New String() {"APP1100", "M", "CASE_NO", "FUTURE_YEAR", "FINANCE_CLASS", "FINANCE_TYPE", "FINANCE_DETAILS", "ESTIMATED_AMOUNT"})
                'Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*,R1.SYS_NAME, R2.SYS_NAME AS 'PROJECT_TYPE_NM', R2.SYS_ID AS 'PROJECT_TYPE_ID' ")
                sql.AppendLine(" FROM APP1100 M WITH(NOLOCK) ")

                If Me.ACC_TYPE = "1" Then
                    sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R1 ON M.PROJECT_CLASS = R1.SYS_ID AND R1.SYS_KEY = 'FINANCE_CODE2' ")
                    sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R2 ON M.PROJECT_TYPE = R2.SYS_ID AND R2.SYS_KEY = 'FINANCE_CODE2'  ")
                Else
                    sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R1 ON M.PROJECT_CLASS = R1.SYS_ID AND R1.SYS_KEY = 'FINANCE_CODE3' ")
                    sql.AppendLine(" LEFT JOIN  ( Select SYS_ID,SYS_NAME,SYS_KEY From SYST010 ) R2 ON M.PROJECT_TYPE = R2.SYS_ID AND R2.SYS_KEY = 'FINANCE_CODE3'  ")
                End If

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    End If
                End If

                Dim txtSql As String = sql.ToString().Replace("$.", "")

                Dim dt As DataTable = Me.QueryBySql(txtSql, pageNo, pageSize)

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

