using ASPA007_1.Models;
using DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPA007_1.Pages
{
    public class LifeEventsModel : PageModel
    {
        private readonly IRepository _repository;
        public List<CelebrityEventsViewModel> CelebritiesWithEvents { get; set; } = new();

        public LifeEventsModel(IRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            var celebrities = _repository.GetAllCelebrities();

            foreach (var celebrity in celebrities)
            {
                var events = _repository.GetLifeeventsByCelebrityId(celebrity.Id);
                CelebritiesWithEvents.Add(new CelebrityEventsViewModel
                {
                    Celebrity = celebrity,
                    LifeEvents = events
                });
            }
        }
    }
}