using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _SubAbout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
            var values = subAboutManager.TGetList();
            return View(values);
        }
    }
}
