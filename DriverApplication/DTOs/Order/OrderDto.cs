using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs
{
    public class OrderDto
    {
        //private int merchant_id;
        //public int Merchant_id { get => merchant_id; set => merchant_id = value; }

        //private int client_id;
        //public int Client_id { get => client_id; set => client_id = value; }

        //private string json_details;
        //public string Json_details { get => json_details; set => json_details = value; }

        //private string trans_type;
        //public string Trans_type { get => trans_type; set => trans_type = value; }

        //private string payment_type;
        //public string Payment_type { get => payment_type; set => payment_type = value; }

        //private float sub_total;
        //public float Sub_total { get => sub_total; set => sub_total = value; }

        //private float tax;
        //public float Tax { get => tax; set => tax = value; }

        //private decimal taxable_total;
        //public decimal Taxable_total { get => taxable_total; set => taxable_total = value; }

        //private float total_w_tax;
        //public float Total_w_tax { get => total_w_tax; set => total_w_tax = value; }

        //private string status;
        //public string Status { get => status; set => status = value; }

        //private int status_id;
        //public int Status_id { get => status_id; set => status_id = value; }

        //private int viewed;
        //public int Viewed { get => viewed; set => viewed = value; }

        //private float delivery_charge;
        //public float Delivery_charge { get => delivery_charge; set => delivery_charge = value; }

        //private DateTime? delivery_date;
        //public DateTime? Delivery_date { get => delivery_date; set => delivery_date = value; }

        //private string delivery_time;
        //public string Delivery_time { get => delivery_time; set => delivery_time = value; }

        //private string delivery_asap;
        //public string Delivery_asap { get => delivery_asap; set => delivery_asap = value; }

        //private string delivery_instruction;
        //public string Delivery_instruction { get => delivery_instruction; set => delivery_instruction = value; }

        //private string voucher_code;
        //public string Voucher_code { get => voucher_code; set => voucher_code = value; }

        //private float voucher_amount;
        //public float Voucher_amount { get => voucher_amount; set => voucher_amount = value; }

        //private string voucher_type;
        //public string Voucher_type { get => voucher_type; set => voucher_type = value; }

        //private int cc_id;
        //public int Cc_id { get => cc_id; set => cc_id = value; }

        //private DateTime? date_created;
        //public DateTime? Date_created { get => date_created; set => date_created = value; }

        //private DateTime? date_modified;
        //public DateTime? Date_modified { get => date_modified; set => date_modified = value; }

        //private string ip_address;
        //public string Ip_address { get => ip_address; set => ip_address = value; }

        //private float order_change;
        //public float Order_change { get => order_change; set => order_change = value; }

        //private string payment_provider_name;
        //public string Payment_provider_name { get => payment_provider_name; set => payment_provider_name = value; }

        //private float discounted_amount;
        //public float Discounted_amount { get => discounted_amount; set => discounted_amount = value; }

        //private float discount_percentage;
        //public float Discount_percentage { get => discount_percentage; set => discount_percentage = value; }

        //private float percent_commission;
        //public float Percent_commission { get => percent_commission; set => percent_commission = value; }

        //private float total_commission;
        //public float Total_commission { get => total_commission; set => total_commission = value; }

        //private int commission_ontop;
        //public int Commission_ontop { get => commission_ontop; set => commission_ontop = value; }

        //private float merchant_earnings;
        //public float Merchant_earnings { get => merchant_earnings; set => merchant_earnings = value; }

        //private float packaging;
        //public float Packaging { get => packaging; set => packaging = value; }

        //private float cart_tip_percentage;
        //public float Cart_tip_percentage { get => cart_tip_percentage; set => cart_tip_percentage = value; }

        //private float car_tip_value;
        //public float Car_tip_value { get => car_tip_value; set => car_tip_value = value; }

        //private float card_fee;
        //public float Card_fee { get => card_fee; set => card_fee = value; }

        //private int donot_apply_tax_delivery;
        //public int Donot_apply_tax_delivery { get => donot_apply_tax_delivery; set => donot_apply_tax_delivery = value; }

        //private int order_locked;
        //public int Order_locked { get => order_locked; set => order_locked = value; }

        //private string request_from;
        //public string Request_from { get => request_from; set => request_from = value; }

        //private string mobile_cart_details;
        //public string Mobile_cart_details { get => mobile_cart_details; set => mobile_cart_details = value; }

        //private float points_discount;
        //public float Points_discount { get => points_discount; set => points_discount = value; }

        //private int apply_food_tax;
        //public int Apply_food_tax { get => apply_food_tax; set => apply_food_tax = value; }

        //private string order_id_token;
        //public string Order_id_token { get => order_id_token; set => order_id_token = value; }

        //private int admin_viewed;
        //public int Admin_viewed { get => admin_viewed; set => admin_viewed = value; }

        //private int merchantapp_viewed;
        //public int Merchantapp_viewed { get => merchantapp_viewed; set => merchantapp_viewed = value; }

        //private string dinein_number_of_guest;
        //public string Dinein_number_of_guest { get => dinein_number_of_guest; set => dinein_number_of_guest = value; }

        //private string dinein_special_instruction;
        //public string Dinein_special_instruction { get => dinein_special_instruction; set => dinein_special_instruction = value; }

        //private int critical;
        //public int Critical { get => critical; set => critical = value; }

        //private string commission_type;
        //public string Commission_type { get => commission_type; set => commission_type = value; }

        //private int calculation_method;
        //public int Calculation_method { get => calculation_method; set => calculation_method = value; }

        //private int request_cancel;
        //public int Request_cancel { get => request_cancel; set => request_cancel = value; }

        //private int request_cancel_viewed;
        //public int Request_cancel_viewed { get => request_cancel_viewed; set => request_cancel_viewed = value; }

        //private string request_cancel_status;
        //public string Request_cancel_status { get => request_cancel_status; set => request_cancel_status = value; }

        //private string sofort_trans_id;
        //public string Sofort_trans_id { get => sofort_trans_id; set => sofort_trans_id = value; }

        //private string dinein_table_number;
        //public string Dinein_table_number { get => dinein_table_number; set => dinein_table_number = value; }

        //private string payment_gateway_ref;
        //public string Payment_gateway_ref { get => payment_gateway_ref; set => payment_gateway_ref = value; }

        //private string cancel_reason;
        //public string Cancel_reason { get => cancel_reason; set => cancel_reason = value; }


    }
}