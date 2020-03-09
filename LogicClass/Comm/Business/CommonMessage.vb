Imports Acer.Form

NameSpace Comm.Business
	Public Class CommonMessage
		Public Enum Message
                        SUCCESS		=	0
			失敗囉		=	1
			新增資料重複	=	2
			資料以存在	=	3
			屬性資料不可為空=	4
                End Enum

		''' <summary>
		''' 取得訊息
		''' </summary>
		''' <param name="langUtil">LangUtil 物件</param>
		''' <param name="MsgKey">對應訊息</param>
		''' <returns>訊息</returns>
		Public Shared Function GetMsg(ByVal langUtil As LangUtil, ByVal MsgKey As String) As String
			Return langUtil.LangMap("COMMON.ERROR." & MsgKey)
		End Function

		''' <summary>
		''' 取得訊息, 需處理置換動作
		''' </summary>
		''' <param name="langUtil">LangUtil 物件</param>
		''' <param name="MsgKey">對應訊息</param>
		''' <param name="argsAL">要置換的資料, 單-Key, 雙-資料</param>
		''' <returns>訊息</returns>
		Public Shared Function GetMsg(ByVal langUtil As LangUtil, ByVal MsgKey As String, ByVal argsAL As ArrayList) As String
			Dim	msg		As	String	=	langUtil.LangMap("COMMON.ERROR." & MsgKey)
			Dim	tmpAry()	As	String
			For i As Integer = 0 To argsAL.Count - 1
				tmpAry	=	argsAL(i).ToString().Split(",")
				msg	=	msg.ToString().Replace("[" & tmpAry(0) & "]", tmpAry(1).ToString())
			Next

			Return msg
		End Function
	End Class
End NameSpace

