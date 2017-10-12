<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ChallengePostalCalculator._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Postal Calculator</div>
        <p>
            &nbsp;Width:
            <asp:TextBox ID="txtWidth" runat="server" AutoPostBack="True" OnTextChanged="txtWidth_TextChanged"></asp:TextBox>
        </p>
        <p>
            Height:
            <asp:TextBox ID="txtHeight" runat="server" AutoPostBack="True" OnTextChanged="txtHeight_TextChanged"></asp:TextBox>
        </p>
        <p>
            Length:<asp:TextBox ID="txtLength" runat="server" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged" Height="16px" Width="125px"></asp:TextBox>
        </p>
        <p>
            <asp:RadioButton ID="radGround" runat="server" AutoPostBack="True" Text="Ground" Checked="True" GroupName="post" OnCheckedChanged="radGround_CheckedChanged" />
        </p>
        <p>
            <asp:RadioButton ID="radAir" runat="server" AutoPostBack="True" Text="Air" GroupName="post" OnCheckedChanged="radAir_CheckedChanged" />
        </p>
        <p>
            <asp:RadioButton ID="radNextDay" runat="server" AutoPostBack="True" Text="Next Day" GroupName="post" OnCheckedChanged="radNextDay_CheckedChanged" />
        </p>
        <p>
            <asp:Label ID="lblPostage" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
