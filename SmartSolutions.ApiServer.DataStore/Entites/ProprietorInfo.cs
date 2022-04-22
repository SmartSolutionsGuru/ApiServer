using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolutions.ApiServer.DataStore.Entites
{
    /// <summary>
    /// Entity F
    /// </summary>
    public class ProprietorInfo : Entity<int>
    {
        #region [Constructor]
        public ProprietorInfo()
        {

        }
        #endregion

        #region [Properties]
        public string ProprietorName { get; set; }
        public string BussinessName { get; set; }
        public int CityId { get; set; }
        public int BussinessTypeId { get; set; }
        public int BussinessCategoryId { get; set; }
        public string LandLineNumber { get; set; }
        public string LandLineNumber1 { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumber1 { get; set; }
        public string WhatsAppNumber { get; set; }
        public string EmergenceyNumber { get; set; }
        public string BussinessAddress { get; set; }
        public string HomeAddress { get; set; }
        public string Description { get; set; }
        #endregion

    }
}
