using System;
using System.Linq;
using System.Windows;

namespace ExampleProductWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var product = new ExampleProductWpf.ProductList();
            MainGrind.Children.Add(product.Render());
        }
    }
}
