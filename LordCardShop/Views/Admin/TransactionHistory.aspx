<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="LordCardShop.Views.Admin.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container mt-5">
        <h2>Transaction Detail</h2>
        <div class="card">
            <div class="card-header">
                <h5>Transaction ID: <asp:Label ID="lblTransactionID" runat="server"></asp:Label></h5>
            </div>
            <div class="card-body">
                <p>Status: <asp:Label ID="lblStatus" runat="server"></asp:Label></p>
                <p>Date: <asp:Label ID="lblTransactionDate" runat="server"></asp:Label></p>
                <h4>Items</h4>
                <ul id="transactionItemsList">
                    <!-- Simulated transaction items for this transaction -->
                    <li>Card ID: 101, Quantity: 1</li>
                    <li>Card ID: 102, Quantity: 2</li>
                </ul>
            </div>
        </div>
    </section>
</asp:Content>
