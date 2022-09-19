using FastFoodDemo.Constants;
using FastFoodDemo.Entities;
using FastFoodDemo.ViewModels.GenericList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainpanel.Visible = false;

            ///llenar con base de datos
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

            if (GenericListProducts.ProductsDrinks is null || GenericListProducts.ProductsDrinks.Count == 0)
            {
                GenericListProducts.ProductsDrinks = Products.Where(x => x.Category == CategoryConstants.Drinks).ToList();
            }

            if (GenericListProducts.ProductsFoods is null || GenericListProducts.ProductsFoods.Count == 0)
            {
                GenericListProducts.ProductsFoods = Products.Where(x => x.Category == CategoryConstants.Foods).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            GenericListProducts.startIndexProduct = 0;
            GenericListProducts.endIndexProduct = 0;
            loadform(new FoodListForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            GenericListProducts.startIndexProduct = 0;
            GenericListProducts.endIndexProduct = 0;
            loadform(new DrinkListForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesForm sales = new SalesForm();
            sales.lblSales.Text = "Delivery";
            sales.lblSales.ForeColor = Color.Black;
            sales.panelIdentify.BackColor = Color.CornflowerBlue;
            mainpanel.Visible = true;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            loadform(sales);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManagerProductForm form = new ManagerProductForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesForm sales = new SalesForm();
            sales.lblSales.Text = "Ventas";
            sales.lblSales.ForeColor = Color.Black;
            sales.panelIdentify.BackColor = Color.ForestGreen;
            mainpanel.Visible = true;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            loadform(sales);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
    }
}
