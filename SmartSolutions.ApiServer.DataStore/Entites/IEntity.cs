using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolutions.ApiServer.DataStore.Entites
{
    public interface IModifiableEntity
    {
        string Name { get; set; }
    }
    public interface IEntity : IModifiableEntity
    {
        #region [Properties]

        /// <summary>
        /// Id is Object Because
        /// It can be int,long,GUID etc
        /// </summary>
        object Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        byte[] Version { get; set; }
        #endregion
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
