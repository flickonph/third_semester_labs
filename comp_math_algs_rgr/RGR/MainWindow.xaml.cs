using System.Collections.Generic;
using System.Windows;
using RGR_BLL;

namespace RGR;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddToList_OnClick(object sender, RoutedEventArgs e)
    {
        ListBox.Items.Add(new Product(double.Parse(X1Ammount.Text), double.Parse(x2ammount.Text), double.Parse(x3ammount.Text), double.Parse(Qammount.Text)));
        X1Ammount.Text = "0";
        x2ammount.Text = "0";
        x3ammount.Text = "0";
        Qammount.Text = "0";
    }

    private void ClearButton_OnClick(object sender, RoutedEventArgs e)
    {
        ListBox.Items.Clear();
        Calc.Test();
    }

    private List<Product> Products()
    {
        List<Product> products = new List<Product>();
        foreach (var item in ListBox.Items)
        {
            if (item is Product product)
            {
                products.Add(product);
            }
        }
        
        return products;
    }

    private void AddToRes_OnClick(object sender, RoutedEventArgs e)
    {
        var product = Calc.ResProduct(Products(), new Product(
            double.Parse(x1res.Text),
            double.Parse(x2res.Text),
            double.Parse(x3res.Text),
            0.0));
        
        ResBox.Items.Add(product);
        
        x1res.Text = "0";
        x2res.Text = "0";
        x3res.Text = "0";
    }
}