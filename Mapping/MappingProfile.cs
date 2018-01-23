using AutoMapper;
using BakeryWebApi.Controllers.Resources;
using Microsoft.AspNetCore.Identity;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
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
            CreateMap<Photo, ItemPhotoDTO>();

            CreateMap<MenuItem, MenuItemDTO>()
                .ForMember(ir => ir.Ingredients, opt => opt.MapFrom(i => i.Ingredients.Select(ir => new IngredientDTO { Id = ir.Ingredient.Id, Name = ir.Ingredient.Name, Description = ir.Ingredient.Description})))
                .ForMember(ir => ir.Price, opt => opt.Ignore())
                .ForMember(ir => ir.Photos, opt => opt.MapFrom(i => i.Photos.Select(ir => new ItemPhotoDTO { FileName = ir.FileName, Length = ir.Length, Id = ir.Id, ContentType = ir.ContentType})))
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
            CreateMap<OrderMenuItem, MenuItemDTO>();
            CreateMap<Order, OrderDTO>();

            CreateMap<Client, ClientDTO>()
                .ForMember(dto => dto.Email, o => o.MapFrom(c => c.Identity.Email));

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
            CreateMap<OrderSaveDTO, Order>()
                .ForMember(item => item.Id, option => option.Ignore())
                .ForMember(item => item.MenuItems, option => option.Ignore())
                .AfterMap((saveDTO, order) =>
                {
                    // Remove unselected features
                    var removedItems = order.MenuItems.Where(item => !saveDTO.MenuItems.Contains(item.MenuItemId));
                    foreach (var item in removedItems.ToList())
                        order.MenuItems.Remove(item);

                    // Add New Ingredients
                    var addedItems = saveDTO.MenuItems
                        .Where(id => !order.MenuItems.Any(item => item.MenuItemId == id))
                        .Select(id => new OrderMenuItem { MenuItemId = id });
                    foreach (var item in addedItems)
                        order.MenuItems.Add(item);
                });
            CreateMap<MenuItemPriceDTO, MenuItemPrice>();
            CreateMap<ItemPricePerSetDTO, ItemPricePerSet>();
            CreateMap<RegisterDTO, Client>()
                .ForMember(c => c.IdentityId, opt => opt.Ignore())
                .ForMember(c => c.Identity, opt => opt.Ignore())
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<RegisterDTO, IdentityUser>();
        }
    }
}
