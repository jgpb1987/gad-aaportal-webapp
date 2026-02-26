using gad.aaportal.commons.Dto.Aplicacion;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;

namespace gad.generic.components.Components.Filters
{
    public partial class CantonesSelection
    {
        [Parameter]
        public List<Canton> Cantones { get; set; } = new List<Canton>();

        [Parameter]
        public EventCallback<Canton> OnPorcentajeExcedido { get; set; }

        [Parameter]
        public ToastsServices? Toast { get; set; }
        [Parameter]
        public EventCallback<Canton> OnPorcentajeCambiado { get; set; }
        
        private HashSet<string> collapsedStates = new();
        private string filtroCanton = string.Empty;

        private void ToggleCollapse(string provincia)
        {
            if (!collapsedStates.Add(provincia))
                collapsedStates.Remove(provincia);
        }

        private void ToggleCanton(Canton canton, object? value)
        {
            bool selected = (bool)value;
            canton.Seleccionado = selected;
            if (!selected)
                canton.Porcentaje = 0;
        }

        private void TooglePagoAA(Canton canton, object? value)
        {
            bool selected = (bool)value;
            canton.PagoAA = selected;
        }

        protected override void OnInitialized()
        {
            var aa = Cantones.FirstOrDefault(c => c.Id == 116);
            if (aa != null)
            {
                aa.Seleccionado = true;
                aa.PagoAA = true;
                if (aa.Porcentaje <= 0) aa.Porcentaje = 100;
            }
        }

        private async Task ValidarSuma(Canton canton)
        {
            var total = Cantones.Where(c => c.Seleccionado).Sum(c => c.Porcentaje);
            if (total > 100)
            {
                canton.Porcentaje = 0;
                if (Toast != null)
                {
                    Toast.ShowMessage("error", "Porcentaje inválido", "El porcentaje no puede superar el 100%");
                }

                if (OnPorcentajeExcedido.HasDelegate)
                {
                    await OnPorcentajeExcedido.InvokeAsync(canton);
                }
            }

            if (OnPorcentajeCambiado.HasDelegate)
                await OnPorcentajeCambiado.InvokeAsync(canton);
        }
    }
}
