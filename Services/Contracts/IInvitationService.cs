using System.Threading.Tasks;
using ViewModels;

namespace Services.Contracts
{
    public interface IInvitationService
    {
        Task<InvitationModel[]> GetInvitationsForUserId(int userId);
    }
}