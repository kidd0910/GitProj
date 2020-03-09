Imports Comm.Data
Imports Acer.Log
Imports Acer.DB

NameSpace Comm.Business
	Public partial Class MultiLanguage
		Inherits Acer.Base.ControlBase

	#Region "�ݩ�"
		#Region "LANGLIST �����ݩ�"
		''' <summary>
		''' LANGLIST �����ݩ�
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

		#Region "LANGUAGE �����ݩ�"
		''' <summary>
		''' LANGUAGE �����ݩ�
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

	#Region "�غc�l"
		''' <summary>
		''' �غc�l
		''' </summary>
		''' <param name="dbManager">dbManager ����</param>
		''' <param name="logUtil">logUtil ����</param>
		Public Sub New (ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
			MyBase.New(dbManager, logUtil)
			'=== ��l���ݩʪ��A ===
			Me.LANGUAGE	=	New LANGUAGE(dbManager, logUtil)
			Me.LANGLIST	=	New LANGLIST(dbManager, logUtil)
		End Sub
	#End Region

	End Class
End NameSpace

