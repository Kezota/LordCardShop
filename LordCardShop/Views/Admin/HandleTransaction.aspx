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

        <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" OnRowCommand="gvTransactions_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <!-- Tombol Handle akan muncul hanya jika status transaksi 'Unhandled' -->
                        <asp:Button ID="btnHandle" runat="server" CommandName="Handle" CommandArgument='<%# Eval("TransactionID") %>' Text="Handle" CssClass="btn btn-sm btn-success" Visible='<%# Eval("Status").ToString() == "Unhandled" %>' />
                        <!-- Tombol Handled akan muncul hanya jika status transaksi 'Handled' -->
                        <asp:Button ID="btnHandled" runat="server" Text="Handled" CssClass="btn btn-sm btn-secondary" Enabled="False" Visible='<%# Eval("Status").ToString() == "Handled" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success mt-3 d-none" EnableViewState="false"></asp:Label>
    </div>
</asp:Content>
