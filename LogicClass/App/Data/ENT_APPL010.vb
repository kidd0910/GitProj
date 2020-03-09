'----------------------------------------------------------------------------------
'File Name		: APPL010
'Author			: CM Huang
'Description		: APPL010 業者資訊
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/11/02	CM Huang		Source Create
'0.0.2      2013/11/11  CM Huang        新增 統一編號檢查 BUS_NO_Query 
'0.0.3      2013/11/18  CM Huang        新增 查詢可用業者appQuery 
'0.0.4      2013/11/22  CM Huang        新增 VIRTUAL_COM 虛擬業者註記（1：虛擬業者，0：一般業者）
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
    ' APPL010 業者資訊
    ' </summary>
    Public Class ENT_APPL010
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
            Me.TableName = "APPL010"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
        End Sub
#End Region


#Region "屬性"
#Region "INF_SOURCE"
        '' <summary>
        '' INF_SOURCE
        '' </summary>
        Public Property INF_SOURCE() As String
            Get
                Return Me.ColumnyMap("INF_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INF_SOURCE") = value
            End Set
        End Property
#End Region

#Region "BUS_NO"
        '' <summary>
        '' BUS_NO
        '' </summary>
        Public Property BUS_NO() As String
            Get
                Return Me.ColumnyMap("BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUS_NO") = value
            End Set
        End Property
#End Region

#Region "OID"
        '' <summary>
        '' OID
        '' </summary>
        Public Property OID() As String
            Get
                Return Me.ColumnyMap("OID")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OID") = value
            End Set
        End Property
#End Region

#Region "COM_CNAM"
        '' <summary>
        '' COM_CNAM
        '' </summary>
        Public Property COM_CNAM() As String
            Get
                Return Me.ColumnyMap("COM_CNAM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_CNAM") = value
            End Set
        End Property
#End Region

#Region "COM_ENAM"
        '' <summary>
        '' COM_ENAM
        '' </summary>
        Public Property COM_ENAM() As String
            Get
                Return Me.ColumnyMap("COM_ENAM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_ENAM") = value
            End Set
        End Property
#End Region

#Region "CONTACT"
        '' <summary>
        '' CONTACT
        '' </summary>
        Public Property CONTACT() As String
            Get
                Return Me.ColumnyMap("CONTACT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL"
        '' <summary>
        '' CONTACT_TEL
        '' </summary>
        Public Property CONTACT_TEL() As String
            Get
                Return Me.ColumnyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "CONTACT_FAX"
        '' <summary>
        '' CONTACT_FAX
        '' </summary>
        Public Property CONTACT_FAX() As String
            Get
                Return Me.ColumnyMap("CONTACT_FAX")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_FAX") = value
            End Set
        End Property
#End Region

#Region "CONTACT_EMAIL"
        '' <summary>
        '' CONTACT_EMAIL
        '' </summary>
        Public Property CONTACT_EMAIL() As String
            Get
                Return Me.ColumnyMap("CONTACT_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CONTACT_EMAIL") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
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

#Region "VIRTUAL_COM"
        '' <summary>
        '' VIRTUAL_COM
        '' </summary>
        Public Property VIRTUAL_COM() As String
            Get
                Return Me.ColumnyMap("VIRTUAL_COM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VIRTUAL_COM") = value
            End Set
        End Property
#End Region

#Region "MODIFY_FLAG"
        '' <summary>
        '' MODIFY_FLAG
        '' </summary>
        Public Property MODIFY_FLAG() As String
            Get
                Return Me.ColumnyMap("MODIFY_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MODIFY_FLAG") = value
            End Set
        End Property
#End Region
#Region "COM_ENAM"
        '' <summary>
        '' COM_ENAM
        '' </summary>
        Public Property COM_SNAM() As String
            Get
                Return Me.ColumnyMap("COM_SNAM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_SNAM") = value
            End Set
        End Property
#End Region

#Region "COM_TYPE"
        '' <summary>
        '' COM_TYPE
        '' </summary>
        Public Property COM_TYPE() As String
            Get
                Return Me.ColumnyMap("COM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_TYPE") = value
            End Set
        End Property
#End Region

#Region "COM_CODE"
        '' <summary>
        '' COM_CODE
        '' </summary>
        Public Property COM_CODE() As String
            Get
                Return Me.ColumnyMap("COM_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_CODE") = value
            End Set
        End Property
#End Region

#Region "COM_CNAM1"
        '' <summary>
        '' COM_CNAM1
        '' </summary>
        Public Property COM_CNAM1() As String
            Get
                Return Me.ColumnyMap("COM_CNAM1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_CNAM1") = value
            End Set
        End Property
#End Region

#Region "UP_COM_PKNO"
        '' <summary>
        '' UP_COM_PKNO
        '' </summary>
        Public Property UP_COM_PKNO() As String
            Get
                Return Me.ColumnyMap("UP_COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UP_COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY1"
        '' <summary>
        '' ADDR_CITY1
        '' </summary>
        Public Property ADDR_CITY1() As String
            Get
                Return Me.ColumnyMap("ADDR_CITY1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR_CITY1") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY2"
        '' <summary>
        '' ADDR_CITY2
        '' </summary>
        Public Property ADDR_CITY2() As String
            Get
                Return Me.ColumnyMap("ADDR_CITY2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR_CITY2") = value
            End Set
        End Property
#End Region

#Region "ADDR"
        '' <summary>
        '' ADDR
        '' </summary>
        Public Property ADDR() As String
            Get
                Return Me.ColumnyMap("ADDR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ADDR") = value
            End Set
        End Property
#End Region

#Region "ORG_TYPE"
        '' <summary>
        '' ORG_TYPE
        '' </summary>
        Public Property ORG_TYPE() As String
            Get
                Return Me.ColumnyMap("ORG_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ORG_TYPE") = value
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
                Me.TableCoumnInfo.Add(New String() {"APPL010", "M", "COM_TYPE", "PKNO", "INF_SOURCE", "BUS_NO", "COM_CNAM", "COM_ENAM", "CONTACT", "CONTACT_TEL", "CONTACT_FAX", "CONTACT_EMAIL", "USE_STATE", "UP_COM_PKNO", "COM_CODE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, isNull(R1.CH_NAME, '') AS UPDATE_USER1, ")
                sql.AppendLine(" ( RIGHT('000' + CAST(YEAR(UPDATE_TIME) - 1911 AS VARCHAR(3)),3) + '/' + RIGHT('00' + CAST(MONTH(UPDATE_TIME) AS VARCHAR(2)),2) + '/' + RIGHT('00' + CAST(DAY(UPDATE_TIME) AS VARCHAR(2)),2) + ' ' + RIGHT('00' + CAST({ fn HOUR(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn MINUTE(UPDATE_TIME) } AS VARCHAR(2)),2) + ':' + RIGHT('00' + CAST({ fn SECOND(UPDATE_TIME) } AS VARCHAR(2)),2) )  AS UPDATE_TIME1 , ")

                sql.AppendLine(" CASE M.USE_STATE   ")
                sql.AppendLine("   WHEN 1 THEN '啟用' ")
                sql.AppendLine("   WHEN 0 THEN '停用' ")
                sql.AppendLine("   WHEN 2 THEN '暫存' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS USE_STATE1,  ")

                sql.AppendLine(" CASE M.INF_SOURCE   ")
                sql.AppendLine("   WHEN '1' THEN '通傳系統' ")
                sql.AppendLine("   WHEN '0' THEN '自建' ")
                sql.AppendLine("   ELSE ''   ")
                sql.AppendLine(" END AS INF_SOURCE1  ")

                sql.AppendLine(" FROM APPL010 M WITH(NOLOCK) ")
                sql.AppendLine(" LEFT JOIN (SELECT ACNT, CH_NAME FROM POST020 WITH(NOLOCK)) R1 ON M.UPDATE_USER = R1.ACNT ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
                    Else
                        sql.AppendLine(" ORDER BY BUS_NO ASC,COM_CNAM ASC ")
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

#Region "GetSubBusNo"
        ''' <summary>
        ''' GetSubBusNo 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 sandra 新增方法
        ''' </remarks>
        Public Function GetSubBusNo() As DataTable
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
                Me.TableCoumnInfo.Clear()
                Me.ParserAlias()

                Dim SQL As StringBuilder = New StringBuilder
                SQL.AppendLine("SELECT PKNO FROM GET_DATA_RIGHT ('" & Me.PKNO & "')")
                SQL.AppendLine("ORDER BY PKNO")


                Dim dt As DataTable = Me.QueryBySql(SQL.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "統一編號檢查 BUS_NO_Query"
#Region "BUS_NO_Query"
        ''' <summary>
        ''' 統一編號檢查
        ''' 接受 Condition 傳回 Count(PKNO) as NUM
        ''' </summary>
        ''' <returns>DataTable(Count(PKNO) as NUM) 傳回計算數量</returns>
        Public Function BUS_NO_Query() As DataTable
            Return Me.BUS_NO_Query(0, 0)
        End Function

        ''' <summary>
        ''' 統一編號檢查 
        ''' </summary>
        ''' <returns>DataTable(Count(PKNO)) 傳回計算數量</returns>
        ''' <remarks>
        ''' 0.0.1 CMHuang 新增方法
        ''' </remarks>
        Public Function BUS_NO_Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL010", "M", "INF_SOURCE", "BUS_NO", "COM_CNAM", "COM_ENAM", "CONTACT", "CONTACT_TEL", "CONTACT_EMAIL", "USE_STATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT COUNT(M.PKNO) as NUM FROM APPL010 M WITH(NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
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


#Region "查詢啟用且至少有一張可用執照的業者(預設不含虛擬業者) appNEQuery"
#Region "appQuery 查詢 "
        ''' <summary>
        ''' 查詢啟用且至少有一張可用執照的業者(預設不含虛擬業者)
        ''' 1.業者啟用
        ''' 2.執照啟用
        ''' 3.未過屆期(isExpire控制:False)
        ''' 4.不含虛擬業者(isVirtual控制:False)
        ''' </summary>
        ''' <param name="isExpire"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function appNEQuery(Optional ByVal isVirtual As Boolean = False, Optional ByVal isExpire As Boolean = False)
            Return Me.appQuery(0, 0, isVirtual, isExpire:=isExpire)
        End Function

        ''' <summary>
        ''' 查詢啟用且至少有一張可用執照的業者(預設不含虛擬業者)
        ''' 1.業者啟用
        ''' 2.執照啟用
        ''' 3.未過屆期
        ''' 4.不含虛擬業者(isVirtual控制:False)
        ''' </summary>
        ''' <param name="isVirtual">是否包含虛擬業者</param>
        ''' <returns >DataTable(COM_CNAM,PKNO) 傳回業者名稱與PKNO</returns>
        ''' <remarks>2013/11/22 新增VIRTUAL_COM欄位（1：虛擬業者，0：一般業者）</remarks>
        Public Function appQuery(Optional ByVal isVirtual As Boolean = False) As DataTable
            Return Me.appQuery(0, 0, isVirtual)
        End Function

        ''' <summary>
        ''' 查詢啟用且至少有一張可用執照的業者(預設不含虛擬業者)
        ''' 1.業者啟用
        ''' 2.執照啟用
        ''' 3.未過屆期
        ''' 4.不含虛擬業者(isVirtual控制:False)
        ''' </summary>
        ''' <param name="isNP">是否維NP業者</param>
        ''' <returns >DataTable(COM_CNAM,PKNO) 傳回業者名稱與PKNO</returns>
        ''' <remarks>2013/11/22 新增VIRTUAL_COM欄位（1：虛擬業者，0：一般業者）</remarks>
        Public Function appNPQuery(Optional ByVal isNP As Boolean = True) As DataTable
            Return Me.appQuery(0, 0, isNP:=isNP)
        End Function

        ''' <summary>
        ''' 查詢啟用且至少有一張可用執照的業者(預設不含虛擬業者)
        ''' 1.業者啟用
        ''' 2.執照啟用
        ''' 3.未過屆期
        ''' 4.不含虛擬業者(isVirtual控制:False)
        ''' </summary>
        ''' <param name="isVirtual">是否包含虛擬業者</param>
        ''' <returns >DataTable(COM_CNAM,PKNO) 傳回業者名稱與PKNO</returns>
        ''' <remarks>2013/11/22 新增VIRTUAL_COM欄位（1：虛擬業者，0：一般業者）</remarks>
        Public Function appQuery(ByVal pageNo As Integer, ByVal pageSize As Integer, Optional ByVal isVirtual As Boolean = False, Optional ByVal isNP As Boolean = False, Optional ByVal isExpire As Boolean = False) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APPL010", "M", "INF_SOURCE", "BUS_NO", "COM_CNAM", "COM_ENAM", "CONTACT", "CONTACT_TEL", "CONTACT_EMAIL", "USE_STATE"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.COM_CNAM, M.PKNO, M.COM_ENAM ")
                sql.AppendLine(" FROM APPL010 M WITH(NOLOCK) ")

                'If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                'End If
                If isNP Then
                    sql.AppendLine(" JOIN (SELECT DISTINCT COM_PKNO FROM APPL020 AS A")
                    sql.AppendLine(" JOIN (SELECT DISTINCT LICENSE_NO FROM APPL021) AS D")
                    sql.AppendLine(" ON A.PKNO = D.LICENSE_NO) AS D")
                    sql.AppendLine(" ON M.PKNO = D.COM_PKNO")
                End If
                sql.AppendLine(" WHERE ")
                sql.AppendLine(" M.USE_STATE = 1 AND (SELECT COUNT(L.PKNO) FROM APPL020 L WHERE L.COM_PKNO =M.PKNO AND L.USE_STATE=1 ")
                If Not isExpire Then
                    sql.AppendLine(" AND CONVERT(varchar(10), L.EXPIRE_DATE, 111) >= CONVERT(varchar(10), GETDATE(), 111) ")
                End If
                sql.AppendLine(" ) > 0 ")

                '2013/11/22 VIRTUAL_COM 虛擬業者註記（1：虛擬業者，0：一般業者）
                If Not isVirtual Then
                    sql.AppendLine(" AND VIRTUAL_COM=0 ")
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY COM_CNAM ASC ")
                    Else
                        sql.AppendLine(" ORDER BY COM_CNAM ASC ")
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
            MyBase.LONG_FIELD_NAME = "INF_SOURCE,COM_CNAM,CONTACT,CONTACT_TEL"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.LONG_FIELD_NAME = "INF_SOURCE,COM_CNAM,CONTACT,CONTACT_TEL"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.LONG_FIELD_NAME = "INF_SOURCE,COM_CNAM,CONTACT,CONTACT_TEL"
            Return MyBase.UpdateByPkNo()
        End Function
#End Region


    End Class
End Namespace

