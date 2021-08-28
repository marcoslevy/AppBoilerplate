using System.Threading.Tasks;
using AppBoilerplate.Configuration.Dto;

namespace AppBoilerplate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
