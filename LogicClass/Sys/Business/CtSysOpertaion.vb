'----------------------------------------------------------------------------------
'File Name		: CtSysOperation
'Author			:  
'Description		: CtSysOperation 系統下拉選單代碼ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		 
'----------------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Sys.Business
    ''' <summary>
    ''' CtSysOperation 系統下拉選單代碼ct
    ''' </summary>
    Partial Public Class CtSysOperation
        Inherits Acer.Base.ControlBase

#Region "屬性"

#Region "SYS_KEY"
        '' <summary>
        '' SYS_KEY
        '' </summary>
        Public Property SYS_KEY() As String
            Get
                Return Me.PropertyMap("SYS_KEY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_KEY") = value
            End Set
        End Property
#End Region

#Region "SYS_PRTID"
        '' <summary>
        '' SYS_PRTID
        '' </summary>
        Public Property SYS_PRTID() As String
            Get
                Return Me.PropertyMap("SYS_PRTID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_PRTID") = value
            End Set
        End Property
#End Region

#Region "SYS_ID"
        '' <summary>
        '' SYS_ID
        '' </summary>
        Public Property SYS_ID() As String
            Get
                Return Me.PropertyMap("SYS_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_ID") = value
            End Set
        End Property
#End Region

#Region "SYS_NAME"
        '' <summary>
        '' SYS_NAME
        '' </summary>
        Public Property SYS_NAME() As String
            Get
                Return Me.PropertyMap("SYS_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_NAME") = value
            End Set
        End Property
#End Region

#Region "SYS_TYPE"
        '' <summary>
        '' SYS_TYPE
        '' </summary>
        Public Property SYS_TYPE() As String
            Get
                Return Me.PropertyMap("SYS_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_TYPE") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV1"
        '' <summary>
        '' SYS_RSV1
        '' </summary>
        Public Property SYS_RSV1() As String
            Get
                Return Me.PropertyMap("SYS_RSV1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV1") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV2"
        '' <summary>
        '' SYS_RSV2
        '' </summary>
        Public Property SYS_RSV2() As String
            Get
                Return Me.PropertyMap("SYS_RSV2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV2") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV3"
        '' <summary>
        '' SYS_RSV3
        '' </summary>
        Public Property SYS_RSV3() As String
            Get
                Return Me.PropertyMap("SYS_RSV3")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV3") = value
            End Set
        End Property
#End Region

#Region "SYS_RSV4"
        '' <summary>
        '' SYS_RSV4
        '' </summary>
        Public Property SYS_RSV4() As String
            Get
                Return Me.PropertyMap("SYS_RSV4")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_RSV4") = value
            End Set
        End Property
#End Region

#Region "SYS_SORT"
        '' <summary>
        '' SYS_SORT
        '' </summary>
        Public Property SYS_SORT() As String
            Get
                Return Me.PropertyMap("SYS_SORT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SYS_SORT") = value
            End Set
        End Property
#End Region

#Region "USE_STATE"
        '' <summary>
        '' USE_STATE
        '' </summary>
        Public Property USE_STATE() As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "REMARK"
        '' <summary>
        '' REMARK
        '' </summary>
        Public Property REMARK() As String
            Get
                Return Me.PropertyMap("REMARK")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("REMARK") = value
            End Set
        End Property
#End Region

#Region "QUERY_COND 查詢條件"
        ''' <summary>
        ''' QUERY_COND 查詢條件
        ''' </summary>
        Public Property QUERY_COND() As String
            Get
                Return Me.PropertyMap("QUERY_COND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QUERY_COND") = value
            End Set
        End Property
#End Region

#Region "CASE_NO 案件編號"
        ''' <summary>
        ''' 案件編號
        ''' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "ITEM_TYPE ITEM_TYPE"
        ''' <summary>
        ''' ITEM_TYPE
        ''' </summary>
        Public Property ITEM_TYPE() As String
            Get
                Return Me.PropertyMap("ITEM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ITEM_TYPE") = value
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

        End Sub
#End Region

#Region "方法"
#Region "Get系統下拉資料"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function Get系統下拉資料() As DataTable
            Try

                Dim AENT_SYST010 As ENT_SYST010 = New ENT_SYST010(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "SYS_KEY", Me.SYS_KEY) '代碼屬性
                Me.ProcessQueryCondition(condition, "=", "SYS_PRTID", Me.SYS_PRTID) '參數父代碼
                Me.ProcessQueryCondition(condition, "=", "SYS_ID", Me.SYS_ID) '參數代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_NAME", Me.SYS_NAME) '參數名稱
                Me.ProcessQueryCondition(condition, "=", "SYS_TYPE", Me.SYS_TYPE) '屬性分類
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT) '系統排序
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE) '使用狀態
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK) '備註

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                AENT_SYST010.OrderBys = Me.OrderBys
                AENT_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = AENT_SYST010.Get系統下拉資料()
                Else
                    result = AENT_SYST010.Get系統下拉資料(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = AENT_SYST010.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get頁籤功能"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function GetTabs() As DataTable
            Try

                Dim AENT_SYST010 As ENT_SYST010 = New ENT_SYST010(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "SYS_KEY", Me.SYS_KEY) '代碼屬性
                Me.ProcessQueryCondition(condition, "=", "SYS_PRTID", Me.SYS_PRTID) '參數父代碼
                Me.ProcessQueryCondition(condition, "=", "SYS_ID", Me.SYS_ID) '參數代碼
                Me.ProcessQueryCondition(condition, "%LIKE%", "SYS_NAME", Me.SYS_NAME) '參數名稱
                Me.ProcessQueryCondition(condition, "=", "SYS_TYPE", Me.SYS_TYPE) '屬性分類
                Me.ProcessQueryCondition(condition, "=", "SYS_SORT", Me.SYS_SORT) '系統排序
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE) '使用狀態
                Me.ProcessQueryCondition(condition, "%LIKE%", "REMARK", Me.REMARK) '備註

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                AENT_SYST010.OrderBys = Me.OrderBys
                AENT_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = AENT_SYST010.GetTabs()
                Else
                    result = AENT_SYST010.GetTabs(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = AENT_SYST010.TotalRowCount
                End If

                Me.ResetColumnProperty()
                Return result

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "Get審X費類別"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function Get審X費類別() As DataTable
            Try

                Dim AENT_SYST010 As ENT_SYST010 = New ENT_SYST010(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                AENT_SYST010.CASE_NO = Me.CASE_NO
                AENT_SYST010.ITEM_TYPE = Me.ITEM_TYPE

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                AENT_SYST010.OrderBys = Me.OrderBys
                AENT_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable = AENT_SYST010.Get審X費類別()
               
                Me.ResetColumnProperty()
                Return result

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "Get客製化訊息"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function Get客製化訊息(ByVal id As String) As String
            Try

                Dim ent As Msg.Data.ENT_MSG010 = New Msg.Data.ENT_MSG010(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = "  MSG_NO ='" & id & "'"
                Dim result As DataTable = ent.Query()
                Dim msg As String = "查無自訂訊息!"

                If result.Rows.Count = 1 Then
                    msg = result.Rows(0).Item("MSG_DESC").ToString
                End If

                Me.ResetColumnProperty()
                Return msg

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "Get資產類別"
        ''' <summary>
        ''' 進行查詢動作
        ''' </summary>
        Public Function Get資產類別() As DataTable
            Try

                Dim AENT_SYST010 As ENT_SYST010 = New ENT_SYST010(Me.DBManager, Me.LogUtil)

                Dim condition As StringBuilder = New StringBuilder()
                AENT_SYST010.SYS_KEY = "FINANCE_CODE1"
                'AENT_SYST010.ITEM_TYPE = Me.ITEM_TYPE

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                AENT_SYST010.OrderBys = Me.OrderBys
                AENT_SYST010.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As DataTable = AENT_SYST010.Get資產類別()

                Me.ResetColumnProperty()
                Return result

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region
    End Class
End Namespace