Imports System.Data.SqlClient
Imports System.Web.Configuration
Public Class AssignmentDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPID.Text = Request("PortfolioID")
            lblUserID.Text = Request("UserID")


            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT u.UserID, u.Firstname + ' ' + ' ' + u.MiddleInitial + '. ' + u.Lastname + ' (' + p.ReviewStage + ')' as Portfolio, p.UserID, p.PortfolioID, (Select Firstname + ' ' + ' ' + MiddleInitial + '. ' + Lastname + ' (' + Type + ')' From [User] where UserID=" & lblUserID.Text & ") as Reviewer FROM [User] u inner join Portfolio p on u.UserID=p.UserID  where p.PortfolioID = " & lblPID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblPortfolio.Text = rdrGET("Portfolio")
                lblReviewer.Text = rdrGET("Reviewer")
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try
        End If
        
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click


        Dim hasReview As Boolean = False
        Dim reviewCounter As Integer
        Try
            cnPT.Open()
            Dim sqlCheck As String = "Select Count(Review) as ReviewCounter, UserID, PortfolioID from Review where UserID=" & lblUserID.Text & " And PortfolioID=" & lblPID.Text & " Group By UserID, PortfolioID"
            Dim cmdGET As New SqlCommand(sqlCheck, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            reviewCounter = rdrGET("ReviewCounter")
            rdrGET.Close()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        If reviewCounter > 0 Then
            hasReview = True
        End If

        If hasReview = True Then

            lblCannotDelete.Visible = True

        ElseIf hasReview = False Then


            Dim sqlDelete As String
            sqlDelete = "DELETE FROM Review Where UserID=" & lblUserID.Text

            Try
                cnPT.Open()
                Dim objCommand As New SqlCommand(sqlDelete, cnPT)
                objCommand.ExecuteNonQuery()
            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Delete error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try

            If lblError.Visible = "False" Then
                Response.Redirect("AssignReviewers.aspx?PortfolioID=" & lblPID.Text)
            End If

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("AssignReviewers.aspx?PortfolioID=" & lblPID.Text)

    End Sub
End Class