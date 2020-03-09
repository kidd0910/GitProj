'----------------------------------------------------------------------------------
'File Name		: APP2010
'Author			: San
'Description		: APP2010 諮詢委員會議資料
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/21	San		Source Create
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
    ' APP2010 諮詢委員會議資料
    ' </summary>
    Public Class ENT_APP2010
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
            Me.TableName = "APP2010"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "GROUP_NAME,GROUP_EXPL"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "GROUP_CODE 諮詢委員會議代碼"
        '' <summary>
        '' GROUP_CODE 諮詢委員會議代碼
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

#Region "GROUP_NAME 諮詢委員會議名稱"
        '' <summary>
        '' GROUP_NAME 諮詢委員會議名稱
        '' </summary>
        Public Property GROUP_NAME() As String
            Get
                Return Me.ColumnyMap("GROUP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_NAME") = value
            End Set
        End Property
#End Region

#Region "GROUP_LEVEL 暫不用"
        '' <summary>
        '' GROUP_LEVEL 暫不用
        '' </summary>
        Public Property GROUP_LEVEL() As String
            Get
                Return Me.ColumnyMap("GROUP_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_LEVEL") = value
            End Set
        End Property
#End Region

#Region "EDU_FG 暫不用"
        '' <summary>
        '' EDU_FG 暫不用
        '' </summary>
        Public Property EDU_FG() As String
            Get
                Return Me.ColumnyMap("EDU_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDU_FG") = value
            End Set
        End Property
#End Region

#Region "RESS_SYS_CD 暫不用"
        '' <summary>
        '' RESS_SYS_CD 暫不用
        '' </summary>
        Public Property RESS_SYS_CD() As String
            Get
                Return Me.ColumnyMap("RESS_SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_SYS_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_OPERATE_CD 暫不用"
        '' <summary>
        '' RESS_OPERATE_CD 暫不用
        '' </summary>
        Public Property RESS_OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("RESS_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "RESS_PROG_CD 暫不用"
        '' <summary>
        '' RESS_PROG_CD 暫不用
        '' </summary>
        Public Property RESS_PROG_CD() As String
            Get
                Return Me.ColumnyMap("RESS_PROG_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESS_PROG_CD") = value
            End Set
        End Property
#End Region

#Region "GROUP_EXPL 群組說明"
        '' <summary>
        '' GROUP_EXPL 群組說明
        '' </summary>
        Public Property GROUP_EXPL() As String
            Get
                Return Me.ColumnyMap("GROUP_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("GROUP_EXPL") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態, 1：啟用，0：停用"
        '' <summary>
        '' USE_STATE 使用狀態, 1：啟用，0：停用
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.ColumnyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 隸屬單位, REF. APPL010.PKNO"
        '' <summary>
        '' DEP_CODE 隸屬單位, REF. APPL010.PKNO
        '' </summary>
        Public Property DEP_CODE() As String
            Get
                Return Me.ColumnyMap("DEP_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEP_CODE") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT 排序"
        '' <summary>
        '' SYS_SORT 排序
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.ColumnyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "MEETING_TYPE 會議類型"
        '' <summary>
        '' MEETING_TYPE 會議類型
        '' </summary>
        Public Property MEETING_TYPE() As String
            Get
                Return Me.ColumnyMap("MEETING_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MEETING_TYPE") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"

#Region "基本查詢"
        ''' <summary>
        ''' 基本查詢 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' 基本查詢 
        ''' </summary>      
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
                Me.TableCoumnInfo.Add(New String() {"APP2010", "M", "MEETING_TYPE", "", "PKNO", "GROUP_CODE", "GROUP_NAME", "GROUP_LEVEL", "GROUP_EXPL", "USE_STATE", "DEP_CODE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT  ")
                sql.AppendLine("  (ROW_NUMBER() OVER (ORDER BY M.PKNO) ) AS ROW_NUM ")
                sql.AppendLine(" , M.* ")
                sql.AppendLine(" FROM APP2010 M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
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

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        Public Function QueryMeeting() As DataTable
            Return Me.QueryMeeting(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>      
        Public Function QueryMeeting(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP2010", "M", "MEETING_TYPE", "", "PKNO", "GROUP_CODE", "GROUP_NAME", "GROUP_LEVEL", "GROUP_EXPL", "USE_STATE", "DEP_CODE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT  ")
                sql.AppendLine("  (ROW_NUMBER() OVER (ORDER BY M.PKNO) ) AS ROW_NUM ")
                sql.AppendLine(" , M.* ")
                sql.AppendLine(" , SYST010.SYS_NAME AS MEETING_TYPE_NAME ")
                sql.AppendLine(" , SYST010.SYS_RSV1 AS SYS_RSV1 ")
                sql.AppendLine(" FROM APP2010 M ")
                sql.AppendLine(" LEFT JOIN SYST010 ON SYST010.SYS_KEY = 'MEETING_TYPE' AND M.MEETING_TYPE = SYST010.SYS_ID ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
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



    End Class
End Namespace

