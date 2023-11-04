﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public LookupService(IRepository<STATIC_DATA> staticDataRepository, IMapper mapper)
        {
            _staticDataRepository = staticDataRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObject<StaticVM>> GetStaticDataAsync(ResponseObject<StaticVM> response, string key)
        {
            try
            {
             var result = await _staticDataRepository.AllQuery.FirstOrDefaultAsync(x=>x.Key == key);
                if(result == null)
                {
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    response.Status.Message = "Tapılmadı!";
                }
                else
                {
                    response.Response = _mapper.Map<StaticVM>(result);
                }
            }
            catch(Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }



    }
}
