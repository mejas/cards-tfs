using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public interface IStorageProvider
    {
        List<Area> GetAllAreas();
        Area GetArea(int id);

        Area Add(Area area);
        Area Update(Area area);

        void RemoveArea(int id);
    }
}
