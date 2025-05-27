<%@ Page Title="Transaction Report" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="LordCardShop.Views.Admin.TransactionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Transactions Report</h2>
        <hr />
        <asp:Literal ID="LiteralReport" runat="server"></asp:Literal>
        <div class="alert alert-info mt-4" role="alert">
            <strong>Grand Total Income:</strong> <%= GrandTotal %>
        </div>
    </div>
</asp:Content>
