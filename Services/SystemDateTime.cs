using System;
using Member.Interfaces;

namespace Member.Services
{
    #region snippet
    public class SystemDateTime : IDateTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
    #endregion
}
