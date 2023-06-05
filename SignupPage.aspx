<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="Project_Game_Portal.SignupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
            <h1>İletişim</h1>
            <div class="form-group">
                <label for="txtName">Kullanıcı Adı:</label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Kullanıcı adınızı girin"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtMail">E-posta Adresi:</label>
                <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" placeholder="E-posta adresinizi girin"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Şifreniz:</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" placeholder="Şifrenizi girin"></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" runat="server" Text="Gönder" CssClass="btn btn-primary" OnClick="btnSignUp_Click" />
        </div>
</asp:Content>
