using Microsoft.JSInterop;
namespace TangyWeb_Server.Helper
{
    public static class IJsRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
        public static async ValueTask SweetAlertOk(this IJSRuntime jsRuntime, string title, string message)
        {
            await jsRuntime.InvokeVoidAsync("Swal", "success", title, message);
        }
        public static async ValueTask SweetAlertCancel(this IJSRuntime jsRuntime, string title, string message)
        {
            await jsRuntime.InvokeVoidAsync("Swal", "failure", title, message);
        }


    }
}
