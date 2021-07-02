using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Torneos.Modelos;
using Torneos.Servicios;
using Torneos.VistaModelos;

namespace Torneos.VistaModelos
{
    public class TorneoVistaModelo : BaseVistaModelo
    {
        #region Constructor
        public TorneoVistaModelo()
        {
            servicios = new FirebaseDB();
        }
        #endregion

        #region Atributos
        private FirebaseDB servicios;
        private Guid id;
        private string txtNombre;
        private string txtLugar;
        private string txtFecha;
        private string txtHora;
        private string txtTipoTorneo;
        private string txtCategoria;
        private string txtEquipos;
        private string txtnEquipos;
        #endregion

        #region Propiedades
        public string TxtNombre
        {
            set { SetValue(ref this.txtNombre, value); }
            get { return this.txtNombre; }
        }

        public string TxtLugar
        {
            set { SetValue(ref this.txtLugar, value); }
            get { return this.txtLugar; }
        }

        public string TxtFecha
        {
            set { SetValue(ref this.txtFecha, value); }
            get { return this.txtFecha; }
        }

        public string TxtHora
        {
            set { SetValue(ref this.txtHora, value); }
            get { return this.txtHora; }
        }

        public string TxtTipo
        {
            set { SetValue(ref this.txtTipoTorneo, value); }
            get { return this.txtTipoTorneo; }
        }

        public string TxtCategoria
        {
            set { SetValue(ref this.txtCategoria, value); }
            get { return this.txtCategoria; }
        }

        public string TxtEquipo
        {
            set { SetValue(ref this.txtEquipos, value); }
            get { return this.txtEquipos; }
        }

        public string TxtNEquipos
        {
            set { SetValue(ref this.txtnEquipos, value); }
            get { return this.txtnEquipos; }
        }

        #endregion

        #region Comandos
        public ICommand GuardarTorneoComando
        {
            get
            {
                return new RelayCommand(GuardarTorneoMetodo);
            }
        }
        #endregion

        #region Metodos
        private async void GuardarTorneoMetodo()
        {
            TorneoModelo torneo = new TorneoModelo()
            {
                id = Guid.NewGuid(),
                nombre = TxtNombre,
                lugar = TxtLugar,
                fecha = TxtFecha,
                hora = TxtHora,
                tipoTorneo = TxtTipo,
                categoria = TxtCategoria,
                equipos = "1",
                nEquipos = int.Parse(TxtNEquipos),

            };

            await servicios.agregarTorneo(torneo);

        }
        #endregion
    }
}
