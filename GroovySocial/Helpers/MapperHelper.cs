using Groov.Library.Data.Entities;
using GroovySocial.ViewModels;

namespace GroovySocial.Helpers
{
    public class MapperHelper
    {
        public static User ViewModelToModel(UserViewModel viewmodel)
        {
            return new User()
            {
                Id = viewmodel.Id,
                UserName = viewmodel.UserName,
                Password = viewmodel.Password,
                City = viewmodel.City,
                Biography = viewmodel.Biography,
                Birthday = viewmodel.Birthday,
            };
        }
    }
}
