'----------------------------------------------------------------------------------
'File Name		: APP2020
'Author			: San
'Description		: APP2020 諮詢委員會議成員
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/22	San		Source Create
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
    ' APP2020 諮詢委員會議成員
    ' </summary>
    Public Class ENT_APP2020
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
            Me.TableName = "APP2020"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = ""
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼, REF.APP2010.GROUP_CODE
        '' </summary>
        Public Property GROUP_CODE() As String
            Get
                Return Me.ColumnyMap("GROUP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_CODE") = value
            End Set
        End Property
#End Region

#Region "ID_FG 暫不用"
        '' <summary>
        '' ID_FG 暫不用
        '' </summary>
        Public Property ID_FG() As String
            Get
                Return Me.ColumnyMap("ID_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ID_FG") = value
            End Set
        End Property
#End Region

#Region "ACNT 帳號, REF.POST020.ACNT"
        '' <summary>
        '' ACNT 帳號, REF.POST020.ACNT
        '' </summary>
        Public Property ACNT() As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
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
        ''' 0.0.1   新增方法
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
                Me.TableCoumnInfo.Add(New String() {"APP2020", "M", "GROUP_CODE", "PKNO"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R2", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "R3", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine("    SELECT M.*,                                                           ")
                sql.AppendLine("               R1.CH_NAME,                                                ")
                sql.AppendLine("               R1.PERSON_TYPE,                                            ")
                sql.AppendLine("               R1.EMAIL,                                                  ")
                sql.AppendLine("               R1.CONTACT_TEL,                                            ")
                sql.AppendLine("               R1.DEADLINE_SDATE,                                         ")
                sql.AppendLine("               R1.DEADLINE_EDATE,                                         ")
                sql.AppendLine("               R1.USE_STATE,                                              ")
                sql.AppendLine("               R2.NO_NAME AS PERSON_TYPE_NAME,R3.GROUP_NAME,              ")
                sql.AppendLine("               R4.COM_CNAM AS DEP_NAME                                    ")
                sql.AppendLine("          FROM             APP2020 M WITH(NOLOCK)                         ")
                sql.AppendLine("                        INNER JOIN                                        ")
                sql.AppendLine("                           POST020 R1 WITH(NOLOCK)                        ")
                sql.AppendLine("                        ON M.ACNT = R1.ACNT                               ")
                sql.AppendLine("                     LEFT JOIN                                            ")
                sql.AppendLine("                        POSC010 R2 WITH(NOLOCK)                           ")
                sql.AppendLine("                     ON R1.PERSON_TYPE = R2.NO AND R2.TYPE_CODE = '0006'  ")
                sql.AppendLine("                  LEFT JOIN                                               ")
                sql.AppendLine("                     APP2010 R3 WITH(NOLOCK)                              ")
                sql.AppendLine("                  ON M.GROUP_CODE = R3.GROUP_CODE                         ")
                sql.AppendLine("               LEFT JOIN                                                  ")
                sql.AppendLine("                  APPL010  R4                                             ")
                sql.AppendLine("               ON R1.DEP_CODE = R4.PKNO                                   ")
                sql.AppendLine("         WHERE 1 = 1                                                      ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" AND " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.ACNT ")
                    Else
                        sql.AppendLine(" ORDER BY ACNT ")
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


