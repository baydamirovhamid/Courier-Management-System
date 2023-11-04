using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Interface;

namespace reserva.user.backend.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<STATIC_DATA> _staticDataRepository;
        private readonly IRepository<TIME_TYPE> _timeTypeRepository;
        private readonly IRepository<STADIUM_TYPE> _stadiumTypeRepository; 
        private readonly IRepository<COMPANY> _companyRepository;
        private readonly IRepository<COMPANY_BRANCH> _companyBranchRepository;

        private readonly IMapper _mapper;
        public LookupService(IRepository<STATIC_DATA> staticDataRepository, IRepository<TIME_TYPE> timeTypeRepository, IRepository<STADIUM_TYPE> stadiumTypeRepository,  IRepository<COMPANY> companyRepository, IRepository<COMPANY_BRANCH> companyBranchRepository, IMapper mapper)
        {
            _staticDataRepository = staticDataRepository;
            _timeTypeRepository = timeTypeRepository;
            _stadiumTypeRepository = stadiumTypeRepository;
            _companyRepository = companyRepository;
            _companyBranchRepository = companyBranchRepository;
            _mapper = mapper;
        }

        
        public async Task<ResponseObject<StaticVM>> GetStaticDataAsync(ResponseObject<StaticVM> response, string key)
        {
            try
            {
                var result = await _staticDataRepository.AllQuery.FirstOrDefaultAsync(x => x.Key == key);
                if (result == null)
                {
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    response.Status.Message = "Tapılmadı!";
                }
                else
                {
                    response.Response = _mapper.Map<StaticVM>(result);
                }
            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }
    
       public async Task<ResponseList<TimeTypeVM>> GetTimeTypeAsync(ResponseList<TimeTypeVM> response)
    {
        try
        {
            var result = await _timeTypeRepository.AllQuery.ToListAsync();
          
            response.Data = _mapper.Map<List<TimeTypeVM>>(result);
            
        }
        catch (Exception ex)
        {
            response.Status.ErrorCode = ErrorCodes.DB;
            response.Status.Message = "Problem baş verdi!";
        }
        return response;
    }

        public async Task<ResponseList<StadiumTypeVM>> GetStadiumTypeAsync(ResponseList<StadiumTypeVM> response)
        {
            try
            {
                var result = await _stadiumTypeRepository.AllQuery.ToListAsync();
                response.Data = _mapper.Map<List<StadiumTypeVM>>(result);
                 
            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }
        public async Task<ResponseList<CompanyVM>> GetCompanyAsync(ResponseList<CompanyVM> response)
        {
            try
            {
                var result = await _companyRepository.AllQuery.ToListAsync();

                response.Data = _mapper.Map<List<CompanyVM>>(result);

            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }


        public async Task<ResponseList<CompanyBranch>> GetCompanyBranch(ResponseList<CompanyBranch> response)
        {
            try
            {
                var result = await _companyBranchRepository.AllQuery.ToListAsync();
                response.Data = _mapper.Map<List<CompanyBranch>>(result);
              
            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }
    }
}

