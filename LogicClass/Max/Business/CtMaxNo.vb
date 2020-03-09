'----------------------------------------------------------------------------------
'File Name		: CtMaxNo 
'Author			: Ethan
'Description		: CtMaxNo 最大號作業Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/09/16	Ethan   	Source Create
'----------------------------------------------------------------------------------

Imports Max.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Max.Business
    ''' <summary>
    ''' CtMaxNo 最大號作業Ct
    ''' </summary>
    Partial Public Class CtMaxNo
        Inherits Acer.Base.ControlBase

#Region "屬性"
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

#Region "ASSORTMENT_CODE 分類代碼"
        ''' <summary>
        ''' ASSORTMENT_CODE 分類代碼
        ''' </summary>
        Public Property ASSORTMENT_CODE() As String
            Get
                Return Me.PropertyMap("ASSORTMENT_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ASSORTMENT_CODE") = value
            End Set
        End Property
#End Region

#Region "COND_CHARA 條件字串"
        ''' <summary>
        ''' COND_CHARA 條件字串
        ''' </summary>
        Public Property COND_CHARA() As String
            Get
                Return Me.PropertyMap("COND_CHARA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COND_CHARA") = value
            End Set
        End Property
#End Region

#Region "EntMaxNo 最大號ENT"
        ''' <summary>
        ''' EntMaxNo 最大號ENT
        ''' </summary>
        Private Property EntMaxNo() As EntMaxNo
            Get
                Return Me.PropertyMap("EntMaxNo")
            End Get
            Set(ByVal value As EntMaxNo)
                Me.PropertyMap("EntMaxNo") = value
            End Set
        End Property
#End Region

#Region "SYS_CODE 系統代碼"
        ''' <summary>
        ''' SYS_CODE 系統代碼
        ''' </summary>
        Public Property SYS_CODE() As String
            Get
                Return Me.PropertyMap("SYS_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_CODE") = value
            End Set
        End Property
#End Region

#Region "USE_MAX_NO 使用最大號碼"
        ''' <summary>
        ''' USE_MAX_NO 使用最大號碼
        ''' </summary>
        Public Property USE_MAX_NO() As String
            Get
                Return Me.PropertyMap("USE_MAX_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_MAX_NO") = value
            End Set
        End Property
#End Region

#Region "SEQUENCE_NO_LEN 流水號碼長度"
        ''' <summary>
        ''' SEQUENCE_NO_LEN 流水號碼長度
        ''' </summary>
        Public Property SEQUENCE_NO_LEN() As String
            Get
                Return Me.PropertyMap("SEQUENCE_NO_LEN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SEQUENCE_NO_LEN") = value
            End Set
        End Property
#End Region

#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===
            Me.EntMaxNo = New EntMaxNo(Me.DBManager, Me.LogUtil)

        End Sub
#End Region

#Region "方法"

#Region "DeleteMaxNo 刪除最大號"
        ''' <summary>
        ''' 刪除最大號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub DeleteMaxNo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== Pkno ===
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("Pkno")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntMaxNo= NEW EntMaxNo()
                'return AEntMaxNo.DeleteByPkno()
                Me.EntMaxNo.PKNO = Me.PKNO
                Me.EntMaxNo.DeleteByPkNo()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetLastNo 取得最後最大號"
        ''' <summary>
        ''' 取得最後最大號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetLastNo() As String
            Try
                Dim result As Integer
                Dim strNo As String = ""

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 分類代碼 ===
                If String.IsNullOrEmpty(Me.ASSORTMENT_CODE) Then
                    faileArguments.Add("ASSORTMENT_CODE")
                End If
                '=== 系統代碼 ===
                If String.IsNullOrEmpty(Me.SYS_CODE) Then
                    faileArguments.Add("SYS_CODE")
                End If
                '=== 條件字串 ===
                If String.IsNullOrEmpty(Me.COND_CHARA) Then
                    faileArguments.Add("COND_CHARA")
                End If

                '=== 流水號碼長度 ===
                If String.IsNullOrEmpty(Me.SEQUENCE_NO_LEN) Then
                    faileArguments.Add("SEQUENCE_NO_LEN")
                End If
                '=== 查詢條件 ===
                'If String.IsNullOrEmpty(Me.QUERY_COND) Then
                '    faileArguments.Add("QUERY_COND")
                'End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntMaxNo= NEW EntMaxNo()
                '
                '
                '組合查詢字串(
                'AEntMaxNo.QUERY_COND(查詢條件),"=",SYS_CODE(系統代碼))
                '
                '組合查詢字串(
                'AEntMaxNo.QUERY_COND(查詢條件),"=",PROGRAM_CODE(程式代碼))
                '
                '組合查詢字串(
                'AEntMaxNo查詢條件,"=",TABLE_CODE(表格代碼))
                '
                '
                '
                'AEntMaxNo.QUERY_COND(查詢條件)=me.
                '組合查詢字串
                '
                'Return AEntMaxNo.GetLastNoFromEnt()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ASSORTMENT_CODE", Me.ASSORTMENT_CODE)     '分類代碼
                Me.ProcessQueryCondition(condition, "=", "SYS_CODE", Me.SYS_CODE)                   '系統代碼
                Me.ProcessQueryCondition(condition, "=", "COND_CHARA", Me.COND_CHARA)               '條件字串
                Me.ProcessQueryCondition(condition, "=", "SEQUENCE_NO_LEN", Me.SEQUENCE_NO_LEN)     '流水號碼長度

                Me.EntMaxNo.SqlRetrictions = condition.ToString

                result = Me.EntMaxNo.GetLastNoFromEnt()

                strNo = result.ToString.PadLeft(CInt(SEQUENCE_NO_LEN), "0")

                Me.ResetColumnProperty()

                Return strNo

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetMaxNo 建立最大號"
        ''' <summary>
        ''' 建立最大號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetMaxNo() As String
            Try
                Dim result As DataTable
                Dim maxNo As String = ""

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 分類代碼 ===
                If String.IsNullOrEmpty(Me.ASSORTMENT_CODE) Then
                    faileArguments.Add("ASSORTMENT_CODE")
                End If
                '=== 系統代碼 ===
                If String.IsNullOrEmpty(Me.SYS_CODE) Then
                    faileArguments.Add("SYS_CODE")
                End If
                '=== 條件字串 ===
                If String.IsNullOrEmpty(Me.COND_CHARA) Then
                    faileArguments.Add("COND_CHARA")
                End If

                '=== 流水號碼長度 ===
                If String.IsNullOrEmpty(Me.SEQUENCE_NO_LEN) Then
                    faileArguments.Add("SEQUENCE_NO_LEN")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntMaxNo= NEW EntEntMaxNo()
                '
                '組合查詢字串(
                'AEntMaxNo.QUERY_COND(查詢條件),"=",SYS_CODE(系統代碼))
                '
                '組合查詢字串(
                'AEntMaxNo.QUERY_COND(查詢條件),"=",ASSORTMENT_CODE(分類代碼))
                '
                '組合查詢字串(
                'AEntMaxNo.QUERY_COND(查詢條件)," =",COND_CHARA(條件字串))
                '
                '
                'AEntMaxNo.QUERY_COND(查詢條件)=me.組合查詢字串
                '
                '
                'Private DT = AEntMaxNo.Query()
                '
                'if ( DT.ROWS.Count > 0 )   
                '   CtMaxNo.SYS_CODE(系統代碼) = DT.Rows[0][SYS_CODE(系統代碼)]
                '   CtMaxNo.ASSORTMENT_CODE(分類代碼) = DT.Rows[0][ASSORTMENT_CODE(分類代碼)]
                '   CtMaxNo.COND_CHARA(條件字串) = DT.Rows[0][COND_CHARA(條件字串)]
                '   CtMaxNo.USE_MAX_NO(使用最大號碼) = DT.Rows[0][USE_MAX_NO(使用最大號碼)]+1
                '   AEntMaxNo.Update()
                '   private strZero = ""
                '   For (int i = 1 to DT.Rows[0][SEQUENCE_NO_LEN(流水號碼長度)])
                '         strZero = strZero+"0"
                '   EndFor
                '   return CtMaxNo.USE_MAX_NO(使用最大號碼).ToString(strZero)
                'else
                '   CtMaxNo.SYS_CODE(系統代碼) = DT.Rows[0][SYS_CODE(系統代碼)]
                '   CtMaxNo.ASSORTMENT_CODE(分類代碼) = DT.Rows[0][ASSORTMENT_CODE(分類代碼)]
                '   CtMaxNo.COND_CHARA(條件字串) = DT.Rows[0][COND_CHARA(條件字串)]
                '   CtMaxNo.USE_MAX_NO(使用最大號碼) = 1
                '   AEntMaxNo.Insert()
                '   For (int i = 1 to DT.Rows[0][SEQUENCE_NO_LEN(流水號碼長度)])
                '         strZero = strZero+"0"
                '   EndFor
                '   return CtMaxNo.USE_MAX_NO(使用最大號碼).ToString(strZero)
                'endif
                Dim isBatch As String = Me.IS_BATCH
                Dim icount As Integer = 0
                While icount = 0

                    Dim condition As StringBuilder = New StringBuilder()
                    Me.ProcessQueryCondition(condition, "=", "ASSORTMENT_CODE", Me.ASSORTMENT_CODE)     '分類代碼
                    Me.ProcessQueryCondition(condition, "=", "SYS_CODE", Me.SYS_CODE)                   '系統代碼
                    Me.ProcessQueryCondition(condition, "=", "COND_CHARA", Me.COND_CHARA)               '條件字串
                    Me.ProcessQueryCondition(condition, "=", "SEQUENCE_NO_LEN", Me.SEQUENCE_NO_LEN)     '流水號碼長度

                    Me.EntMaxNo.SqlRetrictions = condition.ToString

                    result = Me.EntMaxNo.Query

                    If result.Rows.Count > 0 Then
                        Dim condition1 As StringBuilder = New StringBuilder()

                        Me.EntMaxNo.USE_MAX_NO = CInt(result.Rows(0).Item("USE_MAX_NO").ToString) + 1
                        '   Me.EntMaxNo.PKNO = result.Rows(0).Item("PKNO").ToString
                        Me.ProcessQueryCondition(condition1, "=", "PKNO", result.Rows(0).Item("PKNO").ToString)     '分類代碼
                        Me.ProcessQueryCondition(condition1, "=", "ROWSTAMP", result.Rows(0).Item("ROWSTAMP").ToString)                   '系統代碼
                        EntMaxNo.SqlRetrictions = Me.ProcessCondition(condition1.ToString)
                        
                        If isBatch = "Y" Then
                            EntMaxNo.SetUserId("batch")
                        Else
                            Me.EntMaxNo.SetUserId("ACER1") '//2010/12/20 政諺 新增
                        End If

                        icount = Me.EntMaxNo.Update() '.UpdateByPkNo()

                        maxNo = (CInt(result.Rows(0).Item("USE_MAX_NO").ToString)).ToString.PadLeft(CInt(result.Rows(0).Item("SEQUENCE_NO_LEN").ToString), "0")
                    Else
                        Me.EntMaxNo.ASSORTMENT_CODE = Me.ASSORTMENT_CODE
                        Me.EntMaxNo.COND_CHARA = Me.COND_CHARA
                        Me.EntMaxNo.SYS_CODE = Me.SYS_CODE
                        Me.EntMaxNo.SEQUENCE_NO_LEN = Me.SEQUENCE_NO_LEN
                        If USE_MAX_NO <> "" Then
                            Me.EntMaxNo.USE_MAX_NO = USE_MAX_NO
                        Else
                            Me.EntMaxNo.USE_MAX_NO = 1
                        End If

                        If isBatch = "Y" Then
                            EntMaxNo.SetUserId("batch")
                        End If

                        Me.EntMaxNo.Insert()

                        maxNo = 1.ToString.PadLeft(CInt(Me.SEQUENCE_NO_LEN), "0")
                    End If
                End While

                Me.ResetColumnProperty()

                Return maxNo
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "InsertMaxNo 新增最大號"
        ''' <summary>
        ''' 新增最大號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub InsertMaxNo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 分類代碼 ===
                If String.IsNullOrEmpty(Me.ASSORTMENT_CODE) Then
                    faileArguments.Add("ASSORTMENT_CODE")
                End If
                '=== 使用最大號碼 ===
                If String.IsNullOrEmpty(Me.USE_MAX_NO) Then
                    faileArguments.Add("USE_MAX_NO")
                End If
                '=== 系統代碼 ===
                If String.IsNullOrEmpty(Me.SYS_CODE) Then
                    faileArguments.Add("SYS_CODE")
                End If
                '=== 條件字串 ===
                If String.IsNullOrEmpty(Me.COND_CHARA) Then
                    faileArguments.Add("COND_CHARA")
                End If
                '=== 流水號碼長度 ===
                If String.IsNullOrEmpty(Me.SEQUENCE_NO_LEN) Then
                    faileArguments.Add("SEQUENCE_NO_LEN")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'AEntMaxNo= NEW EntEntMaxNo()
                '
                '
                'return AEntMaxNo.Insert()

                Me.EntMaxNo.ASSORTMENT_CODE = Me.ASSORTMENT_CODE
                Me.EntMaxNo.COND_CHARA = Me.COND_CHARA
                Me.EntMaxNo.USE_MAX_NO = Me.USE_MAX_NO
                Me.EntMaxNo.SYS_CODE = Me.SYS_CODE
                Me.EntMaxNo.SEQUENCE_NO_LEN = Me.SEQUENCE_NO_LEN

                Me.EntMaxNo.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateMaxNo 修改最大號"
        ''' <summary>
        ''' 修改最大號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub UpdateMaxNo()
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
                'AEntMaxNo= NEW EntMaxNo()
                'return AEntMaxNo.UpdateByPkno()
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ASSORTMENT_CODE", Me.ASSORTMENT_CODE)     '分類代碼
                Me.ProcessQueryCondition(condition, "=", "SYS_CODE", Me.SYS_CODE)                   '系統代碼
                Me.ProcessQueryCondition(condition, "=", "COND_CHARA", Me.COND_CHARA)               '條件字串
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)     '流水號碼長度

                Me.EntMaxNo.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Me.EntMaxNo.USE_MAX_NO = Me.USE_MAX_NO
                Me.EntMaxNo.SEQUENCE_NO_LEN = Me.SEQUENCE_NO_LEN

                Me.EntMaxNo.Update()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#End Region
    End Class
End Namespace