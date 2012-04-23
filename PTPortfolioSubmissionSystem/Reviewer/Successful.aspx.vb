Public Class Successful
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("/Reviewer/SubmitReview.aspx")
    End Sub
End Class