<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingHistory.aspx.cs" Inherits="TravelExperts_ASP.BookingHistory" MasterPageFile="TESite.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="jumbotron">
            <br />
       <div class="row">
           <div class="col-lg-8 col-md-12">
       <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Booking History</h1>
            <asp:GridView ID="gvbooking" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="Bookings" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="BookingId" CssClass="gvBookingPadding">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="BookingId" HeaderText="BookingId" SortExpression="BookingId" />
                    <asp:BoundField DataField="BookingNo" HeaderText="BookingNo" SortExpression="BookingNo" />
                    <asp:BoundField DataField="BookingDate" HeaderText="BookingDate" SortExpression="BookingDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" />
                    <asp:BoundField DataField="TripType" HeaderText="TripType" SortExpression="TripType" />
                    <asp:BoundField DataField="TravelerCount" HeaderText="TravelerCount" SortExpression="TravelerCount" />
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:c}" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#20c997" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:ObjectDataSource ID="Bookings" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetBookings" TypeName="TravelExperts_ASP.App_Code.BookingDB">
                <SelectParameters>
                    <asp:SessionParameter Name="CustomerId" SessionField="CustomerId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
       <br />
               </div>
           <div class="col-lg-4 col-md-12">
           <h2>Details:</h2>
       <asp:DetailsView ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" ID="dvBookingDetails" runat="server" AllowPaging="True" AutoGenerateRows="False" AutoGenerateColumns="false" DataSourceID="ObjectDataSourc_BookingDetails" Height="50px" Width="355px" BorderStyle="None" CellPadding="4" GridLines="Horizontal">
           <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
           <Fields>
               <asp:BoundField DataField="BookingId" HeaderText="BookingId" SortExpression="BookingId" >
               <HeaderStyle BackColor="#333333" ForeColor="White" />
               </asp:BoundField>
               <asp:BoundField DataField="ItineraryNo" HeaderText="ItineraryNo" SortExpression="ItineraryNo" >
               </asp:BoundField>
               <asp:BoundField DataField="TripStart" HeaderText="TripStart" SortExpression="TripStart" DataFormatString="{0:d}" />
               <asp:BoundField DataField="TripEnd" HeaderText="TripEnd" SortExpression="TripEnd" DataFormatString="{0:d}" />
               <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" DataFormatString="{0:d}" />
               <asp:BoundField DataField="RegionName" HeaderText="RegionName" SortExpression="RegionName" />
               <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
               <asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="Destination" />
               <asp:BoundField DataField="ClassName" HeaderText="ClassName" SortExpression="ClassName" />
               <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
               <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
               <asp:BoundField DataField="ServicePrice" HeaderText="ServicePrice" SortExpression="ServicePrice" DataFormatString="{0:c}" />
               <asp:BoundField DataField="PackagePrice" HeaderText="PackagePrice" SortExpression="PackagePrice" DataFormatString="{0:c}" />
               <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:c}" />
           </Fields> 
           <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
           <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
       </asp:DetailsView> 
       <asp:ObjectDataSource ID="ObjectDataSourc_BookingDetails" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetBookingDetails" TypeName="TravelExperts_ASP.App_Code.BookingDetailDB">
           <SelectParameters>
               <asp:ControlParameter ControlID="gvbooking" Name="BookingId" PropertyName="SelectedValue" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>
               </div>
               </div>
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
    </div> 
</asp:Content>

