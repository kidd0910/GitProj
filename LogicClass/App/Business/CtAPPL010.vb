'ProductName                 : BTEV 
'File Name					 : CtAPPL010 
'Description	             : CtAPPL010 機構資料
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/01/03  Becky      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPPL010
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APPL010 = New Ent_APPL010(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "INF_SOURCE "
        '' <summary>
        '' INF_SOURCE 
        '' </summary>
        Public Property INF_SOURCE() As String
            Get
                Return Me.PropertyMap("INF_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INF_SOURCE") = value
            End Set
        End Property
#End Region

#Region "COM_TYPE 機構類別"
        '' <summary>
        '' COM_TYPE 機構類別
        '' </summary>
        Public Property COM_TYPE() As String
            Get
                Return Me.PropertyMap("COM_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_TYPE") = value
            End Set
        End Property
#End Region

#Region "COM_CODE 機構代碼"
        '' <summary>
        '' COM_CODE 機構代碼
        '' </summary>
        Public Property COM_CODE() As String
            Get
                Return Me.PropertyMap("COM_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_CODE") = value
            End Set
        End Property
#End Region

#Region "OID"
        '' <summary>
        '' OID
        '' </summary>
        Public Property OID() As String
            Get
                Return Me.PropertyMap("OID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OID") = value
            End Set
        End Property
#End Region

#Region "BUS_NO 統一編號"
        '' <summary>
        '' BUS_NO 統一編號
        '' </summary>
        Public Property BUS_NO() As String
            Get
                Return Me.PropertyMap("BUS_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUS_NO") = value
            End Set
        End Property
#End Region

#Region "COM_CNAM 機構名稱"
        '' <summary>
        '' COM_CNAM 機構名稱
        '' </summary>
        Public Property COM_CNAM() As String
            Get
                Return Me.PropertyMap("COM_CNAM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_CNAM") = value
            End Set
        End Property
#End Region

#Region "COM_SNAM 機構簡稱"
        '' <summary>
        '' COM_SNAM 機構簡稱
        '' </summary>
        Public Property COM_SNAM() As String
            Get
                Return Me.PropertyMap("COM_SNAM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_SNAM") = value
            End Set
        End Property
#End Region

#Region "COM_ENAM 英文縮寫"
        '' <summary>
        '' COM_ENAM 英文縮寫
        '' </summary>
        Public Property COM_ENAM() As String
            Get
                Return Me.PropertyMap("COM_ENAM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_ENAM") = value
            End Set
        End Property
#End Region

#Region "CONTACT "
        '' <summary>
        '' CONTACT 
        '' </summary>
        Public Property CONTACT() As String
            Get
                Return Me.PropertyMap("CONTACT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        '' <summary>
        '' CONTACT_TEL 聯絡電話
        '' </summary>
        Public Property CONTACT_TEL() As String
            Get
                Return Me.PropertyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "CONTACT_EMAIL EMAIL"
        '' <summary>
        '' CONTACT_EMAIL EMAIL
        '' </summary>
        Public Property CONTACT_EMAIL() As String
            Get
                Return Me.PropertyMap("CONTACT_EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_EMAIL") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY1 住址"
        '' <summary>
        '' ADDR_CITY1 住址
        '' </summary>
        Public Property ADDR_CITY1() As String
            Get
                Return Me.PropertyMap("ADDR_CITY1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR_CITY1") = value
            End Set
        End Property
#End Region

#Region "ADDR_CITY2 住址"
        '' <summary>
        '' ADDR_CITY2 住址
        '' </summary>
        Public Property ADDR_CITY2() As String
            Get
                Return Me.PropertyMap("ADDR_CITY2")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR_CITY2") = value
            End Set
        End Property
#End Region

#Region "ADDR 住址"
        '' <summary>
        '' ADDR 住址
        '' </summary>
        Public Property ADDR() As String
            Get
                Return Me.PropertyMap("ADDR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ADDR") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 狀態"
        '' <summary>
        '' USE_STATE 狀態
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

#Region "COM_CNAM1 "
        '' <summary>
        '' COM_CNAM1 
        '' </summary>
        Public Property COM_CNAM1() As String
            Get
                Return Me.PropertyMap("COM_CNAM1")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COM_CNAM1") = value
            End Set
        End Property
#End Region

#Region "UP_COM_PKNO 上層機構"
        '' <summary>
        '' UP_COM_PKNO 上層機構
        '' </summary>
        Public Property UP_COM_PKNO() As String
            Get
                Return Me.PropertyMap("UP_COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UP_COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "VIRTUAL_COM 虛擬業者"
        '' <summary>
        '' VIRTUAL_COM 虛擬業者
        '' </summary>
        Public Property VIRTUAL_COM() As String
            Get
                Return Me.PropertyMap("VIRTUAL_COM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("VIRTUAL_COM") = value
            End Set
        End Property
#End Region

#Region "MODIFY_FLAG "
        '' <summary>
        '' MODIFY_FLAG 
        '' </summary>
        Public Property MODIFY_FLAG() As String
            Get
                Return Me.PropertyMap("MODIFY_FLAG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MODIFY_FLAG") = value
            End Set
        End Property
#End Region

#Region "Ent_APPL010"
        ' <summary>Ent_APPL010</ summary>
        Private Property Ent_APPL010() As Ent_APPL010
            Get
                Return Me.PropertyMap("Ent_APPL010")
            End Get
            Set(ByVal value As Ent_APPL010)
                Me.PropertyMap("Ent_APPL010") = value
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

#End Region

#Region "方法"
#Region "DoAdd 處理新增資料動作"
        '' <summary>
        '' 處理新增資料動作
        '' </summary>
        Public Function DoAdd() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 設定屬性參數 ===
                Me.Ent_APPL010.INF_SOURCE = Me.INF_SOURCE       '
                Me.Ent_APPL010.COM_TYPE = Me.COM_TYPE         '機構類別
                Me.Ent_APPL010.COM_CODE = Me.COM_CODE         '機構代碼
                Me.Ent_APPL010.BUS_NO = Me.BUS_NO       '統一編號
                Me.Ent_APPL010.OID = Me.OID
                Me.Ent_APPL010.COM_CNAM = Me.COM_CNAM         '機構名稱
                Me.Ent_APPL010.COM_SNAM = Me.COM_SNAM         '機構簡稱
                Me.Ent_APPL010.COM_ENAM = Me.COM_ENAM         '英文縮寫
                Me.Ent_APPL010.CONTACT = Me.CONTACT      '
                Me.Ent_APPL010.CONTACT_TEL = Me.CONTACT_TEL      '聯絡電話
                Me.Ent_APPL010.CONTACT_EMAIL = Me.CONTACT_EMAIL        'EMAIL
                Me.Ent_APPL010.ADDR_CITY1 = Me.ADDR_CITY1       '住址
                Me.Ent_APPL010.ADDR_CITY2 = Me.ADDR_CITY2       '住址
                Me.Ent_APPL010.ADDR = Me.ADDR         '住址
                Me.Ent_APPL010.USE_STATE = Me.USE_STATE        '狀態
                Me.Ent_APPL010.COM_CNAM1 = Me.COM_CNAM1        '
                Me.Ent_APPL010.UP_COM_PKNO = Me.UP_COM_PKNO      '上層機構
                Me.Ent_APPL010.VIRTUAL_COM = Me.VIRTUAL_COM      '虛擬業者
                Me.Ent_APPL010.MODIFY_FLAG = Me.MODIFY_FLAG      '


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APPL010.Insert()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoModify 處理修改資料動作"
        '' <summary>
        '' 處理修改資料動作
        '' </summary>
        Public Function DoModify() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Me.Ent_APPL010.INF_SOURCE = Me.INF_SOURCE       '
                Me.Ent_APPL010.COM_TYPE = Me.COM_TYPE         '機構類別
                Me.Ent_APPL010.COM_CODE = Me.COM_CODE         '機構代碼
                Me.Ent_APPL010.BUS_NO = Me.BUS_NO       '統一編號
                Me.Ent_APPL010.COM_CNAM = Me.COM_CNAM         '機構名稱
                Me.Ent_APPL010.COM_SNAM = Me.COM_SNAM         '機構簡稱
                Me.Ent_APPL010.COM_ENAM = Me.COM_ENAM         '英文縮寫
                Me.Ent_APPL010.CONTACT = Me.CONTACT      '
                Me.Ent_APPL010.CONTACT_TEL = Me.CONTACT_TEL      '聯絡電話
                Me.Ent_APPL010.CONTACT_EMAIL = Me.CONTACT_EMAIL        'EMAIL
                Me.Ent_APPL010.ADDR_CITY1 = Me.ADDR_CITY1       '住址
                Me.Ent_APPL010.ADDR_CITY2 = Me.ADDR_CITY2       '住址
                Me.Ent_APPL010.ADDR = Me.ADDR         '住址
                Me.Ent_APPL010.USE_STATE = Me.USE_STATE        '狀態
                Me.Ent_APPL010.COM_CNAM1 = Me.COM_CNAM1        '
                Me.Ent_APPL010.UP_COM_PKNO = Me.UP_COM_PKNO      '上層機構
                Me.Ent_APPL010.VIRTUAL_COM = Me.VIRTUAL_COM      '虛擬業者
                Me.Ent_APPL010.MODIFY_FLAG = Me.MODIFY_FLAG      '


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APPL010.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APPL010.Update()

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DoDelete 處理刪除資料動作"
        '' <summary>
        '' 處理刪除資料動作
        '' </summary>
        Public Sub DoDelete()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                If String.IsNullOrEmpty(Me.PKNO) Then
                    faileArguments.Add("PKNO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 設定屬性參數 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.Ent_APPL010.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APPL010.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APPL010.Delete()
                End If

                '=== 重設欄位屬性 ===
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DoQuery 進行查詢動作"
        '' <summary>
        '' 進行查詢動作
        '' </summary>
        Public Function DoQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "INF_SOURCE", Me.INF_SOURCE)        '
                Me.ProcessQueryCondition(condition, "=", "COM_TYPE", Me.COM_TYPE)        '機構類別
                Me.ProcessQueryCondition(condition, "=", "COM_CODE", Me.COM_CODE)        '機構代碼
                Me.ProcessQueryCondition(condition, "=", "BUS_NO", Me.BUS_NO)        '統一編號
                Me.ProcessQueryCondition(condition, "=", "OID", Me.OID)
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_CNAM", Me.COM_CNAM)       '機構名稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_SNAM", Me.COM_SNAM)       '機構簡稱
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_ENAM", Me.COM_ENAM)       '英文縮寫
                Me.ProcessQueryCondition(condition, "=", "CONTACT", Me.CONTACT)      '
                Me.ProcessQueryCondition(condition, "=", "CONTACT_TEL", Me.CONTACT_TEL)      '聯絡電話
                Me.ProcessQueryCondition(condition, "=", "CONTACT_EMAIL", Me.CONTACT_EMAIL)      'EMAIL
                Me.ProcessQueryCondition(condition, "=", "ADDR_CITY1", Me.ADDR_CITY1)        '住址
                Me.ProcessQueryCondition(condition, "=", "ADDR_CITY2", Me.ADDR_CITY2)        '住址
                Me.ProcessQueryCondition(condition, "=", "ADDR", Me.ADDR)        '住址
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)      '狀態
                Me.ProcessQueryCondition(condition, "%LIKE%", "COM_CNAM1", Me.COM_CNAM1)         '
                Me.ProcessQueryCondition(condition, "=", "UP_COM_PKNO", Me.UP_COM_PKNO)      '上層機構
                Me.ProcessQueryCondition(condition, "=", "VIRTUAL_COM", Me.VIRTUAL_COM)      '虛擬業者
                Me.ProcessQueryCondition(condition, "=", "MODIFY_FLAG", Me.MODIFY_FLAG)      '

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)
                Me.Ent_APPL010.SqlRetrictions = condition.ToString()

                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APPL010.OrderBys = "PKNO"
                Else
                    Me.Ent_APPL010.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APPL010.Query()
                Else
                    result = Me.Ent_APPL010.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APPL010.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetSubBusNo"
        ''' <summary>
        ''' GetSubBusNo 取得自己以下的單位
        ''' </summary>
        Public Function GetSubBusNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.Ent_APPL010.PKNO = Me.PKNO

                '=== 處理取得回傳資料===
                Dim result As DataTable = Me.Ent_APPL010.GetSubBusNo()

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

