package com.chargebee.models;

import com.chargebee.*;
import com.chargebee.internal.*;
import com.chargebee.internal.HttpUtil.Method;
import com.chargebee.models.enums.*;
import org.json.*;
import java.io.*;
import java.sql.Timestamp;
import java.util.*;

public class Invoice extends Resource<Invoice> {

    public enum Status {
        PAID,
        PAYMENT_DUE,
        NOT_PAID,
        PENDING,
        _UNKNOWN; /*Indicates unexpected value for this enum. You can get this when there is a
        java-client version incompatibility. We suggest you to upgrade to the latest version */
    }

    public static class LineItem extends Resource<LineItem> {
        public enum Type {
             CHARGE,PRORATED_CHARGE,SETUP_CHARGE,
            _UNKNOWN; /*Indicates unexpected value for this enum. You can get this when there is a
            java-client version incompatibility. We suggest you to upgrade to the latest version */ 
        }

        public enum EntityType {
             PLAN,ADDON,ADHOC,
            _UNKNOWN; /*Indicates unexpected value for this enum. You can get this when there is a
            java-client version incompatibility. We suggest you to upgrade to the latest version */ 
        }

        public LineItem(JSONObject jsonObj) {
            super(jsonObj);
        }

        public Timestamp dateFrom() {
            return reqTimestamp("date_from");
        }

        public Timestamp dateTo() {
            return reqTimestamp("date_to");
        }

        public Integer unitAmount() {
            return reqInteger("unit_amount");
        }

        public Integer quantity() {
            return optInteger("quantity");
        }

        public Integer tax() {
            return optInteger("tax");
        }

        public Double taxRate() {
            return optDouble("tax_rate");
        }

        public Integer amount() {
            return reqInteger("amount");
        }

        public String description() {
            return reqString("description");
        }

        public Type type() {
            return reqEnum("type", Type.class);
        }

        public EntityType entityType() {
            return reqEnum("entity_type", EntityType.class);
        }

        public String entityId() {
            return optString("entity_id");
        }

    }

    public static class Discount extends Resource<Discount> {
        public enum Type {
             COUPON,CREDIT_ADJUSTMENT,
            _UNKNOWN; /*Indicates unexpected value for this enum. You can get this when there is a
            java-client version incompatibility. We suggest you to upgrade to the latest version */ 
        }

        public Discount(JSONObject jsonObj) {
            super(jsonObj);
        }

        public Integer amount() {
            return reqInteger("amount");
        }

        public String description() {
            return optString("description");
        }

        public Type type() {
            return reqEnum("type", Type.class);
        }

        public String entityId() {
            return optString("entity_id");
        }

    }

    public static class Tax extends Resource<Tax> {
        public Tax(JSONObject jsonObj) {
            super(jsonObj);
        }

        public Integer amount() {
            return reqInteger("amount");
        }

        public String description() {
            return optString("description");
        }

    }

    public static class LinkedTransaction extends Resource<LinkedTransaction> {
        public LinkedTransaction(JSONObject jsonObj) {
            super(jsonObj);
        }

        public String txnId() {
            return reqString("txn_id");
        }

        public Integer appliedAmount() {
            return reqInteger("applied_amount");
        }

        public Transaction.Type txnType() {
            return reqEnum("txn_type", Transaction.Type.class);
        }

        public Transaction.Status txnStatus() {
            return optEnum("txn_status", Transaction.Status.class);
        }

        public Timestamp txnDate() {
            return optTimestamp("txn_date");
        }

        public Integer txnAmount() {
            return optInteger("txn_amount");
        }

    }

    public static class LinkedOrder extends Resource<LinkedOrder> {
        public enum Status {
             NEW,PROCESSING,COMPLETE,CANCELLED,VOIDED,
            _UNKNOWN; /*Indicates unexpected value for this enum. You can get this when there is a
            java-client version incompatibility. We suggest you to upgrade to the latest version */ 
        }

        public LinkedOrder(JSONObject jsonObj) {
            super(jsonObj);
        }

        public String id() {
            return reqString("id");
        }

        public Status status() {
            return optEnum("status", Status.class);
        }

        public String referenceId() {
            return optString("reference_id");
        }

        public String fulfillmentStatus() {
            return optString("fulfillment_status");
        }

        public String batchId() {
            return optString("batch_id");
        }

        public Timestamp createdAt() {
            return reqTimestamp("created_at");
        }

    }

    //Constructors
    //============

    public Invoice(String jsonStr) {
        super(jsonStr);
    }

    public Invoice(JSONObject jsonObj) {
        super(jsonObj);
    }

    // Fields
    //=======

    public String id() {
        return reqString("id");
    }

    public String customerId() {
        return reqString("customer_id");
    }

    public String subscriptionId() {
        return optString("subscription_id");
    }

    public Boolean recurring() {
        return reqBoolean("recurring");
    }

    public Status status() {
        return reqEnum("status", Status.class);
    }

    public String vatNumber() {
        return optString("vat_number");
    }

    public Timestamp startDate() {
        return reqTimestamp("start_date");
    }

    public Timestamp endDate() {
        return optTimestamp("end_date");
    }

    public Integer amount() {
        return optInteger("amount");
    }

    public Timestamp paidOn() {
        return optTimestamp("paid_on");
    }

    public Timestamp nextRetry() {
        return optTimestamp("next_retry");
    }

    public Integer subTotal() {
        return reqInteger("sub_total");
    }

    public Integer tax() {
        return reqInteger("tax");
    }

    public List<Invoice.LineItem> lineItems() {
        return optList("line_items", Invoice.LineItem.class);
    }

    public List<Invoice.Discount> discounts() {
        return optList("discounts", Invoice.Discount.class);
    }

    public List<Invoice.Tax> taxes() {
        return optList("taxes", Invoice.Tax.class);
    }

    public List<Invoice.LinkedTransaction> linkedTransactions() {
        return optList("linked_transactions", Invoice.LinkedTransaction.class);
    }

    public List<Invoice.LinkedOrder> linkedOrders() {
        return optList("linked_orders", Invoice.LinkedOrder.class);
    }

    // Operations
    //===========

    public static ChargeRequest charge() throws IOException {
        String uri = uri("invoices", "charge");
        return new ChargeRequest(Method.POST, uri);
    }

    public static ChargeAddonRequest chargeAddon() throws IOException {
        String uri = uri("invoices", "charge_addon");
        return new ChargeAddonRequest(Method.POST, uri);
    }

    public static InvoiceListRequest list() throws IOException {
        String uri = uri("invoices");
        return new InvoiceListRequest(uri);
    }

    public static ListRequest invoicesForCustomer(String id) throws IOException {
        String uri = uri("customers", nullCheck(id), "invoices");
        return new ListRequest(uri);
    }

    public static ListRequest invoicesForSubscription(String id) throws IOException {
        String uri = uri("subscriptions", nullCheck(id), "invoices");
        return new ListRequest(uri);
    }

    public static Request retrieve(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id));
        return new Request(Method.GET, uri);
    }

    public static Request pdf(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id), "pdf");
        return new Request(Method.POST, uri);
    }

    public static AddChargeRequest addCharge(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id), "add_charge");
        return new AddChargeRequest(Method.POST, uri);
    }

    public static AddAddonChargeRequest addAddonCharge(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id), "add_addon_charge");
        return new AddAddonChargeRequest(Method.POST, uri);
    }

    public static Request collect(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id), "collect");
        return new Request(Method.POST, uri);
    }

    public static RefundRequest refund(String id) throws IOException {
        String uri = uri("invoices", nullCheck(id), "refund");
        return new RefundRequest(Method.POST, uri);
    }


    // Operation Request Classes
    //==========================

    public static class ChargeRequest extends Request<ChargeRequest> {

        private ChargeRequest(Method httpMeth, String uri) {
            super(httpMeth, uri);
        }
    
        public ChargeRequest customerId(String customerId) {
            params.addOpt("customer_id", customerId);
            return this;
        }


        public ChargeRequest subscriptionId(String subscriptionId) {
            params.addOpt("subscription_id", subscriptionId);
            return this;
        }


        public ChargeRequest amount(Integer amount) {
            params.add("amount", amount);
            return this;
        }


        public ChargeRequest description(String description) {
            params.add("description", description);
            return this;
        }


        public ChargeRequest coupon(String coupon) {
            params.addOpt("coupon", coupon);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

    public static class ChargeAddonRequest extends Request<ChargeAddonRequest> {

        private ChargeAddonRequest(Method httpMeth, String uri) {
            super(httpMeth, uri);
        }
    
        public ChargeAddonRequest customerId(String customerId) {
            params.addOpt("customer_id", customerId);
            return this;
        }


        public ChargeAddonRequest subscriptionId(String subscriptionId) {
            params.addOpt("subscription_id", subscriptionId);
            return this;
        }


        public ChargeAddonRequest addonId(String addonId) {
            params.add("addon_id", addonId);
            return this;
        }


        public ChargeAddonRequest addonQuantity(Integer addonQuantity) {
            params.addOpt("addon_quantity", addonQuantity);
            return this;
        }


        public ChargeAddonRequest coupon(String coupon) {
            params.addOpt("coupon", coupon);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

    public static class InvoiceListRequest extends ListRequest<InvoiceListRequest> {

        private InvoiceListRequest(String uri) {
            super(uri);
        }
    
        public InvoiceListRequest limit(Integer limit) {
            params.addOpt("limit", limit);
            return this;
        }


        public InvoiceListRequest offset(String offset) {
            params.addOpt("offset", offset);
            return this;
        }


        public InvoiceListRequest paidOnAfter(Timestamp paidOnAfter) {
            params.addOpt("paid_on_after", paidOnAfter);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

    public static class AddChargeRequest extends Request<AddChargeRequest> {

        private AddChargeRequest(Method httpMeth, String uri) {
            super(httpMeth, uri);
        }
    
        public AddChargeRequest amount(Integer amount) {
            params.add("amount", amount);
            return this;
        }


        public AddChargeRequest description(String description) {
            params.add("description", description);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

    public static class AddAddonChargeRequest extends Request<AddAddonChargeRequest> {

        private AddAddonChargeRequest(Method httpMeth, String uri) {
            super(httpMeth, uri);
        }
    
        public AddAddonChargeRequest addonId(String addonId) {
            params.add("addon_id", addonId);
            return this;
        }


        public AddAddonChargeRequest addonQuantity(Integer addonQuantity) {
            params.addOpt("addon_quantity", addonQuantity);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

    public static class RefundRequest extends Request<RefundRequest> {

        private RefundRequest(Method httpMeth, String uri) {
            super(httpMeth, uri);
        }
    
        public RefundRequest refundAmount(Integer refundAmount) {
            params.addOpt("refund_amount", refundAmount);
            return this;
        }


        public RefundRequest memo(String memo) {
            params.addOpt("memo", memo);
            return this;
        }


        @Override
        public Params params() {
            return params;
        }
    }

}