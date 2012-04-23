Public Class Review
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("ReviewAdd.aspx")
    End Sub

    Private Sub btnLastNameSearch_Click(sender As Object, e As System.EventArgs) Handles btnLastNameSearch.Click

        If txtLastNameSearch.Text = "" Then

            Response.Redirect("Review.aspx")

        Else

            SqlReviews.SelectCommand = "Select r.ReviewID, r.UserID, r.PortfolioID, r.PostDate as ReviewDate, u.UserID, u.Type, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate as PortfolioDate, (Select c.Firstname + ' ' + c.MiddleInitial + '. ' + c.Lastname from [User] c where c.UserID=p.UserID) as Candidate From (Review r inner join [User] u on r.UserID=u.UserID) inner join Portfolio p on r.PortfolioID=p.PortfolioID Where u.Lastname like '%" & txtLastNameSearch.Text & "%' order by Reviewer"

        End If
    End Sub

    Private Sub btnYearSearch_Click(sender As Object, e As System.EventArgs) Handles btnYearSearch.Click

        If txtYearSearch.Text = "" Then

            Response.Redirect("Review.aspx")

        Else

            SqlReviews.SelectCommand = "Select r.ReviewID, r.UserID, r.PortfolioID, r.PostDate as ReviewDate, u.UserID, u.Type, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate as PortfolioDate, (Select c.Firstname + ' ' + c.MiddleInitial + '. ' + c.Lastname from [User] c where c.UserID=p.UserID) as Candidate From (Review r inner join [User] u on r.UserID=u.UserID) inner join Portfolio p on r.PortfolioID=p.PortfolioID Where p.PostDate like '%" & txtYearSearch.Text & "%' order by p.PostDate"

        End If
    End Sub

    Private Sub grdReviews_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReviews.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim RLabel As New Label()
            RLabel = DirectCast(e.Row.FindControl("lblReviewDate"), Label)
            Dim rowValue As String = RLabel.Text

            If rowValue Is Nothing OrElse rowValue.Length < 1 Then
                RLabel.Text = "Pending"
                RLabel.ForeColor = Drawing.Color.Red

            Else

                RLabel.Text = CDate(RLabel.Text)

            End If
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim PLabel As New Label()
            PLabel = DirectCast(e.Row.FindControl("lblPortfolioDate"), Label)
            Dim rowValue As String = PLabel.Text

            If rowValue Is Nothing OrElse rowValue.Length < 1 Then
                PLabel.Text = "Pending"
                PLabel.ForeColor = Drawing.Color.Red

            Else

                PLabel.Text = CDate(PLabel.Text)

            End If
        End If

    End Sub
End Class