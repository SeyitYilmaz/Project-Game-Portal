<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="Project_Game_Portal.ContactPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="row">
        <div class="col-md-3 offset-md-2 mx-auto">
            <div class="container">
                <h1>İletişim</h1>
                <div class="form-group">
                    <label for="txtUsername">Kullanıcı Adı:</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Kullanıcı adınızı girin"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail">E-posta Adresi:</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="E-posta adresinizi girin"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMessage">Mesaj:</label>
                    <asp:TextBox ID="txtMessage" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4" placeholder="Mesajınızı girin"></asp:TextBox>
                </div>
                <asp:Button ID="btnSend" runat="server" Text="Gönder" CssClass="btn btn-primary" OnClick="btnSend_Click" />
            </div>
        </div>
    </div>

</asp:Content>
