Imports System.Data.SqlClient
Imports System.Web.Configuration
Public Class ReviewView
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblReviewID.Text = Request("ReviewID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "Select r.ReviewID, r.UserID, r.PortfolioID, r.PostDate as ReviewDate, r.Review, u.UserID, u.Username, u.Type, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate as PortfolioDate, (Select c.Firstname + ' ' + c.MiddleInitial + '. ' + c.Lastname from [User] c where c.UserID=p.UserID) as Candidate From (Review r inner join [User] u on r.UserID=u.UserID) inner join Portfolio p on r.PortfolioID=p.PortfolioID Where ReviewID=" & lblReviewID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblReviewer.Text = rdrGET("Reviewer")
                lblUsername.Text = rdrGET("Username")
                lblReviewType.Text = rdrGET("Type")
                lblPortfolio.Text = rdrGET("Candidate") & " (" & rdrGET("ReviewStage") & ")"
                If IsDBNull(rdrGET("Review")) Then
                    lnkReview.ForeColor = Drawing.Color.Red
                    lnkReview.Text = "Pending"
                Else
                    lnkReview.Text = rdrGET("Review")
                    lnkReview.NavigateUrl = "~/Reviews/" & lblUsername.Text & "/" & lnkReview.Text
                End If
                If IsDBNull(rdrGET("ReviewDate")) Then
                    lblReviewDate.ForeColor = Drawing.Color.Red
                    lblReviewDate.Text = "Pending"
                Else
                    lblReviewDate.Text = CDate(rdrGET("ReviewDate"))
                End If

                If IsDBNull(rdrGET("PortfolioDate")) Then
                    lblPortfolioDate.ForeColor = Drawing.Color.Red
                    lblPortfolioDate.Text = "Pending"
                Else
                    lblPortfolioDate.Text = CDate(rdrGET("PortfolioDate"))
                End If

                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Review.aspx")
    End Sub
End Class