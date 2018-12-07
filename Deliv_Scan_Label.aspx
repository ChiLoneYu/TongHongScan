<%--<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Deliv_Pay_Query.aspx.vb"
    Inherits="Erp_Sale_Deliv_Pay_Query" %>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deliv_Scan_Label.aspx.cs"
    Inherits="Erp_Deve_Deliv_Scan_Label" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="Calder/WdatePicker.js" type="text/javascript"></script>

    <link href="css/css.css" rel="Stylesheet" type="text/css"" />
    <link href="css/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 65px;
        }
        .style3
        {
            height: 44px;
            width: 50px;
        }
        .style5
        {
            height: 44px;
            width: 149px;
        }
        .style16
        {
            /*height: 20px; font-style: normal; font-variant: normal; font-weight: bold; font-size: 16px;letter-spacing: 2px; text-align: middle; border-top: 2px solid #ff7300; padding-left: 10px; background-color: #f0f0f0;text-align:center;*/
            background: #6795B4;
            text-align: center;
            color: #FFFFFF;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            height: 22px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 16px;
            letter-spacing: 2px;
            padding-left: 10px;
            width: 876px;
            padding-right: 5px;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .style24
        {
            width: 297px;
            height: 20px;
        }
        .style25
        {
            height: 20px;
            width: 54px;
        }
        .style28
        {
            height: 20px;
            width: 60px;
        }
        .style30
        {
            width: 60px;
            height: 22px;
        }
        .style31
        {
            height: 22px;
            width: 54px;
        }
        .style34
        {
            height: 22px;
            width: 297px;
        }
        .style40
        {
            height: 21px;
            width: 54px;
        }
        .style43
        {
            width: 60px;
            height: 21px;
        }
        .style45
        {
            height: 21px;
            width: 297px;
        }
        .style46
        {
            height: 11px;
            width: 54px;
        }
        .style49
        {
            width: 60px;
            height: 11px;
        }
        .style51
        {
            height: 11px;
            width: 297px;
        }
        .style52
        {
            height: 21px;
            width: 56px;
        }
        .style53
        {
            height: 11px;
            width: 56px;
        }
        .style54
        {
            height: 22px;
            width: 56px;
        }
        .style55
        {
            height: 20px;
            width: 56px;
        }
        .style56
        {
            width: 54px;
        }
        .style57
        {
            height: 44px;
            width: 34px;
        }
    </style>
</head>
<body style="overflow: auto">
    <form id="form1" runat="server">
    <div style="width: 100%; height: 100%; overflow:auto">
        <table border="0" background="../Main/images/nav04.gif">
            <tr>
                <td class="style16" style="font-size: smaller" align="center">
                    派车明细查询:
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="Cmd_Query" Width="45" runat="server" Text="查询" OnClick="Cmd_Query_Click" />
                    <asp:Button ID="Cmd_Clear" Width="45" runat="server" Text="清空" OnClick="Cmd_Clear_Click" />
                    <asp:Button ID="Cmd_ToExcel" Width="65" runat="server" Text="TOEXCEL" OnClick="Cmd_ToExcel_Click" />
                    <asp:Button ID="Cmd_Print" Width="45" runat="server" Text="打印" OnClick="Cmd_Print_Click" />
                </td>
            </tr>
        </table>
        <table border="1" style="font-size: 10px">
            <tr>
                <td class="style40">
                    客户代号:
                </td>
                <td class="style40">
                    <asp:TextBox ID="cust_no" runat="server" Width="74px"></asp:TextBox>
                </td>
                <td class="style52">
                    客户名称:
                </td>
                <td class="style43">
                    <asp:TextBox ID="cust_name" runat="server" Width="63px"></asp:TextBox>
                </td>
                <td class="style40">
                    订单日期:
                </td>
                <td class="style45">
                    从
                    <asp:CheckBox ID="CheckBox1" Checked="false" runat="server" />
                    <asp:TextBox ID="order_sdate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                    至
                    <asp:TextBox ID="order_edate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    订单单号:
                </td>
                <td class="style46">
                    <asp:TextBox ID="order_no" runat="server" Width="74px"></asp:TextBox>
                </td>
                <td class="style53">
                    客户订单:
                </td>
                <td class="style49">
                    <asp:TextBox ID="cust_order" runat="server" Width="63px"></asp:TextBox>
                </td>
                <td class="style46">
                    出货日期:
                </td>
                <td class="style51">
                    从
                    <asp:CheckBox ID="CheckBox3" Checked="false" runat="server" />
                    <asp:TextBox ID="deliv_sdate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                    至
                    <asp:TextBox ID="deliv_edate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style31">
                    出货单号:
                </td>
                <td class="style31">
                    <asp:TextBox ID="deliv_no" runat="server" Width="75px"></asp:TextBox>
                </td>
                <td class="style54">
                    助理编号:
                </td>
                <td class="style30">
                    <asp:TextBox ID="mag_id" runat="server" Width="63px"></asp:TextBox>
                </td>
                <td class="style31">
                    派车日期:
                </td>
                <td class="style34">
                    从
                    <asp:CheckBox ID="CheckBox5" Checked="true" runat="server" />
                    <asp:TextBox ID="fdeliv_sdate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                    至
                    <asp:TextBox ID="fdeliv_edate" runat="server" Width="79px" OnClick="WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    派车单号:
                </td>
                <td class="style25">
                    <asp:TextBox ID="plancar_inv_no" runat="server" Width="74px"></asp:TextBox>
                </td>
                <td class="style55">
                    车辆牌照:
                </td>
                <td class="style28">
                    <asp:TextBox ID="car_id" runat="server" Width="63px"></asp:TextBox>
                    <td class="style25">
                        车辆编号:
                    </td>
                    <td class="style24" colspan="5">
                        <asp:TextBox ID="car_no" runat="server" Width="73px"></asp:TextBox>
                        <asp:RadioButton ID="c_select" runat="server" GroupName="Radio1" Text="全部" />
                        <asp:RadioButton ID="c_select1" runat="server" GroupName="Radio1" Text="已派车" />
                        <asp:RadioButton ID="c_select2" runat="server" GroupName="Radio1" Text="未派车" />
                        <asp:CheckBox ID="check_car" Text="含过滤" runat="server" />
                    </td>
        </table>
        <div id="Div1" runat="server" style="overflow: auto">
            <asp:GridView ID="TDBGrid1" runat="server" AllowPaging="false" AllowSorting="True"
                PageSize="15" OnRowDataBound="TDBGrid1_RowDataBound" Height=100%
                Style="margin-bottom: 0px" PageIndex="1" OnPageIndexChanging="TDBGrid1_PageIndexChanging"
                AutoGenerateColumns="false" HeaderStyle-Wrap="false" Font-Size="10px">
                <Columns>
                    <%-- <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID ="checkflag" runat="server" Enabled="true" /></ItemTemplate>
                        <HeaderStyle  Width="50px" />
                        <ItemStyle Width="32px" />
                    </asp:TemplateField>--%>
                    <%-- <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %></ItemTemplate>
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="32px" />
                </asp:TemplateField>--%>
                    <%--<asp:CheckBoxField HeaderText="选择" DataField="flag" ItemStyle-HorizontalAlign="Center"/>--%>
                    <asp:TemplateField HeaderText="派车单号" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="Scan_add.aspx?inv_no=<%# DataBinder.Eval(Container.DataItem,"inv_no")%>&plan_date=<%# DataBinder.Eval(Container.DataItem,"plan_date")%>">
                                <%#DataBinder.Eval(Container.DataItem, "inv_no")%></a>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="包装明细" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="Scan_Detail.aspx?inv_no=<%# DataBinder.Eval(Container.DataItem,"inv_no")%>">
                                查看明细</a>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="送货日期" ItemStyle-HorizontalAlign="Center" DataField="plan_date">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <%--                <asp:BoundField HeaderText="车辆编号" ItemStyle-HorizontalAlign="Center" DataField="car_no">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                    <asp:BoundField HeaderText="车辆牌照" ItemStyle-HorizontalAlign="Center" DataField="car_id">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <%--   <asp:BoundField HeaderText="客户名称" ItemStyle-HorizontalAlign="Center" DataField="cust_name">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="客户编号" ItemStyle-HorizontalAlign="Center" DataField="cust_no">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                    <%--  <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:HyperLink ID="edit_data" runat="server" NavigateUrl='<%# "Order_zheKou.aspx?upd_mode=edit_data&d_list="+Eval("d_list") %>'>修改</asp:HyperLink>
                                    </td>
                                    <td align="center">
                                        <asp:HyperLink ID="delete_data" runat="server" onclick="return confirm('确认删除')" NavigateUrl='<%# "Order_Zhekoulist.aspx?upd_mode=dele_data&d_list="+Eval("d_list") %>'>删除</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--        <asp:BoundField DataField="deliv_type" HeaderText="出货类型" />
                <asp:BoundField DataField="deliv_no" HeaderText="出货单号" />
                <asp:BoundField DataField="deliv_date" HeaderText="出货日期" />--%>
                    <asp:BoundField DataField="car_driver" HeaderText="司机" />
                    <asp:BoundField DataField="send_name" HeaderText="送货员1" />
                    <asp:BoundField DataField="send_name1" HeaderText="送货员2" />
                    <%-- <asp:BoundField DataField="order_no" HeaderText="订单号" />
                <asp:BoundField DataField="cust_order" HeaderText="客户订单" />
                <asp:BoundField DataField="mtr_name" HeaderText="产品名称" />
                <asp:BoundField DataField="mtr_dim" HeaderText="规格" />--%>
                    <asp:BoundField DataField="deliv_amt" HeaderText="出货数量" />
                    <asp:BoundField DataField="kun_amt" HeaderText="捆数" />
                    <asp:BoundField DataField="zhang_amt" HeaderText="张数" />
                     <asp:BoundField DataField="owe_amt" HeaderText="欠数" />
                </Columns>
                <PagerSettings Visible="False" />
                <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle Font-Size="12px" Height="20px" />
                <EmptyDataTemplate>
                    <table border="0" cellpadding="0" width="100%">
                        <tr>
                            <td align="center" style="border-right: black 1px; border-top: back 1px; border-left: black 1px;
                                border-bottom: black 1px; background-color: White;">
                                该列表中暂时无数据！
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
   <%--         <table border="0" align="left" style="width: 37%">
                <tr>
                    <td class="style5">
                        共<asp:Label ID="pagecount" CssClass="right-font09 " runat="server"></asp:Label>页<asp:Label
                            ID="totalcount" runat="server" CssClass="right-font09 "></asp:Label>
                        条记录 | 第<asp:Label ID="current_page" CssClass="right-font09 " runat="server"></asp:Label>页
                    </td>
                    <td align="left" class="style3">
                        <asp:LinkButton runat="server" ID="home_page" OnClick="paging_Click">[首页</asp:LinkButton>
                        |
                    </td>
                    <td align="left" class="style2">
                        <asp:LinkButton runat="server" ID="page_up" OnClick="paging_Click">上一页</asp:LinkButton>
                        |
                    </td>
                    <td align="left" class="style56">
                        <asp:LinkButton runat="server" ID="page_down" OnClick="paging_Click">下一页</asp:LinkButton>
                        |
                    </td>
                    <td align="left" class="style57">
                        <asp:LinkButton runat="server" ID="last_page" OnClick="paging_Click">末页</asp:LinkButton>
                        ]
                    </td>
                    <td  align="left">
                        <asp:TextBox ID="key_pagindex" runat="server" Width="26px"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:ImageButton ImageUrl="~/Main/images/button08.gif" ID="go_index" runat="server"
                            OnClick="go_index_Click" Width="16px" />
                    </td>
                </tr>
            </table>--%>
        </div>
    </div>
    </form>
</body>
</html>
