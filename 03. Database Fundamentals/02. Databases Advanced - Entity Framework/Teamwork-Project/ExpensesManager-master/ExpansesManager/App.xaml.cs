using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using ExpansesManager.ViewModels;
using Models.Models;

namespace ExpansesManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()

        {
            this.AutoMapperConfigurations();
        }

        private void AutoMapperConfigurations()
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<Group, GroupViewModel>(); 
                e.CreateMap<GroupViewModel,Group> ();
                e.CreateMap<SubGroup, SubGroupViewModel>();
                e.CreateMap<SubGroupViewModel, SubGroup>();
                e.CreateMap<Element, ElementViewModel>();
                e.CreateMap<ElementViewModel, Element>();
            });
        }
    }
}
