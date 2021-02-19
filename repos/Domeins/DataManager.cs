using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Repository.Abstract;

namespace repos.Domeins
{
    public class DataManager
    {
        public ITextFieldRepository TextFields { get; set; }
        public IServiceItemRepository ServiceItems { get; set; }
        public DataManager (ITextFieldRepository textFieldRepository,IServiceItemRepository serviceItemRepository)
        {
            TextFields = textFieldRepository;
            ServiceItems = serviceItemRepository;
        }
    }
}
