<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scan_Detail.aspx.cs" Inherits="Scan_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>东莞出货条码扫描管理</title>
        <link href="css/css.css"  rel="Stylesheet" type="text/css"" />
    <link href="css/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 104px;
        }
    </style>
</head>
<body> 
<div style="width:280px; overflow:auto">
    <form id="form1" runat="server" border="0" background="../Main/images/nav04.gif" width="100%">
         <div id="detail" style=" border:2px #D2B48C solid; width:320px; 
        height:190px;position:absolute;
        ">
        <div style=" font-size:11px; font-weight:bold; text-align:center overflow: auto">
        <table><tr><td style=" font-size:smaller">包装明细</td><td><asp:TextBox ID="pack_no" 
                Font-Size="10px" runat="server" Width="73px" OnTextChanged="Pack_No_TextChanged" AutoPostBack="true"></asp:TextBox></td>
        <td class="style2"><asp:Label ID="msg" runat="server" Font-Size="10px" Text="无异常" ForeColor="Red"></asp:Label></td>
        <td align="right" colspan="2"><asp:Button  ID="dele_pack" runat="server"  
                Font-Size="10px" Text="返回" onclick="go_pack_Click" /></td>
                <td align="right" colspan="2">
                    <asp:Button  ID="Button1" runat="server"  
                Font-Size="10px" Text="TOExcel" onclick="Cmd_ToExcel_Click"  /></td>
                </tr></table>
        <table>
       
        <div style=" font-size:11px;text-align:center overflow: auto">
        <asp:GridView ID="TDBGrid1" runat="server" AllowPaging="False" AllowSorting="True"
            PageSize="10" Width="71%" OnRowDataBound="TDBGrid2_RowDataBound" Height="20px"
             PageIndex="1" OnPageIndexChanging="TDBGrid2_PageIndexChanging" DataKeyNames="d_list"
            AutoGenerateColumns="false" Font-Size="10px">
            <Columns>
            <%-- <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID ="checkflag" runat="server" Enabled="true" Font-Size="10px" /></ItemTemplate>
                        <HeaderStyle  Width="50px" />
                        <ItemStyle Width="32px" />
                    </asp:TemplateField>--%>
               <asp:TemplateField HeaderText="操作" HeaderStyle-Font-Size="10px" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td align="center" style="font-size:smaller">
                                        <asp:HyperLink ID="delete_data" runat="server" onclick="return confirm('确认删除')"  NavigateUrl='<%# "Scan_Detail.aspx?upd_mode=delete&d_list="+Eval("d_list")+"&inv_no="+Eval("inv_no") %>'>删除</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
      
                <asp:BoundField DataField="cnt_no" HeaderText="箱号"  ItemStyle-Font-Size="10px"/>            
                <asp:BoundField DataField="pack_no" HeaderText="包装单号"  ItemStyle-Font-Size="10px"/>
                <asp:BoundField DataField="cust_name" HeaderText="客户名称" ItemStyle-Font-Size="10px" ItemStyle-Wrap="true" >
                <ItemStyle Width="80px" /> 
                </asp:BoundField >
                <asp:BoundField DataField="inv_amt" HeaderText="尺数" ItemStyle-Font-Size="10px" />
                <asp:BoundField DataField="zhang_amt" HeaderText="张数" ItemStyle-Font-Size="10px"/>
                 <asp:BoundField DataField="inv_no"  Visible="false"/>
                <asp:BoundField DataField="d_list"  Visible="false"/>
                
            </Columns>
            <PagerSettings Visible="False" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle Font-Size="12px" Height="20px" />
            <EmptyDataTemplate>
                <table border="0" cellpadding="0" width="280px">
                    <tr>
                        <td align="center" style="border-right: black 1px;font-size:smaller; border-top: back 1px; border-left: black 1px;
                            border-bottom: black 1px; background-color: White;">
                            该列表中暂时无数据！
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            </asp:GridView>
         <%-- <table width="280px" border="0" align="center">
            <tr>
<%--                <td  style="font-size:smaller" class="style1">
                    共<asp:Label ID="pagecount"  style="font-size:smaller" runat="server"></asp:Label><asp:Label
                        ID="totalcount" runat="server"  style="font-size:smaller"></asp:Label>
                    |<asp:Label ID="current_page"  style="font-size:smaller" runat="server"></asp:Label>
                </td>
                <td align="left"  style="font-size:smaller">
                    <asp:LinkButton runat="server" ID="home_page" OnClick="paging_Click">[home</asp:LinkButton>
                    |
                </td>
                <td align="left"  style="font-size:smaller">
                    <asp:LinkButton runat="server" ID="page_up" OnClick="paging_Click">up</asp:LinkButton>
                    |
                </td>
                <td align="left" style="font-size:smaller">
                    <asp:LinkButton runat="server" ID="page_down" OnClick="paging_Click">next</asp:LinkButton>
                    |
                </td>
                <td align="right"  style="font-size:smaller">
                    <asp:LinkButton runat="server" ID="last_page" OnClick="paging_Click">last</asp:LinkButton>
                    ]跳转
                </td>
                <td width="1.2%" align="left">
                    <asp:TextBox ID="key_pagindex" runat="server" Width="26px"></asp:TextBox>
                </td>
                <td width="8%" align="left">
                    <asp:ImageButton ImageUrl="~/Main/images/button08.gif" ID="go_index" runat="server"
                        OnClick="go_index_Click" />
                </td>
            </tr>
        </table>--%>
            </div></table>
             </div>
    </div>
    </form>
    </div>
</body>
</html>
