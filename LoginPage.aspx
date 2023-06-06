<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_Game_Portal.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="row">
        <div class="col-md-3 offset-md-2 mx-auto">
            <div class="container">
                <h1>Oturum Aç</h1>
                <div class="form-group">
                    <label for="txtMail">E-posta Adresi:</label>
                    <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" placeholder="E-posta adresinizi girin"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Şifreniz:</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" placeholder="Şifrenizi girin"></asp:TextBox>
                </div>
                <asp:Button ID="btnSignin" runat="server" Text="Oturum Aç" CssClass="btn btn-primary" OnClick="btnSignin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
