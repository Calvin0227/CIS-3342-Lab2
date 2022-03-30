<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project-2.aspx.cs" Inherits="Project_2.Project_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1368px;
            width: 1808px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" aria-checked="undefined">


        <br />
        <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="Show Report" />
        <br />
        <br />
        <br />


        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
        &nbsp;<br />
        <asp:Label ID="lblLastname" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPhoneNum" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>

        <br />
        <br />
        <asp:Label ID="lblRWAcctNum" runat="server" Text="Account Num"></asp:Label>
        <br />
        <asp:TextBox ID="txtRwAcct" runat="server"></asp:TextBox>

        <br />
        <br />
        <asp:CheckBox ID="CheckBox3" runat="server" /> In-Store Pick Up
        <asp:CheckBox ID="CheckBox4" runat="server" /> Curb-Side Delivery
        <asp:CheckBox ID="CheckBox5" runat="server" /> Delivery
        <br />
        <br />
        <asp:Label ID="lblinforerror" runat="server" style="color: red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnConfirmInfo" runat="server" OnClick="btnConfirmInfo_Click" Text="Show Menu" />
        <br />
        <br />

        <asp:GridView ID="Coffee" runat="server" AutoGenerateColumns="False" Height="286px" Width="993px" >
            <Columns>
                <asp:TemplateField HeaderText="Select Drink">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="BasePrice" DataFormatString ="{0:c}" HeaderText="Base Price" />
                <asp:TemplateField HeaderText="Drink Size">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value ="Small">Small</asp:ListItem>
                            <asp:ListItem Value ="Tall">Tall</asp:ListItem>
                            <asp:ListItem Value ="Grande">Grande</asp:ListItem>
                            <asp:ListItem Value ="Venti">Venti</asp:ListItem>
                            <asp:ListItem Value ="Trenta">Trenta</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hot or Ice">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="23px" Width="124px">
                            <asp:ListItem>Hot</asp:ListItem>
                            <asp:ListItem>Ice</asp:ListItem>
                        </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="How many you want">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>

        <br />
        <br />

        <br />
        <asp:GridView ID="Tea" runat="server" AutoGenerateColumns="False" Height="233px" style="margin-right: 3px" Width="995px">
            <Columns>
                <asp:TemplateField HeaderText="Select Drink">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Baseprice" DataFormatString ="{0:c}" HeaderText="Base Price" />
                <asp:TemplateField HeaderText="Drink Size">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value ="Small">Small</asp:ListItem>
                            <asp:ListItem Value ="Tall">Tall</asp:ListItem>
                            <asp:ListItem Value ="Grande">Grande</asp:ListItem>
                            <asp:ListItem Value ="Venti">Venti</asp:ListItem>
                            <asp:ListItem Value ="Trenta">Trenta</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hot or Ice">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                            <asp:ListItem>Hot</asp:ListItem>
                            <asp:ListItem>Ice</asp:ListItem>
                        </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="How many you want">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnOrder" runat="server" Height="31px" OnClick="btnOrder_Click" Text="Order !" Width="113px" />
        &nbsp;
        <br />
&nbsp;
        <br />
        <asp:Label ID="lblGVerror" runat="server" style="color: red"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="Receipt" runat="server" AutoGenerateColumns="False" Height="288px" Width="1222px" ShowFooter="true">
            <Columns>
                <asp:BoundField DataField="ProductTitle" HeaderText="Title"/>
                <asp:BoundField DataField="ProductDescription" HeaderText="Description"/>
                <asp:BoundField DataField="ProductSize" HeaderText="Size"/>
                <asp:BoundField DataField="ProductType" HeaderText="Type"/>
                <asp:BoundField DataField="ProductPrice" HeaderText="Price"/>
                <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity"/>
                <asp:BoundField DataField="ProductTotal" HeaderText="Total Cost"/>
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="Report" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />

    </form>

</body>
</html>
