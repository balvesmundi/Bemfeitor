using System.Configuration;

namespace Repository
{

    public abstract class BaseRepository
    {
        protected string ConnectionString;

        public BaseRepository()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}
