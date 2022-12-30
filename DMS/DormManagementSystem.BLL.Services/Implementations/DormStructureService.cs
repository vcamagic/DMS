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
        IMapper mapper)
    {
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

    private readonly IServiceBase<Floor> _floorsService;
    private readonly IMapper _mapper;
}