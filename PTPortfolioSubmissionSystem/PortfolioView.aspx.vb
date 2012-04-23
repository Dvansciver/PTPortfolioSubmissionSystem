Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class PortfolioView
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate, u.UserID, u.Username, u.Firstname + ' ' + u.MiddleInitial + '. ' + u.Lastname as Fullname FROM Portfolio p inner join [User] u on p.UserID=u.UserID where PortfolioID = " & lblPortfolioID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblFullName.Text = rdrGET("Fullname")
                If IsDBNull(rdrGET("PostDate")) Then
                    lblPostDate.ForeColor = Drawing.Color.Red
                    lblPostDate.Text = "Pending"
                Else
                    lblPostDate.Text = rdrGET("PostDate")
                End If
                lblDueDate.Text = CDate(rdrGET("DueDate"))
                lblReviewStage.Text = rdrGET("ReviewStage")
                lblUsername.Text = rdrGET("Username")
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try
        End If

        lnkOpen.NavigateUrl = "~/Portfolios/" & lblUsername.Text & lblReviewStage.Text & "/" & ddlArtifacts.SelectedValue


    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        If Session("IsAdmin") = True Then
            Response.Redirect("Portfolio.aspx")
        ElseIf Session("IsCandidate") = True Then
            Response.Redirect("/Candidate/SubmitPortfolio.aspx")
        End If

    End Sub

    Private Sub ddlArtifacts_DataBound(sender As Object, e As System.EventArgs) Handles ddlArtifacts.DataBound
        Dim SelectedValue As String = ddlArtifacts.SelectedValue
        lnkOpen.NavigateUrl = "~/Portfolios/" & lblUsername.Text & lblReviewStage.Text & "/" & SelectedValue

    End Sub
End Class