<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactModify.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:Label runat="server" Text="Modify Artifact" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Current Artifact:" Font-Bold="true" ForeColor="Black"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblArtifact" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Change Artifact: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:FileUpload ID="FileupArtifact" runat="server" />&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Artifact Type:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlArtifactType" DataSourceID="SqlArtifactType" DataTextField="Type" DataValueField="ArtifactTypeID"></asp:DropDownList>&nbsp;
            <asp:SqlDataSource ID="SqlArtifactType" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select ArtifactTypeID, Type From ArtifactType order by Type" ></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnModify" Text="Modify" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnReset" Text="Reset" />&nbsp;
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
