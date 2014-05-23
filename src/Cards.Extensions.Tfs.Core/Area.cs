using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Extensions.Tfs.Core
{
    public class Area
    {

        public Area()
            : this(new DateProvider(), new EntityFrameworkStorageProvider(), new WindowsIdentityProvider())
        {
            Active = true;
        }

        public Area(IDateProvider dateProvider, IStorageProvider storageProvider, IIdentityProvider identityProvider)
        {
            DateProvider = dateProvider;
            StorageProvider = storageProvider;
            IdentityProvider = identityProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public bool Active { get; set; }

        /// <summary>
        /// Creates an area given the name.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns></returns>
        public Area Add(string areaName)
        {
            var area = new Area()
            {
                Name         = areaName,
                CreatedUser  = IdentityProvider.GetUserName(),
                ModifiedUser = IdentityProvider.GetUserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedDate = DateProvider.Now()
            };

            return StorageProvider.Add(area);
        }

        /// <summary>
        /// Gets all areas.
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAll()
        {
            return StorageProvider.GetAllAreas();
        }

        /// <summary>
        /// Gets the specified area given the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Area Get(int id)
        {
            return StorageProvider.GetArea(id);
        }

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns></returns>
        public Area Update(Area area)
        {
            if (area != null)
            {
                area.ModifiedUser = IdentityProvider.GetUserName();
                area.ModifiedDate = DateProvider.Now();
                return StorageProvider.Update(area);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the specified area given the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(int id)
        {
            var area = Get(id);

            if (area != null)
            {
                area.ModifiedDate = DateProvider.Now();
                area.ModifiedUser = IdentityProvider.GetUserName();

                StorageProvider.RemoveArea(area);
            }
        }
    }
}
