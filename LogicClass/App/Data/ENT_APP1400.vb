'----------------------------------------------------------------------------------
'File Name		: APP1400
'Author			: NCC管理者
'Description		: APP1400 APP1400 廣播事業申設報告
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/12/21	NCC管理者		Source Create
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
    ' APP1400 APP1400 廣播事業申設報告
    ' </summary>
    Public Class ENT_APP1400
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
            Me.TableName = "APP1400"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,TOPIC_ANSWER,SERVICE_OTHER_DESC,SERVICE_TEL,SERVICE_INTERNET_DESC,AC_NAME,DEVICE_RESULT1_DESC,DEVICE_RESULT2_DESC,DEVICE_RESULT3_DESC,DEVICE_RESULT4_DESC,DEVICE_RESULT5_DESC,DEVICE_RESULT6_DESC"
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

#Region "TOPIC_SEQ TOPIC_SEQ"
        '' <summary>
        '' TOPIC_SEQ TOPIC_SEQ
        '' </summary>
        Public Property TOPIC_SEQ() As String
            Get
                Return Me.ColumnyMap("TOPIC_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOPIC_SEQ") = value
            End Set
        End Property
#End Region

#Region "TOPIC_ANSWER TOPIC_ANSWER"
        '' <summary>
        '' TOPIC_ANSWER TOPIC_ANSWER
        '' </summary>
        Public Property TOPIC_ANSWER() As String
            Get
                Return Me.ColumnyMap("TOPIC_ANSWER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOPIC_ANSWER") = value
            End Set
        End Property
#End Region

#Region "TOPIC_RESULT TOPIC_RESULT"
        '' <summary>
        '' TOPIC_RESULT TOPIC_RESULT
        '' </summary>
        Public Property TOPIC_RESULT() As String
            Get
                Return Me.ColumnyMap("TOPIC_RESULT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("TOPIC_RESULT") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL_FLAG 意見反應管道-客服電話, 勾選為'Y'"
        '' <summary>
        '' SERVICE_TEL_FLAG 意見反應管道-客服電話, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_TEL_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_EMAIL_FLAG 意見反應管道-官網信箱, 勾選為'Y'"
        '' <summary>
        '' SERVICE_EMAIL_FLAG 意見反應管道-官網信箱, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_EMAIL_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_EMAIL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_EMAIL_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_ACTIVE_FLAG 意見反應管道-交流活動, 勾選為'Y'"
        '' <summary>
        '' SERVICE_ACTIVE_FLAG 意見反應管道-交流活動, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_ACTIVE_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_ACTIVE_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_ACTIVE_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER_FLAG 意見反應管道-其他, 勾選為'Y'"
        '' <summary>
        '' SERVICE_OTHER_FLAG 意見反應管道-其他, 勾選為'Y'
        '' </summary>
        Public Property SERVICE_OTHER_FLAG() As String
            Get
                Return Me.ColumnyMap("SERVICE_OTHER_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_OTHER_FLAG") = value
            End Set
        End Property
#End Region

#Region "SERVICE_OTHER_DESC 意見反應管道-其他-說明, 勾選其他蝕本欄位必填"
        '' <summary>
        '' SERVICE_OTHER_DESC 意見反應管道-其他-說明, 勾選其他蝕本欄位必填
        '' </summary>
        Public Property SERVICE_OTHER_DESC() As String
            Get
                Return Me.ColumnyMap("SERVICE_OTHER_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_OTHER_DESC") = value
            End Set
        End Property
#End Region

#Region "M_ACTIVE_NUMBER 主辦活動共計場次"
        '' <summary>
        '' M_ACTIVE_NUMBER 主辦活動共計場次
        '' </summary>
        Public Property M_ACTIVE_NUMBER() As String
            Get
                Return Me.ColumnyMap("M_ACTIVE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("M_ACTIVE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "S_ACTIVE_NUMBER 協辦或參加其他活動共計場次"
        '' <summary>
        '' S_ACTIVE_NUMBER 協辦或參加其他活動共計場次
        '' </summary>
        Public Property S_ACTIVE_NUMBER() As String
            Get
                Return Me.ColumnyMap("S_ACTIVE_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("S_ACTIVE_NUMBER") = value
            End Set
        End Property
#End Region

#Region "SERVICE_TEL 電話服務專線號碼"
        '' <summary>
        '' SERVICE_TEL 電話服務專線號碼
        '' </summary>
        Public Property SERVICE_TEL() As String
            Get
                Return Me.ColumnyMap("SERVICE_TEL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_TEL") = value
            End Set
        End Property
#End Region

#Region "SERVICE_INTERNET_DESC 網路留言或其他反應管道"
        '' <summary>
        '' SERVICE_INTERNET_DESC 網路留言或其他反應管道
        '' </summary>
        Public Property SERVICE_INTERNET_DESC() As String
            Get
                Return Me.ColumnyMap("SERVICE_INTERNET_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SERVICE_INTERNET_DESC") = value
            End Set
        End Property
#End Region

#Region "AC_NAME 會計專職人員姓名"
        '' <summary>
        '' AC_NAME 會計專職人員姓名
        '' </summary>
        Public Property AC_NAME() As String
            Get
                Return Me.ColumnyMap("AC_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("AC_NAME") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT1 電臺發射機及天線地點是否與核准者相符"
        '' <summary>
        '' DEVICE_RESULT1 電臺發射機及天線地點是否與核准者相符
        '' </summary>
        Public Property DEVICE_RESULT1() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT1") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT1_DESC 電臺發射機及天線地點是否與核准者相符-說明"
        '' <summary>
        '' DEVICE_RESULT1_DESC 電臺發射機及天線地點是否與核准者相符-說明
        '' </summary>
        Public Property DEVICE_RESULT1_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT2 天線鐵塔是否定期維護保養"
        '' <summary>
        '' DEVICE_RESULT2 天線鐵塔是否定期維護保養
        '' </summary>
        Public Property DEVICE_RESULT2() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT2") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT2_DESC 天線鐵塔是否定期維護保養-保養週期"
        '' <summary>
        '' DEVICE_RESULT2_DESC 天線鐵塔是否定期維護保養-保養週期
        '' </summary>
        Public Property DEVICE_RESULT2_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT3 避雷針及警示燈是否定期檢測並正常運作"
        '' <summary>
        '' DEVICE_RESULT3 避雷針及警示燈是否定期檢測並正常運作
        '' </summary>
        Public Property DEVICE_RESULT3() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT3") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT3_DESC 避雷針及警示燈是否定期檢測並正常運作-說明"
        '' <summary>
        '' DEVICE_RESULT3_DESC 避雷針及警示燈是否定期檢測並正常運作-說明
        '' </summary>
        Public Property DEVICE_RESULT3_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT3_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT4 天線鐵塔是否有安全防護措施"
        '' <summary>
        '' DEVICE_RESULT4 天線鐵塔是否有安全防護措施
        '' </summary>
        Public Property DEVICE_RESULT4() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT4")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT4") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT4_DESC 天線鐵塔是否有安全防護措施-說明"
        '' <summary>
        '' DEVICE_RESULT4_DESC 天線鐵塔是否有安全防護措施-說明
        '' </summary>
        Public Property DEVICE_RESULT4_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT4_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT4_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT5 發射機接地線是否定期檢測並符合規定"
        '' <summary>
        '' DEVICE_RESULT5 發射機接地線是否定期檢測並符合規定
        '' </summary>
        Public Property DEVICE_RESULT5() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT5")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT5") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT5_DESC 發射機接地線是否定期檢測並符合規定-說明"
        '' <summary>
        '' DEVICE_RESULT5_DESC 發射機接地線是否定期檢測並符合規定-說明
        '' </summary>
        Public Property DEVICE_RESULT5_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT5_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT5_DESC") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT6 發射機傳輸品質檢測是否合於標準"
        '' <summary>
        '' DEVICE_RESULT6 發射機傳輸品質檢測是否合於標準
        '' </summary>
        Public Property DEVICE_RESULT6() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT6")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT6") = value
            End Set
        End Property
#End Region

#Region "DEVICE_RESULT6_DESC 發射機傳輸品質檢測是否合於標準-說明"
        '' <summary>
        '' DEVICE_RESULT6_DESC 發射機傳輸品質檢測是否合於標準-說明
        '' </summary>
        Public Property DEVICE_RESULT6_DESC() As String
            Get
                Return Me.ColumnyMap("DEVICE_RESULT6_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEVICE_RESULT6_DESC") = value
            End Set
        End Property
#End Region

#Region "MONITOR_FLAG1 是否以人員值班方式監控"
        '' <summary>
        '' MONITOR_FLAG1 是否以人員值班方式監控
        '' </summary>
        Public Property MONITOR_FLAG1() As String
            Get
                Return Me.ColumnyMap("MONITOR_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MONITOR_FLAG1") = value
            End Set
        End Property
#End Region

#Region "MONITOR_FLAG2 是否以監控設備方式監控"
        '' <summary>
        '' MONITOR_FLAG2 是否以監控設備方式監控
        '' </summary>
        Public Property MONITOR_FLAG2() As String
            Get
                Return Me.ColumnyMap("MONITOR_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MONITOR_FLAG2") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_FLAG1 是否設置工程部門並有正式編制之工程人員"
        '' <summary>
        '' MAINTAIN_FLAG1 是否設置工程部門並有正式編制之工程人員
        '' </summary>
        Public Property MAINTAIN_FLAG1() As String
            Get
                Return Me.ColumnyMap("MAINTAIN_FLAG1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAINTAIN_FLAG1") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_FLAG2 是否以外包方式維護工程設施"
        '' <summary>
        '' MAINTAIN_FLAG2 是否以外包方式維護工程設施
        '' </summary>
        Public Property MAINTAIN_FLAG2() As String
            Get
                Return Me.ColumnyMap("MAINTAIN_FLAG2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAINTAIN_FLAG2") = value
            End Set
        End Property
#End Region

#Region "MAINTAIN_ENGINEER_NUMBER 電臺設置工程部門並有正式編制之工程人員數量"
        '' <summary>
        '' MAINTAIN_ENGINEER_NUMBER 電臺設置工程部門並有正式編制之工程人員數量
        '' </summary>
        Public Property MAINTAIN_ENGINEER_NUMBER() As String
            Get
                Return Me.ColumnyMap("MAINTAIN_ENGINEER_NUMBER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MAINTAIN_ENGINEER_NUMBER") = value
            End Set
        End Property
#End Region

#Region "IMPROVE_RESULT1 過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'"
        '' <summary>
        '' IMPROVE_RESULT1 過去3年對於違規案件是否已改善, REF.SYST010_KEY='IMPROVE_RESULT'
        '' </summary>
        Public Property IMPROVE_RESULT1() As String
            Get
                Return Me.ColumnyMap("IMPROVE_RESULT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IMPROVE_RESULT1") = value
            End Set
        End Property
#End Region



#End Region

#Region "自訂方法"
#Region "Query 查詢 "
        ''' <summary>
        ''' 查詢 
        ''' </summary>
        'Public Overrides Function Query() As DataTable
        '    Return Me.Query(0, 0)
        'End Function

        ''' <summary>
        ''' 查詢 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 NCC管理者 新增方法
        ''' </remarks>
        'Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        '    Try
        '        Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '        Me.LogProperty()
        '
        '        '=== 檢核欄位起始 ===
        '        Dim faileArguments As ArrayList = New ArrayList()
        '
        '        If faileArguments.Count > 0 Then
        '            Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
        '        End If
        '        '=== 檢核欄位結束 ===
        '
        '        '=== 處理別名 ===
        '        Me.TableCoumnInfo.Add(New String() {"SCST020", "M", "COLUMN1"})
        '        Me.TableCoumnInfo.Add(New String() {"SCST040", "R1", "COLUMN2"})
        '        Me.ParserAlias()
        '
        '        Dim sql As New StringBuilder
        '        sql.AppendLine(" SELECT M.*, R1.COLUMN2 ")
        '        sql.AppendLine(" FROM SCST020 M ")
        '        sql.AppendLine(" LEFT JOIN SCST040 R1 ON M.TUTOR_CLASSNO = R1.TUTOR_CLASSNO ")
        '
        '        If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
        '            sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
        '        End If
        '
        '        If Me.OrderBys <> "" Then
        '            sql.AppendLine(" ORDER BY  " & Me.OrderBys)
        '        Else
        '            If pageNo = 0 Then
        '                sql.AppendLine(" ORDER BY M.STNO ")
        '            Else
        '                sql.AppendLine(" ORDER BY STNO ")
        '            End If
        '        End If
        '
        '        Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)
        '
        '        Me.ResetColumnProperty()
        '
        '        Return dt
        '    Finally
        '        Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
        '    End Try
        'End Function
#End Region
#End Region



    End Class
End Namespace

