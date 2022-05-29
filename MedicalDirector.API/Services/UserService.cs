using AutoMapper;
using MedicalDirector.API.DTOs.Users;
using MedicalDirector.Services;

namespace MedicalDirector.API.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IExternalService _externalService;
        private readonly IMapper _mapper;

        public UserService(
            ILogger<UserService> logger,
            IExternalService externalService,
            IMapper mapper)
        {
            _logger = logger;
            _externalService = externalService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserInfoDTO>> GetUserList()
        {
            _logger.LogInformation("GetUserList");

            List<UserInfoDTO> response = new List<UserInfoDTO>();
            IEnumerable<Domain.Entities.User> users = await this._externalService.GetUsers();
            IEnumerable<Domain.Entities.Post> posts = await this._externalService.GetPosts();

            foreach (var user in users)
            {
                var mapped = _mapper.Map<UserInfoDTO>(user);
                mapped.postCount = posts.Where(x => x.userId == user.id).Count();
                response.Add(mapped);
            }

            return response;
        }

        public async Task<UserDetailedDTO> GetUserDetails(int id)
        {
            _logger.LogInformation("GetUserList");

            Domain.Entities.User user = await this._externalService.GetUser(id);
            IEnumerable<Domain.Entities.Post> posts = await this._externalService.GetUserPosts(id);

            UserDetailedDTO response = _mapper.Map<UserDetailedDTO>(user);
            response.posts = _mapper.Map<PostDTO[]>(posts);

            return response;
        }
    }
}
