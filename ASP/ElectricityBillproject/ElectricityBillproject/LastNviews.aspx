<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LastNviews.aspx.cs" Inherits="ElectricityBillproject.LastNviews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Last N Bills</title>
</head>
<body>
    <form id="form1" runat="server">
               
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Please fix the following:"
                ShowMessageBox="false"
                ShowSummary="true"
                ValidationGroup="ViewBillsGroup"
                BackColor="Blue"
                ForeColor="Red" />
                <div>
 
               Enter number of bills:&nbsp;&nbsp;&nbsp;
               <asp:TextBox ID="txtCount" runat="server" />
               <br />
               <asp:RequiredFieldValidator ID="rfvCount" runat="server"
                ControlToValidate="txtCount"
                ErrorMessage="Enter number of bills."
                Display="Dynamic"
                ValidationGroup="ViewBillsGroup" />
 
      
               <asp:CustomValidator ID="cvCount" runat="server"
               ControlToValidate="txtCount"
               ErrorMessage="Enter a value greater than zero."
               Display="Dynamic"
               ValidationGroup="ViewBillsGroup"
               OnServerValidate="cvCount_ServerValidate" />
              <br />
              <br />
 
     
              <asp:Button ID="btnView" runat="server"
              Text="View Bills"
              OnClick="btnView_Click"
              CausesValidation="true"
               Style="background-color:lightskyblue"
              ValidationGroup="ViewBillsGroup" />
             <br />
             <br />
 
     
             <asp:Label ID="lblMessage" runat="server"></asp:Label>
             <br />
 
     
             <asp:GridView ID="gvBills" runat="server"
              AutoGenerateColumns="False"
              Visible="False"
              CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
 
               <Columns>
               <asp:BoundField HeaderText="Consumer Number" DataField="ConsumerNumber" />
               <asp:BoundField HeaderText="Consumer Name" DataField="ConsumerName" />
               <asp:BoundField HeaderText="Units Consumed" DataField="UnitsConsumed" />
               <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString="{0:F2}" />
               </Columns>
 
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
              <RowStyle BackColor="White" ForeColor="#003399" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
              </asp:GridView>
</div>
</form>
 
  
<script type="text/javascript">
      function validateOnBlur(group) {
          if (typeof (Page_ClientValidate) === "function") {
              Page_ClientValidate(group);
          }
      }
</script>
</body>
</html>
       

      
