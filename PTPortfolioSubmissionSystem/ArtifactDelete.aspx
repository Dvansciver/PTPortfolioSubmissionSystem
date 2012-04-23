<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactDelete.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:Label runat="server" Text="Delete Artifact" Font-Bold="true" ForeColor="Red" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Text="Artifact:" Font-Bold="true" ForeColor="Black"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblArtifact"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Artifact Type:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblArtifactType"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnDelete" Text="Delete" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblArtifactID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPostDate" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewStage" Visible="false"></asp:Label>
</asp:Content>
