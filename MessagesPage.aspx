<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="MessagesPage.aspx.cs" Inherits="Project_Game_Portal.MessagesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <h1>Mesajlar</h1>
        <asp:Repeater ID="messageRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Mesaj No</th>
                            <th>Kullanıcı Adı</th>
                            <th>Kullanıcı Mail Adresi</th>
                            <th>Mesaj İçeriği</th>
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
