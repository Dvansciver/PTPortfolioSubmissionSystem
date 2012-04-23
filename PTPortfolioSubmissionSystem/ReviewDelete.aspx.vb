Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class ReviewDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblReviewID.Text = Request("ReviewID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT r.PortfolioID, r.UserID, r.Review, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + u.Type + ')' as Reviewer FROM Review r inner join [User] u on r.UserID=u.UserID where r.ReviewID = " & lblReviewID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblPortfolioID.Text = rdrGET("PortfolioID")
                lblUserID.Text = rdrGET("UserID")
                lblReviewer.Text = rdrGET("Reviewer")
                If IsDBNull(rdrGET("Review")) Then
                    lblReview.ForeColor = Drawing.Color.Red
                    lblReview.Text = "Pending"
                Else
                    lblReview.Text = rdrGET("Review")
                End If

                lblUsername.Text = rdrGET("Username")
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try

        End If

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT p.UserID, p.ReviewStage, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + p.ReviewStage + ')' as Portfolio FROM Portfolio p inner join [User] u on p.UserID=u.UserID where PortfolioID = " & lblPortfolioID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblPortfolioUserName.Text = rdrGET("Username")
            lblPortfolio.Text = rdrGET("Portfolio")
            lblReviewStage.Text = rdrGET("ReviewStage")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        Dim sqlDelete As String

        sqlDelete = "DELETE FROM Review Where ReviewID=" & lblReviewID.Text

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

        If lblError.Visible = False Then
            If lblReview.Text = "" Then

                Response.Redirect("Review.aspx")

            Else

                Dim di As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Reviews\" & lblUsername.Text.Trim.Replace(" ", "") & "\" & lblReview.Text.Trim.Replace(" ", ""))
                Try

                    di.Delete()

                Catch ex As Exception
                    lblError.Visible = True
                    lblError.Text = "Insert Query Error: " & ex.ToString
                End Try

                Response.Redirect("Review.aspx")

            End If

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Review.aspx")
    End Sub
End Class