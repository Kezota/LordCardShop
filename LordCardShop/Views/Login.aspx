<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LordCardShop.Views.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 loginSignupContainer">
        <h2>Login to Lord Card Shop</h2>
        <div class="card mt-4">
            <div class="card-body">
                <form method="post" action="loginAction.aspx">
                    <div class="form-group">
                        <label for="username">Username</label>
                        <input type="text" id="username" name="username" class="form-control" required placeholder="Enter your username" />
                    </div>
                    <div class="form-group mt-3">
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password" class="form-control" required placeholder="Enter your password" />
                    </div>
                    <div class="mt-3">
                        <a href="RegisterPage.aspx" class="btn-link">Don't have an account? Register here</a>
                    </div>
                    <!-- Error Message -->
                    <div class="mt-3">
                        <asp:Label ID="ErrorMessage" runat="server" CssClass="text-danger" Text="" Visible="false"></asp:Label>
                        <button type="submit" class="btn btn-primary btn-block">Login</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
