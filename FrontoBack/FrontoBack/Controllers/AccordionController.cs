using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class AccordionController : Controller
    {
        private AppDbContext _context { get;  }
        private char[] _letters = {'a','b','c','ç' ,'d','e','ə','f','g' ,'ğ','h','x','ı','i','j','k','q','l','m','n','o','ö','p','r','s','ş','t','u','ü','v','y','z' };
        private List<string> _json = new() { "Baku", "Sumqayıt", "Gəncə", "Ağcabədi", "Mingəçevir", "Xırdalan", "Naxçıvan", "Qaraçuxur", "Hövsan", "Bakıxanov", "Şirvan", "Şəki", "Yevlax", "Şatrovka", "M.Ə. Rəsulzadə", "Lənkəran", "Xankəndi", "Biləcəri", "Maştağa", "Qəzyan", "Şəmkir", "Xaçmaz", "Bərdə", "Binəqədi", "Göyçay", "Lökbatan", "Qazax", "Buzovna", "İmişli", "Zaqatala", "Sabirabad", "Salyan", "Əmircan", "Ağdaş", "Aşağı Göycəli", "Binə", "Cəlilabad", "Göygöl", "Keşlə", "Mərdəkan", "Şamaxı", "Biləsuvar", "Hacıqabul", "Quba", "İsmayıllı", "Ağsu", "Ağstafa", "Siyəzən", "Saatlı", "Füzuli", "Astara", "Qusar", "Kürdəmir", "Masallı", "Ucar", "Neftçala", "Tovuz", "Tərtər", "Culfa", "Beyləqan", "Qax", "Daşkəsən", "Ordubad", "Samux", "Naftalan", "Gədəbəy", "Zərdab", "Balakən", "Yardımlı", "Goranboy", "Lerik", "Kəlbəcər", "Oğuz", "Cəbrayıl", "Xocavənd", "Babək", "Şuşa", "Qıvraq", "Qobustan", "Ağdam", "Şahbuz", "Laçın", "Heydərabad", "Xızı", "Xocalı", "Qubadlı", "Şərur", "Qəbələ", "Dəvəçi" };
        private Dictionary<char, int> _letterCountInCountryCity = new Dictionary<char, int>();
        public AccordionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           

            return View();
        }

        //azerbaycan seherlerinde her bir herifden umumi nece defe isdifade edildiyini tapan algorithm
        public IActionResult CountOfLetterInAzerbaijanCities()
        {
            foreach (var letter in _letters)
            {
                int count = 0;
                foreach (var city in _json)
                {
                    foreach (var cityLetter in city.ToLower())
                    {
                        if (letter == cityLetter)
                        {
                            count++;
                        }
                    }

                }
                if (count > 0)
                {
                    _letterCountInCountryCity.Add(letter, count);
                }


            }
            return Content("");
        }

    }
}

