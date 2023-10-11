﻿using Prism.Ioc;
using StyleAndTriggerBasic_02.Views;
using System.Windows;

namespace StyleAndTriggerBasic_02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
