using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Windows;

namespace WPF_Operations
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly WindsorContainer container = new WindsorContainer();
        public App()
        {
            RegisterComponents();
        }
        private void RegisterComponents()
        {
            container.Register(Component.For<IAgentInfoDao>().ImplementedBy<AgentDao>());
        }
    }
}
