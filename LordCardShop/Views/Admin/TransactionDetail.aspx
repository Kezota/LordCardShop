<%@ Page Title="Transaction Detail" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="LordCardShop.Views.Admin.TransactionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Transaction Detail</h2>
        <hr />

        <!-- Menampilkan informasi transaksi -->
        <div class="mb-4">
            <h4>Transaction Overview</h4>
            <table class="table table-bordered">
                <tr>
                    <th>Transaction ID</th>
                    <td><asp:Label ID="lblTransactionID" runat="server" CssClass="form-control" ReadOnly="True" /></td>
                </tr>
                <tr>
                    <th>Customer ID</th>
                    <td><asp:Label ID="lblCustomerID" runat="server" CssClass="form-control" ReadOnly="True" /></td>
                </tr>
                <tr>
                    <th>Status</th>
                    <td><asp:Label ID="lblStatus" runat="server" CssClass="form-control" ReadOnly="True" /></td>
                </tr>
            </table>
        </div>

        <!-- Menampilkan detail transaksi yang terkait dengan TransactionID -->
        <h4>Transaction Details</h4>
        <asp:GridView ID="gvTransactionDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Detail ID" SortExpression="TransactionDetailID" />
                <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>

        <div class="d-flex justify-content-end mt-3">
            <!-- Tombol kembali ke halaman ViewTransactions -->
            <asp:Button ID="btnBack" runat="server" Text="Back to View Transactions" CssClass="btn btn-sm btn-primary" OnClick="btnBack_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mt-3 d-none" EnableViewState="false"></asp:Label>
    </div>
</asp:Content>
