using SEANEMAAPI.Model;
using SEANEMAAPI.Output;

namespace SEANEMAAPI.Helper
{
    public class UserHelper
    {
        private seanemaDBContext dbContext;
        public UserHelper(seanemaDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public StatusOutput Register(User? user)
        {
            var returnValue = new StatusOutput();
            try
            {
                if (user != null)
                {
                    if(user.Username == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "Username Cannot Be Empty";
                        return returnValue;
                    }
                    if(user.Password == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "Password Cannot Be Empty";
                        return returnValue;
                    }
                    if(user.Email == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "Email Cannot Be Empty";
                        return returnValue;
                    }
                    var userCredetials = new User
                    {
                        UserID = user.UserID,
                        Email = user.Email,
                        Password = user.Password,
                        Username = user.Username,
                    };
                    dbContext.MsUser.Add(userCredetials);
                    dbContext.SaveChanges();
                    returnValue.statusCode = 201;
                    returnValue.message = "Register Success!";
                    return returnValue;
                }
                else
                {
                    returnValue.statusCode = 204;
                    returnValue.message = "Data cannot be empty";
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
