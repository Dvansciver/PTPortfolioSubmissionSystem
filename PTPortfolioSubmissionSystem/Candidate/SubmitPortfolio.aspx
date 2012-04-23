<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SubmitPortfolio.aspx.vb" Inherits="PTPortfolioSubmissionSystem.SubmitPortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="My Portfolios" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
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
                    <asp:BoundField HeaderText="Review Stage" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="16%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="ReviewStage" SortExpression="ReviewStage"/>
                    <asp:BoundField HeaderText="Due Date" DataFormatString="{0:d}" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="DueDate" SortExpression="DueDate" />
                    <asp:TemplateField HeaderText="Date Submitted" ItemStyle-Width="15%" SortExpression="PostDate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblPostDate" Text='<%# Eval("PostDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="8%" ItemStyle-Font-Bold="true" Text="Artifacts" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="/Artifact.aspx?PortfolioID={0}" />
                    <asp:HyperLinkField ItemStyle-Font-Bold="true" Text="View Portfolio" DataNavigateUrlFields="PortfolioID" DataNavigateUrlFormatString="/PortfolioView.aspx?PortfolioID={0}" />
                  </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlPortfolios" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Candidate, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate From [User] u inner join Portfolio p on u.UserID=p.UserID where u.UserID=@UID Order By p.PostDate">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblUserID" Name="UID" />
            </SelectParameters>
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblUserID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="False"></asp:Label>
</asp:Content>
