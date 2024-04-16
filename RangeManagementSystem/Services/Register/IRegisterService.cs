using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Services.Register
{
    public interface IRegisterService
    {
        public Task Register(RegisterInputViewModel model);
    }
}
