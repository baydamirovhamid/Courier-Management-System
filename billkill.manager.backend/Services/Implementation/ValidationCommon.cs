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

                case ErrorCodes.REQUIRED:
                case ErrorCodes.FORMAT:
                    return StatusCodeModel.BAD_REQUEST;

                case ErrorCodes.SYSTEM:
                case ErrorCodes.DB:
                    return StatusCodeModel.INTERNEL_SERVER;
            }
            return StatusCodeModel.OK;
        }
    }
}
