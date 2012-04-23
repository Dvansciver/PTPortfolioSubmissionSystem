<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReviewAdd.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ReviewAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Add Review" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="15%" HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Portfolio:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlPortfolios" AutoPostBack="true" CausesValidation="false" DataSourceID="sqlPortfolios" DataTextField="Portfolio" DataValueField="PortfolioID"></asp:DropDownList>
            <asp:SqlDataSource ID="sqlPortfolios" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + p.ReviewStage + ')' as Portfolio, p.UserID, p.PortfolioID From [User] u inner join Portfolio p on u.UserID=p.UserID Where u.UserID=p.UserID order by u.Lastname, p.ReviewStage"></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Reviewer: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlReviewers" DataSourceID="sqlReviewers" DataTextField="Reviewer" DataValueField="UserID" ></asp:DropDownList>&nbsp;
            <asp:SqlDataSource ID="sqlReviewers" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select UserID, Username, FirstName + ' ' + MiddleInitial + '. ' + LastName + ' (' + Type + ')' as Reviewer From [User] Where (Type='Peer Reviewer' OR Type='Classroom Observer') order by Reviewer"></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Please consider this portfolio's artifacts before submitting a review." Font-Bold="true"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Portfolio Artifacts:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlArtifacts" DataSourceID="SqlArtifacts" DataTextField="FullArtifact" DataValueField="Artifact" AutoPostBack="true"  ></asp:DropDownList>&nbsp;
            <asp:SqlDataSource ID="SqlArtifacts" runat="server" ConnectionString="<%$ connectionstrings:PT %>"></asp:SqlDataSource>
            <asp:HyperLink runat="server" ID="lnkOpen" Text="Open Selected Artifact" Font-Bold="true" Target="_blank"></asp:HyperLink>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Review: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:FileUpload ID="FileupReview" runat="server" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ID="rfvReview" ControlToValidate="FileupReview" Display="Dynamic" ForeColor="Red" ErrorMessage="*Required" ></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CausesValidation="false" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioUserName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewStage" Visible="false"></asp:Label>
</asp:Content>
