using System.Threading.Tasks;
using Messages;

namespace MailServiceHost.Processors
{
    public interface ILetterProcessor
    {
        Task SendMail(SendLetterMessage message);
    }
}