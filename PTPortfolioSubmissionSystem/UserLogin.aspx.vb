Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class UserLogin
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtUserName.Focus()

        Session("Username") = ""
        Session("IsAdmin") = False
        Session("IsCandidate") = False
        Session("IsClassroomObserver") = False
        Session("IsPeerReviewer") = False

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click

            Try

            cnPT.Open()

            Dim sqlSelect As String = "SELECT UserID, Username, Password, Type FROM [User] where Username='" & txtUserName.Text & "' and Password='" & txtPassword.Text & "'"
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            

            If Not rdrGET.HasRows Then

                txtUserName.Focus()
                lblFailLogin.Visible = True

            Else
                While rdrGET.Read
                    Session("Username") = txtUserName.Text
                    Session("UserID") = rdrGET("UserID")
                    Select Case rdrGET("Type")
                        Case "Administrator"
                            Session("IsAdmin") = True
                            Response.Redirect("Default.aspx")
                        Case "Candidate"
                            Session("IsCandidate") = True
                            Response.Redirect("Candidate/SubmitPortfolio.aspx")
                        Case "Classroom Observer"
                            Session("IsClassroomObserver") = True
                            Response.Redirect("/Reviewer/SubmitReview.aspx")
                        Case "Peer Reviewer"
                            Session("IsPeerReviewer") = True
                            Response.Redirect("/Reviewer/SubmitReview.aspx")
                    End Select

                End While

            End If
            Catch ex As Exception
            lblHidden.Visible = True
            lblHidden.Text = "Query Error: " & ex.ToString
        Finally
            cnPT.Close()
            End Try


    End Sub
End Class