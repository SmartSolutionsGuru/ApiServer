using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolutions.ApiServer.DataStore.Entites
{
    public class BussinessType : Entity<int>
    {
        #region [Constructor]
        public BussinessType()
        {

        }
        #endregion

        #region [Properties]
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? SyncAt { get; set; }
        public string SyncBy { get; set; }
        #endregion
    }
}
