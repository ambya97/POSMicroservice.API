using POS.Business;
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

            
        }
    }
}
