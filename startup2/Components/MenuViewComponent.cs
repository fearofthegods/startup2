using Microsoft.AspNetCore.Mvc;
using startup2.Models;

namespace startup2.Components
{
    [ViewComponent(Name ="MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _context;
        
        public MenuViewComponent(DataContext context) 
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var ListofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", ListofMenu));
        }

    }
}
