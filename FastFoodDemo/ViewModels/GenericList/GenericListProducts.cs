using FastFoodDemo.Entities;
using System.Collections.Generic;

namespace FastFoodDemo.ViewModels.GenericList
{
    public static class GenericListProducts
    {
        public static List<Product> ProductsFoods { get; set; }
        public static List<Product> ProductsDrinks { get; set; }
        public static List<SeletedItem> SeletedItems { get; set; }
        public static int startIndexProduct = 0;
        public static int endIndexProduct = 0;
    }
}
