<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scan_add.aspx.cs" Inherits="Scan_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>东莞出货条码扫描管理</title>
    <bgsound loop="false" autostart="false" id="bgss">  
<script language="javascript" type="text/javascript">
    function Select(url) {
        try {

            //            document.all.bgss.src = url;
            //            bgss.play();
        }
        catch (e) {

        }
    }  
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 320px; overflow: auto">
        <div id="add" style="border: 2px #D2B48C solid; width: 320px; height: 190px; position: absolute;
            background-color: ThreeDLighShadow;">
            <div style="font-size: 11px; font-weight: bold; text-align: center">
                <table style="width: 317px; height: 8px">
                    <tr>
                        <td>
                            东莞出货条码扫描管理
                        </td>
                        <td align="right">
                            <asp:Button ID="back" runat="server" Text="返回" Font-Size="12px" OnClick="go_pack_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="total" Text="scrpt" TextMode="MultiLine" Wrap="true"
                        ReadOnly="true" Font-Size="10px" BorderStyle="None" Height="48px" Width="300px"></asp:TextBox>
                </td>
            </tr>

            <table style="width: 300px; font-size: 12px; font-size: 12px; margin-top: 0px;" border="0">
                <tr>
                    <td>
                        派车单号:
                    </td>
                    <td>
                        <asp:TextBox ID="plancar_inv_no" Enabled="false" runat="server" Font-Size="10px"
                            Width="70px"></asp:TextBox>
                    </td>
                    <td width="52px">
                        派车日期:
                    </td>
                    <td>
                        <asp:TextBox ID="plan_date" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        包装单号:
                    </td>
                    <td>
                        <asp:TextBox ID="pack_no" AutoPostBack="true" OnTextChanged="Pack_No_TextChanged"
                            runat="server" Font-Size="10px" Width="70px"></asp:TextBox>
                    </td>
                    <td>
                        包装数量:
                    </td>
                    <td>
                        <asp:TextBox ID="mtr_amt" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        客户名称:
                    </td>
                    <td>
                        <asp:TextBox ID="cust_name" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox>
                    </td>
                    <td>
                        制令单号:
                    </td>
                    <td>
                        <asp:TextBox ID="deliv_no" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                            <tr>
                <td>
                    <asp:Label ID="msg" runat="server" Text="无异常" Font-Size="12px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
                <%--          <tr>
                    <td>订单单号:</td>
                    <td><asp:TextBox ID="order_no" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox></td>
                    <td>客户订单:</td>
                    <td><asp:TextBox ID="cust_order" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox></td>
                </tr>--%>
                <%--              <tr>
                    <td>产品名称:</td>
                    <td><asp:TextBox ID="mtr_name" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox></td>
                    <td>产品规格:</td>
                    <td><asp:TextBox ID="mtr_dim" Enabled="false" runat="server" Font-Size="10px" Width="70px"></asp:TextBox></td>
                </tr>--%>
                <%-- <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="cmd_ok" runat="server" Text="确定" OnClick="Button2_Click" TabIndex="1"
                            Height="23px" />
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="Button6" runat="server" Text="取消" OnClick="Button6_Click" Height="22px" />
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" Height="25px" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
