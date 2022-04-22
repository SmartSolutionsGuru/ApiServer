using Microsoft.AspNetCore.Mvc;
using SmartSolutions.ApiServer.DataStore.Entites;
using SmartSolutions.ApiServer.DataStore.Repository;
using SmartSolutions.ApiServer.Otp;
using System.Linq.Expressions;

namespace SmartSolutions.ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        #region [private Members]
        private readonly ILogger<CompaniesController> _logger;
        private readonly IRepository _repository;
        #endregion

        #region [Properties]
        public IEnumerable<CompanyInfo> Companies { get; set; }
        public ProprietorInfo Company { get; set; }
        #endregion

        #region [Constructor]
        public CompaniesController(ILogger<CompaniesController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion

        #region [Public Methods]

        /// <summary>
        /// Get All Companies From Server
        /// </summary>
        /// <returns>List Of Companies</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<CompanyInfo>> GetAll()
        {
            Companies = await _repository.GetAllAsync<CompanyInfo>();
            return Companies;
        }
        /// <summary>
        /// Get the Filtered Companies Which Are 
        /// Filtered By Business Type
        /// </summary>
        /// <param name="id"> Id Of Business Type</param>
        /// <returns>List Of Companies</returns>

        [HttpGet]
        [Route("GetCompaniesByType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CompanyInfo>))]
        public async Task<IEnumerable<CompanyInfo>> GetCompaniesByType(int id)
        {
            Companies = await _repository.GetAllAsync<CompanyInfo>(take: id);
            return Companies;
        }

        [HttpGet]
        [Route("GetCompanyByPhone")]
        public async Task<ProprietorInfo> GetCompanyByPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
            {
                Expression<Func<ProprietorInfo, bool>> result = s => !string.IsNullOrEmpty(s.MobileNumber) && s.MobileNumber.Equals(phone);
                Company = await _repository.GetOneAsync<ProprietorInfo>(filter: result);
                if(Company != null && !string.IsNullOrEmpty(Company?.MobileNumber))
                {
                    OtpService SmsService = new OtpService();
                   
                }
            }
            return Company;

        }
        #endregion
    }
}
