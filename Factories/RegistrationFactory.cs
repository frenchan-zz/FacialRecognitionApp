using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using FacialRecognitionApp.Models;

namespace FacialRecognitionApp.Factories
{
    public class RegistrationFactory : IRegistrationFactory
    {
        private readonly IPersonRepository _personRepository;

        public RegistrationFactory(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> RegisterUser(RegisterApiModel data)
        {
            var personResponse = await _personRepository.CreatePersonId(data);

            if (!personResponse.IsSuccessStatusCode)
            {
                return false;
            }

            var faceResponse = await _personRepository.AddFaceToPerson(data);

            if (!faceResponse.IsSuccessStatusCode)
            {
                return false;
            }

            return false;
        }
    }
}