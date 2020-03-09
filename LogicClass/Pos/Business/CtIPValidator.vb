'----------------------------------------------------------------------------------
'File Name		: CtIPValidator 
'Author			: 
'Description		: 解析IP是否正常分配在正常往段
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/10      Kevin Yu	   	Source Create
'----------------------------------------------------------------------------------


Imports System.Net
Imports Pos.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports System.Net.Sockets

Public Class CtIPValidator
    Inherits Acer.Base.ControlBase
#Region "建構子"
    ''' <summary>
    ''' 建構子
    ''' </summary>
    ''' <param name="dbManager">dbManager 物件</param>
    ''' <param name="logUtil">logUtil 物件</param>
    Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
        MyBase.New(dbManager, logUtil)
    End Sub
#End Region

    'Public Shared Function GetIP() As String
    '    Dim request As HttpRequest = HttpContext.Current.Request
    '    Dim ipAddress As String = String.Empty
    '    If request.ServerVariables("HTTP_X_FORWARDED_FOR") Is Nothing OrElse request.ServerVariables("HTTP_X_FORWARDED_FOR") = "" Then
    '        ipAddress = request.ServerVariables("REMOTE_ADDR")
    '    ElseIf request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(",") >= 0 Then
    '        Dim index As Integer = request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(",")
    '        ipAddress = request.ServerVariables("HTTP_X_FORWARDED_FOR").Substring(0, index - 1)
    '    ElseIf request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(";") >= 0 Then
    '        Dim index As Integer = request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(";")
    '        ipAddress = request.ServerVariables("HTTP_X_FORWARDED_FOR").Substring(0, index - 1)
    '    Else
    '        ipAddress = request.ServerVariables("HTTP_X_FORWARDED_FOR")
    '    End If
    '    If ipAddress = "127.0.0.1" Then
    '        ipAddress = GetLocalhostIPAddress()
    '    End If
    '    Return ipAddress
    'End Function

    Public Shared Function GetIP() As ArrayList 'List(Of String)
        Dim request As HttpRequest = HttpContext.Current.Request
        Dim ipAddress As New ArrayList
        If request.ServerVariables("HTTP_X_FORWARDED_FOR") Is Nothing OrElse request.ServerVariables("HTTP_X_FORWARDED_FOR") = "" Then
            ipAddress.Add(request.ServerVariables("REMOTE_ADDR"))
        ElseIf request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(",") >= 0 Then
            Dim index As Integer = request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(",")
            ipAddress.Add(request.ServerVariables("HTTP_X_FORWARDED_FOR").Substring(0, index - 1))
        ElseIf request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(";") >= 0 Then
            Dim index As Integer = request.ServerVariables("HTTP_X_FORWARDED_FOR").IndexOf(";")
            ipAddress.Add(request.ServerVariables("HTTP_X_FORWARDED_FOR").Substring(0, index - 1))
        Else
            ipAddress.Add(request.ServerVariables("HTTP_X_FORWARDED_FOR"))
        End If
        If ipAddress.Item(0) = "127.0.0.1" Then
            ipAddress = GetLocalhostIPAddress()
        End If
        Return ipAddress
    End Function

    Private Shared Function GetLocalhostIPAddress() As ArrayList
        Dim hostName As String = System.Net.Dns.GetHostName()
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(hostName)
        Dim IpAddr As System.Net.IPAddress() = hostInfo.AddressList

        'FinalIPList 放實體IP v4
        Dim FinalIPList As New ArrayList(IpAddr.Length)
        For Each IP As IPAddress In IpAddr
            '處理虛擬網卡和IP v6地址
            If ((Not IPAddress.IsLoopback(IP)) And (IP.AddressFamily = AddressFamily.InterNetwork)) Then
                FinalIPList.Add(IP)
            End If
        Next IP


        'Dim localIP As String = String.Empty
        'For i As Integer = 0 To FinalIPList.Count - 1
        '    localIP += FinalIPList(i).ToString()
        'Next
        Return FinalIPList
    End Function

    'Private Shared Function GetLocalhostIPAddress() As String 'List(Of String)
    '    Dim IpAddressList As New List(Of String)
    '    Try
    '        '取得本機上ipv4及非Loopback的IP Address
    '        For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
    '            For Each ipInfo As System.Net.NetworkInformation.IPAddressInformation
    '                 In nic.GetIPProperties().UnicastAddresses
    '                If System.Net.IPAddress.IsLoopback(ipInfo.Address) = False AndAlso ipInfo.Address.AddressFamily <> Net.Sockets.AddressFamily.InterNetworkV6 Then
    '                    '取得IP Address
    '                    IpAddressList.Add(ipInfo.Address.ToString())
    '                End If
    '            Next
    '        Next
    '        Dim localIP As String = String.Empty
    '        For i As Integer = 0 To IpAddressList.Count - 1
    '            localIP += IpAddressList(i).ToString()
    '        Next
    '        Return localIP
    '    Finally
    '        IpAddressList = Nothing
    '    End Try
    'End Function



    Public Shared Function TheIpIsRange(ip As String, ParamArray ranges As String()) As Boolean
        Dim tmpRes As Boolean = False
        For Each item As String In ranges
            If TheIpIsRange(ip, item) Then
                tmpRes = True
                Exit For
            End If
        Next
        Return tmpRes
    End Function

    Public Shared Function TheIpIsRange(ip As String, ranges As String) As Boolean
        Dim result As Boolean = False
        Dim count As Integer
        Dim start_ip As String = "", end_ip As String = ""
        '檢測指定的IP範圍 是否異常,資料欄位空白不做檢查
        If ranges <> "" Then
            TryParseRanges(ranges, count, start_ip, end_ip)
        End If
        '檢測ip範圍格式是否有效
        If ip = "::1" Then
            ip = "127.0.0.1"
        End If
        Try
            '判斷指定要判斷的IP是否異常
            IPAddress.Parse(ip)
        Catch generatedExceptionName As Exception
            Throw New ApplicationException("要檢測的IP地址無效")
        End Try
        '如果指定的IP範圍就是一個IP
        If count = 1 AndAlso ip = start_ip Then
            result = True
        ElseIf count = 2 Then
            '如果指定IP範圍 是一個起始IP範圍區間(以-分隔)
            Dim start_ip_array As Byte() = Get4Byte(start_ip)
            'IPv4轉為 4個byte的array
            Dim end_ip_array As Byte() = Get4Byte(end_ip)
            Dim ip_array As Byte() = Get4Byte(ip)
            Dim tmpRes As Boolean = True
            For i As Integer = 0 To 3
                'compare the byte value to check the range
                If ip_array(i) > end_ip_array(i) OrElse ip_array(i) < start_ip_array(i) Then
                    tmpRes = False
                    Exit For
                End If
            Next
            result = tmpRes
        End If
        Return result
    End Function
    ''' <summary>
    ''' Parsing assigned segment Range of 
    ''' </summary>
    ''' <param name="ranges"></param>
    ''' <param name="count"></param>
    ''' <param name="start_ip"></param>
    ''' <param name="end_ip"></param>
    ''' <remarks></remarks>
    Private Shared Sub TryParseRanges(ranges As String, ByRef count As Integer, ByRef start_ip As String, ByRef end_ip As String)
        Dim iprngArr As String() = ranges.Split(";"c)
        For Each _rng As String In iprngArr
            Dim _r As String() = _rng.Split("-"c)
            If Not (_r.Length = 2 Or _r.Length = 1) Then
                Throw New ApplicationException("IP範圍指定格式不正確，可以指定一個IP，如果是一個範圍請用" + "-" + "分隔")
            End If
            count = _r.Length
            start_ip = _r(0)
            end_ip = ""
            Try
                IPAddress.Parse(_r(0))
            Catch generatedExceptionName As Exception
                Throw New ApplicationException("IP address is illegal")
            End Try
            If _r.Length = 2 Then
                end_ip = _r(1)
                Try
                    IPAddress.Parse(_r(1))
                Catch generatedExceptionName As Exception
                    Throw New ApplicationException("IP address is illegal")
                End Try
            End If
        Next


    End Sub

    Private Shared Function Get4Byte(ip As String) As Byte()
        Dim _i As String() = ip.Split("."c)
        Dim res As New List(Of Byte)()
        For Each item As String In _i
            res.Add(Convert.ToByte(item))
        Next
        Return res.ToArray()
    End Function



End Class
