'ProductName                 : TSBA 
'File Name					 : CtAPP1040 
'Description	             : CtAPP1040 營運計畫摘要表
'Modification Log	:
'
'Vers           Date        By          Notes
'---------------------------------------------------------------------------
'0.0.1	        2017/11/28  TIM      Source Create
'---------------------------------------------------------------------------

Imports App.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace App.Business
    Partial Public Class CtAPP1040
        Inherits Acer.Base.ControlBase

#Region "建構子"
        '' <summary>
        '' 建構子
        '' </summary>
        '' <param name="dbManager">dbManager 物件</param>
        '' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.Ent_APP1040 = New ENT_APP1040(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.PropertyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "BUSIN_PRO_PLAN 業務推廣計畫"
        '' <summary>
        '' BUSIN_PRO_PLAN 業務推廣計畫
        '' </summary>
        Public Property BUSIN_PRO_PLAN() As String
            Get
                Return Me.PropertyMap("BUSIN_PRO_PLAN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSIN_PRO_PLAN") = value
            End Set
        End Property
#End Region

#Region "DISPUTE_HAN_MECH 爭議處理機制"
        '' <summary>
        '' DISPUTE_HAN_MECH 爭議處理機制
        '' </summary>
        Public Property DISPUTE_HAN_MECH() As String
            Get
                Return Me.PropertyMap("DISPUTE_HAN_MECH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DISPUTE_HAN_MECH") = value
            End Set
        End Property
#End Region

#Region "INFORM_DISC_PLAN 資訊公開措施規畫"
        '' <summary>
        '' INFORM_DISC_PLAN 資訊公開措施規畫
        '' </summary>
        Public Property INFORM_DISC_PLAN() As String
            Get
                Return Me.PropertyMap("INFORM_DISC_PLAN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INFORM_DISC_PLAN") = value
            End Set
        End Property
#End Region

#Region "BUSIN_PHIL_CHAR 經營理念及特色"
        '' <summary>
        '' BUSIN_PHIL_CHAR 經營理念及特色
        '' </summary>
        Public Property BUSIN_PHIL_CHAR() As String
            Get
                Return Me.PropertyMap("BUSIN_PHIL_CHAR")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("BUSIN_PHIL_CHAR") = value
            End Set
        End Property
#End Region

#Region "MARK_RES_DATA 市場調查資料"
        '' <summary>
        '' MARK_RES_DATA 市場調查資料
        '' </summary>
        Public Property MARK_RES_DATA() As String
            Get
                Return Me.PropertyMap("MARK_RES_DATA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MARK_RES_DATA") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_STRATEGY 頻道屬性區塊化編排策略"
        '' <summary>
        '' CHANNEL_STRATEGY 頻道屬性區塊化編排策略
        '' </summary>
        Public Property CHANNEL_STRATEGY() As String
            Get
                Return Me.PropertyMap("CHANNEL_STRATEGY")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHANNEL_STRATEGY") = value
            End Set
        End Property
#End Region

#Region "NAT_CHANNELS_NUM 本國頻道數"
        '' <summary>
        '' NAT_CHANNELS_NUM 本國頻道數
        '' </summary>
        Public Property NAT_CHANNELS_NUM() As String
            Get
                Return Me.PropertyMap("NAT_CHANNELS_NUM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NAT_CHANNELS_NUM") = value
            End Set
        End Property
#End Region

#Region "OVER_CHANNELS_NUM 境外頻道數"
        '' <summary>
        '' OVER_CHANNELS_NUM 境外頻道數
        '' </summary>
        Public Property OVER_CHANNELS_NUM() As String
            Get
                Return Me.PropertyMap("OVER_CHANNELS_NUM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OVER_CHANNELS_NUM") = value
            End Set
        End Property
#End Region

#Region "PACK_COM_PLAN 套餐組合規畫"
        '' <summary>
        '' PACK_COM_PLAN 套餐組合規畫
        '' </summary>
        Public Property PACK_COM_PLAN() As String
            Get
                Return Me.PropertyMap("PACK_COM_PLAN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PACK_COM_PLAN") = value
            End Set
        End Property
#End Region

#Region "SIN_POINT_CHAN_PLAN 單點頻道規畫"
        '' <summary>
        '' SIN_POINT_CHAN_PLAN 單點頻道規畫
        '' </summary>
        Public Property SIN_POINT_CHAN_PLAN() As String
            Get
                Return Me.PropertyMap("SIN_POINT_CHAN_PLAN")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SIN_POINT_CHAN_PLAN") = value
            End Set
        End Property
#End Region

#Region "SHOPPING_CHANNELS 購物頻道數"
        '' <summary>
        '' SHOPPING_CHANNELS 購物頻道數
        '' </summary>
        Public Property SHOPPING_CHANNELS() As String
            Get
                Return Me.PropertyMap("SHOPPING_CHANNELS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SHOPPING_CHANNELS") = value
            End Set
        End Property
#End Region

#Region "TOTAL_CHANNELS 頻道總數"
        '' <summary>
        '' TOTAL_CHANNELS 頻道總數
        '' </summary>
        Public Property TOTAL_CHANNELS() As String
            Get
                Return Me.PropertyMap("TOTAL_CHANNELS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TOTAL_CHANNELS") = value
            End Set
        End Property
#End Region

#Region "PROPORTION 比例"
        '' <summary>
        '' PROPORTION 比例
        '' </summary>
        Public Property PROPORTION() As String
            Get
                Return Me.PropertyMap("PROPORTION")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PROPORTION") = value
            End Set
        End Property
#End Region

#Region "INTER_CON_ORG_NAME 內部控管組織名稱"
        '' <summary>
        '' INTER_CON_ORG_NAME 內部控管組織名稱
        '' </summary>
        Public Property INTER_CON_ORG_NAME() As String
            Get
                Return Me.PropertyMap("INTER_CON_ORG_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTER_CON_ORG_NAME") = value
            End Set
        End Property
#End Region

#Region "INTER_CON_ORG_INS 內部控管組織運作說明"
        '' <summary>
        '' INTER_CON_ORG_INS 內部控管組織運作說明
        '' </summary>
        Public Property INTER_CON_ORG_INS() As String
            Get
                Return Me.PropertyMap("INTER_CON_ORG_INS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("INTER_CON_ORG_INS") = value
            End Set
        End Property
#End Region

#Region "CHARGE_BASE 收費基準"
        '' <summary>
        '' CHARGE_BASE 收費基準
        '' </summary>
        Public Property CHARGE_BASE() As String
            Get
                Return Me.PropertyMap("CHARGE_BASE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CHARGE_BASE") = value
            End Set
        End Property
#End Region

#Region "PAT_REF_METHOD 訂戶繳退費方式"
        '' <summary>
        '' PAT_REF_METHOD 訂戶繳退費方式
        '' </summary>
        Public Property PAT_REF_METHOD() As String
            Get
                Return Me.PropertyMap("PAT_REF_METHOD")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAT_REF_METHOD") = value
            End Set
        End Property
#End Region

#Region "Ent_APP1040"
        ' <summary>Ent_APP1040</ summary>
        Private Property Ent_APP1040() As ENT_APP1040
            Get
                Return Me.PropertyMap("Ent_APP1040")
            End Get
            Set(ByVal value As ENT_APP1040)
                Me.PropertyMap("Ent_APP1040") = value
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
                Me.Ent_APP1040.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1040.BUSIN_PRO_PLAN = Me.BUSIN_PRO_PLAN        '業務推廣計畫
                Me.Ent_APP1040.DISPUTE_HAN_MECH = Me.DISPUTE_HAN_MECH        '爭議處理機制
                Me.Ent_APP1040.INFORM_DISC_PLAN = Me.INFORM_DISC_PLAN        '資訊公開措施規畫
                Me.Ent_APP1040.BUSIN_PHIL_CHAR = Me.BUSIN_PHIL_CHAR      '經營理念及特色
                Me.Ent_APP1040.MARK_RES_DATA = Me.MARK_RES_DATA      '市場調查資料
                Me.Ent_APP1040.CHANNEL_STRATEGY = Me.CHANNEL_STRATEGY        '頻道屬性區塊化編排策略
                Me.Ent_APP1040.NAT_CHANNELS_NUM = Me.NAT_CHANNELS_NUM        '本國頻道數
                Me.Ent_APP1040.OVER_CHANNELS_NUM = Me.OVER_CHANNELS_NUM      '境外頻道數
                Me.Ent_APP1040.PACK_COM_PLAN = Me.PACK_COM_PLAN      '套餐組合規畫
                Me.Ent_APP1040.SIN_POINT_CHAN_PLAN = Me.SIN_POINT_CHAN_PLAN      '單點頻道規畫
                Me.Ent_APP1040.SHOPPING_CHANNELS = Me.SHOPPING_CHANNELS      '購物頻道數
                Me.Ent_APP1040.TOTAL_CHANNELS = Me.TOTAL_CHANNELS        '頻道總數
                Me.Ent_APP1040.PROPORTION = Me.PROPORTION        '比例
                Me.Ent_APP1040.INTER_CON_ORG_NAME = Me.INTER_CON_ORG_NAME        '內部控管組織名稱
                Me.Ent_APP1040.INTER_CON_ORG_INS = Me.INTER_CON_ORG_INS      '內部控管組織運作說明
                Me.Ent_APP1040.CHARGE_BASE = Me.CHARGE_BASE      '收費基準
                Me.Ent_APP1040.PAT_REF_METHOD = Me.PAT_REF_METHOD        '訂戶繳退費方式


                '=== 設定處理新增動作 ===
                Dim result As String = Me.Ent_APP1040.Insert()

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
                Me.Ent_APP1040.CASE_NO = Me.CASE_NO      '案件編號
                Me.Ent_APP1040.BUSIN_PRO_PLAN = Me.BUSIN_PRO_PLAN        '業務推廣計畫
                Me.Ent_APP1040.DISPUTE_HAN_MECH = Me.DISPUTE_HAN_MECH        '爭議處理機制
                Me.Ent_APP1040.INFORM_DISC_PLAN = Me.INFORM_DISC_PLAN        '資訊公開措施規畫
                Me.Ent_APP1040.BUSIN_PHIL_CHAR = Me.BUSIN_PHIL_CHAR      '經營理念及特色
                Me.Ent_APP1040.MARK_RES_DATA = Me.MARK_RES_DATA      '市場調查資料
                Me.Ent_APP1040.CHANNEL_STRATEGY = Me.CHANNEL_STRATEGY        '頻道屬性區塊化編排策略
                Me.Ent_APP1040.NAT_CHANNELS_NUM = Me.NAT_CHANNELS_NUM        '本國頻道數
                Me.Ent_APP1040.OVER_CHANNELS_NUM = Me.OVER_CHANNELS_NUM      '境外頻道數
                Me.Ent_APP1040.PACK_COM_PLAN = Me.PACK_COM_PLAN      '套餐組合規畫
                Me.Ent_APP1040.SIN_POINT_CHAN_PLAN = Me.SIN_POINT_CHAN_PLAN      '單點頻道規畫
                Me.Ent_APP1040.SHOPPING_CHANNELS = Me.SHOPPING_CHANNELS      '購物頻道數
                Me.Ent_APP1040.TOTAL_CHANNELS = Me.TOTAL_CHANNELS        '頻道總數
                Me.Ent_APP1040.PROPORTION = Me.PROPORTION        '比例
                Me.Ent_APP1040.INTER_CON_ORG_NAME = Me.INTER_CON_ORG_NAME        '內部控管組織名稱
                Me.Ent_APP1040.INTER_CON_ORG_INS = Me.INTER_CON_ORG_INS      '內部控管組織運作說明
                Me.Ent_APP1040.CHARGE_BASE = Me.CHARGE_BASE      '收費基準
                Me.Ent_APP1040.PAT_REF_METHOD = Me.PAT_REF_METHOD        '訂戶繳退費方式


                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)
                Me.ProcessQueryCondition(condition, "=", "ROWSTAMP", Me.ROWSTAMP)
                Me.Ent_APP1040.SqlRetrictions = Me.ProcessCondition(condition.ToString())


                '=== 處理修改資料動作 ===
                Dim updateCount = Me.Ent_APP1040.Update()

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
                Me.Ent_APP1040.SqlRetrictions = Me.ProcessCondition(condition.ToString())



                '=== 刪除資料 ===
                If Me.Ent_APP1040.SqlRetrictions <> "" Then '安全避免沒有條件全刪
                    Me.Ent_APP1040.Delete()
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
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.ProcessQueryCondition(condition, "=", "BUSIN_PRO_PLAN", Me.BUSIN_PRO_PLAN)        '業務推廣計畫
                Me.ProcessQueryCondition(condition, "=", "DISPUTE_HAN_MECH", Me.DISPUTE_HAN_MECH)        '爭議處理機制
                Me.ProcessQueryCondition(condition, "=", "INFORM_DISC_PLAN", Me.INFORM_DISC_PLAN)        '資訊公開措施規畫
                Me.ProcessQueryCondition(condition, "=", "BUSIN_PHIL_CHAR", Me.BUSIN_PHIL_CHAR)      '經營理念及特色
                Me.ProcessQueryCondition(condition, "=", "MARK_RES_DATA", Me.MARK_RES_DATA)      '市場調查資料
                Me.ProcessQueryCondition(condition, "=", "CHANNEL_STRATEGY", Me.CHANNEL_STRATEGY)        '頻道屬性區塊化編排策略
                Me.ProcessQueryCondition(condition, "=", "NAT_CHANNELS_NUM", Me.NAT_CHANNELS_NUM)        '本國頻道數
                Me.ProcessQueryCondition(condition, "=", "OVER_CHANNELS_NUM", Me.OVER_CHANNELS_NUM)      '境外頻道數
                Me.ProcessQueryCondition(condition, "=", "PACK_COM_PLAN", Me.PACK_COM_PLAN)      '套餐組合規畫
                Me.ProcessQueryCondition(condition, "=", "SIN_POINT_CHAN_PLAN", Me.SIN_POINT_CHAN_PLAN)      '單點頻道規畫
                Me.ProcessQueryCondition(condition, "=", "SHOPPING_CHANNELS", Me.SHOPPING_CHANNELS)      '購物頻道數
                Me.ProcessQueryCondition(condition, "=", "TOTAL_CHANNELS", Me.TOTAL_CHANNELS)        '頻道總數
                Me.ProcessQueryCondition(condition, "=", "PROPORTION", Me.PROPORTION)        '比例
                Me.ProcessQueryCondition(condition, "%LIKE%", "INTER_CON_ORG_NAME", Me.INTER_CON_ORG_NAME)       '內部控管組織名稱
                Me.ProcessQueryCondition(condition, "=", "INTER_CON_ORG_INS", Me.INTER_CON_ORG_INS)      '內部控管組織運作說明
                Me.ProcessQueryCondition(condition, "=", "CHARGE_BASE", Me.CHARGE_BASE)      '收費基準
                Me.ProcessQueryCondition(condition, "=", "PAT_REF_METHOD", Me.PAT_REF_METHOD)        '訂戶繳退費方式

                Me.Ent_APP1040.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1040.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1040.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.Ent_APP1040.Query()
                Else
                    result = Me.Ent_APP1040.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.Ent_APP1040.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "DoWordQuery 進行查詢動作"
        '' <summary>
        '' 進行Word Print查詢動作
        '' </summary>
        Public Function DoWordQuery() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 處理查詢條件 === 
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "IN", "PKNO", Me.PKNO)       'PKNO
                Me.ProcessQueryCondition(condition, "=", "CASE_NO", Me.CASE_NO)      '案件編號
                Me.Ent_APP1040.SqlRetrictions = condition.ToString()


                If (String.IsNullOrEmpty(Me.OrderBys)) Then
                    Me.Ent_APP1040.OrderBys = "PKNO"
                Else
                    Me.Ent_APP1040.OrderBys = Me.OrderBys
                End If

                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.Ent_APP1040.DoWordQuery()

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

