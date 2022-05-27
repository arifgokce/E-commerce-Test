using Autofac;
using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Business.Interface.Services;
using Hepsiburada.Business.Operation;
using Hepsiburada.Business.Service;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //DataAccess
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<CampaignRepository>().As<ICampaignRepository>();
            builder.RegisterType<IncreaseTimeRepository>().As<IIncreaseTimeRepository>();

            //Business
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductOperation>().As<IProductOperation>();
            builder.RegisterType<OrderOperation>().As<IOrderOperation>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CampaignService>().As<ICampaignService>();
            builder.RegisterType<CampaignOperation>().As<ICampaignOperation>();
            builder.RegisterType<IncreaseTimeOperation>().As<IIncreaseTimeOperation>();
            builder.RegisterType<IncreaseTimeService>().As<IIncreaseTimeService>();
        }
    }
}
