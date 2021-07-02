using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Torneos.Modelos;

namespace Torneos.Servicios
{
    public class FirebaseDB
    {
        private FirebaseClient client;

        public FirebaseDB()
        {
            client = new FirebaseClient("https://torneosbaloncesto-d773f-default-rtdb.firebaseio.com/");
        }


        #region TorneoModelo
        public ObservableCollection<TorneoModelo> obtenerTorneos()
        {
            var classData = client
                .Child("Torneos")
                .AsObservable<TorneoModelo>()
                .AsObservableCollection();

            return classData;
        }
        public async Task agregarTorneo(TorneoModelo _torneo)
        {
            await client
                .Child("Torneos")
                .PostAsync(_torneo);
        }
        #endregion

        #region EquipoModelo
        public ObservableCollection<EquipoModelo> obtenerEquipos()
        {
            var classData = client
                .Child("Equipos")
                .AsObservable<EquipoModelo>()
                .AsObservableCollection();

            return classData;
        }

        public async Task agregarEquipo(EquipoModelo _equipo)
        {
            await client
                .Child("Equipos")
                .PostAsync(_equipo);
        }

        public async Task eliminarEquipo(Guid id)
        {
            var equipo = (await client
                .Child("Equipos")
                .OnceAsync<EquipoModelo>()).FirstOrDefault
                (a => a.Object.id == id);
            await client.Child("Equipos").Child(equipo.Key).DeleteAsync();
        }

        public async Task actualizarEquipo(EquipoModelo _equipo)
        {
            var equipo = (await client
                .Child("Equipos")
                .OnceAsync<EquipoModelo>()).Where(a => a.Object.id == _equipo.id).FirstOrDefault();

            await client
                .Child("Equipos")
                .Child(equipo.Key)
                .PutAsync(new EquipoModelo() { id = _equipo.id, nombre = _equipo.nombre, nJugadores = _equipo.nJugadores, tipo = _equipo.tipo, categoria = _equipo.categoria, localidad = _equipo.localidad });
        }

        #endregion
    }
}
