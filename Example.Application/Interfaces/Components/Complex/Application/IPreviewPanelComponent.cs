using Example.Application.Interfaces.Components.Primary.Table;
using Example.Application.Interfaces.Components.Primary.TabPanel;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IPreviewPanelComponent
    {
        IFileViewPanelComponent FileViewPanel { get; }

        ITabPanelComponent TabPanel { get; }

        ITableComponent Table { get; }
    }
}
