'----------------------------------------------------------------------------------
'File Name		: EntSystem
'Author			: nono
'Description		: EntSystem 系統ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/14	nono		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

NameSpace Aut.Data
	'' <summary>
	'' EntSystem 系統ENT
	'' </summary>
	Public Class EntSystem 
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
            Me.TableName = "AUTC010"
            Me.SysName = "AUT"
            Me.ConnName = "TSBA"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "EDU_FG 教學務別"
        ''' <summary>
        ''' EDU_FG 教學務別
        ''' </summary>
        Public Property EDU_FG() As String
            Get
                Return Me.ColumnyMap("EDU_FG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("EDU_FG") = value
            End Set
        End Property
#End Region

#Region "OPERATE_CD 作業代號"
        ''' <summary>
        ''' OPERATE_CD 作業代號
        ''' </summary>
        Public Property OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "OPERATE_LEVEL 作業層級"
        ''' <summary>
        ''' OPERATE_LEVEL 作業層級
        ''' </summary>
        Public Property OPERATE_LEVEL() As String
            Get
                Return Me.ColumnyMap("OPERATE_LEVEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_LEVEL") = value
            End Set
        End Property
#End Region

#Region "OPERATE_NM 作業名稱"
        ''' <summary>
        ''' OPERATE_NM 作業名稱
        ''' </summary>
        Public Property OPERATE_NM() As String
            Get
                Return Me.ColumnyMap("OPERATE_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_NM") = value
            End Set
        End Property
#End Region

#Region "OPERATE_SORT 作業排序"
        ''' <summary>
        ''' OPERATE_SORT 作業排序
        ''' </summary>
        Public Property OPERATE_SORT() As String
            Get
                Return Me.ColumnyMap("OPERATE_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OPERATE_SORT") = value
            End Set
        End Property
#End Region

#Region "SYS_AGT 系統代理人"
        ''' <summary>
        ''' SYS_AGT 系統代理人
        ''' </summary>
        Public Property SYS_AGT() As String
            Get
                Return Me.ColumnyMap("SYS_AGT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_AGT") = value
            End Set
        End Property
#End Region

#Region "SYS_CD 系統代號"
        ''' <summary>
        ''' SYS_CD 系統代號
        ''' </summary>
        Public Property SYS_CD() As String
            Get
                Return Me.ColumnyMap("SYS_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CD") = value
            End Set
        End Property
#End Region

#Region "SYS_CHARGE 系統負責人"
        ''' <summary>
        ''' SYS_CHARGE 系統負責人
        ''' </summary>
        Public Property SYS_CHARGE() As String
            Get
                Return Me.ColumnyMap("SYS_CHARGE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_CHARGE") = value
            End Set
        End Property
#End Region

#Region "SYS_NM 系統名稱"
        ''' <summary>
        ''' SYS_NM 系統名稱
        ''' </summary>
        Public Property SYS_NM() As String
            Get
                Return Me.ColumnyMap("SYS_NM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_NM") = value
            End Set
        End Property
#End Region

#Region "UPPER_OPERATE_CD 上層作業代號"
        ''' <summary>
        ''' UPPER_OPERATE_CD 上層作業代號
        ''' </summary>
        Public Property UPPER_OPERATE_CD() As String
            Get
                Return Me.ColumnyMap("UPPER_OPERATE_CD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPPER_OPERATE_CD") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT 系統排序("
        ''' <summary>
        ''' SYS_SORT 系統排序(
        ''' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.ColumnyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#End Region
	
#Region "自訂方法"
#Region "AddSystemTask 新增系統作業 "
        ''' <summary>
        ''' 新增系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub AddSystemTask()
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
                'EntSystemTask = new EntSystemTask()
                'return EntSystemTask.Insert()
                Dim ent As EntSystemTask = New EntSystemTask(Me.DBManager, Me.LogUtil)
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_NM = Me.OPERATE_NM       '作業名稱
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.OPERATE_SORT = Me.OPERATE_SORT     '作業排序
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteSystemTask 刪除系統作業 "
        ''' <summary>
        ''' 刪除系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Sub DeleteSystemTask()
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
                'EntSystemTask = new EntSystemTask()
                '組合查詢字串(EntSystemTask.QUERY_COND(查詢條件),"=",Pkno,SYS_CD(系統代號),OPERATE_CD(作業代號))
                'return EntSystemTask.Delete()
                Dim ent As EntSystemTask = New EntSystemTask(Me.DBManager, Me.LogUtil)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)   '系統代號
                Me.ProcessQueryCondition(condition, "=", "OPERATE_CD", Me.OPERATE_CD)   '作業代號

                ent.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                ent.Delete()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetSystem 取得系統 "
        ''' <summary>
        ''' 取得系統 
        ''' </summary>
        Public Function GetSystem() As DataTable
            Return Me.GetSystem(0, 0)
        End Function

        ''' <summary>
        ''' 取得系統 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetSystem(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名轉換 ===
                Me.TableCoumnInfo = New ArrayList()
                Me.TableCoumnInfo.Add(New String() {"AUTC010", "M", "PKNO", "SYS_CD", "SYS_NM", "EDU_FG", "SYS_CHARGE", "SYS_AGT"})
               
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)    'PKNO
                Me.ProcessQueryCondition(condition, "=", "EDU_FG", Me.EDU_FG)  '教學務別
                Me.ProcessQueryCondition(condition, "=", "SYS_AGT", Me.SYS_AGT) '系統代理人
                Me.ProcessQueryCondition(condition, "=", "SYS_CD", Me.SYS_CD)  '系統代號
                Me.ProcessQueryCondition(condition, "=", "SYS_NM", Me.SYS_NM)  '系統名稱
                Me.ProcessQueryCondition(condition, "=", "SYS_CHARGE", Me.SYS_CHARGE)  '系統負責人

                Me.SqlRetrictions = condition.ToString()
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select A.SYS_CD(系統代號),A.SYS_NM(系統名稱),A.EDU_FG(教學務別),A.SYS_CHARGE(系統負責人),A.CH_NAME(中文姓名) as CHARGE_NAME(負責人姓名),A.SYS_AGT(系統代理人),C.CH_NAME(中文姓名) as AGT_NAME(代理人姓名)
                'From AUTC010 A,POST020 B,POST020 C 
                'where A.SYS_CHARGE(系統負責人)=B.ACNT(帳號) and A.SYS_AGT(系統代理人)=C.ACNT(帳號) and 
                'A.Pkno=QUERY_COND(查詢條件) and A.SYS_CD(系統代號)=QUERY_COND(查詢條件) and A.SYS_NM(系統名稱)=QUERY_COND(查詢條件) and A.EDU_FG(教學務別)=QUERY_COND(查詢條件) and A.SYS_CHARGE(系統負責人)=QUERY_COND(查詢條件) 
                'and A.SYS_AGT(系統代理人)=QUERY_COND(查詢條件)

                Dim sql As StringBuilder = New StringBuilder()
                sql.Append("SELECT M.PKNO, M.SYS_CD, M.SYS_NM, M.EDU_FG, M.SYS_CHARGE,M.SYS_SORT, R1.CH_NAME AS CHARGE_NAME, ")
                sql.Append("M.SYS_AGT, M.ROWSTAMP, R2.CH_NAME AS AGT_NAME,R3.PRJ_NAME ")
                sql.Append("FROM AUTC010 M WITH(NOLOCK) ")
                sql.Append("LEFT OUTER JOIN POST020 R1 WITH(NOLOCK) ON M.SYS_CHARGE = R1.ACNT ")
                sql.Append("LEFT OUTER JOIN POST020 R2 WITH(NOLOCK) ON M.SYS_AGT	= R2.ACNT ")
                sql.Append("LEFT OUTER JOIN autc011 R3 WITH(NOLOCK) ON M.EDU_FG	= R3.EDU_FG ")

                If Me.SqlRetrictions.Length > 0 Then
                    sql.Append("WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If pageNo = 0 Then
                    sql.Append(" ORDER BY M.SYS_CD")
                Else
                    sql.Append(" ORDER BY SYS_CD")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString(), pageNo, pageSize)
                If pageNo > 0 Then
                    Me.TOTAL_ROW_COUNT = Me.TotalRowCount()
                End If
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSystemNmDDL 取得系統名稱下拉 "
        ''' <summary>
        ''' 取得系統名稱下拉 
        ''' </summary>
        Public Function GetSystemNmDDL() As DataTable
            Return Me.GetSystemNmDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得系統名稱下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystemNmDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'Select SYS_CD(系統代號) as value ,系統代號||系統名稱 as text From AUTC010

                Dim sql As String = _
                 "SELECT M.SYS_CD + '-' + M.SYS_NM AS SELECT_TEXT, M.SYS_CD AS SELECT_VALUE " & _
                 "FROM AUTC010 M WITH(NOLOCK) "

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql &= " WHERE " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", "M.")
                End If

                Sql &= " ORDER BY SYS_CD "

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSystemTask 取得系統作業 "
        ''' <summary>
        ''' 取得系統作業 
        ''' </summary>
        Public Function GetSystemTask() As DataTable
            Return Me.GetSystemTask(0, 0)
        End Function

        ''' <summary>
        ''' 取得系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/04/07 Fix 未傳入分頁資訊給查詢方法 Bug
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetSystemTask(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntSystemTask = new EntSystemTask()
                'return EntSystemTask.GetSystemTask_取得系統作業()
                Dim ent As EntSystemTask = New EntSystemTask(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.SYS_CD = Me.SYS_CD       '系統代號

                Dim dt As DataTable = ent.GetSystemTask(pageNo, pageSize)
                Me.TOTAL_ROW_COUNT = ent.TOTAL_ROW_COUNT
                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSystemTaskNmDDL 取得系統作業名稱下拉 "
        ''' <summary>
        ''' 取得系統作業名稱下拉 
        ''' </summary>
        Public Function GetSystemTaskNmDDL() As DataTable
            Return Me.GetSystemTaskNmDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得系統作業名稱下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetSystemTaskNmDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                'EntSystemTask = new EntSystemTask()
                'return EntSystemTask.GetSystemTaskNmDDL_取得系統作業名稱下拉()
                Dim ent As EntSystemTask = New EntSystemTask(Me.DBManager, Me.LogUtil)
                ent.SYS_CD = Me.SYS_CD
                Dim dt As DataTable = ent.GetSystemTaskNmDDL(pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateSystemTask 更新系統作業 "
        ''' <summary>
        ''' 更新系統作業 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function UpdateSystemTask() As Integer
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
                'EntSystemTask = new EntSystemTask()
                'return EntSystemTask.UpdateByPkno()
                Dim ent As EntSystemTask = New EntSystemTask(Me.DBManager, Me.LogUtil)
                ent.PKNO = Me.PKNO         'Pkno
                ent.UPPER_OPERATE_CD = Me.UPPER_OPERATE_CD '上層作業代號
                ent.OPERATE_CD = Me.OPERATE_CD       '作業代號
                ent.OPERATE_NM = Me.OPERATE_NM       '作業名稱
                ent.OPERATE_LEVEL = Me.OPERATE_LEVEL    '作業層級
                ent.OPERATE_SORT = Me.OPERATE_SORT     '作業排序
                ent.SYS_CD = Me.SYS_CD       '系統代號
                ent.ROWSTAMP = Me.ROWSTAMP
                Dim count As Integer = ent.UpdateByPkNo()

                Me.ResetColumnProperty()

                Return count
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetEduFgDDL 取得專案別下拉 "
        ''' <summary>
        ''' 取得專案別下拉 
        ''' </summary>
        Public Function GetEduFgDDL() As DataTable
            Return Me.GetEduFgDDL(0, 0)
        End Function

        ''' <summary>
        ''' 取得專案別下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 nono 2009/03/14 新增方法
        ''' </remarks>
        Public Function GetEduFgDDL(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                'Select SYS_CD(系統代號) as value ,系統代號||系統名稱 as text From AUTC010

                Dim sql As String = _
                 "SELECT EDU_FG + '-' + PRJ_NAME AS SELECT_TEXT, EDU_FG AS SELECT_VALUE,SYS_SORT,PRJ_NAME,EDU_FG " & _
                 "FROM AUTC011 " & _
                 "ORDER BY SYS_SORT,EDU_FG"

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region
#End Region

        Public Overrides Function Insert() As String
            MyBase.SET_NULL_FIELD = "SYS_SORT"
            Return MyBase.Insert()
        End Function

        Public Overrides Function Update() As Integer
            MyBase.SET_NULL_FIELD = "SYS_SORT"
            Return MyBase.Update()
        End Function

        Public Overrides Function UpdateByPkNo() As Integer
            MyBase.SET_NULL_FIELD = "SYS_SORT"
            Return MyBase.UpdateByPkNo()
        End Function
	End Class
End NameSpace