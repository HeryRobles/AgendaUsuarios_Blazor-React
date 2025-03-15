using AgendaUsuarios.Web.Repositories;
using AgendaUsuarios.Model.Entities;
using Microsoft.AspNetCore.Components;
using CurrieTechnologies.Razor.SweetAlert2;

namespace AgendaUsuarios.Web.Pages.Users;

public partial class UsuariosIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    private List<Usuario>? Usuarios { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    private async Task Load()
    {
        var response = await Repository.Get<List<Usuario>>("api/usuarios");
        Usuarios = response.Response!;
    }

    private async Task Delete(Usuario usuario)
    {
        var result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "Confirmación",
            Text = "¿Estás seguro que quieres eliminar este registro?.",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            //ConfirmButtonText = "Sí, bórralo",
            //CancelButtonText = "Cancelar"
        });

        var confirm = string.IsNullOrEmpty(result.Value);

        if(confirm)
        {
            return;
        }

        var responseHttp = await Repository.Delete($"api/usuarios/{usuario.Id}");

        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                navigationManager.NavigateTo("/");
            }
            else
            {
                var mensajeError = await responseHttp.GetErrorMessageAsync();
                await Swal.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
            }
        }
        else
        {
            await Load();
        }
    }
}