using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;

namespace Pagseguro.Sdk.RecurringPayment.Infra.Helper
{
    public static class PagSeguroExtensions
    {
        public static void AddPagseguroAccept(this HttpRequestMessage message, PagseguroAccept accept)
        {
            var acceptValue = accept.ToDescription();
            message.Headers.TryAddWithoutValidation("Accept", acceptValue);

            foreach (var v in message.Headers.Accept)
            {
                if (v.MediaType.Contains("application/vnd.pagseguro"))
                {
                    var field = v.GetType().GetTypeInfo().BaseType.GetField("_mediaType", BindingFlags.NonPublic | BindingFlags.Instance);
                    field.SetValue(v, acceptValue);
                    v.Parameters.Clear();
                }
            }

        }

        public static string ToDescription(this Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }


        public static object ToBodyPayload(this SubscribeRequest subscribeRequest)
        {
            return new
            {
                plan = subscribeRequest.PlanCode,
                reference = subscribeRequest.Reference,
                sender = new
                {
                    name = subscribeRequest.Sender.Name,
                    email = subscribeRequest.Sender.Email,
                    hash = subscribeRequest.Sender.Hash,
                    phone = GetPhoneObject(subscribeRequest.Sender.Phone),
                    address = GetAddressObject(subscribeRequest.Sender.Address),
                    documents = GetDocumentsObject(subscribeRequest.Sender.Cpf)
                },
                paymentMethod = new
                {
                    type = "CREDITCARD",
                    creditCard = GetCreditCardObject(subscribeRequest.PaymentMethod)
                }
            };
        }
        public static object ToBodyPayload(this PaymentMethod paymentMethod, string senderHash)
        {
            return new
            {
                type = "CREDITCARD",
                sender = new
                {
                    hash = senderHash
                },
                creditCard = GetCreditCardObject(paymentMethod)
            };
        }

        private static object GetPhoneObject(Phone phone)
        {
            return new
            {
                areaCode = phone.Code,
                number = phone.PhoneNumber
            };
        }

        private static object GetAddressObject(Address address)
        {
            return new
            {
                street = address.Street,
                number = address.Number,
                complement = address.Complement,
                district = address.District,
                city = address.City,
                state = address.State,
                country = address.Country,
                postalCode = address.ZipCode
            };
        }

        private static object GetDocumentsObject(string cpf)
        {
            return new[]{new
                    {
                        type = "CPF",
                        value = cpf
                    }
            };
        }

        private static object GetCreditCardObject(PaymentMethod paymentMethod)
        {
            return new
            {
                token = paymentMethod.Token,
                holder = new
                {
                    name = paymentMethod.Holder.Name,
                    birthDate = paymentMethod.Holder.BirthDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    documents = GetDocumentsObject(paymentMethod.Holder.Cpf),
                    phone = GetPhoneObject(paymentMethod.Holder.Phone),
                    billingAddress = GetAddressObject(paymentMethod.Holder.Address)
                }
            };
        }
    }
}
