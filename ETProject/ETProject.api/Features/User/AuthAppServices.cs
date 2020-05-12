using System;
using System.Threading.Tasks;
using AutoMapper;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.User
{
    public class AuthAppServices
    {
        public IUnitOfWork UnitOfWork { get; }
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;
        public AuthAppServices(IUnitOfWork unitOfWork, IAuthRepository authRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.authRepository = authRepository;
            this.UnitOfWork = unitOfWork;

        }

        public async Task<UserDto> Register(UserDto user){
            byte[] passHash, passSalt;
            CreatePassHash(user.Password,out passHash, out passSalt);

            User newUser = new User.builder(user.Name,user.UserId,passHash,passSalt).build();

            bool created = await authRepository.AddAsync(newUser);
            
            if (created)
                await UnitOfWork.CompleteAsync();

            return mapper.Map<UserDto>(newUser);            

        }

        private void CreatePassHash(string pass, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));


                
            }
        }

        public async Task<UserDto> Login(string userid, string pass){
            UserDto userDto = new UserDto();
            User user = await authRepository.GetUserByUserIdAsync(userid);
            if (user != null)
                if (VerifyPassword(pass,user.PassHash,user.PassSalt))
                    return mapper.Map<UserDto>(user);
                    
                    
            return null;   
            
        }

        private bool VerifyPassword(string pass, byte[] passHash, byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passHash[i] ) return false;
                }
                return true;
            }
        }
        public async Task<bool> UserExistAsync (string userId){
            
            return await authRepository.UserExists(userId);
        }
    }
}