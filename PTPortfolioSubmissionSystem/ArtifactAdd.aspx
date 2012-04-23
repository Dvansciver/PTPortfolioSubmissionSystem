<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactAdd.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain">
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Add Artifact" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Font-Bold="true" Text="Portfolio:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblCandidateName"></asp:Label>&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Review Stage:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblRS"></asp:Label>&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Date Submitted:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblDateSubmitted"></asp:Label>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Artifact: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:FileUpload ID="FileupArtifact" runat="server" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ID="rfvReview" ControlToValidate="FileupArtifact" Display="Dynamic" ForeColor="Red" ErrorMessage="*Required" ></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Artifact Type:" ></asp:Label>&nbsp;
            </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlArtifactType" DataSourceID="SqlArtifactType" DataTextField="Type" DataValueField="ArtifactTypeID"></asp:DropDownList>&nbsp;
            <asp:SqlDataSource ID="SqlArtifactType" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select ArtifactTypeID, Type From ArtifactType order by Type" ></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
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
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPostDate" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblReviewStage" Visible="false"></asp:Label>
</asp:Content>
