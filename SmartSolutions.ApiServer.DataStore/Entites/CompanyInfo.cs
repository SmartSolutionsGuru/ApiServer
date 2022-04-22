namespace SmartSolutions.ApiServer.DataStore.Entites
{
    public class CompanyInfo : Entity<int>
    {
        #region [Constructor]
        public CompanyInfo()
        {

        }
        #endregion

        #region [Properties]
        public string CompanyName { get; set; }
        /// <summary>
        /// Registered Mobile Number
        /// </summary>
        public string MobileNumber { get; set; }
        public string ProperiterName { get; set; }
        public int BussinessTypeId { get; set; }
        public string Description { get; set; }
        public DateTime? SyncAt { get; set; }
        public string SyncBy { get; set; }
        #endregion
    }
}
