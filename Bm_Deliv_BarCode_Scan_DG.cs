﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseModel.Erp_Sale.Base
{
    public class Bm_Deliv_BarCode_Scan_DG : BaseModel.Erp_Common.bmo_base
    {

        
		 #region 声明变量

		 private 	int  _d_list=0;
		 private 	int  _list_no=0;
		 private 	DateTime  _order_date= DateTime.Today;
		 private 	DateTime  _scan_date= DateTime.Today;
		 private 	DateTime  _deliv_date= DateTime.Today;

         private DateTime _bh_scan_date = DateTime.Today;

         public DateTime bh_scan_date
         {
             get { return _bh_scan_date; }
             set { _bh_scan_date = value; }
         }
		 private 	double  _zhang_amt=0;
		 private 	double  _kun_amt=0;
		 private 	double  _give_amt=0;
		 private 	double  _inv_amt=0;
		 private 	string  _pack_no="";
		 private 	string  _remark="";
		 private 	string  _deliv_no="";
		 private 	string  _mo_no="";
		 private 	string  _mtr_no="";
		 private 	string  _cust_soft="";
		 private 	string  _line_scrpt="";
		 private 	string  _order_mtr_name="";
		 private 	string  _mtr_thick="";
		 private 	string  _mtr_color="";
		 private 	string  _mtr_soft="";
		 private 	string  _cust_order="";
		 private 	string  _sample="";
		 private 	string  _mtr_line="";
		 private 	string  _cust_mo="";
		 private 	string  _card_no="";
		 private 	string  _order_no="";
		 private 	string  _mtr_ability="";
		 private 	string  _mtr_dim="";
		 private 	string  _name_scrpt="";
		 private 	string  _mtr_name="";
         private string _cust_no = "";
         private string _scan_status = "";


         public string cust_no
         {
             get { return _cust_no; }
             set { _cust_no = value; }
         }
         private string _cust_name = "";

         public string cust_name
         {
             get { return _cust_name; }
             set { _cust_name = value; }
         }
		 #endregion 


         public Bm_Deliv_BarCode_Scan_DG()
		{
		}


		#region 属性
         public string scan_status
         {
             get { return _scan_status; }
             set { _scan_status = value; }
         }
		public int d_list
		{
			set { _d_list=value; }
			get{  return  _d_list; }
		}
		public int list_no
		{
			set { _list_no=value; }
			get{  return  _list_no; }
		}
		public DateTime order_date
		{
			set { _order_date=value; }
			get{  return  _order_date; }
		}
		public DateTime scan_date
		{
			set { _scan_date=value; }
			get{  return  _scan_date; }
		}
		public DateTime deliv_date
		{
			set { _deliv_date=value; }
			get{  return  _deliv_date; }
		}
		public double zhang_amt
		{
			set { _zhang_amt=value; }
			get{  return  _zhang_amt; }
		}
		public double kun_amt
		{
			set { _kun_amt=value; }
			get{  return  _kun_amt; }
		}
		public double give_amt
		{
			set { _give_amt=value; }
			get{  return  _give_amt; }
		}
		public double inv_amt
		{
			set { _inv_amt=value; }
			get{  return  _inv_amt; }
		}
		public string pack_no
		{
			set { _pack_no=value; }
			get{  return  _pack_no; }
		}
		public string remark
		{
			set { _remark=value; }
			get{  return  _remark; }
		}
		public string deliv_no
		{
			set { _deliv_no=value; }
			get{  return  _deliv_no; }
		}
		public string mo_no
		{
			set { _mo_no=value; }
			get{  return  _mo_no; }
		}
		public string mtr_no
		{
			set { _mtr_no=value; }
			get{  return  _mtr_no; }
		}
		public string cust_soft
		{
			set { _cust_soft=value; }
			get{  return  _cust_soft; }
		}
		public string line_scrpt
		{
			set { _line_scrpt=value; }
			get{  return  _line_scrpt; }
		}
		public string order_mtr_name
		{
			set { _order_mtr_name=value; }
			get{  return  _order_mtr_name; }
		}
		public string mtr_thick
		{
			set { _mtr_thick=value; }
			get{  return  _mtr_thick; }
		}
		public string mtr_color
		{
			set { _mtr_color=value; }
			get{  return  _mtr_color; }
		}
		public string mtr_soft
		{
			set { _mtr_soft=value; }
			get{  return  _mtr_soft; }
		}
		public string cust_order
		{
			set { _cust_order=value; }
			get{  return  _cust_order; }
		}
		public string sample
		{
			set { _sample=value; }
			get{  return  _sample; }
		}
		public string mtr_line
		{
			set { _mtr_line=value; }
			get{  return  _mtr_line; }
		}
		public string cust_mo
		{
			set { _cust_mo=value; }
			get{  return  _cust_mo; }
		}
		public string card_no
		{
			set { _card_no=value; }
			get{  return  _card_no; }
		}
		public string order_no
		{
			set { _order_no=value; }
			get{  return  _order_no; }
		}
		public string mtr_ability
		{
			set { _mtr_ability=value; }
			get{  return  _mtr_ability; }
		}
		public string mtr_dim
		{
			set { _mtr_dim=value; }
			get{  return  _mtr_dim; }
		}
		public string name_scrpt
		{
			set { _name_scrpt=value; }
			get{  return  _name_scrpt; }
		}
		public string mtr_name
		{
			set { _mtr_name=value; }
			get{  return  _mtr_name; }
		}

		 #endregion 
 
    }
}
