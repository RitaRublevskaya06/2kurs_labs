using DAL_Celebrity_MSSQL;

namespace ASPA007_1.Models
{
    public class CelebrityEventsViewModel
    {
        public Celebrity Celebrity { get; set; }
        public List<Lifeevent> LifeEvents { get; set; }
    }
}
