using System.Collections.Generic;

namespace BookOfRecipes.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<RecipeVariation> Recipes { get; set; }
    }
}