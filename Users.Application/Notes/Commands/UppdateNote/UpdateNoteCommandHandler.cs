using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UppdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>

    {
        private readonly INotesDbContext _dbContext;
        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handel(UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var enttity =
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (enttity == null || enttity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            enttity.Details = request.Details;
            enttity.Title = request.Titles;
            enttity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        
    }
    
}
