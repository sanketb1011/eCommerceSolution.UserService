using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RespositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
          var user =  await _userRepository
                        .GetUserByEamilAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }           

            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "Token"
            };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            
            var user = _mapper.Map<ApplicationUser>(registerRequest);

            var UserEntity = await _userRepository.AddUser(user);
            if (UserEntity == null) 
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "Token"
            };
        }
    }
}
