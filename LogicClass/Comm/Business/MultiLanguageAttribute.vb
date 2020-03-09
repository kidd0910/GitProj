Imports Comm.Data
Imports Acer.Log
Imports Acer.DB

NameSpace Comm.Business
	Public partial Class MultiLanguage
		Inherits Acer.Base.ControlBase

	#Region "屬性"
		#Region "LANGLIST 物件屬性"
		''' <summary>
		''' LANGLIST 物件屬性
		''' </summary>
		Public Property LANGLIST As LANGLIST
			Get
				Return Me.PropertyMap("LANGLIST")
			End Get
			Set(ByVal value As LANGLIST)
				Me.PropertyMap("LANGLIST")	=	value
			End Set
		End Property
		#End Region

		#Region "LANGUAGE 物件屬性"
		''' <summary>
		''' LANGUAGE 物件屬性
		''' </summary>
		Public Property LANGUAGE As LANGUAGE
			Get
				Return Me.PropertyMap("LANGUAGE")
			End Get
			Set(ByVal value As LANGUAGE)
				Me.PropertyMap("LANGUAGE")	=	value
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
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			'=== 初始話屬性狀態 ===
			Me.LANGUAGE	=	New LANGUAGE(dbManager, logUtil)
			Me.LANGLIST	=	New LANGLIST(dbManager, logUtil)
		End Sub
	#End Region

	End Class
End NameSpace

