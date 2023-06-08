<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Project_Game_Portal.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <h1>Veriler</h1>
        <asp:Repeater ID="gameRepeater" runat="server" OnItemDataBound="gameRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Kullanıcı ID</th>
                            <th>Kullanıcı Adı</th>
                            <th>Kullanıcı Maili</th>
                            <th>Admin</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td id="UserID" runat="server"><%# Eval("UserID") %></td>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("UserMail") %></td>
                    <td><asp:CheckBox ID="adminCheckBox" runat="server" Text="Admin"/></td>
                    <td><asp:Button CssClass="btn btn-danger btn-block" ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil"/></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
