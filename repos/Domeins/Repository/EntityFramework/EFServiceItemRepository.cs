using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Repository.Abstract;
using repos.Domeins.Entities;
using Microsoft.EntityFrameworkCore;
using repos.Domeins;


namespace repos.Domeins.Repository.EntityFramework
{
    public class EFServiceItemRepository:IServiceItemRepository
    {
        private readonly ApDbContext context;
        public EFServiceItemRepository(ApDbContext context)
        {
            this.context = context;
        }
        public IQueryable<ServiceItem> GetServiceItems()
        { return context.ServiceItems; }
        public ServiceItem GetServiceItemByID(Guid id)
        { return context.ServiceItems.FirstOrDefault(x => x.Id == id); }
        public ServiceItem GetServiceItemByCodeWord(string codeWord)
        { return context.ServiceItems.FirstOrDefault(x => x.CodeWord == codeWord); }


        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

        }
        public void DeleteServiseItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }
    }
}
