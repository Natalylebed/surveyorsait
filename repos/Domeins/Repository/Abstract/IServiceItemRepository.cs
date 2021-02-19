using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Entities;


namespace repos.Domeins.Repository.Abstract
{
    public interface IServiceItemRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemByID(Guid id);
        ServiceItem GetServiceItemByCodeWord(string codeWord);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiseItem(Guid id);
    }
}
