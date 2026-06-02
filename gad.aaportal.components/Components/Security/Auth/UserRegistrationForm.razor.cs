using gad.aaportal.commons.Dto.Seguridad;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class UserRegistrationForm : ComponentBase
    {
        [Parameter, EditorRequired] public UserRegistrationDtoParam Model { get; set; } = default!;
        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
        [Parameter] public EventCallback OnBack { get; set; }
        [Parameter] public bool IsValidButton { get; set; }
        [Parameter] public EventCallback<string> OnValidarIdentificacion { get; set; }

        private bool AceptaPoliticaDatos { get; set; }
        private bool MostrarModalPoliticaDatos { get; set; }
        private string? MensajePoliticaDatos { get; set; }

        private const string parte1Politica = "                    De conformidad con la Ley Orgánica de Protección de Datos Personales,\r\n                    autorizo al Gobierno Autónomo Descentralizado Municipal de Antonio Ante\r\n                    para que recopile, almacene, use, trate y actualice mis datos personales\r\n                    con la finalidad de gestionar mi registro como contribuyente, validar mi\r\n                    información, brindar servicios municipales y cumplir obligaciones legales\r\n                    aplicables.";

        private const string parte2Politica = "                    Declaro que la información proporcionada es veraz y que he sido informado\r\n                    sobre mis derechos de acceso, rectificación, actualización, eliminación,\r\n                    oposición, suspensión del tratamiento y demás derechos reconocidos por la\r\n                    normativa vigente en materia de protección de datos personales.";

        private const string parte3Politica = "                    El tratamiento de mis datos se realizará bajo principios de seguridad,\r\n                    confidencialidad, transparencia, finalidad legítima y responsabilidad.";

        private async Task OnIdentificacionBlur(FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Model.Identificacion) || Model.Identificacion.Length < 13)
                return;

            if (OnValidarIdentificacion.HasDelegate)
                await OnValidarIdentificacion.InvokeAsync(Model.Identificacion);
        }

        private async Task OnSubmitValidado()
        {
            if (!AceptaPoliticaDatos)
            {
                MensajePoliticaDatos = "Debe aceptar la política de tratamiento y protección de datos personales para continuar.";
                return;
            }

            Model.AceptaPoliticasTratamientoDatos = AceptaPoliticaDatos;
            Model.PoliticasTratamientoDatos = parte1Politica + parte2Politica + parte3Politica;
            MensajePoliticaDatos = null;

            if (OnSubmit.HasDelegate)
                await OnSubmit.InvokeAsync();
        }

        private void AbrirModalPolitica()
        {
            MostrarModalPoliticaDatos = true;
        }

        private void CerrarModalPolitica()
        {
            MostrarModalPoliticaDatos = false;
        }

        private void AceptarPoliticaDesdeModal()
        {
            AceptaPoliticaDatos = true;
            MensajePoliticaDatos = null;
            MostrarModalPoliticaDatos = false;
        }

        private void OnAceptaPoliticaDatosChanged(ChangeEventArgs e)
        {
            AceptaPoliticaDatos = e.Value is bool value && value;

            if (AceptaPoliticaDatos)
                MensajePoliticaDatos = null;
        }
    }
}
