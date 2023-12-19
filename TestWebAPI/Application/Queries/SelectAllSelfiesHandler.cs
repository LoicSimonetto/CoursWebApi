using MediatR;
using SelfieAWookies.NET.Selfies.Domain;
using TestWebAPI.Application.DTOs;

namespace TestWebAPI.Application.Queries
{
    public class SelectAllSelfiesHandler : IRequestHandler<SelectAllSelfiesQuery, List<SelfieResumeDto>>
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        #endregion
        #region Constructors
        public SelectAllSelfiesHandler(ISelfieRepository repository)
        {
            this._repository = repository;
        }
        #endregion
        #region Public Methods
        public Task<List<SelfieResumeDto>> Handle(SelectAllSelfiesQuery request, CancellationToken cancellationToken)
        {
            var selfiesList = this._repository.GetAll(request.WookieId);
            var result =  selfiesList.Select(x => new SelfieResumeDto { Title = x.Title, WookieId = x.Wookie.Id, NbSelfie = x.Wookie.Selfies.Count }).ToList();

            return Task.FromResult(result);
        }
        #endregion

    }
}
