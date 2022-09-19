using Models.Entities;
using System.Collections.Generic;

namespace Models.ViewModels.GenericLists
{
    public static class GenericLists
    {
        public static List<Product> ProductsFoods { get; set; }
        public static List<Product> ProductsDrinks { get; set; }
        public static List<SeletedItem> SeletedItems { get; set; }
        public static List<SalesCheck> SalesChecks { get; set; }
        public static int startIndexProduct = 0;
        public static int endIndexProduct = 0;
    }
}
