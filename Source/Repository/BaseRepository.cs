using System.Configuration;

namespace MundiPagg.Benfeitor.Repository
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
