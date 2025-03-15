using AgendaUsuarios.Web.Repositories;
using AgendaUsuarios.Model.Entities;
using Microsoft.AspNetCore.Components;

namespace AgendaUsuarios.Web.Pages.Users;

public partial class UsuariosIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    private List<Usuario>? Usuarios { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var response = await Repository.GetAsync<List<Usuario>>("api/usuarios");
        Usuarios = response.Response!;
    }


}