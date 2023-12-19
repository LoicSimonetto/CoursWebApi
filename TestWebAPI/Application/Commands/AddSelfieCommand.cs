using MediatR;
using TestWebAPI.Application.DTOs;

namespace TestWebAPI.Application.Commands
{
    public class AddSelfieCommand: IRequest<SelfieDto>
    {
        #region Properties
        public SelfieDto Item { get; set; }
        #endregion

    }
}
