using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;
public class DormStructureService : IDormStructureService
{
    public DormStructureService(
        IRepositoryBase<Room> roomsRepository,
        IServiceBase<Floor> floorsService,
        IMapper mapper)
    {
        _roomsRepository = roomsRepository;
        _floorsService = floorsService;
        _mapper = mapper;
    }

    public async Task CreateFloors(IEnumerable<CreateFloorDTO> floorDTOs)
    {
        var distinctLevels = floorDTOs.DistinctBy(x => x.Level).Count();

        if (distinctLevels != floorDTOs.Count())
        {
            throw new BadRequestException("Floor level must be unique across all floors.");
        }

        var floorsInDb = await _floorsService.GetEntities(false, x => floorDTOs.Select(f => f.Level).Contains(x.Level));

        if (floorsInDb.Count != 0)
        {
            throw new BadRequestException("Some of the floors already exist.");
        }

        var floors = _mapper.Map<IEnumerable<Floor>>(floorDTOs);

        await _floorsService.CreateRange(floors);
    }

    public async Task CreateFloor(CreateFloorDTO floorDTO)
    {
        var floorDb = await _floorsService.GetEntity(x => x.Level == floorDTO.Level, false);

        if (floorDb != null)
        {
            throw new BadRequestException($"Floor already exists on {floorDTO.Level} level.");
        }

        var floor = _mapper.Map<Floor>(floorDTO);
        await _floorsService.Create(floor);
    }

    public async Task CreateRoomsOnFloor(Guid floorId, IEnumerable<RoomDTO> rooms)
    {
        var floor = await _floorsService.GetEntity(x => x.Id == floorId, false) ??
            throw new BadRequestException($"Floor with id {floorId} does not exist.");

        var roomsForCreation = _mapper.Map<IEnumerable<Room>>(rooms);

        roomsForCreation = roomsForCreation.Select(x => new Room 
        { 
            FloorId = floorId, 
            Id = Guid.NewGuid(),
            RoomNumber = x.RoomNumber, 
            Capacity = x.Capacity 
        });

        _roomsRepository.CreateRange(roomsForCreation);

        await _roomsRepository.Context.SaveChangesAsync();
    }

    private readonly IRepositoryBase<Room> _roomsRepository;
    private readonly IServiceBase<Floor> _floorsService;
    private readonly IMapper _mapper;
}