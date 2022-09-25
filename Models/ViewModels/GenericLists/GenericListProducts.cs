using FastFood.Models.Entities;
using System.Collections.Generic;

namespace Models.ViewModels.GenericLists
{
    public static class GenericLists
    {
        public static List<SalesDetails> SelectedItems { get; set; }

        public static int startIndexProduct = 0;
        public static int endIndexProduct = 0;
    }
}
