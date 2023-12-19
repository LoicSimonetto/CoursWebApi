using MediatR;
using SelfieAWookies.NET.Selfies.Domain;
using TestWebAPI.Application.DTOs;

namespace TestWebAPI.Application.Commands
{
    public class AddSelfieHandler : IRequestHandler<AddSelfieCommand, SelfieDto>
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        #endregion
        #region Constructors
        public AddSelfieHandler(ISelfieRepository repository)
        {
            this._repository = repository;
        }
        #endregion
        #region Public Methods

        #endregion
        public Task<SelfieDto> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
        {
            SelfieDto result = null;

            Selfie addSelfie = this._repository.AddOne(new Selfie()
            {
                ImagePath = request.Item.ImagePath,
                Title = request.Item.Title
            });

            this._repository.UnitOfWork.SaveChanges();

            if (addSelfie != null)
            {
                request.Item.Id = addSelfie.Id;
                result = request.Item;
            }

            return Task.FromResult(result);
        }
    }
}
