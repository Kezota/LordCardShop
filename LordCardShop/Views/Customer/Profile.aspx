<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LordCardShop.Views.Customer.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container">
        <h2>Update Profile</h2>
        <asp:Label ID="lblError" runat="server" CssClass="alert d-none" EnableViewState="false" />

        <div class="row">
            <!-- Left Column: Profile Info -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtUsername" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Enabled="false" />
                </div>

                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="dob" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date" />
                </div>

                <div class="mb-3">
                    <label for="ddlGender" class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
                        <asp:ListItem Text="-- Select Gender --" Value="" />
                        <asp:ListItem Text="Male" Value="male" />
                        <asp:ListItem Text="Female" Value="female" />
                        <asp:ListItem Text="Other" Value="other" />
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Right Column: Change Password -->
            <div class="col-md-6 border-start">
                <div class="bg-light p-3 rounded">
                    <h5>Change Password (Optional)</h5>

                    <div class="mb-3">
                        <label for="txtOldPassword" class="form-label">Old Password</label>
                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>

                    <div class="mb-3">
                        <label for="txtNewPassword" class="form-label">New Password</label>
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>

                    <div class="mb-3">
                        <label for="txtConfirmPassword" class="form-label">Confirm New Password</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                </div>
            </div>
        </div>

        <div class="mt-3">
            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update Profile" OnClick="btnUpdate_Click" />
        </div>
    </section>
</asp:Content>
