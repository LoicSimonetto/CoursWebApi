using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookies.NET.Selfies.Domain;
using SelfieAWookies.NET.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestWebAPI.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using TestWebAPI.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediatR;
using TestWebAPI.Application.Queries;
using TestWebAPI.Application.Commands;

namespace TestWebAPI.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
    public class SelfiesController : ControllerBase
    {
        #region Champs
        //private readonly  SelfiesContext _context = null;
        private readonly ISelfieRepository _repository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly IMediator _mediator = null;
        #endregion
        #region Constructeurs
        //public SelfiesController(SelfieContext context)
        //{
        //    _context= context;
        //}
        public SelfiesController(IMediator mediator, ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }
        #endregion
        #region Méthodes publiques
        //[HttpGet]
        //public IEnumerable<Selfie> Get()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item});
        //}

        [HttpGet]
        //[DisableCors()]
        //[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
        public ActionResult GetAll([FromQuery] int wookieId = 0)
        {
            //var query = from selfie in _context.Selfies 
            //            join wookie in _context.Wookies on selfie.WookieId equals wookie.Id
            //            select selfie;

            var param = this.Request.Query["wookieId"];

            //var selfiesList = this._repository.GetAll(wookieId);
            //var model = selfiesList.Select(x => new SelfieResumeDto { Title = x.Title, WookieId = x.Wookie.Id, NbSelfie = x.Wookie.Selfies.Count }).ToList();
            //var model = this._context.Selfies.Include(x => x.Wookie).Select(x => new {Title = x.Title, WookieId = x.Wookie.Id, nbselfie = x.Wookie.Selfies.Count}).ToList();
            
            var model = this._mediator.Send(new SelectAllSelfiesQuery() { WookieId= wookieId });
            
            return this.Ok(model);
        }

        //[Route("photos")]
        //[HttpPost]
        //public async Task<ActionResult> AddPictureAsync()
        //{
        //    using var sr = new StreamReader(this.Request.Body);

        //    var content = await sr.ReadToEndAsync();

        //    return this.Ok();
        //}

        [Route("photos")]
        [HttpPost]
        public async Task<ActionResult> AddPictureAsync(IFormFile picture)
        {
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, "images\\selfies");

            if(!Directory.Exists(filePath)) 
            {
                Directory.CreateDirectory(filePath); 
            }
            filePath = Path.Combine(filePath, picture.FileName);

            using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(fs);

            var itemFile = this._repository.AddOnePicture(filePath);

            try
            {
                this._repository.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return this.Ok(itemFile);
        }

        [HttpPost]
        public async Task<ActionResult> AddOne(SelfieDto selfieDto)
        {
            ActionResult result = this.BadRequest();

            //Selfie addSelfie = this._repository.AddOne(new Selfie()
            //{
            //    ImagePath = selfieDto.ImagePath,
            //    Title = selfieDto.Title
            //});

            //this._repository.UnitOfWork.SaveChanges();

            //if (addSelfie != null)
            //{
            //    selfieDto.Id = addSelfie.Id;
            //    result = this.Ok(selfieDto);
            //}

            var model = await this._mediator.Send(new AddSelfieCommand() { Item = selfieDto});

            if (model != null) 
            {
                return this.Ok(model); 
            }

            return result;
        }
        #endregion
    }
}
