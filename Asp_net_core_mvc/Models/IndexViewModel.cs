namespace Asp_net_core_mvc.Models
{
    
        public class IndexViewModel
        {
            public IEnumerable<Plane> Planes { get; }
            public IEnumerable<Airline> Airlines { get; }
            public PageViewModel PageViewModel { get; }
            public decimal? minPassQuont { get; set; }
            public decimal? maxPassQuont { get; set; }
            public IndexViewModel(IEnumerable<Plane> planes, PageViewModel viewModel)
            {
                Planes = planes;
                PageViewModel = viewModel;
            }
        }
    
}
