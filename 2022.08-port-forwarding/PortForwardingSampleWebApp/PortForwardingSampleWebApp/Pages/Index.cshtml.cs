using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace Pets.Pages
{
    public class PetsModel : PageModel {
        private PetsCounter _counter;
        private int cat = 0;
        private int dog = 0;
        private int capybara = 0;

        public PetsModel(PetsCounter PetsCounter) {
            _counter = PetsCounter;
        }

        public void OnGet() {
            if (_counter != null) {
                cat = _counter.cat;
                dog = _counter.dog;
                capybara = _counter.capybara;
            }
        }
        public PetsCounter Counter {
            get { return _counter; }
        }
        public void OnPostcat() {
            _counter.Incrementcat();
            PrintRequestInfo(nameof(cat));
        }
        public void OnPostdog() {
            _counter.Incrementdog();
            PrintRequestInfo(nameof(dog));
        }
        public void OnPostcapybara() {
            _counter.Incrementdog();
            PrintRequestInfo(nameof(capybara));
        }
        private void PrintRequestInfo(string PetsType) {
            var ua = Request.Headers["User-Agent"].ToString();
            Console.WriteLine($"vote for '{PetsType}'. UA={ua}");
        }
    }
}
