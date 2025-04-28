<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="LordCardShop.Views.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 loginSignupContainer">
        <h2>Register to Lord Card Shop</h2>
        <div class="card mt-4">
            <div class="card-body">
                <form method="post" action="registerAction.aspx">
                    <div class="form-group">
                        <label for="username">Username</label>
                        <input type="text" id="username" name="username" class="form-control" required placeholder="Enter your username" />
                    </div>
                    <div class="form-group mt-3">
                        <label for="email">Email</label>
                        <input type="email" id="email" name="email" class="form-control" required placeholder="Enter your email" />
                    </div>
                    <div class="form-group mt-3">
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password" class="form-control" required placeholder="Enter your password" />
                    </div>
                    <div class="form-group mt-3">
                        <label for="confirmPassword">Confirm Password</label>
                        <input type="password" id="confirmPassword" name="confirmPassword" class="form-control" required placeholder="Confirm your password" />
                    </div>
                    <div class="form-group mt-3">
                        <label for="gender">Gender</label>
                        <select id="gender" name="gender" class="form-control" required>
                            <option value="">Select Gender</option>
                            <option value="male">Male</option>
                            <option value="female">Female</option>
                        </select>
                    </div>

                    <div class="form-group mt-3">
                        <label for="role">Role</label>
                        <select id="role" name="role" class="form-control" required>
                            <option value="customer" aria-checked>Customer</option>
                            <option value="admin">Admin</option>
                        </select>
                    </div>

                    <!-- Error Message -->
                    <div class="mt-3">
                        <asp:Label ID="ErrorMessage" runat="server" CssClass="text-danger" Text="" Visible="false"></asp:Label>
                        <button type="submit" class="btn btn-primary btn-block">Register</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
