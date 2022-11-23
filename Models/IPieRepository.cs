using BethanysPieShop.ViewModels;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        bool CreateNewPie(PieViewModel pieViewModel);
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById(int pieId);
    }
}
