namespace PersonalFinanceAssistant.Utilities;

public static class BudgetCategoriesUtilities
{
    public static BudgetCategories? Parse(string category)
    {
        if (Enum.TryParse(typeof(BudgetCategories), category, true, out var result))
        {
            return (BudgetCategories)result;
        }
        return null;
    }
}