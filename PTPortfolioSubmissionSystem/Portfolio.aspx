<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Portfolio.aspx.vb" Inherits="PTPortfolioSubmissionSystem.Portfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Portfolios" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnAdd" Text="Add Portfolio" />&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Search by Year Submitted..."></asp:Label>&nbsp;
            <asp:TextBox runat="server" ID="txtYearSearch" ></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnYearSearch" Text="Search" />&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Search by Last Name..."></asp:Label>&nbsp;
            <asp:TextBox runat="server" ID="txtLastNameSearch" ></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnLastNameSearch" Text="Search" />&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
     <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdPortfolios" runat="server" DataSourceID="SqlPortfolios" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Modify" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="PortfolioModify.aspx?PortfolioID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="10%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="PortfolioDelete.aspx?PortfolioID={0}" />
                    <asp:BoundField HeaderText="Candidate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="16%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" SortExpression="Candidate" DataField="Candidate" />
                    <asp:BoundField HeaderText="Review Stage" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="16%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="ReviewStage" SortExpression="ReviewStage"/>
                    <asp:BoundField HeaderText="Due Date" DataFormatString="{0:d}" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="DueDate" SortExpression="DueDate" />
                    <asp:TemplateField HeaderText="Date Submitted" SortExpression="PostDate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblPostDate" Text='<%# Eval("PostDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="8%" ItemStyle-Font-Bold="true" Text="Artifacts" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="Artifact.aspx?PortfolioID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="8%" ItemStyle-Font-Bold="true" Text="Assign Reviewers" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="AssignReviewers.aspx?PortfolioID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="10%" ItemStyle-Font-Bold="true" Text="View Portfolio" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="PortfolioView.aspx?PortfolioID={0}" />
                    <asp:HyperLinkField ItemStyle-Font-Bold="true" Text="Reviews Report" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="PortfolioReviewsReport.aspx?PortfolioID={0}" />
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlPortfolios" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate From [User] u inner join Portfolio p on u.UserID=p.UserID order by Candidate" >
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
