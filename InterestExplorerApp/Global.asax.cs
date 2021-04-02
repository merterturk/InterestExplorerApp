using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Bll.Concrete;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Dal.Concrete.EntityFramework;
namespace InterestExplorerApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region AutofacDependencyInjection
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<MainCategoryManager>().As<IMainCategoryService>();
            builder.RegisterType<EfMainCategoryDal>().As<IMainCategoryDal>();

            builder.RegisterType<MovieManager>().As<IMovieService>();
            builder.RegisterType<EfMovieDal>().As<IMovieDal>();

            builder.RegisterType<SeriesManager>().As<ISeriesService>();
            builder.RegisterType<EfSeriesDal>().As<ISeriesDal>();

            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfBookDal>().As<IBookDal>();

            builder.RegisterType<VideoGameManager>().As<IVideoGameService>();
            builder.RegisterType<EfVideoGameDal>().As<IVideoGameDal>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


    }
}
