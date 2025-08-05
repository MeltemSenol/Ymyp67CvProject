using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymyp67CvProject.Business.Abstract;
using Ymyp67CvProject.Entity.Dtos.SocialAccount;

namespace Ymyp67CvProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialAccountsController : ControllerBase
    {
        private readonly ISocialAccountService _socialAccountService;
        public SocialAccountsController(ISocialAccountService socialAccountService)
        {
            _socialAccountService = socialAccountService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(SocialAccountCreateRequestDto dto)
        {
            if(dto == null)
            {
                return BadRequest("Geçersiz veri.");
            }
            var result = await _socialAccountService.AddAsync(dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(SocialAccountUpdateRequestDto dto)
        {
            if(dto == null)
            {
                return BadRequest("Geçersiz veri.");
            }
            var result = await _socialAccountService.UpdateAsync(dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _socialAccountService.RemoveAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _socialAccountService.GetByIdAsync(id);
            if(!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _socialAccountService.GetAllAsync();
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("[action]/{platform}")]
        public async Task<IActionResult> GetBySocialPlatform(string platform)
        {
            var result = await _socialAccountService.GetSocialAccountByNameAsync(platform);
            if(!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> GetAllByUserName(string userName)
        {
            var result = await _socialAccountService.GetSocialAccountsByUserNameAsync(userName);
            if(!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
