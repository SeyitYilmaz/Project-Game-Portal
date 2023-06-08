<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="Project_Game_Portal.SignupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="row">
        <div class="col-md-3 offset-md-2 mx-auto">
            <div class="container">
                <h1>Kayıt Ol
                </h1>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Kayıt Ol" CssClass="btn btn-primary" OnClick="btnSignUp_Click" />
                <div class="form-group mt-3">
                    <asp:HyperLink ID="lnkSignup" runat="server" Text="Hesabın var mı? Giriş Yap" NavigateUrl="LoginPage.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
