using ASystem.Enum;
using ASystem.Models.Component;
using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Models.View
{
    public class HomeViewModel
    {
        public IndexViewModel Index { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
    }
}