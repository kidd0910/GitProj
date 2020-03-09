'----------------------------------------------------------------------------------
'File Name		: APP1040
'Author			: TIM
'Description		: APP1040 營運計畫摘要表
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/28	TIM		Source Create
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
    ' APP1040 營運計畫摘要表
    ' </summary>
    Public Class ENT_APP1040
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
            Me.TableName = "APP1040"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,BUSIN_PRO_PLAN,DISPUTE_HAN_MECH,INFORM_DISC_PLAN,BUSIN_PHIL_CHAR,MARK_RES_DATA,CHANNEL_STRATEGY,NAT_CHANNELS_NUM,OVER_CHANNELS_NUM,PACK_COM_PLAN,SIN_POINT_CHAN_PLAN,SHOPPING_CHANNELS,TOTAL_CHANNELS,PROPORTION,INTER_CON_ORG_NAME,INTER_CON_ORG_INS,CHARGE_BASE,PAT_REF_METHOD"
            Me.SET_NULL_FIELD = ""
        End Sub
#End Region

#Region "屬性"
#Region "CASE_NO 案件編號"
        '' <summary>
        '' CASE_NO 案件編號
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "BUSIN_PRO_PLAN 業務推廣計畫"
        '' <summary>
        '' BUSIN_PRO_PLAN 業務推廣計畫
        '' </summary>
        Public Property BUSIN_PRO_PLAN() As String
            Get
                Return Me.ColumnyMap("BUSIN_PRO_PLAN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSIN_PRO_PLAN") = value
            End Set
        End Property
#End Region

#Region "DISPUTE_HAN_MECH 爭議處理機制"
        '' <summary>
        '' DISPUTE_HAN_MECH 爭議處理機制
        '' </summary>
        Public Property DISPUTE_HAN_MECH() As String
            Get
                Return Me.ColumnyMap("DISPUTE_HAN_MECH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DISPUTE_HAN_MECH") = value
            End Set
        End Property
#End Region

#Region "INFORM_DISC_PLAN 資訊公開措施規畫"
        '' <summary>
        '' INFORM_DISC_PLAN 資訊公開措施規畫
        '' </summary>
        Public Property INFORM_DISC_PLAN() As String
            Get
                Return Me.ColumnyMap("INFORM_DISC_PLAN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INFORM_DISC_PLAN") = value
            End Set
        End Property
#End Region

#Region "BUSIN_PHIL_CHAR 經營理念及特色"
        '' <summary>
        '' BUSIN_PHIL_CHAR 經營理念及特色
        '' </summary>
        Public Property BUSIN_PHIL_CHAR() As String
            Get
                Return Me.ColumnyMap("BUSIN_PHIL_CHAR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("BUSIN_PHIL_CHAR") = value
            End Set
        End Property
#End Region

#Region "MARK_RES_DATA 市場調查資料"
        '' <summary>
        '' MARK_RES_DATA 市場調查資料
        '' </summary>
        Public Property MARK_RES_DATA() As String
            Get
                Return Me.ColumnyMap("MARK_RES_DATA")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MARK_RES_DATA") = value
            End Set
        End Property
#End Region

#Region "CHANNEL_STRATEGY 頻道屬性區塊化編排策略"
        '' <summary>
        '' CHANNEL_STRATEGY 頻道屬性區塊化編排策略
        '' </summary>
        Public Property CHANNEL_STRATEGY() As String
            Get
                Return Me.ColumnyMap("CHANNEL_STRATEGY")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANNEL_STRATEGY") = value
            End Set
        End Property
#End Region

#Region "NAT_CHANNELS_NUM 本國頻道數"
        '' <summary>
        '' NAT_CHANNELS_NUM 本國頻道數
        '' </summary>
        Public Property NAT_CHANNELS_NUM() As String
            Get
                Return Me.ColumnyMap("NAT_CHANNELS_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NAT_CHANNELS_NUM") = value
            End Set
        End Property
#End Region

#Region "OVER_CHANNELS_NUM 境外頻道數"
        '' <summary>
        '' OVER_CHANNELS_NUM 境外頻道數
        '' </summary>
        Public Property OVER_CHANNELS_NUM() As String
            Get
                Return Me.ColumnyMap("OVER_CHANNELS_NUM")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OVER_CHANNELS_NUM") = value
            End Set
        End Property
#End Region

#Region "PACK_COM_PLAN 套餐組合規畫"
        '' <summary>
        '' PACK_COM_PLAN 套餐組合規畫
        '' </summary>
        Public Property PACK_COM_PLAN() As String
            Get
                Return Me.ColumnyMap("PACK_COM_PLAN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PACK_COM_PLAN") = value
            End Set
        End Property
#End Region

#Region "SIN_POINT_CHAN_PLAN 單點頻道規畫"
        '' <summary>
        '' SIN_POINT_CHAN_PLAN 單點頻道規畫
        '' </summary>
        Public Property SIN_POINT_CHAN_PLAN() As String
            Get
                Return Me.ColumnyMap("SIN_POINT_CHAN_PLAN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SIN_POINT_CHAN_PLAN") = value
            End Set
        End Property
#End Region

#Region "SHOPPING_CHANNELS 購物頻道數"
        '' <summary>
        '' SHOPPING_CHANNELS 購物頻道數
        '' </summary>
        Public Property SHOPPING_CHANNELS() As String
            Get
                Return Me.ColumnyMap("SHOPPING_CHANNELS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SHOPPING_CHANNELS") = value
            End Set
        End Property
#End Region

#Region "TOTAL_CHANNELS 頻道總數"
        '' <summary>
        '' TOTAL_CHANNELS 頻道總數
        '' </summary>
        Public Property TOTAL_CHANNELS() As String
            Get
                Return Me.ColumnyMap("TOTAL_CHANNELS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOTAL_CHANNELS") = value
            End Set
        End Property
#End Region

#Region "PROPORTION 比例"
        '' <summary>
        '' PROPORTION 比例
        '' </summary>
        Public Property PROPORTION() As String
            Get
                Return Me.ColumnyMap("PROPORTION")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PROPORTION") = value
            End Set
        End Property
#End Region

#Region "INTER_CON_ORG_NAME 內部控管組織名稱"
        '' <summary>
        '' INTER_CON_ORG_NAME 內部控管組織名稱
        '' </summary>
        Public Property INTER_CON_ORG_NAME() As String
            Get
                Return Me.ColumnyMap("INTER_CON_ORG_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTER_CON_ORG_NAME") = value
            End Set
        End Property
#End Region

#Region "INTER_CON_ORG_INS 內部控管組織運作說明"
        '' <summary>
        '' INTER_CON_ORG_INS 內部控管組織運作說明
        '' </summary>
        Public Property INTER_CON_ORG_INS() As String
            Get
                Return Me.ColumnyMap("INTER_CON_ORG_INS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("INTER_CON_ORG_INS") = value
            End Set
        End Property
#End Region

#Region "CHARGE_BASE 收費基準"
        '' <summary>
        '' CHARGE_BASE 收費基準
        '' </summary>
        Public Property CHARGE_BASE() As String
            Get
                Return Me.ColumnyMap("CHARGE_BASE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHARGE_BASE") = value
            End Set
        End Property
#End Region

#Region "PAT_REF_METHOD 訂戶繳退費方式"
        '' <summary>
        '' PAT_REF_METHOD 訂戶繳退費方式
        '' </summary>
        Public Property PAT_REF_METHOD() As String
            Get
                Return Me.ColumnyMap("PAT_REF_METHOD")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("PAT_REF_METHOD") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "DoWordQuery 查詢 "

        Public Function DoWordQuery() As DataTable
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
                Me.TableCoumnInfo.Add(New String() {"APP1040", "M", ""})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "R1", "APP_PERSON_NM", "SYS_CNAME"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.*, R1.APP_PERSON_NM ,R1.SYS_CNAME ")
                sql.AppendLine(" FROM APP1040 M ")
                sql.AppendLine(" LEFT JOIN APP1010 R1 ON M.CASE_NO = R1.CASE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    sql.AppendLine(" ORDER BY M.PKNO ")
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, 0, 0)

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

