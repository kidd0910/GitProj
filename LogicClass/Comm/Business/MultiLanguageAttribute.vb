Imports Comm.Data
Imports Acer.Log
Imports Acer.DB

NameSpace Comm.Business
	Public partial Class MultiLanguage
		Inherits Acer.Base.ControlBase

	#Region "콜㈙"
		#Region "LANGLIST かτ콜㈙"
		''' <summary>
		''' LANGLIST かτ콜㈙
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

		#Region "LANGUAGE かτ콜㈙"
		''' <summary>
		''' LANGUAGE かτ콜㈙
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

	#Region "ヘ튰쨖"
		''' <summary>
		''' ヘ튰쨖
		''' </summary>
		''' <param name="dbManager">dbManager かτ</param>
		''' <param name="logUtil">logUtil かτ</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			'=== れ쯮멎콜㈙が튍 ===
			Me.LANGUAGE	=	New LANGUAGE(dbManager, logUtil)
			Me.LANGLIST	=	New LANGLIST(dbManager, logUtil)
		End Sub
	#End Region

	End Class
End NameSpace

