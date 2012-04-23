Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("IsAdmin") = True Then
            lblUserType.Text = "Administrator"

        ElseIf Session("IsCandidate") = True Then
            lblUserType.Text = "Candidate"
            btnReview.Visible = "False"
            btnUser.Visible = "False"
            btnArtifactType.Visible = "False"
            btnPortfolio.Visible = "False"
            NavigationMenu.Visible = "False"

        ElseIf Session("IsClassroomObserver") = True Then
            lblUserType.Text = "Classroom Observer"
            btnReview.Visible = "False"
            btnUser.Visible = "False"
            btnArtifactType.Visible = "False"
            btnPortfolio.Visible = "False"
            NavigationMenu.Visible = "False"

        ElseIf Session("IsPeerReviewer") = True Then
            lblUserType.Text = "Peer Reviewer"
            btnReview.Visible = "False"
            btnUser.Visible = "False"
            btnArtifactType.Visible = "False"
            btnPortfolio.Visible = "False"
            NavigationMenu.Visible = "False"

        Else
            Response.Redirect("UserLogin.aspx")
        End If

        lblUsername.Text = Session("Username")

    End Sub

    Private Sub btnPortfolio_Click(sender As Object, e As System.EventArgs) Handles btnPortfolio.Click
        Response.Redirect("Portfolio.aspx")
    End Sub

    Private Sub btnReview_Click(sender As Object, e As System.EventArgs) Handles btnReview.Click
        Response.Redirect("Review.aspx")
    End Sub

    Private Sub btnArtifactType_Click(sender As Object, e As System.EventArgs) Handles btnArtifactType.Click
        Response.Redirect("ArtifactType.aspx")
    End Sub

    Private Sub btnUser_Click(sender As Object, e As System.EventArgs) Handles btnUser.Click
        Response.Redirect("User.aspx")
    End Sub

End Class