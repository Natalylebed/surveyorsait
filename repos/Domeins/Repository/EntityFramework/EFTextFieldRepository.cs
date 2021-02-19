using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Repository.Abstract;
using repos.Domeins.Entities;
using Microsoft.EntityFrameworkCore;

namespace repos.Domeins.Repository.EntityFramework
{
    public class EFTextFieldRepository:ITextFieldRepository
    {
        private readonly ApDbContext context;
        public EFTextFieldRepository(ApDbContext context)
        {
            this.context = context;
        }
        public IQueryable<TextField> GetTextFields()
        { return context.TextFields; }
        public TextField GetTextFieldByID(Guid id)
        { return context.TextFields.FirstOrDefault(x => x.Id == id); }

        public TextField GetTextFieldByCodeWord(string codeWord)
        { return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord); }
        public void SaveTextField(TextField entity)
        { if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
                    
        }
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id=id}) ;
            context.SaveChanges();
        }

    }
}
