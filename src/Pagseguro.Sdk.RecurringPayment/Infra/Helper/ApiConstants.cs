namespace Pagseguro.Sdk.RecurringPayment.Infra.Helper
{
    public static class ApiConstants
    {
        //Api Urls
        public const string WsProdUrl = "https://ws.pagseguro.uol.com.br";
        public const string WsSandboxUrl = "https://ws.sandbox.pagseguro.uol.com.br";


        //Api Resources
        public const string PreApprovals = "pre-approvals";
        public const string PaymentMethod = "payment-method";
        public const string Sessions = "v2/sessions";
        public const string Cancel = "cancel";
    }
}
