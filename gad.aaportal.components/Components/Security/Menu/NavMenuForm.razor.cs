using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class NavMenuForm
    {
        private string SearchTerm { get; set; } = string.Empty;
        private void OnSearchInput(ChangeEventArgs e)
        {
            SearchTerm = e.Value!.ToString()!;
            SearchMenu();
        }
        private void OnButtonSearchInput()
        {
            SearchMenu();
        }
        private void SearchMenu()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                //expandir = false;
                //FilteredMenu = ListaMenu;
            }
            else
            {
                //expandir = true;
                var searchTermLower = SearchTerm.ToLower();
                var uniqueTitles = new HashSet<string>();
            }
            StateHasChanged();
        }
    }
}

