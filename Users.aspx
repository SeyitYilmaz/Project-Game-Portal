<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Project_Game_Portal.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <h1>Veriler</h1>
        <asp:Repeater ID="gameRepeater" runat="server" OnItemDataBound="gameRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Oyun ID</th>
                            <th>Oyun Adı</th>
                            <th>Oyun Fiyatı</th>
                            <th>Admin</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("UserID") %></td>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("UserMail") %></td>
                    <td><asp:CheckBox ID="adminCheckBox" runat="server" Text="Admin"/></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
