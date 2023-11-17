// create a "products" variable here to include at least five Product instances. 
// Give them appropriate ProductTypeIds.------------------------------------------
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

//create a "productTypes" variable here with a List of ProductTypes
// add "Brass" and "Poem" types to the List. -------------------------------------
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

//----------------------put your greeting here------------------------------------
Console.WriteLine(@$"

                Welcome to Brass & Poem
                    
    Antique Brass Instruments and Rare Poetry Collections.

");

//--------------------implement your loop here------------------------------------
DisplayMenu();

// ---------------------------Main Menu-------------------------------------------
void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(@$"   Please enter a NUMBER for how you would like to proceed:
            1. Display all products
            2. Delete a product
            3. Add a new product
            4. Update product properties
            5. Exit");

        choice = Console.ReadLine().Trim();

        if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine(@$"

-------------------------------------------------------  

        I KNEW you weren't the artistic type!!!
                    
               Leave my shop at once!!!

        *slams door and flips sign to CLOSED*

-------------------------------------------------------
            ");
        }
        else
        {
            Console.WriteLine(@$"
            
    Please enter a valid input...
            ");
        }
    }
}

// ----------------------List of all products-------------------------------------
void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"   All Products:");
    int num = 0;
    foreach (Product product in products)
    {
        ProductType pType = productTypes.FirstOrDefault((pt) => pt.Id == product.ProductTypeId);
        num++;
        Console.WriteLine(@$"       {num}. {product.Name} - ${product.Price} - {pType.Title}");
    }
    Console.WriteLine(@"
    ");
}

// ------------------"Form" to delete a product-----------------------------------
void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Product chosenProductToRemove = null;
    while (chosenProductToRemove == null)
    {
        DisplayAllProducts(products, productTypes);
        Console.WriteLine(@"
    Choose a product to delete:
    ");
        try
        {
            int deleteInput = int.Parse(Console.ReadLine());
            chosenProductToRemove = products[deleteInput - 1];
            products.RemoveAt(deleteInput - 1);
            Console.WriteLine(@$"
            
            You chose to remove: 

                {chosenProductToRemove.Name}

            ");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
    DisplayAllProducts(products, productTypes);
}

// ---------------------"Form" to add a product-----------------------------------
void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    // ----------Choose Produce NAME---------------
    bool inputIsNumber = true;
    string nameResponse = null;
    while (string.IsNullOrWhiteSpace(nameResponse) || inputIsNumber)
    {
        Console.WriteLine($@"
    Please enter the name of your product: ");
        nameResponse = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(nameResponse))
        {
            Console.WriteLine(@"    
Please enter a VALID product name, which cannot be exclusively numbers...
");
        }
        else if (int.TryParse(nameResponse, out _))
        {
            Console.WriteLine(@$"Your product name cannot be exclusively numbers...");
        }
        else
        {
            inputIsNumber = false;
        }
    }
    Console.WriteLine(@$"
    New product name: {nameResponse}. 
    ");

    // ----------Choose Product PRICE--------------
    decimal priceResponse = 0;
    while (priceResponse == 0)
    {
        Console.WriteLine(@"
    Please enter the price of your product: ");
        try
        {
            priceResponse = decimal.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine(@"    Only enter numbers greater than 0.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(@$" Exception: {ex}... Format answer using ONLY NUMBERS GREATER THAN ZERO!");
        }
    }
    Console.WriteLine(@$"   
    You entered ${priceResponse} as your price.
    ");

    // ----------Choose Product TypeId-------------
    int productTypeInput = 0;
    Console.WriteLine(@"
    Current Product Types:");

    // lists the product types
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine(@$"       {productType.Id}. {productType.Title}");
    }

    // checks if input matches a product type
    while (productTypeInput < 1 || productTypeInput > productTypes.Count)
    {
        Console.WriteLine(@$"   
    Enter the number correlating to the product type you would like to add...");
        try
        {
            productTypeInput = int.Parse(Console.ReadLine().Trim());
        }
        catch (Exception)
        {
            Console.WriteLine(@$"
    Please only enter a corresponding number to the product type.");
        }
    }

    ProductType matchingType = productTypes.FirstOrDefault(pt => productTypeInput == pt.Id);

    Console.WriteLine(@$"
    You chose {matchingType.Id}. {matchingType.Title}.
    ");


    // show Product which was just created--------------------
    Console.WriteLine(@$"
    Product to be added:
        Name = {nameResponse}
        Price = {priceResponse}
        Type = {matchingType.Title}");
    int confirm = 0;
    while (confirm == 0)
    {
        Console.WriteLine(@"
    Press 1 to confirm or 2 to try again...");
        confirm = int.Parse(Console.ReadLine().Trim());
        if (confirm == 1)
        {
            products.Add(new Product()
            {
                Name = nameResponse,
                Price = priceResponse,
                ProductTypeId = matchingType.Id,
            });
            Console.WriteLine(@"    Thank you for your addition!");
            break;
        }
        if (confirm == 2)
        {
            DisplayMenu();
            break;
        }
        else
        {
            Console.WriteLine(@$"Please only enter a 1 or 2 as selection.
            ");
            confirm = 0;
        }
    }
}

// ----------------"Form" to update a product's details---------------------------
void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Product chosenProductToUpdate = null;
    DisplayAllProducts(products, productTypes);
    Console.WriteLine(@"
Choose a product to update:");

    while (chosenProductToUpdate == null)
    {
        try
        {
            int updateInput = int.Parse(Console.ReadLine());
            chosenProductToUpdate = products[updateInput - 1];
            ProductType matchingType = productTypes.FirstOrDefault(pt => pt.Id == chosenProductToUpdate.ProductTypeId);
            Console.WriteLine(@$"You chose to edit: 

    {chosenProductToUpdate.Name}
    Price: ${chosenProductToUpdate.Price}
    Type: {matchingType.Title}
    ");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    string newName = null;
    decimal newPrice = 0;
    int newType = 0;
    bool nameIsNumber = true;

    // edit NAME----------------------------------------------------------
    while (newName == null)
    {
        Console.WriteLine($"Previous name for product: {chosenProductToUpdate.Name}");
        Console.WriteLine(@$"Enter new name for product:");
        newName = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(newName))
        {

            Console.WriteLine(@"    
Please enter a VALID product name, which cannot be exclusively numbers...
");
        }
        else if (int.TryParse(newName, out _))
        {
            Console.WriteLine(@$"Your product name cannot be exclusively numbers...");
        }
        else
        {
            nameIsNumber = false;
        }
        Console.WriteLine(@$"   New Product Name: {newName}. 
        ");
        chosenProductToUpdate.Name = newName;
    };

    // Edit PRICE ------------------------------------------------------
    while (newPrice == 0)
    {
        Console.WriteLine(@$"
Previous price of product: ${chosenProductToUpdate.Price}.
Input new asking price using only numbers:");
        try
        {
            newPrice = decimal.Parse(Console.ReadLine().Trim());
        }
        catch (Exception)
        {
            Console.WriteLine(@$"Please only enter numbers for your price.");
        }
    }

    Console.WriteLine(@$"
    New Price: ${newPrice}.
        ");
    chosenProductToUpdate.Price = newPrice;

    // Edit ProductTypeId---------------------------------------------
    ProductType mT = productTypes.FirstOrDefault(pt => pt.Id == chosenProductToUpdate.ProductTypeId);
    Console.WriteLine(@$"Current Product Type: {mT.Title}");
    while (newType < 1 || newType > 2)
    {
        Console.WriteLine(@$"
Please enter a new product type:");
        // lists the product types-----------------------------
        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine(@$"   {productType.Id}. {productType.Title}");
        }
        //Checks input to make sure it's a number------------
        try
        {
            newType = int.Parse(Console.ReadLine().Trim());
            chosenProductToUpdate.ProductTypeId = newType;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please use valid numbers with no whitespace...");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("No object matches.. select 1 or 2 only..");
        }
        catch (Exception)
        {
            Console.WriteLine("Only enter 1 or 2 to change type");
        }
    }
    DisplayAllProducts(products, productTypes);
    DisplayMenu();
}

// --------------------don't move or change this!---------------------------------
public partial class Program { }