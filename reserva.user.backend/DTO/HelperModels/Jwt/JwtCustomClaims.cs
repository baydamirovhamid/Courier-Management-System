﻿namespace reserva.user.backend.DTO.HelperModels.Jwt
{
    public class JwtCustomClaims
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}