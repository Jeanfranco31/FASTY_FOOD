using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_FASTY_FOOD.Common
{
    public class MessageResponse
    {
        public const string DefaultMessage = "Datos obtenidos correctamente";
        public const string DefaultErrorMessage = "Error al obtener los datos";

        public const string UsernameNotExist = "El nombre de usuario no existe";
        public const string DifferentPassword = "El usuario o contraseña son incorrectos";
        public const string CorrectAuthentication = "Credenciales correctas";
        public const string RolCorrectInsert = "Rol registrado correctamente";
        public const string RolExist = "El rol que intentas ingresar ya existe.";
        public const string UserCreate = "Usuario registrado exitosamente";
        public const string ErrorCreateUser = "No se pudo registrar al usuario";
        public const string NameCompanyNotExist = "La compañia no existe";
        public const string IdentificationNotFound = "La cedula ingresada no existe";
    }
}
