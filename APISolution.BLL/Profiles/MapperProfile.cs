using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.BLL.DTOs;
using APISolution.Domain;
using AutoMapper;

namespace APISolution.BLL.Profiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			//Category Mapping
			CreateMap<Category, CategoryDTO> ().ReverseMap();
			CreateMap<CategoryCreateDTO, Category>().ReverseMap();
			CreateMap<CategoryUpdateDTO, Category>().ReverseMap();

			//Article Mapping
			CreateMap<Article, ArticleDTO> ().ReverseMap();
			CreateMap<ArticleCreateDTO, Article>().ReverseMap();
			CreateMap<ArticleUpdateDTO, Article>().ReverseMap();

			//Role Mapping
			CreateMap<Role, RoleDTO> ().ReverseMap();
			CreateMap<RoleCreateDTO, Role>().ReverseMap();

			//User Mapping
			CreateMap<User, UserDTO> ().ReverseMap();
			CreateMap<UserCreateDTO, User>().ReverseMap();
			CreateMap<LoginDTO, User>().ReverseMap();

		}
	}
}
