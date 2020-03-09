'----------------------------------------------------------------------------------
'File Name		: EntLoginData
'Author			: 
'Description		: EntLoginData 登入資訊ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/08/27			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase
Imports Pos.Data
Namespace Pos.Data
    '' <summary>
    '' EntLoginData 登入資訊ENT
    '' </summary>
    Public Class EntLoginData
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "POST010"
            Me.SysName = "POS"
            Me.ConnName = "TSBA"
            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT As String
            Get
                Return Me.ColumnyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "ERROR_TIMES 錯誤次數"
        ''' <summary>
        ''' ERROR_TIMES 錯誤次數
        ''' </summary>
        Public Property ERROR_TIMES As String
            Get
                Return Me.ColumnyMap("ERROR_TIMES")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ERROR_TIMES") = value
            End Set
        End Property
#End Region

#Region "IS_CHANG 是否變更"
        ''' <summary>
        ''' IS_CHANG 是否變更
        ''' </summary>
        Public Property IS_CHANG As String
            Get
                Return Me.ColumnyMap("IS_CHANG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_CHANG") = value
            End Set
        End Property
#End Region

#Region "PERSON_TYPE 人員類別"
        ''' <summary>
        ''' PERSON_TYPE 人員類別
        ''' </summary>
        Public Property PERSON_TYPE As String
            Get
                Return Me.ColumnyMap("PERSON_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PERSON_TYPE") = value
            End Set
        End Property
#End Region

#Region "PW 密碼"
        ''' <summary>
        ''' PW 密碼
        ''' </summary>
        Public Property PW As String
            Get
                Return Me.ColumnyMap("PW")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PW") = value
            End Set
        End Property
#End Region

#Region "PW_UPD_DATE 密碼修改日期"
        ''' <summary>
        ''' PW_UPD_DATE 密碼修改日期
        ''' </summary>
        Public Property PW_UPD_DATE As String
            Get
                Return Me.ColumnyMap("PW_UPD_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PW_UPD_DATE") = value
            End Set
        End Property
#End Region

#Region "EntLoginData 登入資訊ENT"
        ''' <summary>
        ''' EntLoginData 登入資訊ENT
        ''' </summary>
        Private Property EntLoginData() As EntLoginData
            Get
                Return Me.PropertyMap("EntLoginData")
            End Get
            Set(ByVal value As EntLoginData)
                Me.PropertyMap("EntLoginData") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "MyQuery 查詢密碼有無過期 "
        ''' <summary>
        ''' 查詢 密碼有無過期
        ''' </summary>
        Public Function MyQuery() As DataTable
            Return Me.MyQuery(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Kevin Yu 新增方法
        ''' </remarks>
        Public Function MyQuery(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"post010", "M", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE", "PKNO"})
                Me.TableCoumnInfo.Add(New String() {"POSH010", "R1", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE", "PKNO"})


                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                'Me.ProcessQueryCondition(condition, "=", "ERROR_TIMES", 0)
                ''Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                ''Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)
                ' ''Unicode欄位查詢
                ''If Me.LICENSE_NO <> "" Then
                ''    condition.Append(" AND $.LICENSE_NO LIKE N'%" & Me.LICENSE_NO & "%' ")
                ''End If
                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" select M.ACNT,m.PW,m.PERSON_TYPE,m.IS_CHANG,m.ERROR_TIMES,m.PW_UPD_DATE,m.PKNO, ")
                sql.AppendLine(" DATEDIFF(DAY,getdate() ,M.PW_UPD_DATE) as PW_DEADLINE2  from post010 M WITH (NOLOCK) ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))  ' & " and DATEDIFF (DAY, getdate(),M.PW_UPD_DATE)> " & p_PW_DEADLINE
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY PW_DEADLINE2 ")
                    Else
                        sql.AppendLine(" ORDER BY PW_DEADLINE2 ")
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

#Region "MyQuery2 查詢重設密碼相關 "
        ''' <summary>
        ''' 查詢 查詢重設密碼相關
        ''' </summary>
        Public Function MyQuery2() As DataTable
            Return Me.MyQuery2(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Kevin Yu 新增方法
        ''' </remarks>
        Public Function MyQuery2(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"post010", "M", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE", "PKNO"})
                Me.TableCoumnInfo.Add(New String() {"POSt020", "R1", "ACNT", "PERSON_TYPE", "CH_NAME", "DEP_CODE", "EMAIL", "CONTACT_TEL", "USE_STATE"})


                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                'Me.ProcessQueryCondition(condition, "=", "ERROR_TIMES", 0)
                ''Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                ''Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)
                ' ''Unicode欄位查詢
                ''If Me.LICENSE_NO <> "" Then
                ''    condition.Append(" AND $.LICENSE_NO LIKE N'%" & Me.LICENSE_NO & "%' ")
                ''End If
                Me.SqlRetrictions = condition.ToString() & Me.SqlRetrictions
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" select M.ACNT,M.PW,M.PERSON_TYPE,M.IS_CHANG,M.ERROR_TIMES,M.PW_UPD_DATE,M.PKNO,  ")
                sql.AppendLine(" R1.ACNT,R1.PERSON_TYPE,R1.CH_NAME, R1.DEP_CODE,R1.EMAIL,R1.CONTACT_TEL,R1.USE_STATE ")
                sql.AppendLine(" from post010 M WITH(NOLOCK)  ")
                sql.AppendLine(" inner join post020 R1 WITH(NOLOCK) on M.ACNT=r1.ACNT ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY PKNO ")
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

#Region "MyQuery3 查詢post010 acnt "
        ''' <summary>
        ''' 查詢 查詢post010 acnt
        ''' </summary>
        Public Function MyQuery3() As DataTable
            Return Me.MyQuery3(0, 0)
        End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Kevin Yu 新增方法
        ''' </remarks>
        Public Function MyQuery3(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"post010", "M", "ACNT", "PW", "PERSON_TYPE", "IS_CHANG", "ERROR_TIMES", "PW_UPD_DATE", "PKNO"})


                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)
                'Me.ProcessQueryCondition(condition, "=", "ERROR_TIMES", 0)
                ''Me.ProcessQueryCondition(condition, "=", "APP_MONTH", Me.APP_MONTH)
                ''Me.ProcessQueryCondition(condition, "=", "AUDIT_OPINION", Me.AUDIT_OPINION)
                ' ''Unicode欄位查詢
                ''If Me.LICENSE_NO <> "" Then
                ''    condition.Append(" AND $.LICENSE_NO LIKE N'%" & Me.LICENSE_NO & "%' ")
                ''End If
                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" select M.* ")
                sql.AppendLine(" from post010 M WITH(NOLOCK) ")


                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY PKNO ")
                    Else
                        sql.AppendLine(" ORDER BY PKNO ")
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

#Region "UpdatePersonPwd 更新人員密碼主檔"
        ''' <summary>
        ''' 更新人員密碼主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 Kevin Yu 新增方法
        ''' </remarks>
        Public Function UpdatePersonPwd() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPerson = new EntPerson()
                '組合查詢字串(EntPerson.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntPerson.Update()

                '=== 處理查詢條件 ===
                EntLoginData = New EntLoginData(Me.DBManager, Me.LogUtil)
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT 
                Me.EntLoginData.SqlRetrictions = Me.ProcessCondition(condition.ToString)
                Me.EntLoginData.UPD_USER_ID = Me.ACNT
                Me.EntLoginData.PW = Me.PW
                Me.EntLoginData.PW_UPD_DATE = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

                Dim result As Integer = Me.EntLoginData.Update()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace

