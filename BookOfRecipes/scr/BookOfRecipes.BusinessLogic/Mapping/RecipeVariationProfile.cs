using AutoMapper;
using BookOfRecipes.BusinessLogic.Recipes.Model;
using BookOfRecipes.Data;

namespace BookOfRecipes.BusinessLogic.Mapping
{
    public class RecipeVariationProfile : Profile
    {
        public RecipeVariationProfile()
        {
            CreateMap<RecipeVariation, RecipeDto>()
                .ForMember(r => r.Name, opt => opt.MapFrom(rv => rv.Recipe.Name))
                .ForMember(r => r.Year, opt => opt.MapFrom(rv => rv.Year))
                .ForMember(r => r.Country, opt => opt.MapFrom(rv => rv.Country))
                .ForMember(r => r.TimeOfCooking, opt => opt.MapFrom(rv => rv.TimeOfCooking))
                .ForMember(r => r.Author, opt => opt.MapFrom(rv => rv.Author.Name))
                .ForMember(r => r.CookingDescription, opt => opt.MapFrom(rv => rv.CookingDescription))
                .ForMember(r => r.Ingredients, opt => opt.MapFrom(rv => rv.Ingredients))
                .ReverseMap();

            CreateMap<Ingredient, IngredientDto>()
                .ReverseMap();

            CreateMap<RecipeDto, Recipe>()
                .ForMember(r => r.Name, opt => opt.MapFrom(r => r.Name))
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.Variations, opt => opt.Ignore());
        }
    }
}