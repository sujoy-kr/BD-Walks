using AutoMapper;
using BDWalks.API.CustomActionFilters;
using BDWalks.API.Interfaces;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO.RegionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            List<Region> regionModels = await regionRepository.GetAllAsync();

            List<RegionDto> regionDtos = mapper.Map<List<RegionDto>>(regionModels);

            return Ok(regionDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Region? regionModel = await regionRepository.GetByIdAsync(id);

            if (regionModel == null)
            {
                return NotFound();
            }

            RegionDto regionDto = mapper.Map<RegionDto>(regionModel);

            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateRegionRequestDto createRegionRequestDto)
        {
            Region regionModel = mapper.Map<Region>(createRegionRequestDto);

            regionModel = await regionRepository.CreateAsync(regionModel);

            RegionDto regionDto = mapper.Map<RegionDto>(regionModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            Region? regionModel = mapper.Map<Region>(updateRegionRequestDto);

            regionModel = await regionRepository.UpdateAsync(id, regionModel);

            if (regionModel == null)
            {
                return NotFound();
            }

            RegionDto regionDto = mapper.Map<RegionDto>(regionModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region? regionModel = await regionRepository.DeleteAsync(id);
            if (regionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
