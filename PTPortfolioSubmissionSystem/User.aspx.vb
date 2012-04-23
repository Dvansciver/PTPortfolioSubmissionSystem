Public Class User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("UserAdd.aspx")
    End Sub

    Private Sub btnSearchLastName_Click(sender As Object, e As System.EventArgs) Handles btnSearchLastName.Click

        If txtSearchLastName.Text = "" Then

            Response.Redirect("User.aspx")

        Else

            SqlUsers.SelectCommand = "Select UserID, FirstName, MiddleInitial, LastName, Username, Type From [User] where LastName like '%" & txtSearchLastName.Text & "%' order by LastName"

        End If

    End Sub

    Private Sub btnSearchUserType_Click(sender As Object, e As System.EventArgs) Handles btnSearchUserType.Click


        SqlUsers.SelectCommand = "Select UserID, FirstName, MiddleInitial, LastName, Username, Type From [User] where Type= '" & ddlUserType.SelectedValue & "' order by LastName"

    End Sub
End Class