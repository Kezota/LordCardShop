<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="HandleTransaction.aspx.cs" Inherits="LordCardShop.Views.Admin.HandleTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Handle Transactions</h2>
        <hr />

        <div class="d-flex justify-content-end mb-3">
            <form method="get">
                <select name="statusFilter" class="form-select w-auto d-inline-block" onchange="this.form.submit()">
                    <option value="All" <%= Filter == "All" ? "selected" : "" %>>All</option>
                    <option value="Handled" <%= Filter == "Handled" ? "selected" : "" %>>Handled</option>
                    <option value="Unhandled" <%= Filter == "Unhandled" ? "selected" : "" %>>Unhandled</option>
                </select>
            </form>
        </div>

        <asp:Literal ID="LiteralTransactions" runat="server"></asp:Literal>
        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success mt-3 d-none" EnableViewState="false"></asp:Label>
    </div>
</asp:Content>
