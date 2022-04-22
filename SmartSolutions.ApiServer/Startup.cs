using Microsoft.EntityFrameworkCore;
using SmartSolutions.ApiServer.DataStore;

namespace SmartSolutions.ApiServer
{
    /// <summary>
    /// Startup Class for Initialization
    /// </summary>
    public class Startup
    {
        #region [Constructor]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;   
        }
        #endregion

        #region [Methods]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));           
        }
        #endregion

        #region [Properties]
        /// <summary>
        /// Gets Configuration Object
        /// </summary>
        public IConfiguration Configuration { get; }
       
        #endregion
    }
}
