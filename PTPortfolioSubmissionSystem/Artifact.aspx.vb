Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Class Artifact
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


            lblPortfolioID.Text = Request("PortfolioID")

            Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT p.PortfolioID, p.UserID, p.PostDate, p.ReviewStage, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate FROM Portfolio p inner join [User] u on p.UserID=u.UserID where p.PortfolioID = " & lblPortfolioID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader

            rdrGET.Read()
            lblCandidateName.Text = rdrGET("Candidate")
            If IsDBNull(rdrGET("PostDate")) Then
                lblPostDate.ForeColor = Drawing.Color.Red
                lblPostDate.Text = "Pending"
            Else
                lblPostDate.Text = rdrGET("PostDate")
            End If

            lblReviewStage.Text = rdrGET("ReviewStage")
            rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("ArtifactAdd.aspx?PortfolioID=" & lblPortfolioID.Text)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        If Session("IsAdmin") = True Then
            Response.Redirect("Portfolio.aspx")
        ElseIf Session("IsCandidate") = True Then
            Response.Redirect("/Candidate/SubmitPortfolio.aspx")
        End If

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Dim sqlInsert As String = "Update Portfolio Set PostDate='" & CDate(Date.Today.Date) & "' where PortfolioID=" & lblPortfolioID.Text

        Try
            cnPT.Open()
            Dim daSC As New SqlDataAdapter
            daSC.InsertCommand = New SqlCommand(sqlInsert, cnPT)
            daSC.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Insert Query Error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        If Session("IsAdmin") = True Then
            Response.Redirect("Portfolio.aspx")
        ElseIf Session("IsCandidate") = True Then
            Response.Redirect("/Candidate/SubmitPortfolio.aspx")
        End If


    End Sub
End Class