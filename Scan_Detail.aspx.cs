using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Scan_Detail : System.Web.UI.Page
{
    private BusinessRuler.Erp_Deve.br_Deliv_Car_Scan Current_Data = new BusinessRuler.Erp_Deve.br_Deliv_Car_Scan();

    string _upd_mode = "";
    string _inv_no = "";
    string _pack_no = "";
    int _d_list = 0;
    //总页数
    int _pagecount = 0;
    //当前页
    int _pageindex = 0;
    //每页显示的数量
    int _pagesize = 10;
    //string _upd_mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        pack_no.Focus();

        _inv_no = Request.QueryString["inv_no"];
        _upd_mode = Request.QueryString["upd_mode"];
        _d_list =Convert.ToInt32( Request.QueryString["d_list"]);
        _pack_no = (Request.QueryString["pack_no"]);
        if (_upd_mode == "delete")
        {

            Cmd_Delete(_d_list);

        }
        if (!Page.IsPostBack)
        {


            Get_Data();
        }
    }


    /// <summary>
    /// 清空控件文本
    /// </summary>
    public void Text_Clear()
    {

        pack_no.Text = "";
        msg.Text = "";

    }

    private void Get_Data()
    {
        Get_Binding();

        Current_Data.Get_Scan_Detail(_inv_no, _pack_no);
        TDBGrid1.PageIndex = _pageindex;
        TDBGrid1.PageSize = _pagesize;

        TDBGrid1.DataSource = Current_Data.Base_Pack_List;
        TDBGrid1.DataBind();

        //totalcount.Text = Current_Data.Base_Data_List.Count.ToString();
        _pagecount = TDBGrid1.PageCount;
        //current_page.Text = (TDBGrid1.PageIndex + 1).ToString();
        //pagecount.Text = _pagecount + "";

    }

    #region -------分頁-------------
    protected void paging_Click(object sender, EventArgs e)
    {
        _pagecount = TDBGrid1.PageCount;
        _pageindex = TDBGrid1.PageIndex;
        _pagesize = TDBGrid1.PageSize;

        //设置按扭名字执行按扭事件上
        string arg = ((LinkButton)sender).ID.ToString().ToLower();

        switch (arg)
        {
            case "home_page":
                _pageindex = 0;
                break;
            case "page_up":
                if (_pageindex > 0)
                {
                    _pageindex -= 1;
                }
                break;
            case "page_down":
                if (_pageindex < _pagecount - 1)
                {
                    _pageindex += 1;
                }
                break;
            case "last_page":
                if (_pagecount > 1)
                {
                    _pageindex = _pagecount - 1;
                }
                break;
            default:
                _pageindex = 0;
                break;
        }

        Get_Data();
    }
    protected void TDBGrid1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        TDBGrid1.PageIndex = e.NewSelectedIndex;

    }
    protected void TDBGrid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TDBGrid1.PageIndex = e.NewPageIndex;
        Get_Data();
    }


    protected void go_index_Click(object sender, ImageClickEventArgs e)
    {
        //if (Convert.ToInt32(key_pagindex.Text.Trim()) < 1)
        //{
        //    _pageindex = 0;
        //    key_pagindex.Text = "1";

        //}


        //else if (Convert.ToInt32(key_pagindex.Text.Trim()) > TDBGrid1.PageCount)
        //{
        //    _pageindex = TDBGrid1.PageCount;
        //    key_pagindex.Text = TDBGrid1.PageCount.ToString();
        //}

        //else
        //{
        //    _pageindex = Convert.ToInt32(key_pagindex.Text.Trim()) - 1;
        //}
        //Get_Data();
    }
    #endregion

    /// <summary>
    /// 绑定数据;location.href='Scan_add.aspx'
    /// </summary>
    protected void Get_Binding()
    {

        Current_Data.Base_Data.pack_no = pack_no.Text.Trim();
    }
    protected void TDBGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D4E2EF'");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


        }

        //for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
        //{
        //    e.Row.Cells[i].Wrap = false;
        //}
    }
    //删除

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='Scan_add.aspx'</script>");
    }

    // 获取扫描后的数据
    protected void Pack_No_TextChanged(object sender, EventArgs e)
    {
        //获取采购数量
        string no = pack_no.Text.Trim();
        if (no != "")
        {
            Current_Data.Get_Pack_Data(no);
            if (Current_Data.Base_Data.deliv_no != "")
            {
                //Get_Data();
                Response.Write("<script>location.href='Scan_Detail.aspx?inv_no="+_inv_no+"&pack_no="+pack_no.Text.Trim()+"'</script>");
            }
            else
            {
                msg.Text = "当前包装单号不存在!";
                //Response.Write("<script>alert('当前包装单号不存在!')</script>");<%# "Scan_Detail.aspx?upd_mode=delete&d_list="+Eval("d_list")+"&inv_no="+Eval("inv_no") %>
            }
        }
    }

    protected void TDBGrid2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void Cmd_Delete(int _d_list)
    {
        if (_d_list > 0)
        {
            Current_Data.Base_Data.d_list = _d_list;
            if (Current_Data.Delete_Data() == true)
            {
                msg.Text = "删除成功!";
                Get_Data();
            }

        }
    }
    protected void go_pack_Click(object sender, EventArgs e)
    {

        Response.Write("<script>location.href='Deliv_Scan_Label.aspx'</script>");
    }

    protected void Cmd_ToExcel_Click(object sender, EventArgs e)
    {
        int i = 0;
        int j = 1;

        if (this.TDBGrid1.Rows.Count == 0)
        {
            Response.Write("<script>alert('没有查找到数据,无法导出！')</script>");
        }
        else
        {
            ///隐藏部分列，不予导出
            this.TDBGrid1.Columns[0].Visible = false;
            //this.Gridview1.Columns[1].Visible = false;

            //this.Gridview1.Columns[Gridview1.Columns.Count - 1].Visible = false;
            //this.Gridview1.Columns[Gridview1.Columns.Count - 2].Visible = false;
            //this.Gridview1.Columns[2].Visible = true;
            //this.Gridview1.Columns[4].Visible = true;
            //this.Gridview1.Columns[5].Visible = false;


        }
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");
        str = str + ".xls";


        TDBGrid1.AllowPaging = false;



        GridViewToExcel(TDBGrid1, "application/ms-excel", str);

        this.TDBGrid1.Columns[0].Visible = true;

    }

    public static void GridViewToExcel(Control ctrl, string FileType, string FileName)
    {
        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;//注意编码
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
        HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
        ctrl.Page.EnableViewState = false;
        System.IO.StringWriter tw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        ctrl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }
    /// <summary>
    /// ReLoad this VerifyRenderingInServerForm is neccessary
    /// </summary>
    /// <param name="control"></param>
    /// 


    public override void VerifyRenderingInServerForm(Control control)
    {


    }

}