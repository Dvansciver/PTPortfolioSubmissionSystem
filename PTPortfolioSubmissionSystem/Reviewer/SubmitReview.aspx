<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SubmitReview.aspx.vb" Inherits="PTPortfolioSubmissionSystem.SubmitReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Submit Review" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="15%" HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Portfolio:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlPortfolios" AutoPostBack="true" CausesValidation="false" DataSourceID="sqlPortfolios" DataTextField="Portfolio" DataValueField="PortfolioID"></asp:DropDownList>
            <asp:SqlDataSource ID="sqlPortfolios" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + p.ReviewStage + ')' as Portfolio, p.UserID, p.PortfolioID From [User] u inner join Portfolio p on u.UserID=p.UserID Where p.PortfolioID In (Select r.PortfolioID From Review r Where r.PostDate Is Null) Order by u.Lastname, p.ReviewStage"></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" ID="lblDisclaimer" Text="Please consider this portfolio's artifacts before submitting a review." Font-Bold="true"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="trArtifacts">
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
        <asp:TableCell>&nbsp;</asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table runat="server" ID="tblNoPortfolios" Visible="false">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblRequired" ForeColor="Red" Visible="false"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioUserName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewStage" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
</asp:Content>
