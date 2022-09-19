using Infrastructure.Constants;
using Models.Entities;
using Models.ViewModels;
using Models.ViewModels.GenericLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class FoodListForm : Form
    {
        public List<Product> ProductsList { get; set; }
        public int ProductId { get; set; }

        public FoodListForm()
        {
            InitializeComponent();
        }

        private void FoodListForm_Load(object sender, EventArgs e)
        {
            panelManager.Visible = false;

            if (GenericLists.SeletedItems is null)
                GenericLists.SeletedItems = new List<SeletedItem>();

            GetListItems(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var listItems = new List<ItemsDTO>();
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && GenericLists.ProductsFoods != null)
                ProductsList = GenericLists.ProductsFoods.Where(x => x.Name.ToLower().Contains(txtSearch.Text.ToLower())).Take(6).ToList();
            else
                ProductsList = GenericLists.ProductsFoods.Take(6).ToList();

            if (ProductsList != null && ProductsList.Count > 0)
            {
                foreach (var x in ProductsList)
                {
                    var item = new ItemsDTO
                    {
                        Description = x.Description,
                        Price = x.SalesPrice.ToString(),
                        ProductId = x.ProductId,
                        Tittle = x.Name,
                        ImageName = string.IsNullOrWhiteSpace(x.ImageName) ? x.ImageName : string.Empty
                    };

                    listItems.Add(item);
                }

                GenericLists.startIndexProduct = listItems.FirstOrDefault().ProductId;
                GenericLists.endIndexProduct = listItems.LastOrDefault().ProductId;
            }

            var panelCount = 0;
            if (listItems != null && listItems.Count() > 0)
                panelCount = listItems.Count();

            panelsShow(panelCount);
            panelsLoad(listItems);
            loadCounterstxt();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int lastProduct = 5;
            if (GenericLists.endIndexProduct != 0)
            {
                lastProduct = GenericLists.ProductsFoods.FindIndex(a => a.ProductId == GenericLists.endIndexProduct);
            }

            GetListItems(lastProduct);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int firtProduct = 0;
            if (GenericLists.startIndexProduct != 0 && GenericLists.endIndexProduct != 0)
            {
                firtProduct = GenericLists.ProductsFoods.FindIndex(a => a.ProductId == GenericLists.startIndexProduct);
            }

            GetListItems(firtProduct);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ProductId > 0)
            {
                var product = ProductsList.FirstOrDefault(x => x.ProductId == ProductId);
                ManagerProductForm form = new ManagerProductForm();
                form.lblProductId.Text = product?.ProductId.ToString();
                form.txtProducto.Text = product?.Name;
                form.txtMarca.Text = product?.Description;
                form.txtPCompra.Text = product?.BayPrice.ToString();
                form.txtPVenta.Text = product?.SalesPrice.ToString();
                form.txtStock.Text = product?.Stock.ToString();
                form.txtType.Text = product?.Type;
                form.lblcategory.Text = product.Category;
                form.Show();
                panelManager.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está Seguro que Desea Eliminar este Producto.?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (ProductsList != null)
                {
                    var product = ProductsList.FirstOrDefault(x => x.ProductId == ProductId);
                    if (product != null)
                    {
                        ProductsList.Remove(product);
                        GenericLists.ProductsFoods.Remove(product);
                        RefreshList();
                    }
                }

                panelManager.Visible = false;
            }
        }

        #region Button Less And Plus
        private void btnLess1_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity1.Text);
            if (quantity > 1)
                txtQuantity1.Text = (quantity - 1).ToString();
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity1.Text);
            if (quantity >= 1)
                txtQuantity1.Text = (quantity + 1).ToString();
        }

        private void btnLess2_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity2.Text);
            if (quantity > 1)
                txtQuantity2.Text = (quantity - 1).ToString();
        }

        private void btnPlus2_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity2.Text);
            if (quantity >= 1)
                txtQuantity2.Text = (quantity + 1).ToString();
        }

        private void btnLess3_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity3.Text);
            if (quantity > 1)
                txtQuantity3.Text = (quantity - 1).ToString();
        }

        private void btnPlus3_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity3.Text);
            if (quantity >= 1)
                txtQuantity3.Text = (quantity + 1).ToString();
        }

        private void btnLess4_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity4.Text);
            if (quantity > 1)
                txtQuantity4.Text = (quantity - 1).ToString();
        }

        private void btnPlus4_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity4.Text);
            if (quantity >= 1)
                txtQuantity4.Text = (quantity + 1).ToString();
        }

        private void btnLess5_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity5.Text);
            if (quantity > 1)
                txtQuantity5.Text = (quantity - 1).ToString();
        }

        private void btnPlus5_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity5.Text);
            if (quantity >= 1)
                txtQuantity5.Text = (quantity + 1).ToString();
        }

        private void btnLess6_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity6.Text);
            if (quantity > 1)
                txtQuantity6.Text = (quantity - 1).ToString();
        }

        private void btnPlus6_Click(object sender, EventArgs e)
        {
            var quantity = Convert.ToInt32(txtQuantity6.Text);
            if (quantity >= 1)
                txtQuantity6.Text = (quantity + 1).ToString();
        }
        #endregion

        #region Helpers
        private void GetListItems(int skip)
        {
            var listItems = new List<ItemsDTO>();

            if (ProductsList is null)
                ProductsList = GenericLists.ProductsFoods;

            if (GenericLists.ProductsFoods != null || GenericLists.ProductsFoods.Count > 0)
            {
                var newSearch = ProductsList.Skip(skip).Take(6).ToList();
                var Products = newSearch != null && newSearch.Count > 2 ? newSearch.ToList() : ProductsList.ToList();
                if (Products != null || Products.Count > 0)
                {
                    foreach (var x in Products)
                    {
                        var item = new ItemsDTO
                        {
                            Description = x.Description,
                            Price = x.SalesPrice.ToString(),
                            ProductId = x.ProductId,
                            Tittle = x.Name,
                            ImageName = string.IsNullOrWhiteSpace(x.ImageName) ? x.ImageName : string.Empty
                        };

                        listItems.Add(item);
                    }

                    GenericLists.startIndexProduct = listItems.FirstOrDefault().ProductId;
                    GenericLists.endIndexProduct = listItems.LastOrDefault().ProductId;
                }
            }

            var panelCount = 0;
            if (listItems != null && listItems.Count() > 0)
                panelCount = listItems.Count();

            panelsShow(panelCount);
            panelsLoad(listItems);
            loadCounterstxt();
        }

        private void panelsShow(int count)
        {
            panel1.Visible = count > 0;
            panel2.Visible = count > 1;
            panel3.Visible = count > 2;

            panel4.Visible = count > 3;
            panel5.Visible = count > 4;
            panel6.Visible = count > 5;
        }

        private void panelsLoad(List<ItemsDTO> items)
        {
            foreach (var item in items)
            {
                //Panel1
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 0)
                {
                    lblProductId1.Text = item.ProductId.ToString();
                    lblProductName1.Text = item.Tittle;
                    lblDescriptionProduct1.Text = item.Description;
                    lblPrice1.Text = item.Price;
                }
                //Panel2
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 1)
                {
                    lblProductId2.Text = item.ProductId.ToString();
                    lblProductName2.Text = item.Tittle;
                    lblDescriptionProduct2.Text = item.Description;
                    lblPrice2.Text = item.Price;
                }
                //Panel3
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 2)
                {
                    lblProductId3.Text = item.ProductId.ToString();
                    lblProductName3.Text = item.Tittle;
                    lblDescriptionProduct3.Text = item.Description;
                    lblPrice3.Text = item.Price;
                }
                //Panel4
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 3)
                {
                    lblProductId4.Text = item.ProductId.ToString();
                    lblProductName4.Text = item.Tittle;
                    lblDescriptionProduct4.Text = item.Description;
                    lblPrice4.Text = item.Price;
                }
                //Panel5
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 4)
                {
                    lblProductId5.Text = item.ProductId.ToString();
                    lblProductName5.Text = item.Tittle;
                    lblDescriptionProduct5.Text = item.Description;
                    lblPrice5.Text = item.Price;
                }
                //Panel6
                if (items.FindIndex(a => a.ProductId == item.ProductId) == 5)
                {
                    lblProductId6.Text = item.ProductId.ToString();
                    lblProductName6.Text = item.Tittle;
                    lblDescriptionProduct6.Text = item.Description;
                    lblPrice6.Text = item.Price;
                }
            }
        }

        private void loadCounterstxt()
        {
            txtQuantity1.Text = 1.ToString();
            txtQuantity2.Text = 1.ToString();
            txtQuantity3.Text = 1.ToString();

            txtQuantity4.Text = 1.ToString();
            txtQuantity5.Text = 1.ToString();
            txtQuantity6.Text = 1.ToString();
        }

        public void RefreshList()
        {
            GetListItems(0);
        }
        #endregion

        #region Panel Manager
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId1.Text);
            panelManager.Visible = true;
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId2.Text);
            panelManager.Visible = true;
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId3.Text);
            panelManager.Visible = true;
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId4.Text);
            panelManager.Visible = true;
        }

        private void panel5_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId5.Text);
            panelManager.Visible = true;
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {
            ProductId = Convert.ToInt32(lblProductId6.Text);
            panelManager.Visible = true;
        }
        #endregion

        #region Agregar Producto
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId1.Text);
            product.Name = lblProductName1.Text;
            product.Price = Convert.ToDecimal(lblPrice1.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity1.Text);
            product.Category = CategoryConstants.Foods;

            if (GenericLists.SeletedItems is null)
                GenericLists.SeletedItems = new List<SeletedItem>();

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId2.Text);
            product.Name = lblProductName2.Text;
            product.Price = Convert.ToDecimal(lblPrice2.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity2.Text);
            product.Category = CategoryConstants.Foods;

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }

        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId3.Text);
            product.Name = lblProductName3.Text;
            product.Price = Convert.ToDecimal(lblPrice3.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity3.Text);
            product.Category = CategoryConstants.Foods;

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }

        private void btnAgregar4_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId4.Text);
            product.Name = lblProductName4.Text;
            product.Price = Convert.ToDecimal(lblPrice4.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity4.Text);
            product.Category = CategoryConstants.Foods;

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }

        private void btnAgregar5_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId5.Text);
            product.Name = lblProductName5.Text;
            product.Price = Convert.ToDecimal(lblPrice5.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity5.Text);
            product.Category = CategoryConstants.Foods;

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }

        private void btnAgregar6_Click(object sender, EventArgs e)
        {
            SeletedItem product = new SeletedItem();
            product.Id = Convert.ToInt32(lblProductId6.Text);
            product.Name = lblProductName6.Text;
            product.Price = Convert.ToDecimal(lblPrice6.Text);
            product.Quantity = Convert.ToDecimal(txtQuantity6.Text);
            product.Category = CategoryConstants.Foods;

            var prod = GenericLists.SeletedItems.FirstOrDefault(x => x.Id == product.Id);
            if (prod is null)
                GenericLists.SeletedItems.Add(product);
            else
                MessageBox.Show("El producto ya fue agregado");
        }
        #endregion

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
