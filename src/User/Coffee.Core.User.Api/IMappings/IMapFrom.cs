using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Coffee.Core.User.Api
{
    // inherit to map get object
    // example: 
    // public class TodoListDto : IMapFrom<TodoList>
    // {
    //     public TodoListDto()
    //     {
    //         Items = new List<TodoItemDto>();
    //     }

    //     public int Id { get; set; }

    //     public string Title { get; set; }

    //     public string Colour { get; set; }

    //     public IList<TodoItemDto> Items { get; private set; } // To minimize missing error.
    // }
    
    // revert object
    // public class TodoItemDto : IMapFrom<TodoItem>
    // {
    //     public int Id { get; set; }

    //     public int ListId { get; set; }

    //     public string Title { get; set; }

    //     public bool Done { get; set; }

    //     public int Priority { get; set; }

    //     public string Note { get; set; }

    //     public void Mapping(Profile profile)
    //     {
    //         profile.CreateMap<TodoItem, TodoItemDto>()
    //             .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    //     }
    // }
    public class IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}