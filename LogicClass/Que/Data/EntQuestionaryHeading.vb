'----------------------------------------------------------------------------------
'File Name		: EntQuestionaryHeading
'Author			:  
'Description		: EntQuestionaryHeading 問卷單題目ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1     2016/11/11       Source Create COPY FROM
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Que.Data
    '' <summary>
    '' EntQuestionaryHeading 問卷單題目ENT
    '' </summary>
    Public Class EntQuestionaryHeading
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
            Me.TableName = "QUET040"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            Me.SET_NULL_FIELD = "SUBJECT_BS,IS_FILL,QSTNNR_FORMAT,SUBJECT_STATUS_NO,SUBJECT_SEQ,SUBJECT_TROVMGP"

            '=== 關聯 Class ===
            Me.EntQuestionaryItem = New EntQuestionaryItem(Me.DBManager, Me.LogUtil)

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"
#Region "EntQuestionaryItem 問卷單選項ENT[]"
        ''' <summary>
        ''' EntQuestionaryItem 問卷單選項ENT[]
        ''' </summary>
        Public Property EntQuestionaryItem() As EntQuestionaryItem
            Get
                Return Me.PropertyMap("EntQuestionaryItem")
            End Get
            Set(ByVal value As EntQuestionaryItem)
                Me.PropertyMap("EntQuestionaryItem") = value
            End Set
        End Property
#End Region

#Region "IS_FILL 是否必填"
        ''' <summary>
        ''' IS_FILL 是否必填
        ''' </summary>
        Public Property IS_FILL() As String
            Get
                Return Me.ColumnyMap("IS_FILL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_FILL") = value
            End Set
        End Property
#End Region

#Region "JUMP_NO 跳題號碼"
        ''' <summary>
        ''' JUMP_NO 跳題號碼
        ''' </summary>
        Public Property JUMP_NO() As String
            Get
                Return Me.ColumnyMap("JUMP_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_NO") = value
            End Set
        End Property
#End Region

#Region "MENU_STYLE 選單樣式"
        ''' <summary>
        ''' MENU_STYLE 選單樣式
        ''' </summary>
        Public Property MENU_STYLE() As String
            Get
                Return Me.ColumnyMap("MENU_STYLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_STYLE") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_BS 題目大小"
        ''' <summary>
        ''' SUBJECT_BS 題目大小
        ''' </summary>
        Public Property SUBJECT_BS() As String
            Get
                Return Me.ColumnyMap("SUBJECT_BS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_BS") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_CONTENT 題目內容"
        ''' <summary>
        ''' SUBJECT_CONTENT 題目內容
        ''' </summary>
        Public Property SUBJECT_CONTENT() As String
            Get
                Return Me.ColumnyMap("SUBJECT_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_CONTENT") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_STATUS 題目狀態"
        ''' <summary>
        ''' SUBJECT_STATUS 題目狀態
        ''' </summary>
        Public Property SUBJECT_STATUS() As String
            Get
                Return Me.ColumnyMap("SUBJECT_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_STATUS") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_NO 題目號碼"
        ''' <summary>
        ''' SUBJECT_NO 題目號碼
        ''' </summary>
        Public Property SUBJECT_NO() As String
            Get
                Return Me.ColumnyMap("SUBJECT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_NO") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TYPE 題目類別"
        ''' <summary>
        ''' SUBJECT_TYPE 題目類別
        ''' </summary>
        Public Property SUBJECT_TYPE() As String
            Get
                Return Me.ColumnyMap("SUBJECT_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_TYPE") = value
            End Set
        End Property
#End Region

#Region "MENU_TROVMGP 選單權數"
        ''' <summary>
        ''' MENU_TROVMGP 選單權數
        ''' </summary>
        Public Property MENU_TROVMGP() As String
            Get
                Return Me.ColumnyMap("MENU_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_TROVMGP") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TROVMGP 題目權數"
        ''' <summary>
        ''' SUBJECT_TROVMGP 題目權數
        ''' </summary>
        Public Property SUBJECT_TROVMGP() As String
            Get
                Return Me.ColumnyMap("SUBJECT_TROVMGP")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_TROVMGP") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_RMK 題目備註"
        ''' <summary>
        ''' SUBJECT_RMK 題目備註
        ''' </summary>
        Public Property SUBJECT_RMK() As String
            Get
                Return Me.ColumnyMap("SUBJECT_RMK")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_RMK") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_TITLE 題目標號"
        ''' <summary>
        ''' SUBJECT_TITLE 題目標號
        ''' </summary>
        Public Property SUBJECT_TITLE() As String
            Get
                Return Me.ColumnyMap("SUBJECT_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_TITLE") = value
            End Set
        End Property
#End Region

#Region "MENU_CONTENT 選單內容"
        ''' <summary>
        ''' MENU_CONTENT 選單內容
        ''' </summary>
        Public Property MENU_CONTENT() As String
            Get
                Return Me.ColumnyMap("MENU_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_CONTENT") = value
            End Set
        End Property
#End Region

#Region "MENU_NO 選單號碼"
        ''' <summary>
        ''' MENU_NO 選單號碼
        ''' </summary>
        Public Property MENU_NO() As String
            Get
                Return Me.ColumnyMap("MENU_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_NO") = value
            End Set
        End Property
#End Region

#Region "JUMP_CONTENT 跳題內容"
        ''' <summary>
        ''' JUMP_CONTENT 跳題內容
        ''' </summary>
        Public Property JUMP_CONTENT() As String
            Get
                Return Me.ColumnyMap("JUMP_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_CONTENT") = value
            End Set
        End Property
#End Region

#Region "MENU_TITLE 選單標號"
        ''' <summary>
        ''' MENU_TITLE 選單標號
        ''' </summary>
        Public Property MENU_TITLE() As String
            Get
                Return Me.ColumnyMap("MENU_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_TITLE") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_SEQ 題目排序"
        ''' <summary>
        ''' SUBJECT_SEQ 題目排序
        ''' </summary>
        Public Property SUBJECT_SEQ() As String
            Get
                Return Me.ColumnyMap("SUBJECT_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_SEQ") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_NO 問卷號碼"
        ''' <summary>
        ''' QSTNNR_NO 問卷號碼
        ''' </summary>
        Public Property QSTNNR_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_NO") = value
            End Set
        End Property
#End Region

#Region "VECTOR_NO 向度號碼"
        ''' <summary>
        ''' VECTOR_NO 向度號碼
        ''' </summary>
        Public Property VECTOR_NO() As String
            Get
                Return Me.ColumnyMap("VECTOR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("VECTOR_NO") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_MAX 題目上限 "
        ''' <summary>
        ''' SUBJECT_MAX 題目上限 
        ''' </summary>
        Public Property SUBJECT_MAX() As String
            Get
                Return Me.ColumnyMap("SUBJECT_MAX")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_MAX") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_MIN 題目下限"
        ''' <summary>
        ''' SUBJECT_MIN 題目下限
        ''' </summary>
        Public Property SUBJECT_MIN() As String
            Get
                Return Me.ColumnyMap("SUBJECT_MIN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_MIN") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_FORMAT"
        ''' <summary>
        ''' QSTNNR_FORMAT
        ''' </summary>
        Public Property QSTNNR_FORMAT() As String
            Get
                Return Me.ColumnyMap("QSTNNR_FORMAT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_FORMAT") = value
            End Set
        End Property
#End Region

#Region "MENU_RMK 選單備註"
        ''' <summary>
        ''' MENU_RMK 選單備註
        ''' </summary>
        Public Property MENU_RMK() As String
            Get
                Return Me.PropertyMap("MENU_RMK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MENU_RMK") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_STATUS_NO 題目狀態數"
        ''' <summary>
        ''' SUBJECT_STATUS_NO 題目狀態數
        ''' </summary>
        Public Property SUBJECT_STATUS_NO() As String
            Get
                Return Me.ColumnyMap("SUBJECT_STATUS_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_STATUS_NO") = value
            End Set
        End Property
#End Region

#Region "PARENT_SNO 父項題目號碼"
        Public Property PARENT_SNO As String
            Get
                Return Me.ColumnyMap("PARENT_SNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARENT_SNO") = value
            End Set
        End Property
#End Region

#Region "PARENT_MNO 父項選單號碼"
        Public Property PARENT_MNO As String
            Get
                Return Me.ColumnyMap("PARENT_MNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PARENT_MNO") = value
            End Set
        End Property
#End Region

#End Region

#Region "自訂方法"
#Region "AddItem 新增題目選項 "
        ''' <summary>
        ''' 新增題目選項 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Sub AddItem()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 選單內容 ===

                '=== 選單樣式 ===
                If String.IsNullOrEmpty(Me.MENU_STYLE) Then
                    faileArguments.Add("MENU_STYLE")
                End If
                '=== 題目號碼 ===
                If String.IsNullOrEmpty(Me.SUBJECT_NO) Then
                    faileArguments.Add("SUBJECT_NO")
                End If
                '=== 選單權數 ===
                If String.IsNullOrEmpty(Me.MENU_TROVMGP) Then
                    faileArguments.Add("MENU_TROVMGP")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                ' Me.ParserAlias()
                Me.EntQuestionaryItem.MENU_NO = Me.MENU_NO
                Me.EntQuestionaryItem.QSTNNR_NO = Me.QSTNNR_NO    '問卷號碼
                Me.EntQuestionaryItem.MENU_CONTENT = Me.MENU_CONTENT '選單內容
                Me.EntQuestionaryItem.MENU_TITLE = Me.MENU_TITLE   '選單標號
                Me.EntQuestionaryItem.MENU_STYLE = Me.MENU_STYLE   '選單樣式
                Me.EntQuestionaryItem.MENU_TROVMGP = Me.MENU_TROVMGP '選單權數
                Me.EntQuestionaryItem.SUBJECT_NO = Me.SUBJECT_NO   '題目號碼
                Me.EntQuestionaryItem.MENU_RMK = Me.MENU_RMK   '選單備註

                Me.EntQuestionaryItem.Insert()

              
                Me.ResetColumnProperty()


            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "ClearItem 取消跳題 "
        ''' <summary>
        ''' 取消跳題 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Sub ClearItem()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                '   Me.ParserAlias()

                '=== 處理說明 ===
                EntQuestionaryItem.JUMP_NO = ""
                EntQuestionaryItem.JUMP_CONTENT = ""
                EntQuestionaryItem.SqlRetrictions = " QSTNNR_NO='" & Me.QSTNNR_NO & "'"
                EntQuestionaryItem.Update()

                'Dim sql As String = ""

                'Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteItem 刪除題目選項 "
        ''' <summary>
        ''' 刪除題目選項 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteItem()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 題目號碼 ===
                If String.IsNullOrEmpty(Me.SUBJECT_NO) Then
                    faileArguments.Add("SUBJECT_NO")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                ' Me.ParserAlias()
                Dim condition As StringBuilder = New StringBuilder()

                Me.ProcessQueryCondition(condition, "=", "QSTNNR_NO", Me.QSTNNR_NO)   '問卷號碼
                Me.ProcessQueryCondition(condition, "=", "SUBJECT_NO", Me.SUBJECT_NO)   '題目號碼
                Me.EntQuestionaryItem.SqlRetrictions = " 1=1 " & condition.ToString()
                EntQuestionaryItem.Delete()
                '=== 處理說明 ===
                'EntQuestionaryItem = new EntQuestionaryItem
                '
                'EntQuestionaryItem.Delete()


                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "QueryHeading 查詢題目 "
        ''' <summary>
        ''' 查詢題目 
        ''' </summary>
        Public Function QueryHeading() As DataTable
            Return Me.QueryHeading(0, 0)
        End Function

        ''' <summary>
        ''' 查詢題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryHeading(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntQuestionaryHeading.Query()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryHeadingMaxNo 查詢最大題目號碼 "
        ''' <summary>
        ''' 查詢最大題目號碼 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryHeadingMaxNo() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    faileArguments.Add("SqlRetrictions")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                '   Me.ParserAlias()

                '=== 處理說明 ===
                '抓取題目最大號碼+1

                Dim sql As String = "SELECT ISNULL(MAX(CONVERT(INT,SUBJECT_NO))+1,1) AS MAXNO FROM QUET040 "

                Dim dt As DataTable = Me.QueryBySql(sql)
                Dim ruslt As String = String.Empty
                If dt.Rows.Count > 0 Then
                    ruslt = dt.Rows(0)("MAXNO").ToString
                Else
                    ruslt = "1"
                End If

                Me.ResetColumnProperty()

                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryHeadingTypeDDL 查詢題目題型下拉 "
        ''' <summary>
        ''' 查詢題目題型下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryHeadingTypeDDL() As DataTable
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
                '寫死 
                'CHECKBOX-多選,
                'RADIO-單選圈選,
                'DROPDOWNLIST-單選下拉,
                'TEXT-問答式

                Dim dt As New DataTable
                dt.Columns.Add("SELECT_VALUE", Type.GetType("System.String"))
                dt.Columns.Add("SELECT_TEXT", Type.GetType("System.String"))

                Dim dr As DataRow

                dr = dt.NewRow
                dr("SELECT_VALUE") = "2" '"CHECKBOX"
                dr("SELECT_TEXT") = "多選"
                dt.Rows.Add(dr)

                dr = dt.NewRow
                dr("SELECT_VALUE") = "1" '"RADIO"
                dr("SELECT_TEXT") = "單選" '"單選圈選"
                dt.Rows.Add(dr)

                'dr = dt.NewRow
                'dr("SELECT_VALUE") = "DROPDOWNLIST"
                'dr("SELECT_TEXT") = "單選下拉"
                'dt.Rows.Add(dr)

                dr = dt.NewRow
                dr("SELECT_VALUE") = "3" '"TEXT"
                dr("SELECT_TEXT") = "問答式"
                dt.Rows.Add(dr)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryItem 查詢題目選項 "
        ''' <summary>
        ''' 查詢題目選項 
        ''' </summary>
        Public Function QueryItem() As DataTable
            Return Me.QueryItem(0, 0)
        End Function

        ''' <summary>
        ''' 查詢題目選項 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryItem(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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

                '=== 處理說明 ===
                'EntQuestionaryItem = new EntQuestionaryItem
                '
                '組合查詢字串(
                'EntQuestionaryItem.QUERY_COND(查詢條件),"=",QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼))
                '
                'EntQuestionaryItem.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                '
                '
                'EntQuestionaryItem.Query()

                Me.EntQuestionaryItem.SqlRetrictions = Me.SqlRetrictions

                Dim dt As DataTable = EntQuestionaryItem.Query(pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢(覆寫掉原來的方法)
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                ''=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                '    faileArguments.Add("SqlRetrictions")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                ' Me.ParserAlias()

                '=== 處理說明 ===
                '使用 QUET040,QUET030
                '
                'QUET040 跟 QUET030 作關聯 on VECTOR_NO(向度號碼)
                '
                '類型名稱=
                'CHECKBOX-多選,
                'RADIO-單選圈選,
                'DROPDOWNLIST-單選下拉,
                'TEXT-問答式

                Dim sql As StringBuilder = New StringBuilder

                sql.Append("SELECT M.*,R1.VECTOR_NAME,R1.VECTOR_TITLE,R1.VECTOR_SEQ,R1.VECTOR_TYPE,R1.VECTOR_BS,")
                'sql.Append("CASE WHEN M.SUBJECT_STATUS='CHECKBOX' THEN '多選' WHEN M.SUBJECT_STATUS='RADIO' THEN '單選' WHEN M.SUBJECT_STATUS='DROPDOWNLIST' THEN '單選下拉'  WHEN M.SUBJECT_STATUS='TEXT' THEN '問答式' END AS SUBJECT_STATUS_NAME ")
                sql.Append("CASE WHEN M.SUBJECT_STATUS='2' THEN '多選' WHEN M.SUBJECT_STATUS='1' THEN '單選' WHEN M.SUBJECT_STATUS='3' THEN '問答式' END AS SUBJECT_STATUS_NAME ")
                sql.Append("FROM QUET040 M ")
                sql.Append("LEFT JOIN QUET030 R1 ON M.QSTNNR_NO=R1.QSTNNR_NO AND M.VECTOR_NO=R1.VECTOR_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.Append(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", "M."))
                End If

                sql.Append(" ORDER BY VECTOR_SEQ*1,SUBJECT_SEQ*1 ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryItemDDL 查詢文字框下拉 "
        ''' <summary>
        ''' 查詢文字框下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryItemDDL() As DataTable
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
                '寫死 
                'none-無
                'text_100_0-單行(長度:100)
                'textarea_20_5-多行(寬:20 高:5)

                Dim dt As New DataTable
                dt.Columns.Add("SELECT_VALUE", Type.GetType("System.String"))
                dt.Columns.Add("SELECT_TEXT", Type.GetType("System.String"))

                Dim dr As DataRow

                dr = dt.NewRow
                dr("SELECT_VALUE") = "NONE"
                dr("SELECT_TEXT") = "無"
                dt.Rows.Add(dr)

                dr = dt.NewRow
                dr("SELECT_VALUE") = "TEXT_100_0"
                dr("SELECT_TEXT") = "單行"
                dt.Rows.Add(dr)

                dr = dt.NewRow
                dr("SELECT_VALUE") = "TEXTAREA_100_5"
                dr("SELECT_TEXT") = "多行"
                dt.Rows.Add(dr)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateItem 設定跳題 "
        ''' <summary>
        ''' 設定跳題 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateItem() As Integer
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
                '更新跳題號碼,JUMP_CONTENT(跳題內容)
                'AEntQuestionaryItem = NEW EntQuestionaryItem()
                '
                '組合查詢字串(
                'AEntQuestionaryItem.QUERY_COND(查詢條件),"=",QSTNNR_NO(問卷號碼),SUBJECT_NO(題目號碼),MENU_NO(選單號碼))
                'AEntQuestionaryItem.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                'AEntQuestionaryItem.Update()

                Me.EntQuestionaryItem.SqlRetrictions = Me.ProcessCondition(Me.SqlRetrictions)

                Me.EntQuestionaryItem.JUMP_NO = Me.JUMP_NO
                Me.EntQuestionaryItem.JUMP_CONTENT = Me.JUMP_CONTENT

                Dim updateCount As Integer = Me.EntQuestionaryItem.Update

                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace

