using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.Services.Interface;
using StatusCodeModel = billkill.manager.backend.DTO.HelperModels.Const.StatusCodeModel;

namespace billkill.manager.backend.Services.Implementation
{
    public class ValidationCommon: IValidationCommon
    {
        public int CheckErrorCode(int error)
        {
            switch (error)
            {
                case ErrorCodes.AUTH:
                    return StatusCodeModel.AUTH;

                case ErrorCodes.FORBIDDEN:
                    return StatusCodeModel.FORBIDDEN;

                case ErrorCodes.NOT_FOUND:
                    return StatusCodeModel.NOT_FOUND;

                case ErrorCodes.LOOKUP:
                case ErrorCodes.REQUIRED:
                case ErrorCodes.FORMAT:
                    return StatusCodeModel.BAD_REQUEST;

                case ErrorCodes.AVIS_NOT_FOUND:
                case ErrorCodes.IAMAS_NOT_FOUND:
                case ErrorCodes.IAMAS_DOC_PASSIVE:
                case ErrorCodes.CUSTOMER:
                case ErrorCodes.RELATED_PEOPLE:
                case ErrorCodes.OPERATION:
                    return StatusCodeModel.OK;

                case ErrorCodes.IAMAS_SERVER:
                case ErrorCodes.AVIS_SERVER:
                case ErrorCodes.SYSTEM:
                case ErrorCodes.DB:
                case ErrorCodes.MODEL_STATE:
                case ErrorCodes.BULK:
                    return StatusCodeModel.INTERNEL_SERVER;
            }
            return StatusCodeModel.OK;
        }
    }
}
