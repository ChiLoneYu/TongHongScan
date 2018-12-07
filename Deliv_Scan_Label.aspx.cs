using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using Microsoft.Win32;
public partial class Erp_Deve_Deliv_Scan_Label : System.Web.UI.Page
{
    //用户 B层
    private BusinessRuler.Erp_Deve.br_Deliv_Car_Scan _Current_Data = new BusinessRuler.Erp_Deve.br_Deliv_Car_Scan();

    //总页数
    int _pagecount = 0;
    //当前页
    int _pageindex = 0;
    //每页显示的数量
    int _pagesize = 10;


    protected void Page_Load(object sender, EventArgs e)
    {
        //


        if (!IsPostBack)
        {
            //Response.Write("<script>alert('getdatestart!')</script>");
            order_sdate.Text = DateTime.Today.ToShortDateString();
            order_edate.Text = DateTime.Today.ToShortDateString();
            deliv_sdate.Text = DateTime.Today.ToShortDateString();
            deliv_edate.Text = DateTime.Today.ToShortDateString();
            fdeliv_sdate.Text = DateTime.Today.ToShortDateString();
            fdeliv_edate.Text = DateTime.Today.AddDays(1).ToShortDateString();


            

            Get_Data();
            //Response.Write("<script>alert('getdataover!')</script>");
        }


        
    }



    private void Get_Data()
    {
        Set_Binding();

        _Current_Data.Get_Data_List();
        TDBGrid1.PageIndex = _pageindex;
        TDBGrid1.PageSize = _pagesize;

        TDBGrid1.DataSource = _Current_Data.Base_Data_List;
        TDBGrid1.DataBind();

        //totalcount.Text = _Current_Data.Base_Data_List.Count.ToString();
        //_pagecount = TDBGrid1.PageCount;
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
                _pageindex = _pagecount - 1;
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
    //    if (Convert.ToInt32(key_pagindex.Text.Trim()) < 1)
    //    {
    //        _pageindex = 0;
    //        key_pagindex.Text = "1";

    //    }


    //    else if (Convert.ToInt32(key_pagindex.Text.Trim()) > TDBGrid1.PageCount)
    //    {
    //        _pageindex = TDBGrid1.PageCount;
    //        key_pagindex.Text = TDBGrid1.PageCount.ToString();
    //    }

    //    else
    //    {
    //        _pageindex = Convert.ToInt32(key_pagindex.Text.Trim()) - 1;
    //    }
    //    Get_Data();
    }
    #endregion
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
            //this.Gridview1.Columns[0].Visible = false;
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

  
    protected void Cmd_Print_Click(object sender, EventArgs e)
    {

    }
    protected void TDBGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D4E2EF'");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


        }

        for (int i = 0; i <= e.Row.Cells.Count-1; i++)
        {
            e.Row.Cells[i].Wrap = false;
        }
    }

    private void Set_Binding()
    {
        _Current_Data.Condition.pc_name = CommonMoulde.PcInfo.getpcinfo.client_pc_name();
        _Current_Data.Condition.order_status = CheckBox1.Checked;
        _Current_Data.Condition.deliv_status = CheckBox3.Checked;
         _Current_Data.Condition.fdeliv_status = CheckBox5.Checked;

        _Current_Data.Condition.cust_name = cust_name.Text.Trim();
        _Current_Data.Condition.start_inv_date = Convert.ToDateTime(order_sdate.Text.Trim());
        //_Current_Data.Condition.order_status = CheckBox1.Checked;
        _Current_Data.Condition.order_sdate = Convert.ToDateTime(order_sdate.Text.Trim());
        _Current_Data.Condition.order_edate = Convert.ToDateTime(order_edate.Text.Trim());
        //_Current_Data.Condition.deliv_status = CheckBox3.Checked;
        _Current_Data.Condition.deliv_sdate = Convert.ToDateTime(deliv_sdate.Text.Trim());
        _Current_Data.Condition.deliv_edate = Convert.ToDateTime(deliv_edate.Text.Trim());
        //_Current_Data.Condition.fdeliv_status = CheckBox3.Checked;
        _Current_Data.Condition.fdeliv_sdate = Convert.ToDateTime(fdeliv_sdate.Text.Trim());
        _Current_Data.Condition.fdeliv_edate = Convert.ToDateTime(fdeliv_edate.Text.Trim());
        _Current_Data.Condition.cust_order = cust_order.Text.Trim();
        _Current_Data.Condition.mag_id = mag_id.Text.Trim();
        _Current_Data.Condition.car_no = car_no.Text.Trim();
        _Current_Data.Condition.car_id = car_id.Text.Trim();
        _Current_Data.Condition.plancar_inv_no = plancar_inv_no.Text.Trim();
        _Current_Data.Condition.deliv_no = deliv_no.Text.Trim();
        _Current_Data.Condition.order_no = order_no.Text.Trim();
        _Current_Data.Condition.option = "1";
        if (c_select.Checked == true)
        {
            _Current_Data.Condition.c_select = "1";
        }
      

        if (c_select1.Checked == true)
        {
    
            _Current_Data.Condition.c_select = "2";
        }
        

        if (c_select2.Checked == true)
        {
            _Current_Data.Condition.c_select = "3";
        }

        _Current_Data.Condition.check_car =(bool) check_car.Checked;


    }


    protected void Cmd_Clear_Click(object sender, EventArgs e)
    {
        cust_name.Text = "";
        cust_no.Text = "";
        cust_order.Text = "";
        order_no.Text = "";
        mag_id.Text = "";
        car_no.Text = "";
        car_id.Text = "";
        plancar_inv_no.Text = "";
        deliv_no.Text = "";


    }
    protected void Cmd_Query_Click(object sender, EventArgs e)
    {

        Get_Data();
    }



    //protected void ExportExcel(System.Web.UI.WebControls.DataList dl, string strFileName)
    //{

    //    strFileName = System.Web.HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8);

    //    System.Web.HttpContext.Current.Response.Clear();
    //    System.Web.HttpContext.Current.Response.Buffer = true;
    //    System.Web.HttpContext.Current.Response.Charset = "gb2312";
    //    System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "online; filename=" + strFileName + ".xls");
    //    System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
    //    System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";

    //    System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("zh-CN", true);
    //    System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
    //    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

    //    dl.RenderControl(oHtmlTextWriter);


    //    System.Web.HttpContext.Current.Response.Write(oStringWriter.ToString().Replace("<td", "<td STYLE='MSO-NUMBER-FORMAT://@'"));
    //    System.Web.HttpContext.Current.Response.Buffer = false;
    //    System.Web.HttpContext.Current.Response.End();
    //}

    //private void ToExcel(GridView GridView,DataTable dt)
    //{
    //    Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();

    //    //SaveFileDialog savefiledialog = new SaveFileDialog();

    //    System.Reflection.Missing miss = System.Reflection.Missing.Value;

    //    appexcel = new Microsoft.Office.Interop.Excel.Application();

    //    Microsoft.Office.Interop.Excel.Workbook workbookdata;

    //    Microsoft.Office.Interop.Excel.Worksheet worksheetdata;

    //    Microsoft.Office.Interop.Excel.Range rangedata;

    //    //设置对象不可见

    //    appexcel.Visible = false;

    //    System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;

    //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

    //    workbookdata = appexcel.Workbooks.Add(miss);

    //    worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

    //    //给工作表赋名称

    //    worksheetdata.Name = "saved";

    //    for (int i = 0; i < GridView.Columns.Count -1; i++)
    //    {

    //        worksheetdata.Cells[1, i + 1] = GridView.Columns[i].HeaderText.ToString();

    //    }

    //    //因为第一行已经写了表头，所以所有数据都应该从a2开始

    //    rangedata = worksheetdata.get_Range("a2", miss);

    //    Microsoft.Office.Interop.Excel.Range xlrang = null;

    //    //irowcount为实际行数，最大行

    //    int irowcount = dt.Rows.Count;

    //    int iparstedrow = 0, icurrsize = 0;

    //    //ieachsize为每次写行的数值，可以自己设置

    //    int ieachsize = 1000;

    //    //icolumnaccount为实际列数，最大列数

    //    int icolumnaccount = GridView.Columns.Count;

    //    //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数

    //    object[,] objval = new object[ieachsize, icolumnaccount];

    //    icurrsize = ieachsize;





    //    while (iparstedrow < irowcount)
    //    {

    //        if ((irowcount - iparstedrow) < ieachsize)

    //            icurrsize = irowcount - iparstedrow;

    //        //用for循环给数组赋值

    //        for (int i = 0; i < icurrsize; i++)
    //        {
    //            ;
    //            for (int j = 0; j < icolumnaccount; j++)
    //                if (GridView.Columns[j].GetType().Name.ToString() == "BoundField")
    //            {
    //                objval[i, j] = dt.Rows[i + iparstedrow][((BoundField)GridView.Columns[j]).DataField].ToString();
    //            }
    //            else if (GridView.Columns[j].GetType().Name.ToString() == "TemplateField")
    //            {
    //                objval[i, j] =i+1;
    //            }

    //            //System.Windows.Forms.Application.DoEvents();

    //        }

    //        string X = "A" + ((int)(iparstedrow + 2)).ToString();

    //        string col = "";

    //        if (icolumnaccount <= 26)
    //        {

    //            col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

    //        }

    //        else
    //        {

    //            col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

    //        }

    //        xlrang = worksheetdata.get_Range(X, col);

    //        // 调用range的value2属性，把内存中的值赋给excel

    //        xlrang.Value2 = objval;

    //        iparstedrow = iparstedrow + icurrsize;

    //    }

    //    //保存工作表

    //    //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlrang);

    //    xlrang = null;

    //    //调用方法关闭excel进程

    //    appexcel.Visible = true;
    //}

   
}
