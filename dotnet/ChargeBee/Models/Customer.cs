using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class Customer : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static UpdateBillingInfoRequest UpdateBillingInfo(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "update_billing_info");
            return new UpdateBillingInfoRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string FirstName 
        {
            get { return GetValue<string>("first_name", false); }
        }
        public string LastName 
        {
            get { return GetValue<string>("last_name", false); }
        }
        public string Email 
        {
            get { return GetValue<string>("email", false); }
        }
        public string Phone 
        {
            get { return GetValue<string>("phone", false); }
        }
        public string Company 
        {
            get { return GetValue<string>("company", false); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public AutoCollectionEnum AutoCollection 
        {
            get { return GetEnum<AutoCollectionEnum>("auto_collection", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string CreatedFromIp 
        {
            get { return GetValue<string>("created_from_ip", false); }
        }
        public CardStatusEnum? CardStatus 
        {
            get { return GetEnum<CardStatusEnum>("card_status", false); }
        }
        public CustomerBillingAddress BillingAddress 
        {
            get { return GetSubResource<CustomerBillingAddress>("billing_address"); }
        }
        public CustomerPaymentMethod PaymentMethod 
        {
            get { return GetSubResource<CustomerPaymentMethod>("payment_method"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public CreateRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public CreateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public CreateRequest Phone(string phone) 
            {
                m_params.AddOpt("phone", phone);
                return this;
            }
            public CreateRequest Company(string company) 
            {
                m_params.AddOpt("company", company);
                return this;
            }
            public CreateRequest AutoCollection(AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public CreateRequest CreatedFromIp(string createdFromIp) 
            {
                m_params.AddOpt("created_from_ip", createdFromIp);
                return this;
            }
            public CreateRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CreateRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CreateRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public CreateRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CreateRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CreateRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CreateRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CreateRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CreateRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CreateRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            public CreateRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CreateRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CreateRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CreateRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CreateRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CreateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CreateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public UpdateRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public UpdateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public UpdateRequest Phone(string phone) 
            {
                m_params.AddOpt("phone", phone);
                return this;
            }
            public UpdateRequest Company(string company) 
            {
                m_params.AddOpt("company", company);
                return this;
            }
            public UpdateRequest AutoCollection(AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
        }
        public class UpdateBillingInfoRequest : EntityRequest<UpdateBillingInfoRequest> 
        {
            public UpdateBillingInfoRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateBillingInfoRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
        }
        #endregion

        public enum CardStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("no_card")]
            NoCard,
            [Description("valid")]
            Valid,
            [Description("expiring")]
            Expiring,
            [Description("expired")]
            Expired,

        }

        #region Subclasses
        public class CustomerBillingAddress : Resource
        {

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string Company() {
                return GetValue<string>("company", false);
            }

            public string Phone() {
                return GetValue<string>("phone", false);
            }

            public string Line1() {
                return GetValue<string>("line1", false);
            }

            public string Line2() {
                return GetValue<string>("line2", false);
            }

            public string Line3() {
                return GetValue<string>("line3", false);
            }

            public string City() {
                return GetValue<string>("city", false);
            }

            public string StateCode() {
                return GetValue<string>("state_code", false);
            }

            public string State() {
                return GetValue<string>("state", false);
            }

            public string Country() {
                return GetValue<string>("country", false);
            }

            public string Zip() {
                return GetValue<string>("zip", false);
            }

        }
        public class CustomerPaymentMethod : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("card")]
                Card,
                [Description("paypal_express_checkout")]
                PaypalExpressCheckout,
                [Description("amazon_payments")]
                AmazonPayments,
            }
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("valid")]
                Valid,
                [Description("expiring")]
                Expiring,
                [Description("expired")]
                Expired,
                [Description("invalid")]
                Invalid,
            }

            public TypeEnum? PaymentMethodType() {
                return GetEnum<TypeEnum>("type", false);
            }

            public StatusEnum Status() {
                return GetEnum<StatusEnum>("status", true);
            }

            public string ReferenceId() {
                return GetValue<string>("reference_id", false);
            }

        }

        #endregion
    }
}