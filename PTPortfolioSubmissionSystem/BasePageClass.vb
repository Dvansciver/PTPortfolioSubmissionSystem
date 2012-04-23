Public Class BasePageClass
    Inherits System.Web.UI.Page
    Protected Sub CheckSession()
        If Context.Session IsNot Nothing Then
            If Session.IsNewSession Then
                Dim newSessionIdCookie As HttpCookie = Request.Cookies("ASP.NET_SessionId")
                If newSessionIdCookie IsNot Nothing Then
                    Dim newSessionIdCookieValue As String = newSessionIdCookie.Value
                    If newSessionIdCookieValue <> String.Empty Then
                        ' This means Session was timed Out and New Session was started
                        Response.Redirect("UserLogin.aspx")
                    End If
                End If
            End If
        End If
    End Sub
End Class
