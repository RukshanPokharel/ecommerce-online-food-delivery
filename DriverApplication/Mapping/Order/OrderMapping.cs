using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DriverApplication.Mapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            //Primary Key
            this.HasKey(t => t.Order_id);
            //Properties
            this.Property(t => t.Order_id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            this.ToTable("mt_order");
            //this.Property(t => t.Admin_viewed).HasColumnName("admin_viewed");
            //this.Property(t => t.Apply_food_tax).HasColumnName("apply_food_tax");
            //this.Property(t => t.Calculation_method).HasColumnName("calculation_method");
            //this.Property(t => t.Cancel_reason).HasColumnName("cancel_reason");
            //this.Property(t => t.Card_fee).HasColumnName("card_fee");
            //this.Property(t => t.Cart_tip_percentage).HasColumnName("cart_tip_percentage");
            //this.Property(t => t.Car_tip_value).HasColumnName("cart_tip_value");
            //this.Property(t => t.Cc_id).HasColumnName("cc_id");
            //this.Property(t => t.Client_id).HasColumnName("client_id");
            //this.Property(t => t.Commission_ontop).HasColumnName("commission_on_top");
            //this.Property(t => t.Commission_type).HasColumnName("commission_type");
            //this.Property(t => t.Critical).HasColumnName("critical");
            //this.Property(t => t.Date_created).HasColumnName("date_created");
            //this.Property(t => t.Date_modified).HasColumnName("date_modified");
            //this.Property(t => t.Delivery_charge).HasColumnName("delivery_charge");
            //this.Property(t => t.Delivery_date).HasColumnName("delivery_date");
            //this.Property(t => t.Delivery_instruction).HasColumnName("delivery_instruction");
            //this.Property(t => t.Delivery_time).HasColumnName("delivery_time");
            //this.Property(t => t.Status).HasColumnName("status");
            //this.Property(t => t.Date_created).HasColumnName("date_created");
            //this.Property(t => t.Date_modified).HasColumnName("date_modified");
            //this.Property(t => t.Dinein_table_number).HasColumnName("dinein_table_number");
            //this.Property(t => t.Dinein_number_of_guest).HasColumnName("dinein_number_of_guest");
            //this.Property(t => t.Dinein_special_instruction).HasColumnName("dinein_special_instruction");
            //this.Property(t => t.Discounted_amount).HasColumnName("discounted_amount");
            //this.Property(t => t.Discount_percentage).HasColumnName("discount_percentage");
            //this.Property(t => t.Donot_apply_tax_delivery).HasColumnName("donot_apply_tax_delivery");
            //this.Property(t => t.Merchantapp_viewed).HasColumnName("merchantapp_viewed");
            //this.Property(t => t.Merchant_earnings).HasColumnName("merchant_earnings");
            //this.Property(t => t.Merchant_id).HasColumnName("merchant_id");
            //this.Property(t => t.Mobile_cart_details).HasColumnName("mobile_cart_details");
            //this.Property(t => t.Order_change).HasColumnName("order_change");
            //this.Property(t => t.Order_id_token).HasColumnName("order_id_token");
            //this.Property(t => t.Order_locked).HasColumnName("order_locked");
            //this.Property(t => t.Packaging).HasColumnName("packaging");
            //this.Property(t => t.Payment_gateway_ref).HasColumnName("payment_gateway_ref");
            //this.Property(t => t.Payment_provider_name).HasColumnName("payment_provider_name");
            //this.Property(t => t.Payment_type).HasColumnName("payment_type");
            //this.Property(t => t.Percent_commission).HasColumnName("percent_commission");
            //this.Property(t => t.Points_discount).HasColumnName("points_discount");
            //this.Property(t => t.Request_cancel).HasColumnName("request_cancel");
            //this.Property(t => t.Request_cancel_status).HasColumnName("request_cancel_status");
            //this.Property(t => t.Request_cancel_viewed).HasColumnName("request_cancel_viewed");
            //this.Property(t => t.Request_from).HasColumnName("request_from");
            //this.Property(t => t.Sofort_trans_id).HasColumnName("sofort_trans_id");
            //this.Property(t => t.Status).HasColumnName("status");
            //this.Property(t => t.Sub_total).HasColumnName("sub_total");
            //this.Property(t => t.Tax).HasColumnName("tax");
            //this.Property(t => t.Taxable_total).HasColumnName("taxable_total");
            //this.Property(t => t.Total_commission).HasColumnName("total_commission");
            //this.Property(t => t.Total_w_tax).HasColumnName("total_w_tax");
            //this.Property(t => t.Voucher_amount).HasColumnName("voucher_amount");
            //this.Property(t => t.Voucher_code).HasColumnName("voucher_code");



            //this.Property(t => t.Client_fk).HasColumnName("client_fk");
            //this.Property(t => t.Merchant_fk).HasColumnName("merchant_fk");
            //this.Property(t => t.delivery_address_fk).HasColumnName("delivery_address_fk");
            //this.Property(t => t.order_history_fk).HasColumnName("order_history_fk");
            //this.Property(t => t.order_status_fk).HasColumnName("order_status_fk");
            //this.Property(t => t.rating_fk).HasColumnName("rating_fk");


            //this.Property(t => t.Delivery_asap).HasColumnName("delivery_asap");
            //this.Property(t => t.Dinein_number_of_guest).HasColumnName("dinein_number_of_guest");
            //this.Property(t => t.Dinein_special_instruction).HasColumnName("dinein_special_instruction");
            //this.Property(t => t.Donot_apply_tax_delivery).HasColumnName("Donot_apply_tax_delivery");
            //this.Property(t => t.Ip_address).HasColumnName("ip_address");
            //this.Property(t => t.Json_details).HasColumnName("json_details");
            //this.Property(t => t.Sofort_trans_id).HasColumnName("sofort_trans_id");
            //this.Property(t => t.Status_id).HasColumnName("status_id");
            //this.Property(t => t.Trans_type).HasColumnName("trans_type");
            //this.Property(t => t.Viewed).HasColumnName("viewed");
            
            
            //this.Property(t => t.merchant_client_client_id).HasColumnName("merchant_client_client_id");
            //this.Property(t => t.merchant_entity_merchant_id).HasColumnName("merchant_entity_merchant_id");
            //this.Property(t => t.order_delivery_address_id).HasColumnName("order_delivery_address_id");
            //this.Property(t => t.order_history_id).HasColumnName("order_history_id");
            //this.Property(t => t.review_id).HasColumnName("review_id");

        }
    }
}