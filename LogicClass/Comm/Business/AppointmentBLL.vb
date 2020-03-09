Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net

Namespace Comm.Business
    Public Class AppointmentBLL
        ' This class formats and sends a meeting request via SMTP email

        Public StartDate As DateTime
        Public EndDate As DateTime
        Public Subject As String
        Public Summary As String
        Public Location As String
        Public AttendeeName As String
        Public AttendeeEmail As String
        Public OrganizerName As String
        Public OrganizerEmail As String
        Public Method As String

        Public Sub New(ByVal pdtStartDate As DateTime, _
                        ByVal pdtEndDate As DateTime, _
                        ByVal psSubject As String, _
                        ByVal psSummary As String, _
                        ByVal psLocation As String, _
                        ByVal psAttendeeName As String, _
                        ByVal psAttendeeEmail As String, _
                        ByVal psOrganizerName As String, _
                        ByVal psOrganizerEmail As String, _
                        Optional psMethod As String = "REQUEST")

            ' Copy constructor parameters to public propeties

            StartDate = pdtStartDate
            EndDate = pdtEndDate
            Subject = psSubject
            Summary = psSummary
            Location = psLocation
            AttendeeName = psAttendeeName
            AttendeeEmail = psAttendeeEmail
            OrganizerName = psOrganizerName
            OrganizerEmail = psOrganizerEmail
            Method = psMethod
        End Sub

        Public Sub EmailAppointment()

            ' Send the calendar message to the attendee

            Dim loMsg As New MailMessage
            Dim loTextView As AlternateView = Nothing
            Dim loHTMLView As AlternateView = Nothing
            Dim loCalendarView As AlternateView = Nothing
            'Dim loSMTPServer As New SmtpClient(Acer.Apps.APConfig.GetProperty("SMTP_SERVER"))
            Dim loSMTPServer As SmtpClient

            loSMTPServer = New SmtpClient
            loSMTPServer.Host = Acer.Apps.APConfig.GetProperty("SMTP_SERVER")
            loSMTPServer.Port = 25
            'loSMTPServer.ServicePoint.MaxIdleTime = 1   '修正 SmtpClient 不會關閉連線的 bug.
            loSMTPServer.EnableSsl = True
            loSMTPServer.UseDefaultCredentials = False
            loSMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network
            Dim cred As NetworkCredential = New NetworkCredential(Acer.Apps.APConfig.GetProperty("SENDER_ID"), Acer.Apps.APConfig.GetProperty("SENDER_PW"))
            loSMTPServer.Credentials = cred

            ' SMTP settings set up in web.config such as:
            '  <system.net>
            '   <mailSettings>
            '    <smtp>
            '     <network
            '       host = "exchange.mycompany.com"
            '       port = "25"
            '       userName = "username"
            '       password="password" />
            '    </smtp>
            '   </mailSettings>
            '  </system.net>

            ' Set up the different mime types contained in the message
            Dim loTextType As System.Net.Mime.ContentType = New System.Net.Mime.ContentType("text/plain")
            Dim loHTMLType As System.Net.Mime.ContentType = New System.Net.Mime.ContentType("text/html")
            Dim loCalendarType As System.Net.Mime.ContentType = New System.Net.Mime.ContentType("text/calendar")

            '先發會議申請人
            ' Add parameters to the calendar header
            loCalendarType.Parameters.Add("method", Method)
            loCalendarType.Parameters.Add("name", "meeting.ics")

            ' Create message body parts
            loTextView = AlternateView.CreateAlternateViewFromString(BodyText(), loTextType)
            loMsg.AlternateViews.Add(loTextView)

            loHTMLView = AlternateView.CreateAlternateViewFromString(BodyHTML(), loHTMLType)
            loMsg.AlternateViews.Add(loHTMLView)

            loCalendarView = AlternateView.CreateAlternateViewFromString(VCalendar("0"), loCalendarType)
            loCalendarView.TransferEncoding = Net.Mime.TransferEncoding.SevenBit
            loMsg.AlternateViews.Add(loCalendarView)

            ' Adress the message

            'loMsg.From = New MailAddress(OrganizerEmail)
            loMsg.From = New MailAddress(Acer.Apps.APConfig.GetProperty("SENDER"))
            '會議使用人
            loMsg.To.Add(New MailAddress(OrganizerEmail))
            loMsg.Subject = Subject
            ' Send the message
            loSMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network
            loSMTPServer.Send(loMsg)


            '再發參加人
            loMsg = New MailMessage
            loTextView = Nothing
            loHTMLView = Nothing
            loCalendarView = Nothing

            loTextType = New System.Net.Mime.ContentType("text/plain")
            loHTMLType = New System.Net.Mime.ContentType("text/html")
            loCalendarType = New System.Net.Mime.ContentType("text/calendar")

            ' Add parameters to the calendar header
            loCalendarType.Parameters.Add("method", Method)
            loCalendarType.Parameters.Add("name", "meeting.ics")

            ' Create message body parts
            loTextView = AlternateView.CreateAlternateViewFromString(BodyText(), loTextType)
            loMsg.AlternateViews.Add(loTextView)

            loHTMLView = AlternateView.CreateAlternateViewFromString(BodyHTML(), loHTMLType)
            loMsg.AlternateViews.Add(loHTMLView)

            loCalendarView = AlternateView.CreateAlternateViewFromString(VCalendar("1"), loCalendarType)
            loCalendarView.TransferEncoding = Net.Mime.TransferEncoding.SevenBit
            loMsg.AlternateViews.Add(loCalendarView)

            'loMsg.From = New MailAddress(OrganizerEmail)
            loMsg.From = New MailAddress(Acer.Apps.APConfig.GetProperty("SENDER"))

            '會議相關人員
            Dim email() As String = AttendeeEmail.Split(",")
            For i As Integer = 0 To email.Length - 1
                If Acer.Apps.APConfig.GetProperty("TEST_MAIL") <> "" Then
                    loMsg.To.Add(New MailAddress(Acer.Apps.APConfig.GetProperty("TEST_MAIL")))
                Else
                    loMsg.To.Add(New MailAddress(email(i)))
                End If
            Next

            loMsg.Subject = Subject
            ' Send the message
            loSMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network
            loSMTPServer.Send(loMsg)


        End Sub

        Public Function BodyText() As String

            ' Return the Body in text format

            Const BODY_TEXT = _
                "==== 會議通知 ===" & vbCrLf & _
                "一、會議連絡人: {0}" & vbCrLf & _
                "二、主旨: {1}" & vbCrLf & _
                "三、會議日期:{2}" & vbCrLf & _
                "四、會議時間:{3}" & vbCrLf & _
                "五、會議室:{4}" & vbCrLf


            Return String.Format(BODY_TEXT, _
                                OrganizerName, _
                                Subject, _
                                StartDate.ToString("yyyy/MM/dd"), _
                                StartDate.ToString("HH:mm") & " ~ " & EndDate.ToString("HH:mm"), _
                                Location)

        End Function

        Public Function BodyHTML() As String

            ' Return the Body in HTML format

            Const BODY_HTML = _
                    "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 3.2//EN"">" & vbCrLf & _
                    "<HTML>" & vbCrLf & _
                    "<HEAD>" & vbCrLf & _
                    "<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"">" & vbCrLf & _
                    "<META NAME=""Generator"" CONTENT=""MS Exchange Server version 6.5.7652.24"">" & vbCrLf & _
                    "<TITLE>{0}</TITLE>" & vbCrLf & _
                    "</HEAD>" & vbCrLf & _
                    "<BODY>" & vbCrLf & _
                    "<!-- Converted from text/plain format -->" & vbCrLf & _
                    "<P><FONT SIZE=2>==== 會議通知 ===<BR>" & vbCrLf & _
                    "一、會議連絡人:{1}<BR>" & vbCrLf & _
                    "二、主旨:{2}<BR>" & vbCrLf & _
                    "三、會議日期:{3}<BR>" & vbCrLf & _
                    "四、會議時間:{4}<BR>" & vbCrLf & _
                    "五、會議室:{5}<BR>" & vbCrLf & _
                    "</FONT>" & vbCrLf & _
                    "</P>" & vbCrLf & _
                    vbCrLf & _
                    "</BODY>" & vbCrLf & _
                    "</HTML>"

            Return String.Format(BODY_HTML, _
                                 Subject, _
                                OrganizerName, _
                                Subject, _
                                StartDate.ToString("yyyy/MM/dd"), _
                                StartDate.ToString("HH:mm") & " ~ " & EndDate.ToString("HH:mm"), _
                                Location)

        End Function

        Public Function VCalendar(type As String) As String

            ' Return the Calendar text in vCalendar format, compatible with most calendar programs

            Const lcDateFormat = "yyyyMMddTHHmmssZ"
            Dim loGUID As Guid = Guid.NewGuid  ' Or use the guid of an exiting meeting?

            Const VCAL_FILE = "BEGIN:VCALENDAR" & vbCrLf & _
            "METHOD:{10}" & vbCrLf & _
            "PRODID:Microsoft CDO for Microsoft Exchange" & vbCrLf & _
            "VERSION:2.0" & vbCrLf & _
                "BEGIN:VTIMEZONE" & vbCrLf & _
                "TZID:(GMT-06.00) Central Time (US & Canada)" & vbCrLf & _
                "X-MICROSOFT-CDO-TZID:11" & vbCrLf & _
                    "BEGIN:STANDARD" & vbCrLf & _
                    "DTSTART:16010101T020000" & vbCrLf & _
                    "TZOFFSETFROM:-0500" & vbCrLf & _
                    "TZOFFSETTO:-0600" & vbCrLf & _
                    "RRULE:FREQ=YEARLY;WKST=MO;INTERVAL=1;BYMONTH=11;BYDAY=1SU" & vbCrLf & _
                    "END:STANDARD" & vbCrLf & _
                    "BEGIN:DAYLIGHT" & vbCrLf & _
                    "DTSTART:16010101T020000" & vbCrLf & _
                    "TZOFFSETFROM:-0600" & vbCrLf & _
                    "TZOFFSETTO:-0500" & vbCrLf & _
                    "RRULE:FREQ=YEARLY;WKST=MO;INTERVAL=1;BYMONTH=3;BYDAY=2SU" & vbCrLf & _
                    "END:DAYLIGHT" & vbCrLf & _
                "END:VTIMEZONE" & vbCrLf & _
                "BEGIN:VEVENT" & vbCrLf & _
                "DTSTAMP:{8}" & vbCrLf & _
                "DTSTART:{0}" & vbCrLf & _
                "SUMMARY:{7}" & vbCrLf & _
                "UID:{5}" & vbCrLf & _
                "ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=NEEDS-ACTION;RSVP=TRUE;CN=""{9}"":MAILTO:{9}" & vbCrLf & _
                "ACTION;RSVP=TRUE;CN=""{4}"":MAILTO:{4}" & vbCrLf & _
                "ORGANIZER;CN=""{3}"":mailto:{4}" & vbCrLf & _
                "LOCATION:{2}" & vbCrLf & _
                "DTEND:{1}" & vbCrLf & _
                "DESCRIPTION:{7}\N" & vbCrLf & _
                "SEQUENCE:1" & vbCrLf & _
                "PRIORITY:5" & vbCrLf & _
                "CLASS:" & vbCrLf & _
                "CREATED:{8}" & vbCrLf & _
                "LAST-MODIFIED:{8}" & vbCrLf & _
                "STATUS:CONFIRMED" & vbCrLf & _
                "TRANSP:OPAQUE" & vbCrLf & _
                "X-MICROSOFT-CDO-BUSYSTATUS:BUSY" & vbCrLf & _
                "X-MICROSOFT-CDO-INSTTYPE:0" & vbCrLf & _
                "X-MICROSOFT-CDO-INTENDEDSTATUS:BUSY" & vbCrLf & _
                "X-MICROSOFT-CDO-ALLDAYEVENT:FALSE" & vbCrLf & _
                "X-MICROSOFT-CDO-IMPORTANCE:1" & vbCrLf & _
                "X-MICROSOFT-CDO-OWNERAPPTID:-1" & vbCrLf & _
                "X-MICROSOFT-CDO-ATTENDEE-CRITICAL-CHANGE:{8}" & vbCrLf & _
                "X-MICROSOFT-CDO-OWNER-CRITICAL-CHANGE:{8}" & vbCrLf & _
                    "BEGIN:VALARM" & vbCrLf & _
                    "ACTION:DISPLAY" & vbCrLf & _
                    "DESCRIPTION:REMINDER" & vbCrLf & _
                    "TRIGGER;RELATED=START:-PT00H15M00S" & vbCrLf & _
                    "END:VALARM" & vbCrLf & _
                "END:VEVENT" & vbCrLf & _
            "END:VCALENDAR" & vbCrLf

            Return String.Format(VCAL_FILE, _
            StartDate.ToUniversalTime().ToString(lcDateFormat), _
            EndDate.ToUniversalTime().ToString(lcDateFormat), _
            Location, _
            OrganizerName, _
            OrganizerEmail, _
            "{" & loGUID.ToString() & "}", _
            Summary, _
            Subject, _
            Now.ToUniversalTime().ToString(lcDateFormat), _
            AttendeeEmail, _
            Method)

            'Return String.Format(VCAL_FILE, _
            '                    StartDate.ToUniversalTime().ToString(lcDateFormat), _
            '                    EndDate.ToUniversalTime().ToString(lcDateFormat), _
            '                    Location, _
            '                    OrganizerName, _
            '                    IIf(type = "0", "judy.lu@acer.com", OrganizerEmail), _
            '                    "{" & loGUID.ToString() & "}", _
            '                    Summary, _
            '                    Subject, _
            '                    Now.ToUniversalTime().ToString(lcDateFormat), _
            '                    AttendeeEmail, _
            '                    Method)
        End Function

        'Public Function VCalendarADD() As String

        '    ' Return the Calendar text in vCalendar format, compatible with most calendar programs

        '    Const lcDateFormat = "yyyyMMddTHHmmssZ"
        '    Dim loGUID As Guid = Guid.NewGuid  ' Or use the guid of an exiting meeting?


        '    Const VCAL_FILE = "BEGIN:VCALENDAR" & vbCrLf & _
        '        "VERSION:2.0" & vbCrLf & _
        '        "METHOD:ADD" & vbCrLf & _
        '        "X-WR-CALNAME:{0}" & vbCrLf & _
        '        "PRODID:Microsoft CDO for Microsoft Exchange" & vbCrLf & _
        '        "BEGIN:VEVENT" & vbCrLf & _
        '        "DTSTART:{1}" & vbCrLf & _
        '        "DTEND:{2}" & vbCrLf & _
        '        "DTSTAMP:{3}" & vbCrLf & _
        '        "UID:{4}" & vbCrLf & _
        '        "CREATED:{4}" & vbCrLf & _
        '        "LAST-MODIFIED:{4}" & vbCrLf & _
        '        "SUMMARY:{5}" & vbCrLf & _
        '        "ORGANIZER;CN=""{6}"":mailto:{6}" & vbCrLf & _
        '        "CLASS:PUBLIC" & vbCrLf & _
        '        "STATUS:CONFIRMED" & vbCrLf & _
        '        "TRANSP:OPAQUE" & vbCrLf & _
        '        "ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=ACCEPTED:MAILTO:{7}" & vbCrLf & _
        '        "SEQUENCE:1" & vbCrLf & _
        '        "END:VEVENT" & vbCrLf & _
        '        "END:VCALENDAR"


        '    Return String.Format(VCAL_FILE, _
        '                         Subject, _
        '    StartDate.ToUniversalTime().ToString(lcDateFormat), _
        '    EndDate.ToUniversalTime().ToString(lcDateFormat), _
        '    Now.ToUniversalTime().ToString(lcDateFormat), _
        '    "{" & loGUID.ToString() & "}", _
        '    Summary, _
        '    OrganizerEmail, _
        '    AttendeeEmail)

        'End Function
        End Class
End Namespace