using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Contracts;
using Utils;
using ViewModels;

namespace Services.Implementations
{
    class InvitationsResponseDTO {
        public InvitationDTO[] results = null;
    }

    class InvitationDTO {
        public int id = 0;
        public string challengeName = "";
        public string recipientFirstName = "";
        public string recipientLastName = "";
    }
    
    public class InvitationService: IInvitationService
    {
        private readonly HttpClient _httpService;
        private readonly Configuration _configuration;

        public InvitationService(HttpClient httpService, Configuration configuration)
        {
            this._httpService = httpService;
            this._configuration = configuration;
        }

        public async Task<InvitationModel[]> GetInvitationsForUserId(int userId)
        {
            string currentSessionToken = "ee680e76d8794737b9081c457c1c2b06x00003B90x846939";
            var urlToRequest = $"{this._configuration.BaseDomain}/brainshark/brainshark.services.coaching/user/{userId}/invitation?hideCourses=true";
            
            this._httpService.TryAppendingSecurityToken(currentSessionToken);

            var wholeHttpResultBody = await _httpService.GetStringAsync(urlToRequest);
            return JsonConvert.DeserializeObject<InvitationsResponseDTO>(wholeHttpResultBody)
                .results
                .Select(invitation => new InvitationModel() {
                    Id = invitation.id,
                    Challenge = invitation.challengeName,
                    Participant = $"{invitation.recipientFirstName} {invitation.recipientLastName}"
                })
                .ToArray();
        }
    }
}