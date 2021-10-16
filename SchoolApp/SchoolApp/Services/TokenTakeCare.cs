using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Services
{
    class TokenTakeCare
    {

        public string Token = "null";

        public string Get()
        {

            return Token;

        }


        public void Set(string token)
        {
            Token = token;
        }

    }
}
