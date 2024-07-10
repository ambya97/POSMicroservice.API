using POS.API.Helpers;
using POS.Business;
using POS.Business.Authentication;
using POS.Data;
using POS.Data.Repository;
using POS.Service;

namespace POS.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddPosServices(this IServiceCollection services) 
        {
            #region Database 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region FileUploadHelper 
            services.AddScoped<IFileUploadHelper,FileUploadHelper>();
            #endregion

            #region Brand
            services.AddScoped<IBrandManager, BrandManager>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            #endregion

            #region Unit
            services.AddScoped<IUnitManager, UnitManager>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            #endregion
            #region Register
            services.AddScoped<IRegisterManager, RegisterManager>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IRegister, Register>();
            #endregion

            #region Login
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            #endregion
            #region Auth
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            #endregion

        }
    }
}
