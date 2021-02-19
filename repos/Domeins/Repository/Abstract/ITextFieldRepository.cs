using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Entities;

namespace repos.Domeins.Repository.Abstract
{
    public interface ITextFieldRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldByID(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
