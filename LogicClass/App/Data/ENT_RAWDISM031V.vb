'----------------------------------------------------------------------------------
'File Name		: 
'Author			: Edward Wang
'Description		: NCCST連線Table
'Modification Log	:
'
'Vers		Date       	By		        Notes
'----------------------------------------------------------------------------------
'0.0.1		2019/02/21	Edward Wang		Source Create
'----------------------------------------------------------------------------------



Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Namespace App.Data
    Public Class ENT_RAWDISM031V
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
            Me.TableName = "RAWDISM031V"
            Me.SysName = "NCC"
            Me.ConnName = "NCCST"
        End Sub
#End Region
#Region "屬性"
#Region "統計年月"
        Public Property YM() As String
            Get
                Return Me.ColumnyMap("YM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("YM") = value
            End Set
        End Property
#End Region

#Region "統一編號"
        Public Property IDENTIFICATION() As String
            Get
                Return Me.ColumnyMap("IDENTIFICATION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IDENTIFICATION") = value
            End Set
        End Property
#End Region

#Region "業者名稱"
        Public Property APPLY_CHT_NAME() As String
            Get
                Return Me.ColumnyMap("APPLY_CHT_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APPLY_CHT_NAME") = value
            End Set
        End Property
#End Region

#Region "頻道代碼"
        Public Property LICENSE_NO1() As String
            Get
                Return Me.ColumnyMap("LICENSE_NO1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_NO1") = value
            End Set
        End Property
#End Region

#Region "申請類別"
        Public Property KINDS() As String
            Get
                Return Me.ColumnyMap("KINDS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("KINDS") = value
            End Set
        End Property
#End Region

#Region "申請類別名稱"
        Public Property KINDNM() As String
            Get
                Return Me.ColumnyMap("KINDNM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("KINDNM") = value
            End Set
        End Property
#End Region

#Region "上架業者統一編號"
        Public Property IDENTIFICATION1() As String
            Get
                Return Me.ColumnyMap("IDENTIFICATION1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IDENTIFICATION1") = value
            End Set
        End Property
#End Region

#Region "頻道名稱"
        Public Property CHANNEL_NAME() As String
            Get
                Return Me.ColumnyMap("CHANNEL_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_NAME") = value
            End Set
        End Property
#End Region

#Region "上架業者名稱"
        Public Property CNAME() As String
            Get
                Return Me.ColumnyMap("CNAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CNAME") = value
            End Set
        End Property
#End Region

#Region "上架位置"
        Public Property CHLNO() As String
            Get
                Return Me.ColumnyMap("CHLNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHLNO") = value
            End Set
        End Property
#End Region

#Region "訂戶數"
        Public Property ISUQTY() As String
            Get
                Return Me.ColumnyMap("ISUQTY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ISUQTY") = value
            End Set
        End Property
#End Region

#End Region


#Region "自訂方法 Query"
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
                Me.TableCoumnInfo.Add(New String() {"RAWDISM031V", "M", "YM", "IDENTIFICATION", "APPLY_CHT_NAME", "LICENSE_NO1", "CHANNEL_NAME", "KINDS", "KINDNM", "IDENTIFICATION1", "CNAME", "CHLNO", "ISUQTY"})
                Me.ParserAlias()

                '=== Combine SQL ===
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT * FROM RAWDISM031V M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                'sql.AppendLine(" AND YM = ( ")
                'sql.AppendLine(" select MAX(YM) from RAWDISM031V M ")
                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                'End If
                'sql.AppendLine(" ) ")

                If Me.OrderBys <> "" Then
                    'sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                    Else
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Public Function GetMaxDate() As DataTable
            Return Me.GetMaxDate(0, 0)
        End Function

        ''' <summary>
        ''' 找類型條件當中的最大日期(YM)
        ''' </summary>
        Public Function GetMaxDate(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"RAWDISM031V", "M", "YM", "KINDS", "KINDNM", "CHANNEL_NAME", "IDENTIFICATION"})
                Me.ParserAlias()

                '=== Combine SQL ===
                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT MAX(YM) as MAX_YM FROM RAWDISM031V M ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    'sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                    Else
                        'sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
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


