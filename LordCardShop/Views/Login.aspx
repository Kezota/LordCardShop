<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LordCardShop.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 loginSignupContainer">
        <h2>Login to Lord Card Shop</h2>
        <div class="card mt-4">
            <div class="card-body">
                <div class="form-group">
                    <label for="Username">Username</label>
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control" Placeholder="Enter your username" />
                </div>
                <div class="form-group mt-3">
                    <label for="Password">Password</label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password" />
                </div>
                <div class="mt-3">
                    <a href="Register.aspx" class="btn-link">Don't have an account? Register here</a>
                </div>
                <!-- Error Message -->
                <div class="mt-3">
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="text-danger" Text="" Visible="false"></asp:Label>
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
