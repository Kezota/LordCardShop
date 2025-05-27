<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LordCardShop.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 loginSignupContainer">
        <h2>Register to Lord Card Shop</h2>
        <div class="card mt-4">
            <div class="card-body">
                <div class="form-group">
                    <label for="Username">Username</label>
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control" Placeholder="Enter your username" />
                </div>
                <div class="form-group mt-3">
                    <label for="Email">Email</label>
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Enter your email" />
                </div>
                <div class="form-group mt-3">
                    <label for="Password">Password</label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password" />
                </div>
                <div class="form-group mt-3">
                    <label for="ConfirmPassword">Confirm Password</label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Confirm your password" />
                </div>
                <div class="form-group mt-3">
                    <label for="Gender">Gender</label>
                    <asp:DropDownList ID="Gender" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Gender" Value="" />
                        <asp:ListItem Text="Male" Value="male" />
                        <asp:ListItem Text="Female" Value="female" />
                    </asp:DropDownList>
                </div>
                <div class="form-group mt-3">
                    <label for="DOB">Date of Birth</label>
                    <asp:TextBox ID="DOB" runat="server" CssClass="form-control" TextMode="Date" Placeholder="Enter your DOB" />
                </div>
                <div class="form-group mt-3">
                    <label for="Role">Role</label>
                    <asp:DropDownList ID="Role" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Customer" Value="customer" />
                        <asp:ListItem Text="Admin" Value="admin" />
                    </asp:DropDownList>
                </div>

                <!-- Error Message -->
                <div class="mt-3">
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="text-danger" Text="" Visible="false"></asp:Label>
                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary btn-block" Text="Register" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
