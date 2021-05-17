//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using IDserv.Infrastruct;
//using IDserv.Models;
//using Microsoft.AspNetCore.Identity;

//namespace IDserv.DBase
//{
//    public class UserService: IUserService
//    {
//        private readonly DBContext _context;
//        private readonly IMapper _mapper;
//        private readonly UserManager<User> userManager;

//        public UserService(IMapper mapper, DBContext context, UserManager<User> userManager)
//        {
//            _mapper = mapper;
//            _context = context;
//            this.userManager = userManager;
//        }

//        public async Task<OperationDetails> AddIdentityUser(UserRegistrationModel userRegistrationModel)
//        {
//            if (await userManager.FindByEmailAsync(userRegistrationModel.Email) != null)
//            {
//                return new OperationDetails(false, "Emali is exist in database", "Email");
//            }

//            User user = _mapper.Map<UserRegistrationModel, User>(userRegistrationModel);

//            var result = await userManager.CreateAsync(user, userRegistrationModel.Password);

//            if (result.Errors.Count() > 0)
//            {
//                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
//            }

//            await _context.SaveChangesAsync();

//            return new OperationDetails(true, "Registration succeeded", "", result);
//        }

//        public Task<User> GetIdentityUserById(int id)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}