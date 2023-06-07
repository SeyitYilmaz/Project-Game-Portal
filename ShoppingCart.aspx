<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Project_Game_Portal.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <h1>Veriler</h1>
        <asp:Repeater ID="messageRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Oyun ID</th>
                            <th>Oyun Adı</th>
                            <th>Oyun Fiyatı</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ContactID") %></td>
                    <td><%# Eval("ContactUsername") %></td>
                    <td><%# Eval("ContactMail") %></td>
                    <td><%# Eval("ContactMessage") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
