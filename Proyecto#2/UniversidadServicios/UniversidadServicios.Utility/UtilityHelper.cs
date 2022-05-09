using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Utility.Encryption;
using UniversidadServicios.Utility.SMTP;

namespace UniversidadServicios.Utility
{
    public class UtilityHelper :IUtility
    {

        private readonly Smtp smtp;

        private readonly Encryption_PBKDF2 encryption;

        public UtilityHelper(AppSettings _appSettings)
        {
            encryption = new Encryption_PBKDF2();
            smtp = new Smtp(_appSettings);

        }

        public IEncryption Encryption => encryption;

        public ISMTP SMTP => smtp;
    }
}
