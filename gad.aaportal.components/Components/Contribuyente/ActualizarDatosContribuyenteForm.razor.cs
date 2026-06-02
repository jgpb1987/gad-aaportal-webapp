using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Contribuyente
{
    public partial class ActualizarDatosContribuyenteForm : ComponentBase
    {
        private ActualizarDatosContribuyenteDtoParam? Model { get; set; }

        private List<TipoMedioContactoDtoResult> _tiposMedioContacto = new();
        private ContribuyenteMedioContactoDtoResult _contactoModal = new();

        private bool _mostrarModalContacto;
        private bool _editandoContacto;
        private ContribuyenteMedioContactoDtoResult? _contactoEdicion;
        private string _tituloModalContacto = "Agregar contacto";

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesContribuyente { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            try
            {
                LoadingBorder?.Open();

                var identificacion = await JSSessionStorageServices
                    .GetItemAsync(Configuraciones.AppConfig.Identificacion);

                if (string.IsNullOrWhiteSpace(identificacion))
                {
                    LoadingBorder?.Close();
                    await MostrarMensaje("error", "IDENTIFICACION_NO_ENCONTRADA", "No se encontró la identificación del contribuyente en sesión");
                    return;
                }

                var tiposResult = await ServicesContribuyente.ConsultarTiposMedioContacto();

                if (tiposResult?.Data is not null)
                    _tiposMedioContacto = tiposResult.Data;

                var result = await ServicesContribuyente.ConsultarDatosContribuyente(
                    new ConsultarDatosContribuyenteDtoParam
                    {
                        Identificacion = identificacion
                    });

                LoadingBorder?.Close();

                if (result?.Data is not null)
                {
                    Model = result.Data;
                    StateHasChanged();
                }
                else
                {
                    await MostrarMensaje(
                        "error",
                        result?.Message?.Code ?? "SIN_DATOS",
                        result?.Message?.Description ?? "No se encontró información del contribuyente");
                }
            }
            catch
            {
                LoadingBorder?.Close();
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }

        private void AbrirModalContacto()
        {
            _editandoContacto = false;
            _contactoEdicion = null;
            _tituloModalContacto = "Agregar contacto";
            _contactoModal = new ContribuyenteMedioContactoDtoResult();
            _mostrarModalContacto = true;
        }

        private void EditarContacto(ContribuyenteMedioContactoDtoResult contacto)
        {
            _editandoContacto = true;
            _contactoEdicion = contacto;
            _tituloModalContacto = "Editar contacto";

            _contactoModal = new ContribuyenteMedioContactoDtoResult
            {
                IdMedioContacto = contacto.IdMedioContacto,
                CodigoTipoMedioContacto = contacto.CodigoTipoMedioContacto,
                NombreTipoMedioContacto = contacto.NombreTipoMedioContacto,
                Valor = contacto.Valor,
                EsPrincipal = contacto.EsPrincipal,
                Estado = contacto.Estado
            };

            _mostrarModalContacto = true;
        }

        private async Task GuardarContactoModal()
        {
            if (Model is null)
                return;

            if (string.IsNullOrWhiteSpace(_contactoModal.CodigoTipoMedioContacto))
            {
                await MostrarMensaje("error", "CONTACTO001", "Debe seleccionar el tipo de contacto");
                return;
            }

            if (string.IsNullOrWhiteSpace(_contactoModal.Valor))
            {
                await MostrarMensaje("error", "CONTACTO002", "Debe ingresar el valor del contacto");
                return;
            }

            var tipo = _tiposMedioContacto
                .FirstOrDefault(t => t.Codigo == _contactoModal.CodigoTipoMedioContacto);

            if (tipo == null)
            {
                await MostrarMensaje("error", "CONTACTO003", "El tipo de contacto seleccionado no es válido");
                return;
            }

            _contactoModal.NombreTipoMedioContacto = tipo.Nombre;

            if (_contactoModal.EsPrincipal)
            {
                foreach (var item in Model.MediosContacto
                    .Where(m => m.CodigoTipoMedioContacto == _contactoModal.CodigoTipoMedioContacto))
                {
                    item.EsPrincipal = false;
                }
            }

            if (_editandoContacto && _contactoEdicion is not null)
            {
                _contactoEdicion.CodigoTipoMedioContacto = _contactoModal.CodigoTipoMedioContacto;
                _contactoEdicion.NombreTipoMedioContacto = _contactoModal.NombreTipoMedioContacto;
                _contactoEdicion.Valor = _contactoModal.Valor;
                _contactoEdicion.EsPrincipal = _contactoModal.EsPrincipal;
            }
            else
            {
                Model.MediosContacto.Add(new ContribuyenteMedioContactoDtoResult
                {
                    CodigoTipoMedioContacto = _contactoModal.CodigoTipoMedioContacto,
                    NombreTipoMedioContacto = _contactoModal.NombreTipoMedioContacto,
                    Valor = _contactoModal.Valor,
                    EsPrincipal = _contactoModal.EsPrincipal,
                    Estado = true
                });
            }

            CerrarModalContacto();
        }

        private void EliminarContacto(ContribuyenteMedioContactoDtoResult contacto)
        {
            if (Model is null)
                return;

            Model.MediosContacto.Remove(contacto);
        }

        private void CerrarModalContacto()
        {
            _mostrarModalContacto = false;
            _editandoContacto = false;
            _contactoEdicion = null;
            _contactoModal = new ContribuyenteMedioContactoDtoResult();
        }

        private async Task OnSubmit()
        {
            if (Model is null)
                return;

            try
            {
                LoadingBorder?.Open();

                var result = await ServicesContribuyente.ActualizarDatosContribuyente(Model);

                LoadingBorder?.Close();

                if (result?.Data is not null && result.Data.ActualizacionCorrecta)
                {
                    await MostrarMensaje(
                        "success",
                        result.Message.Code,
                        result.Message.Description);
                }
                else
                {
                    await MostrarMensaje(
                        "error",
                        result?.Message?.Code ?? "ACTUALIZAR_ERROR",
                        result?.Message?.Description ?? "No fue posible actualizar la información");
                }
            }
            catch
            {
                LoadingBorder?.Close();
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }

        private async Task MostrarMensaje(string tipo, string codigo, string descripcion)
        {
            if (Toast is not null)
                await Toast.ShowMessage(tipo, codigo, descripcion);
        }
    }
}
