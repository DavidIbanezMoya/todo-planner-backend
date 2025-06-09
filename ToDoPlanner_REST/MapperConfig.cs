using AutoMapper;
using ToDoPlanner_REST.Models;
using ToDoPlanner_REST.DTO;

namespace ToDoPlanner_REST
{
    public class MapperConfig
    {
        //Static method, so we do not need to create an instance of MapperConfig
        public static Mapper InitializeAutoMapper()
        {
            //We will first initialize the configuration of the AutoMapper
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<BoardModel, EditBoardDTO>();
                cfg.CreateMap<BoardModel, CreateBoardDTO>();
                //If there are other DTOs to be configured they will go here
                //cfg => cfg.CreateMap<XModel, XDTO>();
                });

            var mapper = new Mapper(config);

            return mapper;
        }

    }
}
