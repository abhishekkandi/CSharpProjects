using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace OCPDemo
{
    /* SOLID Principles */
    /* O - Open for extension but closed for modification(OCP) - */

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    //Below class voilates OCP
    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
                if (product.Color == color)
                    yield return product;
        }

        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
                if (product.Size == size)
                    yield return product;
        }

        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var product in products)
                if (product.Size == size && product.Color == color)
                    yield return product;
        }
    }

    //To follow OC, we introduce two new interface
    public interface ISpecification<T>
    {
        bool IsSatisfied(Product product);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specifaction);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            this._color = color;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            this._size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Size == _size;
        }
    }

    //combinator 
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _firstSpecification, _secondSpecification;

        public AndSpecification(ISpecification<T> firstSpecification, ISpecification<T> secondSpecification)
        {
            this._firstSpecification = firstSpecification ?? throw new ArgumentNullException(paramName: nameof(firstSpecification));
            this._secondSpecification = secondSpecification ?? throw new ArgumentNullException(paramName: nameof(secondSpecification));
        }

        public bool IsSatisfied(Product product)
        {
            return _firstSpecification.IsSatisfied(product) && _secondSpecification.IsSatisfied(product);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
        {
            foreach (var product in products)
                if (specification.IsSatisfied(product))
                    yield return product;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            /* Invoking filter which doesn't follow OCP */
            var productFilter = new ProductFilter();
            WriteLine("Green products (old):");
            foreach (var product in productFilter.FilterByColor(products, Color.Green))
                WriteLine($" - {product.Name} is green");

            /* Invoking filter which follows OCP */
            var bf = new BetterFilter();
            WriteLine("Green products (new):");
            foreach (var product in bf.Filter(products, new ColorSpecification(Color.Green)))
                WriteLine($" - {product.Name} is green");

            WriteLine("Large products");
            foreach (var product in bf.Filter(products, new SizeSpecification(Size.Large)))
                WriteLine($"- {product.Name} is large");

            WriteLine("Large blue items");
            foreach (var product in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
                WriteLine($" - {product.Name} is large and blue");

            ReadKey();
        }
    }
}
