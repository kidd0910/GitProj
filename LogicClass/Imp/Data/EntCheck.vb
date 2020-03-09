'----------------------------------------------------------------------------------
'File Name		: EntCheck
'Author			: 
'Description		: EntCheck 檢核Ent
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/11/21			Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Imp.Data
	'' <summary>
	'' EntCheck 檢核Ent
	'' </summary>
	Public Class EntCheck
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
			Me.TableName = ""
			Me.SysName = "IMP"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===
			Me.IMP_FIELD = New Hashtable()
			'=== 處理別名 ===
		End Sub
#End Region

#Region "屬性"
#Region "CHECK_ITEM_NAME 檢核項目名稱"
		''' <summary>
		''' CHECK_ITEM_NAME 檢核項目名稱
		''' </summary>
		Public Property CHECK_ITEM_NAME() As String
			Get
				Return Me.ColumnyMap("CHECK_ITEM_NAME")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("CHECK_ITEM_NAME") = value
			End Set
		End Property
#End Region

#Region "IMP_FIELD[] 匯入欄位值[]"
		''' <summary>
		''' IMP_FIELD[] 匯入欄位值[]
		''' </summary>
		Public Property IMP_FIELD() As Hashtable
			Get
				Return Me.PropertyMap("IMP_FIELD")
			End Get
			Set(ByVal value As Hashtable)
				Me.PropertyMap("IMP_FIELD") = value
			End Set
		End Property
#End Region


#End Region

#Region "自訂方法"
#Region "ChkItem 檢核項目 "
		
		''' <summary>
		''' 檢核項目 
		''' </summary>
		''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' 0.0.2 KEN 新增 檢查繳費帳號 2008/12/05
		''' </remarks>
		Public Function ChkItem() As String
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 檢核項目名稱 ===
				If String.IsNullOrEmpty(Me.CHECK_ITEM_NAME) Then
					faileArguments.Add("CHECK_ITEM_NAME")
				End If

				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 檢核欄位結束 ===


				Dim msgStr As String = ""

				'=== 檢核項目名稱 ===
				Select Case Me.CHECK_ITEM_NAME
                    
                    Case "匯入金融機構"
                        '針對每筆資料再做處理
                      
                End Select

				Me.ResetColumnProperty()

				Return msgStr
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Function
#End Region

#Region "檢核IP CheckIPAddress"
        ''' <summary>
        ''' 檢核項目 
        ''' </summary>
        ''' 0.0.1 Shanlee 新增方法
        Public Shared Function CheckIPAddress(ByVal IP As String) As Boolean
            Dim pattern As String = "(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))"
            Dim regex As New System.Text.RegularExpressions.Regex(pattern)
            If regex.Match(IP).Success Then
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#End Region

	End Class
End Namespace

