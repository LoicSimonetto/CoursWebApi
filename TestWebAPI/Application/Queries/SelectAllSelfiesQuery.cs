using MediatR;
using TestWebAPI.Application.DTOs;

namespace TestWebAPI.Application.Queries
{
    public class SelectAllSelfiesQuery : IRequest<List<SelfieResumeDto>>
    {
        #region Properties  
        public int WookieId { get; set; }

        #endregion
    }
}
