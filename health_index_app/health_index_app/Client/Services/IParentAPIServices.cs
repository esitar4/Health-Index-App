using health_index_app.Shared.DTObjects;

namespace health_index_app.Client.Services
{
    public interface IParentAPIServices
    {
        Task<List<string>> GetChildUsernames();
        Task<List<ChildMealDTO>> GetChildMeals();
        Task<List<ChildFoodDTO>> GetChildFoods(int mealId);
        Task<bool> DeleteChild(string username);
        Task<bool> AddChild(string username);
    }
}
