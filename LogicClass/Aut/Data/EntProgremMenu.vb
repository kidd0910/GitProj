'----------------------------------------------------------------------------------
'File Name		: EntProgremMenu
'Author			: nono
'Description		: EntProgremMenu 程式目錄ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/03/20	nono		Source Create
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
	'' EntProgremMenu 程式目錄ENT
	'' </summary>
	Public Class EntProgremMenu 
		Inherits Acer.Base.EntityBase
		Implements Acer.Base.IEntityInterface 
		
	#Region "建構子"
		'' <summary>
		'' 建構子/處理屬性對應處理
		'' </summary>
		'' <param name="dt">DataTable 物件</param>
		Public Sub New (ByVal dt As DataTable)
			MyBase.New(dt)
		End Sub

		'' <summary>
		'' 建構子/處理異動處理
		'' </summary>
		'' <param name="dbManager">DBManager 物件</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			Me.TableName	=	"AUTT030"
			Me.SysName	=	"AUT"
            Me.ConnName = "TSBA"

			'=== 關聯 Class ===

			'=== 處理別名 ===
		End Sub
	#End Region

	#Region "屬性"
		#Region "GROUP_CODE 群組代碼"
		''' <summary>
		''' GROUP_CODE 群組代碼
		''' </summary>
		Public Property GROUP_CODE As String
			Get
				Return Me.ColumnyMap("GROUP_CODE")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("GROUP_CODE")	=	value
			End Set
		End Property
		#End Region
		
		#Region "PROG_CD 程式代號"
		''' <summary>
		''' PROG_CD 程式代號
		''' </summary>
		Public Property PROG_CD As String
			Get
				Return Me.ColumnyMap("PROG_CD")
			End Get
			Set(ByVal value As String)
				Me.ColumnyMap("PROG_CD")	=	value
			End Set
		End Property
		#End Region
		

	#End Region
	
	#Region "自訂方法"

	#End Region
		
	End Class
End NameSpace
 
