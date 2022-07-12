namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name;
    public Guid Id { get; set; }
    public bool Active { get; set; } = true;

    public Category(string name)
    {
        Name = name;
    }
}
    
