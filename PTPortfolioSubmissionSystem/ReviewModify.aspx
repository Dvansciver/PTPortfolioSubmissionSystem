<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReviewModify.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ReviewModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Modify Review" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="15%" HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Portfolio:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblPortfolio" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Reviewer: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblReviewer" Font-Size="large"></asp:Label>
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
            <asp:Label runat="server" Text="Current Review:" Font-Bold="true" ForeColor="Black"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblReview" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Change Review: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:FileUpload ID="FileupReview" runat="server" />&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnModify" Text="Modify" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnReset" Text="Reset" CausesValidation="false" />&nbsp;
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CausesValidation="false" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioUserName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewStage" Visible="false"></asp:Label>
</asp:Content>
