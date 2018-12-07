using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using BaseModel.Erp_Common;

public partial class Scan_add : System.Web.UI.Page
{
    private BusinessRuler.Erp_Deve.br_Deliv_Car_Scan Current_Data = new BusinessRuler.Erp_Deve.br_Deliv_Car_Scan();

    bool _result = true;
    string _plancar_inv_no = "";
    string _plan_date = "";
    //string _upd_mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        pack_no.Focus();

        _plancar_inv_no = Request.QueryString["inv_no"];
        _plan_date = Request.QueryString["plan_date"];
        //_upd_mode = Request.QueryString["upd_mode"];
        plancar_inv_no.Text = _plancar_inv_no;
        plan_date.Text = _plan_date;
        if (!Page.IsPostBack)
        {

            Tip();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    protected void set_Binding()
    {
        //scan_date.Text = Current_Data.Base_Data.scan_date.ToShortDateString();

        pack_no.Text = Current_Data.Base_Data.pack_no;
        cust_name.Text = Current_Data.Base_Data.cust_name;
        mtr_amt.Text = Current_Data.Base_Data.inv_amt.ToString();
        plancar_inv_no.Text = _plancar_inv_no;
        deliv_no.Text = Current_Data.Base_Data.deliv_no;
        plan_date.Text = _plan_date;

        deliv_no.Text = Current_Data.Base_Data.deliv_no;
        //order_no.Text = Current_Data.Base_Data.order_no;
        //cust_order.Text = Current_Data.Base_Data.cust_order;
        //mtr_name.Text = Current_Data.Base_Data.mtr_name;
        //mtr_dim.Text = Current_Data.Base_Data.mtr_dim;
    }

    /// <summary>
    /// 清空控件文本
    /// </summary>
    public void Text_Clear()
    {

        pack_no.Text = "";
        cust_name.Text = "";

        deliv_no.Text = "";

        mtr_amt.Text = "";
        //order_no.Text = "";
        //cust_order.Text = "";
        //mtr_name.Text = "";
        //mtr_dim.Text = "";
        //mtr_amt.Text = "";

    }

    public void Tip()
    {
        if (plancar_inv_no.Text.Trim() != "")
            total.Text = Current_Data.Get_Tip(plancar_inv_no.Text.Trim());

    }


    /// <summary>
    /// 绑定数据;location.href='Scan_add.aspx'
    /// </summary>
    protected void Get_Binding()
    {
        if (pack_no.Text.Trim() == "")
        {
            msg.Text = "当前包装单号不能为空!";
            Page.RegisterClientScriptBlock("Select", "<script>Select('wrong.wav')</script>");
            return;
        }
        Current_Data.Base_Data.pack_no = pack_no.Text.Trim();
        Current_Data.Base_Data.plancar_inv_no = plancar_inv_no.Text.Trim();
        Current_Data.Base_Data.inv_amt = Convert.ToDouble(mtr_amt.Text.ToString());
        Current_Data.Base_Data.upd_name = CommonMoulde.PcInfo.getpcinfo.client_pc_name();
    }

    //确定
    protected void Button2_Click(object sender, EventArgs e)
    {
        //check_ok();
        Cmd_Ok_Click();

    }

    private void Cmd_Ok_Click()
    {
        if (_result)
        {
            Get_Binding();
            if (!Current_Data.Check_Ok("add"))
            {
                string check_ok_result = Current_Data.Check_Ok_Result;
                //Response.Write("<script>alert('" + check_ok_result + "')</script>");
                if (check_ok_result == "此包装单号已经扫描过！")
                {
                    msg.Text = "此包装单号已经扫描过！";
                    Page.RegisterClientScriptBlock("Select", "<script>Select('repeat.wav')</script>");
                }
                else
                {
                    msg.Text = "当前包装单号有问题!";
                    Page.RegisterClientScriptBlock("Select", "<script>Select('wrong.wav')</script>");
                }
                msg.Text = check_ok_result;
                Text_Clear();
            }
            else if (Current_Data.Add_Data())
            {
                //Response.Write("<script>alert('新增成功!')</script>");
                msg.Text = "新增成功！";
                Page.RegisterClientScriptBlock("Select", "<script>Select('right.wav')</script>");
                Text_Clear();
            }
        }
        Tip();
    }

    //20457803
    //20457805
    //20457806
    //20457809
    //20457811
    //20457813
    //20457814
    //20457816
    //20457818
    //20457820

    //退出
    protected void Button6_Click(object sender, EventArgs e)
    {
        Text_Clear();
    }

    protected void go_pack_Click(object sender, EventArgs e)
    {

        Response.Write("<script>location.href='Deliv_Scan_vn.aspx'</script>");
    }

    // 获取扫描后的数据
    protected void Pack_No_TextChanged(object sender, EventArgs e)
    {
        //获取采购数量
        string no = pack_no.Text.Trim();
        if (no != "")
        {
            Current_Data.Get_Pack_Data(no);
            if (Current_Data.Base_Data.pack_no != "")
            {

                pack_no.Text = Current_Data.Base_Data.pack_no;
                cust_name.Text = Current_Data.Base_Data.cust_name;
                mtr_amt.Text = Current_Data.Base_Data.inv_amt.ToString();
                deliv_no.Text = Current_Data.Base_Data.deliv_no;
                //deliv_date.Text = Current_Data.Pack_Data.deliv_date.ToShortDateString();
                //order_no.Text = Current_Data.Pack_Data.order_no;
                //cust_order.Text = Current_Data.Pack_Data.cust_order;
                //mtr_name.Text = Current_Data.Pack_Data.mtr_name;
                //mtr_dim.Text = Current_Data.Pack_Data.mtr_dim;
                Cmd_Ok_Click();
            }
            else
            {
                msg.Text = "当前包装单号不存在!";
                //Play_sound();
                Page.RegisterClientScriptBlock("Select", "<script>Select('right.wav')</script>");
                //Response.Write("<script>alert('当前包装单号不存在!')</script>");
                Text_Clear();
            }
        }
    }


    //private void Play_sound()
    //{
    //    wave _wave = new wave();

    //    //if (_wave.Play("\\Platform\\WavAlias\\CRITICAL.WAV") == true)
    //    if (System.IO.File.Exists("\\Platform\\WavAlias\\CRITICAL.WAV"))
    //    {
    //        msg.Text = "文件 存在!";
    //    }
    //    else
    //    {
    //        msg.Text = "声音没成功!";

    //    }
       

    //}


}
