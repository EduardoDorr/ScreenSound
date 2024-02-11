using MudBlazor;
using MudBlazor.Utilities;

namespace ScreenSound.Web.Layout;

public class ScreensoundPallete : PaletteDark
{
    public ScreensoundPallete()
    {
        Primary = new MudColor("#9966FF");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static ScreensoundPallete CreatePallete => new();
}