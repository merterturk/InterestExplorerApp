using Autofac;
using Autofac.Integration.WebApi;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Bll.Concrete;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Dal.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace InterestExplorerApp.WebAPI
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

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

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}