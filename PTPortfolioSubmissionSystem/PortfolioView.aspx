<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PortfolioView.aspx.vb" Inherits="PTPortfolioSubmissionSystem.PortfolioView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain">
<asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="View Portfolio" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Candidate: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblFullName" Font-Size="Large" ForeColor="Black"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Review Stage: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblReviewStage" ForeColor="Black" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Due Date: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblDueDate" ForeColor="Black" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Date Submitted: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblPostDate" ForeColor="Black" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Portfolio Artifacts:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlArtifacts" DataSourceID="SqlArtifacts" DataTextField="FullArtifact" DataValueField="Artifact" AutoPostBack="true"  ></asp:DropDownList>&nbsp;
            <asp:SqlDataSource ID="SqlArtifacts" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID=@PID order by a.Artifact">
            <SelectParameters>
               <asp:ControlParameter ControlID="lblPortfolioID" Name="PID" />
            </SelectParameters>
            </asp:SqlDataSource>
            <asp:HyperLink runat="server" ID="lnkOpen" Text="Open Selected Artifact" Font-Bold="true" Target="_blank"></asp:HyperLink>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Button runat="server" ID="btnBack" Text="Back" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
</asp:Content>
