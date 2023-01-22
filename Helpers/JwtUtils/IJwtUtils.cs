using ProiectV1.Models;

namespace ProiectV1.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        ///generare si validare de token 
        //generare
        public string GenerateJwtToken(User user);
        //validare
        public Guid ValidateJwtToken(string token);
    }
}
