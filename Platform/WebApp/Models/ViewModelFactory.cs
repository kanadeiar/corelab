namespace WebApp.Models;

public static class ViewModelFactory
{
    public static ProductWebModel Details(Product p)
    {
        var model = new ProductWebModel
        {
            Product = p,
            Title = "Детали",
            Action = "Details",
            ReadOnly = true,
            Theme = "info",
            ShowAction = false,
            Categories = p is null || p.Category == null
                ? Enumerable.Empty<Category>()
                : new List<Category> { p.Category },
            Suppliers = p is null || p.Suppliler == null
                ? Enumerable.Empty<Supplier>()
                : new List<Supplier> { p.Suppliler },
        };
        return model;
    }

    public static ProductWebModel Create(Product p, IEnumerable<Category> categories, IEnumerable<Supplier> suppliers)
    {
        var model = new ProductWebModel
        {
            Product = p,
            Categories = categories,
            Suppliers = suppliers,
        };
        return model;
    }

    public static ProductWebModel Edit(Product p, IEnumerable<Category> categories, IEnumerable<Supplier> suppliers)
    {
        var model = new ProductWebModel
        {
            Product = p,
            Title = "Редактирование",
            Action = "Edit",
            Theme = "warning",
            Categories = categories,
            Suppliers = suppliers,
        };
        return model;
    }

    public static ProductWebModel Delete(Product p, IEnumerable<Category> categories, IEnumerable<Supplier> suppliers)
    {
        var model = new ProductWebModel
        {
            Product = p,
            Title = "Удаление",
            Action = "Delete",
            Theme = "danger",
            Categories = categories,
            Suppliers = suppliers,
        };
        return model;
    }
}
