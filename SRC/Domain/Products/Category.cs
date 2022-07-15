using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Contract();
    }

    public void Edit(Category category, string name, bool active, string editedBy)
    {
        category.Name = name;
        category.Active = active;
        category.EditedBy = editedBy;
        category.EditedOn = DateTime.Now;

        Contract();
    }


    //ContratoDeValidação
    private void Contract()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name")
                    .IsNotNullOrEmpty(EditedBy, "EditedBy")
                    .IsNotNullOrEmpty(CreatedBy, "CreatedBy");
        
        AddNotifications(contract);
    }
}

