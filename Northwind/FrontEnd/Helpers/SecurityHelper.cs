using FrontEnd.Models;
using Newtonsoft.Json;
using System.Security.Claims;

namespace FrontEnd.Helpers
{
    public class SecurityHelper
    {

        ServiceRepository repository;

        public SecurityHelper()
        {
            repository = new ServiceRepository();
        }


        public TokenModel Login(UserViewModel usuario)
        {
            try
            {
                TokenModel TokenModel;


                HttpResponseMessage responseMessage = repository.PostResponse("api/Authenticate/login", new {usuario.UserName,usuario.Password});
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                TokenModel = JsonConvert.DeserializeObject<TokenModel>(content);



                return TokenModel;



            }
            catch (Exception)
            {

                throw;
            }
        }



        public LoginModel GetUser(UserViewModel usuario)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Authenticate/getuser", usuario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(content);
            return loginModel;

        }





    }
}
