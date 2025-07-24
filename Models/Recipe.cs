namespace Project.Models
{
    public class Recipe
    {

        public int RecipeId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public string DifficultyLevel { get; set; }

        public string CategoryName { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }


        public int CategoryID { get; set; }
        public string Image { get; set; }

    }
}
