using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace NextSugarCat.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // API : Domain to API Resource

            // Ingredient Mapping from Domain to DTO
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<MenuItemIngredient, IngredientDTO>();
            // Price Mapping from Domain to DTO
            CreateMap<MenuItemPrice, MenuItemPriceDTO>();
            CreateMap<MenuItemPrice, CakePriceDTO>();
            CreateMap<MenuItemPrice, SetPriceDTO>();
            CreateMap<ItemPricePerSet, ItemPricePerSetDTO>();
            CreateMap<MenuItem, MenuItemDTO>()
                .ForMember(ir => ir.Ingredients, opt => opt.MapFrom(i => i.Ingredients.Select(ir => new IngredientDTO { Id = ir.Ingredient.Id, Name = ir.Ingredient.Name, Description = ir.Ingredient.Description})))
                .ForMember(ir => ir.Price, opt => opt.Ignore())
                .AfterMap((mi, mir) =>
                {
                    switch (mi.Type)
                    {
                        case "Cake":
                            mir.Price = Mapper.Map<MenuItemPrice, CakePriceDTO>(mi.Price);
                            break;
                        case "Cupcake":
                            mir.Price = Mapper.Map<MenuItemPrice, SetPriceDTO>(mi.Price);
                            break;
                        case "Macaron":
                            mir.Price = Mapper.Map<MenuItemPrice, SetPriceDTO>(mi.Price);
                            break;
                        default:
                            mir.Price = Mapper.Map<MenuItemPrice, MenuItemPriceDTO>(mi.Price);
                            break;
                    }
                });

            CreateMap<Client, ClientDTO>();

            // API : API Resource to Domain
            CreateMap<IngredientDTO, MenuItemIngredient>();
            CreateMap<IngredientDTO, Ingredient>()
                .ForMember(ingredient => ingredient.Id, option => option.Ignore());

            CreateMap<MenuItemSaveDTO, MenuItem>()
                .ForMember(item => item.Id, option => option.Ignore())
                .ForMember(item => item.Ingredients, option => option.Ignore())
                .AfterMap((saveResource, menuItem) =>
                {
                    // Remove unselected features
                    var removedIngredients = menuItem.Ingredients.Where(ingredient => !saveResource.Ingredients.Contains(ingredient.IngredientId));
                    foreach (var ingredient in removedIngredients.ToList())
                        menuItem.Ingredients.Remove(ingredient);

                    // Add New Ingredients
                    var addedIngredients = saveResource.Ingredients
                        .Where(id => !menuItem.Ingredients.Any(ingredient => ingredient.IngredientId == id))
                        .Select(id => new MenuItemIngredient { IngredientId = id});
                    foreach (var ingredient in addedIngredients)
                        menuItem.Ingredients.Add(ingredient);
                });

            CreateMap<MenuItemPriceDTO, MenuItemPrice>();
            CreateMap<ItemPricePerSetDTO, ItemPricePerSet>().ForMember(item => item.Id, option => option.Ignore());
            CreateMap<RegisterDTO, Client>()
                .ForMember(c => c.IdentityId, opt => opt.Ignore())
                .ForMember(c => c.Identity, opt => opt.Ignore())
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<RegisterDTO, IdentityUser>();
            CreateMap<ContactsDTO, Contacts>();
            CreateMap<ClientDTO, Client>()
                .ForMember(c => c.Identity, opt => opt.Ignore())
                .ForMember(c => c.IdentityId, opt => opt.Ignore());
        }
    }
}
