using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Image.Command.CreateImage
{
  public class CommandHandler : IRequestHandler<Command, Response>
  {
    public CommandHandler()
    {
    }

    public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
    {

    }
  }
}