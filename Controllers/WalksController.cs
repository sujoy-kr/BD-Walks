using AutoMapper;
using BDWalks.API.CustomActionFilters;
using BDWalks.API.Interfaces;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO.WalkDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNo = 1, [FromQuery] int pageSize = 1000)
        {
            List<Walk> walkModels = await walksRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNo, pageSize);

            List<WalkDto> walkDtos = mapper.Map<List<WalkDto>>(walkModels);
            return Ok(walkDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Walk? walkModel = await walksRepository.GetByIdAsync(id);

            if (walkModel == null)
            {
                return NotFound();
            }

            WalkDto walkDto = mapper.Map<WalkDto>(walkModel);
            return Ok(walkDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateWalkRequestDto createWalkRequestDto)
        {
            Walk walkModel = mapper.Map<Walk>(createWalkRequestDto);

            walkModel = await walksRepository.CreateAsync(walkModel);

            CreateWalkResponseDto createWalkResponseDto = mapper.Map<CreateWalkResponseDto>(walkModel);

            return CreatedAtAction(nameof(GetById), new { id = createWalkResponseDto.Id }, createWalkResponseDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            Walk? walkModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkModel = await walksRepository.UpdateAsync(id, walkModel);

            if (walkModel == null)
            {
                return NotFound();
            }

            UpdateWalkResponseDto regionDto = mapper.Map<UpdateWalkResponseDto>(walkModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Walk? walkModel = await walksRepository.DeleteAsync(id);
            if (walkModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
