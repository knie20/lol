

namespace Persistence
{
    public class ApplicationDTO
    {
        private string GetConnectionString(){
            return System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["ResumeDatabase"]
            .ConnectionString;
        }
    }
}