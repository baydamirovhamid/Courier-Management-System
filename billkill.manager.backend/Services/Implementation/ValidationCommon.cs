using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.Services.Interface;
using StatusCodes = billkill.manager.backend.DTO.HelperModels.Const.StatusCodes;

namespace billkill.manager.backend.Services.Implementation
{
    public class ValidationCommon: IValidationCommon
    {
        public int CheckErrorCode(int error)
        {
            switch (error)
            {
                case ErrorCodes.AUTH:
                    return StatusCodes.AUTH;

                case ErrorCodes.FORBIDDEN:
                    return StatusCodes.FORBIDDEN;

                case ErrorCodes.NOT_FOUND:
                    return StatusCodes.NOT_FOUND;

                case ErrorCodes.LOOKUP:
                case ErrorCodes.REQUIRED:
                case ErrorCodes.FORMAT:
                    return StatusCodes.BAD_REQUEST;

                case ErrorCodes.AVIS_NOT_FOUND:
                case ErrorCodes.IAMAS_NOT_FOUND:
                case ErrorCodes.IAMAS_DOC_PASSIVE:
                case ErrorCodes.CUSTOMER:
                case ErrorCodes.RELATED_PEOPLE:
                case ErrorCodes.OPERATION:
                    return StatusCodes.OK;

                case ErrorCodes.IAMAS_SERVER:
                case ErrorCodes.AVIS_SERVER:
                case ErrorCodes.SYSTEM:
                case ErrorCodes.DB:
                case ErrorCodes.MODEL_STATE:
                case ErrorCodes.BULK:
                    return StatusCodes.INTERNEL_SERVER;
            }
            return StatusCodes.OK;
        }
    }
}
