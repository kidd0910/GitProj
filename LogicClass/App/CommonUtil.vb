Imports Acer.Util
Imports Acer.Form.FormUtil
Imports Acer.Base
Imports Acer.Form
Imports Acer.Apps

Public Class CommonUtil
    Public Shared Function DecryptColumnByConfig(ByVal sqlSelect As String) As String
        Dim resultSql As String = ""

        Dim cryptoCols As String = APConfig.GetProperty("ENCODE_COLUMN")
        cryptoCols = "APP_PERSON_NM,REPRESENTATIVE,LIVE_ADDRESS,BUSINESS_ADDRESS,MAILING_ADDRESS,CONTACT_PERSON,CONTACT_ADDRESS,USER_NAME,USER_ID,TEL,MEMBER_NAME,MANAGER_NAME,PID,PASSPORT_ID"
        If sqlSelect.Length > 0 Then
            If cryptoCols.Length > 0 Then
                Dim cols() As String = cryptoCols.Split(",")
                If cols.Length > 0 Then
                    Dim subStr As String = sqlSelect.Substring(0, InStr(sqlSelect, "FROM"))
                    If subStr.Length > 0 Then
                        Dim subCols As String() = Split(subStr, "")
                        For Each col As String In subCols
                            If Not skip(col.Trim) Then

                                'If alianCols.Length > 0 Then
                                '    alianCols(0) =
                                'Else

                                'End If
                            End If
                        Next
                    End If
                End If


                'For Each thistmp As String In cols
                '    If skip(thistmp) Then
                '        Continue For
                '    End If

                '    thistmp.Trim()

                '    resultSql = sqlSelect.Replace(thisCol, "dbo.TripleDesDecrypt(" + thisCol + ") ")
                'Next
            End If
        End If

        Return resultSql
    End Function

    Public Shared ReadOnly SKIP_KEY As String() = {"FROM", "WHERE", "AND", "JOIN"}

    Private Shared Function replaceKey(ByVal str As String, ByVal cryptoCols As String()) As Boolean
        If str.Length > 0 Then
            For Each cryCol As String In cryptoCols
                If cryCol.Contains(cryCol) Then
                    'cryCol
                End If
            Next
        End If
    End Function
    Private Shared Function skip(ByVal str As String) As Boolean

        If (str.Length > 0) Then
            For Each key As String In SKIP_KEY
                If str.Contains(key) Then
                    Return True
                End If
            Next
        Else
            Return True
        End If

        Return False

    End Function
End Class
