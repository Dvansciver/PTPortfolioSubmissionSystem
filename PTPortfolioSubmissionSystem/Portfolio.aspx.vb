Public Class Portfolio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("PortfolioAdd.aspx")
    End Sub

    Private Sub btnYearSearch_Click(sender As Object, e As System.EventArgs) Handles btnYearSearch.Click

        If txtYearSearch.Text = "" Then

            Response.Redirect("Portfolio.aspx")

        Else

            SqlPortfolios.SelectCommand = "Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate From [User] u inner join Portfolio p on u.UserID=p.UserID where p.PostDate like '%" & txtYearSearch.Text & "%' order by p.PostDate"

        End If


    End Sub

    Private Sub btnLastNameSearch_Click(sender As Object, e As System.EventArgs) Handles btnLastNameSearch.Click

        If txtLastNameSearch.Text = "" Then

            Response.Redirect("Portfolio.aspx")

        Else

            SqlPortfolios.SelectCommand = "Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate From [User] u inner join Portfolio p on u.UserID=p.UserID where u.LastName like '%" & txtLastNameSearch.Text & "%' order by u.LastName"

        End If

    End Sub

    Private Sub grdPortfolios_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPortfolios.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim myLabel As New Label()
            myLabel = DirectCast(e.Row.FindControl("lblPostDate"), Label)
            Dim rowValue As String = myLabel.Text

            If rowValue Is Nothing OrElse rowValue.Length < 1 Then
                myLabel.Text = "Pending"
                myLabel.ForeColor = Drawing.Color.Red

            Else

                myLabel.Text = CDate(myLabel.Text)

            End If
        End If

    End Sub
End Class