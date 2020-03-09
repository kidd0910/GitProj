Public Class DataEnum
    Enum MenuType As Integer
        ''' <summary>
        ''' 輸入
        ''' </summary>
        enter
        ''' <summary>
        ''' 審查
        ''' </summary>
        review
        ''' <summary>
        ''' 查詢
        ''' </summary>
        query
        ''' <summary>
        ''' 諮詢
        ''' </summary>
        refer
        ''' <summary>
        ''' 業者查詢
        ''' </summary>
        cusQuery
    End Enum

    Enum RevMode As Integer
        ''' <summary>
        ''' 皆非（三審通過）
        ''' </summary>
        None
        ''' <summary>
        ''' 初審
        ''' </summary>
        First
        ''' <summary>
        ''' 諮詢委員會議
        ''' </summary>
        Advisory
        ''' <summary>
        ''' 本會委員會議
        ''' </summary>
        Ours
    End Enum

    Enum ResultType As Integer
        ''' <summary>
        ''' 續行受理
        ''' </summary>
        Accept = 1
        ''' <summary>
        ''' 補正
        ''' </summary>
        Correct = 3
        ''' <summary>
        ''' 駁回
        ''' </summary>
        Reject = 4
        ''' <summary>
        ''' 不予受理
        ''' </summary>
        Ignore = 5
        ''' <summary>
        ''' 撤案
        ''' </summary>
        Undo = 6
        ''' <summary>
        ''' 退回初審
        ''' </summary>
        ReturnFirst = 7
    End Enum

    ''' <summary>
    ''' 人員類別/角色/PERSON_TYPE/COM_TYPE
    ''' </summary>
    Enum PersonType As Integer
        ''' <summary>
        ''' 機構類別
        ''' </summary>
        COM = 0
        ''' <summary>
        ''' NCC
        ''' </summary>
        NCC = 1
        ''' <summary>
        ''' 諮詢委員
        ''' </summary>
        ADVISER = 2
        ''' <summary>
        ''' 業者
        ''' </summary>
        BUSINESSMAN = 3
    End Enum
End Class
