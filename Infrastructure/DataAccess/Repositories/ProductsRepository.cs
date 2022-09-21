using Infrastructure.Constants;
using Models.Entities;
using Models.ViewModels.GenericLists;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repositories
{
    public class ProductsRepository
    {
        public (List<Product>, string) GetProducts()
        {
            var Products = new List<Product>();
            try
            {
                if (Products is null || Products.Count == 0)
                {

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Mediana", SalesPrice = 125, Description = "Verde", ProductId = 1 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Jumbo", SalesPrice = 235, Description = "Verde", ProductId = 2 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo verde", Type = "Jumbo", SalesPrice = 225, Description = "Verde", ProductId = 3 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Cocacola", Type = "Normal", SalesPrice = 80, Description = "Rojo", ProductId = 4 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Cascada", Type = "Normal", SalesPrice = 35, Description = "Transparente", ProductId = 5 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente", Type = "Jumbo", SalesPrice = 115, Description = "Verde", ProductId = 6 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Mediana", SalesPrice = 135, Description = "Amarilla", ProductId = 13 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Jumbo", SalesPrice = 245, Description = "Amarilla", ProductId = 14 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo Piña", Type = "Jumbo", SalesPrice = 225, Description = "Amarilla", ProductId = 15 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Pepsi", Type = "Normal", SalesPrice = 70, Description = "Rojo", ProductId = 16 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Peñantial", Type = "Normal", SalesPrice = 25, Description = "Transparente", ProductId = 17 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama", Type = "Jumbo", SalesPrice = 100, Description = "Verde", ProductId = 18 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Verde", ProductId = 7 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 200, Description = "Jamon y Queso", ProductId = 8 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Grande", SalesPrice = 60, Description = "Verde", ProductId = 9 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 150, Description = "Con maiz", ProductId = 10 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Grande", SalesPrice = 65, Description = "Chocolate", ProductId = 11 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Pequeña", SalesPrice = 350, Description = "Peperoni", ProductId = 12 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Roja", ProductId = 18 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 250, Description = "Doble queso", ProductId = 19 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Normal", SalesPrice = 25, Description = "Azul", ProductId = 20 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 120, Description = "Sin maiz", ProductId = 21 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Normal", SalesPrice = 45, Description = "Vainilla", ProductId = 22 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Grande", SalesPrice = 750, Description = "Maiz", ProductId = 23 });
                }

                return (Products, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Products, "Error al Cargar Data, Metodo ProductsRepository.GetProducts \n" + ex.Message.ToString());
            }
        }

        public (Product, string) GetProductById(int id)
        {
            try
            {
                var Products = new List<Product>();
                if (Products is null || Products.Count == 0)
                {

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Mediana", SalesPrice = 125, Description = "Verde", ProductId = 1 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Jumbo", SalesPrice = 235, Description = "Verde", ProductId = 2 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo verde", Type = "Jumbo", SalesPrice = 225, Description = "Verde", ProductId = 3 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Cocacola", Type = "Normal", SalesPrice = 80, Description = "Rojo", ProductId = 4 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Cascada", Type = "Normal", SalesPrice = 35, Description = "Transparente", ProductId = 5 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente", Type = "Jumbo", SalesPrice = 115, Description = "Verde", ProductId = 6 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Mediana", SalesPrice = 135, Description = "Amarilla", ProductId = 13 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Jumbo", SalesPrice = 245, Description = "Amarilla", ProductId = 14 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo Piña", Type = "Jumbo", SalesPrice = 225, Description = "Amarilla", ProductId = 15 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Pepsi", Type = "Normal", SalesPrice = 70, Description = "Rojo", ProductId = 16 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Peñantial", Type = "Normal", SalesPrice = 25, Description = "Transparente", ProductId = 17 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama", Type = "Jumbo", SalesPrice = 100, Description = "Verde", ProductId = 18 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Verde", ProductId = 7 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 200, Description = "Jamon y Queso", ProductId = 8 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Grande", SalesPrice = 60, Description = "Verde", ProductId = 9 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 150, Description = "Con maiz", ProductId = 10 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Grande", SalesPrice = 65, Description = "Chocolate", ProductId = 11 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Pequeña", SalesPrice = 350, Description = "Peperoni", ProductId = 12 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Roja", ProductId = 18 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 250, Description = "Doble queso", ProductId = 19 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Normal", SalesPrice = 25, Description = "Azul", ProductId = 20 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 120, Description = "Sin maiz", ProductId = 21 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Normal", SalesPrice = 45, Description = "Vainilla", ProductId = 22 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Grande", SalesPrice = 750, Description = "Maiz", ProductId = 23 });
                }

                var product = Products.FirstOrDefault(x => x.ProductId == id);
                return (product, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new Product(), "Error al Cargar Data, Metodo ProductsRepository.GetProductById \n" + ex.Message.ToString());
            }
        }

        public (List<Product>, string) GetProductByCategory(string category)
        {
            var Products = new List<Product>();
            try
            {
                if (Products is null || Products.Count == 0)
                {

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Mediana", SalesPrice = 125, Description = "Verde", ProductId = 1 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente lithg", Type = "Jumbo", SalesPrice = 235, Description = "Verde", ProductId = 2 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo verde", Type = "Jumbo", SalesPrice = 225, Description = "Verde", ProductId = 3 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Cocacola", Type = "Normal", SalesPrice = 80, Description = "Rojo", ProductId = 4 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Cascada", Type = "Normal", SalesPrice = 35, Description = "Transparente", ProductId = 5 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Presidente", Type = "Jumbo", SalesPrice = 115, Description = "Verde", ProductId = 6 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Mediana", SalesPrice = 135, Description = "Amarilla", ProductId = 13 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama lithg", Type = "Jumbo", SalesPrice = 245, Description = "Amarilla", ProductId = 14 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Jugo Piña", Type = "Jumbo", SalesPrice = 225, Description = "Amarilla", ProductId = 15 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Refrezco Pepsi", Type = "Normal", SalesPrice = 70, Description = "Rojo", ProductId = 16 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Agua Peñantial", Type = "Normal", SalesPrice = 25, Description = "Transparente", ProductId = 17 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Bebida", Name = "Brama", Type = "Jumbo", SalesPrice = 100, Description = "Verde", ProductId = 18 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Verde", ProductId = 7 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 200, Description = "Jamon y Queso", ProductId = 8 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Grande", SalesPrice = 60, Description = "Verde", ProductId = 9 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 150, Description = "Con maiz", ProductId = 10 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Grande", SalesPrice = 65, Description = "Chocolate", ProductId = 11 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Pequeña", SalesPrice = 350, Description = "Peperoni", ProductId = 12 });

                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Papita", Type = "Mediana", SalesPrice = 105, Description = "Roja", ProductId = 18 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Tostada", Type = "Mediana", SalesPrice = 250, Description = "Doble queso", ProductId = 19 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "chicle", Type = "Normal", SalesPrice = 25, Description = "Azul", ProductId = 20 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Hot Dog", Type = "Grande", SalesPrice = 120, Description = "Sin maiz", ProductId = 21 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Dona", Type = "Normal", SalesPrice = 45, Description = "Vainilla", ProductId = 22 });
                    Products.Add(new Product() { Created = DateTime.Now, Updated = DateTime.Now, Category = "Comida", Name = "Pizza", Type = "Grande", SalesPrice = 750, Description = "Maiz", ProductId = 23 });
                }

                return (Products.Where(x => x.Category == category).ToList(), "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Products, "Error al Cargar Data, Metodo ProductsRepository.GetProductByCategory \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddProduct(Product input)
        {
            try
            {
                if (input == null)
                    return (false, "Input Invalido, Metodo ProductsRepository.AddProduct");

                if (input.Category == CategoryConstants.Drinks)
                {
                    var actual = GenericLists.ProductsDrinks.FirstOrDefault(x => x.ProductId == input.ProductId);
                    if (actual != null)
                        return (false, "Elemento existente en la lista Temporal, Metodo ProductsRepository.AddProduct" + CategoryConstants.Drinks);

                    GenericLists.ProductsDrinks.Add(input);
                }

                if (input.Category == CategoryConstants.Foods)
                {
                    var actual = GenericLists.ProductsFoods.FirstOrDefault(x => x.ProductId == input.ProductId);
                    if (actual != null)
                        return (false, "Elemento existente en la lista Temporal, Metodo ProductsRepository.AddProduct" + CategoryConstants.Foods);

                    GenericLists.ProductsFoods.Add(input);
                }

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.AddProduct \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateProduct(Product input)
        {
            try
            {
                if (input == null)
                    return (false, "Input Invalido, Metodo ProductsRepository.UpdateProduct");

                if (input.Category == CategoryConstants.Drinks)
                {
                    var actual = GenericLists.ProductsDrinks.FirstOrDefault(x => x.ProductId == input.ProductId);
                    if (actual is null)
                        return (false, "Elemento no existente en la lista Temporal, Metodo ProductsRepository.UpdateProduct" + CategoryConstants.Drinks);

                    GenericLists.ProductsDrinks.Remove(actual);
                    GenericLists.ProductsDrinks.Add(input);
                }

                if (input.Category == CategoryConstants.Foods)
                {
                    var actual = GenericLists.ProductsFoods.FirstOrDefault(x => x.ProductId == input.ProductId);
                    if (actual is null)
                        return (false, "Elemento no existente en la lista Temporal, Metodo ProductsRepository.UpdateProduct" + CategoryConstants.Foods);

                    GenericLists.ProductsFoods.Remove(actual);
                    GenericLists.ProductsFoods.Add(input);
                }

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.UpdateProduct \n" + ex.Message.ToString());
            }
        }

        public (bool, string) DeleteProductById(int id, string category)
        {
            try
            {
                if (id == 0 || string.IsNullOrWhiteSpace(category))
                    return (false, "Input Invalido, Metodo ProductsRepository.DeleteProductById");

                if (category == CategoryConstants.Drinks)
                {
                    var actual = GenericLists.ProductsDrinks.FirstOrDefault(x => x.ProductId == id);
                    if (actual is null)
                        return (false, "No se pudo encontrar correctamente a la lista Temporal, Metodo ProductsRepository.DeleteProductById" + CategoryConstants.Drinks);

                    GenericLists.ProductsDrinks.Remove(actual);
                }

                if (category == CategoryConstants.Foods)
                {
                    var actual = GenericLists.ProductsFoods.FirstOrDefault(x => x.ProductId == id);
                    if (actual is null)
                        return (false, "No se pudo encontrar correctamente a la lista Temporal, Metodo ProductsRepository.DeleteProductById" + CategoryConstants.Foods);

                    GenericLists.ProductsFoods.Remove(actual);
                }

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.DeleteProductById \n" + ex.Message.ToString());
            }
        }
    }
}
