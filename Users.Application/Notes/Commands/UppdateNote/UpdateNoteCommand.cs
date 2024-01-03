using System;
using MediatR;

namespace Notes.Application.Notes.Commands.UppdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string  Titles{ get; set; }
        public string Details { get; set; }
    }
}
