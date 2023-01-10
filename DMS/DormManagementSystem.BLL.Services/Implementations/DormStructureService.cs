using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;
public class DormStructureService : IDormStructureService
{
    public DormStructureService(
        IServiceBase<Floor> floorsService,
        IServiceBase<Room> roomsService,
        IServiceBase<Residency> residenciesService,
        IServiceBase<Laundry> laundriesService,
        IServiceBase<Entertainment> entertainmentsService,
        IMapper mapper)
    {
        _floorsService = floorsService;
        _roomsService = roomsService;
        _residenciesService = residenciesService;
        _laundriesService = laundriesService;
        _entertainmentsService = entertainmentsService;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<FloorDTO>> GetDormStructure()
    {
        var residencies = await _residenciesService.GetEntities(includes: new string[] { $"{nameof(Residency.Floor)}" });
        var laundries = await _laundriesService.GetEntities(includes: new string[] { $"{nameof(Residency.Floor)}" });
        var entertainments = await _entertainmentsService.GetEntities(includes: new string[] { $"{nameof(Residency.Floor)}" });

        var floors = await _floorsService.GetEntities();

        var joined = floors
            .GroupJoin(
                residencies,
                x => x.Id,
                x => x.FloorId,
                (floor, matchedResidencies) =>
                new
                {
                    FloorId = floor.Id,
                    Level = floor.Level,
                    Residencies = matchedResidencies
                })
            .GroupJoin(
                laundries,
                x => x.FloorId,
                x => x.FloorId,
                (joinResult, matchedLaundries) =>
                new
                {
                    FloorId = joinResult.FloorId,
                    Level = joinResult.Level,
                    Residencies = joinResult.Residencies,
                    Laundries = matchedLaundries
                })
            .GroupJoin(
                entertainments,
                x => x.FloorId,
                x => x.FloorId,
                (joinResult, matchedEntertainments) =>
                new
                {
                    FloorId = joinResult.FloorId,
                    Level = joinResult.Level,
                    Residencies = joinResult.Residencies,
                    Laundries = joinResult.Laundries,
                    Entertainments = matchedEntertainments
                });

        return joined.Select(x =>
        new FloorDTO
        {
            Level = x.Level,
            Residencies = _mapper.Map<IReadOnlyList<ResidencyDTO>>(x.Residencies),
            Laundries = _mapper.Map<IReadOnlyList<LaundryDTO>>(x.Laundries),
            Entertainments = _mapper.Map<IReadOnlyList<EntertainmentDTO>>(x.Entertainments)
        })
        .ToList();
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

    public async Task CreateRoomsOnFloor(Guid floorId, CreateRoomsDTO roomsDTOs, int pageNumber = 1)
    {
        _ = await _floorsService.GetEntity(x => x.Id == floorId, false) ??
            throw new NotFoundException($"Floor with id {floorId} does not exist.");

        var room = await _roomsService.GetEntities(expression: x => roomsDTOs.Rooms.Select(x => x.RoomNumber).Contains(x.RoomNumber));

        if (room.Count > 0)
        {
            throw new BadRequestException("Some of the room numbers already exist.");
        }

        var rooms = _mapper.Map<IEnumerable<Room>>(roomsDTOs.Rooms);

        rooms = rooms.Select(x =>
        {
            x.FloorId = floorId;
            return x;
        });

        await _roomsService.CreateRange(rooms);
    }

    public async Task AddResidenciesToFloor(Guid floorId, CreateResidenciesDTO residenciesDTO)
    {
        await ValidateData(floorId, residenciesDTO.Residencies.Select(x => x.RoomNumber));

        var residencies = _mapper.Map<IEnumerable<Residency>>(residenciesDTO.Residencies);

        residencies = residencies.Select(x =>
        {
            x.FloorId = floorId;
            return x;
        });

        await _residenciesService.CreateRange(residencies);
    }

    public async Task AddLaundryToFloor(Guid floorId, CreateLaundryDTO createLaundryDTO)
    {
        await ValidateData(floorId, new string[] { createLaundryDTO.RoomNumber });

        var laundry = _mapper.Map<Laundry>(createLaundryDTO);
        laundry.FloorId = floorId;

        await _laundriesService.Create(laundry);
    }

    public async Task AddEntertainmentToFloor(Guid floorId, CreateEntertainmentDTO createEntertainmentDTO)
    {
        await ValidateData(floorId, new string[] { createEntertainmentDTO.RoomNumber });

        var entertainment = _mapper.Map<Entertainment>(createEntertainmentDTO);
        entertainment.FloorId = floorId;

        await _entertainmentsService.Create(entertainment);
    }

    private async Task ValidateData(Guid floorId, IEnumerable<string> roomsNumber)
    {
        _ = await _floorsService.GetEntity(x => x.Id == floorId, false) ??
            throw new NotFoundException($"Floor with id {floorId} does not exist.");

        var room = await _roomsService.GetEntity(x => roomsNumber.Contains(x.RoomNumber), false);

        if (room != null)
        {
            throw new BadRequestException("Some of the room numbers already exist.");
        }
    }

    public async Task DeleteRoom(Guid roomId)
    {
        var room = await _roomsService.GetEntity(x => x.Id == roomId, true) ??
            throw new NotFoundException($"Room with id {roomId} does not exist.");

        await _roomsService.Delete(room);
    }

    private readonly IServiceBase<Floor> _floorsService;
    private readonly IServiceBase<Room> _roomsService;
    private readonly IServiceBase<Residency> _residenciesService;
    private readonly IServiceBase<Laundry> _laundriesService;
    private readonly IServiceBase<Entertainment> _entertainmentsService;
    private readonly IMapper _mapper;
}