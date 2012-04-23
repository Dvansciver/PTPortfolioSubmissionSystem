Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class PortfolioReviewsReport
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT p.PortfolioID, p.UserID, u.UserId, u.Firstname + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate, p.ReviewStage, p.PostDate, p.DueDate FROM Portfolio p inner join [User] u on p.UserId=u.UserId where p.PortfolioID = " & lblPortfolioID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblCandidate.Text = rdrGET("Candidate")
                lblReviewStage.Text = rdrGET("ReviewStage")
                If IsDBNull(rdrGET("PostDate")) Then
                    lblPostDate.ForeColor = Drawing.Color.Red
                    lblPostDate.Text = "Pending"
                Else
                    lblPostDate.Text = rdrGET("PostDate")
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

    Private Sub grdReviews_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReviews.RowDataBound


        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim myLabel As New Label()
            myLabel = DirectCast(e.Row.FindControl("lblReviewDate"), Label)
            Dim rowValue As String = myLabel.Text

            If rowValue Is Nothing OrElse rowValue.Length < 1 Then
                myLabel.Text = "Pending"
                myLabel.ForeColor = Drawing.Color.Red

            Else

                myLabel.Text = CDate(myLabel.Text)

            End If
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Portfolio.aspx")
    End Sub
End Class