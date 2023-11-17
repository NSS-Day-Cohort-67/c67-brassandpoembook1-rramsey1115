
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new()
    {
        Name = "Sackbut",
        Price = 2550.50M,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Bass Saxhorn",
        Price = 2900.00M,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Sarrusaphone",
        Price = 2250.99M,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Ophicleide",
        Price = 4100.00M,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Cimbasso",
        Price = 3100.00M,
        ProductTypeId = 1
    },
    new()
    {
        Name = "The Illiad",
        Price = 3000.00M,
        ProductTypeId = 2
    },
    new()
    {
        Name = "Leaves of Grass",
        Price = 1600.00M,
        ProductTypeId = 2
    },
    new()
    {
        Name = "The Wate Land",
        Price = 900.25M,
        ProductTypeId = 2
    },
    new()
    {
        Name = "Selections of Poetical Works of Robert Browning",
        Price = 4235.00M,
        ProductTypeId = 2
    },
    new()
    {
        Name = "Guillaume Apollinaire's Poems",
        Price = 3499.99M,
        ProductTypeId = 2
    }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new()
    {
        Title = "Brass Instrument",
        Id = 1
    },
    new()
    {
        Title = "Poetry Book",
        Id = 2
    }
};

//put your greeting here
Console.WriteLine(@$"
                    Welcome to Brass & Poem
                    
Industry leader in antique brass instruments and rare poetry collections.

");

//implement your loop here
int input = 0;
while (input != 5)
{
    DisplayMenu();
    Console.WriteLine(@$"Select a NUMBER from above to navigate our site...");
}

void DisplayMenu()
{
    throw new NotImplementedException();
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }