using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadServicios.Utility
{
    public interface IUtility
    {

        public IEncryption Encryption { get; }

        public ISMTP SMTP { get; }

        
    }
    public interface IEncryption
    {
        public string Encrypt(string securityKey, string plainText);
        public string Decrypt(string securityKey, string encryptText);
    }

    public interface ISMTP
    {
        public void Send(string body, string subject, string destination);        
    }
}
