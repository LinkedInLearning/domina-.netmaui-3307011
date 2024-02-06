using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.ViewModels;
public partial class SignatureViewModel(INavigationService navigationService, WpmOutDbContext wpmOutDbContext) : ViewModelBase, IQueryAttributable
{
    private int OrderId { get; set; }
    public ObservableCollection<IDrawingLine> Lines { get; set; } = new();
    
    [RelayCommand]
    private async Task Save()
    {
        var currentOrder = await wpmOutDbContext.Orders.FindAsync(OrderId);
        var stream = await DrawingView.GetImageStream(Lines, new Size(300, 300), new SolidColorBrush(Colors.White));
        var signature = GetByteArrayFromStream(stream);
        currentOrder.Signature = signature;
        await wpmOutDbContext.SaveChangesAsync();
        await navigationService.GoToAsync("../..");
    }

    [RelayCommand]
    private async Task Skip()
    {
        await navigationService.GoToAsync("../..");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        OrderId = int.Parse(query["orderId"].ToString());
    }

    private byte[] GetByteArrayFromStream(Stream stream)
    {
        stream.Position = 0;
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        return buffer;
    }

}
