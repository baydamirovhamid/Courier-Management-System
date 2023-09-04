namespace billkill.payment.service.DTO.HelperModels.Const
{
    public class ErrorCodes
    {
        // 403
        public const int FORBIDDEN = 1;

        // 401
        public const int AUTH = 11;

        // 400
        public const int REQUIRED = 21;
        public const int FORMAT = 22;

        //404
        public const int NOT_FOUND = 51;

        // 500
        public const int SYSTEM = 61;
        public const int DB = 62;
    }
}
